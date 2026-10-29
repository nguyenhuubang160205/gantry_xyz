<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SignalMonitor
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
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboSelAxis = New System.Windows.Forms.ComboBox()
        Me.btnLoadFile = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cboELimitP = New System.Windows.Forms.ComboBox()
        Me.chkELimitP = New System.Windows.Forms.CheckBox()
        Me.cboEmg = New System.Windows.Forms.ComboBox()
        Me.chkEmg = New System.Windows.Forms.CheckBox()
        Me.cboInp = New System.Windows.Forms.ComboBox()
        Me.chkInp = New System.Windows.Forms.CheckBox()
        Me.cboELimitN = New System.Windows.Forms.ComboBox()
        Me.chkELimitN = New System.Windows.Forms.CheckBox()
        Me.cboAlarm = New System.Windows.Forms.ComboBox()
        Me.chkAlarm = New System.Windows.Forms.CheckBox()
        Me.cboZPhase = New System.Windows.Forms.ComboBox()
        Me.chkZPhase = New System.Windows.Forms.CheckBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboAlarmReset = New System.Windows.Forms.ComboBox()
        Me.cboServoOn = New System.Windows.Forms.ComboBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.chkOut04 = New System.Windows.Forms.CheckBox()
        Me.chkOut03 = New System.Windows.Forms.CheckBox()
        Me.chkOut02 = New System.Windows.Forms.CheckBox()
        Me.chkOut01 = New System.Windows.Forms.CheckBox()
        Me.chkOut00 = New System.Windows.Forms.CheckBox()
        Me.chkInp04 = New System.Windows.Forms.CheckBox()
        Me.chkInp03 = New System.Windows.Forms.CheckBox()
        Me.chkInp02 = New System.Windows.Forms.CheckBox()
        Me.chkInp01 = New System.Windows.Forms.CheckBox()
        Me.chkInp00 = New System.Windows.Forms.CheckBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.chkSWEnable = New System.Windows.Forms.CheckBox()
        Me.edtSWPosP = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cboSWRef = New System.Windows.Forms.ComboBox()
        Me.chkSWLimitP = New System.Windows.Forms.CheckBox()
        Me.edtSWPosN = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.chkSWLimitN = New System.Windows.Forms.CheckBox()
        Me.cboSWStop = New System.Windows.Forms.ComboBox()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.CommonDialog1Open = New System.Windows.Forms.OpenFileDialog()
        Me.m_timer = New System.Windows.Forms.Timer(Me.components)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(455, 25)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 12)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Select Axis No :"
        '
        'cboSelAxis
        '
        Me.cboSelAxis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSelAxis.FormattingEnabled = True
        Me.cboSelAxis.Location = New System.Drawing.Point(120, 15)
        Me.cboSelAxis.Name = "cboSelAxis"
        Me.cboSelAxis.Size = New System.Drawing.Size(220, 20)
        Me.cboSelAxis.TabIndex = 2
        '
        'btnLoadFile
        '
        Me.btnLoadFile.Location = New System.Drawing.Point(345, 14)
        Me.btnLoadFile.Name = "btnLoadFile"
        Me.btnLoadFile.Size = New System.Drawing.Size(113, 23)
        Me.btnLoadFile.TabIndex = 3
        Me.btnLoadFile.Text = "Load File"
        Me.btnLoadFile.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cboELimitP)
        Me.GroupBox2.Controls.Add(Me.chkELimitP)
        Me.GroupBox2.Controls.Add(Me.cboEmg)
        Me.GroupBox2.Controls.Add(Me.chkEmg)
        Me.GroupBox2.Controls.Add(Me.cboInp)
        Me.GroupBox2.Controls.Add(Me.chkInp)
        Me.GroupBox2.Controls.Add(Me.cboELimitN)
        Me.GroupBox2.Controls.Add(Me.chkELimitN)
        Me.GroupBox2.Controls.Add(Me.cboAlarm)
        Me.GroupBox2.Controls.Add(Me.chkAlarm)
        Me.GroupBox2.Controls.Add(Me.cboZPhase)
        Me.GroupBox2.Controls.Add(Me.chkZPhase)
        Me.GroupBox2.Controls.Add(Me.PictureBox2)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 46)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(455, 96)
        Me.GroupBox2.TabIndex = 10
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "< Input Signal monitor >"
        '
        'cboELimitP
        '
        Me.cboELimitP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboELimitP.FormattingEnabled = True
        Me.cboELimitP.Location = New System.Drawing.Point(333, 66)
        Me.cboELimitP.Name = "cboELimitP"
        Me.cboELimitP.Size = New System.Drawing.Size(111, 20)
        Me.cboELimitP.TabIndex = 21
        '
        'chkELimitP
        '
        Me.chkELimitP.AutoSize = True
        Me.chkELimitP.Enabled = False
        Me.chkELimitP.Location = New System.Drawing.Point(237, 68)
        Me.chkELimitP.Name = "chkELimitP"
        Me.chkELimitP.Size = New System.Drawing.Size(101, 16)
        Me.chkELimitP.TabIndex = 20
        Me.chkELimitP.Text = "(+) End Limit:"
        Me.chkELimitP.UseVisualStyleBackColor = True
        '
        'cboEmg
        '
        Me.cboEmg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEmg.FormattingEnabled = True
        Me.cboEmg.Location = New System.Drawing.Point(333, 42)
        Me.cboEmg.Name = "cboEmg"
        Me.cboEmg.Size = New System.Drawing.Size(111, 20)
        Me.cboEmg.TabIndex = 19
        '
        'chkEmg
        '
        Me.chkEmg.AutoSize = True
        Me.chkEmg.Enabled = False
        Me.chkEmg.Location = New System.Drawing.Point(237, 44)
        Me.chkEmg.Name = "chkEmg"
        Me.chkEmg.Size = New System.Drawing.Size(97, 16)
        Me.chkEmg.TabIndex = 18
        Me.chkEmg.Text = "Emergency :"
        Me.chkEmg.UseVisualStyleBackColor = True
        '
        'cboInp
        '
        Me.cboInp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboInp.FormattingEnabled = True
        Me.cboInp.Location = New System.Drawing.Point(333, 18)
        Me.cboInp.Name = "cboInp"
        Me.cboInp.Size = New System.Drawing.Size(111, 20)
        Me.cboInp.TabIndex = 17
        '
        'chkInp
        '
        Me.chkInp.AutoSize = True
        Me.chkInp.Enabled = False
        Me.chkInp.Location = New System.Drawing.Point(237, 20)
        Me.chkInp.Name = "chkInp"
        Me.chkInp.Size = New System.Drawing.Size(98, 16)
        Me.chkInp.TabIndex = 16
        Me.chkInp.Text = "Inposition    :"
        Me.chkInp.UseVisualStyleBackColor = True
        '
        'cboELimitN
        '
        Me.cboELimitN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboELimitN.FormattingEnabled = True
        Me.cboELimitN.Location = New System.Drawing.Point(108, 66)
        Me.cboELimitN.Name = "cboELimitN"
        Me.cboELimitN.Size = New System.Drawing.Size(111, 20)
        Me.cboELimitN.TabIndex = 15
        '
        'chkELimitN
        '
        Me.chkELimitN.AutoSize = True
        Me.chkELimitN.Enabled = False
        Me.chkELimitN.Location = New System.Drawing.Point(12, 68)
        Me.chkELimitN.Name = "chkELimitN"
        Me.chkELimitN.Size = New System.Drawing.Size(101, 16)
        Me.chkELimitN.TabIndex = 14
        Me.chkELimitN.Text = "(-) End Limit:"
        Me.chkELimitN.UseVisualStyleBackColor = True
        '
        'cboAlarm
        '
        Me.cboAlarm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAlarm.FormattingEnabled = True
        Me.cboAlarm.Location = New System.Drawing.Point(108, 42)
        Me.cboAlarm.Name = "cboAlarm"
        Me.cboAlarm.Size = New System.Drawing.Size(111, 20)
        Me.cboAlarm.TabIndex = 13
        '
        'chkAlarm
        '
        Me.chkAlarm.AutoSize = True
        Me.chkAlarm.Enabled = False
        Me.chkAlarm.Location = New System.Drawing.Point(12, 44)
        Me.chkAlarm.Name = "chkAlarm"
        Me.chkAlarm.Size = New System.Drawing.Size(97, 16)
        Me.chkAlarm.TabIndex = 12
        Me.chkAlarm.Text = "Servo Alarm:"
        Me.chkAlarm.UseVisualStyleBackColor = True
        '
        'cboZPhase
        '
        Me.cboZPhase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboZPhase.FormattingEnabled = True
        Me.cboZPhase.Location = New System.Drawing.Point(108, 18)
        Me.cboZPhase.Name = "cboZPhase"
        Me.cboZPhase.Size = New System.Drawing.Size(111, 20)
        Me.cboZPhase.TabIndex = 11
        '
        'chkZPhase
        '
        Me.chkZPhase.AutoSize = True
        Me.chkZPhase.Enabled = False
        Me.chkZPhase.Location = New System.Drawing.Point(12, 20)
        Me.chkZPhase.Name = "chkZPhase"
        Me.chkZPhase.Size = New System.Drawing.Size(96, 16)
        Me.chkZPhase.TabIndex = 11
        Me.chkZPhase.Text = "Z Phase     :"
        Me.chkZPhase.UseVisualStyleBackColor = True
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.PictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox2.Location = New System.Drawing.Point(225, 18)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(5, 68)
        Me.PictureBox2.TabIndex = 10
        Me.PictureBox2.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cboAlarmReset)
        Me.GroupBox1.Controls.Add(Me.cboServoOn)
        Me.GroupBox1.Controls.Add(Me.PictureBox3)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 148)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(455, 46)
        Me.GroupBox1.TabIndex = 22
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "< Output Signal monitor >"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(235, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(101, 12)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "Alm Reset Level:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(99, 12)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "Servo On Level :"
        '
        'cboAlarmReset
        '
        Me.cboAlarmReset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAlarmReset.FormattingEnabled = True
        Me.cboAlarmReset.Location = New System.Drawing.Point(333, 18)
        Me.cboAlarmReset.Name = "cboAlarmReset"
        Me.cboAlarmReset.Size = New System.Drawing.Size(111, 20)
        Me.cboAlarmReset.TabIndex = 17
        '
        'cboServoOn
        '
        Me.cboServoOn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboServoOn.FormattingEnabled = True
        Me.cboServoOn.Location = New System.Drawing.Point(108, 18)
        Me.cboServoOn.Name = "cboServoOn"
        Me.cboServoOn.Size = New System.Drawing.Size(111, 20)
        Me.cboServoOn.TabIndex = 11
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.PictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox3.Location = New System.Drawing.Point(225, 18)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(5, 20)
        Me.PictureBox3.TabIndex = 10
        Me.PictureBox3.TabStop = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.chkOut04)
        Me.GroupBox3.Controls.Add(Me.chkOut03)
        Me.GroupBox3.Controls.Add(Me.chkOut02)
        Me.GroupBox3.Controls.Add(Me.chkOut01)
        Me.GroupBox3.Controls.Add(Me.chkOut00)
        Me.GroupBox3.Controls.Add(Me.chkInp04)
        Me.GroupBox3.Controls.Add(Me.chkInp03)
        Me.GroupBox3.Controls.Add(Me.chkInp02)
        Me.GroupBox3.Controls.Add(Me.chkInp01)
        Me.GroupBox3.Controls.Add(Me.chkInp00)
        Me.GroupBox3.Controls.Add(Me.PictureBox4)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 200)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(455, 141)
        Me.GroupBox3.TabIndex = 22
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "< Input Signal monitor >"
        '
        'chkOut04
        '
        Me.chkOut04.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkOut04.Location = New System.Drawing.Point(237, 112)
        Me.chkOut04.Name = "chkOut04"
        Me.chkOut04.Size = New System.Drawing.Size(207, 20)
        Me.chkOut04.TabIndex = 20
        Me.chkOut04.Text = "  Output Bit 04"
        Me.chkOut04.UseVisualStyleBackColor = True
        '
        'chkOut03
        '
        Me.chkOut03.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkOut03.Location = New System.Drawing.Point(237, 89)
        Me.chkOut03.Name = "chkOut03"
        Me.chkOut03.Size = New System.Drawing.Size(207, 20)
        Me.chkOut03.TabIndex = 19
        Me.chkOut03.Text = "  Output Bit 03"
        Me.chkOut03.UseVisualStyleBackColor = True
        '
        'chkOut02
        '
        Me.chkOut02.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkOut02.Location = New System.Drawing.Point(237, 66)
        Me.chkOut02.Name = "chkOut02"
        Me.chkOut02.Size = New System.Drawing.Size(207, 20)
        Me.chkOut02.TabIndex = 18
        Me.chkOut02.Text = "  Output Bit 02"
        Me.chkOut02.UseVisualStyleBackColor = True
        '
        'chkOut01
        '
        Me.chkOut01.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkOut01.Location = New System.Drawing.Point(237, 43)
        Me.chkOut01.Name = "chkOut01"
        Me.chkOut01.Size = New System.Drawing.Size(207, 20)
        Me.chkOut01.TabIndex = 17
        Me.chkOut01.Text = "  Output Bit 01 (Alarm Clear)"
        Me.chkOut01.UseVisualStyleBackColor = True
        '
        'chkOut00
        '
        Me.chkOut00.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkOut00.Location = New System.Drawing.Point(237, 20)
        Me.chkOut00.Name = "chkOut00"
        Me.chkOut00.Size = New System.Drawing.Size(207, 20)
        Me.chkOut00.TabIndex = 16
        Me.chkOut00.Text = "  Output Bit 00 (Servo On)"
        Me.chkOut00.UseVisualStyleBackColor = True
        '
        'chkInp04
        '
        Me.chkInp04.Enabled = False
        Me.chkInp04.Location = New System.Drawing.Point(12, 112)
        Me.chkInp04.Name = "chkInp04"
        Me.chkInp04.Size = New System.Drawing.Size(85, 20)
        Me.chkInp04.TabIndex = 15
        Me.chkInp04.Text = "Input Bit 04"
        Me.chkInp04.UseVisualStyleBackColor = True
        '
        'chkInp03
        '
        Me.chkInp03.Enabled = False
        Me.chkInp03.Location = New System.Drawing.Point(12, 89)
        Me.chkInp03.Name = "chkInp03"
        Me.chkInp03.Size = New System.Drawing.Size(85, 20)
        Me.chkInp03.TabIndex = 14
        Me.chkInp03.Text = "Input Bit 03"
        Me.chkInp03.UseVisualStyleBackColor = True
        '
        'chkInp02
        '
        Me.chkInp02.Enabled = False
        Me.chkInp02.Location = New System.Drawing.Point(12, 66)
        Me.chkInp02.Name = "chkInp02"
        Me.chkInp02.Size = New System.Drawing.Size(85, 20)
        Me.chkInp02.TabIndex = 13
        Me.chkInp02.Text = "Input Bit 02"
        Me.chkInp02.UseVisualStyleBackColor = True
        '
        'chkInp01
        '
        Me.chkInp01.Enabled = False
        Me.chkInp01.Location = New System.Drawing.Point(12, 43)
        Me.chkInp01.Name = "chkInp01"
        Me.chkInp01.Size = New System.Drawing.Size(149, 20)
        Me.chkInp01.TabIndex = 12
        Me.chkInp01.Text = "Input Bit 01 (Z-Phase)"
        Me.chkInp01.UseVisualStyleBackColor = True
        '
        'chkInp00
        '
        Me.chkInp00.Enabled = False
        Me.chkInp00.Location = New System.Drawing.Point(12, 20)
        Me.chkInp00.Name = "chkInp00"
        Me.chkInp00.Size = New System.Drawing.Size(176, 20)
        Me.chkInp00.TabIndex = 11
        Me.chkInp00.Text = "Input Bit 00 (Origin Sensor)"
        Me.chkInp00.UseVisualStyleBackColor = True
        '
        'PictureBox4
        '
        Me.PictureBox4.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.PictureBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox4.Location = New System.Drawing.Point(225, 20)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(5, 113)
        Me.PictureBox4.TabIndex = 10
        Me.PictureBox4.TabStop = False
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.chkSWEnable)
        Me.GroupBox4.Controls.Add(Me.edtSWPosP)
        Me.GroupBox4.Controls.Add(Me.Label7)
        Me.GroupBox4.Controls.Add(Me.Label6)
        Me.GroupBox4.Controls.Add(Me.cboSWRef)
        Me.GroupBox4.Controls.Add(Me.chkSWLimitP)
        Me.GroupBox4.Controls.Add(Me.edtSWPosN)
        Me.GroupBox4.Controls.Add(Me.Label5)
        Me.GroupBox4.Controls.Add(Me.Label4)
        Me.GroupBox4.Controls.Add(Me.chkSWLimitN)
        Me.GroupBox4.Controls.Add(Me.cboSWStop)
        Me.GroupBox4.Controls.Add(Me.PictureBox5)
        Me.GroupBox4.Location = New System.Drawing.Point(12, 347)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(455, 134)
        Me.GroupBox4.TabIndex = 23
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "< Software Limit >"
        '
        'chkSWEnable
        '
        Me.chkSWEnable.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkSWEnable.Location = New System.Drawing.Point(12, 98)
        Me.chkSWEnable.Name = "chkSWEnable"
        Me.chkSWEnable.Size = New System.Drawing.Size(432, 24)
        Me.chkSWEnable.TabIndex = 35
        Me.chkSWEnable.Text = "Enable"
        Me.chkSWEnable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkSWEnable.UseVisualStyleBackColor = True
        '
        'edtSWPosP
        '
        Me.edtSWPosP.Location = New System.Drawing.Point(333, 68)
        Me.edtSWPosP.Name = "edtSWPosP"
        Me.edtSWPosP.Size = New System.Drawing.Size(111, 21)
        Me.edtSWPosP.TabIndex = 34
        Me.edtSWPosP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(235, 74)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(98, 12)
        Me.Label7.TabIndex = 33
        Me.Label7.Text = "(+) Soft EndPos:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(235, 46)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(96, 12)
        Me.Label6.TabIndex = 32
        Me.Label6.Text = "Reference Pos :"
        '
        'cboSWRef
        '
        Me.cboSWRef.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSWRef.FormattingEnabled = True
        Me.cboSWRef.Location = New System.Drawing.Point(333, 42)
        Me.cboSWRef.Name = "cboSWRef"
        Me.cboSWRef.Size = New System.Drawing.Size(111, 20)
        Me.cboSWRef.TabIndex = 31
        '
        'chkSWLimitP
        '
        Me.chkSWLimitP.Enabled = False
        Me.chkSWLimitP.Location = New System.Drawing.Point(237, 20)
        Me.chkSWLimitP.Name = "chkSWLimitP"
        Me.chkSWLimitP.Size = New System.Drawing.Size(207, 16)
        Me.chkSWLimitP.TabIndex = 30
        Me.chkSWLimitP.Text = "(+) Software End Limit"
        Me.chkSWLimitP.UseVisualStyleBackColor = True
        '
        'edtSWPosN
        '
        Me.edtSWPosN.Location = New System.Drawing.Point(108, 68)
        Me.edtSWPosN.Name = "edtSWPosN"
        Me.edtSWPosN.Size = New System.Drawing.Size(111, 21)
        Me.edtSWPosN.TabIndex = 29
        Me.edtSWPosN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(10, 74)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(98, 12)
        Me.Label5.TabIndex = 28
        Me.Label5.Text = "(-) Soft EndPos:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(10, 46)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(98, 12)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "Stop Mode       :"
        '
        'chkSWLimitN
        '
        Me.chkSWLimitN.Enabled = False
        Me.chkSWLimitN.Location = New System.Drawing.Point(12, 20)
        Me.chkSWLimitN.Name = "chkSWLimitN"
        Me.chkSWLimitN.Size = New System.Drawing.Size(176, 16)
        Me.chkSWLimitN.TabIndex = 11
        Me.chkSWLimitN.Text = "(-) Software End Limit"
        Me.chkSWLimitN.UseVisualStyleBackColor = True
        '
        'cboSWStop
        '
        Me.cboSWStop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSWStop.FormattingEnabled = True
        Me.cboSWStop.Location = New System.Drawing.Point(108, 42)
        Me.cboSWStop.Name = "cboSWStop"
        Me.cboSWStop.Size = New System.Drawing.Size(111, 20)
        Me.cboSWStop.TabIndex = 25
        '
        'PictureBox5
        '
        Me.PictureBox5.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.PictureBox5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox5.Location = New System.Drawing.Point(225, 20)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(5, 69)
        Me.PictureBox5.TabIndex = 10
        Me.PictureBox5.TabStop = False
        '
        'CommonDialog1Open
        '
        Me.CommonDialog1Open.FileName = "OpenFileDialog1"
        '
        'm_timer
        '
        Me.m_timer.Enabled = True
        '
        'SignalMonitor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(479, 491)
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
        Me.Name = "SignalMonitor"
        Me.Text = "SignalMonitor"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboSelAxis As System.Windows.Forms.ComboBox
    Friend WithEvents btnLoadFile As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cboELimitP As System.Windows.Forms.ComboBox
    Friend WithEvents chkELimitP As System.Windows.Forms.CheckBox
    Friend WithEvents cboEmg As System.Windows.Forms.ComboBox
    Friend WithEvents chkEmg As System.Windows.Forms.CheckBox
    Friend WithEvents cboInp As System.Windows.Forms.ComboBox
    Friend WithEvents chkInp As System.Windows.Forms.CheckBox
    Friend WithEvents cboELimitN As System.Windows.Forms.ComboBox
    Friend WithEvents chkELimitN As System.Windows.Forms.CheckBox
    Friend WithEvents cboAlarm As System.Windows.Forms.ComboBox
    Friend WithEvents chkAlarm As System.Windows.Forms.CheckBox
    Friend WithEvents cboZPhase As System.Windows.Forms.ComboBox
    Friend WithEvents chkZPhase As System.Windows.Forms.CheckBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboAlarmReset As System.Windows.Forms.ComboBox
    Friend WithEvents cboServoOn As System.Windows.Forms.ComboBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents chkOut04 As System.Windows.Forms.CheckBox
    Friend WithEvents chkOut03 As System.Windows.Forms.CheckBox
    Friend WithEvents chkOut02 As System.Windows.Forms.CheckBox
    Friend WithEvents chkOut01 As System.Windows.Forms.CheckBox
    Friend WithEvents chkOut00 As System.Windows.Forms.CheckBox
    Friend WithEvents chkInp04 As System.Windows.Forms.CheckBox
    Friend WithEvents chkInp03 As System.Windows.Forms.CheckBox
    Friend WithEvents chkInp02 As System.Windows.Forms.CheckBox
    Friend WithEvents chkInp01 As System.Windows.Forms.CheckBox
    Friend WithEvents chkInp00 As System.Windows.Forms.CheckBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents chkSWLimitN As System.Windows.Forms.CheckBox
    Friend WithEvents cboSWStop As System.Windows.Forms.ComboBox
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents edtSWPosP As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboSWRef As System.Windows.Forms.ComboBox
    Friend WithEvents chkSWLimitP As System.Windows.Forms.CheckBox
    Friend WithEvents edtSWPosN As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents chkSWEnable As System.Windows.Forms.CheckBox
    Friend WithEvents CommonDialog1Open As System.Windows.Forms.OpenFileDialog
    Friend WithEvents m_timer As System.Windows.Forms.Timer

End Class
