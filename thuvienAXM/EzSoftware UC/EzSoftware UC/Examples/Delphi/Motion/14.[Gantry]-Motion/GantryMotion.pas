unit GantryMotion;
// GantryMotion.pas : implementation file
//
// **************************************************************************
// >> [일자]: 2015.12.14
// >> [개요]: 이 예제는 겐트리 함수들의 사용법을 익히고 겐트리 기구물에서의
//    원점검색 및 Slave축 Offset 설정 방법등에 대해 학습하는 예제입니다.
// >> [중요]: 겐트리 Slave축 Offset설정방법
//     1) AxmGantrySetEnable함수의 uSlHomeUse인자를 2로 설정해서 원점검색을 합니다.
//     2) 원점검색이 정상적으로 완료되면 Slave축 원점위치에서 Master축 원점
//        위치까지의 차이값이(Offset) Master축 지령위치가 됩니다.
//     3) AxmGantrySetEnable함수의 uSlHomeUse인자를 1로, dSlaveHmOffset인자에
//        위에서 측정한 Master축 지령위치값에 부호를 변경한 후 설정하면됩니다.
// **************************************************************************

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, ExtCtrls, StdCtrls, ComCtrls,
  AXL, AXM, AXHS;

const
    GANTRY_SLAVE_HM_DONE = 0;
    GANTRY_SLAVE_HM_BOTH = 1;
    GANTRY_SLAVE_HM_EACH = 2;

type
  TForm1 = class(TForm)
    GroupBox1: TGroupBox;
    Label1: TLabel;
    cboSelAxis: TComboBox;
    btnLoadFile: TButton;
    GroupBox2: TGroupBox;
    Label8: TLabel;
    Label9: TLabel;
    Label10: TLabel;
    stcCmdPosMa: TEdit;
    btnPosClear: TButton;
    chkServoOn: TCheckBox;
    GroupBox3: TGroupBox;
    Label2: TLabel;
    Label4: TLabel;
    Label15: TLabel;
    edtMovePos: TEdit;
    edtMoveVel: TEdit;
    edtMoveAcc: TEdit;
    rdoAbs: TRadioButton;
    rdoRel: TRadioButton;
    btnMovePos: TButton;
    btnMoveStop: TButton;
    GroupBox5: TGroupBox;
    Label19: TLabel;
    Label20: TLabel;
    Shape2: TShape;
    edtGantryHmOffset: TEdit;
    edtGantryHmRange: TEdit;
    chkGantryEnable: TCheckBox;
    OpenDialog1: TOpenDialog;
    m_timerDisplay: TTimer;
    stcAxisNoMa: TLabel;
    stcCmdPosSL: TEdit;
    stcActPosMa: TEdit;
    stcActPosSL: TEdit;
    stcCmdVelMa: TEdit;
    stcCmdVelSL: TEdit;
    stcAxisNoSl: TLabel;
    chkHomeStateMa: TCheckBox;
    chkHomeStateSL: TCheckBox;
    stcGantryState: TLabel;
    Label12: TLabel;
    edtMoveDec: TEdit;
    btnJogMoveP: TButton;
    btnJogMoveN: TButton;
    GroupBox4: TGroupBox;
    Label5: TLabel;
    Label7: TLabel;
    btnHomeStart: TButton;
    btnHomeStop: TButton;
    stcHomeResult: TEdit;
    stcHomeStepMain: TEdit;
    stcHomeStepSub: TEdit;
    prgHomeRate: TProgressBar;
    Shape1: TShape;
    Label13: TLabel;
    cboGantryHmSlaveUse: TComboBox;
    m_timerHomeInfo: TTimer;
    procedure FormCreate(Sender: TObject);
    procedure FormDestroy(Sender: TObject);
    Function InitLibrary() : Boolean; stdcall;
    Function AddAxisInfo() : Boolean; stdcall;
    Function InitControl() : Boolean; stdcall;
    Function UpdateState() : Boolean; stdcall;
    Function ConvertAxmToCombo(pCboItem : TComboBox; dwCurData : DWORD) : DWORD;
    Function ConvertComboToAxm(pCboItem : TComboBox) : DWORD;
    procedure cboSelAxisChange(Sender: TObject);
    procedure btnLoadFileClick(Sender: TObject);
    procedure btnPosClearClick(Sender: TObject);
    procedure chkServoOnClick(Sender: TObject);
    procedure rdoAbsClick(Sender: TObject);
    procedure rdoRelClick(Sender: TObject);
    procedure btnMovePosClick(Sender: TObject);
    procedure btnJogMovePMouseDown(Sender: TObject; Button: TMouseButton;
      Shift: TShiftState; X, Y: Integer);
    procedure btnJogMoveNMouseDown(Sender: TObject; Button: TMouseButton;
      Shift: TShiftState; X, Y: Integer);
    procedure btnJogMovePMouseUp(Sender: TObject; Button: TMouseButton;
      Shift: TShiftState; X, Y: Integer);
    procedure btnJogMoveNMouseUp(Sender: TObject; Button: TMouseButton;
      Shift: TShiftState; X, Y: Integer);
    procedure btnMoveStopClick(Sender: TObject);
    procedure btnHomeStartClick(Sender: TObject);
    procedure btnHomeStopClick(Sender: TObject);
    procedure chkGantryEnableClick(Sender: TObject);
    procedure m_timerDisplayTimer(Sender: TObject);
    procedure m_timerHomeInfoTimer(Sender: TObject);
  private
    { Private declarations }
    m_lAxisNo, m_lAxisNoMa, m_lAxisNoSl, m_lAxisCount: integer;
    m_dwModuleID, m_dwOldResult : DWORD;
    m_dOldCmdPosMa, m_dOldActPosMa, m_dOldCmdVelMa : double;
    m_dOldCmdPosSl, m_dOldActPosSl, m_dOldCmdVelSl : double;

    Function TranslateHomeResult(dwHomeResult: DWORD): String;
  public
    { Public declarations }
    function iif(c: boolean; a, b: integer): integer; Overload;
    function iif(c: integer): boolean; Overload;
  end;

