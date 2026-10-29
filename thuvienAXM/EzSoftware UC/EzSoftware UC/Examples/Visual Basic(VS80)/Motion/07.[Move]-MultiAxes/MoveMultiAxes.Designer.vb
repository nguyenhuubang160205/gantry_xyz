<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MoveMultiAxes
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
        Me.chkMoveBlock = New System.Windows.Forms.CheckBox()
        Me.btnPosStop = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.edtMovePos03 = New System.Windows.Forms.TextBox()
        Me.edtMovePos02 = New System.Windows.Forms.TextBox()
        Me.edtMovePos01 = New System.Windows.Forms.TextBox()
        Me.edtMovePos00 = New System.Windows.Forms.TextBox()
        Me.btnPosMove = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.edtMoveDec03 = New System.Windows.Forms.TextBox()
        Me.edtMoveDec02 = New System.Windows.Forms.TextBox()
        Me.edtMoveDec01 = New System.Windows.Forms.TextBox()
        Me.edtMoveDec00 = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.edtMoveAcc03 = New System.Windows.Forms.TextBox()
        Me.edtMoveAcc02 = New System.Windows.Forms.TextBox()
        Me.edtMoveAcc01 = New System.Windows.Forms.TextBox()
        Me.edtMoveAcc00 = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.edtMoveVel03 = New System.Windows.Forms.TextBox()
        Me.edtMoveVel02 = New System.Windows.Forms.TextBox()
        Me.edtMoveVel01 = New System.Windows.Forms.TextBox()
        Me.edtMoveVel00 = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnJogN = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.edtJogVel03 = New System.Windows.Forms.TextBox()
        Me.edtJogVel02 = New System.Windows.Forms.TextBox()
        Me.edtJogVel01 = New System.Windows.Forms.TextBox()
        Me.edtJogVel00 = New System.Windows.Forms.TextBox()
        Me.btnJogP = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.edtJogDec03 = New System.Windows.Forms.TextBox()
        Me.edtJogDec02 = New System.Windows.Forms.TextBox()
        Me.edtJogDec01 = New System.Windows.Forms.TextBox()
        Me.edtJogDec00 = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.edtJogAcc03 = New System.Windows.Forms.TextBox()
        Me.edtJogAcc02 = New System.Windows.Forms.TextBox()
        Me.edtJogAcc01 = New System.Windows.Forms.TextBox()
        Me.edtJogAcc00 = New System.Windows.Forms.TextBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.btnLineN = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.edtLinePos03 = New System.Windows.Forms.TextBox()
        Me.edtLinePos02 = New System.Windows.Forms.TextBox()
        Me.edtLinePos01 = New System.Windows.Forms.TextBox()
        Me.edtLinePos00 = New System.Windows.Forms.TextBox()
        Me.btnLineP = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.edtLineDec = New System.Windows.Forms.TextBox()
        Me.edtLineAcc = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.edtLineVel = New System.Windows.Forms.TextBox()
        Me.m_timer = New System.Windows.Forms.Timer(Me.components)
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnLoadFile
        '
        Me.btnLoadFile.Location = New System.Drawing.Point(344, 16)
        Me.btnLoadFile.Name = "btnLoadFile"
        Me.btnLoadFile.Size = New System.Drawing.Size(113, 22)
        Me.btnLoadFile.TabIndex = 11
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
        Me.cboSelAxis.TabIndex = 10
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(21, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 12)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Select Axis No :"
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Location = New System.Drawing.Point(12, 13)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(455, 27)
        Me.PictureBox1.TabIndex = 12
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
        Me.GroupBox1.TabIndex = 14
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
        Me.GroupBox2.Controls.Add(Me.chkMoveBlock)
        Me.GroupBox2.Controls.Add(Me.btnPosStop)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.edtMovePos03)
        Me.GroupBox2.Controls.Add(Me.edtMovePos02)
        Me.GroupBox2.Controls.Add(Me.edtMovePos01)
        Me.GroupBox2.Controls.Add(Me.edtMovePos00)
        Me.GroupBox2.Controls.Add(Me.btnPosMove)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.edtMoveDec03)
        Me.GroupBox2.Controls.Add(Me.edtMoveDec02)
        Me.GroupBox2.Controls.Add(Me.edtMoveDec01)
        Me.GroupBox2.Controls.Add(Me.edtMoveDec00)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.edtMoveAcc03)
        Me.GroupBox2.Controls.Add(Me.edtMoveAcc02)
        Me.GroupBox2.Controls.Add(Me.edtMoveAcc01)
        Me.GroupBox2.Controls.Add(Me.edtMoveAcc00)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.edtMoveVel03)
        Me.GroupBox2.Controls.Add(Me.edtMoveVel02)
        Me.GroupBox2.Controls.Add(Me.edtMoveVel01)
        Me.GroupBox2.Controls.Add(Me.edtMoveVel00)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 177)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(455, 119)
        Me.GroupBox2.TabIndex = 28
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "< Multi Position Move >"
        '
        'chkMoveBlock
        '
        Me.chkMoveBlock.AutoSize = True
        Me.chkMoveBlock.Location = New System.Drawing.Point(379, 20)
        Me.chkMoveBlock.Name = "chkMoveBlock"
        Me.chkMoveBlock.Size = New System.Drawing.Size(55, 16)
        Me.chkMoveBlock.TabIndex = 29
        Me.chkMoveBlock.Text = "Block"
        Me.chkMoveBlock.UseVisualStyleBackColor = True
        '
        'btnPosStop
        '
        Me.btnPosStop.Location = New System.Drawing.Point(379, 78)
        Me.btnPosStop.Name = "btnPosStop"
        Me.btnPosStop.Size = New System.Drawing.Size(66, 33)
        Me.btnPosStop.TabIndex = 33
        Me.btnPosStop.Text = "Stop"
        Me.btnPosStop.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(9, 23)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(98, 12)
        Me.Label8.TabIndex = 32
        Me.Label8.Text = "Target Position :"
        '
        'edtMovePos03
        '
        Me.edtMovePos03.Location = New System.Drawing.Point(311, 18)
        Me.edtMovePos03.Name = "edtMovePos03"
        Me.edtMovePos03.Size = New System.Drawing.Size(65, 21)
        Me.edtMovePos03.TabIndex = 31
        Me.edtMovePos03.Text = "100.000"
        Me.edtMovePos03.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'edtMovePos02
        '
        Me.edtMovePos02.Location = New System.Drawing.Point(243, 18)
        Me.edtMovePos02.Name = "edtMovePos02"
        Me.edtMovePos02.Size = New System.Drawing.Size(65, 21)
        Me.edtMovePos02.TabIndex = 30
        Me.edtMovePos02.Text = "100.000"
        Me.edtMovePos02.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'edtMovePos01
        '
        Me.edtMovePos01.Location = New System.Drawing.Point(175, 18)
        Me.edtMovePos01.Name = "edtMovePos01"
        Me.edtMovePos01.Size = New System.Drawing.Size(65, 21)
        Me.edtMovePos01.TabIndex = 29
        Me.edtMovePos01.Text = "100.000"
        Me.edtMovePos01.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'edtMovePos00
        '
        Me.edtMovePos00.Location = New System.Drawing.Point(107, 18)
        Me.edtMovePos00.Name = "edtMovePos00"
        Me.edtMovePos00.Size = New System.Drawing.Size(65, 21)
        Me.edtMovePos00.TabIndex = 28
        Me.edtMovePos00.Text = "100.000"
        Me.edtMovePos00.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnPosMove
        '
        Me.btnPosMove.Location = New System.Drawing.Point(379, 42)
        Me.btnPosMove.Name = "btnPosMove"
        Me.btnPosMove.Size = New System.Drawing.Size(66, 33)
        Me.btnPosMove.TabIndex = 26
        Me.btnPosMove.Text = "Move"
        Me.btnPosMove.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(9, 95)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(96, 12)
        Me.Label5.TabIndex = 25
        Me.Label5.Text = "Move Decel     :"
        '
        'edtMoveDec03
        '
        Me.edtMoveDec03.Location = New System.Drawing.Point(311, 90)
        Me.edtMoveDec03.Name = "edtMoveDec03"
        Me.edtMoveDec03.Size = New System.Drawing.Size(65, 21)
        Me.edtMoveDec03.TabIndex = 24
        Me.edtMoveDec03.Text = "400.000"
        Me.edtMoveDec03.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'edtMoveDec02
        '
        Me.edtMoveDec02.Location = New System.Drawing.Point(243, 90)
        Me.edtMoveDec02.Name = "edtMoveDec02"
        Me.edtMoveDec02.Size = New System.Drawing.Size(65, 21)
        Me.edtMoveDec02.TabIndex = 23
        Me.edtMoveDec02.Text = "400.000"
        Me.edtMoveDec02.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'edtMoveDec01
        '
        Me.edtMoveDec01.Location = New System.Drawing.Point(175, 90)
        Me.edtMoveDec01.Name = "edtMoveDec01"
        Me.edtMoveDec01.Size = New System.Drawing.Size(65, 21)
        Me.edtMoveDec01.TabIndex = 22
        Me.edtMoveDec01.Text = "400.000"
        Me.edtMoveDec01.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'edtMoveDec00
        '
        Me.edtMoveDec00.Location = New System.Drawing.Point(107, 90)
        Me.edtMoveDec00.Name = "edtMoveDec00"
        Me.edtMoveDec00.Size = New System.Drawing.Size(65, 21)
        Me.edtMoveDec00.TabIndex = 21
        Me.edtMoveDec00.Text = "400.000"
        Me.edtMoveDec00.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(9, 71)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(96, 12)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "Move Accel     :"
        '
        'edtMoveAcc03
        '
        Me.edtMoveAcc03.Location = New System.Drawing.Point(311, 66)
        Me.edtMoveAcc03.Name = "edtMoveAcc03"
        Me.edtMoveAcc03.Size = New System.Drawing.Size(65, 21)
        Me.edtMoveAcc03.TabIndex = 19
        Me.edtMoveAcc03.Text = "400.000"
        Me.edtMoveAcc03.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'edtMoveAcc02
        '
        Me.edtMoveAcc02.Location = New System.Drawing.Point(243, 66)
        Me.edtMoveAcc02.Name = "edtMoveAcc02"
        Me.edtMoveAcc02.Size = New System.Drawing.Size(65, 21)
        Me.edtMoveAcc02.TabIndex = 18
        Me.edtMoveAcc02.Text = "400.000"
        Me.edtMoveAcc02.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'edtMoveAcc01
        '
        Me.edtMoveAcc01.Location = New System.Drawing.Point(175, 66)
        Me.edtMoveAcc01.Name = "edtMoveAcc01"
        Me.edtMoveAcc01.Size = New System.Drawing.Size(65, 21)
        Me.edtMoveAcc01.TabIndex = 17
        Me.edtMoveAcc01.Text = "400.000"
        Me.edtMoveAcc01.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'edtMoveAcc00
        '
        Me.edtMoveAcc00.Location = New System.Drawing.Point(107, 66)
        Me.edtMoveAcc00.Name = "edtMoveAcc00"
        Me.edtMoveAcc00.Size = New System.Drawing.Size(65, 21)
        Me.edtMoveAcc00.TabIndex = 16
        Me.edtMoveAcc00.Text = "400.000"
        Me.edtMoveAcc00.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(9, 47)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(97, 12)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Move Velocity  :"
        '
        'edtMoveVel03
        '
        Me.edtMoveVel03.Location = New System.Drawing.Point(311, 42)
        Me.edtMoveVel03.Name = "edtMoveVel03"
        Me.edtMoveVel03.Size = New System.Drawing.Size(65, 21)
        Me.edtMoveVel03.TabIndex = 7
        Me.edtMoveVel03.Text = "100.000"
        Me.edtMoveVel03.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'edtMoveVel02
        '
        Me.edtMoveVel02.Location = New System.Drawing.Point(243, 42)
        Me.edtMoveVel02.Name = "edtMoveVel02"
        Me.edtMoveVel02.Size = New System.Drawing.Size(65, 21)
        Me.edtMoveVel02.TabIndex = 6
        Me.edtMoveVel02.Text = "100.000"
        Me.edtMoveVel02.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'edtMoveVel01
        '
        Me.edtMoveVel01.Location = New System.Drawing.Point(175, 42)
        Me.edtMoveVel01.Name = "edtMoveVel01"
        Me.edtMoveVel01.Size = New System.Drawing.Size(65, 21)
        Me.edtMoveVel01.TabIndex = 5
        Me.edtMoveVel01.Text = "100.000"
        Me.edtMoveVel01.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'edtMoveVel00
        '
        Me.edtMoveVel00.Location = New System.Drawing.Point(107, 42)
        Me.edtMoveVel00.Name = "edtMoveVel00"
        Me.edtMoveVel00.Size = New System.Drawing.Size(65, 21)
        Me.edtMoveVel00.TabIndex = 4
        Me.edtMoveVel00.Text = "100.000"
        Me.edtMoveVel00.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnJogN)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.edtJogVel03)
        Me.GroupBox3.Controls.Add(Me.edtJogVel02)
        Me.GroupBox3.Controls.Add(Me.edtJogVel01)
        Me.GroupBox3.Controls.Add(Me.edtJogVel00)
        Me.GroupBox3.Controls.Add(Me.btnJogP)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.edtJogDec03)
        Me.GroupBox3.Controls.Add(Me.edtJogDec02)
        Me.GroupBox3.Controls.Add(Me.edtJogDec01)
        Me.GroupBox3.Controls.Add(Me.edtJogDec00)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.edtJogAcc03)
        Me.GroupBox3.Controls.Add(Me.edtJogAcc02)
        Me.GroupBox3.Controls.Add(Me.edtJogAcc01)
        Me.GroupBox3.Controls.Add(Me.edtJogAcc00)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 305)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(455, 95)
        Me.GroupBox3.TabIndex = 34
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "< Multi Jog(Velocity) Move >"
        '
        'btnJogN
        '
        Me.btnJogN.Location = New System.Drawing.Point(379, 54)
        Me.btnJogN.Name = "btnJogN"
        Me.btnJogN.Size = New System.Drawing.Size(66, 33)
        Me.btnJogN.TabIndex = 33
        Me.btnJogN.Text = "Jog(-)"
        Me.btnJogN.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(9, 23)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(97, 12)
        Me.Label9.TabIndex = 32
        Me.Label9.Text = "Move Velocity  :"
        '
        'edtJogVel03
        '
        Me.edtJogVel03.Location = New System.Drawing.Point(311, 18)
        Me.edtJogVel03.Name = "edtJogVel03"
        Me.edtJogVel03.Size = New System.Drawing.Size(65, 21)
        Me.edtJogVel03.TabIndex = 31
        Me.edtJogVel03.Text = "100.000"
        Me.edtJogVel03.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'edtJogVel02
        '
        Me.edtJogVel02.Location = New System.Drawing.Point(243, 18)
        Me.edtJogVel02.Name = "edtJogVel02"
        Me.edtJogVel02.Size = New System.Drawing.Size(65, 21)
        Me.edtJogVel02.TabIndex = 30
        Me.edtJogVel02.Text = "100.000"
        Me.edtJogVel02.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'edtJogVel01
        '
        Me.edtJogVel01.Location = New System.Drawing.Point(175, 18)
        Me.edtJogVel01.Name = "edtJogVel01"
        Me.edtJogVel01.Size = New System.Drawing.Size(65, 21)
        Me.edtJogVel01.TabIndex = 29
        Me.edtJogVel01.Text = "100.000"
        Me.edtJogVel01.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'edtJogVel00
        '
        Me.edtJogVel00.Location = New System.Drawing.Point(107, 18)
        Me.edtJogVel00.Name = "edtJogVel00"
        Me.edtJogVel00.Size = New System.Drawing.Size(65, 21)
        Me.edtJogVel00.TabIndex = 28
        Me.edtJogVel00.Text = "100.000"
        Me.edtJogVel00.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnJogP
        '
        Me.btnJogP.Location = New System.Drawing.Point(379, 18)
        Me.btnJogP.Name = "btnJogP"
        Me.btnJogP.Size = New System.Drawing.Size(66, 33)
        Me.btnJogP.TabIndex = 26
        Me.btnJogP.Text = "Jog(+)"
        Me.btnJogP.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(9, 71)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(96, 12)
        Me.Label11.TabIndex = 20
        Me.Label11.Text = "Move Decel     :"
        '
        'edtJogDec03
        '
        Me.edtJogDec03.Location = New System.Drawing.Point(311, 66)
        Me.edtJogDec03.Name = "edtJogDec03"
        Me.edtJogDec03.Size = New System.Drawing.Size(65, 21)
        Me.edtJogDec03.TabIndex = 19
        Me.edtJogDec03.Text = "400.000"
        Me.edtJogDec03.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'edtJogDec02
        '
        Me.edtJogDec02.Location = New System.Drawing.Point(243, 66)
        Me.edtJogDec02.Name = "edtJogDec02"
        Me.edtJogDec02.Size = New System.Drawing.Size(65, 21)
        Me.edtJogDec02.TabIndex = 18
        Me.edtJogDec02.Text = "400.000"
        Me.edtJogDec02.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'edtJogDec01
        '
        Me.edtJogDec01.Location = New System.Drawing.Point(175, 66)
        Me.edtJogDec01.Name = "edtJogDec01"
        Me.edtJogDec01.Size = New System.Drawing.Size(65, 21)
        Me.edtJogDec01.TabIndex = 17
        Me.edtJogDec01.Text = "400.000"
        Me.edtJogDec01.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'edtJogDec00
        '
        Me.edtJogDec00.Location = New System.Drawing.Point(107, 66)
        Me.edtJogDec00.Name = "edtJogDec00"
        Me.edtJogDec00.Size = New System.Drawing.Size(65, 21)
        Me.edtJogDec00.TabIndex = 16
        Me.edtJogDec00.Text = "400.000"
        Me.edtJogDec00.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(9, 47)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(96, 12)
        Me.Label12.TabIndex = 15
        Me.Label12.Text = "Move Accel     :"
        '
        'edtJogAcc03
        '
        Me.edtJogAcc03.Location = New System.Drawing.Point(311, 42)
        Me.edtJogAcc03.Name = "edtJogAcc03"
        Me.edtJogAcc03.Size = New System.Drawing.Size(65, 21)
        Me.edtJogAcc03.TabIndex = 7
        Me.edtJogAcc03.Text = "400.000"
        Me.edtJogAcc03.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'edtJogAcc02
        '
        Me.edtJogAcc02.Location = New System.Drawing.Point(243, 42)
        Me.edtJogAcc02.Name = "edtJogAcc02"
        Me.edtJogAcc02.Size = New System.Drawing.Size(65, 21)
        Me.edtJogAcc02.TabIndex = 6
        Me.edtJogAcc02.Text = "400.000"
        Me.edtJogAcc02.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'edtJogAcc01
        '
        Me.edtJogAcc01.Location = New System.Drawing.Point(175, 42)
        Me.edtJogAcc01.Name = "edtJogAcc01"
        Me.edtJogAcc01.Size = New System.Drawing.Size(65, 21)
        Me.edtJogAcc01.TabIndex = 5
        Me.edtJogAcc01.Text = "400.000"
        Me.edtJogAcc01.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'edtJogAcc00
        '
        Me.edtJogAcc00.Location = New System.Drawing.Point(107, 42)
        Me.edtJogAcc00.Name = "edtJogAcc00"
        Me.edtJogAcc00.Size = New System.Drawing.Size(65, 21)
        Me.edtJogAcc00.TabIndex = 4
        Me.edtJogAcc00.Text = "400.000"
        Me.edtJogAcc00.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.btnLineN)
        Me.GroupBox4.Controls.Add(Me.Label10)
        Me.GroupBox4.Controls.Add(Me.edtLinePos03)
        Me.GroupBox4.Controls.Add(Me.edtLinePos02)
        Me.GroupBox4.Controls.Add(Me.edtLinePos01)
        Me.GroupBox4.Controls.Add(Me.edtLinePos00)
        Me.GroupBox4.Controls.Add(Me.btnLineP)
        Me.GroupBox4.Controls.Add(Me.Label13)
        Me.GroupBox4.Controls.Add(Me.edtLineDec)
        Me.GroupBox4.Controls.Add(Me.edtLineAcc)
        Me.GroupBox4.Controls.Add(Me.Label14)
        Me.GroupBox4.Controls.Add(Me.edtLineVel)
        Me.GroupBox4.Location = New System.Drawing.Point(12, 409)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(455, 95)
        Me.GroupBox4.TabIndex = 35
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "< Multi Jog(Velocity) Line Move >"
        '
        'btnLineN
        '
        Me.btnLineN.Location = New System.Drawing.Point(379, 54)
        Me.btnLineN.Name = "btnLineN"
        Me.btnLineN.Size = New System.Drawing.Size(66, 33)
        Me.btnLineN.TabIndex = 33
        Me.btnLineN.Text = "Jog(-)"
        Me.btnLineN.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(9, 23)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(98, 12)
        Me.Label10.TabIndex = 32
        Me.Label10.Text = "Target Position :"
        '
        'edtLinePos03
        '
        Me.edtLinePos03.Location = New System.Drawing.Point(311, 18)
        Me.edtLinePos03.Name = "edtLinePos03"
        Me.edtLinePos03.Size = New System.Drawing.Size(65, 21)
        Me.edtLinePos03.TabIndex = 31
        Me.edtLinePos03.Text = "100.000"
        Me.edtLinePos03.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'edtLinePos02
        '
        Me.edtLinePos02.Location = New System.Drawing.Point(243, 18)
        Me.edtLinePos02.Name = "edtLinePos02"
        Me.edtLinePos02.Size = New System.Drawing.Size(65, 21)
        Me.edtLinePos02.TabIndex = 30
        Me.edtLinePos02.Text = "100.000"
        Me.edtLinePos02.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'edtLinePos01
        '
        Me.edtLinePos01.Location = New System.Drawing.Point(175, 18)
        Me.edtLinePos01.Name = "edtLinePos01"
        Me.edtLinePos01.Size = New System.Drawing.Size(65, 21)
        Me.edtLinePos01.TabIndex = 29
        Me.edtLinePos01.Text = "100.000"
        Me.edtLinePos01.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'edtLinePos00
        '
        Me.edtLinePos00.Location = New System.Drawing.Point(107, 18)
        Me.edtLinePos00.Name = "edtLinePos00"
        Me.edtLinePos00.Size = New System.Drawing.Size(65, 21)
        Me.edtLinePos00.TabIndex = 28
        Me.edtLinePos00.Text = "100.000"
        Me.edtLinePos00.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnLineP
        '
        Me.btnLineP.Location = New System.Drawing.Point(379, 18)
        Me.btnLineP.Name = "btnLineP"
        Me.btnLineP.Size = New System.Drawing.Size(66, 33)
        Me.btnLineP.TabIndex = 26
        Me.btnLineP.Text = "Jog(+)"
        Me.btnLineP.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(9, 71)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(98, 12)
        Me.Label13.TabIndex = 20
        Me.Label13.Text = "Move Acc/Dec :"
        '
        'edtLineDec
        '
        Me.edtLineDec.Location = New System.Drawing.Point(243, 66)
        Me.edtLineDec.Name = "edtLineDec"
        Me.edtLineDec.Size = New System.Drawing.Size(133, 21)
        Me.edtLineDec.TabIndex = 18
        Me.edtLineDec.Text = "200.000"
        Me.edtLineDec.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'edtLineAcc
        '
        Me.edtLineAcc.Location = New System.Drawing.Point(107, 66)
        Me.edtLineAcc.Name = "edtLineAcc"
        Me.edtLineAcc.Size = New System.Drawing.Size(133, 21)
        Me.edtLineAcc.TabIndex = 16
        Me.edtLineAcc.Text = "400.000"
        Me.edtLineAcc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(9, 47)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(97, 12)
        Me.Label14.TabIndex = 15
        Me.Label14.Text = "Move Velocity  :"
        '
        'edtLineVel
        '
        Me.edtLineVel.Location = New System.Drawing.Point(107, 42)
        Me.edtLineVel.Name = "edtLineVel"
        Me.edtLineVel.Size = New System.Drawing.Size(133, 21)
        Me.edtLineVel.TabIndex = 4
        Me.edtLineVel.Text = "100.000"
        Me.edtLineVel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'm_timer
        '
        Me.m_timer.Enabled = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'MoveMultiAxes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(479, 511)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnLoadFile)
        Me.Controls.Add(Me.cboSelAxis)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MoveMultiAxes"
        Me.Text = "MoveMultiAxes"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chkAxis00 As System.Windows.Forms.CheckBox
    Friend WithEvents stcCmdPos00 As System.Windows.Forms.TextBox
    Friend WithEvents chkAxis03 As System.Windows.Forms.CheckBox
    Friend WithEvents chkAxis02 As System.Windows.Forms.CheckBox
    Friend WithEvents chkAxis01 As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents stcCmdPos03 As System.Windows.Forms.TextBox
    Friend WithEvents stcCmdPos02 As System.Windows.Forms.TextBox
    Friend WithEvents stcCmdPos01 As System.Windows.Forms.TextBox
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
    Friend WithEvents chkServoOn As System.Windows.Forms.CheckBox
    Friend WithEvents btnPosClear As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents edtMovePos03 As System.Windows.Forms.TextBox
    Friend WithEvents edtMovePos02 As System.Windows.Forms.TextBox
    Friend WithEvents edtMovePos01 As System.Windows.Forms.TextBox
    Friend WithEvents edtMovePos00 As System.Windows.Forms.TextBox
    Friend WithEvents btnPosMove As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents edtMoveDec03 As System.Windows.Forms.TextBox
    Friend WithEvents edtMoveDec02 As System.Windows.Forms.TextBox
    Friend WithEvents edtMoveDec01 As System.Windows.Forms.TextBox
    Friend WithEvents edtMoveDec00 As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents edtMoveAcc03 As System.Windows.Forms.TextBox
    Friend WithEvents edtMoveAcc02 As System.Windows.Forms.TextBox
    Friend WithEvents edtMoveAcc01 As System.Windows.Forms.TextBox
    Friend WithEvents edtMoveAcc00 As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents edtMoveVel03 As System.Windows.Forms.TextBox
    Friend WithEvents edtMoveVel02 As System.Windows.Forms.TextBox
    Friend WithEvents edtMoveVel01 As System.Windows.Forms.TextBox
    Friend WithEvents edtMoveVel00 As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents chkMoveBlock As System.Windows.Forms.CheckBox
    Friend WithEvents btnPosStop As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btnJogN As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents edtJogVel03 As System.Windows.Forms.TextBox
    Friend WithEvents edtJogVel02 As System.Windows.Forms.TextBox
    Friend WithEvents edtJogVel01 As System.Windows.Forms.TextBox
    Friend WithEvents edtJogVel00 As System.Windows.Forms.TextBox
    Friend WithEvents btnJogP As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents edtJogDec03 As System.Windows.Forms.TextBox
    Friend WithEvents edtJogDec02 As System.Windows.Forms.TextBox
    Friend WithEvents edtJogDec01 As System.Windows.Forms.TextBox
    Friend WithEvents edtJogDec00 As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents edtJogAcc03 As System.Windows.Forms.TextBox
    Friend WithEvents edtJogAcc02 As System.Windows.Forms.TextBox
    Friend WithEvents edtJogAcc01 As System.Windows.Forms.TextBox
    Friend WithEvents edtJogAcc00 As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents btnLineN As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents edtLinePos03 As System.Windows.Forms.TextBox
    Friend WithEvents edtLinePos02 As System.Windows.Forms.TextBox
    Friend WithEvents edtLinePos01 As System.Windows.Forms.TextBox
    Friend WithEvents edtLinePos00 As System.Windows.Forms.TextBox
    Friend WithEvents btnLineP As System.Windows.Forms.Button
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents edtLineDec As System.Windows.Forms.TextBox
    Friend WithEvents edtLineAcc As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents edtLineVel As System.Windows.Forms.TextBox
    Friend WithEvents m_timer As System.Windows.Forms.Timer
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog

End Class
