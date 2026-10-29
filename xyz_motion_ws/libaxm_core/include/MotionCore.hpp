#pragma once

#include <vector>
#include <deque>
#include <mutex>
#include <thread>
#include <atomic>
#include <condition_variable>
#include <memory>
#include <cmath>
#include <cstddef>

#include "AXHS.h"
#include "IPCSharedMemory.hpp"
#include "SCurveProfile.hpp"
#include "HomingStateMachine.hpp"
#include "SensorConfig.hpp"

// Node definition for continuous interpolation (Conti)
enum class InterpNodeType {
    LINE_3D,
    CIRCLE_CENTER,
    DWELL
};

struct ContiNode {
    InterpNodeType type;
    double end_pos[3];
    double center_pos[3]; // for circle
    double velocity;
    double accel;
    double decel;
    uint32_t cw_dir;      // 0: CCW, 1: CW
    double dwell_time;    // for dwell
    
    // Computed trajectory properties
    double start_pos[3];
    double length;
    double radius;
    double start_angle;
    double sweep_angle;
};

class MotionCore {
public:
    static MotionCore& getInstance();

    bool open();
    bool close();
    bool isOpened() const;

    // Axis configuration
    int getAxisCount() const { return 3; }
    void setMoveUnitPerPulse(int axis, double unit, long pulse);
    void getMoveUnitPerPulse(int axis, double* unit, long* pulse) const;
    void setUnitPerPulse(int axis, double unit_per_pulse);
    double getUnitPerPulse(int axis) const;
    void setMinVel(int axis, double min_vel);
    double getMinVel(int axis) const;
    void setMaxVel(int axis, double max_vel);
    double getMaxVel(int axis) const;
    void setPulseOutMethod(int axis, uint32_t method);
    uint32_t getPulseOutMethod(int axis) const;
    void setEncInputMethod(int axis, uint32_t method);
    uint32_t getEncInputMethod(int axis) const;
    void setAbsRelMode(int axis, uint32_t mode);
    uint32_t getAbsRelMode(int axis) const;
    void setProfileMode(int axis, uint32_t mode);
    uint32_t getProfileMode(int axis) const;
    void setServoOn(int axis, uint32_t on_off);
    uint32_t isServoOn(int axis) const;

    // Single axis motion (PTP / Jog / Override)
    void movePos(int axis, double pos, double vel, double acc, double dec, bool blocking);
    void moveVel(int axis, double vel, double acc, double dec);
    void moveStop(int axis, double dec);
    void moveEStop(int axis);
    void overridePos(int axis, double pos);
    void overrideVel(int axis, double vel, double acc = 0.0, double dec = 0.0);
    void overrideVelAtPos(int axis, double pos, double vel, double acc, double dec, double ovr_pos, double ovr_vel, long target);

    // Master-Slave Electronic Gear & Gantry Sync
    void setLinkMode(int master, int slave, double ratio);
    void getLinkMode(int master, long* slave, double* ratio) const;
    void resetLinkMode(int master);
    void setGantryEnable(int master, int slave, uint32_t home_use, double offset, double offset_range);
    void getGantryEnable(int master, uint32_t* home_use, double* offset, double* offset_range, uint32_t* gantry_on) const;
    void setGantryDisable(int master, int slave);

    // Signal Search & Hardware Touch Probe Capture (Standard AXT API)
    void moveSignalCapture(int axis, double vel, double acc, long detect_signal, long signal_edge, long target, long signal_method);
    double getCapturePos(int axis) const;

    // Status & Feedback
    double getActPos(int axis) const;
    double getCmdPos(int axis) const;
    double getCmdVel(int axis) const;
    double getActVel(int axis) const;
    double getCmdAcc(int axis) const;
    double getActAcc(int axis) const;
    double getPosError(int axis) const;
    bool isInMotion(int axis) const;
    uint32_t getMotionStatus(int axis) const;
    uint32_t getMechanicalStatus(int axis);