var
  Form1: TForm1;

implementation

{$R *.dfm}

procedure TForm1.FormCreate(Sender: TObject);
begin
    m_lAxisNo := -1;
    m_lAxisNoMa := -1;
    m_lAxisNoSl := -1;
    m_lAxisCount := 0;

    InitLibrary();
    AddAxisInfo();
    UpdateState();

    m_dOldCmdPosMa := 0.0;
    m_dOldActPosMa := 0.0;
    m_dOldCmdVelMa := 0.0;
    m_dOldCmdPosSl := 0.0;
    m_dOldActPosSl := 0.0;
    m_dOldCmdVelSl := 0.0;

    m_dwModuleID := 0;
    m_dwOldResult := HOME_ERR_UNKNOWN;

    // TEdit 컨트롤들의 값들을 오른쪽정렬로 설정
    SetWindowLong(stcCmdPosMa.Handle, GWL_STYLE,
        GetWindowLong(stcCmdPosMa.Handle, GWL_STYLE) or ES_RIGHT);
    SetWindowLong(stcCmdPosSL.Handle, GWL_STYLE,
        GetWindowLong(stcCmdPosSL.Handle, GWL_STYLE) or ES_RIGHT);
    SetWindowLong(stcActPosMa.Handle, GWL_STYLE,
        GetWindowLong(stcActPosMa.Handle, GWL_STYLE) or ES_RIGHT);
    SetWindowLong(stcActPosSL.Handle, GWL_STYLE,
        GetWindowLong(stcActPosSL.Handle, GWL_STYLE) or ES_RIGHT);
    SetWindowLong(stcCmdVelMa.Handle, GWL_STYLE,
        GetWindowLong(stcCmdVelMa.Handle, GWL_STYLE) or ES_RIGHT);
    SetWindowLong(stcCmdVelSl.Handle, GWL_STYLE,
        GetWindowLong(stcCmdVelSl.Handle, GWL_STYLE) or ES_RIGHT);
    SetWindowLong(edtMovePos.Handle, GWL_STYLE,
        GetWindowLong(edtMovePos.Handle, GWL_STYLE) or ES_RIGHT);
    SetWindowLong(edtMoveVel.Handle, GWL_STYLE,
        GetWindowLong(edtMoveVel.Handle, GWL_STYLE) or ES_RIGHT);
    SetWindowLong(edtMoveAcc.Handle, GWL_STYLE,
        GetWindowLong(edtMoveAcc.Handle, GWL_STYLE) or ES_RIGHT);
    SetWindowLong(edtMoveDec.Handle, GWL_STYLE,
        GetWindowLong(edtMoveDec.Handle, GWL_STYLE) or ES_RIGHT);
    SetWindowLong(edtGantryHmOffset.Handle, GWL_STYLE,
        GetWindowLong(edtGantryHmOffset.Handle, GWL_STYLE) or ES_RIGHT);
    SetWindowLong(edtGantryHmRange.Handle, GWL_STYLE,
        GetWindowLong(edtGantryHmRange.Handle, GWL_STYLE) or ES_RIGHT);
end;

procedure TForm1.FormDestroy(Sender: TObject);
begin
    AxlClose();
end;

// **************************************************************************
// >> [구분]: Control에 이벤트가 발생했을 때 처리하는 함수들 모음
// **************************************************************************

// ++ =======================================================================
// >> cboSelAxisChange() : 축 번호 변경시 호출되는 핸들러 함수.
//  - 축 번호가 변경되었을 때 변경된 축의 모듈 ID와 Control들을 갱신합니다.
// --------------------------------------------------------------------------
procedure TForm1.cboSelAxisChange(Sender: TObject);
begin
    m_lAxisNo := cboSelAxis.ItemIndex;  // 축 선택 ComboBox에서 선택된 축번호를 제어할 축 번호 변수에 설정합니다.

    m_lAxisNoMa := m_lAxisNo * 2;       // 선택된 축번호로 겐트리 Master축 번호 생성
    m_lAxisNoSl := m_lAxisNoMa + 1;     // 선택된 축번호로 겐트리 Slave축 번호 생성

    // ++ 지정한 축번호의 모듈ID를 반환합니다.
    // [INFO] 여러개의 정보를 읽는 함수 사용시 불필요한 정보는 NULL(0)을 입력하면 됩니다.
    AxmInfoGetAxis(m_lAxisNo, nil, nil, @m_dwModuleID);

    UpdateState();  // 변경한 축의 상태와 Control들의 상태를 일치시킵니다.
end;

// ++ =======================================================================
// >> btnLoadFileClick() : "Load File"버튼 클릭시 호출되는 핸들러 함수.
//  - 임의 위치에 있는 Mot(AXM에서 사용하는 설정파일 형식) 파일을 불러옵니다.
//  - 이 함수를 통해 임의의 Mot파일을 불러오면 모션축의 설정값들이 Mot파일의
//    설정값들로 일괄 변경됩니다.
// --------------------------------------------------------------------------
procedure TForm1.btnLoadFileClick(Sender: TObject);
var
    temp : AnsiString;
begin
    OpenDialog1.Filter := 'Data File (*.mot)|*.mot|All Files (*.*)|*.*';
    OpenDialog1.Title := 'Open';
	  if(OpenDialog1.Execute())then
    begin
        temp := OpenDialog1.FileName;
        //++ 함수 실행 성공시 지정한 Mot파일의 설정값으로 모션축 설정이 일괄 변경됩니다.
		    if (AXT_RT_SUCCESS <> AxmMotLoadParaAll(PChar(temp)))then
        begin
            ShowMessage('Mot File Not Found.');
        end;
    end;

	  UpdateState();  // 변경된 모션축의 상태와 Control들의 상태를 일치시킵니다.
end;

