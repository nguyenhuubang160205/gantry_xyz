#!/usr/bin/env bash
# ==============================================================================================
#  SCRIPT DUY NHẤT KHỞI ĐỘNG HỆ THỐNG MÔ PHỎNG 3 TRỤC XYZ GANTRY CNC & 14 BÀI VÍ DỤ MANUAL
#  Cách dùng:
#    ./run.sh                 -> Mở đồng thời Mô phỏng Gazebo 3D + Giao diện Giám sát Đồ thị & CSV
#    ./run.sh build           -> Biên dịch lại toàn bộ hệ thống (libaxm_core + manual_examples + ROS 2)
#    ./run.sh gui             -> Chỉ mở riêng Giao diện Giám sát Đồ thị & CSV
#    ./run.sh <Ex01..Ex14>    -> Biên dịch và chạy chương trình ví dụ Manual trong manual_examples/
# ==============================================================================================

SCRIPT_DIR="$(cd "$(dirname "$(readlink -f "${BASH_SOURCE[0]}")")" && pwd)"
WS_DIR="$SCRIPT_DIR/xyz_motion_ws"
MANUAL_EX_DIR="$WS_DIR/manual_examples"
export PATH=$HOME/.local/bin:$PATH
export LD_LIBRARY_PATH="$WS_DIR/lib:$LD_LIBRARY_PATH"

ARG="$1"

# ----------------------------------------------------------------------------------------------
# 1. CHẾ ĐỘ BUILD TOÀN BỘ HỆ THỐNG: ./run.sh build
# ----------------------------------------------------------------------------------------------
if [ "$ARG" = "build" ]; then
    set -e
    echo "============================================================"
    echo "  AJINEXTEK 3-AXIS XYZ GANTRY 800mm - AUTOMATED BUILD ALL"
    echo "============================================================"

    echo "[1/3] Biên dịch thư viện C++ libaxm_core..."
    mkdir -p "$WS_DIR/libaxm_core/build"
    cd "$WS_DIR/libaxm_core/build"
    cmake .. -DCMAKE_BUILD_TYPE=Release
    make -j$(nproc)

    echo "[2/3] Biên dịch 14 bài thực hành giảng dạy trong manual_examples..."
    mkdir -p "$MANUAL_EX_DIR/build"
    cd "$MANUAL_EX_DIR/build"
    cmake .. -DCMAKE_BUILD_TYPE=Release
    make -j$(nproc)
    cp -f "$MANUAL_EX_DIR/build/compile_commands.json" "$SCRIPT_DIR/compile_commands.json" 2>/dev/null || true

    echo "[3/3] Biên dịch gói mô phỏng ROS 2 ros2_xyz_sim..."
    if [ -f "/opt/ros/humble/setup.bash" ]; then
        source /opt/ros/humble/setup.bash
        cd "$WS_DIR"
        colcon build --packages-select ros2_xyz_sim
    fi

    echo "============================================================"
    echo "  TẤT CẢ CÁC THÀNH PHẦN ĐÃ ĐƯỢC BIÊN DỊCH THÀNH CÔNG 100%!"
    echo "============================================================"
    exit 0
fi

# ----------------------------------------------------------------------------------------------
# 2. CHẾ ĐỘ CHỈ MỞ GIAO DIỆN GIÁM SÁT: ./run.sh gui
# ----------------------------------------------------------------------------------------------
if [ "$ARG" = "gui" ]; then
    exec python3 "$WS_DIR/gui_telemetry_monitor.py"
fi

