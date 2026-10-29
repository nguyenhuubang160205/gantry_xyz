#pragma once

#include <cmath>
#include <algorithm>
#include <iostream>

class SCurveProfile {
public:
    enum class ProfileState {
        IDLE,
        ACCEL_RAMP_UP,   // T1: Jerk = +J
        ACCEL_CONST,     // T2: Jerk = 0, Accel = +A
        ACCEL_RAMP_DOWN, // T3: Jerk = -J
        CRUISE,          // T4: Accel = 0, Vel = Vmax
        DECEL_RAMP_UP,   // T5: Jerk = -J
        DECEL_CONST,     // T6: Jerk = 0, Accel = -D
        DECEL_RAMP_DOWN, // T7: Jerk = +J
        FINISHED
    };

    SCurveProfile()
        : start_pos_(0.0), target_pos_(0.0), cur_pos_(0.0),
          cur_vel_(0.0), cur_acc_(0.0), target_vel_(0.0),
          max_acc_(2500.0), max_dec_(2500.0), jerk_(50000.0),
          t_acc_(0.0), t_cruise_(0.0), t_dec_(0.0),
          total_time_(0.0), elapsed_time_(0.0),
          dir_(1.0), is_active_(false), is_velocity_mode_(false),
          is_overridden_(false), use_scurve_(true) {}

    void plan(double start_pos, double target_pos, double max_vel, double max_acc, double max_dec, bool use_scurve = true) {
        start_pos_ = start_pos;
        target_pos_ = target_pos;
        cur_pos_ = start_pos;
        cur_vel_ = 0.0;
        cur_acc_ = 0.0;
        elapsed_time_ = 0.0;
        is_velocity_mode_ = false;
        is_overridden_ = false;
        use_scurve_ = use_scurve;

        double dist = target_pos_ - start_pos_;
        if (std::abs(dist) < 1e-6) {
            is_active_ = false;
            return;
        }

        dir_ = (dist > 0.0) ? 1.0 : -1.0;
        double total_dist = std::abs(dist);

        max_vel = std::max(1.0, std::abs(max_vel));
        max_acc_ = std::max(10.0, std::abs(max_acc));
        max_dec_ = std::max(10.0, std::abs(max_dec));

        double tj = std::min(0.04, max_vel / (2.0 * max_acc_));
        jerk_ = max_acc_ / std::max(1e-4, tj);

        t_acc_ = max_vel / max_acc_;
        double d_acc = 0.5 * max_acc_ * t_acc_ * t_acc_;

        t_dec_ = max_vel / max_dec_;
        double d_dec = 0.5 * max_dec_ * t_dec_ * t_dec_;

        if (d_acc + d_dec > total_dist) {
            // Triangle / short-stroke profile
            max_vel = std::sqrt(2.0 * total_dist * (max_acc_ * max_dec_) / (max_acc_ + max_dec_));
            t_acc_ = max_vel / max_acc_;
            t_dec_ = max_vel / max_dec_;
            t_cruise_ = 0.0;
        } else {
            t_cruise_ = (total_dist - (d_acc + d_dec)) / max_vel;
        }
        target_vel_ = max_vel;
        total_time_ = t_acc_ + t_cruise_ + t_dec_;

        is_active_ = true;
    }

    void plan_velocity(double cur_pos, double target_vel, double max_acc, double max_dec) {
        start_pos_ = cur_pos;
        cur_pos_ = cur_pos;
        target_vel_ = target_vel;
        max_acc_ = std::max(10.0, std::abs(max_acc));
        max_dec_ = std::max(10.0, std::abs(max_dec));
        is_velocity_mode_ = true;
        is_active_ = true;
    }

    void stop(double decel) {
        if (std::abs(decel) > 10.0) {
            max_dec_ = std::abs(decel);
        }
        if (!is_active_) return;
        // Switch smoothly to deceleration ramp down to zero velocity without position discontinuity
        is_velocity_mode_ = true;
        target_vel_ = 0.0;
    }

    void estop() {
        cur_vel_ = 0.0;
        cur_acc_ = 0.0;
        is_active_ = false;
    }

    bool update(double dt, double& out_pos, double& out_vel) {
        double dummy_acc = 0.0;
        return update(dt, out_pos, out_vel, dummy_acc);
    }

