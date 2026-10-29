Option Strict Off
Option Explicit On
Module MotionDefine
	Public Const CMD_POS As Short = 0
	
	Public Const AXIS_X_COUNT As Short = 0
	Public Const AXIS_Y_COUNT As Short = 1
	Public Const AXIS_Z_COUNT As Short = 2
	Public Const AXIS_U_COUNT As Short = 3
	Public Const COORD_NO As Short = 0
	Public Const COORDINATE As Short = 0
	
	Declare Sub Sleep Lib "Kernel32" (ByVal dwMilliseconds As Integer)
	
	Function AXIS_N04(ByRef AXIS_NO As Integer, ByRef POS As Integer) As Integer
		AXIS_N04 = (((AXIS_NO \ 4) * 4) + POS)
	End Function
	
	'#define AXIS_EVN(AXIS_NO)       (AXIS_NO - (AXIS_NO % 2))           // 쌍을 이루는 축의 짝수축을 찾음
	'#define AXIS_ODD(AXIS_NO)       (AXIS_NO + ((AXIS_NO + 1) % 2))     // 쌍을 이루는 축의 홀수축을 찾음
	'#define AXIS_QUR(AXIS_NO)       (AXIS_NO % 4)
	Function AXIS_EVN(ByRef AXIS_NO As Integer) As Integer
		AXIS_EVN = (AXIS_NO - (AXIS_NO Mod 2))
	End Function
	
	Function AXIS_ODD(ByRef AXIS_NO As Integer) As Integer
		AXIS_ODD = (AXIS_NO + (AXIS_NO + 1) Mod 2)
	End Function
	
	Function AXIS_QUR(ByRef AXIS_NO As Integer) As Integer
		AXIS_QUR = (AXIS_NO Mod 4)
	End Function
	Function LED_RED(ByRef ON_OFF As Boolean) As Integer
		If (ON_OFF = True) Then LED_RED = &HFF Else LED_RED = &H80
	End Function
	Function LED_YELLOW(ByRef ON_OFF As Boolean) As Integer
		If (ON_OFF = True) Then LED_YELLOW = &HFFFF Else LED_YELLOW = &H8080
	End Function
End Module