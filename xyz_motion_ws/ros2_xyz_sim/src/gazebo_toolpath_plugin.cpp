#include "gazebo_toolpath_plugin.hpp"
#include <gazebo/gui/GuiIface.hh>
#include <gazebo/gui/GuiEvents.hh>
#include <iostream>
#include <algorithm>

namespace gazebo {

GazeboToolpathPlugin::GazeboToolpathPlugin()
    : GUIPlugin() {
}

GazeboToolpathPlugin::~GazeboToolpathPlugin() {
    pre_render_conn_.reset();
    main_window_conn_.reset();
    
    if (scene_ && scene_->WorldVisual()) {
        for (auto &stroke : active_strokes_) {
            for (auto *line : stroke.lines) {
                if (line) {
                    scene_->WorldVisual()->DeleteDynamicLine(line);
                }
            }
        }
    }
    active_strokes_.clear();
    shm_.close();
}

void GazeboToolpathPlugin::Load(sdf::ElementPtr /*_sdf*/) {
    this->resize(0, 0);
    this->setFixedSize(0, 0);
    this->hide();
    this->setVisible(false);
    this->setAttribute(Qt::WA_TransparentForMouseEvents, true);
    this->setAttribute(Qt::WA_TranslucentBackground, true);
    this->setStyleSheet("background: transparent; border: none;");

    is_shm_init_ = shm_.init(false);

    // Kết nối trực tiếp sự kiện PreRender của OGRE Renderer
    pre_render_conn_ = event::Events::ConnectPreRender(
        std::bind(&GazeboToolpathPlugin::OnPreRender, this));
        
    main_window_conn_ = gui::Events::ConnectMainWindowReady(
        std::bind(&GazeboToolpathPlugin::OnMainWindowReady, this));
        
    std::cout << "[GazeboToolpathPlugin] Dynamic 3D CNC Toolpath visualizer connected to PreRender." << std::endl;
}

void GazeboToolpathPlugin::OnMainWindowReady() {
    this->resize(0, 0);
    this->setFixedSize(0, 0);
    this->hide();
    this->setVisible(false);
    if (!pre_render_conn_) {
        pre_render_conn_ = event::Events::ConnectPreRender(
            std::bind(&GazeboToolpathPlugin::OnPreRender, this));
    }
    std::cout << "[GazeboToolpathPlugin] Gazebo MainWindow is ready." << std::endl;
}

void GazeboToolpathPlugin::OnPreRender() {
    if (!scene_) {
        scene_ = rendering::get_scene();
        if (!scene_ || !scene_->Initialized()) return;
    }

    rendering::VisualPtr root_vis = scene_->WorldVisual();
    if (!root_vis) {
        return;
    }

    if (!is_shm_init_) {
        is_shm_init_ = shm_.init(false);
    }

    MotionSharedData* data = shm_.get();
    if (!data) return;

    // Gốc tọa độ O(0,0,0) đặt tại cảm biến Home ORG (cao hơn mặt phôi 20cm = 200mm).
    // - Mặt trên phôi nằm tại Z = -198.0mm đến -200.0mm.
    // - Khi đầu kim cơ khí thực tế (actual_pos[2]) chạm mặt phôi (Z <= -197.0mm): BẬT vệt phay xén thịt phôi.
    bool is_cutting = (data->actual_pos[2] <= -197.0);

    // 1. High-Speed Dynamic Spindle & Cutter Rotation (Trục chính & dao phay xoay tròn)
    if (!collet_vis_) collet_vis_ = scene_->GetVisual("xyz_gantry::z_collet");
    if (!probe_vis_) probe_vis_ = scene_->GetVisual("xyz_gantry::z_probe_body");
    if (!ruby_vis_) ruby_vis_ = scene_->GetVisual("xyz_gantry::z_ruby_tip");

    // Dynamic rotation: Fast cutting spin (24,000 RPM) or idle rapid traverse spin (6,000 RPM)
    double spin_delta = is_cutting ? 0.65 : 0.20;
    spindle_angle_ += spin_delta;
    if (spindle_angle_ > 2.0 * M_PI) {
        spindle_angle_ -= 2.0 * M_PI;
    }
    ignition::math::Quaterniond rot(0, 0, spindle_angle_);
    if (collet_vis_) collet_vis_->SetRotation(rot);
    if (probe_vis_) probe_vis_->SetRotation(rot);
    if (ruby_vis_) ruby_vis_->SetRotation(rot);

    // 2. Auto-clear all strokes when a new program / run starts (epoch changes)
    if (!epoch_initialized_) {
        last_epoch_ = data->toolpath_epoch;
        epoch_initialized_ = true;
    } else if (data->toolpath_epoch != last_epoch_) {
        last_epoch_ = data->toolpath_epoch;
        for (auto &stroke : active_strokes_) {
            for (auto *line : stroke.lines) {
                if (line) {
                    root_vis->DeleteDynamicLine(line);
                }
            }
        }
        active_strokes_.clear();
        current_stroke_.lines.clear();
        is_in_stroke_ = false;
        has_prev_pos_ = false;
        std::cout << "[GazeboToolpathPlugin] Auto-cleared toolpath for new run (epoch " 
                  << last_epoch_ << ")." << std::endl;
    }

    // 3. Dynamic CNC Toolpath Rendering (Vết phay đỏ rực rỡ bám trên mặt phôi)
    if (is_cutting) {
        // Tọa độ đầu dao phay bám 100% theo tọa độ cơ học thực tế
        double tip_x = 0.30 + (data->actual_pos[0] / 1000.0);
        double tip_y = 0.30 + (data->actual_pos[1] / 1000.0);
        // Chiếu nét vẽ ở Z = 0.9025m (ngay trên mặt phôi để chống z-fighting và tránh bị phôi che khuất)
        double tip_z = 0.9025;

        ignition::math::Vector3d cur_tip(tip_x, tip_y, tip_z);
        ignition::math::Color red_color(1.0f, 0.05f, 0.05f, 1.0f);
        std::string mat_name = "Gazebo/Red";

        // 3 dải nét song song siêu mịn tạo nét vẽ đậm rõ nét (độ rộng ~0.8mm)
        const double OFFSETS[3][2] = {
            { 0.0,      0.0 },
            { 0.0004,  0.0004 },
            {-0.0004, -0.0004 }
        };

        // Khi bắt đầu 1 nét phay mới (hạ dao chạm phôi)
        if (!is_in_stroke_) {
            current_stroke_.lines.clear();
            for (int k = 0; k < 3; ++k) {
                rendering::DynamicLines *line = root_vis->CreateDynamicLine(rendering::RENDERING_LINE_STRIP);
                if (line) {
                    line->setMaterial(mat_name);
                    ignition::math::Vector3d p(cur_tip.X() + OFFSETS[k][0],
                                               cur_tip.Y() + OFFSETS[k][1],
                                               cur_tip.Z());
                    line->AddPoint(p, red_color);
                    line->AddPoint(p, red_color);
                    line->Update();
                    current_stroke_.lines.push_back(line);
                }
            }
            active_strokes_.push_back(current_stroke_);
            is_in_stroke_ = true;
            prev_tip_pos_ = cur_tip;
            has_prev_pos_ = true;
            std::cout << "[GazeboToolpathPlugin] Stroke " << active_strokes_.size() 
                      << " started at X=" << data->actual_pos[0] << " mm, Y=" << data->actual_pos[1] << " mm" << std::endl;
        } else {
            double dist = (cur_tip - prev_tip_pos_).Length();
            if (dist >= 0.0003) { // Độ phân giải 0.3 mm mượt mà
                for (size_t k = 0; k < current_stroke_.lines.size(); ++k) {
                    rendering::DynamicLines *line = current_stroke_.lines[k];
                    if (line) {
                        ignition::math::Vector3d p(cur_tip.X() + OFFSETS[k][0],
                                                   cur_tip.Y() + OFFSETS[k][1],
                                                   cur_tip.Z());
                        line->AddPoint(p, red_color);
                        line->Update();
                    }
                }
                prev_tip_pos_ = cur_tip;
            }
        }
    } else {
        // Nhấc dao an toàn trên không -> Ngắt nét vẽ
        is_in_stroke_ = false;
        has_prev_pos_ = false;
    }
}

GZ_REGISTER_GUI_PLUGIN(GazeboToolpathPlugin)

} // namespace gazebo
