<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MoveSignalCapture
    Inherits System.Windows.Forms.Form

    'Form은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows Form 디자이너에 필요합니다.
    Private components As System.ComponentModel.IContainer

    '참고: 다음 프로시저는 Windows Form 디자이너에 필요합니다.
    '수정하려면 Windows Form 디자이너를 사용하십시오.  
    '코드 편집기를 사용하여 수정하지 마십시오.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.btnLoadFile = New System.Windows.Forms.Button()
        Me.cboSelAxis = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkServoOn = New System.Windows.Forms.CheckBox()
        Me.btnPosClear = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.stcCmdVel = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.stcActPos = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.stcCmdPos = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnJogMoveN = New System.Windows.Forms.Button()
        Me.btnJogMoveP = New System.Windows.Forms.Button()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.edtJogDec = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.edtJogAcc = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.edtJogVel = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnGetPos = New System.Windows.Forms.Button()
        Me.stcCapturePos = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.cboStopMethod = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cboCaptureTarget = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cboSignalEdge = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cboDetectSig = New System.Windows.Forms.ComboBox()
        Me.btnMoveStop = New System.Windows.Forms.Button()
        Me.btnCaptureMove = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.edtMoveAcc = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.edtMoveVel = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.m_timer = New System.Windows.Forms.Timer(Me.components)
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnLoadFile
        '
        Me.btnLoadFile.Location = New System.Drawing.Point(344, 16)
        Me.btnLoadFile.Name = "btnLoadFile"
        Me.btnLoadFile.Size = New System.Drawing.Size(113, 22)
        Me.btnLoadFile.TabIndex = 15
        Me.btnLoadFile.Text = "Load File"
        Me.btnLoadFile.UseVisualStyleBackColor = True
        '
        'cboSelAxis
        '
        Me.cboSelAxis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSelAxis.FormattingEnabled = True
        Me.cboSelAxis.Location = New System.Drawing.Point(147, 17)
        Me.cboSelAxis.Name = "cboSelAxis"
        Me.cboSelAxis.Size = New System.Drawing.Size(192, 20)
        Me.cboSelAxis.TabIndex = 14
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(21, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(121, 12)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Select Axis No       :"
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Location = New System.Drawing.Point(12, 13)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(455, 27)
        Me.PictureBox1.TabIndex = 16
        Me.PictureBox1.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkServoOn)
        Me.GroupBox1.Controls.Add(Me.btnPosClear)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.stcCmdVel)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.stcActPos)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.stcCmdPos)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 49)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(455, 99)
        Me.GroupBox1.TabIndex = 18
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Position Monitor"
        '
        'chkServoOn
        '
        Me.chkServoOn.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkServoOn.Location = New System.Drawing.Point(336, 68)
        Me.chkServoOn.Name = "chkServoOn"
        Me.chkServoOn.Size = New System.Drawing.Size(109, 24)
        Me.chkServoOn.TabIndex = 3
        Me.chkServoOn.Text = "Servo On"
        Me.chkServoOn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkServoOn.UseVisualStyleBackColor = True
        '
        'btnPosClear
        '
        Me.btnPosClear.Location = New System.Drawing.Point(336, 15)
        Me.btnPosClear.Name = "btnPosClear"
        Me.btnPosClear.Size = New System.Drawing.Size(109, 44)
        Me.btnPosClear.TabIndex = 2
        Me.btnPosClear.Text = "Position Clear"
        Me.btnPosClear.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(262, 74)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(54, 12)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Unit/Sec"
        '
        'stcCmdVel
        '
        Me.stcCmdVel.Location = New System.Drawing.Point(135, 69)
        Me.stcCmdVel.Name = "stcCmdVel"
        Me.stcCmdVel.ReadOnly = True
        Me.stcCmdVel.Size = New System.Drawing.Size(122, 21)
        Me.stcCmdVel.TabIndex = 23
        Me.stcCmdVel.Text = "0.000"
        Me.stcCmdVel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(9, 74)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(121, 12)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Command Velocity :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(262, 47)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(26, 12)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Unit"
        '
        'stcActPos
        '
        Me.stcActPos.Location = New System.Drawing.Point(135, 42)
        Me.stcActPos.Name = "stcActPos"
        Me.stcActPos.ReadOnly = True
        Me.stcActPos.Size = New System.Drawing.Size(122, 21)
        Me.stcActPos.TabIndex = 22
        Me.stcActPos.Text = "0.000"
        Me.stcActPos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(9, 47)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(121, 12)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Feedback Position  :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(262, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(26, 12)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Unit"
        '
        'stcCmdPos
        '
        Me.stcCmdPos.Location = New System.Drawing.Point(135, 15)
        Me.stcCmdPos.Name = "stcCmdPos"
        Me.stcCmdPos.ReadOnly = True
        Me.stcCmdPos.Size = New System.Drawing.Size(122, 21)
        Me.stcCmdPos.TabIndex = 21
        Me.stcCmdPos.Text = "0.000"
        Me.stcCmdPos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(121, 12)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Command Position :"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnJogMoveN)
        Me.GroupBox3.Controls.Add(Me.btnJogMoveP)
        Me.GroupBox3.Controls.Add(Me.Label23)
        Me.GroupBox3.Controls.Add(Me.edtJogDec)
        Me.GroupBox3.Controls.Add(Me.Label24)
        Me.GroupBox3.Controls.Add(Me.Label21)
        Me.GroupBox3.Controls.Add(Me.edtJogAcc)
        Me.GroupBox3.Controls.Add(Me.Label22)
        Me.GroupBox3.Controls.Add(Me.Label19)
        Me.GroupBox3.Controls.Add(Me.edtJogVel)
        Me.GroupBox3.Controls.Add(Me.Label20)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 157)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(455, 107)
        Me.GroupBox3.TabIndex = 20
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "< Jog(Velocity) Move >"
        '
        'btnJogMoveN
        '
        Me.btnJogMoveN.Location = New System.Drawing.Point(336, 59)
        Me.btnJogMoveN.Name = "btnJogMoveN"
        Me.btnJogMoveN.Size = New System.Drawing.Size(109, 35)
        Me.btnJogMoveN.TabIndex = 20
        Me.btnJogMoveN.Text = "Jog Move(-)"
        Me.btnJogMoveN.UseVisualStyleBackColor = True
        '
        'btnJogMoveP
        '
        Me.btnJogMoveP.Location = New System.Drawing.Point(336, 20)
        Me.btnJogMoveP.Name = "btnJogMoveP"
        Me.btnJogMoveP.Size = New System.Drawing.Size(109, 32)
        Me.btnJogMoveP.TabIndex = 19
        Me.btnJogMoveP.Text = "Jog Move(+)"
        Me.btnJogMoveP.UseVisualStyleBackColor = True
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(262, 79)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(66, 12)
        Me.Label23.TabIndex = 35
        Me.Label23.Text = "Unit/Sec^2"
        '
        'edtJogDec
        '
        Me.edtJogDec.Location = New System.Drawing.Point(135, 74)
        Me.edtJogDec.Name = "edtJogDec"
        Me.edtJogDec.Size = New System.Drawing.Size(122, 21)
        Me.edtJogDec.TabIndex = 18
        Me.edtJogDec.Text = "400.0"
        Me.edtJogDec.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(9, 79)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(123, 12)
        Me.Label24.TabIndex = 33
        Me.Label24.Text = "Jog Deceleration     :"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(262, 52)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(66, 12)
        Me.Label21.TabIndex = 32
        Me.Label21.Text = "Unit/Sec^2"
        '
        'edtJogAcc
        '
        Me.edtJogAcc.Location = New System.Drawing.Point(135, 47)
        Me.edtJogAcc.Name = "edtJogAcc"
        Me.edtJogAcc.Size = New System.Drawing.Size(122, 21)
        Me.edtJogAcc.TabIndex = 17
        Me.edtJogAcc.Text = "400.0"
        Me.edtJogAcc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(9, 52)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(123, 12)
        Me.Label22.TabIndex = 30
        Me.Label22.Text = "Jog Acceleration     :"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(262, 25)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(54, 12)
        Me.Label19.TabIndex = 29
        Me.Label19.Text = "Unit/Sec"
        '
        'edtJogVel
        '
        Me.edtJogVel.Location = New System.Drawing.Point(135, 20)
        Me.edtJogVel.Name = "edtJogVel"
        Me.edtJogVel.Size = New System.Drawing.Size(122, 21)
        Me.edtJogVel.TabIndex = 16
        Me.edtJogVel.Text = "100.0"
        Me.edtJogVel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(9, 25)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(122, 12)
        Me.Label20.TabIndex = 27
        Me.Label20.Text = "Jog Velocity           :"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnGetPos)
        Me.GroupBox2.Controls.Add(Me.stcCapturePos)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.PictureBox2)
        Me.GroupBox2.Controls.Add(Me.cboStopMethod)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.cboCaptureTarget)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.cboSignalEdge)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.cboDetectSig)
        Me.GroupBox2.Controls.Add(Me.btnMoveStop)
        Me.GroupBox2.Controls.Add(Me.btnCaptureMove)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.edtMoveAcc)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.edtMoveVel)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 273)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(455, 228)
        Me.GroupBox2.TabIndex = 21
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = " < Signal Capture Move >"
        '
        'btnGetPos
        '
        Me.btnGetPos.Location = New System.Drawing.Point(336, 191)
        Me.btnGetPos.Name = "btnGetPos"
        Me.btnGetPos.Size = New System.Drawing.Size(109, 21)
        Me.btnGetPos.TabIndex = 44
        Me.btnGetPos.Text = "Get Position"
        Me.btnGetPos.UseVisualStyleBackColor = True
        '
        'stcCapturePos
        '
        Me.stcCapturePos.Enabled = False
        Me.stcCapturePos.Location = New System.Drawing.Point(135, 191)
        Me.stcCapturePos.Name = "stcCapturePos"
        Me.stcCapturePos.Size = New System.Drawing.Size(193, 21)
        Me.stcCapturePos.TabIndex = 43
        Me.stcCapturePos.Text = "xxx.xxx"
        Me.stcCapturePos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(9, 197)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(126, 12)
        Me.Label16.TabIndex = 42
        Me.Label16.Text = "Capture Position      :"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.PictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox2.Location = New System.Drawing.Point(11, 182)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(434, 3)
        Me.PictureBox2.TabIndex = 41
        Me.PictureBox2.TabStop = False
        '
        'cboStopMethod
        '
        Me.cboStopMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStopMethod.FormattingEnabled = True
        Me.cboStopMethod.Items.AddRange(New Object() {"00: EMERGENCY_STOP", "01: SLOWDOWN_STOP"})
        Me.cboStopMethod.Location = New System.Drawing.Point(135, 152)
        Me.cboStopMethod.Name = "cboStopMethod"
        Me.cboStopMethod.Size = New System.Drawing.Size(192, 20)
        Me.cboStopMethod.TabIndex = 40
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(9, 157)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(124, 12)
        Me.Label15.TabIndex = 39
        Me.Label15.Text = "Stop Method           :"
        '
        'cboCaptureTarget
        '
        Me.cboCaptureTarget.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCaptureTarget.FormattingEnabled = True
        Me.cboCaptureTarget.Items.AddRange(New Object() {"00: COMMAND", "01: ACTUAL"})
        Me.cboCaptureTarget.Location = New System.Drawing.Point(135, 126)
        Me.cboCaptureTarget.Name = "cboCaptureTarget"
        Me.cboCaptureTarget.Size = New System.Drawing.Size(192, 20)
        Me.cboCaptureTarget.TabIndex = 38
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(9, 131)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(125, 12)
        Me.Label14.TabIndex = 37
        Me.Label14.Text = "Capture Target        :"
        '
        'cboSignalEdge
        '
        Me.cboSignalEdge.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSignalEdge.FormattingEnabled = True
        Me.cboSignalEdge.Items.AddRange(New Object() {"00: SIGNAL_DOWN_EDGE", "01: SIGNAL_UP_EDGE"})
        Me.cboSignalEdge.Location = New System.Drawing.Point(135, 100)
        Me.cboSignalEdge.Name = "cboSignalEdge"
        Me.cboSignalEdge.Size = New System.Drawing.Size(192, 20)
        Me.cboSignalEdge.TabIndex = 36
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(9, 105)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(125, 12)
        Me.Label8.TabIndex = 35
        Me.Label8.Text = "Signal Edge            :"
        '
        'cboDetectSig
        '
        Me.cboDetectSig.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDetectSig.FormattingEnabled = True
        Me.cboDetectSig.Items.AddRange(New Object() {"00: PosEndLimit", "01: NegEndLimit", "04: HomeSensor", "05: EncodZPhase", "06: UniInput02", "07: UniInput03"})
        Me.cboDetectSig.Location = New System.Drawing.Point(135, 74)
        Me.cboDetectSig.Name = "cboDetectSig"
        Me.cboDetectSig.Size = New System.Drawing.Size(192, 20)
        Me.cboDetectSig.TabIndex = 34
        '
        'btnMoveStop
        '
        Me.btnMoveStop.Location = New System.Drawing.Point(336, 99)
        Me.btnMoveStop.Name = "btnMoveStop"
        Me.btnMoveStop.Size = New System.Drawing.Size(109, 73)
        Me.btnMoveStop.TabIndex = 20
        Me.btnMoveStop.Text = "Move Stop"
        Me.btnMoveStop.UseVisualStyleBackColor = True
        '
        'btnCaptureMove
        '
        Me.btnCaptureMove.Location = New System.Drawing.Point(336, 20)
        Me.btnCaptureMove.Name = "btnCaptureMove"
        Me.btnCaptureMove.Size = New System.Drawing.Size(109, 73)
        Me.btnCaptureMove.TabIndex = 19
        Me.btnCaptureMove.Text = "Capture Move"
        Me.btnCaptureMove.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(9, 79)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(127, 12)
        Me.Label9.TabIndex = 33
        Me.Label9.Text = "Detect Signal           :"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(262, 52)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(66, 12)
        Me.Label10.TabIndex = 32
        Me.Label10.Text = "Unit/Sec^2"
        '
        'edtMoveAcc
        '
        Me.edtMoveAcc.Location = New System.Drawing.Point(135, 47)
        Me.edtMoveAcc.Name = "edtMoveAcc"
        Me.edtMoveAcc.Size = New System.Drawing.Size(122, 21)
        Me.edtMoveAcc.TabIndex = 17
        Me.edtMoveAcc.Text = "400.0"
        Me.edtMoveAcc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(9, 52)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(126, 12)
        Me.Label11.TabIndex = 30
        Me.Label11.Text = "Move Acceleration   :"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(262, 25)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(54, 12)
        Me.Label12.TabIndex = 29
        Me.Label12.Text = "Unit/Sec"
        '
        'edtMoveVel
        '
        Me.edtMoveVel.Location = New System.Drawing.Point(135, 20)
        Me.edtMoveVel.Name = "edtMoveVel"
        Me.edtMoveVel.Size = New System.Drawing.Size(122, 21)
        Me.edtMoveVel.TabIndex = 16
        Me.edtMoveVel.Text = "100.0"
        Me.edtMoveVel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(9, 25)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(125, 12)
        Me.Label13.TabIndex = 27
        Me.Label13.Text = "Move Velocity         :"
        '
        'm_timer
        '
        Me.m_timer.Enabled = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'MoveSignalCapture
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(479, 510)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnLoadFile)
        Me.Controls.Add(Me.cboSelAxis)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MoveSignalCapture"
        Me.Text = "MoveSignalCapture"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnLoadFile As System.Windows.Forms.Button
    Friend WithEvents cboSelAxis As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chkServoOn As System.Windows.Forms.CheckBox
    Friend WithEvents btnPosClear As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents stcCmdVel As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents stcActPos As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents stcCmdPos As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btnJogMoveN As System.Windows.Forms.Button
    Friend WithEvents btnJogMoveP As System.Windows.Forms.Button
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents edtJogDec As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents edtJogAcc As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents edtJogVel As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnMoveStop As System.Windows.Forms.Button
    Friend WithEvents btnCaptureMove As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents edtMoveAcc As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents edtMoveVel As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cboStopMethod As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cboCaptureTarget As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cboSignalEdge As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboDetectSig As System.Windows.Forms.ComboBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents btnGetPos As System.Windows.Forms.Button
    Friend WithEvents stcCapturePos As System.Windows.Forms.TextBox
    Friend WithEvents m_timer As System.Windows.Forms.Timer
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog

End Class
