#include "AXL.h"
#include "AXM.h"
#include "MotionCore.hpp"

extern "C" {

// =============================================================================
// 1. Single-Axis & Multi-Axis Point-to-Point / Jog / Signal Capture APIs
// =============================================================================

DWORD __stdcall AxmMovePos(long lAxisNo, double dPos, double dVel, double dAccel, double dDecel) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (lAxisNo < 0 || lAxisNo >= MotionCore::getInstance().getAxisCount()) return AXT_RT_MOTION_INVALID_AXIS_NO;
    MotionCore::getInstance().movePos(lAxisNo, dPos, dVel, dAccel, dDecel, true);
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmMoveStartPos(long lAxisNo, double dPos, double dVel, double dAccel, double dDecel) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (lAxisNo < 0 || lAxisNo >= MotionCore::getInstance().getAxisCount()) return AXT_RT_MOTION_INVALID_AXIS_NO;
    MotionCore::getInstance().movePos(lAxisNo, dPos, dVel, dAccel, dDecel, false);
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmMoveStartMultiPos(long lArraySize, long *lpAxisNo, double *dpPos, double *dpVel, double *dpAccel, double *dpDecel) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (!lpAxisNo || !dpPos || !dpVel || !dpAccel || !dpDecel) return AXT_RT_INVALID_VARIABLE;
    for (long i = 0; i < lArraySize; ++i) {
        MotionCore::getInstance().movePos(lpAxisNo[i], dpPos[i], dpVel[i], dpAccel[i], dpDecel[i], false);
    }
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmMoveMultiPos(long lArraySize, long *lpAxisNo, double *dpPos, double *dpVel, double *dpAccel, double *dpDecel) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (!lpAxisNo || !dpPos || !dpVel || !dpAccel || !dpDecel) return AXT_RT_INVALID_VARIABLE;
    for (long i = 0; i < lArraySize; ++i) {
        MotionCore::getInstance().movePos(lpAxisNo[i], dpPos[i], dpVel[i], dpAccel[i], dpDecel[i], false);
    }
    for (long i = 0; i < lArraySize; ++i) {
        while (MotionCore::getInstance().isInMotion(lpAxisNo[i])) {
            std::this_thread::sleep_for(std::chrono::milliseconds(2));
        }
    }
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmMoveVel(long lAxisNo, double dVel, double dAccel, double dDecel) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (lAxisNo < 0 || lAxisNo >= MotionCore::getInstance().getAxisCount()) return AXT_RT_MOTION_INVALID_AXIS_NO;
    MotionCore::getInstance().moveVel(lAxisNo, dVel, dAccel, dDecel);
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmMoveStartMultiVel(long lArraySize, long *lpAxesNo, double *dpVel, double *dpAccel, double *dpDecel) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (!lpAxesNo || !dpVel || !dpAccel || !dpDecel) return AXT_RT_INVALID_VARIABLE;
    for (long i = 0; i < lArraySize; ++i) {
        MotionCore::getInstance().moveVel(lpAxesNo[i], dpVel[i], dpAccel[i], dpDecel[i]);
    }
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmMoveSignalSearch(long lAxisNo, double dVel, double dAccel, long lDetectSignal, long lSignalEdge, long lSignalMethod) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (lAxisNo < 0 || lAxisNo >= MotionCore::getInstance().getAxisCount()) return AXT_RT_MOTION_INVALID_AXIS_NO;
    MotionCore::getInstance().moveSignalCapture(lAxisNo, dVel, dAccel, lDetectSignal, lSignalEdge, ACTUAL, lSignalMethod);
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmMoveSignalCapture(long lAxisNo, double dVel, double dAccel, long lDetectSignal, long lSignalEdge, long lTarget, long lSignalMethod) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (lAxisNo < 0 || lAxisNo >= MotionCore::getInstance().getAxisCount()) return AXT_RT_MOTION_INVALID_AXIS_NO;
    MotionCore::getInstance().moveSignalCapture(lAxisNo, dVel, dAccel, lDetectSignal, lSignalEdge, lTarget, lSignalMethod);
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmMoveGetCapturePos(long lAxisNo, double *dpCapPotition) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (lAxisNo < 0 || lAxisNo >= MotionCore::getInstance().getAxisCount()) return AXT_RT_MOTION_INVALID_AXIS_NO;
    if (dpCapPotition) {
        *dpCapPotition = MotionCore::getInstance().getCapturePos(lAxisNo);
    }
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmMoveStop(long lAxisNo, double dDecel) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (lAxisNo < 0 || lAxisNo >= MotionCore::getInstance().getAxisCount()) return AXT_RT_MOTION_INVALID_AXIS_NO;
    MotionCore::getInstance().moveStop(lAxisNo, dDecel);
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmMoveStopEx(long lAxisNo, double dDecel) {
    return AxmMoveStop(lAxisNo, dDecel);
}

DWORD __stdcall AxmMoveEStop(long lAxisNo) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (lAxisNo < 0 || lAxisNo >= MotionCore::getInstance().getAxisCount()) return AXT_RT_MOTION_INVALID_AXIS_NO;
    MotionCore::getInstance().moveEStop(lAxisNo);
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmMoveSStop(long lAxisNo) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (lAxisNo < 0 || lAxisNo >= MotionCore::getInstance().getAxisCount()) return AXT_RT_MOTION_INVALID_AXIS_NO;
    MotionCore::getInstance().moveStop(lAxisNo, 500.0);
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmMoveMultiStop(long lArraySize, long *lpAxesNo, double *dMaxDecel) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (!lpAxesNo || !dMaxDecel) return AXT_RT_INVALID_VARIABLE;
    for (long i = 0; i < lArraySize; ++i) {
        MotionCore::getInstance().moveStop(lpAxesNo[i], dMaxDecel[i]);
    }
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmMoveMultiEStop(long lArraySize, long *lpAxesNo) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (!lpAxesNo) return AXT_RT_INVALID_VARIABLE;
    for (long i = 0; i < lArraySize; ++i) {
        MotionCore::getInstance().moveEStop(lpAxesNo[i]);
    }
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmMoveMultiSStop(long lArraySize, long *lpAxesNo) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (!lpAxesNo) return AXT_RT_INVALID_VARIABLE;
    for (long i = 0; i < lArraySize; ++i) {
        MotionCore::getInstance().moveStop(lpAxesNo[i], 500.0);
    }
    return AXT_RT_SUCCESS;
}

