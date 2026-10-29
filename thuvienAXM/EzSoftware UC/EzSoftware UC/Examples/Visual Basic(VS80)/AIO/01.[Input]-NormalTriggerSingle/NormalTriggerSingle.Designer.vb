<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmNormalTriggerSingle
#Region "Windows Form Designer generated code "
	<System.Diagnostics.DebuggerNonUserCode()> Public Sub New()
		MyBase.New()
		'This call is required by the Windows Form Designer.
		InitializeComponent()
	End Sub
	'Form overrides dispose to clean up the component list.
	<System.Diagnostics.DebuggerNonUserCode()> Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
		If Disposing Then
			If Not components Is Nothing Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(Disposing)
	End Sub
	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer
	Public ToolTip1 As System.Windows.Forms.ToolTip
	Public WithEvents m_timer As System.Windows.Forms.Timer
	Public WithEvents m_btnStop As System.Windows.Forms.Button
	Public WithEvents m_btnStart As System.Windows.Forms.Button
	Public WithEvents m_cboValueType As System.Windows.Forms.ComboBox
	Public WithEvents m_stcReadValue As System.Windows.Forms.TextBox
	Public WithEvents m_cboVoltageRange As System.Windows.Forms.ComboBox
	Public WithEvents m_cboChannel As System.Windows.Forms.ComboBox
	Public WithEvents Frame2 As System.Windows.Forms.GroupBox
	Public WithEvents m_cboModule As System.Windows.Forms.ComboBox
	Public WithEvents Frame1 As System.Windows.Forms.GroupBox
	Public WithEvents m_stcValueType As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmNormalTriggerSingle))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.m_timer = New System.Windows.Forms.Timer(components)
		Me.m_btnStop = New System.Windows.Forms.Button
		Me.m_btnStart = New System.Windows.Forms.Button
		Me.m_cboValueType = New System.Windows.Forms.ComboBox
		Me.m_stcReadValue = New System.Windows.Forms.TextBox
		Me.m_cboVoltageRange = New System.Windows.Forms.ComboBox
		Me.Frame2 = New System.Windows.Forms.GroupBox
		Me.m_cboChannel = New System.Windows.Forms.ComboBox
		Me.Frame1 = New System.Windows.Forms.GroupBox
		Me.m_cboModule = New System.Windows.Forms.ComboBox
		Me.m_stcValueType = New System.Windows.Forms.Label
		Me.Label3 = New System.Windows.Forms.Label
		Me.Label2 = New System.Windows.Forms.Label
		Me.Label1 = New System.Windows.Forms.Label
		Me.Frame2.SuspendLayout()
		Me.Frame1.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.Text = "NormalTriggerSingle"
		Me.ClientSize = New System.Drawing.Size(478, 127)
		Me.Location = New System.Drawing.Point(8, 30)
		Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
		Me.BackgroundImage = CType(resources.GetObject("frmNormalTriggerSingle.BackgroundImage"), System.Drawing.Image)
		Me.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation
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
		Me.Name = "frmNormalTriggerSingle"
		Me.m_timer.Enabled = False
		Me.m_timer.Interval = 100
		Me.m_btnStop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.m_btnStop.Text = "Stop"
		Me.m_btnStop.Size = New System.Drawing.Size(74, 20)
		Me.m_btnStop.Location = New System.Drawing.Point(384, 88)
		Me.m_btnStop.TabIndex = 10
		Me.m_btnStop.BackColor = System.Drawing.SystemColors.Control
		Me.m_btnStop.CausesValidation = True
		Me.m_btnStop.Enabled = True
		Me.m_btnStop.ForeColor = System.Drawing.SystemColors.ControlText
		Me.m_btnStop.Cursor = System.Windows.Forms.Cursors.Default
		Me.m_btnStop.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.m_btnStop.TabStop = True
		Me.m_btnStop.Name = "m_btnStop"
		Me.m_btnStart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.m_btnStart.Text = "Start"
		Me.m_btnStart.Size = New System.Drawing.Size(74, 20)
		Me.m_btnStart.Location = New System.Drawing.Point(300, 88)
		Me.m_btnStart.TabIndex = 9
		Me.m_btnStart.BackColor = System.Drawing.SystemColors.Control
		Me.m_btnStart.CausesValidation = True
		Me.m_btnStart.Enabled = True
		Me.m_btnStart.ForeColor = System.Drawing.SystemColors.ControlText
		Me.m_btnStart.Cursor = System.Windows.Forms.Cursors.Default
		Me.m_btnStart.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.m_btnStart.TabStop = True
		Me.m_btnStart.Name = "m_btnStart"
		Me.m_cboValueType.Size = New System.Drawing.Size(160, 20)
		Me.m_cboValueType.Location = New System.Drawing.Point(300, 60)
		Me.m_cboValueType.Items.AddRange(New Object(){"00: Volt", "01: Digit"})
		Me.m_cboValueType.TabIndex = 7
		Me.m_cboValueType.BackColor = System.Drawing.SystemColors.Window
		Me.m_cboValueType.CausesValidation = True
		Me.m_cboValueType.Enabled = True
		Me.m_cboValueType.ForeColor = System.Drawing.SystemColors.WindowText
		Me.m_cboValueType.IntegralHeight = True
		Me.m_cboValueType.Cursor = System.Windows.Forms.Cursors.Default
		Me.m_cboValueType.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.m_cboValueType.Sorted = False
		Me.m_cboValueType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
		Me.m_cboValueType.TabStop = True
		Me.m_cboValueType.Visible = True
		Me.m_cboValueType.Name = "m_cboValueType"
		Me.m_stcReadValue.AutoSize = False
		Me.m_stcReadValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me.m_stcReadValue.Size = New System.Drawing.Size(120, 20)
		Me.m_stcReadValue.Location = New System.Drawing.Point(87, 88)
		Me.m_stcReadValue.ReadOnly = True
		Me.m_stcReadValue.TabIndex = 5
		Me.m_stcReadValue.Text = "0.0000"
		Me.m_stcReadValue.AcceptsReturn = True
		Me.m_stcReadValue.BackColor = System.Drawing.SystemColors.Window
		Me.m_stcReadValue.CausesValidation = True
		Me.m_stcReadValue.Enabled = True
		Me.m_stcReadValue.ForeColor = System.Drawing.SystemColors.WindowText
		Me.m_stcReadValue.HideSelection = True
		Me.m_stcReadValue.Maxlength = 0
		Me.m_stcReadValue.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.m_stcReadValue.MultiLine = False
		Me.m_stcReadValue.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.m_stcReadValue.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.m_stcReadValue.TabStop = True
		Me.m_stcReadValue.Visible = True
		Me.m_stcReadValue.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.m_stcReadValue.Name = "m_stcReadValue"
		Me.m_cboVoltageRange.Size = New System.Drawing.Size(120, 20)
		Me.m_cboVoltageRange.Location = New System.Drawing.Point(87, 60)
		Me.m_cboVoltageRange.TabIndex = 4
		Me.m_cboVoltageRange.BackColor = System.Drawing.SystemColors.Window
		Me.m_cboVoltageRange.CausesValidation = True
		Me.m_cboVoltageRange.Enabled = True
		Me.m_cboVoltageRange.ForeColor = System.Drawing.SystemColors.WindowText
		Me.m_cboVoltageRange.IntegralHeight = True
		Me.m_cboVoltageRange.Cursor = System.Windows.Forms.Cursors.Default
		Me.m_cboVoltageRange.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.m_cboVoltageRange.Sorted = False
		Me.m_cboVoltageRange.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
		Me.m_cboVoltageRange.TabStop = True
		Me.m_cboVoltageRange.Visible = True
		Me.m_cboVoltageRange.Name = "m_cboVoltageRange"
		Me.Frame2.Text = "[Channel]"
		Me.Frame2.Size = New System.Drawing.Size(113, 44)
		Me.Frame2.Location = New System.Drawing.Point(355, 7)
		Me.Frame2.TabIndex = 1
		Me.Frame2.BackColor = System.Drawing.SystemColors.Control
		Me.Frame2.Enabled = True
		Me.Frame2.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Frame2.Visible = True
		Me.Frame2.Name = "Frame2"
		Me.m_cboChannel.Size = New System.Drawing.Size(97, 20)
		Me.m_cboChannel.Location = New System.Drawing.Point(8, 16)
		Me.m_cboChannel.TabIndex = 12
		Me.m_cboChannel.BackColor = System.Drawing.SystemColors.Window
		Me.m_cboChannel.CausesValidation = True
		Me.m_cboChannel.Enabled = True
		Me.m_cboChannel.ForeColor = System.Drawing.SystemColors.WindowText
		Me.m_cboChannel.IntegralHeight = True
		Me.m_cboChannel.Cursor = System.Windows.Forms.Cursors.Default
		Me.m_cboChannel.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.m_cboChannel.Sorted = False
		Me.m_cboChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
		Me.m_cboChannel.TabStop = True
		Me.m_cboChannel.Visible = True
		Me.m_cboChannel.Name = "m_cboChannel"
		Me.Frame1.Text = "[Board No¢ÂModule No¢ÂModule ID]"
		Me.Frame1.Size = New System.Drawing.Size(338, 44)
		Me.Frame1.Location = New System.Drawing.Point(7, 7)
		Me.Frame1.TabIndex = 0
		Me.Frame1.BackColor = System.Drawing.SystemColors.Control
		Me.Frame1.Enabled = True
		Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Frame1.Visible = True
		Me.Frame1.Name = "Frame1"
		Me.m_cboModule.Size = New System.Drawing.Size(321, 20)
		Me.m_cboModule.Location = New System.Drawing.Point(8, 16)
		Me.m_cboModule.TabIndex = 11
		Me.m_cboModule.BackColor = System.Drawing.SystemColors.Window
		Me.m_cboModule.CausesValidation = True
		Me.m_cboModule.Enabled = True
		Me.m_cboModule.ForeColor = System.Drawing.SystemColors.WindowText
		Me.m_cboModule.IntegralHeight = True
		Me.m_cboModule.Cursor = System.Windows.Forms.Cursors.Default
		Me.m_cboModule.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.m_cboModule.Sorted = False
		Me.m_cboModule.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
		Me.m_cboModule.TabStop = True
		Me.m_cboModule.Visible = True
		Me.m_cboModule.Name = "m_cboModule"
		Me.m_stcValueType.Text = "Volt"
		Me.m_stcValueType.Size = New System.Drawing.Size(73, 17)
		Me.m_stcValueType.Location = New System.Drawing.Point(216, 91)
		Me.m_stcValueType.TabIndex = 8
		Me.m_stcValueType.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.m_stcValueType.BackColor = System.Drawing.SystemColors.Control
		Me.m_stcValueType.Enabled = True
		Me.m_stcValueType.ForeColor = System.Drawing.SystemColors.ControlText
		Me.m_stcValueType.Cursor = System.Windows.Forms.Cursors.Default
		Me.m_stcValueType.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.m_stcValueType.UseMnemonic = True
		Me.m_stcValueType.Visible = True
		Me.m_stcValueType.AutoSize = False
		Me.m_stcValueType.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.m_stcValueType.Name = "m_stcValueType"
		Me.Label3.Text = "Value Type  :"
		Me.Label3.Size = New System.Drawing.Size(81, 17)
		Me.Label3.Location = New System.Drawing.Point(216, 64)
		Me.Label3.TabIndex = 6
		Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label3.BackColor = System.Drawing.SystemColors.Control
		Me.Label3.Enabled = True
		Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label3.UseMnemonic = True
		Me.Label3.Visible = True
		Me.Label3.AutoSize = False
		Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label3.Name = "Label3"
		Me.Label2.Text = "Read Value :"
		Me.Label2.Size = New System.Drawing.Size(73, 17)
		Me.Label2.Location = New System.Drawing.Point(8, 91)
		Me.Label2.TabIndex = 3
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label2.BackColor = System.Drawing.SystemColors.Control
		Me.Label2.Enabled = True
		Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label2.UseMnemonic = True
		Me.Label2.Visible = True
		Me.Label2.AutoSize = False
		Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label2.Name = "Label2"
		Me.Label1.Text = "Volt. Range :"
		Me.Label1.Size = New System.Drawing.Size(73, 17)
		Me.Label1.Location = New System.Drawing.Point(8, 64)
		Me.Label1.TabIndex = 2
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label1.BackColor = System.Drawing.SystemColors.Control
		Me.Label1.Enabled = True
		Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label1.UseMnemonic = True
		Me.Label1.Visible = True
		Me.Label1.AutoSize = False
		Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label1.Name = "Label1"
		Me.Controls.Add(m_btnStop)
		Me.Controls.Add(m_btnStart)
		Me.Controls.Add(m_cboValueType)
		Me.Controls.Add(m_stcReadValue)
		Me.Controls.Add(m_cboVoltageRange)
		Me.Controls.Add(Frame2)
		Me.Controls.Add(Frame1)
		Me.Controls.Add(m_stcValueType)
		Me.Controls.Add(Label3)
		Me.Controls.Add(Label2)
		Me.Controls.Add(Label1)
		Me.Frame2.Controls.Add(m_cboChannel)
		Me.Frame1.Controls.Add(m_cboModule)
		Me.Frame2.ResumeLayout(False)
		Me.Frame1.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class