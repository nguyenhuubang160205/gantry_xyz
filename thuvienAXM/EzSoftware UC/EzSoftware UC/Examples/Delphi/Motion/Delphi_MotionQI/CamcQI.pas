unit CamcQI;

interface

uses
    Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
    AXL,AXM,AXHS, TeEngine, Series, ExtCtrls,
    TeeProcs, Chart, StdCtrls, AxCtrls, OleCtrls, Buttons,
    ComCtrls, MXGRAPH, TeeFunci, BubbleCh, TeeShape,Math;

const
    COORD_NO                = 0;
    WM_AMCALLTESTDoneMsg    = WM_USER + 8;
    WM_CAMC_INTERRUPT       = WM_USER + 2009;

    LINEAR_INTERPOLATION = 0;
    CIRCULAR_INTERPOLATION = 1;

  	INTERRUPT_USE		 = 1;
  	INTERRUPT_NOTUSE = 0;

  	TRIG_USE				 = 1;
  	TRIG_NOTUSE			 = 0;

  	DIOONEOUT_NOTUSE = 0;
  	DIOONEOUT_USE		 = 1;

  	DIO_OUTNOTUSE		 = 0;
  	DIO_OUTUSE			 = 1;

    WM_CAMCIP_INTERRUPT	= (WM_USER + 2009);
    HomeSensor       = 4;

type
    PSIGNAL_SEARCH = ^SIGNAL_SEARCH;
    SIGNAL_SEARCH = packed record
    nAxis      : SmallInt;
    nDir       : SmallInt;
    nSignal    : SmallInt;
    nStopM     : SmallInt;
  	dVelocity  : double;
    dAccel     : double;
end;
type
    PREPEAT_MOVE = ^REPEAT_MOVE;
    REPEAT_MOVE = packed record
    nAxis      : SmallInt;
    dPosition  : double;
  	dVelocity  : double;
    dAccel     : double;
    dDecel     : double;
end;

type
    TfrmCamcQI = class(TForm)
    Label5: TLabel;
    Label6: TLabel;
    GroupBox14: TGroupBox;
    LedBusyX: TLabel;
    LedBusyY: TLabel;
    LedEXPP: TLabel;
    LedEXMP: TLabel;
    GroupBox5: TGroupBox;
    Label20: TLabel;
    Label21: TLabel;
    Label24: TLabel;
    Label25: TLabel;
    m_pendsignal: TLabel;
    m_nendsignal: TLabel;
    m_pslowsignal: TLabel;
    m_nslowsignal: TLabel;
    m_alarmsignal: TLabel;
    m_inpossignal: TLabel;
    Label84: TLabel;
    Label85: TLabel;
    GroupBox6: TGroupBox;
    GroupBox8: TGroupBox;
    LedIn1: TLabel;
    LedIn2: TLabel;
    LedIn3: TLabel;
    LedOut0: TLabel;
    LedOut1: TLabel;
    LedOut2: TLabel;
    LedOut3: TLabel;
    LedIn4: TLabel;
    LedOut4: TLabel;
    LedIn5: TLabel;
    LedOut5: TLabel;
    LedIn0: TLabel;
    GroupBox9: TGroupBox;
    LedPElm: TLabel;
    LedNElm: TLabel;
    LedInp: TLabel;
    LedAlarm: TLabel;
    LedHome: TLabel;
    LedZPhase: TLabel;
    LedEmg: TLabel;
    StaticText20: TStaticText;
    StaticText21: TStaticText;
    StaticText22: TStaticText;
    StaticText23: TStaticText;
    StaticText24: TStaticText;
    StaticText25: TStaticText;
    StaticText26: TStaticText;
    GroupBox10: TGroupBox;
    btnMPGOn: TButton;
    btnMPGOff: TButton;
    GroupBox11: TGroupBox;
    btnCRCOn: TButton;
    btnCRCOff: TButton;
    m_grLevel: TGroupBox;
    cboAxisSet: TComboBox;
    GroupBox17: TGroupBox;
    Label108: TLabel;
    btnIntMessage: TButton;
    btnIntEvent: TButton;
    btnIntCallBack: TButton;
    edtInterruptCount: TEdit;
    btnIntDisable: TButton;
    GroupBox18: TGroupBox;
    cboDetect: TComboBox;
    cboDirection: TComboBox;
    cboStopM: TComboBox;
    btnSearch: TButton;
    StaticText47: TStaticText;
    StaticText48: TStaticText;
    StaticText49: TStaticText;
    GroupBox12: TGroupBox;
    edtUnit: TEdit;
    cboPulseOutM: TComboBox;
    edtCmdPosY: TEdit;
    edtActPosY: TEdit;
    edtCmdVelY: TEdit;
    btnCountClr: TButton;
    edtPulse: TEdit;
    edtCmdPosZ: TEdit;
    edtCmdPosU: TEdit;
    edtActPosU: TEdit;
    edtActPosZ: TEdit;
    edtCmdVelZ: TEdit;
    edtCmdVelU: TEdit;
    edtStartSpeed: TEdit;
    btnSetting: TButton;
    cboEncInputM: TComboBox;
    edtActPosX: TEdit;
    edtCmdVelX: TEdit;
    GroupBox3: TGroupBox;
    edtXEndCen: TEdit;
    edtYEndCen: TEdit;
    edtAngle: TEdit;
    btnLinear: TButton;
    btnCircular: TButton;
    chkCwCcw: TCheckBox;
    StaticText44: TStaticText;
    StaticText45: TStaticText;
    StaticText46: TStaticText;
    GroupBox4: TGroupBox;
    chkGantrySlave: TCheckBox;
    chkGantry: TCheckBox;
    GroupBox7: TGroupBox;
    chkAsym: TCheckBox;
    chkSCurve: TCheckBox;
    chkXYSyn: TCheckBox;
    edtPosition: TEdit;
    btnMove: TButton;
    edtVelocity: TEdit;
    btnRepeat: TButton;
    edtAccel: TEdit;
    btnStop: TButton;
    edtDecel: TEdit;
    btnEStop: TButton;
    chkRelative: TCheckBox;
    StaticText34: TStaticText;
    StaticText35: TStaticText;
    StaticText36: TStaticText;
    StaticText37: TStaticText;
    StaticText38: TStaticText;
    StaticText39: TStaticText;
    StaticText40: TStaticText;
    StaticText41: TStaticText;
    StaticText42: TStaticText;
    StaticText43: TStaticText;
    btnManualSet: TButton;
    btnLoad: TButton;
    btnStatus: TButton;
    btnSave: TButton;
    GroupBox1: TGroupBox;
    btnContiSpline: TButton;
    GroupBox13: TGroupBox;
    Label1: TLabel;
    Label2: TLabel;
    Label3: TLabel;
    Label4: TLabel;
    edtContiNum: TEdit;
    edtTotalNum: TEdit;
    edtQFree: TEdit;
    edtInMotion: TEdit;
    btnContiBlend: TButton;
    btnContiCircle: TButton;
    btnContiLine: TButton;
    btnContiTest: TButton;
    btnContiStart: TButton;
    btnContiClear: TButton;
    edtGearRatio: TEdit;
    Trigger: TGroupBox;
    edtTrigStartPosition: TEdit;
    edtTrigCycle: TEdit;
    edtTrigPulseWidth: TEdit;
    edtTrigEndPos: TEdit;
    btnTrigAbs: TButton;
    btnTrigOneShot: TButton;
    btnTrigReset: TButton;
    btnTrigPeriod: TButton;
    StaticText50: TStaticText;
    StaticText51: TStaticText;
    StaticText52: TStaticText;
    StaticText53: TStaticText;
    GroupBox16: TGroupBox;
    btnSigCapture: TButton;
    btnVelOverride: TButton;
    GroupBox19: TGroupBox;
    edtHomeVelFirst: TEdit;
    edtHomeVelSecond: TEdit;
    edtHomeVelThird: TEdit;
    edtHomeVelLast: TEdit;
    cboHomeSignal: TComboBox;
    cboHomeDir: TComboBox;
    btnHomeAll: TButton;
    btnHomeSingle: TButton;
    StaticText54: TStaticText;
    StaticText55: TStaticText;
    StaticText56: TStaticText;
    StaticText57: TStaticText;
    StaticText58: TStaticText;
    StaticText59: TStaticText;
    GroupBox20: TGroupBox;
    edtCapturePos: TEdit;
    btnReadCapture: TButton;
    chkGearOnOff: TCheckBox;
    lstLog: TListBox;
    btn3DGraph: TButton;
    StaticText1: TStaticText;
    StaticText2: TStaticText;
    StaticText3: TStaticText;
    StaticText4: TStaticText;
    StaticText5: TStaticText;
    StaticText6: TStaticText;
    StaticText7: TStaticText;
    Org: TStaticText;
    Zph: TStaticText;
    StaticText10: TStaticText;
    StaticText11: TStaticText;
    StaticText12: TStaticText;
    StaticText13: TStaticText;
    StaticText14: TStaticText;
    StaticText15: TStaticText;
    StaticText16: TStaticText;
    StaticText17: TStaticText;
    StaticText18: TStaticText;
    StaticText19: TStaticText;
    StaticText8: TStaticText;
    StaticText9: TStaticText;
    StaticText27: TStaticText;
    StaticText28: TStaticText;
    StaticText29: TStaticText;
    StaticText30: TStaticText;
    StaticText31: TStaticText;
    StaticText32: TStaticText;
    StaticText33: TStaticText;
    StaticText63: TStaticText;
    StaticText62: TStaticText;
    StaticText61: TStaticText;
    StaticText60: TStaticText;
    trkXYRange: TTrackBar;
    trkXYRange2: TTrackBar;
    tmDisplay: TTimer;
    tmGraph: TTimer;
    tmHome1: TTimer;
    tmHome2: TTimer;
    tmHome3: TTimer;
    tmHome4: TTimer;
    OpenDialog1: TOpenDialog;
    SaveDialog1: TSaveDialog;
    GraphX: TChart;
    Series1: TFastLineSeries;
    Series2: TFastLineSeries;
    edtCmdPosX: TEdit;
    edtMoveUnit: TEdit;
    chkAbsolute: TCheckBox;
    XYPlot: TChart;
    Series5: TPointSeries;
    chkPElmLevel: TCheckBox;
    chkNElmLevel: TCheckBox;
    chkInpLevel: TCheckBox;
    chkAlarmLevel: TCheckBox;
    chkHomeLevel: TCheckBox;
    chkZPhaseLevel: TCheckBox;
    chkEmgLevel: TCheckBox;
    btnJogPX: TButton;
    btnJogNX: TButton;
    btnJogNY: TButton;
    btnJogPY: TButton;
    btnJogPZ: TButton;
    btnJogNZ: TButton;
    btnJogNU: TButton;
    btnJogPU: TButton;
    GraphY: TChart;
    Series3: TFastLineSeries;
    Series4: TFastLineSeries;
    procedure cboAxisSetChange(Sender: TObject);
    procedure FormCreate(Sender: TObject);
    procedure FormDestroy(Sender: TObject);
    procedure cboPulseOutMChange(Sender: TObject);
    procedure cboEncInputMChange(Sender: TObject);
    procedure btnSettingClick(Sender: TObject);
    procedure chkPElmLevelClick(Sender: TObject);
    procedure chkNElmLevelClick(Sender: TObject);
    procedure chkInpLevelClick(Sender: TObject);
    procedure chkAlarmLevelClick(Sender: TObject);
    procedure chkZPhaseLevelClick(Sender: TObject);
    procedure btnMPGOnClick(Sender: TObject);
    procedure btnMPGOffClick(Sender: TObject);
    procedure btnCRCOnClick(Sender: TObject);
    procedure btnCRCOffClick(Sender: TObject);
    procedure btnCountClrClick(Sender: TObject);
    procedure btnMoveClick(Sender: TObject);
    procedure btnRepeatClick(Sender: TObject);
    procedure tmDisplayTimer(Sender: TObject);
    procedure btnStopClick(Sender: TObject);
    procedure btnEStopClick(Sender: TObject);
    procedure chkAbsoluteClick(Sender: TObject);
    procedure chkRelativeClick(Sender: TObject);
    procedure chkSCurveClick(Sender: TObject);
    procedure chkAsymClick(Sender: TObject);
    procedure chkXYSynClick(Sender: TObject);
    procedure btnLinearClick(Sender: TObject);
    procedure btnCirCularClick(Sender: TObject);
    procedure btnSearchClick(Sender: TObject);
    procedure btnContiSplineClick(Sender: TObject);
    procedure btnContiStartClick(Sender: TObject);
    procedure btnContiClearClick(Sender: TObject);
    procedure btnContiTestClick(Sender: TObject);
    procedure btnTrigAbsClick(Sender: TObject);
    procedure btnTrigOneShotClick(Sender: TObject);
    procedure btnTrigPeriodClick(Sender: TObject);
    procedure btnTrigResetClick(Sender: TObject);
    procedure btnHomeAllClick(Sender: TObject);
    procedure btnHomeSingleClick(Sender: TObject);
    procedure tmGraphTimer(Sender: TObject);
    procedure tmHomeTimer(Sender: TObject);
    procedure LedOut0Click(Sender: TObject);
    procedure LedOut1Click(Sender: TObject);
    procedure LedOut2Click(Sender: TObject);
    procedure LedOut3Click(Sender: TObject);
    procedure LedOut4Click(Sender: TObject);
    procedure LedOut5Click(Sender: TObject);
    procedure btnManualSetClick(Sender: TObject);
    procedure chkHomeLevelClick(Sender: TObject);
    function ThreadData () : Boolean; stdcall;
    Function InitLibrary() : Boolean; stdcall;
    Function InitControl() : Boolean; stdcall;
    Function UpdateAxisInfo() : Integer; stdcall;
    Function SetTitleBar(lAxis : SmallInt) : Integer; stdcall;
    procedure SetCoordMovePara();   stdcall;

    procedure btnStatusClick(Sender: TObject);
    procedure btnJogMouseDown(Sender: TObject; Button: TMouseButton;
        Shift: TShiftState; X, Y: Integer);
    procedure btnJogMouseUp(Sender: TObject; Button: TMouseButton;
    Shift: TShiftState; X, Y: Integer);
    procedure btnLoadClick(Sender: TObject);
    procedure btnSaveClick(Sender: TObject);
    procedure btnContiBlendClick(Sender: TObject);
    procedure btnContiCircleClick(Sender: TObject);
    procedure btnContiLineClick(Sender: TObject);
    procedure btnIntMessageClick(Sender: TObject);
    procedure btnIntEventClick(Sender: TObject);
    procedure btnIntCallBackClick(Sender: TObject);
    procedure btnIntDisableClick(Sender: TObject);
    procedure chkGearOnOffClick(Sender: TObject);
    procedure btnSigCaptureClick(Sender: TObject);
    procedure btnVelOverrideClick(Sender: TObject);
    procedure btn3DGraphClick(Sender: TObject);
    procedure trkXYRangeChange(Sender: TObject);
    procedure chkEmgLevelClick(Sender: TObject);
    procedure chkGantryClick(Sender: TObject);
    procedure Edit_right_align(Sender: TObject; edt_name: TEdit);
    procedure Edit_center_align(Sender: TObject; edt_name: TEdit);
    procedure SetGraphRange(lAxis : smallint; dVelocity:double);
    procedure btnReadCaptureClick(Sender: TObject);

    Function LED_RED(nOn : Boolean)  : Integer ;  stdcall;
    Function LED_YELLOW(nOn : Boolean)  : Integer ;  stdcall;
    Function AXIS_EVN(nAxis : SmallInt)  : Integer ;  stdcall;
    Function AXIS_ODD(nAxis : SmallInt)  : Integer ;  stdcall;
    Function AXIS_QUR(nAxis : SmallInt)  : Integer ;   stdcall;
    Function AXIS_N04(nAxis, nPos : smallInt)  : Integer ; stdcall;
    Function AXIS_N01(nAxis : SmallInt)  : Integer ; stdcall;
    Function AXIS_N02(nAxis : SmallInt)  : Integer ; stdcall;
    procedure lstLogDblClick(Sender: TObject);
    procedure chkGantrySlaveClick(Sender: TObject);

  private
    { Private declarations }
    procedure OnControlMessage(var Msg : TMessage); message WM_CAMC_INTERRUPT;
  public
    { Public declarations }
    
    RepeatFlag, EStop : Boolean;
    m_errorcode       : DWord;

    m_bA4NAxis        : Boolean;

    m_hHandle         : array [0..63] of THandle;
    m_lAxisCounts     : longInt;
    m_bTestActive     : array [0..63] of Boolean;
    m_hTestThread     : array [0..63] of THandle;
  end;
  
   Function RepeatThread(PRM_M : Pointer) : LongInt; StdCall;
   Function SearchThread(PSI_M : Pointer) : LongInt; StdCall;
