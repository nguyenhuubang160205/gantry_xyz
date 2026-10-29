/**
 * ============================================================================
 * @file    Ex05_PositionMove_PTP.cpp
 * @brief   BÀI 05: ĐIỀU KHIỂN VỊ TRÍ ĐƠN TRỤC (PTP) - TRAPEZOID VS S-CURVE, ABS VS REL
 *          (Tương ứng: Ex5_AXM_PositionMove.cpp - Trang 51 Manual AXM_REF_ENG.pdf)
 *
 * @details Mục tiêu giảng dạy & Quan sát trên GUI / Gazebo:
 *   1. So sánh trực quan trên đồ thị Telemetry GUI giữa:
 *      - Profile Hình thang (`SYM_TRAPEZOIDE_MODE = 0`): Gia tốc nhảy bậc thẳng đứng.
 *      - Profile S-Curve (`SYM_S_CURVE_MODE = 3`): Gia tốc biến thiên mượt mà (giới hạn Jerk).
 *   2. Phân biệt hệ tọa độ Tuyệt đối (`POS_ABS_MODE = 0`) và Tương đối (`POS_REL_MODE = 1`).
 *   3. Phân biệt hàm chờ hoàn tất (`AxmMovePos` - Blocking) và hàm thoát ngay
 *      khi bắt đầu phát xung (`AxmMoveStartPos` - Non-Blocking + `AxmStatusReadInMotion`).
 * ============================================================================
 */

#include <iostream>
#include <iomanip>
#include <thread>
#include <chrono>
#include "AXL.h"
#include "AXM.h"

void printAxisTelemetry(long axis, const char* phaseLabel) {
    double cmdPos = 0.0, actPos = 0.0, cmdVel = 0.0, actVel = 0.0;
    AxmStatusGetCmdPos(axis, &cmdPos);
    AxmStatusGetActPos(axis, &actPos);
    AxmStatusReadVel(axis, &cmdVel);
    AxmStatusReadActVel(axis, &actVel);
    std::cout << "  [" << phaseLabel << "] CmdPos=" << std::fixed << std::setprecision(3) << std::setw(8) << cmdPos
              << " mm | ActPos=" << std::setw(8) << actPos
              << " mm | CmdVel=" << std::setprecision(2) << std::setw(7) << cmdVel
              << " mm/s | ActVel=" << std::setw(7) << actVel << " mm/s\n";
}

int main() {
    std::cout << "======================================================================\n";
    std::cout << " [BÀI 05] ĐIỀU KHIỂN VỊ TRÍ ĐƠN TRỤC (PTP): TRAPEZOID VS S-CURVE (Ex5)\n";
    std::cout << "======================================================================\n";

    if (AxlOpen(7) != AXT_RT_SUCCESS) return -1;

    long axisX = 0;
    AxmMotSetMoveUnitPerPulse(axisX, 20.0, 1048576L); // Encoder 20-bit, Vít me 20mm
    AxmSignalServoOn(axisX, ENABLE);

    // Đưa trục X về vị trí 0.0 mm ban đầu
    AxmMotSetAbsRelMode(axisX, POS_ABS_MODE);
    AxmMotSetProfileMode(axisX, SYM_S_CURVE_MODE);
    AxmMovePos(axisX, 0.0, 150.0, 600.0, 600.0);

    // ------------------------------------------------------------------------
    // THÍ NGHIỆM 1: Chạy PTP Tuyệt đối (POS_ABS_MODE) với Profile Hình Thang (Trapezoid)
    //               Non-Blocking (AxmMoveStartPos) từ X = 0 mm -> X = 250 mm
    // ------------------------------------------------------------------------
    std::cout << "\n[THÍ NGHIỆM 1] Chạy X: 0 -> 250 mm | POS_ABS_MODE | SYM_TRAPEZOIDE_MODE (Non-Blocking)\n";
    AxmMotSetAbsRelMode(axisX, POS_ABS_MODE);
    AxmMotSetProfileMode(axisX, SYM_TRAPEZOIDE_MODE);

    AxmMoveStartPos(axisX, 250.0, 120.0, 400.0, 400.0);

    DWORD uInMotion = 1;
    while (uInMotion) {
        printAxisTelemetry(axisX, "Trapezoid Abs");
        std::this_thread::sleep_for(std::chrono::milliseconds(250));
        AxmStatusReadInMotion(axisX, &uInMotion);
    }
    printAxisTelemetry(axisX, "Hoàn tất TN1 ");

    // ------------------------------------------------------------------------
    // THÍ NGHIỆM 2: Chạy PTP Tương đối (POS_REL_MODE) với Profile S-Curve
    //               Dịch thêm +150 mm (từ 250 mm -> 400 mm), sau đó lùi -400 mm về 0 mm
    // ------------------------------------------------------------------------
    std::cout << "\n[THÍ NGHIỆM 2] Dịch tương đối +150 mm (250 -> 400 mm) | POS_REL_MODE | SYM_S_CURVE_MODE\n";
    AxmMotSetAbsRelMode(axisX, POS_REL_MODE);
    AxmMotSetProfileMode(axisX, SYM_S_CURVE_MODE);

    AxmMoveStartPos(axisX, 150.0, 120.0, 400.0, 400.0);
    uInMotion = 1;
    while (uInMotion) {
        printAxisTelemetry(axisX, "S-Curve Rel+");
        std::this_thread::sleep_for(std::chrono::milliseconds(250));
        AxmStatusReadInMotion(axisX, &uInMotion);
    }
    printAxisTelemetry(axisX, "Đạt X=400mm  ");

    std::cout << "\n[THÍ NGHIỆM 3] Dùng hàm Blocking AxmMovePos quay về X = 0.0 mm (POS_ABS_MODE)...\n";
    AxmMotSetAbsRelMode(axisX, POS_ABS_MODE);
    AxmMovePos(axisX, 0.0, 150.0, 500.0, 500.0);
    printAxisTelemetry(axisX, "Về gốc X=0mm ");

    AxlClose();
    return 0;
}
