<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OverridePosition
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
        Me.btnSStop = New System.Windows.Forms.Button()
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
        Me.Label9 = New System.Windows.Forms.Label()
        Me.edtMovePos = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.rdoRel = New System.Windows.Forms.RadioButton()
        Me.rdoAbs = New System.Windows.Forms.RadioButton()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnOverride2 = New System.Windows.Forms.Button()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.btmOverride = New System.Windows.Forms.PictureBox()
        Me.btnOverride1 = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.edtOverrideDis2 = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.edtOverrideDis1 = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.m_timer = New System.Windows.Forms.Timer(Me.components)
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btmOverride, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnLoadFile
        '
        Me.btnLoadFile.Location = New System.Drawing.Point(348, 16)
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
        Me.cboSelAxis.Location = New System.Drawing.Point(147, 17)
        Me.cboSelAxis.Name = "cboSelAxis"
        Me.cboSelAxis.Size = New System.Drawing.Size(195, 20)
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
        Me.GroupBox1.TabIndex = 21
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
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnSStop)
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
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.edtMovePos)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.rdoRel)
        Me.GroupBox2.Controls.Add(Me.rdoAbs)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 157)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(455, 149)
        Me.GroupBox2.TabIndex = 22
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "< Position Move >"
        '
        'btnSStop
        '
        Me.btnSStop.Location = New System.Drawing.Point(336, 64)
        Me.btnSStop.Name = "btnSStop"
        Me.btnSStop.Size = New System.Drawing.Size(109, 75)
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
        Me.btnMove1.Text = "Move Target 1"
        Me.btnMove1.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(262, 123)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(66, 12)
        Me.Label17.TabIndex = 23
        Me.Label17.Text = "Unit/Sec^2"
        '
        'edtMoveDec
        '
        Me.edtMoveDec.Location = New System.Drawing.Point(135, 118)
        Me.edtMoveDec.Name = "edtMoveDec"
        Me.edtMoveDec.Size = New System.Drawing.Size(122, 21)
        Me.edtMoveDec.TabIndex = 11
        Me.edtMoveDec.Text = "400.0"
        Me.edtMoveDec.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(9, 123)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(126, 12)
        Me.Label18.TabIndex = 21
        Me.Label18.Text = "Move Deceleration   :"
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
        'edtMoveAcc
        '
        Me.edtMoveAcc.Location = New System.Drawing.Point(135, 91)
        Me.edtMoveAcc.Name = "edtMoveAcc"
        Me.edtMoveAcc.Size = New System.Drawing.Size(122, 21)
        Me.edtMoveAcc.TabIndex = 10
        Me.edtMoveAcc.Text = "400.0"
        Me.edtMoveAcc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(9, 96)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(126, 12)
        Me.Label16.TabIndex = 18
        Me.Label16.Text = "Move Acceleration   :"
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
        Me.edtMoveVel.Text = "200.0"
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
        Me.edtMovePos.Text = "1000.0"
        Me.edtMovePos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(9, 42)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(124, 12)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "Target Position 1     :"
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
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnOverride2)
        Me.GroupBox3.Controls.Add(Me.PictureBox3)
        Me.GroupBox3.Controls.Add(Me.btmOverride)
        Me.GroupBox3.Controls.Add(Me.btnOverride1)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.edtOverrideDis2)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.edtOverrideDis1)
        Me.GroupBox3.Controls.Add(Me.Label19)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 315)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(455, 204)
        Me.GroupBox3.TabIndex = 24
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "< Position Move >"
        '
        'btnOverride2
        '
        Me.btnOverride2.Location = New System.Drawing.Point(336, 175)
        Me.btnOverride2.Name = "btnOverride2"
        Me.btnOverride2.Size = New System.Drawing.Size(109, 21)
        Me.btnOverride2.TabIndex = 43
        Me.btnOverride2.Text = "Override Pos 2"
        Me.btnOverride2.UseVisualStyleBackColor = True
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.PictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox3.Location = New System.Drawing.Point(10, 140)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(434, 3)
        Me.PictureBox3.TabIndex = 42
        Me.PictureBox3.TabStop = False
        '
        'btmOverride
        '
        Me.btmOverride.Image = Global._09._Override__Position.My.Resources.Resources.PosOverrideRel
        Me.btmOverride.Location = New System.Drawing.Point(6, 20)
        Me.btmOverride.Name = "btmOverride"
        Me.btmOverride.Size = New System.Drawing.Size(439, 113)
        Me.btmOverride.TabIndex = 24
        Me.btmOverride.TabStop = False
        '
        'btnOverride1
        '
        Me.btnOverride1.Location = New System.Drawing.Point(336, 149)
        Me.btnOverride1.Name = "btnOverride1"
        Me.btnOverride1.Size = New System.Drawing.Size(109, 21)
        Me.btnOverride1.TabIndex = 15
        Me.btnOverride1.Text = "Override Pos 1"
        Me.btnOverride1.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(262, 181)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(26, 12)
        Me.Label8.TabIndex = 23
        Me.Label8.Text = "Unit"
        '
        'edtOverrideDis2
        '
        Me.edtOverrideDis2.Location = New System.Drawing.Point(135, 176)
        Me.edtOverrideDis2.Name = "edtOverrideDis2"
        Me.edtOverrideDis2.Size = New System.Drawing.Size(122, 21)
        Me.edtOverrideDis2.TabIndex = 11
        Me.edtOverrideDis2.Text = "1000.0"
        Me.edtOverrideDis2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(9, 181)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(127, 12)
        Me.Label11.TabIndex = 21
        Me.Label11.Text = "Override Distance 2  :"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(262, 154)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(26, 12)
        Me.Label12.TabIndex = 20
        Me.Label12.Text = "Unit"
        '
        'edtOverrideDis1
        '
        Me.edtOverrideDis1.Location = New System.Drawing.Point(135, 149)
        Me.edtOverrideDis1.Name = "edtOverrideDis1"
        Me.edtOverrideDis1.Size = New System.Drawing.Size(122, 21)
        Me.edtOverrideDis1.TabIndex = 10
        Me.edtOverrideDis1.Text = "2000.0"
        Me.edtOverrideDis1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(9, 154)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(127, 12)
        Me.Label19.TabIndex = 18
        Me.Label19.Text = "Override Distance 1  :"
        '
        'm_timer
        '
        Me.m_timer.Enabled = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'OverridePosition
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(479, 529)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnLoadFile)
        Me.Controls.Add(Me.cboSelAxis)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "OverridePosition"
        Me.Text = "OverridePosition"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btmOverride, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnLoadFile As System.Windows.Forms.Button
    Friend WithEvents cboSelAxis As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
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
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnSStop As System.Windows.Forms.Button
    Friend WithEvents btnMove1 As System.Windows.Forms.Button
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents edtMoveDec As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
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
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btnOverride1 As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents edtOverrideDis2 As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents edtOverrideDis1 As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents btmOverride As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents btnOverride2 As System.Windows.Forms.Button
    Friend WithEvents edtSetPos As System.Windows.Forms.TextBox
    Friend WithEvents m_timer As System.Windows.Forms.Timer
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog

End Class
