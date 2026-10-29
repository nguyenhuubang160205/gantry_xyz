unit MoveSignalCapture;
// MoveSignalCapture.pas : implementation file
//
// **************************************************************************
// >> [일자]: 2015.12.10
// >> [개요]: 이 예제는 신호검출 구동함수들의 사용법을 익히고 실제 특정 신호의
//    변화를 감지하여 그때 지령값 또는 엔코더값을 캡쳐해보는 예제입니다.
// >> [중요]: 위치캡쳐구동함수 응용범위
//     1) 구동중 특정 센서가 감지될 때의 지령위치 또는 피드벡 위치를 H/W 기능을
//        이용해 정확하게 저장해야될 때 응용됩니다.
//     2) 이 기능은 웨이퍼 이송 로봇에서 웨이퍼 틀어짐 파악, Tray 적재 로봇에서
//        Tray높이 파악등에 응용할 수 있습니다.
//     3) 구동중 고속 다중위치 캡쳐기능이 필요하신분은 별도로 기술문의 바랍니다.
// **************************************************************************

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs,
  AXL, AXM, AXHS, ExtCtrls, StdCtrls;

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
    GroupBox3: TGroupBox;
    Label4: TLabel;
    Label7: TLabel;
    Label14: TLabel;
    Label15: TLabel;
    Label16: TLabel;
    edtMoveVel: TEdit;
    cboDetectSig: TComboBox;
    edtMoveAcc: TEdit;
    btnCaptureMove: TButton;
    btnMoveStop: TButton;
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
    OpenDialog1: TOpenDialog;
    m_timer: TTimer;
    Label2: TLabel;
    Label3: TLabel;
    cboSignalEdge: TComboBox;
    Label5: TLabel;
    cboCaptureTarget: TComboBox;
    Label6: TLabel;
    cboStopMethod: TComboBox;
    Shape2: TShape;
    Label17: TLabel;
    stcCapturePos: TEdit;
    btnGetPos: TButton;
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
    procedure btnCaptureMoveClick(Sender: TObject);
    procedure btnMoveStopClick(Sender: TObject);
    procedure btnGetPosClick(Sender: TObject);
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
    function iif(c: boolean; a, b: integer): integer; Overload;
    function iif(c: integer): boolean; Overload;
  end;

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
    SetWindowLong(edtJogVel.Handle, GWL_STYLE,
        GetWindowLong(edtJogVel.Handle, GWL_STYLE) or ES_RIGHT);
    SetWindowLong(edtJogAcc.Handle, GWL_STYLE,
        GetWindowLong(edtJogAcc.Handle, GWL_STYLE) or ES_RIGHT);
    SetWindowLong(edtJogDec.Handle, GWL_STYLE,
        GetWindowLong(edtJogDec.Handle, GWL_STYLE) or ES_RIGHT);
    SetWindowLong(edtMoveVel.Handle, GWL_STYLE,
        GetWindowLong(edtMoveVel.Handle, GWL_STYLE) or ES_RIGHT);
    SetWindowLong(edtMoveAcc.Handle, GWL_STYLE,
        GetWindowLong(edtMoveAcc.Handle, GWL_STYLE) or ES_RIGHT);
    SetWindowLong(stcCapturePos.Handle, GWL_STYLE,
        GetWindowLong(stcCapturePos.Handle, GWL_STYLE) or ES_RIGHT);
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
    AxmSignalServoOn(m_lAxisNo, dwOnOff);
end;

// ++ =======================================================================
// >> btnCaptureMoveClick() : "Capture Move "버튼 클릭시 호출되는 핸들러 함수.
//  - 선택된 축으로 지정한 신호검출 위치캡쳐 구동을 시작합니다.
//  - 선택한 신호의 Edge 신호가 검출되지않으면 지정한 속도로 무한 구동합니다.
//  ※ [CAUTION] End Limit 신호는 Edge 검출이 되지 않음에 유의 바랍니다.
// --------------------------------------------------------------------------
procedure TForm1.btnCaptureMoveClick(Sender: TObject);
var
    strData : string;
    dwRetCode : DWORD;
    lDetectSig, lSignalEdge, lTarget, lStopMethod : longint;
    dMoveVel, dMoveAcc : double;
begin
    dMoveVel := StrToFloat(edtMoveVel.Text);
    dMoveAcc := StrToFloat(edtMoveAcc.Text);

    lDetectSig := ConvertComboToAxm(cboDetectSig);
    lSignalEdge := ConvertComboToAxm(cboSignalEdge);
    lTarget := ConvertComboToAxm(cboCaptureTarget);
    lStopMethod := ConvertComboToAxm(cboStopMethod);

    //++ 지정 축에 설정된 신호를 검출하고 신호가 검출될 때 그 위치를 저장하기 위해 구동하는 함수입니다.
    dwRetCode := AxmMoveSignalCapture(m_lAxisNo, dMoveVel, dMoveAcc, lDetectSig, lSignalEdge, lTarget, lStopMethod);
    if (dwRetCode <> AXT_RT_SUCCESS) then
    begin
        strData := Format('AxmMoveSignalCapture return error[Code:%.4d]', [dwRetCode]);
        ShowMessage(strData);
    end;
end;

// ++ =======================================================================
// >> btnMoveStopClick() : "Move Stop"버튼 클릭시 호출되는 핸들러 함수.
//  - 지정한 축의 신호검출 구동을 감속정지 합니다.
// --------------------------------------------------------------------------
procedure TForm1.btnMoveStopClick(Sender: TObject);
begin
    AxmMoveSStop(m_lAxisNo);
end;

// ++ =======================================================================
// >> btnGetPosClick() : "Get Position"버튼 클릭시 호출되는 핸들러 함수.
//  - 지정한 축의 신호검출 구동시 캡쳐한 위치값을 확인합니다.
// --------------------------------------------------------------------------
procedure TForm1.btnGetPosClick(Sender: TObject);
var
    dwRetCode : DWORD;
    dCapturePos : double;
begin
    //++ 'AxmMoveSignalCapture' 함수로 구동중 지정한 신호가 검출되어 저장된 위치값을 확인하는 함수입니다.
	  // ※ [CAUTION] 함수 실행 결과가 "AXT_RT_SUCCESS"일때 저장된 위치가 유효하며, 이 함수를 한번 실행하면
	  //    저장된 위치값은 초기화됩니다.
    dwRetCode := AxmMoveGetCapturePos(m_lAxisNo, @dCapturePos);
    if (dwRetCode = AXT_RT_SUCCESS) then
        stcCapturePos.Text := Format('%*.*f', [1, 3, dCapturePos])
    else
        stcCapturePos.Text := 'xxx.xxx';
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
    dwOnOff : DWORD;
begin
    if (m_lAxisCount < 1) then
    begin
        Result := false;
        exit;
    end;

    //++ 지정한 축의 서보온 상태를 반환합니다.
    AxmSignalIsServoOn(m_lAxisNo, @dwOnOff);
    chkServoOn.Checked := iif(dwOnOff);

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

end.
