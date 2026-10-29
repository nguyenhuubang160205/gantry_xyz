#pragma once

#include <gazebo/common/Plugin.hh>
#include <gazebo/gui/GuiPlugin.hh>
#include <gazebo/rendering/rendering.hh>
#include <gazebo/transport/transport.hh>
#include <gazebo/gui/gui.hh>

#include <QtWidgets/QWidget>
#include <vector>
#include <string>
#include <chrono>

#include "IPCSharedMemory.hpp"

namespace gazebo {

class GAZEBO_VISIBLE GazeboToolpathPlugin : public GUIPlugin {
public:
    GazeboToolpathPlugin();
    virtual ~GazeboToolpathPlugin();

    void Load(sdf::ElementPtr _sdf) override;

protected:
    void OnMainWindowReady();
    void OnPreRender();

private:
    event::ConnectionPtr main_window_conn_;
    event::ConnectionPtr pre_render_conn_;
    rendering::ScenePtr scene_{nullptr};
    
    struct StrokeGroup {
        std::vector<rendering::DynamicLines*> lines;
    };
    std::vector<StrokeGroup> active_strokes_;
    StrokeGroup current_stroke_;
    bool is_in_stroke_{false};

    IPCSharedMemory shm_;
    uint32_t last_epoch_{0};
    bool epoch_initialized_{false};
    bool is_shm_init_{false};

    ignition::math::Vector3d prev_tip_pos_{0, 0, 0};
    bool has_prev_pos_{false};

    // Dynamic High-Speed Spindle Rotation
    double spindle_angle_{0.0};
    rendering::VisualPtr collet_vis_{nullptr};
    rendering::VisualPtr probe_vis_{nullptr};
    rendering::VisualPtr ruby_vis_{nullptr};
};

} // namespace gazebo
