unit MoveSingleAxis;
// MoveSingleAxis.pas : implementation file
//
// **************************************************************************
// >> [일자]: 2015.12.09
// >> [개요]: 이 예제는 단축구동 관련 함수들의 사용법을 익히고 단축구동에 필요한
//    기본 파라메타 설정 및 구동을 학습하는 예제입니다.
// >> [중요]: 단축 구동관련 설정함수들
//     1) AxmMotSetMoveUnitPerPulse 함수는 거리/속도/가감속도의 단위를 설정합니다.
//     2) AxmMotSetAbsRelMode 함수는 구동 좌표계(절대좌표/상대좌표)를 설정합니다.
//     3) AxmMotSetProfileMode 함수는 구동 프로파일 형태를 설정합니다.
// **************************************************************************

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, ExtCtrls, StdCtrls,
  AXL, AXM, AXHS;

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
    btnPosClear: TButton;
    chkServoOn: TCheckBox;
    OpenDialog1: TOpenDialog;
    m_timer: TTimer;
    GroupBox3: TGroupBox;
    Label2: TLabel;
    Label3: TLabel;
    Label4: TLabel;
    Label5: TLabel;
    Label6: TLabel;
    Label7: TLabel;
    edtPos1: TEdit;
    edtPos2: TEdit;
    edtMoveVel: TEdit;
    btnRepeat: TButton;
    Label14: TLabel;
    cboProfile: TComboBox;
    Label15: TLabel;
    edtMoveAcc: TEdit;
    Label16: TLabel;
    Label17: TLabel;
    edtMoveDec: TEdit;
    Label18: TLabel;
    rdoAbs: TRadioButton;
    rdoRel: TRadioButton;
    btnMove1: TButton;
    btnMove2: TButton;
    btnSStop: TButton;
    GroupBox4: TGroupBox;
    Label19: TLabel;
    Label20: TLabel;
    Label21: TLabel;
    Label22: TLabel;
    Label23: TLabel;
    Label24: TLabel;
    edtJogVel: TEdit;
    edtJogAcc: TEdit;
    edtJogDec: TEdit;
    btnJogMoveP: TButton;
    btnJogMoveN: TButton;
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
    procedure btnMove1Click(Sender: TObject);
    procedure btnMove2Click(Sender: TObject);
    procedure btnRepeatClick(Sender: TObject);
    procedure btnSStopClick(Sender: TObject);
    procedure rdoAbsClick(Sender: TObject);
    procedure rdoRelClick(Sender: TObject);
    procedure cboProfileChange(Sender: TObject);
    procedure btnJogMovePMouseDown(Sender: TObject; Button: TMouseButton;
      Shift: TShiftState; X, Y: Integer);
    procedure btnJogMoveNMouseDown(Sender: TObject; Button: TMouseButton;
      Shift: TShiftState; X, Y: Integer);
    procedure btnJogMovePMouseUp(Sender: TObject; Button: TMouseButton;
      Shift: TShiftState; X, Y: Integer);
    procedure btnJogMoveNMouseUp(Sender: TObject; Button: TMouseButton;
      Shift: TShiftState; X, Y: Integer);
    procedure m_timerTimer(Sender: TObject);
  private
    { Private declarations }
    m_lAxisNo, m_lAxisCount, m_dwModuleID : integer;
    m_dOldCmdPos, m_dOldActPos, m_dOldCmdVel : Double;
  public
    { Public declarations }
    m_bTestActive : array[0..7] of boolean;
    m_hTestThread : array[0..7] of THandle;
    function iif(c: boolean; a, b: integer): integer; Overload;
    function iif(c: integer): boolean; Overload;
  end;

    procedure RepeatThread();

var
  Form1: TForm1;

implementation

{$R *.dfm}

