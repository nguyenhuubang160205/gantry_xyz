#include "MotionCore.hpp"
#include <chrono>
#include <iostream>
#include <random>

MotionCore::MotionCore() {
    for (int i = 0; i < 3; ++i) {
        homing_sm_[i] = HomingStateMachine(i);
        cmd_pos_[i] = 0.0;
        act_pos_[i] = 0.0;
        cmd_vel_[i] = 0.0;
        act_vel_[i] = 0.0;
        cmd_acc_[i] = 0.0;
        act_acc_[i] = 0.0;
    }
}

MotionCore::~MotionCore() {
    close();
}

MotionCore& MotionCore::getInstance() {
    static MotionCore instance;
    return instance;
}

void MotionCore::refreshSensorConfig() {
    if (sensor_cfg_.loadFromFile()) {
        for (int i = 0; i < 3; ++i) {
            limit_min_[i] = sensor_cfg_.axis[i].limit_min;
            limit_max_[i] = sensor_cfg_.axis[i].limit_max;
            org_pos_[i] = sensor_cfg_.axis[i].home_org;
            homing_sm_[i].set_sensor_config(org_pos_[i], limit_min_[i], limit_max_[i]);
        }
    }
}

bool MotionCore::open() {
    std::lock_guard<std::mutex> lock(core_mutex_);
    if (is_opened_) return true;

    refreshSensorConfig();

    if (!shm_.init(true)) {
        std::cerr << "[MotionCore] Failed to initialize shared memory IPC" << std::endl;
        return false;
    }

    MotionSharedData* data = shm_.get();
    if (data) {
        data->toolpath_epoch++;
        for (int i = 0; i < 3; ++i) {
            if (data->actual_pos[i] >= -350.0 && data->actual_pos[i] <= 850.0) {
                cmd_pos_[i] = data->actual_pos[i];
                act_pos_[i] = data->actual_pos[i];
                ptp_profiles_[i].set_pos(cmd_pos_[i]);
            } else {
                cmd_pos_[i] = 0.0;
                act_pos_[i] = 0.0;
                data->target_pos[i] = 0.0;
                data->actual_pos[i] = 0.0;
                ptp_profiles_[i].set_pos(0.0);
            }
            cmd_vel_[i] = 0.0;
            act_vel_[i] = 0.0;
            cmd_acc_[i] = 0.0;
            act_acc_[i] = 0.0;
            dyn_pos_[i] = cmd_pos_[i];
            dyn_vel_[i] = 0.0;
            backlash_play_[i] = cmd_pos_[i];
            dyn_integ_[i] = (i == 2) ? (0.96 * 9810.0) : 0.0;
        }
        dyn_initialized_ = true;
    }

    is_opened_ = true;
    is_running_ = true;
    loop_thread_ = std::thread(&MotionCore::realtimeLoop, this);
    std::cout << "[MotionCore] Realtime 1ms CSP Motion Core initialized successfully." << std::endl;
    return true;
}

bool MotionCore::close() {
    if (!is_opened_) return true;

    is_running_ = false;
    if (loop_thread_.joinable()) {
        loop_thread_.join();
    }

    shm_.close();
    is_opened_ = false;
    std::cout << "[MotionCore] Motion Core closed cleanly." << std::endl;
    return true;
}

bool MotionCore::isOpened() const {
    return is_opened_;
}

void MotionCore::setMoveUnitPerPulse(int axis, double unit, long pulse) {
    if (axis >= 0 && axis < 3 && unit > 0.0 && pulse > 0) {
        move_unit_[axis] = unit;
        move_pulse_[axis] = pulse;
        unit_per_pulse_[axis] = unit / static_cast<double>(pulse);
    }
}

void MotionCore::getMoveUnitPerPulse(int axis, double* unit, long* pulse) const {
    if (axis >= 0 && axis < 3) {
        if (unit) *unit = move_unit_[axis];
        if (pulse) *pulse = move_pulse_[axis];
    }
}

void MotionCore::setUnitPerPulse(int axis, double unit_per_pulse) {
    if (axis >= 0 && axis < 3 && unit_per_pulse > 0.0) {
        unit_per_pulse_[axis] = unit_per_pulse;
    }
}

double MotionCore::getUnitPerPulse(int axis) const {
    if (axis >= 0 && axis < 3) return unit_per_pulse_[axis];
    return 20.0 / 1048576.0;
}

void MotionCore::setMinVel(int axis, double min_vel) {
    if (axis >= 0 && axis < 3) min_vel_[axis] = min_vel;
}

double MotionCore::getMinVel(int axis) const {
    if (axis >= 0 && axis < 3) return min_vel_[axis];
    return 1.0;
}

void MotionCore::setMaxVel(int axis, double max_vel) {
    if (axis >= 0 && axis < 3 && max_vel > 0.0) max_vel_[axis] = max_vel;
}

double MotionCore::getMaxVel(int axis) const {
    if (axis >= 0 && axis < 3) return max_vel_[axis];
    return 1000.0;
}

void MotionCore::setPulseOutMethod(int axis, uint32_t method) {
    if (axis >= 0 && axis < 3) pulse_method_[axis] = method;
}

uint32_t MotionCore::getPulseOutMethod(int axis) const {
    if (axis >= 0 && axis < 3) return pulse_method_[axis];
    return 4;
}

void MotionCore::setEncInputMethod(int axis, uint32_t method) {
    if (axis >= 0 && axis < 3) enc_method_[axis] = method;
}

uint32_t MotionCore::getEncInputMethod(int axis) const {
    if (axis >= 0 && axis < 3) return enc_method_[axis];
    return 3;
}

void MotionCore::setAbsRelMode(int axis, uint32_t mode) {
    if (axis >= 0 && axis < 3) abs_rel_mode_[axis] = mode;
}

uint32_t MotionCore::getAbsRelMode(int axis) const {
    if (axis >= 0 && axis < 3) return abs_rel_mode_[axis];
    return 0;
}

void MotionCore::setProfileMode(int axis, uint32_t mode) {
    if (axis >= 0 && axis < 3) profile_mode_[axis] = mode;
}

uint32_t MotionCore::getProfileMode(int axis) const {
    if (axis >= 0 && axis < 3) return profile_mode_[axis];
    return 3;
}

void MotionCore::setServoOn(int axis, uint32_t on_off) {
    if (axis >= 0 && axis < 3) servo_on_[axis] = on_off;
}

uint32_t MotionCore::isServoOn(int axis) const {
    if (axis >= 0 && axis < 3) return servo_on_[axis];
    return 0;
}

void MotionCore::movePos(int axis, double pos, double vel, double acc, double dec, bool blocking) {
    if (axis < 0 || axis >= 3) return;

    {
        std::lock_guard<std::mutex> lock(core_mutex_);
        // Apply per-axis Abs/Rel mode (POS_ABS_MODE = 0, POS_REL_MODE = 1)
        double target = (abs_rel_mode_[axis] == 1) ? (cmd_pos_[axis] + pos) : pos;
        target = std::clamp(target, limit_min_[axis], limit_max_[axis]);

        // Profile mode: 0,1 = Trapezoidal; 2,3,4 = S-Curve
        bool use_scurve = (profile_mode_[axis] >= 2);
        sig_cap_active_[axis] = false;
        ptp_profiles_[axis].plan(cmd_pos_[axis], target, vel, acc, dec, use_scurve);
    }

    if (blocking) {
        while (isInMotion(axis)) {
            std::this_thread::sleep_for(std::chrono::milliseconds(2));
        }
    }
}

