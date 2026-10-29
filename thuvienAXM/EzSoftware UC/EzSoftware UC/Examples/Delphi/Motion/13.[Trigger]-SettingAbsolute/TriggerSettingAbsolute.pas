unit TriggerSettingAbsolute;
// TriggerSettingAbsolute.pas : implementation file
//
// **************************************************************************
// >> [일자]: 2015.12.11
// >> [개요]: 이 예제는 비젼트리거 함수들중 구동중 여러개의 절대위치에서 트리거
//    하는 AxmTriggerOnlyAbs함수의 사용법과 기능을 테스트하는 예제입니다.
// >> [중요]: 절대위치 트리거 제약사항
//     1) 트리거 위치 갯수 제한은 없으나 모션 콘트롤 칩의 트리거 버퍼(15개)가
//        실행될 동안 라이브러리 내부에서 새로운 트리거 데이타를 업데이트 하지
//        못하면 트리거가 중단되게됩니다.
//     2) 즉 15개 이상의 트리거를 사용하고 그 15개의 트리거가 발생하는데 걸리는
//        시간이 1 mSec 이하 일 때는 트리거가 중단될 가능성이 높습니다.
//     3) 위와같이 고속으로 많은 양의 절대위치 트리거를 발생시켜야 될 경우 당사에서
//        제공하는 별도의 카운트 모듈을(SIO-CN2CH) 사용하면됩니다.
// **************************************************************************

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, ExtCtrls, StdCtrls,
  AXL, AXM, AXHS;

const
    MAX_TRIG_NUM = 99;

type
    TArrTrig = array[0..(MAX_TRIG_NUM - 1)] of double;
    PArrTrig = ^TArrTrig;

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
    Label11: TLabel;
    Label12: TLabel;
    Label13: TLabel;
    stcCmdPos: TEdit;
    stcActPos: TEdit;
    stcCmdVel: TEdit;
    btnPosSet: TButton;
    chkServoOn: TCheckBox;
    edtSetPos: TEdit;
    GroupBox3: TGroupBox;
    Label2: TLabel;
    Label4: TLabel;
    Label5: TLabel;
    Label7: TLabel;
    Label15: TLabel;
    Label16: TLabel;
    edtMovePos: TEdit;
    edtMoveVel: TEdit;
    edtMoveAcc: TEdit;
    rdoAbs: TRadioButton;
    rdoRel: TRadioButton;
    btnMove: TButton;
    btnMoveStop: TButton;
    GroupBox4: TGroupBox;
    Shape6: TShape;
    Label3: TLabel;
    Label6: TLabel;
    Label14: TLabel;
    Label17: TLabel;
    Label18: TLabel;
    Shape1: TShape;
    edtTrigTime: TEdit;
    cboTrigLevel: TComboBox;
    cboTrigTarget: TComboBox;
    stcIntCount: TEdit;
    cboIntUse: TComboBox;
    btnSetMethod: TButton;
    GroupBox5: TGroupBox;
    Label19: TLabel;
    Shape2: TShape;
    chkSetAbsolute: TCheckBox;
    OpenDialog1: TOpenDialog;
    m_timer: TTimer;
    edtTrigPosAdd: TEdit;
    btnTrigDataAdd: TButton;
    btnTrigDataClr: TButton;
    Shape3: TShape;
    Label20: TLabel;
    lstTrigPos: TListBox;
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
    procedure btnPosSetClick(Sender: TObject);
    procedure chkServoOnClick(Sender: TObject);
    procedure rdoAbsClick(Sender: TObject);
    procedure rdoRelClick(Sender: TObject);
    procedure btnMoveClick(Sender: TObject);
    procedure btnMoveStopClick(Sender: TObject);
    procedure btnSetMethodClick(Sender: TObject);
    procedure btnTrigDataAddClick(Sender: TObject);
    procedure chkSetAbsoluteClick(Sender: TObject);
    procedure lstTrigPosDblClick(Sender: TObject);
    procedure btnTrigDataClrClick(Sender: TObject);
    procedure m_timerTimer(Sender: TObject);
    Function ConvertListBoxToArray(pLstItem: TListBox; dpTrigPos: PArrTrig) : longint;
  private
    { Private declarations }
    m_lAxisNo, m_lAxisCount, m_dwModuleID : integer;
    m_dOldCmdPos, m_dOldActPos, m_dOldCmdVel : Double;
    procedure OnAxmIntMessage(var Msg : TMessage); message WM_AXL_INTERRUPT;
  public
    { Public declarations }
    function iif(c: boolean; a, b: integer): integer; Overload;
    function iif(c: integer): boolean; Overload;
  end;