procedure TForm1.FormCreate(Sender: TObject);
begin
    InitLibrary();
    AddAxisInfo();
    UpdateState();

    m_dOldCmdPos := 0.0;
    m_dOldActPos := 0.0;
    m_dOldCmdVel := 0.0;

    // TEdit 컨트롤들의 값들을 오른쪽정렬로 설정
    SetWindowLong(stcCmdPos.Handle, GWL_STYLE,
        GetWindowLong(stcCmdPos.Handle, GWL_STYLE) or ES_RIGHT);
    SetWindowLong(stcActPos.Handle, GWL_STYLE,
        GetWindowLong(stcActPos.Handle, GWL_STYLE) or ES_RIGHT);
    SetWindowLong(stcCmdVel.Handle, GWL_STYLE,
        GetWindowLong(stcCmdVel.Handle, GWL_STYLE) or ES_RIGHT);
    SetWindowLong(edtPos1.Handle, GWL_STYLE,
        GetWindowLong(edtPos1.Handle, GWL_STYLE) or ES_RIGHT);
    SetWindowLong(edtPos2.Handle, GWL_STYLE,
        GetWindowLong(edtPos2.Handle, GWL_STYLE) or ES_RIGHT);
    SetWindowLong(edtMoveVel.Handle, GWL_STYLE,
        GetWindowLong(edtMoveVel.Handle, GWL_STYLE) or ES_RIGHT);
    SetWindowLong(edtMoveAcc.Handle, GWL_STYLE,
        GetWindowLong(edtMoveAcc.Handle, GWL_STYLE) or ES_RIGHT);
    SetWindowLong(edtMoveDec.Handle, GWL_STYLE,
        GetWindowLong(edtMoveDec.Handle, GWL_STYLE) or ES_RIGHT);
    SetWindowLong(edtJogVel.Handle, GWL_STYLE,
        GetWindowLong(edtJogVel.Handle, GWL_STYLE) or ES_RIGHT);
    SetWindowLong(edtJogAcc.Handle, GWL_STYLE,
        GetWindowLong(edtJogAcc.Handle, GWL_STYLE) or ES_RIGHT);
    SetWindowLong(edtJogDec.Handle, GWL_STYLE,
        GetWindowLong(edtJogDec.Handle, GWL_STYLE) or ES_RIGHT);
end;

procedure TForm1.FormDestroy(Sender: TObject);
var
    i : integer;
begin
    for i := 0 to (m_lAxisCount - 1) do
    begin
        AxmMoveEStop(i);
		    AxmSignalWriteOutputBit(i, 0, 0);
    end;

    for i := 0 to (m_lAxisCount - 1) do
    begin
        m_bTestActive[i] := false;
        if (m_hTestThread[i] <> 0) then
        begin
            WaitForSingleObject(m_hTestThread[i], WAIT_ABANDONED);
            CloseHandle(m_hTestThread[i]);
            m_hTestThread[i] := 0;
        end;
    end;

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
    //++ Command위치와 Actual위치를 지정한 값으로 설정합니다.
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
    //++ 지정 축의 Servo On/Off 신호를 출력합니다.
    AxmSignalServoOn(m_lAxisNo, dwOnOff);
end;

// ++ =======================================================================
// >> btnMove1Click() : "Move Target 1"버튼 클릭시 호출되는 핸들러 함수.
//  - 선택한 축을 "Target Position 1" Edit콘트롤에 입력된 거리(또는 위치)/속도/
//    가속도/감속도로 모션구동합니다.
// --------------------------------------------------------------------------
procedure TForm1.btnMove1Click(Sender: TObject);
var
    strData : String;
    dwRetCode : DWORD;
    dMovePos, dMoveVel, dMoveAcc, dMoveDec : Double;
begin
    dMovePos := StrToFloat(edtPos1.Text);
    dMoveVel := StrToFloat(edtMoveVel.Text);
    dMoveAcc := StrToFloat(edtMoveAcc.Text);
    dMoveDec := StrToFloat(edtMoveDec.Text);

    //++ 지정한 축을 지정한 거리(또는 위치)/속도/가속도/감속도로 모션구동하고 모션 종료여부와 상관없이 함수를 빠져나옵니다.
    dwRetCode := AxmMoveStartPos(m_lAxisNo, dMovePos, dMoveVel, dMoveAcc, dMoveDec);
    if (dwRetCode <> AXT_RT_SUCCESS) then
    begin
        strData := Format('AxmMoveStartPos1 return error[Code:%.4d]', [dwRetCode]);
        ShowMessage(strData);
    end;