void MotionCore::moveVel(int axis, double vel, double acc, double dec) {
    if (axis < 0 || axis >= 3) return;
    std::lock_guard<std::mutex> lock(core_mutex_);
    sig_cap_active_[axis] = false;
    ptp_profiles_[axis].plan_velocity(cmd_pos_[axis], vel, acc, dec);
}

void MotionCore::moveStop(int axis, double dec) {
    if (axis < 0 || axis >= 3) return;
    std::lock_guard<std::mutex> lock(core_mutex_);
    sig_cap_active_[axis] = false;
    ptp_profiles_[axis].stop(dec);
}

void MotionCore::moveEStop(int axis) {
    if (axis < 0 || axis >= 3) return;
    std::lock_guard<std::mutex> lock(core_mutex_);
    sig_cap_active_[axis] = false;
    ovr_at_pos_active_[axis] = false;
    ptp_profiles_[axis].estop();
    cmd_vel_[axis] = 0.0;
    cmd_acc_[axis] = 0.0;
}

void MotionCore::overridePos(int axis, double pos) {
    if (axis < 0 || axis >= 3) return;
    std::lock_guard<std::mutex> lock(core_mutex_);
    double target = (abs_rel_mode_[axis] == 1) ? (cmd_pos_[axis] + pos) : pos;
    target = std::clamp(target, limit_min_[axis], limit_max_[axis]);
    ptp_profiles_[axis].override_pos(target);
}

void MotionCore::overrideVel(int axis, double vel, double acc, double dec) {
    if (axis < 0 || axis >= 3) return;
    std::lock_guard<std::mutex> lock(core_mutex_);
    ptp_profiles_[axis].override_vel(vel, acc, dec);
}

void MotionCore::overrideVelAtPos(int axis, double pos, double vel, double acc, double dec, double ovr_pos, double ovr_vel, long target) {
    if (axis < 0 || axis >= 3) return;
    std::lock_guard<std::mutex> lock(core_mutex_);
    double target_p = (abs_rel_mode_[axis] == 1) ? (cmd_pos_[axis] + pos) : pos;
    target_p = std::clamp(target_p, limit_min_[axis], limit_max_[axis]);
    bool use_scurve = (profile_mode_[axis] >= 2);
    sig_cap_active_[axis] = false;
    ovr_start_pos_[axis] = cmd_pos_[axis];
    ovr_trigger_pos_[axis] = (abs_rel_mode_[axis] == 1) ? (cmd_pos_[axis] + ovr_pos) : ovr_pos;
    ovr_target_vel_[axis] = ovr_vel;
    ovr_target_source_[axis] = target;
    ovr_at_pos_active_[axis] = true;
    ptp_profiles_[axis].plan(cmd_pos_[axis], target_p, vel, acc, dec, use_scurve);
}

void MotionCore::setLinkMode(int master, int slave, double ratio) {
    if (master < 0 || master >= 3) return;
    std::lock_guard<std::mutex> lock(core_mutex_);
    link_slave_[master] = (slave >= 0 && slave < 3 && slave != master) ? slave : -1;
    link_ratio_[master] = ratio;
}

void MotionCore::getLinkMode(int master, long* slave, double* ratio) const {
    if (master < 0 || master >= 3) return;
    std::lock_guard<std::mutex> lock(core_mutex_);
    if (slave) *slave = link_slave_[master];
    if (ratio) *ratio = link_ratio_[master];
}

void MotionCore::resetLinkMode(int master) {
    if (master < 0 || master >= 3) return;
    std::lock_guard<std::mutex> lock(core_mutex_);
    link_slave_[master] = -1;
}

void MotionCore::setGantryEnable(int master, int slave, uint32_t home_use, double offset, double offset_range) {
    if (master < 0 || master >= 3) return;
    std::lock_guard<std::mutex> lock(core_mutex_);
    gantry_on_[master] = 1;
    gantry_slave_[master] = (slave >= 0 && slave < 3 && slave != master) ? slave : -1;
    gantry_home_use_[master] = home_use;
    gantry_offset_[master] = offset;
    gantry_range_[master] = offset_range;
}

void MotionCore::getGantryEnable(int master, uint32_t* home_use, double* offset, double* offset_range, uint32_t* gantry_on) const {
    if (master < 0 || master >= 3) return;
    std::lock_guard<std::mutex> lock(core_mutex_);
    if (home_use) *home_use = gantry_home_use_[master];
    if (offset) *offset = gantry_offset_[master];
    if (offset_range) *offset_range = gantry_range_[master];
    if (gantry_on) *gantry_on = gantry_on_[master];
}

void MotionCore::setGantryDisable(int master, int slave) {
    (void)slave;
    if (master < 0 || master >= 3) return;
    std::lock_guard<std::mutex> lock(core_mutex_);
    gantry_on_[master] = 0;
    gantry_slave_[master] = -1;
}

bool MotionCore::evalDetectSignal(int axis, long detect_signal) {
    // Standard AXT_MOTION_HOME_DETECT_SIGNAL / QIDETECT_DESTINATION_SIGNAL:
    // 0: PosEndLimit (+Limit, bit 2)
    // 1: NegEndLimit (-Limit, bit 1)
    // 4: HomeSensor  (ORG, bit 3)
    // 5: EncodZPhase (Z-phase)
    // 6..9: Universal Input (Touch Probe on bit 0)
    switch (detect_signal) {
        case 0: return readInputBit(axis, 2) == 1;
        case 1: return readInputBit(axis, 1) == 1;
        case 4: return readInputBit(axis, 3) == 1;
        default: return readInputBit(axis, 0) == 1; // Touch Probe / Universal Input
    }
}

void MotionCore::moveSignalCapture(int axis, double vel, double acc, long detect_signal, long signal_edge, long target, long signal_method) {
    if (axis < 0 || axis >= 3) return;
    std::lock_guard<std::mutex> lock(core_mutex_);
    if (axis == 2) {
        probe_latched_ = false;
        MotionSharedData* data = shm_.get();
        if (data) data->probe_triggered = false;
    }
    sig_cap_signal_[axis] = detect_signal;
    sig_cap_edge_[axis] = signal_edge;       // 0: SIGNAL_DOWN_EDGE, 1: SIGNAL_UP_EDGE
    sig_cap_target_[axis] = target;          // 0: COMMAND, 1: ACTUAL
    sig_cap_method_[axis] = signal_method;   // 0: EMERGENCY_STOP, 1: SLOWDOWN_STOP
    sig_cap_prev_level_[axis] = evalDetectSignal(axis, detect_signal);
    sig_cap_active_[axis] = true;
    ptp_profiles_[axis].plan_velocity(cmd_pos_[axis], vel, acc, acc);
}

double MotionCore::getCapturePos(int axis) const {
    if (axis < 0 || axis >= 3) return 0.0;
    if (axis == 2 && probe_latched_) {
        return probe_latched_z_;
    }
    return captured_pos_[axis];
}

double MotionCore::getActPos(int axis) const {
    if (axis < 0 || axis >= 3) return 0.0;
    return act_pos_[axis];
}

