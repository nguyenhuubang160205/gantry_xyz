/**
 * ============================================================================
 * @file    Ex09_MotionStatusMonitor.cpp
 * @brief   BÀI 09: GIÁM SÁT TOÀN DIỆN TRẠNG THÁI CHUYỂN ĐỘNG, CƠ KHÍ & SERVO MONITOR
 *          (Tương ứng: Ex9_AXM_MotionStatus.cpp - Trang 74 Manual AXM_REF_ENG.pdf)
 *
 * @details Mục tiêu giảng dạy:
 *   1. Đọc vị trí đặt `AxmStatusGetCmdPos`, vị trí thực `AxmStatusGetActPos`,
 *      sai số bám `AxmStatusReadPosError`, vận tốc `AxmStatusReadVel` / `AxmStatusReadActVel`.
 *   2. Đồng bộ hóa bộ đếm vị trí bằng `AxmStatusSetPosMatch(axis, dPos)`.
 *   3. Giải mã thanh ghi trạng thái chuyển động `AxmStatusReadMotion` (`QIDRIVE_STATUS_*`)
 *      và thanh ghi cơ khí `AxmStatusReadMechanical` (`QIMECHANICAL_*`).
 *   4. Đọc cấu trúc tổng hợp `MOTION_INFO` qua `AxmStatusReadMotionInfo` và
 *      giám sát tải Servo qua `AxmStatusReadServoMonitorValue` & `AxmStatusReadTorque`.
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
    std::cout << " [BÀI 09] GIÁM SÁT TRẠNG THÁI MOTION, MECHANICAL & SERVO MONITOR (Ex9)\n";
    std::cout << "======================================================================\n";

    if (AxlOpen(7) != AXT_RT_SUCCESS) return -1;

    long axisX = 0;
    AxmMotSetMoveUnitPerPulse(axisX, 20.0, 1048576L);
    AxmMotSetAbsRelMode(axisX, POS_ABS_MODE);
    AxmMotSetProfileMode(axisX, SYM_S_CURVE_MODE);
    AxmSignalServoOn(axisX, ENABLE);

    // Đồng bộ tọa độ CmdPos = ActPos = 0.0 mm bằng AxmStatusSetPosMatch
    AxmMovePos(axisX, 0.0, 150.0, 500.0, 500.0);
    AxmStatusSetPosMatch(axisX, 0.0);

    // Phát lệnh di chuyển Non-Blocking tới X = 300 mm để giám sát trạng thái thời gian thực
    std::cout << "[1] Khởi chạy AxmMoveStartPos(Axis X -> 300.0 mm, Vel=150 mm/s, Acc=450 mm/s^2)...\n\n";
    AxmMoveStartPos(axisX, 300.0, 150.0, 450.0, 450.0);

    DWORD uInMotion = 1;
    while (uInMotion) {
        double dCmdPos = 0.0, dActPos = 0.0, dPosErr = 0.0;
        double dCmdVel = 0.0, dActVel = 0.0, dTorque = 0.0, dMonPerr = 0.0;
        DWORD  uDrvStat = 0, uMechStat = 0;

        AxmStatusGetCmdPos(axisX, &dCmdPos);
        AxmStatusGetActPos(axisX, &dActPos);
        AxmStatusReadPosError(axisX, &dPosErr);
        AxmStatusReadVel(axisX, &dCmdVel);
        AxmStatusReadActVel(axisX, &dActVel);
        AxmStatusReadMotion(axisX, &uDrvStat);
        AxmStatusReadMechanical(axisX, &uMechStat);
        AxmStatusReadTorque(axisX, &dTorque);
        AxmStatusReadServoMonitorValue(axisX, _MONI_PERR_, &dMonPerr);

        // Giải mã trạng thái QIDRIVE_STATUS: Bit0=Busy, Bit1=Decel, Bit2=Const, Bit3=Accel
        const char* phase = "IDLE ";
        if (uDrvStat & QIDRIVE_STATUS_3) phase = "ACCEL";
        else if (uDrvStat & QIDRIVE_STATUS_2) phase = "CONST";
        else if (uDrvStat & QIDRIVE_STATUS_1) phase = "DECEL";

        std::cout << "  [" << phase << "] Cmd=" << std::fixed << std::setprecision(2) << std::setw(6) << dCmdPos
                  << " | Act=" << std::setw(6) << dActPos
                  << " | Err=" << std::setprecision(4) << std::setw(7) << dPosErr
                  << " mm | Vel=" << std::setprecision(1) << std::setw(5) << dActVel
                  << " mm/s | Trq=" << std::setw(5) << dTorque
                  << "% | Mech=0x" << std::hex << std::setw(2) << std::setfill('0') << uMechStat << std::dec << std::setfill(' ') << "\n";

        std::this_thread::sleep_for(std::chrono::milliseconds(200));
        AxmStatusReadInMotion(axisX, &uInMotion);
    }

    // Đọc toàn bộ bằng cấu trúc MOTION_INFO (AxmStatusReadMotionInfo)
    MOTION_INFO mi{};
    mi.dwMask = 0x1F; // Đọc tất cả các trường: CmdPos, ActPos, MechSig, DrvStat, Input/Output
    AxmStatusReadMotionInfo(axisX, &mi);
    std::cout << "\n[2] Kết quả đọc AxmStatusReadMotionInfo sau khi dừng:\n";
    std::cout << "    + dCmdPos = " << mi.dCmdPos << " mm | dActPos = " << mi.dActPos << " mm\n";
    std::cout << "    + dwMechSig = 0x" << std::hex << mi.dwMechSig << " (In-Position Bit = "
              << ((mi.dwMechSig & QIMECHANICAL_INP_LEVEL) ? "1" : "0") << ")\n" << std::dec;

    // Đưa trục X về 0
    AxmMovePos(axisX, 0.0, 150.0, 500.0, 500.0);
    AxlClose();
    return 0;
}