end;

// ++ =======================================================================
// >> btnMove2Click() : "Move Target 2"버튼 클릭시 호출되는 핸들러 함수.
//  - 선택한 축을 "Target Position 2" Edit콘트롤에 입력된 거리(또는 위치)/속도/
//    가속도/감속도로 모션구동합니다.
// --------------------------------------------------------------------------
procedure TForm1.btnMove2Click(Sender: TObject);
var
    strData : String;
    dwRetCode : DWORD;
    dMovePos, dMoveVel, dMoveAcc, dMoveDec : Double;
begin
    dMovePos := StrToFloat(edtPos2.Text);
    dMoveVel := StrToFloat(edtMoveVel.Text);
    dMoveAcc := StrToFloat(edtMoveAcc.Text);
    dMoveDec := StrToFloat(edtMoveDec.Text);

    //++ 지정한 축을 지정한 거리(또는 위치)/속도/가속도/감속도로 모션구동하고 모션 종료여부와 상관없이 함수를 빠져나옵니다.
    dwRetCode := AxmMoveStartPos(m_lAxisNo, dMovePos, dMoveVel, dMoveAcc, dMoveDec);
    if (dwRetCode <> AXT_RT_SUCCESS) then
    begin
        strData := Format('AxmMoveStartPos2 return error[Code:%.4d]', [dwRetCode]);
        ShowMessage(strData);
    end;
end;

// ++ =======================================================================
// >> btnSStopClick() : "Move SStop"버튼 클릭시 호출되는 핸들러 함수.
//  - 선택한 축에 구동정지 함수를 호출하여 구동을 감속정지합니다.
// --------------------------------------------------------------------------
procedure TForm1.btnSStopClick(Sender: TObject);
var
    strData : String;
    dwRetCode : DWORD;
begin
    dwRetCode := AxmMoveSStop(m_lAxisNo);
    if (m_bTestActive[m_lAxisNo] = true) then
        m_bTestActive[m_lAxisNo] := false;
    if (dwRetCode <> AXT_RT_SUCCESS) then
    begin
        strData := Format('AxmMoveSStop return error[Code:%.4d]', [dwRetCode]);
        ShowMessage(strData);
    end;
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
    strData : String;
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
    strData : String;
    dwRetCode : DWORD;
begin
    dwRetCode := AxmMotSetAbsRelMode(m_lAxisNo, POS_REL_MODE);
    if (dwRetCode <> AXT_RT_SUCCESS) then
    begin
        strData := Format('AxmMotSetAbsRelMode return error[Code:%.4d]', [dwRetCode]);
        ShowMessage(strData);
    end;
end;

// ++ =======================================================================
// >> OnSelchangeCboProfile(...) : "Velocity Profile Set" ComboBox 콘트롤 Item선택
//    변경시 호출되는 핸들러 함수.
//  - 지정한 축의 구동 프로파일을 설정합니다.
// --------------------------------------------------------------------------
procedure TForm1.cboProfileChange(Sender: TObject);
var
    strData : String;
    dwRetCode, dwProfileMode : DWORD;
begin
    dwProfileMode := ConvertComboToAxm(cboProfile);
    dwRetCode := AxmMotSetProfileMode(m_lAxisNo, dwProfileMode);
    if (dwRetCode <> AXT_RT_SUCCESS) then
    begin
        strData := Format('AxmMotSetProfileMode return error[Code:%.4d]', [dwRetCode]);
        ShowMessage(strData);
    end;
end;

