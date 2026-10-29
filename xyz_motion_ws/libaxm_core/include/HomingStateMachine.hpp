#pragma once

#include <cstdint>
#include <cmath>
#include <chrono>
#include <iostream>
#include <algorithm>
#include "SCurveProfile.hpp"

// Standard Ajinextek Homing Constants
#ifndef HOME_SUCCESS
#define HOME_SUCCESS        0x01
#endif
#ifndef HOME_SEARCHING
#define HOME_SEARCHING      0x02
#endif
#ifndef HOME_ERR_USER_BREAK
#define HOME_ERR_USER_BREAK 0x11
#endif
#ifndef HOME_ERR_NEG_LIMIT
#define HOME_ERR_NEG_LIMIT  0x14
#endif
#ifndef HOME_ERR_POS_LIMIT
#define HOME_ERR_POS_LIMIT  0x15
#endif

enum class HomeStep {
    IDLE = 0,
    STEP1_FAST_SEARCH = 1,
    STEP2_STOP_DECEL = 2,
    STEP3_LEAVE_SLOW = 3,
    STEP4_EDGE_DETECT = 4,
    STEP5_ZPHASE_SEARCH = 5,
    STEP6_OFFSET_MOVE = 6,
    STEP7_CLEAR_POS = 7,
    DONE = 8,
    ERROR = 9
};

class HomingStateMachine {
public:
    HomingStateMachine(int axis_no = 0)
        : axis_no_(axis_no), hm_dir_(0), home_signal_(4), z_phase_(1),
          home_clr_time_ms_(100.0), home_offset_(0.0),
          home_org_(0.0),
          limit_min_((axis_no == 2) ? -300.0 : 0.0),
          limit_max_((axis_no == 2) ? 60.0 : 800.0),
          latched_origin_pos_(0.0),
          target_pos_(0.0),
          vel_first_(60.0), vel_second_(20.0), vel_third_(5.0), vel_last_(1.0),
          acc_first_(200.0), acc_second_(100.0),
          current_step_(HomeStep::IDLE), home_result_(0),
          dwell_timer_ms_(0.0), step_progress_(0) {}

    void set_sensor_config(double home_org, double limit_min, double limit_max) {
        home_org_ = home_org;
        limit_min_ = limit_min;
        limit_max_ = limit_max;
        target_pos_ = home_org;
        latched_origin_pos_ = home_org;
    }

    void set_method(long hm_dir, uint32_t home_signal, uint32_t z_phase, double clr_time, double offset) {
        hm_dir_ = hm_dir;
        home_signal_ = home_signal;
        z_phase_ = z_phase;
        home_clr_time_ms_ = clr_time;
        home_offset_ = offset;
    }

    void get_method(long* hm_dir, uint32_t* home_signal, uint32_t* z_phase, double* clr_time, double* offset) const {
        if (hm_dir) *hm_dir = hm_dir_;
        if (home_signal) *home_signal = home_signal_;
        if (z_phase) *z_phase = z_phase_;
        if (clr_time) *clr_time = home_clr_time_ms_;
        if (offset) *offset = home_offset_;
    }

    void set_vel(double v1, double v2, double v3, double v4, double a1, double a2) {
        vel_first_ = v1;
        vel_second_ = v2;
        vel_third_ = v3;
        vel_last_ = v4;
        acc_first_ = a1;
        acc_second_ = a2;
    }

    void get_vel(double* v1, double* v2, double* v3, double* v4, double* a1, double* a2) const {
        if (v1) *v1 = vel_first_;
        if (v2) *v2 = vel_second_;
        if (v3) *v3 = vel_third_;
        if (v4) *v4 = vel_last_;
        if (a1) *a1 = acc_first_;
        if (a2) *a2 = acc_second_;
    }

    void set_result(uint32_t res) {
        home_result_ = res;
    }

    void start(double cur_pos) {
        current_step_ = HomeStep::STEP1_FAST_SEARCH;
        home_result_ = HOME_SEARCHING;
        step_progress_ = 10;
        target_pos_ = home_org_;
        latched_origin_pos_ = home_org_;
        
        // Direction multiplier: hm_dir_ == 1 (CW / positive), hm_dir_ == 0 (CCW / negative)
        double dir_mult = (hm_dir_ == 1) ? 1.0 : -1.0;
        profile_.plan_velocity(cur_pos, dir_mult * vel_first_, acc_first_, acc_first_);
    }

    void stop() {
        profile_.estop();
        current_step_ = HomeStep::IDLE;
        home_result_ = HOME_ERR_USER_BREAK;
    }

    bool update(double dt, double& cur_pos, double& cur_vel, bool org_sensor_active) {
        double dummy_acc = 0.0;
        return update(dt, cur_pos, cur_vel, dummy_acc, org_sensor_active);
    }

