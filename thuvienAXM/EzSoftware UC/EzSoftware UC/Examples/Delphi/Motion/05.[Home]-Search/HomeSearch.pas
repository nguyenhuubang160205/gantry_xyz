unit HomeSearch;
// HomeSearch.pas : implementation file
//
// **************************************************************************
// >> [일자]: 2015.12.09
// >> [개요]: 이 예제는 원점검색 함수들의 사용법을 익히고 원점검색 방법과 각
//    단계별 사용하는 원점검색 속도 설정법을 이해하여 빠르고 정밀한 원점 검색
//    방법에 대해 학습하는 예제입니다.
// >> [중요]: 원점검색 방법 및 원점검색 단계별 속도사용에 대해
//     1) 원점검색은 기본적으로 5번의 신호검출 과정을 거쳐 완료됩니다.
//     2) 원점센서 검출 여부를 판단하여 원점검색 진행 방향으로 신호를 검출할 지
//        원점검색 반대방향으로 신호검출을 진행할지를 판단합니다.
//     3) 1차 원점신호 감지시에는 가감속이 있는 구동을 하여 비교적 빠른 속도로
//        원점신호를 감지합니다.
//     4) 1차 원점신호 감지 후 반대방향으로 2단계 속도로 1차 때와 마찬가지로
//        가감속이 있는 구동을 하여 기구물이 원점센서의 검색진행 반대편에 위치
//        하도록 합니다.
//     5) 3단계 속도를 이용하여 가감속이 없이 원점신호를 검출하게 됩니다.
//     6) 이 후 Z상검출 사용여부에 따라 4단계/5단계 신호 검출을 하여 빠르고
//        정밀하게 원점검출을 완료하게 됩니다.
// >> [중요]: 원점검색 속도설정에 대해
//     1) dVelFirst: 초기 원점신호가 감지되지 않았을 때 원점신호 검색 방향으로
//        On 상태를 검출할 때의 속도
//     2) dVelSecond: 초기 원점신호가 감지되어 있어 원점신호 검색 반대 방향으로
//        Off 상태를 검출할 때의 속도
//     3) dVelFirst, dVelSecond속도는 원점검색 반복 정밀도 보다는 원점검색 시간과
//        관련이 깊습니다. 따라서 dVelFirst, dVelSecond 속도는 빠르게 설정합니다.
//     4) dVelThird: 1차 원점신호 위치를 검출하기위해 On상태를 검출할 때의 속도
//     5) dVelLasts: 최종 원점신호 위치를 검출하기위해 On상태를 검출할 때의 속도
//     6) dVelLasts속도는 원점검색 마지막에 사용되어 반복 정밀도와 밀접한 관련이
//        있으므로 10 PPS정도 설정하면 정밀하게 원점검색을 구현 할 수 있습니다.
// **************************************************************************

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, ExtCtrls, StdCtrls, ComCtrls,
  AXL, AXM, AXHS;