// ++ =======================================================================
// >> btnJogMovePMouseDown(...) : "Jog Move(+/-)"버튼 Down시 호출되는 핸들러 함수.
//  - "CJogButton" 버튼 클래스에서 버튼 클릭시 호출되는 WM_LBUTTONDOWN 이벤트를
//    받아 사용자 이벤트로 이 함수를 호출해 줍니다. 이 때 wParam을 통해 전달되는
//    콘트롤 ID로 Jog(+/-)버튼을 구분하게 됩니다.
//  - Jog버튼 Down시 연속구동 함수를 호출하여 Jog 구동을 시작합니다.
// --------------------------------------------------------------------------
procedure TForm1.btnJogMovePMouseDown(Sender: TObject;
  Button: TMouseButton; Shift: TShiftState; X, Y: Integer);
var
    strData : String;
    dwRetCode : DWORD;
    dJogVel, dJogAcc, dJogDec : Double;
begin
    dJogVel := abs(StrToFloat(edtJogVel.Text));
    dJogAcc := abs(StrToFloat(edtJogAcc.Text));
    dJogDec := abs(StrToFloat(edtJogDec.Text));

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
    dJogVel := abs(StrToFloat(edtJogVel.Text));
    dJogAcc := abs(StrToFloat(edtJogAcc.Text));
    dJogDec := abs(StrToFloat(edtJogDec.Text));

    dwRetCode := AxmMoveVel(m_lAxisNo, -dJogVel, dJogAcc, dJogDec);
    if (dwRetCode <> AXT_RT_SUCCESS) then
    begin
        strData := Format('AxmMoveVel return error[Code:%.4d]', [dwRetCode]);
        ShowMessage(strData);
    end;
end;

// ++ =======================================================================
// >> btnJogMovePMouseUp(...) : "Jog Move(+/-)"버튼 Up시 호출되는 핸들러 함수.
//  - "CJogButton" 버튼 클래스에서 버튼 클릭시 호출되는 WM_LBUTTONUP이벤트를
//    받아 사용자 이벤트로 이 함수를 호출해 줍니다. 이 때 wParam을 통해 전달되는
//    콘트롤 ID로 Jog(+/-)버튼을 구분하게 됩니다.
//  - Jog버튼 Up시 구동정지 함수를 호출하여 Jog 구동을 종료합니다.
// --------------------------------------------------------------------------
procedure TForm1.btnJogMovePMouseUp(Sender: TObject; Button: TMouseButton;
  Shift: TShiftState; X, Y: Integer);
begin
    AxmMoveSStop(m_lAxisNo);
end;

procedure TForm1.btnJogMoveNMouseUp(Sender: TObject; Button: TMouseButton;
  Shift: TShiftState; X, Y: Integer);
begin
    AxmMoveSStop(m_lAxisNo);
end;

// ++ =======================================================================
// >> m_timerTimer(...) : 타이머 이벤트 핸들러 함수.
//  - 일정한 주기로 변경되는 위치/속도/정보등을 Control에 반영합니다.
// --------------------------------------------------------------------------
procedure TForm1.m_timerTimer(Sender: TObject);
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

// ++ =======================================================================
// >> btnRepeatClick(...) : "<< Repeat >> " 버튼 클릭시 호출되는 핸들러 함수.
//  - 선택한 축에 지정된 Position을 이용하여 Repeat 구동을 합니다.
// --------------------------------------------------------------------------
procedure TForm1.btnRepeatClick(Sender: TObject);
var
    nCurSel : integer;
    ThreadID : DWORD;
begin
    nCurSel := cboSelAxis.ItemIndex;

    if (m_bTestActive[nCurSel] = false) then
    begin
        m_bTestActive[nCurSel] := true;
        if (m_hTestThread[nCurSel] = 0) then
        begin
            m_hTestThread[nCurSel] := CreateThread(nil, 0, @RepeatThread, Pointer(@Form1), 0, ThreadID);
            //m_hTestThread[nCurSel].Create(false);
            //m_hTestThread[nCurSel].Resume();
        end;
    end
    else
        ShowMessage('Already Moving');
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
    if ((AxlOpen(7) <> AXT_RT_SUCCESS))then
    begin
	    ShowMessage('AxlOpen Fail...');
      Result := false;
      exit;
    end;

    szFilePath := '..\..\..\EzSoftware\MotionDefault.mot';
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
var
    i : integer;
