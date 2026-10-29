/**
 * ============================================================================
 * @file    Ex04_SettingUniversalIO.cpp
 * @brief   BÀI 04: ĐỌC & GHI TÍN HIỆU UNIVERSAL DIGITAL I/O TRÊN TỪNG TRỤC
 *          (Tương ứng: Ex4_AXM_SettingUniversalIO.cpp - Trang 39 Manual AXM_REF_ENG.pdf)
 *
 * @details Mục tiêu giảng dạy:
 *   1. Xuất tín hiệu Digital Output theo từng bit (`AxmSignalWriteOutputBit`)
 *      hoặc theo thanh ghi nguyên (`AxmSignalWriteOutput`) để bật/tắt trục chính
 *      (Spindle), van tưới nguội (Coolant) hoặc đèn báo trạng thái.
 *   2. Đọc lại trạng thái Digital Output (`AxmSignalReadOutputBit`, `AxmSignalReadOutput`).
 *   3. Đọc tín hiệu Digital Input (`AxmSignalReadInputBit`, `AxmSignalReadInput`):
 *      - Bit 0: Cảm biến đầu dò phôi (Touch Probe)
 *      - Bit 1: Công tắc hành trình âm (-Limit)
 *      - Bit 2: Công tắc hành trình dương (+Limit)
 *      - Bit 3: Cảm biến gốc tọa độ (Home ORG)
 * ===========================================================================
 */

#include <iostream>
#include <iomanip>
#include "AXL.h"
#include "AXM.h"

int main() {
    std::cout << "======================================================================\n";
    std::cout << " [BÀI 04] ĐỌC & GHI UNIVERSAL DIGITAL I/O TRÊN MODULE AXM (Ex4 Manual)\n";
    std::cout << "======================================================================\n";

    if (AxlOpen(7) != AXT_RT_SUCCESS) return -1;

    // ------------------------------------------------------------------------
    // 1. Ghi và kiểm tra các bit Digital Output trên Trục 0 (X)
    //    - Bit 0: Bật động cơ phay Spindle (ENABLE = 1)
    //    - Bit 1: Bật bơm nước làm mát Coolant (ENABLE = 1)
    //    - Bit 2: Đèn báo tháp xanh Green Tower Lamp (ENABLE = 1)
    // ------------------------------------------------------------------------
    long lAxisNo = 0;
    AxmSignalWriteOutput(lAxisNo, 0x00); // Xóa toàn bộ ngõ ra về 0

    AxmSignalWriteOutputBit(lAxisNo, 0, ENABLE);
    AxmSignalWriteOutputBit(lAxisNo, 1, ENABLE);
    AxmSignalWriteOutputBit(lAxisNo, 2, ENABLE);

    DWORD uOutWord = 0;
    AxmSignalReadOutput(lAxisNo, &uOutWord);
    std::cout << "[1] Sau khi bật Bit 0, 1, 2 trên Axis 0 -> AxmSignalReadOutput = 0x"
              << std::hex << std::uppercase << std::setw(2) << std::setfill('0') << uOutWord << std::dec << "\n";

    for (long bit = 0; bit < 4; ++bit) {
        DWORD uBitVal = 0;
        AxmSignalReadOutputBit(lAxisNo, bit, &uBitVal);
        std::cout << "    + Output Bit[" << bit << "] = " << uBitVal << "\n";
    }

    // Tắt Bit 1 (Coolant) và kiểm tra lại
    AxmSignalWriteOutputBit(lAxisNo, 1, DISABLE);
    AxmSignalReadOutput(lAxisNo, &uOutWord);
    std::cout << "[2] Sau khi tắt Bit 1 -> AxmSignalReadOutput = 0x0" << std::hex << uOutWord << std::dec << "\n\n";

    // ------------------------------------------------------------------------
    // 2. Đọc trạng thái thanh ghi Digital Input trên cả 3 trục X, Y, Z
    // ------------------------------------------------------------------------
    std::cout << "[3] Đọc trạng thái Digital Input (Cảm biến vật lý trên 3 trục):\n";
    for (long axis = 0; axis < 3; ++axis) {
        DWORD uInWord = 0;
        AxmSignalReadInput(axis, &uInWord);

        DWORD bProbe = 0, bLimNeg = 0, bLimPos = 0, bHomeOrg = 0;
        AxmSignalReadInputBit(axis, 0, &bProbe);
        AxmSignalReadInputBit(axis, 1, &bLimNeg);
        AxmSignalReadInputBit(axis, 2, &bLimPos);
        AxmSignalReadInputBit(axis, 3, &bHomeOrg);

        std::cout << "  Axis " << axis << " (Input Word = 0x0" << std::hex << uInWord << std::dec << "): "
                  << "Bit0(TouchProbe)=" << bProbe << " | "
                  << "Bit1(-Limit)=" << bLimNeg << " | "
                  << "Bit2(+Limit)=" << bLimPos << " | "
                  << "Bit3(HomeORG)=" << bHomeOrg << "\n";
    }

    AxlClose();
    return 0;
}
