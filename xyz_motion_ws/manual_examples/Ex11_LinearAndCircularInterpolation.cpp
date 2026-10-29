/**
 * ============================================================================
 * @file    Ex11_LinearAndCircularInterpolation.cpp
 * @brief   BÀI 11: NỘI SUY ĐƯỜNG THẲNG 3D, 4 CHẾ ĐỘ CUNG TRÒN & NỘI SUY XOẮN ỐC HELIX
 *          (Tương ứng: Ex12_AXM_Interpolation.cpp - Trang 86 & 120 Manual AXM_REF_ENG.pdf)
 *
 * @details Mục tiêu giảng dạy:
 *   1. Ánh xạ hệ tọa độ nội suy 3 trục (`AxmContiSetAxisMap`) và chọn hệ tọa độ (`AxmContiSetAbsRelMode`).
 *   2. Nội suy đường thẳng 3D trong không gian (`AxmLineMove` / `AxmLineMoveEx2`).
 *   3. Thực hành đủ 4 phương pháp nội suy cung tròn chuẩn của Ajinextek:
 *      - `AxmCircleCenterMove`: Nội suy cung tròn biết **Tâm (Center)** và **Điểm cuối (End)**.
 *      - `AxmCircleRadiusMove`: Nội suy cung tròn biết **Bán kính (Radius)** và **Điểm cuối (End)**.
 *      - `AxmCircleAngleMove` : Nội suy cung tròn biết **Tâm (Center)** và **Góc quét (Angle độ)**.
 *      - `AxmCirclePointMove` : Nội suy cung tròn đi qua **3 điểm (Start -> Mid -> End)**.
 *   4. Nội suy xoắn ốc 3D (`AxmHelixCenterMove`): X và Y chạy đường tròn trong khi Z hạ sâu tuyến tính!
 * ============================================================================
 */

#include <iostream>
#include <iomanip>
#include <thread>
#include <chrono>
#include "AXL.h"
#include "AXM.h"

void waitCoordMotion(long lCoord, const char* stepDesc) {
    DWORD uInMotion = 1;
    while (uInMotion) {
        double x = 0, y = 0, z = 0;
        AxmStatusGetActPos(0, &x);
        AxmStatusGetActPos(1, &y);
        AxmStatusGetActPos(2, &z);
        std::cout << "  [" << stepDesc << "] X=" << std::fixed << std::setprecision(2) << std::setw(6) << x
                  << " | Y=" << std::setw(6) << y << " | Z=" << std::setw(7) << z << " mm\n";
        std::this_thread::sleep_for(std::chrono::milliseconds(250));
        AxmContiIsMotion(lCoord, &uInMotion);
    }
}