type
  TForm1 = class(TForm)
    GroupBox1: TGroupBox;
    Label1: TLabel;
    cboSelAxis: TComboBox;
    btnLoadFile: TButton;
    GroupBox2: TGroupBox;
    GroupBox3: TGroupBox;
    Shape2: TShape;
    GroupBox4: TGroupBox;
    Shape3: TShape;
    GroupBox5: TGroupBox;
    Label4: TLabel;
    OpenDialog1: TOpenDialog;
    m_timerDisplay: TTimer;
    Label8: TLabel;
    Label9: TLabel;
    Label10: TLabel;
    stcCmdPos: TEdit;
    stcActPos: TEdit;
    stcCmdVel: TEdit;
    Label11: TLabel;
    Label12: TLabel;
    Label13: TLabel;
    btnPosClear: TButton;
    chkServoOn: TCheckBox;
    chkHomeState: TCheckBox;
    Label2: TLabel;
    cboHomeLevel: TComboBox;
    Label3: TLabel;
    Label14: TLabel;
    Label15: TLabel;
    cboHomeDir: TComboBox;
    edtHomeOffset: TEdit;
    edtHomeClrTime: TEdit;
    Label16: TLabel;
    cboHomeSignal: TComboBox;
    Label17: TLabel;
    cboZPhaseUse: TComboBox;
    Label18: TLabel;
    btnSetMethod: TButton;
    GroupBox6: TGroupBox;
    Shape1: TShape;
    Label19: TLabel;
    Label20: TLabel;
    Label21: TLabel;
    Label22: TLabel;
    Label23: TLabel;
    edtVelSecond: TEdit;
    edtVelThird: TEdit;
    btnSetVelocity: TButton;
    edtVelFirst: TEdit;
    Label6: TLabel;
    edtVelLast: TEdit;
    edtAccFirst: TEdit;
    edtAccSecond: TEdit;
    Label7: TLabel;
    btnHomeStart: TButton;
    btnMoveStop: TButton;
    stcHomeResult: TEdit;
    stcHomeStepMain: TEdit;
    stcHomeStepSub: TEdit;
    prgHomeRate: TProgressBar;
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
    procedure cboHomeLevelChange(Sender: TObject);
    procedure btnSetMethodClick(Sender: TObject);
    procedure btnSetVelocityClick(Sender: TObject);
    procedure btnHomeStartClick(Sender: TObject);
    procedure btnMoveStopClick(Sender: TObject);
    procedure m_timerDisplayTimer(Sender: TObject);
    procedure m_timerHomeInfoTimer(Sender: TObject);
  private
    { Private declarations }
    m_lAxisNo, m_lAxisCount, m_dwModuleID, m_dwOldResult : integer;
    m_dOldCmdPos, m_dOldActPos, m_dOldCmdVel : Double;

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
    m_dOldCmdPos := 0.0;
    m_dOldActPos := 0.0;
    m_dOldCmdVel := 0.0;
    m_dwOldResult := HOME_ERR_UNKNOWN;

    // TEdit 컨트롤들의 값들을 오른쪽정렬로 설정
    SetWindowLong(stcCmdPos.Handle, GWL_STYLE,
        GetWindowLong(stcCmdPos.Handle, GWL_STYLE) or ES_RIGHT);
    SetWindowLong(stcActPos.Handle, GWL_STYLE,
        GetWindowLong(stcActPos.Handle, GWL_STYLE) or ES_RIGHT);
    SetWindowLong(stcCmdVel.Handle, GWL_STYLE,
        GetWindowLong(stcCmdVel.Handle, GWL_STYLE) or ES_RIGHT);
    SetWindowLong(edtHomeOffset.Handle, GWL_STYLE,
        GetWindowLong(edtHomeOffset.Handle, GWL_STYLE) or ES_RIGHT);
    SetWindowLong(edtHomeClrTime.Handle, GWL_STYLE,
        GetWindowLong(edtHomeClrTime.Handle, GWL_STYLE) or ES_RIGHT);
    SetWindowLong(edtVelFirst.Handle, GWL_STYLE,
        GetWindowLong(edtVelFirst.Handle, GWL_STYLE) or ES_RIGHT);
    SetWindowLong(edtVelSecond.Handle, GWL_STYLE,
        GetWindowLong(edtVelSecond.Handle, GWL_STYLE) or ES_RIGHT);
    SetWindowLong(edtVelThird.Handle, GWL_STYLE,
        GetWindowLong(edtVelThird.Handle, GWL_STYLE) or ES_RIGHT);
    SetWindowLong(edtVelLast.Handle, GWL_STYLE,
        GetWindowLong(edtVelLast.Handle, GWL_STYLE) or ES_RIGHT);
    SetWindowLong(edtAccFirst.Handle, GWL_STYLE,
        GetWindowLong(edtAccFirst.Handle, GWL_STYLE) or ES_RIGHT);
    SetWindowLong(edtAccSecond.Handle, GWL_STYLE,
        GetWindowLong(edtAccSecond.Handle, GWL_STYLE) or ES_RIGHT);

    InitLibrary();
    AddAxisInfo();
    UpdateState();
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
    m_lAxisNo := cboSelAxis.ItemIndex;

    // ++ 지정한 축번호의 모듈ID를 반환합니다.
    // [INFO] 여러개의 정보를 읽는 함수 사용시 불필요한 정보는 NULL(0)을 입력하면 됩니다.
    AxmInfoGetAxis(m_lAxisNo, nil, nil, @m_dwModuleID);

    UpdateState();
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
		    if (AXT_RT_SUCCESS <> AxmMotLoadParaAll(PChar(temp)))then
        begin
            ShowMessage('Mot File Not Found.');
        end;
    end;

	  UpdateState();
