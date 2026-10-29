/**
 * ============================================================================
 * @file    Ex03_SettingMotionSignal.cpp
 * @brief   BÀI 03: CÀI ĐẶT & KIỂM TRA TÍN HIỆU BẢO VỆ PHẦN CỨNG (LIMIT, ALARM, INPOS, SERVO-ON)
 *          (Tương ứng: Ex3_AXM_SettingMotionSignal.cpp - Trang 36 Manual AXM_REF_ENG.pdf)
 *
 * @details Mục tiêu giảng dạy:
 *   1. Cài đặt và đọc cảm biến hành trình cứng +/- Limit (`AxmSignalSetLimit`, `AxmSignalGetLimit`, `AxmSignalReadLimit`).
 *   2. Cài đặt giới hạn hành trình mềm (`AxmSignalSetSoftLimit`, `AxmSignalGetSoftLimit`, `AxmSignalReadSoftLimit`):
 *      - Trục X: [0.0, 800.0] mm
 *      - Trục Y: [0.0, 680.0] mm
 *      - Trục Z: [-300.0, +60.0] mm
 *   3. Cài đặt tín hiệu In-Position (`AxmSignalSetInpos`, `AxmSignalReadInpos`),
 *      báo lỗi Servo Alarm (`AxmSignalSetServoAlarm`, `AxmSignalReadServoAlarm`),
 *      tín hiệu dừng khẩn cấp (`AxmSignalSetStop`, `AxmSignalReadStop`).
 *   4. Bật công suất động cơ Servo (`AxmSignalServoOn`) và kiểm tra (`AxmSignalIsServoOn`).
 * ============================================================================
 */

#include <iostream>
#include <iomanip>
#include "AXL.h"
#include "AXM.h"

int main() {
    std::cout << "======================================================================\n";
    std::cout << " [BÀI 03] CÀI ĐẶT TÍN HIỆU PHẦN CỨNG LIMIT, ALARM, INPOS & SERVO-ON\n";
    std::cout << "======================================================================\n";

    if (AxlOpen(7) != AXT_RT_SUCCESS) return -1;

    const double softMin[3] = {0.0, 0.0, -300.0};
    const double softMax[3] = {800.0, 680.0, 60.0};

    for (long axis = 0; axis < 3; ++axis) {
        // 1. Cài đặt cảm biến Hardware Limit (+/-): Dừng khẩn cấp (EMERGENCY_STOP), tích cực mức HIGH
        AxmSignalSetLimit(axis, EMERGENCY_STOP, HIGH, HIGH);

        // 2. Cài đặt Software Limit theo đúng kích thước bàn máy Gantry 3 trục
        AxmSignalSetSoftLimit(axis, ENABLE, SLOWDOWN_STOP, ACTUAL, softMax[axis], softMin[axis]);

        // 3. Cài đặt tín hiệu In-Position (INP), Servo Alarm và Emergency Stop
        AxmSignalSetInpos(axis, HIGH);
        AxmSignalSetServoAlarm(axis, HIGH);
        AxmSignalSetServoAlarmResetLevel(axis, HIGH);
        AxmSignalSetStop(axis, EMERGENCY_STOP, HIGH);

        // 4. Xóa lỗi Alarm (nếu có) và Bật Servo-ON
        AxmSignalServoAlarmReset(axis, ENABLE);
        AxmSignalServoAlarmReset(axis, DISABLE);
        AxmSignalServoOn(axis, ENABLE);
    }

    // Đọc và hiển thị trạng thái toàn bộ các tín hiệu bảo vệ trên 3 trục
    for (long axis = 0; axis < 3; ++axis) {
        DWORD uStopMode = 0, uPosLevel = 0, uNegLevel = 0;
        DWORD uPosLimState = 0, uNegLimState = 0;
        DWORD uSoftUse = 0, uSoftStop = 0, uSoftSel = 0, uSoftPosStat = 0, uSoftNegStat = 0;
        double dSoftPos = 0.0, dSoftNeg = 0.0;
        DWORD uInposState = 0, uAlarmState = 0, uEStopState = 0, uServoOn = 0;

        AxmSignalGetLimit(axis, &uStopMode, &uPosLevel, &uNegLevel);
        AxmSignalReadLimit(axis, &uPosLimState, &uNegLimState);
        AxmSignalGetSoftLimit(axis, &uSoftUse, &uSoftStop, &uSoftSel, &dSoftPos, &dSoftNeg);
        AxmSignalReadSoftLimit(axis, &uSoftPosStat, &uSoftNegStat);
        AxmSignalReadInpos(axis, &uInposState);
        AxmSignalReadServoAlarm(axis, &uAlarmState);
        AxmSignalReadStop(axis, &uEStopState);
        AxmSignalIsServoOn(axis, &uServoOn);

        std::cout << "--- TRẠNG THÁI TÍN HIỆU TRỤC " << axis << " ---\n";
        std::cout << "  + Servo-ON Status : " << (uServoOn ? "ON (ENABLE)" : "OFF") << "\n";
        std::cout << "  + Hardware Limit  : Level=(+" << uPosLevel << ",-" << uNegLevel << ") | Trạng thái hiện tại: +EL=" << uPosLimState << ", -EL=" << uNegLimState << "\n";
        std::cout << "  + Software Limit  : [" << std::fixed << std::setprecision(1) << dSoftNeg << " mm ~ " << dSoftPos
                  << " mm] | Chạm biên mềm: +SL=" << uSoftPosStat << ", -SL=" << uSoftNegStat << "\n";
        std::cout << "  + In-Position(INP): " << uInposState << " | Servo Alarm: " << uAlarmState << " | E-Stop Signal: " << uEStopState << "\n\n";
    }

    AxlClose();
    return 0;
}