// ++ =======================================================================
// >> btnPosClearClick() : "Clear"버튼 클릭시 호출되는 핸들러 함수.
//  - 선택된 겐트리 축들의 위치정보를 0.0으로 설정합니다.
//  - AxmStatusSetPosMatch함수는 AxmStatusSetCmdPos, AxmStatusSetActPos 함수를
//    사용하는것과 동일한 효과를 냅니다.
// ※ [CAUTION] 겐트리 축으로 설정되어도 위치설정, 서보온등은 축별로 동작합니다.
// --------------------------------------------------------------------------
procedure TForm1.btnPosClearClick(Sender: TObject);
var
    dwState : DWORD;
begin
    //++ 지정 축이 Gantry축으로 활성화되었는지 확인합니다.
    AxmGantryGetEnable(m_lAxisNoMa, nil, nil, nil, @dwState);
    if (dwState = ENABLE) then
    begin
        //++ Command위치와 Actual위치를 지정한 값으로 설정합니다.
        AxmStatusSetPosMatch(m_lAxisNoMa, 0.0);
        AxmStatusSetPosMatch(m_lAxisNoSl, 0.0)
    end
    else
        AxmStatusSetPosMatch(m_lAxisNo, 0.0);
end;

// ++ =======================================================================
// >> chkServoOnClick() : "Servo On"버튼 클릭시 호출되는 핸들러 함수.
//  - 선택된 겐트리 축들을 체크버튼의 상태에 따라 서보 On/Off 합니다.
// ※ [CAUTION] 겐트리 축으로 설정되어도 위치설정, 서보온등은 각 축별로 동작합니다.
// --------------------------------------------------------------------------
procedure TForm1.chkServoOnClick(Sender: TObject);
var
    dwOnOff, dwState : DWORD;
begin
    dwOnOff := iif(chkServoOn.Checked, 1, 0);
    //++ 지정 축이 Gantry축으로 활성화되었는지 확인합니다.
    AxmGantryGetEnable(m_lAxisNoMa, nil, nil, nil, @dwState);
    if (dwState = ENABLE) then
    begin
        //++ 지정 축의 Servo On/Off 신호를 출력합니다.
        AxmSignalServoOn(m_lAxisNoMa, dwOnOff);
        AxmSignalServoOn(m_lAxisNoSl, dwOnOff);
    end
    else
        AxmSignalServoOn(m_lAxisNo, dwOnOff);
end;

// ++ =======================================================================
// >> OnRdoAbsRelMode(...) : "Absolute/Relative"버튼 클릭시 호출되는 핸들러 함수.
//  - 지정한 축의 구동 좌표계를 설정합니다.
// ※ [CAUTION] 겐트리 축으로 설정되어있으면 Master축의 설정값으로 좌표구동합니다.
// --------------------------------------------------------------------------
procedure TForm1.rdoAbsClick(Sender: TObject);
var
    strData : string;
    dwRetCode : DWORD;
begin
    //++ 지정 축의 구동 좌표계를 설정합니다.
	  // dwAbsRelMode : (0)POS_ABS_MODE - 현재 위치와 상관없이 지정한 위치로 절대좌표 이동합니다.
	  //                (1)POS_REL_MODE - 현재 위치에서 지정한 양만큼 상대좌표 이동합니다.
    dwRetCode := AxmMotSetAbsRelMode(m_lAxisNo, POS_ABS_MODE);
    if (dwRetCode <> AXT_RT_SUCCESS) then
    begin
        strData := Format('AxmMotSetAbsRelMode return error[Code:%.4d]', [dwRetCode]);
        ShowMessage(strData);
    end;
end;

procedure TForm1.rdoRelClick(Sender: TObject);
var
    strData : string;
    dwRetCode : DWORD;
begin
    //++ 지정 축의 구동 좌표계를 설정합니다.
	  // dwAbsRelMode : (0)POS_ABS_MODE - 현재 위치와 상관없이 지정한 위치로 절대좌표 이동합니다.
	  //                (1)POS_REL_MODE - 현재 위치에서 지정한 양만큼 상대좌표 이동합니다.
    dwRetCode := AxmMotSetAbsRelMode(m_lAxisNo, POS_REL_MODE);
    if (dwRetCode <> AXT_RT_SUCCESS) then
    begin
        strData := Format('AxmMotSetAbsRelMode return error[Code:%.4d]', [dwRetCode]);
        ShowMessage(strData);
    end;
end;

// ++ =======================================================================
// >> btnMovePosClick() : "Move Target"버튼 클릭시 호출되는 핸들러 함수.
//  - 지정한 축을 지정한 거리(또는 위치)/속도/가속도/감속도로 모션구동합니다.
//  - 지정한 축이 겐트리 축으로 활성화되어 있으면 두축이 동기되어 구동됩니다.
// ※ [CAUTION] 겐트리 축으로 설정되어 있을경우 구동전 반드시 Master축과 Slave축을
//    각각 서보온 해야됩니다. 만약 한쪽만 서보온 되어있을 경우 모터에(Ballscrew)
//    따라 기구물에 부하가 가해져 알람이 발생할 수 있습니다.
// --------------------------------------------------------------------------
procedure TForm1.btnMovePosClick(Sender: TObject);
var
    strData : String;
    dwRetCode : DWORD;
    dMovePos, dMoveVel, dMoveAcc, dMoveDec : Double;
begin
    // 각각의 Edit 콘트롤에서 설정값을 가져옴
    dMovePos := StrToFloat(edtMovePos.Text);
    dMoveVel := StrToFloat(edtMoveVel.Text);
    dMoveAcc := StrToFloat(edtMoveAcc.Text);
    dMoveDec := StrToFloat(edtMoveDec.Text);

    //++ 지정한 축을 지정한 거리(또는 위치)/속도/가속도로 모션구동합니다.
    dwRetCode := AxmMoveStartPos(m_lAxisNo, dMovePos, dMoveVel, dMoveAcc, dMoveDec);
    if (dwRetCode <> AXT_RT_SUCCESS) then
    begin
        strData := Format('AxmMoveStartPos return error[Code:%.4d]', [dwRetCode]);
        ShowMessage(strData);
    end;
