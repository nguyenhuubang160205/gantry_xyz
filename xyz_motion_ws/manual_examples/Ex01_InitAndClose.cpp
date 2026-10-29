/**
 * ============================================================================
 * @file    Ex01_InitAndClose.cpp
 * @brief   BÀI 01: KHỞI TẠO THƯ VIỆN AXL, KIỂM TRA BOARD/MODULE/TRỤC VÀ ĐÓNG HỆ THỐNG
 *          (Tương ứng: Ex1_AXM_InitAndClose.cpp - Trang 18 Manual AXM_REF_ENG.pdf)
 *
 * @details Mục tiêu giảng dạy:
 *   1. Nắm vững quy trình mở kết nối phần cứng/mô phỏng với `AxlOpen(7)` và `AxlIsOpened()`.
 *   2. Kiểm tra sự tồn tại của module điều khiển chuyển động với `AxmInfoIsMotionModule()`.
 *   3. Truy vấn tổng số trục (`AxmInfoGetAxisCount`) và thông tin định danh phần cứng
 *      của từng trục (`AxmInfoGetAxis`, `AxmInfoGetFirstAxisNo`, `AxmInfoIsInvalidAxisNo`).
 *   4. Đóng thư viện an toàn khi kết thúc chương trình với `AxlClose()`.
 * ============================================================================
 */

#include <iostream>
#include <iomanip>
#include "AXL.h"
#include "AXM.h"

int main() {
    std::cout << "======================================================================\n";
    std::cout << " [BÀI 01] KHỞI TẠO THƯ VIỆN AXL & TRUY VẤN THÔNG TIN PHẦN CỨNG (Ex1)\n";
    std::cout << "======================================================================\n";

    // ------------------------------------------------------------------------
    // BƯỚC 1: Khởi tạo thư viện Ajinextek AXL (IRQ số 7 theo chuẩn Manual)
    // ------------------------------------------------------------------------
    if (!AxlIsOpened()) {
        DWORD dwRet = AxlOpen(7);
        if (dwRet != AXT_RT_SUCCESS) {
            std::cerr << "[LỖI] AxlOpen(7) thất bại! Mã lỗi: " << dwRet << "\n";
            return -1;
        }
        std::cout << "[1] AxlOpen(7) thành công! AxlIsOpened() = " << AxlIsOpened() << "\n";
    }

    // ------------------------------------------------------------------------
    // BƯỚC 2: Kiểm tra sự tồn tại của Module Motion trên hệ thống
    // ------------------------------------------------------------------------
    DWORD uStatus = 0;
    DWORD dwRet = AxmInfoIsMotionModule(&uStatus);
    if (dwRet == AXT_RT_SUCCESS && uStatus == STATUS_EXIST) {
        std::cout << "[2] AxmInfoIsMotionModule: Phát hiện Module Motion (STATUS_EXIST = 1).\n";
    } else {
        std::cerr << "[LỖI] Không tìm thấy Module Motion!\n";
        AxlClose();
        return -1;
    }

    // ------------------------------------------------------------------------
    // BƯỚC 3: Đọc tổng số trục hiện có và trục đầu tiên của Board 0, Module 0
    // ------------------------------------------------------------------------
    long lAxisCount = 0;
    AxmInfoGetAxisCount(&lAxisCount);
    std::cout << "[3] AxmInfoGetAxisCount  : Hệ thống có tổng cộng " << lAxisCount << " trục (0:X, 1:Y, 2:Z).\n";

    long lFirstAxisNo = -1;
    AxmInfoGetFirstAxisNo(0, 0, &lFirstAxisNo);
    std::cout << "[4] AxmInfoGetFirstAxisNo(Board=0, Module=0) -> Trục đầu tiên: Axis " << lFirstAxisNo << "\n\n";

    // ------------------------------------------------------------------------
    // BƯỚC 4: Duyệt qua từng trục để đọc thông tin BoardNo, ModulePos, ModuleID
    // ------------------------------------------------------------------------
    std::cout << "Bảng thông tin chi tiết các trục (AxmInfoGetAxis & AxmInfoGetAxisStatus):\n";
    std::cout << "----------------------------------------------------------------------\n";
    std::cout << " AxisNo | Tên Trục | BoardNo | ModulePos | ModuleID (Hex) | Trạng Thái\n";
    std::cout << "----------------------------------------------------------------------\n";

    const char* axisNames[3] = {"Trục X", "Trục Y", "Trục Z"};
    for (long axis = 0; axis < lAxisCount; ++axis) {
        long lBoardNo = 0, lModulePos = 0;
        DWORD uModuleID = 0;

        AxmInfoGetAxis(axis, &lBoardNo, &lModulePos, &uModuleID);
        DWORD uAxisValid = AxmInfoIsInvalidAxisNo(axis);
        DWORD uAxisStat  = AxmInfoGetAxisStatus(axis);

        std::cout << "   " << axis << "    |  " << axisNames[axis]
                  << "  |    " << lBoardNo
                  << "    |     " << lModulePos
                  << "     |     0x" << std::hex << std::uppercase << std::setw(2) << std::setfill('0') << uModuleID << std::dec
                  << "       | " << ((uAxisValid == AXT_RT_SUCCESS && uAxisStat == AXT_RT_SUCCESS) ? "HỢP LỆ (OK)" : "LỖI") << "\n";
    }
    std::cout << "----------------------------------------------------------------------\n";

    // Kiểm thử truyền một số trục không hợp lệ (ví dụ: Axis 99)
    DWORD dwInvalidTest = AxmInfoIsInvalidAxisNo(99);
    std::cout << "[5] Kiểm thử AxmInfoIsInvalidAxisNo(99) -> Mã trả về: " << dwInvalidTest
              << " (AXT_RT_MOTION_INVALID_AXIS_NO = " << AXT_RT_MOTION_INVALID_AXIS_NO << ")\n";

    // ------------------------------------------------------------------------
    // BƯỚC 5: Đóng thư viện AXL an toàn
    // ------------------------------------------------------------------------
    BOOL bClosed = AxlClose();
    std::cout << "[6] AxlClose() hoàn tất (Kết quả = " << bClosed << "). Kết thúc Bài 01.\n";
    return 0;
}