var
    frmCamcQI: TfrmCamcQI;
    m_hInterrupt      : array [0..63] of DWord;
    m_bThread         : array [0..63] of Boolean;
implementation

uses
    ManualSet, DGraph, Status;
var
//    count1, count2 : SmallInt;
//    count3, count4 : SmallInt;
    m_lAxis     : SmallInt;
    g_nIntCnt   : LongInt;
//    bByte       : Byte;
    m_dRange    : Double;
{$R *.dfm}

function ThreadProc(lpData : Pointer): Boolean; StdCall;
var
    pDlg : TfrmCamcQI;
begin
	pDlg := TfrmCamcQI(lpData);
	pDlg.ThreadData();
end;

function SearchThread(PSI_M: Pointer): LongInt;  StdCall;
var
    nSignal: SmallInt;
    dwEdge, dwBusyStatus, dwEndStatus: DWord;
    strLog: String;
    SI_M: PSIGNAL_SEARCH;
begin
    if(SI_M^.nSignal < 6) Then
    begin
        dwEdge  := 0;
        nSignal	:= SI_M^.nSignal;
    end
    else
    begin
        dwEdge	:= 1;
        nSignal	:= SI_M^.nSignal - 4;
    end;

    if nSignal > 1 then
    begin
        nSignal := nSignal + 2;
    end;

	// Re-setup of the maximum value in chart for displaying running speed of each axis on the chart.
    frmCamcQI.SetGraphRange(SI_M^.nAxis, SI_M^.dVelocity);

	// Setup running direction (-) direction
	if(SI_M^.nDir = 1)	Then    AxmMoveSignalSearch(SI_M^.nAxis, -SI_M^.dVelocity, SI_M^.dAccel, nSignal, dwEdge, SI_M^.nStopM)
	else				        AxmMoveSignalSearch(SI_M^.nAxis, SI_M^.dVelocity, SI_M^.dAccel, nSignal, dwEdge, SI_M^.nStopM);

    repeat
		AxmStatusReadInMotion(SI_M^.nAxis, @dwBusyStatus);
		Sleep(1);

	//	if(frmCamcQI.m_bTestActive[frmCamcQI.AXIS_QUR(SI_M^.nAxis)] = FALSE) Then   AxmMoveSStop(SI_M^.nAxis);
    until  dwBusyStatus = 0;
	// Check how running was stopped on certain condition by referring End Status Register.

   	AxmStatusReadStop(SI_M^.nAxis, @dwEndStatus);
	if(nSignal > 3) Then
    begin
		if((dwEndStatus And $FFFF) <> 0) Then  frmCamcQI.lstLog.Items.Add('Search failed.')
		else
        begin
			strLog := frmCamcQI.cboDetect.Items.Strings[frmCamcQI.cboDetect.ItemIndex];
            frmCamcQI.lstLog.Items.Add('Search '+strLog+'complete axis '+IntToStr(SI_M^.nAxis));
		end;
    end;
    
    frmCamcQI.lstLog.TopIndex := frmCamcQI.lstLog.Count - 1;
  	frmCamcQI.m_bTestActive[frmCamcQI.AXIS_QUR(SI_M^.nAxis)] := FALSE;
    CloseHandle(frmCamcQI.m_hTestThread[frmCamcQI.AXIS_QUR(SI_M^.nAxis)]);
	frmCamcQI.m_hTestThread[frmCamcQI.AXIS_QUR(SI_M^.nAxis)] := 0;
end;

function RepeatThread(PRM_M: Pointer): LongInt;  StdCall;
var
    dCurPos: Double;
    dwMode: DWord;
    dwBusyStatus: DWord;
    RM_M: PREPEAT_MOVE;
begin
    RM_M := PRM_M;

	AxmStatusGetCmdPos(RM_M^.nAxis, @dCurPos);
	AxmMotGetAbsRelMode(RM_M^.nAxis, @dwMode);

	// Re-setup of the maximum value in chart for displaying running speed of each axis on the chart.
    frmCamcQI.SetGraphRange(RM_M^.nAxis, RM_M^.dVelocity);
    while frmCamcQI.m_bTestActive[frmCamcQI.AXIS_QUR(RM_M^.nAxis)] = True do
    begin
        AxmMoveStartPos(RM_M^.nAxis, RM_M^.dPosition, RM_M^.dVelocity, RM_M^.dAccel, RM_M^.dAccel);
        repeat
        	AxmStatusReadInMotion(RM_M^.nAxis, @dwBusyStatus);
			Sleep(1);
        until  dwBusyStatus = 0;

        if(frmCamcQI.m_bTestActive[frmCamcQI.AXIS_QUR(RM_M^.nAxis)] = false) Then Break;

		if(dwMode = POS_ABS_MODE) Then
        begin
            if(dCurPos = RM_M^.dPosition) Then Break;
    			AxmMoveStartPos(RM_M^.nAxis, dCurPos, RM_M^.dVelocity, RM_M^.dAccel, RM_M^.dAccel);
        end
        else
        begin
        	if(0 = RM_M^.dPosition)	Then Break;
	   		AxmMoveStartPos(RM_M^.nAxis, -RM_M^.dPosition, RM_M^.dVelocity, RM_M^.dAccel, RM_M^.dAccel);
        end;

        repeat
        	AxmStatusReadInMotion(RM_M^.nAxis, @dwBusyStatus);
			Sleep(1);
        until  dwBusyStatus = 0;
    end;

  	frmCamcQI.m_bTestActive[frmCamcQI.AXIS_QUR(RM_M^.nAxis)] := FALSE;
    CloseHandle(frmCamcQI.m_hTestThread[frmCamcQI.AXIS_QUR(RM_M^.nAxis)]);
	frmCamcQI.m_hTestThread[frmCamcQI.AXIS_QUR(RM_M^.nAxis)] := 0;
end;

procedure TfrmCamcQI.FormCreate(Sender: TObject);
begin
    InitLibrary();						// Combined Library and Module initialize
	InitControl();						// Graph and button control initialize

	UpdateAxisInfo();

    tmDisplay.Enabled := true;
    tmGraph.Enabled   := true;
end;

procedure TfrmCamcQI.FormDestroy(Sender: TObject);
var
    i : Integer;
begin
    m_bTestActive[0] := False;
    m_bTestActive[1] := false;
	m_bTestActive[2] := false;
    m_bTestActive[3] := false;
	for i := 0 to  m_lAxisCounts do
    begin
		AxmMoveEStop(i);
		AxmSignalWriteOutputBit(i, 0, 0);
    end;

    for i := 0 to 4 do
    begin
	    if(m_hTestThread[i] <> 0)then
        begin
			WaitForSingleObject(m_hTestThread[i],  WAIT_ABANDONED);
			CloseHandle(m_hTestThread[i]);
			m_hTestThread[i] := 0;
        end
    end;

    AxlClose();
end;

Function TfrmCamcQI.InitLibrary() : Boolean;
begin
    if ((AxlOpen(7) <> AXT_RT_SUCCESS))then
    begin
	    ShowMessage('AxlOpen Fail...')
    end;
    Result := true;
end;

Function TfrmCamcQI.InitControl() : Boolean;
var
    i   :   Integer;
    dwProfile : DWORD;
    dwModuleID : DWORD;
begin
    cboDetect.ItemIndex := 4;
    cboDirection.ItemIndex := 1;
    cboStopM.ItemIndex := 1;

    cboPulseOutM.ItemIndex := 0;
    cboEncInputM.ItemIndex := 0;
    cboHomeSignal.ItemIndex := 2;
    cboHomeDir.ItemIndex := 0;

    XYPlot.LeftAxis.Minimum := -2500;
    XYPlot.LeftAxis.Maximum := 2500;
    XYPlot.BottomAxis.Minimum := -2500;
    XYPlot.BottomAxis.Maximum := 2500;

    Edit_right_align(self , edtCmdPosX);        Edit_right_align(self , edtCmdPosY);
    Edit_right_align(self , edtCmdPosZ);        Edit_right_align(self , edtCmdPosU);

    Edit_right_align(self , edtActPosX);        Edit_right_align(self , edtActPosY);
    Edit_right_align(self , edtActPosZ);        Edit_right_align(self , edtActPosU);

    Edit_right_align(self , edtCmdVelX);        Edit_right_align(self , edtCmdVelY);
    Edit_right_align(self , edtCmdVelZ);        Edit_right_align(self , edtCmdVelU);

    Edit_right_align(self , edtPulse);          Edit_right_align(self , edtUnit);
    Edit_right_align(self , edtMoveUnit);       Edit_right_align(self , edtStartSpeed);

    Edit_right_align(self , edtPosition);       Edit_right_align(self , edtVelocity);
    Edit_right_align(self , edtAccel);          Edit_right_align(self , edtDecel);

    Edit_right_align(self , edtXEndCen);
    Edit_right_align(self , edtYEndCen);
    Edit_right_align(self , edtAngle);

    Edit_right_align(self , edtHomeVelFirst);   Edit_right_align(self , edtHomeVelSecond);
    Edit_right_align(self , edtHomeVelThird);   Edit_right_align(self , edtHomeVelLast);

    Edit_right_align(self , edtGearRatio);
    Edit_right_align(self , edtTrigStartPosition);
    Edit_right_align(self , edtTrigCycle);
    Edit_right_align(self , edtTrigPulseWidth);
    Edit_right_align(self , edtTrigEndPos);

    Edit_center_align(self , edtContiNum);      Edit_center_align(self , edtTotalNum);
    Edit_center_align(self , edtQFree);         Edit_center_align(self , edtInMotion);
 
    trkXYRange.Position := 5;
	trkXYRange2.Position := 2;

    AxmInfoGetAxisCount(@m_lAxisCounts);
    for i := 0 to m_lAxisCounts-1 do
    begin
        AxmInfoGetAxis(i, NIL, NIL, @dwModuleID);
        if (dwModuleID = AXT_SMC_4V04) then begin
    	   	cboAxisSet.Items.Add(IntToStr(i) + '-[PCIB-QI4A]');
        end
        else if (dwModuleID = AXT_SMC_2V04) then begin
            cboAxisSet.Items.Add(IntToStr(i) + '-[PCIB-QI2A]');
        end
        else if (dwModuleID = AXT_SMC_R1V04) then begin
            cboAxisSet.Items.Add(IntToStr(i) + '-(RTEX-PM)');
        end
        else if (dwModuleID = AXT_SMC_R1V04A4) then begin
            cboAxisSet.Items.Add(IntToStr(i) + '-[RTEX-A4N]');
        end
        else if (dwModuleID = AXT_SMC_R1V04MLIISV) then begin
            cboAxisSet.Items.Add(IntToStr(i) + '-[MLII-SGDV]');
        end
        else if (dwModuleID = AXT_SMC_R1V04MLIIPM) then begin
            cboAxisSet.Items.Add(IntToStr(i) + '-(MLII-PM)');
        end
        else if (dwModuleID = AXT_SMC_R1V04MLIICL) then begin
            cboAxisSet.Items.Add(IntToStr(i) + '-(MLII-CSDL)');
        end
        else if (dwModuleID = AXT_SMC_R1V04MLIICR) then begin
            cboAxisSet.Items.Add(IntToStr(i) + '-(MLII-CSDH)');
        end
        else
            cboAxisSet.Items.Add(IntToStr(i) + '-[Unknown]');
    end;

    cboAxisSet.ItemIndex := 0;
    Result := true;
end;

procedure TfrmCamcQI.Edit_right_align(Sender: TObject; edt_name: TEdit);
var
    AStyle:Integer;
begin
    AStyle:=GetWindowLong(edt_name.Handle, GWL_STYLE);
    AStyle:= (AStyle And $FFFFFFFE) Or $2;
    SetWindowLong(edt_name.Handle,GWL_STYLE,AStyle);
    edt_name.Repaint;
end;

procedure TfrmCamcQI.Edit_center_align(Sender: TObject; edt_name: TEdit);
var
    AStyle:Integer;
begin
    AStyle:=GetWindowLong(edt_name.Handle, GWL_STYLE);
    AStyle:= (AStyle And $FFFFFFFD) Or $1;
    SetWindowLong(edt_name.Handle,GWL_STYLE,AStyle);
    edt_name.Repaint;
end;

Function TfrmCamcQI.LED_RED(nOn : Boolean)  : Integer ;
Begin
    if (nOn = true) then    Result := clRed
    else                    Result := clMaroon;
End;

Function TfrmCamcQI.LED_YELLOW(nOn : Boolean)  : Integer ;
Begin
    if (nOn = true) then    Result := clYellow
    else                    Result := clOlive;
End;

Function TfrmCamcQI.AXIS_EVN(nAxis : SmallInt)  : Integer ;             // Searching for even number axis of axis which makes couple
Begin
    Result :=   nAxis - (nAxis Mod 2);
End;

Function TfrmCamcQI.AXIS_ODD(nAxis : SmallInt)  : Integer ;             // Searching for odd number axis of axis which makes couple
Begin
    Result :=   nAxis + ((nAxis + 1) Mod 2);
End;

Function TfrmCamcQI.AXIS_QUR(nAxis : SmallInt)  : Integer ;
Begin
    Result :=   (nAxis Mod 4);
End;

Function TfrmCamcQI.AXIS_N04(nAxis, nPos : smallInt)  : Integer ;       // Change to the axis' location of the one chip
Begin
    Result :=   ((nAxis div 4) * 4) + nPos;