end;

// ++ =======================================================================
// >> btnJogMovePMouseDown(...) : "Move Jog(+/-)"버튼 Down시 호출되는 핸들러 함수.
//  - "CJogButton" 버튼 클래스에서 버튼 클릭시 호출되는 WM_LBUTTONDOWN 이벤트를
//    받아 사용자 이벤트로 이 함수를 호출해 줍니다. 이 때 wParam을 통해 전달되는
//    콘트롤 ID로 Jog(+/-)버튼을 구분하게 됩니다.
//  - Jog버튼 Down시 연속구동 함수를 호출하여 Jog 구동을 시작합니다.
// ※ [CAUTION] 겐트리 축으로 설정되어 있을경우 구동전 반드시 Master축과 Slave축을
//    각각 서보온 해야됩니다. 만약 한쪽만 서보온 되어있을 경우 모터에(Ballscrew)
//    따라 기구물에 부하가 가해져 알람이 발생할 수 있습니다.
// --------------------------------------------------------------------------
procedure TForm1.btnJogMovePMouseDown(Sender: TObject;
  Button: TMouseButton; Shift: TShiftState; X, Y: Integer);
var
    strData : String;
    dwRetCode : DWORD;
    dJogVel, dJogAcc, dJogDec : Double;
begin
    dJogVel := abs(StrToFloat(edtMoveVel.Text));
    dJogAcc := abs(StrToFloat(edtMoveAcc.Text));
    dJogDec := abs(StrToFloat(edtMoveDec.Text));

    //++ 지정한 축을 (+)방향으로 지정한 속도/가속도/감속도로 모션구동합니다.
    dwRetCode := AxmMoveVel(m_lAxisNo, dJogVel, dJogAcc, dJogDec);
    if (dwRetCode <> AXT_RT_SUCCESS) then
    begin
        strData := Format('AxmMoveVel return error[Code:%.4d]', [dwRetCode]);
        ShowMessage(strData);
    end;
end;

procedure TForm1.btnJogMoveNMouseDown(Sender: TObject;
  Button: TMouseButton; Shift: TShiftState; X, Y: Integer);
var
    strData : String;
    dwRetCode : DWORD;
    dJogVel, dJogAcc, dJogDec : Double;
begin
    dJogVel := abs(StrToFloat(edtMoveVel.Text));
    dJogAcc := abs(StrToFloat(edtMoveAcc.Text));
    dJogDec := abs(StrToFloat(edtMoveDec.Text));

    //++ 지정한 축을 (-)방향으로 지정한 속도/가속도/감속도로 모션구동합니다.
    dwRetCode := AxmMoveVel(m_lAxisNo, -dJogVel, dJogAcc, dJogDec);
    if (dwRetCode <> AXT_RT_SUCCESS) then
    begin
        strData := Format('AxmMoveVel return error[Code:%.4d]', [dwRetCode]);
        ShowMessage(strData);
    end;
end;

// ++ =======================================================================
// >> btnJogMovePMouseUp(...) : "Move Jog(+/-)"버튼 Up시 호출되는 핸들러 함수.
//  - "CJogButton" 버튼 클래스에서 버튼 클릭시 호출되는 WM_LBUTTONUP이벤트를
//    받아 사용자 이벤트로 이 함수를 호출해 줍니다. 이 때 wParam을 통해 전달되는
//    콘트롤 ID로 Jog(+/-)버튼을 구분하게 됩니다.
//  - Jog버튼 Up시 구동정지 함수를 호출하여 Jog 구동을 종료합니다.
// ※ [CAUTION] 겐트리 축으로 설정되어 있을경우 Master축의 구동을 종료하면 Slave축
//    또한 동기되어 자동정지됩니다.
// --------------------------------------------------------------------------
procedure TForm1.btnJogMovePMouseUp(Sender: TObject; Button: TMouseButton;
  Shift: TShiftState; X, Y: Integer);
begin
    //++ 지정한 축의 Jog구동(모션구동/원점검색구동)을 감속정지합니다.
    AxmMoveSStop(m_lAxisNo);
end;

procedure TForm1.btnJogMoveNMouseUp(Sender: TObject; Button: TMouseButton;
  Shift: TShiftState; X, Y: Integer);
begin
    AxmMoveSStop(m_lAxisNo);
end;

// ++ =======================================================================
// >> btnMoveStopClick() : "Move Stop"버튼 클릭시 호출되는 핸들러 함수.
//  - 지정한 축으로 구동정지 함수를 호출하여 구동을 종료합니다.
// ※ [CAUTION] 겐트리 축으로 설정되어 있을경우 Master축의 구동을 종료하면 Slave축
//    또한 동기되어 자동정지됩니다.
// --------------------------------------------------------------------------
procedure TForm1.btnMoveStopClick(Sender: TObject);
begin
    //++ 지정한 축의 모션구동(Jog구동/원점검색구동)을 감속정지합니다.
    AxmMoveSStop(m_lAxisNo);
end;

// ++ =======================================================================
// >> btnHomeStartClick() : "Home Start"버튼 클릭시 호출되는 핸들러 함수.
//  - 지정한 축으로 원점검색을 시작합니다.
// ※ [CAUTION] 지정한 축이 겐트리 축으로 설정되어 있을경우 두축 모두 서보온이
//    되어있지 않을 경우 AxmGantrySetEnable 함수로 겐트리 기능을 활성활 할 때 설정한
//    dwSlaveHmUse의 값에 따라 원점검색이 완료되지 않을 수 있습니다.
// ※ [CAUTION] 지정한 축이 겐트리 축으로 설정되어 있을경우 AxmGantrySetEnable
//    함수로 겐트리 기능을 활성활 할 때 설정한 dwSlaveHmUse의 값에 따라 원점검색
//    방법이 달라집니다.
// --------------------------------------------------------------------------
procedure TForm1.btnHomeStartClick(Sender: TObject);
var
    strData : String;
    dwRetCode : DWORD;
