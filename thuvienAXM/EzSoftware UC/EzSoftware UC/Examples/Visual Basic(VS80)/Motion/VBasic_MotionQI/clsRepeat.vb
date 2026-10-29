Option Strict Off
Option Explicit On
Friend Class clsRepeat
	
	Public nAxis As Integer
	Public dPosition As Double
	Public dVelocity As Double
	Public dAccel As Double
	Public dDecel As Double
	Public nRun As Short
	Dim dCurPos As Double
	Dim dwMode As Integer
	Dim nLoopStep As Short
	Public Sub StartRepeat()
		' 각 축의 구동 속도를 차트에 나타내기 위해 차트 최대값 재설정
		Call frmCamcQI.SetGraphRange(nAxis, dVelocity)
		Call AxmStatusGetCmdPos(nAxis, dCurPos)
		Call AxmMotGetAbsRelMode(nAxis, dwMode)
		nLoopStep = 0
		frmCamcQI.tmTest(AXIS_QUR(nAxis)).Enabled = True
		
	End Sub
	
	Public Sub StartRepeatLoop()
		Dim dwBusyStatus As Integer
		
		If (nRun = 0) Then
			frmCamcQI.tmTest(AXIS_QUR(nAxis)).Enabled = False
		End If
		
		Select Case nLoopStep
			Case 0
				Call AxmMoveStartPos(nAxis, dPosition, dVelocity, dAccel, dAccel)
				nLoopStep = 1
			Case 1
				Call AxmStatusReadInMotion(nAxis, dwBusyStatus)
				If (dwBusyStatus = 0) Then nLoopStep = 2
				
			Case 2
				If (dwMode = POS_ABS_MODE) Then
					If (dCurPos = dPosition) Then
						frmCamcQI.tmTest(AXIS_QUR(nAxis)).Enabled = False
					Else
						Call AxmMoveStartPos(nAxis, dCurPos, dVelocity, dAccel, dAccel)
						nLoopStep = 3
					End If
				Else
					If (0 = dPosition) Then
						frmCamcQI.tmTest(AXIS_QUR(nAxis)).Enabled = False
					Else
						Call AxmMoveStartPos(nAxis, -dPosition, dVelocity, dAccel, dAccel)
						nLoopStep = 3
					End If
				End If
			Case 3
				Call AxmStatusReadInMotion(nAxis, dwBusyStatus)
				If (dwBusyStatus = 0) Then nLoopStep = 0
		End Select
	End Sub
End Class