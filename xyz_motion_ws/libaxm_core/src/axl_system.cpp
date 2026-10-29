#include "AXL.h"
#include "AXM.h"
#include "MotionCore.hpp"
#include <iostream>

extern "C" {

DWORD __stdcall AxlOpen(long lIrqNo) {
    (void)lIrqNo;
    if (MotionCore::getInstance().open()) {
        return AXT_RT_SUCCESS;
    }
    return AXT_RT_OPEN_ERROR;
}

DWORD __stdcall AxlOpenNoReset(long lIrqNo) {
    return AxlOpen(lIrqNo);
}

BOOL __stdcall AxlClose() {
    return MotionCore::getInstance().close() ? 1 : 0;
}

BOOL __stdcall AxlIsOpened() {
    return MotionCore::getInstance().isOpened() ? 1 : 0;
}

DWORD __stdcall AxmInfoGetAxis(long lAxisNo, long *lpBoardNo, long *lpModulePos, DWORD *upModuleID) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (lAxisNo < 0 || lAxisNo >= MotionCore::getInstance().getAxisCount()) return AXT_RT_MOTION_INVALID_AXIS_NO;
    if (lpBoardNo) *lpBoardNo = 0;
    if (lpModulePos) *lpModulePos = 0;
    if (upModuleID) *upModuleID = AXT_SMC_4V04;
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmInfoGetAxisCount(long *lpAxisCount) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (lpAxisCount) {
        *lpAxisCount = MotionCore::getInstance().getAxisCount();
    }
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmVirtualSetAxisNoMap(long lRealAxisNo, long lVirtualAxisNo) {
    (void)lRealAxisNo;
    (void)lVirtualAxisNo;
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmVirtualGetAxisNoMap(long lRealAxisNo, long *lpVirtualAxisNo) {
    if (lpVirtualAxisNo) *lpVirtualAxisNo = lRealAxisNo;
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmVirtualResetAxisMap() {
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmMotSetPulseOutMethod(long lAxisNo, DWORD uMethod) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    MotionCore::getInstance().setPulseOutMethod(lAxisNo, uMethod);
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmMotGetPulseOutMethod(long lAxisNo, DWORD *upMethod) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (upMethod) *upMethod = MotionCore::getInstance().getPulseOutMethod(lAxisNo);
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmMotSetEncInputMethod(long lAxisNo, DWORD uMethod) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    MotionCore::getInstance().setEncInputMethod(lAxisNo, uMethod);
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmMotGetEncInputMethod(long lAxisNo, DWORD *upMethod) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (upMethod) *upMethod = MotionCore::getInstance().getEncInputMethod(lAxisNo);
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmMotSetMoveUnitPerPulse(long lAxisNo, double dUnit, long lPulse) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (lAxisNo < 0 || lAxisNo >= MotionCore::getInstance().getAxisCount()) return AXT_RT_MOTION_INVALID_AXIS_NO;
    if (dUnit <= 0.0 || lPulse <= 0) return AXT_RT_INVALID_VARIABLE;
    MotionCore::getInstance().setMoveUnitPerPulse(lAxisNo, dUnit, lPulse);
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmMotGetMoveUnitPerPulse(long lAxisNo, double *dpUnit, long *lpPulse) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (lAxisNo < 0 || lAxisNo >= MotionCore::getInstance().getAxisCount()) return AXT_RT_MOTION_INVALID_AXIS_NO;
    MotionCore::getInstance().getMoveUnitPerPulse(lAxisNo, dpUnit, lpPulse);
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmMotSetMinVel(long lAxisNo, double dMinVel) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    MotionCore::getInstance().setMinVel(lAxisNo, dMinVel);
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmMotGetMinVel(long lAxisNo, double *dpMinVel) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (dpMinVel) *dpMinVel = MotionCore::getInstance().getMinVel(lAxisNo);
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmMotSetMaxVel(long lAxisNo, double dVel) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    MotionCore::getInstance().setMaxVel(lAxisNo, dVel);
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmMotGetMaxVel(long lAxisNo, double *dpVel) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (dpVel) *dpVel = MotionCore::getInstance().getMaxVel(lAxisNo);
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmMotSetAccelUnit(long lAxisNo, DWORD uAccelUnit) {
    (void)lAxisNo;
    (void)uAccelUnit;
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmMotGetAccelUnit(long lAxisNo, DWORD *upAccelUnit) {
    (void)lAxisNo;
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (upAccelUnit) *upAccelUnit = UNIT_SEC2;
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmMotSetAccelJerk(long lAxisNo, double dAccelJerk) {
    (void)lAxisNo;
    (void)dAccelJerk;
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmMotGetAccelJerk(long lAxisNo, double *dpAccelJerk) {
    (void)lAxisNo;
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (dpAccelJerk) *dpAccelJerk = 50.0;
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmMotSetDecelJerk(long lAxisNo, double dDecelJerk) {
    (void)lAxisNo;
    (void)dDecelJerk;
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmMotGetDecelJerk(long lAxisNo, double *dpDecelJerk) {
    (void)lAxisNo;
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (dpDecelJerk) *dpDecelJerk = 50.0;
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmInfoIsMotionModule(DWORD *upStatus) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (upStatus) *upStatus = STATUS_EXIST;
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmInfoGetFirstAxisNo(long lBoardNo, long lModulePos, long *lpAxisNo) {
    (void)lBoardNo;
    (void)lModulePos;
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (lpAxisNo) {
        *lpAxisNo = 0;
    }
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmInfoGetBoardFirstAxisNo(long lBoardNo, long lModulePos, long *lpAxisNo) {
    (void)lBoardNo;
    (void)lModulePos;
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (lpAxisNo) {
        *lpAxisNo = 0;
    }
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmInfoIsInvalidAxisNo(long lAxisNo) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (lAxisNo < 0 || lAxisNo >= MotionCore::getInstance().getAxisCount()) {
        return AXT_RT_MOTION_INVALID_AXIS_NO;
    }
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmInfoGetAxisStatus(long lAxisNo) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (lAxisNo < 0 || lAxisNo >= MotionCore::getInstance().getAxisCount()) {
        return AXT_RT_MOTION_INVALID_AXIS_NO;
    }
    return AXT_RT_SUCCESS;
}

// --- Parameter Save / Load & ParaLoad (Manual Chapter: Motion Parameter) ---
static double s_para_load[3][4] = {{100.0, 50.0, 200.0, 200.0}, {100.0, 50.0, 200.0, 200.0}, {-100.0, 50.0, 200.0, 200.0}};

DWORD __stdcall AxmMotSaveParaAll(char *szFilePath) {
    (void)szFilePath;
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmMotLoadParaAll(char *szFilePath) {
    (void)szFilePath;
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmMotSetParaLoad(long lAxisNo, double dInitPos, double dInitVel, double dInitAccel, double dInitDecel) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (lAxisNo < 0 || lAxisNo >= 3) return AXT_RT_MOTION_INVALID_AXIS_NO;
    s_para_load[lAxisNo][0] = dInitPos;
    s_para_load[lAxisNo][1] = dInitVel;
    s_para_load[lAxisNo][2] = dInitAccel;
    s_para_load[lAxisNo][3] = dInitDecel;
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmMotGetParaLoad(long lAxisNo, double *dpInitPos, double *dpInitVel, double *dpInitAccel, double *dpInitDecel) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (lAxisNo < 0 || lAxisNo >= 3) return AXT_RT_MOTION_INVALID_AXIS_NO;
    if (dpInitPos) *dpInitPos = s_para_load[lAxisNo][0];
    if (dpInitVel) *dpInitVel = s_para_load[lAxisNo][1];
    if (dpInitAccel) *dpInitAccel = s_para_load[lAxisNo][2];
    if (dpInitDecel) *dpInitDecel = s_para_load[lAxisNo][3];
    return AXT_RT_SUCCESS;
}

// --- CRC Signal API (Manual Chapter: CRC Signal Setting) ---
static DWORD s_crc_level[3] = {HIGH, HIGH, HIGH};
static DWORD s_crc_method[3] = {3, 3, 3};
static DWORD s_crc_out[3] = {0, 0, 0};

DWORD __stdcall AxmCrcSetMaskLevel(long lAxisNo, DWORD uLevel, DWORD uMethod) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (lAxisNo < 0 || lAxisNo >= 3) return AXT_RT_MOTION_INVALID_AXIS_NO;
    s_crc_level[lAxisNo] = uLevel;
    s_crc_method[lAxisNo] = uMethod;
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmCrcGetMaskLevel(long lAxisNo, DWORD *upLevel, DWORD *upMethod) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (lAxisNo < 0 || lAxisNo >= 3) return AXT_RT_MOTION_INVALID_AXIS_NO;
    if (upLevel) *upLevel = s_crc_level[lAxisNo];
    if (upMethod) *upMethod = s_crc_method[lAxisNo];
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmCrcSetOutput(long lAxisNo, DWORD uOnOff) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (lAxisNo < 0 || lAxisNo >= 3) return AXT_RT_MOTION_INVALID_AXIS_NO;
    s_crc_out[lAxisNo] = uOnOff;
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmCrcGetOutput(long lAxisNo, DWORD *upOnOff) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (lAxisNo < 0 || lAxisNo >= 3) return AXT_RT_MOTION_INVALID_AXIS_NO;
    if (upOnOff) *upOnOff = s_crc_out[lAxisNo];
    return AXT_RT_SUCCESS;
}

// --- MPG (Manual Pulse Generator) API ---
static long s_mpg_input[3] = {3, 3, 3};
static long s_mpg_mode[3] = {0, 0, 0};
static double s_mpg_pos[3] = {10.0, 10.0, 10.0};
static double s_mpg_vel[3] = {50.0, 50.0, 50.0};
static double s_mpg_acc[3] = {200.0, 200.0, 200.0};
static DWORD s_mpg_num[3] = {1, 1, 1};
static DWORD s_mpg_den[3] = {4096, 4096, 4096};

DWORD __stdcall AxmMPGSetEnable(long lAxisNo, long lInputMethod, long lDriveMode, double dMPGPos, double dVel, double dAccel) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (lAxisNo < 0 || lAxisNo >= 3) return AXT_RT_MOTION_INVALID_AXIS_NO;
    s_mpg_input[lAxisNo] = lInputMethod;
    s_mpg_mode[lAxisNo] = lDriveMode;
    s_mpg_pos[lAxisNo] = dMPGPos;
    s_mpg_vel[lAxisNo] = dVel;
    s_mpg_acc[lAxisNo] = dAccel;
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmMPGGetEnable(long lAxisNo, long *lpInputMethod, long *lpDriveMode, double *dpMPGPos, double *dpVel, double *dAccel) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (lAxisNo < 0 || lAxisNo >= 3) return AXT_RT_MOTION_INVALID_AXIS_NO;
    if (lpInputMethod) *lpInputMethod = s_mpg_input[lAxisNo];
    if (lpDriveMode) *lpDriveMode = s_mpg_mode[lAxisNo];
    if (dpMPGPos) *dpMPGPos = s_mpg_pos[lAxisNo];
    if (dpVel) *dpVel = s_mpg_vel[lAxisNo];
    if (dAccel) *dAccel = s_mpg_acc[lAxisNo];
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmMPGSetRatio(long lAxisNo, DWORD uMPGnumerator, DWORD uMPGdenominator) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (lAxisNo < 0 || lAxisNo >= 3) return AXT_RT_MOTION_INVALID_AXIS_NO;
    s_mpg_num[lAxisNo] = uMPGnumerator;
    s_mpg_den[lAxisNo] = uMPGdenominator;
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmMPGGetRatio(long lAxisNo, DWORD *upMPGnumerator, DWORD *upMPGdenominator) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (lAxisNo < 0 || lAxisNo >= 3) return AXT_RT_MOTION_INVALID_AXIS_NO;
    if (upMPGnumerator) *upMPGnumerator = s_mpg_num[lAxisNo];
    if (upMPGdenominator) *upMPGdenominator = s_mpg_den[lAxisNo];
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmMPGReset(long lAxisNo) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (lAxisNo < 0 || lAxisNo >= 3) return AXT_RT_MOTION_INVALID_AXIS_NO;
    return AXT_RT_SUCCESS;
}

// --- Sync / Electronic Gear & Gantry API ---
DWORD __stdcall AxmLinkSetMode(long lMasterAxisNo, long lSlaveAxisNo, double dSlaveRatio) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (lMasterAxisNo < 0 || lMasterAxisNo >= 3) return AXT_RT_MOTION_INVALID_AXIS_NO;
    MotionCore::getInstance().setLinkMode(lMasterAxisNo, lSlaveAxisNo, dSlaveRatio);
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmLinkGetMode(long lMasterAxisNo, long *lpSlaveAxisNo, double *dpGearRatio) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (lMasterAxisNo < 0 || lMasterAxisNo >= 3) return AXT_RT_MOTION_INVALID_AXIS_NO;
    MotionCore::getInstance().getLinkMode(lMasterAxisNo, lpSlaveAxisNo, dpGearRatio);
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmLinkResetMode(long lMasterAxisNo) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (lMasterAxisNo < 0 || lMasterAxisNo >= 3) return AXT_RT_MOTION_INVALID_AXIS_NO;
    MotionCore::getInstance().resetLinkMode(lMasterAxisNo);
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmGantrySetEnable(long lMasterAxisNo, long lSlaveAxisNo, DWORD uSlHomeUse, double dSlOffset, double dSlOffsetRange) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (lMasterAxisNo < 0 || lMasterAxisNo >= 3) return AXT_RT_MOTION_INVALID_AXIS_NO;
    MotionCore::getInstance().setGantryEnable(lMasterAxisNo, lSlaveAxisNo, uSlHomeUse, dSlOffset, dSlOffsetRange);
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmGantryGetEnable(long lMasterAxisNo, DWORD *upSlHomeUse, double *dpSlOffset, double *dpSlORange, DWORD *upGatryOn) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (lMasterAxisNo < 0 || lMasterAxisNo >= 3) return AXT_RT_MOTION_INVALID_AXIS_NO;
    uint32_t hu = 0, go = 0;
    MotionCore::getInstance().getGantryEnable(lMasterAxisNo, &hu, dpSlOffset, dpSlORange, &go);
    if (upSlHomeUse) *upSlHomeUse = hu;
    if (upGatryOn) *upGatryOn = go;
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmGantrySetDisable(long lMasterAxisNo, long lSlaveAxisNo) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (lMasterAxisNo < 0 || lMasterAxisNo >= 3) return AXT_RT_MOTION_INVALID_AXIS_NO;
    MotionCore::getInstance().setGantryDisable(lMasterAxisNo, lSlaveAxisNo);
    return AXT_RT_SUCCESS;
}

// --- Interrupt & Trigger API ---
static DWORD s_int_enable[3] = {0, 0, 0};
static DWORD s_int_user_mask[3][2] = {{0, 0}, {0, 0}, {0, 0}};
static double s_trig_time[3] = {100.0, 100.0, 100.0};
static DWORD s_trig_level[3] = {HIGH, HIGH, HIGH};
static DWORD s_trig_select[3] = {COMMAND, COMMAND, COMMAND};
static DWORD s_trig_int[3] = {DISABLE, DISABLE, DISABLE};
static double s_trig_start[3] = {0.0, 0.0, 0.0};
static double s_trig_end[3] = {100.0, 100.0, 100.0};
static double s_trig_period[3] = {10.0, 10.0, 10.0};

DWORD __stdcall AxmInterruptSetAxis(long lAxisNo, HWND hWnd, DWORD uMessage, AXT_INTERRUPT_PROC pProc, HANDLE *pEvent) {
    (void)hWnd; (void)uMessage; (void)pProc; (void)pEvent;
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (lAxisNo < 0 || lAxisNo >= 3) return AXT_RT_MOTION_INVALID_AXIS_NO;
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmInterruptSetAxisEnable(long lAxisNo, DWORD uUse) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (lAxisNo < 0 || lAxisNo >= 3) return AXT_RT_MOTION_INVALID_AXIS_NO;
    s_int_enable[lAxisNo] = uUse;
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmInterruptGetAxisEnable(long lAxisNo, DWORD *upUse) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (lAxisNo < 0 || lAxisNo >= 3) return AXT_RT_MOTION_INVALID_AXIS_NO;
    if (upUse) *upUse = s_int_enable[lAxisNo];
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmInterruptRead(long *lpAxisNo, DWORD *upFlag) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (lpAxisNo) *lpAxisNo = 0;
    if (upFlag) *upFlag = 0;
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmInterruptReadAxisFlag(long lAxisNo, long lBank, DWORD *upFlag) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (lAxisNo < 0 || lAxisNo >= 3) return AXT_RT_MOTION_INVALID_AXIS_NO;
    if (upFlag) *upFlag = s_int_user_mask[lAxisNo][(lBank == 1) ? 1 : 0];
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmInterruptSetUserEnable(long lAxisNo, long lBank, DWORD uInterruptNum) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (lAxisNo < 0 || lAxisNo >= 3) return AXT_RT_MOTION_INVALID_AXIS_NO;
    s_int_user_mask[lAxisNo][(lBank == 1) ? 1 : 0] = uInterruptNum;
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmInterruptGetUserEnable(long lAxisNo, long lBank, DWORD *upInterruptNum) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (lAxisNo < 0 || lAxisNo >= 3) return AXT_RT_MOTION_INVALID_AXIS_NO;
    if (upInterruptNum) *upInterruptNum = s_int_user_mask[lAxisNo][(lBank == 1) ? 1 : 0];
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmTriggerSetTimeLevel(long lAxisNo, double dTrigTime, DWORD uTriggerLevel, DWORD uSelect, DWORD uInterrupt) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (lAxisNo < 0 || lAxisNo >= 3) return AXT_RT_MOTION_INVALID_AXIS_NO;
    s_trig_time[lAxisNo] = dTrigTime;
    s_trig_level[lAxisNo] = uTriggerLevel;
    s_trig_select[lAxisNo] = uSelect;
    s_trig_int[lAxisNo] = uInterrupt;
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmTriggerGetTimeLevel(long lAxisNo, double *dpTrigTime, DWORD *upTriggerLevel, DWORD *upSelect, DWORD *upInterrupt) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (lAxisNo < 0 || lAxisNo >= 3) return AXT_RT_MOTION_INVALID_AXIS_NO;
    if (dpTrigTime) *dpTrigTime = s_trig_time[lAxisNo];
    if (upTriggerLevel) *upTriggerLevel = s_trig_level[lAxisNo];
    if (upSelect) *upSelect = s_trig_select[lAxisNo];
    if (upInterrupt) *upInterrupt = s_trig_int[lAxisNo];
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmTriggerSetBlock(long lAxisNo, double dStartPos, double dEndPos, double dPeriodPos) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (lAxisNo < 0 || lAxisNo >= 3) return AXT_RT_MOTION_INVALID_AXIS_NO;
    s_trig_start[lAxisNo] = dStartPos;
    s_trig_end[lAxisNo] = dEndPos;
    s_trig_period[lAxisNo] = dPeriodPos;
    return AXT_RT_SUCCESS;
}

static DWORD s_trig_method[3] = {PERIOD_MODE, PERIOD_MODE, PERIOD_MODE};
static double s_trig_abs_pos[3] = {10.0, 10.0, 10.0};

DWORD __stdcall AxmTriggerSetAbsPeriod(long lAxisNo, DWORD uMethod, double dPos) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (lAxisNo < 0 || lAxisNo >= 3) return AXT_RT_MOTION_INVALID_AXIS_NO;
    s_trig_method[lAxisNo] = uMethod;
    s_trig_abs_pos[lAxisNo] = dPos;
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmTriggerGetAbsPeriod(long lAxisNo, DWORD *upMethod, double *dpPos) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (lAxisNo < 0 || lAxisNo >= 3) return AXT_RT_MOTION_INVALID_AXIS_NO;
    if (upMethod) *upMethod = s_trig_method[lAxisNo];
    if (dpPos) *dpPos = s_trig_abs_pos[lAxisNo];
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmTriggerOnlyAbs(long lAxisNo, long lTrigNum, double* dpTrigPos) {
    (void)lTrigNum; (void)dpTrigPos;
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (lAxisNo < 0 || lAxisNo >= 3) return AXT_RT_MOTION_INVALID_AXIS_NO;
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmTriggerGetBlock(long lAxisNo, double *dpStartPos, double *dpEndPos, double *dpPeriodPos) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (lAxisNo < 0 || lAxisNo >= 3) return AXT_RT_MOTION_INVALID_AXIS_NO;
    if (dpStartPos) *dpStartPos = s_trig_start[lAxisNo];
    if (dpEndPos) *dpEndPos = s_trig_end[lAxisNo];
    if (dpPeriodPos) *dpPeriodPos = s_trig_period[lAxisNo];
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmTriggerOneShot(long lAxisNo) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (lAxisNo < 0 || lAxisNo >= 3) return AXT_RT_MOTION_INVALID_AXIS_NO;
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmTriggerSetTimerOneshot(long lAxisNo, long lmSec) {
    (void)lmSec;
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (lAxisNo < 0 || lAxisNo >= 3) return AXT_RT_MOTION_INVALID_AXIS_NO;
    return AXT_RT_SUCCESS;
}

} // extern "C"