    // 3D Linear, Circular & Helical Interpolation
    void lineMove(double end_x, double end_y, double end_z, double vel, double acc, double dec);
    void circleCenterMove(double cen_x, double cen_y, double end_x, double end_y, double vel, double acc, double dec, uint32_t cw_dir);
    void helixCenterMove(double cen_x, double cen_y, double end_x, double end_y, double end_z, double vel, double acc, double dec, uint32_t cw_dir);

    // Continuous Contouring (Look-ahead)
    void contiSetAxisMap(long coord, long size, const long* axes);
    void contiGetAxisMap(long coord, long* size, long* axes) const;
    void contiResetAxisMap(long coord);
    void contiSetAbsRelMode(long coord, uint32_t mode) { conti_abs_rel_mode_ = mode; }
    uint32_t contiGetAbsRelMode(long coord = 0) const { return conti_abs_rel_mode_; }
    void contiWriteClear(long coord, bool clear_toolpath = true);
    void contiBeginNode(long coord);
    void contiAddNodeLine(long coord, const double* end_pos, double vel, double acc, double dec);
    void contiAddNodeCircleCenter(long coord, const double* cen_pos, const double* end_pos, double vel, double acc, double dec, uint32_t cw_dir);
    void contiAddNodeDwell(long coord, double dwell_time_sec);
    void contiEndNode(long coord);
    void contiStart(long coord, uint32_t profile_mode, uint32_t blend_mode);
    bool contiIsBuilding(long coord = 0) const { return conti_building_; }
    void contiGetTailPos(long coord, double* pos) const;
    long contiGetNodeNum(long coord) const;
    long contiGetTotalNodeNum(long coord) const;
    bool contiIsMotion(long coord) const;
    long getContiAxisCount() const { return conti_axis_count_; }

    // Homing State Machine
    void homeSetMethod(int axis, long hm_dir, DWORD home_signal, DWORD z_phase, double clr_time, double offset);
    void homeGetMethod(int axis, long* hm_dir, DWORD* home_signal, DWORD* z_phase, double* clr_time, double* offset) const;
    void homeSetVel(int axis, double v1, double v2, double v3, double v4, double a1, double a2);
    void homeGetVel(int axis, double* v1, double* v2, double* v3, double* v4, double* a1, double* a2) const;
    void homeStart(int axis);
    void homeSetResult(int axis, DWORD result);
    DWORD homeGetResult(int axis) const;
    void homeGetRate(int axis, DWORD* main_step, DWORD* step_progress) const;

    // Digital I/O & Touch Probe
    DWORD readInput(int axis);
    DWORD readInputBit(int axis, long bit_no);
    void writeOutput(int axis, DWORD value);
    DWORD readOutput(int axis) const;
    void writeOutputBit(int axis, long bit_no, DWORD on_off);
    DWORD readOutputBit(int axis, long bit_no) const;
    void setTriggerPos(int axis, double pos);
    double getTriggerPos(int axis) const;

    // Reset axis position (used by homing or zeroing)
    void setCmdPos(int axis, double pos);
    void setActPos(int axis, double pos);
    void setPosition(int axis, double pos);

private:
    MotionCore();
    ~MotionCore();

    void realtimeLoop();
    void processAxisMotion(double dt);
    void processContiMotion(double dt);
    void processHoming(double dt);
    void processSignalCapture(double dt);
    void updateHardwareIO(double dt);
    bool evalDetectSignal(int axis, long detect_signal);

    std::atomic<bool> is_opened_{false};
    std::atomic<bool> is_running_{false};
    std::thread loop_thread_;

    mutable std::mutex core_mutex_;
    mutable std::mutex conti_mutex_;

    // 3 axes state
    double cmd_pos_[3] = {0.0, 0.0, 0.0};
    double act_pos_[3] = {0.0, 0.0, 0.0};
    double cmd_vel_[3] = {0.0, 0.0, 0.0};
    double act_vel_[3] = {0.0, 0.0, 0.0};
    double cmd_acc_[3] = {0.0, 0.0, 0.0};
    double act_acc_[3] = {0.0, 0.0, 0.0};