End;

Function TfrmCamcQI.AXIS_N01(nAxis : SmallInt)  : Integer ;             // Change axis of 0, 1 or 0, 2, 3 to 1
Begin
    Result :=   ((nAxis Mod 4) shr 2);
End;

Function TfrmCamcQI.AXIS_N02(nAxis : SmallInt)  : Integer ;             // Change axis of 0, 2 or 0, 1, 3 to 1
Begin
    Result :=   ((nAxis Mod 4)  Mod 2);
End;

procedure TfrmCamcQI.SetGraphRange(lAxis : SmallInt; dVelocity:double);
begin
	if(dVelocity <= 0)then exit;

	// Re-setup of the maximum value in chart for displaying running speed of each axis on the chart.
	if(AXIS_QUR(lAxis) < 2)then GraphX.LeftAxis.Maximum := dVelocity + (dVelocity * 0.2)
	else					    GraphY.LeftAxis.Maximum := dVelocity + (dVelocity * 0.2);
end;

Function TfrmCamcQI.SetTitleBar(lAxis : SmallInt)  : Integer ;
var
    dwModuleID  : DWord;
    lAxtBoardNo, lModulePos : LongInt;
begin
	lAxtBoardNo := 0; lModulePos := 0;

	AxmInfoGetAxis(lAxis, @lAxtBoardNo, @lModulePos, @dwModuleID);
    frmCamcQI.Caption := 'Ajinextek Motion Board No: [' + IntToStr(lAxtBoardNo)+'], Module Pos['+Format('0%x',[lModulePos])+']'+', Module ID['+Format('0%x',[dwModuleID]) +']';
end;

// Setup distance rate and initial speed by pulse among those initial parameter.
// Change maximum speed to fit if setup distance rate by pulse.
procedure TfrmCamcQI.cboAxisSetChange(Sender: TObject);
begin
    m_lAxis := cboAxisSet.ItemIndex;
    UpdateAxisInfo();
end;

Function TfrmCamcQI.UpdateAxisInfo():Integer;stdcall;
var
 	dwMEncInput, dwMPulseOut  : DWord;
	dwAbsRel, dwProfile : DWord;

	lPulse  : LongInt ;
	dUnit   : Double;
	dMinVelocity  : Double;
	dInitpos, dInitvel, dInitaccel, dInitdecel  : double;

    dwPositiveLevel, dwNegativeLevel, dwAlarmLevel, dwInposLevel    :   DWord;
	dwHomeLevel, dwZphaseLevel  :   DWORD;
	dwStopMode, dwReadEmg   :   DWORD;
	dGearRatio  :   Double;

    upSlHomeUse : DWORD;
    strCaption: String;

    dwModuleID : DWORD;
Begin
    cboAxisSet.ItemIndex := m_lAxis;
    lPulse := 1;
    dUnit := 1.0;
    dMinVelocity := 1.0; dInitpos := 1.0; dInitvel := 1.0; dInitaccel := 1.0; dInitdecel := 1.0;

    AxmInfoGetAxis(m_lAxis, NIL, NIL, @dwModuleID);

    case dwModuleID of
    AXT_SMC_4V04, AXT_SMC_2V04, AXT_SMC_2V03, AXT_SMC_R1V04:
    begin

        m_bA4NAxis := false;

        cboEncInputM.Enabled := true;
        cboPulseOutM.Enabled := true;

        chkPElmLevel.AllowGrayed := true;
        chkNElmLevel.AllowGrayed := true;
        chkEmgLevel.AllowGrayed := true;
        chkAlarmLevel.AllowGrayed := true;
        chkInpLevel.AllowGrayed := true;
        chkZPhaseLevel.Enabled := true;
        chkHomeLevel.Enabled := true;

        edtTrigStartPosition.Enabled := true;
        edtTrigCycle.Enabled := true;
        edtTrigPulseWidth.Enabled := true;
        edtTrigEndPos.Enabled := true;
        btnTrigAbs.Enabled := true;
        btnTrigOneShot.Enabled := true;
        btnTrigPeriod.Enabled := true;
        btnTrigReset.Enabled := true;
        m_grLevel.Caption := 'Level Setting';

        if(dwModuleID = AXT_SMC_R1V04) then
        begin
            btnIntMessage.Enabled := false;
            btnIntEvent.Enabled := false;
            btnIntCallBack.Enabled := false;
            btnIntDisable.Enabled := false;
            btnCRCOn.Enabled := false;
            btnCRCOff.Enabled := false;
            btnMPGOn.Enabled := false;
            btnMPGOff.Enabled := false;
        end
        else
        begin
            btnIntMessage.Enabled := true;
            btnIntEvent.Enabled := true;
            btnIntCallBack.Enabled := true;
            btnIntDisable.Enabled := true;
            btnCRCOn.Enabled := true;
            btnCRCOff.Enabled := true;
            btnMPGOn.Enabled := true;
            btnMPGOff.Enabled := true;
        end;
    end;
    AXT_SMC_R1V04A4:
    begin
        m_bA4NAxis := true;

        cboEncInputM.Enabled := false;
        cboPulseOutM.Enabled := false;

        chkPElmLevel.AllowGrayed := false;
        chkNElmLevel.AllowGrayed := false;
        chkEmgLevel.AllowGrayed := false;
        chkAlarmLevel.AllowGrayed := false;
        chkInpLevel.AllowGrayed := false;
        chkZPhaseLevel.Enabled := false;
        chkHomeLevel.Enabled := false;

        m_grLevel.Caption := 'Level/Usage';
        edtTrigStartPosition.Enabled := false;
        edtTrigCycle.Enabled := false;
        edtTrigPulseWidth.Enabled := false;
        edtTrigEndPos.Enabled := false;
        btnTrigAbs.Enabled := false;
        btnTrigOneShot.Enabled := false;
        btnTrigPeriod.Enabled := false;
        btnTrigReset.Enabled := false;
        btnIntMessage.Enabled := false;
        btnIntEvent.Enabled := false;
        btnIntCallBack.Enabled := false;
        btnIntDisable.Enabled := false;
        btnCRCOn.Enabled := false;
        btnCRCOff.Enabled := false;
        btnMPGOn.Enabled := false;
        btnMPGOff.Enabled := false;

    end;
    end;

	AxmMotGetParaLoad(m_lAxis, @dInitpos ,@dInitvel, @dInitaccel, @dInitdecel);

	// Display pulse output method after initialization, encoder input method, initial speed, distance rate by pulse on the screen.
	AxmMotGetMoveUnitPerPulse(m_lAxis, @dUnit , @lPulse);
	AxmMotGetMinVel(m_lAxis, @dMinVelocity);

    edtUnit.Text        := FormatFloat('0.####0', dUnit);
    edtPulse.Text       := Format('%d', [lPulse]);
    if (lPulse <> 0) then
        edtMoveUnit.Text    := FormatFloat('0.#####0', dUnit/lPulse);
    edtStartSpeed.Text  := FormatFloat('0.##0', dMinVelocity);

    edtPosition.Text    := FormatFloat('0.##0', dInitpos);
    edtVelocity.Text    := FormatFloat('0.##0', dInitvel);
    edtAccel.Text       := FormatFloat('0.##0', dInitaccel);
    edtDecel.Text       := FormatFloat('0.##0', dInitdecel);

 	AxmMotGetProfileMode(m_lAxis, @dwProfile);
	AxmMotGetAbsRelMode(m_lAxis, @dwAbsRel);

    if (m_bA4NAxis = true) then
    begin
     	AxmMotGetEncInputMethod(m_lAxis, @dwMEncInput);
	    AxmMotGetPulseOutMethod(m_lAxis, @dwMPulseOut);

        cboEncInputM.ItemIndex  := dwMEncInput;
        cboPulseOutM.ItemIndex := dwMPulseOut;
    end;

    if(dwAbsRel = 1)then
    begin
        chkRelative.Checked := true;
        chkAbsolute.Checked := false;
    end
    else
    begin
        chkRelative.Checked := false;
        chkAbsolute.Checked := true;
    end;

    if((dwProfile = 2) or (dwProfile = 3) or (dwProfile = 4))then chkSCurve.Checked := true
    else                                                          chkSCurve.Checked := false;

	if((dwProfile = 1) or (dwProfile = 4))then
    begin
	    edtDecel.Enabled := true;
		chkAsym.Checked := true;
    end
	else
    begin
	    edtDecel.Enabled := false;
		chkAsym.Checked := false;
    end;

	AxmSignalGetLimit(m_lAxis, @dwStopMode, @dwPositiveLevel, @dwNegativeLevel);
	AxmSignalGetServoAlarm(m_lAxis, @dwAlarmLevel);
	AxmSignalGetInpos(m_lAxis, @dwInposLevel);

	AxmSignalGetStop(m_lAxis, @dwStopMode, @dwReadEmg);

    if (m_bA4NAxis = true) then
    begin
        AxmHomeGetSignalLevel(m_lAxis, @dwHomeLevel);
        AxmSignalGetZphaseLevel(m_lAxis, @dwZphaseLevel);

        chkPElmLevel.Checked   := Boolean(dwPositiveLevel);
        chkNElmLevel.Checked   := Boolean(dwNegativeLevel);
        chkEmgLevel.Checked    := Boolean(dwReadEmg);
        chkAlarmLevel.Checked  := Boolean(dwAlarmLevel);
        chkInpLevel.Checked    := Boolean(dwInposLevel);
        chkHomeLevel.Checked   := Boolean(dwHomeLevel);
        chkZPhaseLevel.Checked := Boolean(dwZphaseLevel);
    end
    else begin
        if (dwPositiveLevel = UNUSED) then chkPElmLevel.Checked := false
        else                          chkPElmLevel.Checked := true;

        if (dwNegativeLevel = UNUSED) then chkNElmLevel.Checked := false
        else                          chkNElmLevel.Checked := true;

        if (dwReadEmg = UNUSED)       then chkEmgLevel.Checked := false
        else                          chkEmgLevel.Checked := true;

        if (dwAlarmLevel = UNUSED)    then chkAlarmLevel.Checked := false
        else                          chkAlarmLevel.Checked := true;

        if (dwInposLevel = UNUSED)    then chkInpLevel.Checked := false
        else                          chkInpLevel.Checked := true;
    end;

	AxmLinkGetMode(AXIS_EVN(m_lAxis), nil, @dGearRatio);
	if(dGearRatio > 0)then
    begin
        chkGearOnOff.Checked := true;
        edtGearRatio.Text := FormatFloat('0.##0', dGearRatio);
    end
	else
        chkGearOnOff.Checked := false;

    SetTitleBar(m_lAxis);

    AxmGantryGetEnable(m_lAxis, @upSlHomeUse, nil, nil, nil);
    if(upSlHomeUse = 0) then begin
        chkGantrySlave.Checked := false;
    end
    else
        chkGantrySlave.Checked := true;

    if(chkGantrySlave.State = cbUnchecked) then begin
	    strCaption := 'Do not Search';
    end
	else if(chkGantrySlave.State = cbChecked) then begin
        strCaption := 'Do origin revision after Search';
    end
	else if(chkGantrySlave.State = cbGrayed) then begin
        strCaption := 'Do not origin revision after Search';
    end;

	chkGantrySlave.Caption := strCaption;
end;

function TfrmCamcQI.ThreadData():Boolean; stdcall;
var
    lAxisNo: LongInt;
    dwFlag: DWord;
    strData: String;
    IntBank0, IntBank1: DWord;
begin
    lAxisNo := m_lAxis;
    while m_bThread[lAxisNo] = True do
    begin
        if (WaitForSingleObject(m_hInterrupt[lAxisNo], INFINITE) = WAIT_OBJECT_0) then
    	begin
            AxmInterruptReadAxisFlag(lAxisNo, 0, @IntBank0);
        	AxmInterruptReadAxisFlag(lAxisNo, 1, @IntBank1);

        	g_nIntCnt := g_nIntCnt + 1;
            strData := 'Event[' + Format('%d', [g_nIntCnt]) + ']Axis[' +  Format('%d', [lAxisNo]) + ']Flag[0x' + Format('%X', [IntBank0]) + Format(', 0x%X', [IntBank1]) + ']';
        	frmCamcQI.lstLog.Items.Add(strData);
        end;
    end;
end;

procedure TfrmCamcQI.cboPulseOutMChange(Sender: TObject);
begin
    AxmMotSetPulseOutMethod(m_lAxis, cboPulseOutM.ItemIndex);
end;

procedure TfrmCamcQI.cboEncInputMChange(Sender: TObject);
begin
    AxmMotSetEncInputMethod(m_lAxis, cboEncInputM.ItemIndex);
end;

// Setup distance rate and initial speed by pulse among those initial parameter.
// Change maximum speed to fit if setup distance rate by pulse.
procedure TfrmCamcQI.btnSettingClick(Sender: TObject);
var
    lPulse : LongInt;
    dMoveUnit, dStartStop : double;
  	dUnit, dMinVelocity : double;
begin
    lPulse     := LongInt(StrToInt(edtPulse.Text));
    dMoveUnit  := StrToFloat(edtUnit.Text);
    dStartStop := StrToFloat(edtStartSpeed.Text);

    AxmMotSetMoveUnitPerPulse(m_lAxis, dMoveUnit, lPulse);
    AxmMotSetMinVel(m_lAxis, dStartStop);
    AxmMotGetMoveUnitPerPulse(m_lAxis, @dUnit, @lPulse);
    AxmMotGetMinVel(m_lAxis, @dMinVelocity);

    edtMoveUnit.text :=  FormatFloat('0.#####0', dUnit/lPulse);
    edtUnit.text :=  FormatFloat('0.##0', dUnit);
    edtPulse.text :=  Format('%d', [lPulse]);
    edtStartSpeed.text := FormatFloat('0.##0', dMinVelocity);
end;

// Setup active level value of (+) End Limit.
procedure TfrmCamcQI.chkPElmLevelClick(Sender: TObject);
var
	dwNegativeLevel, upStopMode, dwLevel : DWORD;
begin
    AxmSignalGetLimit(m_lAxis, @upStopMode, Nil, @dwNegativeLevel);

    if (m_bA4NAxis = true) then begin
        AxmSignalSetLimit(m_lAxis,  upStopMode,  DWORD(chkPElmLevel.State), dwNegativeLevel);
    end
    else begin
        if (chkPElmLevel.Checked = false ) then dwLevel := 2
        else                                    dwLevel := 1;
        AxmSignalSetLimit(m_lAxis,  upStopMode,  dwLevel, dwNegativeLevel);
    end;
end;

// Setup active level value of (-) End Limit.
procedure TfrmCamcQI.chkNElmLevelClick(Sender: TObject);
var
    dwPositiveLevel, upStopMode, dwLevel : DWORD;