end;

// ++ =======================================================================
// >> btnPosClearClick() : "Position Clear"버튼 클릭시 호출되는 핸들러 함수.
//  - 선택된 축의 위치정보를 0.0으로 설정합니다.
//  - AxmStatusSetPosMatch함수는 AxmStatusSetCmdPos, AxmStatusSetActPos 함수를
//    사용하는것과 동일한 효과를 냅니다.
// --------------------------------------------------------------------------
procedure TForm1.btnPosClearClick(Sender: TObject);
begin
    // ++ Command위치와 Actual위치를 지정한 값으로 설정합니다.
    AxmStatusSetPosMatch(m_lAxisNo, 0.0);
end;

// ++ =======================================================================
// >> chkServoOnClick() : "Servo On"버튼 클릭시 호출되는 핸들러 함수.
//  - 선택된 축을 체크버튼의 상태에 따라 서보 On/Off 합니다.
// --------------------------------------------------------------------------
procedure TForm1.chkServoOnClick(Sender: TObject);
var
    dwOnOff : DWORD;
begin
    dwOnOff := iif(chkServoOn.Checked, 1, 0);
    // ++ 지정 축의 Servo On/Off 신호를 출력합니다.
    AxmSignalServoOn(m_lAxisNo, dwOnOff);
end;

// ++ =======================================================================
// >> cboHomeLevelChange() : "Home Level"콤보박스 Item변경시 호출되는 핸들러 함수.
//  - 선택된 축의 원점신호 Active Level을 설정합니다.
// ※ [CAUTION] 특정 네트웍 제품의 경우 원점신호레벨 변경을 지원하지않습니다.
// --------------------------------------------------------------------------
procedure TForm1.cboHomeLevelChange(Sender: TObject);
var
    strData : String;
    dwRetCode, dwLevel : DWORD;
begin
    // 이더켓은 AxmHomeSetSignalLevel을 지원하지 않음.
    if m_dwModuleID <> AXT_ECAT_MOTION then
    begin
      dwLevel := ConvertComboToAxm(cboHomeLevel);
      // ++ 지정한 축의 원점신호 Active Level을 변경합니다.
      dwRetCode := AxmHomeSetSignalLevel(m_lAxisNo, dwLevel);
      if (dwRetCode <> AXT_RT_SUCCESS) then
      begin
          strData := Format('AxmHomeSetSignalLevel return error[Code:%.4d]', [dwRetCode]);
          ShowMessage(strData);
      end;
    end;
end;

// ++ =======================================================================
// >> btnSetMethodClick() : "Set Method"버튼 클릭시 호출되는 핸들러 함수.
//  - 선택된 축의 원점검색 방향, 신호, Z상 검출여부, Offset등을 설정합니다.
//  - 원점검색시 Z상 신호의 검출을 사용함으로 설정하였을 경우 1차로 지정한
//    원점신호를 검출 완료한 후 Z상 신호를 추가적으로 검출하게 됩니다.
// ※ [CAUTION] Z상의 경우 모터와 Ballscrew를 연결해주는 커플링이 풀리거나
//    해체할 경우 Z상 위치가 변경되므로 원점검색 위치가 달라지게됩니다.
// --------------------------------------------------------------------------
procedure TForm1.btnSetMethodClick(Sender: TObject);
var
    strData : String;
    lHomeDir, dwRetCode, dwHomeSignal, dwZPhaseUse : DWORD;
    dHomeClrTime, dHomeOffset : Double;
