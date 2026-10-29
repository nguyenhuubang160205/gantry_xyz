/**
 * ============================================================================
 * @file    Ex10_MultiAxisPositionDrive.cpp
 * @brief   BÀI 10: ĐIỀU KHIỂN ĐỒNG THỜI ĐA TRỤC (MULTI-AXIS PTP DRIVE & MULTI-STOP)
 *          (Tương ứng: Ex11_AXM_MultiPositionDrive.cpp - Trang 79 Manual AXM_REF_ENG.pdf)
 *
 * @details Mục tiêu giảng dạy:
 *   1. Sử dụng `AxmMoveMultiPos` (Blocking) và `AxmMoveStartMultiPos` (Non-Blocking)
 *      để phát lệnh di chuyển đồng thời cả 3 trục X, Y, Z chỉ bằng 1 lời gọi hàm,
 *      trong đó mỗi trục có vị trí đích, vận tốc và gia tốc độc lập.
 *   2. Sử dụng `AxmMoveMultiStop`, `AxmMoveMultiSStop`, `AxmMoveMultiEStop` để
 *      dừng đồng bộ nhiều trục cùng lúc.
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
    std::cout << " [BÀI 10] ĐIỀU KHIỂN ĐA TRỤC ĐỒNG THỜI (AxmMoveMultiPos / StartMultiPos)\n";
    std::cout << "======================================================================\n";

    if (AxlOpen(7) != AXT_RT_SUCCESS) return -1;

    long   lAxes[3]  = {0, 1, 2};
    for (int i = 0; i < 3; ++i) {
        AxmMotSetMoveUnitPerPulse(lAxes[i], 20.0, 1048576L);
        AxmMotSetAbsRelMode(lAxes[i], POS_ABS_MODE);
        AxmMotSetProfileMode(lAxes[i], SYM_S_CURVE_MODE);
        AxmSignalServoOn(lAxes[i], ENABLE);
    }

    // ------------------------------------------------------------------------
    // 1. Dùng AxmMoveMultiPos (Blocking) đưa cả 3 trục tới điểm P1(300, 250, -120)
    // ------------------------------------------------------------------------
    double dPos1[3]   = {300.0, 250.0, -120.0};
    double dVel1[3]   = {150.0, 125.0,  60.0};
    double dAccel1[3] = {450.0, 400.0, 250.0};
    double dDecel1[3] = {450.0, 400.0, 250.0};

    std::cout << "[1] Gọi AxmMoveMultiPos (Blocking) đưa 3 trục tới P1(300, 250, -120 mm)...\n";
    AxmMoveMultiPos(3, lAxes, dPos1, dVel1, dAccel1, dDecel1);

    double x = 0, y = 0, z = 0;
    AxmStatusGetActPos(0, &x);
    AxmStatusGetActPos(1, &y);
    AxmStatusGetActPos(2, &z);
    std::cout << " -> Đã tới P1: X=" << std::fixed << std::setprecision(2) << x
              << " mm, Y=" << y << " mm, Z=" << z << " mm\n\n";

    // ------------------------------------------------------------------------
    // 2. Dùng AxmMoveStartMultiPos (Non-Blocking) hướng tới P2(600, 500, -200),
    //    sau 1.0 giây gọi AxmMoveMultiStop để dừng mượt đồng thời cả 3 trục!
    // ------------------------------------------------------------------------
    double dPos2[3] = {600.0, 500.0, -200.0};
    std::cout << "[2] Gọi AxmMoveStartMultiPos (Non-Blocking) hướng tới P2(600, 500, -200 mm)...\n";
    AxmMoveStartMultiPos(3, lAxes, dPos2, dVel1, dAccel1, dDecel1);

    for (int step = 0; step < 4; ++step) {
        std::this_thread::sleep_for(std::chrono::milliseconds(250));
        AxmStatusGetActPos(0, &x);
        AxmStatusGetActPos(1, &y);
        AxmStatusGetActPos(2, &z);
        std::cout << "    + Đang chạy đa trục: X=" << x << " mm, Y=" << y << " mm, Z=" << z << " mm\n";
    }

    std::cout << " -> Gọi AxmMoveMultiStop(3, lAxes, dDecel1) dừng đồng thời cả 3 trục giữa chừng!\n";
    AxmMoveMultiStop(3, lAxes, dDecel1);
    std::this_thread::sleep_for(std::chrono::milliseconds(600));

    // ------------------------------------------------------------------------
    // 3. Quay về gốc O(0, 0, 0) bằng AxmMoveMultiPos
    // ------------------------------------------------------------------------
    double dHomePos[3] = {0.0, 0.0, 0.0};
    std::cout << "\n[3] Đưa cả 3 trục về gốc O(0, 0, 0) bằng AxmMoveMultiPos...\n";
    AxmMoveMultiPos(3, lAxes, dHomePos, dVel1, dAccel1, dDecel1);
    std::cout << " -> Hoàn tất Bài 10.\n";

    AxlClose();
    return 0;
}