var
  Form1: TForm1;

implementation

var
    g_lIntCount, g_lIntCountOld : longint;

{$R *.dfm}

procedure TForm1.FormCreate(Sender: TObject);
begin
    InitLibrary();
    AddAxisInfo();
    UpdateState();

    m_dOldCmdPos := 0.0;
    m_dOldActPos := 0.0;
    m_dOldCmdVel := 0.0;

    g_lIntCount := 0;
    g_lIntCountOld := 0;

    // TEdit 컨트롤들의 값들을 오른쪽정렬로 설정
    SetWindowLong(stcCmdPos.Handle, GWL_STYLE,
        GetWindowLong(stcCmdPos.Handle, GWL_STYLE) or ES_RIGHT);
    SetWindowLong(stcActPos.Handle, GWL_STYLE,
        GetWindowLong(stcActPos.Handle, GWL_STYLE) or ES_RIGHT);
    SetWindowLong(stcCmdVel.Handle, GWL_STYLE,
        GetWindowLong(stcCmdVel.Handle, GWL_STYLE) or ES_RIGHT);
    SetWindowLong(edtSetPos.Handle, GWL_STYLE,
        GetWindowLong(edtSetPos.Handle, GWL_STYLE) or ES_RIGHT);
    SetWindowLong(edtMovePos.Handle, GWL_STYLE,
        GetWindowLong(edtMovePos.Handle, GWL_STYLE) or ES_RIGHT);
    SetWindowLong(edtMoveVel.Handle, GWL_STYLE,
        GetWindowLong(edtMoveVel.Handle, GWL_STYLE) or ES_RIGHT);
    SetWindowLong(edtMoveAcc.Handle, GWL_STYLE,
        GetWindowLong(edtMoveAcc.Handle, GWL_STYLE) or ES_RIGHT);
    SetWindowLong(edtTrigTime.Handle, GWL_STYLE,
        GetWindowLong(edtTrigTime.Handle, GWL_STYLE) or ES_RIGHT);
    SetWindowLong(stcIntCount.Handle, GWL_STYLE,
        GetWindowLong(stcIntCount.Handle, GWL_STYLE) or ES_CENTER);
    SetWindowLong(edtTrigPosAdd.Handle, GWL_STYLE,
        GetWindowLong(edtTrigPosAdd.Handle, GWL_STYLE) or ES_RIGHT);
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
        //++ 함수 실행 성공시 지정한 Mot파일의 설정값으로 모션축 설정이 일괄 변경됩니다.
		    if (AXT_RT_SUCCESS <> AxmMotLoadParaAll(PChar(temp)))then
        begin
            ShowMessage('Mot File Not Found.');
        end;
    end;

	  UpdateState();  // 변경된 모션축의 상태와 Control들의 상태를 일치시킵니다.
end;

// ++ =======================================================================
// >> btnPosSetClick() : "Position Setting"버튼 클릭시 호출되는 핸들러 함수.
//  - 선택된 축의 위치정보를 지정한 값으로 설정합니다.
//  - AxmStatusSetPosMatch함수는 AxmStatusSetCmdPos, AxmStatusSetActPos 함수를
//    사용하는것과 동일한 효과를 냅니다.
// --------------------------------------------------------------------------
procedure TForm1.btnPosSetClick(Sender: TObject);
var
    dSetPos : double;
begin
    dSetPos := StrToFloat(edtSetPos.Text);
    //++ Command위치와 Actual위치를 지정한 값으로 설정합니다.
    AxmStatusSetPosMatch(m_lAxisNo, dSetPos);
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
    //++ 지정 축의 Servo On/Off 신호를 출력합니다.
    AxmSignalServoOn(m_lAxisNo, dwOnOff);
end;

// ++ =======================================================================
// >> rdoAbsClick(...) : "Absolute/Relative"버튼 클릭시 호출되는 핸들러 함수.
//  - 지정한 축의 구동 좌표계를 설정합니다.
//  - 설정된 좌표계에 따라 구동 함수들에 전달되는 dPos의 값은 절대위치 또는
//    상대 이동량이 됩니다.
//  - Ex1) 현재 Command위치 100으로 가정
//     1) AxmMotSetAbsRelMode(0, POS_ABS_MODE)
//     2) AxmMoveStartPos(0, 200, ...)
//     -> Command위치 기준 200 위치로 이동, 즉 (+)방향으로 100만큼 이동함
//  - Ex2) 현재 Command위치 100으로 가정
//     1) AxmMotSetAbsRelMode(0, POS_REL_MODE)
//     2) AxmMoveStartPos(0, 200, ...)
//     -> Command위치 기준 300 위치로 이동, 즉 (+)방향으로 200만큼 이동함
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
// >> btnMoveClick() : "Move Target"버튼 클릭시 호출되는 핸들러 함수.
//  - 선택한 축을 "Target Position" Edit콘트롤에 입력된 거리(또는 위치)/속도/
//    가속도/감속도로 모션구동합니다.
// --------------------------------------------------------------------------
procedure TForm1.btnMoveClick(Sender: TObject);
var
    strData : String;
    dwRetCode : DWORD;
    dMovePos, dMoveVel, dMoveAcc, dMoveDec : Double;