begin
    lHomeDir := ConvertComboToAxm(cboHomeDir);
    dwHomeSignal := ConvertComboToAxm(cboHomeSignal);
    dwZPhaseUse := ConvertComboToAxm(cboZPhaseUse);
    dHomeClrTime := StrToFloat(edtHomeClrTime.Text);
    dHomeOffset := StrToFloat(edtHomeOffset.Text);

    // ++ 지정한 축의 원점검색 방법을 변경합니다.
    dwRetCode := AxmHomeSetMethod(m_lAxisNo, lHomeDir, dwHomeSignal, dwZPhaseUse, dHomeClrTime, dHomeOffset);
    if (dwRetCode <> AXT_RT_SUCCESS) then
    begin
        strData := Format('AxmHomeSetMethod return error[Code:%.4d]', [dwRetCode]);
        ShowMessage(strData);
    end;
end;

// ++ =======================================================================
// >> btnSetVelocityClick() : "Set Velocity"버튼 클릭시 호출되는 핸들러 함수.
//  - 선택된 축의 단계별 원점검색 속도를 설정합니다.
//  - 원점검색의 단계를 세분화해 빠르고 정밀하게 원점검색을 구현할 수 있습니다.
// ※ [CAUTION] dVelFirst, dVelSecond는 초기 원점검색 속도로 원점검색 반복 정밀도
//    보다는 원점검색 시간과 관련이 깊습니다. 따라서 dVelFirst, dVelSecond 속도는
//    비교적 빠르게 설정하고 원점검색 마지막에 사용되어 반복 정밀도와 밀접한 관련이
//    있는 dVelLasts속도 10 PPS정도에 설정하면 빠르고 정밀하게 원점검색을 구현
//    할 수 있습니다.
// --------------------------------------------------------------------------
procedure TForm1.btnSetVelocityClick(Sender: TObject);
var
    strData : String;
    dwRetCode : DWORD;
    dVelFirst, dVelSecond, dVelThird, dVelLast, dAccFirst, dAccSecond : Double;
begin
    // 각각의 Edit 콘트롤에서 설정값을 가져옴
    dVelFirst := StrToFloat(edtVelFirst.Text);
    dVelSecond := StrToFloat(edtVelSecond.Text);
    dVelThird := StrToFloat(edtVelThird.Text);
    dVelLast := StrToFloat(edtVelLast.Text);
    dAccFirst := StrToFloat(edtAccFirst.Text);
    dAccSecond := StrToFloat(edtAccSecond.Text);

    // ++ 원점검색에 사용되는 단계별 속도를 설정합니다.
    dwRetCode := AxmHomeSetVel(m_lAxisNo, dVelFirst, dVelSecond, dVelThird, dVelLast, dAccFirst, dAccSecond);
    if (dwRetCode <> AXT_RT_SUCCESS) then
    begin
        strData := Format('AxmHomeSetVel return error[Code:%.4d]', [dwRetCode]);
        ShowMessage(strData);
    end;
end;

// ++ =======================================================================
// >> btnHomeStartClick() : "Home Start"버튼 클릭시 호출되는 핸들러 함수.
//  - 선택한 축으로 원점검색을 진행합니다.
//  - 원점검색의 단계를 세분화해 빠르고 정밀하게 원점검색을 구현할 수 있습니다.
// ※ [CAUTION] 원점검색시 라이브러리 내부에서 해당축의 원점검색을 수행 할 쓰레드가
//    자동 생성되어 원점검색을 순차적으로 수행한 후 자동 종료됩니다. 따라서 단일
//    CPU시스템의 경우 사용자 프로그램에서 CPU를 100% 점유할 경우 원점 검색 진행이
//    원할하게 되지 않을 수 있습니다.
// --------------------------------------------------------------------------
procedure TForm1.btnHomeStartClick(Sender: TObject);
var
    strData : String;
    dwRetCode : DWORD;