begin
    AxmSignalGetLimit(m_lAxis, @upStopMode, @dwPositiveLevel, Nil);

    if (m_bA4NAxis = true) then begin
        AxmSignalSetLimit(m_lAxis,  upStopMode, dwPositiveLevel, DWORD(chkNElmLevel.State));
    end
    else begin
        if (chkNElmLevel.Checked = false ) then dwLevel := 2
        else                                    dwLevel := 1;
        AxmSignalSetLimit(m_lAxis,  upStopMode, dwPositiveLevel, dwLevel);
    end;
end;

// Setup active level value of in-position signal.  High if checked, Low if not checked.
procedure TfrmCamcQI.chkInpLevelClick(Sender: TObject);
var
    dwLevel : DWORD;
begin
    if (m_bA4NAxis = true) then begin
        AxmSignalSetInpos(m_lAxis, DWord(chkInpLevel.State))
    end
    else begin
        if (chkInpLevel.Checked = false ) then dwLevel := 2
        else                                    dwLevel := 1;
        AxmSignalSetInpos(m_lAxis, DWord(chkInpLevel.State))
    end;
end;

// Setup active level value of alarm signal.  High if checked, Low if not checked.
procedure TfrmCamcQI.chkAlarmLevelClick(Sender: TObject);
var
    dwLevel : DWORD;
begin
    if (m_bA4NAxis = true) then begin
        AxmSignalSetServoAlarm(m_lAxis, DWORD(chkAlarmLevel.State))
    end
    else begin
        if (chkAlarmLevel.Checked = false ) then dwLevel := 2
        else                                    dwLevel := 1;
        AxmSignalSetServoAlarm(m_lAxis, DWORD(chkAlarmLevel.State))
    end;
end;

// Setup active level value of Emg Signal.
procedure TfrmCamcQI.chkEmgLevelClick(Sender: TObject);
var
    dwLevel : DWORD;
begin
    if (m_bA4NAxis = true) then begin
        AxmSignalSetStop(m_lAxis, EMERGENCY_STOP, DWORD(chkEmgLevel.State))
    end
    else begin
        if (chkEmgLevel.Checked = false ) then dwLevel := 2
        else                                    dwLevel := 1;
        AxmSignalSetStop(m_lAxis, EMERGENCY_STOP, DWORD(chkEmgLevel.State))
    end;
end;

procedure TfrmCamcQI.chkZPhaseLevelClick(Sender: TObject);
begin
    if (m_bA4NAxis = true) then
        AxmSignalSetZphaseLevel(m_lAxis, DWORD(chkZPhaseLevel.Checked));
end;

procedure TfrmCamcQI.btnMPGOnClick(Sender: TObject);
var
    dVelocity, dAccel : Double;
    dMPGPosition    : double;
    dMPGdenominator : LongInt;
    dMPGnumerator	  : LongInt;

    lInputMethod : LongInt;
    lDriveMode   : LongInt;
//    lDirMode     : LongInt;
//    lUserDir     : LongInt;
begin
    dVelocity   := StrToFloat(edtVelocity.Text);
    dAccel      := StrToFloat(edtAccel.Text);

    lInputMethod := 3;
    lDriveMode   := 0;

    dMPGPosition := 1000;
    dMPGdenominator := 4096; // MPG(Manual Pulse Generation device Input) divide value when running (Calculated to add 1 to input value)
    dMPGnumerator := 1;      // MPG(Manual Pulse Generation device Input) multiply value when running (Calculated to add 1 to input value)

    // dwNumerator   : Possible to setup maximum (0 to 63)
    // dwDenominator : Possible to setup maximum (0 to 4095) 
    AxmMPGSetEnable(m_lAxis, lInputMethod, lDriveMode, dMPGPosition, dVelocity, dAccel);
	AxmMPGSetRatio(m_lAxis, dMPGnumerator, dMPGdenominator);
end;

procedure TfrmCamcQI.btnMPGOffClick(Sender: TObject);
begin
    AxmMPGReset(m_lAxis);
end;

procedure TfrmCamcQI.btnCRCOnClick(Sender: TObject);
begin
    // Level   : LOW(0), HIGH(1), UNUSED(2), USED(3)
	// uMethod : Remove remaining pulse, possible to setup output signal pulse range of 0 - 6
	// 0: Don't care , 1: Don't care, 2: 500 uSec, 3: 1 mSec, 4: 10 mSec, 5: 50 mSec, 6: 100 mSec
    AxmCrcSetMaskLevel(m_lAxis, HIGH, 6);
end;

procedure TfrmCamcQI.btnCRCOffClick(Sender: TObject);
begin
    AxmCrcSetMaskLevel(m_lAxis, UNUSED, 6);
end;

procedure TfrmCamcQI.btnCountClrClick(Sender: TObject);
begin
	AxmStatusSetActPos(AXIS_N04(m_lAxis, 0), 0.0);
	AxmStatusSetActPos(AXIS_N04(m_lAxis, 1), 0.0);
	AxmStatusSetCmdPos(AXIS_N04(m_lAxis, 2), 0.0);
	AxmStatusSetCmdPos(AXIS_N04(m_lAxis, 3), 0.0);

	AxmStatusSetCmdPos(AXIS_N04(m_lAxis, 0), 0.0);
	AxmStatusSetCmdPos(AXIS_N04(m_lAxis, 1), 0.0);
	AxmStatusSetActPos(AXIS_N04(m_lAxis, 2), 0.0);
	AxmStatusSetActPos(AXIS_N04(m_lAxis, 3), 0.0);

    Series5.Clear;
    lstLog.Clear;
end;

procedure TfrmCamcQI.btnMoveClick(Sender: TObject);
var
    dPosition, dVelocity, dAccel, dDecel : Double;
    lAxis : array [0..1] of Longint;
    dMPos : array [0..1] of Double;
    dMVel : array [0..1] of Double;
    dMAcc    : array [0..1] of Double;
    dMDec    : array [0..1] of Double;
begin
    dPosition	:= StrToFloat(edtPosition.Text);
	dVelocity	:= StrToFloat(edtVelocity.Text);
	dAccel		:= StrToFloat(edtAccel.Text);
	dDecel		:= StrToFloat(edtDecel.Text);

    SetGraphRange(m_lAxis, dVelocity);
	if (chkXYSyn.Checked = True) then
    begin
	    lAxis[0] := AXIS_ODD(m_lAxis);
		lAxis[1] := AXIS_EVN(m_lAxis);

		dMPos[0] := dPosition; dMPos[1] := dPosition;
		dMVel[0] := dVelocity; dMVel[1] := dVelocity;
        dMAcc[0] := dAccel;    dMAcc[1] := dAccel;
		dMDec[0] := dDecel;    dMDec[1] := dDecel;

		AxmMoveStartMultiPos(2, @lAxis, @dMPos, @dMVel, @dMAcc, @dMDec);
    end
	else
		AxmMoveStartPos(m_lAxis, dPosition, dVelocity, dAccel, dDecel);

	AxmMotSetParaLoad(m_lAxis, dPosition, dVelocity, dAccel, dDecel);
end;

// It is for the test of Home searching, about setup signal to be searched and searching direction and stop method after searching 
// Start searching after read.  Print out the result on list box after finishing search.
procedure TfrmCamcQI.btnSearchClick(Sender: TObject);
var
    ThreadID : DWord;
    SI_M     : PSIGNAL_SEARCH;
begin
    if(m_hTestThread[AXIS_QUR(m_lAxis)] = 0) Then
    begin
        New(SI_M);
	    SI_M^.nAxis		:= m_lAxis;
	    SI_M^.nDir		:= cboDirection.ItemIndex;
	    SI_M^.nSignal	:= cboDetect.ItemIndex;
	    SI_M^.nStopM	:= cboStopM.ItemIndex;
	    SI_M^.dVelocity	:= StrToFloat(edtVelocity.text);
	    SI_M^.dAccel	:= StrToFloat(edtAccel.text);

        m_bTestActive[AXIS_QUR(m_lAxis)] := TRUE;
	    m_hTestThread[AXIS_QUR(m_lAxis)] := CreateThread(nil, 0, @SearchThread, Pointer(SI_M), 0, ThreadID);
    end
    else
    begin
        lstLog.Items.Add('Now moving.');
        lstLog.TopIndex := lstLog.Count - 1;
    end;
end;

// Repeated running after reading running parameter from edit box.
// Create thread for repeated running.
procedure TfrmCamcQI.btnRepeatClick(Sender: TObject);
var
    ThreadID : DWord;
    RM_M     : PREPEAT_MOVE;
begin
    if(m_hTestThread[m_lAxis] = 0) Then
    begin
        New(RM_M);
    	  RM_M^.nAxis := m_lAxis;
        RM_M^.dPosition := StrToFloat(edtPosition.text);
        RM_M^.dVelocity := StrToFloat(edtVelocity.text);
        RM_M^.dAccel := StrToFloat(edtAccel.text);
        RM_M^.dDecel := StrToFloat( edtDecel.Text);

		m_bTestActive[m_lAxis] := TRUE;
		m_hTestThread[m_lAxis] := CreateThread(nil, 0, @RepeatThread, Pointer(RM_M), 0, ThreadID);
    end
    else
    begin
        lstLog.Items.Add('Now moving.');
        lstLog.TopIndex := lstLog.Count - 1;
    end;
end;

procedure TfrmCamcQI.btnStopClick(Sender: TObject);
begin
    if(m_bTestActive[AXIS_QUR(m_lAxis)])then
    begin
        m_bTestActive[AXIS_QUR(m_lAxis)] := FALSE;
        AxmMoveSStop(m_lAxis);
    end
	else
        AxmMoveSStop(m_lAxis);

    lstLog.Items.Add('Stop move.');
	lstLog.TopIndex := lstLog.Count - 1;
end;

procedure TfrmCamcQI.btnEStopClick(Sender: TObject);
var
    i : LongInt;
begin
    m_bTestActive[AXIS_QUR(0)] := FALSE;
	m_bTestActive[AXIS_QUR(1)] := FALSE;
	m_bTestActive[AXIS_QUR(2)] := FALSE;
	m_bTestActive[AXIS_QUR(3)] := FALSE;

	for i := 0 to m_lAxisCounts-1 do
        AxmMoveEStop(i);

    lstLog.Items.Add('All axis emergency stopped.');
	lstLog.TopIndex := lstLog.Count - 1;
end;

// To absolute coordinate if it was checked when click the check box of absolute coordinate.
procedure TfrmCamcQI.chkAbsoluteClick(Sender: TObject);
begin
    if (chkAbsolute.Checked = TRUE)then
    begin
	    chkRelative.Checked := FALSE;
		AxmMotSetAbsRelMode(m_lAxis, POS_ABS_MODE);
    end
    else
    begin
		chkRelative.Checked := TRUE;
		AxmMotSetAbsRelMode(m_lAxis, POS_REL_MODE);
    end;
end;

// To opposite coordinate if it was checked when click the check box of opposite coordinate.
procedure TfrmCamcQI.chkRelativeClick(Sender: TObject);
begin
    if (chkRelative.Checked = TRUE)then
    begin
	    chkAbsolute.Checked := FALSE;
		AxmMotSetAbsRelMode(m_lAxis, POS_REL_MODE);
    end
	else
    begin
		chkAbsolute.Checked := TRUE ;
		AxmMotSetAbsRelMode(m_lAxis, POS_ABS_MODE);
    end;
end;

procedure TfrmCamcQI.chkSCurveClick(Sender: TObject);
var
    dwProfile : DWORD;
begin
	//ProfileMode: '0' - symmetry Trapezode
	//             '1' - asymmetry Trapezode
	//             '2' - symmetry Quasi-S Curve
	//             '3' - symmetry S Curve
	//             '4' - asymmetry S Curve
	AxmMotGetProfileMode(m_lAxis, @dwProfile);
	if(chkSCurve.Checked = TRUE)then
    begin
	    if((dwProfile = 0) or (dwProfile = 1))then  dwProfile := dwProfile + 3
		else                                        dwProfile  := 3;
    end
	else
    begin
		if((dwProfile = 3) or (dwProfile = 4))then  dwProfile := dwProfile - 3
        else                                        dwProfile  := 0;
    end;
	AxmMotSetProfileMode(m_lAxis, dwProfile);
end;

// Make edit window to be active for setting a value of reduced speed when asymmetric running mode.
procedure TfrmCamcQI.chkAsymClick(Sender: TObject);
var
    dwProfile : DWORD;
begin
	//ProfileMode: '0' - symmetry Trapezode
	//             '1' - asymmetry Trapezode
	//             '2' - symmetry Quasi-S Curve
	//             '3' - symmetry S Curve
	//             '4' - asymmetry S Curve
	AxmMotGetProfileMode(m_lAxis, @dwProfile);
	if(chkAsym.Checked = TRUE)then
    begin
	    edtDecel.Enabled := TRUE;
		if((dwProfile = 0) or (dwProfile = 3))then  dwProfile := dwProfile + 1
        else                                        dwProfile  := 4;
    end
	else
    begin
	    edtDecel.Enabled := FALSE;
		if((dwProfile = 1) or (dwProfile = 4))then  dwProfile := dwProfile - 1
		else                                        dwProfile  := 3;
    end;

	AxmMotSetProfileMode(m_lAxis, dwProfile);
end;

procedure TfrmCamcQI.chkXYSynClick(Sender: TObject);
begin
    if( chkXYSyn.Checked = True) then   edtDecel.Enabled := True
    else                                edtDecel.Enabled := False;
end;

// Straight line interpolation running
procedure TfrmCamcQI.btnLinearClick(Sender: TObject);
var
	lAxis       : array[0..1] of Longint;
	dPos        : array[0..1] of double;
	uErrorCode  : DWord;
	dPosition, dVelocity, dAccel, dDecel : double;
//    dwProfile   : DWord;
begin
  	dVelocity	  := StrToFloat(edtVelocity.Text);
	dAccel		  := StrToFloat(edtAccel.Text);
	dDecel		  := StrToFloat(edtDecel.Text);

	dPos[0]		  := StrToFloat(edtXEndCen.Text);
	dPos[1]		  := StrToFloat(edtYEndCen.Text);

    lAxis[0]	  := AXIS_EVN(m_lAxis);
	lAxis[1]	  := AXIS_ODD(m_lAxis);

	SetGraphRange(lAxis[0], dVelocity);

	AxmContiWriteClear(COORD_NO);
	AxmContiSetAxisMap(COORD_NO, 2, @lAxis);

    SetCoordMovePara();
	uErrorCode := AxmLineMove(COORD_NO, @dPos, dVelocity, dAccel, dDecel);

    lstLog.Items.Add('Linear Error Code: ' + IntToStr(uErrorCode));
	if(uErrorCode <> AXT_RT_SUCCESS)then	frmCamcQI.lstLog.Items.Add(IntToStr(uErrorCode));

	AxmMotGetParaLoad(m_lAxis, @dPosition, NIL, NIL, NIL);
	AxmMotSetParaLoad(m_lAxis, dPosition, dVelocity, dAccel, dDecel);
end;

procedure TfrmCamcQI.SetCoordMovePara();
begin
	if (chkAbsolute.Checked ) Then	AxmContiSetAbsRelMode(COORD_NO, POS_ABS_MODE)
	else					 	    AxmContiSetAbsRelMode(COORD_NO, POS_REL_MODE);