double MotionCore::getCmdPos(int axis) const {
    if (axis < 0 || axis >= 3) return 0.0;
    return cmd_pos_[axis];
}

double MotionCore::getCmdVel(int axis) const {
    if (axis < 0 || axis >= 3) return 0.0;
    return cmd_vel_[axis];
}

double MotionCore::getActVel(int axis) const {
    if (axis < 0 || axis >= 3) return 0.0;
    return act_vel_[axis];
}

double MotionCore::getCmdAcc(int axis) const {
    if (axis < 0 || axis >= 3) return 0.0;
    return cmd_acc_[axis];
}

double MotionCore::getActAcc(int axis) const {
    if (axis < 0 || axis >= 3) return 0.0;
    return act_acc_[axis];
}

double MotionCore::getPosError(int axis) const {
    if (axis < 0 || axis >= 3) return 0.0;
    return cmd_pos_[axis] - act_pos_[axis];
}

bool MotionCore::isInMotion(int axis) const {
    if (axis < 0 || axis >= 3) return false;
    if (homing_sm_[axis].is_busy()) return true;
    if (ptp_profiles_[axis].is_active()) return true;
    if (conti_running_) {
        for (long i = 0; i < conti_axis_count_; ++i) {
            if (conti_axis_map_[i] == axis) return true;
        }
    }
    return false;
}

uint32_t MotionCore::getMotionStatus(int axis) const {
    if (axis < 0 || axis >= 3) return 0;
    uint32_t status = 0;
    if (isInMotion(axis)) {
        status |= QIDRIVE_STATUS_0; // Busy (Driving)
        double a = cmd_acc_[axis];
        double v = cmd_vel_[axis];
        if (std::abs(a) < 1.0 && std::abs(v) > 0.1) {
            status |= QIDRIVE_STATUS_2; // Constant speed
        } else if (v * a > 0.0) {
            status |= QIDRIVE_STATUS_3; // Accelerating
        } else if (v * a < 0.0) {
            status |= QIDRIVE_STATUS_1; // Decelerating
        }
    }
    if (homing_sm_[axis].is_busy()) status |= QIDRIVE_STATUS_7;
    if (sig_cap_active_[axis]) status |= QIDRIVE_STATUS_8;
    if (conti_running_) status |= QIDRIVE_STATUS_9;
    return status;
}

uint32_t MotionCore::getMechanicalStatus(int axis) {
    if (axis < 0 || axis >= 3) return 0;
    uint32_t mech = 0;
    if (readInputBit(axis, 2)) mech |= QIMECHANICAL_PELM_LEVEL; // +Limit
    if (readInputBit(axis, 1)) mech |= QIMECHANICAL_NELM_LEVEL; // -Limit
    if (readInputBit(axis, 3)) mech |= QIMECHANICAL_ORG_LEVEL;  // Home ORG
    if (!isInMotion(axis) && std::abs(getPosError(axis)) < 0.05) {
        mech |= QIMECHANICAL_INP_LEVEL; // In-Position
    }
    return mech;
}

void MotionCore::lineMove(double end_x, double end_y, double end_z, double vel, double acc, double dec) {
    end_x = std::clamp(end_x, limit_min_[0], limit_max_[0]);
    end_y = std::clamp(end_y, limit_min_[1], limit_max_[1]);
    end_z = std::clamp(end_z, limit_min_[2], limit_max_[2]);

    // Standalone interpolation: clear queue WITHOUT erasing Gazebo toolpath or overriding axis map
    contiWriteClear(0, false);
    contiBeginNode(0);
    double end_pos[3] = {end_x, end_y, end_z};
    contiAddNodeLine(0, end_pos, vel, acc, dec);
    contiEndNode(0);
    contiStart(0, 0, 0);
}

void MotionCore::circleCenterMove(double cen_x, double cen_y, double end_x, double end_y, double vel, double acc, double dec, uint32_t cw_dir) {
    contiWriteClear(0, false);
    contiBeginNode(0);
    double cen[3] = {cen_x, cen_y, cmd_pos_[2]};
    double end[3] = {end_x, end_y, cmd_pos_[2]};
    contiAddNodeCircleCenter(0, cen, end, vel, acc, dec, cw_dir);
    contiEndNode(0);
    contiStart(0, 0, 0);
}

void MotionCore::helixCenterMove(double cen_x, double cen_y, double end_x, double end_y, double end_z, double vel, double acc, double dec, uint32_t cw_dir) {
    end_z = std::clamp(end_z, limit_min_[2], limit_max_[2]);
    contiWriteClear(0, false);
    contiBeginNode(0);
    double cen[3] = {cen_x, cen_y, cmd_pos_[2]};
    double end[3] = {end_x, end_y, end_z};
    contiAddNodeCircleCenter(0, cen, end, vel, acc, dec, cw_dir);
    contiEndNode(0);
    contiStart(0, 0, 0);
}

void MotionCore::contiSetAxisMap(long coord, long size, const long* axes) {
    std::lock_guard<std::mutex> lock(conti_mutex_);
    conti_axis_count_ = std::clamp(size, 1L, 3L);
    for (long i = 0; i < conti_axis_count_; ++i) {
        conti_axis_map_[i] = axes ? axes[i] : i;
    }
}

void MotionCore::contiGetAxisMap(long coord, long* size, long* axes) const {
    std::lock_guard<std::mutex> lock(conti_mutex_);
    if (size) *size = conti_axis_count_;
    if (axes) {
        for (long i = 0; i < conti_axis_count_; ++i) {
            axes[i] = conti_axis_map_[i];
        }
    }
}

void MotionCore::contiResetAxisMap(long coord) {
    std::lock_guard<std::mutex> lock(conti_mutex_);
    conti_axis_count_ = 3;
    conti_axis_map_[0] = 0;
    conti_axis_map_[1] = 1;
    conti_axis_map_[2] = 2;
}

void MotionCore::contiWriteClear(long coord, bool clear_toolpath) {
    std::lock_guard<std::mutex> lock(conti_mutex_);
    conti_queue_.clear();
    conti_building_ = false;
    conti_running_ = false;
    conti_current_node_index_ = 0;
    conti_total_nodes_ = 0;
    if (clear_toolpath) {
        MotionSharedData* data = shm_.get();
        if (data) {
            data->toolpath_epoch++;
        }
    }
}

void MotionCore::contiBeginNode(long coord) {
    std::lock_guard<std::mutex> lock(conti_mutex_);
    conti_building_ = true;
}

void MotionCore::contiAddNodeLine(long coord, const double* end_pos, double vel, double acc, double dec) {
    std::lock_guard<std::mutex> lock(conti_mutex_);
    ContiNode node;
    node.type = InterpNodeType::LINE_3D;
    node.velocity = vel;
    node.accel = acc;
    node.decel = dec;
    node.cw_dir = 0;

    double p0[3] = {cmd_pos_[0], cmd_pos_[1], cmd_pos_[2]};
    if (!conti_queue_.empty()) {
        p0[0] = conti_queue_.back().end_pos[0];
        p0[1] = conti_queue_.back().end_pos[1];
        p0[2] = conti_queue_.back().end_pos[2];
    }

    node.start_pos[0] = p0[0];
    node.start_pos[1] = p0[1];
    node.start_pos[2] = p0[2];

    node.end_pos[0] = std::clamp(end_pos[0], limit_min_[0], limit_max_[0]);
    node.end_pos[1] = std::clamp(end_pos[1], limit_min_[1], limit_max_[1]);
    node.end_pos[2] = std::clamp(end_pos[2], limit_min_[2], limit_max_[2]);

    double dx = node.end_pos[0] - p0[0];
    double dy = node.end_pos[1] - p0[1];
    double dz = node.end_pos[2] - p0[2];
    node.length = std::sqrt(dx*dx + dy*dy + dz*dz);

    conti_queue_.push_back(node);
    conti_total_nodes_ = static_cast<int32_t>(conti_queue_.size());
}

