#include "AXL.h"
#include "AXM.h"
#include "MotionCore.hpp"

extern "C" {

DWORD __stdcall AxmContiSetAxisMap(long lCoord, long lSize, long *lpAxesNo) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    MotionCore::getInstance().contiSetAxisMap(lCoord, lSize, lpAxesNo);
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmContiGetAxisMap(long lCoord, long *lpSize, long *lpAxesNo) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    MotionCore::getInstance().contiGetAxisMap(lCoord, lpSize, lpAxesNo);
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmContiResetAxisMap(long lCoordinate) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    MotionCore::getInstance().contiResetAxisMap(lCoordinate);
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmContiWriteClear(long lCoord) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    MotionCore::getInstance().contiWriteClear(lCoord, true);
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmContiBeginNode(long lCoord) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    MotionCore::getInstance().contiBeginNode(lCoord);
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmContiEndNode(long lCoord) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    MotionCore::getInstance().contiEndNode(lCoord);
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmContiStart(long lCoord, DWORD dwProfileset, long lAngle) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    MotionCore::getInstance().contiStart(lCoord, dwProfileset, lAngle);
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmContiGetNodeNum(long lCoord, long *lpNodeNum) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (lpNodeNum) {
        *lpNodeNum = MotionCore::getInstance().contiGetNodeNum(lCoord);
    }
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmContiGetTotalNodeNum(long lCoord, long *lpNodeNum) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (lpNodeNum) {
        *lpNodeNum = MotionCore::getInstance().contiGetTotalNodeNum(lCoord);
    }
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmContiReadFree(long lCoord, DWORD *upQueueFree) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (upQueueFree) {
        *upQueueFree = MotionCore::getInstance().contiIsMotion(lCoord) ? 0 : 1;
    }
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmContiReadIndex(long lCoord, long *lpQueueIndex) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (lpQueueIndex) {
        *lpQueueIndex = MotionCore::getInstance().contiGetNodeNum(lCoord);
    }
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmContiIsMotion(long lCoord, DWORD *upInMotion) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (upInMotion) {
        *upInMotion = MotionCore::getInstance().contiIsMotion(lCoord) ? 1 : 0;
    }
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmContiSetAbsRelMode(long lCoord, DWORD uAbsRelMode) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    MotionCore::getInstance().contiSetAbsRelMode(lCoord, uAbsRelMode);
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmContiGetAbsRelMode(long lCoord, DWORD *upAbsRelMode) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (upAbsRelMode) {
        *upAbsRelMode = MotionCore::getInstance().contiGetAbsRelMode(lCoord);
    }
    return AXT_RT_SUCCESS;
}

} // extern "C"
