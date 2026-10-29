Option Strict Off
Option Explicit On
Friend Class frmDigitalIO
	Inherits System.Windows.Forms.Form
#Region "Windows Form 디자이너에서 생성한 코드 "
	Public Sub New()
		MyBase.New()
		If m_vb6FormDefInstance Is Nothing Then
			If m_InitializingDefInstance Then
				m_vb6FormDefInstance = Me
			Else
				Try 
					'시작 폼의 경우 처음 만든 인스턴스가 기본 인스턴스가 됩니다.
					If System.Reflection.Assembly.GetExecutingAssembly.EntryPoint.DeclaringType Is Me.GetType Then
						m_vb6FormDefInstance = Me
					End If
				Catch
				End Try
			End If
		End If
		'이 호출은 Windows Form 디자이너에 필요합니다.
		InitializeComponent()
	End Sub
	'Form은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
	Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
		If Disposing Then
			If Not components Is Nothing Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(Disposing)
	End Sub
	'Windows Form 디자이너에 필요합니다.
	Private components As System.ComponentModel.IContainer
	Public ToolTip1 As System.Windows.Forms.ToolTip
	Public WithEvents Timer1 As System.Windows.Forms.Timer
	Public WithEvents chkInterrupt As System.Windows.Forms.CheckBox
	Public WithEvents chkFalling As System.Windows.Forms.CheckBox
	Public WithEvents chkRising As System.Windows.Forms.CheckBox
	Public WithEvents List1 As System.Windows.Forms.ListBox
	Public WithEvents cmdListClear As System.Windows.Forms.Button
	Public WithEvents cmdClose As System.Windows.Forms.Button
	Public WithEvents _chk2ndWord_0 As System.Windows.Forms.CheckBox
	Public WithEvents _chk2ndWord_1 As System.Windows.Forms.CheckBox
	Public WithEvents _chk2ndWord_2 As System.Windows.Forms.CheckBox
	Public WithEvents _chk2ndWord_3 As System.Windows.Forms.CheckBox
	Public WithEvents _chk2ndWord_4 As System.Windows.Forms.CheckBox
	Public WithEvents _chk2ndWord_5 As System.Windows.Forms.CheckBox
	Public WithEvents _chk2ndWord_6 As System.Windows.Forms.CheckBox
	Public WithEvents _chk2ndWord_7 As System.Windows.Forms.CheckBox
	Public WithEvents _chk2ndWord_8 As System.Windows.Forms.CheckBox
	Public WithEvents _chk2ndWord_9 As System.Windows.Forms.CheckBox
	Public WithEvents _chk2ndWord_10 As System.Windows.Forms.CheckBox
	Public WithEvents _chk2ndWord_11 As System.Windows.Forms.CheckBox
	Public WithEvents _chk2ndWord_12 As System.Windows.Forms.CheckBox
	Public WithEvents _chk2ndWord_13 As System.Windows.Forms.CheckBox
	Public WithEvents _chk2ndWord_14 As System.Windows.Forms.CheckBox
	Public WithEvents _chk2ndWord_15 As System.Windows.Forms.CheckBox
	Public WithEvents Fra2ndWord As System.Windows.Forms.GroupBox
	Public WithEvents _chk1stWord_0 As System.Windows.Forms.CheckBox
	Public WithEvents _chk1stWord_1 As System.Windows.Forms.CheckBox
	Public WithEvents _chk1stWord_2 As System.Windows.Forms.CheckBox
	Public WithEvents _chk1stWord_3 As System.Windows.Forms.CheckBox
	Public WithEvents _chk1stWord_4 As System.Windows.Forms.CheckBox
	Public WithEvents _chk1stWord_5 As System.Windows.Forms.CheckBox
	Public WithEvents _chk1stWord_6 As System.Windows.Forms.CheckBox
	Public WithEvents _chk1stWord_7 As System.Windows.Forms.CheckBox
	Public WithEvents _chk1stWord_8 As System.Windows.Forms.CheckBox
	Public WithEvents _chk1stWord_9 As System.Windows.Forms.CheckBox
	Public WithEvents _chk1stWord_10 As System.Windows.Forms.CheckBox
	Public WithEvents _chk1stWord_11 As System.Windows.Forms.CheckBox
	Public WithEvents _chk1stWord_12 As System.Windows.Forms.CheckBox
	Public WithEvents _chk1stWord_13 As System.Windows.Forms.CheckBox
	Public WithEvents _chk1stWord_14 As System.Windows.Forms.CheckBox
	Public WithEvents _chk1stWord_15 As System.Windows.Forms.CheckBox
	Public WithEvents Fra1stWord As System.Windows.Forms.GroupBox
	Public WithEvents cobModule As System.Windows.Forms.ComboBox
	Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents chk1stWord As Microsoft.VisualBasic.Compatibility.VB6.CheckBoxArray
    Friend WithEvents AxtMsg As AxAXTMESSENGERLib.AxAxtMessenger
	Public WithEvents chk2ndWord As Microsoft.VisualBasic.Compatibility.VB6.CheckBoxArray
	'참고: 다음 프로시저는 Windows Form 디자이너에 필요합니다.
	'Windows Form 디자이너를 사용하여 수정할 수 있습니다.
	'코드 편집기를 사용하여 수정하지 마십시오.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDigitalIO))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.chkInterrupt = New System.Windows.Forms.CheckBox
        Me.chkFalling = New System.Windows.Forms.CheckBox
        Me.chkRising = New System.Windows.Forms.CheckBox
        Me.List1 = New System.Windows.Forms.ListBox
        Me.cmdListClear = New System.Windows.Forms.Button
        Me.cmdClose = New System.Windows.Forms.Button
        Me.Fra2ndWord = New System.Windows.Forms.GroupBox
        Me._chk2ndWord_0 = New System.Windows.Forms.CheckBox
        Me._chk2ndWord_1 = New System.Windows.Forms.CheckBox
        Me._chk2ndWord_2 = New System.Windows.Forms.CheckBox
        Me._chk2ndWord_3 = New System.Windows.Forms.CheckBox
        Me._chk2ndWord_4 = New System.Windows.Forms.CheckBox
        Me._chk2ndWord_5 = New System.Windows.Forms.CheckBox
        Me._chk2ndWord_6 = New System.Windows.Forms.CheckBox
        Me._chk2ndWord_7 = New System.Windows.Forms.CheckBox
        Me._chk2ndWord_8 = New System.Windows.Forms.CheckBox
        Me._chk2ndWord_9 = New System.Windows.Forms.CheckBox
        Me._chk2ndWord_10 = New System.Windows.Forms.CheckBox
        Me._chk2ndWord_11 = New System.Windows.Forms.CheckBox
        Me._chk2ndWord_12 = New System.Windows.Forms.CheckBox
        Me._chk2ndWord_13 = New System.Windows.Forms.CheckBox
        Me._chk2ndWord_14 = New System.Windows.Forms.CheckBox
        Me._chk2ndWord_15 = New System.Windows.Forms.CheckBox
        Me.Fra1stWord = New System.Windows.Forms.GroupBox
        Me._chk1stWord_0 = New System.Windows.Forms.CheckBox
        Me._chk1stWord_1 = New System.Windows.Forms.CheckBox
        Me._chk1stWord_2 = New System.Windows.Forms.CheckBox
        Me._chk1stWord_3 = New System.Windows.Forms.CheckBox
        Me._chk1stWord_4 = New System.Windows.Forms.CheckBox
        Me._chk1stWord_5 = New System.Windows.Forms.CheckBox
        Me._chk1stWord_6 = New System.Windows.Forms.CheckBox
        Me._chk1stWord_7 = New System.Windows.Forms.CheckBox
        Me._chk1stWord_8 = New System.Windows.Forms.CheckBox
        Me._chk1stWord_9 = New System.Windows.Forms.CheckBox
        Me._chk1stWord_10 = New System.Windows.Forms.CheckBox
        Me._chk1stWord_11 = New System.Windows.Forms.CheckBox
        Me._chk1stWord_12 = New System.Windows.Forms.CheckBox
        Me._chk1stWord_13 = New System.Windows.Forms.CheckBox
        Me._chk1stWord_14 = New System.Windows.Forms.CheckBox
        Me._chk1stWord_15 = New System.Windows.Forms.CheckBox
        Me.cobModule = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.chk1stWord = New Microsoft.VisualBasic.Compatibility.VB6.CheckBoxArray(Me.components)
        Me.chk2ndWord = New Microsoft.VisualBasic.Compatibility.VB6.CheckBoxArray(Me.components)
        Me.AxtMsg = New AxAXTMESSENGERLib.AxAxtMessenger
        Me.Fra2ndWord.SuspendLayout()
        Me.Fra1stWord.SuspendLayout()
        CType(Me.chk1stWord, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chk2ndWord, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AxtMsg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 50
        '
        'chkInterrupt
        '
        Me.chkInterrupt.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkInterrupt.BackColor = System.Drawing.SystemColors.Control
        Me.chkInterrupt.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkInterrupt.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkInterrupt.Location = New System.Drawing.Point(16, 40)
        Me.chkInterrupt.Name = "chkInterrupt"
        Me.chkInterrupt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkInterrupt.Size = New System.Drawing.Size(185, 25)
        Me.chkInterrupt.TabIndex = 41
        Me.chkInterrupt.Text = "Enable Interrupt"
        Me.chkInterrupt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkInterrupt.UseVisualStyleBackColor = False
        '
        'chkFalling
        '
        Me.chkFalling.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkFalling.BackColor = System.Drawing.SystemColors.Control
        Me.chkFalling.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkFalling.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkFalling.Location = New System.Drawing.Point(336, 40)
        Me.chkFalling.Name = "chkFalling"
        Me.chkFalling.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkFalling.Size = New System.Drawing.Size(89, 25)
        Me.chkFalling.TabIndex = 40
        Me.chkFalling.Text = "Falling"
        Me.chkFalling.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkFalling.UseVisualStyleBackColor = False
        '
        'chkRising
        '
        Me.chkRising.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkRising.BackColor = System.Drawing.SystemColors.Control
        Me.chkRising.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkRising.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkRising.Location = New System.Drawing.Point(224, 40)
        Me.chkRising.Name = "chkRising"
        Me.chkRising.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkRising.Size = New System.Drawing.Size(89, 25)
        Me.chkRising.TabIndex = 39
        Me.chkRising.Text = "Rising"
        Me.chkRising.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkRising.UseVisualStyleBackColor = False
        '
        'List1
        '
        Me.List1.BackColor = System.Drawing.SystemColors.Window
        Me.List1.Cursor = System.Windows.Forms.Cursors.Default
        Me.List1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.List1.ItemHeight = 12
        Me.List1.Location = New System.Drawing.Point(16, 240)
        Me.List1.Name = "List1"
        Me.List1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.List1.Size = New System.Drawing.Size(449, 184)
        Me.List1.TabIndex = 38
        '
        'cmdListClear
        '
        Me.cmdListClear.BackColor = System.Drawing.SystemColors.Control
        Me.cmdListClear.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdListClear.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdListClear.Location = New System.Drawing.Point(16, 432)
        Me.cmdListClear.Name = "cmdListClear"
        Me.cmdListClear.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdListClear.Size = New System.Drawing.Size(185, 33)
        Me.cmdListClear.TabIndex = 37
        Me.cmdListClear.Text = "List Clear"
        Me.cmdListClear.UseVisualStyleBackColor = False
        '
        'cmdClose
        '
        Me.cmdClose.BackColor = System.Drawing.SystemColors.Control
        Me.cmdClose.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdClose.Location = New System.Drawing.Point(280, 432)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdClose.Size = New System.Drawing.Size(185, 33)
        Me.cmdClose.TabIndex = 36
        Me.cmdClose.Text = "Close"
        Me.cmdClose.UseVisualStyleBackColor = False
        '
        'Fra2ndWord
        '
        Me.Fra2ndWord.BackColor = System.Drawing.SystemColors.Control
        Me.Fra2ndWord.Controls.Add(Me._chk2ndWord_0)
        Me.Fra2ndWord.Controls.Add(Me._chk2ndWord_1)
        Me.Fra2ndWord.Controls.Add(Me._chk2ndWord_2)
        Me.Fra2ndWord.Controls.Add(Me._chk2ndWord_3)
        Me.Fra2ndWord.Controls.Add(Me._chk2ndWord_4)
        Me.Fra2ndWord.Controls.Add(Me._chk2ndWord_5)
        Me.Fra2ndWord.Controls.Add(Me._chk2ndWord_6)
        Me.Fra2ndWord.Controls.Add(Me._chk2ndWord_7)
        Me.Fra2ndWord.Controls.Add(Me._chk2ndWord_8)
        Me.Fra2ndWord.Controls.Add(Me._chk2ndWord_9)
        Me.Fra2ndWord.Controls.Add(Me._chk2ndWord_10)
        Me.Fra2ndWord.Controls.Add(Me._chk2ndWord_11)
        Me.Fra2ndWord.Controls.Add(Me._chk2ndWord_12)
        Me.Fra2ndWord.Controls.Add(Me._chk2ndWord_13)
        Me.Fra2ndWord.Controls.Add(Me._chk2ndWord_14)
        Me.Fra2ndWord.Controls.Add(Me._chk2ndWord_15)
        Me.Fra2ndWord.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Fra2ndWord.Location = New System.Drawing.Point(16, 160)
        Me.Fra2ndWord.Name = "Fra2ndWord"
        Me.Fra2ndWord.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Fra2ndWord.Size = New System.Drawing.Size(449, 73)
        Me.Fra2ndWord.TabIndex = 19
        Me.Fra2ndWord.TabStop = False
        Me.Fra2ndWord.Text = "Frame2"
        '
        '_chk2ndWord_0
        '
        Me._chk2ndWord_0.BackColor = System.Drawing.SystemColors.Control
        Me._chk2ndWord_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._chk2ndWord_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chk2ndWord.SetIndex(Me._chk2ndWord_0, CType(0, Short))
        Me._chk2ndWord_0.Location = New System.Drawing.Point(16, 24)
        Me._chk2ndWord_0.Name = "_chk2ndWord_0"
        Me._chk2ndWord_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._chk2ndWord_0.Size = New System.Drawing.Size(41, 17)
        Me._chk2ndWord_0.TabIndex = 35
        Me._chk2ndWord_0.Text = "16"
        Me._chk2ndWord_0.UseVisualStyleBackColor = False
        '
        '_chk2ndWord_1
        '
        Me._chk2ndWord_1.BackColor = System.Drawing.SystemColors.Control
        Me._chk2ndWord_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._chk2ndWord_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chk2ndWord.SetIndex(Me._chk2ndWord_1, CType(1, Short))
        Me._chk2ndWord_1.Location = New System.Drawing.Point(72, 24)
        Me._chk2ndWord_1.Name = "_chk2ndWord_1"
        Me._chk2ndWord_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._chk2ndWord_1.Size = New System.Drawing.Size(41, 17)
        Me._chk2ndWord_1.TabIndex = 34
        Me._chk2ndWord_1.Text = "17"
        Me._chk2ndWord_1.UseVisualStyleBackColor = False
        '
        '_chk2ndWord_2
        '
        Me._chk2ndWord_2.BackColor = System.Drawing.SystemColors.Control
        Me._chk2ndWord_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._chk2ndWord_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chk2ndWord.SetIndex(Me._chk2ndWord_2, CType(2, Short))
        Me._chk2ndWord_2.Location = New System.Drawing.Point(128, 24)
        Me._chk2ndWord_2.Name = "_chk2ndWord_2"
        Me._chk2ndWord_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._chk2ndWord_2.Size = New System.Drawing.Size(41, 17)
        Me._chk2ndWord_2.TabIndex = 33
        Me._chk2ndWord_2.Text = "18"
        Me._chk2ndWord_2.UseVisualStyleBackColor = False
        '
        '_chk2ndWord_3
        '
        Me._chk2ndWord_3.BackColor = System.Drawing.SystemColors.Control
        Me._chk2ndWord_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._chk2ndWord_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chk2ndWord.SetIndex(Me._chk2ndWord_3, CType(3, Short))
        Me._chk2ndWord_3.Location = New System.Drawing.Point(176, 24)
        Me._chk2ndWord_3.Name = "_chk2ndWord_3"
        Me._chk2ndWord_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._chk2ndWord_3.Size = New System.Drawing.Size(41, 17)
        Me._chk2ndWord_3.TabIndex = 32
        Me._chk2ndWord_3.Text = "19"
        Me._chk2ndWord_3.UseVisualStyleBackColor = False
        '
        '_chk2ndWord_4
        '
        Me._chk2ndWord_4.BackColor = System.Drawing.SystemColors.Control
        Me._chk2ndWord_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._chk2ndWord_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chk2ndWord.SetIndex(Me._chk2ndWord_4, CType(4, Short))
        Me._chk2ndWord_4.Location = New System.Drawing.Point(232, 24)
        Me._chk2ndWord_4.Name = "_chk2ndWord_4"
        Me._chk2ndWord_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._chk2ndWord_4.Size = New System.Drawing.Size(41, 17)
        Me._chk2ndWord_4.TabIndex = 31
        Me._chk2ndWord_4.Text = "20"
        Me._chk2ndWord_4.UseVisualStyleBackColor = False
        '
        '_chk2ndWord_5
        '
        Me._chk2ndWord_5.BackColor = System.Drawing.SystemColors.Control
        Me._chk2ndWord_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._chk2ndWord_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chk2ndWord.SetIndex(Me._chk2ndWord_5, CType(5, Short))
        Me._chk2ndWord_5.Location = New System.Drawing.Point(288, 24)
        Me._chk2ndWord_5.Name = "_chk2ndWord_5"
        Me._chk2ndWord_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._chk2ndWord_5.Size = New System.Drawing.Size(41, 17)
        Me._chk2ndWord_5.TabIndex = 30
        Me._chk2ndWord_5.Text = "21"
        Me._chk2ndWord_5.UseVisualStyleBackColor = False
        '
        '_chk2ndWord_6
        '
        Me._chk2ndWord_6.BackColor = System.Drawing.SystemColors.Control
        Me._chk2ndWord_6.Cursor = System.Windows.Forms.Cursors.Default
        Me._chk2ndWord_6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chk2ndWord.SetIndex(Me._chk2ndWord_6, CType(6, Short))
        Me._chk2ndWord_6.Location = New System.Drawing.Point(344, 24)
        Me._chk2ndWord_6.Name = "_chk2ndWord_6"
        Me._chk2ndWord_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._chk2ndWord_6.Size = New System.Drawing.Size(41, 17)
        Me._chk2ndWord_6.TabIndex = 29
        Me._chk2ndWord_6.Text = "22"
        Me._chk2ndWord_6.UseVisualStyleBackColor = False
        '
        '_chk2ndWord_7
        '
        Me._chk2ndWord_7.BackColor = System.Drawing.SystemColors.Control
        Me._chk2ndWord_7.Cursor = System.Windows.Forms.Cursors.Default
        Me._chk2ndWord_7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chk2ndWord.SetIndex(Me._chk2ndWord_7, CType(7, Short))
        Me._chk2ndWord_7.Location = New System.Drawing.Point(400, 24)
        Me._chk2ndWord_7.Name = "_chk2ndWord_7"
        Me._chk2ndWord_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._chk2ndWord_7.Size = New System.Drawing.Size(41, 17)
        Me._chk2ndWord_7.TabIndex = 28
        Me._chk2ndWord_7.Text = "23"
        Me._chk2ndWord_7.UseVisualStyleBackColor = False
        '
        '_chk2ndWord_8
        '
        Me._chk2ndWord_8.BackColor = System.Drawing.SystemColors.Control
        Me._chk2ndWord_8.Cursor = System.Windows.Forms.Cursors.Default
        Me._chk2ndWord_8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chk2ndWord.SetIndex(Me._chk2ndWord_8, CType(8, Short))
        Me._chk2ndWord_8.Location = New System.Drawing.Point(16, 48)
        Me._chk2ndWord_8.Name = "_chk2ndWord_8"
        Me._chk2ndWord_8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._chk2ndWord_8.Size = New System.Drawing.Size(41, 17)
        Me._chk2ndWord_8.TabIndex = 27
        Me._chk2ndWord_8.Text = "24"
        Me._chk2ndWord_8.UseVisualStyleBackColor = False
        '
        '_chk2ndWord_9
        '
        Me._chk2ndWord_9.BackColor = System.Drawing.SystemColors.Control
        Me._chk2ndWord_9.Cursor = System.Windows.Forms.Cursors.Default
        Me._chk2ndWord_9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chk2ndWord.SetIndex(Me._chk2ndWord_9, CType(9, Short))
        Me._chk2ndWord_9.Location = New System.Drawing.Point(72, 48)
        Me._chk2ndWord_9.Name = "_chk2ndWord_9"
        Me._chk2ndWord_9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._chk2ndWord_9.Size = New System.Drawing.Size(41, 17)
        Me._chk2ndWord_9.TabIndex = 26
        Me._chk2ndWord_9.Text = "25"
        Me._chk2ndWord_9.UseVisualStyleBackColor = False
        '
        '_chk2ndWord_10
        '
        Me._chk2ndWord_10.BackColor = System.Drawing.SystemColors.Control
        Me._chk2ndWord_10.Cursor = System.Windows.Forms.Cursors.Default
        Me._chk2ndWord_10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chk2ndWord.SetIndex(Me._chk2ndWord_10, CType(10, Short))
        Me._chk2ndWord_10.Location = New System.Drawing.Point(128, 48)
        Me._chk2ndWord_10.Name = "_chk2ndWord_10"
        Me._chk2ndWord_10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._chk2ndWord_10.Size = New System.Drawing.Size(41, 17)
        Me._chk2ndWord_10.TabIndex = 25
        Me._chk2ndWord_10.Text = "26"
        Me._chk2ndWord_10.UseVisualStyleBackColor = False
        '
        '_chk2ndWord_11
        '
        Me._chk2ndWord_11.BackColor = System.Drawing.SystemColors.Control
        Me._chk2ndWord_11.Cursor = System.Windows.Forms.Cursors.Default
        Me._chk2ndWord_11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chk2ndWord.SetIndex(Me._chk2ndWord_11, CType(11, Short))
        Me._chk2ndWord_11.Location = New System.Drawing.Point(176, 48)
        Me._chk2ndWord_11.Name = "_chk2ndWord_11"
        Me._chk2ndWord_11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._chk2ndWord_11.Size = New System.Drawing.Size(41, 17)
        Me._chk2ndWord_11.TabIndex = 24
        Me._chk2ndWord_11.Text = "27"
        Me._chk2ndWord_11.UseVisualStyleBackColor = False
        '
        '_chk2ndWord_12
        '
        Me._chk2ndWord_12.BackColor = System.Drawing.SystemColors.Control
        Me._chk2ndWord_12.Cursor = System.Windows.Forms.Cursors.Default
        Me._chk2ndWord_12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chk2ndWord.SetIndex(Me._chk2ndWord_12, CType(12, Short))
        Me._chk2ndWord_12.Location = New System.Drawing.Point(232, 48)
        Me._chk2ndWord_12.Name = "_chk2ndWord_12"
        Me._chk2ndWord_12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._chk2ndWord_12.Size = New System.Drawing.Size(41, 17)
        Me._chk2ndWord_12.TabIndex = 23
        Me._chk2ndWord_12.Text = "28"
        Me._chk2ndWord_12.UseVisualStyleBackColor = False
        '
        '_chk2ndWord_13
        '
        Me._chk2ndWord_13.BackColor = System.Drawing.SystemColors.Control
        Me._chk2ndWord_13.Cursor = System.Windows.Forms.Cursors.Default
        Me._chk2ndWord_13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chk2ndWord.SetIndex(Me._chk2ndWord_13, CType(13, Short))
        Me._chk2ndWord_13.Location = New System.Drawing.Point(288, 48)
        Me._chk2ndWord_13.Name = "_chk2ndWord_13"
        Me._chk2ndWord_13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._chk2ndWord_13.Size = New System.Drawing.Size(41, 17)
        Me._chk2ndWord_13.TabIndex = 22
        Me._chk2ndWord_13.Text = "29"
        Me._chk2ndWord_13.UseVisualStyleBackColor = False
        '
        '_chk2ndWord_14
        '
        Me._chk2ndWord_14.BackColor = System.Drawing.SystemColors.Control
        Me._chk2ndWord_14.Cursor = System.Windows.Forms.Cursors.Default
        Me._chk2ndWord_14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chk2ndWord.SetIndex(Me._chk2ndWord_14, CType(14, Short))
        Me._chk2ndWord_14.Location = New System.Drawing.Point(344, 48)
        Me._chk2ndWord_14.Name = "_chk2ndWord_14"
        Me._chk2ndWord_14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._chk2ndWord_14.Size = New System.Drawing.Size(41, 17)
        Me._chk2ndWord_14.TabIndex = 21
        Me._chk2ndWord_14.Text = "30"
        Me._chk2ndWord_14.UseVisualStyleBackColor = False
        '
        '_chk2ndWord_15
        '
        Me._chk2ndWord_15.BackColor = System.Drawing.SystemColors.Control
        Me._chk2ndWord_15.Cursor = System.Windows.Forms.Cursors.Default
        Me._chk2ndWord_15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chk2ndWord.SetIndex(Me._chk2ndWord_15, CType(15, Short))
        Me._chk2ndWord_15.Location = New System.Drawing.Point(400, 48)
        Me._chk2ndWord_15.Name = "_chk2ndWord_15"
        Me._chk2ndWord_15.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._chk2ndWord_15.Size = New System.Drawing.Size(41, 17)
        Me._chk2ndWord_15.TabIndex = 20
        Me._chk2ndWord_15.Text = "31"
        Me._chk2ndWord_15.UseVisualStyleBackColor = False
        '
        'Fra1stWord
        '
        Me.Fra1stWord.BackColor = System.Drawing.SystemColors.Control
        Me.Fra1stWord.Controls.Add(Me._chk1stWord_0)
        Me.Fra1stWord.Controls.Add(Me._chk1stWord_1)
        Me.Fra1stWord.Controls.Add(Me._chk1stWord_2)
        Me.Fra1stWord.Controls.Add(Me._chk1stWord_3)
        Me.Fra1stWord.Controls.Add(Me._chk1stWord_4)
        Me.Fra1stWord.Controls.Add(Me._chk1stWord_5)
        Me.Fra1stWord.Controls.Add(Me._chk1stWord_6)
        Me.Fra1stWord.Controls.Add(Me._chk1stWord_7)
        Me.Fra1stWord.Controls.Add(Me._chk1stWord_8)
        Me.Fra1stWord.Controls.Add(Me._chk1stWord_9)
        Me.Fra1stWord.Controls.Add(Me._chk1stWord_10)
        Me.Fra1stWord.Controls.Add(Me._chk1stWord_11)
        Me.Fra1stWord.Controls.Add(Me._chk1stWord_12)
        Me.Fra1stWord.Controls.Add(Me._chk1stWord_13)
        Me.Fra1stWord.Controls.Add(Me._chk1stWord_14)
        Me.Fra1stWord.Controls.Add(Me._chk1stWord_15)
        Me.Fra1stWord.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Fra1stWord.Location = New System.Drawing.Point(16, 80)
        Me.Fra1stWord.Name = "Fra1stWord"
        Me.Fra1stWord.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Fra1stWord.Size = New System.Drawing.Size(449, 73)
        Me.Fra1stWord.TabIndex = 2
        Me.Fra1stWord.TabStop = False
        Me.Fra1stWord.Text = "Frame1"
        '
        '_chk1stWord_0
        '
        Me._chk1stWord_0.BackColor = System.Drawing.SystemColors.Control
        Me._chk1stWord_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._chk1stWord_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chk1stWord.SetIndex(Me._chk1stWord_0, CType(0, Short))
        Me._chk1stWord_0.Location = New System.Drawing.Point(16, 24)
        Me._chk1stWord_0.Name = "_chk1stWord_0"
        Me._chk1stWord_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._chk1stWord_0.Size = New System.Drawing.Size(41, 17)
        Me._chk1stWord_0.TabIndex = 18
        Me._chk1stWord_0.Text = "00"
        Me._chk1stWord_0.UseVisualStyleBackColor = False
        '
        '_chk1stWord_1
        '
        Me._chk1stWord_1.BackColor = System.Drawing.SystemColors.Control
        Me._chk1stWord_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._chk1stWord_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chk1stWord.SetIndex(Me._chk1stWord_1, CType(1, Short))
        Me._chk1stWord_1.Location = New System.Drawing.Point(72, 24)
        Me._chk1stWord_1.Name = "_chk1stWord_1"
        Me._chk1stWord_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._chk1stWord_1.Size = New System.Drawing.Size(41, 17)
        Me._chk1stWord_1.TabIndex = 17
        Me._chk1stWord_1.Text = "01"
        Me._chk1stWord_1.UseVisualStyleBackColor = False
        '
        '_chk1stWord_2
        '
        Me._chk1stWord_2.BackColor = System.Drawing.SystemColors.Control
        Me._chk1stWord_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._chk1stWord_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chk1stWord.SetIndex(Me._chk1stWord_2, CType(2, Short))
        Me._chk1stWord_2.Location = New System.Drawing.Point(128, 24)
        Me._chk1stWord_2.Name = "_chk1stWord_2"
        Me._chk1stWord_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._chk1stWord_2.Size = New System.Drawing.Size(41, 17)
        Me._chk1stWord_2.TabIndex = 16
        Me._chk1stWord_2.Text = "02"
        Me._chk1stWord_2.UseVisualStyleBackColor = False
        '
        '_chk1stWord_3
        '
        Me._chk1stWord_3.BackColor = System.Drawing.SystemColors.Control
        Me._chk1stWord_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._chk1stWord_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chk1stWord.SetIndex(Me._chk1stWord_3, CType(3, Short))
        Me._chk1stWord_3.Location = New System.Drawing.Point(176, 24)
        Me._chk1stWord_3.Name = "_chk1stWord_3"
        Me._chk1stWord_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._chk1stWord_3.Size = New System.Drawing.Size(41, 17)
        Me._chk1stWord_3.TabIndex = 15
        Me._chk1stWord_3.Text = "03"
        Me._chk1stWord_3.UseVisualStyleBackColor = False
        '
        '_chk1stWord_4
        '
        Me._chk1stWord_4.BackColor = System.Drawing.SystemColors.Control
        Me._chk1stWord_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._chk1stWord_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chk1stWord.SetIndex(Me._chk1stWord_4, CType(4, Short))
        Me._chk1stWord_4.Location = New System.Drawing.Point(232, 24)
        Me._chk1stWord_4.Name = "_chk1stWord_4"
        Me._chk1stWord_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._chk1stWord_4.Size = New System.Drawing.Size(41, 17)
        Me._chk1stWord_4.TabIndex = 14
        Me._chk1stWord_4.Text = "04"
        Me._chk1stWord_4.UseVisualStyleBackColor = False
        '
        '_chk1stWord_5
        '
        Me._chk1stWord_5.BackColor = System.Drawing.SystemColors.Control
        Me._chk1stWord_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._chk1stWord_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chk1stWord.SetIndex(Me._chk1stWord_5, CType(5, Short))
        Me._chk1stWord_5.Location = New System.Drawing.Point(288, 24)
        Me._chk1stWord_5.Name = "_chk1stWord_5"
        Me._chk1stWord_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._chk1stWord_5.Size = New System.Drawing.Size(41, 17)
        Me._chk1stWord_5.TabIndex = 13
        Me._chk1stWord_5.Text = "05"
        Me._chk1stWord_5.UseVisualStyleBackColor = False
        '
        '_chk1stWord_6
        '
        Me._chk1stWord_6.BackColor = System.Drawing.SystemColors.Control
        Me._chk1stWord_6.Cursor = System.Windows.Forms.Cursors.Default
        Me._chk1stWord_6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chk1stWord.SetIndex(Me._chk1stWord_6, CType(6, Short))
        Me._chk1stWord_6.Location = New System.Drawing.Point(344, 24)
        Me._chk1stWord_6.Name = "_chk1stWord_6"
        Me._chk1stWord_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._chk1stWord_6.Size = New System.Drawing.Size(41, 17)
        Me._chk1stWord_6.TabIndex = 12
        Me._chk1stWord_6.Text = "06"
        Me._chk1stWord_6.UseVisualStyleBackColor = False
        '
        '_chk1stWord_7
        '
        Me._chk1stWord_7.BackColor = System.Drawing.SystemColors.Control
        Me._chk1stWord_7.Cursor = System.Windows.Forms.Cursors.Default
        Me._chk1stWord_7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chk1stWord.SetIndex(Me._chk1stWord_7, CType(7, Short))
        Me._chk1stWord_7.Location = New System.Drawing.Point(400, 24)
        Me._chk1stWord_7.Name = "_chk1stWord_7"
        Me._chk1stWord_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._chk1stWord_7.Size = New System.Drawing.Size(41, 17)
        Me._chk1stWord_7.TabIndex = 11
        Me._chk1stWord_7.Text = "07"
        Me._chk1stWord_7.UseVisualStyleBackColor = False
        '
        '_chk1stWord_8
        '
        Me._chk1stWord_8.BackColor = System.Drawing.SystemColors.Control
        Me._chk1stWord_8.Cursor = System.Windows.Forms.Cursors.Default
        Me._chk1stWord_8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chk1stWord.SetIndex(Me._chk1stWord_8, CType(8, Short))
        Me._chk1stWord_8.Location = New System.Drawing.Point(16, 48)
        Me._chk1stWord_8.Name = "_chk1stWord_8"
        Me._chk1stWord_8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._chk1stWord_8.Size = New System.Drawing.Size(41, 17)
        Me._chk1stWord_8.TabIndex = 10
        Me._chk1stWord_8.Text = "08"
        Me._chk1stWord_8.UseVisualStyleBackColor = False
        '
        '_chk1stWord_9
        '
        Me._chk1stWord_9.BackColor = System.Drawing.SystemColors.Control
        Me._chk1stWord_9.Cursor = System.Windows.Forms.Cursors.Default
        Me._chk1stWord_9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chk1stWord.SetIndex(Me._chk1stWord_9, CType(9, Short))
        Me._chk1stWord_9.Location = New System.Drawing.Point(72, 48)
        Me._chk1stWord_9.Name = "_chk1stWord_9"
        Me._chk1stWord_9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._chk1stWord_9.Size = New System.Drawing.Size(41, 17)
        Me._chk1stWord_9.TabIndex = 9
        Me._chk1stWord_9.Text = "09"
        Me._chk1stWord_9.UseVisualStyleBackColor = False
        '
        '_chk1stWord_10
        '
        Me._chk1stWord_10.BackColor = System.Drawing.SystemColors.Control
        Me._chk1stWord_10.Cursor = System.Windows.Forms.Cursors.Default
        Me._chk1stWord_10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chk1stWord.SetIndex(Me._chk1stWord_10, CType(10, Short))
        Me._chk1stWord_10.Location = New System.Drawing.Point(128, 48)
        Me._chk1stWord_10.Name = "_chk1stWord_10"
        Me._chk1stWord_10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._chk1stWord_10.Size = New System.Drawing.Size(41, 17)
        Me._chk1stWord_10.TabIndex = 8
        Me._chk1stWord_10.Text = "10"
        Me._chk1stWord_10.UseVisualStyleBackColor = False
        '
        '_chk1stWord_11
        '
        Me._chk1stWord_11.BackColor = System.Drawing.SystemColors.Control
        Me._chk1stWord_11.Cursor = System.Windows.Forms.Cursors.Default
        Me._chk1stWord_11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chk1stWord.SetIndex(Me._chk1stWord_11, CType(11, Short))
        Me._chk1stWord_11.Location = New System.Drawing.Point(176, 48)
        Me._chk1stWord_11.Name = "_chk1stWord_11"
        Me._chk1stWord_11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._chk1stWord_11.Size = New System.Drawing.Size(41, 17)
        Me._chk1stWord_11.TabIndex = 7
        Me._chk1stWord_11.Text = "11"
        Me._chk1stWord_11.UseVisualStyleBackColor = False
        '
        '_chk1stWord_12
        '
        Me._chk1stWord_12.BackColor = System.Drawing.SystemColors.Control
        Me._chk1stWord_12.Cursor = System.Windows.Forms.Cursors.Default
        Me._chk1stWord_12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chk1stWord.SetIndex(Me._chk1stWord_12, CType(12, Short))
        Me._chk1stWord_12.Location = New System.Drawing.Point(232, 48)
        Me._chk1stWord_12.Name = "_chk1stWord_12"
        Me._chk1stWord_12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._chk1stWord_12.Size = New System.Drawing.Size(41, 17)
        Me._chk1stWord_12.TabIndex = 6
        Me._chk1stWord_12.Text = "12"
        Me._chk1stWord_12.UseVisualStyleBackColor = False
        '
        '_chk1stWord_13
        '
        Me._chk1stWord_13.BackColor = System.Drawing.SystemColors.Control
        Me._chk1stWord_13.Cursor = System.Windows.Forms.Cursors.Default
        Me._chk1stWord_13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chk1stWord.SetIndex(Me._chk1stWord_13, CType(13, Short))
        Me._chk1stWord_13.Location = New System.Drawing.Point(288, 48)
        Me._chk1stWord_13.Name = "_chk1stWord_13"
        Me._chk1stWord_13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._chk1stWord_13.Size = New System.Drawing.Size(41, 17)
        Me._chk1stWord_13.TabIndex = 5
        Me._chk1stWord_13.Text = "13"
        Me._chk1stWord_13.UseVisualStyleBackColor = False
        '
        '_chk1stWord_14
        '
        Me._chk1stWord_14.BackColor = System.Drawing.SystemColors.Control
        Me._chk1stWord_14.Cursor = System.Windows.Forms.Cursors.Default
        Me._chk1stWord_14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chk1stWord.SetIndex(Me._chk1stWord_14, CType(14, Short))
        Me._chk1stWord_14.Location = New System.Drawing.Point(344, 48)
        Me._chk1stWord_14.Name = "_chk1stWord_14"
        Me._chk1stWord_14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._chk1stWord_14.Size = New System.Drawing.Size(41, 17)
        Me._chk1stWord_14.TabIndex = 4
        Me._chk1stWord_14.Text = "14"
        Me._chk1stWord_14.UseVisualStyleBackColor = False
        '
        '_chk1stWord_15
        '
        Me._chk1stWord_15.BackColor = System.Drawing.SystemColors.Control
        Me._chk1stWord_15.Cursor = System.Windows.Forms.Cursors.Default
        Me._chk1stWord_15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chk1stWord.SetIndex(Me._chk1stWord_15, CType(15, Short))
        Me._chk1stWord_15.Location = New System.Drawing.Point(400, 48)
        Me._chk1stWord_15.Name = "_chk1stWord_15"
        Me._chk1stWord_15.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._chk1stWord_15.Size = New System.Drawing.Size(41, 17)
        Me._chk1stWord_15.TabIndex = 3
        Me._chk1stWord_15.Text = "15"
        Me._chk1stWord_15.UseVisualStyleBackColor = False
        '
        'cobModule
        '
        Me.cobModule.BackColor = System.Drawing.SystemColors.Window
        Me.cobModule.Cursor = System.Windows.Forms.Cursors.Default
        Me.cobModule.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cobModule.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cobModule.Location = New System.Drawing.Point(216, 8)
        Me.cobModule.Name = "cobModule"
        Me.cobModule.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cobModule.Size = New System.Drawing.Size(249, 20)
        Me.cobModule.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(16, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(161, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "[Bo.No.:Mo.No.] Mo.ID"
        '
        'chk1stWord
        '
        '
        'chk2ndWord
        '
        '
        'AxtMsg
        '
        Me.AxtMsg.Enabled = True
        Me.AxtMsg.Location = New System.Drawing.Point(207, 432)
        Me.AxtMsg.Name = "AxtMsg"
        Me.AxtMsg.OcxState = CType(resources.GetObject("AxtMsg.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxtMsg.Size = New System.Drawing.Size(26, 26)
        Me.AxtMsg.TabIndex = 42
        Me.AxtMsg.Visible = False
        '
        'frmDigitalIO
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(481, 481)
        Me.Controls.Add(Me.AxtMsg)
        Me.Controls.Add(Me.chkInterrupt)
        Me.Controls.Add(Me.chkFalling)
        Me.Controls.Add(Me.chkRising)
        Me.Controls.Add(Me.List1)
        Me.Controls.Add(Me.cmdListClear)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.Fra2ndWord)
        Me.Controls.Add(Me.Fra1stWord)
        Me.Controls.Add(Me.cobModule)
        Me.Controls.Add(Me.Label1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Location = New System.Drawing.Point(4, 23)
        Me.MaximizeBox = False
        Me.Name = "frmDigitalIO"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "DigitalIO"
        Me.Fra2ndWord.ResumeLayout(False)
        Me.Fra1stWord.ResumeLayout(False)
        CType(Me.chk1stWord, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chk2ndWord, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AxtMsg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
#End Region 
#Region "업그레이드 지원 "
	Private Shared m_vb6FormDefInstance As frmDigitalIO
	Private Shared m_InitializingDefInstance As Boolean
	Public Shared Property DefInstance() As frmDigitalIO
		Get
			If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
				m_InitializingDefInstance = True
				m_vb6FormDefInstance = New frmDigitalIO()
				m_InitializingDefInstance = False
			End If
			DefInstance = m_vb6FormDefInstance
		End Get
		Set
			m_vb6FormDefInstance = Value
		End Set
	End Property
#End Region 
	'The module of the downside must be added to use DIO
	'AXL.bas, AXHS.bas, AXD.bas
    Private Sub frmDigitalIO_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Initialize_DIO()
        SubOpenDevice()
    End Sub
	
	Private Sub Initialize_DIO()
		' Confirm Library initialized.
		If AxlIsOpened = False Then
			' Library initialize
            If AxlOpenNoReset(7) <> AXT_RT_SUCCESS Then
                MsgBox("Library initialized failed." & vbCrLf, MsgBoxStyle.Critical)
                End
            End If
		End If
		
	End Sub
	
	Private Sub SubOpenDevice()
		Dim lBoardNo As Integer
		Dim lModulePos As Integer
		Dim lModuleCnt As Integer
		Dim lModuleID As Integer
		Dim i1 As Short
	
		If AxlIsOpened Then
            cobModule.ResumeLayout()
			
            AxdInfoGetModuleCount(lModuleCnt)
			For i1 = 0 To lModuleCnt - 1
				
				' Get information(Board No, Module Pos, Module ID) of that module.
				AxdInfoGetModule(i1, lBoardNo, lModulePos, lModuleID)
				
				Select Case lModuleID
					Case AXT_SIO_DI32
                        cobModule.Items.Add("[BD No:" & VB6.Format(lBoardNo, "00") & " - MD No:" & VB6.Format(i1, "00") & "]" & "SIO-DI32")
					Case AXT_SIO_DO32P
                        cobModule.Items.Add("[BD No:" & VB6.Format(lBoardNo, "00") & " - MD No:" & VB6.Format(i1, "00") & "]" & "SIO-DO32P")
					Case AXT_SIO_DO32T
                        cobModule.Items.Add("[BD No:" & VB6.Format(lBoardNo, "00") & " - MD No:" & VB6.Format(i1, "00") & "]" & "SIO-DO32T")
					Case AXT_SIO_DB32P
                        cobModule.Items.Add("[BD No:" & VB6.Format(lBoardNo, "00") & " - MD No:" & VB6.Format(i1, "00") & "]" & "SIO-DB32P")
					Case AXT_SIO_DB32T
                        cobModule.Items.Add("[BD No:" & VB6.Format(lBoardNo, "00") & " - MD No:" & VB6.Format(i1, "00") & "]" & "SIO-DB32T")
					Case AXT_SIO_RDI32
                        cobModule.Items.Add("[BD No:" & VB6.Format(lBoardNo, "00") & " - MD No:" & VB6.Format(i1, "00") & "]" & "SIO-RDI32")
					Case AXT_SIO_RDO32
                        cobModule.Items.Add("[BD No:" & VB6.Format(lBoardNo, "00") & " - MD No:" & VB6.Format(i1, "00") & "]" & "SIO-RDO32")
                    Case AXT_SIO_RSIMPLEIOMLII
                        cobModule.Items.Add("[BD No:" & VB6.Format(lBoardNo, "00") & " - MD No:" & VB6.Format(i1, "00") & "]" & "SIO-RSIMPLEIOMLII")
                    Case AXT_SIO_RDO16AMLII
                        cobModule.Items.Add("[BD No:" & VB6.Format(lBoardNo, "00") & " - MD No:" & VB6.Format(i1, "00") & "]" & "SIO-RDO16AMLII")
                    Case AXT_SIO_RDO16BMLII
                        cobModule.Items.Add("[BD No:" & VB6.Format(lBoardNo, "00") & " - MD No:" & VB6.Format(i1, "00") & "]" & "RDO16BMLII")
                    Case AXT_SIO_DI32_P
                        cobModule.Items.Add("[BD No:" & VB6.Format(lBoardNo, "00") & " - MD No:" & VB6.Format(i1, "00") & "]" & "SIO-DI32_P")
                    Case AXT_SIO_RDI32RTEX
                        cobModule.Items.Add("[BD No:" & VB6.Format(lBoardNo, "00") & " - MD No:" & VB6.Format(i1, "00") & "]" & "SIO-RDI32RTEX")
                    Case AXT_SIO_DO32T_P
                        cobModule.Items.Add("[BD No:" & VB6.Format(lBoardNo, "00") & " - MD No:" & VB6.Format(i1, "00") & "]" & "SIO-DO32T_P")
                    Case AXT_SIO_RDO32RTEX
                        cobModule.Items.Add("[BD No:" & VB6.Format(lBoardNo, "00") & " - MD No:" & VB6.Format(i1, "00") & "]" & "SIO-RDO32RTEX")
                    Case AXT_SIO_RDB32T
                        cobModule.Items.Add("[BD No:" & VB6.Format(lBoardNo, "00") & " - MD No:" & VB6.Format(i1, "00") & "]" & "SIO-RDB32T")
                    Case AXT_SIO_RDB32RTEX
                        cobModule.Items.Add("[BD No:" & VB6.Format(lBoardNo, "00") & " - MD No:" & VB6.Format(i1, "00") & "]" & "SIO-RDB32RTEX")
                    Case AXT_SIO_RDB96MLII
                        cobModule.Items.Add("[BD No:" & VB6.Format(lBoardNo, "00") & " - MD No:" & VB6.Format(i1, "00") & "]" & "SIO-RDB96MLII")
                    Case AXT_SIO_RDB128MLII
                        cobModule.Items.Add("[BD No:" & VB6.Format(lBoardNo, "00") & " - MD No:" & VB6.Format(i1, "00") & "]" & "SIO-RDB128MLII")
                    Case AXT_ECAT_DIO
                        Dim szModuleName As String = Space(50)
                        Dim nModuleSubID As Integer
                        Dim szModuleDescription As String = Space(80)
                        AxdInfoGetModuleEx(i1, nModuleSubID, szModuleName, szModuleDescription)
                        cobModule.Items.Add("[BD No:" & VB6.Format(lBoardNo, "00") & " - MD No:" & VB6.Format(i1, "00") & "]" & szModuleName & "]")
                End Select
            Next
            cobModule.SelectedIndex = 0
			
		End If
		
	End Sub
	
	'UPGRADE_WARNING: Form 이벤트 frmDigitalIO.Unload에 새 동작이 있습니다. 자세한 내용은 다음을 참조하십시오: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2065"'
	Private Sub frmDigitalIO_Closed(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Closed
		
		If AxlIsOpened Then
			' Library close
			AxlClose()
		End If
		
	End Sub
	
	Private Function SubHiByte(ByRef wParam As Integer) As Byte
		SubHiByte = Int(wParam / &H100s)
		
	End Function
	
	Private Function SubLoByte(ByRef wParam As Integer) As Byte
		Dim nHiByte As Short
		
		nHiByte = Int(wParam / &H100s)
		SubLoByte = wParam - (nHiByte * &H100s)
		
		If SubLoByte > &H7FFs Then SubLoByte = SubLoByte - &H100s
		
	End Function
	
	Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
		
		Me.Close()
	End Sub
	
	Private Sub cmdListClear_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdListClear.Click

		List1.Items.Clear()
	End Sub
    'UPGRADE_WARNING: 폼이 초기화될 때 cobModule.SelectedIndexChanged 이벤트가 발생합니다. 자세한 내용은 다음을 참조하십시오: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2075"'
	Private Sub cobModule_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cobModule.SelectedIndexChanged
		Dim lBoardNo As Integer
		Dim lModulePos As Integer
		Dim lModuleID As Integer
		Dim lModuleNo As Integer
		Dim i1 As Integer
		Dim lUse As Integer
		Dim lEdge As Integer
        Dim lValue As Integer
        Dim lInCount As Integer
        Dim lOutCount As Integer

		
		' If library initialized
        If AxlIsOpened Then
            ' Get information(Board No, Module Pos, Module ID) of that module.
            lModuleNo = cobModule.SelectedIndex
            AxdInfoGetModule(lModuleNo, lBoardNo, lModulePos, lModuleID)

            Select Case lModuleID
                Case AXT_SIO_DI32, AXT_SIO_RDI32, AXT_SIO_DI32_P, AXT_SIO_RDI32RTEX
                    ' Structure to INPUT 32Bit
                    Fra1stWord.Text = " INPUT  0bit ~ 15Bit"
                    Fra2ndWord.Text = " INPUT 16bit ~ 31Bit"

                    ' Used in digital Input.
                    If (lModuleID = AXT_SIO_RDI32) Then
                        chkInterrupt.Enabled = True
                        chkRising.Enabled = True
                        chkFalling.Enabled = True
                    Else
                        ' The module to specify confirmes an interrupt permission situation recognition.
                        AxdiInterruptGetModuleEnable(lModuleNo, lUse)
                        If lUse Then
                            chkInterrupt.Checked = 1
                        Else
                            chkInterrupt.Checked = 0
                        End If

                        ' Confirmes whether the module to specify is UpEdge situation.
                        AxdiInterruptEdgeGetWord(lModuleNo, 0, UP_EDGE, lEdge)
                        If (lEdge = "&HFFFF") Then
                            chkRising.Checked = 1
                        Else
                            chkRising.Checked = 0
                        End If

                        ' Confirmes whether the module to specify is DownEdge situation.
                        AxdiInterruptEdgeGetWord(lModuleNo, 0, DOWN_EDGE, lEdge)
                        If (lEdge = "&HFFFF") Then
                            chkFalling.Checked = 1
                        Else
                            chkFalling.Checked = 0
                        End If
                    End If
                    For i1 = 0 To 15
                        chk1stWord(i1).Text = Format(i1, "00")
                        chk2ndWord(i1).Text = Format(16 + i1, "00")
                    Next
                Case AXT_SIO_DO32P, AXT_SIO_DO32T, AXT_SIO_RDO32, AXT_SIO_DO32T_P, AXT_SIO_RDO32RTEX, AXT_SIO_RDO16AMLII, AXT_SIO_RDO16BMLII

                    ' Structure to OUTPUT 32Bit
                    Fra1stWord.Text = "OUTPUT  0bit ~ 15Bit"
                    Fra2ndWord.Text = "OUTPUT 16bit ~ 31Bit"

                    ' Only Digital Input was used
                    chkInterrupt.Enabled = False
                    chkRising.Enabled = False
                    chkFalling.Enabled = False

                    ' Display current OUTPUT(00bit~32bit) on state screen
                    For i1 = 0 To 15
                        ' OUTPUT(00bit ~ 15bit) Verify output state
                        AxdoReadOutportBit(lModuleNo, i1, lValue)
                        If lValue Then
                            chk1stWord(i1).CheckState = System.Windows.Forms.CheckState.Checked
                        Else
                            chk1stWord(i1).CheckState = System.Windows.Forms.CheckState.Unchecked
                        End If

                        ' OUTPUT(16bit ~ 31bit) Verify output state
                        AxdoReadOutportBit(lModuleNo, i1 + 16, lValue)
                        If lValue Then
                            chk2ndWord(i1).CheckState = System.Windows.Forms.CheckState.Checked
                        Else
                            chk2ndWord(i1).CheckState = System.Windows.Forms.CheckState.Unchecked
                        End If
                        chk1stWord(i1).Text = Format(i1, "00")
                        chk2ndWord(i1).Text = Format(16 + i1, "00")
                    Next

                Case AXT_SIO_DB32P, AXT_SIO_DB32T, AXT_SIO_RDB32T, AXT_SIO_RDB32RTEX, AXT_SIO_RDB96MLII, AXT_SIO_RDB128MLII, AXT_SIO_RSIMPLEIOMLII
                    ' Configure with INPUT 16 Bit and INPUT 32Bit
                    Fra1stWord.Text = " INPUT  0bit ~ 15Bit"
                    Fra2ndWord.Text = "OUTPUT  0bit ~ 15Bit"

                    ' Only Digital Input was used
                    chkInterrupt.Enabled = True
                    chkRising.Enabled = True
                    chkFalling.Enabled = True

                    ' Verify if the specific moudle is allowable state of interrupt
                    AxdiInterruptGetModuleEnable(lModuleNo, lUse)
                    If lUse Then
                        chkInterrupt.Checked = 1
                    Else
                        chkInterrupt.Checked = 0
                    End If

                    ' Verify if the specific moudle is state of UpEdge
                    AxdiInterruptEdgeGetWord(lModuleNo, 0, UP_EDGE, lEdge)
                    If (lEdge = "&HFFFF") Then
                        chkRising.Checked = 1
                    Else
                        chkRising.Checked = 0
                    End If

                    ' Verify if the specific moudle is state of DownEdge
                    AxdiInterruptEdgeGetWord(lModuleNo, 0, DOWN_EDGE, lEdge)
                    If (lEdge = "&HFFFF") Then
                        chkFalling.Checked = 1
                    Else
                        chkFalling.Checked = 0
                    End If

                    'Display current OUTPUT(00bit~15bit) on state screen
                    For i1 = 0 To 15
                        AxdoReadOutportBit(lModuleNo, i1, lValue)
                        If lValue Then
                            chk2ndWord(i1).CheckState = System.Windows.Forms.CheckState.Checked
                        Else
                            chk2ndWord(i1).CheckState = System.Windows.Forms.CheckState.Unchecked
                        End If
                        chk1stWord(i1).Text = Format(i1, "00")
                        chk2ndWord(i1).Text = Format(i1, "00")
                    Next
                Case AXT_ECAT_DIO
                    AxdInfoGetInputCount(lModuleNo, lInCount)
                    AxdInfoGetOutputCount(lModuleNo, lOutCount)

                    If (lInCount > 16) Then
                        Fra1stWord.Text = "INPUT  0bit ~ 15Bit"
                        Fra2ndWord.Text = "INPUT 16bit ~ 31Bit"

                        For i1 = 0 To 15
                            chk2ndWord(i1).Enabled = False
                            chk2ndWord(i1).Text = Format(i1 + 16, "00")
                        Next

                        For i1 = 0 To 15
                            chk1stWord(i1).Enabled = False
                        Next

                    ElseIf (lInCount > 0) Then
                        Fra1stWord.Text = "INPUT  0bit ~ 15Bit"

                        For i1 = 0 To 15
                            chk1stWord(i1).Enabled = False
                        Next

                        If (lOutCount > 0) Then
                            Fra2ndWord.Text = "OUTPUT  0bit ~ 15Bit"
                            AxdoReadOutportWord(lModuleNo, 0, lValue)

                            For i1 = 0 To 15
                                chk2ndWord(i1).Enabled = True
                                chk2ndWord(i1).Text = Format(i1, "00")
                            Next
                        Else
                            Fra2ndWord.Text = " "
                        End If
                    Else
                        If (lOutCount > 16) Then
                            Fra1stWord.Text = "INPUT  0bit ~ 15Bit"
                            Fra2ndWord.Text = "INPUT 16bit ~ 31Bit"

                            AxdoReadOutportWord(lModuleNo, 0, lEdge)
                            AxdoReadOutportWord(lModuleNo, 1, lValue)

                            For i1 = 0 To 15
                                chk1stWord(i1).Enabled = True
                            Next

                            For i1 = 0 To 15
                                chk2ndWord(i1).Enabled = True
                                chk2ndWord(i1).Text = Format(i1 + 16, "00")
                            Next

                        ElseIf (lOutCount > 0) Then
                            Fra1stWord.Text = "INPUT  0bit ~ 15Bit"
                            Fra2ndWord.Text = " "

                            AxdoReadOutportWord(lModuleNo, 0, lEdge)

                            For i1 = 0 To 15
                                chk1stWord(i1).Enabled = True
                            Next
                        End If
                    End If

                    chkInterrupt.Enabled = False
                    chkRising.Enabled = False
                    chkFalling.Enabled = False

                    For i1 = 0 To 15
                        AxdoReadOutportBit(lModuleNo, i1, lValue)
                        If lValue Then
                            chk2ndWord(i1).CheckState = System.Windows.Forms.CheckState.Checked
                        Else
                            chk2ndWord(i1).CheckState = System.Windows.Forms.CheckState.Unchecked
                        End If

                        If (lOutCount > 16) Then
                            chk1stWord(i1).CheckState = System.Windows.Forms.CheckState.Checked
                        Else
                            chk1stWord(i1).CheckState = System.Windows.Forms.CheckState.Unchecked
                        End If
                    Next
            End Select
        End If
	End Sub
	
	'UPGRADE_WARNING: 폼이 초기화될 때 chk1stWord.CheckStateChanged 이벤트가 발생합니다. 자세한 내용은 다음을 참조하십시오: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2075"'
	Private Sub chk1stWord_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chk1stWord.CheckStateChanged
		Dim Index As Short = chk1stWord.GetIndex(eventSender)
		Dim lModuleNo As Integer
		Dim lBoardNo As Integer
		Dim lModulePos As Integer
        Dim lModuleID As Integer
        Dim lOutCount As Integer

		
        If AxlIsOpened Then
            lModuleNo = cobModule.SelectedIndex
            AxdInfoGetModule(lModuleNo, lBoardNo, lModulePos, lModuleID)
            Select Case lModuleID

                Case AXT_SIO_DO32P, AXT_SIO_DO32T, AXT_SIO_RDO32
                    ' OUTPUT(00bit ~ 15bit) output
                    If chk1stWord(Index).CheckState Then
                        AxdoWriteOutportBit(lModuleNo, Index, 1)
                    Else
                        AxdoWriteOutportBit(lModuleNo, Index, 0)
                    End If
                Case AXT_ECAT_DIO
                    AxdInfoGetOutputCount(lModuleNo, lOutCount)
                    If (lOutCount > 16) Then
                        If chk1stWord(Index).CheckState Then
                            AxdoWriteOutportBit(lModuleNo, Index, 1)
                        Else
                            AxdoWriteOutportBit(lModuleNo, Index, 0)
                        End If
                    End If
            End Select
        End If
	End Sub
	
	'UPGRADE_WARNING: 폼이 초기화될 때 chk2ndWord.CheckStateChanged 이벤트가 발생합니다. 자세한 내용은 다음을 참조하십시오: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2075"'
	Private Sub chk2ndWord_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chk2ndWord.CheckStateChanged
		Dim Index As Short = chk2ndWord.GetIndex(eventSender)
		Dim lModuleNo As Integer
		Dim lBoardNo As Integer
		Dim lModulePos As Integer
        Dim lModuleID As Integer
        Dim lOutCount As Integer

		' If library is initialized
        If AxlIsOpened Then
            lModuleNo = cobModule.SelectedIndex
            AxdInfoGetModule(lModuleNo, lBoardNo, lModulePos, lModuleID)
            Select Case lModuleID
                Case AXT_SIO_DB32P, AXT_SIO_DB32T
                    ' OUTPUT(00bit ~ 15bit) output
                    If chk2ndWord(Index).CheckState Then
                        AxdoWriteOutportBit(lModuleNo, Index, 1)
                    Else
                        AxdoWriteOutportBit(lModuleNo, Index, 0)
                    End If
                Case AXT_SIO_DO32P, AXT_SIO_DO32T, AXT_SIO_RDO32
                    ' OUTPUT(150bit ~ 31bit) output
                    If chk2ndWord(Index).CheckState Then
                        AxdoWriteOutportBit(lModuleNo, Index + 16, 1)
                    Else
                        AxdoWriteOutportBit(lModuleNo, Index + 16, 0)
                    End If
                Case AXT_ECAT_DIO
                    AxdInfoGetOutputCount(lModuleNo, lOutCount)
                    If (lOutCount > 16) Then
                        If chk2ndWord(Index).CheckState Then
                            AxdoWriteOutportBit(lModuleNo, Index + 16, 1)
                        Else
                            AxdoWriteOutportBit(lModuleNo, Index + 16, 0)
                        End If
                    ElseIf (lOutCount > 0) Then
                        If chk2ndWord(Index).CheckState Then
                            AxdoWriteOutportBit(lModuleNo, Index, 1)
                        Else
                            AxdoWriteOutportBit(lModuleNo, Index, 0)
                        End If
                    End If

            End Select
        End If
	End Sub
	
	
	Private Sub Timer1_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Timer1.Tick
        Dim i1 As Integer
        Dim lModuleNo As Integer
		Dim lBoardNo As Integer
		Dim lModulePos As Integer
		Dim lModuleID As Integer
        Dim lValue As Integer
        Dim lInCount As Integer

		If AxlIsOpened Then
			
			lModuleNo = cobModule.SelectedIndex
			AxdInfoGetModule(lModuleNo, lBoardNo, lModulePos, lModuleID)
			Select Case lModuleID
				
                Case AXT_SIO_DI32, AXT_SIO_RDI32, AXT_SIO_DI32_P, AXT_SIO_RDI32RTEX
                    For i1 = 0 To 15
                        ' INPUTOUTPUT (00bit ~ 15bit) Verify input
                        AxdiReadInportBit(lModuleNo, i1, lValue)
                        If lValue Then
                            chk1stWord(i1).CheckState = System.Windows.Forms.CheckState.Checked
                        Else
                            chk1stWord(i1).CheckState = System.Windows.Forms.CheckState.Unchecked
                        End If

                        ' INPUTOUTPUT (150bit ~ 31bit) Verify input
                        AxdiReadInportBit(lModuleNo, i1 + 16, lValue)
                        If lValue Then
                            chk2ndWord(i1).CheckState = System.Windows.Forms.CheckState.Checked
                        Else
                            chk2ndWord(i1).CheckState = System.Windows.Forms.CheckState.Unchecked
                        End If
                    Next
					
                Case AXT_SIO_DO32P, AXT_SIO_DO32T, AXT_SIO_RDO32, AXT_SIO_DO32T_P, AXT_SIO_RDO32RTEX, AXT_SIO_RDO16AMLII, AXT_SIO_RDO16BMLII
                    For i1 = 0 To 15
                        ' INPUTOUTPUT (00bit ~ 15bit) Verify input
                        AxdiReadInportBit(lModuleNo, i1, lValue)
                        If lValue Then
                            chk1stWord(i1).CheckState = System.Windows.Forms.CheckState.Checked
                        Else
                            chk1stWord(i1).CheckState = System.Windows.Forms.CheckState.Unchecked
                        End If
                    Next
                Case AXT_ECAT_DIO
                    AxdInfoGetInputCount(lModuleNo, lInCount)
                    If (lInCount > 0) Then
                        For i1 = 0 To 1
                            AxdiReadInportBit(lModuleNo, i1, lValue)
                            If lValue Then
                                chk1stWord(i1).CheckState = System.Windows.Forms.CheckState.Checked
                            Else
                                chk1stWord(i1).CheckState = System.Windows.Forms.CheckState.Unchecked
                            End If
                            If (lInCount > 16) Then
                                AxdiReadInportBit(lModuleNo, i1 + 16, lValue)
                                If lValue Then
                                    chk2ndWord(i1).CheckState = System.Windows.Forms.CheckState.Checked
                                Else
                                    chk2ndWord(i1).CheckState = System.Windows.Forms.CheckState.Unchecked
                                End If
                            End If
                        Next
                    End If
            End Select
		End If
		
	End Sub
	
	'UPGRADE_WARNING: 폼이 초기화될 때 chkInterrupt.CheckStateChanged 이벤트가 발생합니다. 자세한 내용은 다음을 참조하십시오: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2075"'
	Private Sub chkInterrupt_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkInterrupt.CheckStateChanged
        Dim lModuleNo As Integer
		Dim lBoardNo As Integer
		Dim lModulePos As Integer
		Dim lModuleID As Integer

		Dim szInterruptSelect As String
		Dim sInterruptEnable As String
		Dim sInterruptDisable As String
		Dim sInterruptFail As String
		
        szInterruptSelect = "※Please set edge"
        sInterruptEnable = "Enable Interrupt button is 'activated' "
        sInterruptDisable = "Enable Interrupt button is 'deactivated' "
        sInterruptFail = "Enable Interrupt button can not be used "
		
        If AxlIsOpened Then
            lModuleNo = cobModule.SelectedIndex
            ' Retun base board number and module position of specific module number
            AxdInfoGetModule(lModuleNo, lBoardNo, lModulePos, lModuleID)
            Select Case lModuleID
                Case AXT_SIO_DI32, AXT_SIO_DB32P, AXT_SIO_DB32T
                    If chkInterrupt.Checked Then
                        AxlInterruptEnable()
                        AxdiInterruptSetModule(lModuleNo, AxtMsg.hWnd, WM_AXL_INTERRUPT, 0, 0)

                        ' Allow interrupt of specific module
                        AxdiInterruptSetModuleEnable(lModuleNo, 1)

                        List1.Items.Add(sInterruptEnable)
                        List1.Items.Add(szInterruptSelect)
                        List1.SelectedIndex = List1.Items.Count - 1
                    Else
                        ' Prohibit interrupt of specific module
                        AxdiInterruptSetModuleEnable(lModuleNo, 0)
                        AxlInterruptDisable()

                        chkRising.Checked = 0
                        chkRising.Checked = 0

                        List1.Items.Add(sInterruptDisable)
                        List1.SelectedIndex = List1.Items.Count - 1
                    End If

                Case AXT_SIO_DO32P, AXT_SIO_DO32T, AXT_SIO_RDI32
                    List1.Items.Add(sInterruptFail)
                    List1.SelectedIndex = List1.Items.Count - 1
            End Select
        End If
    End Sub
	
	'UPGRADE_WARNING: 폼이 초기화될 때 chkRising.CheckStateChanged 이벤트가 발생합니다. 자세한 내용은 다음을 참조하십시오: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2075"'
	Private Sub chkRising_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkRising.CheckStateChanged
        Dim lModuleNo As Integer
		Dim lBoardNo As Integer
		Dim lModulePos As Integer
		Dim lModuleID As Integer

		Dim sStartMsg As String
		Dim sEndMsg As String
		Dim sErrMsg As String
		Dim sinterruptErrMsg As String
		
		sStartMsg = "'Start' Rising Edge detection"
		sEndMsg = "'Exit' Rising Edge detection"
		sErrMsg = "Can not use Rising Edge detection"
		sinterruptErrMsg = "Please enable interrupt button first."
		
		' If library is initialized
		If AxlIsOpened Then
			
			lModuleNo = cobModule.SelectedIndex
			AxdInfoGetModule(lModuleNo, lBoardNo, lModulePos, lModuleID)
            Select Case lModuleID
                Case AXT_SIO_DI32
                    If chkRising.CheckState Then
                        If chkInterrupt.CheckState Then
                            ' Set Interrupt Edge
                            AxdiInterruptEdgeSetDword(lModuleNo, 0, UP_EDGE, &HFFFFFFFF)

                            List1.Items.Add(sStartMsg)
                            List1.SelectedIndex = List1.Items.Count - 1
                        Else
                            List1.Items.Add(sErrMsg)

                            chkRising.CheckState = System.Windows.Forms.CheckState.Unchecked

                            List1.Items.Add(sinterruptErrMsg)
                            List1.SelectedIndex = List1.Items.Count - 1
                        End If
                    Else
                        ' Set Interrupt Edge
                        AxdiInterruptEdgeSetWord(lModuleNo, 0, UP_EDGE, &H0)
                        AxdiInterruptEdgeSetWord(lModuleNo, 1, UP_EDGE, &H0)

                        If VB6.GetItemString(List1, List1.Items.Count - 1) <> sErrMsg Then
                            List1.Items.Add(sEndMsg)
                            List1.SelectedIndex = List1.Items.Count - 1
                        End If
                    End If
                Case AXT_SIO_DB32P, AXT_SIO_DB32T

                    If chkRising.CheckState Then
                        If chkInterrupt.CheckState Then
                            ' Set Interrupt Edge
                            AxdiInterruptEdgeSetDword(lModuleNo, 0, UP_EDGE, &HFFFFFFFF)

                            List1.Items.Add(sStartMsg)
                            List1.SelectedIndex = List1.Items.Count - 1
                        Else


                            List1.Items.Add(sErrMsg)

                            chkRising.CheckState = System.Windows.Forms.CheckState.Unchecked

                            List1.Items.Add(sinterruptErrMsg)
                            List1.SelectedIndex = List1.Items.Count - 1
                        End If
                    Else
                        ' Set Interrupt Edge
                        AxdiInterruptEdgeSetWord(lModuleNo, 0, UP_EDGE, &H0)

                        If VB6.GetItemString(List1, List1.Items.Count - 1) <> sErrMsg Then
                            List1.Items.Add(sEndMsg)
                            List1.SelectedIndex = List1.Items.Count - 1
                        End If
                    End If
                Case AXT_SIO_DO32P, AXT_SIO_DO32T
                    List1.Items.Add(sinterruptErrMsg)
                    List1.SelectedIndex = List1.Items.Count - 1

            End Select
		End If
	End Sub
	
	'UPGRADE_WARNING: 폼이 초기화될 때 chkFalling.CheckStateChanged 이벤트가 발생합니다. 자세한 내용은 다음을 참조하십시오: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2075"'
	Private Sub chkFalling_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkFalling.CheckStateChanged
        Dim lModuleNo As Integer
		Dim lBoardNo As Integer
		Dim lModulePos As Integer
		Dim lModuleID As Integer
        Dim sStartMsg As String
		Dim sEndMsg As String
		Dim sErrMsg As String
		Dim sinterruptErrMsg As String
		
		sStartMsg = "'Start' Falling Edge detection"
		sEndMsg = "'Exit' Falling Edge detection"
		sErrMsg = "Can not use Falling Edge detection"
		sinterruptErrMsg = "Please enable interrupt button first."
		
		
		' If library is initialized
		If AxlIsOpened Then
			
			lModuleNo = cobModule.SelectedIndex
			AxdInfoGetModule(lModuleNo, lBoardNo, lModulePos, lModuleID)
			Select Case lModuleID
				Case AXT_SIO_DI32
					
					If chkFalling.CheckState Then
						If chkInterrupt.CheckState Then
							' Set Interrupt Edge
                            AxdiInterruptEdgeSetDword(lModuleNo, 0, DOWN_EDGE, &HFFFFFFFF)
							
							List1.Items.Add(sStartMsg)
							List1.SelectedIndex = List1.Items.Count - 1
						Else
							List1.Items.Add(sErrMsg)
							
							chkFalling.CheckState = System.Windows.Forms.CheckState.Unchecked
							
							List1.Items.Add(sinterruptErrMsg)
							List1.SelectedIndex = List1.Items.Count - 1
						End If
					Else
						' Set Interrupt Edge
                        AxdiInterruptEdgeSetWord(lModuleNo, 0, DOWN_EDGE, &H0)
                        AxdiInterruptEdgeSetWord(lModuleNo, 1, DOWN_EDGE, &H0)
						
						If VB6.GetItemString(List1, List1.Items.Count - 1) <> sErrMsg Then
							List1.Items.Add(sEndMsg)
							List1.SelectedIndex = List1.Items.Count - 1
						End If
					End If
                Case AXT_SIO_DB32P, AXT_SIO_DB32T

                    If chkFalling.CheckState Then
                        If chkInterrupt.CheckState Then
                            ' Set Interrupt Edge
                            AxdiInterruptEdgeSetDword(lModuleNo, 0, DOWN_EDGE, &HFFFFFFFF)

                            List1.Items.Add(sStartMsg)
                            List1.SelectedIndex = List1.Items.Count - 1
                        Else

                            List1.Items.Add(sErrMsg)

                            chkFalling.CheckState = System.Windows.Forms.CheckState.Unchecked

                            List1.Items.Add(sinterruptErrMsg)
                            List1.SelectedIndex = List1.Items.Count - 1
                        End If
                    Else
                        ' Set Interrupt Edge
                        AxdiInterruptEdgeSetWord(lModuleNo, 0, DOWN_EDGE, &H0)

                        If VB6.GetItemString(List1, List1.Items.Count - 1) <> sErrMsg Then
                            List1.Items.Add(sEndMsg)
                            List1.SelectedIndex = List1.Items.Count - 1
                        End If
                    End If

                Case AXT_SIO_DO32P, AXT_SIO_DO32T
                    List1.Items.Add(sinterruptErrMsg)
                    List1.SelectedIndex = List1.Items.Count - 1
            End Select
		End If
	End Sub
    Private Sub chkInterrupt_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkInterrupt.CheckedChanged
        Dim lModuleNo As Long
        Dim lBoardNo As Long
        Dim lModulePos As Long
        Dim lModuleID As Long

        Dim szInterruptSelect As String
        Dim sInterruptEnable As String
        Dim sInterruptDisable As String
        Dim sInterruptFail As String

        szInterruptSelect = "※Please set edge"
        sInterruptEnable = "Enable Interrupt button is 'activated' "
        sInterruptDisable = "Enable Interrupt button is 'deactivated' "
        sInterruptFail = "Enable Interrupt button can not be used "

        If AxlIsOpened Then
            lModuleNo = cobModule.SelectedIndex
            ' Retun base board number and module position of specific module number
            AxtMsg.Message1 = WM_AXL_INTERRUPT
            AxdInfoGetModule(lModuleNo, lBoardNo, lModulePos, lModuleID)
            Select Case lModuleID

                Case AXT_SIO_DI32, _
                     AXT_SIO_DB32P, AXT_SIO_DB32T

                    If chkInterrupt.Checked Then
                        AxlInterruptEnable()
                        AxdiInterruptSetModule(lModuleNo, AxtMsg.hWnd, WM_AXL_INTERRUPT, 0, 0)

                        ' Allow interrupt of specific module
                        AxdiInterruptSetModuleEnable(lModuleNo, 1)

                        List1.Items.Add(sInterruptEnable)
                        List1.Items.Add(szInterruptSelect)
                        List1.SelectedIndex = List1.Items.Count - 1
                    Else
                        ' Prohibit interrupt of specific module
                        AxdiInterruptSetModuleEnable(lModuleNo, 0)
                        AxlInterruptDisable()

                        chkRising.Checked = 0
                        chkFalling.Checked = 0

                        List1.Items.Add(sInterruptDisable)
                        List1.SelectedIndex = List1.Items.Count - 1
                    End If

                Case AXT_SIO_DO32P, AXT_SIO_DO32T, AXT_SIO_RDI32
                    List1.Items.Add(sInterruptFail)
                    List1.SelectedIndex = List1.Items.Count - 1
            End Select
        End If
    End Sub
    Private Sub AxtMsg_OnMessage1(ByVal sender As System.Object, ByVal e As AxAXTMESSENGERLib._DAxtMessengerEvents_OnMessage1Event) Handles AxtMsg.OnMessage1
        Dim nBoardNo As Long
        Dim nModuleNo As Long
        Dim nModulePos As Long
        Dim lValue, lChkBit As Long
        Dim i1 As Integer

        nBoardNo = Int(e.wParam / &H100)
        nModulePos = e.wParam - (Int(e.wParam / &H100) * &H100)
        AxdInfoGetModuleNo(nBoardNo, nModulePos, nModuleNo)

        AxdoReadOutportDword(nModuleNo, 0, lValue)
        For i1 = 0 To 31
            If Int(e.lParam / 2 ^ i1) And &H1 Then
                ' 해당모듈의 해당 오프셋의 비트값을 읽어온다.
                lChkBit = Int(lValue / (2 ^ i1)) And &H1

                If lChkBit Then
                    List1.Items.Add("Interrupt set bit " + " ☞  &H" + Hex(i1) + "    [▲Rising]")
                Else
                    List1.Items.Add("Interrupt set bit " + " ☞  &H" + Hex(i1) + "    [▼Falling]")
                End If

                List1.SelectedIndex = List1.Items.Count() - 1
            End If
        Next
    End Sub

End Class