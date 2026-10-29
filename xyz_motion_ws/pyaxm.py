#!/usr/bin/env python3
"""
Python Wrapper for Ajinextek Motion Core (libaxm_sim.so)
Allows controlling ROS 2 Gazebo / Web 3D simulation using standard Ajinextek AXL/AXM APIs in Python!
"""

import os
import ctypes
from ctypes import c_long, c_double, c_uint32, POINTER, byref

# Load libaxm_sim.so
LIB_DIR = os.path.join(os.path.dirname(os.path.abspath(__file__)), "lib")
LIB_PATH = os.path.join(LIB_DIR, "libaxm_sim.so")
if not os.path.exists(LIB_PATH):
    raise FileNotFoundError(f"Cannot find libaxm_sim.so at {LIB_PATH}")

_lib = ctypes.CDLL(LIB_PATH)

# --- AXL System ---
_lib.AxlOpen.argtypes = [c_long]
_lib.AxlOpen.restype = c_uint32
def AxlOpen(board_type=7):
    return _lib.AxlOpen(board_type)

_lib.AxlClose.argtypes = []
_lib.AxlClose.restype = c_uint32
def AxlClose():
    return _lib.AxlClose()

_lib.AxlIsOpened.argtypes = []
_lib.AxlIsOpened.restype = c_uint32
def AxlIsOpened():
    return _lib.AxlIsOpened()

# --- Motion PTP ---
_lib.AxmMovePos.argtypes = [c_long, c_double, c_double, c_double, c_double]
_lib.AxmMovePos.restype = c_uint32
def AxmMovePos(axis, pos, vel, acc, dec):
    """Blocking Point-to-Point motion"""
    return _lib.AxmMovePos(axis, float(pos), float(vel), float(acc), float(dec))

_lib.AxmMoveStartPos.argtypes = [c_long, c_double, c_double, c_double, c_double]
_lib.AxmMoveStartPos.restype = c_uint32
def AxmMoveStartPos(axis, pos, vel, acc, dec):
    """Non-blocking Point-to-Point motion"""
    return _lib.AxmMoveStartPos(axis, float(pos), float(vel), float(acc), float(dec))

_lib.AxmMoveVel.argtypes = [c_long, c_double, c_double, c_double]
_lib.AxmMoveVel.restype = c_uint32
def AxmMoveVel(axis, vel, acc, dec):
    return _lib.AxmMoveVel(axis, float(vel), float(acc), float(dec))

_lib.AxmMoveStop.argtypes = [c_long, c_double]
_lib.AxmMoveStop.restype = c_uint32
def AxmMoveStop(axis, dec):
    return _lib.AxmMoveStop(axis, float(dec))

_lib.AxmMoveEStop.argtypes = [c_long]
_lib.AxmMoveEStop.restype = c_uint32
def AxmMoveEStop(axis):
    return _lib.AxmMoveEStop(axis)

# --- Status Reads (Official Ajinextek AXM APIs) ---
_lib.AxmStatusGetActPos.argtypes = [c_long, POINTER(c_double)]
_lib.AxmStatusGetActPos.restype = c_uint32
def AxmStatusGetActPos(axis):
    val = c_double()
    _lib.AxmStatusGetActPos(axis, byref(val))
    return val.value

_lib.AxmStatusGetCmdPos.argtypes = [c_long, POINTER(c_double)]
_lib.AxmStatusGetCmdPos.restype = c_uint32
def AxmStatusGetCmdPos(axis):
    val = c_double()
    _lib.AxmStatusGetCmdPos(axis, byref(val))
    return val.value

_lib.AxmStatusReadVel.argtypes = [c_long, POINTER(c_double)]
_lib.AxmStatusReadVel.restype = c_uint32
def AxmStatusReadVel(axis):
    val = c_double()
    _lib.AxmStatusReadVel(axis, byref(val))
    return val.value

_lib.AxmStatusReadActVel.argtypes = [c_long, POINTER(c_double)]
_lib.AxmStatusReadActVel.restype = c_uint32
def AxmStatusReadActVel(axis):
    val = c_double()
    _lib.AxmStatusReadActVel(axis, byref(val))
    return val.value

_lib.AxmStatusReadPosError.argtypes = [c_long, POINTER(c_double)]
_lib.AxmStatusReadPosError.restype = c_uint32
def AxmStatusReadPosError(axis):
    val = c_double()
    _lib.AxmStatusReadPosError(axis, byref(val))
    return val.value

_lib.AxmStatusReadMechanical.argtypes = [c_long, POINTER(c_uint32)]
_lib.AxmStatusReadMechanical.restype = c_uint32
def AxmStatusReadMechanical(axis):
    val = c_uint32()
    _lib.AxmStatusReadMechanical(axis, byref(val))
    return val.value