    // 20-bit Optical Encoder (2^20 = 1,048,576 pulses/rev) & 2cm (20.0 mm) Ball Screw Lead
    double move_unit_[3] = {20.0, 20.0, 20.0};
    long move_pulse_[3] = {1048576, 1048576, 1048576};
    double unit_per_pulse_[3] = {20.0 / 1048576.0, 20.0 / 1048576.0, 20.0 / 1048576.0};
    double min_vel_[3] = {1.0, 1.0, 1.0};
    double max_vel_[3] = {1000.0, 1000.0, 1000.0};
    uint32_t pulse_method_[3] = {4, 4, 4}; // TwoCcwCwHigh
    uint32_t enc_method_[3] = {3, 3, 3};   // ObverseSqr4Mode
    uint32_t abs_rel_mode_[3] = {0, 0, 0}; // 0: POS_ABS_MODE, 1: POS_REL_MODE
    uint32_t profile_mode_[3] = {3, 3, 3}; // 3: SYM_S_CURVE_MODE
    uint32_t servo_on_[3] = {1, 1, 1};
    uint32_t digital_out_[3] = {0, 0, 0};

    // Signal Capture / Search state per axis
    bool sig_cap_active_[3] = {false, false, false};
    long sig_cap_signal_[3] = {0, 0, 0};
    long sig_cap_edge_[3] = {1, 1, 1};
    long sig_cap_target_[3] = {1, 1, 1};
    long sig_cap_method_[3] = {0, 0, 0};
    bool sig_cap_prev_level_[3] = {false, false, false};
    double captured_pos_[3] = {0.0, 0.0, 0.0};

    // Velocity Override At Position state per axis
    bool ovr_at_pos_active_[3] = {false, false, false};
    double ovr_trigger_pos_[3] = {0.0, 0.0, 0.0};
    double ovr_target_vel_[3] = {0.0, 0.0, 0.0};
    long ovr_target_source_[3] = {0, 0, 0};
    double ovr_start_pos_[3] = {0.0, 0.0, 0.0};

    // Master-Slave Electronic Gear & Gantry Sync state
    long link_slave_[3] = {-1, -1, -1};
    double link_ratio_[3] = {1.0, 1.0, 1.0};
    uint32_t gantry_on_[3] = {0, 0, 0};
    long gantry_slave_[3] = {-1, -1, -1};
    uint32_t gantry_home_use_[3] = {0, 0, 0};
    double gantry_offset_[3] = {0.0, 0.0, 0.0};
    double gantry_range_[3] = {10.0, 10.0, 10.0};

    // Profiles & Homing
    SCurveProfile ptp_profiles_[3];
    HomingStateMachine homing_sm_[3];

    // Dynamic Sensor Config (loaded from sensors_config.yaml)
    RobotSensorsConfig sensor_cfg_;
    double limit_min_[3] = {0.0, 0.0, -300.0};
    double limit_max_[3] = {800.0, 680.0, 60.0};
    double org_pos_[3] = {0.0, 0.0, 0.0};

    void refreshSensorConfig();

    // Continuous Contouring
    bool conti_building_{false};
    std::atomic<bool> conti_running_{false};
    uint32_t conti_abs_rel_mode_{0};
    std::deque<ContiNode> conti_queue_;
    ContiNode active_conti_node_;
    SCurveProfile conti_profile_;
    double conti_node_s_{0.0};
    long conti_axis_map_[3] = {0, 1, 2};
    long conti_axis_count_{3};
    int32_t conti_current_node_index_{0};
    int32_t conti_total_nodes_{0};

    // Touch Probe
    std::atomic<bool> probe_latched_{false};
    std::atomic<double> probe_latched_z_{0.0};

    // High-fidelity physical servo plant state (Gravity, Stribeck Friction, Backlash, Cutting Load & Noise)
    double dyn_pos_[3] = {0.0, 0.0, 0.0};
    double dyn_vel_[3] = {0.0, 0.0, 0.0};
    double dyn_integ_[3] = {0.0, 0.0, 0.0};
    double backlash_play_[3] = {0.0, 0.0, 0.0};
    double sim_time_sec_{0.0};
    bool dyn_initialized_{false};

    // IPC Shared Memory
    IPCSharedMemory shm_;
};