    bool update(double dt, double& out_pos, double& out_vel, double& out_acc) {
        if (!is_active_) {
            cur_vel_ = 0.0;
            cur_acc_ = 0.0;
            out_pos = cur_pos_;
            out_vel = 0.0;
            out_acc = 0.0;
            return false;
        }

        if (is_velocity_mode_) {
            double prev_vel = cur_vel_;
            if (cur_vel_ < target_vel_) {
                double rate = (std::abs(target_vel_) < 1e-4) ? max_dec_ : max_acc_;
                cur_vel_ = std::min(target_vel_, cur_vel_ + rate * dt);
            } else if (cur_vel_ > target_vel_) {
                double rate = (std::abs(target_vel_) < 1e-4) ? max_dec_ : max_dec_;
                cur_vel_ = std::max(target_vel_, cur_vel_ - rate * dt);
            }
            cur_acc_ = (dt > 1e-7) ? ((cur_vel_ - prev_vel) / dt) : 0.0;
            cur_pos_ += 0.5 * (prev_vel + cur_vel_) * dt;
            out_pos = cur_pos_;
            out_vel = cur_vel_;
            out_acc = cur_acc_;

            if (std::abs(target_vel_) < 1e-4 && std::abs(cur_vel_) < 1e-4) {
                is_active_ = false;
                cur_vel_ = 0.0;
                cur_acc_ = 0.0;
                out_vel = 0.0;
                out_acc = 0.0;
                return false;
            }
            return true;
        }

        if (is_overridden_) {
            double rem = target_pos_ - cur_pos_;
            dir_ = (rem >= 0.0) ? 1.0 : -1.0;
            double dist_rem = std::abs(rem);
            double v = std::abs(cur_vel_);
            double prev_v = v;
            double d_stop = (v * v) / (2.0 * std::max(10.0, max_dec_));

            if (dist_rem <= 1e-3 || (dist_rem <= d_stop + 1e-3 && v <= 0.05)) {
                cur_pos_ = target_pos_;
                cur_vel_ = 0.0;
                cur_acc_ = 0.0;
                is_active_ = false;
                is_overridden_ = false;
                out_pos = cur_pos_;
                out_vel = 0.0;
                out_acc = 0.0;
                return false;
            }

            if (dist_rem <= d_stop) {
                double req_dec = (v * v) / std::max(1e-6, 2.0 * dist_rem);
                v = std::max(0.0, v - req_dec * dt);
            } else if (v < target_vel_) {
                v = std::min(target_vel_, v + max_acc_ * dt);
            } else if (v > target_vel_) {
                v = std::max(target_vel_, v - max_dec_ * dt);
            }

            double a = (dt > 1e-7) ? ((v - prev_v) / dt) : 0.0;
            double ds = 0.5 * (prev_v + v) * dt;
            if (ds >= dist_rem) {
                cur_pos_ = target_pos_;
                cur_vel_ = 0.0;
                cur_acc_ = 0.0;
                is_active_ = false;
                is_overridden_ = false;
                out_pos = cur_pos_;
                out_vel = 0.0;
                out_acc = 0.0;
                return false;
            }
            cur_pos_ += dir_ * ds;
            cur_vel_ = dir_ * v;
            cur_acc_ = dir_ * a;
            out_pos = cur_pos_;
            out_vel = cur_vel_;
            out_acc = cur_acc_;
            return true;
        }

        // Positional profile calculation
        elapsed_time_ += dt;
        if (elapsed_time_ >= total_time_) {
            cur_pos_ = target_pos_;
            cur_vel_ = 0.0;
            cur_acc_ = 0.0;
            is_active_ = false;
            out_pos = cur_pos_;
            out_vel = 0.0;
            out_acc = 0.0;
            return false;
        }

        double t = elapsed_time_;
        double s = 0.0;
        double v = 0.0;
        double a = 0.0;

        if (use_scurve_) {
            if (t < t_acc_) {
                double ratio = std::min(1.0, t / std::max(1e-6, t_acc_));
                double smooth_ratio = ratio * ratio * (3.0 - 2.0 * ratio);
                v = target_vel_ * smooth_ratio;
                a = (target_vel_ / std::max(1e-6, t_acc_)) * 6.0 * ratio * (1.0 - ratio);
                s = target_vel_ * t_acc_ * (ratio * ratio * ratio - 0.5 * ratio * ratio * ratio * ratio);
            } else if (t < t_acc_ + t_cruise_) {
                double s_acc = 0.5 * target_vel_ * t_acc_;
                double t_c = t - t_acc_;
                v = target_vel_;
                a = 0.0;
                s = s_acc + target_vel_ * t_c;
            } else {
                double s_acc = 0.5 * target_vel_ * t_acc_;
                double s_cruise = target_vel_ * t_cruise_;
                double t_d = t - (t_acc_ + t_cruise_);
                double ratio = std::min(1.0, t_d / std::max(1e-6, t_dec_));
                double smooth_ratio = 1.0 - (ratio * ratio * (3.0 - 2.0 * ratio));
                v = target_vel_ * smooth_ratio;
                a = -(target_vel_ / std::max(1e-6, t_dec_)) * 6.0 * ratio * (1.0 - ratio);
                double s_dec = target_vel_ * t_dec_ * (ratio - ratio * ratio * ratio + 0.5 * ratio * ratio * ratio * ratio);
                s = s_acc + s_cruise + s_dec;
            }
        } else {
            // Trapezoidal (T-Curve)
            if (t < t_acc_) {
                a = max_acc_;
                v = max_acc_ * t;
                s = 0.5 * max_acc_ * t * t;
            } else if (t < t_acc_ + t_cruise_) {
                double s_acc = 0.5 * target_vel_ * t_acc_;
                double t_c = t - t_acc_;
                a = 0.0;
                v = target_vel_;
                s = s_acc + target_vel_ * t_c;
            } else {
                double s_acc = 0.5 * target_vel_ * t_acc_;
                double s_cruise = target_vel_ * t_cruise_;
                double t_d = t - (t_acc_ + t_cruise_);
                a = -max_dec_;
                v = std::max(0.0, target_vel_ - max_dec_ * t_d);
                s = s_acc + s_cruise + target_vel_ * t_d - 0.5 * max_dec_ * t_d * t_d;
            }
        }

        cur_vel_ = dir_ * v;
        cur_acc_ = dir_ * a;
        cur_pos_ = start_pos_ + dir_ * s;
        out_pos = cur_pos_;
        out_vel = cur_vel_;
        out_acc = cur_acc_;

        return true;
    }

