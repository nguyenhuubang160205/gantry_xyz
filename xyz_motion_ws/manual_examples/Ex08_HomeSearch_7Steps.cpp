/**
 * ============================================================================
 * @file    Ex08_HomeSearch_7Steps.cpp
 * @brief   BÀI 08: QUY TRÌNH VỀ GỐC TỌA ĐỘ TỰ ĐỘNG (HOME SEARCH DRIVE - 7 STEPS)
 *          (Tương ứng: Ex8_AXM_HomeSearchDrive.cpp - Trang 65 Manual AXM_REF_ENG.pdf)
 *
 * @details Mục tiêu giảng dạy:
 *   1. Cấu hình phương pháp dò gốc `AxmHomeSetMethod`:
 *      - `lHmDir`      : Hướng dò gốc (`DIR_CCW = 0` cho X/Y, `DIR_CW = 1` cho Z).
 *      - `uHomeSignal` : Cảm biến gốc (`HomeSensor = 4`).
 *      - `uZphas`      : Xung Z-Phase của Encoder 20-bit.
 *      - `dHomeClrTime`: Thời gian chờ xóa bộ đếm Encoder về 0 (ms).
 *      - `dHomeOffset` : Khoảng dịch Offset sau khi tìm thấy gốc.
 *   2. Cấu hình 4 cấp vận tốc dò gốc `AxmHomeSetVel(axis, v1, v2, v3, v4, a1, a2)`:
 *      - `dVelFirst`  (v1): Tốc độ cao tìm cảm biến ORG.
 *      - `dVelSecond` (v2): Tốc độ thoát khỏi vùng cảm biến ORG.
 *      - `dVelThird`  (v3): Tốc độ chậm bắt chính xác sườn cảm biến ORG.
 *      - `dVelLast`   (v4): Tốc độ siêu chậm dò xung Z-Phase của Encoder 20-bit.
 *   3. Khởi chạy `AxmHomeSetStart` và giám sát tiến độ `AxmHomeGetRate` / `AxmHomeGetResult`.
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
    std::cout << " [BÀI 08] QUY TRÌNH DÒ GỐC TỌA ĐỘ HOME SEARCH 3 TRỤC (Ex8 Manual)\n";
    std::cout << "======================================================================\n";

    if (AxlOpen(7) != AXT_RT_SUCCESS) return -1;

    for (long a = 0; a < 3; ++a) {
        AxmMotSetMoveUnitPerPulse(a, 20.0, 1048576L);
        AxmMotSetAbsRelMode(a, POS_ABS_MODE);
        AxmSignalServoOn(a, ENABLE);
    }

    // Đưa máy ra vị trí bất kỳ ngoài vùng gốc để quan sát rõ quá trình chạy về Home
    std::cout << "[Chuẩn bị] Đưa 3 trục tới vị trí (X=120, Y=100, Z=-80 mm) trước khi Home...\n";
    AxmMovePos(0, 120.0, 150.0, 500.0, 500.0);
    AxmMovePos(1, 100.0, 150.0, 500.0, 500.0);
    AxmMovePos(2, -80.0, 100.0, 400.0, 400.0);

    // ------------------------------------------------------------------------
    // BƯỚC 1: Cài đặt thông số Home Method & 4 cấp vận tốc cho cả 3 trục
    // ------------------------------------------------------------------------
    // Trục X (0) & Y (1) về gốc theo chiều âm (DIR_CCW = 0), Trục Z (2) về gốc trên đỉnh (DIR_CW = 1)
    AxmHomeSetMethod(0, DIR_CCW, HomeSensor, 1, 100.0, 0.0);
    AxmHomeSetMethod(1, DIR_CCW, HomeSensor, 1, 100.0, 0.0);
    AxmHomeSetMethod(2, DIR_CW,  HomeSensor, 1, 100.0, 0.0);

    // Cài đặt 4 cấp vận tốc: V1=80, V2=30, V3=10, V4=2 mm/s; Acc1=300, Acc2=150 mm/s^2
    for (long a = 0; a < 3; ++a) {
        AxmHomeSetVel(a, 80.0, 30.0, 10.0, 2.0, 300.0, 150.0);

        // Kiểm tra lại bằng AxmHomeGetMethod & AxmHomeGetVel
        long hmDir = 0; DWORD hmSig = 0, zPhas = 0; double clrT = 0.0, offset = 0.0;
        double v1 = 0, v2 = 0, v3 = 0, v4 = 0, a1 = 0, a2 = 0;
        AxmHomeGetMethod(a, &hmDir, &hmSig, &zPhas, &clrT, &offset);
        AxmHomeGetVel(a, &v1, &v2, &v3, &v4, &a1, &a2);
        std::cout << "  Axis " << a << ": Dir=" << hmDir << ", Sig=" << hmSig
                  << ", V1=" << v1 << ", V2=" << v2 << ", V3=" << v3 << ", V4=" << v4 << " mm/s\n";
    }

    // ------------------------------------------------------------------------
    // BƯỚC 2: Khởi chạy Home Search cho Trục Z trước (An toàn CNC), sau đó X và Y
    // ------------------------------------------------------------------------
    std::cout << "\n[1] Bắt đầu dò gốc Trục Z (AxmHomeSetStart(2))...\n";
    AxmHomeSetStart(2);
    while (true) {
        DWORD uResult = HOME_SEARCHING, uMainStep = 0, uStep = 0, uHomeSig = 0;
        AxmHomeGetResult(2, &uResult);
        AxmHomeGetRate(2, &uMainStep, &uStep);
        AxmHomeReadSignal(2, &uHomeSig);
        double zPos = 0.0;
        AxmStatusGetActPos(2, &zPos);
        std::cout << "    Axis Z: Step=" << uMainStep << " (" << std::setw(3) << uStep << "%)"
                  << " | ActPos=" << std::fixed << std::setprecision(2) << zPos << " mm | ORG_Sig=" << uHomeSig << "\n";
        if (uResult != HOME_SEARCHING) break;
        std::this_thread::sleep_for(std::chrono::milliseconds(200));
    }

    std::cout << "\n[2] Bắt đầu dò gốc đồng thời Trục X và Trục Y (AxmHomeSetStart(0 & 1))...\n";
    AxmHomeSetStart(0);
    AxmHomeSetStart(1);
    while (true) {
        DWORD resX = 0, resY = 0, stepX = 0, progX = 0, stepY = 0, progY = 0;
        AxmHomeGetResult(0, &resX);
        AxmHomeGetResult(1, &resY);
        AxmHomeGetRate(0, &stepX, &progX);
        AxmHomeGetRate(1, &stepY, &progY);
        double xPos = 0.0, yPos = 0.0;
        AxmStatusGetActPos(0, &xPos);
        AxmStatusGetActPos(1, &yPos);
        std::cout << "    X: Step=" << stepX << "(" << std::setw(3) << progX << "%, Pos=" << std::fixed << std::setprecision(2) << xPos << "mm) | "
                  << "Y: Step=" << stepY << "(" << std::setw(3) << progY << "%, Pos=" << yPos << "mm)\n";
        if (resX != HOME_SEARCHING && resY != HOME_SEARCHING) break;
        std::this_thread::sleep_for(std::chrono::milliseconds(250));
    }

    std::cout << "\n[HOÀN TẤT HOME 3 TRỤC] Tất cả các trục đã về gốc O(0.000, 0.000, 0.000) thành công!\n";
    AxlClose();
    return 0;
}
