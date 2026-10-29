<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GantryMotion
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
        Me.stcGantryState = New System.Windows.Forms.Label()
        Me.chkHomeStateSL = New System.Windows.Forms.CheckBox()
        Me.chkHomeStateMa = New System.Windows.Forms.CheckBox()
        Me.stcAxisNoSl = New System.Windows.Forms.Label()
        Me.stcAxisNoMa = New System.Windows.Forms.Label()
        Me.stcCmdVelSL = New System.Windows.Forms.TextBox()
        Me.stcActPosSL = New System.Windows.Forms.TextBox()
        Me.stcCmdPosSL = New System.Windows.Forms.TextBox()
        Me.chkServoOn = New System.Windows.Forms.CheckBox()
        Me.btnPosClear = New System.Windows.Forms.Button()
        Me.stcCmdVelMa = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.stcActPosMa = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.stcCmdPosMa = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnJogMoveN = New System.Windows.Forms.Button()
        Me.btnJogMoveP = New System.Windows.Forms.Button()
        Me.btnMoveStop = New System.Windows.Forms.Button()
        Me.btnMovePos = New System.Windows.Forms.Button()
        Me.edtMoveDec = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.edtMoveAcc = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.edtMoveVel = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.edtMovePos = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.rdoRel = New System.Windows.Forms.RadioButton()
        Me.rdoAbs = New System.Windows.Forms.RadioButton()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.prgHomeRate = New System.Windows.Forms.ProgressBar()
        Me.stcHomeStepSub = New System.Windows.Forms.TextBox()
        Me.stcHomeStepMain = New System.Windows.Forms.TextBox()
        Me.btnHomeStop = New System.Windows.Forms.Button()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.btnHomeStart = New System.Windows.Forms.Button()
        Me.stcHomeResult = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.chkGantryEnable = New System.Windows.Forms.CheckBox()
        Me.cboGantryHmSlaveUse = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.edtGantryHmRange = New System.Windows.Forms.TextBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.edtGantryHmOffset = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.m_timerDisplay = New System.Windows.Forms.Timer(Me.components)
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.m_timerHomeInfo = New System.Windows.Forms.Timer(Me.components)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnLoadFile
        '
        Me.btnLoadFile.Location = New System.Drawing.Point(348, 15)
        Me.btnLoadFile.Name = "btnLoadFile"
        Me.btnLoadFile.Size = New System.Drawing.Size(109, 22)
        Me.btnLoadFile.TabIndex = 18
        Me.btnLoadFile.Text = "Load File"
        Me.btnLoadFile.UseVisualStyleBackColor = True
        '
        'cboSelAxis
        '
        Me.cboSelAxis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSelAxis.FormattingEnabled = True
        Me.cboSelAxis.Location = New System.Drawing.Point(143, 16)
        Me.cboSelAxis.Name = "cboSelAxis"
        Me.cboSelAxis.Size = New System.Drawing.Size(199, 20)
        Me.cboSelAxis.TabIndex = 17
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(21, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(121, 12)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Select Axis No       :"
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Location = New System.Drawing.Point(12, 13)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(455, 27)
        Me.PictureBox1.TabIndex = 19
        Me.PictureBox1.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.stcGantryState)
        Me.GroupBox1.Controls.Add(Me.chkHomeStateSL)
        Me.GroupBox1.Controls.Add(Me.chkHomeStateMa)
        Me.GroupBox1.Controls.Add(Me.stcAxisNoSl)
        Me.GroupBox1.Controls.Add(Me.stcAxisNoMa)
        Me.GroupBox1.Controls.Add(Me.stcCmdVelSL)
        Me.GroupBox1.Controls.Add(Me.stcActPosSL)
        Me.GroupBox1.Controls.Add(Me.stcCmdPosSL)
        Me.GroupBox1.Controls.Add(Me.chkServoOn)
        Me.GroupBox1.Controls.Add(Me.btnPosClear)
        Me.GroupBox1.Controls.Add(Me.stcCmdVelMa)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.stcActPosMa)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.stcCmdPosMa)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 49)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(455, 140)
        Me.GroupBox1.TabIndex = 21
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Position Monitor"
        '
        'stcGantryState
        '
        Me.stcGantryState.AutoSize = True
        Me.stcGantryState.Location = New System.Drawing.Point(223, 17)
        Me.stcGantryState.Name = "stcGantryState"
        Me.stcGantryState.Size = New System.Drawing.Size(15, 12)
        Me.stcGantryState.TabIndex = 31
        Me.stcGantryState.Text = "∞"
        '
        'chkHomeStateSL
        '
        Me.chkHomeStateSL.AutoSize = True
        Me.chkHomeStateSL.Enabled = False
        Me.chkHomeStateSL.Location = New System.Drawing.Point(232, 116)
        Me.chkHomeStateSL.Name = "chkHomeStateSL"
        Me.chkHomeStateSL.Size = New System.Drawing.Size(89, 16)
        Me.chkHomeStateSL.TabIndex = 30
        Me.chkHomeStateSL.Text = "Home State"
        Me.chkHomeStateSL.UseVisualStyleBackColor = True
        '
        'chkHomeStateMa
        '
        Me.chkHomeStateMa.AutoSize = True
        Me.chkHomeStateMa.Enabled = False
        Me.chkHomeStateMa.Location = New System.Drawing.Point(131, 116)
        Me.chkHomeStateMa.Name = "chkHomeStateMa"
        Me.chkHomeStateMa.Size = New System.Drawing.Size(89, 16)
        Me.chkHomeStateMa.TabIndex = 29
        Me.chkHomeStateMa.Text = "Home State"
        Me.chkHomeStateMa.UseVisualStyleBackColor = True
        '
        'stcAxisNoSl
        '
        Me.stcAxisNoSl.AutoSize = True
        Me.stcAxisNoSl.Location = New System.Drawing.Point(248, 17)
        Me.stcAxisNoSl.Name = "stcAxisNoSl"
        Me.stcAxisNoSl.Size = New System.Drawing.Size(61, 12)
        Me.stcAxisNoSl.TabIndex = 28
        Me.stcAxisNoSl.Text = "Sl Axis 00"
        '
        'stcAxisNoMa
        '
        Me.stcAxisNoMa.AutoSize = True
        Me.stcAxisNoMa.Location = New System.Drawing.Point(146, 17)
        Me.stcAxisNoMa.Name = "stcAxisNoMa"
        Me.stcAxisNoMa.Size = New System.Drawing.Size(68, 12)
        Me.stcAxisNoMa.TabIndex = 27
        Me.stcAxisNoMa.Text = "Ma Axis 00"
        '
        'stcCmdVelSL
        '
        Me.stcCmdVelSL.Location = New System.Drawing.Point(232, 89)
        Me.stcCmdVelSL.Name = "stcCmdVelSL"
        Me.stcCmdVelSL.ReadOnly = True
        Me.stcCmdVelSL.Size = New System.Drawing.Size(95, 21)
        Me.stcCmdVelSL.TabIndex = 26
        Me.stcCmdVelSL.Text = "0.000"
        Me.stcCmdVelSL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'stcActPosSL
        '
        Me.stcActPosSL.Location = New System.Drawing.Point(232, 64)
        Me.stcActPosSL.Name = "stcActPosSL"
        Me.stcActPosSL.ReadOnly = True
        Me.stcActPosSL.Size = New System.Drawing.Size(95, 21)
        Me.stcActPosSL.TabIndex = 25
        Me.stcActPosSL.Text = "0.000"
        Me.stcActPosSL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'stcCmdPosSL
        '
        Me.stcCmdPosSL.Location = New System.Drawing.Point(232, 35)
        Me.stcCmdPosSL.Name = "stcCmdPosSL"
        Me.stcCmdPosSL.ReadOnly = True
        Me.stcCmdPosSL.Size = New System.Drawing.Size(95, 21)
        Me.stcCmdPosSL.TabIndex = 24
        Me.stcCmdPosSL.Text = "0.000"
        Me.stcCmdPosSL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chkServoOn
        '
        Me.chkServoOn.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkServoOn.Location = New System.Drawing.Point(336, 88)
        Me.chkServoOn.Name = "chkServoOn"
        Me.chkServoOn.Size = New System.Drawing.Size(109, 24)
        Me.chkServoOn.TabIndex = 3
        Me.chkServoOn.Text = "Servo On"
        Me.chkServoOn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkServoOn.UseVisualStyleBackColor = True
        '
        'btnPosClear
        '
        Me.btnPosClear.Location = New System.Drawing.Point(336, 35)
        Me.btnPosClear.Name = "btnPosClear"
        Me.btnPosClear.Size = New System.Drawing.Size(109, 44)
        Me.btnPosClear.TabIndex = 2
        Me.btnPosClear.Text = "Position Clear"
        Me.btnPosClear.UseVisualStyleBackColor = True
        '
        'stcCmdVelMa
        '
        Me.stcCmdVelMa.Location = New System.Drawing.Point(131, 89)
        Me.stcCmdVelMa.Name = "stcCmdVelMa"
        Me.stcCmdVelMa.ReadOnly = True
        Me.stcCmdVelMa.Size = New System.Drawing.Size(98, 21)
        Me.stcCmdVelMa.TabIndex = 23
        Me.stcCmdVelMa.Text = "0.000"
        Me.stcCmdVelMa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(9, 94)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(121, 12)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Command Velocity :"
        '
        'stcActPosMa
        '
        Me.stcActPosMa.Location = New System.Drawing.Point(131, 62)
        Me.stcActPosMa.Name = "stcActPosMa"
        Me.stcActPosMa.ReadOnly = True
        Me.stcActPosMa.Size = New System.Drawing.Size(98, 21)
        Me.stcActPosMa.TabIndex = 22
        Me.stcActPosMa.Text = "0.000"
        Me.stcActPosMa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(9, 67)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(121, 12)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Feedback Position  :"
        '
        'stcCmdPosMa
        '
        Me.stcCmdPosMa.Location = New System.Drawing.Point(131, 35)
        Me.stcCmdPosMa.Name = "stcCmdPosMa"
        Me.stcCmdPosMa.ReadOnly = True
        Me.stcCmdPosMa.Size = New System.Drawing.Size(98, 21)
        Me.stcCmdPosMa.TabIndex = 21
        Me.stcCmdPosMa.Text = "0.000"
        Me.stcCmdPosMa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(121, 12)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Command Position :"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnJogMoveN)
        Me.GroupBox2.Controls.Add(Me.btnJogMoveP)
        Me.GroupBox2.Controls.Add(Me.btnMoveStop)
        Me.GroupBox2.Controls.Add(Me.btnMovePos)
        Me.GroupBox2.Controls.Add(Me.edtMoveDec)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.edtMoveAcc)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.edtMoveVel)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.edtMovePos)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.rdoRel)
        Me.GroupBox2.Controls.Add(Me.rdoAbs)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 195)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(455, 155)
        Me.GroupBox2.TabIndex = 22
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Position Move"
        '
        'btnJogMoveN
        '
        Me.btnJogMoveN.Location = New System.Drawing.Point(336, 123)
        Me.btnJogMoveN.Name = "btnJogMoveN"
        Me.btnJogMoveN.Size = New System.Drawing.Size(109, 21)
        Me.btnJogMoveN.TabIndex = 22
        Me.btnJogMoveN.Text = "Move Jog(-)"
        Me.btnJogMoveN.UseVisualStyleBackColor = True
        '
        'btnJogMoveP
        '
        Me.btnJogMoveP.Location = New System.Drawing.Point(336, 96)
        Me.btnJogMoveP.Name = "btnJogMoveP"
        Me.btnJogMoveP.Size = New System.Drawing.Size(109, 21)
        Me.btnJogMoveP.TabIndex = 15
        Me.btnJogMoveP.Text = "Move Jog(+)"
        Me.btnJogMoveP.UseVisualStyleBackColor = True
        '
        'btnMoveStop
        '
        Me.btnMoveStop.Location = New System.Drawing.Point(336, 69)
        Me.btnMoveStop.Name = "btnMoveStop"
        Me.btnMoveStop.Size = New System.Drawing.Size(109, 21)
        Me.btnMoveStop.TabIndex = 14
        Me.btnMoveStop.Text = "Move Stop"
        Me.btnMoveStop.UseVisualStyleBackColor = True
        '
        'btnMovePos
        '
        Me.btnMovePos.Location = New System.Drawing.Point(336, 42)
        Me.btnMovePos.Name = "btnMovePos"
        Me.btnMovePos.Size = New System.Drawing.Size(109, 21)
        Me.btnMovePos.TabIndex = 12
        Me.btnMovePos.Text = "Move Target"
        Me.btnMovePos.UseVisualStyleBackColor = True
        '
        'edtMoveDec
        '
        Me.edtMoveDec.Location = New System.Drawing.Point(135, 123)
        Me.edtMoveDec.Name = "edtMoveDec"
        Me.edtMoveDec.Size = New System.Drawing.Size(190, 21)
        Me.edtMoveDec.TabIndex = 11
        Me.edtMoveDec.Text = "400.0"
        Me.edtMoveDec.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(9, 128)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(126, 12)
        Me.Label18.TabIndex = 21
        Me.Label18.Text = "Move Deceleration   :"
        '
        'edtMoveAcc
        '
        Me.edtMoveAcc.Location = New System.Drawing.Point(135, 96)
        Me.edtMoveAcc.Name = "edtMoveAcc"
        Me.edtMoveAcc.Size = New System.Drawing.Size(190, 21)
        Me.edtMoveAcc.TabIndex = 10
        Me.edtMoveAcc.Text = "400.0"
        Me.edtMoveAcc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(9, 101)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(126, 12)
        Me.Label16.TabIndex = 18
        Me.Label16.Text = "Move Acceleration   :"
        '
        'edtMoveVel
        '
        Me.edtMoveVel.Location = New System.Drawing.Point(135, 69)
        Me.edtMoveVel.Name = "edtMoveVel"
        Me.edtMoveVel.Size = New System.Drawing.Size(190, 21)
        Me.edtMoveVel.TabIndex = 9
        Me.edtMoveVel.Text = "100.0"
        Me.edtMoveVel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(9, 74)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(125, 12)
        Me.Label14.TabIndex = 15
        Me.Label14.Text = "Move Velocity         :"
        '
        'edtMovePos
        '
        Me.edtMovePos.Location = New System.Drawing.Point(135, 42)
        Me.edtMovePos.Name = "edtMovePos"
        Me.edtMovePos.Size = New System.Drawing.Size(192, 21)
        Me.edtMovePos.TabIndex = 7
        Me.edtMovePos.Text = "100.0"
        Me.edtMovePos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(9, 47)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(122, 12)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "Target Position       :"
        '
        'rdoRel
        '
        Me.rdoRel.AutoSize = True
        Me.rdoRel.Location = New System.Drawing.Point(239, 20)
        Me.rdoRel.Name = "rdoRel"
        Me.rdoRel.Size = New System.Drawing.Size(95, 16)
        Me.rdoRel.TabIndex = 5
        Me.rdoRel.Tag = "rdoGroup"
        Me.rdoRel.Text = "[01] Relative"
        Me.rdoRel.UseVisualStyleBackColor = True
        '
        'rdoAbs
        '
        Me.rdoAbs.AutoSize = True
        Me.rdoAbs.Location = New System.Drawing.Point(136, 20)
        Me.rdoAbs.Name = "rdoAbs"
        Me.rdoAbs.Size = New System.Drawing.Size(100, 16)
        Me.rdoAbs.TabIndex = 4
        Me.rdoAbs.Tag = "rdoGroup"
        Me.rdoAbs.Text = "[00] Absolute"
        Me.rdoAbs.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.prgHomeRate)
        Me.GroupBox5.Controls.Add(Me.stcHomeStepSub)
        Me.GroupBox5.Controls.Add(Me.stcHomeStepMain)
        Me.GroupBox5.Controls.Add(Me.btnHomeStop)
        Me.GroupBox5.Controls.Add(Me.Label22)
        Me.GroupBox5.Controls.Add(Me.btnHomeStart)
        Me.GroupBox5.Controls.Add(Me.stcHomeResult)
        Me.GroupBox5.Controls.Add(Me.Label17)
        Me.GroupBox5.Location = New System.Drawing.Point(12, 359)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(455, 73)
        Me.GroupBox5.TabIndex = 23
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Home Search"
        '
        'prgHomeRate
        '
        Me.prgHomeRate.Location = New System.Drawing.Point(208, 41)
        Me.prgHomeRate.Name = "prgHomeRate"
        Me.prgHomeRate.Size = New System.Drawing.Size(119, 21)
        Me.prgHomeRate.Step = 1
        Me.prgHomeRate.TabIndex = 31
        '
        'stcHomeStepSub
        '
        Me.stcHomeStepSub.Location = New System.Drawing.Point(171, 41)
        Me.stcHomeStepSub.Name = "stcHomeStepSub"
        Me.stcHomeStepSub.ReadOnly = True
        Me.stcHomeStepSub.Size = New System.Drawing.Size(30, 21)
        Me.stcHomeStepSub.TabIndex = 30
        Me.stcHomeStepSub.Text = "100"
        '
        'stcHomeStepMain
        '
        Me.stcHomeStepMain.Location = New System.Drawing.Point(135, 41)
        Me.stcHomeStepMain.Name = "stcHomeStepMain"
        Me.stcHomeStepMain.ReadOnly = True
        Me.stcHomeStepMain.Size = New System.Drawing.Size(30, 21)
        Me.stcHomeStepMain.TabIndex = 29
        Me.stcHomeStepMain.Text = "100"
        '
        'btnHomeStop
        '
        Me.btnHomeStop.Location = New System.Drawing.Point(336, 41)
        Me.btnHomeStop.Name = "btnHomeStop"
        Me.btnHomeStop.Size = New System.Drawing.Size(109, 23)
        Me.btnHomeStop.TabIndex = 20
        Me.btnHomeStop.Text = "Home Stop"
        Me.btnHomeStop.UseVisualStyleBackColor = True
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(9, 47)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(126, 12)
        Me.Label22.TabIndex = 27
        Me.Label22.Text = "Home Step/Rate      :"
        '
        'btnHomeStart
        '
        Me.btnHomeStart.Location = New System.Drawing.Point(336, 13)
        Me.btnHomeStart.Name = "btnHomeStart"
        Me.btnHomeStart.Size = New System.Drawing.Size(109, 23)
        Me.btnHomeStart.TabIndex = 19
        Me.btnHomeStart.Text = "Home Start"
        Me.btnHomeStart.UseVisualStyleBackColor = True
        '
        'stcHomeResult
        '
        Me.stcHomeResult.Location = New System.Drawing.Point(136, 15)
        Me.stcHomeResult.Name = "stcHomeResult"
        Me.stcHomeResult.ReadOnly = True
        Me.stcHomeResult.Size = New System.Drawing.Size(191, 21)
        Me.stcHomeResult.TabIndex = 26
        Me.stcHomeResult.Text = " [FFH] HOME_ERR_UNKNOWN"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(9, 20)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(125, 12)
        Me.Label17.TabIndex = 24
        Me.Label17.Text = "Home Result           :"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.chkGantryEnable)
        Me.GroupBox3.Controls.Add(Me.cboGantryHmSlaveUse)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.PictureBox3)
        Me.GroupBox3.Controls.Add(Me.edtGantryHmRange)
        Me.GroupBox3.Controls.Add(Me.PictureBox2)
        Me.GroupBox3.Controls.Add(Me.edtGantryHmOffset)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 441)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(455, 73)
        Me.GroupBox3.TabIndex = 24
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "< Gantry Enable >"
        '
        'chkGantryEnable
        '
        Me.chkGantryEnable.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkGantryEnable.Location = New System.Drawing.Point(336, 49)
        Me.chkGantryEnable.Name = "chkGantryEnable"
        Me.chkGantryEnable.Size = New System.Drawing.Size(119, 24)
        Me.chkGantryEnable.TabIndex = 31
        Me.chkGantryEnable.Text = "Gantry Enable"
        Me.chkGantryEnable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkGantryEnable.UseVisualStyleBackColor = True
        '
        'cboGantryHmSlaveUse
        '
        Me.cboGantryHmSlaveUse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboGantryHmSlaveUse.FormattingEnabled = True
        Me.cboGantryHmSlaveUse.Items.AddRange(New Object() {"00: NONE", "01: BOTH", "02: EACH"})
        Me.cboGantryHmSlaveUse.Location = New System.Drawing.Point(336, 16)
        Me.cboGantryHmSlaveUse.Name = "cboGantryHmSlaveUse"
        Me.cboGantryHmSlaveUse.Size = New System.Drawing.Size(109, 20)
        Me.cboGantryHmSlaveUse.TabIndex = 25
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(244, 20)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(89, 12)
        Me.Label9.TabIndex = 47
        Me.Label9.Text = "Slave Hm Use:"
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.PictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox3.Location = New System.Drawing.Point(235, 15)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(3, 48)
        Me.PictureBox3.TabIndex = 45
        Me.PictureBox3.TabStop = False
        '
        'edtGantryHmRange
        '
        Me.edtGantryHmRange.Location = New System.Drawing.Point(135, 42)
        Me.edtGantryHmRange.Name = "edtGantryHmRange"
        Me.edtGantryHmRange.Size = New System.Drawing.Size(94, 21)
        Me.edtGantryHmRange.TabIndex = 28
        Me.edtGantryHmRange.Text = "100.0"
        Me.edtGantryHmRange.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.PictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox2.Location = New System.Drawing.Point(336, 42)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(119, 3)
        Me.PictureBox2.TabIndex = 46
        Me.PictureBox2.TabStop = False
        '
        'edtGantryHmOffset
        '
        Me.edtGantryHmOffset.Location = New System.Drawing.Point(135, 15)
        Me.edtGantryHmOffset.Name = "edtGantryHmOffset"
        Me.edtGantryHmOffset.Size = New System.Drawing.Size(94, 21)
        Me.edtGantryHmOffset.TabIndex = 23
        Me.edtGantryHmOffset.Text = "0.0"
        Me.edtGantryHmOffset.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(9, 47)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(125, 12)
        Me.Label6.TabIndex = 27
        Me.Label6.Text = "Slave Home Range  :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(9, 20)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(125, 12)
        Me.Label8.TabIndex = 24
        Me.Label8.Text = "Slave Home Offset   :"
        '
        'm_timerDisplay
        '
        Me.m_timerDisplay.Enabled = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'm_timerHomeInfo
        '
        Me.m_timerHomeInfo.Enabled = True
        Me.m_timerHomeInfo.Interval = 200
        '
        'GantryMotion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(479, 523)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnLoadFile)
        Me.Controls.Add(Me.cboSelAxis)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "GantryMotion"
        Me.Text = "GantryMotion"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents stcCmdVelMa As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents stcActPosMa As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents stcCmdPosMa As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnJogMoveP As System.Windows.Forms.Button
    Friend WithEvents btnMoveStop As System.Windows.Forms.Button
    Friend WithEvents btnMovePos As System.Windows.Forms.Button
    Friend WithEvents edtMoveDec As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents edtMoveAcc As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents edtMoveVel As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents edtMovePos As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents rdoRel As System.Windows.Forms.RadioButton
    Friend WithEvents rdoAbs As System.Windows.Forms.RadioButton
    Friend WithEvents chkHomeStateSL As System.Windows.Forms.CheckBox
    Friend WithEvents chkHomeStateMa As System.Windows.Forms.CheckBox
    Friend WithEvents stcAxisNoSl As System.Windows.Forms.Label
    Friend WithEvents stcAxisNoMa As System.Windows.Forms.Label
    Friend WithEvents stcCmdVelSL As System.Windows.Forms.TextBox
    Friend WithEvents stcActPosSL As System.Windows.Forms.TextBox
    Friend WithEvents stcCmdPosSL As System.Windows.Forms.TextBox
    Friend WithEvents btnJogMoveN As System.Windows.Forms.Button
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents prgHomeRate As System.Windows.Forms.ProgressBar
    Friend WithEvents stcHomeStepSub As System.Windows.Forms.TextBox
    Friend WithEvents stcHomeStepMain As System.Windows.Forms.TextBox
    Friend WithEvents btnHomeStop As System.Windows.Forms.Button
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents btnHomeStart As System.Windows.Forms.Button
    Friend WithEvents stcHomeResult As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents edtGantryHmRange As System.Windows.Forms.TextBox
    Friend WithEvents edtGantryHmOffset As System.Windows.Forms.TextBox
    Friend WithEvents cboGantryHmSlaveUse As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents chkGantryEnable As System.Windows.Forms.CheckBox
    Friend WithEvents m_timerDisplay As System.Windows.Forms.Timer
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents m_timerHomeInfo As System.Windows.Forms.Timer
    Friend WithEvents stcGantryState As System.Windows.Forms.Label

End Class
