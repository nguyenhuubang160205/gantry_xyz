/**
 * ============================================================================
 * @file    Ex12_ContinuousInterpolationQueue.cpp
 * @brief   BÀI 12: NỘI SUY LIÊN TỤC ĐA PHÂN ĐOẠN QUA HÀNG ĐỢI LOOK-AHEAD (CONTI QUEUE)
 *          (Tương ứng: Ex13_AXM_ContiInterpolation.cpp - Trang 95 Manual AXM_REF_ENG.pdf)
 *
 * @details Mục tiêu giảng dạy:
 *   1. Quy trình chuẩn 6 bước để lập trình gia công biên dạng CNC liên tục (Continuous Interpolation):
 *      - Bước 1: `AxmContiWriteClear(lCoord)`      -> Xóa hàng đợi nội suy cũ.
 *      - Bước 2: `AxmContiSetAxisMap(lCoord, ...)` -> Ánh xạ các trục tham gia hệ tọa độ.
 *      - Bước 3: `AxmContiSetAbsRelMode(lCoord, .)`-> Chọn tọa độ Tuyệt đối/Tương đối.
 *      - Bước 4: `AxmContiBeginNode(lCoord)`       -> Mở khối đăng ký các phân đoạn (Nodes) vào Queue.
 *      - Bước 5: Gọi chuỗi `AxmLineMove`, `AxmCircleCenterMove`... và đóng khối bằng `AxmContiEndNode(lCoord)`.
 *      - Bước 6: `AxmContiStart(lCoord, dwProfileset, lAngle)` -> Thực thi toàn bộ hàng đợi mượt mà!
 *   2. Giám sát trạng thái hàng đợi thời gian thực với `AxmContiReadFree`, `AxmContiReadIndex`,
 *      `AxmContiGetTotalNodeNum`, `AxmContiGetNodeNum` và `AxmContiIsMotion`.
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
    std::cout << " [BÀI 12] HÀNG ĐỢI NỘI SUY LIÊN TỤC LOOK-AHEAD (CONTI QUEUE - Ex13)\n";
    std::cout << "======================================================================\n";

    if (AxlOpen(7) != AXT_RT_SUCCESS) return -1;

    long lCoord = 0;
    long lAxes[3]   = {0, 1, 2};
    long lXYAxes[2] = {0, 1};
    for (int i = 0; i < 3; ++i) {
        AxmMotSetMoveUnitPerPulse(lAxes[i], 20.0, 1048576L);
        AxmSignalServoOn(lAxes[i], ENABLE);
    }

    // Đưa mũi dao tới vị trí bắt đầu biên dạng Pocket (X=100, Y=120, Z=-199.0 mm)
    AxmContiSetAxisMap(lCoord, 3, lAxes);
    AxmContiSetAbsRelMode(lCoord, POS_ABS_MODE);
    double startPt[3] = {100.0, 120.0, -199.0};
    AxmLineMove(lCoord, startPt, 180.0, 600.0, 600.0);
    DWORD uMoving = 1;
    while (uMoving) {
        std::this_thread::sleep_for(std::chrono::milliseconds(100));
        AxmContiIsMotion(lCoord, &uMoving);
    }

    // ------------------------------------------------------------------------
    // ĐĂNG KÝ BIÊN DẠNG HÌNH CHỮ NHẬT BO GÓC (6 NODES: 4 ĐOẠN THẲNG + 2 CUNG TRÒN) VÀO QUEUE
    // ------------------------------------------------------------------------
    AxmContiWriteClear(lCoord);
    AxmContiSetAxisMap(lCoord, 3, lAxes);
    AxmContiSetAbsRelMode(lCoord, POS_ABS_MODE);

    DWORD uFreeQueue = 0;
    AxmContiReadFree(lCoord, &uFreeQueue);
    std::cout << "[1] Trước khi nạp Node: AxmContiReadFree = " << uFreeQueue << "\n";

    AxmContiBeginNode(lCoord);
    {
        double vCut = 120.0, aCut = 450.0;

        // Node 1: Cạnh thẳng dưới từ (100, 120) -> (260, 120)
        double n1[3] = {260.0, 120.0, -199.0};
        AxmLineMove(lCoord, n1, vCut, aCut, aCut);

        // Node 2: Cung bo góc 90 độ CCW bán kính R=40 tới (300, 160) quanh tâm (260, 160)
        double c2[2] = {260.0, 160.0}, e2[2] = {300.0, 160.0};
        AxmCircleCenterMove(lCoord, lXYAxes, c2, e2, vCut, aCut, aCut, DIR_CCW);

        // Node 3: Cạnh thẳng phải từ (300, 160) -> (300, 260)
        double n3[3] = {300.0, 260.0, -199.0};
        AxmLineMove(lCoord, n3, vCut, aCut, aCut);

        // Node 4: Cung bo góc 90 độ CCW bán kính R=40 tới (260, 300) quanh tâm (260, 260)
        double c4[2] = {260.0, 260.0}, e4[2] = {260.0, 300.0};
        AxmCircleCenterMove(lCoord, lXYAxes, c4, e4, vCut, aCut, aCut, DIR_CCW);

        // Node 5: Cạnh thẳng trên từ (260, 300) -> (100, 300)
        double n5[3] = {100.0, 300.0, -199.0};
        AxmLineMove(lCoord, n5, vCut, aCut, aCut);

        // Node 6: Cạnh thẳng trái khép kín về (100, 120)
        double n6[3] = {100.0, 120.0, -199.0};
        AxmLineMove(lCoord, n6, vCut, aCut, aCut);
    }
    AxmContiEndNode(lCoord);

    long lTotalNodes = 0, lQueueIdx = 0;
    AxmContiGetTotalNodeNum(lCoord, &lTotalNodes);
    AxmContiReadIndex(lCoord, &lQueueIdx);
    std::cout << "[2] Đã đóng gói Conti Queue: TotalNodes = " << lTotalNodes
              << " | QueueIndex = " << lQueueIdx << "\n";

    // ------------------------------------------------------------------------
    // KHỞI CHẠY HÀNG ĐỢI NỘI SUY LIÊN TỤC (AxmContiStart)
    // ------------------------------------------------------------------------
    std::cout << "[3] Gọi AxmContiStart(lCoord, CONTI_NODE_VELOCITY, 0)...\n";
    AxmContiStart(lCoord, 0, 0);

    uMoving = 1;
    while (uMoving) {
        long lCurNode = 0;
        double x = 0, y = 0, z = 0;
        AxmContiGetNodeNum(lCoord, &lCurNode);
        AxmStatusGetActPos(0, &x);
        AxmStatusGetActPos(1, &y);
        AxmStatusGetActPos(2, &z);

        std::cout << "    -> Đang chạy Node [" << lCurNode << "/" << lTotalNodes << "]: "
                  << "X=" << std::fixed << std::setprecision(2) << std::setw(6) << x
                  << " mm, Y=" << std::setw(6) << y << " mm, Z=" << z << " mm\n";
        std::this_thread::sleep_for(std::chrono::milliseconds(250));
        AxmContiIsMotion(lCoord, &uMoving);
    }

    // Nhấc dao và quay về gốc O(0,0,0)
    double homePt[3] = {0.0, 0.0, 0.0};
    AxmLineMove(lCoord, homePt, 180.0, 600.0, 600.0);
    uMoving = 1;
    while (uMoving) {
        std::this_thread::sleep_for(std::chrono::milliseconds(100));
        AxmContiIsMotion(lCoord, &uMoving);
    }

    std::cout << "[HOÀN TẤT BÀI 12] Đã chạy xong toàn bộ hàng đợi nội suy liên tục!\n";
    AxlClose();
    return 0;
}
