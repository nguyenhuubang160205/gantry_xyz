<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class OutputWriteSingle
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
	Public WithEvents m_stcOutputVoltage As System.Windows.Forms.TextBox
    'Public WithEvents m_sliSettingVoltage As Axmscomctl.AxSlider
	Public WithEvents m_cboModule As System.Windows.Forms.ComboBox
	Public WithEvents Frame1 As System.Windows.Forms.GroupBox
	Public WithEvents m_cboChannel As System.Windows.Forms.ComboBox
	Public WithEvents Frame2 As System.Windows.Forms.GroupBox
	Public WithEvents m_cboVoltageRange As System.Windows.Forms.ComboBox
	Public WithEvents m_edtSettingVoltage As System.Windows.Forms.TextBox
	Public WithEvents m_btnSet As System.Windows.Forms.Button
	Public WithEvents m_timer As System.Windows.Forms.Timer
	Public WithEvents Label5 As System.Windows.Forms.Label
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.m_stcOutputVoltage = New System.Windows.Forms.TextBox
        Me.Frame1 = New System.Windows.Forms.GroupBox
        Me.m_cboModule = New System.Windows.Forms.ComboBox
        Me.Frame2 = New System.Windows.Forms.GroupBox
        Me.m_cboChannel = New System.Windows.Forms.ComboBox
        Me.m_cboVoltageRange = New System.Windows.Forms.ComboBox
        Me.m_edtSettingVoltage = New System.Windows.Forms.TextBox
        Me.m_btnSet = New System.Windows.Forms.Button
        Me.m_timer = New System.Windows.Forms.Timer(Me.components)
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.m_sliSettingVoltage = New System.Windows.Forms.TrackBar
        Me.Frame1.SuspendLayout()
        Me.Frame2.SuspendLayout()
        CType(Me.m_sliSettingVoltage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'm_stcOutputVoltage
        '
        Me.m_stcOutputVoltage.AcceptsReturn = True
        Me.m_stcOutputVoltage.BackColor = System.Drawing.SystemColors.Window
        Me.m_stcOutputVoltage.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.m_stcOutputVoltage.ForeColor = System.Drawing.SystemColors.WindowText
        Me.m_stcOutputVoltage.Location = New System.Drawing.Point(112, 142)
        Me.m_stcOutputVoltage.MaxLength = 0
        Me.m_stcOutputVoltage.Name = "m_stcOutputVoltage"
        Me.m_stcOutputVoltage.ReadOnly = True
        Me.m_stcOutputVoltage.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.m_stcOutputVoltage.Size = New System.Drawing.Size(193, 21)
        Me.m_stcOutputVoltage.TabIndex = 12
        Me.m_stcOutputVoltage.Text = "0.0000"
        Me.m_stcOutputVoltage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Frame1
        '
        Me.Frame1.BackColor = System.Drawing.SystemColors.Control
        Me.Frame1.Controls.Add(Me.m_cboModule)
        Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame1.Location = New System.Drawing.Point(8, 0)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(338, 44)
        Me.Frame1.TabIndex = 5
        Me.Frame1.TabStop = False
        Me.Frame1.Text = "[Board No¢ÂModule No¢ÂModule ID]"
        '
        'm_cboModule
        '
        Me.m_cboModule.BackColor = System.Drawing.SystemColors.Window
        Me.m_cboModule.Cursor = System.Windows.Forms.Cursors.Default
        Me.m_cboModule.ForeColor = System.Drawing.SystemColors.WindowText
        Me.m_cboModule.Location = New System.Drawing.Point(8, 16)
        Me.m_cboModule.Name = "m_cboModule"
        Me.m_cboModule.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.m_cboModule.Size = New System.Drawing.Size(321, 20)
        Me.m_cboModule.TabIndex = 6
        '
        'Frame2
        '
        Me.Frame2.BackColor = System.Drawing.SystemColors.Control
        Me.Frame2.Controls.Add(Me.m_cboChannel)
        Me.Frame2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame2.Location = New System.Drawing.Point(356, 0)
        Me.Frame2.Name = "Frame2"
        Me.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame2.Size = New System.Drawing.Size(113, 44)
        Me.Frame2.TabIndex = 3
        Me.Frame2.TabStop = False
        Me.Frame2.Text = "[Channel]"
        '
        'm_cboChannel
        '
        Me.m_cboChannel.BackColor = System.Drawing.SystemColors.Window
        Me.m_cboChannel.Cursor = System.Windows.Forms.Cursors.Default
        Me.m_cboChannel.ForeColor = System.Drawing.SystemColors.WindowText
        Me.m_cboChannel.Location = New System.Drawing.Point(8, 16)
        Me.m_cboChannel.Name = "m_cboChannel"
        Me.m_cboChannel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.m_cboChannel.Size = New System.Drawing.Size(97, 20)
        Me.m_cboChannel.TabIndex = 4
        '
        'm_cboVoltageRange
        '
        Me.m_cboVoltageRange.BackColor = System.Drawing.SystemColors.Window
        Me.m_cboVoltageRange.Cursor = System.Windows.Forms.Cursors.Default
        Me.m_cboVoltageRange.ForeColor = System.Drawing.SystemColors.WindowText
        Me.m_cboVoltageRange.Location = New System.Drawing.Point(112, 54)
        Me.m_cboVoltageRange.Name = "m_cboVoltageRange"
        Me.m_cboVoltageRange.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.m_cboVoltageRange.Size = New System.Drawing.Size(224, 20)
        Me.m_cboVoltageRange.TabIndex = 2
        '
        'm_edtSettingVoltage
        '
        Me.m_edtSettingVoltage.AcceptsReturn = True
        Me.m_edtSettingVoltage.BackColor = System.Drawing.SystemColors.Window
        Me.m_edtSettingVoltage.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.m_edtSettingVoltage.ForeColor = System.Drawing.SystemColors.WindowText
        Me.m_edtSettingVoltage.Location = New System.Drawing.Point(112, 97)
        Me.m_edtSettingVoltage.MaxLength = 0
        Me.m_edtSettingVoltage.Name = "m_edtSettingVoltage"
        Me.m_edtSettingVoltage.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.m_edtSettingVoltage.Size = New System.Drawing.Size(72, 21)
        Me.m_edtSettingVoltage.TabIndex = 1
        Me.m_edtSettingVoltage.Text = "0.0000"
        Me.m_edtSettingVoltage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'm_btnSet
        '
        Me.m_btnSet.BackColor = System.Drawing.SystemColors.Control
        Me.m_btnSet.Cursor = System.Windows.Forms.Cursors.Default
        Me.m_btnSet.ForeColor = System.Drawing.SystemColors.ControlText
        Me.m_btnSet.Location = New System.Drawing.Point(365, 54)
        Me.m_btnSet.Name = "m_btnSet"
        Me.m_btnSet.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.m_btnSet.Size = New System.Drawing.Size(94, 108)
        Me.m_btnSet.TabIndex = 0
        Me.m_btnSet.Text = "Set"
        Me.m_btnSet.UseVisualStyleBackColor = False
        '
        'm_timer
        '
        Me.m_timer.Enabled = True
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(313, 145)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(25, 17)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Volt"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(17, 146)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(97, 17)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Output Voltage :"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(17, 57)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(97, 17)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Voltage Range :"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(17, 101)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(97, 17)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Setting Voltage :"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(313, 100)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(25, 17)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Volt"
        '
        'm_sliSettingVoltage
        '
        Me.m_sliSettingVoltage.Location = New System.Drawing.Point(185, 96)
        Me.m_sliSettingVoltage.Margin = New System.Windows.Forms.Padding(0)
        Me.m_sliSettingVoltage.Name = "m_sliSettingVoltage"
        Me.m_sliSettingVoltage.Size = New System.Drawing.Size(128, 45)
        Me.m_sliSettingVoltage.TabIndex = 14
        '
        'OutputWriteSingle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(478, 186)
        Me.Controls.Add(Me.m_sliSettingVoltage)
        Me.Controls.Add(Me.m_stcOutputVoltage)
        Me.Controls.Add(Me.Frame1)
        Me.Controls.Add(Me.Frame2)
        Me.Controls.Add(Me.m_cboVoltageRange)
        Me.Controls.Add(Me.m_edtSettingVoltage)
        Me.Controls.Add(Me.m_btnSet)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Location = New System.Drawing.Point(8, 30)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "OutputWriteSingle"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "OutputWriteSingle"
        Me.Frame1.ResumeLayout(False)
        Me.Frame2.ResumeLayout(False)
        CType(Me.m_sliSettingVoltage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents m_sliSettingVoltage As System.Windows.Forms.TrackBar
#End Region
End Class