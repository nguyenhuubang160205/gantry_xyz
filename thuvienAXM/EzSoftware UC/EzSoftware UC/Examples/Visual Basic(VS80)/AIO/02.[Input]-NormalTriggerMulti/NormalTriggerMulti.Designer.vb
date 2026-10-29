<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class NormalTriggerMulti
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
    Public WithEvents m_stcCh03 As System.Windows.Forms.TextBox
    Public WithEvents m_stcCh02 As System.Windows.Forms.TextBox
    Public WithEvents m_stcCh01 As System.Windows.Forms.TextBox
    Public WithEvents m_cboModule As System.Windows.Forms.ComboBox
    Public WithEvents Frame1 As System.Windows.Forms.GroupBox
    Public WithEvents m_cboVoltageRange As System.Windows.Forms.ComboBox
    Public WithEvents m_stcCh00 As System.Windows.Forms.TextBox
    Public WithEvents m_cboValueType As System.Windows.Forms.ComboBox
    Public WithEvents m_btnStart As System.Windows.Forms.Button
    Public WithEvents m_btnStop As System.Windows.Forms.Button
    Public WithEvents m_timer As System.Windows.Forms.Timer
    Public WithEvents Label5 As System.Windows.Forms.Label
    Public WithEvents CH02 As System.Windows.Forms.Label
    Public WithEvents Label4 As System.Windows.Forms.Label
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents Label3 As System.Windows.Forms.Label
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.m_stcCh03 = New System.Windows.Forms.TextBox()
        Me.m_stcCh02 = New System.Windows.Forms.TextBox()
        Me.m_stcCh01 = New System.Windows.Forms.TextBox()
        Me.Frame1 = New System.Windows.Forms.GroupBox()
        Me.m_cboModule = New System.Windows.Forms.ComboBox()
        Me.m_cboVoltageRange = New System.Windows.Forms.ComboBox()
        Me.m_stcCh00 = New System.Windows.Forms.TextBox()
        Me.m_cboValueType = New System.Windows.Forms.ComboBox()
        Me.m_btnStart = New System.Windows.Forms.Button()
        Me.m_btnStop = New System.Windows.Forms.Button()
        Me.m_timer = New System.Windows.Forms.Timer(Me.components)
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CH02 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Frame1.SuspendLayout()
        Me.SuspendLayout()
        '
        'm_stcCh03
        '
        Me.m_stcCh03.AcceptsReturn = True
        Me.m_stcCh03.BackColor = System.Drawing.SystemColors.Window
        Me.m_stcCh03.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.m_stcCh03.ForeColor = System.Drawing.SystemColors.WindowText
        Me.m_stcCh03.Location = New System.Drawing.Point(228, 100)
        Me.m_stcCh03.MaxLength = 0
        Me.m_stcCh03.Name = "m_stcCh03"
        Me.m_stcCh03.ReadOnly = True
        Me.m_stcCh03.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.m_stcCh03.Size = New System.Drawing.Size(68, 21)
        Me.m_stcCh03.TabIndex = 14
        Me.m_stcCh03.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'm_stcCh02
        '
        Me.m_stcCh02.AcceptsReturn = True
        Me.m_stcCh02.BackColor = System.Drawing.SystemColors.Window
        Me.m_stcCh02.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.m_stcCh02.ForeColor = System.Drawing.SystemColors.WindowText
        Me.m_stcCh02.Location = New System.Drawing.Point(157, 100)
        Me.m_stcCh02.MaxLength = 0
        Me.m_stcCh02.Name = "m_stcCh02"
        Me.m_stcCh02.ReadOnly = True
        Me.m_stcCh02.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.m_stcCh02.Size = New System.Drawing.Size(68, 21)
        Me.m_stcCh02.TabIndex = 13
        Me.m_stcCh02.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'm_stcCh01
        '
        Me.m_stcCh01.AcceptsReturn = True
        Me.m_stcCh01.BackColor = System.Drawing.SystemColors.Window
        Me.m_stcCh01.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.m_stcCh01.ForeColor = System.Drawing.SystemColors.WindowText
        Me.m_stcCh01.Location = New System.Drawing.Point(87, 100)
        Me.m_stcCh01.MaxLength = 0
        Me.m_stcCh01.Name = "m_stcCh01"
        Me.m_stcCh01.ReadOnly = True
        Me.m_stcCh01.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.m_stcCh01.Size = New System.Drawing.Size(68, 21)
        Me.m_stcCh01.TabIndex = 11
        Me.m_stcCh01.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Frame1
        '
        Me.Frame1.BackColor = System.Drawing.SystemColors.Control
        Me.Frame1.Controls.Add(Me.m_cboModule)
        Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame1.Location = New System.Drawing.Point(8, 0)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(461, 44)
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
        Me.m_cboModule.Size = New System.Drawing.Size(445, 20)
        Me.m_cboModule.TabIndex = 6
        '
        'm_cboVoltageRange
        '
        Me.m_cboVoltageRange.BackColor = System.Drawing.SystemColors.Window
        Me.m_cboVoltageRange.Cursor = System.Windows.Forms.Cursors.Default
        Me.m_cboVoltageRange.ForeColor = System.Drawing.SystemColors.WindowText
        Me.m_cboVoltageRange.Location = New System.Drawing.Point(88, 54)
        Me.m_cboVoltageRange.Name = "m_cboVoltageRange"
        Me.m_cboVoltageRange.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.m_cboVoltageRange.Size = New System.Drawing.Size(138, 20)
        Me.m_cboVoltageRange.TabIndex = 4
        '
        'm_stcCh00
        '
        Me.m_stcCh00.AcceptsReturn = True
        Me.m_stcCh00.BackColor = System.Drawing.SystemColors.Window
        Me.m_stcCh00.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.m_stcCh00.ForeColor = System.Drawing.SystemColors.WindowText
        Me.m_stcCh00.Location = New System.Drawing.Point(16, 100)
        Me.m_stcCh00.MaxLength = 0
        Me.m_stcCh00.Name = "m_stcCh00"
        Me.m_stcCh00.ReadOnly = True
        Me.m_stcCh00.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.m_stcCh00.Size = New System.Drawing.Size(68, 21)
        Me.m_stcCh00.TabIndex = 3
        Me.m_stcCh00.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'm_cboValueType
        '
        Me.m_cboValueType.BackColor = System.Drawing.SystemColors.Window
        Me.m_cboValueType.Cursor = System.Windows.Forms.Cursors.Default
        Me.m_cboValueType.ForeColor = System.Drawing.SystemColors.WindowText
        Me.m_cboValueType.Items.AddRange(New Object() {"00: Volt", "01: Digit"})
        Me.m_cboValueType.Location = New System.Drawing.Point(309, 54)
        Me.m_cboValueType.Name = "m_cboValueType"
        Me.m_cboValueType.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.m_cboValueType.Size = New System.Drawing.Size(152, 20)
        Me.m_cboValueType.TabIndex = 2
        '
        'm_btnStart
        '
        Me.m_btnStart.BackColor = System.Drawing.SystemColors.Control
        Me.m_btnStart.Cursor = System.Windows.Forms.Cursors.Default
        Me.m_btnStart.ForeColor = System.Drawing.SystemColors.ControlText
        Me.m_btnStart.Location = New System.Drawing.Point(309, 82)
        Me.m_btnStart.Name = "m_btnStart"
        Me.m_btnStart.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.m_btnStart.Size = New System.Drawing.Size(70, 37)
        Me.m_btnStart.TabIndex = 1
        Me.m_btnStart.Text = "Start"
        Me.m_btnStart.UseVisualStyleBackColor = False
        '
        'm_btnStop
        '
        Me.m_btnStop.BackColor = System.Drawing.SystemColors.Control
        Me.m_btnStop.Cursor = System.Windows.Forms.Cursors.Default
        Me.m_btnStop.ForeColor = System.Drawing.SystemColors.ControlText
        Me.m_btnStop.Location = New System.Drawing.Point(388, 82)
        Me.m_btnStop.Name = "m_btnStop"
        Me.m_btnStop.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.m_btnStop.Size = New System.Drawing.Size(70, 37)
        Me.m_btnStop.TabIndex = 0
        Me.m_btnStop.Text = "Stop"
        Me.m_btnStop.UseVisualStyleBackColor = False
        '
        'm_timer
        '
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(248, 84)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(33, 17)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "CH03"
        '
        'CH02
        '
        Me.CH02.BackColor = System.Drawing.SystemColors.Control
        Me.CH02.Cursor = System.Windows.Forms.Cursors.Default
        Me.CH02.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CH02.Location = New System.Drawing.Point(177, 84)
        Me.CH02.Name = "CH02"
        Me.CH02.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CH02.Size = New System.Drawing.Size(33, 17)
        Me.CH02.TabIndex = 12
        Me.CH02.Text = "CH02"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(108, 84)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(33, 17)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "CH01"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(17, 57)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(73, 17)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Volt.Range:"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(36, 84)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(33, 17)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "CH00"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(233, 57)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(81, 17)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Value Type :"
        '
        'NormalTriggerMulti
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(478, 130)
        Me.Controls.Add(Me.m_stcCh03)
        Me.Controls.Add(Me.m_stcCh02)
        Me.Controls.Add(Me.m_stcCh01)
        Me.Controls.Add(Me.Frame1)
        Me.Controls.Add(Me.m_cboVoltageRange)
        Me.Controls.Add(Me.m_stcCh00)
        Me.Controls.Add(Me.m_cboValueType)
        Me.Controls.Add(Me.m_btnStart)
        Me.Controls.Add(Me.m_btnStop)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.CH02)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Location = New System.Drawing.Point(8, 30)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "NormalTriggerMulti"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "s"
        Me.Frame1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region
End Class