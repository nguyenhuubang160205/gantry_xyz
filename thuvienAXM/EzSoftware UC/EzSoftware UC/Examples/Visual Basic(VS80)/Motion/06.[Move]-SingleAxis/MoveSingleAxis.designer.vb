<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MoveSingleAxis
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
        Me.btnLoadFile = New System.Windows.Forms.Button()
        Me.cboSelAxis = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnSStop = New System.Windows.Forms.Button()
        Me.btnRepeat = New System.Windows.Forms.Button()
        Me.btnMove2 = New System.Windows.Forms.Button()
        Me.btnMove1 = New System.Windows.Forms.Button()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.edtMoveDec = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.edtMoveAcc = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.edtMoveVel = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.edtPos2 = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cboProfile = New System.Windows.Forms.ComboBox()
        Me.edtPos1 = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.rdoRel = New System.Windows.Forms.RadioButton()
        Me.rdoAbs = New System.Windows.Forms.RadioButton()
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
        Me.m_timer = New System.Windows.Forms.Timer(Me.components)
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
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
        Me.GroupBox1.TabIndex = 17
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
        'btnLoadFile
        '
        Me.btnLoadFile.Location = New System.Drawing.Point(348, 16)
        Me.btnLoadFile.Name = "btnLoadFile"
        Me.btnLoadFile.Size = New System.Drawing.Size(109, 22)
        Me.btnLoadFile.TabIndex = 1
        Me.btnLoadFile.Text = "Load File"
        Me.btnLoadFile.UseVisualStyleBackColor = True
        '
        'cboSelAxis
        '
        Me.cboSelAxis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSelAxis.FormattingEnabled = True
        Me.cboSelAxis.Location = New System.Drawing.Point(147, 17)
        Me.cboSelAxis.Name = "cboSelAxis"
        Me.cboSelAxis.Size = New System.Drawing.Size(195, 20)
        Me.cboSelAxis.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(21, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(121, 12)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Select Axis No       :"
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Location = New System.Drawing.Point(12, 13)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(455, 27)
        Me.PictureBox1.TabIndex = 15
        Me.PictureBox1.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnSStop)
        Me.GroupBox2.Controls.Add(Me.btnRepeat)
        Me.GroupBox2.Controls.Add(Me.btnMove2)
        Me.GroupBox2.Controls.Add(Me.btnMove1)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.edtMoveDec)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.edtMoveAcc)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.edtMoveVel)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.edtPos2)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.cboProfile)
        Me.GroupBox2.Controls.Add(Me.edtPos1)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.rdoRel)
        Me.GroupBox2.Controls.Add(Me.rdoAbs)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 157)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(455, 217)
        Me.GroupBox2.TabIndex = 18
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "< Position Move >"
        '
        'btnSStop
        '
        Me.btnSStop.Location = New System.Drawing.Point(336, 168)
        Me.btnSStop.Name = "btnSStop"
        Me.btnSStop.Size = New System.Drawing.Size(109, 37)
        Me.btnSStop.TabIndex = 15
        Me.btnSStop.Text = "Move SStop"
        Me.btnSStop.UseVisualStyleBackColor = True
        '
        'btnRepeat
        '
        Me.btnRepeat.Location = New System.Drawing.Point(336, 124)
        Me.btnRepeat.Name = "btnRepeat"
        Me.btnRepeat.Size = New System.Drawing.Size(109, 37)
        Me.btnRepeat.TabIndex = 14
        Me.btnRepeat.Text = "Repeat Target 2"
        Me.btnRepeat.UseVisualStyleBackColor = True
        '
        'btnMove2
        '
        Me.btnMove2.Location = New System.Drawing.Point(336, 97)
        Me.btnMove2.Name = "btnMove2"
        Me.btnMove2.Size = New System.Drawing.Size(109, 21)
        Me.btnMove2.TabIndex = 13
        Me.btnMove2.Text = "Move Target 2"
        Me.btnMove2.UseVisualStyleBackColor = True
        '
        'btnMove1
        '
        Me.btnMove1.Location = New System.Drawing.Point(336, 71)
        Me.btnMove1.Name = "btnMove1"
        Me.btnMove1.Size = New System.Drawing.Size(109, 21)
        Me.btnMove1.TabIndex = 12
        Me.btnMove1.Text = "Move Target 1"
        Me.btnMove1.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(262, 189)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(66, 12)
        Me.Label17.TabIndex = 23
        Me.Label17.Text = "Unit/Sec^2"
        '
        'edtMoveDec
        '
        Me.edtMoveDec.Location = New System.Drawing.Point(135, 184)
        Me.edtMoveDec.Name = "edtMoveDec"
        Me.edtMoveDec.Size = New System.Drawing.Size(122, 21)
        Me.edtMoveDec.TabIndex = 11
        Me.edtMoveDec.Text = "400.0"
        Me.edtMoveDec.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(9, 189)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(126, 12)
        Me.Label18.TabIndex = 21
        Me.Label18.Text = "Move Deceleration   :"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(262, 162)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(66, 12)
        Me.Label15.TabIndex = 20
        Me.Label15.Text = "Unit/Sec^2"
        '
        'edtMoveAcc
        '
        Me.edtMoveAcc.Location = New System.Drawing.Point(135, 157)
        Me.edtMoveAcc.Name = "edtMoveAcc"
        Me.edtMoveAcc.Size = New System.Drawing.Size(122, 21)
        Me.edtMoveAcc.TabIndex = 10
        Me.edtMoveAcc.Text = "400.0"
        Me.edtMoveAcc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(9, 162)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(126, 12)
        Me.Label16.TabIndex = 18
        Me.Label16.Text = "Move Acceleration   :"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(262, 135)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(54, 12)
        Me.Label13.TabIndex = 17
        Me.Label13.Text = "Unit/Sec"
        '
        'edtMoveVel
        '
        Me.edtMoveVel.Location = New System.Drawing.Point(135, 130)
        Me.edtMoveVel.Name = "edtMoveVel"
        Me.edtMoveVel.Size = New System.Drawing.Size(122, 21)
        Me.edtMoveVel.TabIndex = 9
        Me.edtMoveVel.Text = "100.0"
        Me.edtMoveVel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(9, 135)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(125, 12)
        Me.Label14.TabIndex = 15
        Me.Label14.Text = "Move Velocity         :"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(262, 103)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(26, 12)
        Me.Label11.TabIndex = 14
        Me.Label11.Text = "Unit"
        '
        'edtPos2
        '
        Me.edtPos2.Location = New System.Drawing.Point(135, 98)
        Me.edtPos2.Name = "edtPos2"
        Me.edtPos2.Size = New System.Drawing.Size(122, 21)
        Me.edtPos2.TabIndex = 8
        Me.edtPos2.Text = "100.0"
        Me.edtPos2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(9, 103)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(124, 12)
        Me.Label12.TabIndex = 12
        Me.Label12.Text = "Target Position 2     :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(262, 76)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(26, 12)
        Me.Label9.TabIndex = 11
        Me.Label9.Text = "Unit"
        '
        'cboProfile
        '
        Me.cboProfile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboProfile.FormattingEnabled = True
        Me.cboProfile.Location = New System.Drawing.Point(135, 42)
        Me.cboProfile.Name = "cboProfile"
        Me.cboProfile.Size = New System.Drawing.Size(195, 20)
        Me.cboProfile.TabIndex = 6
        '
        'edtPos1
        '
        Me.edtPos1.Location = New System.Drawing.Point(135, 71)
        Me.edtPos1.Name = "edtPos1"
        Me.edtPos1.Size = New System.Drawing.Size(122, 21)
        Me.edtPos1.TabIndex = 7
        Me.edtPos1.Text = "0.0"
        Me.edtPos1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(9, 76)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(124, 12)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "Target Position 1     :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(9, 46)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(123, 12)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "Velocity Profile Set  :"
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
        Me.GroupBox3.Location = New System.Drawing.Point(12, 383)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(455, 107)
        Me.GroupBox3.TabIndex = 19
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
        Me.Label24.Size = New System.Drawing.Size(127, 12)
        Me.Label24.TabIndex = 33
        Me.Label24.Text = "Jog Deceleration      :"
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
        Me.Label22.Size = New System.Drawing.Size(127, 12)
        Me.Label22.TabIndex = 30
        Me.Label22.Text = "Jog Acceleration      :"
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
        Me.Label20.Size = New System.Drawing.Size(126, 12)
        Me.Label20.TabIndex = 27
        Me.Label20.Text = "Jog Velocity            :"
        '
        'm_timer
        '
        Me.m_timer.Enabled = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'MoveSingleAxis
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(479, 502)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnLoadFile)
        Me.Controls.Add(Me.cboSelAxis)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MoveSingleAxis"
        Me.Text = "MoveSingleAxis"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
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
    Friend WithEvents btnLoadFile As System.Windows.Forms.Button
    Friend WithEvents cboSelAxis As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rdoRel As System.Windows.Forms.RadioButton
    Friend WithEvents rdoAbs As System.Windows.Forms.RadioButton
    Friend WithEvents cboProfile As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents edtPos1 As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents edtMoveDec As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents edtMoveAcc As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents edtMoveVel As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents edtPos2 As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents btnMove1 As System.Windows.Forms.Button
    Friend WithEvents btnSStop As System.Windows.Forms.Button
    Friend WithEvents btnRepeat As System.Windows.Forms.Button
    Friend WithEvents btnMove2 As System.Windows.Forms.Button
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
    Friend WithEvents m_timer As System.Windows.Forms.Timer
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog

End Class
