/**
 * ============================================================================
 * @file    Ex06_VelocityMove_JogAndStop.cpp
 * @brief   BÀI 06: CHẠY VẬN TỐC LIÊN TỤC (JOG DRIVE) & 3 PHƯƠNG PHÁP DỪNG TRỤC
 *          (Tương ứng: Ex6_AXM_VelocityMove.cpp - Trang 54 Manual AXM_REF_ENG.pdf)
 *
 * @details Mục tiêu giảng dạy:
 *   1. Điều khiển trục chạy liên tục theo vận tốc (`AxmMoveVel`):
 *      - dVel > 0: Chạy theo chiều dương (+CW)
 *      - dVel < 0: Chạy theo chiều âm (-CCW)
 *   2. Điều khiển Jog nhiều trục đồng thời (`AxmMoveStartMultiVel`).
 *   3. Phân biệt 3 lệnh dừng chuẩn của Ajinextek trên đồ thị vận tốc:
 *      - `AxmMoveStop(axis, dDecel)`: Giảm tốc dừng mượt theo gia tốc giảm `dDecel` chỉ định.
 *      - `AxmMoveSStop(axis)`       : Giảm tốc dừng mềm (Slowdown Stop) theo thông số mặc định.
 *      - `AxmMoveEStop(axis)`       : Dừng khẩn cấp tức thời (Emergency Stop - ngắt xung ngay).
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
    std::cout << " [BÀI 06] CHẠY VẬN TỐC (JOG) & SO SÁNH S-STOP / DECEL-STOP / E-STOP\n";
    std::cout << "======================================================================\n";

    if (AxlOpen(7) != AXT_RT_SUCCESS) return -1;

    long axisY = 1;
    AxmMotSetMoveUnitPerPulse(axisY, 20.0, 1048576L);
    AxmSignalServoOn(axisY, ENABLE);

    // Đưa trục Y về vị trí xuất phát 50.0 mm
    AxmMotSetAbsRelMode(axisY, POS_ABS_MODE);
    AxmMovePos(axisY, 50.0, 150.0, 500.0, 500.0);

    // ------------------------------------------------------------------------
    // 1. Chạy Jog chiều dương (+CW) với vận tốc +100 mm/s và dừng bằng AxmMoveStop(dDecel)
    // ------------------------------------------------------------------------
    std::cout << "\n[1] AxmMoveVel(Axis Y, +100.0 mm/s, Acc=300, Dec=300) trong 1.2 giây...\n";
    AxmMoveVel(axisY, 100.0, 300.0, 300.0);

    for (int i = 0; i < 4; ++i) {
        std::this_thread::sleep_for(std::chrono::milliseconds(300));
        double pos = 0.0, vel = 0.0;
        AxmStatusGetActPos(axisY, &pos);
        AxmStatusReadActVel(axisY, &vel);
        std::cout << "    + Đang Jog (+CW): ActPos = " << std::fixed << std::setprecision(2) << pos
                  << " mm | ActVel = " << vel << " mm/s\n";
    }

    std::cout << " -> Gọi AxmMoveStop(Axis Y, Decel = 250.0 mm/s^2) để giảm tốc dừng mượt...\n";
    AxmMoveStop(axisY, 250.0);
    DWORD uInMotion = 1;
    while (uInMotion) {
        std::this_thread::sleep_for(std::chrono::milliseconds(50));
        AxmStatusReadInMotion(axisY, &uInMotion);
    }
    double stopPos1 = 0.0;
    AxmStatusGetActPos(axisY, &stopPos1);
    std::cout << " -> Đã dừng hẳn tại Y = " << stopPos1 << " mm.\n";

    // ------------------------------------------------------------------------
    // 2. Chạy Jog chiều âm (-CCW) với vận tốc -80 mm/s và dừng khẩn cấp bằng AxmMoveEStop
    // ------------------------------------------------------------------------
    std::cout << "\n[2] AxmMoveVel(Axis Y, -80.0 mm/s) trong 0.9 giây rồi gọi AxmMoveEStop...\n";
    AxmMoveVel(axisY, -80.0, 300.0, 300.0);
    std::this_thread::sleep_for(std::chrono::milliseconds(900));

    AxmMoveEStop(axisY);
    double stopPos2 = 0.0, stopVel2 = 0.0;
    AxmStatusGetCmdPos(axisY, &stopPos2);
    AxmStatusReadVel(axisY, &stopVel2);
    std::cout << " -> Sau AxmMoveEStop: CmdPos = " << stopPos2 << " mm | CmdVel = " << stopVel2 << " mm/s (Ngắt xung tức thời!).\n";

    // Quay về 0 mm
    std::this_thread::sleep_for(std::chrono::milliseconds(300));
    AxmMovePos(axisY, 0.0, 150.0, 500.0, 500.0);

    AxlClose();
    return 0;
}
