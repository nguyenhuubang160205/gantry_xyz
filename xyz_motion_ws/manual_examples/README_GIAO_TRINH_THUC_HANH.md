# GIÁO TRÌNH THỰC HÀNH C++ THEO SỔ TAY MANUAL AJINEXTEK (TỪ CƠ BẢN ĐẾN NÂNG CAO)

Thư mục `manual_examples/` chứa **14 bài thực hành C++ chuẩn hãng** được biên soạn bám sát 100% theo trình tự từ đầu đến cuối của tài liệu gốc **[Manual] AXM_REF_ENG.pdf** và bộ thư viện gốc `thuvienAXM/` (`AXL.h`, `AXM.h`, `AXHS.h`).

Mỗi bài đều được tích hợp sẵn thông số cơ khí thực tế của hệ **Gantry CNC 3 trục (Encoder quang học 20-bit = 1,048,576 xung/vòng, bước vít me 2 cm = 20.0 mm/vòng)** và chạy trực tiếp trên **Gazebo 3D + Giao diện đồ thị giám sát thời gian thực (Telemetry GUI)**.

---

## Cách Chạy Nhanh Cho Giảng Viên & Sinh Viên

1. **Bước 1: Mở mô phỏng Gazebo 3D & Giao diện đồ thị giám sát (chỉ cần chạy 1 lần):**
   ```bash
   ./run.sh
   ```
2. **Bước 2: Chạy bất kỳ bài ví dụ nào trong `manual_examples/`:**
   - **Cách 1 (Trong VS Code)**: Mở file `Ex01_...cpp` $\rightarrow$ `Ex14_...cpp` bất kỳ và nhấn nút **Run Code (`▶`)** ở góc trên bên phải.
   - **Cách 2 (Trên Terminal)**:
     ```bash
     ./run.sh Ex01_InitAndClose
     ./run.sh Ex05_PositionMove_PTP
     ./run.sh Ex11_LinearAndCircularInterpolation
     ./run.sh Ex13_OverrideAndCRC
     ```

---

## Danh Mục 14 Bài Thực Hành Tương Ứng Từng Chương Trong Manual

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
