<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StatusMonitor
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
        Me.Label15 = New System.Windows.Forms.Label()
        Me.chkMechBit17 = New System.Windows.Forms.CheckBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.chkMechBit14 = New System.Windows.Forms.CheckBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.chkMechBit13 = New System.Windows.Forms.CheckBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.chkMechBit12 = New System.Windows.Forms.CheckBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.chkMechBit11 = New System.Windows.Forms.CheckBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.chkMechBit10 = New System.Windows.Forms.CheckBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.chkMechBit09 = New System.Windows.Forms.CheckBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.chkMechBit08 = New System.Windows.Forms.CheckBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.chkMechBit07 = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.chkMechBit06 = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.chkMechBit05 = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.chkMechBit04 = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.chkMechBit01 = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.chkMechBit00 = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.chkEndBit31 = New System.Windows.Forms.CheckBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.chkEndBit30 = New System.Windows.Forms.CheckBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.chkEndBit28 = New System.Windows.Forms.CheckBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.chkEndBit15 = New System.Windows.Forms.CheckBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.chkEndBit11 = New System.Windows.Forms.CheckBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.chkEndBit10 = New System.Windows.Forms.CheckBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.chkEndBit09 = New System.Windows.Forms.CheckBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.chkEndBit08 = New System.Windows.Forms.CheckBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.chkEndBit07 = New System.Windows.Forms.CheckBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.chkEndBit06 = New System.Windows.Forms.CheckBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.chkEndBit05 = New System.Windows.Forms.CheckBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.chkEndBit04 = New System.Windows.Forms.CheckBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.chkEndBit01 = New System.Windows.Forms.CheckBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.chkEndBit00 = New System.Windows.Forms.CheckBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.chkDriveBit11 = New System.Windows.Forms.CheckBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.chkDriveBit10 = New System.Windows.Forms.CheckBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.chkDriveBit07 = New System.Windows.Forms.CheckBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.chkDriveBit06 = New System.Windows.Forms.CheckBox()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.chkDriveBit05 = New System.Windows.Forms.CheckBox()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.chkDriveBit04 = New System.Windows.Forms.CheckBox()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.chkDriveBit03 = New System.Windows.Forms.CheckBox()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.chkDriveBit02 = New System.Windows.Forms.CheckBox()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.chkDriveBit01 = New System.Windows.Forms.CheckBox()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.chkDriveBit00 = New System.Windows.Forms.CheckBox()
        Me.m_timer = New System.Windows.Forms.Timer(Me.components)
        Me.CommonDialog1Open = New System.Windows.Forms.OpenFileDialog()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnLoadFile
        '
        Me.btnLoadFile.Location = New System.Drawing.Point(344, 16)
        Me.btnLoadFile.Name = "btnLoadFile"
        Me.btnLoadFile.Size = New System.Drawing.Size(113, 22)
        Me.btnLoadFile.TabIndex = 7
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
        Me.cboSelAxis.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(21, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 12)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Select Axis No :"
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Location = New System.Drawing.Point(12, 13)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(455, 27)
        Me.PictureBox1.TabIndex = 4
        Me.PictureBox1.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.chkMechBit17)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.chkMechBit14)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.chkMechBit13)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.chkMechBit12)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.chkMechBit11)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.chkMechBit10)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.chkMechBit09)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.chkMechBit08)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.chkMechBit07)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.chkMechBit06)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.chkMechBit05)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.chkMechBit04)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.chkMechBit01)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.chkMechBit00)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 47)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(455, 165)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Mechanical Status"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(249, 141)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(150, 12)
        Me.Label15.TabIndex = 27
        Me.Label15.Text = "Bit 17: MODE Signal State"
        '
        'chkMechBit17
        '
        Me.chkMechBit17.AutoSize = True
        Me.chkMechBit17.Enabled = False
        Me.chkMechBit17.Location = New System.Drawing.Point(230, 140)
        Me.chkMechBit17.Name = "chkMechBit17"
        Me.chkMechBit17.Size = New System.Drawing.Size(15, 14)
        Me.chkMechBit17.TabIndex = 26
        Me.chkMechBit17.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(249, 121)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(165, 12)
        Me.Label14.TabIndex = 25
        Me.Label14.Text = "Bit 14: SQSTR 2 Signal State"
        '
        'chkMechBit14
        '
        Me.chkMechBit14.AutoSize = True
        Me.chkMechBit14.Enabled = False
        Me.chkMechBit14.Location = New System.Drawing.Point(230, 120)
        Me.chkMechBit14.Name = "chkMechBit14"
        Me.chkMechBit14.Size = New System.Drawing.Size(15, 14)
        Me.chkMechBit14.TabIndex = 24
        Me.chkMechBit14.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(249, 101)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(165, 12)
        Me.Label13.TabIndex = 23
        Me.Label13.Text = "Bit 13: SQSTR 1 Signal State"
        '
        'chkMechBit13
        '
        Me.chkMechBit13.AutoSize = True
        Me.chkMechBit13.Enabled = False
        Me.chkMechBit13.Location = New System.Drawing.Point(230, 100)
        Me.chkMechBit13.Name = "chkMechBit13"
        Me.chkMechBit13.Size = New System.Drawing.Size(15, 14)
        Me.chkMechBit13.TabIndex = 22
        Me.chkMechBit13.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(249, 81)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(187, 12)
        Me.Label12.TabIndex = 21
        Me.Label12.Text = "Bit 12: EXMP(MPG) Signal State"
        '
        'chkMechBit12
        '
        Me.chkMechBit12.AutoSize = True
        Me.chkMechBit12.Enabled = False
        Me.chkMechBit12.Location = New System.Drawing.Point(230, 80)
        Me.chkMechBit12.Name = "chkMechBit12"
        Me.chkMechBit12.Size = New System.Drawing.Size(15, 14)
        Me.chkMechBit12.TabIndex = 20
        Me.chkMechBit12.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(249, 61)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(184, 12)
        Me.Label11.TabIndex = 19
        Me.Label11.Text = "Bit 11: EXPP(MPG) Signal State"
        '
        'chkMechBit11
        '
        Me.chkMechBit11.AutoSize = True
        Me.chkMechBit11.Enabled = False
        Me.chkMechBit11.Location = New System.Drawing.Point(230, 60)
        Me.chkMechBit11.Name = "chkMechBit11"
        Me.chkMechBit11.Size = New System.Drawing.Size(15, 14)
        Me.chkMechBit11.TabIndex = 18
        Me.chkMechBit11.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(249, 41)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(180, 12)
        Me.Label10.TabIndex = 17
        Me.Label10.Text = "Bit 10: Encoder Dn Signal State"
        '
        'chkMechBit10
        '
        Me.chkMechBit10.AutoSize = True
        Me.chkMechBit10.Enabled = False
        Me.chkMechBit10.Location = New System.Drawing.Point(230, 40)
        Me.chkMechBit10.Name = "chkMechBit10"
        Me.chkMechBit10.Size = New System.Drawing.Size(15, 14)
        Me.chkMechBit10.TabIndex = 16
        Me.chkMechBit10.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(249, 21)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(180, 12)
        Me.Label9.TabIndex = 15
        Me.Label9.Text = "Bit 09: Encoder Up Signal State"
        '
        'chkMechBit09
        '
        Me.chkMechBit09.AutoSize = True
        Me.chkMechBit09.Enabled = False
        Me.chkMechBit09.Location = New System.Drawing.Point(230, 20)
        Me.chkMechBit09.Name = "chkMechBit09"
        Me.chkMechBit09.Size = New System.Drawing.Size(15, 14)
        Me.chkMechBit09.TabIndex = 14
        Me.chkMechBit09.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(31, 141)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(162, 12)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "Bit 08: Z Phase Signal State"
        '
        'chkMechBit08
        '
        Me.chkMechBit08.AutoSize = True
        Me.chkMechBit08.Enabled = False
        Me.chkMechBit08.Location = New System.Drawing.Point(12, 140)
        Me.chkMechBit08.Name = "chkMechBit08"
        Me.chkMechBit08.Size = New System.Drawing.Size(15, 14)
        Me.chkMechBit08.TabIndex = 12
        Me.chkMechBit08.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(31, 121)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(147, 12)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "Bit 07: Home Signal State"
        '
        'chkMechBit07
        '
        Me.chkMechBit07.AutoSize = True
        Me.chkMechBit07.Enabled = False
        Me.chkMechBit07.Location = New System.Drawing.Point(12, 120)
        Me.chkMechBit07.Name = "chkMechBit07"
        Me.chkMechBit07.Size = New System.Drawing.Size(15, 14)
        Me.chkMechBit07.TabIndex = 10
        Me.chkMechBit07.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(31, 101)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(179, 12)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Bit 06: Emergency Signal State"
        '
        'chkMechBit06
        '
        Me.chkMechBit06.AutoSize = True
        Me.chkMechBit06.Enabled = False
        Me.chkMechBit06.Location = New System.Drawing.Point(12, 100)
        Me.chkMechBit06.Name = "chkMechBit06"
        Me.chkMechBit06.Size = New System.Drawing.Size(15, 14)
        Me.chkMechBit06.TabIndex = 8
        Me.chkMechBit06.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(31, 81)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(168, 12)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Bit 05: Inposition Signal State"
        '
        'chkMechBit05
        '
        Me.chkMechBit05.AutoSize = True
        Me.chkMechBit05.Enabled = False
        Me.chkMechBit05.Location = New System.Drawing.Point(12, 80)
        Me.chkMechBit05.Name = "chkMechBit05"
        Me.chkMechBit05.Size = New System.Drawing.Size(15, 14)
        Me.chkMechBit05.TabIndex = 6
        Me.chkMechBit05.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(31, 61)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(147, 12)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Bit 04: Alarm Signal State"
        '
        'chkMechBit04
        '
        Me.chkMechBit04.AutoSize = True
        Me.chkMechBit04.Enabled = False
        Me.chkMechBit04.Location = New System.Drawing.Point(12, 60)
        Me.chkMechBit04.Name = "chkMechBit04"
        Me.chkMechBit04.Size = New System.Drawing.Size(15, 14)
        Me.chkMechBit04.TabIndex = 4
        Me.chkMechBit04.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(31, 41)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(181, 12)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Bit 01: Negative End Limit State"
        '
        'chkMechBit01
        '
        Me.chkMechBit01.AutoSize = True
        Me.chkMechBit01.Enabled = False
        Me.chkMechBit01.Location = New System.Drawing.Point(12, 40)
        Me.chkMechBit01.Name = "chkMechBit01"
        Me.chkMechBit01.Size = New System.Drawing.Size(15, 14)
        Me.chkMechBit01.TabIndex = 2
        Me.chkMechBit01.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(31, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(176, 12)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Bit 00: Positive End Limit State"
        '
        'chkMechBit00
        '
        Me.chkMechBit00.AutoSize = True
        Me.chkMechBit00.Enabled = False
        Me.chkMechBit00.Location = New System.Drawing.Point(12, 20)
        Me.chkMechBit00.Name = "chkMechBit00"
        Me.chkMechBit00.Size = New System.Drawing.Size(15, 14)
        Me.chkMechBit00.TabIndex = 0
        Me.chkMechBit00.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.chkEndBit31)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.chkEndBit30)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.chkEndBit28)
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Controls.Add(Me.chkEndBit15)
        Me.GroupBox2.Controls.Add(Me.Label20)
        Me.GroupBox2.Controls.Add(Me.chkEndBit11)
        Me.GroupBox2.Controls.Add(Me.Label21)
        Me.GroupBox2.Controls.Add(Me.chkEndBit10)
        Me.GroupBox2.Controls.Add(Me.Label22)
        Me.GroupBox2.Controls.Add(Me.chkEndBit09)
        Me.GroupBox2.Controls.Add(Me.Label23)
        Me.GroupBox2.Controls.Add(Me.chkEndBit08)
        Me.GroupBox2.Controls.Add(Me.Label24)
        Me.GroupBox2.Controls.Add(Me.chkEndBit07)
        Me.GroupBox2.Controls.Add(Me.Label25)
        Me.GroupBox2.Controls.Add(Me.chkEndBit06)
        Me.GroupBox2.Controls.Add(Me.Label26)
        Me.GroupBox2.Controls.Add(Me.chkEndBit05)
        Me.GroupBox2.Controls.Add(Me.Label27)
        Me.GroupBox2.Controls.Add(Me.chkEndBit04)
        Me.GroupBox2.Controls.Add(Me.Label28)
        Me.GroupBox2.Controls.Add(Me.chkEndBit01)
        Me.GroupBox2.Controls.Add(Me.Label29)
        Me.GroupBox2.Controls.Add(Me.chkEndBit00)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 218)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(455, 165)
        Me.GroupBox2.TabIndex = 28
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Motion End Status"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(249, 141)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(173, 12)
        Me.Label16.TabIndex = 27
        Me.Label16.Text = "Bit 31: Interpolation data error "
        '
        'chkEndBit31
        '
        Me.chkEndBit31.AutoSize = True
        Me.chkEndBit31.Enabled = False
        Me.chkEndBit31.Location = New System.Drawing.Point(230, 140)
        Me.chkEndBit31.Name = "chkEndBit31"
        Me.chkEndBit31.Size = New System.Drawing.Size(15, 14)
        Me.chkEndBit31.TabIndex = 26
        Me.chkEndBit31.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(249, 121)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(156, 12)
        Me.Label17.TabIndex = 25
        Me.Label17.Text = "Bit 30: Abnormal drive stop"
        '
        'chkEndBit30
        '
        Me.chkEndBit30.AutoSize = True
        Me.chkEndBit30.Enabled = False
        Me.chkEndBit30.Location = New System.Drawing.Point(230, 120)
        Me.chkEndBit30.Name = "chkEndBit30"
        Me.chkEndBit30.Size = New System.Drawing.Size(15, 14)
        Me.chkEndBit30.TabIndex = 24
        Me.chkEndBit30.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(249, 101)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(201, 12)
        Me.Label18.TabIndex = 23
        Me.Label18.Text = "Bit 28: Current/Last move direction"
        '
        'chkEndBit28
        '
        Me.chkEndBit28.AutoSize = True
        Me.chkEndBit28.Enabled = False
        Me.chkEndBit28.Location = New System.Drawing.Point(230, 100)
        Me.chkEndBit28.Name = "chkEndBit28"
        Me.chkEndBit28.Size = New System.Drawing.Size(15, 14)
        Me.chkEndBit28.TabIndex = 22
        Me.chkEndBit28.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(249, 81)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(151, 12)
        Me.Label19.TabIndex = 21
        Me.Label19.Text = "Bit 15: Encoder input error"
        '
        'chkEndBit15
        '
        Me.chkEndBit15.AutoSize = True
        Me.chkEndBit15.Enabled = False
        Me.chkEndBit15.Location = New System.Drawing.Point(230, 80)
        Me.chkEndBit15.Name = "chkEndBit15"
        Me.chkEndBit15.Size = New System.Drawing.Size(15, 14)
        Me.chkEndBit15.TabIndex = 20
        Me.chkEndBit15.UseVisualStyleBackColor = True
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(249, 61)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(173, 12)
        Me.Label20.TabIndex = 19
        Me.Label20.Text = "Bit 11: Exit by slow stop CMD"
        '
        'chkEndBit11
        '
        Me.chkEndBit11.AutoSize = True
        Me.chkEndBit11.Enabled = False
        Me.chkEndBit11.Location = New System.Drawing.Point(230, 60)
        Me.chkEndBit11.Name = "chkEndBit11"
        Me.chkEndBit11.Size = New System.Drawing.Size(15, 14)
        Me.chkEndBit11.TabIndex = 18
        Me.chkEndBit11.UseVisualStyleBackColor = True
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(249, 41)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(174, 12)
        Me.Label21.TabIndex = 17
        Me.Label21.Text = "Bit 10: Exit by EMG stop CMD"
        '
        'chkEndBit10
        '
        Me.chkEndBit10.AutoSize = True
        Me.chkEndBit10.Enabled = False
        Me.chkEndBit10.Location = New System.Drawing.Point(230, 40)
        Me.chkEndBit10.Name = "chkEndBit10"
        Me.chkEndBit10.Size = New System.Drawing.Size(15, 14)
        Me.chkEndBit10.TabIndex = 16
        Me.chkEndBit10.UseVisualStyleBackColor = True
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(249, 21)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(188, 12)
        Me.Label22.TabIndex = 15
        Me.Label22.Text = "Bit 09: Exit by emergency signal"
        '
        'chkEndBit09
        '
        Me.chkEndBit09.AutoSize = True
        Me.chkEndBit09.Enabled = False
        Me.chkEndBit09.Location = New System.Drawing.Point(230, 20)
        Me.chkEndBit09.Name = "chkEndBit09"
        Me.chkEndBit09.Size = New System.Drawing.Size(15, 14)
        Me.chkEndBit09.TabIndex = 14
        Me.chkEndBit09.UseVisualStyleBackColor = True
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(31, 141)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(191, 12)
        Me.Label23.TabIndex = 13
        Me.Label23.Text = "Bit 08: Exit by servo alarm signal"
        '
        'chkEndBit08
        '
        Me.chkEndBit08.AutoSize = True
        Me.chkEndBit08.Enabled = False
        Me.chkEndBit08.Location = New System.Drawing.Point(12, 140)
        Me.chkEndBit08.Name = "chkEndBit08"
        Me.chkEndBit08.Size = New System.Drawing.Size(15, 14)
        Me.chkEndBit08.TabIndex = 12
        Me.chkEndBit08.UseVisualStyleBackColor = True
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(31, 121)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(198, 12)
        Me.Label24.TabIndex = 11
        Me.Label24.Text = "Bit 07: Exit by negative SW S-Stop"
        '
        'chkEndBit07
        '
        Me.chkEndBit07.AutoSize = True
        Me.chkEndBit07.Enabled = False
        Me.chkEndBit07.Location = New System.Drawing.Point(12, 120)
        Me.chkEndBit07.Name = "chkEndBit07"
        Me.chkEndBit07.Size = New System.Drawing.Size(15, 14)
        Me.chkEndBit07.TabIndex = 10
        Me.chkEndBit07.UseVisualStyleBackColor = True
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(31, 101)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(194, 12)
        Me.Label25.TabIndex = 9
        Me.Label25.Text = "Bit 06: Exit by positive SW S-Stop"
        '
        'chkEndBit06
        '
        Me.chkEndBit06.AutoSize = True
        Me.chkEndBit06.Enabled = False
        Me.chkEndBit06.Location = New System.Drawing.Point(12, 100)
        Me.chkEndBit06.Name = "chkEndBit06"
        Me.chkEndBit06.Size = New System.Drawing.Size(15, 14)
        Me.chkEndBit06.TabIndex = 8
        Me.chkEndBit06.UseVisualStyleBackColor = True
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(31, 81)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(198, 12)
        Me.Label26.TabIndex = 7
        Me.Label26.Text = "Bit 05: Exit by negative SW E-Stop"
        '
        'chkEndBit05
        '
        Me.chkEndBit05.AutoSize = True
        Me.chkEndBit05.Enabled = False
        Me.chkEndBit05.Location = New System.Drawing.Point(12, 80)
        Me.chkEndBit05.Name = "chkEndBit05"
        Me.chkEndBit05.Size = New System.Drawing.Size(15, 14)
        Me.chkEndBit05.TabIndex = 6
        Me.chkEndBit05.UseVisualStyleBackColor = True
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(31, 61)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(194, 12)
        Me.Label27.TabIndex = 5
        Me.Label27.Text = "Bit 04: Exit by positive SW E-Stop"
        '
        'chkEndBit04
        '
        Me.chkEndBit04.AutoSize = True
        Me.chkEndBit04.Enabled = False
        Me.chkEndBit04.Location = New System.Drawing.Point(12, 60)
        Me.chkEndBit04.Name = "chkEndBit04"
        Me.chkEndBit04.Size = New System.Drawing.Size(15, 14)
        Me.chkEndBit04.TabIndex = 4
        Me.chkEndBit04.UseVisualStyleBackColor = True
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(31, 41)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(185, 12)
        Me.Label28.TabIndex = 3
        Me.Label28.Text = "Bit 01: Exit by negative end limit"
        '
        'chkEndBit01
        '
        Me.chkEndBit01.AutoSize = True
        Me.chkEndBit01.Enabled = False
        Me.chkEndBit01.Location = New System.Drawing.Point(12, 40)
        Me.chkEndBit01.Name = "chkEndBit01"
        Me.chkEndBit01.Size = New System.Drawing.Size(15, 14)
        Me.chkEndBit01.TabIndex = 2
        Me.chkEndBit01.UseVisualStyleBackColor = True
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(31, 21)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(181, 12)
        Me.Label29.TabIndex = 1
        Me.Label29.Text = "Bit 00: Exit by positive end limit"
        '
        'chkEndBit00
        '
        Me.chkEndBit00.AutoSize = True
        Me.chkEndBit00.Enabled = False
        Me.chkEndBit00.Location = New System.Drawing.Point(12, 20)
        Me.chkEndBit00.Name = "chkEndBit00"
        Me.chkEndBit00.Size = New System.Drawing.Size(15, 14)
        Me.chkEndBit00.TabIndex = 0
        Me.chkEndBit00.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label32)
        Me.GroupBox3.Controls.Add(Me.chkDriveBit11)
        Me.GroupBox3.Controls.Add(Me.Label33)
        Me.GroupBox3.Controls.Add(Me.chkDriveBit10)
        Me.GroupBox3.Controls.Add(Me.Label34)
        Me.GroupBox3.Controls.Add(Me.chkDriveBit07)
        Me.GroupBox3.Controls.Add(Me.Label35)
        Me.GroupBox3.Controls.Add(Me.chkDriveBit06)
        Me.GroupBox3.Controls.Add(Me.Label36)
        Me.GroupBox3.Controls.Add(Me.chkDriveBit05)
        Me.GroupBox3.Controls.Add(Me.Label39)
        Me.GroupBox3.Controls.Add(Me.chkDriveBit04)
        Me.GroupBox3.Controls.Add(Me.Label40)
        Me.GroupBox3.Controls.Add(Me.chkDriveBit03)
        Me.GroupBox3.Controls.Add(Me.Label41)
        Me.GroupBox3.Controls.Add(Me.chkDriveBit02)
        Me.GroupBox3.Controls.Add(Me.Label42)
        Me.GroupBox3.Controls.Add(Me.chkDriveBit01)
        Me.GroupBox3.Controls.Add(Me.Label43)
        Me.GroupBox3.Controls.Add(Me.chkDriveBit00)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 389)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(455, 124)
        Me.GroupBox3.TabIndex = 29
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Drive Status"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(249, 101)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(173, 12)
        Me.Label32.TabIndex = 23
        Me.Label32.Text = "Bit 11: Direction of motor drive"
        '
        'chkDriveBit11
        '
        Me.chkDriveBit11.AutoSize = True
        Me.chkDriveBit11.Enabled = False
        Me.chkDriveBit11.Location = New System.Drawing.Point(230, 100)
        Me.chkDriveBit11.Name = "chkDriveBit11"
        Me.chkDriveBit11.Size = New System.Drawing.Size(15, 14)
        Me.chkDriveBit11.TabIndex = 22
        Me.chkDriveBit11.UseVisualStyleBackColor = True
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(249, 81)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(167, 12)
        Me.Label33.TabIndex = 21
        Me.Label33.Text = "Bit 10: In move of slave drive"
        '
        'chkDriveBit10
        '
        Me.chkDriveBit10.AutoSize = True
        Me.chkDriveBit10.Enabled = False
        Me.chkDriveBit10.Location = New System.Drawing.Point(230, 80)
        Me.chkDriveBit10.Name = "chkDriveBit10"
        Me.chkDriveBit10.Size = New System.Drawing.Size(15, 14)
        Me.chkDriveBit10.TabIndex = 20
        Me.chkDriveBit10.UseVisualStyleBackColor = True
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(249, 61)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(169, 12)
        Me.Label34.TabIndex = 19
        Me.Label34.Text = "Bit 07: In move of home drive"
        '
        'chkDriveBit07
        '
        Me.chkDriveBit07.AutoSize = True
        Me.chkDriveBit07.Enabled = False
        Me.chkDriveBit07.Location = New System.Drawing.Point(230, 60)
        Me.chkDriveBit07.Name = "chkDriveBit07"
        Me.chkDriveBit07.Size = New System.Drawing.Size(15, 14)
        Me.chkDriveBit07.TabIndex = 18
        Me.chkDriveBit07.UseVisualStyleBackColor = True
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(249, 41)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(165, 12)
        Me.Label35.TabIndex = 17
        Me.Label35.Text = "Bit 06: In move of MPG drive"
        '
        'chkDriveBit06
        '
        Me.chkDriveBit06.AutoSize = True
        Me.chkDriveBit06.Enabled = False
        Me.chkDriveBit06.Location = New System.Drawing.Point(230, 40)
        Me.chkDriveBit06.Name = "chkDriveBit06"
        Me.chkDriveBit06.Size = New System.Drawing.Size(15, 14)
        Me.chkDriveBit06.TabIndex = 16
        Me.chkDriveBit06.UseVisualStyleBackColor = True
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(249, 21)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(189, 12)
        Me.Label36.TabIndex = 15
        Me.Label36.Text = "Bit 05: In move of assigned drive"
        '
        'chkDriveBit05
        '
        Me.chkDriveBit05.AutoSize = True
        Me.chkDriveBit05.Enabled = False
        Me.chkDriveBit05.Location = New System.Drawing.Point(230, 20)
        Me.chkDriveBit05.Name = "chkDriveBit05"
        Me.chkDriveBit05.Size = New System.Drawing.Size(15, 14)
        Me.chkDriveBit05.TabIndex = 14
        Me.chkDriveBit05.UseVisualStyleBackColor = True
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Location = New System.Drawing.Point(31, 101)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(199, 12)
        Me.Label39.TabIndex = 9
        Me.Label39.Text = "Bit 04: In move of continuous drive"
        '
        'chkDriveBit04
        '
        Me.chkDriveBit04.AutoSize = True
        Me.chkDriveBit04.Enabled = False
        Me.chkDriveBit04.Location = New System.Drawing.Point(12, 100)
        Me.chkDriveBit04.Name = "chkDriveBit04"
        Me.chkDriveBit04.Size = New System.Drawing.Size(15, 14)
        Me.chkDriveBit04.TabIndex = 8
        Me.chkDriveBit04.UseVisualStyleBackColor = True
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Location = New System.Drawing.Point(31, 81)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(156, 12)
        Me.Label40.TabIndex = 7
        Me.Label40.Text = "Bit 03: UP (In acceleration)"
        '
        'chkDriveBit03
        '
        Me.chkDriveBit03.AutoSize = True
        Me.chkDriveBit03.Enabled = False
        Me.chkDriveBit03.Location = New System.Drawing.Point(12, 80)
        Me.chkDriveBit03.Name = "chkDriveBit03"
        Me.chkDriveBit03.Size = New System.Drawing.Size(15, 14)
        Me.chkDriveBit03.TabIndex = 6
        Me.chkDriveBit03.UseVisualStyleBackColor = True
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Location = New System.Drawing.Point(31, 61)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(201, 12)
        Me.Label41.TabIndex = 5
        Me.Label41.Text = "Bit 02: CONST (In constant speed)"
        '
        'chkDriveBit02
        '
        Me.chkDriveBit02.AutoSize = True
        Me.chkDriveBit02.Enabled = False
        Me.chkDriveBit02.Location = New System.Drawing.Point(12, 60)
        Me.chkDriveBit02.Name = "chkDriveBit02"
        Me.chkDriveBit02.Size = New System.Drawing.Size(15, 14)
        Me.chkDriveBit02.TabIndex = 4
        Me.chkDriveBit02.UseVisualStyleBackColor = True
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Location = New System.Drawing.Point(31, 41)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(176, 12)
        Me.Label42.TabIndex = 3
        Me.Label42.Text = "Bit 01: DOWN (In deceleration)"
        '
        'chkDriveBit01
        '
        Me.chkDriveBit01.AutoSize = True
        Me.chkDriveBit01.Enabled = False
        Me.chkDriveBit01.Location = New System.Drawing.Point(12, 40)
        Me.chkDriveBit01.Name = "chkDriveBit01"
        Me.chkDriveBit01.Size = New System.Drawing.Size(15, 14)
        Me.chkDriveBit01.TabIndex = 2
        Me.chkDriveBit01.UseVisualStyleBackColor = True
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Location = New System.Drawing.Point(31, 21)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(165, 12)
        Me.Label43.TabIndex = 1
        Me.Label43.Text = "Bit 00: BUSY (In drive move)"
        '
        'chkDriveBit00
        '
        Me.chkDriveBit00.AutoSize = True
        Me.chkDriveBit00.Enabled = False
        Me.chkDriveBit00.Location = New System.Drawing.Point(12, 20)
        Me.chkDriveBit00.Name = "chkDriveBit00"
        Me.chkDriveBit00.Size = New System.Drawing.Size(15, 14)
        Me.chkDriveBit00.TabIndex = 0
        Me.chkDriveBit00.UseVisualStyleBackColor = True
        '
        'm_timer
        '
        Me.m_timer.Enabled = True
        '
        'CommonDialog1Open
        '
        Me.CommonDialog1Open.FileName = "OpenFileDialog1"
        '
        'StatusMonitor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(479, 525)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnLoadFile)
        Me.Controls.Add(Me.cboSelAxis)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "StatusMonitor"
        Me.Text = "StatusMonitor"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnLoadFile As System.Windows.Forms.Button
    Friend WithEvents cboSelAxis As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents chkMechBit08 As System.Windows.Forms.CheckBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents chkMechBit07 As System.Windows.Forms.CheckBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents chkMechBit06 As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents chkMechBit05 As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents chkMechBit04 As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents chkMechBit01 As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chkMechBit00 As System.Windows.Forms.CheckBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents chkMechBit17 As System.Windows.Forms.CheckBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents chkMechBit14 As System.Windows.Forms.CheckBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents chkMechBit13 As System.Windows.Forms.CheckBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents chkMechBit12 As System.Windows.Forms.CheckBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents chkMechBit11 As System.Windows.Forms.CheckBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents chkMechBit10 As System.Windows.Forms.CheckBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents chkMechBit09 As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents chkEndBit31 As System.Windows.Forms.CheckBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents chkEndBit30 As System.Windows.Forms.CheckBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents chkEndBit28 As System.Windows.Forms.CheckBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents chkEndBit15 As System.Windows.Forms.CheckBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents chkEndBit11 As System.Windows.Forms.CheckBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents chkEndBit10 As System.Windows.Forms.CheckBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents chkEndBit09 As System.Windows.Forms.CheckBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents chkEndBit08 As System.Windows.Forms.CheckBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents chkEndBit07 As System.Windows.Forms.CheckBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents chkEndBit06 As System.Windows.Forms.CheckBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents chkEndBit05 As System.Windows.Forms.CheckBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents chkEndBit04 As System.Windows.Forms.CheckBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents chkEndBit01 As System.Windows.Forms.CheckBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents chkEndBit00 As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents chkDriveBit11 As System.Windows.Forms.CheckBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents chkDriveBit10 As System.Windows.Forms.CheckBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents chkDriveBit07 As System.Windows.Forms.CheckBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents chkDriveBit06 As System.Windows.Forms.CheckBox
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents chkDriveBit05 As System.Windows.Forms.CheckBox
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents chkDriveBit04 As System.Windows.Forms.CheckBox
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents chkDriveBit03 As System.Windows.Forms.CheckBox
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents chkDriveBit02 As System.Windows.Forms.CheckBox
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents chkDriveBit01 As System.Windows.Forms.CheckBox
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents chkDriveBit00 As System.Windows.Forms.CheckBox
    Friend WithEvents m_timer As System.Windows.Forms.Timer
    Friend WithEvents CommonDialog1Open As System.Windows.Forms.OpenFileDialog

End Class