// =============================================================================
// 1b. Official Ajinextek Position & Velocity Override APIs (AXM.h lines 839-896)
// =============================================================================

static double s_override_max_vel[3] = {1000.0, 1000.0, 1000.0};
static DWORD s_override_pos_mode[3] = {0, 0, 0};

DWORD __stdcall AxmOverridePos(long lAxisNo, double dOverridePos) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (lAxisNo < 0 || lAxisNo >= MotionCore::getInstance().getAxisCount()) return AXT_RT_MOTION_INVALID_AXIS_NO;
    MotionCore::getInstance().overridePos(lAxisNo, dOverridePos);
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmOverrideSetMaxVel(long lAxisNo, double dOverrideMaxVel) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (lAxisNo < 0 || lAxisNo >= MotionCore::getInstance().getAxisCount()) return AXT_RT_MOTION_INVALID_AXIS_NO;
    if (dOverrideMaxVel <= 0.0) return AXT_RT_INVALID_VARIABLE;
    s_override_max_vel[lAxisNo] = dOverrideMaxVel;
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmOverrideVel(long lAxisNo, double dOverrideVel) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (lAxisNo < 0 || lAxisNo >= MotionCore::getInstance().getAxisCount()) return AXT_RT_MOTION_INVALID_AXIS_NO;
    double v = std::min(std::abs(dOverrideVel), s_override_max_vel[lAxisNo]);
    MotionCore::getInstance().overrideVel(lAxisNo, v);
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmOverrideAccelVelDecel(long lAxisNo, double dOverrideVelocity, double dMaxAccel, double dMaxDecel) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (lAxisNo < 0 || lAxisNo >= MotionCore::getInstance().getAxisCount()) return AXT_RT_MOTION_INVALID_AXIS_NO;
    double v = std::min(std::abs(dOverrideVelocity), s_override_max_vel[lAxisNo]);
    MotionCore::getInstance().overrideVel(lAxisNo, v, dMaxAccel, dMaxDecel);
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmOverrideVelAtPos(long lAxisNo, double dPos, double dVel, double dAccel, double dDecel, double dOverridePos, double dOverrideVel, long lTarget) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (lAxisNo < 0 || lAxisNo >= MotionCore::getInstance().getAxisCount()) return AXT_RT_MOTION_INVALID_AXIS_NO;
    double v_ovr = std::min(std::abs(dOverrideVel), s_override_max_vel[lAxisNo]);
    MotionCore::getInstance().overrideVelAtPos(lAxisNo, dPos, dVel, dAccel, dDecel, dOverridePos, v_ovr, lTarget);
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmOverrideVelAtMultiPos(long lAxisNo, double dPos, double dVel, double dAccel, double dDecel, long lArraySize, double* dpOverridePos, double* dpOverrideVel, long lTarget, DWORD dwOverrideMode) {
    (void)dwOverrideMode;
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (lAxisNo < 0 || lAxisNo >= MotionCore::getInstance().getAxisCount()) return AXT_RT_MOTION_INVALID_AXIS_NO;
    if (lArraySize <= 0 || !dpOverridePos || !dpOverrideVel) return AXT_RT_INVALID_VARIABLE;
    return AxmOverrideVelAtPos(lAxisNo, dPos, dVel, dAccel, dDecel, dpOverridePos[0], dpOverrideVel[0], lTarget);
}

