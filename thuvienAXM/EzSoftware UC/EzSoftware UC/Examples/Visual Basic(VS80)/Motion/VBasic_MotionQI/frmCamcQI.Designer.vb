<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmCamcQI
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
    Public WithEvents Label71 As System.Windows.Forms.Label
	Public WithEvents Label72 As System.Windows.Forms.Label
	Public WithEvents Label73 As System.Windows.Forms.Label
	Public WithEvents Label74 As System.Windows.Forms.Label
	Public WithEvents edtContiNum As System.Windows.Forms.Label
	Public WithEvents edtTotalNum As System.Windows.Forms.Label
	Public WithEvents edtQFree As System.Windows.Forms.Label
	Public WithEvents edtInMotion As System.Windows.Forms.Label
	Public WithEvents Frame16 As System.Windows.Forms.GroupBox
	Public WithEvents btnContiSpline As System.Windows.Forms.Button
	Public WithEvents btnContiBlend As System.Windows.Forms.Button
	Public WithEvents btnContiCircle As System.Windows.Forms.Button
	Public WithEvents btnContiLine As System.Windows.Forms.Button
	Public WithEvents btnContiTest As System.Windows.Forms.Button
	Public WithEvents btnContiStart As System.Windows.Forms.Button
	Public WithEvents btnContiClear As System.Windows.Forms.Button
	Public WithEvents Frame15 As System.Windows.Forms.GroupBox
	Public WithEvents edtTrigStartPosition As System.Windows.Forms.TextBox
	Public WithEvents edtTrigCycle As System.Windows.Forms.TextBox
	Public WithEvents edtTrigPulseWidth As System.Windows.Forms.TextBox
	Public WithEvents edtTrigEndPos As System.Windows.Forms.TextBox
	Public WithEvents btnTrigAbs As System.Windows.Forms.Button
	Public WithEvents btnTrigOneShot As System.Windows.Forms.Button
	Public WithEvents btnTrigPeriod As System.Windows.Forms.Button
	Public WithEvents btnTrigReset As System.Windows.Forms.Button
	Public WithEvents Label60 As System.Windows.Forms.Label
	Public WithEvents Label61 As System.Windows.Forms.Label
	Public WithEvents Label62 As System.Windows.Forms.Label
	Public WithEvents Label63 As System.Windows.Forms.Label
	Public WithEvents Frame17 As System.Windows.Forms.GroupBox
	Public WithEvents btnHomeAll As System.Windows.Forms.Button
	Public WithEvents btnHomeSingle As System.Windows.Forms.Button
	Public WithEvents cboHomeDir As System.Windows.Forms.ComboBox
	Public WithEvents cboHomeSignal As System.Windows.Forms.ComboBox
	Public WithEvents edtHomeVelFirst As System.Windows.Forms.TextBox
	Public WithEvents edtHomeVelSecond As System.Windows.Forms.TextBox
	Public WithEvents edtHomeVelThird As System.Windows.Forms.TextBox
	Public WithEvents edtHomeVelLast As System.Windows.Forms.TextBox
	Public WithEvents Label64 As System.Windows.Forms.Label
	Public WithEvents Label65 As System.Windows.Forms.Label
	Public WithEvents Label66 As System.Windows.Forms.Label
	Public WithEvents Label67 As System.Windows.Forms.Label
	Public WithEvents Label68 As System.Windows.Forms.Label
	Public WithEvents Label69 As System.Windows.Forms.Label
	Public WithEvents Frame19 As System.Windows.Forms.GroupBox
	Public WithEvents lstLog As System.Windows.Forms.ListBox
	Public WithEvents btnsearch As System.Windows.Forms.Button
	Public WithEvents cboDetect As System.Windows.Forms.ComboBox
	Public WithEvents cboDirection As System.Windows.Forms.ComboBox
	Public WithEvents cboStopM As System.Windows.Forms.ComboBox
	Public WithEvents Label57 As System.Windows.Forms.Label
	Public WithEvents Label58 As System.Windows.Forms.Label
	Public WithEvents Label59 As System.Windows.Forms.Label
	Public WithEvents Frame13 As System.Windows.Forms.GroupBox
	Public WithEvents _tmTest_3 As System.Windows.Forms.Timer
	Public WithEvents _tmTest_2 As System.Windows.Forms.Timer
	Public WithEvents _tmTest_1 As System.Windows.Forms.Timer
	Public WithEvents _tmTest_0 As System.Windows.Forms.Timer
	Public WithEvents _tmHome_3 As System.Windows.Forms.Timer
	Public WithEvents _tmHome_2 As System.Windows.Forms.Timer
	Public WithEvents _tmHome_1 As System.Windows.Forms.Timer
	Public WithEvents _tmHome_0 As System.Windows.Forms.Timer
	Public WithEvents tmGraph As System.Windows.Forms.Timer
	Public WithEvents tmDisplay As System.Windows.Forms.Timer
    Public WithEvents chkGearOnOff As System.Windows.Forms.CheckBox
	Public CommonDialog1Open As System.Windows.Forms.OpenFileDialog
	Public CommonDialog1Save As System.Windows.Forms.SaveFileDialog
	Public WithEvents btnSigCapture As System.Windows.Forms.Button
    Public WithEvents btnVelOverride As System.Windows.Forms.Button
    Public WithEvents Frame18 As System.Windows.Forms.GroupBox
    Public WithEvents btnReadCapture As System.Windows.Forms.Button
    Public WithEvents edtCapturePos As System.Windows.Forms.Label
    Public WithEvents Frame20 As System.Windows.Forms.GroupBox
    Public WithEvents edtGearRatio As System.Windows.Forms.TextBox
    Public WithEvents btnSave As System.Windows.Forms.Button
    Public WithEvents btnStatus As System.Windows.Forms.Button
    Public WithEvents btnLoad As System.Windows.Forms.Button
    Public WithEvents btnManualSet As System.Windows.Forms.Button
    Public WithEvents btnIntDisable As System.Windows.Forms.Button
    Public WithEvents btnIntCallback As System.Windows.Forms.Button
    Public WithEvents btnIntEvent As System.Windows.Forms.Button
    Public WithEvents btnIntMessage As System.Windows.Forms.Button
    Public WithEvents edtIntCount As System.Windows.Forms.Label
    Public WithEvents Label55 As System.Windows.Forms.Label
    Public WithEvents Frame12 As System.Windows.Forms.GroupBox
    Public WithEvents LedEXMP As System.Windows.Forms.PictureBox
    Public WithEvents LedEXPP As System.Windows.Forms.PictureBox
    Public WithEvents LedBusyy As System.Windows.Forms.PictureBox
    Public WithEvents LedBusyx As System.Windows.Forms.PictureBox
    Public WithEvents Label54 As System.Windows.Forms.Label
    Public WithEvents Label53 As System.Windows.Forms.Label
    Public WithEvents Label52 As System.Windows.Forms.Label
    Public WithEvents Label51 As System.Windows.Forms.Label
    Public WithEvents Frame11 As System.Windows.Forms.GroupBox
    Public WithEvents _btnJog_4 As System.Windows.Forms.Button
    Public WithEvents _btnJog_6 As System.Windows.Forms.Button
    Public WithEvents _btnJog_2 As System.Windows.Forms.Button
    Public WithEvents btn3DGraph As System.Windows.Forms.Button
    Public WithEvents cboAxisSet As System.Windows.Forms.ComboBox
    Public WithEvents edtMoveUnit As System.Windows.Forms.TextBox
    Public WithEvents edtUnit As System.Windows.Forms.TextBox
    Public WithEvents edtPulse As System.Windows.Forms.TextBox
    Public WithEvents btnSetting As System.Windows.Forms.Button
    Public WithEvents edtStartSpeed As System.Windows.Forms.TextBox
    Public WithEvents cboPulseOutM As System.Windows.Forms.ComboBox
    Public WithEvents cboEncInputM As System.Windows.Forms.ComboBox
    Public WithEvents btnCountclr As System.Windows.Forms.Button
    Public WithEvents cbGantrySlave As System.Windows.Forms.ComboBox
    Public WithEvents chkGantry As System.Windows.Forms.CheckBox
    Public WithEvents Frame9 As System.Windows.Forms.GroupBox
    Public WithEvents edtPosition As System.Windows.Forms.TextBox
    Public WithEvents edtVelocity As System.Windows.Forms.TextBox
    Public WithEvents edtAccel As System.Windows.Forms.TextBox
    Public WithEvents edtDecel As System.Windows.Forms.TextBox
    Public WithEvents chkAbsolute As System.Windows.Forms.CheckBox
    Public WithEvents chkRelative As System.Windows.Forms.CheckBox
    Public WithEvents chkAsym As System.Windows.Forms.CheckBox
    Public WithEvents chkSCurve As System.Windows.Forms.CheckBox
    Public WithEvents chkXYSyn As System.Windows.Forms.CheckBox
    Public WithEvents btnMove As System.Windows.Forms.Button
    Public WithEvents btnRepeat As System.Windows.Forms.Button
    Public WithEvents btnStop As System.Windows.Forms.Button
    Public WithEvents btnEstop As System.Windows.Forms.Button
    Public WithEvents Label47 As System.Windows.Forms.Label
    Public WithEvents Label48 As System.Windows.Forms.Label
    Public WithEvents Label49 As System.Windows.Forms.Label
    Public WithEvents Label50 As System.Windows.Forms.Label
    Public WithEvents Frame10 As System.Windows.Forms.GroupBox
    Public WithEvents _btnJog_1 As System.Windows.Forms.Button
    Public WithEvents _btnJog_3 As System.Windows.Forms.Button
    Public WithEvents _btnJog_5 As System.Windows.Forms.Button
    Public WithEvents _btnJog_7 As System.Windows.Forms.Button
    Public WithEvents _btnJog_0 As System.Windows.Forms.Button
    Public WithEvents edtCmdPosX As System.Windows.Forms.TextBox
    Public WithEvents edtCmdPosY As System.Windows.Forms.TextBox
    Public WithEvents edtCmdPosZ As System.Windows.Forms.TextBox
    Public WithEvents edtCmdPosU As System.Windows.Forms.TextBox
    Public WithEvents edtActPosX As System.Windows.Forms.TextBox
    Public WithEvents edtActPosY As System.Windows.Forms.TextBox
    Public WithEvents edtActPosZ As System.Windows.Forms.TextBox
    Public WithEvents edtActPosU As System.Windows.Forms.TextBox
    Public WithEvents edtCmdVelX As System.Windows.Forms.TextBox
    Public WithEvents edtCmdVelY As System.Windows.Forms.TextBox
    Public WithEvents edtCmdVelZ As System.Windows.Forms.TextBox
    Public WithEvents edtCmdVelU As System.Windows.Forms.TextBox
    Public WithEvents btnCircular As System.Windows.Forms.Button
    Public WithEvents btnlinear As System.Windows.Forms.Button
    Public WithEvents chkCwCcw As System.Windows.Forms.CheckBox
    Public WithEvents edtAngle As System.Windows.Forms.TextBox
    Public WithEvents edtYCen As System.Windows.Forms.TextBox
    Public WithEvents edtXCen As System.Windows.Forms.TextBox
    Public WithEvents Label46 As System.Windows.Forms.Label
    Public WithEvents Label45 As System.Windows.Forms.Label
    Public WithEvents Label44 As System.Windows.Forms.Label
    Public WithEvents Frame8 As System.Windows.Forms.GroupBox
    Public WithEvents Label6 As System.Windows.Forms.Label
    Public WithEvents Label26 As System.Windows.Forms.Label
    Public WithEvents Label25 As System.Windows.Forms.Label
    Public WithEvents Label27 As System.Windows.Forms.Label
    Public WithEvents Label28 As System.Windows.Forms.Label
    Public WithEvents Label36 As System.Windows.Forms.Label
    Public WithEvents Label37 As System.Windows.Forms.Label
    Public WithEvents Label38 As System.Windows.Forms.Label
    Public WithEvents Label39 As System.Windows.Forms.Label
    Public WithEvents Label40 As System.Windows.Forms.Label
    Public WithEvents Label41 As System.Windows.Forms.Label
    Public WithEvents Label42 As System.Windows.Forms.Label
    Public WithEvents Label43 As System.Windows.Forms.Label
    Public WithEvents Frame7 As System.Windows.Forms.GroupBox
    Public WithEvents btnCRCOff As System.Windows.Forms.Button
    Public WithEvents btnCRCOn As System.Windows.Forms.Button
    Public WithEvents Frame6 As System.Windows.Forms.GroupBox
    Public WithEvents btnMPGOff As System.Windows.Forms.Button
    Public WithEvents btnMPGOn As System.Windows.Forms.Button
    Public WithEvents Frame5 As System.Windows.Forms.GroupBox
    Public WithEvents LedEmg As System.Windows.Forms.PictureBox
    Public WithEvents LedZPhase As System.Windows.Forms.PictureBox
    Public WithEvents LedHome As System.Windows.Forms.PictureBox
    Public WithEvents LedAlarm As System.Windows.Forms.PictureBox
    Public WithEvents LedInp As System.Windows.Forms.PictureBox
    Public WithEvents LedNElm As System.Windows.Forms.PictureBox
    Public WithEvents LedPElm As System.Windows.Forms.PictureBox
    Public WithEvents Label35 As System.Windows.Forms.Label
    Public WithEvents Label34 As System.Windows.Forms.Label
    Public WithEvents Label33 As System.Windows.Forms.Label
    Public WithEvents Label32 As System.Windows.Forms.Label
    Public WithEvents Label31 As System.Windows.Forms.Label
    Public WithEvents Label30 As System.Windows.Forms.Label
    Public WithEvents Label29 As System.Windows.Forms.Label
    Public WithEvents Frame4 As System.Windows.Forms.GroupBox
    Public WithEvents LedOut2 As System.Windows.Forms.PictureBox
    Public WithEvents LedOut5 As System.Windows.Forms.PictureBox
    Public WithEvents LedOut4 As System.Windows.Forms.PictureBox
    Public WithEvents LedOut3 As System.Windows.Forms.PictureBox
    Public WithEvents LedOut0 As System.Windows.Forms.PictureBox
    Public WithEvents LedOut1 As System.Windows.Forms.PictureBox
    Public WithEvents LedIn5 As System.Windows.Forms.PictureBox
    Public WithEvents LedIn4 As System.Windows.Forms.PictureBox
    Public WithEvents LedIn3 As System.Windows.Forms.PictureBox
    Public WithEvents LedIn2 As System.Windows.Forms.PictureBox
    Public WithEvents LedIn0 As System.Windows.Forms.PictureBox
    Public WithEvents LedIn1 As System.Windows.Forms.PictureBox
    Public WithEvents Label24 As System.Windows.Forms.Label
    Public WithEvents Label23 As System.Windows.Forms.Label
    Public WithEvents Label22 As System.Windows.Forms.Label
    Public WithEvents Label21 As System.Windows.Forms.Label
    Public WithEvents Label20 As System.Windows.Forms.Label
    Public WithEvents Label19 As System.Windows.Forms.Label
    Public WithEvents Label18 As System.Windows.Forms.Label
    Public WithEvents Label17 As System.Windows.Forms.Label
    Public WithEvents Label16 As System.Windows.Forms.Label
    Public WithEvents Label15 As System.Windows.Forms.Label
    Public WithEvents Label14 As System.Windows.Forms.Label
    Public WithEvents Label13 As System.Windows.Forms.Label
    Public WithEvents Label12 As System.Windows.Forms.Label
    Public WithEvents Label11 As System.Windows.Forms.Label
    Public WithEvents Frame3 As System.Windows.Forms.GroupBox
    Public WithEvents cboLevel4 As System.Windows.Forms.ComboBox
    Public WithEvents cboLevel3 As System.Windows.Forms.ComboBox
    Public WithEvents cboLevel2 As System.Windows.Forms.ComboBox
    Public WithEvents cboLevel1 As System.Windows.Forms.ComboBox
    Public WithEvents cboLevel0 As System.Windows.Forms.ComboBox
    Public WithEvents chkZPhaseLevel As System.Windows.Forms.CheckBox
    Public WithEvents chkHomeLevel As System.Windows.Forms.CheckBox
    Public WithEvents Label10 As System.Windows.Forms.Label
    Public WithEvents Label9 As System.Windows.Forms.Label
    Public WithEvents Label8 As System.Windows.Forms.Label
    Public WithEvents Label7 As System.Windows.Forms.Label
    Public WithEvents Label5 As System.Windows.Forms.Label
    Public WithEvents lbl As System.Windows.Forms.Label
    Public WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents m_grLevel As System.Windows.Forms.GroupBox
    Public WithEvents Frame1 As System.Windows.Forms.GroupBox
    'Public WithEvents AxtXYGraph As AxtXYGraphLib.AxtXYGraph
    Public WithEvents _Label2_1 As System.Windows.Forms.Label
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents Label2 As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    Public WithEvents btnJog As Microsoft.VisualBasic.Compatibility.VB6.ButtonArray
    Public WithEvents tmHome As Microsoft.VisualBasic.Compatibility.VB6.TimerArray
    Public WithEvents tmTest As Microsoft.VisualBasic.Compatibility.VB6.TimerArray
    '참고: 다음 프로시저는 Windows Form 디자이너에 필요합니다.
    'Windows Form 디자이너를 사용하여 수정할 수 있습니다.
    '코드 편집기를 사용하여 수정하지 마십시오.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCamcQI))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Frame15 = New System.Windows.Forms.GroupBox
        Me.Frame16 = New System.Windows.Forms.GroupBox
        Me.Label71 = New System.Windows.Forms.Label
        Me.Label72 = New System.Windows.Forms.Label
        Me.Label73 = New System.Windows.Forms.Label
        Me.Label74 = New System.Windows.Forms.Label
        Me.edtContiNum = New System.Windows.Forms.Label
        Me.edtTotalNum = New System.Windows.Forms.Label
        Me.edtQFree = New System.Windows.Forms.Label
        Me.edtInMotion = New System.Windows.Forms.Label
        Me.btnContiSpline = New System.Windows.Forms.Button
        Me.btnContiBlend = New System.Windows.Forms.Button
        Me.btnContiCircle = New System.Windows.Forms.Button
        Me.btnContiLine = New System.Windows.Forms.Button
        Me.btnContiTest = New System.Windows.Forms.Button
        Me.btnContiStart = New System.Windows.Forms.Button
        Me.btnContiClear = New System.Windows.Forms.Button
        Me.Frame17 = New System.Windows.Forms.GroupBox
        Me.edtTrigStartPosition = New System.Windows.Forms.TextBox
        Me.edtTrigCycle = New System.Windows.Forms.TextBox
        Me.edtTrigPulseWidth = New System.Windows.Forms.TextBox
        Me.edtTrigEndPos = New System.Windows.Forms.TextBox
        Me.btnTrigAbs = New System.Windows.Forms.Button
        Me.btnTrigOneShot = New System.Windows.Forms.Button
        Me.btnTrigPeriod = New System.Windows.Forms.Button
        Me.btnTrigReset = New System.Windows.Forms.Button
        Me.Label60 = New System.Windows.Forms.Label
        Me.Label61 = New System.Windows.Forms.Label
        Me.Label62 = New System.Windows.Forms.Label
        Me.Label63 = New System.Windows.Forms.Label
        Me.Frame19 = New System.Windows.Forms.GroupBox
        Me.btnHomeAll = New System.Windows.Forms.Button
        Me.btnHomeSingle = New System.Windows.Forms.Button
        Me.cboHomeDir = New System.Windows.Forms.ComboBox
        Me.cboHomeSignal = New System.Windows.Forms.ComboBox
        Me.edtHomeVelFirst = New System.Windows.Forms.TextBox
        Me.edtHomeVelSecond = New System.Windows.Forms.TextBox
        Me.edtHomeVelThird = New System.Windows.Forms.TextBox
        Me.edtHomeVelLast = New System.Windows.Forms.TextBox
        Me.Label64 = New System.Windows.Forms.Label
        Me.Label65 = New System.Windows.Forms.Label
        Me.Label66 = New System.Windows.Forms.Label
        Me.Label67 = New System.Windows.Forms.Label
        Me.Label68 = New System.Windows.Forms.Label
        Me.Label69 = New System.Windows.Forms.Label
        Me.lstLog = New System.Windows.Forms.ListBox
        Me.Frame13 = New System.Windows.Forms.GroupBox
        Me.btnsearch = New System.Windows.Forms.Button
        Me.cboDetect = New System.Windows.Forms.ComboBox
        Me.cboDirection = New System.Windows.Forms.ComboBox
        Me.cboStopM = New System.Windows.Forms.ComboBox
        Me.Label57 = New System.Windows.Forms.Label
        Me.Label58 = New System.Windows.Forms.Label
        Me.Label59 = New System.Windows.Forms.Label
        Me._tmTest_3 = New System.Windows.Forms.Timer(Me.components)
        Me._tmTest_2 = New System.Windows.Forms.Timer(Me.components)
        Me._tmTest_1 = New System.Windows.Forms.Timer(Me.components)
        Me._tmTest_0 = New System.Windows.Forms.Timer(Me.components)
        Me._tmHome_3 = New System.Windows.Forms.Timer(Me.components)
        Me._tmHome_2 = New System.Windows.Forms.Timer(Me.components)
        Me._tmHome_1 = New System.Windows.Forms.Timer(Me.components)
        Me._tmHome_0 = New System.Windows.Forms.Timer(Me.components)
        Me.tmGraph = New System.Windows.Forms.Timer(Me.components)
        Me.tmDisplay = New System.Windows.Forms.Timer(Me.components)
        Me.chkGearOnOff = New System.Windows.Forms.CheckBox
        Me.CommonDialog1Open = New System.Windows.Forms.OpenFileDialog
        Me.CommonDialog1Save = New System.Windows.Forms.SaveFileDialog
        Me.Frame18 = New System.Windows.Forms.GroupBox
        Me.btnSigCapture = New System.Windows.Forms.Button
        Me.btnVelOverride = New System.Windows.Forms.Button
        Me.Frame20 = New System.Windows.Forms.GroupBox
        Me.btnReadCapture = New System.Windows.Forms.Button
        Me.edtCapturePos = New System.Windows.Forms.Label
        Me.edtGearRatio = New System.Windows.Forms.TextBox
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnStatus = New System.Windows.Forms.Button
        Me.btnLoad = New System.Windows.Forms.Button
        Me.btnManualSet = New System.Windows.Forms.Button
        Me.Frame12 = New System.Windows.Forms.GroupBox
        Me.btnIntDisable = New System.Windows.Forms.Button
        Me.btnIntCallback = New System.Windows.Forms.Button
        Me.btnIntEvent = New System.Windows.Forms.Button
        Me.btnIntMessage = New System.Windows.Forms.Button
        Me.edtIntCount = New System.Windows.Forms.Label
        Me.Label55 = New System.Windows.Forms.Label
        Me.Frame11 = New System.Windows.Forms.GroupBox
        Me.LedEXMP = New System.Windows.Forms.PictureBox
        Me.LedEXPP = New System.Windows.Forms.PictureBox
        Me.LedBusyy = New System.Windows.Forms.PictureBox
        Me.LedBusyx = New System.Windows.Forms.PictureBox
        Me.Label54 = New System.Windows.Forms.Label
        Me.Label53 = New System.Windows.Forms.Label
        Me.Label52 = New System.Windows.Forms.Label
        Me.Label51 = New System.Windows.Forms.Label
        Me._btnJog_4 = New System.Windows.Forms.Button
        Me._btnJog_6 = New System.Windows.Forms.Button
        Me._btnJog_2 = New System.Windows.Forms.Button
        Me.btn3DGraph = New System.Windows.Forms.Button
        Me.cboAxisSet = New System.Windows.Forms.ComboBox
        Me.edtMoveUnit = New System.Windows.Forms.TextBox
        Me.Frame7 = New System.Windows.Forms.GroupBox
        Me.edtUnit = New System.Windows.Forms.TextBox
        Me.edtPulse = New System.Windows.Forms.TextBox
        Me.btnSetting = New System.Windows.Forms.Button
        Me.edtStartSpeed = New System.Windows.Forms.TextBox
        Me.cboPulseOutM = New System.Windows.Forms.ComboBox
        Me.cboEncInputM = New System.Windows.Forms.ComboBox
        Me.btnCountclr = New System.Windows.Forms.Button
        Me.Frame9 = New System.Windows.Forms.GroupBox
        Me.cbGantrySlave = New System.Windows.Forms.ComboBox
        Me.chkGantry = New System.Windows.Forms.CheckBox
        Me._btnJog_1 = New System.Windows.Forms.Button
        Me._btnJog_3 = New System.Windows.Forms.Button
        Me._btnJog_5 = New System.Windows.Forms.Button
        Me._btnJog_7 = New System.Windows.Forms.Button
        Me._btnJog_0 = New System.Windows.Forms.Button
        Me.edtCmdPosX = New System.Windows.Forms.TextBox
        Me.edtCmdPosY = New System.Windows.Forms.TextBox
        Me.edtCmdPosZ = New System.Windows.Forms.TextBox
        Me.edtCmdPosU = New System.Windows.Forms.TextBox
        Me.edtActPosX = New System.Windows.Forms.TextBox
        Me.edtActPosY = New System.Windows.Forms.TextBox
        Me.edtActPosZ = New System.Windows.Forms.TextBox
        Me.edtActPosU = New System.Windows.Forms.TextBox
        Me.edtCmdVelX = New System.Windows.Forms.TextBox
        Me.edtCmdVelY = New System.Windows.Forms.TextBox
        Me.edtCmdVelZ = New System.Windows.Forms.TextBox
        Me.edtCmdVelU = New System.Windows.Forms.TextBox
        Me.Frame8 = New System.Windows.Forms.GroupBox
        Me.btnCircular = New System.Windows.Forms.Button
        Me.btnlinear = New System.Windows.Forms.Button
        Me.chkCwCcw = New System.Windows.Forms.CheckBox
        Me.edtAngle = New System.Windows.Forms.TextBox
        Me.edtYCen = New System.Windows.Forms.TextBox
        Me.edtXCen = New System.Windows.Forms.TextBox
        Me.Label46 = New System.Windows.Forms.Label
        Me.Label45 = New System.Windows.Forms.Label
        Me.Label44 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label27 = New System.Windows.Forms.Label
        Me.Label28 = New System.Windows.Forms.Label
        Me.Label36 = New System.Windows.Forms.Label
        Me.Label37 = New System.Windows.Forms.Label
        Me.Label38 = New System.Windows.Forms.Label
        Me.Label39 = New System.Windows.Forms.Label
        Me.Label40 = New System.Windows.Forms.Label
        Me.Label41 = New System.Windows.Forms.Label
        Me.Label42 = New System.Windows.Forms.Label
        Me.Label43 = New System.Windows.Forms.Label
        Me.Frame10 = New System.Windows.Forms.GroupBox
        Me.edtPosition = New System.Windows.Forms.TextBox
        Me.edtVelocity = New System.Windows.Forms.TextBox
        Me.edtAccel = New System.Windows.Forms.TextBox
        Me.edtDecel = New System.Windows.Forms.TextBox
        Me.chkAbsolute = New System.Windows.Forms.CheckBox
        Me.chkRelative = New System.Windows.Forms.CheckBox
        Me.chkAsym = New System.Windows.Forms.CheckBox
        Me.chkSCurve = New System.Windows.Forms.CheckBox
        Me.chkXYSyn = New System.Windows.Forms.CheckBox
        Me.btnMove = New System.Windows.Forms.Button
        Me.btnRepeat = New System.Windows.Forms.Button
        Me.btnStop = New System.Windows.Forms.Button
        Me.btnEstop = New System.Windows.Forms.Button
        Me.Label47 = New System.Windows.Forms.Label
        Me.Label48 = New System.Windows.Forms.Label
        Me.Label49 = New System.Windows.Forms.Label
        Me.Label50 = New System.Windows.Forms.Label
        Me.Frame1 = New System.Windows.Forms.GroupBox
        Me.Frame6 = New System.Windows.Forms.GroupBox
        Me.btnCRCOff = New System.Windows.Forms.Button
        Me.btnCRCOn = New System.Windows.Forms.Button
        Me.Frame5 = New System.Windows.Forms.GroupBox
        Me.btnMPGOff = New System.Windows.Forms.Button
        Me.btnMPGOn = New System.Windows.Forms.Button
        Me.Frame4 = New System.Windows.Forms.GroupBox
        Me.LedEmg = New System.Windows.Forms.PictureBox
        Me.LedZPhase = New System.Windows.Forms.PictureBox
        Me.LedHome = New System.Windows.Forms.PictureBox
        Me.LedAlarm = New System.Windows.Forms.PictureBox
        Me.LedInp = New System.Windows.Forms.PictureBox
        Me.LedNElm = New System.Windows.Forms.PictureBox
        Me.LedPElm = New System.Windows.Forms.PictureBox
        Me.Label35 = New System.Windows.Forms.Label
        Me.Label34 = New System.Windows.Forms.Label
        Me.Label33 = New System.Windows.Forms.Label
        Me.Label32 = New System.Windows.Forms.Label
        Me.Label31 = New System.Windows.Forms.Label
        Me.Label30 = New System.Windows.Forms.Label
        Me.Label29 = New System.Windows.Forms.Label
        Me.Frame3 = New System.Windows.Forms.GroupBox
        Me.LedOut2 = New System.Windows.Forms.PictureBox
        Me.LedOut5 = New System.Windows.Forms.PictureBox
        Me.LedOut4 = New System.Windows.Forms.PictureBox
        Me.LedOut3 = New System.Windows.Forms.PictureBox
        Me.LedOut0 = New System.Windows.Forms.PictureBox
        Me.LedOut1 = New System.Windows.Forms.PictureBox
        Me.LedIn5 = New System.Windows.Forms.PictureBox
        Me.LedIn4 = New System.Windows.Forms.PictureBox
        Me.LedIn3 = New System.Windows.Forms.PictureBox
        Me.LedIn2 = New System.Windows.Forms.PictureBox
        Me.LedIn0 = New System.Windows.Forms.PictureBox
        Me.LedIn1 = New System.Windows.Forms.PictureBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.m_grLevel = New System.Windows.Forms.GroupBox
        Me.cboLevel4 = New System.Windows.Forms.ComboBox
        Me.cboLevel3 = New System.Windows.Forms.ComboBox
        Me.cboLevel2 = New System.Windows.Forms.ComboBox
        Me.cboLevel1 = New System.Windows.Forms.ComboBox
        Me.cboLevel0 = New System.Windows.Forms.ComboBox
        Me.chkZPhaseLevel = New System.Windows.Forms.CheckBox
        Me.chkHomeLevel = New System.Windows.Forms.CheckBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.lbl = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me._Label2_1 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.btnJog = New Microsoft.VisualBasic.Compatibility.VB6.ButtonArray(Me.components)
        Me.tmHome = New Microsoft.VisualBasic.Compatibility.VB6.TimerArray(Me.components)
        Me.tmTest = New Microsoft.VisualBasic.Compatibility.VB6.TimerArray(Me.components)
        Me.XYPlot = New AxAxtXYGraphLib.AxAxtXYGraph
        Me.AxtMsg = New AxAXTMESSENGERLib.AxAxtMessenger
        Me.GraphX = New AxAXTGRAPHLib.AxAxtGraph
        Me.GraphY = New AxAXTGRAPHLib.AxAxtGraph
        Me.Frame15.SuspendLayout()
        Me.Frame16.SuspendLayout()
        Me.Frame17.SuspendLayout()
        Me.Frame19.SuspendLayout()
        Me.Frame13.SuspendLayout()
        Me.Frame18.SuspendLayout()
        Me.Frame20.SuspendLayout()
        Me.Frame12.SuspendLayout()
        Me.Frame11.SuspendLayout()
        CType(Me.LedEXMP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LedEXPP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LedBusyy, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LedBusyx, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Frame7.SuspendLayout()
        Me.Frame9.SuspendLayout()
        Me.Frame8.SuspendLayout()
        Me.Frame10.SuspendLayout()
        Me.Frame1.SuspendLayout()
        Me.Frame6.SuspendLayout()
        Me.Frame5.SuspendLayout()
        Me.Frame4.SuspendLayout()
        CType(Me.LedEmg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LedZPhase, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LedHome, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LedAlarm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LedInp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LedNElm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LedPElm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Frame3.SuspendLayout()
        CType(Me.LedOut2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LedOut5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LedOut4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LedOut3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LedOut0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LedOut1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LedIn5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LedIn4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LedIn3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LedIn2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LedIn0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LedIn1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.m_grLevel.SuspendLayout()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnJog, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tmHome, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tmTest, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XYPlot, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AxtMsg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GraphX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GraphY, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Frame15
        '
        Me.Frame15.BackColor = System.Drawing.SystemColors.Control
        Me.Frame15.Controls.Add(Me.Frame16)
        Me.Frame15.Controls.Add(Me.btnContiSpline)
        Me.Frame15.Controls.Add(Me.btnContiBlend)
        Me.Frame15.Controls.Add(Me.btnContiCircle)
        Me.Frame15.Controls.Add(Me.btnContiLine)
        Me.Frame15.Controls.Add(Me.btnContiTest)
        Me.Frame15.Controls.Add(Me.btnContiStart)
        Me.Frame15.Controls.Add(Me.btnContiClear)
        Me.Frame15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame15.Location = New System.Drawing.Point(835, 8)
        Me.Frame15.Name = "Frame15"
        Me.Frame15.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame15.Size = New System.Drawing.Size(174, 248)
        Me.Frame15.TabIndex = 202
        Me.Frame15.TabStop = False
        Me.Frame15.Text = "Conti Interpolation"
        '
        'Frame16
        '
        Me.Frame16.BackColor = System.Drawing.SystemColors.Control
        Me.Frame16.Controls.Add(Me.Label71)
        Me.Frame16.Controls.Add(Me.Label72)
        Me.Frame16.Controls.Add(Me.Label73)
        Me.Frame16.Controls.Add(Me.Label74)
        Me.Frame16.Controls.Add(Me.edtContiNum)
        Me.Frame16.Controls.Add(Me.edtTotalNum)
        Me.Frame16.Controls.Add(Me.edtQFree)
        Me.Frame16.Controls.Add(Me.edtInMotion)
        Me.Frame16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame16.Location = New System.Drawing.Point(0, 16)
        Me.Frame16.Name = "Frame16"
        Me.Frame16.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame16.Size = New System.Drawing.Size(174, 105)
        Me.Frame16.TabIndex = 210
        Me.Frame16.TabStop = False
        Me.Frame16.Text = "Conti Queue"
        '
        'Label71
        '
        Me.Label71.BackColor = System.Drawing.SystemColors.Control
        Me.Label71.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label71.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label71.Location = New System.Drawing.Point(8, 19)
        Me.Label71.Name = "Label71"
        Me.Label71.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label71.Size = New System.Drawing.Size(64, 17)
        Me.Label71.TabIndex = 218
        Me.Label71.Text = "ContiNum:"
        '
        'Label72
        '
        Me.Label72.BackColor = System.Drawing.SystemColors.Control
        Me.Label72.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label72.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label72.Location = New System.Drawing.Point(8, 40)
        Me.Label72.Name = "Label72"
        Me.Label72.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label72.Size = New System.Drawing.Size(64, 17)
        Me.Label72.TabIndex = 217
        Me.Label72.Text = "TotalNum:"
        '
        'Label73
        '
        Me.Label73.BackColor = System.Drawing.SystemColors.Control
        Me.Label73.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label73.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label73.Location = New System.Drawing.Point(8, 62)
        Me.Label73.Name = "Label73"
        Me.Label73.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label73.Size = New System.Drawing.Size(64, 17)
        Me.Label73.TabIndex = 216
        Me.Label73.Text = "Q free :"
        '
        'Label74
        '
        Me.Label74.BackColor = System.Drawing.SystemColors.Control
        Me.Label74.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label74.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label74.Location = New System.Drawing.Point(8, 83)
        Me.Label74.Name = "Label74"
        Me.Label74.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label74.Size = New System.Drawing.Size(64, 17)
        Me.Label74.TabIndex = 215
        Me.Label74.Text = "InMotion :"
        '
        'edtContiNum
        '
        Me.edtContiNum.BackColor = System.Drawing.SystemColors.Control
        Me.edtContiNum.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.edtContiNum.Cursor = System.Windows.Forms.Cursors.Default
        Me.edtContiNum.ForeColor = System.Drawing.SystemColors.ControlText
        Me.edtContiNum.Location = New System.Drawing.Point(75, 18)
        Me.edtContiNum.Name = "edtContiNum"
        Me.edtContiNum.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.edtContiNum.Size = New System.Drawing.Size(92, 17)
        Me.edtContiNum.TabIndex = 214
        Me.edtContiNum.Text = "0"
        Me.edtContiNum.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'edtTotalNum
        '
        Me.edtTotalNum.BackColor = System.Drawing.SystemColors.Control
        Me.edtTotalNum.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.edtTotalNum.Cursor = System.Windows.Forms.Cursors.Default
        Me.edtTotalNum.ForeColor = System.Drawing.SystemColors.ControlText
        Me.edtTotalNum.Location = New System.Drawing.Point(75, 38)
        Me.edtTotalNum.Name = "edtTotalNum"
        Me.edtTotalNum.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.edtTotalNum.Size = New System.Drawing.Size(92, 17)
        Me.edtTotalNum.TabIndex = 213
        Me.edtTotalNum.Text = "0"
        Me.edtTotalNum.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'edtQFree
        '
        Me.edtQFree.BackColor = System.Drawing.SystemColors.Control
        Me.edtQFree.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.edtQFree.Cursor = System.Windows.Forms.Cursors.Default
        Me.edtQFree.ForeColor = System.Drawing.SystemColors.ControlText
        Me.edtQFree.Location = New System.Drawing.Point(75, 59)
        Me.edtQFree.Name = "edtQFree"
        Me.edtQFree.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.edtQFree.Size = New System.Drawing.Size(92, 17)
        Me.edtQFree.TabIndex = 212
        Me.edtQFree.Text = "1"
        Me.edtQFree.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'edtInMotion
        '
        Me.edtInMotion.BackColor = System.Drawing.SystemColors.Control
        Me.edtInMotion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.edtInMotion.Cursor = System.Windows.Forms.Cursors.Default
        Me.edtInMotion.ForeColor = System.Drawing.SystemColors.ControlText
        Me.edtInMotion.Location = New System.Drawing.Point(75, 80)
        Me.edtInMotion.Name = "edtInMotion"
        Me.edtInMotion.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.edtInMotion.Size = New System.Drawing.Size(92, 17)
        Me.edtInMotion.TabIndex = 211
        Me.edtInMotion.Text = "0"
        Me.edtInMotion.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnContiSpline
        '
        Me.btnContiSpline.BackColor = System.Drawing.SystemColors.Control
        Me.btnContiSpline.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnContiSpline.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnContiSpline.Location = New System.Drawing.Point(8, 128)
        Me.btnContiSpline.Name = "btnContiSpline"
        Me.btnContiSpline.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnContiSpline.Size = New System.Drawing.Size(108, 25)
        Me.btnContiSpline.TabIndex = 209
        Me.btnContiSpline.Text = "2Axis Spline"
        Me.btnContiSpline.UseVisualStyleBackColor = False
        '
        'btnContiBlend
        '
        Me.btnContiBlend.BackColor = System.Drawing.SystemColors.Control
        Me.btnContiBlend.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnContiBlend.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnContiBlend.Location = New System.Drawing.Point(8, 156)
        Me.btnContiBlend.Name = "btnContiBlend"
        Me.btnContiBlend.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnContiBlend.Size = New System.Drawing.Size(108, 25)
        Me.btnContiBlend.TabIndex = 208
        Me.btnContiBlend.Text = "Line & Circle"
        Me.btnContiBlend.UseVisualStyleBackColor = False
        '
        'btnContiCircle
        '
        Me.btnContiCircle.BackColor = System.Drawing.SystemColors.Control
        Me.btnContiCircle.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnContiCircle.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnContiCircle.Location = New System.Drawing.Point(8, 184)
        Me.btnContiCircle.Name = "btnContiCircle"
        Me.btnContiCircle.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnContiCircle.Size = New System.Drawing.Size(54, 25)
        Me.btnContiCircle.TabIndex = 207
        Me.btnContiCircle.Text = "Circle"
        Me.btnContiCircle.UseVisualStyleBackColor = False
        '
        'btnContiLine
        '
        Me.btnContiLine.BackColor = System.Drawing.SystemColors.Control
        Me.btnContiLine.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnContiLine.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnContiLine.Location = New System.Drawing.Point(62, 184)
        Me.btnContiLine.Name = "btnContiLine"
        Me.btnContiLine.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnContiLine.Size = New System.Drawing.Size(54, 25)
        Me.btnContiLine.TabIndex = 206
        Me.btnContiLine.Text = "Line"
        Me.btnContiLine.UseVisualStyleBackColor = False
        '
        'btnContiTest
        '
        Me.btnContiTest.BackColor = System.Drawing.SystemColors.Control
        Me.btnContiTest.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnContiTest.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnContiTest.Location = New System.Drawing.Point(8, 213)
        Me.btnContiTest.Name = "btnContiTest"
        Me.btnContiTest.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnContiTest.Size = New System.Drawing.Size(108, 25)
        Me.btnContiTest.TabIndex = 205
        Me.btnContiTest.Text = "Verification"
        Me.btnContiTest.UseVisualStyleBackColor = False
        '
        'btnContiStart
        '
        Me.btnContiStart.BackColor = System.Drawing.SystemColors.Control
        Me.btnContiStart.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnContiStart.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnContiStart.Location = New System.Drawing.Point(117, 128)
        Me.btnContiStart.Name = "btnContiStart"
        Me.btnContiStart.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnContiStart.Size = New System.Drawing.Size(50, 54)
        Me.btnContiStart.TabIndex = 204
        Me.btnContiStart.Text = "Start"
        Me.btnContiStart.UseVisualStyleBackColor = False
        '
        'btnContiClear
        '
        Me.btnContiClear.BackColor = System.Drawing.SystemColors.Control
        Me.btnContiClear.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnContiClear.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnContiClear.Location = New System.Drawing.Point(117, 184)
        Me.btnContiClear.Name = "btnContiClear"
        Me.btnContiClear.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnContiClear.Size = New System.Drawing.Size(50, 54)
        Me.btnContiClear.TabIndex = 203
        Me.btnContiClear.Text = "CLR"
        Me.btnContiClear.UseVisualStyleBackColor = False
        '
        'Frame17
        '
        Me.Frame17.BackColor = System.Drawing.SystemColors.Control
        Me.Frame17.Controls.Add(Me.edtTrigStartPosition)
        Me.Frame17.Controls.Add(Me.edtTrigCycle)
        Me.Frame17.Controls.Add(Me.edtTrigPulseWidth)
        Me.Frame17.Controls.Add(Me.edtTrigEndPos)
        Me.Frame17.Controls.Add(Me.btnTrigAbs)
        Me.Frame17.Controls.Add(Me.btnTrigOneShot)
        Me.Frame17.Controls.Add(Me.btnTrigPeriod)
        Me.Frame17.Controls.Add(Me.btnTrigReset)
        Me.Frame17.Controls.Add(Me.Label60)
        Me.Frame17.Controls.Add(Me.Label61)
        Me.Frame17.Controls.Add(Me.Label62)
        Me.Frame17.Controls.Add(Me.Label63)
        Me.Frame17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame17.Location = New System.Drawing.Point(835, 290)
        Me.Frame17.Name = "Frame17"
        Me.Frame17.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame17.Size = New System.Drawing.Size(172, 169)
        Me.Frame17.TabIndex = 189
        Me.Frame17.TabStop = False
        Me.Frame17.Text = "Block / One Shot Trigger"
        '
        'edtTrigStartPosition
        '
        Me.edtTrigStartPosition.AcceptsReturn = True
        Me.edtTrigStartPosition.BackColor = System.Drawing.SystemColors.Window
        Me.edtTrigStartPosition.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.edtTrigStartPosition.ForeColor = System.Drawing.SystemColors.WindowText
        Me.edtTrigStartPosition.Location = New System.Drawing.Point(96, 20)
        Me.edtTrigStartPosition.MaxLength = 0
        Me.edtTrigStartPosition.Name = "edtTrigStartPosition"
        Me.edtTrigStartPosition.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.edtTrigStartPosition.Size = New System.Drawing.Size(74, 21)
        Me.edtTrigStartPosition.TabIndex = 197
        Me.edtTrigStartPosition.Text = "1000"
        Me.edtTrigStartPosition.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'edtTrigCycle
        '
        Me.edtTrigCycle.AcceptsReturn = True
        Me.edtTrigCycle.BackColor = System.Drawing.SystemColors.Window
        Me.edtTrigCycle.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.edtTrigCycle.ForeColor = System.Drawing.SystemColors.WindowText
        Me.edtTrigCycle.Location = New System.Drawing.Point(96, 43)
        Me.edtTrigCycle.MaxLength = 0
        Me.edtTrigCycle.Name = "edtTrigCycle"
        Me.edtTrigCycle.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.edtTrigCycle.Size = New System.Drawing.Size(74, 21)
        Me.edtTrigCycle.TabIndex = 196
        Me.edtTrigCycle.Text = "100"
        Me.edtTrigCycle.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'edtTrigPulseWidth
        '
        Me.edtTrigPulseWidth.AcceptsReturn = True
        Me.edtTrigPulseWidth.BackColor = System.Drawing.SystemColors.Window
        Me.edtTrigPulseWidth.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.edtTrigPulseWidth.ForeColor = System.Drawing.SystemColors.WindowText
        Me.edtTrigPulseWidth.Location = New System.Drawing.Point(96, 64)
        Me.edtTrigPulseWidth.MaxLength = 0
        Me.edtTrigPulseWidth.Name = "edtTrigPulseWidth"
        Me.edtTrigPulseWidth.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.edtTrigPulseWidth.Size = New System.Drawing.Size(74, 21)
        Me.edtTrigPulseWidth.TabIndex = 195
        Me.edtTrigPulseWidth.Text = "1000"
        Me.edtTrigPulseWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'edtTrigEndPos
        '
        Me.edtTrigEndPos.AcceptsReturn = True
        Me.edtTrigEndPos.BackColor = System.Drawing.SystemColors.Window
        Me.edtTrigEndPos.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.edtTrigEndPos.ForeColor = System.Drawing.SystemColors.WindowText
        Me.edtTrigEndPos.Location = New System.Drawing.Point(96, 88)
        Me.edtTrigEndPos.MaxLength = 0
        Me.edtTrigEndPos.Name = "edtTrigEndPos"
        Me.edtTrigEndPos.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.edtTrigEndPos.Size = New System.Drawing.Size(74, 21)
        Me.edtTrigEndPos.TabIndex = 194
        Me.edtTrigEndPos.Text = "5000"
        Me.edtTrigEndPos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnTrigAbs
        '
        Me.btnTrigAbs.BackColor = System.Drawing.SystemColors.Control
        Me.btnTrigAbs.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnTrigAbs.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnTrigAbs.Location = New System.Drawing.Point(8, 112)
        Me.btnTrigAbs.Name = "btnTrigAbs"
        Me.btnTrigAbs.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnTrigAbs.Size = New System.Drawing.Size(87, 25)
        Me.btnTrigAbs.TabIndex = 193
        Me.btnTrigAbs.Text = "Trig(Abs)"
        Me.btnTrigAbs.UseVisualStyleBackColor = False
        '
        'btnTrigOneShot
        '
        Me.btnTrigOneShot.BackColor = System.Drawing.SystemColors.Control
        Me.btnTrigOneShot.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnTrigOneShot.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnTrigOneShot.Location = New System.Drawing.Point(97, 111)
        Me.btnTrigOneShot.Name = "btnTrigOneShot"
        Me.btnTrigOneShot.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnTrigOneShot.Size = New System.Drawing.Size(70, 25)
        Me.btnTrigOneShot.TabIndex = 192
        Me.btnTrigOneShot.Text = "OneShot"
        Me.btnTrigOneShot.UseVisualStyleBackColor = False
        '
        'btnTrigPeriod
        '
        Me.btnTrigPeriod.BackColor = System.Drawing.SystemColors.Control
        Me.btnTrigPeriod.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnTrigPeriod.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnTrigPeriod.Location = New System.Drawing.Point(8, 138)
        Me.btnTrigPeriod.Name = "btnTrigPeriod"
        Me.btnTrigPeriod.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnTrigPeriod.Size = New System.Drawing.Size(87, 25)
        Me.btnTrigPeriod.TabIndex = 191
        Me.btnTrigPeriod.Text = "Trig(Period)"
        Me.btnTrigPeriod.UseVisualStyleBackColor = False
        '
        'btnTrigReset
        '
        Me.btnTrigReset.BackColor = System.Drawing.SystemColors.Control
        Me.btnTrigReset.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnTrigReset.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnTrigReset.Location = New System.Drawing.Point(97, 138)
        Me.btnTrigReset.Name = "btnTrigReset"
        Me.btnTrigReset.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnTrigReset.Size = New System.Drawing.Size(70, 25)
        Me.btnTrigReset.TabIndex = 190
        Me.btnTrigReset.Text = "Reset"
        Me.btnTrigReset.UseVisualStyleBackColor = False
        '
        'Label60
        '
        Me.Label60.BackColor = System.Drawing.SystemColors.Control
        Me.Label60.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label60.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label60.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label60.Location = New System.Drawing.Point(8, 20)
        Me.Label60.Name = "Label60"
        Me.Label60.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label60.Size = New System.Drawing.Size(87, 21)
        Me.Label60.TabIndex = 201
        Me.Label60.Text = "Start Position"
        Me.Label60.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label61
        '
        Me.Label61.BackColor = System.Drawing.SystemColors.Control
        Me.Label61.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label61.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label61.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label61.Location = New System.Drawing.Point(8, 43)
        Me.Label61.Name = "Label61"
        Me.Label61.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label61.Size = New System.Drawing.Size(87, 21)
        Me.Label61.TabIndex = 200
        Me.Label61.Text = "Cycle"
        Me.Label61.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label62
        '
        Me.Label62.BackColor = System.Drawing.SystemColors.Control
        Me.Label62.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label62.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label62.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label62.Location = New System.Drawing.Point(8, 66)
        Me.Label62.Name = "Label62"
        Me.Label62.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label62.Size = New System.Drawing.Size(87, 21)
        Me.Label62.TabIndex = 199
        Me.Label62.Text = "Pulse Width"
        Me.Label62.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label63
        '
        Me.Label63.BackColor = System.Drawing.SystemColors.Control
        Me.Label63.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label63.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label63.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label63.Location = New System.Drawing.Point(8, 88)
        Me.Label63.Name = "Label63"
        Me.Label63.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label63.Size = New System.Drawing.Size(87, 21)
        Me.Label63.TabIndex = 198
        Me.Label63.Text = "End Position"
        Me.Label63.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Frame19
        '
        Me.Frame19.BackColor = System.Drawing.SystemColors.Control
        Me.Frame19.Controls.Add(Me.btnHomeAll)
        Me.Frame19.Controls.Add(Me.btnHomeSingle)
        Me.Frame19.Controls.Add(Me.cboHomeDir)
        Me.Frame19.Controls.Add(Me.cboHomeSignal)
        Me.Frame19.Controls.Add(Me.edtHomeVelFirst)
        Me.Frame19.Controls.Add(Me.edtHomeVelSecond)
        Me.Frame19.Controls.Add(Me.edtHomeVelThird)
        Me.Frame19.Controls.Add(Me.edtHomeVelLast)
        Me.Frame19.Controls.Add(Me.Label64)
        Me.Frame19.Controls.Add(Me.Label65)
        Me.Frame19.Controls.Add(Me.Label66)
        Me.Frame19.Controls.Add(Me.Label67)
        Me.Frame19.Controls.Add(Me.Label68)
        Me.Frame19.Controls.Add(Me.Label69)
        Me.Frame19.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame19.Location = New System.Drawing.Point(835, 518)
        Me.Frame19.Name = "Frame19"
        Me.Frame19.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame19.Size = New System.Drawing.Size(172, 182)
        Me.Frame19.TabIndex = 174
        Me.Frame19.TabStop = False
        Me.Frame19.Text = "Home Search"
        '
        'btnHomeAll
        '
        Me.btnHomeAll.BackColor = System.Drawing.SystemColors.Control
        Me.btnHomeAll.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnHomeAll.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnHomeAll.Location = New System.Drawing.Point(8, 152)
        Me.btnHomeAll.Name = "btnHomeAll"
        Me.btnHomeAll.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnHomeAll.Size = New System.Drawing.Size(69, 23)
        Me.btnHomeAll.TabIndex = 182
        Me.btnHomeAll.Text = "All Home"
        Me.btnHomeAll.UseVisualStyleBackColor = False
        '
        'btnHomeSingle
        '
        Me.btnHomeSingle.BackColor = System.Drawing.SystemColors.Control
        Me.btnHomeSingle.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnHomeSingle.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnHomeSingle.Location = New System.Drawing.Point(80, 152)
        Me.btnHomeSingle.Name = "btnHomeSingle"
        Me.btnHomeSingle.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnHomeSingle.Size = New System.Drawing.Size(83, 23)
        Me.btnHomeSingle.TabIndex = 181
        Me.btnHomeSingle.Text = "Single Home"
        Me.btnHomeSingle.UseVisualStyleBackColor = False
        '
        'cboHomeDir
        '
        Me.cboHomeDir.BackColor = System.Drawing.SystemColors.Window
        Me.cboHomeDir.Cursor = System.Windows.Forms.Cursors.Default
        Me.cboHomeDir.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboHomeDir.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboHomeDir.Items.AddRange(New Object() {"(-)Direction", "(+)Direction"})
        Me.cboHomeDir.Location = New System.Drawing.Point(72, 128)
        Me.cboHomeDir.Name = "cboHomeDir"
        Me.cboHomeDir.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboHomeDir.Size = New System.Drawing.Size(94, 20)
        Me.cboHomeDir.TabIndex = 180
        '
        'cboHomeSignal
        '
        Me.cboHomeSignal.BackColor = System.Drawing.SystemColors.Window
        Me.cboHomeSignal.Cursor = System.Windows.Forms.Cursors.Default
        Me.cboHomeSignal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboHomeSignal.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboHomeSignal.Items.AddRange(New Object() {"PosEndLimit", "NegEndLimit", "HomeSensor"})
        Me.cboHomeSignal.Location = New System.Drawing.Point(72, 106)
        Me.cboHomeSignal.Name = "cboHomeSignal"
        Me.cboHomeSignal.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboHomeSignal.Size = New System.Drawing.Size(94, 20)
        Me.cboHomeSignal.TabIndex = 179
        '
        'edtHomeVelFirst
        '
        Me.edtHomeVelFirst.AcceptsReturn = True
        Me.edtHomeVelFirst.BackColor = System.Drawing.Color.Black
        Me.edtHomeVelFirst.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.edtHomeVelFirst.ForeColor = System.Drawing.Color.Yellow
        Me.edtHomeVelFirst.Location = New System.Drawing.Point(72, 18)
        Me.edtHomeVelFirst.MaxLength = 0
        Me.edtHomeVelFirst.Name = "edtHomeVelFirst"
        Me.edtHomeVelFirst.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.edtHomeVelFirst.Size = New System.Drawing.Size(94, 21)
        Me.edtHomeVelFirst.TabIndex = 178
        Me.edtHomeVelFirst.Text = "10000"
        Me.edtHomeVelFirst.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'edtHomeVelSecond
        '
        Me.edtHomeVelSecond.AcceptsReturn = True
        Me.edtHomeVelSecond.BackColor = System.Drawing.Color.Black
        Me.edtHomeVelSecond.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.edtHomeVelSecond.ForeColor = System.Drawing.Color.Yellow
        Me.edtHomeVelSecond.Location = New System.Drawing.Point(72, 40)
        Me.edtHomeVelSecond.MaxLength = 0
        Me.edtHomeVelSecond.Name = "edtHomeVelSecond"
        Me.edtHomeVelSecond.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.edtHomeVelSecond.Size = New System.Drawing.Size(94, 21)
        Me.edtHomeVelSecond.TabIndex = 177
        Me.edtHomeVelSecond.Text = "5000"
        Me.edtHomeVelSecond.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'edtHomeVelThird
        '
        Me.edtHomeVelThird.AcceptsReturn = True
        Me.edtHomeVelThird.BackColor = System.Drawing.Color.Black
        Me.edtHomeVelThird.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.edtHomeVelThird.ForeColor = System.Drawing.Color.Yellow
        Me.edtHomeVelThird.Location = New System.Drawing.Point(72, 61)
        Me.edtHomeVelThird.MaxLength = 0
        Me.edtHomeVelThird.Name = "edtHomeVelThird"
        Me.edtHomeVelThird.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.edtHomeVelThird.Size = New System.Drawing.Size(94, 21)
        Me.edtHomeVelThird.TabIndex = 176
        Me.edtHomeVelThird.Text = "1000"
        Me.edtHomeVelThird.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'edtHomeVelLast
        '
        Me.edtHomeVelLast.AcceptsReturn = True
        Me.edtHomeVelLast.BackColor = System.Drawing.Color.Black
        Me.edtHomeVelLast.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.edtHomeVelLast.ForeColor = System.Drawing.Color.Yellow
        Me.edtHomeVelLast.Location = New System.Drawing.Point(72, 84)
        Me.edtHomeVelLast.MaxLength = 0
        Me.edtHomeVelLast.Name = "edtHomeVelLast"
        Me.edtHomeVelLast.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.edtHomeVelLast.Size = New System.Drawing.Size(94, 21)
        Me.edtHomeVelLast.TabIndex = 175
        Me.edtHomeVelLast.Text = "100"
        Me.edtHomeVelLast.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label64
        '
        Me.Label64.BackColor = System.Drawing.SystemColors.Control
        Me.Label64.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label64.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label64.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label64.Location = New System.Drawing.Point(8, 18)
        Me.Label64.Name = "Label64"
        Me.Label64.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label64.Size = New System.Drawing.Size(64, 17)
        Me.Label64.TabIndex = 188
        Me.Label64.Text = "Vel First"
        Me.Label64.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label65
        '
        Me.Label65.BackColor = System.Drawing.SystemColors.Control
        Me.Label65.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label65.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label65.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label65.Location = New System.Drawing.Point(8, 61)
        Me.Label65.Name = "Label65"
        Me.Label65.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label65.Size = New System.Drawing.Size(63, 17)
        Me.Label65.TabIndex = 187
        Me.Label65.Text = "Vel Again"
        Me.Label65.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label66
        '
        Me.Label66.BackColor = System.Drawing.SystemColors.Control
        Me.Label66.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label66.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label66.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label66.Location = New System.Drawing.Point(8, 84)
        Me.Label66.Name = "Label66"
        Me.Label66.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label66.Size = New System.Drawing.Size(63, 17)
        Me.Label66.TabIndex = 186
        Me.Label66.Text = "Vel Last"
        Me.Label66.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label67
        '
        Me.Label67.BackColor = System.Drawing.SystemColors.Control
        Me.Label67.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label67.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label67.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label67.Location = New System.Drawing.Point(8, 40)
        Me.Label67.Name = "Label67"
        Me.Label67.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label67.Size = New System.Drawing.Size(64, 17)
        Me.Label67.TabIndex = 185
        Me.Label67.Text = "Vel After"
        Me.Label67.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label68
        '
        Me.Label68.BackColor = System.Drawing.SystemColors.Control
        Me.Label68.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label68.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label68.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label68.Location = New System.Drawing.Point(8, 106)
        Me.Label68.Name = "Label68"
        Me.Label68.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label68.Size = New System.Drawing.Size(63, 17)
        Me.Label68.TabIndex = 184
        Me.Label68.Text = "Signal"
        Me.Label68.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label69
        '
        Me.Label69.BackColor = System.Drawing.SystemColors.Control
        Me.Label69.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label69.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label69.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label69.Location = New System.Drawing.Point(8, 128)
        Me.Label69.Name = "Label69"
        Me.Label69.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label69.Size = New System.Drawing.Size(63, 17)
        Me.Label69.TabIndex = 183
        Me.Label69.Text = "Direction"
        Me.Label69.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lstLog
        '
        Me.lstLog.BackColor = System.Drawing.SystemColors.Window
        Me.lstLog.Cursor = System.Windows.Forms.Cursors.Default
        Me.lstLog.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lstLog.ItemHeight = 12
        Me.lstLog.Location = New System.Drawing.Point(634, 492)
        Me.lstLog.Name = "lstLog"
        Me.lstLog.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lstLog.Size = New System.Drawing.Size(194, 208)
        Me.lstLog.TabIndex = 105
        '
        'Frame13
        '
        Me.Frame13.BackColor = System.Drawing.SystemColors.Control
        Me.Frame13.Controls.Add(Me.btnsearch)
        Me.Frame13.Controls.Add(Me.cboDetect)
        Me.Frame13.Controls.Add(Me.cboDirection)
        Me.Frame13.Controls.Add(Me.cboStopM)
        Me.Frame13.Controls.Add(Me.Label57)
        Me.Frame13.Controls.Add(Me.Label58)
        Me.Frame13.Controls.Add(Me.Label59)
        Me.Frame13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame13.Location = New System.Drawing.Point(635, 363)
        Me.Frame13.Name = "Frame13"
        Me.Frame13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame13.Size = New System.Drawing.Size(194, 121)
        Me.Frame13.TabIndex = 97
        Me.Frame13.TabStop = False
        Me.Frame13.Text = "Signal Search"
        '
        'btnsearch
        '
        Me.btnsearch.BackColor = System.Drawing.SystemColors.Control
        Me.btnsearch.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnsearch.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnsearch.Location = New System.Drawing.Point(8, 88)
        Me.btnsearch.Name = "btnsearch"
        Me.btnsearch.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnsearch.Size = New System.Drawing.Size(180, 25)
        Me.btnsearch.TabIndex = 101
        Me.btnsearch.Text = "Search"
        Me.btnsearch.UseVisualStyleBackColor = False
        '
        'cboDetect
        '
        Me.cboDetect.BackColor = System.Drawing.SystemColors.Window
        Me.cboDetect.Cursor = System.Windows.Forms.Cursors.Default
        Me.cboDetect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDetect.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboDetect.Items.AddRange(New Object() {"PosEndLimit (0)", "NegEndLimit (1)", "HomeSensor DN (4)", "EncZPhase DN (5)", "UniInput02 DN (6)", "UniInput03 DN (7)", "HomeSensor UP (4)", "EncZPhase UP (5)", "UniInput02 UP (6)", "UniInput03 UP (7)"})
        Me.cboDetect.Location = New System.Drawing.Point(89, 16)
        Me.cboDetect.Name = "cboDetect"
        Me.cboDetect.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboDetect.Size = New System.Drawing.Size(98, 20)
        Me.cboDetect.TabIndex = 100
        '
        'cboDirection
        '
        Me.cboDirection.BackColor = System.Drawing.SystemColors.Window
        Me.cboDirection.Cursor = System.Windows.Forms.Cursors.Default
        Me.cboDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDirection.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboDirection.Items.AddRange(New Object() {"+ CW", "- CCW"})
        Me.cboDirection.Location = New System.Drawing.Point(88, 40)
        Me.cboDirection.Name = "cboDirection"
        Me.cboDirection.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboDirection.Size = New System.Drawing.Size(98, 20)
        Me.cboDirection.TabIndex = 99
        '
        'cboStopM
        '
        Me.cboStopM.BackColor = System.Drawing.SystemColors.Window
        Me.cboStopM.Cursor = System.Windows.Forms.Cursors.Default
        Me.cboStopM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStopM.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboStopM.Items.AddRange(New Object() {"ESTOP", "SSTOP"})
        Me.cboStopM.Location = New System.Drawing.Point(89, 64)
        Me.cboStopM.Name = "cboStopM"
        Me.cboStopM.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboStopM.Size = New System.Drawing.Size(98, 20)
        Me.cboStopM.TabIndex = 98
        '
        'Label57
        '
        Me.Label57.BackColor = System.Drawing.SystemColors.Control
        Me.Label57.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label57.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label57.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label57.Location = New System.Drawing.Point(8, 16)
        Me.Label57.Name = "Label57"
        Me.Label57.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label57.Size = New System.Drawing.Size(81, 17)
        Me.Label57.TabIndex = 104
        Me.Label57.Text = "Detect signal"
        Me.Label57.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label58
        '
        Me.Label58.BackColor = System.Drawing.SystemColors.Control
        Me.Label58.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label58.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label58.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label58.Location = New System.Drawing.Point(8, 40)
        Me.Label58.Name = "Label58"
        Me.Label58.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label58.Size = New System.Drawing.Size(73, 17)
        Me.Label58.TabIndex = 103
        Me.Label58.Text = "Direction"
        Me.Label58.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label59
        '
        Me.Label59.BackColor = System.Drawing.SystemColors.Control
        Me.Label59.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label59.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label59.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label59.Location = New System.Drawing.Point(8, 64)
        Me.Label59.Name = "Label59"
        Me.Label59.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label59.Size = New System.Drawing.Size(81, 17)
        Me.Label59.TabIndex = 102
        Me.Label59.Text = "Stop Method"
        Me.Label59.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_tmTest_3
        '
        Me.tmTest.SetIndex(Me._tmTest_3, CType(3, Short))
        '
        '_tmTest_2
        '
        Me.tmTest.SetIndex(Me._tmTest_2, CType(2, Short))
        '
        '_tmTest_1
        '
        Me.tmTest.SetIndex(Me._tmTest_1, CType(1, Short))
        '
        '_tmTest_0
        '
        Me.tmTest.SetIndex(Me._tmTest_0, CType(0, Short))
        '
        '_tmHome_3
        '
        Me.tmHome.SetIndex(Me._tmHome_3, CType(3, Short))
        '
        '_tmHome_2
        '
        Me.tmHome.SetIndex(Me._tmHome_2, CType(2, Short))
        '
        '_tmHome_1
        '
        Me.tmHome.SetIndex(Me._tmHome_1, CType(1, Short))
        '
        '_tmHome_0
        '
        Me.tmHome.SetIndex(Me._tmHome_0, CType(0, Short))
        '
        'tmGraph
        '
        Me.tmGraph.Interval = 50
        '
        'tmDisplay
        '
        Me.tmDisplay.Interval = 50
        '
        'chkGearOnOff
        '
        Me.chkGearOnOff.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkGearOnOff.BackColor = System.Drawing.SystemColors.Control
        Me.chkGearOnOff.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkGearOnOff.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkGearOnOff.ForeColor = System.Drawing.SystemColors.WindowText
        Me.chkGearOnOff.Location = New System.Drawing.Point(839, 262)
        Me.chkGearOnOff.Name = "chkGearOnOff"
        Me.chkGearOnOff.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkGearOnOff.Size = New System.Drawing.Size(89, 22)
        Me.chkGearOnOff.TabIndex = 93
        Me.chkGearOnOff.Text = "Gear On/Off"
        Me.chkGearOnOff.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkGearOnOff.UseVisualStyleBackColor = False
        '
        'Frame18
        '
        Me.Frame18.BackColor = System.Drawing.SystemColors.Control
        Me.Frame18.Controls.Add(Me.btnSigCapture)
        Me.Frame18.Controls.Add(Me.btnVelOverride)
        Me.Frame18.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame18.Location = New System.Drawing.Point(835, 464)
        Me.Frame18.Name = "Frame18"
        Me.Frame18.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame18.Size = New System.Drawing.Size(172, 50)
        Me.Frame18.TabIndex = 88
        Me.Frame18.TabStop = False
        Me.Frame18.Text = "Override & CaptureMove"
        '
        'btnSigCapture
        '
        Me.btnSigCapture.BackColor = System.Drawing.SystemColors.Control
        Me.btnSigCapture.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnSigCapture.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnSigCapture.Location = New System.Drawing.Point(8, 16)
        Me.btnSigCapture.Name = "btnSigCapture"
        Me.btnSigCapture.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnSigCapture.Size = New System.Drawing.Size(89, 25)
        Me.btnSigCapture.TabIndex = 90
        Me.btnSigCapture.Text = "CaptureMove"
        Me.btnSigCapture.UseVisualStyleBackColor = False
        '
        'btnVelOverride
        '
        Me.btnVelOverride.BackColor = System.Drawing.SystemColors.Control
        Me.btnVelOverride.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnVelOverride.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnVelOverride.Location = New System.Drawing.Point(100, 16)
        Me.btnVelOverride.Name = "btnVelOverride"
        Me.btnVelOverride.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnVelOverride.Size = New System.Drawing.Size(66, 25)
        Me.btnVelOverride.TabIndex = 89
        Me.btnVelOverride.Text = "Override"
        Me.btnVelOverride.UseVisualStyleBackColor = False
        '
        'Frame20
        '
        Me.Frame20.BackColor = System.Drawing.SystemColors.Control
        Me.Frame20.Controls.Add(Me.btnReadCapture)
        Me.Frame20.Controls.Add(Me.edtCapturePos)
        Me.Frame20.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame20.Location = New System.Drawing.Point(835, 703)
        Me.Frame20.Name = "Frame20"
        Me.Frame20.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame20.Size = New System.Drawing.Size(172, 42)
        Me.Frame20.TabIndex = 85
        Me.Frame20.TabStop = False
        Me.Frame20.Text = "Capture Positon"
        '
        'btnReadCapture
        '
        Me.btnReadCapture.BackColor = System.Drawing.SystemColors.Control
        Me.btnReadCapture.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnReadCapture.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnReadCapture.Location = New System.Drawing.Point(8, 16)
        Me.btnReadCapture.Name = "btnReadCapture"
        Me.btnReadCapture.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnReadCapture.Size = New System.Drawing.Size(57, 19)
        Me.btnReadCapture.TabIndex = 94
        Me.btnReadCapture.Text = "GetPos"
        Me.btnReadCapture.UseVisualStyleBackColor = False
        '
        'edtCapturePos
        '
        Me.edtCapturePos.BackColor = System.Drawing.SystemColors.Control
        Me.edtCapturePos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.edtCapturePos.Cursor = System.Windows.Forms.Cursors.Default
        Me.edtCapturePos.ForeColor = System.Drawing.SystemColors.ControlText
        Me.edtCapturePos.Location = New System.Drawing.Point(72, 16)
        Me.edtCapturePos.Name = "edtCapturePos"
        Me.edtCapturePos.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.edtCapturePos.Size = New System.Drawing.Size(94, 18)
        Me.edtCapturePos.TabIndex = 86
        Me.edtCapturePos.Text = "0.000"
        Me.edtCapturePos.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'edtGearRatio
        '
        Me.edtGearRatio.AcceptsReturn = True
        Me.edtGearRatio.BackColor = System.Drawing.SystemColors.Window
        Me.edtGearRatio.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.edtGearRatio.ForeColor = System.Drawing.SystemColors.WindowText
        Me.edtGearRatio.Location = New System.Drawing.Point(933, 263)
        Me.edtGearRatio.MaxLength = 0
        Me.edtGearRatio.Name = "edtGearRatio"
        Me.edtGearRatio.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.edtGearRatio.Size = New System.Drawing.Size(76, 21)
        Me.edtGearRatio.TabIndex = 84
        Me.edtGearRatio.Text = "1.000"
        Me.edtGearRatio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.SystemColors.Control
        Me.btnSave.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnSave.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnSave.Location = New System.Drawing.Point(733, 331)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnSave.Size = New System.Drawing.Size(88, 25)
        Me.btnSave.TabIndex = 83
        Me.btnSave.Text = "SAVE"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'btnStatus
        '
        Me.btnStatus.BackColor = System.Drawing.SystemColors.Control
        Me.btnStatus.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnStatus.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnStatus.Location = New System.Drawing.Point(642, 331)
        Me.btnStatus.Name = "btnStatus"
        Me.btnStatus.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnStatus.Size = New System.Drawing.Size(88, 25)
        Me.btnStatus.TabIndex = 82
        Me.btnStatus.Text = "STATUS"
        Me.btnStatus.UseVisualStyleBackColor = False
        '
        'btnLoad
        '
        Me.btnLoad.BackColor = System.Drawing.SystemColors.Control
        Me.btnLoad.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnLoad.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnLoad.Location = New System.Drawing.Point(733, 301)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnLoad.Size = New System.Drawing.Size(88, 25)
        Me.btnLoad.TabIndex = 81
        Me.btnLoad.Text = "LOAD"
        Me.btnLoad.UseVisualStyleBackColor = False
        '
        'btnManualSet
        '
        Me.btnManualSet.BackColor = System.Drawing.SystemColors.Control
        Me.btnManualSet.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnManualSet.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnManualSet.Location = New System.Drawing.Point(642, 301)
        Me.btnManualSet.Name = "btnManualSet"
        Me.btnManualSet.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnManualSet.Size = New System.Drawing.Size(88, 25)
        Me.btnManualSet.TabIndex = 80
        Me.btnManualSet.Text = "Manual Set"
        Me.btnManualSet.UseVisualStyleBackColor = False
        '
        'Frame12
        '
        Me.Frame12.BackColor = System.Drawing.SystemColors.Control
        Me.Frame12.Controls.Add(Me.btnIntDisable)
        Me.Frame12.Controls.Add(Me.btnIntCallback)
        Me.Frame12.Controls.Add(Me.btnIntEvent)
        Me.Frame12.Controls.Add(Me.btnIntMessage)
        Me.Frame12.Controls.Add(Me.edtIntCount)
        Me.Frame12.Controls.Add(Me.Label55)
        Me.Frame12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame12.Location = New System.Drawing.Point(347, 704)
        Me.Frame12.Name = "Frame12"
        Me.Frame12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame12.Size = New System.Drawing.Size(480, 41)
        Me.Frame12.TabIndex = 73
        Me.Frame12.TabStop = False
        Me.Frame12.Text = "Interrupt Method Setting"
        '
        'btnIntDisable
        '
        Me.btnIntDisable.BackColor = System.Drawing.SystemColors.Control
        Me.btnIntDisable.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnIntDisable.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnIntDisable.Location = New System.Drawing.Point(246, 14)
        Me.btnIntDisable.Name = "btnIntDisable"
        Me.btnIntDisable.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnIntDisable.Size = New System.Drawing.Size(78, 21)
        Me.btnIntDisable.TabIndex = 77
        Me.btnIntDisable.Text = "DISABLE"
        Me.btnIntDisable.UseVisualStyleBackColor = False
        '
        'btnIntCallback
        '
        Me.btnIntCallback.BackColor = System.Drawing.SystemColors.Control
        Me.btnIntCallback.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnIntCallback.Enabled = False
        Me.btnIntCallback.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnIntCallback.Location = New System.Drawing.Point(166, 14)
        Me.btnIntCallback.Name = "btnIntCallback"
        Me.btnIntCallback.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnIntCallback.Size = New System.Drawing.Size(78, 21)
        Me.btnIntCallback.TabIndex = 76
        Me.btnIntCallback.Text = "CallBack"
        Me.btnIntCallback.UseVisualStyleBackColor = False
        '
        'btnIntEvent
        '
        Me.btnIntEvent.BackColor = System.Drawing.SystemColors.Control
        Me.btnIntEvent.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnIntEvent.Enabled = False
        Me.btnIntEvent.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnIntEvent.Location = New System.Drawing.Point(88, 14)
        Me.btnIntEvent.Name = "btnIntEvent"
        Me.btnIntEvent.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnIntEvent.Size = New System.Drawing.Size(78, 21)
        Me.btnIntEvent.TabIndex = 75
        Me.btnIntEvent.Text = "Event"
        Me.btnIntEvent.UseVisualStyleBackColor = False
        '
        'btnIntMessage
        '
        Me.btnIntMessage.BackColor = System.Drawing.SystemColors.Control
        Me.btnIntMessage.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnIntMessage.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnIntMessage.Location = New System.Drawing.Point(8, 14)
        Me.btnIntMessage.Name = "btnIntMessage"
        Me.btnIntMessage.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnIntMessage.Size = New System.Drawing.Size(78, 21)
        Me.btnIntMessage.TabIndex = 74
        Me.btnIntMessage.Text = "Message"
        Me.btnIntMessage.UseVisualStyleBackColor = False
        '
        'edtIntCount
        '
        Me.edtIntCount.BackColor = System.Drawing.SystemColors.Control
        Me.edtIntCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.edtIntCount.Cursor = System.Windows.Forms.Cursors.Default
        Me.edtIntCount.ForeColor = System.Drawing.SystemColors.ControlText
        Me.edtIntCount.Location = New System.Drawing.Point(424, 16)
        Me.edtIntCount.Name = "edtIntCount"
        Me.edtIntCount.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.edtIntCount.Size = New System.Drawing.Size(49, 17)
        Me.edtIntCount.TabIndex = 79
        Me.edtIntCount.Text = "0"
        Me.edtIntCount.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label55
        '
        Me.Label55.BackColor = System.Drawing.SystemColors.Control
        Me.Label55.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label55.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label55.Location = New System.Drawing.Point(335, 16)
        Me.Label55.Name = "Label55"
        Me.Label55.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label55.Size = New System.Drawing.Size(89, 17)
        Me.Label55.TabIndex = 78
        Me.Label55.Text = "Interrupt Count:"
        '
        'Frame11
        '
        Me.Frame11.BackColor = System.Drawing.SystemColors.Control
        Me.Frame11.Controls.Add(Me.LedEXMP)
        Me.Frame11.Controls.Add(Me.LedEXPP)
        Me.Frame11.Controls.Add(Me.LedBusyy)
        Me.Frame11.Controls.Add(Me.LedBusyx)
        Me.Frame11.Controls.Add(Me.Label54)
        Me.Frame11.Controls.Add(Me.Label53)
        Me.Frame11.Controls.Add(Me.Label52)
        Me.Frame11.Controls.Add(Me.Label51)
        Me.Frame11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame11.Location = New System.Drawing.Point(3, 703)
        Me.Frame11.Name = "Frame11"
        Me.Frame11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame11.Size = New System.Drawing.Size(337, 42)
        Me.Frame11.TabIndex = 64
        Me.Frame11.TabStop = False
        Me.Frame11.Text = "ETC"
        '
        'LedEXMP
        '
        Me.LedEXMP.BackColor = System.Drawing.Color.Red
        Me.LedEXMP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LedEXMP.Cursor = System.Windows.Forms.Cursors.Default
        Me.LedEXMP.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LedEXMP.Location = New System.Drawing.Point(312, 16)
        Me.LedEXMP.Name = "LedEXMP"
        Me.LedEXMP.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LedEXMP.Size = New System.Drawing.Size(17, 17)
        Me.LedEXMP.TabIndex = 72
        Me.LedEXMP.TabStop = False
        '
        'LedEXPP
        '
        Me.LedEXPP.BackColor = System.Drawing.Color.Red
        Me.LedEXPP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LedEXPP.Cursor = System.Windows.Forms.Cursors.Default
        Me.LedEXPP.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LedEXPP.Location = New System.Drawing.Point(242, 16)
        Me.LedEXPP.Name = "LedEXPP"
        Me.LedEXPP.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LedEXPP.Size = New System.Drawing.Size(17, 17)
        Me.LedEXPP.TabIndex = 71
        Me.LedEXPP.TabStop = False
        '
        'LedBusyy
        '
        Me.LedBusyy.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LedBusyy.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LedBusyy.Cursor = System.Windows.Forms.Cursors.Default
        Me.LedBusyy.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LedBusyy.Location = New System.Drawing.Point(172, 16)
        Me.LedBusyy.Name = "LedBusyy"
        Me.LedBusyy.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LedBusyy.Size = New System.Drawing.Size(17, 17)
        Me.LedBusyy.TabIndex = 70
        Me.LedBusyy.TabStop = False
        '
        'LedBusyx
        '
        Me.LedBusyx.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LedBusyx.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LedBusyx.Cursor = System.Windows.Forms.Cursors.Default
        Me.LedBusyx.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LedBusyx.Location = New System.Drawing.Point(76, 16)
        Me.LedBusyx.Name = "LedBusyx"
        Me.LedBusyx.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LedBusyx.Size = New System.Drawing.Size(17, 17)
        Me.LedBusyx.TabIndex = 69
        Me.LedBusyx.TabStop = False
        '
        'Label54
        '
        Me.Label54.BackColor = System.Drawing.SystemColors.Control
        Me.Label54.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label54.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label54.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label54.Location = New System.Drawing.Point(262, 16)
        Me.Label54.Name = "Label54"
        Me.Label54.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label54.Size = New System.Drawing.Size(49, 17)
        Me.Label54.TabIndex = 68
        Me.Label54.Text = "EXMP"
        Me.Label54.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label53
        '
        Me.Label53.BackColor = System.Drawing.SystemColors.Control
        Me.Label53.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label53.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label53.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label53.Location = New System.Drawing.Point(190, 16)
        Me.Label53.Name = "Label53"
        Me.Label53.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label53.Size = New System.Drawing.Size(49, 17)
        Me.Label53.TabIndex = 67
        Me.Label53.Text = "EXPP"
        Me.Label53.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label52
        '
        Me.Label52.BackColor = System.Drawing.SystemColors.Control
        Me.Label52.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label52.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label52.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label52.Location = New System.Drawing.Point(96, 16)
        Me.Label52.Name = "Label52"
        Me.Label52.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label52.Size = New System.Drawing.Size(73, 17)
        Me.Label52.TabIndex = 66
        Me.Label52.Text = "Y axis ON"
        Me.Label52.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label51
        '
        Me.Label51.BackColor = System.Drawing.SystemColors.Control
        Me.Label51.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label51.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label51.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label51.Location = New System.Drawing.Point(8, 16)
        Me.Label51.Name = "Label51"
        Me.Label51.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label51.Size = New System.Drawing.Size(65, 17)
        Me.Label51.TabIndex = 65
        Me.Label51.Text = "X axis ON"
        Me.Label51.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_btnJog_4
        '
        Me._btnJog_4.BackColor = System.Drawing.SystemColors.Control
        Me._btnJog_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._btnJog_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnJog.SetIndex(Me._btnJog_4, CType(4, Short))
        Me._btnJog_4.Location = New System.Drawing.Point(581, 439)
        Me._btnJog_4.Name = "_btnJog_4"
        Me._btnJog_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._btnJog_4.Size = New System.Drawing.Size(22, 20)
        Me._btnJog_4.TabIndex = 62
        Me._btnJog_4.Text = "+"
        Me._btnJog_4.UseVisualStyleBackColor = False
        '
        '_btnJog_6
        '
        Me._btnJog_6.BackColor = System.Drawing.SystemColors.Control
        Me._btnJog_6.Cursor = System.Windows.Forms.Cursors.Default
        Me._btnJog_6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnJog.SetIndex(Me._btnJog_6, CType(6, Short))
        Me._btnJog_6.Location = New System.Drawing.Point(581, 462)
        Me._btnJog_6.Name = "_btnJog_6"
        Me._btnJog_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._btnJog_6.Size = New System.Drawing.Size(22, 20)
        Me._btnJog_6.TabIndex = 61
        Me._btnJog_6.Text = "+"
        Me._btnJog_6.UseVisualStyleBackColor = False
        '
        '_btnJog_2
        '
        Me._btnJog_2.BackColor = System.Drawing.SystemColors.Control
        Me._btnJog_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._btnJog_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnJog.SetIndex(Me._btnJog_2, CType(2, Short))
        Me._btnJog_2.Location = New System.Drawing.Point(581, 415)
        Me._btnJog_2.Name = "_btnJog_2"
        Me._btnJog_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._btnJog_2.Size = New System.Drawing.Size(22, 20)
        Me._btnJog_2.TabIndex = 60
        Me._btnJog_2.Text = "+"
        Me._btnJog_2.UseVisualStyleBackColor = False
        '
        'btn3DGraph
        '
        Me.btn3DGraph.BackColor = System.Drawing.SystemColors.Control
        Me.btn3DGraph.Cursor = System.Windows.Forms.Cursors.Default
        Me.btn3DGraph.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btn3DGraph.Location = New System.Drawing.Point(159, 294)
        Me.btn3DGraph.Name = "btn3DGraph"
        Me.btn3DGraph.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btn3DGraph.Size = New System.Drawing.Size(69, 22)
        Me.btn3DGraph.TabIndex = 3
        Me.btn3DGraph.Text = "3D Graph"
        Me.btn3DGraph.UseVisualStyleBackColor = False
        '
        'cboAxisSet
        '
        Me.cboAxisSet.BackColor = System.Drawing.SystemColors.Window
        Me.cboAxisSet.Cursor = System.Windows.Forms.Cursors.Default
        Me.cboAxisSet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAxisSet.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboAxisSet.Location = New System.Drawing.Point(78, 318)
        Me.cboAxisSet.Name = "cboAxisSet"
        Me.cboAxisSet.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboAxisSet.Size = New System.Drawing.Size(150, 20)
        Me.cboAxisSet.TabIndex = 1
        '
        'edtMoveUnit
        '
        Me.edtMoveUnit.AcceptsReturn = True
        Me.edtMoveUnit.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.edtMoveUnit.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.edtMoveUnit.Font = New System.Drawing.Font("굴림", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.edtMoveUnit.ForeColor = System.Drawing.Color.Yellow
        Me.edtMoveUnit.Location = New System.Drawing.Point(78, 294)
        Me.edtMoveUnit.MaxLength = 0
        Me.edtMoveUnit.Name = "edtMoveUnit"
        Me.edtMoveUnit.ReadOnly = True
        Me.edtMoveUnit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.edtMoveUnit.Size = New System.Drawing.Size(79, 22)
        Me.edtMoveUnit.TabIndex = 63
        Me.edtMoveUnit.Text = "1"
        Me.edtMoveUnit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Frame7
        '
        Me.Frame7.BackColor = System.Drawing.SystemColors.Control
        Me.Frame7.Controls.Add(Me.edtUnit)
        Me.Frame7.Controls.Add(Me.edtPulse)
        Me.Frame7.Controls.Add(Me.btnSetting)
        Me.Frame7.Controls.Add(Me.edtStartSpeed)
        Me.Frame7.Controls.Add(Me.cboPulseOutM)
        Me.Frame7.Controls.Add(Me.cboEncInputM)
        Me.Frame7.Controls.Add(Me.btnCountclr)
        Me.Frame7.Controls.Add(Me.Frame9)
        Me.Frame7.Controls.Add(Me._btnJog_1)
        Me.Frame7.Controls.Add(Me._btnJog_3)
        Me.Frame7.Controls.Add(Me._btnJog_5)
        Me.Frame7.Controls.Add(Me._btnJog_7)
        Me.Frame7.Controls.Add(Me._btnJog_0)
        Me.Frame7.Controls.Add(Me.edtCmdPosX)
        Me.Frame7.Controls.Add(Me.edtCmdPosY)
        Me.Frame7.Controls.Add(Me.edtCmdPosZ)
        Me.Frame7.Controls.Add(Me.edtCmdPosU)
        Me.Frame7.Controls.Add(Me.edtActPosX)
        Me.Frame7.Controls.Add(Me.edtActPosY)
        Me.Frame7.Controls.Add(Me.edtActPosZ)
        Me.Frame7.Controls.Add(Me.edtActPosU)
        Me.Frame7.Controls.Add(Me.edtCmdVelX)
        Me.Frame7.Controls.Add(Me.edtCmdVelY)
        Me.Frame7.Controls.Add(Me.edtCmdVelZ)
        Me.Frame7.Controls.Add(Me.edtCmdVelU)
        Me.Frame7.Controls.Add(Me.Frame8)
        Me.Frame7.Controls.Add(Me.Label6)
        Me.Frame7.Controls.Add(Me.Label26)
        Me.Frame7.Controls.Add(Me.Label25)
        Me.Frame7.Controls.Add(Me.Label27)
        Me.Frame7.Controls.Add(Me.Label28)
        Me.Frame7.Controls.Add(Me.Label36)
        Me.Frame7.Controls.Add(Me.Label37)
        Me.Frame7.Controls.Add(Me.Label38)
        Me.Frame7.Controls.Add(Me.Label39)
        Me.Frame7.Controls.Add(Me.Label40)
        Me.Frame7.Controls.Add(Me.Label41)
        Me.Frame7.Controls.Add(Me.Label42)
        Me.Frame7.Controls.Add(Me.Label43)
        Me.Frame7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame7.Location = New System.Drawing.Point(234, 294)
        Me.Frame7.Name = "Frame7"
        Me.Frame7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame7.Size = New System.Drawing.Size(397, 406)
        Me.Frame7.TabIndex = 106
        Me.Frame7.TabStop = False
        Me.Frame7.Text = "Motion"
        '
        'edtUnit
        '
        Me.edtUnit.AcceptsReturn = True
        Me.edtUnit.BackColor = System.Drawing.Color.Black
        Me.edtUnit.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.edtUnit.ForeColor = System.Drawing.Color.Yellow
        Me.edtUnit.Location = New System.Drawing.Point(40, 16)
        Me.edtUnit.MaxLength = 0
        Me.edtUnit.Name = "edtUnit"
        Me.edtUnit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.edtUnit.Size = New System.Drawing.Size(47, 21)
        Me.edtUnit.TabIndex = 160
        Me.edtUnit.Text = "1"
        Me.edtUnit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'edtPulse
        '
        Me.edtPulse.AcceptsReturn = True
        Me.edtPulse.BackColor = System.Drawing.Color.Black
        Me.edtPulse.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.edtPulse.ForeColor = System.Drawing.Color.Yellow
        Me.edtPulse.Location = New System.Drawing.Point(134, 18)
        Me.edtPulse.MaxLength = 0
        Me.edtPulse.Name = "edtPulse"
        Me.edtPulse.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.edtPulse.Size = New System.Drawing.Size(78, 21)
        Me.edtPulse.TabIndex = 159
        Me.edtPulse.Text = "1"
        Me.edtPulse.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnSetting
        '
        Me.btnSetting.BackColor = System.Drawing.SystemColors.Control
        Me.btnSetting.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnSetting.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnSetting.Location = New System.Drawing.Point(334, 17)
        Me.btnSetting.Name = "btnSetting"
        Me.btnSetting.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnSetting.Size = New System.Drawing.Size(57, 22)
        Me.btnSetting.TabIndex = 158
        Me.btnSetting.Text = "Setting"
        Me.btnSetting.UseVisualStyleBackColor = False
        '
        'edtStartSpeed
        '
        Me.edtStartSpeed.AcceptsReturn = True
        Me.edtStartSpeed.BackColor = System.Drawing.Color.Black
        Me.edtStartSpeed.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.edtStartSpeed.ForeColor = System.Drawing.Color.Yellow
        Me.edtStartSpeed.Location = New System.Drawing.Point(295, 18)
        Me.edtStartSpeed.MaxLength = 0
        Me.edtStartSpeed.Name = "edtStartSpeed"
        Me.edtStartSpeed.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.edtStartSpeed.Size = New System.Drawing.Size(38, 21)
        Me.edtStartSpeed.TabIndex = 157
        Me.edtStartSpeed.Text = "100"
        Me.edtStartSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboPulseOutM
        '
        Me.cboPulseOutM.BackColor = System.Drawing.SystemColors.Window
        Me.cboPulseOutM.Cursor = System.Windows.Forms.Cursors.Default
        Me.cboPulseOutM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPulseOutM.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboPulseOutM.Items.AddRange(New Object() {"OneHighLowHigh", "OneHighHighLow", "OneLowLowHigh", "OneLowHighLow", "TwoCcwCwHigh", "TwoCcwCwLow", "TwoCwCcwHigh", "TwoCwCcwLow", "TwoPhase", "TwoPhaseReverse"})
        Me.cboPulseOutM.Location = New System.Drawing.Point(88, 44)
        Me.cboPulseOutM.Name = "cboPulseOutM"
        Me.cboPulseOutM.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboPulseOutM.Size = New System.Drawing.Size(123, 20)
        Me.cboPulseOutM.TabIndex = 156
        '
        'cboEncInputM
        '
        Me.cboEncInputM.BackColor = System.Drawing.SystemColors.Window
        Me.cboEncInputM.Cursor = System.Windows.Forms.Cursors.Default
        Me.cboEncInputM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEncInputM.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboEncInputM.Items.AddRange(New Object() {"Up/Down", "1 Multiple", "2 Multiples", "4 Multiples", "Rev Up/Down", "Rev 1 Multiple", "Rev 2 Multiples", "Rev 4 Multiples"})
        Me.cboEncInputM.Location = New System.Drawing.Point(294, 44)
        Me.cboEncInputM.Name = "cboEncInputM"
        Me.cboEncInputM.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboEncInputM.Size = New System.Drawing.Size(97, 20)
        Me.cboEncInputM.TabIndex = 155
        '
        'btnCountclr
        '
        Me.btnCountclr.BackColor = System.Drawing.SystemColors.Control
        Me.btnCountclr.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnCountclr.Font = New System.Drawing.Font("굴림", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnCountclr.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnCountclr.Location = New System.Drawing.Point(8, 72)
        Me.btnCountclr.Name = "btnCountclr"
        Me.btnCountclr.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnCountclr.Size = New System.Drawing.Size(80, 20)
        Me.btnCountclr.TabIndex = 154
        Me.btnCountclr.Text = "CNTCLR"
        Me.btnCountclr.UseVisualStyleBackColor = False
        '
        'Frame9
        '
        Me.Frame9.BackColor = System.Drawing.SystemColors.Control
        Me.Frame9.Controls.Add(Me.cbGantrySlave)
        Me.Frame9.Controls.Add(Me.chkGantry)
        Me.Frame9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame9.Location = New System.Drawing.Point(260, 198)
        Me.Frame9.Name = "Frame9"
        Me.Frame9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame9.Size = New System.Drawing.Size(137, 105)
        Me.Frame9.TabIndex = 152
        Me.Frame9.TabStop = False
        Me.Frame9.Text = "Gantry"
        '
        'cbGantrySlave
        '
        Me.cbGantrySlave.BackColor = System.Drawing.SystemColors.Window
        Me.cbGantrySlave.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbGantrySlave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbGantrySlave.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbGantrySlave.Items.AddRange(New Object() {"Do not Search", "Do origin revision after Search", "Do not origin revision after Search"})
        Me.cbGantrySlave.Location = New System.Drawing.Point(8, 16)
        Me.cbGantrySlave.Name = "cbGantrySlave"
        Me.cbGantrySlave.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbGantrySlave.Size = New System.Drawing.Size(121, 20)
        Me.cbGantrySlave.TabIndex = 226
        '
        'chkGantry
        '
        Me.chkGantry.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkGantry.BackColor = System.Drawing.SystemColors.Control
        Me.chkGantry.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkGantry.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkGantry.Location = New System.Drawing.Point(8, 40)
        Me.chkGantry.Name = "chkGantry"
        Me.chkGantry.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkGantry.Size = New System.Drawing.Size(121, 55)
        Me.chkGantry.TabIndex = 153
        Me.chkGantry.Text = "Gantry Enable"
        Me.chkGantry.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkGantry.UseVisualStyleBackColor = False
        '
        '_btnJog_1
        '
        Me._btnJog_1.BackColor = System.Drawing.SystemColors.Control
        Me._btnJog_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._btnJog_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnJog.SetIndex(Me._btnJog_1, CType(1, Short))
        Me._btnJog_1.Location = New System.Drawing.Point(370, 96)
        Me._btnJog_1.Name = "_btnJog_1"
        Me._btnJog_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._btnJog_1.Size = New System.Drawing.Size(22, 20)
        Me._btnJog_1.TabIndex = 133
        Me._btnJog_1.Text = "-"
        Me._btnJog_1.UseVisualStyleBackColor = False
        '
        '_btnJog_3
        '
        Me._btnJog_3.BackColor = System.Drawing.SystemColors.Control
        Me._btnJog_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._btnJog_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnJog.SetIndex(Me._btnJog_3, CType(3, Short))
        Me._btnJog_3.Location = New System.Drawing.Point(370, 121)
        Me._btnJog_3.Name = "_btnJog_3"
        Me._btnJog_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._btnJog_3.Size = New System.Drawing.Size(22, 20)
        Me._btnJog_3.TabIndex = 132
        Me._btnJog_3.Text = "-"
        Me._btnJog_3.UseVisualStyleBackColor = False
        '
        '_btnJog_5
        '
        Me._btnJog_5.BackColor = System.Drawing.SystemColors.Control
        Me._btnJog_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._btnJog_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnJog.SetIndex(Me._btnJog_5, CType(5, Short))
        Me._btnJog_5.Location = New System.Drawing.Point(370, 144)
        Me._btnJog_5.Name = "_btnJog_5"
        Me._btnJog_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._btnJog_5.Size = New System.Drawing.Size(22, 20)
        Me._btnJog_5.TabIndex = 131
        Me._btnJog_5.Text = "-"
        Me._btnJog_5.UseVisualStyleBackColor = False
        '
        '_btnJog_7
        '
        Me._btnJog_7.BackColor = System.Drawing.SystemColors.Control
        Me._btnJog_7.Cursor = System.Windows.Forms.Cursors.Default
        Me._btnJog_7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnJog.SetIndex(Me._btnJog_7, CType(7, Short))
        Me._btnJog_7.Location = New System.Drawing.Point(370, 168)
        Me._btnJog_7.Name = "_btnJog_7"
        Me._btnJog_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._btnJog_7.Size = New System.Drawing.Size(22, 20)
        Me._btnJog_7.TabIndex = 130
        Me._btnJog_7.Text = "-"
        Me._btnJog_7.UseVisualStyleBackColor = False
        '
        '_btnJog_0
        '
        Me._btnJog_0.BackColor = System.Drawing.SystemColors.Control
        Me._btnJog_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._btnJog_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnJog.SetIndex(Me._btnJog_0, CType(0, Short))
        Me._btnJog_0.Location = New System.Drawing.Point(347, 96)
        Me._btnJog_0.Name = "_btnJog_0"
        Me._btnJog_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._btnJog_0.Size = New System.Drawing.Size(22, 20)
        Me._btnJog_0.TabIndex = 129
        Me._btnJog_0.Text = "+"
        Me._btnJog_0.UseVisualStyleBackColor = False
        '
        'edtCmdPosX
        '
        Me.edtCmdPosX.AcceptsReturn = True
        Me.edtCmdPosX.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.edtCmdPosX.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.edtCmdPosX.Font = New System.Drawing.Font("굴림", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.edtCmdPosX.ForeColor = System.Drawing.Color.Yellow
        Me.edtCmdPosX.Location = New System.Drawing.Point(88, 96)
        Me.edtCmdPosX.MaxLength = 0
        Me.edtCmdPosX.Name = "edtCmdPosX"
        Me.edtCmdPosX.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.edtCmdPosX.Size = New System.Drawing.Size(81, 22)
        Me.edtCmdPosX.TabIndex = 128
        Me.edtCmdPosX.Text = "0.000"
        Me.edtCmdPosX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'edtCmdPosY
        '
        Me.edtCmdPosY.AcceptsReturn = True
        Me.edtCmdPosY.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.edtCmdPosY.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.edtCmdPosY.Font = New System.Drawing.Font("굴림", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.edtCmdPosY.ForeColor = System.Drawing.Color.Yellow
        Me.edtCmdPosY.Location = New System.Drawing.Point(88, 120)
        Me.edtCmdPosY.MaxLength = 0
        Me.edtCmdPosY.Name = "edtCmdPosY"
        Me.edtCmdPosY.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.edtCmdPosY.Size = New System.Drawing.Size(81, 22)
        Me.edtCmdPosY.TabIndex = 127
        Me.edtCmdPosY.Text = "0.000"
        Me.edtCmdPosY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'edtCmdPosZ
        '
        Me.edtCmdPosZ.AcceptsReturn = True
        Me.edtCmdPosZ.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.edtCmdPosZ.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.edtCmdPosZ.Font = New System.Drawing.Font("굴림", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.edtCmdPosZ.ForeColor = System.Drawing.Color.Yellow
        Me.edtCmdPosZ.Location = New System.Drawing.Point(88, 144)
        Me.edtCmdPosZ.MaxLength = 0
        Me.edtCmdPosZ.Name = "edtCmdPosZ"
        Me.edtCmdPosZ.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.edtCmdPosZ.Size = New System.Drawing.Size(81, 22)
        Me.edtCmdPosZ.TabIndex = 126
        Me.edtCmdPosZ.Text = "0.000"
        Me.edtCmdPosZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'edtCmdPosU
        '
        Me.edtCmdPosU.AcceptsReturn = True
        Me.edtCmdPosU.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.edtCmdPosU.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.edtCmdPosU.Font = New System.Drawing.Font("굴림", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.edtCmdPosU.ForeColor = System.Drawing.Color.Yellow
        Me.edtCmdPosU.Location = New System.Drawing.Point(88, 168)
        Me.edtCmdPosU.MaxLength = 0
        Me.edtCmdPosU.Name = "edtCmdPosU"
        Me.edtCmdPosU.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.edtCmdPosU.Size = New System.Drawing.Size(81, 22)
        Me.edtCmdPosU.TabIndex = 125
        Me.edtCmdPosU.Text = "0.000"
        Me.edtCmdPosU.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'edtActPosX
        '
        Me.edtActPosX.AcceptsReturn = True
        Me.edtActPosX.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.edtActPosX.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.edtActPosX.Font = New System.Drawing.Font("굴림", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.edtActPosX.ForeColor = System.Drawing.Color.Yellow
        Me.edtActPosX.Location = New System.Drawing.Point(176, 96)
        Me.edtActPosX.MaxLength = 0
        Me.edtActPosX.Name = "edtActPosX"
        Me.edtActPosX.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.edtActPosX.Size = New System.Drawing.Size(81, 22)
        Me.edtActPosX.TabIndex = 124
        Me.edtActPosX.Text = "0.000"
        Me.edtActPosX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'edtActPosY
        '
        Me.edtActPosY.AcceptsReturn = True
        Me.edtActPosY.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.edtActPosY.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.edtActPosY.Font = New System.Drawing.Font("굴림", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.edtActPosY.ForeColor = System.Drawing.Color.Yellow
        Me.edtActPosY.Location = New System.Drawing.Point(176, 120)
        Me.edtActPosY.MaxLength = 0
        Me.edtActPosY.Name = "edtActPosY"
        Me.edtActPosY.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.edtActPosY.Size = New System.Drawing.Size(81, 22)
        Me.edtActPosY.TabIndex = 123
        Me.edtActPosY.Text = "0.000"
        Me.edtActPosY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'edtActPosZ
        '
        Me.edtActPosZ.AcceptsReturn = True
        Me.edtActPosZ.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.edtActPosZ.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.edtActPosZ.Font = New System.Drawing.Font("굴림", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.edtActPosZ.ForeColor = System.Drawing.Color.Yellow
        Me.edtActPosZ.Location = New System.Drawing.Point(176, 144)
        Me.edtActPosZ.MaxLength = 0
        Me.edtActPosZ.Name = "edtActPosZ"
        Me.edtActPosZ.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.edtActPosZ.Size = New System.Drawing.Size(81, 22)
        Me.edtActPosZ.TabIndex = 122
        Me.edtActPosZ.Text = "0.000"
        Me.edtActPosZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'edtActPosU
        '
        Me.edtActPosU.AcceptsReturn = True
        Me.edtActPosU.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.edtActPosU.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.edtActPosU.Font = New System.Drawing.Font("굴림", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.edtActPosU.ForeColor = System.Drawing.Color.Yellow
        Me.edtActPosU.Location = New System.Drawing.Point(176, 168)
        Me.edtActPosU.MaxLength = 0
        Me.edtActPosU.Name = "edtActPosU"
        Me.edtActPosU.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.edtActPosU.Size = New System.Drawing.Size(81, 22)
        Me.edtActPosU.TabIndex = 121
        Me.edtActPosU.Text = "0.000"
        Me.edtActPosU.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'edtCmdVelX
        '
        Me.edtCmdVelX.AcceptsReturn = True
        Me.edtCmdVelX.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.edtCmdVelX.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.edtCmdVelX.Font = New System.Drawing.Font("굴림", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.edtCmdVelX.ForeColor = System.Drawing.Color.Yellow
        Me.edtCmdVelX.Location = New System.Drawing.Point(264, 96)
        Me.edtCmdVelX.MaxLength = 0
        Me.edtCmdVelX.Name = "edtCmdVelX"
        Me.edtCmdVelX.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.edtCmdVelX.Size = New System.Drawing.Size(81, 22)
        Me.edtCmdVelX.TabIndex = 120
        Me.edtCmdVelX.Text = "0.000"
        Me.edtCmdVelX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'edtCmdVelY
        '
        Me.edtCmdVelY.AcceptsReturn = True
        Me.edtCmdVelY.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.edtCmdVelY.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.edtCmdVelY.Font = New System.Drawing.Font("굴림", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.edtCmdVelY.ForeColor = System.Drawing.Color.Yellow
        Me.edtCmdVelY.Location = New System.Drawing.Point(264, 120)
        Me.edtCmdVelY.MaxLength = 0
        Me.edtCmdVelY.Name = "edtCmdVelY"
        Me.edtCmdVelY.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.edtCmdVelY.Size = New System.Drawing.Size(81, 22)
        Me.edtCmdVelY.TabIndex = 119
        Me.edtCmdVelY.Text = "0.000"
        Me.edtCmdVelY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'edtCmdVelZ
        '
        Me.edtCmdVelZ.AcceptsReturn = True
        Me.edtCmdVelZ.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.edtCmdVelZ.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.edtCmdVelZ.Font = New System.Drawing.Font("굴림", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.edtCmdVelZ.ForeColor = System.Drawing.Color.Yellow
        Me.edtCmdVelZ.Location = New System.Drawing.Point(264, 144)
        Me.edtCmdVelZ.MaxLength = 0
        Me.edtCmdVelZ.Name = "edtCmdVelZ"
        Me.edtCmdVelZ.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.edtCmdVelZ.Size = New System.Drawing.Size(81, 22)
        Me.edtCmdVelZ.TabIndex = 118
        Me.edtCmdVelZ.Text = "0.000"
        Me.edtCmdVelZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'edtCmdVelU
        '
        Me.edtCmdVelU.AcceptsReturn = True
        Me.edtCmdVelU.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.edtCmdVelU.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.edtCmdVelU.Font = New System.Drawing.Font("굴림", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.edtCmdVelU.ForeColor = System.Drawing.Color.Yellow
        Me.edtCmdVelU.Location = New System.Drawing.Point(264, 168)
        Me.edtCmdVelU.MaxLength = 0
        Me.edtCmdVelU.Name = "edtCmdVelU"
        Me.edtCmdVelU.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.edtCmdVelU.Size = New System.Drawing.Size(81, 22)
        Me.edtCmdVelU.TabIndex = 117
        Me.edtCmdVelU.Text = "0.000"
        Me.edtCmdVelU.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Frame8
        '
        Me.Frame8.BackColor = System.Drawing.SystemColors.Control
        Me.Frame8.Controls.Add(Me.btnCircular)
        Me.Frame8.Controls.Add(Me.btnlinear)
        Me.Frame8.Controls.Add(Me.chkCwCcw)
        Me.Frame8.Controls.Add(Me.edtAngle)
        Me.Frame8.Controls.Add(Me.edtYCen)
        Me.Frame8.Controls.Add(Me.edtXCen)
        Me.Frame8.Controls.Add(Me.Label46)
        Me.Frame8.Controls.Add(Me.Label45)
        Me.Frame8.Controls.Add(Me.Label44)
        Me.Frame8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame8.Location = New System.Drawing.Point(0, 198)
        Me.Frame8.Name = "Frame8"
        Me.Frame8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame8.Size = New System.Drawing.Size(261, 105)
        Me.Frame8.TabIndex = 107
        Me.Frame8.TabStop = False
        Me.Frame8.Text = "Interpolation"
        '
        'btnCircular
        '
        Me.btnCircular.BackColor = System.Drawing.SystemColors.Control
        Me.btnCircular.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnCircular.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnCircular.Location = New System.Drawing.Point(176, 71)
        Me.btnCircular.Name = "btnCircular"
        Me.btnCircular.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnCircular.Size = New System.Drawing.Size(81, 24)
        Me.btnCircular.TabIndex = 113
        Me.btnCircular.Text = "Circular"
        Me.btnCircular.UseVisualStyleBackColor = False
        '
        'btnlinear
        '
        Me.btnlinear.BackColor = System.Drawing.SystemColors.Control
        Me.btnlinear.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnlinear.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnlinear.Location = New System.Drawing.Point(176, 44)
        Me.btnlinear.Name = "btnlinear"
        Me.btnlinear.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnlinear.Size = New System.Drawing.Size(81, 24)
        Me.btnlinear.TabIndex = 112
        Me.btnlinear.Text = "Linear"
        Me.btnlinear.UseVisualStyleBackColor = False
        '
        'chkCwCcw
        '
        Me.chkCwCcw.BackColor = System.Drawing.SystemColors.Control
        Me.chkCwCcw.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkCwCcw.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkCwCcw.Location = New System.Drawing.Point(182, 24)
        Me.chkCwCcw.Name = "chkCwCcw"
        Me.chkCwCcw.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkCwCcw.Size = New System.Drawing.Size(73, 17)
        Me.chkCwCcw.TabIndex = 111
        Me.chkCwCcw.Text = "cw/ccw"
        Me.chkCwCcw.UseVisualStyleBackColor = False
        '
        'edtAngle
        '
        Me.edtAngle.AcceptsReturn = True
        Me.edtAngle.BackColor = System.Drawing.Color.Black
        Me.edtAngle.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.edtAngle.Font = New System.Drawing.Font("굴림", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.edtAngle.ForeColor = System.Drawing.Color.Yellow
        Me.edtAngle.Location = New System.Drawing.Point(88, 71)
        Me.edtAngle.MaxLength = 0
        Me.edtAngle.Name = "edtAngle"
        Me.edtAngle.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.edtAngle.Size = New System.Drawing.Size(86, 25)
        Me.edtAngle.TabIndex = 110
        Me.edtAngle.Text = "360.000"
        Me.edtAngle.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'edtYCen
        '
        Me.edtYCen.AcceptsReturn = True
        Me.edtYCen.BackColor = System.Drawing.Color.Black
        Me.edtYCen.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.edtYCen.Font = New System.Drawing.Font("굴림", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.edtYCen.ForeColor = System.Drawing.Color.Yellow
        Me.edtYCen.Location = New System.Drawing.Point(88, 44)
        Me.edtYCen.MaxLength = 0
        Me.edtYCen.Name = "edtYCen"
        Me.edtYCen.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.edtYCen.Size = New System.Drawing.Size(86, 25)
        Me.edtYCen.TabIndex = 109
        Me.edtYCen.Text = "200.000"
        Me.edtYCen.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'edtXCen
        '
        Me.edtXCen.AcceptsReturn = True
        Me.edtXCen.BackColor = System.Drawing.Color.Black
        Me.edtXCen.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.edtXCen.Font = New System.Drawing.Font("굴림", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.edtXCen.ForeColor = System.Drawing.Color.Yellow
        Me.edtXCen.Location = New System.Drawing.Point(88, 18)
        Me.edtXCen.MaxLength = 0
        Me.edtXCen.Name = "edtXCen"
        Me.edtXCen.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.edtXCen.Size = New System.Drawing.Size(86, 25)
        Me.edtXCen.TabIndex = 108
        Me.edtXCen.Text = "200.000"
        Me.edtXCen.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label46
        '
        Me.Label46.BackColor = System.Drawing.SystemColors.Control
        Me.Label46.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label46.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label46.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label46.Location = New System.Drawing.Point(7, 71)
        Me.Label46.Name = "Label46"
        Me.Label46.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label46.Size = New System.Drawing.Size(77, 23)
        Me.Label46.TabIndex = 116
        Me.Label46.Text = "Angle"
        Me.Label46.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label45
        '
        Me.Label45.BackColor = System.Drawing.SystemColors.Control
        Me.Label45.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label45.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label45.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label45.Location = New System.Drawing.Point(7, 44)
        Me.Label45.Name = "Label45"
        Me.Label45.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label45.Size = New System.Drawing.Size(77, 23)
        Me.Label45.TabIndex = 115
        Me.Label45.Text = "Y end/cen"
        Me.Label45.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label44
        '
        Me.Label44.BackColor = System.Drawing.SystemColors.Control
        Me.Label44.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label44.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label44.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label44.Location = New System.Drawing.Point(7, 18)
        Me.Label44.Name = "Label44"
        Me.Label44.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label44.Size = New System.Drawing.Size(77, 22)
        Me.Label44.TabIndex = 114
        Me.Label44.Text = "X end/cen "
        Me.Label44.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(8, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(33, 20)
        Me.Label6.TabIndex = 173
        Me.Label6.Text = "Unit"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label26
        '
        Me.Label26.BackColor = System.Drawing.SystemColors.Control
        Me.Label26.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label26.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label26.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label26.Location = New System.Drawing.Point(214, 17)
        Me.Label26.Name = "Label26"
        Me.Label26.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label26.Size = New System.Drawing.Size(75, 20)
        Me.Label26.TabIndex = 172
        Me.Label26.Text = "Start Speed"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label25
        '
        Me.Label25.BackColor = System.Drawing.SystemColors.Control
        Me.Label25.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label25.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label25.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label25.Location = New System.Drawing.Point(88, 16)
        Me.Label25.Name = "Label25"
        Me.Label25.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label25.Size = New System.Drawing.Size(44, 20)
        Me.Label25.TabIndex = 171
        Me.Label25.Text = "Pulse"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label27
        '
        Me.Label27.BackColor = System.Drawing.SystemColors.Control
        Me.Label27.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label27.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label27.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label27.Location = New System.Drawing.Point(8, 44)
        Me.Label27.Name = "Label27"
        Me.Label27.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label27.Size = New System.Drawing.Size(76, 20)
        Me.Label27.TabIndex = 170
        Me.Label27.Text = "PulseOut_M"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label28
        '
        Me.Label28.BackColor = System.Drawing.SystemColors.Control
        Me.Label28.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label28.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label28.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label28.Location = New System.Drawing.Point(215, 44)
        Me.Label28.Name = "Label28"
        Me.Label28.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label28.Size = New System.Drawing.Size(74, 20)
        Me.Label28.TabIndex = 169
        Me.Label28.Text = "Encoder_M"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label36
        '
        Me.Label36.BackColor = System.Drawing.SystemColors.Control
        Me.Label36.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label36.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label36.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label36.Location = New System.Drawing.Point(88, 72)
        Me.Label36.Name = "Label36"
        Me.Label36.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label36.Size = New System.Drawing.Size(81, 20)
        Me.Label36.TabIndex = 168
        Me.Label36.Text = "CMD POS"
        Me.Label36.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label37
        '
        Me.Label37.BackColor = System.Drawing.SystemColors.Control
        Me.Label37.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label37.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label37.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label37.Location = New System.Drawing.Point(176, 72)
        Me.Label37.Name = "Label37"
        Me.Label37.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label37.Size = New System.Drawing.Size(81, 20)
        Me.Label37.TabIndex = 167
        Me.Label37.Text = "ACT POS"
        Me.Label37.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label38
        '
        Me.Label38.BackColor = System.Drawing.SystemColors.Control
        Me.Label38.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label38.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label38.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label38.Location = New System.Drawing.Point(264, 72)
        Me.Label38.Name = "Label38"
        Me.Label38.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label38.Size = New System.Drawing.Size(81, 20)
        Me.Label38.TabIndex = 166
        Me.Label38.Text = "CMD VEL"
        Me.Label38.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label39
        '
        Me.Label39.BackColor = System.Drawing.SystemColors.Control
        Me.Label39.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label39.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label39.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label39.Location = New System.Drawing.Point(346, 72)
        Me.Label39.Name = "Label39"
        Me.Label39.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label39.Size = New System.Drawing.Size(44, 20)
        Me.Label39.TabIndex = 165
        Me.Label39.Text = "JOG"
        Me.Label39.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label40
        '
        Me.Label40.BackColor = System.Drawing.SystemColors.Control
        Me.Label40.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label40.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label40.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label40.Location = New System.Drawing.Point(8, 96)
        Me.Label40.Name = "Label40"
        Me.Label40.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label40.Size = New System.Drawing.Size(77, 20)
        Me.Label40.TabIndex = 164
        Me.Label40.Text = "Axis X"
        Me.Label40.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label41
        '
        Me.Label41.BackColor = System.Drawing.SystemColors.Control
        Me.Label41.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label41.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label41.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label41.Location = New System.Drawing.Point(8, 120)
        Me.Label41.Name = "Label41"
        Me.Label41.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label41.Size = New System.Drawing.Size(77, 20)
        Me.Label41.TabIndex = 163
        Me.Label41.Text = "Axis Y"
        Me.Label41.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label42
        '
        Me.Label42.BackColor = System.Drawing.SystemColors.Control
        Me.Label42.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label42.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label42.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label42.Location = New System.Drawing.Point(8, 144)
        Me.Label42.Name = "Label42"
        Me.Label42.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label42.Size = New System.Drawing.Size(77, 20)
        Me.Label42.TabIndex = 162
        Me.Label42.Text = "Axis Z"
        Me.Label42.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label43
        '
        Me.Label43.BackColor = System.Drawing.SystemColors.Control
        Me.Label43.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label43.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label43.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label43.Location = New System.Drawing.Point(8, 168)
        Me.Label43.Name = "Label43"
        Me.Label43.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label43.Size = New System.Drawing.Size(77, 20)
        Me.Label43.TabIndex = 161
        Me.Label43.Text = "Axis U"
        Me.Label43.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Frame10
        '
        Me.Frame10.BackColor = System.Drawing.SystemColors.Control
        Me.Frame10.Controls.Add(Me.edtPosition)
        Me.Frame10.Controls.Add(Me.edtVelocity)
        Me.Frame10.Controls.Add(Me.edtAccel)
        Me.Frame10.Controls.Add(Me.edtDecel)
        Me.Frame10.Controls.Add(Me.chkAbsolute)
        Me.Frame10.Controls.Add(Me.chkRelative)
        Me.Frame10.Controls.Add(Me.chkAsym)
        Me.Frame10.Controls.Add(Me.chkSCurve)
        Me.Frame10.Controls.Add(Me.chkXYSyn)
        Me.Frame10.Controls.Add(Me.btnMove)
        Me.Frame10.Controls.Add(Me.btnRepeat)
        Me.Frame10.Controls.Add(Me.btnStop)
        Me.Frame10.Controls.Add(Me.btnEstop)
        Me.Frame10.Controls.Add(Me.Label47)
        Me.Frame10.Controls.Add(Me.Label48)
        Me.Frame10.Controls.Add(Me.Label49)
        Me.Frame10.Controls.Add(Me.Label50)
        Me.Frame10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame10.Location = New System.Drawing.Point(233, 607)
        Me.Frame10.Name = "Frame10"
        Me.Frame10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame10.Size = New System.Drawing.Size(398, 93)
        Me.Frame10.TabIndex = 134
        Me.Frame10.TabStop = False
        Me.Frame10.Text = "One Axis"
        '
        'edtPosition
        '
        Me.edtPosition.AcceptsReturn = True
        Me.edtPosition.BackColor = System.Drawing.Color.Black
        Me.edtPosition.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.edtPosition.Font = New System.Drawing.Font("굴림", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.edtPosition.ForeColor = System.Drawing.Color.Yellow
        Me.edtPosition.Location = New System.Drawing.Point(8, 35)
        Me.edtPosition.MaxLength = 0
        Me.edtPosition.Name = "edtPosition"
        Me.edtPosition.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.edtPosition.Size = New System.Drawing.Size(75, 22)
        Me.edtPosition.TabIndex = 147
        Me.edtPosition.Text = "0.0"
        Me.edtPosition.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'edtVelocity
        '
        Me.edtVelocity.AcceptsReturn = True
        Me.edtVelocity.BackColor = System.Drawing.Color.Black
        Me.edtVelocity.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.edtVelocity.Font = New System.Drawing.Font("굴림", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.edtVelocity.ForeColor = System.Drawing.Color.Yellow
        Me.edtVelocity.Location = New System.Drawing.Point(84, 35)
        Me.edtVelocity.MaxLength = 0
        Me.edtVelocity.Name = "edtVelocity"
        Me.edtVelocity.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.edtVelocity.Size = New System.Drawing.Size(75, 22)
        Me.edtVelocity.TabIndex = 146
        Me.edtVelocity.Text = "0.0"
        Me.edtVelocity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'edtAccel
        '
        Me.edtAccel.AcceptsReturn = True
        Me.edtAccel.BackColor = System.Drawing.Color.Black
        Me.edtAccel.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.edtAccel.Font = New System.Drawing.Font("굴림", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.edtAccel.ForeColor = System.Drawing.Color.Yellow
        Me.edtAccel.Location = New System.Drawing.Point(160, 35)
        Me.edtAccel.MaxLength = 0
        Me.edtAccel.Name = "edtAccel"
        Me.edtAccel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.edtAccel.Size = New System.Drawing.Size(75, 22)
        Me.edtAccel.TabIndex = 145
        Me.edtAccel.Text = "0.0"
        Me.edtAccel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'edtDecel
        '
        Me.edtDecel.AcceptsReturn = True
        Me.edtDecel.BackColor = System.Drawing.Color.Black
        Me.edtDecel.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.edtDecel.Font = New System.Drawing.Font("굴림", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.edtDecel.ForeColor = System.Drawing.Color.Yellow
        Me.edtDecel.Location = New System.Drawing.Point(238, 35)
        Me.edtDecel.MaxLength = 0
        Me.edtDecel.Name = "edtDecel"
        Me.edtDecel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.edtDecel.Size = New System.Drawing.Size(75, 22)
        Me.edtDecel.TabIndex = 144
        Me.edtDecel.Text = "0.0"
        Me.edtDecel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chkAbsolute
        '
        Me.chkAbsolute.BackColor = System.Drawing.SystemColors.Control
        Me.chkAbsolute.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkAbsolute.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkAbsolute.ForeColor = System.Drawing.SystemColors.WindowText
        Me.chkAbsolute.Location = New System.Drawing.Point(318, 10)
        Me.chkAbsolute.Name = "chkAbsolute"
        Me.chkAbsolute.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkAbsolute.Size = New System.Drawing.Size(73, 17)
        Me.chkAbsolute.TabIndex = 143
        Me.chkAbsolute.Text = "Absolute"
        Me.chkAbsolute.UseVisualStyleBackColor = False
        '
        'chkRelative
        '
        Me.chkRelative.BackColor = System.Drawing.SystemColors.Control
        Me.chkRelative.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkRelative.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkRelative.ForeColor = System.Drawing.SystemColors.WindowText
        Me.chkRelative.Location = New System.Drawing.Point(318, 26)
        Me.chkRelative.Name = "chkRelative"
        Me.chkRelative.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkRelative.Size = New System.Drawing.Size(73, 17)
        Me.chkRelative.TabIndex = 142
        Me.chkRelative.Text = "Relative"
        Me.chkRelative.UseVisualStyleBackColor = False
        '
        'chkAsym
        '
        Me.chkAsym.BackColor = System.Drawing.SystemColors.Control
        Me.chkAsym.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkAsym.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkAsym.ForeColor = System.Drawing.SystemColors.WindowText
        Me.chkAsym.Location = New System.Drawing.Point(318, 42)
        Me.chkAsym.Name = "chkAsym"
        Me.chkAsym.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkAsym.Size = New System.Drawing.Size(73, 17)
        Me.chkAsym.TabIndex = 141
        Me.chkAsym.Text = "Asym"
        Me.chkAsym.UseVisualStyleBackColor = False
        '
        'chkSCurve
        '
        Me.chkSCurve.BackColor = System.Drawing.SystemColors.Control
        Me.chkSCurve.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkSCurve.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkSCurve.ForeColor = System.Drawing.SystemColors.WindowText
        Me.chkSCurve.Location = New System.Drawing.Point(318, 57)
        Me.chkSCurve.Name = "chkSCurve"
        Me.chkSCurve.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkSCurve.Size = New System.Drawing.Size(73, 17)
        Me.chkSCurve.TabIndex = 140
        Me.chkSCurve.Text = "S-Curve"
        Me.chkSCurve.UseVisualStyleBackColor = False
        '
        'chkXYSyn
        '
        Me.chkXYSyn.BackColor = System.Drawing.SystemColors.Control
        Me.chkXYSyn.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkXYSyn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkXYSyn.ForeColor = System.Drawing.SystemColors.WindowText
        Me.chkXYSyn.Location = New System.Drawing.Point(318, 72)
        Me.chkXYSyn.Name = "chkXYSyn"
        Me.chkXYSyn.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkXYSyn.Size = New System.Drawing.Size(73, 17)
        Me.chkXYSyn.TabIndex = 139
        Me.chkXYSyn.Text = "X-Y Syn"
        Me.chkXYSyn.UseVisualStyleBackColor = False
        '
        'btnMove
        '
        Me.btnMove.BackColor = System.Drawing.SystemColors.Control
        Me.btnMove.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnMove.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnMove.Location = New System.Drawing.Point(8, 60)
        Me.btnMove.Name = "btnMove"
        Me.btnMove.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnMove.Size = New System.Drawing.Size(75, 25)
        Me.btnMove.TabIndex = 138
        Me.btnMove.Text = "MOVE"
        Me.btnMove.UseVisualStyleBackColor = False
        '
        'btnRepeat
        '
        Me.btnRepeat.BackColor = System.Drawing.SystemColors.Control
        Me.btnRepeat.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnRepeat.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnRepeat.Location = New System.Drawing.Point(84, 60)
        Me.btnRepeat.Name = "btnRepeat"
        Me.btnRepeat.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnRepeat.Size = New System.Drawing.Size(75, 25)
        Me.btnRepeat.TabIndex = 137
        Me.btnRepeat.Text = "Repeat"
        Me.btnRepeat.UseVisualStyleBackColor = False
        '
        'btnStop
        '
        Me.btnStop.BackColor = System.Drawing.SystemColors.Control
        Me.btnStop.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnStop.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnStop.Location = New System.Drawing.Point(160, 60)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnStop.Size = New System.Drawing.Size(75, 25)
        Me.btnStop.TabIndex = 136
        Me.btnStop.Text = "Stop"
        Me.btnStop.UseVisualStyleBackColor = False
        '
        'btnEstop
        '
        Me.btnEstop.BackColor = System.Drawing.SystemColors.Control
        Me.btnEstop.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnEstop.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnEstop.Location = New System.Drawing.Point(238, 60)
        Me.btnEstop.Name = "btnEstop"
        Me.btnEstop.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnEstop.Size = New System.Drawing.Size(75, 25)
        Me.btnEstop.TabIndex = 135
        Me.btnEstop.Text = "ESTOP"
        Me.btnEstop.UseVisualStyleBackColor = False
        '
        'Label47
        '
        Me.Label47.BackColor = System.Drawing.Color.Transparent
        Me.Label47.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label47.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label47.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label47.Location = New System.Drawing.Point(8, 16)
        Me.Label47.Name = "Label47"
        Me.Label47.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label47.Size = New System.Drawing.Size(75, 17)
        Me.Label47.TabIndex = 151
        Me.Label47.Text = "Position"
        Me.Label47.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label48
        '
        Me.Label48.BackColor = System.Drawing.SystemColors.Control
        Me.Label48.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label48.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label48.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label48.Location = New System.Drawing.Point(84, 16)
        Me.Label48.Name = "Label48"
        Me.Label48.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label48.Size = New System.Drawing.Size(75, 17)
        Me.Label48.TabIndex = 150
        Me.Label48.Text = "Velocity"
        Me.Label48.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label49
        '
        Me.Label49.BackColor = System.Drawing.SystemColors.Control
        Me.Label49.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label49.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label49.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label49.Location = New System.Drawing.Point(160, 16)
        Me.Label49.Name = "Label49"
        Me.Label49.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label49.Size = New System.Drawing.Size(75, 17)
        Me.Label49.TabIndex = 149
        Me.Label49.Text = "Accel"
        Me.Label49.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label50
        '
        Me.Label50.BackColor = System.Drawing.SystemColors.Control
        Me.Label50.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label50.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label50.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label50.Location = New System.Drawing.Point(238, 16)
        Me.Label50.Name = "Label50"
        Me.Label50.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label50.Size = New System.Drawing.Size(75, 17)
        Me.Label50.TabIndex = 148
        Me.Label50.Text = "Decel"
        Me.Label50.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Frame1
        '
        Me.Frame1.BackColor = System.Drawing.SystemColors.Control
        Me.Frame1.Controls.Add(Me.Frame6)
        Me.Frame1.Controls.Add(Me.Frame5)
        Me.Frame1.Controls.Add(Me.Frame4)
        Me.Frame1.Controls.Add(Me.Frame3)
        Me.Frame1.Controls.Add(Me.m_grLevel)
        Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame1.Location = New System.Drawing.Point(4, 340)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(225, 360)
        Me.Frame1.TabIndex = 4
        Me.Frame1.TabStop = False
        Me.Frame1.Text = "I / O"
        '
        'Frame6
        '
        Me.Frame6.BackColor = System.Drawing.SystemColors.Control
        Me.Frame6.Controls.Add(Me.btnCRCOff)
        Me.Frame6.Controls.Add(Me.btnCRCOn)
        Me.Frame6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame6.Location = New System.Drawing.Point(112, 275)
        Me.Frame6.Name = "Frame6"
        Me.Frame6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame6.Size = New System.Drawing.Size(113, 85)
        Me.Frame6.TabIndex = 9
        Me.Frame6.TabStop = False
        Me.Frame6.Text = "CRC"
        '
        'btnCRCOff
        '
        Me.btnCRCOff.BackColor = System.Drawing.SystemColors.Control
        Me.btnCRCOff.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnCRCOff.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnCRCOff.Location = New System.Drawing.Point(8, 52)
        Me.btnCRCOff.Name = "btnCRCOff"
        Me.btnCRCOff.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnCRCOff.Size = New System.Drawing.Size(97, 25)
        Me.btnCRCOff.TabIndex = 92
        Me.btnCRCOff.Text = "CRC OFF"
        Me.btnCRCOff.UseVisualStyleBackColor = False
        '
        'btnCRCOn
        '
        Me.btnCRCOn.BackColor = System.Drawing.SystemColors.Control
        Me.btnCRCOn.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnCRCOn.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnCRCOn.Location = New System.Drawing.Point(8, 19)
        Me.btnCRCOn.Name = "btnCRCOn"
        Me.btnCRCOn.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnCRCOn.Size = New System.Drawing.Size(97, 25)
        Me.btnCRCOn.TabIndex = 91
        Me.btnCRCOn.Text = "CRC ON"
        Me.btnCRCOn.UseVisualStyleBackColor = False
        '
        'Frame5
        '
        Me.Frame5.BackColor = System.Drawing.SystemColors.Control
        Me.Frame5.Controls.Add(Me.btnMPGOff)
        Me.Frame5.Controls.Add(Me.btnMPGOn)
        Me.Frame5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame5.Location = New System.Drawing.Point(112, 190)
        Me.Frame5.Name = "Frame5"
        Me.Frame5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame5.Size = New System.Drawing.Size(113, 81)
        Me.Frame5.TabIndex = 8
        Me.Frame5.TabStop = False
        Me.Frame5.Text = "MPG"
        '
        'btnMPGOff
        '
        Me.btnMPGOff.BackColor = System.Drawing.SystemColors.Control
        Me.btnMPGOff.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnMPGOff.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnMPGOff.Location = New System.Drawing.Point(8, 48)
        Me.btnMPGOff.Name = "btnMPGOff"
        Me.btnMPGOff.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnMPGOff.Size = New System.Drawing.Size(97, 23)
        Me.btnMPGOff.TabIndex = 59
        Me.btnMPGOff.Text = "MPG OFF"
        Me.btnMPGOff.UseVisualStyleBackColor = False
        '
        'btnMPGOn
        '
        Me.btnMPGOn.BackColor = System.Drawing.SystemColors.Control
        Me.btnMPGOn.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnMPGOn.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnMPGOn.Location = New System.Drawing.Point(8, 19)
        Me.btnMPGOn.Name = "btnMPGOn"
        Me.btnMPGOn.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnMPGOn.Size = New System.Drawing.Size(97, 23)
        Me.btnMPGOn.TabIndex = 58
        Me.btnMPGOn.Text = "MPG ON"
        Me.btnMPGOn.UseVisualStyleBackColor = False
        '
        'Frame4
        '
        Me.Frame4.BackColor = System.Drawing.SystemColors.Control
        Me.Frame4.Controls.Add(Me.LedEmg)
        Me.Frame4.Controls.Add(Me.LedZPhase)
        Me.Frame4.Controls.Add(Me.LedHome)
        Me.Frame4.Controls.Add(Me.LedAlarm)
        Me.Frame4.Controls.Add(Me.LedInp)
        Me.Frame4.Controls.Add(Me.LedNElm)
        Me.Frame4.Controls.Add(Me.LedPElm)
        Me.Frame4.Controls.Add(Me.Label35)
        Me.Frame4.Controls.Add(Me.Label34)
        Me.Frame4.Controls.Add(Me.Label33)
        Me.Frame4.Controls.Add(Me.Label32)
        Me.Frame4.Controls.Add(Me.Label31)
        Me.Frame4.Controls.Add(Me.Label30)
        Me.Frame4.Controls.Add(Me.Label29)
        Me.Frame4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame4.Location = New System.Drawing.Point(0, 190)
        Me.Frame4.Name = "Frame4"
        Me.Frame4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame4.Size = New System.Drawing.Size(110, 170)
        Me.Frame4.TabIndex = 7
        Me.Frame4.TabStop = False
        Me.Frame4.Text = "Mechanical"
        '
        'LedEmg
        '
        Me.LedEmg.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LedEmg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LedEmg.Cursor = System.Windows.Forms.Cursors.Default
        Me.LedEmg.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LedEmg.Location = New System.Drawing.Point(84, 143)
        Me.LedEmg.Name = "LedEmg"
        Me.LedEmg.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LedEmg.Size = New System.Drawing.Size(17, 17)
        Me.LedEmg.TabIndex = 57
        Me.LedEmg.TabStop = False
        '
        'LedZPhase
        '
        Me.LedZPhase.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LedZPhase.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LedZPhase.Cursor = System.Windows.Forms.Cursors.Default
        Me.LedZPhase.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LedZPhase.Location = New System.Drawing.Point(84, 122)
        Me.LedZPhase.Name = "LedZPhase"
        Me.LedZPhase.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LedZPhase.Size = New System.Drawing.Size(17, 17)
        Me.LedZPhase.TabIndex = 53
        Me.LedZPhase.TabStop = False
        '
        'LedHome
        '
        Me.LedHome.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LedHome.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LedHome.Cursor = System.Windows.Forms.Cursors.Default
        Me.LedHome.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LedHome.Location = New System.Drawing.Point(84, 102)
        Me.LedHome.Name = "LedHome"
        Me.LedHome.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LedHome.Size = New System.Drawing.Size(17, 17)
        Me.LedHome.TabIndex = 52
        Me.LedHome.TabStop = False
        '
        'LedAlarm
        '
        Me.LedAlarm.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LedAlarm.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LedAlarm.Cursor = System.Windows.Forms.Cursors.Default
        Me.LedAlarm.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LedAlarm.Location = New System.Drawing.Point(84, 82)
        Me.LedAlarm.Name = "LedAlarm"
        Me.LedAlarm.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LedAlarm.Size = New System.Drawing.Size(17, 17)
        Me.LedAlarm.TabIndex = 51
        Me.LedAlarm.TabStop = False
        '
        'LedInp
        '
        Me.LedInp.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LedInp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LedInp.Cursor = System.Windows.Forms.Cursors.Default
        Me.LedInp.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LedInp.Location = New System.Drawing.Point(84, 60)
        Me.LedInp.Name = "LedInp"
        Me.LedInp.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LedInp.Size = New System.Drawing.Size(17, 17)
        Me.LedInp.TabIndex = 50
        Me.LedInp.TabStop = False
        '
        'LedNElm
        '
        Me.LedNElm.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LedNElm.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LedNElm.Cursor = System.Windows.Forms.Cursors.Default
        Me.LedNElm.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LedNElm.Location = New System.Drawing.Point(84, 39)
        Me.LedNElm.Name = "LedNElm"
        Me.LedNElm.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LedNElm.Size = New System.Drawing.Size(17, 17)
        Me.LedNElm.TabIndex = 49
        Me.LedNElm.TabStop = False
        '
        'LedPElm
        '
        Me.LedPElm.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LedPElm.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LedPElm.Cursor = System.Windows.Forms.Cursors.Default
        Me.LedPElm.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LedPElm.Location = New System.Drawing.Point(84, 18)
        Me.LedPElm.Name = "LedPElm"
        Me.LedPElm.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LedPElm.Size = New System.Drawing.Size(17, 17)
        Me.LedPElm.TabIndex = 48
        Me.LedPElm.TabStop = False
        '
        'Label35
        '
        Me.Label35.BackColor = System.Drawing.SystemColors.Control
        Me.Label35.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label35.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label35.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label35.Location = New System.Drawing.Point(6, 143)
        Me.Label35.Name = "Label35"
        Me.Label35.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label35.Size = New System.Drawing.Size(70, 17)
        Me.Label35.TabIndex = 56
        Me.Label35.Text = "Emg"
        Me.Label35.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label34
        '
        Me.Label34.BackColor = System.Drawing.SystemColors.Control
        Me.Label34.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label34.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label34.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label34.Location = New System.Drawing.Point(6, 122)
        Me.Label34.Name = "Label34"
        Me.Label34.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label34.Size = New System.Drawing.Size(70, 17)
        Me.Label34.TabIndex = 47
        Me.Label34.Text = "Zphase"
        Me.Label34.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label33
        '
        Me.Label33.BackColor = System.Drawing.SystemColors.Control
        Me.Label33.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label33.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label33.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label33.Location = New System.Drawing.Point(6, 102)
        Me.Label33.Name = "Label33"
        Me.Label33.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label33.Size = New System.Drawing.Size(70, 17)
        Me.Label33.TabIndex = 46
        Me.Label33.Text = "Home"
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label32
        '
        Me.Label32.BackColor = System.Drawing.SystemColors.Control
        Me.Label32.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label32.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label32.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label32.Location = New System.Drawing.Point(6, 82)
        Me.Label32.Name = "Label32"
        Me.Label32.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label32.Size = New System.Drawing.Size(70, 17)
        Me.Label32.TabIndex = 45
        Me.Label32.Text = "Alarm"
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label31
        '
        Me.Label31.BackColor = System.Drawing.SystemColors.Control
        Me.Label31.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label31.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label31.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label31.Location = New System.Drawing.Point(6, 60)
        Me.Label31.Name = "Label31"
        Me.Label31.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label31.Size = New System.Drawing.Size(70, 17)
        Me.Label31.TabIndex = 44
        Me.Label31.Text = "Inposition"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label30
        '
        Me.Label30.BackColor = System.Drawing.SystemColors.Control
        Me.Label30.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label30.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label30.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label30.Location = New System.Drawing.Point(6, 39)
        Me.Label30.Name = "Label30"
        Me.Label30.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label30.Size = New System.Drawing.Size(70, 17)
        Me.Label30.TabIndex = 43
        Me.Label30.Text = "- End Limit"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label29
        '
        Me.Label29.BackColor = System.Drawing.SystemColors.Control
        Me.Label29.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label29.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label29.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label29.Location = New System.Drawing.Point(6, 18)
        Me.Label29.Name = "Label29"
        Me.Label29.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label29.Size = New System.Drawing.Size(70, 17)
        Me.Label29.TabIndex = 42
        Me.Label29.Text = "+ End Limit"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Frame3
        '
        Me.Frame3.BackColor = System.Drawing.SystemColors.Control
        Me.Frame3.Controls.Add(Me.LedOut2)
        Me.Frame3.Controls.Add(Me.LedOut5)
        Me.Frame3.Controls.Add(Me.LedOut4)
        Me.Frame3.Controls.Add(Me.LedOut3)
        Me.Frame3.Controls.Add(Me.LedOut0)
        Me.Frame3.Controls.Add(Me.LedOut1)
        Me.Frame3.Controls.Add(Me.LedIn5)
        Me.Frame3.Controls.Add(Me.LedIn4)
        Me.Frame3.Controls.Add(Me.LedIn3)
        Me.Frame3.Controls.Add(Me.LedIn2)
        Me.Frame3.Controls.Add(Me.LedIn0)
        Me.Frame3.Controls.Add(Me.LedIn1)
        Me.Frame3.Controls.Add(Me.Label24)
        Me.Frame3.Controls.Add(Me.Label23)
        Me.Frame3.Controls.Add(Me.Label22)
        Me.Frame3.Controls.Add(Me.Label21)
        Me.Frame3.Controls.Add(Me.Label20)
        Me.Frame3.Controls.Add(Me.Label19)
        Me.Frame3.Controls.Add(Me.Label18)
        Me.Frame3.Controls.Add(Me.Label17)
        Me.Frame3.Controls.Add(Me.Label16)
        Me.Frame3.Controls.Add(Me.Label15)
        Me.Frame3.Controls.Add(Me.Label14)
        Me.Frame3.Controls.Add(Me.Label13)
        Me.Frame3.Controls.Add(Me.Label12)
        Me.Frame3.Controls.Add(Me.Label11)
        Me.Frame3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame3.Location = New System.Drawing.Point(112, 14)
        Me.Frame3.Name = "Frame3"
        Me.Frame3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame3.Size = New System.Drawing.Size(113, 167)
        Me.Frame3.TabIndex = 6
        Me.Frame3.TabStop = False
        Me.Frame3.Text = "Universal I/O"
        '
        'LedOut2
        '
        Me.LedOut2.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LedOut2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LedOut2.Cursor = System.Windows.Forms.Cursors.Default
        Me.LedOut2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LedOut2.Location = New System.Drawing.Point(58, 80)
        Me.LedOut2.Name = "LedOut2"
        Me.LedOut2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LedOut2.Size = New System.Drawing.Size(17, 18)
        Me.LedOut2.TabIndex = 87
        Me.LedOut2.TabStop = False
        '
        'LedOut5
        '
        Me.LedOut5.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LedOut5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LedOut5.Cursor = System.Windows.Forms.Cursors.Default
        Me.LedOut5.Enabled = False
        Me.LedOut5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LedOut5.Location = New System.Drawing.Point(58, 143)
        Me.LedOut5.Name = "LedOut5"
        Me.LedOut5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LedOut5.Size = New System.Drawing.Size(17, 18)
        Me.LedOut5.TabIndex = 29
        Me.LedOut5.TabStop = False
        '
        'LedOut4
        '
        Me.LedOut4.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LedOut4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LedOut4.Cursor = System.Windows.Forms.Cursors.Default
        Me.LedOut4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LedOut4.Location = New System.Drawing.Point(58, 122)
        Me.LedOut4.Name = "LedOut4"
        Me.LedOut4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LedOut4.Size = New System.Drawing.Size(17, 18)
        Me.LedOut4.TabIndex = 28
        Me.LedOut4.TabStop = False
        '
        'LedOut3
        '
        Me.LedOut3.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LedOut3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LedOut3.Cursor = System.Windows.Forms.Cursors.Default
        Me.LedOut3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LedOut3.Location = New System.Drawing.Point(58, 100)
        Me.LedOut3.Name = "LedOut3"
        Me.LedOut3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LedOut3.Size = New System.Drawing.Size(17, 18)
        Me.LedOut3.TabIndex = 27
        Me.LedOut3.TabStop = False
        '
        'LedOut0
        '
        Me.LedOut0.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LedOut0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LedOut0.Cursor = System.Windows.Forms.Cursors.Default
        Me.LedOut0.ForeColor = System.Drawing.Color.Black
        Me.LedOut0.Location = New System.Drawing.Point(58, 38)
        Me.LedOut0.Name = "LedOut0"
        Me.LedOut0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LedOut0.Size = New System.Drawing.Size(17, 18)
        Me.LedOut0.TabIndex = 26
        Me.LedOut0.TabStop = False
        '
        'LedOut1
        '
        Me.LedOut1.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LedOut1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LedOut1.Cursor = System.Windows.Forms.Cursors.Default
        Me.LedOut1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LedOut1.Location = New System.Drawing.Point(58, 59)
        Me.LedOut1.Name = "LedOut1"
        Me.LedOut1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LedOut1.Size = New System.Drawing.Size(17, 18)
        Me.LedOut1.TabIndex = 25
        Me.LedOut1.TabStop = False
        '
        'LedIn5
        '
        Me.LedIn5.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LedIn5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LedIn5.Cursor = System.Windows.Forms.Cursors.Default
        Me.LedIn5.Enabled = False
        Me.LedIn5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LedIn5.Location = New System.Drawing.Point(8, 143)
        Me.LedIn5.Name = "LedIn5"
        Me.LedIn5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LedIn5.Size = New System.Drawing.Size(17, 18)
        Me.LedIn5.TabIndex = 24
        Me.LedIn5.TabStop = False
        '
        'LedIn4
        '
        Me.LedIn4.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LedIn4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LedIn4.Cursor = System.Windows.Forms.Cursors.Default
        Me.LedIn4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LedIn4.Location = New System.Drawing.Point(8, 122)
        Me.LedIn4.Name = "LedIn4"
        Me.LedIn4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LedIn4.Size = New System.Drawing.Size(17, 18)
        Me.LedIn4.TabIndex = 23
        Me.LedIn4.TabStop = False
        '
        'LedIn3
        '
        Me.LedIn3.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LedIn3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LedIn3.Cursor = System.Windows.Forms.Cursors.Default
        Me.LedIn3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LedIn3.Location = New System.Drawing.Point(8, 100)
        Me.LedIn3.Name = "LedIn3"
        Me.LedIn3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LedIn3.Size = New System.Drawing.Size(17, 18)
        Me.LedIn3.TabIndex = 22
        Me.LedIn3.TabStop = False
        '
        'LedIn2
        '
        Me.LedIn2.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LedIn2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LedIn2.Cursor = System.Windows.Forms.Cursors.Default
        Me.LedIn2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LedIn2.Location = New System.Drawing.Point(8, 80)
        Me.LedIn2.Name = "LedIn2"
        Me.LedIn2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LedIn2.Size = New System.Drawing.Size(17, 18)
        Me.LedIn2.TabIndex = 21
        Me.LedIn2.TabStop = False
        '
        'LedIn0
        '
        Me.LedIn0.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LedIn0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LedIn0.Cursor = System.Windows.Forms.Cursors.Default
        Me.LedIn0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LedIn0.Location = New System.Drawing.Point(8, 38)
        Me.LedIn0.Name = "LedIn0"
        Me.LedIn0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LedIn0.Size = New System.Drawing.Size(17, 18)
        Me.LedIn0.TabIndex = 20
        Me.LedIn0.TabStop = False
        '
        'LedIn1
        '
        Me.LedIn1.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LedIn1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LedIn1.Cursor = System.Windows.Forms.Cursors.Default
        Me.LedIn1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LedIn1.Location = New System.Drawing.Point(8, 59)
        Me.LedIn1.Name = "LedIn1"
        Me.LedIn1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LedIn1.Size = New System.Drawing.Size(17, 18)
        Me.LedIn1.TabIndex = 19
        Me.LedIn1.TabStop = False
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.SystemColors.Control
        Me.Label24.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label24.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label24.Enabled = False
        Me.Label24.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label24.Location = New System.Drawing.Point(78, 143)
        Me.Label24.Name = "Label24"
        Me.Label24.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label24.Size = New System.Drawing.Size(30, 18)
        Me.Label24.TabIndex = 41
        Me.Label24.Text = "5"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.SystemColors.Control
        Me.Label23.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label23.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label23.Enabled = False
        Me.Label23.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label23.Location = New System.Drawing.Point(78, 122)
        Me.Label23.Name = "Label23"
        Me.Label23.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label23.Size = New System.Drawing.Size(30, 18)
        Me.Label23.TabIndex = 40
        Me.Label23.Text = "4"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.SystemColors.Control
        Me.Label22.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label22.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label22.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label22.Location = New System.Drawing.Point(78, 100)
        Me.Label22.Name = "Label22"
        Me.Label22.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label22.Size = New System.Drawing.Size(30, 18)
        Me.Label22.TabIndex = 39
        Me.Label22.Text = "3"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.SystemColors.Control
        Me.Label21.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label21.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label21.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label21.Location = New System.Drawing.Point(78, 80)
        Me.Label21.Name = "Label21"
        Me.Label21.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label21.Size = New System.Drawing.Size(30, 18)
        Me.Label21.TabIndex = 38
        Me.Label21.Text = "2"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.SystemColors.Control
        Me.Label20.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label20.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label20.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label20.Location = New System.Drawing.Point(78, 59)
        Me.Label20.Name = "Label20"
        Me.Label20.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label20.Size = New System.Drawing.Size(30, 18)
        Me.Label20.TabIndex = 37
        Me.Label20.Text = "Alm"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.SystemColors.Control
        Me.Label19.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label19.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label19.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label19.Location = New System.Drawing.Point(78, 38)
        Me.Label19.Name = "Label19"
        Me.Label19.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label19.Size = New System.Drawing.Size(29, 18)
        Me.Label19.TabIndex = 36
        Me.Label19.Text = "Son"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.SystemColors.Control
        Me.Label18.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label18.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label18.Enabled = False
        Me.Label18.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label18.Location = New System.Drawing.Point(28, 143)
        Me.Label18.Name = "Label18"
        Me.Label18.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label18.Size = New System.Drawing.Size(28, 18)
        Me.Label18.TabIndex = 35
        Me.Label18.Text = "5"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.SystemColors.Control
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label17.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label17.Enabled = False
        Me.Label17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label17.Location = New System.Drawing.Point(28, 122)
        Me.Label17.Name = "Label17"
        Me.Label17.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label17.Size = New System.Drawing.Size(28, 18)
        Me.Label17.TabIndex = 34
        Me.Label17.Text = "4"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.SystemColors.Control
        Me.Label16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label16.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label16.Location = New System.Drawing.Point(28, 100)
        Me.Label16.Name = "Label16"
        Me.Label16.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label16.Size = New System.Drawing.Size(28, 18)
        Me.Label16.TabIndex = 33
        Me.Label16.Text = "3"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.SystemColors.Control
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label15.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label15.Location = New System.Drawing.Point(28, 80)
        Me.Label15.Name = "Label15"
        Me.Label15.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label15.Size = New System.Drawing.Size(28, 18)
        Me.Label15.TabIndex = 32
        Me.Label15.Text = "2"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.SystemColors.Control
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label14.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label14.Location = New System.Drawing.Point(28, 59)
        Me.Label14.Name = "Label14"
        Me.Label14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label14.Size = New System.Drawing.Size(28, 18)
        Me.Label14.TabIndex = 31
        Me.Label14.Text = "Zph"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.SystemColors.Control
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label13.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(28, 38)
        Me.Label13.Name = "Label13"
        Me.Label13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label13.Size = New System.Drawing.Size(28, 18)
        Me.Label13.TabIndex = 30
        Me.Label13.Text = "Org"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.SystemColors.Control
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label12.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(57, 16)
        Me.Label12.Name = "Label12"
        Me.Label12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label12.Size = New System.Drawing.Size(49, 18)
        Me.Label12.TabIndex = 18
        Me.Label12.Text = "OUT"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.SystemColors.Control
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label11.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(8, 16)
        Me.Label11.Name = "Label11"
        Me.Label11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label11.Size = New System.Drawing.Size(49, 18)
        Me.Label11.TabIndex = 17
        Me.Label11.Text = "IN"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'm_grLevel
        '
        Me.m_grLevel.BackColor = System.Drawing.SystemColors.Control
        Me.m_grLevel.Controls.Add(Me.cboLevel4)
        Me.m_grLevel.Controls.Add(Me.cboLevel3)
        Me.m_grLevel.Controls.Add(Me.cboLevel2)
        Me.m_grLevel.Controls.Add(Me.cboLevel1)
        Me.m_grLevel.Controls.Add(Me.cboLevel0)
        Me.m_grLevel.Controls.Add(Me.chkZPhaseLevel)
        Me.m_grLevel.Controls.Add(Me.chkHomeLevel)
        Me.m_grLevel.Controls.Add(Me.Label10)
        Me.m_grLevel.Controls.Add(Me.Label9)
        Me.m_grLevel.Controls.Add(Me.Label8)
        Me.m_grLevel.Controls.Add(Me.Label7)
        Me.m_grLevel.Controls.Add(Me.Label5)
        Me.m_grLevel.Controls.Add(Me.lbl)
        Me.m_grLevel.Controls.Add(Me.Label3)
        Me.m_grLevel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.m_grLevel.Location = New System.Drawing.Point(0, 14)
        Me.m_grLevel.Name = "m_grLevel"
        Me.m_grLevel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.m_grLevel.Size = New System.Drawing.Size(110, 168)
        Me.m_grLevel.TabIndex = 5
        Me.m_grLevel.TabStop = False
        Me.m_grLevel.Text = "Level Setting"
        '
        'cboLevel4
        '
        Me.cboLevel4.BackColor = System.Drawing.SystemColors.Window
        Me.cboLevel4.Cursor = System.Windows.Forms.Cursors.Default
        Me.cboLevel4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLevel4.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboLevel4.Items.AddRange(New Object() {"L", "H", "D"})
        Me.cboLevel4.Location = New System.Drawing.Point(76, 144)
        Me.cboLevel4.Name = "cboLevel4"
        Me.cboLevel4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboLevel4.Size = New System.Drawing.Size(31, 20)
        Me.cboLevel4.TabIndex = 225
        '
        'cboLevel3
        '
        Me.cboLevel3.BackColor = System.Drawing.SystemColors.Window
        Me.cboLevel3.Cursor = System.Windows.Forms.Cursors.Default
        Me.cboLevel3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLevel3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboLevel3.Items.AddRange(New Object() {"L", "H", "D"})
        Me.cboLevel3.Location = New System.Drawing.Point(76, 80)
        Me.cboLevel3.Name = "cboLevel3"
        Me.cboLevel3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboLevel3.Size = New System.Drawing.Size(31, 20)
        Me.cboLevel3.TabIndex = 224
        '
        'cboLevel2
        '
        Me.cboLevel2.BackColor = System.Drawing.SystemColors.Window
        Me.cboLevel2.Cursor = System.Windows.Forms.Cursors.Default
        Me.cboLevel2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLevel2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboLevel2.Items.AddRange(New Object() {"L", "H", "D"})
        Me.cboLevel2.Location = New System.Drawing.Point(76, 59)
        Me.cboLevel2.Name = "cboLevel2"
        Me.cboLevel2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboLevel2.Size = New System.Drawing.Size(31, 20)
        Me.cboLevel2.TabIndex = 223
        '
        'cboLevel1
        '
        Me.cboLevel1.BackColor = System.Drawing.SystemColors.Window
        Me.cboLevel1.Cursor = System.Windows.Forms.Cursors.Default
        Me.cboLevel1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLevel1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboLevel1.Items.AddRange(New Object() {"L", "H", "D"})
        Me.cboLevel1.Location = New System.Drawing.Point(76, 38)
        Me.cboLevel1.Name = "cboLevel1"
        Me.cboLevel1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboLevel1.Size = New System.Drawing.Size(31, 20)
        Me.cboLevel1.TabIndex = 222
        '
        'cboLevel0
        '
        Me.cboLevel0.BackColor = System.Drawing.SystemColors.Window
        Me.cboLevel0.Cursor = System.Windows.Forms.Cursors.Default
        Me.cboLevel0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLevel0.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboLevel0.Items.AddRange(New Object() {"L", "H", "D"})
        Me.cboLevel0.Location = New System.Drawing.Point(76, 16)
        Me.cboLevel0.Name = "cboLevel0"
        Me.cboLevel0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboLevel0.Size = New System.Drawing.Size(31, 20)
        Me.cboLevel0.TabIndex = 221
        '
        'chkZPhaseLevel
        '
        Me.chkZPhaseLevel.BackColor = System.Drawing.SystemColors.Control
        Me.chkZPhaseLevel.Checked = True
        Me.chkZPhaseLevel.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkZPhaseLevel.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkZPhaseLevel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkZPhaseLevel.Location = New System.Drawing.Point(87, 124)
        Me.chkZPhaseLevel.Name = "chkZPhaseLevel"
        Me.chkZPhaseLevel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkZPhaseLevel.Size = New System.Drawing.Size(17, 17)
        Me.chkZPhaseLevel.TabIndex = 16
        Me.chkZPhaseLevel.UseVisualStyleBackColor = False
        '
        'chkHomeLevel
        '
        Me.chkHomeLevel.BackColor = System.Drawing.SystemColors.Control
        Me.chkHomeLevel.Checked = True
        Me.chkHomeLevel.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkHomeLevel.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkHomeLevel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkHomeLevel.Location = New System.Drawing.Point(87, 106)
        Me.chkHomeLevel.Name = "chkHomeLevel"
        Me.chkHomeLevel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkHomeLevel.Size = New System.Drawing.Size(17, 12)
        Me.chkHomeLevel.TabIndex = 15
        Me.chkHomeLevel.UseVisualStyleBackColor = False
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.SystemColors.Control
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label10.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(6, 143)
        Me.Label10.Name = "Label10"
        Me.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label10.Size = New System.Drawing.Size(70, 18)
        Me.Label10.TabIndex = 14
        Me.Label10.Text = "Emg"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.Control
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label9.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(6, 122)
        Me.Label9.Name = "Label9"
        Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label9.Size = New System.Drawing.Size(70, 18)
        Me.Label9.TabIndex = 13
        Me.Label9.Text = "Zphase"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.Control
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(6, 100)
        Me.Label8.Name = "Label8"
        Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label8.Size = New System.Drawing.Size(70, 18)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "Home"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.Control
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(6, 80)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(70, 18)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "Alarm"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(6, 59)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(70, 18)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Inposition"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lbl
        '
        Me.lbl.BackColor = System.Drawing.SystemColors.Control
        Me.lbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl.Location = New System.Drawing.Point(6, 38)
        Me.lbl.Name = "lbl"
        Me.lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl.Size = New System.Drawing.Size(70, 18)
        Me.lbl.TabIndex = 55
        Me.lbl.Text = "- End Limit"
        Me.lbl.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(6, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(70, 18)
        Me.Label3.TabIndex = 54
        Me.Label3.Text = "+ End Limit"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_Label2_1
        '
        Me._Label2_1.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Label2_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.SetIndex(Me._Label2_1, CType(1, Short))
        Me._Label2_1.Location = New System.Drawing.Point(6, 318)
        Me._Label2_1.Name = "_Label2_1"
        Me._Label2_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_1.Size = New System.Drawing.Size(70, 18)
        Me._Label2_1.TabIndex = 0
        Me._Label2_1.Text = "Axis No"
        Me._Label2_1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(6, 293)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(70, 18)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Unit/Pulse"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnJog
        '
        '
        'tmHome
        '
        '
        'tmTest
        '
        '
        'XYPlot
        '
        Me.XYPlot.Enabled = True
        Me.XYPlot.Location = New System.Drawing.Point(515, 8)
        Me.XYPlot.Name = "XYPlot"
        Me.XYPlot.OcxState = CType(resources.GetObject("XYPlot.OcxState"), System.Windows.Forms.AxHost.State)
        Me.XYPlot.Size = New System.Drawing.Size(312, 282)
        Me.XYPlot.TabIndex = 204
        '
        'AxtMsg
        '
        Me.AxtMsg.Enabled = True
        Me.AxtMsg.Location = New System.Drawing.Point(636, 671)
        Me.AxtMsg.Name = "AxtMsg"
        Me.AxtMsg.OcxState = CType(resources.GetObject("AxtMsg.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxtMsg.Size = New System.Drawing.Size(27, 28)
        Me.AxtMsg.TabIndex = 205
        Me.AxtMsg.Visible = False
        '
        'GraphX
        '
        Me.GraphX.Enabled = True
        Me.GraphX.Location = New System.Drawing.Point(5, 7)
        Me.GraphX.Name = "GraphX"
        Me.GraphX.OcxState = CType(resources.GetObject("GraphX.OcxState"), System.Windows.Forms.AxHost.State)
        Me.GraphX.Size = New System.Drawing.Size(504, 138)
        Me.GraphX.TabIndex = 206
        '
        'GraphY
        '
        Me.GraphY.Enabled = True
        Me.GraphY.Location = New System.Drawing.Point(6, 151)
        Me.GraphY.Name = "GraphY"
        Me.GraphY.OcxState = CType(resources.GetObject("GraphY.OcxState"), System.Windows.Forms.AxHost.State)
        Me.GraphY.Size = New System.Drawing.Size(504, 139)
        Me.GraphY.TabIndex = 206
        '
        'frmCamcQI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(1014, 751)
        Me.Controls.Add(Me.GraphY)
        Me.Controls.Add(Me.GraphX)
        Me.Controls.Add(Me.AxtMsg)
        Me.Controls.Add(Me.XYPlot)
        Me.Controls.Add(Me.Frame15)
        Me.Controls.Add(Me.Frame17)
        Me.Controls.Add(Me.Frame19)
        Me.Controls.Add(Me.lstLog)
        Me.Controls.Add(Me.Frame10)
        Me.Controls.Add(Me.Frame13)
        Me.Controls.Add(Me.chkGearOnOff)
        Me.Controls.Add(Me.Frame18)
        Me.Controls.Add(Me.Frame20)
        Me.Controls.Add(Me.edtGearRatio)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnStatus)
        Me.Controls.Add(Me.btnLoad)
        Me.Controls.Add(Me.btnManualSet)
        Me.Controls.Add(Me.Frame12)
        Me.Controls.Add(Me.Frame11)
        Me.Controls.Add(Me._btnJog_4)
        Me.Controls.Add(Me._btnJog_6)
        Me.Controls.Add(Me._btnJog_2)
        Me.Controls.Add(Me.btn3DGraph)
        Me.Controls.Add(Me.cboAxisSet)
        Me.Controls.Add(Me.edtMoveUnit)
        Me.Controls.Add(Me.Frame7)
        Me.Controls.Add(Me.Frame1)
        Me.Controls.Add(Me._Label2_1)
        Me.Controls.Add(Me.Label1)
        Me.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Location = New System.Drawing.Point(3, 333)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCamcQI"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Ajinextek Motion board No[00]"
        Me.Frame15.ResumeLayout(False)
        Me.Frame16.ResumeLayout(False)
        Me.Frame17.ResumeLayout(False)
        Me.Frame17.PerformLayout()
        Me.Frame19.ResumeLayout(False)
        Me.Frame19.PerformLayout()
        Me.Frame13.ResumeLayout(False)
        Me.Frame18.ResumeLayout(False)
        Me.Frame20.ResumeLayout(False)
        Me.Frame12.ResumeLayout(False)
        Me.Frame11.ResumeLayout(False)
        CType(Me.LedEXMP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LedEXPP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LedBusyy, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LedBusyx, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Frame7.ResumeLayout(False)
        Me.Frame7.PerformLayout()
        Me.Frame9.ResumeLayout(False)
        Me.Frame8.ResumeLayout(False)
        Me.Frame8.PerformLayout()
        Me.Frame10.ResumeLayout(False)
        Me.Frame10.PerformLayout()
        Me.Frame1.ResumeLayout(False)
        Me.Frame6.ResumeLayout(False)
        Me.Frame5.ResumeLayout(False)
        Me.Frame4.ResumeLayout(False)
        CType(Me.LedEmg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LedZPhase, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LedHome, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LedAlarm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LedInp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LedNElm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LedPElm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Frame3.ResumeLayout(False)
        CType(Me.LedOut2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LedOut5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LedOut4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LedOut3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LedOut0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LedOut1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LedIn5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LedIn4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LedIn3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LedIn2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LedIn0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LedIn1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.m_grLevel.ResumeLayout(False)
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnJog, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tmHome, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tmTest, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XYPlot, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AxtMsg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GraphX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GraphY, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents XYPlot As AxAxtXYGraphLib.AxAxtXYGraph
    Friend WithEvents AxtMsg As AxAXTMESSENGERLib.AxAxtMessenger
    Friend WithEvents GraphX As AxAXTGRAPHLib.AxAxtGraph
    Friend WithEvents GraphY As AxAXTGRAPHLib.AxAxtGraph
#End Region
End Class