begin
    // 원점검색 레벨 변경이 필요할 때 주석을 해제해서 사용하세요.
    // - dwLevel: [00]LOW, [01]HIGH
    // > AxmHomeSetSignalLevel(m_lAxisNoMa, dwLevel);
    // > AxmHomeSetSignalLevel(m_lAxisNoSl, dwLevel);

    // 원점검색 방법설정 변경이 필요할 때 주석을 해제해서 사용하세요.
    // - lHomeDir     : [00]DIR_CCW, [01]DIR_CW
    // - dwHomeSignal : [00]PosEndLimit, [01]NegEndLimit, [04]HomeSensor
    // - dwZPhaseUse  : [00]Not Use, [01]Home Dir, [02]Not Home Dir
    // > AxmHomeSetMethod(m_lAxisNoMa, lHomeDir, dwHomeSignal, dwZPhaseUse, dHomeClrTime, dHomeOffset);
    // > AxmHomeSetMethod(m_lAxisNoSl, lHomeDir, dwHomeSignal, dwZPhaseUse, dHomeClrTime, dHomeOffset);

    // 원점검색 속도설정 변경이 필요할 때 주석을 해제해서 사용하세요.
    // > AxmHomeSetVel(m_lAxisNoMa, dVelFirst, dVelSecond, dVelThird, dVelLast, dAccFirst, dAccSecond);
    // > AxmHomeSetVel(m_lAxisNoSl, dVelFirst, dVelSecond, dVelThird, dVelLast, dAccFirst, dAccSecond);

    //++ 지정한 축의 원점검색 구동을 시작합니다.
    dwRetCode := AxmHomeSetStart(m_lAxisNo);
    if (dwRetCode <> AXT_RT_SUCCESS) then
    begin
        strData := Format('AxmHomeSetStart return error[Code:%.4d]', [dwRetCode]);
        ShowMessage(strData);
    end;
end;

// ++ =======================================================================
// >> btnHomeStopClick() : "Home Stop"버튼 클릭시 호출되는 핸들러 함수.
//  - 지정한 축으로 구동정지 함수를 호출하여 원점검색구동을 종료합니다.
// ※ [CAUTION] 겐트리 축으로 설정되어 있을경우 Master축의 구동을 종료하면 Slave축
//    또한 동기되어 자동정지됩니다.
// --------------------------------------------------------------------------
procedure TForm1.btnHomeStopClick(Sender: TObject);
begin
    //++ 지정한 축의 원점검색구동(모션구동/Jog구동)을 감속정지합니다.
    AxmMoveSStop(m_lAxisNo);
end;

// ++ =======================================================================
// >> chkGantryEnableClick() : "Gantry Enable"버튼 클릭시 호출되는 핸들러 함수.
//  - 지정한 축으로 겐트리 기능을 활성화 합니다.
// ※ [CAUTION] 겐트리 축으로 설정되어 있을경우 Master축의 구동을 종료하면 Slave축
//    또한 동기되어 자동정지됩니다.
// --------------------------------------------------------------------------
procedure TForm1.chkGantryEnableClick(Sender: TObject);
var
    strData : string;
    dwSlaveHmUse, dwRetCode : DWORD;
    dSlaveHmOffset, dSlaveHmRange : double;
begin
    if (chkGantryEnable.Checked) then
    begin
        dwSlaveHmUse := ConvertComboToAxm(cboGantryHmSlaveUse);
        dSlaveHmOffset := StrToFloat(edtGantryHmOffset.Text);
        dSlaveHmRange := StrToFloat(edtGantryHmRange.Text);

        //++ 지정한 Master축과 Slave축으로 겐트리 기능을 활성화 시킵니다.
        dwRetCode := AxmGantrySetEnable(m_lAxisNoMa, m_lAxisNoSl, dwSlaveHmUse, dSlaveHmOffset, dSlaveHmRange);
        if (dwRetCode <> AXT_RT_SUCCESS) then
        begin
            strData := Format('AxmGantrySetEnable return error[Code:%.4d]', [dwRetCode]);
            ShowMessage(strData);
        end
    end
    else
    begin
        //++ 지정한 Master축과 Slave축으로 겐트리 기능을 비활성화 시킵니다.
        dwRetCode := AxmGantrySetDisable(m_lAxisNoMa, m_lAxisNoSl);
        if (dwRetCode <> AXT_RT_SUCCESS) then
        begin
            chkGantryEnable.Checked := true;
            strData := Format('AxmGantrySetDisable return error[Code:%.4d]', [dwRetCode]);
            ShowMessage(strData);
        end
    end;
end;

// ++ =======================================================================
// >> m_timerDisplayTimer(...) : 타이머 이벤트 핸들러 함수.
//  - 일정한 주기로 변경되는 위치/속도/정보등을 Control에 반영합니다.
// --------------------------------------------------------------------------
procedure TForm1.m_timerDisplayTimer(Sender: TObject);
var
    dwState : DWORD;
    dCmdPos, dActPos, dCmdVel : Double;
