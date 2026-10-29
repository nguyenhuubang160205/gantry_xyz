<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class OutputWriteMulti
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
	Public WithEvents m_edtSetVoltCh03 As System.Windows.Forms.TextBox
	Public WithEvents m_stcOutVolt03 As System.Windows.Forms.TextBox
	Public WithEvents m_edtSetVoltCh02 As System.Windows.Forms.TextBox
	Public WithEvents m_stcOutVolt02 As System.Windows.Forms.TextBox
	Public WithEvents m_edtSetVoltCh01 As System.Windows.Forms.TextBox
	Public WithEvents m_stcOutVolt01 As System.Windows.Forms.TextBox
	Public WithEvents m_timer As System.Windows.Forms.Timer
	Public WithEvents m_btnSet As System.Windows.Forms.Button
	Public WithEvents m_edtSetVoltCh00 As System.Windows.Forms.TextBox
	Public WithEvents m_cboVoltageRange As System.Windows.Forms.ComboBox
	Public WithEvents m_cboModule As System.Windows.Forms.ComboBox
	Public WithEvents Frame1 As System.Windows.Forms.GroupBox
	Public WithEvents m_stcOutVolt00 As System.Windows.Forms.TextBox
    'Public WithEvents m_sliSetVoltCh00 As Axmscomctl.AxSlider
    'Public WithEvents m_sliSetVoltCh01 As Axmscomctl.AxSlider
    'Public WithEvents m_sliSetVoltCh02 As Axmscomctl.AxSlider
    'Public WithEvents m_sliSetVoltCh03 As Axmscomctl.AxSlider
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents Label4 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.m_edtSetVoltCh03 = New System.Windows.Forms.TextBox
        Me.m_stcOutVolt03 = New System.Windows.Forms.TextBox
        Me.m_edtSetVoltCh02 = New System.Windows.Forms.TextBox
        Me.m_stcOutVolt02 = New System.Windows.Forms.TextBox
        Me.m_edtSetVoltCh01 = New System.Windows.Forms.TextBox
        Me.m_stcOutVolt01 = New System.Windows.Forms.TextBox
        Me.m_timer = New System.Windows.Forms.Timer(Me.components)
        Me.m_btnSet = New System.Windows.Forms.Button
        Me.m_edtSetVoltCh00 = New System.Windows.Forms.TextBox
        Me.m_cboVoltageRange = New System.Windows.Forms.ComboBox
        Me.Frame1 = New System.Windows.Forms.GroupBox
        Me.m_cboModule = New System.Windows.Forms.ComboBox
        Me.m_stcOutVolt00 = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.m_sliSetVoltCh00 = New System.Windows.Forms.TrackBar
        Me.m_sliSetVoltCh01 = New System.Windows.Forms.TrackBar
        Me.m_sliSetVoltCh02 = New System.Windows.Forms.TrackBar
        Me.m_sliSetVoltCh03 = New System.Windows.Forms.TrackBar
        Me.Frame1.SuspendLayout()
        CType(Me.m_sliSetVoltCh00, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.m_sliSetVoltCh01, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.m_sliSetVoltCh02, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.m_sliSetVoltCh03, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'm_edtSetVoltCh03
        '
        Me.m_edtSetVoltCh03.AcceptsReturn = True
        Me.m_edtSetVoltCh03.BackColor = System.Drawing.SystemColors.Window
        Me.m_edtSetVoltCh03.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.m_edtSetVoltCh03.ForeColor = System.Drawing.SystemColors.WindowText
        Me.m_edtSetVoltCh03.Location = New System.Drawing.Point(375, 86)
        Me.m_edtSetVoltCh03.MaxLength = 0
        Me.m_edtSetVoltCh03.Name = "m_edtSetVoltCh03"
        Me.m_edtSetVoltCh03.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.m_edtSetVoltCh03.Size = New System.Drawing.Size(82, 20)
        Me.m_edtSetVoltCh03.TabIndex = 18
        Me.m_edtSetVoltCh03.Text = "4.0000"
        Me.m_edtSetVoltCh03.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'm_stcOutVolt03
        '
        Me.m_stcOutVolt03.AcceptsReturn = True
        Me.m_stcOutVolt03.BackColor = System.Drawing.SystemColors.Window
        Me.m_stcOutVolt03.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.m_stcOutVolt03.ForeColor = System.Drawing.SystemColors.WindowText
        Me.m_stcOutVolt03.Location = New System.Drawing.Point(375, 162)
        Me.m_stcOutVolt03.MaxLength = 0
        Me.m_stcOutVolt03.Name = "m_stcOutVolt03"
        Me.m_stcOutVolt03.ReadOnly = True
        Me.m_stcOutVolt03.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.m_stcOutVolt03.Size = New System.Drawing.Size(82, 20)
        Me.m_stcOutVolt03.TabIndex = 16
        Me.m_stcOutVolt03.Text = "0.0000"
        Me.m_stcOutVolt03.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'm_edtSetVoltCh02
        '
        Me.m_edtSetVoltCh02.AcceptsReturn = True
        Me.m_edtSetVoltCh02.BackColor = System.Drawing.SystemColors.Window
        Me.m_edtSetVoltCh02.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.m_edtSetVoltCh02.ForeColor = System.Drawing.SystemColors.WindowText
        Me.m_edtSetVoltCh02.Location = New System.Drawing.Point(287, 86)
        Me.m_edtSetVoltCh02.MaxLength = 0
        Me.m_edtSetVoltCh02.Name = "m_edtSetVoltCh02"
        Me.m_edtSetVoltCh02.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.m_edtSetVoltCh02.Size = New System.Drawing.Size(82, 20)
        Me.m_edtSetVoltCh02.TabIndex = 15
        Me.m_edtSetVoltCh02.Text = "3.0000"
        Me.m_edtSetVoltCh02.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'm_stcOutVolt02
        '
        Me.m_stcOutVolt02.AcceptsReturn = True
        Me.m_stcOutVolt02.BackColor = System.Drawing.SystemColors.Window
        Me.m_stcOutVolt02.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.m_stcOutVolt02.ForeColor = System.Drawing.SystemColors.WindowText
        Me.m_stcOutVolt02.Location = New System.Drawing.Point(287, 162)
        Me.m_stcOutVolt02.MaxLength = 0
        Me.m_stcOutVolt02.Name = "m_stcOutVolt02"
        Me.m_stcOutVolt02.ReadOnly = True
        Me.m_stcOutVolt02.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.m_stcOutVolt02.Size = New System.Drawing.Size(82, 20)
        Me.m_stcOutVolt02.TabIndex = 13
        Me.m_stcOutVolt02.Text = "0.0000"
        Me.m_stcOutVolt02.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'm_edtSetVoltCh01
        '
        Me.m_edtSetVoltCh01.AcceptsReturn = True
        Me.m_edtSetVoltCh01.BackColor = System.Drawing.SystemColors.Window
        Me.m_edtSetVoltCh01.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.m_edtSetVoltCh01.ForeColor = System.Drawing.SystemColors.WindowText
        Me.m_edtSetVoltCh01.Location = New System.Drawing.Point(200, 86)
        Me.m_edtSetVoltCh01.MaxLength = 0
        Me.m_edtSetVoltCh01.Name = "m_edtSetVoltCh01"
        Me.m_edtSetVoltCh01.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.m_edtSetVoltCh01.Size = New System.Drawing.Size(82, 20)
        Me.m_edtSetVoltCh01.TabIndex = 12
        Me.m_edtSetVoltCh01.Text = "2.0000"
        Me.m_edtSetVoltCh01.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'm_stcOutVolt01
        '
        Me.m_stcOutVolt01.AcceptsReturn = True
        Me.m_stcOutVolt01.BackColor = System.Drawing.SystemColors.Window
        Me.m_stcOutVolt01.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.m_stcOutVolt01.ForeColor = System.Drawing.SystemColors.WindowText
        Me.m_stcOutVolt01.Location = New System.Drawing.Point(200, 162)
        Me.m_stcOutVolt01.MaxLength = 0
        Me.m_stcOutVolt01.Name = "m_stcOutVolt01"
        Me.m_stcOutVolt01.ReadOnly = True
        Me.m_stcOutVolt01.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.m_stcOutVolt01.Size = New System.Drawing.Size(82, 20)
        Me.m_stcOutVolt01.TabIndex = 10
        Me.m_stcOutVolt01.Text = "0.0000"
        Me.m_stcOutVolt01.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'm_timer
        '
        Me.m_timer.Enabled = True
        '
        'm_btnSet
        '
        Me.m_btnSet.BackColor = System.Drawing.SystemColors.Control
        Me.m_btnSet.Cursor = System.Windows.Forms.Cursors.Default
        Me.m_btnSet.ForeColor = System.Drawing.SystemColors.ControlText
        Me.m_btnSet.Location = New System.Drawing.Point(375, 54)
        Me.m_btnSet.Name = "m_btnSet"
        Me.m_btnSet.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.m_btnSet.Size = New System.Drawing.Size(82, 20)
        Me.m_btnSet.TabIndex = 6
        Me.m_btnSet.Text = "Voltage Set"
        Me.m_btnSet.UseVisualStyleBackColor = False
        '
        'm_edtSetVoltCh00
        '
        Me.m_edtSetVoltCh00.AcceptsReturn = True
        Me.m_edtSetVoltCh00.BackColor = System.Drawing.SystemColors.Window
        Me.m_edtSetVoltCh00.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.m_edtSetVoltCh00.ForeColor = System.Drawing.SystemColors.WindowText
        Me.m_edtSetVoltCh00.Location = New System.Drawing.Point(114, 86)
        Me.m_edtSetVoltCh00.MaxLength = 0
        Me.m_edtSetVoltCh00.Name = "m_edtSetVoltCh00"
        Me.m_edtSetVoltCh00.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.m_edtSetVoltCh00.Size = New System.Drawing.Size(82, 20)
        Me.m_edtSetVoltCh00.TabIndex = 5
        Me.m_edtSetVoltCh00.Text = "1.0000"
        Me.m_edtSetVoltCh00.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'm_cboVoltageRange
        '
        Me.m_cboVoltageRange.BackColor = System.Drawing.SystemColors.Window
        Me.m_cboVoltageRange.Cursor = System.Windows.Forms.Cursors.Default
        Me.m_cboVoltageRange.ForeColor = System.Drawing.SystemColors.WindowText
        Me.m_cboVoltageRange.Location = New System.Drawing.Point(114, 54)
        Me.m_cboVoltageRange.Name = "m_cboVoltageRange"
        Me.m_cboVoltageRange.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.m_cboVoltageRange.Size = New System.Drawing.Size(258, 20)
        Me.m_cboVoltageRange.TabIndex = 4
        '
        'Frame1
        '
        Me.Frame1.BackColor = System.Drawing.SystemColors.Control
        Me.Frame1.Controls.Add(Me.m_cboModule)
        Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame1.Location = New System.Drawing.Point(8, 0)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(464, 44)
        Me.Frame1.TabIndex = 2
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
        Me.m_cboModule.Size = New System.Drawing.Size(444, 20)
        Me.m_cboModule.TabIndex = 3
        '
        'm_stcOutVolt00
        '
        Me.m_stcOutVolt00.AcceptsReturn = True
        Me.m_stcOutVolt00.BackColor = System.Drawing.SystemColors.Window
        Me.m_stcOutVolt00.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.m_stcOutVolt00.ForeColor = System.Drawing.SystemColors.WindowText
        Me.m_stcOutVolt00.Location = New System.Drawing.Point(114, 162)
        Me.m_stcOutVolt00.MaxLength = 0
        Me.m_stcOutVolt00.Name = "m_stcOutVolt00"
        Me.m_stcOutVolt00.ReadOnly = True
        Me.m_stcOutVolt00.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.m_stcOutVolt00.Size = New System.Drawing.Size(82, 20)
        Me.m_stcOutVolt00.TabIndex = 0
        Me.m_stcOutVolt00.Text = "0.0000"
        Me.m_stcOutVolt00.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(17, 90)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(97, 17)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Setting Voltage :"
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
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Voltage Range :"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(17, 166)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(97, 17)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Output Voltage :"
        '
        'm_sliSetVoltCh00
        '
        Me.m_sliSetVoltCh00.Location = New System.Drawing.Point(114, 117)
        Me.m_sliSetVoltCh00.Name = "m_sliSetVoltCh00"
        Me.m_sliSetVoltCh00.Size = New System.Drawing.Size(82, 45)
        Me.m_sliSetVoltCh00.TabIndex = 19
        '
        'm_sliSetVoltCh01
        '
        Me.m_sliSetVoltCh01.Location = New System.Drawing.Point(198, 117)
        Me.m_sliSetVoltCh01.Name = "m_sliSetVoltCh01"
        Me.m_sliSetVoltCh01.Size = New System.Drawing.Size(82, 45)
        Me.m_sliSetVoltCh01.TabIndex = 20
        '
        'm_sliSetVoltCh02
        '
        Me.m_sliSetVoltCh02.Location = New System.Drawing.Point(286, 117)
        Me.m_sliSetVoltCh02.Name = "m_sliSetVoltCh02"
        Me.m_sliSetVoltCh02.Size = New System.Drawing.Size(82, 45)
        Me.m_sliSetVoltCh02.TabIndex = 21
        '
        'm_sliSetVoltCh03
        '
        Me.m_sliSetVoltCh03.Location = New System.Drawing.Point(374, 117)
        Me.m_sliSetVoltCh03.Name = "m_sliSetVoltCh03"
        Me.m_sliSetVoltCh03.Size = New System.Drawing.Size(82, 45)
        Me.m_sliSetVoltCh03.TabIndex = 22
        '
        'OutputWriteMulti
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(478, 201)
        Me.Controls.Add(Me.m_sliSetVoltCh03)
        Me.Controls.Add(Me.m_sliSetVoltCh02)
        Me.Controls.Add(Me.m_sliSetVoltCh01)
        Me.Controls.Add(Me.m_sliSetVoltCh00)
        Me.Controls.Add(Me.m_edtSetVoltCh03)
        Me.Controls.Add(Me.m_stcOutVolt03)
        Me.Controls.Add(Me.m_edtSetVoltCh02)
        Me.Controls.Add(Me.m_stcOutVolt02)
        Me.Controls.Add(Me.m_edtSetVoltCh01)
        Me.Controls.Add(Me.m_stcOutVolt01)
        Me.Controls.Add(Me.m_btnSet)
        Me.Controls.Add(Me.m_edtSetVoltCh00)
        Me.Controls.Add(Me.m_cboVoltageRange)
        Me.Controls.Add(Me.Frame1)
        Me.Controls.Add(Me.m_stcOutVolt00)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label4)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Location = New System.Drawing.Point(8, 30)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "OutputWriteMulti"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "OutputWriteMulti"
        Me.Frame1.ResumeLayout(False)
        CType(Me.m_sliSetVoltCh00, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.m_sliSetVoltCh01, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.m_sliSetVoltCh02, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.m_sliSetVoltCh03, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents m_sliSetVoltCh00 As System.Windows.Forms.TrackBar
    Friend WithEvents m_sliSetVoltCh01 As System.Windows.Forms.TrackBar
    Friend WithEvents m_sliSetVoltCh02 As System.Windows.Forms.TrackBar
    Friend WithEvents m_sliSetVoltCh03 As System.Windows.Forms.TrackBar
#End Region 
End Class