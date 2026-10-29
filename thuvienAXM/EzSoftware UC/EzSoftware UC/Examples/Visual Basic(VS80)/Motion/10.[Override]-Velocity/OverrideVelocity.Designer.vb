<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OverrideVelocity
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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnSStop = New System.Windows.Forms.Button()
        Me.btnMove1 = New System.Windows.Forms.Button()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.edtMoveAccDec = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.edtMoveVel = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.edtMovePos = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.rdoRel = New System.Windows.Forms.RadioButton()
        Me.rdoAbs = New System.Windows.Forms.RadioButton()
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
        Me.btnJogStop = New System.Windows.Forms.Button()
        Me.btnJogMove = New System.Windows.Forms.Button()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.edtJogAccDec = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.edtJogVel = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.stcOverrideMaxVel = New System.Windows.Forms.Label()
        Me.chkOverrideOnlyVel = New System.Windows.Forms.CheckBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.edtOverrideDec = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.edtOverrideAcc = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.edtOverrideVel = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.btnSetOverrideMaxVel = New System.Windows.Forms.Button()
        Me.btnSetOverride = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.edtOverrideMaxVel = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.m_timer = New System.Windows.Forms.Timer(Me.components)
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnLoadFile
        '
        Me.btnLoadFile.Location = New System.Drawing.Point(348, 16)
        Me.btnLoadFile.Name = "btnLoadFile"
        Me.btnLoadFile.Size = New System.Drawing.Size(109, 22)
        Me.btnLoadFile.TabIndex = 22
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
        Me.cboSelAxis.TabIndex = 21
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(21, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(121, 12)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "Select Axis No       :"
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Location = New System.Drawing.Point(12, 13)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(455, 27)
        Me.PictureBox1.TabIndex = 23
        Me.PictureBox1.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnSStop)
        Me.GroupBox2.Controls.Add(Me.btnMove1)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.edtMoveAccDec)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.edtMoveVel)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.edtMovePos)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.rdoRel)
        Me.GroupBox2.Controls.Add(Me.rdoAbs)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 157)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(455, 121)
        Me.GroupBox2.TabIndex = 26
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Position Move"
        '
        'btnSStop
        '
        Me.btnSStop.Location = New System.Drawing.Point(336, 64)
        Me.btnSStop.Name = "btnSStop"
        Me.btnSStop.Size = New System.Drawing.Size(109, 48)
        Me.btnSStop.TabIndex = 15
        Me.btnSStop.Text = "Move SStop"
        Me.btnSStop.UseVisualStyleBackColor = True
        '
        'btnMove1
        '
        Me.btnMove1.Location = New System.Drawing.Point(336, 36)
        Me.btnMove1.Name = "btnMove1"
        Me.btnMove1.Size = New System.Drawing.Size(109, 21)
        Me.btnMove1.TabIndex = 12
        Me.btnMove1.Text = "Move Target"
        Me.btnMove1.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(262, 96)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(66, 12)
        Me.Label15.TabIndex = 20
        Me.Label15.Text = "Unit/Sec^2"
        '
        'edtMoveAccDec
        '
        Me.edtMoveAccDec.Location = New System.Drawing.Point(135, 91)
        Me.edtMoveAccDec.Name = "edtMoveAccDec"
        Me.edtMoveAccDec.Size = New System.Drawing.Size(122, 21)
        Me.edtMoveAccDec.TabIndex = 10
        Me.edtMoveAccDec.Text = "400.0"
        Me.edtMoveAccDec.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(9, 96)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(126, 12)
        Me.Label16.TabIndex = 18
        Me.Label16.Text = "Move Accel/Decel   :"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(262, 69)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(54, 12)
        Me.Label13.TabIndex = 17
        Me.Label13.Text = "Unit/Sec"
        '
        'edtMoveVel
        '
        Me.edtMoveVel.Location = New System.Drawing.Point(135, 64)
        Me.edtMoveVel.Name = "edtMoveVel"
        Me.edtMoveVel.Size = New System.Drawing.Size(122, 21)
        Me.edtMoveVel.TabIndex = 9
        Me.edtMoveVel.Text = "100.0"
        Me.edtMoveVel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(9, 69)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(125, 12)
        Me.Label14.TabIndex = 15
        Me.Label14.Text = "Move Velocity         :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(262, 42)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(26, 12)
        Me.Label9.TabIndex = 11
        Me.Label9.Text = "Unit"
        '
        'edtMovePos
        '
        Me.edtMovePos.Location = New System.Drawing.Point(135, 37)
        Me.edtMovePos.Name = "edtMovePos"
        Me.edtMovePos.Size = New System.Drawing.Size(122, 21)
        Me.edtMovePos.TabIndex = 7
        Me.edtMovePos.Text = "100.0"
        Me.edtMovePos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(9, 42)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(126, 12)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "Target Position        :"
        '
        'rdoRel
        '
        Me.rdoRel.AutoSize = True
        Me.rdoRel.Location = New System.Drawing.Point(239, 16)
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
        Me.rdoAbs.Location = New System.Drawing.Point(136, 16)
        Me.rdoAbs.Name = "rdoAbs"
        Me.rdoAbs.Size = New System.Drawing.Size(100, 16)
        Me.rdoAbs.TabIndex = 4
        Me.rdoAbs.Tag = "rdoGroup"
        Me.rdoAbs.Text = "[00] Absolute"
        Me.rdoAbs.UseVisualStyleBackColor = True
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
        Me.GroupBox1.TabIndex = 27
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
        Me.GroupBox3.Controls.Add(Me.btnJogStop)
        Me.GroupBox3.Controls.Add(Me.btnJogMove)
        Me.GroupBox3.Controls.Add(Me.Label21)
        Me.GroupBox3.Controls.Add(Me.edtJogAccDec)
        Me.GroupBox3.Controls.Add(Me.Label22)
        Me.GroupBox3.Controls.Add(Me.Label19)
        Me.GroupBox3.Controls.Add(Me.edtJogVel)
        Me.GroupBox3.Controls.Add(Me.Label20)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 287)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(455, 76)
        Me.GroupBox3.TabIndex = 28
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Jog(Velocity) Move"
        '
        'btnJogStop
        '
        Me.btnJogStop.Location = New System.Drawing.Point(336, 47)
        Me.btnJogStop.Name = "btnJogStop"
        Me.btnJogStop.Size = New System.Drawing.Size(109, 21)
        Me.btnJogStop.TabIndex = 20
        Me.btnJogStop.Text = "Velocity Stop"
        Me.btnJogStop.UseVisualStyleBackColor = True
        '
        'btnJogMove
        '
        Me.btnJogMove.Location = New System.Drawing.Point(336, 20)
        Me.btnJogMove.Name = "btnJogMove"
        Me.btnJogMove.Size = New System.Drawing.Size(109, 21)
        Me.btnJogMove.TabIndex = 19
        Me.btnJogMove.Text = "Velocity Move"
        Me.btnJogMove.UseVisualStyleBackColor = True
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
        'edtJogAccDec
        '
        Me.edtJogAccDec.Location = New System.Drawing.Point(135, 47)
        Me.edtJogAccDec.Name = "edtJogAccDec"
        Me.edtJogAccDec.Size = New System.Drawing.Size(122, 21)
        Me.edtJogAccDec.TabIndex = 17
        Me.edtJogAccDec.Text = "400.0"
        Me.edtJogAccDec.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(9, 52)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(127, 12)
        Me.Label22.TabIndex = 30
        Me.Label22.Text = "Jog Accel/Decel      :"
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
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.stcOverrideMaxVel)
        Me.GroupBox4.Controls.Add(Me.chkOverrideOnlyVel)
        Me.GroupBox4.Controls.Add(Me.Label26)
        Me.GroupBox4.Controls.Add(Me.edtOverrideDec)
        Me.GroupBox4.Controls.Add(Me.Label27)
        Me.GroupBox4.Controls.Add(Me.Label24)
        Me.GroupBox4.Controls.Add(Me.edtOverrideAcc)
        Me.GroupBox4.Controls.Add(Me.Label25)
        Me.GroupBox4.Controls.Add(Me.Label18)
        Me.GroupBox4.Controls.Add(Me.edtOverrideVel)
        Me.GroupBox4.Controls.Add(Me.Label23)
        Me.GroupBox4.Controls.Add(Me.btnSetOverrideMaxVel)
        Me.GroupBox4.Controls.Add(Me.btnSetOverride)
        Me.GroupBox4.Controls.Add(Me.Label8)
        Me.GroupBox4.Controls.Add(Me.edtOverrideMaxVel)
        Me.GroupBox4.Controls.Add(Me.Label11)
        Me.GroupBox4.Controls.Add(Me.Label12)
        Me.GroupBox4.Controls.Add(Me.Label17)
        Me.GroupBox4.Location = New System.Drawing.Point(12, 372)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(455, 159)
        Me.GroupBox4.TabIndex = 29
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "< Override Velocity >"
        '
        'stcOverrideMaxVel
        '
        Me.stcOverrideMaxVel.Location = New System.Drawing.Point(134, 20)
        Me.stcOverrideMaxVel.Name = "stcOverrideMaxVel"
        Me.stcOverrideMaxVel.Size = New System.Drawing.Size(123, 23)
        Me.stcOverrideMaxVel.TabIndex = 43
        Me.stcOverrideMaxVel.Text = "xxx.xxx"
        Me.stcOverrideMaxVel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'chkOverrideOnlyVel
        '
        Me.chkOverrideOnlyVel.AutoSize = True
        Me.chkOverrideOnlyVel.Location = New System.Drawing.Point(336, 22)
        Me.chkOverrideOnlyVel.Name = "chkOverrideOnlyVel"
        Me.chkOverrideOnlyVel.Size = New System.Drawing.Size(102, 16)
        Me.chkOverrideOnlyVel.TabIndex = 42
        Me.chkOverrideOnlyVel.Text = "Over Only Vel"
        Me.chkOverrideOnlyVel.UseVisualStyleBackColor = True
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(262, 133)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(66, 12)
        Me.Label26.TabIndex = 41
        Me.Label26.Text = "Unit/Sec^2"
        '
        'edtOverrideDec
        '
        Me.edtOverrideDec.Location = New System.Drawing.Point(135, 128)
        Me.edtOverrideDec.Name = "edtOverrideDec"
        Me.edtOverrideDec.Size = New System.Drawing.Size(122, 21)
        Me.edtOverrideDec.TabIndex = 39
        Me.edtOverrideDec.Text = "1200.0"
        Me.edtOverrideDec.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(9, 133)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(124, 12)
        Me.Label27.TabIndex = 40
        Me.Label27.Text = "Override Decel        :"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(262, 106)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(66, 12)
        Me.Label24.TabIndex = 38
        Me.Label24.Text = "Unit/Sec^2"
        '
        'edtOverrideAcc
        '
        Me.edtOverrideAcc.Location = New System.Drawing.Point(135, 101)
        Me.edtOverrideAcc.Name = "edtOverrideAcc"
        Me.edtOverrideAcc.Size = New System.Drawing.Size(122, 21)
        Me.edtOverrideAcc.TabIndex = 36
        Me.edtOverrideAcc.Text = "600.0"
        Me.edtOverrideAcc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(9, 106)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(124, 12)
        Me.Label25.TabIndex = 37
        Me.Label25.Text = "Override Accel        :"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(262, 79)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(54, 12)
        Me.Label18.TabIndex = 35
        Me.Label18.Text = "Unit/Sec"
        '
        'edtOverrideVel
        '
        Me.edtOverrideVel.Location = New System.Drawing.Point(135, 74)
        Me.edtOverrideVel.Name = "edtOverrideVel"
        Me.edtOverrideVel.Size = New System.Drawing.Size(122, 21)
        Me.edtOverrideVel.TabIndex = 33
        Me.edtOverrideVel.Text = "300.0"
        Me.edtOverrideVel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(9, 79)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(125, 12)
        Me.Label23.TabIndex = 34
        Me.Label23.Text = "Override Velocity     :"
        '
        'btnSetOverrideMaxVel
        '
        Me.btnSetOverrideMaxVel.Location = New System.Drawing.Point(336, 47)
        Me.btnSetOverrideMaxVel.Name = "btnSetOverrideMaxVel"
        Me.btnSetOverrideMaxVel.Size = New System.Drawing.Size(109, 21)
        Me.btnSetOverrideMaxVel.TabIndex = 20
        Me.btnSetOverrideMaxVel.Text = "Set Velocity"
        Me.btnSetOverrideMaxVel.UseVisualStyleBackColor = True
        '
        'btnSetOverride
        '
        Me.btnSetOverride.Location = New System.Drawing.Point(336, 74)
        Me.btnSetOverride.Name = "btnSetOverride"
        Me.btnSetOverride.Size = New System.Drawing.Size(109, 75)
        Me.btnSetOverride.TabIndex = 19
        Me.btnSetOverride.Text = "Override"
        Me.btnSetOverride.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(262, 52)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(54, 12)
        Me.Label8.TabIndex = 32
        Me.Label8.Text = "Unit/Sec"
        '
        'edtOverrideMaxVel
        '
        Me.edtOverrideMaxVel.Location = New System.Drawing.Point(135, 47)
        Me.edtOverrideMaxVel.Name = "edtOverrideMaxVel"
        Me.edtOverrideMaxVel.Size = New System.Drawing.Size(122, 21)
        Me.edtOverrideMaxVel.TabIndex = 17
        Me.edtOverrideMaxVel.Text = "1000.0"
        Me.edtOverrideMaxVel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(9, 52)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(127, 12)
        Me.Label11.TabIndex = 30
        Me.Label11.Text = "Override Max Vel     :"
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
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(9, 25)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(126, 12)
        Me.Label17.TabIndex = 27
        Me.Label17.Text = "Valid Over Max Vel  :"
        '
        'm_timer
        '
        Me.m_timer.Enabled = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'OverrideVelocity
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(479, 539)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btnLoadFile)
        Me.Controls.Add(Me.cboSelAxis)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "OverrideVelocity"
        Me.Text = "OverrideVelocity"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnLoadFile As System.Windows.Forms.Button
    Friend WithEvents cboSelAxis As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnSStop As System.Windows.Forms.Button
    Friend WithEvents btnMove1 As System.Windows.Forms.Button
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents edtMoveAccDec As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents edtMoveVel As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents edtMovePos As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents rdoRel As System.Windows.Forms.RadioButton
    Friend WithEvents rdoAbs As System.Windows.Forms.RadioButton
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
    Friend WithEvents btnJogStop As System.Windows.Forms.Button
    Friend WithEvents btnJogMove As System.Windows.Forms.Button
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents edtJogAccDec As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents edtJogVel As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents stcOverrideMaxVel As System.Windows.Forms.Label
    Friend WithEvents chkOverrideOnlyVel As System.Windows.Forms.CheckBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents edtOverrideDec As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents edtOverrideAcc As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents edtOverrideVel As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents btnSetOverrideMaxVel As System.Windows.Forms.Button
    Friend WithEvents btnSetOverride As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents edtOverrideMaxVel As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents m_timer As System.Windows.Forms.Timer
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog

End Class
