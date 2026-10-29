#include "AXL.h"
#include "AXM.h"
#include "MotionCore.hpp"
#include <cmath>
#include <algorithm>

extern "C" {

DWORD __stdcall AxmLineMove(long lCoord, double *dpEndPos, double dVel, double dAccel, double dDecel) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (!dpEndPos) return AXT_RT_INVALID_VARIABLE;

    uint32_t abs_rel = MotionCore::getInstance().contiGetAbsRelMode(lCoord);
    bool is_building = MotionCore::getInstance().contiIsBuilding(lCoord);

    double p_ref[3];
    if (is_building) {
        MotionCore::getInstance().contiGetTailPos(lCoord, p_ref);
    } else {
        p_ref[0] = MotionCore::getInstance().getCmdPos(0);
        p_ref[1] = MotionCore::getInstance().getCmdPos(1);
        p_ref[2] = MotionCore::getInstance().getCmdPos(2);
    }

    long axis_count = MotionCore::getInstance().getContiAxisCount();
    double target_x = (abs_rel == 1) ? (p_ref[0] + dpEndPos[0]) : dpEndPos[0];
    double target_y = (abs_rel == 1) ? (p_ref[1] + dpEndPos[1]) : dpEndPos[1];
    double target_z = (axis_count >= 3) ? ((abs_rel == 1) ? (p_ref[2] + dpEndPos[2]) : dpEndPos[2]) : p_ref[2];

    if (is_building) {
        double end_pos[3] = {target_x, target_y, target_z};
        MotionCore::getInstance().contiAddNodeLine(lCoord, end_pos, dVel, dAccel, dDecel);
        return AXT_RT_SUCCESS;
    }

    MotionCore::getInstance().lineMove(target_x, target_y, target_z, dVel, dAccel, dDecel);
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmLineMoveEx2(long lCoord, double *dpEndPos, double dVel, double dAccel, double dDecel) {
    return AxmLineMove(lCoord, dpEndPos, dVel, dAccel, dDecel);
}

DWORD __stdcall AxmCircleCenterMove(long lCoord, long *lAxisNo, double *dCenterPos, double *dEndPos, double dVel, double dAccel, double dDecel, DWORD uCWDir) {
    (void)lAxisNo;
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (!dCenterPos || !dEndPos) return AXT_RT_INVALID_VARIABLE;

    uint32_t abs_rel = MotionCore::getInstance().contiGetAbsRelMode(lCoord);
    bool is_building = MotionCore::getInstance().contiIsBuilding(lCoord);

    double p_ref[3];
    if (is_building) {
        MotionCore::getInstance().contiGetTailPos(lCoord, p_ref);
    } else {
        p_ref[0] = MotionCore::getInstance().getCmdPos(0);
        p_ref[1] = MotionCore::getInstance().getCmdPos(1);
        p_ref[2] = MotionCore::getInstance().getCmdPos(2);
    }

    double cen_x = (abs_rel == 1) ? (p_ref[0] + dCenterPos[0]) : dCenterPos[0];
    double cen_y = (abs_rel == 1) ? (p_ref[1] + dCenterPos[1]) : dCenterPos[1];
    double end_x = (abs_rel == 1) ? (p_ref[0] + dEndPos[0]) : dEndPos[0];
    double end_y = (abs_rel == 1) ? (p_ref[1] + dEndPos[1]) : dEndPos[1];

    if (is_building) {
        double cen[3] = {cen_x, cen_y, p_ref[2]};
        double end[3] = {end_x, end_y, p_ref[2]};
        MotionCore::getInstance().contiAddNodeCircleCenter(lCoord, cen, end, dVel, dAccel, dDecel, uCWDir);
        return AXT_RT_SUCCESS;
    }

    MotionCore::getInstance().circleCenterMove(cen_x, cen_y, end_x, end_y, dVel, dAccel, dDecel, uCWDir);
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmCircleRadiusMove(long lCoord, long *lAxisNo, double dRadius, double *dEndPos, double dVel, double dAccel, double dDecel, DWORD uCWDir, DWORD uShortDistance) {
    (void)lAxisNo;
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (!dEndPos) return AXT_RT_INVALID_VARIABLE;

    uint32_t abs_rel = MotionCore::getInstance().contiGetAbsRelMode(lCoord);
    bool is_building = MotionCore::getInstance().contiIsBuilding(lCoord);

    double p_ref[3];
    if (is_building) {
        MotionCore::getInstance().contiGetTailPos(lCoord, p_ref);
    } else {
        p_ref[0] = MotionCore::getInstance().getCmdPos(0);
        p_ref[1] = MotionCore::getInstance().getCmdPos(1);
        p_ref[2] = MotionCore::getInstance().getCmdPos(2);
    }

    double cur_x = p_ref[0];
    double cur_y = p_ref[1];
    double end_x = (abs_rel == 1) ? (cur_x + dEndPos[0]) : dEndPos[0];
    double end_y = (abs_rel == 1) ? (cur_y + dEndPos[1]) : dEndPos[1];

    double dx = end_x - cur_x;
    double dy = end_y - cur_y;
    double d = std::hypot(dx, dy);
    if (d < 1e-6 || d > 2.0 * dRadius + 1e-4) return AXT_RT_INVALID_VARIABLE;

    double mid_x = (cur_x + end_x) * 0.5;
    double mid_y = (cur_y + end_y) * 0.5;
    double h = std::sqrt(std::max(0.0, dRadius * dRadius - 0.25 * d * d));

    // CCW (DIR_CCW = 0): center on left; CW (DIR_CW = 1): center on right
    double sign = (uCWDir == 0) ? 1.0 : -1.0;
    if (uShortDistance != 0) sign = -sign;

    double cen_x = mid_x + sign * h * (-dy / d);
    double cen_y = mid_y + sign * h * (dx / d);

    if (is_building) {
        double cen[3] = {cen_x, cen_y, p_ref[2]};
        double end[3] = {end_x, end_y, p_ref[2]};
        MotionCore::getInstance().contiAddNodeCircleCenter(lCoord, cen, end, dVel, dAccel, dDecel, uCWDir);
        return AXT_RT_SUCCESS;
    }

    MotionCore::getInstance().circleCenterMove(cen_x, cen_y, end_x, end_y, dVel, dAccel, dDecel, uCWDir);
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmCircleAngleMove(long lCoord, long *lAxisNo, double *dCenterPos, double dAngle, double dVel, double dAccel, double dDecel, DWORD uCWDir) {
    (void)lAxisNo;
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (!dCenterPos) return AXT_RT_INVALID_VARIABLE;

    uint32_t abs_rel = MotionCore::getInstance().contiGetAbsRelMode(lCoord);
    bool is_building = MotionCore::getInstance().contiIsBuilding(lCoord);

    double p_ref[3];
    if (is_building) {
        MotionCore::getInstance().contiGetTailPos(lCoord, p_ref);
    } else {
        p_ref[0] = MotionCore::getInstance().getCmdPos(0);
        p_ref[1] = MotionCore::getInstance().getCmdPos(1);
        p_ref[2] = MotionCore::getInstance().getCmdPos(2);
    }

    double cur_x = p_ref[0];
    double cur_y = p_ref[1];
    double cen_x = (abs_rel == 1) ? (cur_x + dCenterPos[0]) : dCenterPos[0];
    double cen_y = (abs_rel == 1) ? (cur_y + dCenterPos[1]) : dCenterPos[1];

    double r = std::hypot(cur_x - cen_x, cur_y - cen_y);
    double theta0 = std::atan2(cur_y - cen_y, cur_x - cen_x);
    double rad = dAngle * M_PI / 180.0;
    double theta1 = (uCWDir == 1 /*CW*/) ? (theta0 - rad) : (theta0 + rad);

    double end_x = cen_x + r * std::cos(theta1);
    double end_y = cen_y + r * std::sin(theta1);

    if (is_building) {
        double cen[3] = {cen_x, cen_y, p_ref[2]};
        double end[3] = {end_x, end_y, p_ref[2]};
        MotionCore::getInstance().contiAddNodeCircleCenter(lCoord, cen, end, dVel, dAccel, dDecel, uCWDir);
        return AXT_RT_SUCCESS;
    }

    MotionCore::getInstance().circleCenterMove(cen_x, cen_y, end_x, end_y, dVel, dAccel, dDecel, uCWDir);
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmCirclePointMove(long lCoord, long *lAxisNo, double *dMidPos, double *dEndPos, double dVel, double dAccel, double dDecel, long lArcCircle) {
    (void)lAxisNo; (void)lArcCircle;
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;
    if (!dMidPos || !dEndPos) return AXT_RT_INVALID_VARIABLE;

    uint32_t abs_rel = MotionCore::getInstance().contiGetAbsRelMode(lCoord);
    bool is_building = MotionCore::getInstance().contiIsBuilding(lCoord);

    double p_ref[3];
    if (is_building) {
        MotionCore::getInstance().contiGetTailPos(lCoord, p_ref);
    } else {
        p_ref[0] = MotionCore::getInstance().getCmdPos(0);
        p_ref[1] = MotionCore::getInstance().getCmdPos(1);
        p_ref[2] = MotionCore::getInstance().getCmdPos(2);
    }

    double x0 = p_ref[0], y0 = p_ref[1];
    double x1 = (abs_rel == 1) ? (x0 + dMidPos[0]) : dMidPos[0];
    double y1 = (abs_rel == 1) ? (y0 + dMidPos[1]) : dMidPos[1];
    double x2 = (abs_rel == 1) ? (x0 + dEndPos[0]) : dEndPos[0];
    double y2 = (abs_rel == 1) ? (y0 + dEndPos[1]) : dEndPos[1];

    double A1 = x1 - x0, B1 = y1 - y0;
    double C1 = (x1 * x1 - x0 * x0 + y1 * y1 - y0 * y0) * 0.5;
    double A2 = x2 - x1, B2 = y2 - y1;
    double C2 = (x2 * x2 - x1 * x1 + y2 * y2 - y1 * y1) * 0.5;

    double D = A1 * B2 - A2 * B1;
    if (std::abs(D) < 1e-9) {
        if (is_building) {
            double end_p[3] = {x2, y2, p_ref[2]};
            MotionCore::getInstance().contiAddNodeLine(lCoord, end_p, dVel, dAccel, dDecel);
            return AXT_RT_SUCCESS;
        }
        MotionCore::getInstance().lineMove(x2, y2, p_ref[2], dVel, dAccel, dDecel);
        return AXT_RT_SUCCESS;
    }

    double cx = (C1 * B2 - C2 * B1) / D;
    double cy = (A1 * C2 - A2 * C1) / D;

    double cross = (x1 - x0) * (y2 - y1) - (y1 - y0) * (x2 - x1);
    DWORD uCWDir = (cross > 0.0) ? 0 /*CCW*/ : 1 /*CW*/;

    if (is_building) {
        double cen[3] = {cx, cy, p_ref[2]};
        double end[3] = {x2, y2, p_ref[2]};
        MotionCore::getInstance().contiAddNodeCircleCenter(lCoord, cen, end, dVel, dAccel, dDecel, uCWDir);
        return AXT_RT_SUCCESS;
    }

    MotionCore::getInstance().circleCenterMove(cx, cy, x2, y2, dVel, dAccel, dDecel, uCWDir);
    return AXT_RT_SUCCESS;
}

// =============================================================================
// 3D Helical Interpolation APIs (AXM.h lines 1200-1231)
// =============================================================================

DWORD __stdcall AxmHelixCenterMove(long lCoord, double dCenterXPos, double dCenterYPos, double dEndXPos, double dEndYPos, double dZPos, double dVel, double dAccel, double dDecel, DWORD uCWDir) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;

    uint32_t abs_rel = MotionCore::getInstance().contiGetAbsRelMode(lCoord);
    bool is_building = MotionCore::getInstance().contiIsBuilding(lCoord);

    double p_ref[3];
    if (is_building) {
        MotionCore::getInstance().contiGetTailPos(lCoord, p_ref);
    } else {
        p_ref[0] = MotionCore::getInstance().getCmdPos(0);
        p_ref[1] = MotionCore::getInstance().getCmdPos(1);
        p_ref[2] = MotionCore::getInstance().getCmdPos(2);
    }

    double cen_x = (abs_rel == 1) ? (p_ref[0] + dCenterXPos) : dCenterXPos;
    double cen_y = (abs_rel == 1) ? (p_ref[1] + dCenterYPos) : dCenterYPos;
    double end_x = (abs_rel == 1) ? (p_ref[0] + dEndXPos) : dEndXPos;
    double end_y = (abs_rel == 1) ? (p_ref[1] + dEndYPos) : dEndYPos;
    double end_z = (abs_rel == 1) ? (p_ref[2] + dZPos) : dZPos;

    if (is_building) {
        double cen[3] = {cen_x, cen_y, p_ref[2]};
        double end[3] = {end_x, end_y, end_z};
        MotionCore::getInstance().contiAddNodeCircleCenter(lCoord, cen, end, dVel, dAccel, dDecel, uCWDir);
        return AXT_RT_SUCCESS;
    }

    MotionCore::getInstance().helixCenterMove(cen_x, cen_y, end_x, end_y, end_z, dVel, dAccel, dDecel, uCWDir);
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmHelixRadiusMove(long lCoord, double dRadius, double dEndXPos, double dEndYPos, double dZPos, double dVel, double dAccel, double dDecel, DWORD uCWDir, DWORD uShortDistance) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;

    uint32_t abs_rel = MotionCore::getInstance().contiGetAbsRelMode(lCoord);
    bool is_building = MotionCore::getInstance().contiIsBuilding(lCoord);

    double p_ref[3];
    if (is_building) {
        MotionCore::getInstance().contiGetTailPos(lCoord, p_ref);
    } else {
        p_ref[0] = MotionCore::getInstance().getCmdPos(0);
        p_ref[1] = MotionCore::getInstance().getCmdPos(1);
        p_ref[2] = MotionCore::getInstance().getCmdPos(2);
    }

    double cur_x = p_ref[0];
    double cur_y = p_ref[1];
    double end_x = (abs_rel == 1) ? (cur_x + dEndXPos) : dEndXPos;
    double end_y = (abs_rel == 1) ? (cur_y + dEndYPos) : dEndYPos;
    double end_z = (abs_rel == 1) ? (p_ref[2] + dZPos) : dZPos;

    double dx = end_x - cur_x;
    double dy = end_y - cur_y;
    double d = std::hypot(dx, dy);
    if (d < 1e-6 || d > 2.0 * dRadius + 1e-4) return AXT_RT_INVALID_VARIABLE;

    double mid_x = (cur_x + end_x) * 0.5;
    double mid_y = (cur_y + end_y) * 0.5;
    double h = std::sqrt(std::max(0.0, dRadius * dRadius - 0.25 * d * d));

    double sign = (uCWDir == 0) ? 1.0 : -1.0;
    if (uShortDistance != 0) sign = -sign;

    double cen_x = mid_x + sign * h * (-dy / d);
    double cen_y = mid_y + sign * h * (dx / d);

    if (is_building) {
        double cen[3] = {cen_x, cen_y, p_ref[2]};
        double end[3] = {end_x, end_y, end_z};
        MotionCore::getInstance().contiAddNodeCircleCenter(lCoord, cen, end, dVel, dAccel, dDecel, uCWDir);
        return AXT_RT_SUCCESS;
    }

    MotionCore::getInstance().helixCenterMove(cen_x, cen_y, end_x, end_y, end_z, dVel, dAccel, dDecel, uCWDir);
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmHelixAngleMove(long lCoord, double dCenterXPos, double dCenterYPos, double dAngle, double dZPos, double dVel, double dAccel, double dDecel, DWORD uCWDir) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;

    uint32_t abs_rel = MotionCore::getInstance().contiGetAbsRelMode(lCoord);
    bool is_building = MotionCore::getInstance().contiIsBuilding(lCoord);

    double p_ref[3];
    if (is_building) {
        MotionCore::getInstance().contiGetTailPos(lCoord, p_ref);
    } else {
        p_ref[0] = MotionCore::getInstance().getCmdPos(0);
        p_ref[1] = MotionCore::getInstance().getCmdPos(1);
        p_ref[2] = MotionCore::getInstance().getCmdPos(2);
    }

    double cur_x = p_ref[0];
    double cur_y = p_ref[1];
    double cen_x = (abs_rel == 1) ? (cur_x + dCenterXPos) : dCenterXPos;
    double cen_y = (abs_rel == 1) ? (cur_y + dCenterYPos) : dCenterYPos;
    double end_z = (abs_rel == 1) ? (p_ref[2] + dZPos) : dZPos;

    double r = std::hypot(cur_x - cen_x, cur_y - cen_y);
    double theta0 = std::atan2(cur_y - cen_y, cur_x - cen_x);
    double rad = dAngle * M_PI / 180.0;
    double theta1 = (uCWDir == 1 /*CW*/) ? (theta0 - rad) : (theta0 + rad);

    double end_x = cen_x + r * std::cos(theta1);
    double end_y = cen_y + r * std::sin(theta1);

    if (is_building) {
        double cen[3] = {cen_x, cen_y, p_ref[2]};
        double end[3] = {end_x, end_y, end_z};
        MotionCore::getInstance().contiAddNodeCircleCenter(lCoord, cen, end, dVel, dAccel, dDecel, uCWDir);
        return AXT_RT_SUCCESS;
    }

    MotionCore::getInstance().helixCenterMove(cen_x, cen_y, end_x, end_y, end_z, dVel, dAccel, dDecel, uCWDir);
    return AXT_RT_SUCCESS;
}

DWORD __stdcall AxmHelixPointMove(long lCoord, double dMidXPos, double dMidYPos, double dEndXPos, double dEndYPos, double dZPos, double dVel, double dAccel, double dDecel) {
    if (!MotionCore::getInstance().isOpened()) return AXT_RT_OPEN_ERROR;

    uint32_t abs_rel = MotionCore::getInstance().contiGetAbsRelMode(lCoord);
    bool is_building = MotionCore::getInstance().contiIsBuilding(lCoord);

    double p_ref[3];
    if (is_building) {
        MotionCore::getInstance().contiGetTailPos(lCoord, p_ref);
    } else {
        p_ref[0] = MotionCore::getInstance().getCmdPos(0);
        p_ref[1] = MotionCore::getInstance().getCmdPos(1);
        p_ref[2] = MotionCore::getInstance().getCmdPos(2);
    }

    double x0 = p_ref[0], y0 = p_ref[1];
    double x1 = (abs_rel == 1) ? (x0 + dMidXPos) : dMidXPos;
    double y1 = (abs_rel == 1) ? (y0 + dMidYPos) : dMidYPos;
    double x2 = (abs_rel == 1) ? (x0 + dEndXPos) : dEndXPos;
    double y2 = (abs_rel == 1) ? (y0 + dEndYPos) : dEndYPos;
    double end_z = (abs_rel == 1) ? (p_ref[2] + dZPos) : dZPos;

    double A1 = x1 - x0, B1 = y1 - y0;
    double C1 = (x1 * x1 - x0 * x0 + y1 * y1 - y0 * y0) * 0.5;
    double A2 = x2 - x1, B2 = y2 - y1;
    double C2 = (x2 * x2 - x1 * x1 + y2 * y2 - y1 * y1) * 0.5;

    double D = A1 * B2 - A2 * B1;
    if (std::abs(D) < 1e-9) {
        if (is_building) {
            double end_p[3] = {x2, y2, end_z};
            MotionCore::getInstance().contiAddNodeLine(lCoord, end_p, dVel, dAccel, dDecel);
            return AXT_RT_SUCCESS;
        }
        MotionCore::getInstance().lineMove(x2, y2, end_z, dVel, dAccel, dDecel);
        return AXT_RT_SUCCESS;
    }

    double cx = (C1 * B2 - C2 * B1) / D;
    double cy = (A1 * C2 - A2 * C1) / D;
    double cross = (x1 - x0) * (y2 - y1) - (y1 - y0) * (x2 - x1);
    DWORD uCWDir = (cross > 0.0) ? 0 /*CCW*/ : 1 /*CW*/;

    if (is_building) {
        double cen[3] = {cx, cy, p_ref[2]};
        double end[3] = {x2, y2, end_z};
        MotionCore::getInstance().contiAddNodeCircleCenter(lCoord, cen, end, dVel, dAccel, dDecel, uCWDir);
        return AXT_RT_SUCCESS;
    }

    MotionCore::getInstance().helixCenterMove(cx, cy, x2, y2, end_z, dVel, dAccel, dDecel, uCWDir);
    return AXT_RT_SUCCESS;
}

} // extern "C"