void MotionCore::contiAddNodeCircleCenter(long coord, const double* cen_pos, const double* end_pos, double vel, double acc, double dec, uint32_t cw_dir) {
    std::lock_guard<std::mutex> lock(conti_mutex_);
    ContiNode node;
    node.type = InterpNodeType::CIRCLE_CENTER;
    node.velocity = vel;
    node.accel = acc;
    node.decel = dec;
    node.cw_dir = cw_dir;

    double p0[3] = {cmd_pos_[0], cmd_pos_[1], cmd_pos_[2]};
    if (!conti_queue_.empty()) {
        p0[0] = conti_queue_.back().end_pos[0];
        p0[1] = conti_queue_.back().end_pos[1];
        p0[2] = conti_queue_.back().end_pos[2];
    }

    node.start_pos[0] = p0[0];
    node.start_pos[1] = p0[1];
    node.start_pos[2] = p0[2];

    node.center_pos[0] = cen_pos[0];
    node.center_pos[1] = cen_pos[1];
    node.center_pos[2] = cen_pos[2];

    node.end_pos[0] = end_pos[0];
    node.end_pos[1] = end_pos[1];
    node.end_pos[2] = end_pos[2];

    double r_start = std::hypot(p0[0] - cen_pos[0], p0[1] - cen_pos[1]);
    node.radius = r_start;
    node.start_angle = std::atan2(p0[1] - cen_pos[1], p0[0] - cen_pos[0]);
    double end_angle = std::atan2(end_pos[1] - cen_pos[1], end_pos[0] - cen_pos[0]);

    double sweep = 0.0;
    if (cw_dir == 1) { // CW
        sweep = node.start_angle - end_angle;
        while (sweep < 0.0) sweep += 2.0 * M_PI;
        while (sweep >= 2.0 * M_PI) sweep -= 2.0 * M_PI;
    } else { // CCW
        sweep = end_angle - node.start_angle;
        while (sweep < 0.0) sweep += 2.0 * M_PI;
        while (sweep >= 2.0 * M_PI) sweep -= 2.0 * M_PI;
    }
    if (sweep < 1e-4) sweep = 2.0 * M_PI; // Full circle
    node.sweep_angle = sweep;
    double xy_len = node.radius * sweep;
    double dz = end_pos[2] - p0[2];
    node.length = std::hypot(xy_len, dz);

    conti_queue_.push_back(node);
    conti_total_nodes_ = static_cast<int32_t>(conti_queue_.size());
}

void MotionCore::contiAddNodeDwell(long coord, double dwell_time_sec) {
    std::lock_guard<std::mutex> lock(conti_mutex_);
    ContiNode node;
    node.type = InterpNodeType::DWELL;
    node.velocity = 0.0;
    node.accel = 0.0;
    node.decel = 0.0;
    node.cw_dir = 0;
    node.length = std::max(0.001, dwell_time_sec);

    double p0[3] = {cmd_pos_[0], cmd_pos_[1], cmd_pos_[2]};
    if (!conti_queue_.empty()) {
        p0[0] = conti_queue_.back().end_pos[0];
        p0[1] = conti_queue_.back().end_pos[1];
        p0[2] = conti_queue_.back().end_pos[2];
    }
    for (int i = 0; i < 3; ++i) {
        node.start_pos[i] = p0[i];
        node.end_pos[i] = p0[i];
    }
    conti_queue_.push_back(node);
    conti_total_nodes_ = static_cast<int32_t>(conti_queue_.size());
}

void MotionCore::contiEndNode(long coord) {
    std::lock_guard<std::mutex> lock(conti_mutex_);
    conti_building_ = false;
}

void MotionCore::contiStart(long coord, uint32_t profile_mode, uint32_t blend_mode) {
    std::lock_guard<std::mutex> lock(conti_mutex_);
    if (conti_queue_.empty()) return;

    conti_total_nodes_ = static_cast<int32_t>(conti_queue_.size());
    conti_current_node_index_ = 1;
    active_conti_node_ = conti_queue_.front();
    conti_queue_.pop_front();

    conti_profile_.plan(0.0, active_conti_node_.length, active_conti_node_.velocity,
                        active_conti_node_.accel, active_conti_node_.decel, true);
    conti_node_s_ = 0.0;
    conti_running_ = true;
}

long MotionCore::contiGetNodeNum(long coord) const {
    std::lock_guard<std::mutex> lock(conti_mutex_);
    return conti_running_ ? static_cast<long>(conti_current_node_index_) : 0L;
}

long MotionCore::contiGetTotalNodeNum(long coord) const {
    std::lock_guard<std::mutex> lock(conti_mutex_);
    if (conti_total_nodes_ > 0) return static_cast<long>(conti_total_nodes_);
    return static_cast<long>(conti_queue_.size() + (conti_running_ ? 1 : 0));
}

void MotionCore::contiGetTailPos(long coord, double* pos) const {
    if (!pos) return;
    std::lock_guard<std::mutex> lock(conti_mutex_);
    if (!conti_queue_.empty()) {
        pos[0] = conti_queue_.back().end_pos[0];
        pos[1] = conti_queue_.back().end_pos[1];
        pos[2] = conti_queue_.back().end_pos[2];
    } else {
        pos[0] = cmd_pos_[0];
        pos[1] = cmd_pos_[1];
        pos[2] = cmd_pos_[2];
    }
}

bool MotionCore::contiIsMotion(long coord) const {
    return conti_running_;
}

void MotionCore::homeSetMethod(int axis, long hm_dir, DWORD home_signal, DWORD z_phase, double clr_time, double offset) {
    if (axis >= 0 && axis < 3) {
        homing_sm_[axis].set_method(hm_dir, home_signal, z_phase, clr_time, offset);
    }
}

void MotionCore::homeGetMethod(int axis, long* hm_dir, DWORD* home_signal, DWORD* z_phase, double* clr_time, double* offset) const {
    if (axis >= 0 && axis < 3) {
        uint32_t hs = 0, zp = 0;
        homing_sm_[axis].get_method(hm_dir, &hs, &zp, clr_time, offset);
        if (home_signal) *home_signal = hs;
        if (z_phase) *z_phase = zp;
    }
}

void MotionCore::homeSetVel(int axis, double v1, double v2, double v3, double v4, double a1, double a2) {
    if (axis >= 0 && axis < 3) {
        homing_sm_[axis].set_vel(v1, v2, v3, v4, a1, a2);
    }
}

void MotionCore::homeGetVel(int axis, double* v1, double* v2, double* v3, double* v4, double* a1, double* a2) const {
    if (axis >= 0 && axis < 3) {
        homing_sm_[axis].get_vel(v1, v2, v3, v4, a1, a2);
    }
}