begin
    dMovePos := StrToFloat(edtMovePos.Text);
    dMoveVel := StrToFloat(edtMoveVel.Text);
    dMoveAcc := StrToFloat(edtMoveAcc.Text);
    dMoveDec := dMoveAcc;

    //++ 지정한 축을 지정한 거리(또는 위치)/속도/가속도/감속도로 모션구동하고 모션 종료여부와 상관없이 함수를 빠져나옵니다.
    dwRetCode := AxmMoveStartPos(m_lAxisNo, dMovePos, dMoveVel, dMoveAcc, dMoveDec);
    if (dwRetCode <> AXT_RT_SUCCESS) then
    begin
        strData := Format('AxmMoveStartPos return error[Code:%.4d]', [dwRetCode]);
        ShowMessage(strData);
    end;
end;

// ++ =======================================================================
// >> btnMoveStopClick() : "Move SStop"버튼 클릭시 호출되는 핸들러 함수.
//  - 선택한 축에 구동정지 함수를 호출하여 구동을 감속정지합니다.
// --------------------------------------------------------------------------
procedure TForm1.btnMoveStopClick(Sender: TObject);
begin
    //++ 지정한 축의 구동을 감속정지합니다.
    AxmMoveSStop(m_lAxisNo);
end;

// ++ =======================================================================
// >> btnSetMethodClick() : "Set Method"버튼 클릭시 호출되는 핸들러 함수.
//  - 선택한 축에 트리거 펄스출력 시간, 트리거 레벨, 인터럽트사용 유무를 설정하고
//    트리거 기능을 활성화/비활성화 시킵니다.
// --------------------------------------------------------------------------
procedure TForm1.btnSetMethodClick(Sender: TObject);
var
    strData : string;
    dTrigTime : double;
    dwRetCode, dwTrigLevel, dwTrigTarget, dwIntUse : DWORD;
begin
    dTrigTime := StrToFloat(edtTrigTime.Text);
    dwTrigLevel := ConvertComboToAxm(cboTrigLevel);
    dwTrigTarget := ConvertComboToAxm(cboTrigTarget);
    dwIntUse := ConvertComboToAxm(cboIntUse);

    //++ 지정 축에 트리거 펄스출력 시간 및 트리거 출력 레벨, 트리거 출력방법을 설정합니다.
    dwRetCode := AxmTriggerSetTimeLevel(m_lAxisNo, dTrigTime, dwTrigLevel, dwTrigTarget, dwIntUse);
    if (dwRetCode <> AXT_RT_SUCCESS) then
    begin
        strData := Format('AxmTriggerSetTimeLevel return error[Code:%.4d]', [dwRetCode]);
        ShowMessage(strData);
    end;

    if (dwIntUse = ENABLE) then
    begin
        //++ 인터럽트 처리방식을 윈도우메세지 방식으로 지정함
        AxmInterruptSetAxis(m_lAxisNo, Form1.Handle, WM_AXL_INTERRUPT, nil, nil);
        //++ AXL라이브러리의 인터럽트 발생을 허용합니다.
        AxlInterruptEnable();
        //++ 지정한 축에 인터럽트 발생을 허용합니다.
        AxmInterruptSetAxisEnable(m_lAxisNo, ENABLE)
    end
    else
    begin
        //++ AXL라이브러리의 인터럽트 발생을 금지합니다.
        AxlInterruptDisable();
        //++ 지정한 축에 인터럽트 발생을 금지합니다.
        AxmInterruptSetAxisEnable(m_lAxisNo, DISABLE);
    end;
end;

// ++ =======================================================================
// >> btnTrigDataAddClick() : "<< Add Item"버튼 클릭시 호출되는 핸들러 함수.
//  - 트리거 위치 정보를 ListBox에 등록합니다.
// --------------------------------------------------------------------------
procedure TForm1.btnTrigDataAddClick(Sender: TObject);
var
    strData : string;
    lCount : longint;
    dTrigPos : double;