int main() {
    std::cout << "======================================================================\n";
    std::cout << " [BÀI 11] NỘI SUY ĐƯỜNG THẲNG 3D, 4 KIỂU CUNG TRÒN & XOẮN ỐC HELIX\n";
    std::cout << "======================================================================\n";

    if (AxlOpen(7) != AXT_RT_SUCCESS) return -1;

    long lCoord = 0;
    long lAxes[3] = {0, 1, 2};
    long lXYAxes[2] = {0, 1};
    for (int i = 0; i < 3; ++i) {
        AxmMotSetMoveUnitPerPulse(lAxes[i], 20.0, 1048576L);
        AxmSignalServoOn(lAxes[i], ENABLE);
    }

    // Ánh xạ hệ tọa độ 0 gồm 3 trục X, Y, Z ở chế độ tọa độ tuyệt đối POS_ABS_MODE
    AxmContiSetAxisMap(lCoord, 3, lAxes);
    AxmContiSetAbsRelMode(lCoord, POS_ABS_MODE);

    // ------------------------------------------------------------------------
    // 1. AxmLineMove: Nội suy đường thẳng 3D tới điểm xuất phát P0(150, 200, -198.5)
    // ------------------------------------------------------------------------
    std::cout << "\n[1] AxmLineMove: Nội suy thẳng 3D tới P0(150.0, 200.0, -198.5 mm)...\n";
    double p0[3] = {150.0, 200.0, -198.5};
    AxmLineMove(lCoord, p0, 150.0, 500.0, 500.0);
    waitCoordMotion(lCoord, "AxmLineMove        ");

    // ------------------------------------------------------------------------
    // 2. AxmCircleCenterMove: Cung tròn 180 độ từ (150, 200) -> (250, 200) quanh tâm (200, 200)
    // ------------------------------------------------------------------------
    std::cout << "\n[2] AxmCircleCenterMove: Cung nửa đường tròn CW từ (150,200) -> (250,200), Tâm (200,200)...\n";
    double center1[2] = {200.0, 200.0};
    double end1[2]    = {250.0, 200.0};
    AxmCircleCenterMove(lCoord, lXYAxes, center1, end1, 100.0, 400.0, 400.0, DIR_CW);
    waitCoordMotion(lCoord, "AxmCircleCenterMove");

    // ------------------------------------------------------------------------
    // 3. AxmCircleRadiusMove: Cung tròn biết Bán kính R=50 mm từ (250, 200) -> (150, 200)
    // ------------------------------------------------------------------------
    std::cout << "\n[3] AxmCircleRadiusMove: Cung tròn R=50 mm CW từ (250,200) -> (150,200)...\n";
    double end2[2] = {150.0, 200.0};
    AxmCircleRadiusMove(lCoord, lXYAxes, 50.0, end2, 100.0, 400.0, 400.0, DIR_CW, 0);
    waitCoordMotion(lCoord, "AxmCircleRadiusMove");

    // ------------------------------------------------------------------------
    // 4. AxmCircleAngleMove: Quay góc 270 độ CCW quanh tâm (200, 200)
    // ------------------------------------------------------------------------
    std::cout << "\n[4] AxmCircleAngleMove: Quay góc 270 độ CCW quanh tâm (200,200)...\n";
    AxmCircleAngleMove(lCoord, lXYAxes, center1, 270.0, 100.0, 400.0, 400.0, DIR_CCW);
    waitCoordMotion(lCoord, "AxmCircleAngleMove ");

    // ------------------------------------------------------------------------
    // 5. AxmCirclePointMove: Nội suy cung tròn qua Điểm giữa Mid(250, 200) tới End(200, 150)
    // ------------------------------------------------------------------------
    std::cout << "\n[5] AxmCirclePointMove: Đi qua điểm giữa (250,200) tới điểm cuối (200,150)...\n";
    double midPt[2] = {250.0, 200.0};
    double endPt[2] = {200.0, 150.0};
    AxmCirclePointMove(lCoord, lXYAxes, midPt, endPt, 100.0, 400.0, 400.0, 0);
    waitCoordMotion(lCoord, "AxmCirclePointMove ");

    // ------------------------------------------------------------------------
    // 6. AxmHelixCenterMove: Nội suy xoắn ốc 3D (Helical Milling) vừa xoay tròn XY vừa nhấc Z lên -100 mm
    // ------------------------------------------------------------------------
    std::cout << "\n[6] AxmHelixCenterMove: Nội suy xoắn ốc 3D quanh tâm (200,200) kết hợp rút dao Z -> -100 mm...\n";
    AxmHelixCenterMove(lCoord, 200.0, 200.0, 200.0, 150.0, -100.0, 120.0, 400.0, 400.0, DIR_CCW);
    waitCoordMotion(lCoord, "AxmHelixCenterMove ");

    // Đưa máy về gốc O(0,0,0)
    double pHome[3] = {0.0, 0.0, 0.0};
    AxmLineMove(lCoord, pHome, 180.0, 600.0, 600.0);
    waitCoordMotion(lCoord, "Về gốc O(0,0,0)    ");

    AxlClose();
    return 0;
}