void MotionCore::homeStart(int axis) {
    if (axis >= 0 && axis < 3) {
        refreshSensorConfig();
        homing_sm_[axis].set_sensor_config(org_pos_[axis], limit_min_[axis], limit_max_[axis]);
        homing_sm_[axis].start(cmd_pos_[axis]);
    }
}

void MotionCore::homeSetResult(int axis, DWORD result) {
    if (axis >= 0 && axis < 3) {
        homing_sm_[axis].set_result(result);
    }
}

DWORD MotionCore::homeGetResult(int axis) const {
    if (axis >= 0 && axis < 3) {
        return homing_sm_[axis].get_result();
    }
    return 0;
}

void MotionCore::homeGetRate(int axis, DWORD* main_step, DWORD* step_progress) const {
    if (axis >= 0 && axis < 3) {
        uint32_t ms = 0, sp = 0;
        homing_sm_[axis].get_rate(&ms, &sp);
        if (main_step) *main_step = ms;
        if (step_progress) *step_progress = sp;
    }
}

DWORD MotionCore::readInput(int axis) {
    if (axis < 0 || axis >= 3) return 0;
    MotionSharedData* data = shm_.get();
    if (!data) return 0;
    return data->digital_in[axis];
}

DWORD MotionCore::readInputBit(int axis, long bit_no) {
    if (axis < 0 || axis >= 3) return 0;
    MotionSharedData* data = shm_.get();
    if (!data) return 0;

    // Bit 0: Touch probe / Universal input 0
    if (bit_no == 0) {
        if (axis == 2 && (probe_latched_ || (data->digital_in[2] & 0x01))) return 1;
        return (data->digital_in[axis] & 0x01) ? 1 : 0;
    }
    // Bit 1: Limit -
    if (bit_no == 1) {
        return (data->digital_in[axis] & 0x02) ? 1 : 0;
    }
    // Bit 2: Limit +
    if (bit_no == 2) {
        return (data->digital_in[axis] & 0x04) ? 1 : 0;
    }
    // Bit 3: Home ORG
    if (bit_no == 3) {
        return (data->digital_in[axis] & 0x08) ? 1 : 0;
    }

    return 0;
}

void MotionCore::writeOutput(int axis, DWORD value) {
    if (axis >= 0 && axis < 3) digital_out_[axis] = value;
}

DWORD MotionCore::readOutput(int axis) const {
    if (axis >= 0 && axis < 3) return digital_out_[axis];
    return 0;
}

void MotionCore::writeOutputBit(int axis, long bit_no, DWORD on_off) {
    if (axis < 0 || axis >= 3 || bit_no < 0 || bit_no >= 32) return;
    if (on_off) digital_out_[axis] |= (1u << bit_no);
    else digital_out_[axis] &= ~(1u << bit_no);
}

DWORD MotionCore::readOutputBit(int axis, long bit_no) const {
    if (axis < 0 || axis >= 3 || bit_no < 0 || bit_no >= 32) return 0;
    return (digital_out_[axis] & (1u << bit_no)) ? 1 : 0;
}

void MotionCore::setTriggerPos(int axis, double pos) {
    if (axis >= 0 && axis < 3) captured_pos_[axis] = pos;
    probe_latched_z_ = pos;
}

double MotionCore::getTriggerPos(int axis) const {
    return getCapturePos(axis);
}

void MotionCore::setCmdPos(int axis, double pos) {
    if (axis >= 0 && axis < 3) {
        cmd_pos_[axis] = pos;
        dyn_pos_[axis] = pos;
        backlash_play_[axis] = pos;
        ptp_profiles_[axis].set_pos(pos);
    }
}

void MotionCore::setActPos(int axis, double pos) {
    if (axis >= 0 && axis < 3) {
        act_pos_[axis] = pos;
        dyn_pos_[axis] = pos;
        backlash_play_[axis] = pos;
    }
}

void MotionCore::setPosition(int axis, double pos) {
    if (axis >= 0 && axis < 3) {
        cmd_pos_[axis] = pos;
        act_pos_[axis] = pos;
        dyn_pos_[axis] = pos;
        dyn_vel_[axis] = 0.0;
        backlash_play_[axis] = pos;
        ptp_profiles_[axis].set_pos(pos);
    }
}

void MotionCore::processHoming(double dt) {
    for (int i = 0; i < 3; ++i) {
        if (homing_sm_[i].is_busy()) {
            bool org_active = (readInputBit(i, 3) == 1);
            double new_pos = cmd_pos_[i];
            double new_vel = cmd_vel_[i];
            double new_acc = cmd_acc_[i];
            bool active = homing_sm_[i].update(dt, new_pos, new_vel, new_acc, org_active);
            cmd_pos_[i] = new_pos;
            cmd_vel_[i] = new_vel;
            cmd_acc_[i] = new_acc;
            if (!active && homing_sm_[i].get_result() == HOME_SUCCESS) {
                cmd_pos_[i] = homing_sm_[i].get_target_pos();
                act_pos_[i] = cmd_pos_[i];
                dyn_pos_[i] = cmd_pos_[i];
                dyn_vel_[i] = 0.0;
                backlash_play_[i] = cmd_pos_[i];
                cmd_vel_[i] = 0.0;
                cmd_acc_[i] = 0.0;
                ptp_profiles_[i].set_pos(cmd_pos_[i]);
            }
        }
    }
}

