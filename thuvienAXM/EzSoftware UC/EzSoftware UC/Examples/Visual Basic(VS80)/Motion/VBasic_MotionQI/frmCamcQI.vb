Option Strict Off
Option Explicit On
Friend Class frmCamcQI
	Inherits System.Windows.Forms.Form
	
	Public m_lAxis As Integer
	Public m_lAxisCounts As Integer
	
	Public m_bA4NAxis As Boolean
	
	Dim m_lRange As Integer
	
    Dim g_Search(64) As clsSearch
    Dim g_Repeat(64) As clsRepeat

	Dim g_nTest As Short
	Dim g_nIntCnt As Short
	Private Sub CLR_Click()
		AxmContiWriteClear(COORD_NO)
	End Sub
    ' Setup active level value of (+) End Limit.
    Private Sub cboLevel0_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cboLevel0.SelectedIndexChanged
        Dim dwPositiveLevel, dwNegativeLevel As Integer
        Dim upStopMode As Integer

        AxmSignalGetLimit(m_lAxis, upStopMode, 0, dwNegativeLevel)

        If (m_bA4NAxis = False) Then
            AxmSignalSetLimit(m_lAxis, upStopMode, cboLevel0.SelectedIndex, dwNegativeLevel)
        Else
            If (cboLevel0.SelectedIndex = 0) Then
                dwPositiveLevel = 2
            Else
                dwPositiveLevel = 1
            End If
            AxmSignalSetLimit(m_lAxis, upStopMode, dwPositiveLevel, dwNegativeLevel)
        End If
    End Sub
    ' Setup active level value of (-) End Limit.
    Private Sub cboLevel1_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cboLevel1.SelectedIndexChanged
        Dim dwPositiveLevel, dwNegativeLevel As Integer
        Dim upStopMode As Integer

        AxmSignalGetLimit(m_lAxis, upStopMode, dwPositiveLevel, 0)

        If (m_bA4NAxis = False) Then
            AxmSignalSetLimit(m_lAxis, upStopMode, dwPositiveLevel, cboLevel1.SelectedIndex)
        Else
            If (cboLevel1.SelectedIndex = 0) Then
                dwNegativeLevel = 2
            Else
                dwNegativeLevel = 1
            End If
            AxmSignalSetLimit(m_lAxis, upStopMode, dwPositiveLevel, dwNegativeLevel)
        End If
    End Sub
    ' Setup active level value of in-position signal.  High if checked, Low if not checked.
    Private Sub cboLevel2_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cboLevel2.SelectedIndexChanged
        Dim dwLevel As Integer

        If (m_bA4NAxis = False) Then
            AxmSignalSetInpos(m_lAxis, cboLevel2.SelectedIndex)
        Else
            If (cboLevel2.SelectedIndex = 0) Then
                dwLevel = 2
            Else
                dwLevel = 1
            End If
            AxmSignalSetInpos(m_lAxis, dwLevel)
        End If
    End Sub

    ' Setup active level value of alarm signal.  High if checked, Low if not checked.
    Private Sub cboLevel3_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cboLevel3.SelectedIndexChanged
        Dim dwLevel As Integer

        If (m_bA4NAxis = False) Then
            AxmSignalSetServoAlarm(m_lAxis, cboLevel3.SelectedIndex)
        Else
            If (cboLevel3.SelectedIndex = 0) Then
                dwLevel = 2
            Else
                dwLevel = 1
            End If
            AxmSignalSetServoAlarm(m_lAxis, dwLevel)
        End If
    End Sub
    ' Setup active level value of Emg Signal.
    Private Sub cboLevel4_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cboLevel4.SelectedIndexChanged
        Dim dwLevel As Integer

        If (m_bA4NAxis = False) Then
            AxmSignalSetStop(m_lAxis, EMERGENCY_STOP, cboLevel4.SelectedIndex)
        Else
            If (cboLevel4.SelectedIndex = 0) Then
                dwLevel = 2
            Else
                dwLevel = 1
            End If
            AxmSignalSetStop(m_lAxis, EMERGENCY_STOP, dwLevel)
        End If
    End Sub
    Private Sub chkHomeLevel_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkHomeLevel.CheckStateChanged
        If (m_bA4NAxis = False) Then
            AxmHomeSetSignalLevel(m_lAxis, chkHomeLevel.CheckState)
        End If
    End Sub
    Private Sub chkZphaseLevel_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkZPhaseLevel.CheckStateChanged
        If (m_bA4NAxis = False) Then
            AxmSignalSetZphaseLevel(m_lAxis, chkZPhaseLevel.CheckState)
        End If
    End Sub
    Private Sub frmCamcQI_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        m_lRange = 2500

        InitLibrary() ' Combined Library and Module initialize
        InitControl() ' Graph and button control initialize

        If (m_lAxisCounts > 0) Then
            UpdateAxisInfo()
        End If

        tmDisplay.Enabled = True
        tmGraph.Enabled = True
    End Sub
    Private Sub btnContiLine_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnContiLine.Click
        Dim lAxis(2) As Integer
        Dim dPos(2) As Double
        Dim dVelocity As Double
        Dim dAccel As Double
        Dim dDecel As Double

        dVelocity = CDbl(edtVelocity.Text)
        dAccel = CDbl(edtAccel.Text)
        dDecel = CDbl(edtDecel.Text)

        lAxis(0) = AXIS_N04(m_lAxis, 0)
        lAxis(1) = AXIS_N04(m_lAxis, 1)
        lAxis(2) = AXIS_N04(m_lAxis, 2)

        SetGraphRange(lAxis(0), dVelocity)
        SetGraphRange(lAxis(2), dVelocity)

        AxmContiSetAxisMap(COORD_NO, 3, lAxis(0))
        AxmContiWriteClear(COORD_NO)
        AxmContiSetAbsRelMode(COORD_NO, POS_ABS_MODE)

        AxmContiBeginNode(COORD_NO)

        dPos(0) = 0 : dPos(1) = 0 : dPos(2) = 0
        AxmLineMove(COORD_NO, dPos(0), dVelocity, dAccel, dDecel)

        dPos(0) = 0 : dPos(1) = 2000 : dPos(2) = 0
        AxmLineMove(COORD_NO, dPos(0), dVelocity, dAccel, dDecel)

        dPos(0) = 0 : dPos(1) = 2000 : dPos(2) = 2000
        AxmLineMove(COORD_NO, dPos(0), dVelocity, dAccel, dDecel)

        dPos(0) = 2000 : dPos(1) = 0 : dPos(2) = 2000
        AxmLineMove(COORD_NO, dPos(0), dVelocity, dAccel, dDecel)

        dPos(0) = 0 : dPos(1) = -2000 : dPos(2) = 2000
        AxmLineMove(COORD_NO, dPos(0), dVelocity, dAccel, dDecel)

        dPos(0) = -2000 : dPos(1) = 0 : dPos(2) = 2000
        AxmLineMove(COORD_NO, dPos(0), dVelocity, dAccel, dDecel)

        dPos(0) = 0 : dPos(1) = 2000 : dPos(2) = 2000
        AxmLineMove(COORD_NO, dPos(0), dVelocity, dAccel, dDecel)

        dPos(0) = 0 : dPos(1) = 2000 : dPos(2) = 0
        AxmLineMove(COORD_NO, dPos(0), dVelocity, dAccel, dDecel)

        dPos(0) = 0 : dPos(1) = 0 : dPos(2) = 0
        AxmLineMove(COORD_NO, dPos(0), dVelocity, dAccel, dDecel)

        AxmContiEndNode(COORD_NO)
    End Sub
    Private Sub btnContiCircle_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnContiCircle.Click
        Dim lAxis(1) As Integer
        Dim dAccel As Double
        Dim dDecel As Double
        Dim dVelocity As Double
        Dim dCenPos(1) As Double
        Dim dEndPos(1) As Double

        dVelocity = CDbl(edtVelocity.Text)
        dAccel = CDbl(edtAccel.Text)
        dDecel = CDbl(edtDecel.Text)

        lAxis(0) = AXIS_N04(m_lAxis, 0)
        lAxis(1) = AXIS_N04(m_lAxis, 1)

        SetGraphRange(lAxis(0), dVelocity)

        AxmContiSetAxisMap(COORD_NO, 2, lAxis(0))
        AxmContiWriteClear(COORD_NO)
        AxmContiSetAbsRelMode(COORD_NO, POS_ABS_MODE)

        AxmContiBeginNode(COORD_NO)

        dCenPos(0) = 1000
        dCenPos(1) = 1000 : dEndPos(0) = 0 : dEndPos(1) = 0
        AxmCircleCenterMove(COORD_NO, lAxis(0), dCenPos(0), dEndPos(0), dVelocity, dAccel, dAccel, DIR_CCW)

        dCenPos(0) = -1000
        dCenPos(1) = 1000 : dEndPos(0) = 0 : dEndPos(1) = 0
        AxmCircleCenterMove(COORD_NO, lAxis(0), dCenPos(0), dEndPos(0), dVelocity, dAccel, dAccel, DIR_CCW)

        dCenPos(0) = -1000
        dCenPos(1) = -1000 : dEndPos(0) = 0 : dEndPos(1) = 0
        AxmCircleCenterMove(COORD_NO, lAxis(0), dCenPos(0), dEndPos(0), dVelocity, dAccel, dAccel, DIR_CCW)

        dCenPos(0) = 1000
        dCenPos(1) = -1000 : dEndPos(0) = 0 : dEndPos(1) = 0
        AxmCircleCenterMove(COORD_NO, lAxis(0), dCenPos(0), dEndPos(0), dVelocity, dAccel, dAccel, DIR_CCW)

        AxmContiEndNode(COORD_NO)
    End Sub
    Private Sub btnContiSpline_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnContiSpline.Click
        Dim lAxis(1) As Integer
        Dim dPosX(4) As Double
        Dim dPosY(4) As Double
        Dim dAccel As Double
        Dim dDecel As Double
        Dim dVelocity As Double

        dVelocity = CDbl(edtVelocity.Text)
        dAccel = CDbl(edtAccel.Text)
        dDecel = CDbl(edtDecel.Text)

        lAxis(0) = AXIS_N04(m_lAxis, 0)
        lAxis(1) = AXIS_N04(m_lAxis, 1)

        SetGraphRange(lAxis(0), dVelocity)

        AxmContiSetAxisMap(COORD_NO, 2, lAxis(0))
        AxmContiWriteClear(COORD_NO)
        AxmContiSetAbsRelMode(COORD_NO, POS_ABS_MODE)

        dPosX(0) = 0 : dPosY(0) = 0
        dPosX(1) = 450 : dPosY(1) = 100
        dPosX(2) = 750 : dPosY(2) = 450
        dPosX(3) = 1080 : dPosY(3) = 750
        dPosX(4) = 1300 : dPosY(4) = 700
        AxmContiBeginNode(COORD_NO)

        AxmSplineWrite(COORD_NO, 5, dPosX(0), dPosY(0), dVelocity, dAccel, dAccel, 0, 100)
        AxmContiEndNode(COORD_NO)
    End Sub
    Private Sub btnContiBlend_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnContiBlend.Click
        Dim lAxis(1) As Integer
        Dim dPos(1) As Double
        Dim dCenPos(1) As Double
        Dim dEndPos(1) As Double
        Dim dAccel As Double
        Dim dDecel As Double
        Dim dVelocity As Double

        dVelocity = CDbl(edtVelocity.Text)
        dAccel = CDbl(edtAccel.Text)
        dDecel = CDbl(edtDecel.Text)

        lAxis(0) = AXIS_N04(m_lAxis, 0)
        lAxis(1) = AXIS_N04(m_lAxis, 1)

        SetGraphRange(lAxis(0), dVelocity)

        AxmContiSetAxisMap(COORD_NO, 2, lAxis(0))
        AxmContiWriteClear(COORD_NO)
        AxmContiSetAbsRelMode(COORD_NO, POS_ABS_MODE)

        AxmContiBeginNode(COORD_NO)
        dPos(0) = 0 : dPos(1) = 2000
        AxmLineMove(COORD_NO, dPos(0), dVelocity, dAccel, dDecel)

        dPos(0) = 1800 : dPos(1) = 2000
        AxmLineMove(COORD_NO, dPos(0), dVelocity, dAccel, dDecel)

        dCenPos(0) = 1800 : dCenPos(1) = 1800 : dEndPos(0) = 2000 : dEndPos(1) = 1800
        AxmCircleCenterMove(COORD_NO, lAxis(0), dCenPos(0), dEndPos(0), dVelocity, dAccel, dAccel, DIR_CW)

        dPos(0) = 2000 : dPos(1) = -1800
        AxmLineMove(COORD_NO, dPos(0), dVelocity, dAccel, dAccel)

        dCenPos(0) = 1800 : dCenPos(1) = -1800 : dEndPos(0) = 1800 : dEndPos(1) = -2000
        AxmCircleCenterMove(COORD_NO, lAxis(0), dCenPos(0), dEndPos(0), dVelocity, dAccel, dAccel, DIR_CW)

        dPos(0) = -1800 : dPos(1) = -2000
        AxmLineMove(COORD_NO, dPos(0), dVelocity, dAccel, dAccel)

        dCenPos(0) = -1800 : dCenPos(1) = -1800 : dEndPos(0) = -2000 : dEndPos(1) = -1800
        AxmCircleCenterMove(COORD_NO, lAxis(0), dCenPos(0), dEndPos(0), dVelocity, dAccel, dAccel, DIR_CW)

        dPos(0) = -2000 : dPos(1) = 1800
        AxmLineMove(COORD_NO, dPos(0), dVelocity, dAccel, dAccel)

        dCenPos(0) = -1800 : dCenPos(1) = 1800 : dEndPos(0) = -1800 : dEndPos(1) = 2000
        AxmCircleCenterMove(COORD_NO, lAxis(0), dCenPos(0), dEndPos(0), dVelocity, dAccel, dAccel, DIR_CW)

        dPos(0) = 0 : dPos(1) = 2000
        AxmLineMove(COORD_NO, dPos(0), dVelocity, dAccel, dAccel)

        AxmContiEndNode(COORD_NO)
    End Sub
    Private Sub btnContiStart_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnContiStart.Click
        AxmContiStart(COORD_NO, 0, 0)
    End Sub
    Private Sub btn3DGraph_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btn3DGraph.Click
        frm3DGraph.UpdateAxis(m_lAxis)
        frm3DGraph.Show()
    End Sub
    Private Sub btnContiTestLine_Click()
        Dim lAxis(3) As Integer
        Dim dPos(3) As Double
        Dim dVelocity, dAccel As Double
        Dim dDecel As Double

        dVelocity = CDbl(edtVelocity.Text)
        dAccel = CDbl(edtAccel.Text)
        dDecel = CDbl(edtDecel.Text)

        lAxis(0) = AXIS_N04(m_lAxis, 0)
        lAxis(1) = AXIS_N04(m_lAxis, 1)
        lAxis(2) = AXIS_N04(m_lAxis, 2)

        AxmContiSetAxisMap(COORD_NO, 3, lAxis(0))
        AxmContiWriteClear(COORD_NO)
        AxmContiSetAbsRelMode(COORD_NO, POS_ABS_MODE)

        AxmContiBeginNode(COORD_NO)

        dPos(0) = 0 : dPos(1) = 0 : dPos(2) = 0
        AxmLineMove(COORD_NO, dPos(0), dVelocity, dAccel, dDecel)

        dPos(0) = 0 : dPos(1) = 1000 : dPos(2) = 0
        AxmLineMove(COORD_NO, dPos(0), dVelocity, dAccel, dDecel)

        dPos(0) = 0 : dPos(1) = 1000 : dPos(2) = 1000
        AxmLineMove(COORD_NO, dPos(0), dVelocity, dAccel, dDecel)

        dPos(0) = 1000 : dPos(1) = 0 : dPos(2) = 1000
        AxmLineMove(COORD_NO, dPos(0), dVelocity, dAccel, dDecel)

        dPos(0) = 0 : dPos(1) = -1000 : dPos(2) = 1000
        AxmLineMove(COORD_NO, dPos(0), dVelocity, dAccel, dDecel)

        dPos(0) = -1000 : dPos(1) = 0 : dPos(2) = 1000
        AxmLineMove(COORD_NO, dPos(0), dVelocity, dAccel, dDecel)

        dPos(0) = 0 : dPos(1) = 1000 : dPos(2) = 1000
        AxmLineMove(COORD_NO, dPos(0), dVelocity, dAccel, dDecel)

        dPos(0) = 0 : dPos(1) = 1000 : dPos(2) = 0
        AxmLineMove(COORD_NO, dPos(0), dVelocity, dAccel, dDecel)

        dPos(0) = 0 : dPos(1) = 0 : dPos(2) = 0
        AxmLineMove(COORD_NO, dPos(0), dVelocity, dAccel, dDecel)

        AxmContiEndNode(COORD_NO)
    End Sub
    Private Sub btnJog_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles btnJog.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Dim Index As Short = btnJog.GetIndex(eventSender)
        Dim lAxisNo As Integer
        Dim lAxis(1) As Integer
        Dim dMVel(1) As Double
        Dim dMAcc(1) As Double
        Dim dMDec(1) As Double
        Dim dVelocity, dAccel As Double
        Dim dDecel As Double

        dVelocity = CDbl(edtVelocity.Text)
        dAccel = CDbl(edtAccel.Text)
        dDecel = CDbl(edtDecel.Text)

        dMAcc(0) = dMAcc(1) = dAccel
        dMDec(0) = dMDec(1) = dDecel

        Select Case Index
            Case 0
                lAxisNo = AXIS_N04(m_lAxis, 0)
                lAxis(0) = AXIS_N04(m_lAxis, 0)
                lAxis(1) = AXIS_N04(m_lAxis, 1)
                dMVel(0) = dVelocity
                dMVel(1) = dVelocity
            Case 1
                lAxisNo = AXIS_N04(m_lAxis, 0)
                lAxis(0) = AXIS_N04(m_lAxis, 0)
                lAxis(1) = AXIS_N04(m_lAxis, 1)
                dMVel(0) = -dVelocity
                dMVel(1) = -dVelocity
            Case 2
                lAxisNo = AXIS_N04(m_lAxis, 1)
                lAxis(0) = AXIS_N04(m_lAxis, 0)
                lAxis(1) = AXIS_N04(m_lAxis, 1)
                dMVel(0) = dVelocity
                dMVel(1) = dVelocity
            Case 3
                lAxisNo = AXIS_N04(m_lAxis, 1)
                lAxis(0) = AXIS_N04(m_lAxis, 0)
                lAxis(1) = AXIS_N04(m_lAxis, 1)
                dMVel(0) = -dVelocity
                dMVel(1) = -dVelocity
            Case 4
                lAxisNo = AXIS_N04(m_lAxis, 2)
                lAxis(0) = AXIS_N04(m_lAxis, 2)
                lAxis(1) = AXIS_N04(m_lAxis, 3)
                dMVel(0) = dVelocity
                dMVel(1) = dVelocity
            Case 5
                lAxisNo = AXIS_N04(m_lAxis, 2)
                lAxis(0) = AXIS_N04(m_lAxis, 2)
                lAxis(1) = AXIS_N04(m_lAxis, 3)
                dMVel(0) = -dVelocity
                dMVel(1) = -dVelocity
            Case 6
                lAxisNo = AXIS_N04(m_lAxis, 3)
                lAxis(0) = AXIS_N04(m_lAxis, 2)
                lAxis(1) = AXIS_N04(m_lAxis, 3)
                dMVel(0) = dVelocity
                dMVel(1) = dVelocity
            Case 7
                lAxisNo = AXIS_N04(m_lAxis, 3)
                lAxis(0) = AXIS_N04(m_lAxis, 2)
                lAxis(1) = AXIS_N04(m_lAxis, 3)
                dMVel(0) = -dVelocity
                dMVel(1) = -dVelocity
        End Select

        If (Index < 4) Then
            GraphX.SetRanges(0, dVelocity + (dVelocity * 0.2))
        Else
            GraphY.SetRanges(0, dVelocity + (dVelocity * 0.2))
        End If

        If (chkXYSyn.CheckState = 1) Then
            If (chkAsym.CheckState = True) Then
                AxmMoveStartMultiVel(2, lAxis(0), dMVel(0), dMAcc(0), dMDec(0))
            Else
                AxmMoveStartMultiVel(2, lAxis(0), dMVel(0), dMAcc(0), dMAcc(0))
            End If
        Else
            If (chkAsym.CheckState = 1) Then
                AxmMoveVel(lAxisNo, dMVel(0), dAccel, dDecel)
            Else
                AxmMoveVel(lAxisNo, dMVel(0), dAccel, dAccel)
            End If
        End If
    End Sub
    Private Sub btnJog_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles btnJog.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Dim Index As Short = btnJog.GetIndex(eventSender)
        Dim lAxisNo As Integer
        lAxisNo = AXIS_N04(m_lAxis, Index \ 2)
        AxmMoveSStop(lAxisNo)
    End Sub
    Private Sub btnlinear_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnlinear.Click
        Dim strMsg As String
        Dim lAxis(1) As Integer
        Dim dPos(1) As Double
        Dim uErrorCode As Integer
        Dim dPosition, dAccel As Double
        Dim dDecel As Double
        Dim dVelocity As Double

        dVelocity = CDbl(edtVelocity.Text)
        dAccel = CDbl(edtAccel.Text)
        dDecel = CDbl(edtDecel.Text)

        dPos(0) = CDbl(edtXCen.Text)
        dPos(1) = CDbl(edtYCen.Text)

        lAxis(0) = AXIS_EVN(m_lAxis)
        lAxis(1) = AXIS_ODD(m_lAxis)

        SetGraphRange(lAxis(0), dVelocity)
        AxmContiSetAxisMap(COORD_NO, 2, lAxis(0))
        AxmContiWriteClear(COORD_NO)

        SetCoordMovePara()
        uErrorCode = AxmLineMove(COORD_NO, dPos(0), dVelocity, dAccel, dDecel)

        strMsg = "Linear Error Code:" & VB6.Format(uErrorCode)
        If (uErrorCode <> AXT_RT_SUCCESS) Then lstLog.Items.Add((strMsg))

        AxmMotGetParaLoad(m_lAxis, dPosition, 0, 0, 0)
        AxmMotSetParaLoad(m_lAxis, dPosition, dVelocity, dAccel, dDecel)
    End Sub
    Private Sub SetCoordMovePara()
        If (chkAbsolute.CheckState = 1) Then
            AxmContiSetAbsRelMode(COORD_NO, POS_ABS_MODE)
        Else
            AxmContiSetAbsRelMode(COORD_NO, POS_REL_MODE)
        End If
    End Sub
    Private Sub btnCircular_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnCircular.Click
        Dim lAxis(1) As Integer
        Dim dCenPos(1) As Double
        Dim uErrorCode As Integer
        Dim dAccel, dDecel As Double
        Dim dAngle As Double
        Dim dPosition As Double
        Dim dVelocity As Double

        dVelocity = CDbl(edtVelocity.Text)
        dAccel = CDbl(edtAccel.Text)
        dDecel = CDbl(edtDecel.Text)
        dAngle = CDbl(edtAngle.Text)

        dCenPos(0) = CDbl(edtXCen.Text)
        dCenPos(1) = CDbl(edtYCen.Text)

        lAxis(0) = AXIS_EVN(m_lAxis)
        lAxis(0) = AXIS_ODD(m_lAxis)

        SetGraphRange(lAxis(0), dVelocity)

        AxmContiSetAxisMap(COORD_NO, 2, lAxis(0))
        AxmContiWriteClear(COORD_NO)

        SetCoordMovePara()
        If chkCwCcw.CheckState = True Then
            uErrorCode = AxmCircleAngleMove(COORD_NO, lAxis(0), dCenPos(0), dAngle, dVelocity, dAccel, dDecel, 0)
        Else
            uErrorCode = AxmCircleAngleMove(COORD_NO, lAxis(0), dCenPos(0), dAngle, dVelocity, dAccel, dDecel, 1)
        End If

        If uErrorCode <> AXT_RT_SUCCESS Then
            lstLog.Items.Add("Circular Error Code: " & VB6.Format(uErrorCode))
        End If

        AxmMotGetParaLoad(m_lAxis, dPosition, 0, 0, 0)
        AxmMotSetParaLoad(m_lAxis, dPosition, dVelocity, dAccel, dDecel)
    End Sub
    Private Sub btnManualSet_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnManualSet.Click
        frmManualSet.UpdateAxis(m_lAxis)
        frmManualSet.Show()
    End Sub
    Private Sub btnReadCapture_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnReadCapture.Click
        Dim dCapPos As Double

        AxmMoveGetCapturePos(m_lAxis, dCapPos)
        edtCapturePos.Text = VB6.Format(dCapPos, "0.00000")
    End Sub
    Private Sub btnStop_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnStop.Click
        If tmTest(AXIS_QUR(m_lAxis)).Enabled = True Then
            g_Repeat(AXIS_QUR(m_lAxis)).nRun = 0
            g_Search(AXIS_QUR(m_lAxis)).nRun = 0
            AxmMoveSStop(m_lAxis)
        Else
            AxmMoveSStop(m_lAxis)
        End If

        lstLog.Items.Add("Stop move.")
        lstLog.SelectedIndex = lstLog.Items.Count - 1
    End Sub
    Private Sub btnEstop_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnEstop.Click
        Dim i As Short

        Me.tmTest(AXIS_QUR(0)).Enabled = False
        Me.tmTest(AXIS_QUR(1)).Enabled = False
        Me.tmTest(AXIS_QUR(2)).Enabled = False
        Me.tmTest(AXIS_QUR(3)).Enabled = False

        For i = 0 To m_lAxisCounts - 1
            AxmMoveEStop(i)
        Next i

        lstLog.Items.Add("All axis emergency stopped.")
        lstLog.SelectedIndex = lstLog.Items.Count - 1
    End Sub
    Private Sub btnVelover_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnVelOverride.Click
        Dim dPosition As Double
        Dim dVelocity As Double
        Dim dAccel As Double
        Dim dDecel As Double

        dPosition = CDbl(edtPosition.Text)
        dVelocity = CDbl(edtVelocity.Text)
        dAccel = CDbl(edtAccel.Text)
        dDecel = CDbl(edtDecel.Text)

        SetGraphRange(m_lAxis, dVelocity * 2)
        AxmOverrideVelAtPos(m_lAxis, dPosition, dVelocity, dAccel, dAccel, dPosition / 4, dVelocity * 2, COMMAND_Renamed)
    End Sub
    ' Make edit window to be active for setting a value of reduced speed when asymmetric running mode.
    Private Sub chkAsym_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkAsym.CheckStateChanged
        Dim dwProfile As Integer
        'ProfileMode: '0' - symmetry Trapezoid
        '             '1' - asymmetry Trapezoid
        '             '2' - symmetry Quasi-S Curve
        '             '3' - symmetry S Curve
        '             '4' - asymmetry S Curve
        AxmMotGetProfileMode(m_lAxis, dwProfile)
        If chkAsym.CheckState = 1 Then
            edtDecel.Enabled = True
            If (dwProfile = 0) Or (dwProfile = 3) Then
                dwProfile = (dwProfile + 1)
            Else
                dwProfile = 4
            End If
        Else
            edtDecel.Enabled = False
            If (dwProfile = 1) Or (dwProfile = 4) Then
                dwProfile = (dwProfile - 1)
            Else
                dwProfile = 3
            End If
        End If

        AxmMotSetProfileMode(m_lAxis, dwProfile)
    End Sub
    Private Sub chkSCurve_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkSCurve.CheckStateChanged
        Dim dwProfile As Integer
        'ProfileMode: '0' - symmetry Trapezoid
        '             '1' - asymmetry Trapezoid
        '             '2' - symmetry Quasi-S Curve
        '             '3' - symmetry S Curve
        '             '4' - asymmetry S Curve
        AxmMotGetProfileMode(m_lAxis, dwProfile)
        If chkSCurve.CheckState = 1 Then
            If (dwProfile = 0 Or dwProfile = 1) Then
                dwProfile = (dwProfile + 3)
            Else
                dwProfile = 3
            End If
        Else
            If (dwProfile = 3 Or dwProfile = 4) Then
                dwProfile = (dwProfile - 3)
            Else
                dwProfile = 0
            End If
        End If
        AxmMotSetProfileMode(m_lAxis, dwProfile)
    End Sub
    Private Sub chkGantry_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkGantry.CheckStateChanged
        Dim uErrorCode As Integer
        If (chkGantry.CheckState = 1) Then
            uErrorCode = AxmGantrySetEnable(AXIS_EVN(m_lAxis), AXIS_ODD(m_lAxis), cbGantrySlave.SelectedIndex, 0.0#, 100000.0#)
            lstLog.Items.Add("Gantry Enable ErrCode " & Trim(CStr(uErrorCode)))
        Else
            AxmGantrySetDisable(AXIS_EVN(m_lAxis), AXIS_ODD(m_lAxis))
            lstLog.Items.Add("Gantry Disable")
        End If
    End Sub
    Private Sub chkGearOnOff_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkGearOnOff.CheckStateChanged
        Dim dRatio As Double
        dRatio = CDbl(edtGearRatio.Text)
        ' It is a function to setup gear rate of Master axis and Slave axis on Electric Gear mode.
        If (chkGearOnOff.CheckState = 1) Then
            AxmLinkSetMode(AXIS_EVN(m_lAxis), AXIS_ODD(m_lAxis), dRatio)
        Else
            AxmLinkResetMode(AXIS_EVN(m_lAxis))
        End If
    End Sub
    Private Sub btnContiTestSpline_Click()
        Dim dVelocity, dAccel As Double
        Dim dDecel As Double
        Dim dPosX(4) As Double
        Dim dPosY(4) As Double
        Dim lAxis(1) As Integer

        dVelocity = CDbl(edtVelocity.Text)
        dAccel = CDbl(edtAccel.Text)
        dDecel = CDbl(edtDecel.Text)

        lAxis(0) = AXIS_N04(m_lAxis, 0)
        lAxis(1) = AXIS_N04(m_lAxis, 1)

        AxmContiSetAxisMap(COORD_NO, 2, lAxis(0))
        AxmContiWriteClear(COORD_NO)
        AxmContiSetAbsRelMode(COORD_NO, 0)

        AxmContiSetAxisMap(COORD_NO, 2, lAxis(0))
        AxmContiSetAbsRelMode(COORD_NO, 0)

        dPosX(0) = 0 : dPosY(0) = 0
        dPosX(1) = 450 : dPosY(1) = 100
        dPosX(2) = 750 : dPosY(2) = 450
        dPosX(3) = 1080 : dPosY(3) = 750
        dPosX(4) = 1300 : dPosY(4) = 700

        AxmContiBeginNode(COORD_NO)
        AxmSplineWrite(COORD_NO, 5, dPosX(0), dPosY(0), dVelocity, dAccel, dAccel, 0, 100)
        AxmContiEndNode(COORD_NO)
    End Sub
    Private Sub btnContiClear_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnContiClear.Click
        AxmContiWriteClear(COORD_NO)
    End Sub
    Private Sub btnContiTest_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnContiTest.Click
        Dim dVelocity As Double
        Dim dAccel As Double

        Dim lAxis(1) As Integer
        Dim dPos(1) As Double
        Dim lPosSize As Integer
        Dim dCenPos(1) As Double
        Dim dEndPos(1) As Double

        lPosSize = 2
        lAxis(0) = 0
        lAxis(1) = 1
        dVelocity = CDbl(edtVelocity.Text)
        dAccel = CDbl(edtAccel.Text)

        SetGraphRange(lAxis(0), dVelocity)

        AxmContiSetAxisMap(COORD_NO, lPosSize, lAxis(0))
        AxmContiWriteClear(COORD_NO)
        AxmContiSetAbsRelMode(COORD_NO, POS_REL_MODE)

        AxmContiBeginNode(COORD_NO) : dPos(0) = -15000 : dPos(1) = 0

        AxmLineMove(COORD_NO, dPos(0), dVelocity, dAccel, dAccel) '1
        dCenPos(0) = 0 : dCenPos(1) = 5000 : dEndPos(0) = -5000 : dEndPos(1) = 5000
        AxmCircleCenterMove(COORD_NO, lAxis(0), dCenPos(0), dEndPos(0), dVelocity, dAccel, dAccel, DIR_CW) '2
        dPos(0) = 0 : dPos(1) = 30000
        AxmLineMove(COORD_NO, dPos(0), dVelocity, dAccel, dAccel) '3
        dCenPos(0) = 5000 : dCenPos(1) = 0 : dEndPos(0) = 5000 : dEndPos(1) = 5000
        AxmCircleCenterMove(COORD_NO, lAxis(0), dCenPos(0), dEndPos(0), dVelocity, dAccel, dAccel, DIR_CW) '4
        dPos(0) = 30000 : dPos(1) = 0
        AxmLineMove(COORD_NO, dPos(0), dVelocity, dAccel, dAccel) '5
        dCenPos(0) = 0 : dCenPos(1) = -5000 : dEndPos(0) = 5000 : dEndPos(1) = -5000
        AxmCircleCenterMove(COORD_NO, lAxis(0), dCenPos(0), dEndPos(0), dVelocity, dAccel, dAccel, DIR_CW) '6
        dPos(0) = 0 : dPos(1) = -30000
        AxmLineMove(COORD_NO, dPos(0), dVelocity, dAccel, dAccel) '7
        dCenPos(0) = -5000 : dCenPos(1) = 0 : dEndPos(0) = -5000 : dEndPos(1) = -5000
        AxmCircleCenterMove(COORD_NO, lAxis(0), dCenPos(0), dEndPos(0), dVelocity, dAccel, dAccel, DIR_CW) '8
        dPos(0) = -15000 : dPos(1) = 0

        AxmLineMove(COORD_NO, dPos(0), dVelocity, dAccel, dAccel) '9
        dPos(0) = -10000 : dPos(1) = 0

        AxmLineMove(COORD_NO, dPos(0), dVelocity, dAccel, dAccel) '10
        dCenPos(0) = 0 : dCenPos(1) = 10000 : dEndPos(0) = -10000 : dEndPos(1) = 10000
        AxmCircleCenterMove(COORD_NO, lAxis(0), dCenPos(0), dEndPos(0), dVelocity, dAccel, dAccel, DIR_CW) '11
        dPos(0) = 0 : dPos(1) = 20000
        AxmLineMove(COORD_NO, dPos(0), dVelocity, dAccel, dAccel) '12
        dCenPos(0) = 10000 : dCenPos(1) = 0 : dEndPos(0) = 10000 : dEndPos(1) = 10000
        AxmCircleCenterMove(COORD_NO, lAxis(0), dCenPos(0), dEndPos(0), dVelocity, dAccel, dAccel, DIR_CW) '13
        dPos(0) = 20000 : dPos(1) = 0
        AxmLineMove(COORD_NO, dPos(0), dVelocity, dAccel, dAccel) '14
        dCenPos(0) = 0 : dCenPos(1) = -10000 : dEndPos(0) = 10000 : dEndPos(1) = -10000
        AxmCircleCenterMove(COORD_NO, lAxis(0), dCenPos(0), dEndPos(0), dVelocity, dAccel, dAccel, DIR_CW) '15
        dPos(0) = 0 : dPos(1) = -20000
        AxmLineMove(COORD_NO, dPos(0), dVelocity, dAccel, dAccel) '16
        dCenPos(0) = -10000 : dCenPos(1) = 0 : dEndPos(0) = -10000 : dEndPos(1) = -10000
        AxmCircleCenterMove(COORD_NO, lAxis(0), dCenPos(0), dEndPos(0), dVelocity, dAccel, dAccel, DIR_CW) '17
        dPos(0) = -10000 : dPos(1) = 0
        AxmLineMove(COORD_NO, dPos(0), dVelocity, dAccel, dAccel) '18
        dCenPos(0) = 0 : dCenPos(1) = 20000 : dEndPos(0) = 0 : dEndPos(1) = 0
        AxmCircleCenterMove(COORD_NO, lAxis(0), dCenPos(0), dEndPos(0), dVelocity, dAccel, dAccel, DIR_CW) '19
        dCenPos(0) = 0 : dCenPos(1) = 10000 : dEndPos(0) = -7071 : dEndPos(1) = 2929
        AxmCircleCenterMove(COORD_NO, lAxis(0), dCenPos(0), dEndPos(0), dVelocity, dAccel, dAccel, DIR_CW) '20

        dPos(0) = -10000 : dPos(1) = 10000
        AxmLineMove(COORD_NO, dPos(0), dVelocity, dAccel, dAccel) '21
        dCenPos(0) = 7071 : dCenPos(1) = 7071 : dEndPos(0) = 0 : dEndPos(1) = 14142
        AxmCircleCenterMove(COORD_NO, lAxis(0), dCenPos(0), dEndPos(0), dVelocity, dAccel, dAccel, DIR_CW) '22
        dPos(0) = 10000 : dPos(1) = 10000
        AxmLineMove(COORD_NO, dPos(0), dVelocity, dAccel, dAccel) '23
        dCenPos(0) = 7071 : dCenPos(1) = -7071 : dEndPos(0) = 14142 : dEndPos(1) = 0
        AxmCircleCenterMove(COORD_NO, lAxis(0), dCenPos(0), dEndPos(0), dVelocity, dAccel, dAccel, DIR_CW) '24
        dPos(0) = 10000 : dPos(1) = -10000
        AxmLineMove(COORD_NO, dPos(0), dVelocity, dAccel, dAccel) '25
        dCenPos(0) = -7071 : dCenPos(1) = -7071 : dEndPos(0) = 0 : dEndPos(1) = -14142
        AxmCircleCenterMove(COORD_NO, lAxis(0), dCenPos(0), dEndPos(0), dVelocity, dAccel, dAccel, DIR_CW) '26
        dPos(0) = -10000 : dPos(1) = -10000
        AxmLineMove(COORD_NO, dPos(0), dVelocity, dAccel, dAccel) '27
        dCenPos(0) = -7071 : dCenPos(1) = 7071 : dEndPos(0) = -7071 : dEndPos(1) = -2929

        AxmCircleCenterMove(COORD_NO, lAxis(0), dCenPos(0), dEndPos(0), dVelocity, dAccel, dAccel, DIR_CW) '28
        dCenPos(0) = 0 : dCenPos(1) = 10000 : dEndPos(0) = 0 : dEndPos(1) = 20000
        AxmCircleCenterMove(COORD_NO, lAxis(0), dCenPos(0), dEndPos(0), dVelocity, dAccel, dAccel, DIR_CW) '29
        dCenPos(0) = 0 : dCenPos(1) = 10000 : dEndPos(0) = 0 : dEndPos(1) = 20000
        AxmCircleCenterMove(COORD_NO, lAxis(0), dCenPos(0), dEndPos(0), dVelocity, dAccel, dAccel, DIR_CCW) '30
        dCenPos(0) = 0 : dCenPos(1) = -5000 : dEndPos(0) = 0 : dEndPos(1) = -10000
        AxmCircleCenterMove(COORD_NO, lAxis(0), dCenPos(0), dEndPos(0), dVelocity, dAccel, dAccel, DIR_CCW) '31

        dCenPos(0) = 0 : dCenPos(1) = -5000 : dEndPos(0) = 0 : dEndPos(1) = -10000
        AxmCircleCenterMove(COORD_NO, lAxis(0), dCenPos(0), dEndPos(0), dVelocity, dAccel, dAccel, DIR_CW) '32
        dCenPos(0) = 0 : dCenPos(1) = -5000 : dEndPos(0) = 0 : dEndPos(1) = -10000
        AxmCircleCenterMove(COORD_NO, lAxis(0), dCenPos(0), dEndPos(0), dVelocity, dAccel, dAccel, DIR_CCW) '33
        dCenPos(0) = 0 : dCenPos(1) = -5000 : dEndPos(0) = 0 : dEndPos(1) = -10000
        AxmCircleCenterMove(COORD_NO, lAxis(0), dCenPos(0), dEndPos(0), dVelocity, dAccel, dAccel, DIR_CW) '34

        AxmContiEndNode(COORD_NO)
    End Sub
    Private Sub btnStatus_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnStatus.Click
        frmStatus.UpdateAxis(m_lAxis)
        frmStatus.Show()
    End Sub
    Private Sub btnCountclr_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnCountclr.Click
        AxmStatusSetActPos(AXIS_N04(m_lAxis, 0), 0.0#)
        AxmStatusSetActPos(AXIS_N04(m_lAxis, 1), 0.0#)
        AxmStatusSetCmdPos(AXIS_N04(m_lAxis, 2), 0.0#)
        AxmStatusSetCmdPos(AXIS_N04(m_lAxis, 3), 0.0#)

        AxmStatusSetCmdPos(AXIS_N04(m_lAxis, 0), 0.0#)
        AxmStatusSetCmdPos(AXIS_N04(m_lAxis, 1), 0.0#)
        AxmStatusSetActPos(AXIS_N04(m_lAxis, 2), 0.0#)
        AxmStatusSetActPos(AXIS_N04(m_lAxis, 3), 0.0#)

        XYPlot.Reset = 1
        lstLog.Items.Clear()
    End Sub
    Function InitLibrary() As Boolean
        ' Initialize AXT board
        If (AxlOpen(7) <> AXT_RT_SUCCESS) Then
            MsgBox("Intialize Fail..!!")
        End If
    End Function
    ' Initialize Control
    Sub InitControl()
        Dim i As Short
        Dim dwModuleID As Integer

        cboDetect.SelectedIndex = 4
        cboDirection.SelectedIndex = 1
        cboStopM.SelectedIndex = 1

        cboHomeSignal.SelectedIndex = 2
        cboHomeDir.SelectedIndex = 0

        GraphX.SetRanges(0, 400)
        GraphY.SetRanges(0, 400)

        XYPlot.SetRange(-2500, 2500, -2500, 2500)

        GraphX.SetRanges(0, 400)
        GraphX.SetPlotColor(RGB(255, 0, 0), 0)
        GraphX.SetPlotColor(RGB(0, 255, 0), 1)
        GraphX.SetXUnits("Time(sampling: 100 msec)", "0", "")
        GraphX.SetYUnits("unit/s", "0", "")

        GraphY.SetRanges(0, 400)
        GraphY.SetPlotColor(RGB(255, 255, 0), 0)
        GraphY.SetPlotColor(RGB(0, 255, 255), 1)
        GraphY.SetXUnits("Time(sampling: 100 msec)", "0", "")
        GraphY.SetYUnits("unit/s", "0", "")

        AxmInfoGetAxisCount(m_lAxisCounts)
        ' Initialize setup of axis
        For i = 0 To m_lAxisCounts - 1
            g_Repeat(i) = New clsRepeat
            g_Search(i) = New clsSearch

            AxmInfoGetAxis(i, 0, 0, dwModuleID)
            Select Case dwModuleID
                Case AXT_SMC_4V04
                    cboAxisSet.Items.Add(Format(i, "00") + "-[PCIB-QI4A]")
                Case AXT_SMC_R1V04
                    cboAxisSet.Items.Add(Format(i, "00") + "-(RTEX-PM)")
                Case AXT_SMC_R1V04PM2Q
                    cboAxisSet.Items.Add(Format(i, "00") + "-(RTEX-PM2Q)")
                Case AXT_SMC_R1V04PM2QE
                    cboAxisSet.Items.Add(Format(i, "00") + "-(RTEX-PM2QE)")
                Case AXT_SMC_R1V04A4
                    cboAxisSet.Items.Add(Format(i, "00") + "-[RTEX-A4N]")
                Case AXT_SMC_R1V04A5
                    cboAxisSet.Items.Add(Format(i, "00") + "-[RTEX-A5N]")
                Case AXT_SMC_R1V04MLIISV
                    cboAxisSet.Items.Add(Format(i, "00") + "-[MLII-SGDV]")
                Case AXT_SMC_R1V04MLIIPM
                    cboAxisSet.Items.Add(Format(i, "00") + "-(MLII-PM)")
                Case AXT_SMC_R1V04MLIICL
                    cboAxisSet.Items.Add(Format(i, "00") + "-[MLII-CSDL]")
                Case AXT_SMC_R1V04MLIICR
                    cboAxisSet.Items.Add(Format(i, "00") + "-[MLII-CSDH]")
                Case AXT_SMC_R1V04SIIIHMIV
                    cboAxisSet.Items.Add(Format(i, "00") + "-[SIIIH-MRJ4]")
                Case Else
                    cboAxisSet.Items.Add(Format(i, "00") + "-[Unknown]")
            End Select
        Next
    End Sub

    Sub UpdateAxisInfo()
        Dim dwMEncInput As Integer = 0
        Dim dwMPulseOut As Integer = 0
        Dim dwAbsRel As Integer = 0
        Dim dwProfile As Integer = 0

        Dim lPulse As Integer = 1
        Dim dUnit As Double = 1.0
        Dim dMinVelocity As Double = 1.0
        Dim dInitVel As Double = 1.0
        Dim dInitPos As Double = 1.0
        Dim dInitAccel As Double = 1.0
        Dim dInitDecel As Double = 1.0

        Dim dwAlarmLevel As Integer = 0
        Dim dwPositiveLevel As Integer = 0
        Dim dwNegativeLevel As Integer = 0
        Dim dwInposLevel As Integer = 0
        Dim dwSlhomeUse As Integer = 0
        Dim dwHomeLevel As Integer = 0
        Dim dwZphaseLevel As Integer = 0
        Dim dwStopMode As Integer = 0
        Dim dwReadEmg As Integer = 0
        Dim dGearRatio As Double = 1.0
        Dim dwModuleID As Integer

        cboAxisSet.SelectedIndex = m_lAxis

        AxmInfoGetAxis(m_lAxis, 0, 0, dwModuleID)
        ' RTEX- PM
        If (dwModuleID = AXT_SMC_4V04) Or (dwModuleID = AXT_SMC_2V03) Or (dwModuleID = AXT_SMC_R1V04) Or (dwModuleID = AXT_SMC_R1V04PM2Q) Or (dwModuleID = AXT_SMC_R1V04PM2QE) Then
            m_bA4NAxis = False

            cboEncInputM.Enabled = True
            cboPulseOutM.Enabled = True

            cboLevel0.Items.Clear()
            cboLevel0.Items.Add("L")
            cboLevel0.Items.Add("H")
            cboLevel0.Items.Add("D")
            cboLevel1.Items.Clear()
            cboLevel1.Items.Add("L")
            cboLevel1.Items.Add("H")
            cboLevel1.Items.Add("D")
            cboLevel2.Items.Clear()
            cboLevel2.Items.Add("L")
            cboLevel2.Items.Add("H")
            cboLevel2.Items.Add("D")
            cboLevel3.Items.Clear()
            cboLevel3.Items.Add("L")
            cboLevel3.Items.Add("H")
            cboLevel3.Items.Add("D")
            cboLevel4.Items.Clear()
            cboLevel4.Items.Add("L")
            cboLevel4.Items.Add("H")
            cboLevel4.Items.Add("D")

            chkZPhaseLevel.Enabled = True
            chkHomeLevel.Enabled = True

            edtTrigStartPosition.Enabled = True
            edtTrigCycle.Enabled = True
            edtTrigPulseWidth.Enabled = True
            edtTrigEndPos.Enabled = True
            btnTrigAbs.Enabled = True
            btnTrigOneShot.Enabled = True
            btnTrigPeriod.Enabled = True
            btnTrigReset.Enabled = True
            m_grLevel.Text = "Level Setting"

            If (dwModuleID = AXT_SMC_R1V04) Or (dwModuleID = AXT_SMC_R1V04PM2Q) Or (dwModuleID = AXT_SMC_R1V04PM2QE) Then
                btnMPGOn.Enabled = False
                btnMPGOff.Enabled = False
                btnCRCOn.Enabled = False
                btnCRCOff.Enabled = False
                btnIntMessage.Enabled = False
                btnIntDisable.Enabled = False
                btnReadCapture.Enabled = False
                btnSigCapture.Enabled = False
            Else
                btnMPGOn.Enabled = True
                btnMPGOff.Enabled = True
                btnCRCOn.Enabled = True
                btnCRCOff.Enabled = True
                btnIntMessage.Enabled = True
                btnIntDisable.Enabled = True
                btnReadCapture.Enabled = True
                btnSigCapture.Enabled = True
            End If
            ' A4N Servo Drive
        ElseIf (dwModuleID = AXT_SMC_R1V04A4) Or (dwModuleID = AXT_SMC_R1V04MLIISV) Or (dwModuleID = AXT_SMC_R1V04SIIIHMIV) Then
            m_bA4NAxis = True

            cboEncInputM.Enabled = False
            cboPulseOutM.Enabled = False

            cboLevel0.Items.Clear()
            cboLevel0.Items.Add("D")
            cboLevel0.Items.Add("E")
            cboLevel1.Items.Clear()
            cboLevel1.Items.Add("D")
            cboLevel1.Items.Add("E")
            cboLevel2.Items.Clear()
            cboLevel2.Items.Add("D")
            cboLevel2.Items.Add("E")
            cboLevel3.Items.Clear()
            cboLevel3.Items.Add("D")
            cboLevel3.Items.Add("E")
            cboLevel4.Items.Clear()
            cboLevel4.Items.Add("D")
            cboLevel4.Items.Add("E")

            chkZPhaseLevel.Enabled = False
            chkHomeLevel.Enabled = False

            edtTrigStartPosition.Enabled = False
            edtTrigCycle.Enabled = False
            edtTrigPulseWidth.Enabled = False
            edtTrigEndPos.Enabled = False
            btnTrigAbs.Enabled = False
            btnTrigOneShot.Enabled = False
            btnTrigPeriod.Enabled = False
            btnTrigReset.Enabled = False
            btnCRCOn.Enabled = False
            btnCRCOff.Enabled = False
            btnMPGOn.Enabled = False
            btnMPGOff.Enabled = False

            m_grLevel.Text = "Level/Usage"

            btnIntMessage.Enabled = False
            btnIntDisable.Enabled = False
            btnReadCapture.Enabled = False
            btnSigCapture.Enabled = False
        End If

        AxmMotGetParaLoad(m_lAxis, dInitPos, dInitVel, dInitAccel, dInitDecel)

        ' Display pulse output method after initialization, encoder input method, initial speed, distance rate by pulse on the screen.
        AxmMotGetMoveUnitPerPulse(m_lAxis, dUnit, lPulse)
        AxmMotGetMinVel(m_lAxis, dMinVelocity)

        edtUnit.Text = VB6.Format(dUnit, "0.00000")
        edtPulse.Text = CStr(lPulse)
        edtMoveUnit.Text = VB6.Format(dUnit / lPulse, "0.000000")
        edtStartSpeed.Text = VB6.Format(dMinVelocity, "0.000")

        edtPosition.Text = VB6.Format(dInitPos, "0.000")
        edtVelocity.Text = VB6.Format(dInitVel, "0.000")
        edtAccel.Text = VB6.Format(dInitAccel, "0.000")
        edtDecel.Text = VB6.Format(dInitDecel, "0.000")

        AxmMotGetProfileMode(m_lAxis, dwProfile)
        AxmMotGetAbsRelMode(m_lAxis, dwAbsRel)

        If (m_bA4NAxis = False) Then
            AxmMotGetEncInputMethod(m_lAxis, dwMEncInput)
            AxmMotGetPulseOutMethod(m_lAxis, dwMPulseOut)
            cboEncInputM.SelectedIndex = dwMEncInput
            cboPulseOutM.SelectedIndex = dwMPulseOut
        End If

        If (dwAbsRel = 1) Then
            chkRelative.CheckState = System.Windows.Forms.CheckState.Checked
            chkAbsolute.CheckState = System.Windows.Forms.CheckState.Unchecked
        Else
            chkRelative.CheckState = System.Windows.Forms.CheckState.Unchecked
            chkAbsolute.CheckState = System.Windows.Forms.CheckState.Checked
        End If

        If ((dwProfile = 2) Or (dwProfile = 3) Or (dwProfile = 4)) Then
            chkSCurve.CheckState = System.Windows.Forms.CheckState.Checked
        Else
            chkSCurve.CheckState = System.Windows.Forms.CheckState.Unchecked
        End If


        If ((dwProfile = 1) Or (dwProfile = 4)) Then
            edtDecel.Enabled = True
            chkAsym.CheckState = System.Windows.Forms.CheckState.Checked
        Else
            edtDecel.Enabled = False
            chkAsym.CheckState = System.Windows.Forms.CheckState.Unchecked
        End If

        AxmSignalGetLimit(m_lAxis, dwStopMode, dwPositiveLevel, dwNegativeLevel)
        AxmSignalGetServoAlarm(m_lAxis, dwAlarmLevel)
        AxmSignalGetInpos(m_lAxis, dwInposLevel)
        AxmSignalGetStop(m_lAxis, dwStopMode, dwReadEmg)

        If (m_bA4NAxis = False) Then
            AxmHomeGetSignalLevel(m_lAxis, dwHomeLevel)
            AxmSignalGetZphaseLevel(m_lAxis, dwZphaseLevel)

            If (dwPositiveLevel = 3) Then
                dwPositiveLevel = 0
            End If
            cboLevel0.SelectedIndex = dwPositiveLevel
            If (dwNegativeLevel = 3) Then
                dwNegativeLevel = 0
            End If
            cboLevel1.SelectedIndex = dwNegativeLevel
            If (dwReadEmg = 3) Then
                dwReadEmg = 0
            End If
            cboLevel4.SelectedIndex = dwReadEmg
            If (dwAlarmLevel = 3) Then
                dwAlarmLevel = 0
            End If
            cboLevel3.SelectedIndex = dwAlarmLevel
            If (dwInposLevel = 3) Then
                dwInposLevel = 0
            End If
            cboLevel2.SelectedIndex = dwInposLevel
            chkHomeLevel.CheckState = dwHomeLevel
            chkZPhaseLevel.CheckState = dwZphaseLevel
        Else
            If (dwPositiveLevel = 2) Then
                dwPositiveLevel = 0
            Else
                dwPositiveLevel = 1
            End If
            cboLevel0.SelectedIndex = dwPositiveLevel
            If (dwNegativeLevel = 2) Then
                dwNegativeLevel = 0
            Else
                dwNegativeLevel = 1
            End If
            cboLevel1.SelectedIndex = dwNegativeLevel
            If (dwReadEmg = 2) Then
                dwReadEmg = 0
            Else
                dwReadEmg = 1
            End If
            cboLevel4.SelectedIndex = dwReadEmg
            If (dwAlarmLevel = 2) Then
                dwAlarmLevel = 0
            Else
                dwAlarmLevel = 1
            End If
            cboLevel3.SelectedIndex = dwAlarmLevel
            If (dwInposLevel = 2) Then
                dwInposLevel = 0
            Else
                dwInposLevel = 1
            End If
            cboLevel2.SelectedIndex = dwInposLevel
        End If

        AxmLinkGetMode(AXIS_EVN(m_lAxis), 0, dGearRatio)
        If (dGearRatio > 0) Then
            edtGearRatio.Text = VB6.Format(dGearRatio, "0.000")
            chkGearOnOff.CheckState = System.Windows.Forms.CheckState.Checked
        Else
            chkGearOnOff.CheckState = System.Windows.Forms.CheckState.Unchecked
        End If

        SetTitleBar(m_lAxis)

        AxmGantryGetEnable(m_lAxis, dwSlhomeUse, 0, 0, 0)

        cbGantrySlave.SelectedIndex = dwSlhomeUse

        If AXIS_N04(m_lAxis, 0) < m_lAxisCounts Then
            GraphX.SetLegendLabel(Format(AXIS_N04(m_lAxis, 0), "00") + "Axis", 0)
        Else
            GraphX.SetLegendLabel("None", 0)
        End If

        If AXIS_N04(m_lAxis, 1) < m_lAxisCounts Then
            GraphX.SetLegendLabel(Format(AXIS_N04(m_lAxis, 1), "00") + "Axis", 1)
        Else
            GraphX.SetLegendLabel("None", 1)
        End If

        If AXIS_N04(m_lAxis, 2) < m_lAxisCounts Then
            GraphY.SetLegendLabel(Format(AXIS_N04(m_lAxis, 2), "00") + "Axis", 0)
        Else
            GraphY.SetLegendLabel("None", 0)
        End If

        If AXIS_N04(m_lAxis, 3) < m_lAxisCounts Then
            GraphY.SetLegendLabel(Format(AXIS_N04(m_lAxis, 3), "00") + "Axis", 1)
        Else
            GraphY.SetLegendLabel("None", 1)
        End If
    End Sub
    Sub SetTitleBar(ByRef lAxis As Integer)
        Dim dwModuleID As Integer
        Dim lAxtBoardNo As Integer
        Dim lModulePos As Integer

        AxmInfoGetAxis(lAxis, lAxtBoardNo, lModulePos, dwModuleID)
        Me.Text = "Ajinextek Motion Board No[" & VB6.Format(lAxtBoardNo, "00") & "], Module Pos[" & VB6.Format(lModulePos, "00") & "], Module ID[0x" & VB6.Format(Hex(dwModuleID), "00") & "]"
    End Sub
    Private Sub frmCamcQI_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Dim i As Short
        For i = 0 To i < m_lAxisCounts
            AxmMoveEStop(i)
            AxmSignalWriteOutputBit(i, 0, 0)
        Next i

        AxlClose()
        End
    End Sub
    ' To absolute coordinate if it was checked when click the check box of absolute coordinate.
    Private Sub chkAbsolute_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkAbsolute.CheckStateChanged
        If (chkAbsolute.CheckState = 1) Then
            chkRelative.CheckState = System.Windows.Forms.CheckState.Unchecked
            AxmMotSetAbsRelMode(m_lAxis, POS_ABS_MODE)
        Else
            chkRelative.CheckState = System.Windows.Forms.CheckState.Checked
            AxmMotSetAbsRelMode(m_lAxis, POS_REL_MODE)
        End If
    End Sub
    ' To opposite coordinate if it was checked when click the check box of opposite coordinate.
    Private Sub chkRelative_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkRelative.CheckStateChanged
        If (chkRelative.CheckState = 1) Then
            chkAbsolute.CheckState = System.Windows.Forms.CheckState.Unchecked
            AxmMotSetAbsRelMode(m_lAxis, POS_REL_MODE)
        Else
            chkAbsolute.CheckState = System.Windows.Forms.CheckState.Checked
            AxmMotSetAbsRelMode(m_lAxis, POS_ABS_MODE)
        End If
    End Sub
    Private Sub chkAsy_Click()
        If (chkAsym.CheckState = 1) Then
            edtDecel.Enabled = True

        Else
            edtDecel.Enabled = False
        End If

    End Sub
    Private Sub btnSigCapture_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnSigCapture.Click
        Dim bySignal As Byte
        Dim dAccel As Double
        Dim dVelocity As Double
        Dim dwEdge As Integer
        Dim lDirect As Short
        Dim lSignalMethod As Integer

        dVelocity = CDbl(edtVelocity.Text)
        dAccel = CDbl(edtAccel.Text)
        bySignal = cboDetect.SelectedIndex
        lDirect = cboDirection.SelectedIndex
        lSignalMethod = cboStopM.SelectedIndex

        ' Re-setup of the maximum value in chart for displaying running speed of each axis on the chart.
        SetGraphRange(m_lAxis, dVelocity)

        If (bySignal < 8) Then
            dwEdge = 0
            bySignal = cboDetect.SelectedIndex
        Else
            dwEdge = 1
            bySignal = cboDetect.SelectedIndex - 8
        End If

        If (lDirect = 0) Then
            AxmMoveSignalCapture(m_lAxis, dVelocity, dAccel, bySignal, dwEdge, COMMAND_Renamed, lSignalMethod)
        Else
            AxmMoveSignalCapture(m_lAxis, -dVelocity, dAccel, bySignal, dwEdge, COMMAND_Renamed, lSignalMethod)
        End If
    End Sub
    Private Sub btnContiTestCircle_Click()
        Dim lAxis(1) As Integer
        Dim dVelocity, dAccel As Double
        Dim dDecel As Double
        Dim dCenPos(1) As Double
        Dim dedtTrigEndPos(1) As Double

        dVelocity = CDbl(edtVelocity.Text)
        dAccel = CDbl(edtAccel.Text)
        dDecel = CDbl(edtDecel.Text)

        lAxis(0) = AXIS_N04(m_lAxis, 0)
        lAxis(1) = AXIS_N04(m_lAxis, 1)

        AxmContiSetAxisMap(COORD_NO, 2, lAxis(0))
        AxmContiWriteClear(COORD_NO)
        AxmContiSetAbsRelMode(COORD_NO, POS_ABS_MODE)

        AxmContiBeginNode(COORD_NO)

        dCenPos(0) = 500
        dCenPos(1) = 500 : dedtTrigEndPos(0) = 0 : dedtTrigEndPos(1) = 0
        AxmCircleCenterMove(COORD_NO, lAxis(0), dCenPos(0), dedtTrigEndPos(0), dVelocity, dAccel, dAccel, DIR_CCW)

        dCenPos(0) = -500
        dCenPos(1) = 500 : dedtTrigEndPos(0) = 0 : dedtTrigEndPos(1) = 0
        AxmCircleCenterMove(COORD_NO, lAxis(0), dCenPos(0), dedtTrigEndPos(0), dVelocity, dAccel, dAccel, DIR_CCW)

        dCenPos(0) = -500
        dCenPos(1) = -500 : dedtTrigEndPos(0) = 0 : dedtTrigEndPos(1) = 0
        AxmCircleCenterMove(COORD_NO, lAxis(0), dCenPos(0), dedtTrigEndPos(0), dVelocity, dAccel, dAccel, DIR_CCW)

        dCenPos(0) = 500
        dCenPos(1) = -500 : dedtTrigEndPos(0) = 0 : dedtTrigEndPos(0) = 0
        AxmCircleCenterMove(COORD_NO, lAxis(0), dCenPos(0), dedtTrigEndPos(0), dVelocity, dAccel, dAccel, DIR_CCW)

        AxmContiEndNode(COORD_NO)
    End Sub
    Private Sub btnCRCOn_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnCRCOn.Click
        ' Level   : LOW(0), HIGH(1), UNUSED(2), USED(3)
        ' uMethod : Remove remaining pulse, possible to setup output signal pulse range of 0 - 6
        ' 0: Don't care , 1: Don't care, 2: 500 uSec, 3: 1 mSec, 4: 10 mSec, 5: 50 mSec, 6: 100 mSec
        AxmCrcSetMaskLevel(m_lAxis, HIGH, 6)
    End Sub
    Private Sub btnCRCOff_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnCRCOff.Click
        AxmCrcSetMaskLevel(m_lAxis, UNUSED, 6)
    End Sub
    Private Sub btnMPGOn_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnMPGOn.Click
        Dim dVelocity As Double
        Dim dAccel As Double

        dVelocity = CDbl(edtVelocity.Text)
        dAccel = CDbl(edtAccel.Text)

        Dim lInputMethod As Integer
        Dim lDriveMode As Integer

        Dim dMPGPosition As Double
        Dim dMPGdenominator As Double
        Dim dMPGnumerator As Double

        lInputMethod = 3
        lDriveMode = 0

        dMPGPosition = 1000
        dMPGdenominator = 4096 ' MPG(Manual Pulse Generation device Input) divide value when running (Calculated to add 1 to input value)
        dMPGnumerator = 1 ' MPG(Manual Pulse Generation device Input) multiply value when running (Calculated to add 1 to input value)

        ' dwNumerator   : Possible to setup maximum (1 to 64).
        ' dwDenominator : Possible to setup maximum (1 to 4096).
        'UPGRADE_WARNING: dVelocity 개체의 기본 속성을 확인할 수 없습니다. 자세한 내용은 다음을 참조하십시오. 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        AxmMPGSetEnable(m_lAxis, lInputMethod, lDriveMode, dMPGPosition, dVelocity, dAccel)
        AxmMPGSetRatio(m_lAxis, dMPGnumerator, dMPGdenominator)
    End Sub
    Private Sub btnMPGOff_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnMPGOff.Click
        AxmMPGReset(m_lAxis)
    End Sub
    Private Sub btnLoad_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnLoad.Click
        Dim sFileName As String

        CommonDialog1Open.Filter = "All Files (*.*)|*.*|Data File (*.mot)|*.mot||"
        CommonDialog1Save.Filter = "All Files (*.*)|*.*|Data File (*.mot)|*.mot||"
        CommonDialog1Open.FileName = "*.mot"
        CommonDialog1Save.FileName = "*.mot"
        CommonDialog1Open.FilterIndex = 2
        CommonDialog1Save.FilterIndex = 2

        CommonDialog1Open.ShowDialog()
        CommonDialog1Save.FileName = CommonDialog1Open.FileName
        sFileName = CommonDialog1Open.FileName
        If sFileName <> "" Then
            If AxmMotLoadParaAll(sFileName) <> AXT_RT_SUCCESS Then
                lstLog.Items.Add(("File load fail!"))
                lstLog.SelectedIndex = lstLog.Items.Count - 1
            End If
        End If

        UpdateAxisInfo()
    End Sub
    Private Sub btnSave_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnSave.Click
        Dim sFileName As String

        CommonDialog1Open.Filter = "Data File (*.mot)|*.mot|All Files (*.*)|*.*||"
        CommonDialog1Save.Filter = "Data File (*.mot)|*.mot|All Files (*.*)|*.*||"
        CommonDialog1Open.Title = "Save"
        CommonDialog1Save.Title = "Save"

        CommonDialog1Save.ShowDialog()
        CommonDialog1Open.FileName = CommonDialog1Save.FileName
        sFileName = CommonDialog1Open.FileName
        If sFileName <> "" Then
            If AxmMotSaveParaAll(sFileName) <> AXT_RT_SUCCESS Then
                lstLog.Items.Add(("File save fail!"))
                lstLog.SelectedIndex = lstLog.Items.Count - 1
            End If
        End If
    End Sub
    Private Sub btnMove_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnMove.Click
        Dim dPosition As Double
        Dim dVelocity As Double
        Dim dAccel As Double
        Dim dDecel As Double
        Dim lAxis(1) As Integer
        Dim dMPos(1) As Double
        Dim dMVel(1) As Double
        Dim dMAcc(1) As Double
        Dim dMDec(1) As Double

        dPosition = CDbl(edtPosition.Text)
        dVelocity = CDbl(edtVelocity.Text)
        dAccel = CDbl(edtAccel.Text)
        dDecel = CDbl(edtDecel.Text)

        SetGraphRange(m_lAxis, dVelocity)

        If (chkXYSyn.CheckState = True) Then
            lAxis(0) = AXIS_ODD(m_lAxis)
            lAxis(1) = AXIS_EVN(m_lAxis)

            dMPos(0) = dPosition : dMPos(1) = dPosition
            dMVel(0) = dVelocity : dMVel(1) = dVelocity
            dMAcc(0) = dAccel : dMAcc(1) = dAccel
            dMDec(0) = dDecel : dMDec(1) = dDecel

            AxmMoveStartMultiPos(2, lAxis(0), dMPos(0), dMVel(0), dMAcc(0), dMDec(0), 0)
        Else
            AxmMoveStartPos(m_lAxis, dPosition, dVelocity, dAccel, dDecel)
        End If

        AxmMotSetParaLoad(m_lAxis, dPosition, dVelocity, dAccel, dDecel)
    End Sub
    Private Sub btnVelOverride_Click()
        Dim dDistance As Double
        Dim dVelocity As Double
        Dim dAcceleration As Double
        Dim dDeceleration As Double

        dDistance = CDbl(edtPosition.Text)
        dVelocity = CDbl(edtVelocity.Text)
        dAcceleration = CDbl(edtAccel.Text)
        dDeceleration = CDbl(edtDecel.Text)

        ' Re-setup of the maximum value in chart for displaying running speed of each axis on the chart.
        If ((m_lAxis Mod 2) = 0) Then
            GraphX.MaxRange = dVelocity * 2 '+ (dVelocity * 2 * 0.2)
        Else
            GraphY.MaxRange = dVelocity * 2 '+ (dVelocity * 2 * 0.2)
        End If

        AxmOverrideVelAtPos(m_lAxis, dDistance, dVelocity, dAcceleration, dAcceleration, dVelocity * 2, dDistance / 2, 0)
    End Sub
    'UPGRADE_WARNING: 폼이 초기화될 때 cboPulseOutM.SelectedIndexChanged 이벤트가 발생합니다. 자세한 내용은 다음을 참조하십시오. 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
    Private Sub cboPulseOutM_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cboPulseOutM.SelectedIndexChanged
        AxmMotSetPulseOutMethod(m_lAxis, cboPulseOutM.SelectedIndex)
    End Sub
    'UPGRADE_WARNING: 폼이 초기화될 때 cboEncInputM.SelectedIndexChanged 이벤트가 발생합니다. 자세한 내용은 다음을 참조하십시오. 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
    Private Sub cboEncInputM_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cboEncInputM.SelectedIndexChanged
        AxmMotSetEncInputMethod(m_lAxis, cboEncInputM.SelectedIndex)
    End Sub
    Private Sub btnHomeAll_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnHomeAll.Click
        Dim lHmDir As Integer
        Dim lHmsig As Integer
        Dim dwZphas As Integer
        Dim dHClrTim As Double
        Dim dHOffset As Double
        Dim dwResult As Integer

        lHmsig = cboHomeSignal.SelectedIndex ' Setup a direction of Home searching.
        lHmDir = cboHomeDir.SelectedIndex ' Setup Home sensor.
        dwZphas = 0 ' Setup whether Z phase is searching or not.
        dHClrTim = 1000.0# ' Delay time of Position Clear after searching Home sensor.
        dHOffset = 0.0# ' Setup Offset movement value after searching Home sensor.

        If lHmsig > 1 Then
            lHmsig = lHmsig + 2
        End If

        SetGraphRange(AXIS_N04(m_lAxis, 0), 100)
        SetGraphRange(AXIS_N04(m_lAxis, 2), 100)

        dwResult = AxmHomeSetVel(AXIS_N04(m_lAxis, 0), 100, 50, 5, 1, 400, 100)
        If (dwResult = AXT_RT_SUCCESS) Then
            AxmHomeSetMethod(AXIS_N04(m_lAxis, 0), lHmDir, lHmsig, dwZphas, dHClrTim, dHOffset)
            AxmHomeSetStart(AXIS_N04(m_lAxis, 0))
            tmHome(0).Enabled = True
        End If

        dwResult = AxmHomeSetVel(AXIS_N04(m_lAxis, 1), 100, 50, 5, 1, 400, 100)
        If (dwResult = AXT_RT_SUCCESS) Then
            AxmHomeSetMethod(AXIS_N04(m_lAxis, 1), lHmDir, lHmsig, dwZphas, dHClrTim, dHOffset)
            AxmHomeSetStart(AXIS_N04(m_lAxis, 1))
            tmHome(1).Enabled = True
        End If

        dwResult = AxmHomeSetVel(AXIS_N04(m_lAxis, 2), 100, 50, 5, 1, 400, 100)
        If (dwResult = AXT_RT_SUCCESS) Then
            AxmHomeSetMethod(AXIS_N04(m_lAxis, 2), lHmDir, lHmsig, dwZphas, dHClrTim, dHOffset)
            AxmHomeSetStart(AXIS_N04(m_lAxis, 2))
            tmHome(2).Enabled = True
        End If

        dwResult = AxmHomeSetVel(AXIS_N04(m_lAxis, 3), 100, 50, 5, 1, 400, 100)
        If (dwResult = AXT_RT_SUCCESS) Then
            AxmHomeSetMethod(AXIS_N04(m_lAxis, 3), lHmDir, lHmsig, dwZphas, dHClrTim, dHOffset)
            AxmHomeSetStart(AXIS_N04(m_lAxis, 3))
            tmHome(3).Enabled = True
        End If
    End Sub
    Private Sub btnHomeSingle_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnHomeSingle.Click
        Dim dwZphas As Integer
        Dim dHClrTim As Double
        Dim dHOffset As Double

        Dim dVelFirst As Double
        Dim dVelSecond As Double
        Dim dVelThird As Double
        Dim dVelLast As Double

        Dim lHmsig As Integer
        Dim lHmDir As Integer

        dVelFirst = CDbl(edtHomeVelFirst.Text)
        dVelSecond = CDbl(edtHomeVelSecond.Text)
        dVelThird = CDbl(edtHomeVelThird.Text)
        dVelLast = CDbl(edtHomeVelLast.Text)

        dwZphas = 0 ' Setup whether Z phase is searching or not.
        dHClrTim = 1000.0# ' Delay time of Position Clear after searching Home sensor.
        dHOffset = 0.0# ' Setup Offset movement value after searching Home sensor.
        lHmsig = cboHomeSignal.SelectedIndex ' Setup Home sensor.
        lHmDir = cboHomeDir.SelectedIndex ' Setup a direction of Home searching.

        If lHmsig > 1 Then
            lHmsig = lHmsig + 2
        End If

        SetGraphRange(m_lAxis, dVelFirst)

        If cbGantrySlave.SelectedIndex Then
            AxmHomeSetVel(AXIS_EVN(m_lAxis), dVelFirst, dVelSecond, dVelThird, dVelLast, dVelFirst * 4, dVelSecond * 10)
            AxmHomeSetVel(AXIS_ODD(m_lAxis), dVelFirst, dVelSecond, dVelThird, dVelLast, dVelFirst * 4, dVelSecond * 10)

            AxmHomeSetMethod(AXIS_EVN(m_lAxis), lHmDir, lHmsig, dwZphas, dHClrTim, dHOffset)
            AxmHomeSetMethod(AXIS_ODD(m_lAxis), lHmDir, lHmsig, dwZphas, dHClrTim, dHOffset)

            AxmHomeSetStart(AXIS_EVN(m_lAxis))
            tmHome(AXIS_EVN(m_lAxis)).Enabled = True
        Else
            AxmHomeSetVel(m_lAxis, dVelFirst, dVelSecond, dVelThird, dVelLast, dVelFirst * 4, dVelSecond * 10)

            AxmHomeSetMethod(m_lAxis, lHmDir, lHmsig, dwZphas, dHClrTim, dHOffset)
            AxmHomeSetStart(m_lAxis)
            tmHome(AXIS_QUR(m_lAxis)).Enabled = True
        End If
    End Sub
    ' It is for the test of Home searching, about setup signal to be searched and searching direction and stop method after searching
    ' Start searching after read.  Print out the result on list box after finishing search.
    Private Sub btnSearch_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnsearch.Click
        Dim lAxis As Integer

        lAxis = AXIS_QUR(m_lAxis)
        If (tmTest(lAxis).Enabled = False) Then
            g_Search(lAxis).nAxis = m_lAxis
            g_Search(lAxis).nDir = cboDirection.SelectedIndex
            g_Search(lAxis).nSignal = cboDetect.SelectedIndex
            g_Search(lAxis).nStopM = cboStopM.SelectedIndex
            g_Search(lAxis).dVelocity = CDbl(edtVelocity.Text)
            g_Search(lAxis).dAccel = CDbl(edtAccel.Text)
            g_Search(lAxis).nRun = 1
            g_Search(lAxis).SearchSignal()
            g_nTest = 1
        Else
            lstLog.Items.Add(("Now moving."))
            lstLog.SelectedIndex = lstLog.Items.Count - 1
        End If
    End Sub
    ' Repeated running after reading running parameter from edit box.
    ' Create thread for repeated running.
    Private Sub btnRepeat_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnRepeat.Click
        Dim lAxis As Integer

        lAxis = AXIS_QUR(m_lAxis)
        If (tmTest(lAxis).Enabled = False) Then
            g_Repeat(lAxis).nAxis = m_lAxis
            g_Repeat(lAxis).dPosition = CDbl(edtPosition.Text)
            g_Repeat(lAxis).dVelocity = CDbl(edtVelocity.Text)
            g_Repeat(lAxis).dAccel = CDbl(edtAccel.Text)
            g_Repeat(lAxis).dDecel = CDbl(edtDecel.Text)
            g_Repeat(lAxis).nRun = 1
            g_nTest = 0
            g_Repeat(lAxis).StartRepeat()
        Else
            lstLog.Items.Add(("Now moving."))
            lstLog.SelectedIndex = lstLog.Items.Count - 1
        End If
    End Sub
    ' Setup distance rate and initial speed by pulse among those initial parameter.
    ' Change maximum speed to fit if setup distance rate by pulse.
    Private Sub btnSetting_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnSetting.Click
        Dim lPulse As Integer
        Dim dMoveUnit As Double
        Dim dStartStop As Double
        Dim dUnit As Double
        Dim dMinVelocity As Double

        lPulse = CDbl(edtPulse.Text)
        dMoveUnit = CDbl(edtUnit.Text)
        dStartStop = CDbl(edtStartSpeed.Text)

        AxmMotSetMoveUnitPerPulse(m_lAxis, dMoveUnit, lPulse)
        AxmMotSetMinVel(m_lAxis, dStartStop)
        AxmMotGetMoveUnitPerPulse(m_lAxis, dUnit, lPulse)
        AxmMotGetMinVel(m_lAxis, dMinVelocity)

        edtMoveUnit.Text = VB6.Format(dUnit / lPulse, "0.000000")
        edtUnit.Text = VB6.Format(dUnit, "0.000")
        edtPulse.Text = VB6.Format(lPulse)
        edtStartSpeed.Text = VB6.Format(dMinVelocity, "0.0000")
    End Sub
    Private Sub btnTrigOneShot_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnTrigOneShot.Click
        Dim pulse_width As Integer
        pulse_width = CInt(edtTrigPulseWidth.Text)

        ' It is the function that user outputting one trigger pulse by force.
        Call AxmTriggerSetTimeLevel(m_lAxis, pulse_width, HIGH, COMMAND_Renamed, ENABLE)
        Call AxmTriggerOneShot(m_lAxis)
    End Sub
    Private Sub btnTrigAbs_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnTrigAbs.Click
        Dim uErrorCode As Integer
        Dim trig_pos(1) As Double
        Dim pulse_width As Short

        trig_pos(0) = CDbl(edtTrigStartPosition.Text)
        pulse_width = CDbl(edtTrigPulseWidth.Text)

        AxmTriggerSetReset(m_lAxis)
        AxmTriggerSetTimeLevel(m_lAxis, pulse_width, HIGH, COMMAND_Renamed, ENABLE)

        uErrorCode = AxmTriggerOnlyAbs(m_lAxis, 1, trig_pos(0))
        If (uErrorCode = AXT_RT_SUCCESS) Then
            lstLog.Items.Add("Setting Trigger")
        Else
            lstLog.Items.Add("Not Setting Trigger")
        End If
        lstLog.SelectedIndex = lstLog.Items.Count - 1
    End Sub
    Private Sub btnTrigPeriod_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnTrigPeriod.Click
        Dim uErrorCode As Double
        Dim start_pos As Double
        Dim cycle As Double
        Dim end_pos As Double
        Dim pulse_width As Short

        start_pos = CDbl(edtTrigStartPosition.Text)
        cycle = CDbl(edtTrigCycle.Text)
        end_pos = CDbl(edtTrigEndPos.Text)
        pulse_width = CDbl(edtTrigPulseWidth.Text)

        AxmTriggerSetReset(m_lAxis)
        AxmTriggerSetTimeLevel(m_lAxis, pulse_width, HIGH, COMMAND_Renamed, ENABLE)

        uErrorCode = AxmTriggerSetBlock(m_lAxis, start_pos, end_pos, cycle)
        If (uErrorCode = AXT_RT_SUCCESS) Then
            lstLog.Items.Add("Setting Trigger")
        Else
            lstLog.Items.Add("Not Setting Trigger")
        End If
        lstLog.SelectedIndex = lstLog.Items.Count - 1
    End Sub
    Private Sub btnTrigReset_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnTrigReset.Click
        AxmTriggerSetReset(m_lAxis)
    End Sub
    Private Sub btnIntDisable_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnIntDisable.Click
        g_nIntCnt = 0 ' Interrupt count clear
        AxlInterruptDisable()
        AxmInterruptSetAxis(m_lAxis, AxtMsg.hWnd, 0, 0, 0)         ' Cancel interrupt method
        AxmInterruptSetAxisEnable(m_lAxis, 0) '             ' Interrupt DISABLE
    End Sub
    Private Sub btnIntMessage_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnIntMessage.Click
        Dim dwInterruptNum As Long

        g_nIntCnt = 0

        AxlInterruptEnable()
        AxmInterruptSetAxisEnable(m_lAxis, ENABLE)

        ' Setup whether interrupt is generated which user of the designated axis set.
        ' lBank : Possible to setup interrupt bank number (0 - 1).
        ' lInterruptNum : Setup interrupt
        AxmInterruptSetUserEnable(m_lAxis, 1, QIINTBANK2_29)           ' Input signal of limit signal (PELM, NELM).
        AxtMsg.Message1 = WM_AXL_INTERRUPT
        AxmInterruptSetAxis(m_lAxis, AxtMsg.hWnd, WM_AXL_INTERRUPT, 0, 0)

        AxmInterruptGetUserEnable(m_lAxis, 1, dwInterruptNum)
        lstLog.Items.Add("Limit Int Enable[1][0x" + Format(Hex(dwInterruptNum), "00000000") + "]")
    End Sub
    Private Sub cboAxisSet_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cboAxisSet.SelectedIndexChanged
        m_lAxis = cboAxisSet.SelectedIndex
        UpdateAxisInfo()
    End Sub
    ' Setup general output #0(Servo-On).  Output will go out if checked, Output will not go out if not checked.
    Private Sub LedOut0_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles LedOut0.Click
        Dim dwOnOff As Integer

        AxmSignalIsServoOn(m_lAxis, dwOnOff)
        If (dwOnOff) Then
            AxmSignalServoOn(m_lAxis, 0)
        Else
            AxmSignalServoOn(m_lAxis, 1)
        End If
    End Sub
    ' Setup general output #1(Alarm-Clear).
    Private Sub LedOut1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles LedOut1.Click
        Dim dwOutBit As Integer

        AxmSignalReadOutputBit(m_lAxis, 1, dwOutBit)
        If (dwOutBit) Then
            AxmSignalServoAlarmReset(m_lAxis, 0)
        Else
            AxmSignalServoAlarmReset(m_lAxis, 1)
        End If
    End Sub
    ' Setup general output #2.
    Private Sub LedOut2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles LedOut2.Click
        Dim dwOutBit As Integer

        AxmSignalReadOutputBit(m_lAxis, 2, dwOutBit)
        If (dwOutBit) Then
            AxmSignalWriteOutputBit(m_lAxis, 2, 0)
        Else
            AxmSignalWriteOutputBit(m_lAxis, 2, 1)
        End If
    End Sub
    ' Setup general output #3.
    Private Sub LedOut3_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles LedOut3.Click
        Dim dwOutBit As Integer

        AxmSignalReadOutputBit(m_lAxis, 3, dwOutBit)
        If (dwOutBit) Then
            AxmSignalWriteOutputBit(m_lAxis, 3, 0)
        Else
            AxmSignalWriteOutputBit(m_lAxis, 3, 1)
        End If
    End Sub
    ' Setup general output #4.
    Private Sub LedOut4_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles LedOut4.Click
        Dim dwOutBit As Integer

        AxmSignalReadOutputBit(m_lAxis, 4, dwOutBit)
        If (dwOutBit) Then
            AxmSignalWriteOutputBit(m_lAxis, 4, 0)
        Else
            AxmSignalWriteOutputBit(m_lAxis, 4, 1)
        End If
    End Sub
    ' Setup general output #5.
    Private Sub LedOut5_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles LedOut5.Click
        Dim dwOutBit As Integer

        AxmSignalReadOutputBit(m_lAxis, 5, dwOutBit)
        If (dwOutBit) Then
            AxmSignalWriteOutputBit(m_lAxis, 5, 0)
        Else
            AxmSignalWriteOutputBit(m_lAxis, 5, 1)
        End If
    End Sub
    Private Sub lstLog_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lstLog.DoubleClick
        lstLog.Items.Clear()
    End Sub
    Private Sub tmDisplay_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles tmDisplay.Tick
        Dim dCmdPos(3) As Double
        Dim dActPos(3) As Double
        Dim wReadInput, wReadOuput As Integer
        Dim wMechanicalStatus As Integer
        Dim wReadInterpolationQueueFree, wIsContMotion As Integer
        Dim wBusyStatus As Integer

        Dim wReadHome As Integer
        Dim lNodeNum1 As Integer
        Dim lTotalNodeNum1 As Integer


        AxmStatusGetCmdPos(AXIS_N04(m_lAxis, 0), dCmdPos(0))
        AxmStatusGetActPos(AXIS_N04(m_lAxis, 0), dActPos(0))

        AxmStatusGetCmdPos(AXIS_N04(m_lAxis, 1), dCmdPos(1))
        AxmStatusGetActPos(AXIS_N04(m_lAxis, 1), dActPos(1))

        AxmStatusGetCmdPos(AXIS_N04(m_lAxis, 2), dCmdPos(2))
        AxmStatusGetActPos(AXIS_N04(m_lAxis, 2), dActPos(2))

        AxmStatusGetCmdPos(AXIS_N04(m_lAxis, 3), dCmdPos(3))
        AxmStatusGetActPos(AXIS_N04(m_lAxis, 3), dActPos(3))

        edtCmdPosX.Text = VB6.Format(dCmdPos(0), "0.000")
        edtCmdPosY.Text = VB6.Format(dCmdPos(1), "0.000")

        edtActPosX.Text = VB6.Format(dActPos(0), "0.000")
        edtActPosY.Text = VB6.Format(dActPos(1), "0.000")

        edtCmdPosZ.Text = VB6.Format(dCmdPos(2), "0.000")
        edtCmdPosU.Text = VB6.Format(dCmdPos(3), "0.000")

        edtActPosZ.Text = VB6.Format(dActPos(2), "0.000")
        edtActPosU.Text = VB6.Format(dActPos(3), "0.000")

        AxmSignalReadInput(m_lAxis, wReadInput)
        AxmSignalReadOutput(m_lAxis, wReadOuput)
        AxmStatusReadMechanical(m_lAxis, wMechanicalStatus)

        ' General output
        LedOut0.BackColor = System.Drawing.ColorTranslator.FromOle(LED_RED((wReadOuput And &H1S) = &H1S))
        LedOut1.BackColor = System.Drawing.ColorTranslator.FromOle(LED_RED((wReadOuput And &H2S) = &H2S))
        LedOut2.BackColor = System.Drawing.ColorTranslator.FromOle(LED_RED((wReadOuput And &H4S) = &H4S))
        LedOut3.BackColor = System.Drawing.ColorTranslator.FromOle(LED_RED((wReadOuput And &H8S) = &H8S))
        LedOut4.BackColor = System.Drawing.ColorTranslator.FromOle(LED_RED((wReadOuput And &H10S) = &H10S))
        '	LedOut5.BackColor = System.Drawing.ColorTranslator.FromOle(LED_RED((wReadOuput And &H20s) = &H20s))

        AxmHomeReadSignal(m_lAxis, wReadHome)
        LedHome.BackColor = System.Drawing.ColorTranslator.FromOle(LED_RED(wReadHome = 1))

        ' General input
        LedIn0.BackColor = System.Drawing.ColorTranslator.FromOle(LED_RED(wReadHome = 1))
        LedIn1.BackColor = System.Drawing.ColorTranslator.FromOle(LED_RED((wReadInput And &H2S) = &H2S))
        LedIn2.BackColor = System.Drawing.ColorTranslator.FromOle(LED_RED((wReadInput And &H4S) = &H4S))
        LedIn3.BackColor = System.Drawing.ColorTranslator.FromOle(LED_RED((wReadInput And &H8S) = &H8S))
        LedIn4.BackColor = System.Drawing.ColorTranslator.FromOle(LED_RED((wReadInput And &H10S) = &H10S))
        '	LedIn5.BackColor = System.Drawing.ColorTranslator.FromOle(LED_RED((wReadInput And &H20s) = &H20s))

        ' Hardware signal
        LedPElm.BackColor = System.Drawing.ColorTranslator.FromOle(LED_RED((wMechanicalStatus And &H1S) = &H1S))
        LedNElm.BackColor = System.Drawing.ColorTranslator.FromOle(LED_RED((wMechanicalStatus And &H2S) = &H2S))
        LedAlarm.BackColor = System.Drawing.ColorTranslator.FromOle(LED_RED((wMechanicalStatus And &H10S) = &H10S))
        LedInp.BackColor = System.Drawing.ColorTranslator.FromOle(LED_RED((wMechanicalStatus And &H20S) = &H20S))
        LedEmg.BackColor = System.Drawing.ColorTranslator.FromOle(LED_RED((wMechanicalStatus And &H40S) = &H40S))
        LedZPhase.BackColor = System.Drawing.ColorTranslator.FromOle(LED_RED((wMechanicalStatus And &H100S) = &H100S))
        LedEXPP.BackColor = System.Drawing.ColorTranslator.FromOle(LED_RED((wMechanicalStatus And &H400S) = &H400S))
        LedEXMP.BackColor = System.Drawing.ColorTranslator.FromOle(LED_RED((wMechanicalStatus And &H800S) = &H800S))

        AxmStatusReadInMotion(AXIS_EVN(m_lAxis), wBusyStatus)
        LedBusyx.BackColor = System.Drawing.ColorTranslator.FromOle(LED_YELLOW(wBusyStatus = 1))

        AxmStatusReadInMotion(AXIS_ODD(m_lAxis), wBusyStatus)
        LedBusyy.BackColor = System.Drawing.ColorTranslator.FromOle(LED_YELLOW(wBusyStatus = 1))

        AxmContiReadFree(COORD_NO, wReadInterpolationQueueFree)
        ' A function which checks running of serial interpolation
        AxmContiIsMotion(COORD_NO, wIsContMotion)
        ' A function which reads current index value in interpolation queue
        AxmContiGetNodeNum(COORD_NO, lNodeNum1)
        AxmContiGetTotalNodeNum(COORD_NO, lTotalNodeNum1)

        edtTotalNum.Text = VB6.Format(lTotalNodeNum1)
        edtContiNum.Text = VB6.Format(lNodeNum1)
        edtInMotion.Text = VB6.Format(wIsContMotion)
        edtQFree.Text = VB6.Format(wReadInterpolationQueueFree)
        edtIntCount.Text = VB6.Format(g_nIntCnt)
    End Sub
    Private Sub tmGraph_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles tmGraph.Tick
        Dim dX1 As Double
        Dim dY1 As Double
        Dim dCurVelX(1) As Double
        Dim dCurVelY(1) As Double

        AxmStatusGetCmdPos(AXIS_EVN(m_lAxis), dX1)
        AxmStatusGetCmdPos(AXIS_ODD(m_lAxis), dY1)

        AxmStatusReadVel(AXIS_N04(m_lAxis, 0), dCurVelX(0))
        AxmStatusReadVel(AXIS_N04(m_lAxis, 1), dCurVelX(1))
        AxmStatusReadVel(AXIS_N04(m_lAxis, 2), dCurVelY(0))
        AxmStatusReadVel(AXIS_N04(m_lAxis, 3), dCurVelY(1))

        edtCmdVelX.Text = VB6.Format(dCurVelX(0), "0.000")
        edtCmdVelY.Text = VB6.Format(dCurVelX(1), "0.000")
        edtCmdVelZ.Text = VB6.Format(dCurVelY(0), "0.000")
        edtCmdVelU.Text = VB6.Format(dCurVelY(1), "0.000")

        XYPlot.AppendPoint(dX1, dY1)

        If (dCurVelX(0) > 0 Or dCurVelX(1) > 0) Then
            GraphX.AppendPoints(dCurVelX(0), dCurVelX(1))
        End If

        If (dCurVelY(0) > 0 Or dCurVelY(1) > 0) Then
            GraphY.AppendPoints(dCurVelY(0), dCurVelY(1))
        End If

    End Sub
    Private Sub tmHome_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles tmHome.Tick
        Dim Index As Short = tmHome.GetIndex(eventSender)

        Dim nTimeNo As Short
        Dim wHomeResult As Integer

        nTimeNo = Index
        AxmHomeGetResult(AXIS_N04(m_lAxis, CInt(nTimeNo)), wHomeResult)
        If (wHomeResult <> HOME_SEARCHING) Then
            tmHome(nTimeNo).Enabled = False
            If (wHomeResult = HOME_SUCCESS) Then
                MsgBox("Home Search " & VB6.Format(nTimeNo + 1) & " Success")
            Else
                MsgBox("Home Search " & VB6.Format(nTimeNo + 1) & "Fail[0x" & VB6.Format(Hex(wHomeResult)) & "]")
            End If
        End If
    End Sub
    Public Sub SetGraphRange(ByRef lAxis As Integer, ByRef dVelocity As Double)
        If (dVelocity > 0) Then
            ' Re-setup of the maximum value in chart for displaying running speed of each axis on the chart.
            If (AXIS_QUR(lAxis) < 2) Then
                GraphX.SetRanges(0, dVelocity + (dVelocity * 0.2))
            Else
                GraphY.SetRanges(0, dVelocity + (dVelocity * 0.2))
            End If
        End If
    End Sub
    Private Sub tmTest_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles tmTest.Tick
        Dim Index As Short = tmTest.GetIndex(eventSender)
        If g_nTest = 0 Then
            g_Repeat(Index).StartRepeatLoop()
        ElseIf g_nTest = 1 Then
            g_Search(Index).SearchSignalLoop()
        End If
    End Sub
    Private Sub AxtMsg_OnMessage1(ByVal sender As System.Object, ByVal e As AxAXTMESSENGERLib._DAxtMessengerEvents_OnMessage1Event) Handles AxtMsg.OnMessage1
        Dim nBoard As Integer
        Dim lAxisNo As Long
        Dim nIntrFlag As Integer
        Dim IntBank0, IntBank1 As Long

        nBoard = e.wParam / 256       ' Interrupt generation board number.
        lAxisNo = CByte(e.wParam)     ' Interrupt generation axis number.
        nIntrFlag = CInt(e.lParam)    ' Interrupt generation axis location.

        AxmInterruptReadAxisFlag(lAxisNo, 0, IntBank0)
        AxmInterruptReadAxisFlag(lAxisNo, 1, IntBank1)

        g_nIntCnt = g_nIntCnt + 1
        lstLog.Items.Add("Msg[" + Format(g_nIntCnt) + "]Axis[" + Format(lAxisNo) + "]Flag[0x" + Format(nIntrFlag) + "]")

    End Sub

    Private Sub chkGantry_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkGantry.CheckedChanged

    End Sub
End Class