end;

procedure TfrmCamcQI.btnCirCularClick(Sender: TObject);
var
    lAxis       : array [0..1] of Longint;
    dCenPos     : array [0..1] of Double;
    uErrorCode  : DWORD;
    dPosition, dVelocity, dAccel, dDecel, dAngle : Double;
//    dwProfile   : DWord;
begin

	dVelocity	:= StrToFloat(edtVelocity.Text);
	dAccel		:= StrToFloat(edtAccel.Text);
	dDecel		:= StrToFloat(edtDecel.Text);
	dAngle		:= StrToFloat(edtAngle.Text);

	dCenPos[0]  := StrToFloat(edtXEndCen.Text);
	dCenPos[1]	:= StrToFloat(edtYEndCen.Text);

    lAxis[0]    := AXIS_EVN(m_lAxis);
    lAxis[1]    := AXIS_ODD(m_lAxis);

	SetGraphRange(lAxis[0],dVelocity);
	AxmContiWriteClear(COORD_NO);
	AxmContiSetAxisMap(COORD_NO, 2, @lAxis);

    SetCoordMovePara();
    if(chkCwCcw.Checked = TRUE)then	uErrorCode := AxmCircleAngleMove(COORD_NO, @lAxis, @dCenPos, dAngle, dVelocity, dAccel, dDecel, 0)
	else					        uErrorCode := AxmCircleAngleMove(COORD_NO, @lAxis, @dCenPos, dAngle, dVelocity, dAccel, dDecel, 1);

	if(uErrorCode <> AXT_RT_SUCCESS)then
        lstLog.Items.Add('Circular Error Code: ' + IntToStr(uErrorCode));

	AxmMotGetParaLoad(m_lAxis, @dPosition, NIL, NIL, NIL);
	AxmMotSetParaLoad(m_lAxis, dPosition, dVelocity, dAccel, dDecel);
end;

procedure keMotionInterruptCallback(lActiveNo : LongInt; dwFlag : DWord); stdcall;
var
    strData: String;
    IntBank0, IntBank1: DWord;
begin
    g_nIntCnt := g_nIntCnt + 1;
	AxmInterruptReadAxisFlag(lActiveNo, 0, @IntBank0);
	AxmInterruptReadAxisFlag(lActiveNo, 1, @IntBank1);

    strData := 'Cal[' + Format('%d', [g_nIntCnt]) + ']Axis[' +  Format('%d', [lActiveNo]) + ']Flag[0x' + Format('%X', [dwFlag]) + ']';
	frmCamcQI.lstLog.Items.Add(strData);
end;

procedure TfrmCamcQI.btnVelOverrideClick(Sender: TObject);
var
    dPosition : double;
    dVelocity : double;
    dAccel : double;
    dDecel : double;
begin
    dPosition	:= StrToFloat(edtPosition.Text);
	dVelocity	:= StrToFloat(edtVelocity.Text);
	dAccel		:= StrToFloat(edtAccel.Text);
	dDecel		:= StrToFloat(edtDecel.Text);

	SetGraphRange(m_lAxis,dVelocity*2);
	AxmOverrideVelAtPos(m_lAxis, dPosition, dVelocity, dAccel, dDecel, dPosition/4,dVelocity*2, COMMAND);
end;
 
procedure TfrmCamcQI.btnContiStartClick(Sender: TObject);
begin
    AxmContiStart(COORD_NO, 0, 0);
end;

procedure TfrmCamcQI.btnContiClearClick(Sender: TObject);
begin
    AxmContiWriteClear(COORD_NO);
end;

procedure TfrmCamcQI.btnContiTestClick(Sender: TObject);
var
    dVelocity, dAccel : Double;

    lAxis : array [0..1] of LongInt;
    dPos : array [0..1] of Double;
    dCenPos : array [0..1] of Double;
    dEndPos : array [0..1] of Double;
    lPosSize : LongInt;

begin
    lPosSize  := 2;
    lAxis[0]  := 0;
	lAxis[1]  := 1;
    dVelocity := StrToFloat( edtVelocity.Text);
    dAccel    := StrToFloat( edtAccel.Text);
    SetGraphRange(lAxis[0],dVelocity);

	AxmContiWriteClear(COORD_NO);
	AxmContiSetAxisMap(COORD_NO, lPosSize, @lAxis);
	AxmContiSetAbsRelMode(COORD_NO, POS_REL_MODE);

    AxmContiBeginNode(COORD_NO); dPos[0] := -15000; dPos[1] := 0;

	AxmLineMove(COORD_NO, @dPos, dVelocity, dAccel, dAccel);                  //1
  	dCenPos[0] := 0; dCenPos[1] := 5000; dEndPos[0] := -5000; dEndPos[1] := 5000;
 	AxmCircleCenterMove(COORD_NO, @lAxis, @dCenPos, @dEndPos, dVelocity, dAccel, dAccel, DIR_CW);  //2
	dPos[0] := 0; dPos[1] := 30000;
	AxmLineMove(COORD_NO, @dPos, dVelocity, dAccel, dAccel);  //3

	dCenPos[0] := 5000; dCenPos[1] := 0; dEndPos[0] := 5000; dEndPos[1] := 5000;
	AxmCircleCenterMove(COORD_NO, @lAxis, @dCenPos, @dEndPos, dVelocity, dAccel, dAccel, DIR_CW);   //4
	dPos[0] := 30000; dPos[1] := 0;
	AxmLineMove(COORD_NO, @dPos, dVelocity, dAccel, dAccel);				   //5
	dCenPos[0] := 0; dCenPos[1] := -5000; dEndPos[0] := 5000; dEndPos[1] := -5000;
	AxmCircleCenterMove(COORD_NO, @lAxis, @dCenPos, @dEndPos,  dVelocity, dAccel, dAccel, DIR_CW);//6
	dPos[0] := 0; dPos[1] := -30000;
	AxmLineMove(COORD_NO, @dPos, dVelocity, dAccel, dAccel);                  //7
	dCenPos[0] := -5000; dCenPos[1] := 0; dEndPos[0] := -5000; dEndPos[1] := -5000;
	AxmCircleCenterMove(COORD_NO, @lAxis, @dCenPos, @dEndPos, dVelocity, dAccel, dAccel, DIR_CW);//8
	dPos[0] := -15000; dPos[1] := 0;

    AxmLineMove(COORD_NO, @dPos, dVelocity, dAccel, dAccel);				   //9
	dPos[0] := -10000; dPos[1] := 0;

	AxmLineMove(COORD_NO, @dPos, dVelocity, dAccel, dAccel);                  //10
	dCenPos[0] := 0; dCenPos[1] := 10000; dEndPos[0] := -10000; dEndPos[1] := 10000;
	AxmCircleCenterMove(COORD_NO, @lAxis, @dCenPos, @dEndPos, dVelocity, dAccel, dAccel, DIR_CW);//11
	dPos[0] := 0; dPos[1] := 20000;
	AxmLineMove(COORD_NO, @dPos, dVelocity, dAccel, dAccel);                    //12
	dCenPos[0] := 10000; dCenPos[1] := 0; dEndPos[0] := 10000; dEndPos[1] := 10000;
	AxmCircleCenterMove(COORD_NO, @lAxis, @dCenPos, @dEndPos, dVelocity, dAccel, dAccel, DIR_CW); //13
	dPos[0] := 20000; dPos[1] := 0;
	AxmLineMove(COORD_NO, @dPos, dVelocity, dAccel, dAccel);                    //14
	dCenPos[0] := 0; dCenPos[1] := -10000; dEndPos[0] := 10000; dEndPos[1] := -10000;
	AxmCircleCenterMove(COORD_NO, @lAxis, @dCenPos, @dEndPos, dVelocity, dAccel, dAccel, DIR_CW);//15
	dPos[0] := 0; dPos[1] := -20000;
	AxmLineMove(COORD_NO, @dPos, dVelocity, dAccel, dAccel);                    //16
	dCenPos[0] := -10000; dCenPos[1] := 0; dEndPos[0] := -10000; dEndPos[1] := -10000;
	AxmCircleCenterMove(COORD_NO, @lAxis, @dCenPos, @dEndPos, dVelocity, dAccel, dAccel, DIR_CW);//17
	dPos[0] := -10000; dPos[1] := 0;
	AxmLineMove(COORD_NO, @dPos, dVelocity, dAccel, dAccel);                      //18
	dCenPos[0] := 0; dCenPos[1] := 20000; dEndPos[0] := 0; dEndPos[1] := 0;
	AxmCircleCenterMove(COORD_NO, @lAxis, @dCenPos, @dEndPos, dVelocity, dAccel, dAccel, DIR_CW);            //19
	dCenPos[0] := 0; dCenPos[1] := 10000; dEndPos[0] := -7071; dEndPos[1] := 2929;
	AxmCircleCenterMove(COORD_NO, @lAxis,  @dCenPos, @dEndPos, dVelocity, dAccel, dAccel, DIR_CW);    //20

	dPos[0] := -10000; dPos[1] := 10000;
	AxmLineMove(COORD_NO, @dPos, dVelocity, dAccel, dAccel);                  //21
	dCenPos[0] := 7071; dCenPos[1] := 7071; dEndPos[0] := 0; dEndPos[1] := 14142;
	AxmCircleCenterMove(COORD_NO, @lAxis,  @dCenPos, @dEndPos, dVelocity, dAccel, dAccel, DIR_CW);    //22
	dPos[0] := 10000; dPos[1] := 10000;
	AxmLineMove(COORD_NO, @dPos, dVelocity, dAccel, dAccel);                   //23
	dCenPos[0] := 7071; dCenPos[1] := -7071; dEndPos[0] := 14142; dEndPos[1] := 0;
	AxmCircleCenterMove(COORD_NO, @lAxis,  @dCenPos, @dEndPos, dVelocity, dAccel, dAccel, DIR_CW);   //24
	dPos[0] := 10000; dPos[1] := -10000;
	AxmLineMove(COORD_NO, @dPos, dVelocity, dAccel, dAccel);                  //25
	dCenPos[0] := -7071; dCenPos[1] := -7071; dEndPos[0] := 0; dEndPos[1] := -14142;
	AxmCircleCenterMove(COORD_NO, @lAxis,  @dCenPos, @dEndPos, dVelocity, dAccel, dAccel, DIR_CW); //26
	dPos[0] := -10000; dPos[1] := -10000;
	AxmLineMove(COORD_NO, @dPos, dVelocity, dAccel, dAccel);     //27
	dCenPos[0] := -7071; dCenPos[1] := 7071; dEndPos[0] := -7071; dEndPos[1] := -2929;

	AxmCircleCenterMove(COORD_NO, @lAxis,  @dCenPos, @dEndPos, dVelocity, dAccel, dAccel, DIR_CW);//28
	dCenPos[0] := 0; dCenPos[1] := 10000; dEndPos[0] := 0; dEndPos[1] := 20000;
	AxmCircleCenterMove(COORD_NO, @lAxis,  @dCenPos, @dEndPos, dVelocity, dAccel, dAccel, DIR_CW);      //29
	dCenPos[0] := 0; dCenPos[1] := 10000; dEndPos[0] := 0; dEndPos[1] := 20000;
	AxmCircleCenterMove(COORD_NO, @lAxis,  @dCenPos, @dEndPos, dVelocity, dAccel, dAccel, DIR_CCW);      //30
	dCenPos[0] := 0; dCenPos[1] := -5000; dEndPos[0] := 0; dEndPos[1] := -10000;
	AxmCircleCenterMove(COORD_NO, @lAxis,  @dCenPos, @dEndPos, dVelocity, dAccel, dAccel, DIR_CCW);     //31

	dCenPos[0] := 0; dCenPos[1] := -5000; dEndPos[0] := 0; dEndPos[1] := -10000;
	AxmCircleCenterMove(COORD_NO, @lAxis,  @dCenPos, @dEndPos, dVelocity, dAccel, dAccel, DIR_CW);     //32
	dCenPos[0] := 0; dCenPos[1] := -5000; dEndPos[0] := 0; dEndPos[1] := -10000;
	AxmCircleCenterMove(COORD_NO, @lAxis,  @dCenPos, @dEndPos, dVelocity, dAccel, dAccel, DIR_CCW);     //33
	dCenPos[0] := 0; dCenPos[1] := -5000; dEndPos[0] := 0; dEndPos[1] := -10000;
	AxmCircleCenterMove(COORD_NO, @lAxis,  @dCenPos, @dEndPos, dVelocity, dAccel, dAccel, DIR_CW);     //34

	AxmContiEndNode(COORD_NO);
end;

procedure TfrmCamcQI.btnTrigOneShotClick(Sender: TObject);
var
    pulse_width : Integer;
begin
    pulse_width := StrToInt(edtTrigPulseWidth.Text);
    // It is the function that user outputting one trigger pulse by force.
  	AxmTriggerSetTimeLevel(m_lAxis, pulse_width, HIGH, COMMAND, ENABLE);
	AxmTriggerOneShot(m_lAxis);
end;

procedure TfrmCamcQI.btnTrigAbsClick(Sender: TObject);
var
    uErrorCode  : DWord;
    trig_pos    : array [0..1] of Double;
	pulse_width	: Integer;
begin
    pulse_width   := StrToInt(edtTrigPulseWidth.Text);
    trig_pos[0]  := StrToFloat(edtTrigStartPosition.Text);

    AxmTriggerSetReset(m_lAxis);
	AxmTriggerSetTimeLevel(m_lAxis, pulse_width, HIGH, COMMAND, ENABLE);

    uErrorCode := AxmTriggerOnlyAbs(m_lAxis, 1, @trig_pos);
    if(uErrorCode = AXT_RT_SUCCESS) then lstLog.Items.Add( 'Trigger absolute position set')
    else                                 lstLog.Items.Add( 'Trigger absolute position not set')
end;

procedure TfrmCamcQI.btnTrigPeriodClick(Sender: TObject);
var
    uErrorCode  : DWord;
    start_pos   : double;
    cycle       : double;
    end_pos     : double;
    pulse_width : Integer;
begin
    start_pos   := StrToFloat(edtTrigStartPosition.Text);
    pulse_width := StrToInt(edtTrigPulseWidth.Text);
    cycle       := StrToFloat(edtTrigCycle.Text);
    end_pos     := StrToFloat(edtTrigEndPos.Text);

	AxmTriggerSetReset(m_lAxis);
	AxmTriggerSetTimeLevel(m_lAxis, pulse_width, HIGH, COMMAND, ENABLE);

	uErrorCode    := AxmTriggerSetBlock(m_lAxis, start_pos, end_pos, cycle);
    if(uErrorCode = AXT_RT_SUCCESS)then frmCamcQI.lstLog.Items.Add( 'Trigger cycle position set')
    else                                frmCamcQI.lstLog.Items.Add( 'Trigger cycle position not set')
end;

procedure TfrmCamcQI.btnTrigResetClick(Sender: TObject);
begin
    AxmTriggerSetReset(m_lAxis);
end;