begin
    //++ 지정한 축의 지령(Command)위치를 반환합니다.
    AxmStatusGetCmdPos(m_lAxisNoMa, @dCmdPos);
    if (m_dOldCmdPosMa <> dCmdPos) then
    begin
        stcCmdPosMa.Text := Format('%*.*f', [1, 3, dCmdPos]);
        m_dOldCmdPosMa := dCmdPos;
    end;
    AxmStatusGetCmdPos(m_lAxisNoSl, @dCmdPos);
    if (m_dOldCmdPosSl <> dCmdPos) then
    begin
        stcCmdPosSl.Text := Format('%*.*f', [1, 3, dCmdPos]);
        m_dOldCmdPosSl := dCmdPos;
    end;

    //++ 지정한 축의 실제(Feedback)위치를 반환합니다.
    AxmStatusGetActPos(m_lAxisNoMa, @dActPos);
    if (m_dOldActPosMa <> dActPos) then
    begin
        stcActPosMa.Text := Format('%*.*f', [1, 3, dActPos]);
        m_dOldActPosMa := dActPos;
    end;
    AxmStatusGetActPos(m_lAxisNoSl, @dActPos);
    if (m_dOldActPosSl <> dActPos) then
    begin
        stcActPosSL.Text := Format('%*.*f', [1, 3, dActPos]);
        m_dOldActPosSl := dActPos;
    end;

    //++ 지정한 축의 구동 속도를 반환합니다.
    AxmStatusReadVel(m_lAxisNoMa, @dCmdVel);
    if (m_dOldCmdVelMa <> dCmdVel) then
    begin
        stcCmdVelMa.Text := Format('%*.*f', [1, 3, dCmdVel]);
        m_dOldCmdVelMa := dCmdVel;
    end;
    AxmStatusReadVel(m_lAxisNoSl, @dCmdVel);
    if (m_dOldCmdVelSl <> dCmdVel) then
    begin
        stcCmdVelSL.Text := Format('%*.*f', [1, 3, dCmdVel]);
        m_dOldCmdVelSl := dCmdVel;
    end;

    //++ 지정한 축에 겐트리 기능이 활성화되었는지 확인합니다.
    AxmGantryGetEnable(m_lAxisNoMa, nil, nil, nil, @dwState);
    if (dwState = ENABLE) then
        stcGantryState.Caption := '∞'
    else
        stcGantryState.Caption := ' ';
end;

procedure TForm1.m_timerHomeInfoTimer(Sender: TObject);
var
    dwRetCode, dwState, dwStepMain, dwStepSub : DWORD;
begin
    //++ 지정한 축의 원점신호의 상태를 확인합니다.
    dwRetCode := AxmHomeReadSignal(m_lAxisNoMa, @dwState);
    if (dwRetCode = AXT_RT_SUCCESS) then
        chkHomeStateMa.Checked := iif(dwState);
    //++ 지정한 축의 원점신호의 상태를 확인합니다.
    dwRetCode := AxmHomeReadSignal(m_lAxisNoSl, @dwState);
    if (dwRetCode = AXT_RT_SUCCESS) then
        chkHomeStateSl.Checked := iif(dwState);

    //++ 지정한 축의 원점검색 결과를 확인합니다.
    AxmHomeGetResult(m_lAxisNoMa, @dwState);
    if (m_dwOldResult <> dwState) then
    begin
        stcHomeResult.Text := TranslateHomeResult(dwState);
        m_dwOldResult := dwState;
    end;

    //++ 지정한 축의 원점검색 진행율을 확인합니다.
    dwRetCode := AxmHomeGetRate(m_lAxisNoMa, @dwStepMain, @dwStepSub);
    if (dwRetCode = AXT_RT_SUCCESS) then
    begin
        if (StrToInt(stcHomeStepMain.Text) <> dwStepMain) then
            stcHomeStepMain.Text := Format('%d', [dwStepMain]);
        if (StrToInt(stcHomeStepSub.Text) <> dwStepSub) then
            stcHomeStepSub.Text := Format('%d', [dwStepSub]);
        prgHomeRate.Position := dwStepSub;
    end;
end;

// **************************************************************************
// >> [구분]: 별도의 기능을 구현하기위해 만든 사용자 정의 함수들 모음
// **************************************************************************

// ++ =======================================================================
// >> InitLibrary() : 라이브러리 초기화 및 Mot파일을 불러오는 함수.
//  - AXL(AjineXtek Library)을 사용가능하게 합니다.
//  - EzConfig 프로그램이 설치되어있는 폴더에서 기본 Mot파일(모션 설정파일)을
//    지정해 모션관련 기본설정을 자동으로 합니다.
// --------------------------------------------------------------------------
Function TForm1.InitLibrary() : Boolean;
var
    szFilePath : AnsiString;
    dwResult : DWORD;
begin
    //++ AXL(AjineXtek Library)을 사용가능하게 하고 장착된 보드들을 초기화합니다.
    if ((AxlOpen(7) <> AXT_RT_SUCCESS))then
    begin
	    ShowMessage('AxlOpen Fail...');
      Result := false;
      exit;
    end;

    // ※ [CAUTION] 아래와 다른 Mot파일(모션 설정파일)을 사용할 경우 경로를 변경하십시요.
    szFilePath := '..\..\..\EzSoftware\MotionDefault.mot';
    //++ 지정한 Mot파일의 설정값들로 모션보드의 설정값들을 일괄변경 적용합니다.
    dwResult := AxmMotLoadParaAll(PChar(szFilePath));
    if (dwResult <> AXT_RT_SUCCESS) then
    begin
        ShowMessage('Mot File Not Found.');
    end;

    Result := true;
end;

// ++ =======================================================================
// >> AddAxisInfo() : 시스템에 장착된 모션축들을 ComboBox에 등록하는 함수.
//  - AXL Open시 검색된 축들의 정보를 읽어 ComboBox에 등록하여 사용자가 선택
//    제어할 수 있도록 합니다.
//  - 유효한 축이 검색되었을 때 Control들을 초기화 하고, 정보 갱신용 타이머를
//    100msec 주기로 동작시킵니다.
// --------------------------------------------------------------------------
Function TForm1.AddAxisInfo() : Boolean;
var
    strData : String;
    i   :   Integer;
    dwModuleID : DWORD;
    dwBoardNo : DWORD;
    dwModulePos : DWORD;
    szModuleName : PAnsiChar;