    bool update(double dt, double& cur_pos, double& cur_vel, double& cur_acc, bool org_sensor_active) {
        if (current_step_ == HomeStep::IDLE || current_step_ == HomeStep::DONE || current_step_ == HomeStep::ERROR) {
            cur_acc = 0.0;
            return false;
        }

        double dir_mult = (hm_dir_ == 1) ? 1.0 : -1.0;

        switch (current_step_) {
            case HomeStep::STEP1_FAST_SEARCH: {
                double target_stroke = (hm_dir_ == 1) ? limit_max_ : limit_min_;
                double total = std::max(1.0, limit_max_ - limit_min_);
                double span = std::clamp(std::abs(target_stroke - cur_pos), 0.0, total);
                double pct = std::clamp(10.0 + 20.0 * (1.0 - span / total), 10.0, 30.0);
                step_progress_ = static_cast<uint32_t>(pct);

                profile_.update(dt, cur_pos, cur_vel, cur_acc);
                if (org_sensor_active || (hm_dir_ != 1 && cur_pos <= limit_min_ + 1.0) || (hm_dir_ == 1 && cur_pos >= limit_max_ - 1.0)) {
                    // Reached ORG sensor or stroke boundary
                    current_step_ = HomeStep::STEP2_STOP_DECEL;
                    profile_.stop(acc_first_);
                }
                break;
            }

            case HomeStep::STEP2_STOP_DECEL: {
                step_progress_ = 35;
                bool moving = profile_.update(dt, cur_pos, cur_vel, cur_acc);
                if (!moving || std::abs(cur_vel) < 0.01) {
                    // Stopped. Step 3: reverse direction slowly to leave ORG
                    current_step_ = HomeStep::STEP3_LEAVE_SLOW;
                    profile_.plan_velocity(cur_pos, -dir_mult * vel_second_, acc_second_, acc_second_);
                }
                break;
            }

            case HomeStep::STEP3_LEAVE_SLOW: {
                step_progress_ = 50;
                profile_.update(dt, cur_pos, cur_vel, cur_acc);
                if (!org_sensor_active) {
                    // Falling edge of ORG
                    current_step_ = HomeStep::STEP4_EDGE_DETECT;
                    profile_.plan_velocity(cur_pos, dir_mult * vel_third_, acc_second_, acc_second_);
                }
                break;
            }

            case HomeStep::STEP4_EDGE_DETECT: {
                step_progress_ = 65;
                profile_.update(dt, cur_pos, cur_vel, cur_acc);
                if (org_sensor_active || (hm_dir_ == 1 && cur_pos >= home_org_ - 0.5) || (hm_dir_ != 1 && cur_pos <= home_org_ + 0.5)) {
                    // Rising edge detected at the home origin sensor position
                    latched_origin_pos_ = home_org_;
                    current_step_ = HomeStep::STEP5_ZPHASE_SEARCH;
                    profile_.stop(acc_second_);
                }
                break;
            }

            case HomeStep::STEP5_ZPHASE_SEARCH: {
                step_progress_ = 80;
                bool moving = profile_.update(dt, cur_pos, cur_vel, cur_acc);
                if (!moving || std::abs(cur_vel) < 0.01) {
                    // Stopped at origin switch edge.
                    // Advance to Step 6: Smoothly move to final safe Home target
                    current_step_ = HomeStep::STEP6_OFFSET_MOVE;
                    if (std::abs(home_offset_) < 1e-4) {
                        target_pos_ = home_org_;
                    } else {
                        // Offset moves into safe interior of workspace away from the sensor/limit
                        target_pos_ = home_org_ - dir_mult * std::abs(home_offset_);
                    }
                    target_pos_ = std::clamp(target_pos_, limit_min_, limit_max_);
                    profile_.plan(cur_pos, target_pos_, vel_second_, acc_second_, acc_second_, false);
                }
                break;
            }

            case HomeStep::STEP6_OFFSET_MOVE: {
                step_progress_ = 90;
                bool moving = profile_.update(dt, cur_pos, cur_vel, cur_acc);
                if (!moving || std::abs(cur_vel) < 0.001) {
                    cur_pos = target_pos_;
                    current_step_ = HomeStep::STEP7_CLEAR_POS;
                    dwell_timer_ms_ = 0.0;
                    cur_vel = 0.0;
                    cur_acc = 0.0;
                }
                break;
            }

            case HomeStep::STEP7_CLEAR_POS: {
                step_progress_ = 98;
                dwell_timer_ms_ += dt * 1000.0;
                cur_vel = 0.0;
                cur_acc = 0.0;
                cur_pos = target_pos_;
                if (dwell_timer_ms_ >= home_clr_time_ms_) {
                    cur_pos = target_pos_;
                    current_step_ = HomeStep::DONE;
                    home_result_ = HOME_SUCCESS;
                    step_progress_ = 100;
                    return false;
                }
                break;
            }

            default:
                break;
        }

        return true;
    }

    double get_target_pos() const { return target_pos_; }
    uint32_t get_result() const { return home_result_; }
    uint32_t get_main_step() const { return static_cast<uint32_t>(current_step_); }
    uint32_t get_step_progress() const { return step_progress_; }
    void get_rate(uint32_t* main_step, uint32_t* step_progress) const {
        if (main_step) *main_step = static_cast<uint32_t>(current_step_);
        if (step_progress) *step_progress = step_progress_;
    }
    bool is_busy() const {
        return (current_step_ != HomeStep::IDLE && current_step_ != HomeStep::DONE && current_step_ != HomeStep::ERROR);
    }

private:
    int axis_no_;
    long hm_dir_;
    uint32_t home_signal_;
    uint32_t z_phase_;
    double home_clr_time_ms_;
    double home_offset_;

    double home_org_;
    double limit_min_;
    double limit_max_;
    double latched_origin_pos_;
    double target_pos_;

    double vel_first_;
    double vel_second_;
    double vel_third_;
    double vel_last_;
    double acc_first_;
    double acc_second_;

    HomeStep current_step_;
    uint32_t home_result_;
    double dwell_timer_ms_;
    uint32_t step_progress_;

    SCurveProfile profile_;
};