procedure TfrmCamcQI.btnHomeAllClick(Sender: TObject);
var
    lHmDir : LongInt;     // Setup a direction of Home searching.
    lHmsig  : LongInt;    // Setup Home sensor.
    dwZphas	: DWord;      // Setup whether Z phase is searching or not.
	dHClrTim : Double;   // Delay time of Position Clear after searching Home sensor.
	dHOffset : Double;    // Setup Offset movement value after searching Home sensor.
    dwResult : DWORD;
begin
	lHmsig      := cboHomeSignal.ItemIndex;
    lHmDir      := cboHomeDir.ItemIndex;
    dwZphas     := 0;
  	dHClrTim    := 1000.0;
    dHOffset    := 0.0;

    if lHmsig > 1 then
    begin
      lHmsig := lHmsig + 2;
    end;

    SetGraphRange(AXIS_N04(m_lAxis, 0), 100);
    SetGraphRange(AXIS_N04(m_lAxis, 2), 100);

	dwResult := AxmHomeSetVel(AXIS_N04(m_lAxis, 0), 100, 50, 5, 1, 400, 100);
    if (dwResult = AXT_RT_SUCCESS) then
    begin
        AxmHomeSetMethod(AXIS_N04(m_lAxis, 0), lHmDir, lHmsig, dwZphas, dHClrTim, dHOffset);
        AxmHomeSetStart(AXIS_N04(m_lAxis, 0));
        tmHome1.Enabled :=  TRUE;
    end;

	dwResult :=	AxmHomeSetVel(AXIS_N04(m_lAxis, 1), 100, 50, 5, 1, 400, 100);
    if (dwResult = AXT_RT_SUCCESS) then
    begin
        AxmHomeSetMethod(AXIS_N04(m_lAxis, 1), lHmDir, lHmsig, dwZphas, dHClrTim, dHOffset);
        AxmHomeSetStart(AXIS_N04(m_lAxis, 1));
        tmHome2.Enabled :=  TRUE;
    end;

	dwResult :=	AxmHomeSetVel(AXIS_N04(m_lAxis, 2), 100, 50, 5, 1, 400, 100);
    if (dwResult = AXT_RT_SUCCESS) then
    begin
        AxmHomeSetMethod(AXIS_N04(m_lAxis, 2), lHmDir, lHmsig, dwZphas, dHClrTim, dHOffset);
        AxmHomeSetStart(AXIS_N04(m_lAxis, 2));
        tmHome3.Enabled :=  TRUE;
    end;

	dwResult :=	AxmHomeSetVel(AXIS_N04(m_lAxis, 3), 100, 50, 5, 1, 400, 100);
    if (dwResult = AXT_RT_SUCCESS) then
    begin
        AxmHomeSetMethod(AXIS_N04(m_lAxis, 3), lHmDir, lHmsig, dwZphas, dHClrTim, dHOffset);
        AxmHomeSetStart(AXIS_N04(m_lAxis, 3));
        tmHome4.Enabled :=  TRUE;
    end;
end;

procedure TfrmCamcQI.btnHomeSingleClick(Sender: TObject);
var
    dwZphas     : DWord;
	dHClrTim	: Double;
	dHOffset	: Double;

	dVelFirst	: Double;
	dVelSecond  : Double;
	dVelThird	: Double;
	dVelLast	: Double;
	lHmsig		: LongInt;
    lHmDir		: LongInt;

    tmHomer :   array[0..3] of TTimer;
begin
    dwZphas     := 0;               // Setup whether Z phase is searching or not.
    dHClrTim   := 1000.0;           // Delay time of Position Clear after searching Home sensor.
    dHOffset   := 0.0;              // Setup Offset movement value after searching Home sensor.

    dVelFirst   := StrToFloat(edtHomeVelFirst.Text);
    dVelSecond  := StrToFloat(edtHomeVelSecond.Text);
    dVelThird   := StrToFloat(edtHomeVelThird.Text);
    dVelLast    := StrToFloat(edtHomeVelLast.Text);
    lHmsig      := cboHomeSignal.ItemIndex;             // Setup Home sensor.
    lHmDir      := cboHomeDir.ItemIndex;                // Setup a direction of Home searching.

    tmHomer[0] := tmHome1;    tmHomer[1] := tmHome2;
    tmHomer[2] := tmHome3;    tmHomer[3] := tmHome4;

    if lHmsig > 1 then
    begin
      lHmsig := lHmsig + 2;
    end;

    SetGraphRange(m_lAxis, dVelFirst);

    if(chkGantrySlave.Checked = True)then
    begin
	    AxmHomeSetVel(AXIS_EVN(m_lAxis), dVelFirst, dVelSecond, dVelThird, dVelLast, dVelFirst * 4, dVelSecond * 10);
		AxmHomeSetVel(AXIS_ODD(m_lAxis), dVelFirst, dVelSecond, dVelThird, dVelLast, dVelFirst * 4, dVelSecond * 10);

		AxmHomeSetMethod(AXIS_EVN(m_lAxis), lHmDir, lHmsig, dwZphas, dHClrTim, dHOffset);
		AxmHomeSetMethod(AXIS_ODD(m_lAxis), lHmDir, lHmsig, dwZphas, dHClrTim, dHOffset);

		AxmHomeSetStart(AXIS_EVN(m_lAxis));
        tmHomer[AXIS_EVN(m_lAxis)].Enabled := true;
    end
	else
    begin
	    AxmHomeSetVel(m_lAxis, dVelFirst, dVelSecond, dVelThird, dVelLast, dVelFirst * 4, dVelSecond * 10);

		AxmHomeSetMethod(m_lAxis, lHmDir, lHmsig, dwZphas, dHClrTim, dHOffset);
		AxmHomeSetStart(m_lAxis);
        tmHomer[AXIS_QUR(m_lAxis)].Enabled := true;
    end;
end;

// Setup general output #0(Servo-On).  Output will go out if checked, Output will not go out if not checked.
procedure TfrmCamcQI.LedOut0Click(Sender: TObject);
var
    dwOutBit : DWORD;
begin
    AxmSignalReadOutputBit(m_lAxis, 0, @dwOutBit);
    if ( dwOutBit = $01 ) then
        AxmSignalWriteOutputBit(m_lAxis, 0, 0)
    else
        AxmSignalWriteOutputBit(m_lAxis, 0, 1);

end;

// Setup general output #1(Alarm-Clear).
procedure TfrmCamcQI.LedOut1Click(Sender: TObject);
var
    dwOutBit : DWORD;
begin
    AxmSignalReadOutputBit(m_lAxis, 1, @dwOutBit);
    if ( dwOutBit = $01 ) then
        AxmSignalWriteOutputBit(m_lAxis, 1, 0)
    else
        AxmSignalWriteOutputBit(m_lAxis, 1, 1);

end;

// Setup general output #2.
procedure TfrmCamcQI.LedOut2Click(Sender: TObject);
var
    dwOutBit : DWORD;
begin
    AxmSignalReadOutputBit(m_lAxis, 2, @dwOutBit);
    if ( dwOutBit = $01 ) then
        AxmSignalWriteOutputBit(m_lAxis, 2, 0)
    else
        AxmSignalWriteOutputBit(m_lAxis, 2, 1);

end;

// Setup general output #3.
procedure TfrmCamcQI.LedOut3Click(Sender: TObject);
var
    dwOutBit : DWORD;
begin
    AxmSignalReadOutputBit(m_lAxis, 3, @dwOutBit);
    if ( dwOutBit = $01 ) then
        AxmSignalWriteOutputBit(m_lAxis, 3, 0)
    else
        AxmSignalWriteOutputBit(m_lAxis, 3, 1);
end;

// Setup general output #4.
procedure TfrmCamcQI.LedOut4Click(Sender: TObject);
var
    dwOutBit : DWORD;
begin
    AxmSignalReadOutputBit(m_lAxis, 4, @dwOutBit);
    if ( dwOutBit = $01 ) then
        AxmSignalWriteOutputBit(m_lAxis, 4, 0)
    else
        AxmSignalWriteOutputBit(m_lAxis, 4, 1);
end;

// Setup general output #5.
procedure TfrmCamcQI.LedOut5Click(Sender: TObject);
var
    dwOutBit : DWORD;
begin
    AxmSignalReadOutputBit(m_lAxis, 5, @dwOutBit);
    if ( dwOutBit = $01 ) then
        AxmSignalWriteOutputBit(m_lAxis, 5, 0)
    else
        AxmSignalWriteOutputBit(m_lAxis, 5, 1);
end;

procedure TfrmCamcQI.btnManualSetClick(Sender: TObject);
begin
    frmManualSet.UpdateAxis(m_lAxis);
    frmManualSet.Show();
end;

procedure TfrmCamcQI.btnStatusClick(Sender: TObject);
begin
    frmStatus.UpdateAxis(m_lAxis);
    frmStatus.Show();
end;

procedure TfrmCamcQI.btnJogMouseDown(Sender: TObject; Button: TMouseButton;
    Shift: TShiftState; X, Y: Integer);
var
    lAxisNo : LongInt;
    lAxis   : array[0..1] of LongInt;
    dMVel   : array[0..1] of Double;
    dMAcc   : array[0..1] of Double;
    dMDec   : array[0..1] of Double;
    dVelocity, dAccel, dDecel : Double;
begin
    lAxisNo     := -1;
	dVelocity	:=  StrToFloat(edtVelocity.Text);
	dAccel 		:=  StrToFloat(edtAccel.Text);
	dDecel		:=  StrToFloat(edtDecel.Text);

   	dMAcc[0] := dAccel; dMAcc[1] := dAccel;
	dMDec[0] := dDecel; dMDec[1] := dDecel;

    case ((TButton (Sender)).Tag) of
    0:  begin
        lAxisNo		:= AXIS_N04(m_lAxis, 0);
		lAxis[0]	:= AXIS_N04(m_lAxis, 0);
		lAxis[1]	:= AXIS_N04(m_lAxis, 1);
		dMVel[0]	:= dVelocity;
		dMVel[1]	:= dVelocity;
        end;
    1:  begin
		lAxisNo		:= AXIS_N04(m_lAxis, 0);
		lAxis[0]	:= AXIS_N04(m_lAxis, 0);
		lAxis[1]	:= AXIS_N04(m_lAxis, 1);
		dMVel[0]	:= -dVelocity;
		dMVel[1]	:= -dVelocity;
	    end;
	2:  begin
		lAxisNo		:= AXIS_N04(m_lAxis, 1);
		lAxis[0]	:= AXIS_N04(m_lAxis, 0);
		lAxis[1]	:= AXIS_N04(m_lAxis, 1);
		dMVel[0]	:= dVelocity;
		dMVel[1]	:= dVelocity;
	    end;
	3:  begin
		lAxisNo		:= AXIS_N04(m_lAxis, 1);
		lAxis[0]	:= AXIS_N04(m_lAxis, 0);
		lAxis[1]	:= AXIS_N04(m_lAxis, 1);
		dMVel[0]	:= -dVelocity;
		dMVel[1]	:= -dVelocity;
	    end;
    4:  begin
		lAxisNo		:= AXIS_N04(m_lAxis, 2);
		lAxis[0]	:= AXIS_N04(m_lAxis, 2);
		lAxis[1]	:= AXIS_N04(m_lAxis, 3);
		dMVel[0]	:= dVelocity;
		dMVel[1]	:= dVelocity;
	    end;
    5:  begin
		lAxisNo		:= AXIS_N04(m_lAxis, 2);
		lAxis[0]	:= AXIS_N04(m_lAxis, 2);
		lAxis[1]	:= AXIS_N04(m_lAxis, 3);
		dMVel[0]	:= -dVelocity;
		dMVel[1]	:= -dVelocity;
	    end;

	6:  begin
		lAxisNo		:= AXIS_N04(m_lAxis, 3);
		lAxis[0]	:= AXIS_N04(m_lAxis, 2);
		lAxis[1]	:= AXIS_N04(m_lAxis, 3);
		dMVel[0]	:= dVelocity;
		dMVel[1]	:= dVelocity;
	    end;
    7:  begin
		lAxisNo		:= AXIS_N04(m_lAxis, 3);
		lAxis[0]	:= AXIS_N04(m_lAxis, 2);
		lAxis[1]	:= AXIS_N04(m_lAxis, 3);
		dMVel[0]	:= -dVelocity;
		dMVel[1]	:= -dVelocity;
	    end;
    end;

    // Re-setup of the maximum value in chart for displaying running speed of each axis on the chart.
    if((TButton (Sender)).Tag < 4)then GraphX.LeftAxis.Maximum := dVelocity + (dVelocity * 0.2)
    else                               GraphY.LeftAxis.Maximum := dVelocity + (dVelocity * 0.2);

	if (chkXYSyn.Checked = TRUE)then
    begin
		if(chkAsym.Checked = TRUE)then  AxmMoveStartMultiVel(2, @lAxis, @dMVel, @dMAcc, @dMDec)
		else					        AxmMoveStartMultiVel(2, @lAxis, @dMVel, @dMAcc, @dMAcc);
    end
	else
    begin
		if(chkAsym.Checked = TRUE)then  AxmMoveVel(lAxisNo, dMVel[0], dAccel, dDecel)
		else					        AxmMoveVel(lAxisNo, dMVel[0], dAccel, dAccel);
    end;
end;

procedure TfrmCamcQI.btnJogMouseUp(Sender: TObject; Button: TMouseButton;
    Shift: TShiftState; X, Y: Integer);
var
    lAxisNo : LongInt;
begin
    lAxisNo	:= AXIS_N04(m_lAxis, ((TButton (Sender)).Tag)div 2);
    AxmMoveSStop(lAxisNo);
end;

procedure TfrmCamcQI.chkHomeLevelClick(Sender: TObject);
begin
    if (m_bA4NAxis = true) then
        AxmHomeSetSignalLevel(m_lAxis, DWORD(chkHomeLevel.Checked)) ;
end;

procedure TfrmCamcQI.chkGantryClick(Sender: TObject);
var
    uErrorCode : DWord;
begin
	if(chkGantry.Checked = True)then
    begin
	    uErrorCode := AxmGantrySetEnable(AXIS_EVN(m_lAxis), AXIS_ODD(m_lAxis), DWORD(chkGantrySlave.State), 0.0, 100000.0);
        frmCamcQI.lstLog.Items.Add('Gantry Enable ErrCode ' + IntToStr(uErrorCode));
    end
	else
    begin
		AxmGantrySetDisable(AXIS_EVN(m_lAxis), AXIS_ODD(m_lAxis));
        lstLog.Items.Add('Gantry Disable');
    end;
end;

procedure TfrmCamcQI.btnLoadClick(Sender: TObject);
var
    temp : AnsiString;
begin
    OpenDialog1.Filter := 'Data File (*.mot)|*.mot|All Files (*.*)|*.*';
	if(OpenDialog1.Execute())then
    begin
        temp := OpenDialog1.FileName;
		if (AXT_RT_SUCCESS <> AxmMotLoadParaAll(PChar(temp)))then
        begin
            lstLog.Items.Add('File load fail!');
        end;
        lstLog.TopIndex := frmCamcQI.lstLog.Count - 1;
    end;

	UpdateAxisInfo();