void MotionCore::processContiMotion(double dt) {
    if (!conti_running_) return;

    std::lock_guard<std::mutex> lock(conti_mutex_);

    if (active_conti_node_.type == InterpNodeType::DWELL) {
        for (int i = 0; i < 3; ++i) {
            cmd_pos_[i] = active_conti_node_.start_pos[i];
            cmd_vel_[i] = 0.0;
            cmd_acc_[i] = 0.0;
        }
        conti_node_s_ += dt;
        if (conti_node_s_ >= active_conti_node_.length) {
            if (!conti_queue_.empty()) {
                active_conti_node_ = conti_queue_.front();
                conti_queue_.pop_front();
                conti_current_node_index_++;
                if (active_conti_node_.type != InterpNodeType::DWELL) {
                    conti_profile_.plan(0.0, active_conti_node_.length, active_conti_node_.velocity,
                                        active_conti_node_.accel, active_conti_node_.decel, true);
                }
                conti_node_s_ = 0.0;
            } else {
                conti_running_ = false;
            }
        }
        return;
    }

    double cur_s = conti_node_s_;
    double cur_v = 0.0;
    double cur_a = 0.0;
    bool active = conti_profile_.update(dt, cur_s, cur_v, cur_a);
    conti_node_s_ = cur_s;

    double L = active_conti_node_.length;
    double ratio = (L > 1e-6) ? (cur_s / L) : 1.0;
    ratio = std::clamp(ratio, 0.0, 1.0);

    if (active_conti_node_.type == InterpNodeType::LINE_3D) {
        double inv_L = (L > 1e-6) ? (1.0 / L) : 0.0;
        for (int i = 0; i < 3; ++i) {
            double delta = active_conti_node_.end_pos[i] - active_conti_node_.start_pos[i];
            double unit_dir = delta * inv_L;
            cmd_pos_[i] = active_conti_node_.start_pos[i] + ratio * delta;
            cmd_vel_[i] = cur_v * unit_dir;
            cmd_acc_[i] = cur_a * unit_dir;
        }
    } else if (active_conti_node_.type == InterpNodeType::CIRCLE_CENTER) {
        double dir_sign = (active_conti_node_.cw_dir == 1) ? -1.0 : 1.0;
        double d_theta = dir_sign * ratio * active_conti_node_.sweep_angle;
        double theta = active_conti_node_.start_angle + d_theta;
        double cos_t = std::cos(theta);
        double sin_t = std::sin(theta);
        double R = std::max(1e-6, active_conti_node_.radius);

        cmd_pos_[0] = active_conti_node_.center_pos[0] + active_conti_node_.radius * cos_t;
        cmd_pos_[1] = active_conti_node_.center_pos[1] + active_conti_node_.radius * sin_t;
        cmd_pos_[2] = active_conti_node_.start_pos[2] +
                      ratio * (active_conti_node_.end_pos[2] - active_conti_node_.start_pos[2]);

        // Exact circular tangential velocity & combined tangential + centripetal acceleration
        cmd_vel_[0] = -dir_sign * cur_v * sin_t;
        cmd_vel_[1] =  dir_sign * cur_v * cos_t;
        cmd_vel_[2] = (L > 1e-6) ? (cur_v * (active_conti_node_.end_pos[2] - active_conti_node_.start_pos[2]) / L) : 0.0;

        double a_centripetal = (cur_v * cur_v) / R;
        cmd_acc_[0] = -dir_sign * cur_a * sin_t - a_centripetal * cos_t;
        cmd_acc_[1] =  dir_sign * cur_a * cos_t - a_centripetal * sin_t;
        cmd_acc_[2] = (L > 1e-6) ? (cur_a * (active_conti_node_.end_pos[2] - active_conti_node_.start_pos[2]) / L) : 0.0;
    }

    if (!active) {
        if (!conti_queue_.empty()) {
            active_conti_node_ = conti_queue_.front();
            conti_queue_.pop_front();
            conti_current_node_index_++;
            if (active_conti_node_.type != InterpNodeType::DWELL) {
                conti_profile_.plan(0.0, active_conti_node_.length, active_conti_node_.velocity,
                                    active_conti_node_.accel, active_conti_node_.decel, true);
            }
            conti_node_s_ = 0.0;
        } else {
            conti_running_ = false;
            for (int i = 0; i < 3; ++i) {
                cmd_vel_[i] = 0.0;
                cmd_acc_[i] = 0.0;
                ptp_profiles_[i].set_pos(cmd_pos_[i]);
            }
        }
    }
}

void MotionCore::processAxisMotion(double dt) {
    double prev_cmd[3] = {cmd_pos_[0], cmd_pos_[1], cmd_pos_[2]};

    for (int i = 0; i < 3; ++i) {
        if (!homing_sm_[i].is_busy() && !conti_running_) {
            if (ptp_profiles_[i].is_active()) {
                if (ovr_at_pos_active_[i]) {
                    double check_p = (ovr_target_source_[i] == 0) ? cmd_pos_[i] : act_pos_[i];
                    bool crossed = (ptp_profiles_[i].target_pos() >= ovr_start_pos_[i])
                                   ? (check_p >= ovr_trigger_pos_[i])
                                   : (check_p <= ovr_trigger_pos_[i]);
                    if (crossed) {
                        ptp_profiles_[i].override_vel(ovr_target_vel_[i]);
                        ovr_at_pos_active_[i] = false;
                    }
                }

                double p = cmd_pos_[i];
                double v = cmd_vel_[i];
                double a = cmd_acc_[i];
                ptp_profiles_[i].update(dt, p, v, a);
                if (p <= limit_min_[i] || p >= limit_max_[i]) {
                    p = std::clamp(p, limit_min_[i], limit_max_[i]);
                    if ((v < 0.0 && p <= limit_min_[i]) || (v > 0.0 && p >= limit_max_[i])) {
                        ptp_profiles_[i].estop();
                        v = 0.0;
                        a = 0.0;
                    }
                }
                cmd_pos_[i] = p;
                cmd_vel_[i] = v;
                cmd_acc_[i] = a;
            } else {
                ovr_at_pos_active_[i] = false;
                cmd_vel_[i] = 0.0;
                cmd_acc_[i] = 0.0;
            }
        }
    }

    // Apply Electronic Gear (AxmLinkSetMode) and Gantry Master-Slave Sync (AxmGantrySetEnable)
    for (int m = 0; m < 3; ++m) {
        double dp_m = cmd_pos_[m] - prev_cmd[m];
        if (std::abs(dp_m) > 1e-9 || std::abs(cmd_vel_[m]) > 1e-6) {
            long s_link = link_slave_[m];
            if (s_link >= 0 && s_link < 3 && s_link != m) {
                double ratio = link_ratio_[m];
                cmd_pos_[s_link] = std::clamp(cmd_pos_[s_link] + dp_m * ratio, limit_min_[s_link], limit_max_[s_link]);
                cmd_vel_[s_link] = cmd_vel_[m] * ratio;
                cmd_acc_[s_link] = cmd_acc_[m] * ratio;
                ptp_profiles_[s_link].set_pos(cmd_pos_[s_link]);
            }
            if (gantry_on_[m]) {
                long s_gnt = gantry_slave_[m];
                if (s_gnt >= 0 && s_gnt < 3 && s_gnt != m) {
                    cmd_pos_[s_gnt] = std::clamp(cmd_pos_[m] + gantry_offset_[m], limit_min_[s_gnt], limit_max_[s_gnt]);
                    cmd_vel_[s_gnt] = cmd_vel_[m];
                    cmd_acc_[s_gnt] = cmd_acc_[m];
                    ptp_profiles_[s_gnt].set_pos(cmd_pos_[s_gnt]);
                }
            }
        }
    }
}

void MotionCore::processSignalCapture(double dt) {
    (void)dt;
    for (int i = 0; i < 3; ++i) {
        if (!sig_cap_active_[i]) continue;
        bool cur_level = evalDetectSignal(i, sig_cap_signal_[i]);
        bool triggered = false;
        if (sig_cap_edge_[i] == 1) { // SIGNAL_UP_EDGE (or active high level)
            triggered = cur_level && !sig_cap_prev_level_[i];
            if (cur_level) triggered = true;
        } else { // SIGNAL_DOWN_EDGE
            triggered = !cur_level && sig_cap_prev_level_[i];
        }
        sig_cap_prev_level_[i] = cur_level;

        if (triggered) {
            captured_pos_[i] = (sig_cap_target_[i] == 0) ? cmd_pos_[i] : act_pos_[i];
            if (i == 2) {
                probe_latched_ = true;
                probe_latched_z_ = captured_pos_[i];
            }
            sig_cap_active_[i] = false;
            if (sig_cap_method_[i] == 0) {
                // EMERGENCY_STOP
                ptp_profiles_[i].estop();
                cmd_vel_[i] = 0.0;
                cmd_acc_[i] = 0.0;
            } else {
                // SLOWDOWN_STOP
                ptp_profiles_[i].stop(1000.0);
            }
        }
    }
}