DWORD __stdcall AxmMotSetOverridePosMode(long lAxisNo, DWORD dwAbsRelMode) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (lAxisNo < 0 || lAxisNo >= MotionCore::getInstance().getAxisCount()) return AXT_RT_MOTION_INVALID_AXIS_NO;
    s_override_pos_mode[lAxisNo] = dwAbsRelMode;
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmMotGetOverridePosMode(long lAxisNo, DWORD *dwpAbsRelMode) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (lAxisNo < 0 || lAxisNo >= MotionCore::getInstance().getAxisCount()) return AXT_RT_MOTION_INVALID_AXIS_NO;
    if (dwpAbsRelMode) *dwpAbsRelMode = s_override_pos_mode[lAxisNo];
    return AXT_RT_SUCCESS;
}

// =============================================================================
// 2. Official Ajinextek Axis Status & Telemetry APIs (AXM.h lines 468-555, 1340-1792)
// =============================================================================

DWORD __stdcall AxmStatusGetActPos(long lAxisNo, double *dpPos) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (lAxisNo < 0 || lAxisNo >= MotionCore::getInstance().getAxisCount()) return AXT_RT_MOTION_INVALID_AXIS_NO;
    if (dpPos) {
        *dpPos = MotionCore::getInstance().getActPos(lAxisNo);
    }
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmStatusGetAmpActPos(long lAxisNo, double *dpPos) {
    return AxmStatusGetActPos(lAxisNo, dpPos);
}