begin
    // ++ 지정한 축에 원점검색을 진행합니다.
    dwRetCode := AxmHomeSetStart(m_lAxisNo);
    if (dwRetCode <> AXT_RT_SUCCESS) then
    begin
        strData := Format('AxmHomeSetStart return error[Code:%.4d]', [dwRetCode]);
        ShowMessage(strData);
    end;
end;

// ++ =======================================================================
// >> btnMoveStopClick() : "Move Stop"버튼 클릭시 호출되는 핸들러 함수.
//  - 지정한 축의 구동을 종료합니다. 만약 원점검색 중이면 검색을 중단하고 원점검색
//    결과를 HOME_ERR_USER_BREAK로 설정합니다.
// --------------------------------------------------------------------------
procedure TForm1.btnMoveStopClick(Sender: TObject);
begin
    // ++ 지정한 축의 구동을 감속정지합니다.
    AxmMoveSStop(m_lAxisNo);
end;

// ++ =======================================================================
// >> m_timerDisplayTimer(...) : 타이머 이벤트 핸들러 함수.
//  - 일정한 주기로 변경되는 위치/속도/정보등을 Control에 반영합니다.
// --------------------------------------------------------------------------
procedure TForm1.m_timerDisplayTimer(Sender: TObject);
var
    dCmdPos, dActPos, dCmdVel : Double;
begin
    AxmStatusGetCmdPos(m_lAxisNo, @dCmdPos);
    if (m_dOldCmdPos <> dCmdPos) then
    begin
        stcCmdPos.Text := Format('%*.*f', [1, 3, dCmdPos]);
        m_dOldCmdPos := dCmdPos;
    end;

    AxmStatusGetActPos(m_lAxisNo, @dActPos);
    if (m_dOldActPos <> dActPos) then
    begin
        stcActPos.Text := Format('%*.*f', [1, 3, dActPos]);
        m_dOldActPos := dActPos;
    end;

    AxmStatusReadVel(m_lAxisNo, @dCmdVel);
    if (m_dOldCmdVel <> dCmdVel) then
    begin
        stcCmdVel.Text := Format('%*.*f', [1, 3, dCmdVel]);
        m_dOldCmdVel := dCmdVel;
    end;
end;

procedure TForm1.m_timerHomeInfoTimer(Sender: TObject);
var
    dwRetCode, dwState, dwStepMain, dwStepSub : DWORD;
begin
    dwRetCode := AxmHomeReadSignal(m_lAxisNo, @dwState);
    if (dwRetCode = AXT_RT_SUCCESS) then
        chkHomeState.Checked := iif(dwState);

    AxmHomeGetResult(m_lAxisNo, @dwState);
    if (m_dwOldResult <> dwState) then
    begin
        stcHomeResult.Text := TranslateHomeResult(dwState);
        m_dwOldResult := dwState;
    end;

    dwRetCode := AxmHomeGetRate(m_lAxisNo, @dwStepMain, @dwStepSub);
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
    // ++ AXL(AjineXtek Library)을 사용가능하게 하고 장착된 보드들을 초기화합니다.
    if ((AxlOpen(7) <> AXT_RT_SUCCESS))then
    begin
	    ShowMessage('AxlOpen Fail...');
      Result := false;
      exit;
    end;

    // ※ [CAUTION] 아래와 다른 Mot파일(모션 설정파일)을 사용할 경우 경로를 변경하십시요.
    szFilePath := '..\..\..\EzSoftware\MotionDefault.mot';

    // ++ 지정한 Mot파일의 설정값들로 모션보드의 설정값들을 일괄변경 적용합니다.
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
    // ++ 지정한 축의 정보를 반환합니다.
    // [INFO] 여러개의 정보를 읽는 함수 사용시 불필요한 정보는 nil을 입력하면 됩니다.
    AxmInfoGetAxis(m_lAxisNo, @dwBoardNo, @dwModulePos, @m_dwModuleID);

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

    InitControl();
    Result := true;