void MotionCore::updateHardwareIO(double dt) {
    MotionSharedData* data = shm_.get();
    if (!data) return;

    // Tx commands
    for (int i = 0; i < 3; ++i) {
        data->target_pos[i] = cmd_pos_[i];
        data->control_word[i] = servo_on_[i] ? 0x000F : 0x0000;
    }
    data->heartbeat_tx++;

    // Detect if external Gazebo / ROS2 simulator is actively publishing
    static uint32_t prev_sim_rx = 0;
    static int rx_stale_count = 100;
    static bool rx_tracker_init = false;

    if (!rx_tracker_init) {
        prev_sim_rx = data->heartbeat_rx;
        rx_stale_count = 100;
        data->sim_active = false;
        rx_tracker_init = true;
    } else if (data->heartbeat_rx != prev_sim_rx) {
        prev_sim_rx = data->heartbeat_rx;
        rx_stale_count = 0;
        data->sim_active = true;
    } else {
        if (rx_stale_count < 50) { // 50ms timeout
            rx_stale_count++;
        } else {
            data->sim_active = false;
        }
    }

    if (data->sim_active) {
        // External Gazebo / ROS2 bridge is actively feeding positions & velocities
        for (int i = 0; i < 3; ++i) {
            act_pos_[i] = data->actual_pos[i];
            act_vel_[i] = data->act_vel[i];
            act_acc_[i] = data->act_acc[i];
            dyn_pos_[i] = act_pos_[i];
            dyn_vel_[i] = act_vel_[i];
            backlash_play_[i] = act_pos_[i];
        }
        if (data->probe_triggered) {
            probe_latched_ = true;
            probe_latched_z_ = data->probe_latched_z;
            captured_pos_[2] = data->probe_latched_z;
        }
    } else {
        // =========================================================================================
        // REAL-WORLD 3-AXIS CNC GANTRY PHYSICAL PLANT MODEL (1000 Hz)
        // Includes:
        //   1. Asymmetric Coupled Axis Masses: M_x = 42 kg, M_y = 16 kg, M_z = 4 kg
        //   2. Gravitational Load on Z-Axis: g = 9810 mm/s^2 (F_g = -39.24 N downward) + Integral Hold
        //   3. Nonlinear Stribeck + Coulomb + Viscous Guideway Friction (Stick-Slip & Quadrant Glitch)
        //   4. Ballscrew Preload Backlash Deadzone Hysteresis: +/-2.5 um (X), +/-2.0 um (Y), +/-1.5 um (Z)
        //   5. Electromagnetic Servo Cogging & Ballscrew Pitch Harmonics
        //   6. Workpiece Milling Cutting Force & Spindle Tooth-Passing Chatter (when Z <= -197.5 mm)
        //   7. Gaussian Process Noise, Sensor Jitter & 20-bit Optical Encoder Quantization
        // =========================================================================================
        static thread_local std::mt19937 rng(20261028);
        std::normal_distribution<double> norm_dist(0.0, 1.0);

        sim_time_sec_ += dt;

        // Physical axis parameters: [0]=X (Gantry 42kg), [1]=Y (Carriage 16kg), [2]=Z (Spindle 4kg)
        const double MASS_KG[3]       = {42.0, 16.0, 4.0};
        const double WN[3]            = {235.0, 285.0, 320.0};    // Servo loop natural freq (rad/s)
        const double ZETA[3]          = {0.82,  0.85,  0.88};     // Damping ratio
        const double K_AFF[3]         = {0.84,  0.87,  0.89};     // Acceleration feedforward gain
        const double KI_ACC[3]        = {18000.0, 24000.0, 65000.0}; // Integral gain (1/s^3)
        const double I_CLAMP_ACC[3]   = {400.0,   600.0,  11250.0};  // Anti-windup clamp (mm/s^2)

        // Friction parameters: Static F_s (N), Coulomb F_c (N), Viscous B (N.s/m), Stribeck vel v_s (mm/s)
        const double FRIC_FS_N[3]     = {5.2, 3.0, 2.2};
        const double FRIC_FC_N[3]     = {3.5, 2.0, 1.5};
        const double FRIC_VISC[3]     = {4.5, 3.0, 2.5};
        const double V_STRIBECK       = 3.5; // mm/s

        // Ballscrew half-backlash deadzone (mm): 2.5 um (X), 2.0 um (Y), 1.5 um (Z)
        const double BACKLASH_MM[3]   = {0.0025, 0.0020, 0.0015};
        const double Q_ENC[3]         = {unit_per_pulse_[0], unit_per_pulse_[1], unit_per_pulse_[2]};

        if (!dyn_initialized_) {
            for (int i = 0; i < 3; ++i) {
                dyn_pos_[i] = cmd_pos_[i];
                dyn_vel_[i] = 0.0;
                backlash_play_[i] = cmd_pos_[i];
                dyn_integ_[i] = (i == 2) ? (0.96 * 9810.0) : 0.0;
            }
            dyn_initialized_ = true;
        }

        // Check if tool tip is actively cutting inside the workpiece billet (X,Y in [0,400], Z <= -197.5 mm)
        const bool in_workpiece_xy = (dyn_pos_[0] >= 0.0 && dyn_pos_[0] <= 400.0 &&
                                      dyn_pos_[1] >= 0.0 && dyn_pos_[1] <= 400.0);
        const double depth_of_cut = (in_workpiece_xy && dyn_pos_[2] <= -197.0)
                                    ? std::clamp(-197.0 - dyn_pos_[2], 0.0, 5.0)
                                    : 0.0;
        const double feed_speed_xy = std::hypot(dyn_vel_[0], dyn_vel_[1]);
        const bool is_milling = (depth_of_cut > 0.05 && (feed_speed_xy > 0.2 || std::abs(dyn_vel_[2]) > 0.2));

        for (int i = 0; i < 3; ++i) {
            // 1. Closed-Loop Servo Controller (PID + Velocity & Acceleration Feedforward)
            double err_p = cmd_pos_[i] - act_pos_[i];
            double err_v = cmd_vel_[i] - dyn_vel_[i];

            dyn_integ_[i] += KI_ACC[i] * err_p * dt;
            dyn_integ_[i] = std::clamp(dyn_integ_[i], -I_CLAMP_ACC[i], I_CLAMP_ACC[i]);

            double acc_servo = (WN[i] * WN[i] * err_p)
                             + (2.0 * ZETA[i] * WN[i] * err_v)
                             + dyn_integ_[i]
                             + (K_AFF[i] * cmd_acc_[i]);

            // 2. Gravity Disturbance on Vertical Z-Axis (g = -9810 mm/s^2 downward)
            double acc_gravity = (i == 2) ? -9810.0 : 0.0;

            // 3. Nonlinear Stribeck + Coulomb + Viscous Friction (opposing motion)
            double v = dyn_vel_[i];
            double stribeck_term = FRIC_FC_N[i] + (FRIC_FS_N[i] - FRIC_FC_N[i]) * std::exp(-(v * v) / (V_STRIBECK * V_STRIBECK));
            double f_friction_N = stribeck_term * std::tanh(v / 2.5) + FRIC_VISC[i] * (v * 0.001);
            double acc_friction = -(1000.0 / MASS_KG[i]) * f_friction_N;

            // 4. Electromagnetic Motor Cogging & Ballscrew Pitch Ripple (20mm lead, 8 pole pairs)
            double cog_phase = (2.0 * M_PI * 8.0 * dyn_pos_[i]) / 20.0;
            double acc_cogging = (16.0 / MASS_KG[i]) * 20.0 * std::sin(cog_phase) * std::tanh(std::abs(v) / 1.5);

            // 5. Workpiece Milling Cutting Force & Spindle Tooth-Passing Harmonics (12,000 RPM = 200Hz / 400Hz)
            double acc_cutting = 0.0;
            double imu_chatter = 0.0;
            if (is_milling) {
                // Resistant cutting force opposing feed vector (N)
                double f_cut_N = 0.0;
                if (i == 0 || i == 1) {
                    double dir = v / (feed_speed_xy + 2.0);
                    // Lateral radial milling force + tangential feed resistance
                    double ortho_v = (i == 0) ? -dyn_vel_[1] : dyn_vel_[0];
                    double dir_ortho = 0.35 * (ortho_v / (feed_speed_xy + 2.0));
                    f_cut_N = (4.5 * depth_of_cut) * (dir + dir_ortho);
                } else {
                    // Axial thrust resistance on Z spindle during plunge/cut
                    f_cut_N = 2.8 * depth_of_cut * std::tanh(v / 2.0) - 1.2 * depth_of_cut;
                }

                // Spindle harmonic chatter (68 Hz gantry structural mode + 185 Hz & 310 Hz tooth harmonics)
                double chatter_wave = 0.55 * std::sin(2.0 * M_PI * 68.0 * sim_time_sec_ + i * 1.1)
                                    + 0.30 * std::sin(2.0 * M_PI * 185.0 * sim_time_sec_ + i * 2.3)
                                    + 0.15 * std::cos(2.0 * M_PI * 310.0 * sim_time_sec_);
                double f_chatter_N = (1.8 * depth_of_cut) * chatter_wave;

                acc_cutting = -(1000.0 / MASS_KG[i]) * (f_cut_N + f_chatter_N);
                imu_chatter = (140.0 * depth_of_cut) * chatter_wave + 65.0 * norm_dist(rng);
            }

            // 6. Gaussian Servo Process Disturbance Noise
            double sigma_proc = isInMotion(i) ? (14.0 / std::sqrt(MASS_KG[i])) : (3.5 / std::sqrt(MASS_KG[i]));
            double acc_noise = sigma_proc * norm_dist(rng);

            // Total Physical Acceleration (Newton's 2nd Law)
            double total_acc = acc_servo + acc_gravity + acc_friction + acc_cogging + acc_cutting + acc_noise;

            // Integrate motor shaft velocity and position
            double prev_act_p = act_pos_[i];
            dyn_vel_[i] += total_acc * dt;
            dyn_pos_[i] += dyn_vel_[i] * dt;

            // 7. Mechanical Ballscrew Backlash Deadzone Hysteresis (Preloaded Nut Compliance)
            double b = BACKLASH_MM[i];
            double diff_b = dyn_pos_[i] - backlash_play_[i];
            if (diff_b > b) {
                backlash_play_[i] = dyn_pos_[i] - b;
            } else if (diff_b < -b) {
                backlash_play_[i] = dyn_pos_[i] + b;
            } else {
                // Preloaded ballscrew nut elastic stiffness inside deadband
                backlash_play_[i] += 0.35 * diff_b;
            }

            // 8. 20-bit Optical Encoder Quantization (0.01907 um resolution)
            act_pos_[i] = std::round(backlash_play_[i] / Q_ENC[i]) * Q_ENC[i];

            // Filtered actual velocity and acceleration from 20-bit optical encoder feedback
            double raw_v = (act_pos_[i] - prev_act_p) / dt;
            act_vel_[i] = 0.80 * act_vel_[i] + 0.20 * raw_v;
            act_acc_[i] = 0.82 * act_acc_[i] + 0.18 * total_acc;

            // 9. 3-Axis MEMS Tool-Tip IMU Accelerometer (Dynamic Acc + Chatter + Gaussian White Noise)
            double imu_white_noise = 15.0 * norm_dist(rng); // stddev = 15 mm/s^2 (0.015 m/s^2) matching URDF
            data->actual_pos[i] = act_pos_[i];
            data->act_vel[i]    = act_vel_[i];
            data->act_acc[i]    = act_acc_[i];
            data->imu_acc[i]    = act_acc_[i] + imu_chatter + imu_white_noise;

            // Limit and Home flags matching sensors_config.yaml & sim_bridge_node
            uint32_t dig = 0;
            if (act_pos_[i] <= limit_min_[i] + 0.5) dig |= 0x02; // Limit-
            if (act_pos_[i] >= limit_max_[i] - 0.5) dig |= 0x04; // Limit+
            if (i == 2) {
                if (act_pos_[i] >= org_pos_[i] - 0.5) dig |= 0x08; // Home ORG (Z top)
            } else {
                if (act_pos_[i] <= org_pos_[i] + 0.5) dig |= 0x08; // Home ORG (X, Y origin)
            }

            if (i == 2) {
                // Workpiece surface is at Z = -198.5 mm across X in [0, 400], Y in [0, 400]
                bool workpiece_contact = (act_pos_[0] >= 0.0 && act_pos_[0] <= 400.0 &&
                                          act_pos_[1] >= 0.0 && act_pos_[1] <= 400.0 &&
                                          act_pos_[2] <= -198.5);
                if (workpiece_contact) {
                    dig |= 0x01;
                    if (!data->probe_triggered) {
                        data->probe_triggered = true;
                        data->probe_latched_z = act_pos_[2];
                        probe_latched_ = true;
                        probe_latched_z_ = act_pos_[2];
                        captured_pos_[2] = act_pos_[2];
                    }
                } else if (act_pos_[2] > -198.0) {
                    data->probe_triggered = false;
                }
            }
            data->digital_in[i] = dig;
        }
    }
}

