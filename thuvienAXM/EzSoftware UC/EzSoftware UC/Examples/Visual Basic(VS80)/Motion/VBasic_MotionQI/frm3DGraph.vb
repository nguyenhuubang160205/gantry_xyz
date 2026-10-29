Option Strict Off
Option Explicit On
Friend Class frm3DGraph
	Inherits System.Windows.Forms.Form
	Dim m_aAxis(3) As Integer
	Dim m_SliderRange As Integer
	
	Private Sub btnSetRange_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnSetRange.Click
		Dim dVRangeX As Double
		Dim dVRangeY As Double
		Dim dVRangeZ As Double
		
		dVRangeX = CDbl(TextRangeX.Text)
		dVRangeY = CDbl(TextRangeY.Text)
		dVRangeZ = CDbl(TextRangeZ.Text)
		
        AxtGraph3D.SetRangeX = dVRangeX
        AxtGraph3D.SetRangeY = dVRangeY
        AxtGraph3D.SetRangeZ = dVRangeZ
	End Sub
    Private Sub cboAxisReset_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cboAxisReset.SelectedIndexChanged
        Dim lIndex As Integer
        lIndex = cboAxisReset.SelectedIndex
        Select Case lIndex
            Case 0
                AxtGraph3D.SetRangeX = 2500
                AxtGraph3D.SetRangeY = 2500

            Case 1
                AxtGraph3D.SetRangeY = 2500
                AxtGraph3D.SetRangeZ = 2500

            Case 2
                AxtGraph3D.SetRangeX = 2500
                AxtGraph3D.SetRangeZ = 2500

            Case 3
                AxtGraph3D.SetRange3Axis(2500, 2500, 2500)
        End Select
    End Sub
    Private Sub cboDimension_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cboDimension.SelectedIndexChanged
        Dim lIndex As Integer
        lIndex = cboDimension.SelectedIndex
        Select Case lIndex
            Case 0
                AxtGraph3D.SetDimensionXY()
            Case 1
                AxtGraph3D.SetDimensionYZ()
            Case 2
                AxtGraph3D.SetDimensionXZ()
            Case 3
                AxtGraph3D.SetDimensionXYZ()
        End Select
    End Sub
    Private Sub chkBoxEnable_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkBoxEnable.CheckStateChanged
        If (chkBoxEnable.CheckState = 1) Then
            AxtGraph3D.SetBoxEnable = True
        Else
            AxtGraph3D.SetBoxEnable = False
        End If
    End Sub
	
	Private Sub frm3DGraph_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		cboAxisReset.SelectedIndex = 3
		cboDimension.SelectedIndex = 3
		chkBoxEnable.CheckState = System.Windows.Forms.CheckState.Checked
        AxtGraph3D.SetRange3Axis(2500, 2500, 2500)
	End Sub
    Private Sub btnclose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnClose.Click
        Dim OK As Integer
        OK = False
        Me.Close()
    End Sub
	Public Sub UpdateAxis(ByRef lAxis As Integer)
		m_aAxis(0) = AXIS_N04(lAxis, 0)
		m_aAxis(1) = AXIS_N04(lAxis, 1)
		m_aAxis(2) = AXIS_N04(lAxis, 2)
		m_aAxis(3) = AXIS_N04(lAxis, 3)
	End Sub
	Private Sub btnHelical_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnHelical.Click
		Dim dVelocity As Double
		Dim dAccel As Double
		
		dVelocity = 2000
		dAccel = 4000
		
		AxmContiWriteClear(COORDINATE)
		AxmContiSetAxisMap(COORDINATE, 4, m_aAxis(0))
		AxmContiSetAbsRelMode(COORDINATE, POS_REL_MODE)
		
		AxmContiBeginNode(COORDINATE)
		AxmHelixCenterMove(COORDINATE, 500, 500, 0, 0, 100, dVelocity, dAccel, dAccel, DIR_CW)
		AxmHelixCenterMove(COORDINATE, 500, 500, 0, 0, 100, dVelocity, dAccel, dAccel, DIR_CW)
		AxmHelixCenterMove(COORDINATE, 500, 500, 0, 0, 100, dVelocity, dAccel, dAccel, DIR_CW)
		AxmHelixCenterMove(COORDINATE, 500, 500, 0, 0, 100, dVelocity, dAccel, dAccel, DIR_CW)
		AxmHelixCenterMove(COORDINATE, 500, 500, 0, 0, 100, dVelocity, dAccel, dAccel, DIR_CW)
		AxmHelixCenterMove(COORDINATE, 500, 500, 0, 0, 100, dVelocity, dAccel, dAccel, DIR_CW)
		AxmHelixCenterMove(COORDINATE, 500, 500, 0, 0, 100, dVelocity, dAccel, dAccel, DIR_CW)
		AxmHelixCenterMove(COORDINATE, 500, 500, 0, 0, 100, dVelocity, dAccel, dAccel, DIR_CW)
		AxmHelixCenterMove(COORDINATE, 500, 500, 0, 0, 100, dVelocity, dAccel, dAccel, DIR_CW)
		AxmHelixCenterMove(COORDINATE, 500, 500, 0, 0, 100, dVelocity, dAccel, dAccel, DIR_CW)
		AxmHelixCenterMove(COORDINATE, 500, 500, 0, 0, 100, dVelocity, dAccel, dAccel, DIR_CW)
		AxmHelixCenterMove(COORDINATE, 500, 500, 0, 0, 100, dVelocity, dAccel, dAccel, DIR_CW)
		AxmHelixCenterMove(COORDINATE, 500, 500, 0, 0, 100, dVelocity, dAccel, dAccel, DIR_CW)
		AxmContiEndNode(COORDINATE)
	End Sub
	Private Sub btnHelicalPlay_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnHelicalPlay.Click
		AxmContiStart(COORDINATE, 0, 0)
	End Sub
	Private Sub btnSpline_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnSpline.Click
		Dim dVelocity As Double
		Dim dAccel As Double
		Dim dPosX(4) As Double
		Dim dPosY(4) As Double
		Dim dPosZ(4) As Double
		
		dVelocity = 2000
		dAccel = 4000
		
		AxmContiWriteClear(COORDINATE)
		AxmContiSetAxisMap(COORDINATE, 3, m_aAxis(0))
		AxmContiSetAbsRelMode(COORDINATE, POS_ABS_MODE)
		
		dPosX(0) = 0 : dPosY(0) = 0
		dPosX(1) = 450 : dPosY(1) = 100
		dPosX(2) = 750 : dPosY(2) = 450
		dPosX(3) = 1080 : dPosY(3) = 750
		dPosX(4) = 1300 : dPosY(4) = 700
		
		AxmContiBeginNode(COORDINATE)
		AxmSplineWrite(COORDINATE, 5, dPosX(0), dPosY(0), dVelocity, dAccel, dAccel, 1, 100)
		AxmContiEndNode(COORDINATE)
	End Sub
	Private Sub btnSplinePlay_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnSplinePlay.Click
        Dim lCoodinate As Integer
        AxmContiStart(lCoodinate, 0, 0)
	End Sub
    Private Sub btnClear_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnClear.Click
        AxmStatusSetActPos(0, 0.0#)
        AxmStatusSetActPos(1, 0.0#)
        AxmStatusSetCmdPos(2, 0.0#)
        AxmStatusSetCmdPos(3, 0.0#)

        AxmStatusSetActPos(0, 0.0#)
        AxmStatusSetActPos(1, 0.0#)
        AxmStatusSetCmdPos(2, 0.0#)
        AxmStatusSetCmdPos(3, 0.0#)

        AxmContiWriteClear(COORDINATE)
        AxtGraph3D.Clear()
    End Sub
    Private Sub Timer1_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Timer1.Tick
        Dim dCmdX, dCmdY As Double
        Dim dCmdZ As Double
        Dim dVelX, dVelY As Double
        Dim dVelZ As Double

        AxmStatusReadVel(m_aAxis(0), dVelX)
        AxmStatusReadVel(m_aAxis(1), dVelY)
        AxmStatusReadVel(m_aAxis(2), dVelZ)
        If (dVelX >= 0.0# Or dVelY >= 0.0# Or dVelZ >= 0.0#) Then
            AxmStatusGetCmdPos(m_aAxis(0), dCmdX)
            AxmStatusGetCmdPos(m_aAxis(1), dCmdY)
            AxmStatusGetCmdPos(m_aAxis(2), dCmdZ)

            lblCmdPosX.Text = VB6.Format(dCmdX, "0.000")
            lblCmdPosY.Text = VB6.Format(dCmdY, "0.000")
            lblCmdPosZ.Text = VB6.Format(dCmdZ, "0.000")

            AxtGraph3D.AddPoint(dCmdX, dCmdY, dCmdZ)
        End If
    End Sub
End Class