# ----------------------------------------------------------------------------------------------
# 3. CHẾ ĐỘ CHẠY CHƯƠNG TRÌNH VÍ DỤ MANUAL (Ex01..Ex14): ./run.sh <Ex01..Ex14>
# ----------------------------------------------------------------------------------------------
if [ -n "$ARG" ]; then
    set -e
    CLEAN_NAME=$(basename "$ARG" .cpp)
    TARGET=""

    if [ -f "$MANUAL_EX_DIR/${CLEAN_NAME}.cpp" ]; then
        TARGET="$CLEAN_NAME"
    else
        MATCH_EX=$(find "$MANUAL_EX_DIR" -maxdepth 1 -name "*${CLEAN_NAME}*.cpp" | sort | head -n 1)
        if [ -n "$MATCH_EX" ]; then
            TARGET=$(basename "$MATCH_EX" .cpp)
        else
            echo "❌ Không tìm thấy bài ví dụ '$ARG' trong manual_examples/"
            exit 1
        fi
    fi

    BUILD_DIR="$MANUAL_EX_DIR/build"
    mkdir -p "$BUILD_DIR"

    echo "===================================================="
    echo "  BIÊN DỊCH & CHẠY: ${TARGET}.cpp"
    echo "===================================================="
    cd "$BUILD_DIR"
    if ! cmake .. > /dev/null 2>&1; then
        rm -rf CMakeCache.txt CMakeFiles
        cmake .. > /dev/null 2>&1
    fi
    make -j4 "$TARGET"
    echo ""
    exec "./$TARGET"
fi

# ----------------------------------------------------------------------------------------------
# 4. MẶC ĐỊNH KHI CHẠY ./run.sh: MỞ ĐỒNG THỜI GAZEBO 3D + GIAO DIỆN GIÁM SÁT ĐỒ THỊ
# ----------------------------------------------------------------------------------------------
echo "====================================================================="
echo "  KHỞI ĐỘNG MÔ PHỎNG GAZEBO 3D & GIAO DIỆN GIÁM SÁT ĐỒ THỊ (AJINEXTEK)"
echo "====================================================================="

killall -9 gzserver gzclient rviz2 sim_bridge_node robot_state_publisher spawner 2>/dev/null || true
pkill -f "gui_telemetry_monitor.py" 2>/dev/null || true
sleep 1

python3 -c "
import os
shm_path = '/dev/shm/xyz_motion_shm'
if not os.path.exists(shm_path) or os.path.getsize(shm_path) < 352:
    with open(shm_path, 'wb') as f:
        f.write(b'\x00' * 352)
" 2>/dev/null || true

if [ -f /usr/share/gazebo/setup.bash ]; then
    source /usr/share/gazebo/setup.bash
elif [ -f /usr/share/gazebo-11/setup.bash ]; then
    source /usr/share/gazebo-11/setup.bash
fi

source /opt/ros/humble/setup.bash
source "$WS_DIR/install/setup.bash"

export GAZEBO_PLUGIN_PATH="$WS_DIR/install/ros2_xyz_sim/lib:$WS_DIR/install/ros2_xyz_sim/lib/ros2_xyz_sim:$WS_DIR/build/ros2_xyz_sim:$WS_DIR/install/lib:$GAZEBO_PLUGIN_PATH"
export LD_LIBRARY_PATH="$WS_DIR/install/ros2_xyz_sim/lib:$WS_DIR/install/ros2_xyz_sim/lib/ros2_xyz_sim:$WS_DIR/build/ros2_xyz_sim:$WS_DIR/install/lib:$WS_DIR/lib:$LD_LIBRARY_PATH"
export GAZEBO_RESOURCE_PATH="$WS_DIR/install/ros2_xyz_sim/share/ros2_xyz_sim:$WS_DIR/ros2_xyz_sim:$GAZEBO_RESOURCE_PATH"
export GAZEBO_MODEL_PATH="$WS_DIR/install/ros2_xyz_sim/share:$WS_DIR:$GAZEBO_MODEL_PATH"

echo "-> [1/3] Đang khởi động Gazebo Server & ROS 2 Sim Bridge 1000Hz..."
ros2 launch ros2_xyz_sim display_sim.launch.py &
LAUNCH_PID=$!

echo "-> [2/3] Đang mở Giao diện Giám sát Đồ thị & Record CSV..."
python3 "$WS_DIR/gui_telemetry_monitor.py" &
GUI_PID=$!

cleanup() {
    echo ""
    echo "-> Đang đóng Gazebo và Giao diện Giám sát..."
    kill -9 $GUI_PID $LAUNCH_PID 2>/dev/null || true
    killall -9 gzserver gzclient rviz2 sim_bridge_node robot_state_publisher spawner 2>/dev/null || true
}
trap cleanup EXIT INT TERM

sleep 4.0

echo "-> [3/3] Đang mở cửa sổ 3D Gazebo Client..."
gzclient