end;

procedure TfrmCamcQI.btnSaveClick(Sender: TObject);
var
//    nLength :   Integer;
    temp, FileType  :   AnsiString;
begin
    frmCamcQI.SaveDialog1.Filter := 'Data File (*.mot)|*.mot|All Files (*.*)|*.*';
	if(frmCamcQI.SaveDialog1.Execute())then
    begin
        frmCamcQI.SaveDialog1.FilterIndex := 1;
        temp := SaveDialog1.FileName;

        if(FileType <> '.mot')then
            temp := temp + '.mot';

		if (AXT_RT_SUCCESS <> AxmMotSaveParaAll(PChar(temp)))then
            frmCamcQI.lstLog.Items.Add('File save fail!');
    end;
end;

procedure TfrmCamcQI.btnContiLineClick(Sender: TObject);
var
    lAxis     : array[0..2] of LongInt;
    dPos      : array[0..2] of Double;
    dVelocity, dAccel, dDecel : Double;
begin
    dVelocity	:= StrToFloat(edtVelocity.Text);
	dAccel		:= StrToFloat(edtAccel.Text);
    dDecel		:= StrToFloat(edtDecel.Text);

    lAxis[0]	:= AXIS_N04(m_lAxis, 0);
	lAxis[1]	:= AXIS_N04(m_lAxis, 1);
	lAxis[2]	:= AXIS_N04(m_lAxis, 2);

    SetGraphRange(lAxis[0],dVelocity);
    SetGraphRange(lAxis[2],dVelocity);

	AxmContiWriteClear(COORD_NO);
	AxmContiSetAxisMap(COORD_NO, 3, @lAxis);
	AxmContiSetAbsRelMode(COORD_NO, POS_ABS_MODE);

	AxmContiBeginNode(COORD_NO);

	dPos[0] := 0;    dPos[1] := 0;    dPos[2] := 0;
    AxmLineMove(COORD_NO, @dPos, dVelocity, dAccel, dDecel);

	dPos[0] := 0;    dPos[1] := 2000; dPos[2] := 0;
	AxmLineMove(COORD_NO, @dPos, dVelocity, dAccel, dDecel);

	dPos[0] := 0;    dPos[1] := 2000; dPos[2] := 2000;
	AxmLineMove(COORD_NO, @dPos, dVelocity, dAccel, dDecel);

	dPos[0] := 2000; dPos[1] := 0;    dPos[2] := 2000;
	AxmLineMove(COORD_NO, @dPos, dVelocity, dAccel, dDecel);

	dPos[0] := 0;    dPos[1] := -2000;dPos[2] := 2000;
  	AxmLineMove(COORD_NO, @dPos, dVelocity, dAccel, dDecel);

  	dPos[0] := -2000;dPos[1] := 0;    dPos[2] := 2000;
	AxmLineMove(COORD_NO, @dPos, dVelocity, dAccel, dDecel);

	dPos[0] := 0;    dPos[1] := 2000; dPos[2] := 2000;
	AxmLineMove(COORD_NO, @dPos, dVelocity, dAccel, dDecel);

	dPos[0] := 0;    dPos[1] := 2000; dPos[2] := 0;
	AxmLineMove(COORD_NO, @dPos, dVelocity, dAccel, dDecel);

	dPos[0] := 0;    dPos[1] := 0;    dPos[2] := 0;
	AxmLineMove(COORD_NO, @dPos, dVelocity, dAccel, dDecel);

    AxmContiEndNode(COORD_NO);
end;

procedure TfrmCamcQI.btnContiCircleClick(Sender: TObject);
var
    lAxis     : array[0..1] of LongInt;
    dCenPos   : array[0..1] of Double;
    dEndPos   : array[0..1] of Double;
    dVelocity, dAccel, dDecel : Double;
begin
    dVelocity	:= StrToFloat(edtVelocity.Text);
	dAccel		:= StrToFloat(edtAccel.Text);
    dDecel		:= StrToFloat(edtDecel.Text);

    lAxis[0]	:= AXIS_N04(m_lAxis, 0);
    lAxis[1]	:= AXIS_N04(m_lAxis, 1);

    SetGraphRange(lAxis[0],dVelocity);

	AxmContiWriteClear(COORD_NO);
	AxmContiSetAxisMap(COORD_NO, 2, @lAxis);
	AxmContiSetAbsRelMode(COORD_NO, POS_ABS_MODE);

	AxmContiBeginNode(COORD_NO);

	dCenPos[0] := 1000;    dCenPos[1] := 1000;    dEndPos[0] := 0;    dEndPos[1] := 0;
	AxmCircleCenterMove(COORD_NO, @lAxis, @dCenPos, @dEndPos, dVelocity, dAccel, dDecel, DIR_CCW);

	dCenPos[0] := -1000;   dCenPos[1] := 1000;    dEndPos[0] := 0;    dEndPos[1] := 0;
	AxmCircleCenterMove(COORD_NO, @lAxis, @dCenPos, @dEndPos, dVelocity, dAccel, dDecel, DIR_CCW);

	dCenPos[0] := -1000;   dCenPos[1] := -1000;   dEndPos[0] := 0;    dEndPos[1] := 0;
	AxmCircleCenterMove(COORD_NO, @lAxis, @dCenPos, @dEndPos, dVelocity, dAccel, dDecel, DIR_CCW);

	dCenPos[0] := 1000;    dCenPos[1] := -1000;   dEndPos[0] := 0;    dEndPos[1] := 0;
	AxmCircleCenterMove(COORD_NO, @lAxis, @dCenPos, @dEndPos, dVelocity, dAccel, dDecel, DIR_CCW);

	AxmContiEndNode(COORD_NO);
end;

procedure TfrmCamcQI.btnContiSplineClick(Sender: TObject);
var
    lAxis : array[0..1] of  LongInt;
    dPosX : array[0..4] of  Double;
	dPosY : array[0..4] of  Double;
    dVelocity, dAccel, dDecel : Double;
begin
    dVelocity	:= StrToFloat(edtVelocity.Text);
	dAccel		:= StrToFloat(edtAccel.Text);
    dDecel		:= StrToFloat(edtDecel.Text);

    lAxis[0]	:= AXIS_N04(m_lAxis, 0);
	lAxis[1]	:= AXIS_N04(m_lAxis, 1);

    SetGraphRange(lAxis[0],dVelocity);

	AxmContiWriteClear(COORD_NO);
	AxmContiSetAxisMap(COORD_NO, 2, @lAxis);
    AxmContiSetAbsRelMode(COORD_NO, POS_ABS_MODE);

	dPosX[0] := 0;      dPosY[0] := 0;
	dPosX[1] := 450;    dPosY[1] := 100;
	dPosX[2] := 750;    dPosY[2] := 450;
	dPosX[3] := 1080;   dPosY[3] := 750;
	dPosX[4] := 1300;   dPosY[4] := 700;
	AxmContiBeginNode(COORD_NO);

	AxmSplineWrite(COORD_NO, 5, @dPosX, @dPosY, dVelocity, dAccel, dDecel, 0, 100);
	AxmContiEndNode(COORD_NO);
end;

procedure TfrmCamcQI.btnContiBlendClick(Sender: TObject);
var
    lAxis     : array[0..1] of LongInt;
    dPos      : array[0..1] of Double;
    dCenPos   : array[0..2] of Double;
    dEndPos   : array[0..2] of Double;
    dVelocity : Double;
    dAccel    : Double;
    dDecel    : Double;
begin
	dVelocity	:= StrToFloat(edtVelocity.Text);
	dAccel		:= StrToFloat(edtAccel.Text);
	dDecel		:= StrToFloat(edtDecel.Text);

    lAxis[0]	:= AXIS_N04(m_lAxis, 0);
	lAxis[1]	:= AXIS_N04(m_lAxis, 1);

    SetGraphRange(lAxis[0], dVelocity);

	AxmContiWriteClear(COORD_NO);
	AxmContiSetAxisMap(COORD_NO, 2, @lAxis);

	AxmContiSetAbsRelMode(COORD_NO, POS_ABS_MODE);

	AxmContiBeginNode(COORD_NO);
	dPos[0] := 0;          dPos[1] := 2000;
	AxmLineMove(COORD_NO, @dPos, dVelocity, dAccel, dDecel);

	dPos[0] := 1800;       dPos[1] := 2000;
	AxmLineMove(COORD_NO, @dPos, dVelocity, dAccel, dDecel);

	dCenPos[0] := 1800;    dCenPos[1] := 1800;    dEndPos[0] := 2000;    dEndPos[1] := 1800;
  	AxmCircleCenterMove(COORD_NO, @lAxis, @dCenPos, @dEndPos, dVelocity, dAccel, dAccel, DIR_CW);

	dPos[0] := 2000;       dPos[1] := -1800;
	AxmLineMove(COORD_NO, @dPos, dVelocity, dAccel, dAccel);

	dCenPos[0] := 1800;    dCenPos[1] := -1800;   dEndPos[0] := 1800;    dEndPos[1] := -2000;
	AxmCircleCenterMove(COORD_NO, @lAxis, @dCenPos, @dEndPos, dVelocity, dAccel, dAccel, DIR_CW);

	dPos[0] := -1800;      dPos[1] := -2000;
	AxmLineMove(COORD_NO, @dPos, dVelocity, dAccel, dAccel);

	dCenPos[0] := -1800;   dCenPos[1] := -1800;   dEndPos[0] := -2000;   dEndPos[1] := -1800;
	AxmCircleCenterMove(COORD_NO, @lAxis, @dCenPos, @dEndPos, dVelocity, dAccel, dAccel, DIR_CW);

	dPos[0] := -2000;      dPos[1] := 1800;
	AxmLineMove(COORD_NO, @dPos, dVelocity, dAccel, dAccel);

	dCenPos[0] := -1800;   dCenPos[1] := 1800;    dEndPos[0] := -1800;   dEndPos[1] := 2000;
	AxmCircleCenterMove(COORD_NO, @lAxis, @dCenPos, @dEndPos, dVelocity, dAccel, dAccel, DIR_CW);

	dPos[0] := 0;          dPos[1] := 2000;
	AxmLineMove(COORD_NO, @dPos, dVelocity, dAccel, dAccel);

	AxmContiEndNode(COORD_NO);
end;

procedure TfrmCamcQI.btnIntMessageClick(Sender: TObject);
var
    dInterruptNum : DWord;
begin
    g_nIntCnt := 0;
    AxlInterruptEnable();
	AxmInterruptSetAxisEnable(m_lAxis, ENABLE);

	// Setup whether interrupt is generated which user of the designated axis set.
	// lBank : Possible to setup interrupt bank number (0 - 1).
	// lInterruptNum : Setup interrupt
	AxmInterruptSetUserEnable(m_lAxis, 1, QIINTBANK2_29);			// Input signal of limit signal (PELM, NELM).
	AxmInterruptSetAxis(m_lAxis, frmCamcQI.Handle, WM_CAMC_INTERRUPT, nil, 0);

	AxmInterruptGetUserEnable(m_lAxis, 1, @dInterruptNum);
    lstLog.Items.Add('Limit Int Enable[1][' + Format('%x', [dInterruptNum]) + ']');
end;

procedure TfrmCamcQI.btnIntEventClick(Sender: TObject);
var
   dwInterruptNum : DWord;
    ThreadID: DWord;

begin
	g_nIntCnt := 0;
    AxlInterruptEnable();
	AxmInterruptSetAxisEnable(m_lAxis, ENABLE);
	// Setup whether interrupt is generated which user of the designated axis set.
	// lBank : Possible to setup interrupt bank number (0 - 1).
	// lInterruptNum : Setup interrupt
	AxmInterruptSetUserEnable(m_lAxis, 0, QIINTBANK1_29);			// Accepted server alarm signal
	AxmInterruptSetAxis(m_lAxis, 0, 0, nil, @m_hInterrupt[m_lAxis]);

	AxmInterruptGetUserEnable(m_lAxis, 0, @dwInterruptNum);
    lstLog.Items.Add('Alarm Int Enable[0][' + Format('%x', [dwInterruptNum]) + ']');

	if(m_hHandle[m_lAxis] <> 0)then
    begin
		m_bThread[m_lAxis]	:= False;
		m_hHandle[m_lAxis]	:= 0;
	end;

	if (m_bThread[m_lAxis] = False)then
    begin
		m_bThread[m_lAxis]	:= TRUE;
        m_hHandle[m_lAxis]	:= CreateThread(nil, 0, @ThreadProc, Pointer(@frmCamcQI), 0, ThreadID);
    end;
end;

procedure TfrmCamcQI.btnIntCallBackClick(Sender: TObject);
var
	dInterruptNum : DWord;
begin
  	g_nIntCnt := 0;
    AxlInterruptEnable();
	AxmInterruptSetAxisEnable(m_lAxis, ENABLE);

	// Setup whether interrupt is generated which user of the designated axis set.
	// lBank : Possible to setup interrupt bank number (0 - 1).
	// lInterruptNum : Setup interrupt
	AxmInterruptSetUserEnable(m_lAxis, 0, QIINTBANK1_1);			// When running is finished
	AxmInterruptSetAxis(m_lAxis, frmCamcQI.Handle, 0, keMotionInterruptCallback, 0);
	AxmInterruptGetUserEnable(m_lAxis, 0, @dInterruptNum);
    lstLog.Items.Add('Done Int Enable[0][' + Format('%x', [dInterruptNum])+']');
end;

procedure TfrmCamcQI.btnIntDisableClick(Sender: TObject);
begin
  if (frmCamcQI.m_hHandle[m_lAxis] = 0)then
  begin
		m_bThread[m_lAxis]	:= true;
		m_hHandle[m_lAxis]	:= 0;
	end;

	g_nIntCnt := 0;                                                  // Interrupt count clear
	AxlInterruptDisable();
	AxmInterruptSetAxis(m_lAxis, frmCamcQI.Handle, 0, NiL, 0);       // Cancel interrupt method
	AxmInterruptSetAxisEnable(m_lAxis, DISABLE);                     // Interrupt DISABLE
end;

procedure TfrmCamcQI.chkGearOnOffClick(Sender: TObject);
var
    dRatio : double;
begin
    dRatio := StrToFloat(edtGearRatio.Text);
    // It is a function to setup gear rate of Master axis and Slave axis on Electric Gear mode.
    if(chkGearOnOff.Checked = True) then AxmLinkSetMode(AXIS_EVN(m_lAxis), AXIS_ODD(m_lAxis), dRatio)
    else                                 AxmLinkResetMode(AXIS_EVN(m_lAxis));
end;

procedure TfrmCamcQI.btnSigCaptureClick(Sender: TObject);
var
    bySignal  : Byte;
    dVelocity, dAccel : double;
    dwEdge    : DWord;
    lDirect   : LongInt;
    lSignalMethod : LongInt;
