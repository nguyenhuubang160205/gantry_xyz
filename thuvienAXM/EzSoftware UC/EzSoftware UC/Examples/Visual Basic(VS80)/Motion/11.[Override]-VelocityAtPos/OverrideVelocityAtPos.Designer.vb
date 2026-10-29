<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OverrideVelocityAtPos
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
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.edtOverVel = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.edtOverPos = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.edtMoveDec = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.btnStop = New System.Windows.Forms.Button()
        Me.btnOverVelAtPos = New System.Windows.Forms.Button()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.edtMoveAcc = New System.Windows.Forms.TextBox()
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
        Me.edtSetPos = New System.Windows.Forms.TextBox()
        Me.chkServoOn = New System.Windows.Forms.CheckBox()
        Me.btnPosSet = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.stcCmdVel = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.stcActPos = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.stcCmdPos = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.chkOverMulti = New System.Windows.Forms.CheckBox()
        Me.cboCampTarget = New System.Windows.Forms.ComboBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.cboOverMode = New System.Windows.Forms.ComboBox()
        Me.lstOverData = New System.Windows.Forms.ListBox()
        Me.btnOverVelAtMPos = New System.Windows.Forms.Button()
        Me.btnOverDataClr = New System.Windows.Forms.Button()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.edtOverPosAdd = New System.Windows.Forms.TextBox()
        Me.edtOverVelAdd = New System.Windows.Forms.TextBox()
        Me.btnOverDataAdd = New System.Windows.Forms.Button()
        Me.m_timer = New System.Windows.Forms.Timer(Me.components)
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnLoadFile
        '
        Me.btnLoadFile.Location = New System.Drawing.Point(348, 15)
        Me.btnLoadFile.Name = "btnLoadFile"
        Me.btnLoadFile.Size = New System.Drawing.Size(109, 22)
        Me.btnLoadFile.TabIndex = 26
        Me.btnLoadFile.Text = "Load File"
        Me.btnLoadFile.UseVisualStyleBackColor = True
        '
        'cboSelAxis
        '
        Me.cboSelAxis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSelAxis.FormattingEnabled = True
        Me.cboSelAxis.Location = New System.Drawing.Point(137, 16)
        Me.cboSelAxis.Name = "cboSelAxis"
        Me.cboSelAxis.Size = New System.Drawing.Size(206, 20)
        Me.cboSelAxis.TabIndex = 25
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(21, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(117, 12)
        Me.Label1.TabIndex = 28
        Me.Label1.Text = "Select Axis No      :"
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Location = New System.Drawing.Point(12, 13)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(455, 27)
        Me.PictureBox1.TabIndex = 27
        Me.PictureBox1.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnOverDataAdd)
        Me.GroupBox2.Controls.Add(Me.edtOverVelAdd)
        Me.GroupBox2.Controls.Add(Me.edtOverPosAdd)
        Me.GroupBox2.Controls.Add(Me.Label20)
        Me.GroupBox2.Controls.Add(Me.PictureBox3)
        Me.GroupBox2.Controls.Add(Me.btnOverDataClr)
        Me.GroupBox2.Controls.Add(Me.btnOverVelAtMPos)
        Me.GroupBox2.Controls.Add(Me.lstOverData)
        Me.GroupBox2.Controls.Add(Me.cboOverMode)
        Me.GroupBox2.Controls.Add(Me.PictureBox2)
        Me.GroupBox2.Controls.Add(Me.cboCampTarget)
        Me.GroupBox2.Controls.Add(Me.chkOverMulti)
        Me.GroupBox2.Controls.Add(Me.Label25)
        Me.GroupBox2.Controls.Add(Me.Label23)
        Me.GroupBox2.Controls.Add(Me.Label21)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.edtOverVel)
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.edtOverPos)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.edtMoveDec)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.btnStop)
        Me.GroupBox2.Controls.Add(Me.btnOverVelAtPos)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.edtMoveAcc)
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
        Me.GroupBox2.Size = New System.Drawing.Size(455, 380)
        Me.GroupBox2.TabIndex = 29
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "< Override Velocity At Position >"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(9, 266)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(118, 12)
        Me.Label25.TabIndex = 37
        Me.Label25.Text = "Multi List(Pos, Vel):"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(9, 239)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(116, 12)
        Me.Label23.TabIndex = 34
        Me.Label23.Text = "Override Mode      :"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(9, 204)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(113, 12)
        Me.Label21.TabIndex = 31
        Me.Label21.Text = "Compare Target   :"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(265, 177)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(54, 12)
        Me.Label18.TabIndex = 29
        Me.Label18.Text = "Unit/Sec"
        '
        'edtOverVel
        '
        Me.edtOverVel.Location = New System.Drawing.Point(125, 172)
        Me.edtOverVel.Name = "edtOverVel"
        Me.edtOverVel.Size = New System.Drawing.Size(137, 21)
        Me.edtOverVel.TabIndex = 27
        Me.edtOverVel.Text = "200.0"
        Me.edtOverVel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(9, 177)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(113, 12)
        Me.Label19.TabIndex = 28
        Me.Label19.Text = "Override Velocity  :"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(265, 150)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(26, 12)
        Me.Label12.TabIndex = 26
        Me.Label12.Text = "Unit"
        '
        'edtOverPos
        '
        Me.edtOverPos.Location = New System.Drawing.Point(125, 145)
        Me.edtOverPos.Name = "edtOverPos"
        Me.edtOverPos.Size = New System.Drawing.Size(137, 21)
        Me.edtOverPos.TabIndex = 24
        Me.edtOverPos.Text = "200.0"
        Me.edtOverPos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(9, 150)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(113, 12)
        Me.Label17.TabIndex = 25
        Me.Label17.Text = "Override Position  :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(265, 123)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(66, 12)
        Me.Label8.TabIndex = 23
        Me.Label8.Text = "Unit/Sec^2"
        '
        'edtMoveDec
        '
        Me.edtMoveDec.Location = New System.Drawing.Point(125, 118)
        Me.edtMoveDec.Name = "edtMoveDec"
        Me.edtMoveDec.Size = New System.Drawing.Size(137, 21)
        Me.edtMoveDec.TabIndex = 21
        Me.edtMoveDec.Text = "200.0"
        Me.edtMoveDec.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(9, 123)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(114, 12)
        Me.Label11.TabIndex = 22
        Me.Label11.Text = "Move Deceleration:"
        '
        'btnStop
        '
        Me.btnStop.Location = New System.Drawing.Point(336, 145)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(109, 48)
        Me.btnStop.TabIndex = 15
        Me.btnStop.Text = "Move Stop"
        Me.btnStop.UseVisualStyleBackColor = True
        '
        'btnOverVelAtPos
        '
        Me.btnOverVelAtPos.Location = New System.Drawing.Point(336, 64)
        Me.btnOverVelAtPos.Name = "btnOverVelAtPos"
        Me.btnOverVelAtPos.Size = New System.Drawing.Size(109, 75)
        Me.btnOverVelAtPos.TabIndex = 12
        Me.btnOverVelAtPos.Text = "Override At Pos"
        Me.btnOverVelAtPos.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(265, 96)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(66, 12)
        Me.Label15.TabIndex = 20
        Me.Label15.Text = "Unit/Sec^2"
        '
        'edtMoveAcc
        '
        Me.edtMoveAcc.Location = New System.Drawing.Point(125, 91)
        Me.edtMoveAcc.Name = "edtMoveAcc"
        Me.edtMoveAcc.Size = New System.Drawing.Size(137, 21)
        Me.edtMoveAcc.TabIndex = 10
        Me.edtMoveAcc.Text = "200.0"
        Me.edtMoveAcc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(9, 96)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(114, 12)
        Me.Label16.TabIndex = 18
        Me.Label16.Text = "Move Acceleration:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(265, 69)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(54, 12)
        Me.Label13.TabIndex = 17
        Me.Label13.Text = "Unit/Sec"
        '
        'edtMoveVel
        '
        Me.edtMoveVel.Location = New System.Drawing.Point(125, 64)
        Me.edtMoveVel.Name = "edtMoveVel"
        Me.edtMoveVel.Size = New System.Drawing.Size(137, 21)
        Me.edtMoveVel.TabIndex = 9
        Me.edtMoveVel.Text = "100.0"
        Me.edtMoveVel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(9, 69)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(113, 12)
        Me.Label14.TabIndex = 15
        Me.Label14.Text = "Move Velocity      :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(265, 42)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(26, 12)
        Me.Label9.TabIndex = 11
        Me.Label9.Text = "Unit"
        '
        'edtMovePos
        '
        Me.edtMovePos.Location = New System.Drawing.Point(125, 37)
        Me.edtMovePos.Name = "edtMovePos"
        Me.edtMovePos.Size = New System.Drawing.Size(137, 21)
        Me.edtMovePos.TabIndex = 7
        Me.edtMovePos.Text = "1000.0"
        Me.edtMovePos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(9, 42)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(114, 12)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "Target Position     :"
        '
        'rdoRel
        '
        Me.rdoRel.AutoSize = True
        Me.rdoRel.Location = New System.Drawing.Point(336, 40)
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
        Me.rdoAbs.Location = New System.Drawing.Point(336, 18)
        Me.rdoAbs.Name = "rdoAbs"
        Me.rdoAbs.Size = New System.Drawing.Size(100, 16)
        Me.rdoAbs.TabIndex = 4
        Me.rdoAbs.Tag = "rdoGroup"
        Me.rdoAbs.Text = "[00] Absolute"
        Me.rdoAbs.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.edtSetPos)
        Me.GroupBox1.Controls.Add(Me.chkServoOn)
        Me.GroupBox1.Controls.Add(Me.btnPosSet)
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
        Me.GroupBox1.TabIndex = 30
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Position Monitor"
        '
        'edtSetPos
        '
        Me.edtSetPos.Location = New System.Drawing.Point(336, 15)
        Me.edtSetPos.Name = "edtSetPos"
        Me.edtSetPos.Size = New System.Drawing.Size(109, 21)
        Me.edtSetPos.TabIndex = 24
        Me.edtSetPos.Text = "0.0"
        Me.edtSetPos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chkServoOn
        '
        Me.chkServoOn.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkServoOn.Location = New System.Drawing.Point(336, 69)
        Me.chkServoOn.Name = "chkServoOn"
        Me.chkServoOn.Size = New System.Drawing.Size(109, 20)
        Me.chkServoOn.TabIndex = 3
        Me.chkServoOn.Text = "Servo On"
        Me.chkServoOn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkServoOn.UseVisualStyleBackColor = True
        '
        'btnPosSet
        '
        Me.btnPosSet.Location = New System.Drawing.Point(336, 42)
        Me.btnPosSet.Name = "btnPosSet"
        Me.btnPosSet.Size = New System.Drawing.Size(109, 21)
        Me.btnPosSet.TabIndex = 2
        Me.btnPosSet.Text = "Position Setting"
        Me.btnPosSet.UseVisualStyleBackColor = True
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
        Me.stcCmdVel.Location = New System.Drawing.Point(125, 69)
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
        Me.Label7.Size = New System.Drawing.Size(117, 12)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Command Velocity:"
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
        Me.stcActPos.Location = New System.Drawing.Point(125, 42)
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
        Me.Label5.Size = New System.Drawing.Size(117, 12)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Feedback Position :"
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
        Me.stcCmdPos.Location = New System.Drawing.Point(125, 15)
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
        Me.Label2.Size = New System.Drawing.Size(117, 12)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Command Position:"
        '
        'chkOverMulti
        '
        Me.chkOverMulti.AutoSize = True
        Me.chkOverMulti.Location = New System.Drawing.Point(125, 18)
        Me.chkOverMulti.Name = "chkOverMulti"
        Me.chkOverMulti.Size = New System.Drawing.Size(191, 16)
        Me.chkOverMulti.TabIndex = 39
        Me.chkOverMulti.Text = "Override Vel At Multi Pos Use"
        Me.chkOverMulti.UseVisualStyleBackColor = True
        '
        'cboCampTarget
        '
        Me.cboCampTarget.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCampTarget.FormattingEnabled = True
        Me.cboCampTarget.Items.AddRange(New Object() {"00: COMMAND", "01: ACTUAL"})
        Me.cboCampTarget.Location = New System.Drawing.Point(125, 199)
        Me.cboCampTarget.Name = "cboCampTarget"
        Me.cboCampTarget.Size = New System.Drawing.Size(206, 20)
        Me.cboCampTarget.TabIndex = 31
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.PictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox2.Location = New System.Drawing.Point(125, 225)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(206, 3)
        Me.PictureBox2.TabIndex = 42
        Me.PictureBox2.TabStop = False
        '
        'cboOverMode
        '
        Me.cboOverMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOverMode.Enabled = False
        Me.cboOverMode.FormattingEnabled = True
        Me.cboOverMode.Items.AddRange(New Object() {"00: OVERRIDE_POS_START", "01: OVERRIDE_POS_END"})
        Me.cboOverMode.Location = New System.Drawing.Point(125, 233)
        Me.cboOverMode.Name = "cboOverMode"
        Me.cboOverMode.Size = New System.Drawing.Size(206, 20)
        Me.cboOverMode.TabIndex = 43
        '
        'lstOverData
        '
        Me.lstOverData.FormattingEnabled = True
        Me.lstOverData.ItemHeight = 12
        Me.lstOverData.Location = New System.Drawing.Point(125, 259)
        Me.lstOverData.Name = "lstOverData"
        Me.lstOverData.Size = New System.Drawing.Size(206, 76)
        Me.lstOverData.TabIndex = 44
        '
        'btnOverVelAtMPos
        '
        Me.btnOverVelAtMPos.Enabled = False
        Me.btnOverVelAtMPos.Location = New System.Drawing.Point(336, 199)
        Me.btnOverVelAtMPos.Name = "btnOverVelAtMPos"
        Me.btnOverVelAtMPos.Size = New System.Drawing.Size(109, 96)
        Me.btnOverVelAtMPos.TabIndex = 45
        Me.btnOverVelAtMPos.Text = "Multi At Pos"
        Me.btnOverVelAtMPos.UseVisualStyleBackColor = True
        '
        'btnOverDataClr
        '
        Me.btnOverDataClr.Enabled = False
        Me.btnOverDataClr.Location = New System.Drawing.Point(336, 301)
        Me.btnOverDataClr.Name = "btnOverDataClr"
        Me.btnOverDataClr.Size = New System.Drawing.Size(109, 34)
        Me.btnOverDataClr.TabIndex = 46
        Me.btnOverDataClr.Text = "All Clear Item"
        Me.btnOverDataClr.UseVisualStyleBackColor = True
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.PictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox3.Location = New System.Drawing.Point(11, 341)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(434, 3)
        Me.PictureBox3.TabIndex = 47
        Me.PictureBox3.TabStop = False
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(9, 355)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(114, 12)
        Me.Label20.TabIndex = 48
        Me.Label20.Text = "Override (Pos:Vel):"
        '
        'edtOverPosAdd
        '
        Me.edtOverPosAdd.Location = New System.Drawing.Point(125, 350)
        Me.edtOverPosAdd.Name = "edtOverPosAdd"
        Me.edtOverPosAdd.Size = New System.Drawing.Size(101, 21)
        Me.edtOverPosAdd.TabIndex = 49
        Me.edtOverPosAdd.Text = "300.0"
        Me.edtOverPosAdd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'edtOverVelAdd
        '
        Me.edtOverVelAdd.Location = New System.Drawing.Point(230, 350)
        Me.edtOverVelAdd.Name = "edtOverVelAdd"
        Me.edtOverVelAdd.Size = New System.Drawing.Size(101, 21)
        Me.edtOverVelAdd.TabIndex = 50
        Me.edtOverVelAdd.Text = "300.0"
        Me.edtOverVelAdd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnOverDataAdd
        '
        Me.btnOverDataAdd.Enabled = False
        Me.btnOverDataAdd.Location = New System.Drawing.Point(336, 350)
        Me.btnOverDataAdd.Name = "btnOverDataAdd"
        Me.btnOverDataAdd.Size = New System.Drawing.Size(109, 21)
        Me.btnOverDataAdd.TabIndex = 51
        Me.btnOverDataAdd.Text = "<< Add Item"
        Me.btnOverDataAdd.UseVisualStyleBackColor = True
        '
        'm_timer
        '
        Me.m_timer.Enabled = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'OverrideVelocityAtPos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(479, 545)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btnLoadFile)
        Me.Controls.Add(Me.cboSelAxis)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "OverrideVelocityAtPos"
        Me.Text = "OverrideVelocityAtPos"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnLoadFile As System.Windows.Forms.Button
    Friend WithEvents cboSelAxis As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnStop As System.Windows.Forms.Button
    Friend WithEvents btnOverVelAtPos As System.Windows.Forms.Button
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents edtMoveAcc As System.Windows.Forms.TextBox
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
    Friend WithEvents edtSetPos As System.Windows.Forms.TextBox
    Friend WithEvents chkServoOn As System.Windows.Forms.CheckBox
    Friend WithEvents btnPosSet As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents stcCmdVel As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents stcActPos As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents stcCmdPos As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents edtOverVel As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents edtOverPos As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents edtMoveDec As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents chkOverMulti As System.Windows.Forms.CheckBox
    Friend WithEvents cboCampTarget As System.Windows.Forms.ComboBox
    Friend WithEvents cboOverMode As System.Windows.Forms.ComboBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents lstOverData As System.Windows.Forms.ListBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents btnOverDataClr As System.Windows.Forms.Button
    Friend WithEvents btnOverVelAtMPos As System.Windows.Forms.Button
    Friend WithEvents btnOverDataAdd As System.Windows.Forms.Button
    Friend WithEvents edtOverVelAdd As System.Windows.Forms.TextBox
    Friend WithEvents edtOverPosAdd As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents m_timer As System.Windows.Forms.Timer
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog

End Class