end;

// ++ =======================================================================
// >> InitControl() : Control들에 초기값을 설정하는 함수.
//  - Control 변수들을 등록하고, 초기 설정값들을 설정합니다.
// --------------------------------------------------------------------------
Function TForm1.InitControl() : Boolean;
begin
    cboSelAxis.ItemIndex := m_lAxisNo;

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
    lHomeDir, dwRetCode, dwLevel, dwHomeSignal, dwZPhaseUse : DWORD;
    dHomeClrTime, dHomeOffset, dVelFirst, dVelSecond : Double;
    dVelThird, dVelLast, dAccFirst, dAccSecond : Double;
begin
    if (m_lAxisCount < 1) then
    begin
        Result := false;
        exit;
    end;

    // 각 제품별 지원여부에 따라 콘트롤 값들을 변경합니다.
    case m_dwModuleID of
        AXT_SMC_4V04, AXT_SMC_R1V04, AXT_SMC_2V04, AXT_SMC_R1V04PM2Q, AXT_SMC_R1V04PM2QE, AXT_SMC_R1V04MLIIIPM,
                AXT_SMC_R1V04MLIIISV, AXT_SMC_R1V04MLIIISV_MD, AXT_SMC_R1V04MLIIIS7S, AXT_SMC_R1V04MLIIIS7W, AXT_ECAT_MOTION :
        begin
            cboHomeLevel.Items.Clear();
            cboHomeLevel.Enabled := true;
            cboHomeLevel.AddItem('00:LOW', TObject(00));
            cboHomeLevel.AddItem('01:HIGH', TObject(01));

            cboHomeSignal.Items.Clear();
            cboHomeSignal.Enabled := true;
            cboHomeSignal.AddItem('00:PosEndLimit', TObject(00));
            cboHomeSignal.AddItem('01:NegEndLimit', TObject(01));
            cboHomeSignal.AddItem('04:HomeSensor', TObject(04));
            cboHomeSignal.AddItem('05:EncodZPhase', TObject(05));

            cboZPhaseUse.Items.Clear();
            cboZPhaseUse.Enabled := true;
            cboZPhaseUse.AddItem('00:DISABLE', TObject(00));
            cboZPhaseUse.AddItem('01:DIR_CHOME', TObject(01));
            cboZPhaseUse.AddItem('02:DIR_HOME', TObject(02));
        end;

        AXT_SMC_R1V04A4 :
        begin
            cboHomeLevel.Items.Clear();
            cboHomeLevel.Enabled := true;
            cboHomeLevel.AddItem('01:HIGH', TObject(01));
            cboHomeLevel.AddItem('02:UNUSED', TObject(02));

            cboHomeSignal.Items.Clear();
            cboHomeSignal.Enabled := true;
            cboHomeSignal.AddItem('00:PosEndLimit', TObject(00));
            cboHomeSignal.AddItem('01:NegEndLimit', TObject(01));
            cboHomeSignal.AddItem('04:HomeSensor', TObject(04));

            cboZPhaseUse.Items.Clear();
            cboZPhaseUse.Enabled := true;
            cboZPhaseUse.AddItem('00:DISABLE', TObject(00));
            cboZPhaseUse.AddItem('01:DIR_CHOME', TObject(01));
            cboZPhaseUse.AddItem('02:DIR_HOME', TObject(02));
        end;

        AXT_SMC_R1V04MLIIPM :
        begin
            cboHomeLevel.Items.Clear();
            cboHomeLevel.Enabled := true;
            cboHomeLevel.AddItem('01:HIGH', TObject(01));
            cboHomeLevel.AddItem('02:UNUSED', TObject(02));

            cboHomeSignal.Items.Clear();
            cboHomeSignal.Enabled := false;
            cboHomeSignal.AddItem('04:HomeSensor', TObject(04));

            cboZPhaseUse.Items.Clear();
            cboZPhaseUse.Enabled := false;
            cboZPhaseUse.AddItem('00:DISABLE', TObject(00));
        end;

        AXT_SMC_R1V04MLIISV, AXT_SMC_R1V04A5, AXT_SMC_R1V04MLIICL, AXT_SMC_R1V04MLIICR,
                AXT_SMC_R1V04MLIIORI, AXT_SMC_R1V04SIIIHMIV, AXT_SMC_R1V04SIIIHMIV_R :
        begin
            cboHomeLevel.Items.Clear();
            cboHomeLevel.Enabled := true;
            cboHomeLevel.AddItem('01:HIGH', TObject(01));
            cboHomeLevel.AddItem('02:UNUSED', TObject(02));

            cboHomeSignal.Items.Clear();
            cboHomeSignal.Enabled := true;
            cboHomeSignal.AddItem('00:PosEndLimit', TObject(00));
            cboHomeSignal.AddItem('01:NegEndLimit', TObject(01));
            cboHomeSignal.AddItem('04:HomeSensor', TObject(04));

            cboZPhaseUse.Items.Clear();
            cboZPhaseUse.Enabled := true;
            cboZPhaseUse.AddItem('00:DISABLE', TObject(00));
            cboZPhaseUse.AddItem('01:DIR_CHOME', TObject(01));
            cboZPhaseUse.AddItem('02:DIR_HOME', TObject(02));
        end;
    end;

    //++ 지정한 축의 서보온 상태를 반환합니다.
    AxmSignalIsServoOn(m_lAxisNo, @dwLevel);
    chkServoOn.Checked := iif(dwLevel);

    //++ 선택한 축의 원점신호 Active Level 설정값을 확인합니다.
    dwRetCode := AxmHomeGetSignalLevel(m_lAxisNo, @dwLevel);
    if (dwRetCode <> AXT_RT_SUCCESS) then
    begin
        dwLevel := UNUSED;
    end;
    ConvertAxmToCombo(cboHomeLevel, dwLevel);

    //++ 선택한 축의 원점검출 속도 설정값을 확인합니다.
    AxmHomeGetVel(m_lAxisNo, @dVelFirst, @dVelSecond, @dVelThird, @dVelLast, @dAccFirst, @dAccSecond);
    edtVelFirst.Text := Format('%*.*f', [1, 3, dVelFirst]);
    edtVelSecond.Text := Format('%*.*f', [1, 3, dVelSecond]);
    edtVelThird.Text := Format('%*.*f', [1, 3, dVelThird]);
    edtVelLast.Text := Format('%*.*f', [1, 3, dVelLast]);
    edtAccFirst.Text := Format('%*.*f', [1, 3, dAccFirst]);
    edtAccSecond.Text := Format('%*.*f', [1, 3, dAccSecond]);

    //++ 선택한 축의 원점검출 방법 설정값을 확인합니다.
    AxmHomeGetMethod(m_lAxisNo, @lHomeDir, @dwHomeSignal, @dwZPhaseUse, @dHomeClrTime, @dHomeOffset);
    ConvertAxmToCombo(cboHomeDir, lHomeDir);
    ConvertAxmToCombo(cboHomeSignal, dwHomeSignal);
    ConvertAxmToCombo(cboZPhaseUse, dwZPhaseUse);
    edtHomeClrTime.Text := Format('%*.*f', [1, 3, dHomeClrTime]);
    edtHomeOffset.Text := Format('%*.*f', [1, 3, dHomeOffset]);

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
