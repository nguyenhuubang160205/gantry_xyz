#pragma once

#include <cstdint>
#include <cstring>
#include <fcntl.h>
#include <sys/mman.h>
#include <sys/stat.h>
#include <unistd.h>
#include <iostream>

#define XYZ_SHM_NAME "/xyz_motion_shm"

struct MotionSharedData {
    // Command from libaxm_sim (TxPDO -> RxPDO)
    double target_pos[3];     // 0x607A Target Position (X, Y, Z in mm)
    uint32_t control_word[3]; // 0x6040 Controlword (Servo On, QuickStop)
    
    // Feedback from Gazebo/ROS2 (RxPDO <- TxPDO)
    double actual_pos[3];     // 0x6064 Actual Position (X, Y, Z in mm)
    uint32_t status_word[3];  // 0x6041 Statusword
    uint32_t digital_in[3];   // 0x60FD Bit 0: Touch Probe, Bit 1: Limit-, Bit 2: Limit+, Bit 3: Home ORG
    
    // Touch Probe Events
    bool probe_triggered;     // True khi đầu dò chạm phôi
    double probe_latched_z;   // Tọa độ Z chốt được tại thời điểm chạm

    // Diagnostics & Synchronization
    uint32_t heartbeat_tx;    // Incremented by libaxm_core (1kHz)
    uint32_t heartbeat_rx;    // Incremented by Sim bridge / Gazebo
    bool sim_active;          // Set to true by simulator when active
    uint32_t toolpath_epoch;  // Incremented on new motion start to auto-clear previous toolpath

    // Extended Real-Time Kinematics & Dynamics Telemetry (1000 Hz)
    double cmd_vel[3];        // Command Velocity (X, Y, Z in mm/s)
    double act_vel[3];        // Actual Encoder Velocity (X, Y, Z in mm/s)
    double cmd_acc[3];        // Command Acceleration (X, Y, Z in mm/s^2)
    double act_acc[3];        // Actual Acceleration (X, Y, Z in mm/s^2)
    double pos_error[3];      // Following Error: cmd_pos - act_pos (X, Y, Z in mm)
    double imu_acc[3];        // MEMS Tool Vibration Sensor Acceleration (X, Y, Z in mm/s^2)

    // Extended Axis & Controller State Telemetry
    uint32_t axis_in_motion[3]; // 1 if axis is moving, 0 if idle
    uint32_t home_step[3];      // Homing Step (0..8)
    uint32_t home_progress[3];  // Homing Progress (0..100%)
    uint32_t home_result[3];    // Homing Result (HOME_SUCCESS=0x01, HOME_SEARCHING=0x02, etc.)
    uint32_t abs_rel_mode[3];   // 0: POS_ABS_MODE, 1: POS_REL_MODE
    uint32_t profile_mode[3];   // 0..4: AXT_MOTION_PROFILE_MODE
    uint32_t conti_in_motion;   // 1 if Continuous Interpolation is active
    int32_t conti_node_index;   // Current active Conti node index
    int32_t conti_total_nodes;  // Total Conti nodes in queue
};

class IPCSharedMemory {
public:
    IPCSharedMemory() : shm_fd_(-1), data_(nullptr), is_owner_(false) {}

    ~IPCSharedMemory() {
        close();
    }

    bool init(bool create_if_not_exists = true) {
        int flags = O_RDWR;
        if (create_if_not_exists) {
            flags |= O_CREAT;
        }

        shm_fd_ = shm_open(XYZ_SHM_NAME, flags, 0666);
        if (shm_fd_ < 0) {
            std::cerr << "[IPCSharedMemory] Failed to shm_open: " << strerror(errno) << std::endl;
            return false;
        }

        struct stat sb;
        if (fstat(shm_fd_, &sb) == 0 && sb.st_size < static_cast<off_t>(sizeof(MotionSharedData))) {
            if (ftruncate(shm_fd_, sizeof(MotionSharedData)) != 0) {
                std::cerr << "[IPCSharedMemory] Failed to ftruncate: " << strerror(errno) << std::endl;
                ::close(shm_fd_);
                shm_fd_ = -1;
                return false;
            }
            is_owner_ = true;
        }

        void* ptr = mmap(nullptr, sizeof(MotionSharedData), PROT_READ | PROT_WRITE, MAP_SHARED, shm_fd_, 0);
        if (ptr == MAP_FAILED) {
            std::cerr << "[IPCSharedMemory] Failed to mmap: " << strerror(errno) << std::endl;
            ::close(shm_fd_);
            shm_fd_ = -1;
            return false;
        }

        data_ = static_cast<MotionSharedData*>(ptr);
        if (is_owner_) {
            std::memset(data_, 0, sizeof(MotionSharedData));
            // Default home sensor / limit flags
            data_->digital_in[0] = 0;
            data_->digital_in[1] = 0;
            data_->digital_in[2] = 0;
        }

        return true;
    }

    MotionSharedData* get() {
        return data_;
    }

    const MotionSharedData* get() const {
        return data_;
    }

    void close() {
        if (data_ != nullptr) {
            munmap(data_, sizeof(MotionSharedData));
            data_ = nullptr;
        }
        if (shm_fd_ >= 0) {
            ::close(shm_fd_);
            shm_fd_ = -1;
        }
    }

private:
    int shm_fd_;
    MotionSharedData* data_;
    bool is_owner_;
};
