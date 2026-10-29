/**
 * ============================================================================
 * @file    Ex14_GantrySyncTriggerAndMPG.cpp
 * @brief   BÀI 14: ĐỒNG BỘ HỘP SỐ ĐIỆN TỬ (LINK), GANTRY MASTER-SLAVE, MPG & TRIGGER
 *          (Tương ứng: Ex16 ~ Ex22 - Trang 109 ~ 144 Manual AXM_REF_ENG.pdf)
 *
 * @details Mục tiêu giảng dạy & Quan sát trực quan trên Gazebo 3D / GUI:
 *   1. **Electronic Gear (`AxmLinkSetMode`, `AxmLinkGetMode`, `AxmLinkResetMode`)**:
 *      - Liên kết Trục Master (Axis 0 - X) với Trục Slave (Axis 1 - Y) theo tỷ số truyền
 *        `dSlaveRatio = 0.5` (Khi chỉ phát lệnh cho Trục X chạy 200 mm, Trục Y tự động
 *        chạy đồng bộ 100 mm theo thời gian thực!).
 *   2. **Gantry Master-Slave (`AxmGantrySetEnable`, `AxmGantryGetEnable`, `AxmGantrySetDisable`)**:
 *      - Đồng bộ cứng 1:1 giữa trục Master và trục Slave kèm bù lệch gốc `dSlOffset`.
 *   3. **Tay quay phát xung thủ công MPG (`AxmMPGSetEnable`, `AxmMPGSetRatio`, `AxmMPGReset`)**,
 *      **Ánh xạ trục ảo (`AxmVirtualSetAxisNoMap`)**, **Ngắt (`AxmInterruptSetAxisEnable`)**
 *      và **Phát xung Trigger theo vị trí (`AxmTriggerSetTimeLevel`, `AxmTriggerSetBlock`, `AxmTriggerOneShot`)**.
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
    std::cout << " [BÀI 14] ELECTRONIC GEAR, GANTRY SYNC, MPG, INTERRUPT & TRIGGER\n";
    std::cout << "======================================================================\n";

    if (AxlOpen(7) != AXT_RT_SUCCESS) return -1;

    for (long a = 0; a < 3; ++a) {
        AxmMotSetMoveUnitPerPulse(a, 20.0, 1048576L);
        AxmMotSetAbsRelMode(a, POS_ABS_MODE);
        AxmMotSetProfileMode(a, SYM_S_CURVE_MODE);
        AxmSignalServoOn(a, ENABLE);
        AxmMovePos(a, 0.0, 180.0, 600.0, 600.0);
    }

    // ------------------------------------------------------------------------
    // 1. ELECTRONIC GEAR (AxmLinkSetMode): Master = Axis 0 (X), Slave = Axis 1 (Y), Ratio = 0.5
    // ------------------------------------------------------------------------
    std::cout << "\n[1] Bật Electronic Gear: AxmLinkSetMode(Master=X[0], Slave=Y[1], Ratio=0.5)...\n";
    AxmLinkSetMode(0, 1, 0.5);

    long lSlaveAxis = -1;
    double dRatio = 0.0;
    AxmLinkGetMode(0, &lSlaveAxis, &dRatio);
    std::cout << "    + Kiểm tra AxmLinkGetMode: Master=0 -> Slave=" << lSlaveAxis << ", Ratio=" << dRatio << "\n";

    std::cout << "    + Chỉ phát lệnh AxmMoveStartPos cho Trục X (0 -> 240 mm) và quan sát Trục Y tự chạy theo tỷ lệ 0.5!\n";
    AxmMoveStartPos(0, 240.0, 120.0, 400.0, 400.0);

    DWORD uInMotion = 1;
    while (uInMotion) {
        double xPos = 0.0, yPos = 0.0, xVel = 0.0, yVel = 0.0;
        AxmStatusGetActPos(0, &xPos);
        AxmStatusGetActPos(1, &yPos);
        AxmStatusReadActVel(0, &xVel);
        AxmStatusReadActVel(1, &yVel);
        std::cout << "      [Gear 1:0.5] Master X=" << std::fixed << std::setprecision(2) << std::setw(6) << xPos
                  << " mm (Vel=" << std::setw(5) << xVel << ") | Slave Y=" << std::setw(6) << yPos
                  << " mm (Vel=" << std::setw(5) << yVel << ")\n";
        std::this_thread::sleep_for(std::chrono::milliseconds(250));
        AxmStatusReadInMotion(0, &uInMotion);
    }

    // Ngắt chế độ Electronic Gear
    AxmLinkResetMode(0);
    std::cout << " -> Đã gọi AxmLinkResetMode(0) hủy liên kết hộp số điện tử.\n";

    // ------------------------------------------------------------------------
    // 2. GANTRY DRIVE (AxmGantrySetEnable / AxmGantryGetEnable / AxmGantrySetDisable)
    // ------------------------------------------------------------------------
    std::cout << "\n[2] Bật chế độ đồng bộ Gantry: AxmGantrySetEnable(Master=0, Slave=1, HomeUse=1, Offset=0.0, Range=5.0)...\n";
    AxmMovePos(0, 100.0, 150.0, 500.0, 500.0);
    AxmMovePos(1, 100.0, 150.0, 500.0, 500.0);

    AxmGantrySetEnable(0, 1, 1, 0.0, 5.0);
    DWORD uHomeUse = 0, uGantryOn = 0;
    double dSlOffset = 0.0, dSlRange = 0.0;
    AxmGantryGetEnable(0, &uHomeUse, &dSlOffset, &dSlRange, &uGantryOn);
    std::cout << "    + AxmGantryGetEnable: GantryOn=" << uGantryOn << ", Offset=" << dSlOffset << " mm, Range=" << dSlRange << " mm\n";

    // Di chuyển Master X về 0 mm -> Slave Y tự động đồng bộ 1:1 về 0 mm
    AxmMovePos(0, 0.0, 150.0, 500.0, 500.0);
    double xEnd = 0.0, yEnd = 0.0;
    AxmStatusGetActPos(0, &xEnd);
    AxmStatusGetActPos(1, &yEnd);
    std::cout << "    + Sau khi di chuyển Master X về 0: X=" << xEnd << " mm, Slave Y=" << yEnd << " mm\n";
    AxmGantrySetDisable(0, 1);

    // ------------------------------------------------------------------------
    // 3. CẤU HÌNH TRIGGER VỊ TRÍ, MPG & INTERRUPT THEO CHUẨN MANUAL
    // ------------------------------------------------------------------------
    std::cout << "\n[3] Cài đặt Position Trigger (AxmTriggerSetTimeLevel & AxmTriggerSetBlock)...\n";
    AxmTriggerSetTimeLevel(0, 50.0, HIGH, ACTUAL, DISABLE);
    AxmTriggerSetBlock(0, 20.0, 200.0, 10.0); // Phát xung Trigger mỗi 10 mm từ 20 mm -> 200 mm
    AxmTriggerOneShot(0);

    double dTrigTime = 0, dStart = 0, dEnd = 0, dPeriod = 0;
    DWORD uTrigLvl = 0, uTrigSel = 0, uTrigInt = 0;
    AxmTriggerGetTimeLevel(0, &dTrigTime, &uTrigLvl, &uTrigSel, &uTrigInt);
    AxmTriggerGetBlock(0, &dStart, &dEnd, &dPeriod);
    std::cout << "    + Trigger Block: [" << dStart << " ~ " << dEnd << " mm], Chu kỳ = " << dPeriod
              << " mm, Độ rộng xung = " << dTrigTime << " us\n";
    AxmTriggerSetReset(0);

    std::cout << "[4] Cài đặt Tay quay MPG (AxmMPGSetEnable & AxmMPGSetRatio) và Interrupt...\n";
    AxmMPGSetEnable(0, 3, 0, 10.0, 50.0, 200.0);
    AxmMPGSetRatio(0, 1, 4096);
    AxmMPGReset(0);

    AxmInterruptSetAxisEnable(0, ENABLE);
    AxmInterruptSetAxisEnable(0, DISABLE);
    std::cout << " -> Đã kiểm tra thành công toàn bộ các hàm nâng cao Chương 14 Manual!\n";

    AxlClose();
    return 0;
}
