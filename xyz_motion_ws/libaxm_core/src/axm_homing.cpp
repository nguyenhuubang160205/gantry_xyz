#include "AXL.h"
#include "AXM.h"
#include "MotionCore.hpp"

extern "C" {

DWORD __stdcall AxmHomeSetSignalLevel(long lAxisNo, DWORD uLevel) {
    (void)lAxisNo;
    (void)uLevel;
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmHomeGetSignalLevel(long lAxisNo, DWORD *upLevel) {
    (void)lAxisNo;
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (upLevel) *upLevel = HIGH;
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmHomeReadSignal(long lAxisNo, DWORD *upStatus) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (upStatus) {
        *upStatus = MotionCore::getInstance().readInputBit(lAxisNo, 3);
    }
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmHomeSetMethod(long lAxisNo, long lHmDir, DWORD uHomeSignal, DWORD uZphas, double dHomeClrTime, double dHomeOffset) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    MotionCore::getInstance().homeSetMethod(lAxisNo, lHmDir, uHomeSignal, uZphas, dHomeClrTime, dHomeOffset);
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmHomeGetMethod(long lAxisNo, long *lpHmDir, DWORD *upHomeSignal, DWORD *upZphas, double *dpHomeClrTime, double *dpHomeOffset) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    MotionCore::getInstance().homeGetMethod(lAxisNo, lpHmDir, upHomeSignal, upZphas, dpHomeClrTime, dpHomeOffset);
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmHomeSetVel(long lAxisNo, double dVelFirst, double dVelSecond, double dVelThird, double dVelLast, double dAccFirst, double dAccSecond) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    MotionCore::getInstance().homeSetVel(lAxisNo, dVelFirst, dVelSecond, dVelThird, dVelLast, dAccFirst, dAccSecond);
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmHomeGetVel(long lAxisNo, double *dpVelFirst, double *dpVelSecond, double *dpVelThird, double *dpVelLast, double *dpAccFirst, double *dpAccSecond) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    MotionCore::getInstance().homeGetVel(lAxisNo, dpVelFirst, dpVelSecond, dpVelThird, dpVelLast, dpAccFirst, dpAccSecond);
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmHomeSetStart(long lAxisNo) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    MotionCore::getInstance().homeStart(lAxisNo);
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmHomeSetResult(long lAxisNo, DWORD uHomeResult) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    MotionCore::getInstance().homeSetResult(lAxisNo, uHomeResult);
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmHomeGetResult(long lAxisNo, DWORD *upHomeResult) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (upHomeResult) {
        *upHomeResult = MotionCore::getInstance().homeGetResult(lAxisNo);
    }
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmHomeGetRate(long lAxisNo, DWORD *upHomeMainStepNumber, DWORD *upHomeStepNumber) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    DWORD main_step = 0, progress = 0;
    MotionCore::getInstance().homeGetRate(lAxisNo, &main_step, &progress);
    if (upHomeMainStepNumber) *upHomeMainStepNumber = main_step;
    if (upHomeStepNumber) *upHomeStepNumber = progress;
    return AXT_RT_SUCCESS;
}

} // extern "C"
