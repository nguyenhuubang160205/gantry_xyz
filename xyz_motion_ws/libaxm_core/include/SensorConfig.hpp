#pragma once

#include <string>
#include <fstream>
#include <sstream>
#include <sys/stat.h>
#include <iostream>
#include <cmath>
#include <algorithm>

struct AxisSensorConfig {
    std::string name = "";
    double limit_min = -20.0;
    double home_org = 0.0;
    double limit_max = 800.0;
    double sensor_width = 10.0;
};

struct RobotSensorsConfig {
    AxisSensorConfig axis[3];
    time_t last_mtime = 0;

    RobotSensorsConfig() {
        axis[0] = {"Axis X", 0.0, 0.0, 800.0, 10.0};
        axis[1] = {"Axis Y", 0.0, 0.0, 680.0, 10.0};
        axis[2] = {"Axis Z", -300.0, 0.0, 60.0, 10.0};
    }

    bool loadFromFile(const std::string& explicit_path = "") {
        std::string path = explicit_path;
        if (path.empty()) {
            // Danh sách các đường dẫn ưu tiên tìm kiếm
            const std::string candidates[] = {
                "/home/bang/Downloads/project/Ajinextek_3Axis_Gantry_CNC/xyz_motion_ws/ros2_xyz_sim/config/sensors_config.yaml",
                "/home/bang/Downloads/project/Ajinextek_3Axis_Gantry_CNC/xyz_motion_ws/install/ros2_xyz_sim/share/ros2_xyz_sim/config/sensors_config.yaml",
                "../ros2_xyz_sim/config/sensors_config.yaml",
                "config/sensors_config.yaml"
            };
            for (const auto& c : candidates) {
                struct stat s;
                if (stat(c.c_str(), &s) == 0) {
                    path = c;
                    break;
                }
            }
        }

        if (path.empty()) return false;

        struct stat st;
        if (stat(path.c_str(), &st) != 0) {
            return false;
        }

        if (last_mtime != 0 && st.st_mtime == last_mtime) {
            return false; // Chưa có thay đổi
        }

        std::ifstream f(path);
        if (!f.is_open()) {
            return false;
        }

        std::string line;
        std::string current_axis = "";
        while (std::getline(f, line)) {
            if (line.find("axis_x:") != std::string::npos) current_axis = "x";
            else if (line.find("axis_y:") != std::string::npos) current_axis = "y";
            else if (line.find("axis_z:") != std::string::npos) current_axis = "z";

            int ax = -1;
            if (current_axis == "x") ax = 0;
            else if (current_axis == "y") ax = 1;
            else if (current_axis == "z") ax = 2;
            if (ax == -1) continue;

            auto parse_val = [&](const std::string& key) -> double {
                auto pos = line.find(key + ":");
                if (pos != std::string::npos) {
                    std::string sub = line.substr(pos + key.length() + 1);
                    auto comment_pos = sub.find("#");
                    if (comment_pos != std::string::npos) sub = sub.substr(0, comment_pos);
                    try { return std::stod(sub); } catch (...) {}
                }
                return -9999.0;
            };

            double v = parse_val("limit_min");
            if (v != -9999.0) axis[ax].limit_min = v;
            v = parse_val("home_org");
            if (v != -9999.0) axis[ax].home_org = v;
            v = parse_val("limit_max");
            if (v != -9999.0) axis[ax].limit_max = v;
            v = parse_val("sensor_width");
            if (v != -9999.0) axis[ax].sensor_width = v;
        }

        last_mtime = st.st_mtime;
        std::cout << "[SensorConfig] Đã nạp thành công cấu hình cảm biến từ: " << path << "\n"
                  << "  -> Trục X: Limit-=" << axis[0].limit_min << "mm, Home ORG=" << axis[0].home_org << "mm, Limit+=" << axis[0].limit_max << "mm\n"
                  << "  -> Trục Y: Limit-=" << axis[1].limit_min << "mm, Home ORG=" << axis[1].home_org << "mm, Limit+=" << axis[1].limit_max << "mm\n"
                  << "  -> Trục Z: Limit-=" << axis[2].limit_min << "mm, Home ORG=" << axis[2].home_org << "mm, Limit+=" << axis[2].limit_max << "mm" << std::endl;
        return true;
    }
};
