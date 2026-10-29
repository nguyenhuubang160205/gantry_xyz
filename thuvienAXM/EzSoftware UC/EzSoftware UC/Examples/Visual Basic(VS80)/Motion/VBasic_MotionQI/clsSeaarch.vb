Option Strict Off
Option Explicit On
Friend Class clsSearch
	
	Public nAxis As Integer
	Public nDir As Short
	Public nSignal As Short
	Public nStopM As Short
	Public dVelocity As Double
	Public dAccel As Double
	Public nRun As Short
	Dim nLoopStep As Short
	Public Sub SearchSignal()
		Dim dwEdge As Integer
		
		If (nSignal < 6) Then
			dwEdge = 0
			nSignal = nSignal
		Else
			dwEdge = 1
			nSignal = nSignal - 6
		End If
		
		If nSignal > 1 Then
			nSignal = nSignal + 2
		End If
		
		' 각 축의 구동 속도를 차트에 나타내기 위해 차트 최대값 재설정
		Call frmCamcQI.SetGraphRange(nAxis, dVelocity)
		If (nDir = 1) Then
			Call AxmMoveSignalSearch(nAxis, -dVelocity, dAccel, nSignal, dwEdge, nStopM)
		Else
			Call AxmMoveSignalSearch(nAxis, dVelocity, dAccel, nSignal, dwEdge, nStopM)
		End If
		
		nLoopStep = 0
		frmCamcQI.tmTest(AXIS_QUR(nAxis)).Enabled = True
	End Sub
	
	Public Sub SearchSignalLoop()
        Dim dwBusyStatus As Integer
		Dim dwEndStatus As Integer
		
		Select Case nLoopStep
			Case 0
				'UPGRADE_WARNING: dwBusyStatus 개체의 기본 속성을 확인할 수 없습니다. 자세한 내용은 다음을 참조하십시오. 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Call AxmStatusReadInMotion(nAxis, dwBusyStatus)
				'UPGRADE_WARNING: dwBusyStatus 개체의 기본 속성을 확인할 수 없습니다. 자세한 내용은 다음을 참조하십시오. 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If (dwBusyStatus = 0) Then nLoopStep = 1
				If (nRun = 0) Then
					AxmMoveSStop(nAxis)
				End If
				
			Case 1
				' End Status Register를 참조하여 어떤 상태로 구동이 정지 되었는가 확인
				Call AxmStatusReadStop(nAxis, dwEndStatus)
				
				If (nSignal > 1) Then
					'(wReadInput And &H1) = &H1
					If ((dwEndStatus And &H8000FFFF) <> 0) Then
						frmCamcQI.lstLog.Items.Add("검색을 실패하였습니다.")
					Else
						frmCamcQI.lstLog.Items.Add(VB6.Format(nAxis, "0") & "축의" & VB6.GetItemString(frmCamcQI.cboDetect, frmCamcQI.cboDetect.SelectedIndex) & "을 검색하였습니다.")
					End If
				End If
				
				nRun = 0
				nLoopStep = 0
				frmCamcQI.tmTest(AXIS_QUR(nAxis)).Enabled = False
		End Select
		
	End Sub
End Class