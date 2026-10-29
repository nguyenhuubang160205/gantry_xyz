Option Strict Off
Option Explicit On
Friend Class frmAnalogOutput
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
	Public WithEvents TimerControlWave As System.Windows.Forms.Timer
	Public WithEvents chkStart As System.Windows.Forms.CheckBox
	Public WithEvents comboRange As System.Windows.Forms.ComboBox
	Public WithEvents textPeriod As System.Windows.Forms.TextBox
	Public WithEvents textVoltage As System.Windows.Forms.TextBox
	Public WithEvents comboInterval As System.Windows.Forms.ComboBox
	Public WithEvents comboWave As System.Windows.Forms.ComboBox
	Public WithEvents Label5 As System.Windows.Forms.Label
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents Frame1 As System.Windows.Forms.GroupBox
	Public WithEvents listAnalogOutput As AxMSComctlLib.AxListView
	'참고: 다음 프로시저는 Windows Form 디자이너에 필요합니다.
	'Windows Form 디자이너를 사용하여 수정할 수 있습니다.
	'코드 편집기를 사용하여 수정하지 마십시오.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAnalogOutput))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.TimerControlWave = New System.Windows.Forms.Timer(Me.components)
        Me.Frame1 = New System.Windows.Forms.GroupBox
        Me.chkStart = New System.Windows.Forms.CheckBox
        Me.comboRange = New System.Windows.Forms.ComboBox
        Me.textPeriod = New System.Windows.Forms.TextBox
        Me.textVoltage = New System.Windows.Forms.TextBox
        Me.comboInterval = New System.Windows.Forms.ComboBox
        Me.comboWave = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.listAnalogOutput = New AxMSComctlLib.AxListView
        Me.Frame1.SuspendLayout()
        CType(Me.listAnalogOutput, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TimerControlWave
        '
        Me.TimerControlWave.Enabled = True
        Me.TimerControlWave.Interval = 1
        '
        'Frame1
        '
        Me.Frame1.BackColor = System.Drawing.SystemColors.Control
        Me.Frame1.Controls.Add(Me.chkStart)
        Me.Frame1.Controls.Add(Me.comboRange)
        Me.Frame1.Controls.Add(Me.textPeriod)
        Me.Frame1.Controls.Add(Me.textVoltage)
        Me.Frame1.Controls.Add(Me.comboInterval)
        Me.Frame1.Controls.Add(Me.comboWave)
        Me.Frame1.Controls.Add(Me.Label5)
        Me.Frame1.Controls.Add(Me.Label4)
        Me.Frame1.Controls.Add(Me.Label3)
        Me.Frame1.Controls.Add(Me.Label2)
        Me.Frame1.Controls.Add(Me.Label1)
        Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame1.Location = New System.Drawing.Point(448, 8)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(161, 193)
        Me.Frame1.TabIndex = 1
        Me.Frame1.TabStop = False
        Me.Frame1.Text = "Setting"
        '
        'chkStart
        '
        Me.chkStart.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkStart.BackColor = System.Drawing.SystemColors.Control
        Me.chkStart.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkStart.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkStart.Location = New System.Drawing.Point(16, 144)
        Me.chkStart.Name = "chkStart"
        Me.chkStart.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkStart.Size = New System.Drawing.Size(129, 41)
        Me.chkStart.TabIndex = 12
        Me.chkStart.Text = "START"
        Me.chkStart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkStart.UseVisualStyleBackColor = False
        '
        'comboRange
        '
        Me.comboRange.BackColor = System.Drawing.SystemColors.Window
        Me.comboRange.Cursor = System.Windows.Forms.Cursors.Default
        Me.comboRange.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboRange.ForeColor = System.Drawing.SystemColors.WindowText
        Me.comboRange.Items.AddRange(New Object() {"-10~10"})
        Me.comboRange.Location = New System.Drawing.Point(64, 72)
        Me.comboRange.Name = "comboRange"
        Me.comboRange.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.comboRange.Size = New System.Drawing.Size(81, 20)
        Me.comboRange.TabIndex = 11
        '
        'textPeriod
        '
        Me.textPeriod.AcceptsReturn = True
        Me.textPeriod.BackColor = System.Drawing.SystemColors.Window
        Me.textPeriod.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.textPeriod.ForeColor = System.Drawing.SystemColors.WindowText
        Me.textPeriod.Location = New System.Drawing.Point(64, 48)
        Me.textPeriod.MaxLength = 0
        Me.textPeriod.Name = "textPeriod"
        Me.textPeriod.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.textPeriod.Size = New System.Drawing.Size(81, 21)
        Me.textPeriod.TabIndex = 10
        Me.textPeriod.Text = "100"
        '
        'textVoltage
        '
        Me.textVoltage.AcceptsReturn = True
        Me.textVoltage.BackColor = System.Drawing.SystemColors.Window
        Me.textVoltage.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.textVoltage.ForeColor = System.Drawing.SystemColors.WindowText
        Me.textVoltage.Location = New System.Drawing.Point(64, 120)
        Me.textVoltage.MaxLength = 0
        Me.textVoltage.Name = "textVoltage"
        Me.textVoltage.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.textVoltage.Size = New System.Drawing.Size(81, 21)
        Me.textVoltage.TabIndex = 9
        Me.textVoltage.Text = "0"
        '
        'comboInterval
        '
        Me.comboInterval.BackColor = System.Drawing.SystemColors.Window
        Me.comboInterval.Cursor = System.Windows.Forms.Cursors.Default
        Me.comboInterval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboInterval.ForeColor = System.Drawing.SystemColors.WindowText
        Me.comboInterval.Items.AddRange(New Object() {" 1ms", " 5ms", "10ms"})
        Me.comboInterval.Location = New System.Drawing.Point(64, 96)
        Me.comboInterval.Name = "comboInterval"
        Me.comboInterval.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.comboInterval.Size = New System.Drawing.Size(81, 20)
        Me.comboInterval.TabIndex = 8
        '
        'comboWave
        '
        Me.comboWave.BackColor = System.Drawing.SystemColors.Window
        Me.comboWave.Cursor = System.Windows.Forms.Cursors.Default
        Me.comboWave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboWave.ForeColor = System.Drawing.SystemColors.WindowText
        Me.comboWave.Items.AddRange(New Object() {"사인파", "삼각파", "구형파", "전   압"})
        Me.comboWave.Location = New System.Drawing.Point(64, 24)
        Me.comboWave.Name = "comboWave"
        Me.comboWave.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.comboWave.Size = New System.Drawing.Size(81, 20)
        Me.comboWave.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(8, 120)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(57, 25)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Voltage"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(6, 96)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(59, 17)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Interval"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(8, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(57, 17)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "V Range"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(6, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(59, 17)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Period"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(6, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(59, 17)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "WaveType"
        '
        'listAnalogOutput
        '
        Me.listAnalogOutput.Location = New System.Drawing.Point(8, 8)
        Me.listAnalogOutput.Name = "listAnalogOutput"
        Me.listAnalogOutput.OcxState = CType(resources.GetObject("listAnalogOutput.OcxState"), System.Windows.Forms.AxHost.State)
        Me.listAnalogOutput.Size = New System.Drawing.Size(433, 193)
        Me.listAnalogOutput.TabIndex = 0
        '
        'frmAnalogOutput
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(617, 210)
        Me.Controls.Add(Me.Frame1)
        Me.Controls.Add(Me.listAnalogOutput)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Location = New System.Drawing.Point(4, 23)
        Me.Name = "frmAnalogOutput"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "AnalogOutput"
        Me.Frame1.ResumeLayout(False)
        Me.Frame1.PerformLayout()
        CType(Me.listAnalogOutput, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
#End Region 
#Region "업그레이드 지원 "
	Private Shared m_vb6FormDefInstance As frmAnalogOutput
	Private Shared m_InitializingDefInstance As Boolean
	Public Shared Property DefInstance() As frmAnalogOutput
		Get
			If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
				m_InitializingDefInstance = True
				m_vb6FormDefInstance = New frmAnalogOutput()
				m_InitializingDefInstance = False
			End If
			DefInstance = m_vb6FormDefInstance
		End Get
		Set
			m_vb6FormDefInstance = Value
		End Set
	End Property
#End Region 
	' The module of the downside must be added to use Analog Input/Output
	' AXL.bas , AXHS.bas , AXA.bas
	
	Private Const MAXNUM_WAVETYPE As Short = 4 'Wave all number
	Private Const MAXNUM_RANGETYPE As Short = 4 'Range type all number
	Private Const MAXNUM_PERIODTYPE As Short = 3 'Period type all number
	Private Const MAXVAL_PERIOD As Short = 500 'Period max number
	Private Const MINVAL_PERIOD As Short = 50 'Period min number
	Private Const MAXNUM_LISTSUBITEM As Short = 8
	Private Const PI As Double = 3.141592
	
	Private Structure SAOChannel
		Dim bUse As Boolean 'utility yes or no
		Dim lModuleNo As Integer 'Module number
		Dim lModuleID As Integer 'Module ID
		Dim lChannelNo As Integer 'Channel number
		Dim nWave As Short 'Wave set index
		Dim lPeriod As Integer 'Period value
		Dim nVRange As Short 'Period set index
		Dim dVoltage As Double 'Voltage
		Dim lIndex As Integer
	End Structure
	
	Dim g_stChannelInfo() As SAOChannel 'The arrangement to be made the channel information
	Dim g_nIndexOfItemSelected As Short 'An item index of listview to be selected.
	Dim g_bIsStartMode As Boolean
	
	'UPGRADE_WARNING: 폼이 초기화될 때 chkStart.CheckStateChanged 이벤트가 발생합니다. 자세한 내용은 다음을 참조하십시오: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2075"'
	Private Sub chkStart_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkStart.CheckStateChanged
		If (chkStart.CheckState = 1) Then
			chkStart.Text = "WRITING"
		Else
			chkStart.Text = "START"
		End If
		
	End Sub
	
	'UPGRADE_WARNING: 폼이 초기화될 때 comboInterval.SelectedIndexChanged 이벤트가 발생합니다. 자세한 내용은 다음을 참조하십시오: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2075"'
	Private Sub comboInterval_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles comboInterval.SelectedIndexChanged
		Select Case comboInterval.SelectedIndex
			Case 0
				TimerControlWave.Interval = 1
			Case 1
				TimerControlWave.Interval = 5
			Case 2
				TimerControlWave.Interval = 10
		End Select
		
	End Sub
	
	'UPGRADE_WARNING: 폼이 초기화될 때 comboRange.SelectedIndexChanged 이벤트가 발생합니다. 자세한 내용은 다음을 참조하십시오: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2075"'
	Private Sub comboRange_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles comboRange.SelectedIndexChanged
		Dim nRange As Short
		Dim nIndexSel As Short
		
		' bring a wavetype index to be selected.
		nRange = comboRange.SelectedIndex
		
		' Data input at the listview    // wavetype
		nIndexSel = g_nIndexOfItemSelected - 1
		If nIndexSel > -1 Then
			g_stChannelInfo(nIndexSel).nVRange = comboRange.SelectedIndex
			listAnalogOutput.ListItems.Item(nIndexSel + 1).SubItems(6) = comboRange.Text
			
			' Volt range setting up
			Select Case comboRange.SelectedIndex
                Case 0 '-10 ~ 10
                    AxaoSetRange(nIndexSel, -10, 10)
            End Select
			
		End If
		
	End Sub
	
	'UPGRADE_WARNING: 폼이 초기화될 때 comboWave.SelectedIndexChanged 이벤트가 발생합니다. 자세한 내용은 다음을 참조하십시오: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2075"'
	Private Sub comboWave_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles comboWave.SelectedIndexChanged
		Dim nWave As Short
		Dim nIndexSel As Short
		
		' bring a wavetype index to be selected.
		nWave = comboWave.SelectedIndex
		
		' Data input at the listview    // wavetype
		nIndexSel = g_nIndexOfItemSelected - 1
		If nIndexSel > -1 Then
			g_stChannelInfo(nIndexSel).nWave = comboWave.SelectedIndex
			listAnalogOutput.ListItems.Item(nIndexSel + 1).SubItems(4) = comboWave.Text
			
		End If
		
		If (nWave < 3) Then 'Sin, Triangle, Rectangle
			textPeriod.Enabled = True
			textPeriod.BackColor = System.Drawing.ColorTranslator.FromOle(&H80000005)
			textVoltage.Enabled = False
			textVoltage.BackColor = System.Drawing.ColorTranslator.FromOle(&H8000000B)
		ElseIf (nWave = 3) Then  'Volt
			textPeriod.Enabled = False
			textPeriod.BackColor = System.Drawing.ColorTranslator.FromOle(&H8000000B)
			textVoltage.Enabled = True
			textVoltage.BackColor = System.Drawing.ColorTranslator.FromOle(&H80000005)
		End If
		
	End Sub
	
	'UPGRADE_WARNING: Form 이벤트 frmAnalogOutput.Activate에 새 동작이 있습니다. 자세한 내용은 다음을 참조하십시오: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2065"'
	Private Sub frmAnalogOutput_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
		g_nIndexOfItemSelected = 1
		
	End Sub
	
	Private Sub frmAnalogOutput_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		
		'Init variable
		g_nIndexOfItemSelected = -1
		
		comboWave.SelectedIndex = 0
        comboRange.SelectedIndex = 0
		comboInterval.SelectedIndex = 0
		
		'Control and Library initialize
		Initialize_AIO()
		Initialize_ListCtrl()
		
	End Sub
	
	'UPGRADE_WARNING: Form 이벤트 frmAnalogOutput.Unload에 새 동작이 있습니다. 자세한 내용은 다음을 참조하십시오: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2065"'
	Private Sub frmAnalogOutput_Closed(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Closed
		
		If AxlIsOpened Then
			' Library close
			AxlClose()
		End If
		
	End Sub
	
	Private Sub Initialize_AIO()
		Dim lState As Integer
		
		' Confirm Library initialized.
		If AxlIsOpened = False Then
			' Library initialize
			If AxlOpenNoReset(7) <> AXT_RT_SUCCESS Then
				
				MsgBox("Library initialized failed." & vbCrLf & "Please reset program", MsgBoxStyle.Critical)
				End
			End If
		End If
		
	End Sub
	
	Private Sub Initialize_ListCtrl()
		Dim lChannelCnt As Integer
		Dim i1 As Short
		Dim i2 As Short
		Dim lBoardID As Integer
		Dim lBoardNo As Integer
		Dim lModulePos As Integer
		Dim lModuleID As Integer
		Dim lModuleNo As Integer
		
		' ListView의 Column Header Add
		With listAnalogOutput
            .ColumnHeaders.Add(1, , "Channel", 80, 0)
            .ColumnHeaders.Add(2, , "Module No", 80, 0)
            .ColumnHeaders.Add(3, , "Module ID", 80, 0)
            .ColumnHeaders.Add(4, , "Channel No", 80, 0)
            .ColumnHeaders.Add(5, , "WaveType", 80, 0)
            .ColumnHeaders.Add(6, , "Period", 80, 0)
            .ColumnHeaders.Add(7, , "Volt Range", 80, 0)
            .ColumnHeaders.Add(8, , "Voltage", 84, 0)
		End With
		
		' Get Output Channel number
		AxaoInfoGetChannelCount(lChannelCnt)
		' Suitable to the number of channels arrangement finance's
		ReDim g_stChannelInfo(lChannelCnt)
		
		For i1 = 0 To lChannelCnt - 1
            AxaoWriteVoltage(i1, 0)
			AxaoInfoGetModuleNoOfChannelNo(i1, lModuleNo)
			AxaInfoGetModule(lModuleNo, lBoardNo, lModulePos, lModuleID)
			
			' Channel information collection
			g_stChannelInfo(i1).bUse = False
			g_stChannelInfo(i1).lModuleNo = lModuleNo
			g_stChannelInfo(i1).lModuleID = lModuleID
			g_stChannelInfo(i1).lChannelNo = i1
			g_stChannelInfo(i1).nWave = comboWave.SelectedIndex
			g_stChannelInfo(i1).lPeriod = CInt(textPeriod.Text)
			g_stChannelInfo(i1).nVRange = comboRange.SelectedIndex
			g_stChannelInfo(i1).dVoltage = CInt(textVoltage.Text)
			
			' express the information at listview
			refreshListAnalogOutput(i1)
		Next 
		
	End Sub
	
	Private Sub refreshListAnalogOutput(ByVal nIndex As Short)
		Dim i1 As Short
		i1 = nIndex
		
		' Data input at listview
		' Channel
		listAnalogOutput.ListItems.Add(i1 + 1,  , CStr(i1 + 1),  , 0)
		' use/not use setting up
		listAnalogOutput.ListItems.Item(i1 + 1).Checked = g_stChannelInfo(i1).bUse
		' Module No
		listAnalogOutput.ListItems.Item(i1 + 1).SubItems(1) = CStr(g_stChannelInfo(i1).lModuleNo)
		' Module ID
		listAnalogOutput.ListItems.Item(i1 + 1).SubItems(2) = CStr(g_stChannelInfo(i1).lModuleID)
		' Channel No
		listAnalogOutput.ListItems.Item(i1 + 1).SubItems(3) = CStr(g_stChannelInfo(i1).lChannelNo)
		' WaveType
		comboWave.SelectedIndex = g_stChannelInfo(i1).nWave
		listAnalogOutput.ListItems.Item(i1 + 1).SubItems(4) = comboWave.Text
		' Period
		listAnalogOutput.ListItems.Item(i1 + 1).SubItems(5) = CStr(g_stChannelInfo(i1).lPeriod)
		' Volt range
		comboRange.SelectedIndex = g_stChannelInfo(i1).nVRange
		listAnalogOutput.ListItems.Item(i1 + 1).SubItems(6) = comboRange.Text
		' Voltage
		listAnalogOutput.ListItems.Item(i1 + 1).SubItems(7) = CStr(g_stChannelInfo(i1).dVoltage)
		
	End Sub
	
	Private Sub RefreshCtrlAboutSetting()
		Dim nIndexSel As Short
		
		nIndexSel = g_nIndexOfItemSelected - 1
		If nIndexSel > -1 Then
			comboWave.SelectedIndex = g_stChannelInfo(nIndexSel).nWave ' WaveType
			textPeriod.Text = CStr(g_stChannelInfo(nIndexSel).lPeriod) ' Period
			comboRange.SelectedIndex = g_stChannelInfo(nIndexSel).nVRange ' Volt range
			textVoltage.Text = CStr(g_stChannelInfo(nIndexSel).dVoltage) ' Voltage
		End If
	End Sub
	
	Private Sub listAnalogOutput_ItemCheck(ByVal eventSender As System.Object, ByVal eventArgs As AxMSComctlLib.ListViewEvents_ItemCheckEvent) Handles listAnalogOutput.ItemCheck
		Dim Item As MSComctlLib.ListItem
		Item = EventArgs.Item
		Dim nIndexSel As Short
		
		nIndexSel = CDbl(Item.Default) - 1
		If nIndexSel > -1 Then
			g_stChannelInfo(nIndexSel).bUse = Item.Checked
		End If
		
	End Sub
	
	Private Sub listAnalogOutput_ItemClick(ByVal eventSender As System.Object, ByVal eventArgs As AxMSComctlLib.ListViewEvents_ItemClickEvent) Handles listAnalogOutput.ItemClick
		g_nIndexOfItemSelected = CShort(eventArgs.Item.Default)
		
		' Input value of setting control
		RefreshCtrlAboutSetting()
	End Sub
	
	'UPGRADE_WARNING: 폼이 초기화될 때 textPeriod.TextChanged 이벤트가 발생합니다. 자세한 내용은 다음을 참조하십시오: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2075"'
	Private Sub textPeriod_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles textPeriod.TextChanged
		Dim nIndexSel As Short
		Dim nPeriod As Short
		
		If IsNumeric(textPeriod.Text) = True Then
			nPeriod = CShort(textPeriod.Text)
			' A validity inspection of a cycle price to be input
			If (nPeriod < 0) Then
				textPeriod.Text = CStr(0)
			ElseIf (nPeriod > MAXVAL_PERIOD) Then 
				textPeriod.Text = CStr(MAXVAL_PERIOD)
			End If
			
			' Data input at listview    // Period
			nIndexSel = g_nIndexOfItemSelected - 1
			If nIndexSel > -1 Then
				g_stChannelInfo(nIndexSel).lPeriod = CInt(textPeriod.Text)
				listAnalogOutput.ListItems.Item(nIndexSel + 1).SubItems(5) = textPeriod.Text
			End If
		End If
		
	End Sub
	
	Private Sub textPeriod_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles textPeriod.Leave
		Dim nIndexSel As Short
		Dim nPeriod As Short
		
		nIndexSel = g_nIndexOfItemSelected - 1
		
		' Period value setting up to rather small a minimum price 50.
		If IsNumeric(textPeriod.Text) = True Then
			nPeriod = CShort(textPeriod.Text)
			If nPeriod < 50 Then
				If nIndexSel > -1 Then
					g_stChannelInfo(nIndexSel).lPeriod = 50
					textPeriod.Text = "50"
				End If
			End If
		Else
			If nIndexSel > -1 Then
				g_stChannelInfo(nIndexSel).lPeriod = 50
				textPeriod.Text = "50"
			End If
		End If
		
	End Sub
	
	Private Sub TimerControlWave_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TimerControlWave.Tick
		Dim i1 As Short
		Dim lChannelCnt As Integer
		Dim dVRange As Double
		Dim dPeriod As Double
		Dim dValue As Double
		
		Dim nIndexSel As Short
		nIndexSel = g_nIndexOfItemSelected - 1
		
		If (chkStart.CheckState = 1) Then
			' cardinality of a total output channel
			AxaoInfoGetChannelCount(lChannelCnt)
			For i1 = 0 To lChannelCnt - 1
				If (g_stChannelInfo(i1).bUse = True) Then
					' To do the change of wavetype according to Volt range
					Select Case g_stChannelInfo(i1).nVRange
						Case 0
							dVRange = 10
						Case 1
							dVRange = 5
						Case 2
							dVRange = 10
						Case 3
							dVRange = 5
					End Select
					
					' setting up to increase
					If (g_stChannelInfo(i1).lIndex >= g_stChannelInfo(i1).lPeriod) Then
						g_stChannelInfo(i1).lIndex = 0
					Else
						g_stChannelInfo(i1).lIndex = g_stChannelInfo(i1).lIndex + TimerControlWave.Interval
					End If
					
					Select Case g_stChannelInfo(i1).nWave
						Case 0 ' Sin wave
							dPeriod = g_stChannelInfo(i1).lPeriod / 2#
							If (g_stChannelInfo(i1).lIndex = 0) Then
								dValue = 0
							Else
								dValue = System.Math.Sin(g_stChannelInfo(i1).lIndex * PI / dPeriod) * dVRange
							End If
							
							' Output
							AxaoWriteVoltage(i1, dValue)
						Case 1 ' Triangle wave
							' under the rise which the interval is big than 0 (case which the interval is 100 0 ~ 24)
							If (g_stChannelInfo(i1).lIndex < g_stChannelInfo(i1).lPeriod / 4#) Then
								dValue = dVRange / (g_stChannelInfo(i1).lPeriod / 4) * g_stChannelInfo(i1).lIndex
								' under the falling which the interval (case which the interval is 100 25 ~ 74)
							ElseIf (g_stChannelInfo(i1).lIndex < ((g_stChannelInfo(i1).lPeriod / 4#) * 3)) Then 
								dValue = -((dVRange / (g_stChannelInfo(i1).lPeriod / 4)) * g_stChannelInfo(i1).lIndex) + dVRange * 2#
								' under the rise which the interval is small than 0 (case which the interval is 100 75 ~ 99)
							Else
								dValue = ((dVRange / (g_stChannelInfo(i1).lPeriod / 4)) * g_stChannelInfo(i1).lIndex) - dVRange * 4#
							End If
							
							' Output
							AxaoWriteVoltage(i1, dValue)
							
						Case 2 ' Rectangle wave
							' under the rise which the interval (case which the interval is 100 0 ~ 49)
							If (g_stChannelInfo(i1).lIndex < g_stChannelInfo(i1).lPeriod / 2#) Then
								dValue = dVRange
							Else
								dValue = -dVRange
							End If
							
							' Output
							AxaoWriteVoltage(i1, dValue)
					End Select
				End If
			Next 
		End If 'If (chkStart.Value = True) Then
		
	End Sub
	
	'UPGRADE_WARNING: 폼이 초기화될 때 textVoltage.TextChanged 이벤트가 발생합니다. 자세한 내용은 다음을 참조하십시오: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2075"'
	Private Sub textVoltage_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles textVoltage.TextChanged
		Dim nIndexSel As Short
		Dim nRange As Short
		Dim dVoltage As Double
		
		nIndexSel = g_nIndexOfItemSelected - 1
		
		If IsNumeric(textVoltage.Text) = True Then
			
			dVoltage = CDbl(textVoltage.Text)
			' validity inspection of Volt value to be input
            ' -10 ~ 10
            If (dVoltage < -10) Then
                dVoltage = -10
                textVoltage.Text = CStr(dVoltage)
            ElseIf (dVoltage > 10) Then
                dVoltage = 10
                textVoltage.Text = CStr(dVoltage)
            End If

            ' Data input at listview    // Voltage

            If (nIndexSel > -1) Then
                g_stChannelInfo(nIndexSel).dVoltage = CDbl(textVoltage.Text)
                listAnalogOutput.ListItems.Item(nIndexSel + 1).SubItems(7) = textVoltage.Text

                ' output
                AxaoWriteVoltage(nIndexSel, g_stChannelInfo(nIndexSel).dVoltage)
            End If
        End If
		
	End Sub
End Class