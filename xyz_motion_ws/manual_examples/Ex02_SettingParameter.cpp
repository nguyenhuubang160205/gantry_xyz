/**
 * ============================================================================
 * @file    Ex02_SettingParameter.cpp
 * @brief   BÀI 02: CÀI ĐẶT THÔNG SỐ ĐỘNG HỌC, ENCODER 20-BIT & LƯU/NẠP FILE .MOT
 *          (Tương ứng: Ex2_AXM_SettingParameter.cpp - Trang 29 Manual AXM_REF_ENG.pdf)
 *
 * @details Mục tiêu giảng dạy:
 *   1. Thiết lập tỷ lệ truyền động cơ khí `AxmMotSetMoveUnitPerPulse`:
 *      - Encoder quang học 20-bit: 1 vòng = 2^20 = 1,048,576 xung (pulses).
 *      - Trục vít me bi bước 2 cm: 1 vòng = 20.0 mm.
 *      => Độ phân giải lượng tử: q = 20.0 / 1,048,576 ≈ 0.00001907 mm/pulse (~19.07 nm).
 *   2. Cài đặt kiểu xuất xung (`AxmMotSetPulseOutMethod`) và kiểu đọc Encoder
 *      nhân 4 (`AxmMotSetEncInputMethod` -> `ObverseSqr4Mode`).
 *   3. Cài đặt vận tốc tối thiểu/tối đa (`AxmMotSetMinVel`, `AxmMotSetMaxVel`),
 *      đơn vị gia tốc (`AxmMotSetAccelUnit`), độ giật Jerk (`AxmMotSetAccelJerk`),
 *      hệ tọa độ Abs/Rel (`AxmMotSetAbsRelMode`) và dạng Profile (`AxmMotSetProfileMode`).
 *   4. Lưu và nạp toàn bộ thông số với `AxmMotSaveParaAll` & `AxmMotLoadParaAll`.
 * ============================================================================
 */

#include <iostream>
#include <iomanip>
#include "AXL.h"
#include "AXM.h"

int main() {
    std::cout << "======================================================================\n";
    std::cout << " [BÀI 02] CÀI ĐẶT THÔNG SỐ ĐỘNG HỌC & ENCODER 20-BIT (Ex2 Manual)\n";
    std::cout << "======================================================================\n";

    if (AxlOpen(7) != AXT_RT_SUCCESS) return -1;

    const double LEAD_MM_PER_REV = 20.0;      // 1 vòng vít me dịch chuyển 2 cm = 20.0 mm
    const long   ENC_20BIT_PULSE = 1048576L;  // Encoder 20-bit = 2^20 = 1,048,576 xung/vòng

    for (long axis = 0; axis < 3; ++axis) {
        // 1. Cài đặt tỷ lệ truyền động Unit/Pulse
        AxmMotSetMoveUnitPerPulse(axis, LEAD_MM_PER_REV, ENC_20BIT_PULSE);

        // 2. Cài đặt phương pháp xuất xung (TwoCcwCwHigh = 4) & đọc Encoder 4x (ObverseSqr4Mode = 3)
        AxmMotSetPulseOutMethod(axis, TwoCcwCwHigh);
        AxmMotSetEncInputMethod(axis, ObverseSqr4Mode);

        // 3. Cài đặt đơn vị gia tốc (UNIT_SEC2 = mm/s^2) và vận tốc giới hạn
        AxmMotSetAccelUnit(axis, UNIT_SEC2);
        AxmMotSetMinVel(axis, 1.0);
        AxmMotSetMaxVel(axis, 1000.0);

        // 4. Cài đặt Jerk cho S-Curve và chế độ tọa độ tuyệt đối (POS_ABS_MODE), S-Curve đối xứng
        AxmMotSetAccelJerk(axis, 50.0);
        AxmMotSetDecelJerk(axis, 50.0);
        AxmMotSetAbsRelMode(axis, POS_ABS_MODE);
        AxmMotSetProfileMode(axis, SYM_S_CURVE_MODE);

        // 5. Cài đặt thông số mặc định khi nạp (AxmMotSetParaLoad)
        AxmMotSetParaLoad(axis, (axis == 2) ? -100.0 : 200.0, 100.0, 400.0, 400.0);
    }

    // Lưu và nạp lại file thông số chuẩn .mot
    char motFile[] = "gantry_3axis_20bit.mot";
    AxmMotSaveParaAll(motFile);
    AxmMotLoadParaAll(motFile);
    std::cout << "[OK] Đã lưu và nạp lại cấu hình thông số từ file: " << motFile << "\n\n";

    // Đọc ngược (Get) toàn bộ thông số từ phần cứng/mô phỏng để kiểm chứng
    for (long axis = 0; axis < 3; ++axis) {
        double dUnit = 0.0, dMinVel = 0.0, dMaxVel = 0.0, dAccJerk = 0.0;
        double dInitPos = 0.0, dInitVel = 0.0, dInitAcc = 0.0, dInitDec = 0.0;
        long   lPulse = 0;
        DWORD  uPulseMethod = 0, uEncMethod = 0, uAbsRel = 0, uProfile = 0, uAccUnit = 0;

        AxmMotGetMoveUnitPerPulse(axis, &dUnit, &lPulse);
        AxmMotGetPulseOutMethod(axis, &uPulseMethod);
        AxmMotGetEncInputMethod(axis, &uEncMethod);
        AxmMotGetMinVel(axis, &dMinVel);
        AxmMotGetMaxVel(axis, &dMaxVel);
        AxmMotGetAccelUnit(axis, &uAccUnit);
        AxmMotGetAccelJerk(axis, &dAccJerk);
        AxmMotGetAbsRelMode(axis, &uAbsRel);
        AxmMotGetProfileMode(axis, &uProfile);
        AxmMotGetParaLoad(axis, &dInitPos, &dInitVel, &dInitAcc, &dInitDec);

        std::cout << "--- THÔNG SỐ TRỤC " << axis << " ---\n";
        std::cout << std::fixed << std::setprecision(8);
        std::cout << "  + MoveUnitPerPulse : " << std::setprecision(1) << dUnit << " mm / " << lPulse
                  << " pulses (1 pulse = " << std::setprecision(8) << (dUnit / lPulse) << " mm)\n";
        std::cout << std::setprecision(1);
        std::cout << "  + PulseOut / EncIn : PulseMethod=" << uPulseMethod << " (TwoCcwCwHigh), EncMethod=" << uEncMethod << " (ObverseSqr4Mode)\n";
        std::cout << "  + MinVel / MaxVel  : " << dMinVel << " mm/s ~ " << dMaxVel << " mm/s (AccelUnit=" << uAccUnit << ", Jerk=" << dAccJerk << "%)\n";
        std::cout << "  + AbsRel / Profile : AbsRelMode=" << uAbsRel << " (POS_ABS_MODE), ProfileMode=" << uProfile << " (SYM_S_CURVE_MODE)\n";
        std::cout << "  + ParaLoad Default : Pos=" << dInitPos << " mm, Vel=" << dInitVel << " mm/s, Acc=" << dInitAcc << " mm/s^2\n\n";
    }

    AxlClose();
    return 0;
}