DWORD __stdcall AxmStatusSetActPos(long lAxisNo, double dPos) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (lAxisNo < 0 || lAxisNo >= MotionCore::getInstance().getAxisCount()) return AXT_RT_MOTION_INVALID_AXIS_NO;
    MotionCore::getInstance().setActPos(lAxisNo, dPos);
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmStatusGetCmdPos(long lAxisNo, double *dpPos) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (lAxisNo < 0 || lAxisNo >= MotionCore::getInstance().getAxisCount()) return AXT_RT_MOTION_INVALID_AXIS_NO;
    if (dpPos) {
        *dpPos = MotionCore::getInstance().getCmdPos(lAxisNo);
    }
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmStatusSetCmdPos(long lAxisNo, double dPos) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (lAxisNo < 0 || lAxisNo >= MotionCore::getInstance().getAxisCount()) return AXT_RT_MOTION_INVALID_AXIS_NO;
    MotionCore::getInstance().setCmdPos(lAxisNo, dPos);
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmStatusSetPosMatch(long lAxisNo, double dPos) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (lAxisNo < 0 || lAxisNo >= MotionCore::getInstance().getAxisCount()) return AXT_RT_MOTION_INVALID_AXIS_NO;
    MotionCore::getInstance().setPosition(lAxisNo, dPos);
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmStatusReadVel(long lAxisNo, double *dpVel) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (lAxisNo < 0 || lAxisNo >= MotionCore::getInstance().getAxisCount()) return AXT_RT_MOTION_INVALID_AXIS_NO;
    if (dpVel) {
        *dpVel = MotionCore::getInstance().getCmdVel(lAxisNo);
    }
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmStatusReadVelEx(long lAxisNo, double *dpVel) {
    return AxmStatusReadVel(lAxisNo, dpVel);
}

DWORD __stdcall AxmStatusReadActVel(long lAxisNo, double *dpVel) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (lAxisNo < 0 || lAxisNo >= MotionCore::getInstance().getAxisCount()) return AXT_RT_MOTION_INVALID_AXIS_NO;
    if (dpVel) {
        *dpVel = MotionCore::getInstance().getActVel(lAxisNo);
    }
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmStatusReadPosError(long lAxisNo, double *dpError) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (lAxisNo < 0 || lAxisNo >= MotionCore::getInstance().getAxisCount()) return AXT_RT_MOTION_INVALID_AXIS_NO;
    if (dpError) {
        *dpError = MotionCore::getInstance().getPosError(lAxisNo);
    }
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmStatusReadInMotion(long lAxisNo, DWORD *upStatus) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (lAxisNo < 0 || lAxisNo >= MotionCore::getInstance().getAxisCount()) return AXT_RT_MOTION_INVALID_AXIS_NO;
    if (upStatus) {
        *upStatus = MotionCore::getInstance().isInMotion(lAxisNo) ? 1 : 0;
    }
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmStatusReadMotion(long lAxisNo, DWORD *upStatus) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (lAxisNo < 0 || lAxisNo >= MotionCore::getInstance().getAxisCount()) return AXT_RT_MOTION_INVALID_AXIS_NO;
    if (upStatus) {
        *upStatus = MotionCore::getInstance().getMotionStatus(lAxisNo);
    }
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmStatusReadStop(long lAxisNo, DWORD *upStatus) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (lAxisNo < 0 || lAxisNo >= MotionCore::getInstance().getAxisCount()) return AXT_RT_MOTION_INVALID_AXIS_NO;
    if (upStatus) *upStatus = 0;
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmStatusReadMechanical(long lAxisNo, DWORD *upStatus) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (lAxisNo < 0 || lAxisNo >= MotionCore::getInstance().getAxisCount()) return AXT_RT_MOTION_INVALID_AXIS_NO;
    if (upStatus) {
        *upStatus = MotionCore::getInstance().getMechanicalStatus(lAxisNo);
    }
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmStatusReadMotionInfo(long lAxisNo, PMOTION_INFO pMI) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (lAxisNo < 0 || lAxisNo >= MotionCore::getInstance().getAxisCount()) return AXT_RT_MOTION_INVALID_AXIS_NO;
    if (!pMI) return AXT_RT_INVALID_VARIABLE;
    if (pMI->dwMask & 0x01) pMI->dCmdPos = MotionCore::getInstance().getCmdPos(lAxisNo);
    if (pMI->dwMask & 0x02) pMI->dActPos = MotionCore::getInstance().getActPos(lAxisNo);
    if (pMI->dwMask & 0x04) pMI->dwMechSig = MotionCore::getInstance().getMechanicalStatus(lAxisNo);
    if (pMI->dwMask & 0x08) pMI->dwDrvStat = MotionCore::getInstance().getMotionStatus(lAxisNo);
    if (pMI->dwMask & 0x10) {
        pMI->dwInput = MotionCore::getInstance().readInput(lAxisNo);
        pMI->dwOutput = MotionCore::getInstance().readOutput(lAxisNo);
    }
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmStatusReadServoMonitorValue(long lAxisNo, DWORD dwSelMon, double *dpMonitorValue) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (lAxisNo < 0 || lAxisNo >= MotionCore::getInstance().getAxisCount()) return AXT_RT_MOTION_INVALID_AXIS_NO;
    if (!dpMonitorValue) return AXT_RT_INVALID_VARIABLE;
    switch (dwSelMon) {
        case _MONI_APOS_:  *dpMonitorValue = MotionCore::getInstance().getActPos(lAxisNo); break;
        case _MONI_CPOS_:  *dpMonitorValue = MotionCore::getInstance().getCmdPos(lAxisNo); break;
        case _MONI_PERR_:  *dpMonitorValue = MotionCore::getInstance().getPosError(lAxisNo); break;
        case _MONI_LPOS1_: *dpMonitorValue = MotionCore::getInstance().getCapturePos(lAxisNo); break;
        case _MONI_FSPD_:  *dpMonitorValue = MotionCore::getInstance().getActVel(lAxisNo); break;
        case _MONI_CSPD_:  *dpMonitorValue = MotionCore::getInstance().getCmdVel(lAxisNo); break;
        default:           *dpMonitorValue = 0.0; break;
    }
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmStatusReadTorque(long lAxisNo, double *pdTorque) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (lAxisNo < 0 || lAxisNo >= MotionCore::getInstance().getAxisCount()) return AXT_RT_MOTION_INVALID_AXIS_NO;
    if (pdTorque) {
        // Approximate motor load torque % from acceleration and velocity
        double acc = MotionCore::getInstance().getActAcc(lAxisNo);
        double vel = MotionCore::getInstance().getActVel(lAxisNo);
        *pdTorque = (acc / 25.0) + (vel * 0.02);
    }
    return AXT_RT_SUCCESS;
}

