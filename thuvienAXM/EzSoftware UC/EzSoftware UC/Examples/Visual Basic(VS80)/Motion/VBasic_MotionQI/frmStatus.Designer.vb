<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmStatus
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
	Public WithEvents tmStatusView As System.Windows.Forms.Timer
	Public WithEvents btnCur As System.Windows.Forms.Button
	Public WithEvents btnNext As System.Windows.Forms.Button
	Public WithEvents btnPrev As System.Windows.Forms.Button
	Public WithEvents LedYDRS09 As System.Windows.Forms.PictureBox
	Public WithEvents LedYDRS10 As System.Windows.Forms.PictureBox
	Public WithEvents LedYDRS07 As System.Windows.Forms.PictureBox
	Public WithEvents LedYDRS06 As System.Windows.Forms.PictureBox
	Public WithEvents LedYDRS05 As System.Windows.Forms.PictureBox
	Public WithEvents LedYDRS04 As System.Windows.Forms.PictureBox
	Public WithEvents LedYDRS03 As System.Windows.Forms.PictureBox
	Public WithEvents LedYDRS02 As System.Windows.Forms.PictureBox
	Public WithEvents LedYDRS01 As System.Windows.Forms.PictureBox
	Public WithEvents LedYDRS00 As System.Windows.Forms.PictureBox
	Public WithEvents Label69 As System.Windows.Forms.Label
	Public WithEvents Label70 As System.Windows.Forms.Label
	Public WithEvents Label67 As System.Windows.Forms.Label
	Public WithEvents Label66 As System.Windows.Forms.Label
	Public WithEvents Label65 As System.Windows.Forms.Label
	Public WithEvents Label64 As System.Windows.Forms.Label
	Public WithEvents Label63 As System.Windows.Forms.Label
	Public WithEvents Label62 As System.Windows.Forms.Label
	Public WithEvents Label61 As System.Windows.Forms.Label
	Public WithEvents Label60 As System.Windows.Forms.Label
	Public WithEvents Frame1 As System.Windows.Forms.GroupBox
	Public WithEvents LedYENS16 As System.Windows.Forms.PictureBox
	Public WithEvents LedYENS30 As System.Windows.Forms.PictureBox
	Public WithEvents LedYENS31 As System.Windows.Forms.PictureBox
	Public WithEvents LedYENS08 As System.Windows.Forms.PictureBox
	Public WithEvents LedYENS09 As System.Windows.Forms.PictureBox
	Public WithEvents LedYENS10 As System.Windows.Forms.PictureBox
	Public WithEvents LedYENS11 As System.Windows.Forms.PictureBox
	Public WithEvents LedYENS12 As System.Windows.Forms.PictureBox
	Public WithEvents LedYENS13 As System.Windows.Forms.PictureBox
	Public WithEvents LedYENS14 As System.Windows.Forms.PictureBox
	Public WithEvents LedYENS15 As System.Windows.Forms.PictureBox
	Public WithEvents LedYENS07 As System.Windows.Forms.PictureBox
	Public WithEvents LedYENS06 As System.Windows.Forms.PictureBox
	Public WithEvents LedYENS05 As System.Windows.Forms.PictureBox
	Public WithEvents LedYENS04 As System.Windows.Forms.PictureBox
	Public WithEvents LedYENS03 As System.Windows.Forms.PictureBox
	Public WithEvents LedYENS02 As System.Windows.Forms.PictureBox
	Public WithEvents LedYENS01 As System.Windows.Forms.PictureBox
	Public WithEvents LedYENS00 As System.Windows.Forms.PictureBox
	Public WithEvents Label58 As System.Windows.Forms.Label
	Public WithEvents Label57 As System.Windows.Forms.Label
	Public WithEvents Label56 As System.Windows.Forms.Label
	Public WithEvents Label55 As System.Windows.Forms.Label
	Public WithEvents Label54 As System.Windows.Forms.Label
	Public WithEvents Label53 As System.Windows.Forms.Label
	Public WithEvents Label52 As System.Windows.Forms.Label
	Public WithEvents Label51 As System.Windows.Forms.Label
	Public WithEvents Label50 As System.Windows.Forms.Label
	Public WithEvents Label49 As System.Windows.Forms.Label
	Public WithEvents Label48 As System.Windows.Forms.Label
	Public WithEvents _lblAxis_1 As System.Windows.Forms.Label
	Public WithEvents Label47 As System.Windows.Forms.Label
	Public WithEvents Label46 As System.Windows.Forms.Label
	Public WithEvents Label45 As System.Windows.Forms.Label
	Public WithEvents Label44 As System.Windows.Forms.Label
	Public WithEvents Label43 As System.Windows.Forms.Label
	Public WithEvents Label42 As System.Windows.Forms.Label
	Public WithEvents Label41 As System.Windows.Forms.Label
	Public WithEvents Label40 As System.Windows.Forms.Label
	Public WithEvents Frame2 As System.Windows.Forms.GroupBox
	Public WithEvents frmAxisY As System.Windows.Forms.GroupBox
	Public WithEvents LedXDRS00 As System.Windows.Forms.PictureBox
	Public WithEvents LedXDRS01 As System.Windows.Forms.PictureBox
	Public WithEvents LedXDRS02 As System.Windows.Forms.PictureBox
	Public WithEvents LedXDRS03 As System.Windows.Forms.PictureBox
	Public WithEvents LedXDRS04 As System.Windows.Forms.PictureBox
	Public WithEvents LedXDRS05 As System.Windows.Forms.PictureBox
	Public WithEvents LedXDRS06 As System.Windows.Forms.PictureBox
	Public WithEvents LedXDRS07 As System.Windows.Forms.PictureBox
	Public WithEvents LedXDRS10 As System.Windows.Forms.PictureBox
	Public WithEvents LedXDRS09 As System.Windows.Forms.PictureBox
	Public WithEvents Label25 As System.Windows.Forms.Label
	Public WithEvents Label24 As System.Windows.Forms.Label
	Public WithEvents Label23 As System.Windows.Forms.Label
	Public WithEvents Label22 As System.Windows.Forms.Label
	Public WithEvents Label21 As System.Windows.Forms.Label
	Public WithEvents Label20 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label33 As System.Windows.Forms.Label
	Public WithEvents Label34 As System.Windows.Forms.Label
	Public WithEvents Frame6 As System.Windows.Forms.GroupBox
	Public WithEvents LedXENS00 As System.Windows.Forms.PictureBox
	Public WithEvents LedXENS01 As System.Windows.Forms.PictureBox
	Public WithEvents LedXENS02 As System.Windows.Forms.PictureBox
	Public WithEvents LedXENS03 As System.Windows.Forms.PictureBox
	Public WithEvents LedXENS04 As System.Windows.Forms.PictureBox
	Public WithEvents LedXENS05 As System.Windows.Forms.PictureBox
	Public WithEvents LedXENS06 As System.Windows.Forms.PictureBox
	Public WithEvents LedXENS07 As System.Windows.Forms.PictureBox
	Public WithEvents LedXENS15 As System.Windows.Forms.PictureBox
	Public WithEvents LedXENS14 As System.Windows.Forms.PictureBox
	Public WithEvents LedXENS13 As System.Windows.Forms.PictureBox
	Public WithEvents LedXENS12 As System.Windows.Forms.PictureBox
	Public WithEvents LedXENS11 As System.Windows.Forms.PictureBox
	Public WithEvents LedXENS10 As System.Windows.Forms.PictureBox
	Public WithEvents LedXENS09 As System.Windows.Forms.PictureBox
	Public WithEvents LedXENS08 As System.Windows.Forms.PictureBox
	Public WithEvents LedXENS31 As System.Windows.Forms.PictureBox
	Public WithEvents LedXENS30 As System.Windows.Forms.PictureBox
	Public WithEvents LedXENS16 As System.Windows.Forms.PictureBox
	Public WithEvents Label19 As System.Windows.Forms.Label
	Public WithEvents Label26 As System.Windows.Forms.Label
	Public WithEvents Label27 As System.Windows.Forms.Label
	Public WithEvents Label28 As System.Windows.Forms.Label
	Public WithEvents Label29 As System.Windows.Forms.Label
	Public WithEvents Label30 As System.Windows.Forms.Label
	Public WithEvents Label31 As System.Windows.Forms.Label
	Public WithEvents Label32 As System.Windows.Forms.Label
	Public WithEvents _lblAxis_0 As System.Windows.Forms.Label
	Public WithEvents Label11 As System.Windows.Forms.Label
	Public WithEvents Label12 As System.Windows.Forms.Label
	Public WithEvents Label13 As System.Windows.Forms.Label
	Public WithEvents Label14 As System.Windows.Forms.Label
	Public WithEvents Label15 As System.Windows.Forms.Label
	Public WithEvents Label16 As System.Windows.Forms.Label
	Public WithEvents Label17 As System.Windows.Forms.Label
	Public WithEvents Label18 As System.Windows.Forms.Label
	Public WithEvents Label37 As System.Windows.Forms.Label
	Public WithEvents Label38 As System.Windows.Forms.Label
	Public WithEvents Label39 As System.Windows.Forms.Label
	Public WithEvents Frame3 As System.Windows.Forms.GroupBox
	Public WithEvents frmAxisX As System.Windows.Forms.GroupBox
	Public WithEvents lblAxis As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	'참고: 다음 프로시저는 Windows Form 디자이너에 필요합니다.
	'Windows Form 디자이너를 사용하여 수정할 수 있습니다.
	'코드 편집기를 사용하여 수정하지 마십시오.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.tmStatusView = New System.Windows.Forms.Timer(Me.components)
        Me.btnCur = New System.Windows.Forms.Button
        Me.btnNext = New System.Windows.Forms.Button
        Me.btnPrev = New System.Windows.Forms.Button
        Me.frmAxisY = New System.Windows.Forms.GroupBox
        Me.Frame1 = New System.Windows.Forms.GroupBox
        Me.LedYDRS09 = New System.Windows.Forms.PictureBox
        Me.LedYDRS10 = New System.Windows.Forms.PictureBox
        Me.LedYDRS07 = New System.Windows.Forms.PictureBox
        Me.LedYDRS06 = New System.Windows.Forms.PictureBox
        Me.LedYDRS05 = New System.Windows.Forms.PictureBox
        Me.LedYDRS04 = New System.Windows.Forms.PictureBox
        Me.LedYDRS03 = New System.Windows.Forms.PictureBox
        Me.LedYDRS02 = New System.Windows.Forms.PictureBox
        Me.LedYDRS01 = New System.Windows.Forms.PictureBox
        Me.LedYDRS00 = New System.Windows.Forms.PictureBox
        Me.Label69 = New System.Windows.Forms.Label
        Me.Label70 = New System.Windows.Forms.Label
        Me.Label67 = New System.Windows.Forms.Label
        Me.Label66 = New System.Windows.Forms.Label
        Me.Label65 = New System.Windows.Forms.Label
        Me.Label64 = New System.Windows.Forms.Label
        Me.Label63 = New System.Windows.Forms.Label
        Me.Label62 = New System.Windows.Forms.Label
        Me.Label61 = New System.Windows.Forms.Label
        Me.Label60 = New System.Windows.Forms.Label
        Me.Frame2 = New System.Windows.Forms.GroupBox
        Me.LedYENS16 = New System.Windows.Forms.PictureBox
        Me.LedYENS30 = New System.Windows.Forms.PictureBox
        Me.LedYENS31 = New System.Windows.Forms.PictureBox
        Me.LedYENS08 = New System.Windows.Forms.PictureBox
        Me.LedYENS09 = New System.Windows.Forms.PictureBox
        Me.LedYENS10 = New System.Windows.Forms.PictureBox
        Me.LedYENS11 = New System.Windows.Forms.PictureBox
        Me.LedYENS12 = New System.Windows.Forms.PictureBox
        Me.LedYENS13 = New System.Windows.Forms.PictureBox
        Me.LedYENS14 = New System.Windows.Forms.PictureBox
        Me.LedYENS15 = New System.Windows.Forms.PictureBox
        Me.LedYENS07 = New System.Windows.Forms.PictureBox
        Me.LedYENS06 = New System.Windows.Forms.PictureBox
        Me.LedYENS05 = New System.Windows.Forms.PictureBox
        Me.LedYENS04 = New System.Windows.Forms.PictureBox
        Me.LedYENS03 = New System.Windows.Forms.PictureBox
        Me.LedYENS02 = New System.Windows.Forms.PictureBox
        Me.LedYENS01 = New System.Windows.Forms.PictureBox
        Me.LedYENS00 = New System.Windows.Forms.PictureBox
        Me.Label58 = New System.Windows.Forms.Label
        Me.Label57 = New System.Windows.Forms.Label
        Me.Label56 = New System.Windows.Forms.Label
        Me.Label55 = New System.Windows.Forms.Label
        Me.Label54 = New System.Windows.Forms.Label
        Me.Label53 = New System.Windows.Forms.Label
        Me.Label52 = New System.Windows.Forms.Label
        Me.Label51 = New System.Windows.Forms.Label
        Me.Label50 = New System.Windows.Forms.Label
        Me.Label49 = New System.Windows.Forms.Label
        Me.Label48 = New System.Windows.Forms.Label
        Me._lblAxis_1 = New System.Windows.Forms.Label
        Me.Label47 = New System.Windows.Forms.Label
        Me.Label46 = New System.Windows.Forms.Label
        Me.Label45 = New System.Windows.Forms.Label
        Me.Label44 = New System.Windows.Forms.Label
        Me.Label43 = New System.Windows.Forms.Label
        Me.Label42 = New System.Windows.Forms.Label
        Me.Label41 = New System.Windows.Forms.Label
        Me.Label40 = New System.Windows.Forms.Label
        Me.frmAxisX = New System.Windows.Forms.GroupBox
        Me.Frame6 = New System.Windows.Forms.GroupBox
        Me.LedXDRS00 = New System.Windows.Forms.PictureBox
        Me.LedXDRS01 = New System.Windows.Forms.PictureBox
        Me.LedXDRS02 = New System.Windows.Forms.PictureBox
        Me.LedXDRS03 = New System.Windows.Forms.PictureBox
        Me.LedXDRS04 = New System.Windows.Forms.PictureBox
        Me.LedXDRS05 = New System.Windows.Forms.PictureBox
        Me.LedXDRS06 = New System.Windows.Forms.PictureBox
        Me.LedXDRS07 = New System.Windows.Forms.PictureBox
        Me.LedXDRS10 = New System.Windows.Forms.PictureBox
        Me.LedXDRS09 = New System.Windows.Forms.PictureBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label33 = New System.Windows.Forms.Label
        Me.Label34 = New System.Windows.Forms.Label
        Me.Frame3 = New System.Windows.Forms.GroupBox
        Me.LedXENS00 = New System.Windows.Forms.PictureBox
        Me.LedXENS01 = New System.Windows.Forms.PictureBox
        Me.LedXENS02 = New System.Windows.Forms.PictureBox
        Me.LedXENS03 = New System.Windows.Forms.PictureBox
        Me.LedXENS04 = New System.Windows.Forms.PictureBox
        Me.LedXENS05 = New System.Windows.Forms.PictureBox
        Me.LedXENS06 = New System.Windows.Forms.PictureBox
        Me.LedXENS07 = New System.Windows.Forms.PictureBox
        Me.LedXENS15 = New System.Windows.Forms.PictureBox
        Me.LedXENS14 = New System.Windows.Forms.PictureBox
        Me.LedXENS13 = New System.Windows.Forms.PictureBox
        Me.LedXENS12 = New System.Windows.Forms.PictureBox
        Me.LedXENS11 = New System.Windows.Forms.PictureBox
        Me.LedXENS10 = New System.Windows.Forms.PictureBox
        Me.LedXENS09 = New System.Windows.Forms.PictureBox
        Me.LedXENS08 = New System.Windows.Forms.PictureBox
        Me.LedXENS31 = New System.Windows.Forms.PictureBox
        Me.LedXENS30 = New System.Windows.Forms.PictureBox
        Me.LedXENS16 = New System.Windows.Forms.PictureBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label27 = New System.Windows.Forms.Label
        Me.Label28 = New System.Windows.Forms.Label
        Me.Label29 = New System.Windows.Forms.Label
        Me.Label30 = New System.Windows.Forms.Label
        Me.Label31 = New System.Windows.Forms.Label
        Me.Label32 = New System.Windows.Forms.Label
        Me._lblAxis_0 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label37 = New System.Windows.Forms.Label
        Me.Label38 = New System.Windows.Forms.Label
        Me.Label39 = New System.Windows.Forms.Label
        Me.lblAxis = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.frmAxisY.SuspendLayout()
        Me.Frame1.SuspendLayout()
        CType(Me.LedYDRS09, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LedYDRS10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LedYDRS07, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LedYDRS06, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LedYDRS05, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LedYDRS04, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LedYDRS03, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LedYDRS02, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LedYDRS01, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LedYDRS00, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Frame2.SuspendLayout()
        CType(Me.LedYENS16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LedYENS30, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LedYENS31, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LedYENS08, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LedYENS09, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LedYENS10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LedYENS11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LedYENS12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LedYENS13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LedYENS14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LedYENS15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LedYENS07, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LedYENS06, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LedYENS05, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LedYENS04, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LedYENS03, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LedYENS02, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LedYENS01, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LedYENS00, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.frmAxisX.SuspendLayout()
        Me.Frame6.SuspendLayout()
        CType(Me.LedXDRS00, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LedXDRS01, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LedXDRS02, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LedXDRS03, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LedXDRS04, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LedXDRS05, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LedXDRS06, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LedXDRS07, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LedXDRS10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LedXDRS09, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Frame3.SuspendLayout()
        CType(Me.LedXENS00, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LedXENS01, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LedXENS02, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LedXENS03, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LedXENS04, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LedXENS05, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LedXENS06, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LedXENS07, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LedXENS15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LedXENS14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LedXENS13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LedXENS12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LedXENS11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LedXENS10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LedXENS09, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LedXENS08, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LedXENS31, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LedXENS30, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LedXENS16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblAxis, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tmStatusView
        '
        Me.tmStatusView.Enabled = True
        '
        'btnCur
        '
        Me.btnCur.BackColor = System.Drawing.SystemColors.Control
        Me.btnCur.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnCur.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnCur.Location = New System.Drawing.Point(411, 8)
        Me.btnCur.Name = "btnCur"
        Me.btnCur.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnCur.Size = New System.Drawing.Size(17, 15)
        Me.btnCur.TabIndex = 126
        Me.btnCur.Text = "Ⅱ"
        Me.btnCur.UseVisualStyleBackColor = False
        '
        'btnNext
        '
        Me.btnNext.BackColor = System.Drawing.SystemColors.Control
        Me.btnNext.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnNext.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnNext.Location = New System.Drawing.Point(429, 8)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnNext.Size = New System.Drawing.Size(27, 15)
        Me.btnNext.TabIndex = 125
        Me.btnNext.Text = ">>"
        Me.btnNext.UseVisualStyleBackColor = False
        '
        'btnPrev
        '
        Me.btnPrev.BackColor = System.Drawing.SystemColors.Control
        Me.btnPrev.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnPrev.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnPrev.Location = New System.Drawing.Point(383, 8)
        Me.btnPrev.Name = "btnPrev"
        Me.btnPrev.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnPrev.Size = New System.Drawing.Size(27, 15)
        Me.btnPrev.TabIndex = 124
        Me.btnPrev.Text = "<<"
        Me.btnPrev.UseVisualStyleBackColor = False
        '
        'frmAxisY
        '
        Me.frmAxisY.BackColor = System.Drawing.SystemColors.Control
        Me.frmAxisY.Controls.Add(Me.Frame1)
        Me.frmAxisY.Controls.Add(Me.Frame2)
        Me.frmAxisY.ForeColor = System.Drawing.SystemColors.ControlText
        Me.frmAxisY.Location = New System.Drawing.Point(240, 16)
        Me.frmAxisY.Name = "frmAxisY"
        Me.frmAxisY.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.frmAxisY.Size = New System.Drawing.Size(217, 614)
        Me.frmAxisY.TabIndex = 62
        Me.frmAxisY.TabStop = False
        Me.frmAxisY.Text = "Y Axis: 00"
        '
        'Frame1
        '
        Me.Frame1.BackColor = System.Drawing.SystemColors.Control
        Me.Frame1.Controls.Add(Me.LedYDRS09)
        Me.Frame1.Controls.Add(Me.LedYDRS10)
        Me.Frame1.Controls.Add(Me.LedYDRS07)
        Me.Frame1.Controls.Add(Me.LedYDRS06)
        Me.Frame1.Controls.Add(Me.LedYDRS05)
        Me.Frame1.Controls.Add(Me.LedYDRS04)
        Me.Frame1.Controls.Add(Me.LedYDRS03)
        Me.Frame1.Controls.Add(Me.LedYDRS02)
        Me.Frame1.Controls.Add(Me.LedYDRS01)
        Me.Frame1.Controls.Add(Me.LedYDRS00)
        Me.Frame1.Controls.Add(Me.Label69)
        Me.Frame1.Controls.Add(Me.Label70)
        Me.Frame1.Controls.Add(Me.Label67)
        Me.Frame1.Controls.Add(Me.Label66)
        Me.Frame1.Controls.Add(Me.Label65)
        Me.Frame1.Controls.Add(Me.Label64)
        Me.Frame1.Controls.Add(Me.Label63)
        Me.Frame1.Controls.Add(Me.Label62)
        Me.Frame1.Controls.Add(Me.Label61)
        Me.Frame1.Controls.Add(Me.Label60)
        Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame1.Location = New System.Drawing.Point(0, 400)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(205, 213)
        Me.Frame1.TabIndex = 103
        Me.Frame1.TabStop = False
        Me.Frame1.Text = "Drive Status"
        '
        'LedYDRS09
        '
        Me.LedYDRS09.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LedYDRS09.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LedYDRS09.Cursor = System.Windows.Forms.Cursors.Default
        Me.LedYDRS09.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LedYDRS09.Location = New System.Drawing.Point(8, 35)
        Me.LedYDRS09.Name = "LedYDRS09"
        Me.LedYDRS09.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LedYDRS09.Size = New System.Drawing.Size(20, 18)
        Me.LedYDRS09.TabIndex = 113
        '
        'LedYDRS10
        '
        Me.LedYDRS10.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LedYDRS10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LedYDRS10.Cursor = System.Windows.Forms.Cursors.Default
        Me.LedYDRS10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LedYDRS10.Location = New System.Drawing.Point(8, 16)
        Me.LedYDRS10.Name = "LedYDRS10"
        Me.LedYDRS10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LedYDRS10.Size = New System.Drawing.Size(20, 18)
        Me.LedYDRS10.TabIndex = 112
        '
        'LedYDRS07
        '
        Me.LedYDRS07.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LedYDRS07.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LedYDRS07.Cursor = System.Windows.Forms.Cursors.Default
        Me.LedYDRS07.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LedYDRS07.Location = New System.Drawing.Point(8, 54)
        Me.LedYDRS07.Name = "LedYDRS07"
        Me.LedYDRS07.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LedYDRS07.Size = New System.Drawing.Size(20, 18)
        Me.LedYDRS07.TabIndex = 111
        '
        'LedYDRS06
        '
        Me.LedYDRS06.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LedYDRS06.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LedYDRS06.Cursor = System.Windows.Forms.Cursors.Default
        Me.LedYDRS06.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LedYDRS06.Location = New System.Drawing.Point(8, 72)
        Me.LedYDRS06.Name = "LedYDRS06"
        Me.LedYDRS06.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LedYDRS06.Size = New System.Drawing.Size(20, 18)
        Me.LedYDRS06.TabIndex = 110
        '
        'LedYDRS05
        '
        Me.LedYDRS05.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LedYDRS05.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LedYDRS05.Cursor = System.Windows.Forms.Cursors.Default
        Me.LedYDRS05.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LedYDRS05.Location = New System.Drawing.Point(8, 91)
        Me.LedYDRS05.Name = "LedYDRS05"
        Me.LedYDRS05.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LedYDRS05.Size = New System.Drawing.Size(20, 18)
        Me.LedYDRS05.TabIndex = 109
        '
        'LedYDRS04
        '
        Me.LedYDRS04.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LedYDRS04.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LedYDRS04.Cursor = System.Windows.Forms.Cursors.Default
        Me.LedYDRS04.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LedYDRS04.Location = New System.Drawing.Point(8, 110)
        Me.LedYDRS04.Name = "LedYDRS04"
        Me.LedYDRS04.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LedYDRS04.Size = New System.Drawing.Size(20, 18)
        Me.LedYDRS04.TabIndex = 108
        '
        'LedYDRS03
        '
        Me.LedYDRS03.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LedYDRS03.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LedYDRS03.Cursor = System.Windows.Forms.Cursors.Default
        Me.LedYDRS03.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LedYDRS03.Location = New System.Drawing.Point(8, 128)
        Me.LedYDRS03.Name = "LedYDRS03"
        Me.LedYDRS03.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LedYDRS03.Size = New System.Drawing.Size(20, 18)
        Me.LedYDRS03.TabIndex = 107
        '
        'LedYDRS02
        '
        Me.LedYDRS02.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LedYDRS02.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LedYDRS02.Cursor = System.Windows.Forms.Cursors.Default
        Me.LedYDRS02.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LedYDRS02.Location = New System.Drawing.Point(8, 147)
        Me.LedYDRS02.Name = "LedYDRS02"
        Me.LedYDRS02.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LedYDRS02.Size = New System.Drawing.Size(20, 18)
        Me.LedYDRS02.TabIndex = 106
        '
        'LedYDRS01
        '
        Me.LedYDRS01.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LedYDRS01.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LedYDRS01.Cursor = System.Windows.Forms.Cursors.Default
        Me.LedYDRS01.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LedYDRS01.Location = New System.Drawing.Point(8, 167)
        Me.LedYDRS01.Name = "LedYDRS01"
        Me.LedYDRS01.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LedYDRS01.Size = New System.Drawing.Size(20, 18)
        Me.LedYDRS01.TabIndex = 105
        '
        'LedYDRS00
        '
        Me.LedYDRS00.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LedYDRS00.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LedYDRS00.Cursor = System.Windows.Forms.Cursors.Default
        Me.LedYDRS00.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LedYDRS00.Location = New System.Drawing.Point(8, 186)
        Me.LedYDRS00.Name = "LedYDRS00"
        Me.LedYDRS00.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LedYDRS00.Size = New System.Drawing.Size(20, 18)
        Me.LedYDRS00.TabIndex = 104
        '
        'Label69
        '
        Me.Label69.BackColor = System.Drawing.SystemColors.Control
        Me.Label69.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label69.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label69.Location = New System.Drawing.Point(32, 35)
        Me.Label69.Name = "Label69"
        Me.Label69.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label69.Size = New System.Drawing.Size(167, 18)
        Me.Label69.TabIndex = 123
        Me.Label69.Text = "9bit : INP BUSY"
        '
        'Label70
        '
        Me.Label70.BackColor = System.Drawing.SystemColors.Control
        Me.Label70.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label70.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label70.Location = New System.Drawing.Point(32, 16)
        Me.Label70.Name = "Label70"
        Me.Label70.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label70.Size = New System.Drawing.Size(167, 18)
        Me.Label70.TabIndex = 122
        Me.Label70.Text = "10bit : SLAVE BUSY"
        '
        'Label67
        '
        Me.Label67.BackColor = System.Drawing.SystemColors.Control
        Me.Label67.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label67.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label67.Location = New System.Drawing.Point(32, 54)
        Me.Label67.Name = "Label67"
        Me.Label67.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label67.Size = New System.Drawing.Size(167, 18)
        Me.Label67.TabIndex = 121
        Me.Label67.Text = "7bit : ORG BUSY"
        '
        'Label66
        '
        Me.Label66.BackColor = System.Drawing.SystemColors.Control
        Me.Label66.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label66.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label66.Location = New System.Drawing.Point(32, 72)
        Me.Label66.Name = "Label66"
        Me.Label66.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label66.Size = New System.Drawing.Size(167, 18)
        Me.Label66.TabIndex = 120
        Me.Label66.Text = "6bit : MPG BUSY"
        '
        'Label65
        '
        Me.Label65.BackColor = System.Drawing.SystemColors.Control
        Me.Label65.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label65.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label65.Location = New System.Drawing.Point(32, 91)
        Me.Label65.Name = "Label65"
        Me.Label65.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label65.Size = New System.Drawing.Size(167, 18)
        Me.Label65.TabIndex = 119
        Me.Label65.Text = "5bit : PRESET BUSY"
        '
        'Label64
        '
        Me.Label64.BackColor = System.Drawing.SystemColors.Control
        Me.Label64.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label64.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label64.Location = New System.Drawing.Point(32, 110)
        Me.Label64.Name = "Label64"
        Me.Label64.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label64.Size = New System.Drawing.Size(167, 18)
        Me.Label64.TabIndex = 118
        Me.Label64.Text = "4bit : CONTI BUSY"
        '
        'Label63
        '
        Me.Label63.BackColor = System.Drawing.SystemColors.Control
        Me.Label63.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label63.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label63.Location = New System.Drawing.Point(32, 128)
        Me.Label63.Name = "Label63"
        Me.Label63.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label63.Size = New System.Drawing.Size(167, 18)
        Me.Label63.TabIndex = 117
        Me.Label63.Text = "3bit : UP"
        '
        'Label62
        '
        Me.Label62.BackColor = System.Drawing.SystemColors.Control
        Me.Label62.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label62.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label62.Location = New System.Drawing.Point(32, 147)
        Me.Label62.Name = "Label62"
        Me.Label62.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label62.Size = New System.Drawing.Size(167, 18)
        Me.Label62.TabIndex = 116
        Me.Label62.Text = "2bit : CONST"
        '
        'Label61
        '
        Me.Label61.BackColor = System.Drawing.SystemColors.Control
        Me.Label61.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label61.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label61.Location = New System.Drawing.Point(32, 167)
        Me.Label61.Name = "Label61"
        Me.Label61.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label61.Size = New System.Drawing.Size(167, 18)
        Me.Label61.TabIndex = 115
        Me.Label61.Text = "1bit : DOWN"
        '
        'Label60
        '
        Me.Label60.BackColor = System.Drawing.SystemColors.Control
        Me.Label60.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label60.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label60.Location = New System.Drawing.Point(32, 186)
        Me.Label60.Name = "Label60"
        Me.Label60.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label60.Size = New System.Drawing.Size(167, 18)
        Me.Label60.TabIndex = 114
        Me.Label60.Text = "0bit : BUSY"
        '
        'Frame2
        '
        Me.Frame2.BackColor = System.Drawing.SystemColors.Control
        Me.Frame2.Controls.Add(Me.LedYENS16)
        Me.Frame2.Controls.Add(Me.LedYENS30)
        Me.Frame2.Controls.Add(Me.LedYENS31)
        Me.Frame2.Controls.Add(Me.LedYENS08)
        Me.Frame2.Controls.Add(Me.LedYENS09)
        Me.Frame2.Controls.Add(Me.LedYENS10)
        Me.Frame2.Controls.Add(Me.LedYENS11)
        Me.Frame2.Controls.Add(Me.LedYENS12)
        Me.Frame2.Controls.Add(Me.LedYENS13)
        Me.Frame2.Controls.Add(Me.LedYENS14)
        Me.Frame2.Controls.Add(Me.LedYENS15)
        Me.Frame2.Controls.Add(Me.LedYENS07)
        Me.Frame2.Controls.Add(Me.LedYENS06)
        Me.Frame2.Controls.Add(Me.LedYENS05)
        Me.Frame2.Controls.Add(Me.LedYENS04)
        Me.Frame2.Controls.Add(Me.LedYENS03)
        Me.Frame2.Controls.Add(Me.LedYENS02)
        Me.Frame2.Controls.Add(Me.LedYENS01)
        Me.Frame2.Controls.Add(Me.LedYENS00)
        Me.Frame2.Controls.Add(Me.Label58)
        Me.Frame2.Controls.Add(Me.Label57)
        Me.Frame2.Controls.Add(Me.Label56)
        Me.Frame2.Controls.Add(Me.Label55)
        Me.Frame2.Controls.Add(Me.Label54)
        Me.Frame2.Controls.Add(Me.Label53)
        Me.Frame2.Controls.Add(Me.Label52)
        Me.Frame2.Controls.Add(Me.Label51)
        Me.Frame2.Controls.Add(Me.Label50)
        Me.Frame2.Controls.Add(Me.Label49)
        Me.Frame2.Controls.Add(Me.Label48)
        Me.Frame2.Controls.Add(Me._lblAxis_1)
        Me.Frame2.Controls.Add(Me.Label47)
        Me.Frame2.Controls.Add(Me.Label46)
        Me.Frame2.Controls.Add(Me.Label45)
        Me.Frame2.Controls.Add(Me.Label44)
        Me.Frame2.Controls.Add(Me.Label43)
        Me.Frame2.Controls.Add(Me.Label42)
        Me.Frame2.Controls.Add(Me.Label41)
        Me.Frame2.Controls.Add(Me.Label40)
        Me.Frame2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame2.Location = New System.Drawing.Point(0, 16)
        Me.Frame2.Name = "Frame2"
        Me.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame2.Size = New System.Drawing.Size(205, 375)
        Me.Frame2.TabIndex = 63
        Me.Frame2.TabStop = False
        Me.Frame2.Text = "End Status"
        '
        'LedYENS16
        '
        Me.LedYENS16.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LedYENS16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LedYENS16.Cursor = System.Windows.Forms.Cursors.Default
        Me.LedYENS16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LedYENS16.Location = New System.Drawing.Point(8, 54)
        Me.LedYENS16.Name = "LedYENS16"
        Me.LedYENS16.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LedYENS16.Size = New System.Drawing.Size(20, 18)
        Me.LedYENS16.TabIndex = 82
        '
        'LedYENS30
        '
        Me.LedYENS30.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LedYENS30.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LedYENS30.Cursor = System.Windows.Forms.Cursors.Default
        Me.LedYENS30.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LedYENS30.Location = New System.Drawing.Point(8, 35)
        Me.LedYENS30.Name = "LedYENS30"
        Me.LedYENS30.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LedYENS30.Size = New System.Drawing.Size(20, 18)
        Me.LedYENS30.TabIndex = 81
        '
        'LedYENS31
        '
        Me.LedYENS31.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LedYENS31.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LedYENS31.Cursor = System.Windows.Forms.Cursors.Default
        Me.LedYENS31.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LedYENS31.Location = New System.Drawing.Point(8, 16)
        Me.LedYENS31.Name = "LedYENS31"
        Me.LedYENS31.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LedYENS31.Size = New System.Drawing.Size(20, 18)
        Me.LedYENS31.TabIndex = 80
        '
        'LedYENS08
        '
        Me.LedYENS08.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LedYENS08.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LedYENS08.Cursor = System.Windows.Forms.Cursors.Default
        Me.LedYENS08.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LedYENS08.Location = New System.Drawing.Point(8, 204)
        Me.LedYENS08.Name = "LedYENS08"
        Me.LedYENS08.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LedYENS08.Size = New System.Drawing.Size(20, 18)
        Me.LedYENS08.TabIndex = 79
        '
        'LedYENS09
        '
        Me.LedYENS09.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LedYENS09.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LedYENS09.Cursor = System.Windows.Forms.Cursors.Default
        Me.LedYENS09.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LedYENS09.Location = New System.Drawing.Point(8, 186)
        Me.LedYENS09.Name = "LedYENS09"
        Me.LedYENS09.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LedYENS09.Size = New System.Drawing.Size(20, 18)
        Me.LedYENS09.TabIndex = 78
        '
        'LedYENS10
        '
        Me.LedYENS10.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LedYENS10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LedYENS10.Cursor = System.Windows.Forms.Cursors.Default
        Me.LedYENS10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LedYENS10.Location = New System.Drawing.Point(8, 167)
        Me.LedYENS10.Name = "LedYENS10"
        Me.LedYENS10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LedYENS10.Size = New System.Drawing.Size(20, 18)
        Me.LedYENS10.TabIndex = 77
        '
        'LedYENS11
        '
        Me.LedYENS11.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LedYENS11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LedYENS11.Cursor = System.Windows.Forms.Cursors.Default
        Me.LedYENS11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LedYENS11.Location = New System.Drawing.Point(8, 147)
        Me.LedYENS11.Name = "LedYENS11"
        Me.LedYENS11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LedYENS11.Size = New System.Drawing.Size(20, 18)
        Me.LedYENS11.TabIndex = 76
        '
        'LedYENS12
        '
        Me.LedYENS12.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LedYENS12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LedYENS12.Cursor = System.Windows.Forms.Cursors.Default
        Me.LedYENS12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LedYENS12.Location = New System.Drawing.Point(8, 128)
        Me.LedYENS12.Name = "LedYENS12"
        Me.LedYENS12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LedYENS12.Size = New System.Drawing.Size(20, 18)
        Me.LedYENS12.TabIndex = 75
        '
        'LedYENS13
        '
        Me.LedYENS13.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LedYENS13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LedYENS13.Cursor = System.Windows.Forms.Cursors.Default
        Me.LedYENS13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LedYENS13.Location = New System.Drawing.Point(8, 110)
        Me.LedYENS13.Name = "LedYENS13"
        Me.LedYENS13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LedYENS13.Size = New System.Drawing.Size(20, 18)
        Me.LedYENS13.TabIndex = 74
        '
        'LedYENS14
        '
        Me.LedYENS14.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LedYENS14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LedYENS14.Cursor = System.Windows.Forms.Cursors.Default
        Me.LedYENS14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LedYENS14.Location = New System.Drawing.Point(8, 91)
        Me.LedYENS14.Name = "LedYENS14"
        Me.LedYENS14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LedYENS14.Size = New System.Drawing.Size(20, 18)
        Me.LedYENS14.TabIndex = 73
        '
        'LedYENS15
        '
        Me.LedYENS15.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LedYENS15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LedYENS15.Cursor = System.Windows.Forms.Cursors.Default
        Me.LedYENS15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LedYENS15.Location = New System.Drawing.Point(8, 72)
        Me.LedYENS15.Name = "LedYENS15"
        Me.LedYENS15.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LedYENS15.Size = New System.Drawing.Size(20, 18)
        Me.LedYENS15.TabIndex = 72
        '
        'LedYENS07
        '
        Me.LedYENS07.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LedYENS07.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LedYENS07.Cursor = System.Windows.Forms.Cursors.Default
        Me.LedYENS07.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LedYENS07.Location = New System.Drawing.Point(8, 223)
        Me.LedYENS07.Name = "LedYENS07"
        Me.LedYENS07.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LedYENS07.Size = New System.Drawing.Size(20, 18)
        Me.LedYENS07.TabIndex = 71
        '
        'LedYENS06
        '
        Me.LedYENS06.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LedYENS06.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LedYENS06.Cursor = System.Windows.Forms.Cursors.Default
        Me.LedYENS06.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LedYENS06.Location = New System.Drawing.Point(8, 242)
        Me.LedYENS06.Name = "LedYENS06"
        Me.LedYENS06.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LedYENS06.Size = New System.Drawing.Size(20, 18)
        Me.LedYENS06.TabIndex = 70
        '
        'LedYENS05
        '
        Me.LedYENS05.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LedYENS05.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LedYENS05.Cursor = System.Windows.Forms.Cursors.Default
        Me.LedYENS05.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LedYENS05.Location = New System.Drawing.Point(8, 260)
        Me.LedYENS05.Name = "LedYENS05"
        Me.LedYENS05.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LedYENS05.Size = New System.Drawing.Size(20, 18)
        Me.LedYENS05.TabIndex = 69
        '
        'LedYENS04
        '
        Me.LedYENS04.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LedYENS04.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LedYENS04.Cursor = System.Windows.Forms.Cursors.Default
        Me.LedYENS04.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LedYENS04.Location = New System.Drawing.Point(8, 279)
        Me.LedYENS04.Name = "LedYENS04"
        Me.LedYENS04.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LedYENS04.Size = New System.Drawing.Size(20, 18)
        Me.LedYENS04.TabIndex = 68
        '
        'LedYENS03
        '
        Me.LedYENS03.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LedYENS03.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LedYENS03.Cursor = System.Windows.Forms.Cursors.Default
        Me.LedYENS03.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LedYENS03.Location = New System.Drawing.Point(8, 298)
        Me.LedYENS03.Name = "LedYENS03"
        Me.LedYENS03.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LedYENS03.Size = New System.Drawing.Size(20, 18)
        Me.LedYENS03.TabIndex = 67
        '
        'LedYENS02
        '
        Me.LedYENS02.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LedYENS02.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LedYENS02.Cursor = System.Windows.Forms.Cursors.Default
        Me.LedYENS02.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LedYENS02.Location = New System.Drawing.Point(8, 316)
        Me.LedYENS02.Name = "LedYENS02"
        Me.LedYENS02.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LedYENS02.Size = New System.Drawing.Size(20, 18)
        Me.LedYENS02.TabIndex = 66
        '
        'LedYENS01
        '
        Me.LedYENS01.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LedYENS01.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LedYENS01.Cursor = System.Windows.Forms.Cursors.Default
        Me.LedYENS01.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LedYENS01.Location = New System.Drawing.Point(8, 335)
        Me.LedYENS01.Name = "LedYENS01"
        Me.LedYENS01.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LedYENS01.Size = New System.Drawing.Size(20, 18)
        Me.LedYENS01.TabIndex = 65
        '
        'LedYENS00
        '
        Me.LedYENS00.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LedYENS00.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LedYENS00.Cursor = System.Windows.Forms.Cursors.Default
        Me.LedYENS00.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LedYENS00.Location = New System.Drawing.Point(8, 354)
        Me.LedYENS00.Name = "LedYENS00"
        Me.LedYENS00.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LedYENS00.Size = New System.Drawing.Size(20, 18)
        Me.LedYENS00.TabIndex = 64
        '
        'Label58
        '
        Me.Label58.BackColor = System.Drawing.SystemColors.Control
        Me.Label58.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label58.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label58.Location = New System.Drawing.Point(32, 54)
        Me.Label58.Name = "Label58"
        Me.Label58.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label58.Size = New System.Drawing.Size(167, 18)
        Me.Label58.TabIndex = 102
        Me.Label58.Text = "16bit : MPGERR stopped"
        '
        'Label57
        '
        Me.Label57.BackColor = System.Drawing.SystemColors.Control
        Me.Label57.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label57.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label57.Location = New System.Drawing.Point(32, 35)
        Me.Label57.Name = "Label57"
        Me.Label57.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label57.Size = New System.Drawing.Size(167, 18)
        Me.Label57.TabIndex = 101
        Me.Label57.Text = "30bit : ERRSTATE"
        '
        'Label56
        '
        Me.Label56.BackColor = System.Drawing.SystemColors.Control
        Me.Label56.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label56.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label56.Location = New System.Drawing.Point(32, 16)
        Me.Label56.Name = "Label56"
        Me.Label56.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label56.Size = New System.Drawing.Size(167, 18)
        Me.Label56.TabIndex = 100
        Me.Label56.Text = "31bit : INPERR"
        '
        'Label55
        '
        Me.Label55.BackColor = System.Drawing.SystemColors.Control
        Me.Label55.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label55.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label55.Location = New System.Drawing.Point(32, 204)
        Me.Label55.Name = "Label55"
        Me.Label55.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label55.Size = New System.Drawing.Size(167, 18)
        Me.Label55.TabIndex = 99
        Me.Label55.Text = "8bit : SVALARM stopped"
        '
        'Label54
        '
        Me.Label54.BackColor = System.Drawing.SystemColors.Control
        Me.Label54.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label54.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label54.Location = New System.Drawing.Point(32, 186)
        Me.Label54.Name = "Label54"
        Me.Label54.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label54.Size = New System.Drawing.Size(167, 18)
        Me.Label54.TabIndex = 98
        Me.Label54.Text = "9bit : ESTOP stopped"
        '
        'Label53
        '
        Me.Label53.BackColor = System.Drawing.SystemColors.Control
        Me.Label53.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label53.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label53.Location = New System.Drawing.Point(32, 167)
        Me.Label53.Name = "Label53"
        Me.Label53.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label53.Size = New System.Drawing.Size(167, 18)
        Me.Label53.TabIndex = 97
        Me.Label53.Text = "10bit : ESTOPCMD stopped"
        '
        'Label52
        '
        Me.Label52.BackColor = System.Drawing.SystemColors.Control
        Me.Label52.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label52.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label52.Location = New System.Drawing.Point(32, 147)
        Me.Label52.Name = "Label52"
        Me.Label52.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label52.Size = New System.Drawing.Size(167, 18)
        Me.Label52.TabIndex = 96
        Me.Label52.Text = "11bit : SSTOPCMD stopped"
        '
        'Label51
        '
        Me.Label51.BackColor = System.Drawing.SystemColors.Control
        Me.Label51.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label51.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label51.Location = New System.Drawing.Point(32, 128)
        Me.Label51.Name = "Label51"
        Me.Label51.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label51.Size = New System.Drawing.Size(167, 18)
        Me.Label51.TabIndex = 95
        Me.Label51.Text = "12bit : ESTOPALL stopped"
        '
        'Label50
        '
        Me.Label50.BackColor = System.Drawing.SystemColors.Control
        Me.Label50.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label50.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label50.Location = New System.Drawing.Point(32, 110)
        Me.Label50.Name = "Label50"
        Me.Label50.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label50.Size = New System.Drawing.Size(167, 18)
        Me.Label50.TabIndex = 94
        Me.Label50.Text = "13bit : SQSTP#1 stopped"
        '
        'Label49
        '
        Me.Label49.BackColor = System.Drawing.SystemColors.Control
        Me.Label49.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label49.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label49.Location = New System.Drawing.Point(32, 91)
        Me.Label49.Name = "Label49"
        Me.Label49.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label49.Size = New System.Drawing.Size(167, 18)
        Me.Label49.TabIndex = 93
        Me.Label49.Text = "14bit : SQSTP#2 stopped"
        '
        'Label48
        '
        Me.Label48.BackColor = System.Drawing.SystemColors.Control
        Me.Label48.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label48.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label48.Location = New System.Drawing.Point(32, 72)
        Me.Label48.Name = "Label48"
        Me.Label48.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label48.Size = New System.Drawing.Size(167, 18)
        Me.Label48.TabIndex = 92
        Me.Label48.Text = "15bit : ENCERR"
        '
        '_lblAxis_1
        '
        Me._lblAxis_1.AutoSize = True
        Me._lblAxis_1.BackColor = System.Drawing.SystemColors.Control
        Me._lblAxis_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblAxis_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblAxis.SetIndex(Me._lblAxis_1, CType(1, Short))
        Me._lblAxis_1.Location = New System.Drawing.Point(312, 0)
        Me._lblAxis_1.Name = "_lblAxis_1"
        Me._lblAxis_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblAxis_1.Size = New System.Drawing.Size(48, 12)
        Me._lblAxis_1.TabIndex = 91
        Me._lblAxis_1.Text = "Label33"
        Me._lblAxis_1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label47
        '
        Me.Label47.BackColor = System.Drawing.SystemColors.Control
        Me.Label47.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label47.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label47.Location = New System.Drawing.Point(32, 223)
        Me.Label47.Name = "Label47"
        Me.Label47.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label47.Size = New System.Drawing.Size(167, 18)
        Me.Label47.TabIndex = 90
        Me.Label47.Text = "7bit : NSWSLMT stopped"
        '
        'Label46
        '
        Me.Label46.BackColor = System.Drawing.SystemColors.Control
        Me.Label46.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label46.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label46.Location = New System.Drawing.Point(32, 242)
        Me.Label46.Name = "Label46"
        Me.Label46.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label46.Size = New System.Drawing.Size(167, 18)
        Me.Label46.TabIndex = 89
        Me.Label46.Text = "6bit : PSWSLMT stopped"
        '
        'Label45
        '
        Me.Label45.BackColor = System.Drawing.SystemColors.Control
        Me.Label45.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label45.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label45.Location = New System.Drawing.Point(32, 260)
        Me.Label45.Name = "Label45"
        Me.Label45.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label45.Size = New System.Drawing.Size(167, 18)
        Me.Label45.TabIndex = 88
        Me.Label45.Text = "5bit : NSWLMT stopped"
        '
        'Label44
        '
        Me.Label44.BackColor = System.Drawing.SystemColors.Control
        Me.Label44.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label44.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label44.Location = New System.Drawing.Point(32, 279)
        Me.Label44.Name = "Label44"
        Me.Label44.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label44.Size = New System.Drawing.Size(167, 18)
        Me.Label44.TabIndex = 87
        Me.Label44.Text = "4bit : PSWLMT stopped"
        '
        'Label43
        '
        Me.Label43.BackColor = System.Drawing.SystemColors.Control
        Me.Label43.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label43.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label43.Location = New System.Drawing.Point(32, 298)
        Me.Label43.Name = "Label43"
        Me.Label43.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label43.Size = New System.Drawing.Size(167, 18)
        Me.Label43.TabIndex = 86
        Me.Label43.Text = "3bit : NSLM stopped"
        '
        'Label42
        '
        Me.Label42.BackColor = System.Drawing.SystemColors.Control
        Me.Label42.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label42.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label42.Location = New System.Drawing.Point(32, 316)
        Me.Label42.Name = "Label42"
        Me.Label42.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label42.Size = New System.Drawing.Size(167, 18)
        Me.Label42.TabIndex = 85
        Me.Label42.Text = "2bit : PSLM stopped"
        '
        'Label41
        '
        Me.Label41.BackColor = System.Drawing.SystemColors.Control
        Me.Label41.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label41.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label41.Location = New System.Drawing.Point(32, 335)
        Me.Label41.Name = "Label41"
        Me.Label41.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label41.Size = New System.Drawing.Size(167, 18)
        Me.Label41.TabIndex = 84
        Me.Label41.Text = "1bit : NELM stopped"
        '
        'Label40
        '
        Me.Label40.BackColor = System.Drawing.SystemColors.Control
        Me.Label40.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label40.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label40.Location = New System.Drawing.Point(32, 354)
        Me.Label40.Name = "Label40"
        Me.Label40.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label40.Size = New System.Drawing.Size(167, 18)
        Me.Label40.TabIndex = 83
        Me.Label40.Text = "0bit : PELM stopped"
        '
        'frmAxisX
        '
        Me.frmAxisX.BackColor = System.Drawing.SystemColors.Control
        Me.frmAxisX.Controls.Add(Me.Frame6)
        Me.frmAxisX.Controls.Add(Me.Frame3)
        Me.frmAxisX.ForeColor = System.Drawing.SystemColors.ControlText
        Me.frmAxisX.Location = New System.Drawing.Point(12, 16)
        Me.frmAxisX.Name = "frmAxisX"
        Me.frmAxisX.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.frmAxisX.Size = New System.Drawing.Size(217, 614)
        Me.frmAxisX.TabIndex = 0
        Me.frmAxisX.TabStop = False
        Me.frmAxisX.Text = "X Axis: 00"
        '
        'Frame6
        '
        Me.Frame6.BackColor = System.Drawing.SystemColors.Control
        Me.Frame6.Controls.Add(Me.LedXDRS00)
        Me.Frame6.Controls.Add(Me.LedXDRS01)
        Me.Frame6.Controls.Add(Me.LedXDRS02)
        Me.Frame6.Controls.Add(Me.LedXDRS03)
        Me.Frame6.Controls.Add(Me.LedXDRS04)
        Me.Frame6.Controls.Add(Me.LedXDRS05)
        Me.Frame6.Controls.Add(Me.LedXDRS06)
        Me.Frame6.Controls.Add(Me.LedXDRS07)
        Me.Frame6.Controls.Add(Me.LedXDRS10)
        Me.Frame6.Controls.Add(Me.LedXDRS09)
        Me.Frame6.Controls.Add(Me.Label25)
        Me.Frame6.Controls.Add(Me.Label24)
        Me.Frame6.Controls.Add(Me.Label23)
        Me.Frame6.Controls.Add(Me.Label22)
        Me.Frame6.Controls.Add(Me.Label21)
        Me.Frame6.Controls.Add(Me.Label20)
        Me.Frame6.Controls.Add(Me.Label1)
        Me.Frame6.Controls.Add(Me.Label2)
        Me.Frame6.Controls.Add(Me.Label33)
        Me.Frame6.Controls.Add(Me.Label34)
        Me.Frame6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame6.Location = New System.Drawing.Point(0, 400)
        Me.Frame6.Name = "Frame6"
        Me.Frame6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame6.Size = New System.Drawing.Size(205, 213)
        Me.Frame6.TabIndex = 41
        Me.Frame6.TabStop = False
        Me.Frame6.Text = "Drive Status"
        '
        'LedXDRS00
        '
        Me.LedXDRS00.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LedXDRS00.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LedXDRS00.Cursor = System.Windows.Forms.Cursors.Default
        Me.LedXDRS00.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LedXDRS00.Location = New System.Drawing.Point(8, 186)
        Me.LedXDRS00.Name = "LedXDRS00"
        Me.LedXDRS00.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LedXDRS00.Size = New System.Drawing.Size(20, 18)
        Me.LedXDRS00.TabIndex = 51
        '
        'LedXDRS01
        '
        Me.LedXDRS01.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LedXDRS01.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LedXDRS01.Cursor = System.Windows.Forms.Cursors.Default
        Me.LedXDRS01.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LedXDRS01.Location = New System.Drawing.Point(8, 167)
        Me.LedXDRS01.Name = "LedXDRS01"
        Me.LedXDRS01.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LedXDRS01.Size = New System.Drawing.Size(20, 18)
        Me.LedXDRS01.TabIndex = 50
        '
        'LedXDRS02
        '
        Me.LedXDRS02.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LedXDRS02.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LedXDRS02.Cursor = System.Windows.Forms.Cursors.Default
        Me.LedXDRS02.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LedXDRS02.Location = New System.Drawing.Point(8, 147)
        Me.LedXDRS02.Name = "LedXDRS02"
        Me.LedXDRS02.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LedXDRS02.Size = New System.Drawing.Size(20, 18)
        Me.LedXDRS02.TabIndex = 49
        '
        'LedXDRS03
        '
        Me.LedXDRS03.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LedXDRS03.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LedXDRS03.Cursor = System.Windows.Forms.Cursors.Default
        Me.LedXDRS03.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LedXDRS03.Location = New System.Drawing.Point(8, 128)
        Me.LedXDRS03.Name = "LedXDRS03"
        Me.LedXDRS03.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LedXDRS03.Size = New System.Drawing.Size(20, 18)
        Me.LedXDRS03.TabIndex = 48
        '
        'LedXDRS04
        '
        Me.LedXDRS04.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LedXDRS04.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LedXDRS04.Cursor = System.Windows.Forms.Cursors.Default
        Me.LedXDRS04.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LedXDRS04.Location = New System.Drawing.Point(8, 110)
        Me.LedXDRS04.Name = "LedXDRS04"
        Me.LedXDRS04.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LedXDRS04.Size = New System.Drawing.Size(20, 18)
        Me.LedXDRS04.TabIndex = 47
        '
        'LedXDRS05
        '
        Me.LedXDRS05.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LedXDRS05.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LedXDRS05.Cursor = System.Windows.Forms.Cursors.Default
        Me.LedXDRS05.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LedXDRS05.Location = New System.Drawing.Point(8, 91)
        Me.LedXDRS05.Name = "LedXDRS05"
        Me.LedXDRS05.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LedXDRS05.Size = New System.Drawing.Size(20, 18)
        Me.LedXDRS05.TabIndex = 46
        '
        'LedXDRS06
        '
        Me.LedXDRS06.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LedXDRS06.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LedXDRS06.Cursor = System.Windows.Forms.Cursors.Default
        Me.LedXDRS06.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LedXDRS06.Location = New System.Drawing.Point(8, 72)
        Me.LedXDRS06.Name = "LedXDRS06"
        Me.LedXDRS06.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LedXDRS06.Size = New System.Drawing.Size(20, 18)
        Me.LedXDRS06.TabIndex = 45
        '
        'LedXDRS07
        '
        Me.LedXDRS07.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LedXDRS07.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LedXDRS07.Cursor = System.Windows.Forms.Cursors.Default
        Me.LedXDRS07.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LedXDRS07.Location = New System.Drawing.Point(8, 54)
        Me.LedXDRS07.Name = "LedXDRS07"
        Me.LedXDRS07.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LedXDRS07.Size = New System.Drawing.Size(20, 18)
        Me.LedXDRS07.TabIndex = 44
        '
        'LedXDRS10
        '
        Me.LedXDRS10.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LedXDRS10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LedXDRS10.Cursor = System.Windows.Forms.Cursors.Default
        Me.LedXDRS10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LedXDRS10.Location = New System.Drawing.Point(8, 16)
        Me.LedXDRS10.Name = "LedXDRS10"
        Me.LedXDRS10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LedXDRS10.Size = New System.Drawing.Size(20, 18)
        Me.LedXDRS10.TabIndex = 43
        '
        'LedXDRS09
        '
        Me.LedXDRS09.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LedXDRS09.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LedXDRS09.Cursor = System.Windows.Forms.Cursors.Default
        Me.LedXDRS09.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LedXDRS09.Location = New System.Drawing.Point(8, 35)
        Me.LedXDRS09.Name = "LedXDRS09"
        Me.LedXDRS09.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LedXDRS09.Size = New System.Drawing.Size(20, 18)
        Me.LedXDRS09.TabIndex = 42
        '
        'Label25
        '
        Me.Label25.BackColor = System.Drawing.SystemColors.Control
        Me.Label25.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label25.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label25.Location = New System.Drawing.Point(32, 186)
        Me.Label25.Name = "Label25"
        Me.Label25.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label25.Size = New System.Drawing.Size(167, 18)
        Me.Label25.TabIndex = 61
        Me.Label25.Text = "0bit : BUSY"
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.SystemColors.Control
        Me.Label24.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label24.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label24.Location = New System.Drawing.Point(32, 167)
        Me.Label24.Name = "Label24"
        Me.Label24.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label24.Size = New System.Drawing.Size(167, 18)
        Me.Label24.TabIndex = 60
        Me.Label24.Text = "1bit : DOWN"
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.SystemColors.Control
        Me.Label23.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label23.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label23.Location = New System.Drawing.Point(32, 147)
        Me.Label23.Name = "Label23"
        Me.Label23.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label23.Size = New System.Drawing.Size(167, 18)
        Me.Label23.TabIndex = 59
        Me.Label23.Text = "2bit : CONST"
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.SystemColors.Control
        Me.Label22.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label22.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label22.Location = New System.Drawing.Point(32, 128)
        Me.Label22.Name = "Label22"
        Me.Label22.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label22.Size = New System.Drawing.Size(167, 18)
        Me.Label22.TabIndex = 58
        Me.Label22.Text = "3bit : UP"
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.SystemColors.Control
        Me.Label21.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label21.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label21.Location = New System.Drawing.Point(32, 110)
        Me.Label21.Name = "Label21"
        Me.Label21.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label21.Size = New System.Drawing.Size(167, 18)
        Me.Label21.TabIndex = 57
        Me.Label21.Text = "4bit : CONTI BUSY"
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.SystemColors.Control
        Me.Label20.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label20.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label20.Location = New System.Drawing.Point(32, 91)
        Me.Label20.Name = "Label20"
        Me.Label20.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label20.Size = New System.Drawing.Size(167, 18)
        Me.Label20.TabIndex = 56
        Me.Label20.Text = "5bit : PRESET BUSY"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(32, 72)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(167, 18)
        Me.Label1.TabIndex = 55
        Me.Label1.Text = "6bit : MPG BUSY"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(32, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(167, 18)
        Me.Label2.TabIndex = 54
        Me.Label2.Text = "7bit : ORG BUSY"
        '
        'Label33
        '
        Me.Label33.BackColor = System.Drawing.SystemColors.Control
        Me.Label33.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label33.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label33.Location = New System.Drawing.Point(32, 16)
        Me.Label33.Name = "Label33"
        Me.Label33.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label33.Size = New System.Drawing.Size(167, 18)
        Me.Label33.TabIndex = 53
        Me.Label33.Text = "10bit : SLAVE BUSY"
        '
        'Label34
        '
        Me.Label34.BackColor = System.Drawing.SystemColors.Control
        Me.Label34.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label34.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label34.Location = New System.Drawing.Point(32, 35)
        Me.Label34.Name = "Label34"
        Me.Label34.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label34.Size = New System.Drawing.Size(167, 18)
        Me.Label34.TabIndex = 52
        Me.Label34.Text = "9bit : INP BUSY"
        '
        'Frame3
        '
        Me.Frame3.BackColor = System.Drawing.SystemColors.Control
        Me.Frame3.Controls.Add(Me.LedXENS00)
        Me.Frame3.Controls.Add(Me.LedXENS01)
        Me.Frame3.Controls.Add(Me.LedXENS02)
        Me.Frame3.Controls.Add(Me.LedXENS03)
        Me.Frame3.Controls.Add(Me.LedXENS04)
        Me.Frame3.Controls.Add(Me.LedXENS05)
        Me.Frame3.Controls.Add(Me.LedXENS06)
        Me.Frame3.Controls.Add(Me.LedXENS07)
        Me.Frame3.Controls.Add(Me.LedXENS15)
        Me.Frame3.Controls.Add(Me.LedXENS14)
        Me.Frame3.Controls.Add(Me.LedXENS13)
        Me.Frame3.Controls.Add(Me.LedXENS12)
        Me.Frame3.Controls.Add(Me.LedXENS11)
        Me.Frame3.Controls.Add(Me.LedXENS10)
        Me.Frame3.Controls.Add(Me.LedXENS09)
        Me.Frame3.Controls.Add(Me.LedXENS08)
        Me.Frame3.Controls.Add(Me.LedXENS31)
        Me.Frame3.Controls.Add(Me.LedXENS30)
        Me.Frame3.Controls.Add(Me.LedXENS16)
        Me.Frame3.Controls.Add(Me.Label19)
        Me.Frame3.Controls.Add(Me.Label26)
        Me.Frame3.Controls.Add(Me.Label27)
        Me.Frame3.Controls.Add(Me.Label28)
        Me.Frame3.Controls.Add(Me.Label29)
        Me.Frame3.Controls.Add(Me.Label30)
        Me.Frame3.Controls.Add(Me.Label31)
        Me.Frame3.Controls.Add(Me.Label32)
        Me.Frame3.Controls.Add(Me._lblAxis_0)
        Me.Frame3.Controls.Add(Me.Label11)
        Me.Frame3.Controls.Add(Me.Label12)
        Me.Frame3.Controls.Add(Me.Label13)
        Me.Frame3.Controls.Add(Me.Label14)
        Me.Frame3.Controls.Add(Me.Label15)
        Me.Frame3.Controls.Add(Me.Label16)
        Me.Frame3.Controls.Add(Me.Label17)
        Me.Frame3.Controls.Add(Me.Label18)
        Me.Frame3.Controls.Add(Me.Label37)
        Me.Frame3.Controls.Add(Me.Label38)
        Me.Frame3.Controls.Add(Me.Label39)
        Me.Frame3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame3.Location = New System.Drawing.Point(0, 16)
        Me.Frame3.Name = "Frame3"
        Me.Frame3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame3.Size = New System.Drawing.Size(205, 375)
        Me.Frame3.TabIndex = 1
        Me.Frame3.TabStop = False
        Me.Frame3.Text = "End Status"
        '
        'LedXENS00
        '
        Me.LedXENS00.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LedXENS00.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LedXENS00.Cursor = System.Windows.Forms.Cursors.Default
        Me.LedXENS00.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LedXENS00.Location = New System.Drawing.Point(8, 354)
        Me.LedXENS00.Name = "LedXENS00"
        Me.LedXENS00.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LedXENS00.Size = New System.Drawing.Size(20, 18)
        Me.LedXENS00.TabIndex = 20
        '
        'LedXENS01
        '
        Me.LedXENS01.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LedXENS01.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LedXENS01.Cursor = System.Windows.Forms.Cursors.Default
        Me.LedXENS01.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LedXENS01.Location = New System.Drawing.Point(8, 335)
        Me.LedXENS01.Name = "LedXENS01"
        Me.LedXENS01.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LedXENS01.Size = New System.Drawing.Size(20, 18)
        Me.LedXENS01.TabIndex = 19
        '
        'LedXENS02
        '
        Me.LedXENS02.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LedXENS02.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LedXENS02.Cursor = System.Windows.Forms.Cursors.Default
        Me.LedXENS02.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LedXENS02.Location = New System.Drawing.Point(8, 316)
        Me.LedXENS02.Name = "LedXENS02"
        Me.LedXENS02.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LedXENS02.Size = New System.Drawing.Size(20, 18)
        Me.LedXENS02.TabIndex = 18
        '
        'LedXENS03
        '
        Me.LedXENS03.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LedXENS03.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LedXENS03.Cursor = System.Windows.Forms.Cursors.Default
        Me.LedXENS03.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LedXENS03.Location = New System.Drawing.Point(8, 298)
        Me.LedXENS03.Name = "LedXENS03"
        Me.LedXENS03.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LedXENS03.Size = New System.Drawing.Size(20, 18)
        Me.LedXENS03.TabIndex = 17
        '
        'LedXENS04
        '
        Me.LedXENS04.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LedXENS04.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LedXENS04.Cursor = System.Windows.Forms.Cursors.Default
        Me.LedXENS04.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LedXENS04.Location = New System.Drawing.Point(8, 279)
        Me.LedXENS04.Name = "LedXENS04"
        Me.LedXENS04.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LedXENS04.Size = New System.Drawing.Size(20, 18)
        Me.LedXENS04.TabIndex = 16
        '
        'LedXENS05
        '
        Me.LedXENS05.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LedXENS05.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LedXENS05.Cursor = System.Windows.Forms.Cursors.Default
        Me.LedXENS05.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LedXENS05.Location = New System.Drawing.Point(8, 260)
        Me.LedXENS05.Name = "LedXENS05"
        Me.LedXENS05.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LedXENS05.Size = New System.Drawing.Size(20, 18)
        Me.LedXENS05.TabIndex = 15
        '
        'LedXENS06
        '
        Me.LedXENS06.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LedXENS06.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LedXENS06.Cursor = System.Windows.Forms.Cursors.Default
        Me.LedXENS06.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LedXENS06.Location = New System.Drawing.Point(8, 242)
        Me.LedXENS06.Name = "LedXENS06"
        Me.LedXENS06.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LedXENS06.Size = New System.Drawing.Size(20, 18)
        Me.LedXENS06.TabIndex = 14
        '
        'LedXENS07
        '
        Me.LedXENS07.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LedXENS07.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LedXENS07.Cursor = System.Windows.Forms.Cursors.Default
        Me.LedXENS07.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LedXENS07.Location = New System.Drawing.Point(8, 223)
        Me.LedXENS07.Name = "LedXENS07"
        Me.LedXENS07.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LedXENS07.Size = New System.Drawing.Size(20, 18)
        Me.LedXENS07.TabIndex = 13
        '
        'LedXENS15
        '
        Me.LedXENS15.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LedXENS15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LedXENS15.Cursor = System.Windows.Forms.Cursors.Default
        Me.LedXENS15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LedXENS15.Location = New System.Drawing.Point(8, 72)
        Me.LedXENS15.Name = "LedXENS15"
        Me.LedXENS15.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LedXENS15.Size = New System.Drawing.Size(20, 18)
        Me.LedXENS15.TabIndex = 12
        '
        'LedXENS14
        '
        Me.LedXENS14.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LedXENS14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LedXENS14.Cursor = System.Windows.Forms.Cursors.Default
        Me.LedXENS14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LedXENS14.Location = New System.Drawing.Point(8, 91)
        Me.LedXENS14.Name = "LedXENS14"
        Me.LedXENS14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LedXENS14.Size = New System.Drawing.Size(20, 18)
        Me.LedXENS14.TabIndex = 11
        '
        'LedXENS13
        '
        Me.LedXENS13.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LedXENS13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LedXENS13.Cursor = System.Windows.Forms.Cursors.Default
        Me.LedXENS13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LedXENS13.Location = New System.Drawing.Point(8, 110)
        Me.LedXENS13.Name = "LedXENS13"
        Me.LedXENS13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LedXENS13.Size = New System.Drawing.Size(20, 18)
        Me.LedXENS13.TabIndex = 10
        '
        'LedXENS12
        '
        Me.LedXENS12.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LedXENS12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LedXENS12.Cursor = System.Windows.Forms.Cursors.Default
        Me.LedXENS12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LedXENS12.Location = New System.Drawing.Point(8, 128)
        Me.LedXENS12.Name = "LedXENS12"
        Me.LedXENS12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LedXENS12.Size = New System.Drawing.Size(20, 18)
        Me.LedXENS12.TabIndex = 9
        '
        'LedXENS11
        '
        Me.LedXENS11.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LedXENS11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LedXENS11.Cursor = System.Windows.Forms.Cursors.Default
        Me.LedXENS11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LedXENS11.Location = New System.Drawing.Point(8, 147)
        Me.LedXENS11.Name = "LedXENS11"
        Me.LedXENS11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LedXENS11.Size = New System.Drawing.Size(20, 18)
        Me.LedXENS11.TabIndex = 8
        '
        'LedXENS10
        '
        Me.LedXENS10.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LedXENS10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LedXENS10.Cursor = System.Windows.Forms.Cursors.Default
        Me.LedXENS10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LedXENS10.Location = New System.Drawing.Point(8, 167)
        Me.LedXENS10.Name = "LedXENS10"
        Me.LedXENS10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LedXENS10.Size = New System.Drawing.Size(20, 18)
        Me.LedXENS10.TabIndex = 7
        '
        'LedXENS09
        '
        Me.LedXENS09.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LedXENS09.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LedXENS09.Cursor = System.Windows.Forms.Cursors.Default
        Me.LedXENS09.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LedXENS09.Location = New System.Drawing.Point(8, 186)
        Me.LedXENS09.Name = "LedXENS09"
        Me.LedXENS09.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LedXENS09.Size = New System.Drawing.Size(20, 18)
        Me.LedXENS09.TabIndex = 6
        '
        'LedXENS08
        '
        Me.LedXENS08.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LedXENS08.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LedXENS08.Cursor = System.Windows.Forms.Cursors.Default
        Me.LedXENS08.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LedXENS08.Location = New System.Drawing.Point(8, 204)
        Me.LedXENS08.Name = "LedXENS08"
        Me.LedXENS08.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LedXENS08.Size = New System.Drawing.Size(20, 18)
        Me.LedXENS08.TabIndex = 5
        '
        'LedXENS31
        '
        Me.LedXENS31.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LedXENS31.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LedXENS31.Cursor = System.Windows.Forms.Cursors.Default
        Me.LedXENS31.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LedXENS31.Location = New System.Drawing.Point(8, 16)
        Me.LedXENS31.Name = "LedXENS31"
        Me.LedXENS31.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LedXENS31.Size = New System.Drawing.Size(20, 18)
        Me.LedXENS31.TabIndex = 4
        '
        'LedXENS30
        '
        Me.LedXENS30.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LedXENS30.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LedXENS30.Cursor = System.Windows.Forms.Cursors.Default
        Me.LedXENS30.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LedXENS30.Location = New System.Drawing.Point(8, 35)
        Me.LedXENS30.Name = "LedXENS30"
        Me.LedXENS30.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LedXENS30.Size = New System.Drawing.Size(20, 18)
        Me.LedXENS30.TabIndex = 3
        '
        'LedXENS16
        '
        Me.LedXENS16.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LedXENS16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LedXENS16.Cursor = System.Windows.Forms.Cursors.Default
        Me.LedXENS16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LedXENS16.Location = New System.Drawing.Point(8, 54)
        Me.LedXENS16.Name = "LedXENS16"
        Me.LedXENS16.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LedXENS16.Size = New System.Drawing.Size(20, 18)
        Me.LedXENS16.TabIndex = 2
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.SystemColors.Control
        Me.Label19.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label19.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label19.Location = New System.Drawing.Point(32, 354)
        Me.Label19.Name = "Label19"
        Me.Label19.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label19.Size = New System.Drawing.Size(167, 18)
        Me.Label19.TabIndex = 40
        Me.Label19.Text = "0bit : PELM stopped"
        '
        'Label26
        '
        Me.Label26.BackColor = System.Drawing.SystemColors.Control
        Me.Label26.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label26.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label26.Location = New System.Drawing.Point(32, 335)
        Me.Label26.Name = "Label26"
        Me.Label26.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label26.Size = New System.Drawing.Size(167, 18)
        Me.Label26.TabIndex = 39
        Me.Label26.Text = "1bit : NELM stopped"
        '
        'Label27
        '
        Me.Label27.BackColor = System.Drawing.SystemColors.Control
        Me.Label27.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label27.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label27.Location = New System.Drawing.Point(32, 316)
        Me.Label27.Name = "Label27"
        Me.Label27.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label27.Size = New System.Drawing.Size(167, 18)
        Me.Label27.TabIndex = 38
        Me.Label27.Text = "2bit : PSLM stopped"
        '
        'Label28
        '
        Me.Label28.BackColor = System.Drawing.SystemColors.Control
        Me.Label28.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label28.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label28.Location = New System.Drawing.Point(32, 298)
        Me.Label28.Name = "Label28"
        Me.Label28.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label28.Size = New System.Drawing.Size(167, 18)
        Me.Label28.TabIndex = 37
        Me.Label28.Text = "3bit : NSLM stopped"
        '
        'Label29
        '
        Me.Label29.BackColor = System.Drawing.SystemColors.Control
        Me.Label29.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label29.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label29.Location = New System.Drawing.Point(32, 279)
        Me.Label29.Name = "Label29"
        Me.Label29.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label29.Size = New System.Drawing.Size(167, 18)
        Me.Label29.TabIndex = 36
        Me.Label29.Text = "4bit : PSWLMT stopped"
        '
        'Label30
        '
        Me.Label30.BackColor = System.Drawing.SystemColors.Control
        Me.Label30.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label30.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label30.Location = New System.Drawing.Point(32, 260)
        Me.Label30.Name = "Label30"
        Me.Label30.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label30.Size = New System.Drawing.Size(167, 18)
        Me.Label30.TabIndex = 35
        Me.Label30.Text = "5bit : NSWLMT stopped"
        '
        'Label31
        '
        Me.Label31.BackColor = System.Drawing.SystemColors.Control
        Me.Label31.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label31.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label31.Location = New System.Drawing.Point(32, 242)
        Me.Label31.Name = "Label31"
        Me.Label31.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label31.Size = New System.Drawing.Size(167, 18)
        Me.Label31.TabIndex = 34
        Me.Label31.Text = "6bit : PSWSLMT stopped"
        '
        'Label32
        '
        Me.Label32.BackColor = System.Drawing.SystemColors.Control
        Me.Label32.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label32.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label32.Location = New System.Drawing.Point(32, 223)
        Me.Label32.Name = "Label32"
        Me.Label32.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label32.Size = New System.Drawing.Size(167, 18)
        Me.Label32.TabIndex = 33
        Me.Label32.Text = "7bit : NSWSLMT stopped"
        '
        '_lblAxis_0
        '
        Me._lblAxis_0.AutoSize = True
        Me._lblAxis_0.BackColor = System.Drawing.SystemColors.Control
        Me._lblAxis_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblAxis_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblAxis.SetIndex(Me._lblAxis_0, CType(0, Short))
        Me._lblAxis_0.Location = New System.Drawing.Point(312, 0)
        Me._lblAxis_0.Name = "_lblAxis_0"
        Me._lblAxis_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblAxis_0.Size = New System.Drawing.Size(48, 12)
        Me._lblAxis_0.TabIndex = 32
        Me._lblAxis_0.Text = "Label33"
        Me._lblAxis_0.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.SystemColors.Control
        Me.Label11.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(32, 72)
        Me.Label11.Name = "Label11"
        Me.Label11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label11.Size = New System.Drawing.Size(167, 18)
        Me.Label11.TabIndex = 31
        Me.Label11.Text = "15bit : ENCERR"
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.SystemColors.Control
        Me.Label12.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(32, 91)
        Me.Label12.Name = "Label12"
        Me.Label12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label12.Size = New System.Drawing.Size(167, 18)
        Me.Label12.TabIndex = 30
        Me.Label12.Text = "14bit : SQSTP#2 stopped"
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.SystemColors.Control
        Me.Label13.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(32, 110)
        Me.Label13.Name = "Label13"
        Me.Label13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label13.Size = New System.Drawing.Size(167, 18)
        Me.Label13.TabIndex = 29
        Me.Label13.Text = "13bit : SQSTP#1 stopped"
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.SystemColors.Control
        Me.Label14.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label14.Location = New System.Drawing.Point(32, 128)
        Me.Label14.Name = "Label14"
        Me.Label14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label14.Size = New System.Drawing.Size(167, 18)
        Me.Label14.TabIndex = 28
        Me.Label14.Text = "12bit : ESTOPALL stopped"
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.SystemColors.Control
        Me.Label15.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label15.Location = New System.Drawing.Point(32, 147)
        Me.Label15.Name = "Label15"
        Me.Label15.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label15.Size = New System.Drawing.Size(167, 18)
        Me.Label15.TabIndex = 27
        Me.Label15.Text = "11bit : SSTOPCMD stopped"
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.SystemColors.Control
        Me.Label16.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label16.Location = New System.Drawing.Point(32, 167)
        Me.Label16.Name = "Label16"
        Me.Label16.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label16.Size = New System.Drawing.Size(167, 18)
        Me.Label16.TabIndex = 26
        Me.Label16.Text = "10bit : ESTOPCMD stopped"
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.SystemColors.Control
        Me.Label17.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label17.Location = New System.Drawing.Point(32, 186)
        Me.Label17.Name = "Label17"
        Me.Label17.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label17.Size = New System.Drawing.Size(167, 18)
        Me.Label17.TabIndex = 25
        Me.Label17.Text = "9bit : ESTOP stopped"
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.SystemColors.Control
        Me.Label18.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label18.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label18.Location = New System.Drawing.Point(32, 204)
        Me.Label18.Name = "Label18"
        Me.Label18.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label18.Size = New System.Drawing.Size(167, 18)
        Me.Label18.TabIndex = 24
        Me.Label18.Text = "8bit : SVALARM stopped"
        '
        'Label37
        '
        Me.Label37.BackColor = System.Drawing.SystemColors.Control
        Me.Label37.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label37.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label37.Location = New System.Drawing.Point(32, 16)
        Me.Label37.Name = "Label37"
        Me.Label37.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label37.Size = New System.Drawing.Size(167, 18)
        Me.Label37.TabIndex = 23
        Me.Label37.Text = "31bit : INPERR"
        '
        'Label38
        '
        Me.Label38.BackColor = System.Drawing.SystemColors.Control
        Me.Label38.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label38.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label38.Location = New System.Drawing.Point(32, 35)
        Me.Label38.Name = "Label38"
        Me.Label38.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label38.Size = New System.Drawing.Size(167, 18)
        Me.Label38.TabIndex = 22
        Me.Label38.Text = "30bit : ERRSTATE"
        '
        'Label39
        '
        Me.Label39.BackColor = System.Drawing.SystemColors.Control
        Me.Label39.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label39.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label39.Location = New System.Drawing.Point(32, 54)
        Me.Label39.Name = "Label39"
        Me.Label39.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label39.Size = New System.Drawing.Size(167, 18)
        Me.Label39.TabIndex = 21
        Me.Label39.Text = "16bit : MPGERR stopped"
        '
        'frmStatus
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(471, 638)
        Me.Controls.Add(Me.btnCur)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.btnPrev)
        Me.Controls.Add(Me.frmAxisY)
        Me.Controls.Add(Me.frmAxisX)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Location = New System.Drawing.Point(3, 29)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmStatus"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "Status View(END ,DRV)"
        Me.frmAxisY.ResumeLayout(False)
        Me.Frame1.ResumeLayout(False)
        CType(Me.LedYDRS09, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LedYDRS10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LedYDRS07, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LedYDRS06, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LedYDRS05, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LedYDRS04, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LedYDRS03, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LedYDRS02, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LedYDRS01, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LedYDRS00, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Frame2.ResumeLayout(False)
        Me.Frame2.PerformLayout()
        CType(Me.LedYENS16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LedYENS30, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LedYENS31, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LedYENS08, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LedYENS09, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LedYENS10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LedYENS11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LedYENS12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LedYENS13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LedYENS14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LedYENS15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LedYENS07, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LedYENS06, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LedYENS05, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LedYENS04, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LedYENS03, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LedYENS02, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LedYENS01, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LedYENS00, System.ComponentModel.ISupportInitialize).EndInit()
        Me.frmAxisX.ResumeLayout(False)
        Me.Frame6.ResumeLayout(False)
        CType(Me.LedXDRS00, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LedXDRS01, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LedXDRS02, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LedXDRS03, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LedXDRS04, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LedXDRS05, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LedXDRS06, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LedXDRS07, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LedXDRS10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LedXDRS09, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Frame3.ResumeLayout(False)
        Me.Frame3.PerformLayout()
        CType(Me.LedXENS00, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LedXENS01, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LedXENS02, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LedXENS03, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LedXENS04, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LedXENS05, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LedXENS06, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LedXENS07, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LedXENS15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LedXENS14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LedXENS13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LedXENS12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LedXENS11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LedXENS10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LedXENS09, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LedXENS08, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LedXENS31, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LedXENS30, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LedXENS16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblAxis, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
#End Region 
End Class