void MotionCore::realtimeLoop() {
    using clock = std::chrono::steady_clock;
    const std::chrono::microseconds cycle_time(1000); // 1.0 ms = 1000 Hz CSP
    auto next_cycle = clock::now();

    while (is_running_) {
        next_cycle += cycle_time;

        {
            std::lock_guard<std::mutex> lock(core_mutex_);
            const double dt = 0.001; // 1 ms
            updateHardwareIO(dt);
            processSignalCapture(dt);
            processHoming(dt);
            processContiMotion(dt);
            processAxisMotion(dt);

            // Sync all command & telemetry signals to shared memory
            MotionSharedData* data = shm_.get();
            if (data) {
                for (int i = 0; i < 3; ++i) {
                    data->target_pos[i] = cmd_pos_[i];
                    data->cmd_vel[i] = cmd_vel_[i];
                    data->cmd_acc[i] = cmd_acc_[i];
                    data->pos_error[i] = cmd_pos_[i] - act_pos_[i];
                    data->axis_in_motion[i] = isInMotion(i) ? 1 : 0;
                    data->home_step[i] = homing_sm_[i].get_main_step();
                    data->home_progress[i] = homing_sm_[i].get_step_progress();
                    data->home_result[i] = homing_sm_[i].get_result();
                    data->abs_rel_mode[i] = abs_rel_mode_[i];
                    data->profile_mode[i] = profile_mode_[i];
                }
                data->conti_in_motion = conti_running_ ? 1 : 0;
                data->conti_node_index = conti_running_ ? conti_current_node_index_ : 0;
                data->conti_total_nodes = conti_total_nodes_;
            }
        }

        std::this_thread::sleep_until(next_cycle);
    }
}
