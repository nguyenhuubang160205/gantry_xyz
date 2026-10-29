/**
 * ============================================================================
 * @file    Ex07_SignalSearchAndTouchProbe.cpp
 * @brief   BÀI 07: DÒ TÍN HIỆU CẢM BIẾN & CHỐT VỊ TRÍ ĐẦU DÒ PHÔI (SIGNAL SEARCH & CAPTURE)
 *          (Tương ứng: Ex7_AXM_SignalSearchDrive.cpp - Trang 59 Manual AXM_REF_ENG.pdf)
 *
 * @details Mục tiêu giảng dạy:
 *   1. Sử dụng `AxmMoveSignalSearch` để di chuyển trục cho đến khi bắt được sườn
 *      tín hiệu cảm biến (`HomeSensor`, `PosEndLimit`, `NegEndLimit`, `UniInput`).
 *   2. Sử dụng `AxmMoveSignalCapture` kết hợp `AxmMoveGetCapturePos` để thực hiện
 *      chu trình **Dò bề mặt phôi tự động (Touch Probe)** trên trục Z:
 *      - Hạ đầu dò trục Z đi xuống với vận tốc chậm (-15 mm/s).
 *      - Khi mũi đầu dò chạm mặt phôi (tại Z = -198.500 mm), phần cứng lập tức
 *        chốt (Latch) tọa độ Encoder 20-bit chính xác vào thanh ghi Capture và dừng trục!
 * ============================================================================
 */

#include <iostream>
#include <iomanip>
#include <thread>
#include <chrono>
#include "AXL.h"
#include "AXM.h"

int main() {
    std::cout << "======================================================================\n";
    std::cout << " [BÀI 07] DÒ CẢM BIẾN & CHỐT TỌA ĐỘ TOUCH PROBE (Ex7 Manual)\n";
    std::cout << "======================================================================\n";

    if (AxlOpen(7) != AXT_RT_SUCCESS) return -1;

    long axisX = 0, axisY = 1, axisZ = 2;
    for (long a = 0; a < 3; ++a) {
        AxmMotSetMoveUnitPerPulse(a, 20.0, 1048576L);
        AxmMotSetAbsRelMode(a, POS_ABS_MODE);
        AxmMotSetProfileMode(a, SYM_S_CURVE_MODE);
        AxmSignalServoOn(a, ENABLE);
    }

    // Bước 1: Đưa bàn máy XY tới vị trí tâm phôi (X = 200 mm, Y = 200 mm) và Z = -180 mm (cách mặt phôi 18.5 mm)
    std::cout << "[1] Di chuyển đầu dò tới vị trí chuẩn bị dò phôi: X=200, Y=200, Z=-180 mm...\n";
    AxmMovePos(axisZ, -50.0, 100.0, 400.0, 400.0);
    AxmMovePos(axisX, 200.0, 180.0, 600.0, 600.0);
    AxmMovePos(axisY, 200.0, 180.0, 600.0, 600.0);
    AxmMovePos(axisZ, -180.0, 80.0, 300.0, 300.0);

    // Bước 2: Kích hoạt hàm chuẩn AxmMoveSignalCapture trên Trục Z (Axis 2)
    //   - dVel = -15.0 mm/s (Hạ xuống chậm để bảo vệ kim dò)
    //   - lDetectSignal = 6 (UniInput02 / Touch Probe Input Bit 0)
    //   - lSignalEdge   = SIGNAL_UP_EDGE (1: Bắt sườn lên khi chạm phôi)
    //   - lTarget       = ACTUAL (1: Chốt theo vị trí thực tế của Encoder 20-bit)
    //   - lSignalMethod = EMERGENCY_STOP (0: Dừng ngay lập tức khi chạm bề mặt phôi)
    std::cout << "[2] Gọi AxmMoveSignalCapture(Axis Z, Vel=-15 mm/s, Edge=UP, Target=ACTUAL, E_STOP)...\n";
    AxmMoveSignalCapture(axisZ, -15.0, 200.0, 6, SIGNAL_UP_EDGE, ACTUAL, EMERGENCY_STOP);

    DWORD uInMotion = 1;
    while (uInMotion) {
        double zAct = 0.0;
        AxmStatusGetActPos(axisZ, &zAct);
        std::cout << "    -> Đang hạ đầu dò Z... ActPos = " << std::fixed << std::setprecision(3) << zAct << " mm\n";
        std::this_thread::sleep_for(std::chrono::milliseconds(200));
        AxmStatusReadInMotion(axisZ, &uInMotion);
    }

    // Bước 3: Đọc tọa độ bề mặt phôi đã chốt trong phần cứng bằng AxmMoveGetCapturePos
    double dCapturedZ = 0.0;
    AxmMoveGetCapturePos(axisZ, &dCapturedZ);
    std::cout << "\n[KẾT QUẢ CAPTURE] Đã chạm bề mặt phôi!\n";
    std::cout << "  + Tọa độ chốt từ AxmMoveGetCapturePos(Axis Z): Z_surface = "
              << std::fixed << std::setprecision(4) << dCapturedZ << " mm (Chuẩn thiết kế: -198.5000 mm)\n";

    // Bước 4: Nhấc trục Z lên vị trí an toàn Z = -150 mm sau khi dò xong
    std::cout << "[3] Nhấc đầu dò Z lên cao độ an toàn Z = -150.0 mm...\n";
    AxmMovePos(axisZ, -150.0, 80.0, 300.0, 300.0);

    AxlClose();
    return 0;
}
