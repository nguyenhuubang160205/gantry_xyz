Attribute VB_Name = "MotionDefine"
Public Const CMD_POS = 0

Public Const AXIS_X_COUNT = 0
Public Const AXIS_Y_COUNT = 1
Public Const AXIS_Z_COUNT = 2
Public Const AXIS_U_COUNT = 3
Public Const COORD_NO = 0
Public Const COORDINATE = 0

Declare Sub Sleep Lib "Kernel32" (ByVal dwMilliseconds As Long)

Function AXIS_N04(AXIS_NO As Long, POS As Long) As Long
    AXIS_N04 = (((AXIS_NO \ 4) * 4) + POS)
End Function

'#define AXIS_EVN(AXIS_NO)       (AXIS_NO - (AXIS_NO % 2))           // 쌍을 이루는 축의 짝수축을 찾음
'#define AXIS_ODD(AXIS_NO)       (AXIS_NO + ((AXIS_NO + 1) % 2))     // 쌍을 이루는 축의 홀수축을 찾음
'#define AXIS_QUR(AXIS_NO)       (AXIS_NO % 4)
Function AXIS_EVN(AXIS_NO As Long) As Long
    AXIS_EVN = (AXIS_NO - (AXIS_NO Mod 2))
End Function

Function AXIS_ODD(AXIS_NO As Long) As Long
    AXIS_ODD = (AXIS_NO + (AXIS_NO + 1) Mod 2)
End Function

Function AXIS_QUR(AXIS_NO As Long) As Long
    AXIS_QUR = (AXIS_NO Mod 4)
End Function
Function LED_RED(ON_OFF As Boolean) As Long
    If (ON_OFF = True) Then LED_RED = &HFF& Else LED_RED = &H80&
End Function
Function LED_YELLOW(ON_OFF As Boolean) As Long
    If (ON_OFF = True) Then LED_YELLOW = &HFFFF& Else LED_YELLOW = &H8080&
End Function

