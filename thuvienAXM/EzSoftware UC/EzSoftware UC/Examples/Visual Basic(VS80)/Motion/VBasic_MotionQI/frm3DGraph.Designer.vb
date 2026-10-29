<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frm3DGraph
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
	Public WithEvents btnSetRange As System.Windows.Forms.Button
    Public WithEvents chkBoxEnable As System.Windows.Forms.CheckBox
	Public WithEvents cboDimension As System.Windows.Forms.ComboBox
	Public WithEvents cboAxisReset As System.Windows.Forms.ComboBox
    Public WithEvents btnHelicalPlay As System.Windows.Forms.Button
	Public WithEvents btnHelical As System.Windows.Forms.Button
	Public WithEvents btnSplinePlay As System.Windows.Forms.Button
	Public WithEvents btnSpline As System.Windows.Forms.Button
	Public WithEvents btnClear As System.Windows.Forms.Button
	Public WithEvents btnClose As System.Windows.Forms.Button
	Public WithEvents Timer1 As System.Windows.Forms.Timer
	Public WithEvents TextRangeZ As System.Windows.Forms.TextBox
	Public WithEvents TextRangeY As System.Windows.Forms.TextBox
	Public WithEvents TextRangeX As System.Windows.Forms.TextBox
    Public WithEvents _RangeZ_1 As System.Windows.Forms.Label
	Public WithEvents _RangeY_0 As System.Windows.Forms.Label
	Public WithEvents _RangeX_5 As System.Windows.Forms.Label
	Public WithEvents _CMDZ_4 As System.Windows.Forms.Label
	Public WithEvents _CMDY_3 As System.Windows.Forms.Label
	Public WithEvents _CMDX_2 As System.Windows.Forms.Label
	Public WithEvents Reset_Renamed As System.Windows.Forms.Label
	Public WithEvents _Dimension_0 As System.Windows.Forms.Label
	Public WithEvents Frame13 As System.Windows.Forms.GroupBox
	Public WithEvents CMDX As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	Public WithEvents CMDY As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	Public WithEvents CMDZ As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	Public WithEvents Dimension As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	Public WithEvents RangeX As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	Public WithEvents RangeY As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	Public WithEvents RangeZ As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	'참고: 다음 프로시저는 Windows Form 디자이너에 필요합니다.
	'Windows Form 디자이너를 사용하여 수정할 수 있습니다.
	'코드 편집기를 사용하여 수정하지 마십시오.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm3DGraph))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnSetRange = New System.Windows.Forms.Button
        Me.chkBoxEnable = New System.Windows.Forms.CheckBox
        Me.cboDimension = New System.Windows.Forms.ComboBox
        Me.cboAxisReset = New System.Windows.Forms.ComboBox
        Me.btnHelicalPlay = New System.Windows.Forms.Button
        Me.btnHelical = New System.Windows.Forms.Button
        Me.btnSplinePlay = New System.Windows.Forms.Button
        Me.btnSpline = New System.Windows.Forms.Button
        Me.btnClear = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Frame13 = New System.Windows.Forms.GroupBox
        Me.TextRangeZ = New System.Windows.Forms.TextBox
        Me.TextRangeY = New System.Windows.Forms.TextBox
        Me.TextRangeX = New System.Windows.Forms.TextBox
        Me._RangeZ_1 = New System.Windows.Forms.Label
        Me._RangeY_0 = New System.Windows.Forms.Label
        Me._RangeX_5 = New System.Windows.Forms.Label
        Me.Reset_Renamed = New System.Windows.Forms.Label
        Me._Dimension_0 = New System.Windows.Forms.Label
        Me._CMDZ_4 = New System.Windows.Forms.Label
        Me._CMDY_3 = New System.Windows.Forms.Label
        Me._CMDX_2 = New System.Windows.Forms.Label
        Me.CMDX = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.CMDY = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.CMDZ = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.Dimension = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.RangeX = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.RangeY = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.RangeZ = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.AxtGraph3D = New AxAXTGRAPH3DLib.AxAxtGraph3D
        Me.lblCmdPosX = New System.Windows.Forms.Label
        Me.lblCmdPosY = New System.Windows.Forms.Label
        Me.lblCmdPosZ = New System.Windows.Forms.Label
        Me.Frame13.SuspendLayout()
        CType(Me.CMDX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CMDY, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CMDZ, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dimension, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RangeX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RangeY, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RangeZ, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AxtGraph3D, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnSetRange
        '
        Me.btnSetRange.BackColor = System.Drawing.SystemColors.Control
        Me.btnSetRange.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnSetRange.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnSetRange.Location = New System.Drawing.Point(11, 163)
        Me.btnSetRange.Name = "btnSetRange"
        Me.btnSetRange.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnSetRange.Size = New System.Drawing.Size(220, 33)
        Me.btnSetRange.TabIndex = 25
        Me.btnSetRange.Text = "Set Range"
        Me.btnSetRange.UseVisualStyleBackColor = False
        '
        'chkBoxEnable
        '
        Me.chkBoxEnable.BackColor = System.Drawing.SystemColors.Control
        Me.chkBoxEnable.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkBoxEnable.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkBoxEnable.Location = New System.Drawing.Point(144, 90)
        Me.chkBoxEnable.Name = "chkBoxEnable"
        Me.chkBoxEnable.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkBoxEnable.Size = New System.Drawing.Size(89, 17)
        Me.chkBoxEnable.TabIndex = 9
        Me.chkBoxEnable.Text = "Box Enable"
        Me.chkBoxEnable.UseVisualStyleBackColor = False
        '
        'cboDimension
        '
        Me.cboDimension.BackColor = System.Drawing.SystemColors.Window
        Me.cboDimension.Cursor = System.Windows.Forms.Cursors.Default
        Me.cboDimension.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDimension.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboDimension.Items.AddRange(New Object() {"X - Y Dimension", "Y - Z Dimension", "X - Z Dimension", "X - Y - Z Dimension"})
        Me.cboDimension.Location = New System.Drawing.Point(80, 55)
        Me.cboDimension.Name = "cboDimension"
        Me.cboDimension.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboDimension.Size = New System.Drawing.Size(148, 20)
        Me.cboDimension.TabIndex = 5
        '
        'cboAxisReset
        '
        Me.cboAxisReset.BackColor = System.Drawing.SystemColors.Window
        Me.cboAxisReset.Cursor = System.Windows.Forms.Cursors.Default
        Me.cboAxisReset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAxisReset.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboAxisReset.Items.AddRange(New Object() {"X - Y Axis", "Y - Z Axis", "X - Z Axis", "X - Y - Z Axis"})
        Me.cboAxisReset.Location = New System.Drawing.Point(80, 20)
        Me.cboAxisReset.Name = "cboAxisReset"
        Me.cboAxisReset.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboAxisReset.Size = New System.Drawing.Size(147, 20)
        Me.cboAxisReset.TabIndex = 4
        '
        'btnHelicalPlay
        '
        Me.btnHelicalPlay.BackColor = System.Drawing.SystemColors.Control
        Me.btnHelicalPlay.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnHelicalPlay.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnHelicalPlay.Location = New System.Drawing.Point(12, 269)
        Me.btnHelicalPlay.Name = "btnHelicalPlay"
        Me.btnHelicalPlay.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnHelicalPlay.Size = New System.Drawing.Size(117, 41)
        Me.btnHelicalPlay.TabIndex = 7
        Me.btnHelicalPlay.Text = "HelicalPlay"
        Me.btnHelicalPlay.UseVisualStyleBackColor = False
        '
        'btnHelical
        '
        Me.btnHelical.BackColor = System.Drawing.SystemColors.Control
        Me.btnHelical.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnHelical.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnHelical.Location = New System.Drawing.Point(12, 222)
        Me.btnHelical.Name = "btnHelical"
        Me.btnHelical.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnHelical.Size = New System.Drawing.Size(117, 41)
        Me.btnHelical.TabIndex = 6
        Me.btnHelical.Text = "Helical"
        Me.btnHelical.UseVisualStyleBackColor = False
        '
        'btnSplinePlay
        '
        Me.btnSplinePlay.BackColor = System.Drawing.SystemColors.Control
        Me.btnSplinePlay.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnSplinePlay.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnSplinePlay.Location = New System.Drawing.Point(139, 269)
        Me.btnSplinePlay.Name = "btnSplinePlay"
        Me.btnSplinePlay.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnSplinePlay.Size = New System.Drawing.Size(117, 41)
        Me.btnSplinePlay.TabIndex = 3
        Me.btnSplinePlay.Text = "Spline Play"
        Me.btnSplinePlay.UseVisualStyleBackColor = False
        '
        'btnSpline
        '
        Me.btnSpline.BackColor = System.Drawing.SystemColors.Control
        Me.btnSpline.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnSpline.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnSpline.Location = New System.Drawing.Point(139, 222)
        Me.btnSpline.Name = "btnSpline"
        Me.btnSpline.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnSpline.Size = New System.Drawing.Size(117, 41)
        Me.btnSpline.TabIndex = 2
        Me.btnSpline.Text = "Spline"
        Me.btnSpline.UseVisualStyleBackColor = False
        '
        'btnClear
        '
        Me.btnClear.BackColor = System.Drawing.SystemColors.Control
        Me.btnClear.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnClear.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnClear.Location = New System.Drawing.Point(12, 396)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnClear.Size = New System.Drawing.Size(117, 41)
        Me.btnClear.TabIndex = 1
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = False
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.SystemColors.Control
        Me.btnClose.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnClose.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnClose.Location = New System.Drawing.Point(139, 396)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnClose.Size = New System.Drawing.Size(117, 41)
        Me.btnClose.TabIndex = 0
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'Frame13
        '
        Me.Frame13.BackColor = System.Drawing.SystemColors.Control
        Me.Frame13.Controls.Add(Me.btnSetRange)
        Me.Frame13.Controls.Add(Me.TextRangeZ)
        Me.Frame13.Controls.Add(Me.TextRangeY)
        Me.Frame13.Controls.Add(Me.TextRangeX)
        Me.Frame13.Controls.Add(Me.chkBoxEnable)
        Me.Frame13.Controls.Add(Me.cboDimension)
        Me.Frame13.Controls.Add(Me.cboAxisReset)
        Me.Frame13.Controls.Add(Me._RangeZ_1)
        Me.Frame13.Controls.Add(Me._RangeY_0)
        Me.Frame13.Controls.Add(Me._RangeX_5)
        Me.Frame13.Controls.Add(Me.Reset_Renamed)
        Me.Frame13.Controls.Add(Me._Dimension_0)
        Me.Frame13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame13.Location = New System.Drawing.Point(12, 9)
        Me.Frame13.Name = "Frame13"
        Me.Frame13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame13.Size = New System.Drawing.Size(244, 207)
        Me.Frame13.TabIndex = 10
        Me.Frame13.TabStop = False
        Me.Frame13.Text = "Graph Properties"
        '
        'TextRangeZ
        '
        Me.TextRangeZ.AcceptsReturn = True
        Me.TextRangeZ.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.TextRangeZ.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextRangeZ.Font = New System.Drawing.Font("굴림", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.TextRangeZ.ForeColor = System.Drawing.Color.Yellow
        Me.TextRangeZ.Location = New System.Drawing.Point(161, 137)
        Me.TextRangeZ.MaxLength = 0
        Me.TextRangeZ.Name = "TextRangeZ"
        Me.TextRangeZ.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TextRangeZ.Size = New System.Drawing.Size(70, 22)
        Me.TextRangeZ.TabIndex = 24
        Me.TextRangeZ.Text = "2500"
        Me.TextRangeZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextRangeY
        '
        Me.TextRangeY.AcceptsReturn = True
        Me.TextRangeY.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.TextRangeY.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextRangeY.Font = New System.Drawing.Font("굴림", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.TextRangeY.ForeColor = System.Drawing.Color.Yellow
        Me.TextRangeY.Location = New System.Drawing.Point(86, 137)
        Me.TextRangeY.MaxLength = 0
        Me.TextRangeY.Name = "TextRangeY"
        Me.TextRangeY.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TextRangeY.Size = New System.Drawing.Size(70, 22)
        Me.TextRangeY.TabIndex = 23
        Me.TextRangeY.Text = "2500"
        Me.TextRangeY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextRangeX
        '
        Me.TextRangeX.AcceptsReturn = True
        Me.TextRangeX.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.TextRangeX.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextRangeX.Font = New System.Drawing.Font("굴림", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.TextRangeX.ForeColor = System.Drawing.Color.Yellow
        Me.TextRangeX.Location = New System.Drawing.Point(11, 137)
        Me.TextRangeX.MaxLength = 0
        Me.TextRangeX.Name = "TextRangeX"
        Me.TextRangeX.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TextRangeX.Size = New System.Drawing.Size(70, 22)
        Me.TextRangeX.TabIndex = 22
        Me.TextRangeX.Text = "2500"
        Me.TextRangeX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        '_RangeZ_1
        '
        Me._RangeZ_1.BackColor = System.Drawing.SystemColors.Control
        Me._RangeZ_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._RangeZ_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._RangeZ_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.RangeZ.SetIndex(Me._RangeZ_1, CType(1, Short))
        Me._RangeZ_1.Location = New System.Drawing.Point(161, 112)
        Me._RangeZ_1.Name = "_RangeZ_1"
        Me._RangeZ_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._RangeZ_1.Size = New System.Drawing.Size(70, 20)
        Me._RangeZ_1.TabIndex = 21
        Me._RangeZ_1.Text = "RangeZ"
        Me._RangeZ_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_RangeY_0
        '
        Me._RangeY_0.BackColor = System.Drawing.SystemColors.Control
        Me._RangeY_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._RangeY_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._RangeY_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.RangeY.SetIndex(Me._RangeY_0, CType(0, Short))
        Me._RangeY_0.Location = New System.Drawing.Point(86, 112)
        Me._RangeY_0.Name = "_RangeY_0"
        Me._RangeY_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._RangeY_0.Size = New System.Drawing.Size(70, 20)
        Me._RangeY_0.TabIndex = 20
        Me._RangeY_0.Text = "RangeY"
        Me._RangeY_0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_RangeX_5
        '
        Me._RangeX_5.BackColor = System.Drawing.SystemColors.Control
        Me._RangeX_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._RangeX_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._RangeX_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.RangeX.SetIndex(Me._RangeX_5, CType(5, Short))
        Me._RangeX_5.Location = New System.Drawing.Point(11, 112)
        Me._RangeX_5.Name = "_RangeX_5"
        Me._RangeX_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._RangeX_5.Size = New System.Drawing.Size(70, 20)
        Me._RangeX_5.TabIndex = 19
        Me._RangeX_5.Text = "RangeX"
        Me._RangeX_5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Reset_Renamed
        '
        Me.Reset_Renamed.BackColor = System.Drawing.SystemColors.Control
        Me.Reset_Renamed.Cursor = System.Windows.Forms.Cursors.Default
        Me.Reset_Renamed.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Reset_Renamed.Location = New System.Drawing.Point(6, 23)
        Me.Reset_Renamed.Name = "Reset_Renamed"
        Me.Reset_Renamed.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Reset_Renamed.Size = New System.Drawing.Size(73, 17)
        Me.Reset_Renamed.TabIndex = 12
        Me.Reset_Renamed.Text = "Reset Axis"
        Me.Reset_Renamed.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_Dimension_0
        '
        Me._Dimension_0.BackColor = System.Drawing.SystemColors.Control
        Me._Dimension_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Dimension_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Dimension.SetIndex(Me._Dimension_0, CType(0, Short))
        Me._Dimension_0.Location = New System.Drawing.Point(6, 58)
        Me._Dimension_0.Name = "_Dimension_0"
        Me._Dimension_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Dimension_0.Size = New System.Drawing.Size(73, 17)
        Me._Dimension_0.TabIndex = 11
        Me._Dimension_0.Text = "Dimension"
        Me._Dimension_0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_CMDZ_4
        '
        Me._CMDZ_4.BackColor = System.Drawing.Color.Black
        Me._CMDZ_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._CMDZ_4.ForeColor = System.Drawing.Color.Yellow
        Me.CMDZ.SetIndex(Me._CMDZ_4, CType(4, Short))
        Me._CMDZ_4.Location = New System.Drawing.Point(262, 68)
        Me._CMDZ_4.Name = "_CMDZ_4"
        Me._CMDZ_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._CMDZ_4.Size = New System.Drawing.Size(50, 17)
        Me._CMDZ_4.TabIndex = 15
        Me._CMDZ_4.Text = "CMD Z:"
        Me._CMDZ_4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        '_CMDY_3
        '
        Me._CMDY_3.BackColor = System.Drawing.Color.Black
        Me._CMDY_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._CMDY_3.ForeColor = System.Drawing.Color.Yellow
        Me.CMDY.SetIndex(Me._CMDY_3, CType(3, Short))
        Me._CMDY_3.Location = New System.Drawing.Point(262, 44)
        Me._CMDY_3.Name = "_CMDY_3"
        Me._CMDY_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._CMDY_3.Size = New System.Drawing.Size(50, 17)
        Me._CMDY_3.TabIndex = 14
        Me._CMDY_3.Text = "CMD Y:"
        Me._CMDY_3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        '_CMDX_2
        '
        Me._CMDX_2.BackColor = System.Drawing.Color.Black
        Me._CMDX_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._CMDX_2.ForeColor = System.Drawing.Color.Yellow
        Me.CMDX.SetIndex(Me._CMDX_2, CType(2, Short))
        Me._CMDX_2.Location = New System.Drawing.Point(262, 19)
        Me._CMDX_2.Name = "_CMDX_2"
        Me._CMDX_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._CMDX_2.Size = New System.Drawing.Size(50, 17)
        Me._CMDX_2.TabIndex = 13
        Me._CMDX_2.Text = "CMD X:"
        Me._CMDX_2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'AxtGraph3D
        '
        Me.AxtGraph3D.Enabled = True
        Me.AxtGraph3D.Location = New System.Drawing.Point(262, 12)
        Me.AxtGraph3D.Name = "AxtGraph3D"
        Me.AxtGraph3D.OcxState = CType(resources.GetObject("AxtGraph3D.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxtGraph3D.Size = New System.Drawing.Size(526, 425)
        Me.AxtGraph3D.TabIndex = 26
        '
        'lblCmdPosX
        '
        Me.lblCmdPosX.BackColor = System.Drawing.Color.Black
        Me.lblCmdPosX.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblCmdPosX.Font = New System.Drawing.Font("굴림", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblCmdPosX.ForeColor = System.Drawing.Color.Lime
        Me.lblCmdPosX.Location = New System.Drawing.Point(318, 19)
        Me.lblCmdPosX.Name = "lblCmdPosX"
        Me.lblCmdPosX.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblCmdPosX.Size = New System.Drawing.Size(80, 17)
        Me.lblCmdPosX.TabIndex = 13
        Me.lblCmdPosX.Text = "0.000"
        Me.lblCmdPosX.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCmdPosY
        '
        Me.lblCmdPosY.BackColor = System.Drawing.Color.Black
        Me.lblCmdPosY.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblCmdPosY.Font = New System.Drawing.Font("굴림", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblCmdPosY.ForeColor = System.Drawing.Color.Lime
        Me.lblCmdPosY.Location = New System.Drawing.Point(318, 44)
        Me.lblCmdPosY.Name = "lblCmdPosY"
        Me.lblCmdPosY.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblCmdPosY.Size = New System.Drawing.Size(80, 17)
        Me.lblCmdPosY.TabIndex = 13
        Me.lblCmdPosY.Text = "0.000"
        Me.lblCmdPosY.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCmdPosZ
        '
        Me.lblCmdPosZ.BackColor = System.Drawing.Color.Black
        Me.lblCmdPosZ.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblCmdPosZ.Font = New System.Drawing.Font("굴림", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblCmdPosZ.ForeColor = System.Drawing.Color.Lime
        Me.lblCmdPosZ.Location = New System.Drawing.Point(318, 68)
        Me.lblCmdPosZ.Name = "lblCmdPosZ"
        Me.lblCmdPosZ.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblCmdPosZ.Size = New System.Drawing.Size(80, 17)
        Me.lblCmdPosZ.TabIndex = 13
        Me.lblCmdPosZ.Text = "0.000"
        Me.lblCmdPosZ.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frm3DGraph
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(800, 447)
        Me.Controls.Add(Me.btnHelicalPlay)
        Me.Controls.Add(Me.btnHelical)
        Me.Controls.Add(Me.btnSplinePlay)
        Me.Controls.Add(Me.btnSpline)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.Frame13)
        Me.Controls.Add(Me.lblCmdPosZ)
        Me.Controls.Add(Me.lblCmdPosY)
        Me.Controls.Add(Me.lblCmdPosX)
        Me.Controls.Add(Me._CMDX_2)
        Me.Controls.Add(Me._CMDZ_4)
        Me.Controls.Add(Me._CMDY_3)
        Me.Controls.Add(Me.AxtGraph3D)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Location = New System.Drawing.Point(197, 177)
        Me.Name = "frm3DGraph"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "3DGraphView"
        Me.Frame13.ResumeLayout(False)
        Me.Frame13.PerformLayout()
        CType(Me.CMDX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CMDY, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CMDZ, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dimension, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RangeX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RangeY, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RangeZ, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AxtGraph3D, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents AxtGraph3D As AxAXTGRAPH3DLib.AxAxtGraph3D
    Public WithEvents lblCmdPosX As System.Windows.Forms.Label
    Public WithEvents lblCmdPosY As System.Windows.Forms.Label
    Public WithEvents lblCmdPosZ As System.Windows.Forms.Label
#End Region 
End Class