_lib.AxmStatusReadInMotion.argtypes = [c_long, POINTER(c_uint32)]
_lib.AxmStatusReadInMotion.restype = c_uint32
def AxmStatusReadInMotion(axis):
    val = c_uint32()
    _lib.AxmStatusReadInMotion(axis, byref(val))
    return val.value == 1

# --- Interpolation ---
_lib.AxmLineMove.argtypes = [c_long, POINTER(c_double), c_double, c_double, c_double]
_lib.AxmLineMove.restype = c_uint32
def AxmLineMove(axis_count, end_pos_list, vel, acc, dec):
    arr_type = c_double * len(end_pos_list)
    arr = arr_type(*[float(x) for x in end_pos_list])
    return _lib.AxmLineMove(axis_count, arr, float(vel), float(acc), float(dec))

_lib.AxmCircleCenterMove.argtypes = [c_long, POINTER(c_long), POINTER(c_double), POINTER(c_double), c_double, c_double, c_double, c_uint32]
_lib.AxmCircleCenterMove.restype = c_uint32
def AxmCircleCenterMove(axes, cen_pos, end_pos, vel, acc, dec, cw_dir=0):
    axes_arr = (c_long * len(axes))(*axes)
    cen_arr = (c_double * len(cen_pos))(*[float(x) for x in cen_pos])
    end_arr = (c_double * len(end_pos))(*[float(x) for x in end_pos])
    return _lib.AxmCircleCenterMove(len(axes), axes_arr, cen_arr, end_arr, float(vel), float(acc), float(dec), cw_dir)

# --- Homing ---
_lib.AxmHomeSetMethod.argtypes = [c_long, c_long, c_uint32, c_uint32, c_double, c_double]
_lib.AxmHomeSetMethod.restype = c_uint32
def AxmHomeSetMethod(axis, hm_dir, home_signal=4, z_phase=1, clr_time=100.0, offset=5.0):
    return _lib.AxmHomeSetMethod(axis, hm_dir, home_signal, z_phase, float(clr_time), float(offset))

_lib.AxmHomeSetVel.argtypes = [c_long, c_double, c_double, c_double, c_double, c_double, c_double]
_lib.AxmHomeSetVel.restype = c_uint32
def AxmHomeSetVel(axis, v1, v2, v3, v4, a1, a2):
    return _lib.AxmHomeSetVel(axis, float(v1), float(v2), float(v3), float(v4), float(a1), float(a2))

_lib.AxmHomeSetStart.argtypes = [c_long]
_lib.AxmHomeSetStart.restype = c_uint32
def AxmHomeSetStart(axis):
    return _lib.AxmHomeSetStart(axis)

_lib.AxmHomeGetRate.argtypes = [c_long, POINTER(c_uint32), POINTER(c_uint32)]
_lib.AxmHomeGetRate.restype = c_uint32
def AxmHomeGetRate(axis):
    step = c_uint32()
    prog = c_uint32()
    _lib.AxmHomeGetRate(axis, byref(step), byref(prog))
    return step.value, prog.value

_lib.AxmHomeGetResult.argtypes = [c_long, POINTER(c_uint32)]
_lib.AxmHomeGetResult.restype = c_uint32
def AxmHomeGetResult(axis):
    res = c_uint32()
    _lib.AxmHomeGetResult(axis, byref(res))
    return res.value

# --- Touch Probe & Digital Inputs (Official Ajinextek AXM APIs) ---
_lib.AxmSignalReadInputBit.argtypes = [c_long, c_long, POINTER(c_uint32)]
_lib.AxmSignalReadInputBit.restype = c_uint32
def AxmSignalReadInputBit(axis, bit_no):
    val = c_uint32()
    _lib.AxmSignalReadInputBit(axis, bit_no, byref(val))
    return val.value

_lib.AxmMoveSignalCapture.argtypes = [c_long, c_double, c_double, c_long, c_long, c_long, c_long]
_lib.AxmMoveSignalCapture.restype = c_uint32
def AxmMoveSignalCapture(axis, vel, accel, detect_signal=0, edge=1, target=0, mode=0):
    return _lib.AxmMoveSignalCapture(axis, float(vel), float(accel), detect_signal, edge, target, mode)

_lib.AxmMoveGetCapturePos.argtypes = [c_long, POINTER(c_double)]
_lib.AxmMoveGetCapturePos.restype = c_uint32
def AxmMoveGetCapturePos(axis):
    val = c_double()
    _lib.AxmMoveGetCapturePos(axis, byref(val))
    return val.value