begin
    dTrigPos := StrToFloat(edtTrigPosAdd.Text);
    lCount := lstTrigPos.Count + 1;
    strData := Format('%12.3f', [dTrigPos]);

    lstTrigPos.AddItem(strData, TObject(lCount));
end;

// ++ =======================================================================
// >> chkSetAbsoluteClick() : "Set Absolute"버튼 클릭시 호출되는 핸들러 함수.
//  - ListBox에 등록된 트리거위치 정보를 추출하여 절대위치 트리거 함수로 트리거를
//    예약합니다.
//  - 간결한 예제구성을 위해 트리거 갯수를 최대 99개로 제한하였습니다.
// --------------------------------------------------------------------------
procedure TForm1.chkSetAbsoluteClick(Sender: TObject);
var
    strData : string;
    dwRetCode : DWORD;
    lArraySize : longint;
    daTrigPos : array[0..(MAX_TRIG_NUM)] of double;
begin
    if (chkSetAbsolute.Checked) then
    begin
        lArraySize := ConvertListBoxToArray(lstTrigPos, @daTrigPos);

        //++ 입력한 절대위치값의 순서대로 해당 위치를 지날때 트리거 신호를 출력합니다.
		    // - 한번 출력된 트리거는 트리거 Queue에서 소멸되므로 재 발생되지않습니다.
        dwRetCode := AxmTriggerOnlyAbs(m_lAxisNo, lArraySize, @daTrigPos);
        if (dwRetCode <> AXT_RT_SUCCESS) then
        begin
            chkSetAbsolute.Checked := false;
            strData := Format('AxmTriggerOnlyAbs return error[Code:%.4d]', [dwRetCode]);
            ShowMessage(strData);
        end;

        g_lIntCount := 0;
    end
    else
    begin
        //++ 예약된 트리거 데이타를 초기화 합니다.
        dwRetCode := AxmTriggerSetReset(m_lAxisNo);
        if (dwRetCode <> AXT_RT_SUCCESS) then
        begin
            chkSetAbsolute.Checked := true;
            strData := Format('AxmTriggerSetReset return error[Code:%.4d]', [dwRetCode]);
            ShowMessage(strData);
        end;
    end;
end;

// ++ =======================================================================
// >> lstTrigPosDblClick() : ListBox 콘트롤 마우스 더블클릭시 호출되는 핸들러 함수.
//  - 등록된 트리거 위치 정보중 선택된 Item을 지울때 호출됩니다.
//  - List Box 콘트롤에서 마우스 포인트를 삭제할 Item 으로 이동한 후 마우스
//    오르쪽 버튼을 더블클릭하면 해당 Item이 선택 삭제됩니다.
// --------------------------------------------------------------------------
procedure TForm1.lstTrigPosDblClick(Sender: TObject);
var
    nSelectedIndex : integer;
begin
    nSelectedIndex := lstTrigPos.ItemIndex;
    lstTrigPos.Items.Delete(nSelectedIndex);
end;

// ++ =======================================================================
// >> btnTrigDataClrClick() : "All Clear Item"버튼 클릭시 호출되는 핸들러 함수.
//  - 등록된 트리거 위치 데이타를 모두 지웁니다.
// --------------------------------------------------------------------------
procedure TForm1.btnTrigDataClrClick(Sender: TObject);
begin
    lstTrigPos.Items.Clear();
end;

// ++ =======================================================================
// >> m_timerTimer(...) : 타이머 이벤트 핸들러 함수.
//  - 일정한 주기로 변경되는 위치/속도/정보등을 Control에 반영합니다.
// --------------------------------------------------------------------------
procedure TForm1.m_timerTimer(Sender: TObject);
var
    dCmdPos, dActPos, dCmdVel : Double;
begin
    //++ 지정한 축의 지령(Command)위치를 반환합니다.
    AxmStatusGetCmdPos(m_lAxisNo, @dCmdPos);
    if (m_dOldCmdPos <> dCmdPos) then
    begin
        stcCmdPos.Text := Format('%*.*f', [1, 3, dCmdPos]);
        m_dOldCmdPos := dCmdPos;
    end;

    //++ 지정한 축의 실제(Feedback)위치를 반환합니다.
    AxmStatusGetActPos(m_lAxisNo, @dActPos);
    if (m_dOldActPos <> dActPos) then
    begin
        stcActPos.Text := Format('%*.*f', [1, 3, dActPos]);
        m_dOldActPos := dActPos;
    end;

    //++ 지정한 축의 구동 속도를 반환합니다.
    AxmStatusReadVel(m_lAxisNo, @dCmdVel);
    if (m_dOldCmdVel <> dCmdVel) then
    begin
        stcCmdVel.Text := Format('%*.*f', [1, 3, dCmdVel]);
        m_dOldCmdVel := dCmdVel;
    end;

    // 인터럽트 발생 카운터값을 출력합니다.
    if (g_lIntCountOld <> g_lIntCount) then
    begin
        stcIntCount.Text := Format('%d', [g_lIntCount]);
        g_lIntCountOld := g_lIntCount;
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
    dwAbsRelMode, dwOnOff : DWORD;
    dTrigTime : double;
    dwTrigLevel, dwTrigTarget, dwIntUse : DWORD;
