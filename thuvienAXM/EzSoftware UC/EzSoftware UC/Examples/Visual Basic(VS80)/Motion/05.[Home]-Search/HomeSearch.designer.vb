<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HomeSearch
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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cboHomeLevel = New System.Windows.Forms.ComboBox()
        Me.chkHomeState = New System.Windows.Forms.CheckBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnSetMethod = New System.Windows.Forms.Button()
        Me.cboZPhaseUse = New System.Windows.Forms.ComboBox()
        Me.cboHomeSignal = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.cboHomeDir = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.edtHomeClrTime = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.edtHomeOffset = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.edtAccSecond = New System.Windows.Forms.TextBox()
        Me.edtAccFirst = New System.Windows.Forms.TextBox()
        Me.edtVelFirst = New System.Windows.Forms.TextBox()
        Me.edtVelLast = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.btnSetVelocity = New System.Windows.Forms.Button()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.edtVelThird = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.edtVelSecond = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.prgHomeRate = New System.Windows.Forms.ProgressBar()
        Me.stcHomeStepSub = New System.Windows.Forms.TextBox()
        Me.stcHomeStepMain = New System.Windows.Forms.TextBox()
        Me.btnMoveStop = New System.Windows.Forms.Button()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.btnHomeStart = New System.Windows.Forms.Button()
        Me.stcHomeResult = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.m_timerDisplay = New System.Windows.Forms.Timer(Me.components)
        Me.m_timerHomeInfo = New System.Windows.Forms.Timer(Me.components)
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnLoadFile
        '
        Me.btnLoadFile.Location = New System.Drawing.Point(344, 16)
        Me.btnLoadFile.Name = "btnLoadFile"
        Me.btnLoadFile.Size = New System.Drawing.Size(113, 22)
        Me.btnLoadFile.TabIndex = 2
        Me.btnLoadFile.Text = "Load File"
        Me.btnLoadFile.UseVisualStyleBackColor = True
        '
        'cboSelAxis
        '
        Me.cboSelAxis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSelAxis.FormattingEnabled = True
        Me.cboSelAxis.Location = New System.Drawing.Point(119, 17)
        Me.cboSelAxis.Name = "cboSelAxis"
        Me.cboSelAxis.Size = New System.Drawing.Size(220, 20)
        Me.cboSelAxis.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(21, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 12)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Select Axis No :"
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Location = New System.Drawing.Point(12, 13)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(455, 27)
        Me.PictureBox1.TabIndex = 8
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
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Position Monitor"
        '
        'chkServoOn
        '
        Me.chkServoOn.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkServoOn.Location = New System.Drawing.Point(332, 68)
        Me.chkServoOn.Name = "chkServoOn"
        Me.chkServoOn.Size = New System.Drawing.Size(113, 24)
        Me.chkServoOn.TabIndex = 4
        Me.chkServoOn.Text = "Servo On"
        Me.chkServoOn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkServoOn.UseVisualStyleBackColor = True
        '
        'btnPosClear
        '
        Me.btnPosClear.Location = New System.Drawing.Point(332, 15)
        Me.btnPosClear.Name = "btnPosClear"
        Me.btnPosClear.Size = New System.Drawing.Size(113, 44)
        Me.btnPosClear.TabIndex = 3
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
        Me.stcCmdVel.Location = New System.Drawing.Point(107, 69)
        Me.stcCmdVel.Name = "stcCmdVel"
        Me.stcCmdVel.ReadOnly = True
        Me.stcCmdVel.Size = New System.Drawing.Size(150, 21)
        Me.stcCmdVel.TabIndex = 7
        Me.stcCmdVel.Text = "0.000"
        Me.stcCmdVel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(9, 74)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(94, 12)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Command Vel :"
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
        Me.stcActPos.Location = New System.Drawing.Point(107, 42)
        Me.stcActPos.Name = "stcActPos"
        Me.stcActPos.ReadOnly = True
        Me.stcActPos.Size = New System.Drawing.Size(150, 21)
        Me.stcActPos.TabIndex = 4
        Me.stcActPos.Text = "0.000"
        Me.stcActPos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(9, 47)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(94, 12)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Feedback Pos :"
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
        Me.stcCmdPos.Location = New System.Drawing.Point(107, 15)
        Me.stcCmdPos.Name = "stcCmdPos"
        Me.stcCmdPos.ReadOnly = True
        Me.stcCmdPos.Size = New System.Drawing.Size(150, 21)
        Me.stcCmdPos.TabIndex = 1
        Me.stcCmdPos.Text = "0.000"
        Me.stcCmdPos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(98, 12)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Command Pos :"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.PictureBox2)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.cboHomeLevel)
        Me.GroupBox2.Controls.Add(Me.chkHomeState)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 157)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(455, 46)
        Me.GroupBox2.TabIndex = 13
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "< Home Signal Level >"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.PictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox2.Location = New System.Drawing.Point(233, 16)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(3, 20)
        Me.PictureBox2.TabIndex = 15
        Me.PictureBox2.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(242, 21)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(88, 12)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Home Level   :"
        '
        'cboHomeLevel
        '
        Me.cboHomeLevel.FormattingEnabled = True
        Me.cboHomeLevel.Location = New System.Drawing.Point(332, 16)
        Me.cboHomeLevel.Name = "cboHomeLevel"
        Me.cboHomeLevel.Size = New System.Drawing.Size(113, 20)
        Me.cboHomeLevel.TabIndex = 5
        '
        'chkHomeState
        '
        Me.chkHomeState.AutoSize = True
        Me.chkHomeState.Enabled = False
        Me.chkHomeState.Location = New System.Drawing.Point(11, 20)
        Me.chkHomeState.Name = "chkHomeState"
        Me.chkHomeState.Size = New System.Drawing.Size(128, 16)
        Me.chkHomeState.TabIndex = 0
        Me.chkHomeState.Text = "Home Signal State"
        Me.chkHomeState.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnSetMethod)
        Me.GroupBox3.Controls.Add(Me.cboZPhaseUse)
        Me.GroupBox3.Controls.Add(Me.cboHomeSignal)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.PictureBox3)
        Me.GroupBox3.Controls.Add(Me.cboHomeDir)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.edtHomeClrTime)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.edtHomeOffset)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 212)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(455, 99)
        Me.GroupBox3.TabIndex = 14
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "< Home Method Setting >"
        '
        'btnSetMethod
        '
        Me.btnSetMethod.Location = New System.Drawing.Point(332, 76)
        Me.btnSetMethod.Name = "btnSetMethod"
        Me.btnSetMethod.Size = New System.Drawing.Size(123, 23)
        Me.btnSetMethod.TabIndex = 11
        Me.btnSetMethod.Text = "Set Method"
        Me.btnSetMethod.UseVisualStyleBackColor = True
        '
        'cboZPhaseUse
        '
        Me.cboZPhaseUse.FormattingEnabled = True
        Me.cboZPhaseUse.Location = New System.Drawing.Point(332, 43)
        Me.cboZPhaseUse.Name = "cboZPhaseUse"
        Me.cboZPhaseUse.Size = New System.Drawing.Size(113, 20)
        Me.cboZPhaseUse.TabIndex = 10
        '
        'cboHomeSignal
        '
        Me.cboHomeSignal.FormattingEnabled = True
        Me.cboHomeSignal.Location = New System.Drawing.Point(332, 15)
        Me.cboHomeSignal.Name = "cboHomeSignal"
        Me.cboHomeSignal.Size = New System.Drawing.Size(113, 20)
        Me.cboHomeSignal.TabIndex = 9
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(242, 47)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(87, 12)
        Me.Label13.TabIndex = 17
        Me.Label13.Text = "Z Phase Use :"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(242, 20)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(89, 12)
        Me.Label11.TabIndex = 16
        Me.Label11.Text = "Home Signal  :"
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.PictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox3.Location = New System.Drawing.Point(233, 15)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(3, 47)
        Me.PictureBox3.TabIndex = 16
        Me.PictureBox3.TabStop = False
        '
        'cboHomeDir
        '
        Me.cboHomeDir.DisplayMember = "00: -DIR_CCW;01: +DIR_CW;"
        Me.cboHomeDir.FormattingEnabled = True
        Me.cboHomeDir.Location = New System.Drawing.Point(107, 15)
        Me.cboHomeDir.Name = "cboHomeDir"
        Me.cboHomeDir.Size = New System.Drawing.Size(120, 20)
        Me.cboHomeDir.TabIndex = 6
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(231, 74)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(38, 12)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "mSec"
        '
        'edtHomeClrTime
        '
        Me.edtHomeClrTime.Location = New System.Drawing.Point(107, 69)
        Me.edtHomeClrTime.Name = "edtHomeClrTime"
        Me.edtHomeClrTime.Size = New System.Drawing.Size(120, 21)
        Me.edtHomeClrTime.TabIndex = 8
        Me.edtHomeClrTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(9, 74)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(99, 12)
        Me.Label10.TabIndex = 6
        Me.Label10.Text = "Home Clr Time :"
        '
        'edtHomeOffset
        '
        Me.edtHomeOffset.Location = New System.Drawing.Point(107, 42)
        Me.edtHomeOffset.Name = "edtHomeOffset"
        Me.edtHomeOffset.Size = New System.Drawing.Size(120, 21)
        Me.edtHomeOffset.TabIndex = 7
        Me.edtHomeOffset.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(9, 47)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(100, 12)
        Me.Label12.TabIndex = 3
        Me.Label12.Text = "Home Set Offset:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(9, 20)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(99, 12)
        Me.Label14.TabIndex = 0
        Me.Label14.Text = "Home Direction :"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.edtAccSecond)
        Me.GroupBox4.Controls.Add(Me.edtAccFirst)
        Me.GroupBox4.Controls.Add(Me.edtVelFirst)
        Me.GroupBox4.Controls.Add(Me.edtVelLast)
        Me.GroupBox4.Controls.Add(Me.Label21)
        Me.GroupBox4.Controls.Add(Me.btnSetVelocity)
        Me.GroupBox4.Controls.Add(Me.Label15)
        Me.GroupBox4.Controls.Add(Me.Label16)
        Me.GroupBox4.Controls.Add(Me.PictureBox4)
        Me.GroupBox4.Controls.Add(Me.edtVelThird)
        Me.GroupBox4.Controls.Add(Me.Label18)
        Me.GroupBox4.Controls.Add(Me.edtVelSecond)
        Me.GroupBox4.Controls.Add(Me.Label19)
        Me.GroupBox4.Controls.Add(Me.Label20)
        Me.GroupBox4.Location = New System.Drawing.Point(12, 320)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(455, 125)
        Me.GroupBox4.TabIndex = 19
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "< Home Velocity Setting >"
        '
        'edtAccSecond
        '
        Me.edtAccSecond.Location = New System.Drawing.Point(332, 42)
        Me.edtAccSecond.Name = "edtAccSecond"
        Me.edtAccSecond.Size = New System.Drawing.Size(113, 21)
        Me.edtAccSecond.TabIndex = 17
        Me.edtAccSecond.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'edtAccFirst
        '
        Me.edtAccFirst.Location = New System.Drawing.Point(332, 15)
        Me.edtAccFirst.Name = "edtAccFirst"
        Me.edtAccFirst.Size = New System.Drawing.Size(113, 21)
        Me.edtAccFirst.TabIndex = 16
        Me.edtAccFirst.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'edtVelFirst
        '
        Me.edtVelFirst.Location = New System.Drawing.Point(107, 15)
        Me.edtVelFirst.Name = "edtVelFirst"
        Me.edtVelFirst.Size = New System.Drawing.Size(120, 21)
        Me.edtVelFirst.TabIndex = 12
        Me.edtVelFirst.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'edtVelLast
        '
        Me.edtVelLast.Location = New System.Drawing.Point(107, 96)
        Me.edtVelLast.Name = "edtVelLast"
        Me.edtVelLast.Size = New System.Drawing.Size(120, 21)
        Me.edtVelLast.TabIndex = 15
        Me.edtVelLast.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(9, 101)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(98, 12)
        Me.Label21.TabIndex = 19
        Me.Label21.Text = "Last Velocity    :"
        '
        'btnSetVelocity
        '
        Me.btnSetVelocity.Location = New System.Drawing.Point(332, 102)
        Me.btnSetVelocity.Name = "btnSetVelocity"
        Me.btnSetVelocity.Size = New System.Drawing.Size(123, 23)
        Me.btnSetVelocity.TabIndex = 18
        Me.btnSetVelocity.Text = "Set Velocity"
        Me.btnSetVelocity.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(242, 47)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(92, 12)
        Me.Label15.TabIndex = 17
        Me.Label15.Text = "Second Accel :"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(242, 20)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(93, 12)
        Me.Label16.TabIndex = 16
        Me.Label16.Text = "First Accel      :"
        '
        'PictureBox4
        '
        Me.PictureBox4.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.PictureBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox4.Location = New System.Drawing.Point(233, 15)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(3, 102)
        Me.PictureBox4.TabIndex = 16
        Me.PictureBox4.TabStop = False
        '
        'edtVelThird
        '
        Me.edtVelThird.Location = New System.Drawing.Point(107, 69)
        Me.edtVelThird.Name = "edtVelThird"
        Me.edtVelThird.Size = New System.Drawing.Size(120, 21)
        Me.edtVelThird.TabIndex = 14
        Me.edtVelThird.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(9, 74)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(99, 12)
        Me.Label18.TabIndex = 6
        Me.Label18.Text = "Third Velocity   :"
        '
        'edtVelSecond
        '
        Me.edtVelSecond.Location = New System.Drawing.Point(107, 42)
        Me.edtVelSecond.Name = "edtVelSecond"
        Me.edtVelSecond.Size = New System.Drawing.Size(120, 21)
        Me.edtVelSecond.TabIndex = 13
        Me.edtVelSecond.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(9, 47)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(101, 12)
        Me.Label19.TabIndex = 3
        Me.Label19.Text = "Second Velocity:"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(9, 20)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(98, 12)
        Me.Label20.TabIndex = 0
        Me.Label20.Text = "First Velocity    :"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.prgHomeRate)
        Me.GroupBox5.Controls.Add(Me.stcHomeStepSub)
        Me.GroupBox5.Controls.Add(Me.stcHomeStepMain)
        Me.GroupBox5.Controls.Add(Me.btnMoveStop)
        Me.GroupBox5.Controls.Add(Me.Label22)
        Me.GroupBox5.Controls.Add(Me.btnHomeStart)
        Me.GroupBox5.Controls.Add(Me.stcHomeResult)
        Me.GroupBox5.Controls.Add(Me.Label17)
        Me.GroupBox5.Location = New System.Drawing.Point(12, 454)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(455, 73)
        Me.GroupBox5.TabIndex = 20
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "< Home Search >"
        '
        'prgHomeRate
        '
        Me.prgHomeRate.Location = New System.Drawing.Point(171, 41)
        Me.prgHomeRate.Name = "prgHomeRate"
        Me.prgHomeRate.Size = New System.Drawing.Size(156, 21)
        Me.prgHomeRate.Step = 1
        Me.prgHomeRate.TabIndex = 31
        '
        'stcHomeStepSub
        '
        Me.stcHomeStepSub.Location = New System.Drawing.Point(139, 41)
        Me.stcHomeStepSub.Name = "stcHomeStepSub"
        Me.stcHomeStepSub.ReadOnly = True
        Me.stcHomeStepSub.Size = New System.Drawing.Size(30, 21)
        Me.stcHomeStepSub.TabIndex = 30
        '
        'stcHomeStepMain
        '
        Me.stcHomeStepMain.Location = New System.Drawing.Point(107, 41)
        Me.stcHomeStepMain.Name = "stcHomeStepMain"
        Me.stcHomeStepMain.ReadOnly = True
        Me.stcHomeStepMain.Size = New System.Drawing.Size(30, 21)
        Me.stcHomeStepMain.TabIndex = 29
        '
        'btnMoveStop
        '
        Me.btnMoveStop.Location = New System.Drawing.Point(332, 41)
        Me.btnMoveStop.Name = "btnMoveStop"
        Me.btnMoveStop.Size = New System.Drawing.Size(113, 23)
        Me.btnMoveStop.TabIndex = 20
        Me.btnMoveStop.Text = "Move Stop"
        Me.btnMoveStop.UseVisualStyleBackColor = True
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(9, 47)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(102, 12)
        Me.Label22.TabIndex = 27
        Me.Label22.Text = "Home Step/Rate:"
        '
        'btnHomeStart
        '
        Me.btnHomeStart.Location = New System.Drawing.Point(332, 14)
        Me.btnHomeStart.Name = "btnHomeStart"
        Me.btnHomeStart.Size = New System.Drawing.Size(113, 23)
        Me.btnHomeStart.TabIndex = 19
        Me.btnHomeStart.Text = "Home Start"
        Me.btnHomeStart.UseVisualStyleBackColor = True
        '
        'stcHomeResult
        '
        Me.stcHomeResult.Location = New System.Drawing.Point(107, 15)
        Me.stcHomeResult.Name = "stcHomeResult"
        Me.stcHomeResult.ReadOnly = True
        Me.stcHomeResult.Size = New System.Drawing.Size(220, 21)
        Me.stcHomeResult.TabIndex = 26
        Me.stcHomeResult.Text = " [FFH] HOME_ERR_UNKNOWN"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(9, 20)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(97, 12)
        Me.Label17.TabIndex = 24
        Me.Label17.Text = "Home Result    :"
        '
        'm_timerDisplay
        '
        Me.m_timerDisplay.Enabled = True
        '
        'm_timerHomeInfo
        '
        Me.m_timerHomeInfo.Enabled = True
        Me.m_timerHomeInfo.Interval = 200
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'HomeSearch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(479, 537)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnLoadFile)
        Me.Controls.Add(Me.cboSelAxis)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Name = "HomeSearch"
        Me.Text = "HomeSearch"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnLoadFile As System.Windows.Forms.Button
    Friend WithEvents cboSelAxis As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents stcCmdVel As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents stcActPos As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents stcCmdPos As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnPosClear As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboHomeLevel As System.Windows.Forms.ComboBox
    Friend WithEvents chkHomeState As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cboHomeDir As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents edtHomeClrTime As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents edtHomeOffset As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents cboZPhaseUse As System.Windows.Forms.ComboBox
    Friend WithEvents cboHomeSignal As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents btnSetMethod As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents edtAccSecond As System.Windows.Forms.TextBox
    Friend WithEvents edtAccFirst As System.Windows.Forms.TextBox
    Friend WithEvents edtVelFirst As System.Windows.Forms.TextBox
    Friend WithEvents edtVelLast As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents btnSetVelocity As System.Windows.Forms.Button
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents edtVelThird As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents edtVelSecond As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents btnMoveStop As System.Windows.Forms.Button
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents btnHomeStart As System.Windows.Forms.Button
    Friend WithEvents stcHomeResult As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents prgHomeRate As System.Windows.Forms.ProgressBar
    Friend WithEvents stcHomeStepSub As System.Windows.Forms.TextBox
    Friend WithEvents stcHomeStepMain As System.Windows.Forms.TextBox
    Friend WithEvents m_timerDisplay As System.Windows.Forms.Timer
    Friend WithEvents m_timerHomeInfo As System.Windows.Forms.Timer
    Friend WithEvents chkServoOn As System.Windows.Forms.CheckBox
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog

End Class
