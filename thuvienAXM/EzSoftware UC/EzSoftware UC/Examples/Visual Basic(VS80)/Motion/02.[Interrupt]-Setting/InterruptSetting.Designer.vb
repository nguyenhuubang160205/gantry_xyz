<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InterruptSetting
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InterruptSetting))
        Me.grpBank1 = New System.Windows.Forms.GroupBox()
        Me.btnSetBank1 = New System.Windows.Forms.Button()
        Me.chkBank1Bit31 = New System.Windows.Forms.CheckBox()
        Me.chkBank1Bit02 = New System.Windows.Forms.CheckBox()
        Me.chkBank1Bit01 = New System.Windows.Forms.CheckBox()
        Me.chkBank1Bit00 = New System.Windows.Forms.CheckBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cboSelAxis = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.grpBank2 = New System.Windows.Forms.GroupBox()
        Me.chkBank2Bit22 = New System.Windows.Forms.CheckBox()
        Me.chkBank2Bit21 = New System.Windows.Forms.CheckBox()
        Me.btnSetBank2 = New System.Windows.Forms.Button()
        Me.chkBank2Bit20 = New System.Windows.Forms.CheckBox()
        Me.chkBank2Bit16 = New System.Windows.Forms.CheckBox()
        Me.chkBank2Bit15 = New System.Windows.Forms.CheckBox()
        Me.chkBank2Bit14 = New System.Windows.Forms.CheckBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.rdoEvent = New System.Windows.Forms.RadioButton()
        Me.rdoCallback = New System.Windows.Forms.RadioButton()
        Me.rdoMessage = New System.Windows.Forms.RadioButton()
        Me.chkIntEnable = New System.Windows.Forms.CheckBox()
        Me.lstIntLog = New System.Windows.Forms.ListBox()
        Me.AxtMsg = New AxAXTMESSENGERLib.AxAxtMessenger()
        Me.m_timer = New System.Windows.Forms.Timer(Me.components)
        Me.grpBank1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.grpBank2.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.AxtMsg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpBank1
        '
        Me.grpBank1.Controls.Add(Me.btnSetBank1)
        Me.grpBank1.Controls.Add(Me.chkBank1Bit31)
        Me.grpBank1.Controls.Add(Me.chkBank1Bit02)
        Me.grpBank1.Controls.Add(Me.chkBank1Bit01)
        Me.grpBank1.Controls.Add(Me.chkBank1Bit00)
        Me.grpBank1.Controls.Add(Me.PictureBox1)
        Me.grpBank1.Location = New System.Drawing.Point(12, 49)
        Me.grpBank1.Name = "grpBank1"
        Me.grpBank1.Size = New System.Drawing.Size(460, 122)
        Me.grpBank1.TabIndex = 11
        Me.grpBank1.TabStop = False
        Me.grpBank1.Text = "< Interrupt Event Bank 1 [0x00000000] >"
        '
        'btnSetBank1
        '
        Me.btnSetBank1.Location = New System.Drawing.Point(332, 96)
        Me.btnSetBank1.Name = "btnSetBank1"
        Me.btnSetBank1.Size = New System.Drawing.Size(128, 26)
        Me.btnSetBank1.TabIndex = 15
        Me.btnSetBank1.Text = "Set Bank 1"
        Me.btnSetBank1.UseVisualStyleBackColor = True
        '
        'chkBank1Bit31
        '
        Me.chkBank1Bit31.AutoSize = True
        Me.chkBank1Bit31.Location = New System.Drawing.Point(11, 96)
        Me.chkBank1Bit31.Name = "chkBank1Bit31"
        Me.chkBank1Bit31.Size = New System.Drawing.Size(303, 16)
        Me.chkBank1Bit31.TabIndex = 14
        Me.chkBank1Bit31.Text = "[Bit 31] Interrupt occurrence command execution"
        Me.chkBank1Bit31.UseVisualStyleBackColor = True
        '
        'chkBank1Bit02
        '
        Me.chkBank1Bit02.AutoSize = True
        Me.chkBank1Bit02.Location = New System.Drawing.Point(11, 65)
        Me.chkBank1Bit02.Name = "chkBank1Bit02"
        Me.chkBank1Bit02.Size = New System.Drawing.Size(174, 16)
        Me.chkBank1Bit02.TabIndex = 13
        Me.chkBank1Bit02.Text = "[Bit 02] When drive started"
        Me.chkBank1Bit02.UseVisualStyleBackColor = True
        '
        'chkBank1Bit01
        '
        Me.chkBank1Bit01.AutoSize = True
        Me.chkBank1Bit01.Location = New System.Drawing.Point(11, 43)
        Me.chkBank1Bit01.Name = "chkBank1Bit01"
        Me.chkBank1Bit01.Size = New System.Drawing.Size(184, 16)
        Me.chkBank1Bit01.TabIndex = 12
        Me.chkBank1Bit01.Text = "[Bit 01] When drive is exited"
        Me.chkBank1Bit01.UseVisualStyleBackColor = True
        '
        'chkBank1Bit00
        '
        Me.chkBank1Bit00.AutoSize = True
        Me.chkBank1Bit00.Location = New System.Drawing.Point(11, 21)
        Me.chkBank1Bit00.Name = "chkBank1Bit00"
        Me.chkBank1Bit00.Size = New System.Drawing.Size(347, 16)
        Me.chkBank1Bit00.TabIndex = 11
        Me.chkBank1Bit00.Text = "[Bit 00] When drive set interrupt occurrence use is exited"
        Me.chkBank1Bit00.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Location = New System.Drawing.Point(29, 87)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(421, 3)
        Me.PictureBox1.TabIndex = 10
        Me.PictureBox1.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboSelAxis)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 10)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(460, 30)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        '
        'cboSelAxis
        '
        Me.cboSelAxis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSelAxis.FormattingEnabled = True
        Me.cboSelAxis.Location = New System.Drawing.Point(110, 8)
        Me.cboSelAxis.Name = "cboSelAxis"
        Me.cboSelAxis.Size = New System.Drawing.Size(340, 20)
        Me.cboSelAxis.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 12)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Select Axis No : "
        '
        'grpBank2
        '
        Me.grpBank2.Controls.Add(Me.chkBank2Bit22)
        Me.grpBank2.Controls.Add(Me.chkBank2Bit21)
        Me.grpBank2.Controls.Add(Me.btnSetBank2)
        Me.grpBank2.Controls.Add(Me.chkBank2Bit20)
        Me.grpBank2.Controls.Add(Me.chkBank2Bit16)
        Me.grpBank2.Controls.Add(Me.chkBank2Bit15)
        Me.grpBank2.Controls.Add(Me.chkBank2Bit14)
        Me.grpBank2.Controls.Add(Me.PictureBox2)
        Me.grpBank2.Location = New System.Drawing.Point(12, 182)
        Me.grpBank2.Name = "grpBank2"
        Me.grpBank2.Size = New System.Drawing.Size(460, 173)
        Me.grpBank2.TabIndex = 12
        Me.grpBank2.TabStop = False
        Me.grpBank2.Text = "< Interrupt Event Bank 2 [0x00000000] >"
        '
        'chkBank2Bit22
        '
        Me.chkBank2Bit22.AutoSize = True
        Me.chkBank2Bit22.Location = New System.Drawing.Point(11, 140)
        Me.chkBank2Bit22.Name = "chkBank2Bit22"
        Me.chkBank2Bit22.Size = New System.Drawing.Size(301, 16)
        Me.chkBank2Bit22.TabIndex = 17
        Me.chkBank2Bit22.Text = "[Bit 22] UInput 2 terminal signal is changed to '1'"
        Me.chkBank2Bit22.UseVisualStyleBackColor = True
        '
        'chkBank2Bit21
        '
        Me.chkBank2Bit21.AutoSize = True
        Me.chkBank2Bit21.Location = New System.Drawing.Point(11, 118)
        Me.chkBank2Bit21.Name = "chkBank2Bit21"
        Me.chkBank2Bit21.Size = New System.Drawing.Size(404, 16)
        Me.chkBank2Bit21.TabIndex = 16
        Me.chkBank2Bit21.Text = "[Bit 21] UInput 1 terminal signal is changed to '1' (Z-Phase Signal)"
        Me.chkBank2Bit21.UseVisualStyleBackColor = True
        '
        'btnSetBank2
        '
        Me.btnSetBank2.Location = New System.Drawing.Point(332, 147)
        Me.btnSetBank2.Name = "btnSetBank2"
        Me.btnSetBank2.Size = New System.Drawing.Size(128, 26)
        Me.btnSetBank2.TabIndex = 15
        Me.btnSetBank2.Text = "Set Bank 2"
        Me.btnSetBank2.UseVisualStyleBackColor = True
        '
        'chkBank2Bit20
        '
        Me.chkBank2Bit20.AutoSize = True
        Me.chkBank2Bit20.Location = New System.Drawing.Point(11, 96)
        Me.chkBank2Bit20.Name = "chkBank2Bit20"
        Me.chkBank2Bit20.Size = New System.Drawing.Size(387, 16)
        Me.chkBank2Bit20.TabIndex = 14
        Me.chkBank2Bit20.Text = "[Bit 20] UInput 0 terminal signal is changed to '1' (Home Signal)"
        Me.chkBank2Bit20.UseVisualStyleBackColor = True
        '
        'chkBank2Bit16
        '
        Me.chkBank2Bit16.AutoSize = True
        Me.chkBank2Bit16.Location = New System.Drawing.Point(11, 65)
        Me.chkBank2Bit16.Name = "chkBank2Bit16"
        Me.chkBank2Bit16.Size = New System.Drawing.Size(293, 16)
        Me.chkBank2Bit16.TabIndex = 13
        Me.chkBank2Bit16.Text = "[Bit 16] UOut 2 terminal signal is changed to '1'"
        Me.chkBank2Bit16.UseVisualStyleBackColor = True
        '
        'chkBank2Bit15
        '
        Me.chkBank2Bit15.AutoSize = True
        Me.chkBank2Bit15.Location = New System.Drawing.Point(11, 43)
        Me.chkBank2Bit15.Name = "chkBank2Bit15"
        Me.chkBank2Bit15.Size = New System.Drawing.Size(374, 16)
        Me.chkBank2Bit15.TabIndex = 12
        Me.chkBank2Bit15.Text = "[Bit 15] UOut 1 terminal signal is changed to '1' (Alarm Clear)"
        Me.chkBank2Bit15.UseVisualStyleBackColor = True
        '
        'chkBank2Bit14
        '
        Me.chkBank2Bit14.AutoSize = True
        Me.chkBank2Bit14.Location = New System.Drawing.Point(11, 21)
        Me.chkBank2Bit14.Name = "chkBank2Bit14"
        Me.chkBank2Bit14.Size = New System.Drawing.Size(363, 16)
        Me.chkBank2Bit14.TabIndex = 11
        Me.chkBank2Bit14.Text = "[Bit 14] UOut 0 terminal signal is changed to '1' (Servo On) "
        Me.chkBank2Bit14.UseVisualStyleBackColor = True
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.PictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox2.Location = New System.Drawing.Point(29, 87)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(421, 3)
        Me.PictureBox2.TabIndex = 10
        Me.PictureBox2.TabStop = False
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.rdoEvent)
        Me.GroupBox4.Controls.Add(Me.rdoCallback)
        Me.GroupBox4.Controls.Add(Me.rdoMessage)
        Me.GroupBox4.Location = New System.Drawing.Point(12, 367)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(314, 45)
        Me.GroupBox4.TabIndex = 13
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "< Interrupt Method >"
        '
        'rdoEvent
        '
        Me.rdoEvent.AutoSize = True
        Me.rdoEvent.Location = New System.Drawing.Point(248, 20)
        Me.rdoEvent.Name = "rdoEvent"
        Me.rdoEvent.Size = New System.Drawing.Size(54, 16)
        Me.rdoEvent.TabIndex = 2
        Me.rdoEvent.TabStop = True
        Me.rdoEvent.Text = "Event"
        Me.rdoEvent.UseVisualStyleBackColor = True
        '
        'rdoCallback
        '
        Me.rdoCallback.AutoSize = True
        Me.rdoCallback.Location = New System.Drawing.Point(132, 20)
        Me.rdoCallback.Name = "rdoCallback"
        Me.rdoCallback.Size = New System.Drawing.Size(72, 16)
        Me.rdoCallback.TabIndex = 1
        Me.rdoCallback.TabStop = True
        Me.rdoCallback.Text = "Callback"
        Me.rdoCallback.UseVisualStyleBackColor = True
        '
        'rdoMessage
        '
        Me.rdoMessage.AutoSize = True
        Me.rdoMessage.Location = New System.Drawing.Point(11, 20)
        Me.rdoMessage.Name = "rdoMessage"
        Me.rdoMessage.Size = New System.Drawing.Size(76, 16)
        Me.rdoMessage.TabIndex = 0
        Me.rdoMessage.TabStop = True
        Me.rdoMessage.Text = "Message"
        Me.rdoMessage.UseVisualStyleBackColor = True
        '
        'chkIntEnable
        '
        Me.chkIntEnable.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkIntEnable.Location = New System.Drawing.Point(344, 378)
        Me.chkIntEnable.Name = "chkIntEnable"
        Me.chkIntEnable.Size = New System.Drawing.Size(128, 30)
        Me.chkIntEnable.TabIndex = 14
        Me.chkIntEnable.Text = "Interrupt Enable"
        Me.chkIntEnable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkIntEnable.UseVisualStyleBackColor = True
        '
        'lstIntLog
        '
        Me.lstIntLog.FormattingEnabled = True
        Me.lstIntLog.ItemHeight = 12
        Me.lstIntLog.Location = New System.Drawing.Point(12, 418)
        Me.lstIntLog.Name = "lstIntLog"
        Me.lstIntLog.Size = New System.Drawing.Size(460, 100)
        Me.lstIntLog.TabIndex = 15
        '
        'AxtMsg
        '
        Me.AxtMsg.Enabled = True
        Me.AxtMsg.Location = New System.Drawing.Point(448, 418)
        Me.AxtMsg.Name = "AxtMsg"
        Me.AxtMsg.OcxState = CType(resources.GetObject("AxtMsg.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxtMsg.Size = New System.Drawing.Size(24, 23)
        Me.AxtMsg.TabIndex = 16
        Me.AxtMsg.Visible = False
        '
        'm_timer
        '
        Me.m_timer.Enabled = True
        '
        'InterruptSetting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(484, 527)
        Me.Controls.Add(Me.AxtMsg)
        Me.Controls.Add(Me.lstIntLog)
        Me.Controls.Add(Me.chkIntEnable)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.grpBank2)
        Me.Controls.Add(Me.grpBank1)
        Me.Controls.Add(Me.GroupBox1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "InterruptSetting"
        Me.Text = "InterruptSetting"
        Me.grpBank1.ResumeLayout(False)
        Me.grpBank1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.grpBank2.ResumeLayout(False)
        Me.grpBank2.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.AxtMsg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpBank1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnSetBank1 As System.Windows.Forms.Button
    Friend WithEvents chkBank1Bit31 As System.Windows.Forms.CheckBox
    Friend WithEvents chkBank1Bit02 As System.Windows.Forms.CheckBox
    Friend WithEvents chkBank1Bit01 As System.Windows.Forms.CheckBox
    Friend WithEvents chkBank1Bit00 As System.Windows.Forms.CheckBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cboSelAxis As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents grpBank2 As System.Windows.Forms.GroupBox
    Friend WithEvents chkBank2Bit22 As System.Windows.Forms.CheckBox
    Friend WithEvents chkBank2Bit21 As System.Windows.Forms.CheckBox
    Friend WithEvents btnSetBank2 As System.Windows.Forms.Button
    Friend WithEvents chkBank2Bit20 As System.Windows.Forms.CheckBox
    Friend WithEvents chkBank2Bit16 As System.Windows.Forms.CheckBox
    Friend WithEvents chkBank2Bit15 As System.Windows.Forms.CheckBox
    Friend WithEvents chkBank2Bit14 As System.Windows.Forms.CheckBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents rdoEvent As System.Windows.Forms.RadioButton
    Friend WithEvents rdoCallback As System.Windows.Forms.RadioButton
    Friend WithEvents rdoMessage As System.Windows.Forms.RadioButton
    Friend WithEvents chkIntEnable As System.Windows.Forms.CheckBox
    Friend WithEvents lstIntLog As System.Windows.Forms.ListBox
    Friend WithEvents AxtMsg As AxAXTMESSENGERLib.AxAxtMessenger
    Friend WithEvents m_timer As System.Windows.Forms.Timer

End Class