begin
    // ++ 유효한 전체 모션축수를 반환합니다.
    AxmInfoGetAxisCount(@m_lAxisCount);
    if (m_lAxisCount < 1) then
    begin
        Result := false;
        exit;
    end;

    m_lAxisNo := 0;
    m_lAxisNoMa := 0;
    m_lAxisNoSl := -1;
    // ++ 지정한 축의 정보를 반환합니다.
    // [INFO] 여러개의 정보를 읽는 함수 사용시 불필요한 정보는 nil을 입력하면 됩니다.
    AxmInfoGetAxis(m_lAxisNoMa, @dwBoardNo, @dwModulePos, @m_dwModuleID);

    // 유효한 전체 모션축수의 정보를 읽어 ComboBox에 등록합니다.
    For i := 0 to (m_lAxisCount - 1) do
    begin
      // ++ 지정한 축의 정보를 반환합니다.
      // [INFO] 여러개의 정보를 읽는 함수 사용시 불필요한 정보는 nil을 입력하면 됩니다.
      AxmInfoGetAxis(i, nil, nil, @dwModuleID);
      case dwModuleID of
        AXT_SMC_4V04 : strData := Format('%.2d-[4V04]', [i]);
        AXT_SMC_R1V04 : strData := Format('%.2d-[R1V04]', [i]);
        AXT_SMC_2V04 : strData := Format('%.2d-[2V04]', [i]);
        AXT_SMC_R1V04MLIIPM : strData := Format('%.2d-[R1V04MLIIPM]', [i]);
        AXT_SMC_R1V04PM2Q : strData := Format('%.2d-[R1V04PM2Q]', [i]);
        AXT_SMC_R1V04PM2QE : strData := Format('%.2d-[R1V04PM2QE]', [i]);
        AXT_SMC_R1V04MLIIIPM : strData := Format('%.2d-[R1V04MLIIIPM]', [i]);
        AXT_SMC_R1V04MLIISV : strData := Format('%.2d-[R1V04MLIISV]', [i]);
        AXT_SMC_R1V04A5 : strData := Format('%.2d-[R1V04A5]', [i]);
        AXT_SMC_R1V04A4 : strData := Format('%.2d-[R1V04A4]', [i]);
        AXT_SMC_R1V04SIIIHMIV : strData := Format('%.2d-[R1V04SIIIHMIV]', [i]);
        AXT_SMC_R1V04SIIIHMIV_R : strData := Format('%.2d-[R1V04SIIIHMIV_R]', [i]);
        AXT_SMC_R1V04MLIIISV : strData := Format('%.2d-[R1V04MLIIISV]', [i]);
        AXT_SMC_R1V04MLIIISV_MD : strData := Format('%.2d-[R1V04MLIIISV_MD]', [i]);
        AXT_SMC_R1V04MLIIIS7S : strData := Format('%.2d-[R1V04MLIIIS7S]', [i]);
        AXT_SMC_R1V04MLIIIS7W : strData := Format('%.2d-[R1V04MLIIIS7W]', [i]);
        AXT_ECAT_MOTION :
            begin
                szModuleName := Allocmem(50);
                AxmInfoGetAxisEx(i, nil, PChar(szModuleName), nil);
                strData := Format('%.2d-[ECAT-%s]', [i, String(szModuleName)]);
            end
      else
        strData := Format('%.2d-[Unknown]', [i]);
      end;

      cboSelAxis.AddItem(strData, TObject(i))

    end;

    InitControl();  // Control 변수들을 등록하고, 초기 설정값들을 설정합니다.
    Result := true;
end;

// ++ =======================================================================
// >> InitControl() : Control들에 초기값을 설정하는 함수.
//  - Control 변수들을 등록하고, 초기 설정값들을 설정합니다.
// --------------------------------------------------------------------------
Function TForm1.InitControl() : Boolean;
begin
    cboSelAxis.ItemIndex := m_lAxisNo;

    m_lAxisNoMa := m_lAxisNo * 2;
    m_lAxisNoSl := m_lAxisNoMa + 1;

    Result := true;
end;

// ++ =======================================================================
// >> UpdateState() : 지정한 축의 설정값들을 읽어 Control과 일치시키는 함수.
//  - 축번호가 변경되었을 때 변경한 축의 설정값들과 Control들과 일치시키는
//    역할을하는 함수입니다.
//  - 지정한 축의 모델별 제약들을 Control에 반영하는 역할을 합니다.
//  - 프로그램 초기 실행시, Mot파일 불러올 때, 축 번호 바뀔 때 사용됩니다.
// --------------------------------------------------------------------------
Function TForm1.UpdateState() : Boolean;
var
    dwAbsRelMode, dwOnOff, dwSlaveHmUse, dwGantryOn : DWORD;
    dSlaveHmOffset, dSlaveHmRange : double;
begin
    if (m_lAxisCount < 1) then
    begin
        Result := false;
        exit;
    end;

    dwAbsRelMode := POS_ABS_MODE;
    dwOnOff := 0;
    dwSlaveHmUse := 0;
    dwGantryOn := DISABLE;
    dSlaveHmOffset := 0.0;
    dSlaveHmRange := 1.0;

    //++ 지정한 축의 서보온 상태를 반환합니다.
    AxmSignalIsServoOn(m_lAxisNo, @dwOnOff);
    chkServoOn.Checked := iif(dwOnOff);

    //++ 지정한 축의 구동 좌표계 설정값을 확인합니다.
    AxmMotGetAbsRelMode(m_lAxisNo, @dwAbsRelMode);
    if (dwAbsRelMode = POS_ABS_MODE) then
        rdoAbs.Checked := true
    else
        rdoRel.Checked := true;

    //++ 지정한 축이 제어가 가능한 상태인지 확인합니다.
    if (AxmInfoGetAxisStatus(m_lAxisNoSl) = AXT_RT_SUCCESS) then
    begin
        stcCmdPosSL.Enabled := true;
        stcActPosSL.Enabled := true;
        stcCmdVelSL.Enabled := true
    end
    else
    begin
        stcCmdPosSL.Enabled := false;
        stcActPosSL.Enabled := false;
        stcCmdVelSL.Enabled := false;
    end;

    stcAxisNoMa.Caption := Format('Ma Axis %2d', [m_lAxisNoMa]);
    stcAxisNoSl.Caption := Format('Sl Axis %2d', [m_lAxisNoSl]);

    //++ 지정한 축의 겐트리제어 관련 설정값을 확인합니다.
    AxmGantryGetEnable(m_lAxisNoMa, @dwSlaveHmUse, @dSlaveHmOffset, @dSlaveHmRange, @dwGantryOn);
    ConvertAxmToCombo(cboGantryHmSlaveUse, dwSlaveHmUse);
    edtGantryHmOffset.Text := Format('%*.*f', [1, 3, dSlaveHmOffset]);
    edtGantryHmRange.Text := Format('%*.*f', [1, 3, dSlaveHmRange]);
    chkGantryEnable.Checked := iif(dwGantryOn);

    Result := true;