// =============================================================================
// 3. Per-Axis Profile Mode & Abs/Rel Coordinate Mode (AXM.h lines 284-301)
// =============================================================================

DWORD __stdcall AxmMotSetProfileMode(long lAxisNo, DWORD uProfileMode) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (lAxisNo < 0 || lAxisNo >= MotionCore::getInstance().getAxisCount()) return AXT_RT_MOTION_INVALID_AXIS_NO;
    MotionCore::getInstance().setProfileMode(lAxisNo, uProfileMode);
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmMotGetProfileMode(long lAxisNo, DWORD *upProfileMode) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (lAxisNo < 0 || lAxisNo >= MotionCore::getInstance().getAxisCount()) return AXT_RT_MOTION_INVALID_AXIS_NO;
    if (upProfileMode) *upProfileMode = MotionCore::getInstance().getProfileMode(lAxisNo);
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmMotSetAbsRelMode(long lAxisNo, DWORD uAbsRelMode) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (lAxisNo < 0 || lAxisNo >= MotionCore::getInstance().getAxisCount()) return AXT_RT_MOTION_INVALID_AXIS_NO;
    MotionCore::getInstance().setAbsRelMode(lAxisNo, uAbsRelMode);
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmMotGetAbsRelMode(long lAxisNo, DWORD *upAbsRelMode) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (lAxisNo < 0 || lAxisNo >= MotionCore::getInstance().getAxisCount()) return AXT_RT_MOTION_INVALID_AXIS_NO;
    if (upAbsRelMode) *upAbsRelMode = MotionCore::getInstance().getAbsRelMode(lAxisNo);
    return AXT_RT_SUCCESS;
}

// Legacy ABI aliases (not declared in AXM.h, kept only for backwards binary compatibility)
DWORD __stdcall AxmStatusReadActPos(long lAxisNo, double *dpPosition) {
    return AxmStatusGetActPos(lAxisNo, dpPosition);
}
DWORD __stdcall AxmStatusReadCmdPos(long lAxisNo, double *dpPosition) {
    return AxmStatusGetCmdPos(lAxisNo, dpPosition);
}

} // extern "C"
