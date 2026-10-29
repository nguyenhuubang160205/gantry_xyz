# HỆ THỐNG MÔ PHỎNG 3 TRỤC XYZ GANTRY CNC & GIÁO TRÌNH THỰC HÀNH C++ CHUẨN MANUAL AJINEXTEK

> **Nền tảng**: Linux (Ubuntu 22.04 LTS / 24.04) + ROS 2 Humble + Gazebo 11 + PyQt5 Telemetry GUI  
> **Bộ Điều Khiển**: C++ Ajinextek Official Library (`libaxm_sim.so` / `AXL.h`, `AXM.h`, `AXHS.h` khớp 100% `thuvienAXM/`)  
> **Động Cơ & Truyền Động**: AC Servo + **Encoder Quang Học 20-bit ($2^{20} = 1,048,576\text{ pulses/rev}$)** + **Vít Me Bi Bước $2\text{ cm}$ ($20.0\text{ mm/rev}$)**  
> **Hành trình cơ khí**: $X \in [0, 800]\text{ mm}$, $Y \in [0, 680]\text{ mm}$, $Z \in [-300, +60]\text{ mm}$ (Gốc Home ORG tại $O(0,0,0)$, mặt phôi tại $Z = -198.5\text{ mm}$)

---

## 1. Cấu Trúc Dự Án

```text
gantry_xyz/
├── run.sh                               # Script duy nhất: Build, mở Gazebo 3D + GUI, và chạy các bài thực hành
├── manual_examples -> xyz_motion_ws/manual_examples
├── thuvienAXM/                          # Bộ thư viện header gốc chính hãng Ajinextek (AXL.h, AXM.h, AXHS.h, AXHD.h, AXDev.h)
├── user_aji/                            # Tài liệu sổ tay gốc [Manual] AXM_REF_ENG.pdf & AXL Manual
└── xyz_motion_ws/
    ├── gui_telemetry_monitor.py         # Giao diện đồ thị giám sát thời gian thực (Thêm đồ thị động + Record & Xuất CSV)
    ├── libaxm_core/                     # Nhân điều khiển chuyển động thời gian thực 1ms CSP (1000Hz) chuẩn Ajinextek
    ├── ros2_xyz_sim/                    # Mô hình 3D URDF/Xacro, Gazebo World & Cầu nối ROS 2 Sim Bridge 1000Hz
    └── manual_examples/                 # 14 Bài Thực Hành C++ Từ Cơ Bản Đến Nâng Cao Theo Sách Manual (Ex01 -> Ex14)
```

---

## 2. Danh Mục 14 Bài Thực Hành C++ Theo Sổ Tay `[Manual] AXM_REF_ENG.pdf`

Toàn bộ 14 bài ví dụ trong thư mục `manual_examples/` được biên soạn bám sát trình tự từ đầu đến cuối của cuốn Manual gốc Ajinextek:

| Bài | File Code C++ | Trang Manual | Chủ Đề Giảng Dạy & Các Hàm API Trọng Tâm |
| :--- | :--- | :---: | :--- |
| **Bài 01** | `Ex01_InitAndClose.cpp` | Trang 18 (`Ex1`) | **Khởi tạo & Đóng thư viện, Truy vấn phần cứng**: `AxlOpen`, `AxlIsOpened`, `AxmInfoIsMotionModule`, `AxmInfoGetAxisCount`, `AxmInfoGetAxis`, `AxmInfoGetFirstAxisNo`, `AxmInfoIsInvalidAxisNo`, `AxlClose`. |
| **Bài 02** | `Ex02_SettingParameter.cpp` | Trang 29 (`Ex2`) | **Cài đặt thông số Động học & Encoder 20-bit**: `AxmMotSetMoveUnitPerPulse` ($20\text{ mm}/2^{20}\text{ pulses}$), `AxmMotSetPulseOutMethod`, `AxmMotSetEncInputMethod`, `AxmMotSetMinVel`, `AxmMotSetMaxVel`, `AxmMotSetAccelUnit`, `AxmMotSetAccelJerk`, `AxmMotSaveParaAll`, `AxmMotLoadParaAll`. |
| **Bài 03** | `Ex03_SettingMotionSignal.cpp` | Trang 36 (`Ex3`) | **Tín hiệu bảo vệ phần cứng & Servo-ON**: `AxmSignalSetLimit`, `AxmSignalReadLimit`, `AxmSignalSetSoftLimit`, `AxmSignalReadSoftLimit`, `AxmSignalSetInpos`, `AxmSignalReadInpos`, `AxmSignalSetServoAlarm`, `AxmSignalServoAlarmReset`, `AxmSignalSetStop`, `AxmSignalServoOn`, `AxmSignalIsServoOn`. |
| **Bài 04** | `Ex04_SettingUniversalIO.cpp` | Trang 39 (`Ex4`) | **Đọc/Ghi Digital I/O đa năng**: `AxmSignalWriteOutput`, `AxmSignalReadOutput`, `AxmSignalWriteOutputBit`, `AxmSignalReadOutputBit`, `AxmSignalReadInput`, `AxmSignalReadInputBit`. |
| **Bài 05** | `Ex05_PositionMove_PTP.cpp` | Trang 51 (`Ex5`) | **Điều khiển vị trí đơn trục (PTP)**: So sánh trực quan đồ thị **Trapezoid (`SYM_TRAPEZOIDE_MODE`)** vs **S-Curve (`SYM_S_CURVE_MODE`)**, tọa độ Tuyệt đối (`POS_ABS_MODE`) vs Tương đối (`POS_REL_MODE`), Blocking (`AxmMovePos`) vs Non-Blocking (`AxmMoveStartPos`). |
| **Bài 06** | `Ex06_VelocityMove_JogAndStop.cpp` | Trang 54 (`Ex6`) | **Chạy vận tốc liên tục (Jog) & 3 Chế độ dừng**: `AxmMoveVel`, `AxmMoveStop` (giảm tốc theo `dDecel`), `AxmMoveSStop` (dừng mềm), `AxmMoveEStop` (dừng khẩn cấp tức thời). |
| **Bài 07** | `Ex07_SignalSearchAndTouchProbe.cpp` | Trang 59 (`Ex7`) | **Dò cảm biến & Chốt vị trí đầu dò phôi (Touch Probe)**: `AxmMoveSignalSearch`, `AxmMoveSignalCapture`, `AxmMoveGetCapturePos` (chốt chính xác mặt phôi tại $Z = -198.500\text{ mm}$). |
| **Bài 08** | `Ex08_HomeSearch_7Steps.cpp` | Trang 65 (`Ex8`) | **Quy trình về gốc Home Search 7 bước**: `AxmHomeSetMethod`, `AxmHomeGetMethod`, `AxmHomeSetVel` ($V_1, V_2, V_3, V_4$), `AxmHomeSetStart`, `AxmHomeGetRate`, `AxmHomeGetResult`, `AxmHomeReadSignal`. |
| **Bài 09** | `Ex09_MotionStatusMonitor.cpp` | Trang 74 (`Ex9`) | **Giám sát toàn diện trạng thái Motion & Servo**: `AxmStatusGetCmdPos`, `AxmStatusGetActPos`, `AxmStatusSetPosMatch`, `AxmStatusReadVel`, `AxmStatusReadActVel`, `AxmStatusReadPosError`, `AxmStatusReadMotion`, `AxmStatusReadMechanical`, `AxmStatusReadMotionInfo`, `AxmStatusReadServoMonitorValue`, `AxmStatusReadTorque`. |
| **Bài 10** | `Ex10_MultiAxisPositionDrive.cpp` | Trang 79 (`Ex11`) | **Điều khiển đồng thời đa trục (Multi-Axis PTP)**: `AxmMoveMultiPos`, `AxmMoveStartMultiPos`, `AxmMoveMultiStop`, `AxmMoveMultiSStop`, `AxmMoveMultiEStop`. |
| **Bài 11** | `Ex11_LinearAndCircularInterpolation.cpp` | Trang 86 (`Ex12`) | **Nội suy đường thẳng 3D, 4 kiểu Cung tròn & Xoắn ốc Helix**: `AxmLineMove`, `AxmCircleCenterMove`, `AxmCircleRadiusMove`, `AxmCircleAngleMove`, `AxmCirclePointMove`, `AxmHelixCenterMove`. |
| **Bài 12** | `Ex12_ContinuousInterpolationQueue.cpp` | Trang 95 (`Ex13`) | **Hàng đợi nội suy liên tục Look-Ahead (Conti Queue)**: `AxmContiWriteClear`, `AxmContiSetAxisMap`, `AxmContiSetAbsRelMode`, `AxmContiBeginNode`, `AxmContiEndNode`, `AxmContiStart`, `AxmContiGetNodeNum`, `AxmContiGetTotalNodeNum`, `AxmContiIsMotion`. |
| **Bài 13** | `Ex13_OverrideAndCRC.cpp` | Trang 101 (`Ex14–15`) | **Thay đổi nóng Vận tốc & Vị trí khi đang chạy (Override) + CRC**: `AxmOverrideSetMaxVel`, `AxmOverrideVel`, `AxmOverrideAccelVelDecel`, `AxmOverridePos`, `AxmOverrideVelAtPos`, `AxmCrcSetMaskLevel`, `AxmCrcSetOutput`. |
| **Bài 14** | `Ex14_GantrySyncTriggerAndMPG.cpp` | Trang 109 (`Ex16–22`) | **Đồng bộ Hộp số điện tử (Link), Gantry Master-Slave, MPG, Interrupt & Position Trigger**: `AxmLinkSetMode`, `AxmLinkResetMode`, `AxmGantrySetEnable`, `AxmGantrySetDisable`, `AxmMPGSetEnable`, `AxmTriggerSetTimeLevel`, `AxmTriggerSetBlock`, `AxmTriggerOneShot`, `AxmInterruptSetAxisEnable`. |

---

## 3. Hướng Dẫn Biên Dịch & Chạy Thực Hành

### Bước 1: Biên dịch toàn bộ hệ thống
```bash
chmod +x run.sh
./run.sh build
```

### Bước 2: Mở Mô Phỏng Gazebo 3D & Giao Diện Đồ Thị Giám Sát
```bash
./run.sh
```

### Bước 3: Chạy bất kỳ bài ví dụ nào trong 14 bài Manual (Terminal mới)
```bash
./run.sh Ex01
./run.sh Ex02
./run.sh Ex05
./run.sh Ex07
./run.sh Ex08
./run.sh Ex11
./run.sh Ex12
./run.sh Ex13
./run.sh Ex14
```