begin
    cboProfile.Items.Clear();
    cboProfile.Enabled := true;
    cboProfile.AddItem('00: SYM_TRAPEZOID_MODE', TObject(00));
    cboProfile.AddItem('01: ASYM_TRAPEZOID_MODE', TObject(01));
    cboProfile.AddItem('03: SYM_S_CURVE_MODE', TObject(03));
    cboProfile.AddItem('04: ASYM_S_CURVE_MODE', TObject(04));

    cboSelAxis.ItemIndex := m_lAxisNo;

    rdoAbs.Checked := true;

    for i := 0 to 7 do
    begin
        m_bTestActive[i] := false;
        m_hTestThread[i] := 0;
    end;

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
    dwLevel, dwAbsRelMode, dwProfile : DWORD;
begin
    if (m_lAxisCount < 1) then
    begin
        Result := false;
        exit;
    end;

    //++ 지정한 축의 서보온 상태를 반환합니다.
    AxmSignalIsServoOn(m_lAxisNo, @dwLevel);
    chkServoOn.Checked := iif(dwLevel);

    //++ 지정한 축의 구동 좌표계 설정값을 확인합니다.
    AxmMotGetAbsRelMode(m_lAxisNo, @dwAbsRelMode);
    if (dwAbsRelMode = POS_ABS_MODE) then
        rdoAbs.Checked := true
    else
        rdoRel.Checked := true;

    //++ 지정한 축의 구동 프로파일 설정값을 확인합니다.
    AxmMotGetProfileMode(m_lAxisNo, @dwProfile);
    if (dwProfile > 2) then
        cboProfile.ItemIndex := dwProfile - 1
    else
        cboProfile.ItemIndex := dwProfile;

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
// >> RepeatThread(...) : 사용자가 지정한 위치와 명령내린 지점을 반복해서 이동하는 쓰레드.
// --------------------------------------------------------------------------
procedure RepeatThread();
var
    dCurPos, dPos, dVel, dAcc, dDec : Double;
    dwMode, dwBusyStatus : DWord;
    nCurSel : integer;
begin
    nCurSel := Form1.cboSelAxis.ItemIndex;
    dPos := abs(StrToFloat(Form1.edtPos2.Text));
    dVel := abs(StrToFloat(Form1.edtMoveVel.Text));
    dAcc := abs(StrToFloat(Form1.edtMoveAcc.Text));
    dDec := abs(StrToFloat(Form1.edtMoveDec.Text));

    AxmMotGetAbsRelMode(nCurSel, @dwMode);
    AxmStatusGetCmdPos(nCurSel, @dCurPos);

    while (Form1.m_bTestActive[nCurSel] = true) do
    begin
        AxmMoveStartPos(nCurSel, dPos, dVel, dAcc, dDec);
        repeat
            AxmStatusReadInMotion(nCurSel, @dwBusyStatus);
            sleep(100);
        until ((Form1.m_bTestActive[nCurSel] = false) or (dwBusyStatus = 0));

        if (Form1.m_bTestActive[nCurSel] = false) then
            break;

        if (dwMode = POS_ABS_MODE) then
        begin
            if (dCurPos = dPos) then
                break;
            AxmMoveStartPos(nCurSel, dCurPos, dVel, dAcc, dDec);
        end
        else
        begin
            if (dPos = 0.0) then
                break;
            AxmMoveStartPos(nCurSel, -dPos, dVel, dAcc, dDec);
        end;

        repeat
            AxmStatusReadInMotion(nCurSel, @dwBusyStatus);
            sleep(1);
        until ((Form1.m_bTestActive[nCurSel] = false) or (dwBusyStatus = 0));
    end;

    Form1.m_bTestActive[nCurSel] := false;
    Form1.m_hTestThread[nCurSel] := 0;
end;

end.
