/**
 * ============================================================================
 * @file    Ex13_OverrideAndCRC.cpp
 * @brief   BÀI 13: THAY ĐỔI NÓNG VẬN TỐC / VỊ TRÍ ĐÍCH KHI ĐANG CHẠY (OVERRIDE) & TÍN HIỆU CRC
 *          (Tương ứng: Ex14 & Ex15 - Trang 101 & 107 Manual AXM_REF_ENG.pdf)
 *
 * @details Mục tiêu giảng dạy & Quan sát trực quan trên đồ thị GUI:
 *   1. **Velocity Override (`AxmOverrideSetMaxVel`, `AxmOverrideVel`, `AxmOverrideAccelVelDecel`)**:
 *      - Khi trục X đang di chuyển từ 0 -> 500 mm ở vận tốc 60 mm/s, gọi `AxmOverrideVel`
 *        tăng vọt vận tốc lên 180 mm/s rồi hạ xuống 80 mm/s ngay trong lúc trục đang chạy!
 *   2. **Position OverrideAtPos (`AxmOverrideVelAtPos`)**:
 *      - Tự động đổi vận tốc từ V1 = 70 mm/s sang V2 = 180 mm/s ngay khi trục đi qua
 *        tọa độ mốc `dOverridePos = 150.0 mm`.
 *   3. **Position Override (`AxmOverridePos`)**:
 *      - Khi trục đang chạy tới đích 250 mm, gọi `AxmOverridePos` kéo dài đích đến 400 mm
 *        mà không hề bị khựng vận tốc!
 *   4. **CRC Signal (`AxmCrcSetMaskLevel`, `AxmCrcGetMaskLevel`, `AxmCrcSetOutput`)**:
 *      - Cấu hình tín hiệu xóa xung dư (Current Remaining Clear) gửi tới bộ Servo Driver.
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
    std::cout << " [BÀI 13] OVERRIDE VẬN TỐC / VỊ TRÍ THỜI GIAN THỰC & TÍN HIỆU CRC\n";
    std::cout << "======================================================================\n";

    if (AxlOpen(7) != AXT_RT_SUCCESS) return -1;

    long axisX = 0;
    AxmMotSetMoveUnitPerPulse(axisX, 20.0, 1048576L);
    AxmMotSetAbsRelMode(axisX, POS_ABS_MODE);
    AxmMotSetProfileMode(axisX, SYM_S_CURVE_MODE);
    AxmSignalServoOn(axisX, ENABLE);

    // Đưa trục X về 0.0 mm
    AxmMovePos(axisX, 0.0, 180.0, 600.0, 600.0);

    // ------------------------------------------------------------------------
    // THÍ NGHIỆM 1: AxmOverrideVelAtPos - Tự động tăng tốc khi đi qua mốc X = 120 mm
    // ------------------------------------------------------------------------
    std::cout << "\n[1] AxmOverrideVelAtPos: Chạy X: 0 -> 420 mm với V1=70 mm/s, tự động tăng lên V2=180 mm/s tại X=120 mm!\n";
    AxmOverrideSetMaxVel(axisX, 300.0);
    AxmOverrideVelAtPos(axisX, 420.0, 70.0, 500.0, 500.0, 120.0, 180.0, ACTUAL);

    DWORD uInMotion = 1;
    while (uInMotion) {
        double pos = 0.0, vel = 0.0;
        AxmStatusGetActPos(axisX, &pos);
        AxmStatusReadActVel(axisX, &vel);
        std::cout << "    + [OverrideVelAtPos] ActPos = " << std::fixed << std::setprecision(2) << std::setw(6) << pos
                  << " mm | ActVel = " << std::setw(6) << vel << " mm/s\n";
        std::this_thread::sleep_for(std::chrono::milliseconds(200));
        AxmStatusReadInMotion(axisX, &uInMotion);
    }

    // ------------------------------------------------------------------------
    // THÍ NGHIỆM 2: AxmOverrideVel & AxmOverridePos trực tiếp trong khi đang chạy về
    // ------------------------------------------------------------------------
    std::cout << "\n[2] Khởi chạy X từ 420 mm -> 200 mm ở V=60 mm/s, sau đó gọi AxmOverrideVel(150 mm/s) & AxmOverridePos(0.0 mm)...\n";
    AxmMoveStartPos(axisX, 200.0, 60.0, 400.0, 400.0);

    std::this_thread::sleep_for(std::chrono::milliseconds(600));
    std::cout << " -> Gọi AxmOverrideVel(150.0 mm/s) & AxmOverridePos(0.0 mm) ngay khi trục đang chạy!\n";
    AxmOverrideVel(axisX, 150.0);
    AxmOverridePos(axisX, 0.0);

    uInMotion = 1;
    while (uInMotion) {
        double pos = 0.0, vel = 0.0;
        AxmStatusGetActPos(axisX, &pos);
        AxmStatusReadActVel(axisX, &vel);
        std::cout << "    + [Live Override] ActPos = " << std::fixed << std::setprecision(2) << std::setw(6) << pos
                  << " mm | ActVel = " << std::setw(6) << vel << " mm/s\n";
        std::this_thread::sleep_for(std::chrono::milliseconds(200));
        AxmStatusReadInMotion(axisX, &uInMotion);
    }

    // ------------------------------------------------------------------------
    // THÍ NGHIỆM 3: Cài đặt & phát xung xóa sai số tồn dư CRC (Current Remaining Clear)
    // ------------------------------------------------------------------------
    AxmCrcSetMaskLevel(axisX, HIGH, 3); // Mức HIGH, độ rộng xung 1 ms (Method = 3)
    DWORD uCrcLevel = 0, uCrcMethod = 0, uCrcOn = 0;
    AxmCrcGetMaskLevel(axisX, &uCrcLevel, &uCrcMethod);
    AxmCrcSetOutput(axisX, ENABLE);
    AxmCrcGetOutput(axisX, &uCrcOn);
    AxmCrcSetOutput(axisX, DISABLE);
    std::cout << "\n[3] Kiểm tra CRC Signal: Level=" << uCrcLevel << ", PulseWidthMethod=" << uCrcMethod
              << ", CrcOutputTriggered=" << uCrcOn << "\n";

    AxlClose();
    return 0;
}
