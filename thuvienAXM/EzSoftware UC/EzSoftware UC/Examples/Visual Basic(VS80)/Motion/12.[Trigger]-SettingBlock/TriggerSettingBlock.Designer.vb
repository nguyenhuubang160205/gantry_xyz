<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TriggerSettingBlock
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TriggerSettingBlock))
        Me.btnLoadFile = New System.Windows.Forms.Button()
        Me.cboSelAxis = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.chkSetBlock = New System.Windows.Forms.CheckBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.edtTrigStartPos = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.edtTrigPeriod = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.edtTrigEndPos = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.AxtMsg = New AxAXTMESSENGERLib.AxAxtMessenger()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.cboIntUse = New System.Windows.Forms.ComboBox()
        Me.stcIntCount = New System.Windows.Forms.TextBox()
        Me.cboTrigTarget = New System.Windows.Forms.ComboBox()
        Me.cboTrigLevel = New System.Windows.Forms.ComboBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.btnSetMethod = New System.Windows.Forms.Button()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.edtTrigTime = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnMoveStop = New System.Windows.Forms.Button()
        Me.btnMove = New System.Windows.Forms.Button()
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
        Me.m_timer = New System.Windows.Forms.Timer(Me.components)
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.AxtMsg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnLoadFile
        '
        Me.btnLoadFile.Location = New System.Drawing.Point(348, 15)
        Me.btnLoadFile.Name = "btnLoadFile"
        Me.btnLoadFile.Size = New System.Drawing.Size(109, 22)
        Me.btnLoadFile.TabIndex = 30
        Me.btnLoadFile.Text = "Load File"
        Me.btnLoadFile.UseVisualStyleBackColor = True
        '
        'cboSelAxis
        '
        Me.cboSelAxis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSelAxis.FormattingEnabled = True
        Me.cboSelAxis.Location = New System.Drawing.Point(141, 16)
        Me.cboSelAxis.Name = "cboSelAxis"
        Me.cboSelAxis.Size = New System.Drawing.Size(199, 20)
        Me.cboSelAxis.TabIndex = 29
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(21, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(117, 12)
        Me.Label1.TabIndex = 32
        Me.Label1.Text = "Select Axis No      :"
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Location = New System.Drawing.Point(12, 13)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(455, 27)
        Me.PictureBox1.TabIndex = 31
        Me.PictureBox1.TabStop = False
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.chkSetBlock)
        Me.GroupBox4.Controls.Add(Me.PictureBox4)
        Me.GroupBox4.Controls.Add(Me.edtTrigStartPos)
        Me.GroupBox4.Controls.Add(Me.Label18)
        Me.GroupBox4.Controls.Add(Me.edtTrigPeriod)
        Me.GroupBox4.Controls.Add(Me.Label23)
        Me.GroupBox4.Controls.Add(Me.Label8)
        Me.GroupBox4.Controls.Add(Me.edtTrigEndPos)
        Me.GroupBox4.Controls.Add(Me.Label11)
        Me.GroupBox4.Controls.Add(Me.Label12)
        Me.GroupBox4.Controls.Add(Me.Label17)
        Me.GroupBox4.Location = New System.Drawing.Point(12, 402)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(455, 107)
        Me.GroupBox4.TabIndex = 36
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "< Trigger Setting Block >"
        '
        'chkSetBlock
        '
        Me.chkSetBlock.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkSetBlock.Location = New System.Drawing.Point(336, 85)
        Me.chkSetBlock.Name = "chkSetBlock"
        Me.chkSetBlock.Size = New System.Drawing.Size(117, 20)
        Me.chkSetBlock.TabIndex = 46
        Me.chkSetBlock.Text = "Set Block"
        Me.chkSetBlock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkSetBlock.UseVisualStyleBackColor = True
        '
        'PictureBox4
        '
        Me.PictureBox4.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.PictureBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox4.Location = New System.Drawing.Point(336, 77)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(117, 3)
        Me.PictureBox4.TabIndex = 45
        Me.PictureBox4.TabStop = False
        '
        'edtTrigStartPos
        '
        Me.edtTrigStartPos.Location = New System.Drawing.Point(129, 20)
        Me.edtTrigStartPos.Name = "edtTrigStartPos"
        Me.edtTrigStartPos.Size = New System.Drawing.Size(130, 21)
        Me.edtTrigStartPos.TabIndex = 43
        Me.edtTrigStartPos.Text = "1000.0"
        Me.edtTrigStartPos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(263, 79)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(26, 12)
        Me.Label18.TabIndex = 35
        Me.Label18.Text = "Unit"
        '
        'edtTrigPeriod
        '
        Me.edtTrigPeriod.Location = New System.Drawing.Point(129, 74)
        Me.edtTrigPeriod.Name = "edtTrigPeriod"
        Me.edtTrigPeriod.Size = New System.Drawing.Size(130, 21)
        Me.edtTrigPeriod.TabIndex = 33
        Me.edtTrigPeriod.Text = "300.0"
        Me.edtTrigPeriod.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(9, 79)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(117, 12)
        Me.Label23.TabIndex = 34
        Me.Label23.Text = "Trigger Period       :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(263, 52)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(26, 12)
        Me.Label8.TabIndex = 32
        Me.Label8.Text = "Unit"
        '
        'edtTrigEndPos
        '
        Me.edtTrigEndPos.Location = New System.Drawing.Point(129, 47)
        Me.edtTrigEndPos.Name = "edtTrigEndPos"
        Me.edtTrigEndPos.Size = New System.Drawing.Size(130, 21)
        Me.edtTrigEndPos.TabIndex = 17
        Me.edtTrigEndPos.Text = "1000.0"
        Me.edtTrigEndPos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(9, 52)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(119, 12)
        Me.Label11.TabIndex = 30
        Me.Label11.Text = "Block End Position :"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(263, 25)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(26, 12)
        Me.Label12.TabIndex = 29
        Me.Label12.Text = "Unit"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(9, 25)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(118, 12)
        Me.Label17.TabIndex = 27
        Me.Label17.Text = "Block Start Position:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.AxtMsg)
        Me.GroupBox3.Controls.Add(Me.PictureBox3)
        Me.GroupBox3.Controls.Add(Me.PictureBox2)
        Me.GroupBox3.Controls.Add(Me.cboIntUse)
        Me.GroupBox3.Controls.Add(Me.stcIntCount)
        Me.GroupBox3.Controls.Add(Me.cboTrigTarget)
        Me.GroupBox3.Controls.Add(Me.cboTrigLevel)
        Me.GroupBox3.Controls.Add(Me.Label28)
        Me.GroupBox3.Controls.Add(Me.btnSetMethod)
        Me.GroupBox3.Controls.Add(Me.Label21)
        Me.GroupBox3.Controls.Add(Me.Label22)
        Me.GroupBox3.Controls.Add(Me.Label19)
        Me.GroupBox3.Controls.Add(Me.edtTrigTime)
        Me.GroupBox3.Controls.Add(Me.Label20)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 287)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(455, 106)
        Me.GroupBox3.TabIndex = 35
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "< Trigger Setting Method >"
        '
        'AxtMsg
        '
        Me.AxtMsg.Enabled = True
        Me.AxtMsg.Location = New System.Drawing.Point(421, 20)
        Me.AxtMsg.Name = "AxtMsg"
        Me.AxtMsg.OcxState = CType(resources.GetObject("AxtMsg.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxtMsg.Size = New System.Drawing.Size(24, 23)
        Me.AxtMsg.TabIndex = 47
        Me.AxtMsg.Visible = False
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.PictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox3.Location = New System.Drawing.Point(268, 20)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(3, 75)
        Me.PictureBox3.TabIndex = 43
        Me.PictureBox3.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.PictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox2.Location = New System.Drawing.Point(336, 76)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(117, 3)
        Me.PictureBox2.TabIndex = 44
        Me.PictureBox2.TabStop = False
        '
        'cboIntUse
        '
        Me.cboIntUse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboIntUse.FormattingEnabled = True
        Me.cboIntUse.Items.AddRange(New Object() {"00: DISABLE", "01: ENABLE"})
        Me.cboIntUse.Location = New System.Drawing.Point(336, 49)
        Me.cboIntUse.Name = "cboIntUse"
        Me.cboIntUse.Size = New System.Drawing.Size(109, 20)
        Me.cboIntUse.TabIndex = 36
        '
        'stcIntCount
        '
        Me.stcIntCount.Location = New System.Drawing.Point(336, 20)
        Me.stcIntCount.Name = "stcIntCount"
        Me.stcIntCount.ReadOnly = True
        Me.stcIntCount.Size = New System.Drawing.Size(109, 21)
        Me.stcIntCount.TabIndex = 24
        Me.stcIntCount.Text = "0"
        Me.stcIntCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cboTrigTarget
        '
        Me.cboTrigTarget.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTrigTarget.FormattingEnabled = True
        Me.cboTrigTarget.Items.AddRange(New Object() {"00: COMMAND", "01: ACTUAL"})
        Me.cboTrigTarget.Location = New System.Drawing.Point(129, 75)
        Me.cboTrigTarget.Name = "cboTrigTarget"
        Me.cboTrigTarget.Size = New System.Drawing.Size(130, 20)
        Me.cboTrigTarget.TabIndex = 35
        '
        'cboTrigLevel
        '
        Me.cboTrigLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTrigLevel.FormattingEnabled = True
        Me.cboTrigLevel.Items.AddRange(New Object() {"00: LOW", "01: HIGH"})
        Me.cboTrigLevel.Location = New System.Drawing.Point(129, 49)
        Me.cboTrigLevel.Name = "cboTrigLevel"
        Me.cboTrigLevel.Size = New System.Drawing.Size(130, 20)
        Me.cboTrigLevel.TabIndex = 34
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(9, 79)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(119, 12)
        Me.Label28.TabIndex = 33
        Me.Label28.Text = "Trigger Target Sel  :"
        '
        'btnSetMethod
        '
        Me.btnSetMethod.Location = New System.Drawing.Point(336, 85)
        Me.btnSetMethod.Name = "btnSetMethod"
        Me.btnSetMethod.Size = New System.Drawing.Size(119, 21)
        Me.btnSetMethod.TabIndex = 19
        Me.btnSetMethod.Text = "Set Method"
        Me.btnSetMethod.UseVisualStyleBackColor = True
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(277, 52)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(58, 12)
        Me.Label21.TabIndex = 32
        Me.Label21.Text = "Interrupt :"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(9, 52)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(117, 12)
        Me.Label22.TabIndex = 30
        Me.Label22.Text = "Trigger Level Set   :"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(277, 25)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(59, 12)
        Me.Label19.TabIndex = 29
        Me.Label19.Text = "Int Count:"
        '
        'edtTrigTime
        '
        Me.edtTrigTime.Location = New System.Drawing.Point(129, 20)
        Me.edtTrigTime.Name = "edtTrigTime"
        Me.edtTrigTime.Size = New System.Drawing.Size(130, 21)
        Me.edtTrigTime.TabIndex = 16
        Me.edtTrigTime.Text = "100.0"
        Me.edtTrigTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(9, 25)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(118, 12)
        Me.Label20.TabIndex = 27
        Me.Label20.Text = "Trigger Time(us)   :"
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
        Me.GroupBox1.TabIndex = 34
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Position Monitor"
        '
        'edtSetPos
        '
        Me.edtSetPos.Location = New System.Drawing.Point(336, 15)
        Me.edtSetPos.Name = "edtSetPos"
        Me.edtSetPos.Size = New System.Drawing.Size(109, 21)
        Me.edtSetPos.TabIndex = 24
        Me.edtSetPos.Text = "0.000"
        Me.edtSetPos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chkServoOn
        '
        Me.chkServoOn.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkServoOn.Location = New System.Drawing.Point(336, 66)
        Me.chkServoOn.Name = "chkServoOn"
        Me.chkServoOn.Size = New System.Drawing.Size(109, 24)
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
        Me.stcCmdVel.Location = New System.Drawing.Point(129, 69)
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
        Me.stcActPos.Location = New System.Drawing.Point(129, 42)
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
        Me.stcCmdPos.Location = New System.Drawing.Point(129, 15)
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
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnMoveStop)
        Me.GroupBox2.Controls.Add(Me.btnMove)
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
        Me.GroupBox2.TabIndex = 33
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Position Move"
        '
        'btnMoveStop
        '
        Me.btnMoveStop.Location = New System.Drawing.Point(336, 91)
        Me.btnMoveStop.Name = "btnMoveStop"
        Me.btnMoveStop.Size = New System.Drawing.Size(109, 21)
        Me.btnMoveStop.TabIndex = 15
        Me.btnMoveStop.Text = "Move SStop"
        Me.btnMoveStop.UseVisualStyleBackColor = True
        '
        'btnMove
        '
        Me.btnMove.Location = New System.Drawing.Point(336, 36)
        Me.btnMove.Name = "btnMove"
        Me.btnMove.Size = New System.Drawing.Size(109, 49)
        Me.btnMove.TabIndex = 12
        Me.btnMove.Text = "Move Target"
        Me.btnMove.UseVisualStyleBackColor = True
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
        Me.edtMoveAccDec.Location = New System.Drawing.Point(129, 91)
        Me.edtMoveAccDec.Name = "edtMoveAccDec"
        Me.edtMoveAccDec.Size = New System.Drawing.Size(130, 21)
        Me.edtMoveAccDec.TabIndex = 10
        Me.edtMoveAccDec.Text = "400.0"
        Me.edtMoveAccDec.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(9, 96)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(118, 12)
        Me.Label16.TabIndex = 18
        Me.Label16.Text = "Move Accel/Decel :"
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
        Me.edtMoveVel.Location = New System.Drawing.Point(129, 64)
        Me.edtMoveVel.Name = "edtMoveVel"
        Me.edtMoveVel.Size = New System.Drawing.Size(130, 21)
        Me.edtMoveVel.TabIndex = 9
        Me.edtMoveVel.Text = "100.0"
        Me.edtMoveVel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(9, 69)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(117, 12)
        Me.Label14.TabIndex = 15
        Me.Label14.Text = "Move Velocity       :"
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
        Me.edtMovePos.Location = New System.Drawing.Point(129, 37)
        Me.edtMovePos.Name = "edtMovePos"
        Me.edtMovePos.Size = New System.Drawing.Size(130, 21)
        Me.edtMovePos.TabIndex = 7
        Me.edtMovePos.Text = "100.0"
        Me.edtMovePos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(9, 42)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(118, 12)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "Target Position      :"
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
        Me.rdoAbs.Location = New System.Drawing.Point(133, 16)
        Me.rdoAbs.Name = "rdoAbs"
        Me.rdoAbs.Size = New System.Drawing.Size(100, 16)
        Me.rdoAbs.TabIndex = 4
        Me.rdoAbs.Tag = "rdoGroup"
        Me.rdoAbs.Text = "[00] Absolute"
        Me.rdoAbs.UseVisualStyleBackColor = True
        '
        'm_timer
        '
        Me.m_timer.Enabled = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'TriggerSettingBlock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(479, 519)
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
        Me.Name = "TriggerSettingBlock"
        Me.Text = "TriggerSettingBlock"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.AxtMsg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnLoadFile As System.Windows.Forms.Button
    Friend WithEvents cboSelAxis As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents edtTrigPeriod As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents edtTrigEndPos As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btnSetMethod As System.Windows.Forms.Button
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents edtTrigTime As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chkServoOn As System.Windows.Forms.CheckBox
    Friend WithEvents btnPosSet As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnMoveStop As System.Windows.Forms.Button
    Friend WithEvents btnMove As System.Windows.Forms.Button
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
    Friend WithEvents cboIntUse As System.Windows.Forms.ComboBox
    Friend WithEvents stcIntCount As System.Windows.Forms.TextBox
    Friend WithEvents cboTrigTarget As System.Windows.Forms.ComboBox
    Friend WithEvents cboTrigLevel As System.Windows.Forms.ComboBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents stcCmdVel As System.Windows.Forms.TextBox
    Friend WithEvents stcActPos As System.Windows.Forms.TextBox
    Friend WithEvents stcCmdPos As System.Windows.Forms.TextBox
    Friend WithEvents edtTrigStartPos As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents chkSetBlock As System.Windows.Forms.CheckBox
    Friend WithEvents edtSetPos As System.Windows.Forms.TextBox
    Friend WithEvents m_timer As System.Windows.Forms.Timer
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents AxtMsg As AxAXTMESSENGERLib.AxAxtMessenger

End Class
