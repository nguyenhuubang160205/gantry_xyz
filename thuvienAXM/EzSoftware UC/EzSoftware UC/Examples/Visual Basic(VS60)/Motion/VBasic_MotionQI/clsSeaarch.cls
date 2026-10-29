VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "clsSearch"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = False
Option Explicit

Public nAxis As Long
Public nDir As Integer
Public nSignal As Integer
Public nStopM As Integer
Public dVelocity As Double
Public dAccel As Double
Public nRun As Integer
Dim nLoopStep As Integer
Public Sub SearchSignal()
    Dim dwEdge As Long
    
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
    Dim dwBusyStatus, dwEndStatus As Long
    
    Select Case nLoopStep
        Case 0
            Call AxmStatusReadInMotion(nAxis, dwBusyStatus)
            If (dwBusyStatus = 0) Then nLoopStep = 1
            If (nRun = 0) Then
                AxmMoveSStop (nAxis)
            End If
            
        Case 1
            ' End Status Register를 참조하여 어떤 상태로 구동이 정지 되었는가 확인
            Call AxmStatusReadStop(nAxis, dwEndStatus)

            If (nSignal > 1) Then
            '(wReadInput And &H1) = &H1
                If ((dwEndStatus And &H8000FFFF) <> 0) Then
                    frmCamcQI.lstLog.AddItem "검색을 실패하였습니다."
                Else
                    frmCamcQI.lstLog.AddItem Format(nAxis, "0") + "축의" + frmCamcQI.cboDetect.List(frmCamcQI.cboDetect.ListIndex) + "을 검색하였습니다."
                End If
            End If
            
            nRun = 0
            nLoopStep = 0
            frmCamcQI.tmTest(AXIS_QUR(nAxis)).Enabled = False
    End Select
    
End Sub
