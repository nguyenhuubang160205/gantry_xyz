<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmManualSet
#Region "Windows Form 디자이너에서 생성한 코드 "
	<System.Diagnostics.DebuggerNonUserCode()> Public Sub New()
		MyBase.New()
		'이 호출은 Windows Form 디자이너에 필요합니다.
		InitializeComponent()
	End Sub
	'Form은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
	<System.Diagnostics.DebuggerNonUserCode()> Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
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
	Public WithEvents tmDisplay As System.Windows.Forms.Timer
	Public WithEvents _edtRdData_5 As System.Windows.Forms.TextBox
	Public WithEvents _edtRdData_4 As System.Windows.Forms.TextBox
	Public WithEvents _edtRdData_3 As System.Windows.Forms.TextBox
	Public WithEvents _edtRdCmd_5 As System.Windows.Forms.TextBox
	Public WithEvents _edtRdCmd_4 As System.Windows.Forms.TextBox
	Public WithEvents _edtRdCmd_3 As System.Windows.Forms.TextBox
	Public WithEvents _chkOnOff_5 As System.Windows.Forms.CheckBox
	Public WithEvents _chkOnOff_4 As System.Windows.Forms.CheckBox
	Public WithEvents _chkOnOff_3 As System.Windows.Forms.CheckBox
	Public WithEvents _edtRdData_2 As System.Windows.Forms.TextBox
	Public WithEvents _edtRdData_1 As System.Windows.Forms.TextBox
	Public WithEvents _edtRdData_0 As System.Windows.Forms.TextBox
	Public WithEvents _edtRdCmd_2 As System.Windows.Forms.TextBox
	Public WithEvents _edtRdCmd_1 As System.Windows.Forms.TextBox
	Public WithEvents _edtRdCmd_0 As System.Windows.Forms.TextBox
	Public WithEvents _chkOnOff_2 As System.Windows.Forms.CheckBox
	Public WithEvents _chkOnOff_1 As System.Windows.Forms.CheckBox
	Public WithEvents _chkOnOff_0 As System.Windows.Forms.CheckBox
	Public WithEvents cboAxisSel As System.Windows.Forms.ComboBox
	Public WithEvents chkHex As System.Windows.Forms.CheckBox
	Public WithEvents cboPort As System.Windows.Forms.ComboBox
	Public WithEvents edtData As System.Windows.Forms.TextBox
	Public WithEvents edtCmd As System.Windows.Forms.TextBox
	Public WithEvents btnWr As System.Windows.Forms.Button
	Public WithEvents btnRd As System.Windows.Forms.Button
	Public WithEvents btnCmd As System.Windows.Forms.Button
	Public WithEvents chkOnOff As Microsoft.VisualBasic.Compatibility.VB6.CheckBoxArray
	Public WithEvents edtRdCmd As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
	Public WithEvents edtRdData As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
	'참고: 다음 프로시저는 Windows Form 디자이너에 필요합니다.
	'Windows Form 디자이너를 사용하여 수정할 수 있습니다.
	'코드 편집기를 사용하여 수정하지 마십시오.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmManualSet))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.tmDisplay = New System.Windows.Forms.Timer(components)
		Me._edtRdData_5 = New System.Windows.Forms.TextBox
		Me._edtRdData_4 = New System.Windows.Forms.TextBox
		Me._edtRdData_3 = New System.Windows.Forms.TextBox
		Me._edtRdCmd_5 = New System.Windows.Forms.TextBox
		Me._edtRdCmd_4 = New System.Windows.Forms.TextBox
		Me._edtRdCmd_3 = New System.Windows.Forms.TextBox
		Me._chkOnOff_5 = New System.Windows.Forms.CheckBox
		Me._chkOnOff_4 = New System.Windows.Forms.CheckBox
		Me._chkOnOff_3 = New System.Windows.Forms.CheckBox
		Me._edtRdData_2 = New System.Windows.Forms.TextBox
		Me._edtRdData_1 = New System.Windows.Forms.TextBox
		Me._edtRdData_0 = New System.Windows.Forms.TextBox
		Me._edtRdCmd_2 = New System.Windows.Forms.TextBox
		Me._edtRdCmd_1 = New System.Windows.Forms.TextBox
		Me._edtRdCmd_0 = New System.Windows.Forms.TextBox
		Me._chkOnOff_2 = New System.Windows.Forms.CheckBox
		Me._chkOnOff_1 = New System.Windows.Forms.CheckBox
		Me._chkOnOff_0 = New System.Windows.Forms.CheckBox
		Me.cboAxisSel = New System.Windows.Forms.ComboBox
		Me.chkHex = New System.Windows.Forms.CheckBox
		Me.cboPort = New System.Windows.Forms.ComboBox
		Me.edtData = New System.Windows.Forms.TextBox
		Me.edtCmd = New System.Windows.Forms.TextBox
		Me.btnWr = New System.Windows.Forms.Button
		Me.btnRd = New System.Windows.Forms.Button
		Me.btnCmd = New System.Windows.Forms.Button
		Me.chkOnOff = New Microsoft.VisualBasic.Compatibility.VB6.CheckBoxArray(components)
		Me.edtRdCmd = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(components)
		Me.edtRdData = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(components)
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.chkOnOff, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.edtRdCmd, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.edtRdData, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
		Me.Text = "Manual Set"
		Me.ClientSize = New System.Drawing.Size(513, 168)
		Me.Location = New System.Drawing.Point(204, 208)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable
		Me.ControlBox = True
		Me.Enabled = True
		Me.KeyPreview = False
		Me.MaximizeBox = True
		Me.MinimizeBox = True
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmManualSet"
		Me.tmDisplay.Interval = 100
		Me.tmDisplay.Enabled = True
		Me._edtRdData_5.AutoSize = False
		Me._edtRdData_5.Size = New System.Drawing.Size(106, 25)
		Me._edtRdData_5.Location = New System.Drawing.Point(400, 133)
		Me._edtRdData_5.TabIndex = 25
		Me._edtRdData_5.AcceptsReturn = True
		Me._edtRdData_5.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me._edtRdData_5.BackColor = System.Drawing.SystemColors.Window
		Me._edtRdData_5.CausesValidation = True
		Me._edtRdData_5.Enabled = True
		Me._edtRdData_5.ForeColor = System.Drawing.SystemColors.WindowText
		Me._edtRdData_5.HideSelection = True
		Me._edtRdData_5.ReadOnly = False
		Me._edtRdData_5.Maxlength = 0
		Me._edtRdData_5.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._edtRdData_5.MultiLine = False
		Me._edtRdData_5.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._edtRdData_5.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._edtRdData_5.TabStop = True
		Me._edtRdData_5.Visible = True
		Me._edtRdData_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._edtRdData_5.Name = "_edtRdData_5"
		Me._edtRdData_4.AutoSize = False
		Me._edtRdData_4.Size = New System.Drawing.Size(106, 25)
		Me._edtRdData_4.Location = New System.Drawing.Point(400, 106)
		Me._edtRdData_4.TabIndex = 24
		Me._edtRdData_4.AcceptsReturn = True
		Me._edtRdData_4.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me._edtRdData_4.BackColor = System.Drawing.SystemColors.Window
		Me._edtRdData_4.CausesValidation = True
		Me._edtRdData_4.Enabled = True
		Me._edtRdData_4.ForeColor = System.Drawing.SystemColors.WindowText
		Me._edtRdData_4.HideSelection = True
		Me._edtRdData_4.ReadOnly = False
		Me._edtRdData_4.Maxlength = 0
		Me._edtRdData_4.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._edtRdData_4.MultiLine = False
		Me._edtRdData_4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._edtRdData_4.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._edtRdData_4.TabStop = True
		Me._edtRdData_4.Visible = True
		Me._edtRdData_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._edtRdData_4.Name = "_edtRdData_4"
		Me._edtRdData_3.AutoSize = False
		Me._edtRdData_3.Size = New System.Drawing.Size(106, 25)
		Me._edtRdData_3.Location = New System.Drawing.Point(400, 80)
		Me._edtRdData_3.TabIndex = 23
		Me._edtRdData_3.AcceptsReturn = True
		Me._edtRdData_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me._edtRdData_3.BackColor = System.Drawing.SystemColors.Window
		Me._edtRdData_3.CausesValidation = True
		Me._edtRdData_3.Enabled = True
		Me._edtRdData_3.ForeColor = System.Drawing.SystemColors.WindowText
		Me._edtRdData_3.HideSelection = True
		Me._edtRdData_3.ReadOnly = False
		Me._edtRdData_3.Maxlength = 0
		Me._edtRdData_3.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._edtRdData_3.MultiLine = False
		Me._edtRdData_3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._edtRdData_3.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._edtRdData_3.TabStop = True
		Me._edtRdData_3.Visible = True
		Me._edtRdData_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._edtRdData_3.Name = "_edtRdData_3"
		Me._edtRdCmd_5.AutoSize = False
		Me._edtRdCmd_5.Size = New System.Drawing.Size(65, 25)
		Me._edtRdCmd_5.Location = New System.Drawing.Point(328, 133)
		Me._edtRdCmd_5.TabIndex = 22
		Me._edtRdCmd_5.AcceptsReturn = True
		Me._edtRdCmd_5.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me._edtRdCmd_5.BackColor = System.Drawing.SystemColors.Window
		Me._edtRdCmd_5.CausesValidation = True
		Me._edtRdCmd_5.Enabled = True
		Me._edtRdCmd_5.ForeColor = System.Drawing.SystemColors.WindowText
		Me._edtRdCmd_5.HideSelection = True
		Me._edtRdCmd_5.ReadOnly = False
		Me._edtRdCmd_5.Maxlength = 0
		Me._edtRdCmd_5.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._edtRdCmd_5.MultiLine = False
		Me._edtRdCmd_5.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._edtRdCmd_5.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._edtRdCmd_5.TabStop = True
		Me._edtRdCmd_5.Visible = True
		Me._edtRdCmd_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._edtRdCmd_5.Name = "_edtRdCmd_5"
		Me._edtRdCmd_4.AutoSize = False
		Me._edtRdCmd_4.Size = New System.Drawing.Size(65, 25)
		Me._edtRdCmd_4.Location = New System.Drawing.Point(328, 106)
		Me._edtRdCmd_4.TabIndex = 21
		Me._edtRdCmd_4.AcceptsReturn = True
		Me._edtRdCmd_4.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me._edtRdCmd_4.BackColor = System.Drawing.SystemColors.Window
		Me._edtRdCmd_4.CausesValidation = True
		Me._edtRdCmd_4.Enabled = True
		Me._edtRdCmd_4.ForeColor = System.Drawing.SystemColors.WindowText
		Me._edtRdCmd_4.HideSelection = True
		Me._edtRdCmd_4.ReadOnly = False
		Me._edtRdCmd_4.Maxlength = 0
		Me._edtRdCmd_4.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._edtRdCmd_4.MultiLine = False
		Me._edtRdCmd_4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._edtRdCmd_4.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._edtRdCmd_4.TabStop = True
		Me._edtRdCmd_4.Visible = True
		Me._edtRdCmd_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._edtRdCmd_4.Name = "_edtRdCmd_4"
		Me._edtRdCmd_3.AutoSize = False
		Me._edtRdCmd_3.Size = New System.Drawing.Size(65, 25)
		Me._edtRdCmd_3.Location = New System.Drawing.Point(328, 80)
		Me._edtRdCmd_3.TabIndex = 20
		Me._edtRdCmd_3.AcceptsReturn = True
		Me._edtRdCmd_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me._edtRdCmd_3.BackColor = System.Drawing.SystemColors.Window
		Me._edtRdCmd_3.CausesValidation = True
		Me._edtRdCmd_3.Enabled = True
		Me._edtRdCmd_3.ForeColor = System.Drawing.SystemColors.WindowText
		Me._edtRdCmd_3.HideSelection = True
		Me._edtRdCmd_3.ReadOnly = False
		Me._edtRdCmd_3.Maxlength = 0
		Me._edtRdCmd_3.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._edtRdCmd_3.MultiLine = False
		Me._edtRdCmd_3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._edtRdCmd_3.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._edtRdCmd_3.TabStop = True
		Me._edtRdCmd_3.Visible = True
		Me._edtRdCmd_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._edtRdCmd_3.Name = "_edtRdCmd_3"
		Me._chkOnOff_5.Text = "On/Off"
		Me._chkOnOff_5.Size = New System.Drawing.Size(57, 17)
		Me._chkOnOff_5.Location = New System.Drawing.Point(264, 136)
		Me._chkOnOff_5.TabIndex = 19
		Me._chkOnOff_5.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._chkOnOff_5.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me._chkOnOff_5.BackColor = System.Drawing.SystemColors.Control
		Me._chkOnOff_5.CausesValidation = True
		Me._chkOnOff_5.Enabled = True
		Me._chkOnOff_5.ForeColor = System.Drawing.SystemColors.ControlText
		Me._chkOnOff_5.Cursor = System.Windows.Forms.Cursors.Default
		Me._chkOnOff_5.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._chkOnOff_5.Appearance = System.Windows.Forms.Appearance.Normal
		Me._chkOnOff_5.TabStop = True
		Me._chkOnOff_5.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me._chkOnOff_5.Visible = True
		Me._chkOnOff_5.Name = "_chkOnOff_5"
		Me._chkOnOff_4.Text = "On/Off"
		Me._chkOnOff_4.Size = New System.Drawing.Size(57, 12)
		Me._chkOnOff_4.Location = New System.Drawing.Point(264, 112)
		Me._chkOnOff_4.TabIndex = 18
		Me._chkOnOff_4.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._chkOnOff_4.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me._chkOnOff_4.BackColor = System.Drawing.SystemColors.Control
		Me._chkOnOff_4.CausesValidation = True
		Me._chkOnOff_4.Enabled = True
		Me._chkOnOff_4.ForeColor = System.Drawing.SystemColors.ControlText
		Me._chkOnOff_4.Cursor = System.Windows.Forms.Cursors.Default
		Me._chkOnOff_4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._chkOnOff_4.Appearance = System.Windows.Forms.Appearance.Normal
		Me._chkOnOff_4.TabStop = True
		Me._chkOnOff_4.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me._chkOnOff_4.Visible = True
		Me._chkOnOff_4.Name = "_chkOnOff_4"
		Me._chkOnOff_3.Text = "On/Off"
		Me._chkOnOff_3.Size = New System.Drawing.Size(57, 17)
		Me._chkOnOff_3.Location = New System.Drawing.Point(264, 84)
		Me._chkOnOff_3.TabIndex = 17
		Me._chkOnOff_3.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._chkOnOff_3.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me._chkOnOff_3.BackColor = System.Drawing.SystemColors.Control
		Me._chkOnOff_3.CausesValidation = True
		Me._chkOnOff_3.Enabled = True
		Me._chkOnOff_3.ForeColor = System.Drawing.SystemColors.ControlText
		Me._chkOnOff_3.Cursor = System.Windows.Forms.Cursors.Default
		Me._chkOnOff_3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._chkOnOff_3.Appearance = System.Windows.Forms.Appearance.Normal
		Me._chkOnOff_3.TabStop = True
		Me._chkOnOff_3.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me._chkOnOff_3.Visible = True
		Me._chkOnOff_3.Name = "_chkOnOff_3"
		Me._edtRdData_2.AutoSize = False
		Me._edtRdData_2.Size = New System.Drawing.Size(106, 25)
		Me._edtRdData_2.Location = New System.Drawing.Point(152, 133)
		Me._edtRdData_2.TabIndex = 16
		Me._edtRdData_2.AcceptsReturn = True
		Me._edtRdData_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me._edtRdData_2.BackColor = System.Drawing.SystemColors.Window
		Me._edtRdData_2.CausesValidation = True
		Me._edtRdData_2.Enabled = True
		Me._edtRdData_2.ForeColor = System.Drawing.SystemColors.WindowText
		Me._edtRdData_2.HideSelection = True
		Me._edtRdData_2.ReadOnly = False
		Me._edtRdData_2.Maxlength = 0
		Me._edtRdData_2.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._edtRdData_2.MultiLine = False
		Me._edtRdData_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._edtRdData_2.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._edtRdData_2.TabStop = True
		Me._edtRdData_2.Visible = True
		Me._edtRdData_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._edtRdData_2.Name = "_edtRdData_2"
		Me._edtRdData_1.AutoSize = False
		Me._edtRdData_1.Size = New System.Drawing.Size(106, 25)
		Me._edtRdData_1.Location = New System.Drawing.Point(152, 106)
		Me._edtRdData_1.TabIndex = 15
		Me._edtRdData_1.AcceptsReturn = True
		Me._edtRdData_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me._edtRdData_1.BackColor = System.Drawing.SystemColors.Window
		Me._edtRdData_1.CausesValidation = True
		Me._edtRdData_1.Enabled = True
		Me._edtRdData_1.ForeColor = System.Drawing.SystemColors.WindowText
		Me._edtRdData_1.HideSelection = True
		Me._edtRdData_1.ReadOnly = False
		Me._edtRdData_1.Maxlength = 0
		Me._edtRdData_1.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._edtRdData_1.MultiLine = False
		Me._edtRdData_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._edtRdData_1.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._edtRdData_1.TabStop = True
		Me._edtRdData_1.Visible = True
		Me._edtRdData_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._edtRdData_1.Name = "_edtRdData_1"
		Me._edtRdData_0.AutoSize = False
		Me._edtRdData_0.Size = New System.Drawing.Size(106, 25)
		Me._edtRdData_0.Location = New System.Drawing.Point(152, 80)
		Me._edtRdData_0.TabIndex = 14
		Me._edtRdData_0.AcceptsReturn = True
		Me._edtRdData_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me._edtRdData_0.BackColor = System.Drawing.SystemColors.Window
		Me._edtRdData_0.CausesValidation = True
		Me._edtRdData_0.Enabled = True
		Me._edtRdData_0.ForeColor = System.Drawing.SystemColors.WindowText
		Me._edtRdData_0.HideSelection = True
		Me._edtRdData_0.ReadOnly = False
		Me._edtRdData_0.Maxlength = 0
		Me._edtRdData_0.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._edtRdData_0.MultiLine = False
		Me._edtRdData_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._edtRdData_0.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._edtRdData_0.TabStop = True
		Me._edtRdData_0.Visible = True
		Me._edtRdData_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._edtRdData_0.Name = "_edtRdData_0"
		Me._edtRdCmd_2.AutoSize = False
		Me._edtRdCmd_2.Size = New System.Drawing.Size(65, 25)
		Me._edtRdCmd_2.Location = New System.Drawing.Point(80, 133)
		Me._edtRdCmd_2.TabIndex = 13
		Me._edtRdCmd_2.AcceptsReturn = True
		Me._edtRdCmd_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me._edtRdCmd_2.BackColor = System.Drawing.SystemColors.Window
		Me._edtRdCmd_2.CausesValidation = True
		Me._edtRdCmd_2.Enabled = True
		Me._edtRdCmd_2.ForeColor = System.Drawing.SystemColors.WindowText
		Me._edtRdCmd_2.HideSelection = True
		Me._edtRdCmd_2.ReadOnly = False
		Me._edtRdCmd_2.Maxlength = 0
		Me._edtRdCmd_2.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._edtRdCmd_2.MultiLine = False
		Me._edtRdCmd_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._edtRdCmd_2.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._edtRdCmd_2.TabStop = True
		Me._edtRdCmd_2.Visible = True
		Me._edtRdCmd_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._edtRdCmd_2.Name = "_edtRdCmd_2"
		Me._edtRdCmd_1.AutoSize = False
		Me._edtRdCmd_1.Size = New System.Drawing.Size(65, 25)
		Me._edtRdCmd_1.Location = New System.Drawing.Point(80, 106)
		Me._edtRdCmd_1.TabIndex = 12
		Me._edtRdCmd_1.AcceptsReturn = True
		Me._edtRdCmd_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me._edtRdCmd_1.BackColor = System.Drawing.SystemColors.Window
		Me._edtRdCmd_1.CausesValidation = True
		Me._edtRdCmd_1.Enabled = True
		Me._edtRdCmd_1.ForeColor = System.Drawing.SystemColors.WindowText
		Me._edtRdCmd_1.HideSelection = True
		Me._edtRdCmd_1.ReadOnly = False
		Me._edtRdCmd_1.Maxlength = 0
		Me._edtRdCmd_1.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._edtRdCmd_1.MultiLine = False
		Me._edtRdCmd_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._edtRdCmd_1.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._edtRdCmd_1.TabStop = True
		Me._edtRdCmd_1.Visible = True
		Me._edtRdCmd_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._edtRdCmd_1.Name = "_edtRdCmd_1"
		Me._edtRdCmd_0.AutoSize = False
		Me._edtRdCmd_0.Size = New System.Drawing.Size(65, 25)
		Me._edtRdCmd_0.Location = New System.Drawing.Point(80, 80)
		Me._edtRdCmd_0.TabIndex = 11
		Me._edtRdCmd_0.AcceptsReturn = True
		Me._edtRdCmd_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me._edtRdCmd_0.BackColor = System.Drawing.SystemColors.Window
		Me._edtRdCmd_0.CausesValidation = True
		Me._edtRdCmd_0.Enabled = True
		Me._edtRdCmd_0.ForeColor = System.Drawing.SystemColors.WindowText
		Me._edtRdCmd_0.HideSelection = True
		Me._edtRdCmd_0.ReadOnly = False
		Me._edtRdCmd_0.Maxlength = 0
		Me._edtRdCmd_0.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._edtRdCmd_0.MultiLine = False
		Me._edtRdCmd_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._edtRdCmd_0.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._edtRdCmd_0.TabStop = True
		Me._edtRdCmd_0.Visible = True
		Me._edtRdCmd_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._edtRdCmd_0.Name = "_edtRdCmd_0"
		Me._chkOnOff_2.Text = "On/Off"
		Me._chkOnOff_2.Size = New System.Drawing.Size(57, 19)
		Me._chkOnOff_2.Location = New System.Drawing.Point(16, 136)
		Me._chkOnOff_2.TabIndex = 10
		Me._chkOnOff_2.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._chkOnOff_2.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me._chkOnOff_2.BackColor = System.Drawing.SystemColors.Control
		Me._chkOnOff_2.CausesValidation = True
		Me._chkOnOff_2.Enabled = True
		Me._chkOnOff_2.ForeColor = System.Drawing.SystemColors.ControlText
		Me._chkOnOff_2.Cursor = System.Windows.Forms.Cursors.Default
		Me._chkOnOff_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._chkOnOff_2.Appearance = System.Windows.Forms.Appearance.Normal
		Me._chkOnOff_2.TabStop = True
		Me._chkOnOff_2.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me._chkOnOff_2.Visible = True
		Me._chkOnOff_2.Name = "_chkOnOff_2"
		Me._chkOnOff_1.Text = "On/Off"
		Me._chkOnOff_1.Size = New System.Drawing.Size(57, 19)
		Me._chkOnOff_1.Location = New System.Drawing.Point(16, 109)
		Me._chkOnOff_1.TabIndex = 9
		Me._chkOnOff_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._chkOnOff_1.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me._chkOnOff_1.BackColor = System.Drawing.SystemColors.Control
		Me._chkOnOff_1.CausesValidation = True
		Me._chkOnOff_1.Enabled = True
		Me._chkOnOff_1.ForeColor = System.Drawing.SystemColors.ControlText
		Me._chkOnOff_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._chkOnOff_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._chkOnOff_1.Appearance = System.Windows.Forms.Appearance.Normal
		Me._chkOnOff_1.TabStop = True
		Me._chkOnOff_1.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me._chkOnOff_1.Visible = True
		Me._chkOnOff_1.Name = "_chkOnOff_1"
		Me._chkOnOff_0.Text = "On/Off"
		Me._chkOnOff_0.Size = New System.Drawing.Size(57, 19)
		Me._chkOnOff_0.Location = New System.Drawing.Point(16, 84)
		Me._chkOnOff_0.TabIndex = 8
		Me._chkOnOff_0.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._chkOnOff_0.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me._chkOnOff_0.BackColor = System.Drawing.SystemColors.Control
		Me._chkOnOff_0.CausesValidation = True
		Me._chkOnOff_0.Enabled = True
		Me._chkOnOff_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me._chkOnOff_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._chkOnOff_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._chkOnOff_0.Appearance = System.Windows.Forms.Appearance.Normal
		Me._chkOnOff_0.TabStop = True
		Me._chkOnOff_0.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me._chkOnOff_0.Visible = True
		Me._chkOnOff_0.Name = "_chkOnOff_0"
		Me.cboAxisSel.Size = New System.Drawing.Size(161, 20)
		Me.cboAxisSel.Location = New System.Drawing.Point(336, 20)
		Me.cboAxisSel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cboAxisSel.TabIndex = 7
		Me.cboAxisSel.BackColor = System.Drawing.SystemColors.Window
		Me.cboAxisSel.CausesValidation = True
		Me.cboAxisSel.Enabled = True
		Me.cboAxisSel.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cboAxisSel.IntegralHeight = True
		Me.cboAxisSel.Cursor = System.Windows.Forms.Cursors.Default
		Me.cboAxisSel.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cboAxisSel.Sorted = False
		Me.cboAxisSel.TabStop = True
		Me.cboAxisSel.Visible = True
		Me.cboAxisSel.Name = "cboAxisSel"
		Me.chkHex.Text = "Hex/Dec"
		Me.chkHex.Size = New System.Drawing.Size(73, 17)
		Me.chkHex.Location = New System.Drawing.Point(264, 21)
		Me.chkHex.TabIndex = 6
		Me.chkHex.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkHex.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkHex.BackColor = System.Drawing.SystemColors.Control
		Me.chkHex.CausesValidation = True
		Me.chkHex.Enabled = True
		Me.chkHex.ForeColor = System.Drawing.SystemColors.ControlText
		Me.chkHex.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkHex.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkHex.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkHex.TabStop = True
		Me.chkHex.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkHex.Visible = True
		Me.chkHex.Name = "chkHex"
		Me.cboPort.Size = New System.Drawing.Size(105, 20)
		Me.cboPort.Location = New System.Drawing.Point(152, 48)
		Me.cboPort.Items.AddRange(New Object(){"DATAPL0", "DATAPL1", "DATAPM0", "DATAPM1", "CMDP0", "CMDP1", "UIOP0", "UIOP1"})
		Me.cboPort.TabIndex = 5
		Me.cboPort.Text = "Combo1"
		Me.cboPort.BackColor = System.Drawing.SystemColors.Window
		Me.cboPort.CausesValidation = True
		Me.cboPort.Enabled = True
		Me.cboPort.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cboPort.IntegralHeight = True
		Me.cboPort.Cursor = System.Windows.Forms.Cursors.Default
		Me.cboPort.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cboPort.Sorted = False
		Me.cboPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
		Me.cboPort.TabStop = True
		Me.cboPort.Visible = True
		Me.cboPort.Name = "cboPort"
		Me.edtData.AutoSize = False
		Me.edtData.Size = New System.Drawing.Size(106, 25)
		Me.edtData.Location = New System.Drawing.Point(152, 16)
		Me.edtData.TabIndex = 4
		Me.edtData.AcceptsReturn = True
		Me.edtData.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.edtData.BackColor = System.Drawing.SystemColors.Window
		Me.edtData.CausesValidation = True
		Me.edtData.Enabled = True
		Me.edtData.ForeColor = System.Drawing.SystemColors.WindowText
		Me.edtData.HideSelection = True
		Me.edtData.ReadOnly = False
		Me.edtData.Maxlength = 0
		Me.edtData.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.edtData.MultiLine = False
		Me.edtData.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.edtData.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.edtData.TabStop = True
		Me.edtData.Visible = True
		Me.edtData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.edtData.Name = "edtData"
		Me.edtCmd.AutoSize = False
		Me.edtCmd.Size = New System.Drawing.Size(65, 25)
		Me.edtCmd.Location = New System.Drawing.Point(80, 16)
		Me.edtCmd.TabIndex = 3
		Me.edtCmd.AcceptsReturn = True
		Me.edtCmd.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.edtCmd.BackColor = System.Drawing.SystemColors.Window
		Me.edtCmd.CausesValidation = True
		Me.edtCmd.Enabled = True
		Me.edtCmd.ForeColor = System.Drawing.SystemColors.WindowText
		Me.edtCmd.HideSelection = True
		Me.edtCmd.ReadOnly = False
		Me.edtCmd.Maxlength = 0
		Me.edtCmd.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.edtCmd.MultiLine = False
		Me.edtCmd.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.edtCmd.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.edtCmd.TabStop = True
		Me.edtCmd.Visible = True
		Me.edtCmd.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.edtCmd.Name = "edtCmd"
		Me.btnWr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.btnWr.Text = "WR"
		Me.btnWr.Size = New System.Drawing.Size(57, 25)
		Me.btnWr.Location = New System.Drawing.Point(80, 48)
		Me.btnWr.TabIndex = 2
		Me.btnWr.BackColor = System.Drawing.SystemColors.Control
		Me.btnWr.CausesValidation = True
		Me.btnWr.Enabled = True
		Me.btnWr.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btnWr.Cursor = System.Windows.Forms.Cursors.Default
		Me.btnWr.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btnWr.TabStop = True
		Me.btnWr.Name = "btnWr"
		Me.btnRd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.btnRd.Text = "RD"
		Me.btnRd.Size = New System.Drawing.Size(57, 25)
		Me.btnRd.Location = New System.Drawing.Point(16, 48)
		Me.btnRd.TabIndex = 1
		Me.btnRd.BackColor = System.Drawing.SystemColors.Control
		Me.btnRd.CausesValidation = True
		Me.btnRd.Enabled = True
		Me.btnRd.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btnRd.Cursor = System.Windows.Forms.Cursors.Default
		Me.btnRd.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btnRd.TabStop = True
		Me.btnRd.Name = "btnRd"
		Me.btnCmd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.btnCmd.Text = "CMD"
		Me.btnCmd.Size = New System.Drawing.Size(57, 25)
		Me.btnCmd.Location = New System.Drawing.Point(16, 16)
		Me.btnCmd.TabIndex = 0
		Me.btnCmd.BackColor = System.Drawing.SystemColors.Control
		Me.btnCmd.CausesValidation = True
		Me.btnCmd.Enabled = True
		Me.btnCmd.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btnCmd.Cursor = System.Windows.Forms.Cursors.Default
		Me.btnCmd.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btnCmd.TabStop = True
		Me.btnCmd.Name = "btnCmd"
		Me.Controls.Add(_edtRdData_5)
		Me.Controls.Add(_edtRdData_4)
		Me.Controls.Add(_edtRdData_3)
		Me.Controls.Add(_edtRdCmd_5)
		Me.Controls.Add(_edtRdCmd_4)
		Me.Controls.Add(_edtRdCmd_3)
		Me.Controls.Add(_chkOnOff_5)
		Me.Controls.Add(_chkOnOff_4)
		Me.Controls.Add(_chkOnOff_3)
		Me.Controls.Add(_edtRdData_2)
		Me.Controls.Add(_edtRdData_1)
		Me.Controls.Add(_edtRdData_0)
		Me.Controls.Add(_edtRdCmd_2)
		Me.Controls.Add(_edtRdCmd_1)
		Me.Controls.Add(_edtRdCmd_0)
		Me.Controls.Add(_chkOnOff_2)
		Me.Controls.Add(_chkOnOff_1)
		Me.Controls.Add(_chkOnOff_0)
		Me.Controls.Add(cboAxisSel)
		Me.Controls.Add(chkHex)
		Me.Controls.Add(cboPort)
		Me.Controls.Add(edtData)
		Me.Controls.Add(edtCmd)
		Me.Controls.Add(btnWr)
		Me.Controls.Add(btnRd)
		Me.Controls.Add(btnCmd)
		Me.chkOnOff.SetIndex(_chkOnOff_5, CType(5, Short))
		Me.chkOnOff.SetIndex(_chkOnOff_4, CType(4, Short))
		Me.chkOnOff.SetIndex(_chkOnOff_3, CType(3, Short))
		Me.chkOnOff.SetIndex(_chkOnOff_2, CType(2, Short))
		Me.chkOnOff.SetIndex(_chkOnOff_1, CType(1, Short))
		Me.chkOnOff.SetIndex(_chkOnOff_0, CType(0, Short))
		Me.edtRdCmd.SetIndex(_edtRdCmd_5, CType(5, Short))
		Me.edtRdCmd.SetIndex(_edtRdCmd_4, CType(4, Short))
		Me.edtRdCmd.SetIndex(_edtRdCmd_3, CType(3, Short))
		Me.edtRdCmd.SetIndex(_edtRdCmd_2, CType(2, Short))
		Me.edtRdCmd.SetIndex(_edtRdCmd_1, CType(1, Short))
		Me.edtRdCmd.SetIndex(_edtRdCmd_0, CType(0, Short))
		Me.edtRdData.SetIndex(_edtRdData_5, CType(5, Short))
		Me.edtRdData.SetIndex(_edtRdData_4, CType(4, Short))
		Me.edtRdData.SetIndex(_edtRdData_3, CType(3, Short))
		Me.edtRdData.SetIndex(_edtRdData_2, CType(2, Short))
		Me.edtRdData.SetIndex(_edtRdData_1, CType(1, Short))
		Me.edtRdData.SetIndex(_edtRdData_0, CType(0, Short))
		CType(Me.edtRdData, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.edtRdCmd, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.chkOnOff, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class