begin
    dVelocity     := StrToFloat(edtVelocity.Text);
    dAccel        := StrToFloat(edtAccel.Text);
    bySignal      := cboDetect.ItemIndex;
    lDirect       := cboDirection.ItemIndex;
    lSignalMethod := cboStopM.ItemIndex;

    // Re-setup of the maximum value in chart for displaying running speed of each axis on the chart.
    SetGraphRange(m_lAxis,dVelocity);

    if(bySignal < 8)Then
    begin
	    dwEdge	 := 0;
		bySignal := cboDetect.ItemIndex;
    end
	else
    begin
		dwEdge	 := 1;
		bySignal := cboDetect.ItemIndex - 8;
    end;

	if(lDirect = 0)Then
	    AxmMoveSignalCapture(m_lAxis, dVelocity, dAccel, bySignal, dwEdge, COMMAND, lSignalMethod)
    else
    	AxmMoveSignalCapture(m_lAxis, -dVelocity, dAccel, bySignal, dwEdge, COMMAND, lSignalMethod);
end;

procedure TfrmCamcQI.tmDisplayTimer(Sender: TObject);
var
    wReadInput , wReadOuput , wBusyStatus , wReadHome : DWord;
	wReadInterpolationQueueFree , wIsContMotion : Double;
//	wHomeResult0 , wHomeResult1 , wHomeResult2 , wHomeResult3 : DWord;

    bMechanic  : Byte;
	dCmdPos : array[0..3] of Double;
    dActPos : array[0..3] of Double;
//    dpCapPotition : Double;
	lNodeNum1, lTotalNodeNum1 : LongInt;
begin
    wReadInput := 0; wReadOuput := 0; wBusyStatus := 0; wReadHome := 0;
	wReadInterpolationQueueFree := 0; wIsContMotion := 0; bMechanic := 0;
    lNodeNum1 := 0; lTotalNodeNum1 := 0;

    AxmStatusGetCmdPos((AXIS_N04(m_lAxis, 0)), @dCmdPos[0]);
    AxmStatusGetActPos((AXIS_N04(m_lAxis, 0)), @dActPos[0]);

	AxmStatusGetCmdPos((AXIS_N04(m_lAxis, 1)), @dCmdPos[1]);
	AxmStatusGetActPos((AXIS_N04(m_lAxis, 1)), @dActPos[1]);

	AxmStatusGetCmdPos((AXIS_N04(m_lAxis, 2)), @dCmdPos[2]);
	AxmStatusGetActPos((AXIS_N04(m_lAxis, 2)), @dActPos[2]);

	AxmStatusGetCmdPos((AXIS_N04(m_lAxis, 3)), @dCmdPos[3]);
	AxmStatusGetActPos((AXIS_N04(m_lAxis, 3)), @dActPos[3]);

    edtCmdPosX.Text := FormatFloat('0.##0', dCmdPos[0]);
    edtCmdPosY.Text := FormatFloat('0.##0', dCmdPos[1]);

    edtActPosX.Text := FormatFloat('0.##0', dActPos[0]);
    edtActPosY.Text := FormatFloat('0.##0', dActPos[1]);

    edtCmdPosZ.Text := FormatFloat('0.##0', dCmdPos[2]);
    edtCmdPosU.Text := FormatFloat('0.##0', dCmdPos[3]);

    edtActPosZ.Text := FormatFloat('0.##0', dActPos[2]);
    edtActPosU.Text := FormatFloat('0.##0', dActPos[3]);

    AxmSignalReadInput(m_lAxis, @wReadInput);
	AxmSignalReadOutput(m_lAxis, @wReadOuput);
	AxmStatusReadMechanical(m_lAxis, @bMechanic);

    // General output
    LedOut0.color := LED_RED(((wReadOuput shr 0) and $01) = $01);
    LedOut1.color := LED_RED(((wReadOuput shr 1) and $01) = $01);
    LedOut2.color := LED_RED(((wReadOuput shr 2) and $01) = $01);
    LedOut3.color := LED_RED(((wReadOuput shr 3) and $01) = $01);
    LedOut4.color := LED_RED(((wReadOuput shr 4) and $01) = $01);
 //   LedOut5.color := LED_RED(((wReadOuput shr 5) and $01) = $01);

    AxmHomeReadSignal(m_lAxis, @wReadHome);
    LedHome.color := LED_RED(wReadHome = 1);

    // General input
    LedIn0.color := LED_RED(wReadHome = 1);
    LedIn1.color := LED_RED(((wReadInput shr 1) and $01)= $01);
    LedIn2.color := LED_RED(((wReadInput shr 2 ) and $01 )= $01);
    LedIn3.color := LED_RED(((wReadInput shr 3) and $01)= $01);
    LedIn4.color := LED_RED(((wReadInput shr 4) and $01)= $01);
 //   LedIn5.color := LED_RED(((wReadInput shr 5) and $01)= $01);

	// Hardware signal
    LedPElm.color   := LED_RED(((bMechanic shr 0) and $01) = $01);
    LedNElm.color   := LED_RED(((bMechanic shr 1) and $01) = $01);
    LedAlarm.color  := LED_RED(((bMechanic shr 4) and $01) = $01);
    LedInp.color    := LED_RED(((bMechanic shr 5) and $01) = $01);
    LedEmg.color    := LED_RED(((bMechanic shr 6) and $01) = $01);
    LedZPhase.color := LED_RED(((bMechanic shr 8) and $01) = $01);
    LedEXPP.color   := LED_RED(((bMechanic shr 11) and $01) = $01);
    LedEXMP.color   := LED_RED(((bMechanic shr 12) and $01) = $01);

    AxmHomeReadSignal(m_lAxis, @wReadHome);
    LedHome.color := LED_RED(((bMechanic shr 7) and $01) = $01);

    AxmStatusReadInMotion(AXIS_EVN(m_lAxis), @wBusyStatus);
    LedBusyX.color := LED_YELLOW(wBusyStatus = 1);

    AxmStatusReadInMotion(AXIS_ODD(m_lAxis), @wBusyStatus);
    LedBusyY.color := LED_YELLOW(wBusyStatus = 1);

    AxmContiReadFree(COORD_NO, @wReadInterpolationQueueFree);
	// A function which checks running of serial interpolation
	AxmContiIsMotion(COORD_NO, @wIsContMotion);
	// A function which reads current index value in interpolation queue
	AxmContiGetNodeNum(COORD_NO, @lNodeNum1);
	AxmContiGetTotalNodeNum(COORD_NO, @lTotalNodeNum1);

    edtTotalNum.Text        := FormatFloat('0',lTotalNodeNum1);
    edtContiNum.Text        := FormatFloat('0',lNodeNum1);
    edtInMotion.Text        := FormatFloat('0',wIsContMotion);
    edtQFree.Text           := FormatFloat('0',wReadInterpolationQueueFree);
    edtInterruptCount.Text  := FormatFloat('0',g_nIntCnt);
end;

procedure TfrmCamcQI.tmGraphTimer(Sender: TObject);
var
    lCount    : LongInt;
    dX1, dY1  : Double;
    dCurVelX  : array[0..1] of Double;
    dCurVelY  : array[0..1] of Double;
    dwResult, dwResult2 : DWord;
begin
//    lCount := 0;
    dX1    := 0.0;  dY1 := 0.0;
    dCurVelX[0] := 0.0;
    dCurVelX[1] := 0.0;
    dCurVelY[0] := 0.0;
    dCurVelY[1] := 0.0;
    AxmStatusGetCmdPos(AXIS_EVN(m_lAxis), @dX1);
	AxmStatusGetCmdPos(AXIS_ODD(m_lAxis), @dY1);

    // Coordinate graph of X, Y axis
    Series5.AddXY(dX1, dY1, '', TColor(clYellow));

	dwResult := AxmStatusReadVel(AXIS_N04(m_lAxis, 0), @dCurVelX[0]);
    if (dwResult = AXT_RT_SUCCESS) then
        edtCmdVelX.Text :=  FormatFloat('0.##0', dCurVelX[0]);

	dwResult2 := AxmStatusReadVel(AXIS_N04(m_lAxis, 1), @dCurVelX[1]);
    if (dwResult2 = AXT_RT_SUCCESS) then
        edtCmdVelY.Text :=  FormatFloat('0.##0', dCurVelX[1]);

    if (dwResult = AXT_RT_SUCCESS) then
    begin
        // Speed graph of X, Y axis
        if ((dCurVelX[0] > 0.0) or (dCurVelX[1] > 0.0))then
        begin
            lCount := Series1.XValues.Count();
            Series1.AddXY(lCount, dCurVelX[0], '', TColor(clRed));
            Series2.AddXY(lCount, dCurVelX[1], '', TColor(clGreen));

            GraphX.BottomAxis.Automatic :=  False;
            GraphX.BottomAxis.Maximum   :=  Series1.XValues.Last;
            GraphX.BottomAxis.Minimum   :=  GraphX.BottomAxis.Maximum - 200;
        end;
    end;

	dwResult := AxmStatusReadVel(AXIS_N04(m_lAxis, 2), @dCurVelY[0]);
    if (dwResult = AXT_RT_SUCCESS) then
        edtCmdVelZ.Text :=  FormatFloat('0.##0', dCurVelY[0]);

	dwResult2 := AxmStatusReadVel(AXIS_N04(m_lAxis, 3), @dCurVelY[1]);
    if (dwResult2 = AXT_RT_SUCCESS) then
        edtCmdVelU.Text :=  FormatFloat('0.##0', dCurVelY[1]);

    if (dwResult = AXT_RT_SUCCESS) then
    begin
        // Speed graph of Z, U axis
        if ((dCurVelY[0] > 0.0) or (dCurVelY[1] > 0.0))then
        begin
            lCount := Series3.XValues.Count();
            Series3.AddXY(lCount, dCurVelY[0], '', TColor(clRed));
            Series4.AddXY(lCount, dCurVelY[1], '', TColor(clGreen));

            GraphY.BottomAxis.Automatic :=  False;
            GraphY.BottomAxis.Maximum   :=  Series3.XValues.Last;
            GraphY.BottomAxis.Minimum   :=  GraphY.BottomAxis.Maximum - 200;
        end;
    end;
end;

procedure TfrmCamcQI.tmHomeTimer(Sender: TObject);
var
    wHomeResult0, wHomeResult1, wHomeResult2, wHomeResult3 :  DWord;
begin
    if( Sender as TTimer = tmHome1 )then begin
        AxmHomeGetResult((AXIS_N04(m_lAxis, 0)), @wHomeResult0);
    	if(wHomeResult0 <> HOME_SEARCHING)then begin
            tmHome1.Enabled := false;
    		if(wHomeResult0 = HOME_SUCCESS)then ShowMessage('Home Search 1 Success')
            else                                ShowMessage('Home Search 1 Fail[0X' + IntToHex(wHomeResult0, 2) + ']');
        end;
    end
    else if( Sender as TTimer = tmHome2)then begin
        AxmHomeGetResult((AXIS_N04(m_lAxis, 1)), @wHomeResult1);
    	if(wHomeResult1 <> HOME_SEARCHING)then begin
            tmHome2.Enabled := false;
    		if(wHomeResult1 = HOME_SUCCESS)then ShowMessage('Home Search 2 Success')
    		else                                ShowMessage('Home Search 2 Fail[' + IntToHex(wHomeResult1, 2) + ']');
        end;
    end
    else if( Sender as TTimer = tmHome3)then begin
        AxmHomeGetResult((AXIS_N04(m_lAxis, 2)), @wHomeResult2);
    	if(wHomeResult2 <> HOME_SEARCHING)then  begin
            tmHome3.Enabled := false;
    		if(wHomeResult2 = HOME_SUCCESS)then  ShowMessage('Home Search 3 Success')
    		else                                 ShowMessage('Home Search 3 Fail[' + IntToHex(wHomeResult2, 2) + ']');
        end;
    end
    else if( Sender as TTimer = tmHome4)then begin
        AxmHomeGetResult((AXIS_N04(m_lAxis, 3)), @wHomeResult3);
    	if(wHomeResult3 <> HOME_SEARCHING)then begin
            tmHome4.Enabled := false;
    		if(wHomeResult3 = HOME_SUCCESS)then ShowMessage('Home Search 4 Success')
    		else                                ShowMessage('Home Search 4 Fail[' + IntToHex(wHomeResult3, 2) + ']');
        end;
    end;
end;

procedure TfrmCamcQI.trkXYRangeChange(Sender: TObject);
var
    nTicPos, nTicPos2   :   Integer;
	dUnit               :   Double;
	lPulse              :   longInt;
begin
	nTicPos		:= trkXYRange.Position;
	nTicPos2	:= trkXYRange2.Position;

	AxmMotGetMoveUnitPerPulse(m_lAxis, @dUnit, @lPulse);
	m_dRange	:= (nTicPos * 5) * Power(10, nTicPos2) * (dUnit / lPulse);

	XYPlot.LeftAxis.Minimum     := -m_dRange;
    XYPlot.LeftAxis.Maximum     := m_dRange;
    XYPlot.BottomAxis.Minimum   := -m_dRange;
    XYPlot.BottomAxis.Maximum   := m_dRange;
end;

procedure TfrmCamcQI.btn3DGraphClick(Sender: TObject);
begin
    frm3DGraph.UpdateAxis(m_lAxis);
    frm3DGraph.Show();
    frm3DGraph.tmGraph.Enabled := true;
end;

procedure TfrmCamcQI.btnReadCaptureClick(Sender: TObject);
var
    dCapPos  : double;
begin
    dCapPos := 0.0;

    AxmMoveGetCapturePos(m_lAxis, @dCapPos);
    edtCapturePos.Text := FormatFloat('0.##0', dCapPos);
end;

procedure TfrmCamcQI.OnControlMessage(var Msg : TMessage);
var
    strData : String;
    nBoard: SmallInt;
    lAxisNo: SmallInt;
    nIntrFlag: SmallInt;
    IntBank0, IntBank1: DWord;
begin
	nBoard := HIBYTE(Msg.WParam);		// Interrupt generation board number.
	lAxisNo := LOBYTE(Msg.WParam);		// Interrupt generation axis number.
	nIntrFlag := Msg.LParam;	        // Interrupt generation axis location.

	AxmInterruptReadAxisFlag(lAxisNo, 0, @IntBank0);
	AxmInterruptReadAxisFlag(lAxisNo, 1, @IntBank1);

	g_nIntCnt := g_nIntCnt + 1;
    strData := 'Msg[' + Format('%d', [g_nIntCnt]) + ']Axis[' +  Format('%d', [lAxisNo]) + ']Flag[0x' + Format('%X', [nIntrFlag]) + ']';
	lstLog.Items.Add(strData);
end;

procedure TfrmCamcQI.lstLogDblClick(Sender: TObject);
begin
    lstLog.Clear; 
end;

procedure TfrmCamcQI.chkGantrySlaveClick(Sender: TObject);
var
    strCaption: String;
begin
	if(chkGantrySlave.State = cbUnchecked) then begin
	    strCaption := 'Do not Search';
    end
	else if(chkGantrySlave.State = cbChecked) then begin
        strCaption := 'Do origin revision after Search';
    end
	else if(chkGantrySlave.State = cbGrayed) then begin
        strCaption := 'Do not origin revision after Search';
    end;

	chkGantrySlave.Caption := strCaption;
end;

end.



