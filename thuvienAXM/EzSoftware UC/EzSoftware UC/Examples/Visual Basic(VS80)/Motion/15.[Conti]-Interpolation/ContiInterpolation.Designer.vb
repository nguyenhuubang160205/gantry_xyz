<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ContiInterpolation
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
        Me.Label4 = New System.Windows.Forms.Label()
        Me.stcCmdVel03 = New System.Windows.Forms.TextBox()
        Me.stcCmdVel02 = New System.Windows.Forms.TextBox()
        Me.stcCmdVel01 = New System.Windows.Forms.TextBox()
        Me.stcCmdVel00 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.stcActPos03 = New System.Windows.Forms.TextBox()
        Me.stcActPos02 = New System.Windows.Forms.TextBox()
        Me.stcActPos01 = New System.Windows.Forms.TextBox()
        Me.stcActPos00 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.stcCmdPos03 = New System.Windows.Forms.TextBox()
        Me.stcCmdPos02 = New System.Windows.Forms.TextBox()
        Me.stcCmdPos01 = New System.Windows.Forms.TextBox()
        Me.stcCmdPos00 = New System.Windows.Forms.TextBox()
        Me.chkAxis03 = New System.Windows.Forms.CheckBox()
        Me.chkAxis02 = New System.Windows.Forms.CheckBox()
        Me.chkAxis01 = New System.Windows.Forms.CheckBox()
        Me.chkAxis00 = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.chkIntpInMotion = New System.Windows.Forms.CheckBox()
        Me.chkIntpQueueFree = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.stcIntpExeNode = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.stcIntpTotalNode = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnIntpClear = New System.Windows.Forms.Button()
        Me.btnIntpStart = New System.Windows.Forms.Button()
        Me.btnIntpSpline = New System.Windows.Forms.Button()
        Me.btnIntpHelical = New System.Windows.Forms.Button()
        Me.btnIntpLineArc = New System.Windows.Forms.Button()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.btnIntpCircle = New System.Windows.Forms.Button()
        Me.btnIntpArc = New System.Windows.Forms.Button()
        Me.btnIntpLine = New System.Windows.Forms.Button()
        Me.btnIntpStop = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.edtMoveDec = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.edtMoveVel = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.edtMoveAcc = New System.Windows.Forms.TextBox()
        Me.m_timer = New System.Windows.Forms.Timer(Me.components)
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnLoadFile
        '
        Me.btnLoadFile.Location = New System.Drawing.Point(348, 15)
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
        Me.cboSelAxis.Location = New System.Drawing.Point(119, 16)
        Me.cboSelAxis.Name = "cboSelAxis"
        Me.cboSelAxis.Size = New System.Drawing.Size(223, 20)
        Me.cboSelAxis.TabIndex = 21
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(21, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 12)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "Select Axis No :"
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
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkServoOn)
        Me.GroupBox1.Controls.Add(Me.btnPosClear)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.stcCmdVel03)
        Me.GroupBox1.Controls.Add(Me.stcCmdVel02)
        Me.GroupBox1.Controls.Add(Me.stcCmdVel01)
        Me.GroupBox1.Controls.Add(Me.stcCmdVel00)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.stcActPos03)
        Me.GroupBox1.Controls.Add(Me.stcActPos02)
        Me.GroupBox1.Controls.Add(Me.stcActPos01)
        Me.GroupBox1.Controls.Add(Me.stcActPos00)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.stcCmdPos03)
        Me.GroupBox1.Controls.Add(Me.stcCmdPos02)
        Me.GroupBox1.Controls.Add(Me.stcCmdPos01)
        Me.GroupBox1.Controls.Add(Me.stcCmdPos00)
        Me.GroupBox1.Controls.Add(Me.chkAxis03)
        Me.GroupBox1.Controls.Add(Me.chkAxis02)
        Me.GroupBox1.Controls.Add(Me.chkAxis01)
        Me.GroupBox1.Controls.Add(Me.chkAxis00)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 49)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(455, 119)
        Me.GroupBox1.TabIndex = 25
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Position Monitor"
        '
        'chkServoOn
        '
        Me.chkServoOn.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkServoOn.AutoSize = True
        Me.chkServoOn.Location = New System.Drawing.Point(379, 89)
        Me.chkServoOn.Name = "chkServoOn"
        Me.chkServoOn.Size = New System.Drawing.Size(67, 22)
        Me.chkServoOn.TabIndex = 27
        Me.chkServoOn.Text = "Servo On"
        Me.chkServoOn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkServoOn.UseVisualStyleBackColor = True
        '
        'btnPosClear
        '
        Me.btnPosClear.Location = New System.Drawing.Point(379, 42)
        Me.btnPosClear.Name = "btnPosClear"
        Me.btnPosClear.Size = New System.Drawing.Size(66, 45)
        Me.btnPosClear.TabIndex = 26
        Me.btnPosClear.Text = "Clear"
        Me.btnPosClear.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 95)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(98, 12)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = "Command Vel  :"
        '
        'stcCmdVel03
        '
        Me.stcCmdVel03.Enabled = False
        Me.stcCmdVel03.Location = New System.Drawing.Point(311, 90)
        Me.stcCmdVel03.Name = "stcCmdVel03"
        Me.stcCmdVel03.Size = New System.Drawing.Size(65, 21)
        Me.stcCmdVel03.TabIndex = 24
        Me.stcCmdVel03.Text = "0.000"
        Me.stcCmdVel03.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'stcCmdVel02
        '
        Me.stcCmdVel02.Enabled = False
        Me.stcCmdVel02.Location = New System.Drawing.Point(243, 90)
        Me.stcCmdVel02.Name = "stcCmdVel02"
        Me.stcCmdVel02.Size = New System.Drawing.Size(65, 21)
        Me.stcCmdVel02.TabIndex = 23
        Me.stcCmdVel02.Text = "0.000"
        Me.stcCmdVel02.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'stcCmdVel01
        '
        Me.stcCmdVel01.Enabled = False
        Me.stcCmdVel01.Location = New System.Drawing.Point(175, 90)
        Me.stcCmdVel01.Name = "stcCmdVel01"
        Me.stcCmdVel01.Size = New System.Drawing.Size(65, 21)
        Me.stcCmdVel01.TabIndex = 22
        Me.stcCmdVel01.Text = "0.000"
        Me.stcCmdVel01.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'stcCmdVel00
        '
        Me.stcCmdVel00.Enabled = False
        Me.stcCmdVel00.Location = New System.Drawing.Point(107, 90)
        Me.stcCmdVel00.Name = "stcCmdVel00"
        Me.stcCmdVel00.Size = New System.Drawing.Size(65, 21)
        Me.stcCmdVel00.TabIndex = 21
        Me.stcCmdVel00.Text = "0.000"
        Me.stcCmdVel00.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 71)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(98, 12)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "Feedback Pos  :"
        '
        'stcActPos03
        '
        Me.stcActPos03.Enabled = False
        Me.stcActPos03.Location = New System.Drawing.Point(311, 66)
        Me.stcActPos03.Name = "stcActPos03"
        Me.stcActPos03.Size = New System.Drawing.Size(65, 21)
        Me.stcActPos03.TabIndex = 19
        Me.stcActPos03.Text = "0.000"
        Me.stcActPos03.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'stcActPos02
        '
        Me.stcActPos02.Enabled = False
        Me.stcActPos02.Location = New System.Drawing.Point(243, 66)
        Me.stcActPos02.Name = "stcActPos02"
        Me.stcActPos02.Size = New System.Drawing.Size(65, 21)
        Me.stcActPos02.TabIndex = 18
        Me.stcActPos02.Text = "0.000"
        Me.stcActPos02.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'stcActPos01
        '
        Me.stcActPos01.Enabled = False
        Me.stcActPos01.Location = New System.Drawing.Point(175, 66)
        Me.stcActPos01.Name = "stcActPos01"
        Me.stcActPos01.Size = New System.Drawing.Size(65, 21)
        Me.stcActPos01.TabIndex = 17
        Me.stcActPos01.Text = "0.000"
        Me.stcActPos01.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'stcActPos00
        '
        Me.stcActPos00.Enabled = False
        Me.stcActPos00.Location = New System.Drawing.Point(107, 66)
        Me.stcActPos00.Name = "stcActPos00"
        Me.stcActPos00.Size = New System.Drawing.Size(65, 21)
        Me.stcActPos00.TabIndex = 16
        Me.stcActPos00.Text = "0.000"
        Me.stcActPos00.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(98, 12)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Command Pos :"
        '
        'stcCmdPos03
        '
        Me.stcCmdPos03.Enabled = False
        Me.stcCmdPos03.Location = New System.Drawing.Point(311, 42)
        Me.stcCmdPos03.Name = "stcCmdPos03"
        Me.stcCmdPos03.Size = New System.Drawing.Size(65, 21)
        Me.stcCmdPos03.TabIndex = 7
        Me.stcCmdPos03.Text = "0.000"
        Me.stcCmdPos03.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'stcCmdPos02
        '
        Me.stcCmdPos02.Enabled = False
        Me.stcCmdPos02.Location = New System.Drawing.Point(243, 42)
        Me.stcCmdPos02.Name = "stcCmdPos02"
        Me.stcCmdPos02.Size = New System.Drawing.Size(65, 21)
        Me.stcCmdPos02.TabIndex = 6
        Me.stcCmdPos02.Text = "0.000"
        Me.stcCmdPos02.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'stcCmdPos01
        '
        Me.stcCmdPos01.Enabled = False
        Me.stcCmdPos01.Location = New System.Drawing.Point(175, 42)
        Me.stcCmdPos01.Name = "stcCmdPos01"
        Me.stcCmdPos01.Size = New System.Drawing.Size(65, 21)
        Me.stcCmdPos01.TabIndex = 5
        Me.stcCmdPos01.Text = "0.000"
        Me.stcCmdPos01.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'stcCmdPos00
        '
        Me.stcCmdPos00.Enabled = False
        Me.stcCmdPos00.Location = New System.Drawing.Point(107, 42)
        Me.stcCmdPos00.Name = "stcCmdPos00"
        Me.stcCmdPos00.Size = New System.Drawing.Size(65, 21)
        Me.stcCmdPos00.TabIndex = 4
        Me.stcCmdPos00.Text = "0.000"
        Me.stcCmdPos00.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chkAxis03
        '
        Me.chkAxis03.AutoSize = True
        Me.chkAxis03.Location = New System.Drawing.Point(311, 20)
        Me.chkAxis03.Name = "chkAxis03"
        Me.chkAxis03.Size = New System.Drawing.Size(65, 16)
        Me.chkAxis03.TabIndex = 3
        Me.chkAxis03.Text = "Axis 03"
        Me.chkAxis03.UseVisualStyleBackColor = True
        '
        'chkAxis02
        '
        Me.chkAxis02.AutoSize = True
        Me.chkAxis02.Location = New System.Drawing.Point(243, 20)
        Me.chkAxis02.Name = "chkAxis02"
        Me.chkAxis02.Size = New System.Drawing.Size(65, 16)
        Me.chkAxis02.TabIndex = 2
        Me.chkAxis02.Text = "Axis 02"
        Me.chkAxis02.UseVisualStyleBackColor = True
        '
        'chkAxis01
        '
        Me.chkAxis01.AutoSize = True
        Me.chkAxis01.Location = New System.Drawing.Point(175, 20)
        Me.chkAxis01.Name = "chkAxis01"
        Me.chkAxis01.Size = New System.Drawing.Size(65, 16)
        Me.chkAxis01.TabIndex = 1
        Me.chkAxis01.Text = "Axis 01"
        Me.chkAxis01.UseVisualStyleBackColor = True
        '
        'chkAxis00
        '
        Me.chkAxis00.AutoSize = True
        Me.chkAxis00.Location = New System.Drawing.Point(107, 20)
        Me.chkAxis00.Name = "chkAxis00"
        Me.chkAxis00.Size = New System.Drawing.Size(65, 16)
        Me.chkAxis00.TabIndex = 0
        Me.chkAxis00.Text = "Axis 00"
        Me.chkAxis00.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chkIntpInMotion)
        Me.GroupBox2.Controls.Add(Me.chkIntpQueueFree)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.PictureBox2)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.stcIntpExeNode)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.stcIntpTotalNode)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 177)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(455, 73)
        Me.GroupBox2.TabIndex = 26
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "< Interpolation Monitor >"
        '
        'chkIntpInMotion
        '
        Me.chkIntpInMotion.AutoSize = True
        Me.chkIntpInMotion.Enabled = False
        Me.chkIntpInMotion.Location = New System.Drawing.Point(381, 43)
        Me.chkIntpInMotion.Name = "chkIntpInMotion"
        Me.chkIntpInMotion.Size = New System.Drawing.Size(15, 14)
        Me.chkIntpInMotion.TabIndex = 45
        Me.chkIntpInMotion.UseVisualStyleBackColor = True
        '
        'chkIntpQueueFree
        '
        Me.chkIntpQueueFree.AutoSize = True
        Me.chkIntpQueueFree.Enabled = False
        Me.chkIntpQueueFree.Location = New System.Drawing.Point(381, 19)
        Me.chkIntpQueueFree.Name = "chkIntpQueueFree"
        Me.chkIntpQueueFree.Size = New System.Drawing.Size(15, 14)
        Me.chkIntpQueueFree.TabIndex = 27
        Me.chkIntpQueueFree.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(255, 45)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(126, 12)
        Me.Label5.TabIndex = 44
        Me.Label5.Text = "In Interpolation Move:"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.PictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox2.Location = New System.Drawing.Point(246, 18)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(3, 45)
        Me.PictureBox2.TabIndex = 43
        Me.PictureBox2.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(255, 21)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(123, 12)
        Me.Label9.TabIndex = 30
        Me.Label9.Text = "Interpolation Q Free :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(9, 45)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(163, 12)
        Me.Label8.TabIndex = 29
        Me.Label8.Text = "Interpolation Total Node     :"
        '
        'stcIntpExeNode
        '
        Me.stcIntpExeNode.Enabled = False
        Me.stcIntpExeNode.Location = New System.Drawing.Point(175, 18)
        Me.stcIntpExeNode.Name = "stcIntpExeNode"
        Me.stcIntpExeNode.Size = New System.Drawing.Size(65, 21)
        Me.stcIntpExeNode.TabIndex = 28
        Me.stcIntpExeNode.Text = "0"
        Me.stcIntpExeNode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(9, 21)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(165, 12)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Interpolation Execute Node :"
        '
        'stcIntpTotalNode
        '
        Me.stcIntpTotalNode.Enabled = False
        Me.stcIntpTotalNode.Location = New System.Drawing.Point(175, 42)
        Me.stcIntpTotalNode.Name = "stcIntpTotalNode"
        Me.stcIntpTotalNode.Size = New System.Drawing.Size(65, 21)
        Me.stcIntpTotalNode.TabIndex = 5
        Me.stcIntpTotalNode.Text = "0"
        Me.stcIntpTotalNode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnIntpClear)
        Me.GroupBox3.Controls.Add(Me.btnIntpStart)
        Me.GroupBox3.Controls.Add(Me.btnIntpSpline)
        Me.GroupBox3.Controls.Add(Me.btnIntpHelical)
        Me.GroupBox3.Controls.Add(Me.btnIntpLineArc)
        Me.GroupBox3.Controls.Add(Me.PictureBox4)
        Me.GroupBox3.Controls.Add(Me.btnIntpCircle)
        Me.GroupBox3.Controls.Add(Me.btnIntpArc)
        Me.GroupBox3.Controls.Add(Me.btnIntpLine)
        Me.GroupBox3.Controls.Add(Me.btnIntpStop)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Controls.Add(Me.edtMoveDec)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.PictureBox3)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.edtMoveVel)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.edtMoveAcc)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 259)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(455, 231)
        Me.GroupBox3.TabIndex = 46
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "< Interpolation Move >"
        '
        'btnIntpClear
        '
        Me.btnIntpClear.Location = New System.Drawing.Point(380, 184)
        Me.btnIntpClear.Name = "btnIntpClear"
        Me.btnIntpClear.Size = New System.Drawing.Size(66, 33)
        Me.btnIntpClear.TabIndex = 55
        Me.btnIntpClear.Text = "Clear"
        Me.btnIntpClear.UseVisualStyleBackColor = True
        '
        'btnIntpStart
        '
        Me.btnIntpStart.Location = New System.Drawing.Point(379, 147)
        Me.btnIntpStart.Name = "btnIntpStart"
        Me.btnIntpStart.Size = New System.Drawing.Size(66, 33)
        Me.btnIntpStart.TabIndex = 54
        Me.btnIntpStart.Text = "Start"
        Me.btnIntpStart.UseVisualStyleBackColor = True
        '
        'btnIntpSpline
        '
        Me.btnIntpSpline.Enabled = False
        Me.btnIntpSpline.Location = New System.Drawing.Point(257, 147)
        Me.btnIntpSpline.Name = "btnIntpSpline"
        Me.btnIntpSpline.Size = New System.Drawing.Size(120, 70)
        Me.btnIntpSpline.TabIndex = 53
        Me.btnIntpSpline.Text = "Spline"
        Me.btnIntpSpline.UseVisualStyleBackColor = True
        '
        'btnIntpHelical
        '
        Me.btnIntpHelical.Enabled = False
        Me.btnIntpHelical.Location = New System.Drawing.Point(134, 147)
        Me.btnIntpHelical.Name = "btnIntpHelical"
        Me.btnIntpHelical.Size = New System.Drawing.Size(120, 70)
        Me.btnIntpHelical.TabIndex = 52
        Me.btnIntpHelical.Text = "Helical"
        Me.btnIntpHelical.UseVisualStyleBackColor = True
        '
        'btnIntpLineArc
        '
        Me.btnIntpLineArc.Enabled = False
        Me.btnIntpLineArc.Location = New System.Drawing.Point(11, 147)
        Me.btnIntpLineArc.Name = "btnIntpLineArc"
        Me.btnIntpLineArc.Size = New System.Drawing.Size(120, 70)
        Me.btnIntpLineArc.TabIndex = 51
        Me.btnIntpLineArc.Text = "Line && Arc"
        Me.btnIntpLineArc.UseVisualStyleBackColor = True
        '
        'PictureBox4
        '
        Me.PictureBox4.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.PictureBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox4.Location = New System.Drawing.Point(11, 138)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(364, 3)
        Me.PictureBox4.TabIndex = 50
        Me.PictureBox4.TabStop = False
        '
        'btnIntpCircle
        '
        Me.btnIntpCircle.Enabled = False
        Me.btnIntpCircle.Location = New System.Drawing.Point(257, 104)
        Me.btnIntpCircle.Name = "btnIntpCircle"
        Me.btnIntpCircle.Size = New System.Drawing.Size(120, 28)
        Me.btnIntpCircle.TabIndex = 49
        Me.btnIntpCircle.Text = "Circle(Angle)"
        Me.btnIntpCircle.UseVisualStyleBackColor = True
        '
        'btnIntpArc
        '
        Me.btnIntpArc.Enabled = False
        Me.btnIntpArc.Location = New System.Drawing.Point(134, 104)
        Me.btnIntpArc.Name = "btnIntpArc"
        Me.btnIntpArc.Size = New System.Drawing.Size(120, 28)
        Me.btnIntpArc.TabIndex = 48
        Me.btnIntpArc.Text = "Arc(Radius)"
        Me.btnIntpArc.UseVisualStyleBackColor = True
        '
        'btnIntpLine
        '
        Me.btnIntpLine.Enabled = False
        Me.btnIntpLine.Location = New System.Drawing.Point(11, 104)
        Me.btnIntpLine.Name = "btnIntpLine"
        Me.btnIntpLine.Size = New System.Drawing.Size(120, 28)
        Me.btnIntpLine.TabIndex = 28
        Me.btnIntpLine.Text = "Line"
        Me.btnIntpLine.UseVisualStyleBackColor = True
        '
        'btnIntpStop
        '
        Me.btnIntpStop.Location = New System.Drawing.Point(379, 18)
        Me.btnIntpStop.Name = "btnIntpStop"
        Me.btnIntpStop.Size = New System.Drawing.Size(66, 114)
        Me.btnIntpStop.TabIndex = 28
        Me.btnIntpStop.Text = "Stop"
        Me.btnIntpStop.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(309, 71)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(66, 12)
        Me.Label13.TabIndex = 47
        Me.Label13.Text = "Unit/Sec^2"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(9, 71)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(167, 12)
        Me.Label14.TabIndex = 46
        Me.Label14.Text = "Interpolation Deceleration    :"
        '
        'edtMoveDec
        '
        Me.edtMoveDec.Location = New System.Drawing.Point(175, 68)
        Me.edtMoveDec.Name = "edtMoveDec"
        Me.edtMoveDec.Size = New System.Drawing.Size(133, 21)
        Me.edtMoveDec.TabIndex = 45
        Me.edtMoveDec.Text = "400.0"
        Me.edtMoveDec.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(309, 46)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(66, 12)
        Me.Label6.TabIndex = 44
        Me.Label6.Text = "Unit/Sec^2"
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.PictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox3.Location = New System.Drawing.Point(11, 95)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(364, 3)
        Me.PictureBox3.TabIndex = 43
        Me.PictureBox3.TabStop = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(309, 21)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(54, 12)
        Me.Label10.TabIndex = 30
        Me.Label10.Text = "Unit/Sec"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(9, 46)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(167, 12)
        Me.Label11.TabIndex = 29
        Me.Label11.Text = "Interpolation Acceleration    :"
        '
        'edtMoveVel
        '
        Me.edtMoveVel.Location = New System.Drawing.Point(175, 18)
        Me.edtMoveVel.Name = "edtMoveVel"
        Me.edtMoveVel.Size = New System.Drawing.Size(133, 21)
        Me.edtMoveVel.TabIndex = 28
        Me.edtMoveVel.Text = "100.0"
        Me.edtMoveVel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(9, 21)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(166, 12)
        Me.Label12.TabIndex = 15
        Me.Label12.Text = "Interpolation Velocity          :"
        '
        'edtMoveAcc
        '
        Me.edtMoveAcc.Location = New System.Drawing.Point(175, 43)
        Me.edtMoveAcc.Name = "edtMoveAcc"
        Me.edtMoveAcc.Size = New System.Drawing.Size(133, 21)
        Me.edtMoveAcc.TabIndex = 5
        Me.edtMoveAcc.Text = "400.0"
        Me.edtMoveAcc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'm_timer
        '
        Me.m_timer.Enabled = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'ContiInterpolation
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
        Me.Name = "ContiInterpolation"
        Me.Text = "ContiInterpolation"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents stcCmdVel03 As System.Windows.Forms.TextBox
    Friend WithEvents stcCmdVel02 As System.Windows.Forms.TextBox
    Friend WithEvents stcCmdVel01 As System.Windows.Forms.TextBox
    Friend WithEvents stcCmdVel00 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents stcActPos03 As System.Windows.Forms.TextBox
    Friend WithEvents stcActPos02 As System.Windows.Forms.TextBox
    Friend WithEvents stcActPos01 As System.Windows.Forms.TextBox
    Friend WithEvents stcActPos00 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents stcCmdPos03 As System.Windows.Forms.TextBox
    Friend WithEvents stcCmdPos02 As System.Windows.Forms.TextBox
    Friend WithEvents stcCmdPos01 As System.Windows.Forms.TextBox
    Friend WithEvents stcCmdPos00 As System.Windows.Forms.TextBox
    Friend WithEvents chkAxis03 As System.Windows.Forms.CheckBox
    Friend WithEvents chkAxis02 As System.Windows.Forms.CheckBox
    Friend WithEvents chkAxis01 As System.Windows.Forms.CheckBox
    Friend WithEvents chkAxis00 As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents stcIntpExeNode As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents stcIntpTotalNode As System.Windows.Forms.TextBox
    Friend WithEvents chkIntpInMotion As System.Windows.Forms.CheckBox
    Friend WithEvents chkIntpQueueFree As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents btnIntpCircle As System.Windows.Forms.Button
    Friend WithEvents btnIntpArc As System.Windows.Forms.Button
    Friend WithEvents btnIntpLine As System.Windows.Forms.Button
    Friend WithEvents btnIntpStop As System.Windows.Forms.Button
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents edtMoveDec As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents edtMoveVel As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents edtMoveAcc As System.Windows.Forms.TextBox
    Friend WithEvents btnIntpClear As System.Windows.Forms.Button
    Friend WithEvents btnIntpStart As System.Windows.Forms.Button
    Friend WithEvents btnIntpSpline As System.Windows.Forms.Button
    Friend WithEvents btnIntpHelical As System.Windows.Forms.Button
    Friend WithEvents btnIntpLineArc As System.Windows.Forms.Button
    Friend WithEvents m_timer As System.Windows.Forms.Timer
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog

End Class