end;

// ++ =======================================================================
// >> ConvertComboToAxm(...) : ComboBox콘트롤에 현재 선택된 Item Index를 모션
//    보드에 설정할 값으로 변경하는 함수.
//  - ComboBox에 선택된 Item Index와 실제 모션보드에 설정되는 값이 다르므로
//    선택된 문자열에서 모션보드에 설정할 값을 추출해서 반환하는 함수입니다.
//  - 변환 할 ComboBox 콘트롤의 포인트를 인자로 전달합니다.
//  - 이 함수를 사용하고자 할 때 데이타 등록을 지정된 양식으로 설정해야됩니다.
//    Format) XX: String, XX=라이브러리로 전달될 값, String=인자 설명
//    Ex) "01: HIGH", "00: COMMAND", "04: HomeSensor"
// --------------------------------------------------------------------------
Function TForm1.ConvertAxmToCombo(pCboItem : TComboBox; dwCurData : DWORD) : DWORD;
var
    dwCount, dwSelData : DWORD;
    strText, strNumber : String;
    i : DWORD;
begin
    if (pCboItem = nil) then
    begin
        Result := 0;
        exit;
    end;

    dwCount := pCboItem.Items.Count;
    if (dwCount = 0) then
    begin
        Result := 0;
        exit;
    end;

    for i := 0 to (dwCount - 1) do
    begin
        strText := pCboItem.Items.Strings[i];
        strNumber := Copy(strText, 1, 2);
        dwSelData := StrToInt(strNumber);
        if (dwSelData = dwCurData) then
        begin
            pCboItem.ItemIndex := i;
            Result := i;
            exit;
        end;
    end;

    pCboItem.ItemIndex := 0;
    Result := 0;
end;

// ++ =======================================================================
// >> ConvertComboToAxm(...) : 지정한 모션보드에 설정값과 ComboBox콘트롤의
//    Item과 일치하는 Item을 찾아 선택하는 함수.
//  - 실제 모션보드에 설정되는 값과 ComboBox의 Item Index와  다르므로 지정한
//    값과 일치하는 Item을 찾아 선택하고 선택된 Item의 Index를 반환합니다.
//  - 변경하고자하는 ComboBox 콘트롤의 포인트를 인자로 전달합니다.
//  - 이 함수를 사용하고자 할 때 데이타 등록을 지정된 양식으로 설정해야됩니다.
//    Format) XX: String, XX=라이브러리로 전달될 값, String=인자 설명
//    Ex) "01: HIGH", "00: COMMAND", "04: HomeSensor"
// --------------------------------------------------------------------------
Function TForm1.ConvertComboToAxm(pCboItem : TComboBox) : DWORD;
var
    dwCount : DWORD;
    dwSelData : integer;
    strText : String;
begin
    if (pCboItem = nil) then
    begin
        Result := 0;
        exit;
    end;

    dwCount := pCboItem.Items.Count;
    if (dwCount = 0) then
    begin
        Result := 0;
        exit;
    end;

    dwSelData := pCboItem.ItemIndex;
    if (dwSelData < 0) then
    begin
        Result := 0;
        exit;
    end;

    strText := pCboItem.Items.Strings[dwSelData];
    Result := StrToInt(Copy(strText, 1, 2));
end;

function TForm1.iif(c: boolean; a, b: integer): integer;
begin
  if c then
    Result := a
  else
    Result := b;
end;

function TForm1.iif(c: integer): boolean;
begin
    if (c <> 0) then
      Result := true
    else
      Result := false;
end;

// ++ =======================================================================
// >> TranslateHomeResult(...) : 지정한 원점검색 결과에 해당하는 문자열을 반환
//    하는 함수.
//  - "AXHS.h"에 정의되어있는 AXT_MOTION_HOME_RESULT 구조체를 기반으로 합니다.
// --------------------------------------------------------------------------
Function TForm1.TranslateHomeResult(dwHomeResult: DWORD): String;
var
    strResult : String;
begin
    case dwHomeResult of
        HOME_SUCCESS : strResult := '[01H] HOME_SUCCESS';
        HOME_SEARCHING : strResult := '[02H] HOME_SEARCHING';
        HOME_ERR_GNT_RANGE : strResult := '[10H] HOME_ERR_GNT_RANGE';
        HOME_ERR_USER_BREAK : strResult := '[11H] HOME_ERR_USER_BREAK';
        HOME_ERR_VELOCITY : strResult := '[12H] HOME_ERR_VELOCITY';
        HOME_ERR_AMP_FAULT : strResult := '[13H] HOME_ERR_AMP_FAULT';
        HOME_ERR_NEG_LIMIT : strResult := '[14H] HOME_ERR_NEG_LIMIT';
        HOME_ERR_POS_LIMIT : strResult := '[15H] HOME_ERR_POS_LIMIT';
        HOME_ERR_NOT_DETECT : strResult := '[16H] HOME_ERR_NOT_DETECT';
        HOME_ERR_UNKNOWN : strResult := '[FFH] HOME_ERR_UNKNOWN';
    end;

    Result := strResult;
end;

end.