    bool is_active() const { return is_active_; }
    double current_pos() const { return cur_pos_; }
    double current_vel() const { return cur_vel_; }
    double current_acc() const { return cur_acc_; }
    double target_pos() const { return target_pos_; }
    double target_vel() const { return target_vel_; }
    double max_acc() const { return max_acc_; }
    double max_dec() const { return max_dec_; }

    void override_vel(double new_vel, double new_acc = 0.0, double new_dec = 0.0) {
        if (!is_active_) return;
        double acc = (new_acc > 10.0) ? new_acc : max_acc_;
        double dec = (new_dec > 10.0) ? new_dec : max_dec_;
        if (is_velocity_mode_) {
            target_vel_ = (target_vel_ >= 0.0) ? std::abs(new_vel) : -std::abs(new_vel);
            max_acc_ = acc;
            max_dec_ = dec;
        } else {
            target_vel_ = std::max(1.0, std::abs(new_vel));
            max_acc_ = acc;
            max_dec_ = dec;
            is_overridden_ = true;
        }
    }

    void override_pos(double new_target_pos) {
        if (!is_active_ || is_velocity_mode_) return;
        target_pos_ = new_target_pos;
        is_overridden_ = true;
    }

    void set_pos(double pos) {
        cur_pos_ = pos;
        start_pos_ = pos;
        target_pos_ = pos;
        cur_vel_ = 0.0;
        cur_acc_ = 0.0;
        is_overridden_ = false;
    }

private:
    double start_pos_;
    double target_pos_;
    double cur_pos_;
    double cur_vel_;
    double cur_acc_;

    double target_vel_;
    double max_acc_;
    double max_dec_;
    double jerk_;

    double t_acc_;
    double t_cruise_;
    double t_dec_;
    double total_time_;
    double elapsed_time_;

    double dir_;
    bool is_active_;
    bool is_velocity_mode_;
    bool is_overridden_;
    bool use_scurve_;
};