begin
    if (m_lAxisCount < 1) then
    begin
        Result := false;
        exit;
    end;

    dwAbsRelMode := POS_ABS_MODE;
    dwOnOff := 0;
    dTrigTime := 1000.0;
    dwTrigLevel := HIGH;
    dwTrigTarget := COMMAND;
    dwIntUse := DISABLE;

    //++ 지정한 축의 서보온 상태를 반환합니다.
    AxmSignalIsServoOn(m_lAxisNo, @dwOnOff);
    chkServoOn.Checked := iif(dwOnOff);

    //++ 지정 축의 구동 좌표계를 확인합니다.
	  // dwAbsRelMode : (0)POS_ABS_MODE - 현재 위치와 상관없이 지정한 위치로 절대좌표 이동합니다.
	  //                (1)POS_REL_MODE - 현재 위치에서 지정한 양만큼 상대좌표 이동합니다.
    AxmMotGetAbsRelMode(m_lAxisNo, @dwAbsRelMode);
    if (dwAbsRelMode = POS_ABS_MODE) then
        rdoAbs.Checked := true
    else
        rdoRel.Checked := true;

    //++ 지정 축에 트리거 펄스출력 시간 및 트리거 출력 레벨, 트리거 출력방법을 확인합니다.
    AxmTriggerGetTimeLevel(m_lAxisNo, @dTrigTime, @dwTrigLevel, @dwTrigTarget, @dwIntUse);
    edtTrigTime.Text := Format('%*.*f', [1, 3, dTrigTime]);
    ConvertAxmToCombo(cboTrigLevel, dwTrigLevel);
    ConvertAxmToCombo(cboTrigTarget, dwTrigTarget);
    ConvertAxmToCombo(cboIntUse, dwIntUse);

    Result := true;
end;

// ++ =======================================================================
// >> OnAxmIntMessage(...) : 인터럽트 메시지 핸들러 함수.
//  - 인터럽트 방식중 윈도 메세지 방식으로 인터럽트를 사용할 경우 라이브러리에서
//    인터럽트 발생시 자동으로 호출되는 인터럽트 메세지 처리 함수입니다.
//  - wParam에는 축정보가 전달됩니다.
//  - lParam에는 인터럽트가 발생된 Bank정보가 전달 됩니다.
// --------------------------------------------------------------------------
procedure TForm1.OnAxmIntMessage(var Msg : TMessage);
begin
    g_lIntCount := g_lIntCount + 1; // 트리거 인터럽트 발생시 카운트값을 증가시킵니다.
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
// >> ConvertListBoxToArray(...) : 지정한 콘트롤에 설정되어 있는 텍스트를
//    트리거 위치 정보값으로  변환하여 반환하는 함수.
//  - ListBox 콘트롤에 설정된 텍스트를 트리거 위치 정보값으로 변환하여 코드를
//    간결하게 구현하였습니다.
//  - 실제 트리거 함수의 위치지정 갯수 제한은 없으나 예제구현 편의상 99개로
//    제한하였습니다.
// --------------------------------------------------------------------------
Function TForm1.ConvertListBoxToArray(pLstItem: TListBox; dpTrigPos: PArrTrig) : longint;
var
    strData : string;
    lArraySize, lCount : longint;
begin
    if ((pLstItem = nil) or (dpTrigPos = nil)) then
    begin
        Result := 0;
        exit;
    end;

    lArraySize := pLstItem.Items.Count;
    if (lArraySize = 0) then
    begin
        Result := 0;
        exit;
    end;

    for lCount := 0 to (lArraySize - 1) do
    begin
        if (lCount = MAX_TRIG_NUM) then
        begin
            lArraySize := MAX_TRIG_NUM;
            break;
        end;
        strData := pLstItem.Items.ValueFromIndex[lCount];

        dpTrigPos[lCount] := StrToFloat(Trim(strData));
    end;

    Result := lArraySize;
end;

end.
