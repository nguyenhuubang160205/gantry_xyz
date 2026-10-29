#include "AXL.h"
#include "AXM.h"
#include "MotionCore.hpp"

extern "C" {

DWORD __stdcall AxmSignalServoOn(long lAxisNo, DWORD uOnOff) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    MotionCore::getInstance().setServoOn(lAxisNo, uOnOff);
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmSignalIsServoOn(long lAxisNo, DWORD *upOnOff) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (upOnOff) {
        *upOnOff = MotionCore::getInstance().isServoOn(lAxisNo);
    }
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmSignalServoAlarmReset(long lAxisNo, DWORD uOnOff) {
    (void)lAxisNo;
    (void)uOnOff;
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmSignalReadInput(long lAxisNo, DWORD *upValue) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (upValue) {
        *upValue = MotionCore::getInstance().readInput(lAxisNo);
    }
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmSignalReadInputBit(long lAxisNo, long lBitNo, DWORD *upOn) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (upOn) {
        *upOn = MotionCore::getInstance().readInputBit(lAxisNo, lBitNo);
    }
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmSignalWriteOutput(long lAxisNo, DWORD uValue) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    MotionCore::getInstance().writeOutput(lAxisNo, uValue);
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmSignalReadOutput(long lAxisNo, DWORD *upValue) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (upValue) {
        *upValue = MotionCore::getInstance().readOutput(lAxisNo);
    }
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmSignalWriteOutputBit(long lAxisNo, long lBitNo, DWORD uOnOff) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    MotionCore::getInstance().writeOutputBit(lAxisNo, lBitNo, uOnOff);
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmSignalReadOutputBit(long lAxisNo, long lBitNo, DWORD *upOnOff) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (upOnOff) {
        *upOnOff = MotionCore::getInstance().readOutputBit(lAxisNo, lBitNo);
    }
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmSignalSetLimit(long lAxisNo, DWORD uStopMode, DWORD uPositiveLevel, DWORD uNegativeLevel) {
    (void)lAxisNo;
    (void)uStopMode;
    (void)uPositiveLevel;
    (void)uNegativeLevel;
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmSignalGetLimit(long lAxisNo, DWORD *upStopMode, DWORD *upPositiveLevel, DWORD *upNegativeLevel) {
    (void)lAxisNo;
    if (upStopMode) *upStopMode = EMERGENCY_STOP;
    if (upPositiveLevel) *upPositiveLevel = HIGH;
    if (upNegativeLevel) *upNegativeLevel = HIGH;
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmSignalReadLimit(long lAxisNo, DWORD *upPositiveStatus, DWORD *upNegativeStatus) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (upPositiveStatus) *upPositiveStatus = MotionCore::getInstance().readInputBit(lAxisNo, 2);
    if (upNegativeStatus) *upNegativeStatus = MotionCore::getInstance().readInputBit(lAxisNo, 1);
    return AXT_RT_SUCCESS;
}

static DWORD s_soft_use[3] = {ENABLE, ENABLE, ENABLE};
static DWORD s_soft_stop[3] = {SLOWDOWN_STOP, SLOWDOWN_STOP, SLOWDOWN_STOP};
static DWORD s_soft_sel[3] = {ACTUAL, ACTUAL, ACTUAL};
static double s_soft_pos[3] = {800.0, 680.0, 60.0};
static double s_soft_neg[3] = {0.0, 0.0, -300.0};
static DWORD s_alarm_rst_lvl[3] = {HIGH, HIGH, HIGH};

DWORD __stdcall AxmSignalSetSoftLimit(long lAxisNo, DWORD uUse, DWORD uStopMode, DWORD uSelection, double dPositivePos, double dNegativePos) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (lAxisNo < 0 || lAxisNo >= 3) return AXT_RT_MOTION_INVALID_AXIS_NO;
    s_soft_use[lAxisNo] = uUse;
    s_soft_stop[lAxisNo] = uStopMode;
    s_soft_sel[lAxisNo] = uSelection;
    s_soft_pos[lAxisNo] = dPositivePos;
    s_soft_neg[lAxisNo] = dNegativePos;
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmSignalGetSoftLimit(long lAxisNo, DWORD *upUse, DWORD *upStopMode, DWORD *upSelection, double *dpPositivePos, double *dpNegativePos) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (lAxisNo < 0 || lAxisNo >= 3) return AXT_RT_MOTION_INVALID_AXIS_NO;
    if (upUse) *upUse = s_soft_use[lAxisNo];
    if (upStopMode) *upStopMode = s_soft_stop[lAxisNo];
    if (upSelection) *upSelection = s_soft_sel[lAxisNo];
    if (dpPositivePos) *dpPositivePos = s_soft_pos[lAxisNo];
    if (dpNegativePos) *dpNegativePos = s_soft_neg[lAxisNo];
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmSignalReadSoftLimit(long lAxisNo, DWORD *upPositiveStatus, DWORD *upNegativeStatus) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (lAxisNo < 0 || lAxisNo >= 3) return AXT_RT_MOTION_INVALID_AXIS_NO;
    double p = (s_soft_sel[lAxisNo] == 0) ? MotionCore::getInstance().getCmdPos(lAxisNo) : MotionCore::getInstance().getActPos(lAxisNo);
    if (upPositiveStatus) *upPositiveStatus = (s_soft_use[lAxisNo] && p >= s_soft_pos[lAxisNo]) ? 1 : 0;
    if (upNegativeStatus) *upNegativeStatus = (s_soft_use[lAxisNo] && p <= s_soft_neg[lAxisNo]) ? 1 : 0;
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmSignalSetServoAlarmResetLevel(long lAxisNo, DWORD uLevel) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (lAxisNo < 0 || lAxisNo >= 3) return AXT_RT_MOTION_INVALID_AXIS_NO;
    s_alarm_rst_lvl[lAxisNo] = uLevel;
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmSignalGetServoAlarmResetLevel(long lAxisNo, DWORD *upLevel) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (lAxisNo < 0 || lAxisNo >= 3) return AXT_RT_MOTION_INVALID_AXIS_NO;
    if (upLevel) *upLevel = s_alarm_rst_lvl[lAxisNo];
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmSignalSetInpos(long lAxisNo, DWORD uUse) {
    (void)lAxisNo;
    (void)uUse;
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmSignalGetInpos(long lAxisNo, DWORD *upUse) {
    (void)lAxisNo;
    if (upUse) *upUse = HIGH;
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmSignalReadInpos(long lAxisNo, DWORD *upStatus) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (upStatus) {
        *upStatus = MotionCore::getInstance().isInMotion(lAxisNo) ? 0 : 1;
    }
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmSignalSetServoAlarm(long lAxisNo, DWORD uUse) {
    (void)lAxisNo;
    (void)uUse;
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmSignalGetServoAlarm(long lAxisNo, DWORD *upUse) {
    (void)lAxisNo;
    if (upUse) *upUse = LOW;
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmSignalReadServoAlarm(long lAxisNo, DWORD *upStatus) {
    (void)lAxisNo;
    if (upStatus) *upStatus = 0;
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmSignalSetStop(long lAxisNo, DWORD uStopMode, DWORD uLevel) {
    (void)lAxisNo;
    (void)uStopMode;
    (void)uLevel;
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmSignalGetStop(long lAxisNo, DWORD *upStopMode, DWORD *upLevel) {
    (void)lAxisNo;
    if (upStopMode) *upStopMode = EMERGENCY_STOP;
    if (upLevel) *upLevel = HIGH;
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmSignalReadStop(long lAxisNo, DWORD *upStatus) {
    (void)lAxisNo;
    if (upStatus) *upStatus = 0;
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmTriggerSetReset(long lAxisNo) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    MotionCore::getInstance().setTriggerPos(lAxisNo, 0.0);
    return AXT_RT_SUCCESS;
}

// Legacy ABI aliases (not declared in AXM.h, kept only for backwards binary compatibility)
DWORD __stdcall AxmSignalSetServoOn(long lAxisNo, DWORD uOnOff) {
    return AxmSignalServoOn(lAxisNo, uOnOff);
}
DWORD __stdcall AxmTriggerSetPos(long lAxisNo, double dPos) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    MotionCore::getInstance().setTriggerPos(lAxisNo, dPos);
    return AXT_RT_SUCCESS;
}
DWORD __stdcall AxmTriggerGetPos(long lAxisNo, double *dpPos) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (dpPos) *dpPos = MotionCore::getInstance().getTriggerPos(lAxisNo);
    return AXT_RT_SUCCESS;
}

} // extern "C"
