unit OverrideVelocityAtPos;
// OverrideVelocityAtPos.pas : implementation file
//
// **************************************************************************
// >> [일자]: 2015.12.11
// >> [개요]: 이 예제는 지정한 위치에서 속도 오버라이드하는 함수들의 사용법을
//    익히고 여러 위치에서 다중 속도 오버라이드를 확인할 수 있는 예제입니다.
// >> [중요]: 속도오버라이드 제약사항
//     1) 속도오버라이드는 가속/감속 중에는 반영되지 않습니다.
//     2) 등속구간 진입시 가속/감속 중에 변경한 속도값이 반영됩니다.
//     3) AxmOverrideVelAtMultiPos 함수를 이용해서 오버라이드 구동중에는 별도의
//        속도 오버라이드 함수를 호출하여 속도를 변경하면 지정한 오버라이드
//        위치에서 지정한 속도가 되도록 하는 기능은 보장 할 수 없습니다.
// **************************************************************************

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, ExtCtrls, StdCtrls,
  AXL, AXM, AXHS;

const
    MAX_OVER_MULTI_POS = 50;
    FW_NORMAL = 400;
    WIDTH_PER_LIST_WORD = 18;
type
    TArrOver = array[0..(MAX_OVER_MULTI_POS - 1)] of double;
    PArrOver = ^TArrOver;

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
    Label17: TLabel;
    Label18: TLabel;
    edtMovePos: TEdit;
    edtMoveVel: TEdit;
    edtMoveAcc: TEdit;
    edtMoveDec: TEdit;
    rdoAbs: TRadioButton;
    rdoRel: TRadioButton;
    btnOverVelAtPos: TButton;
    btnStop: TButton;
    OpenDialog1: TOpenDialog;
    m_timer: TTimer;
    Shape1: TShape;
    Label3: TLabel;
    edtOverPos: TEdit;
    Label6: TLabel;
    Label14: TLabel;
    edtOverVel: TEdit;
    Label19: TLabel;
    Label20: TLabel;
    cboCampTarget: TComboBox;
    Shape2: TShape;
    Label21: TLabel;
    cboOverMode: TComboBox;
    lstOverData: TListBox;
    Label22: TLabel;
    edtOverPosAdd: TEdit;
    edtOverVelAdd: TEdit;
    Label23: TLabel;
    btnOverVelAtMPos: TButton;
    btnOverDataClr: TButton;
    btnOverDataAdd: TButton;
    chkOverMulti: TCheckBox;
    procedure FormCreate(Sender: TObject);
    procedure FormDestroy(Sender: TObject);
    Function InitLibrary() : Boolean; stdcall;
    Function AddAxisInfo() : Boolean; stdcall;
    Function InitControl() : Boolean; stdcall;
    Function UpdateState() : Boolean; stdcall;
    Function ConvertAxmToCombo(pCboItem : TComboBox; dwCurData : DWORD) : DWORD;
    Function ConvertComboToAxm(pCboItem : TComboBox) : DWORD;
    Function ConvertListBoxToArray(pLstItem: TListBox; dpOverPos: PArrOver; dpOverVel: PArrOver) : longint;
    procedure cboSelAxisChange(Sender: TObject);
    procedure btnLoadFileClick(Sender: TObject);
    procedure btnPosSetClick(Sender: TObject);
    procedure chkServoOnClick(Sender: TObject);
    procedure rdoAbsClick(Sender: TObject);
    procedure rdoRelClick(Sender: TObject);
    procedure chkOverMultiClick(Sender: TObject);
    procedure btnOverVelAtPosClick(Sender: TObject);
    procedure btnOverVelAtMPosClick(Sender: TObject);
    procedure btnStopClick(Sender: TObject);
    procedure btnOverDataAddClick(Sender: TObject);
    procedure lstOverDataDblClick(Sender: TObject);
    procedure btnOverDataClrClick(Sender: TObject);
    procedure m_timerTimer(Sender: TObject);
  private
    { Private declarations }
    m_lAxisNo, m_lAxisCount, m_dwModuleID, m_lstCount : integer;
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
    m_lstCount := 0;

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
    SetWindowLong(edtMoveDec.Handle, GWL_STYLE,
        GetWindowLong(edtMoveDec.Handle, GWL_STYLE) or ES_RIGHT);
    SetWindowLong(edtOverPos.Handle, GWL_STYLE,
        GetWindowLong(edtOverPos.Handle, GWL_STYLE) or ES_RIGHT);
    SetWindowLong(edtOverVel.Handle, GWL_STYLE,
        GetWindowLong(edtOverVel.Handle, GWL_STYLE) or ES_RIGHT);
    SetWindowLong(edtOverPosAdd.Handle, GWL_STYLE,
        GetWindowLong(edtOverPosAdd.Handle, GWL_STYLE) or ES_RIGHT);
    SetWindowLong(edtOverVelAdd.Handle, GWL_STYLE,
        GetWindowLong(edtOverVelAdd.Handle, GWL_STYLE) or ES_RIGHT);
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
// >> chkOverMultiClick() : "Override Vel At Multi Pos Use"버튼 클릭시 호출되는 핸들러 함수.
//  - 선택한 축에 오버라이드 할 함수의 종류를 설정합니다.
//  - 오버라이드 함수에 따라 필요한 인자들을 활성화/비활성화 시킵니다.
// --------------------------------------------------------------------------
procedure TForm1.chkOverMultiClick(Sender: TObject);
var
    bEnableMulti : boolean;
begin
    bEnableMulti := chkOverMulti.Checked;

    edtOverPos.Enabled := not bEnableMulti;
    edtOverVel.Enabled := not bEnableMulti;
    btnOverVelAtPos.Enabled := not bEnableMulti;

    cboOverMode.Enabled := bEnableMulti;
    lstOverData.Enabled := bEnableMulti;
    btnOverVelAtMPos.Enabled := bEnableMulti;
    btnOverDataAdd.Enabled := bEnableMulti;
    btnOverDataClr.Enabled := bEnableMulti;
    edtOverPosAdd.Enabled := bEnableMulti;
    edtOverVelAdd.Enabled := bEnableMulti;
end;

// ++ =======================================================================
// >> btnOverVelAtPosClick() : "Override At Pos"버튼 클릭시 호출되는 핸들러 함수.
//  - 선택한 축에 지정한 위치에서 정확하게 오버라이드하는 구동을 시작합니다.
// --------------------------------------------------------------------------
procedure TForm1.btnOverVelAtPosClick(Sender: TObject);
var
    strData : String;
    dwRetCode : DWORD;
    lCampTarget : longint;
    dMovePos, dMoveVel, dMoveAcc, dMoveDec, dOverPos, dOverVel : Double;
begin
    dMovePos := StrToFloat(edtMovePos.Text);
    dMoveVel := StrToFloat(edtMoveVel.Text);
    dMoveAcc := StrToFloat(edtMoveAcc.Text);
    dMoveDec := StrToFloat(edtMoveDec.Text);
    dOverPos := StrToFloat(edtOverPos.Text);
    dOverVel := StrToFloat(edtOverVel.Text);

    lCampTarget := ConvertComboToAxm(cboCampTarget);

    //++ 선택한 축에 모션 구동중 지정한 위치에서 속도 오버라이드 하는 구동을 시작합니다.
    dwRetCode := AxmOverrideVelAtPos(m_lAxisNo, dMovePos, dMoveVel, dMoveAcc,
            dMoveDec, dOverPos, dOverVel, lCampTarget);
    if (dwRetCode <> AXT_RT_SUCCESS) then
    begin
        strData := Format('AxmOverrideVelAtPos return error[Code:%.4d]', [dwRetCode]);
        ShowMessage(strData);
    end;
end;

// ++ =======================================================================
// >> btnOverVelAtMPosClick() : "Multi At Pos"버튼 클릭시 호출되는 핸들러 함수.
//  - 선택한 축에 여러개의 지정한 위치에서 정확하게 오버라이드하는 구동을 시작합니다.
//  - 실제 오버라이드 함수의 위치지정 갯수 제한은 없으나 예제 구현 편의상 50개로
//    제한하였습니다.
// --------------------------------------------------------------------------
procedure TForm1.btnOverVelAtMPosClick(Sender: TObject);
var
    strData : String;
    dwRetCode : DWORD;
    iArraySize, i : integer;
    lCampTarget, lOverMode : longint;
    dMovePos, dMoveVel, dMoveAcc, dMoveDec : Double;
    daOverPos, daOverVel : array[0..(MAX_OVER_MULTI_POS - 1)] of double;
begin
    dMovePos := StrToFloat(edtMovePos.Text);
    dMoveVel := StrToFloat(edtMoveVel.Text);
    dMoveAcc := StrToFloat(edtMoveAcc.Text);
    dMoveDec := StrToFloat(edtMoveDec.Text);

    for i := 0 to (MAX_OVER_MULTI_POS - 1) do
    begin
        daOverPos[i] := 0.0;
        daOverVel[i] := 0.0;
    end;

    lCampTarget := ConvertComboToAxm(cboCampTarget);
    lOverMode := ConvertComboToAxm(cboOverMode);
    iArraySize := ConvertListBoxToArray(lstOverData, @daOverPos, @daOverVel);

    //++ 선택한 축에 모션 구동중 여러개의 지정한 위치에서 속도 오버라이드 하는 구동을 시작합니다.
	  //   함수 사용시 진행 방향 기준으로 먼저 도달하는 포지션부터 배열에 입력이 되어야 합니다.
    //   dwOverrideMode : (0)OVERRIDE_POS_START 지정한 위치에서 지정한 속도로 오버라이드 시작함
    //                  : (1)OVERRIDE_POS_END 지정한 위치에서 지정한 속도가 되도록 미리 오버라이드 시작함
    dwRetCode := AxmOverrideVelAtMultiPos(m_lAxisNo, dMovePos, dMoveVel,
          dMoveAcc, dMoveDec, iArraySize, @daOverPos, @daOverVel,
          lCampTarget, lOverMode);
    if (dwRetCode <> AXT_RT_SUCCESS) then
    begin
        strData := Format('AxmOverrideVelAtMultiPos return error[Code:%.4d]', [dwRetCode]);
        ShowMessage(strData);
    end;
end;

// ++ =======================================================================
// >> btnStopClick() : "Move Stop"버튼 클릭시 호출되는 핸들러 함수.
//  - 선택한 축에 구동정지 함수를 호출하여 구동을 감속정지합니다.
// --------------------------------------------------------------------------
procedure TForm1.btnStopClick(Sender: TObject);
begin
    //++ 지정한 축의 구동을 감속정지합니다.
    AxmMoveSStop(m_lAxisNo);
end;

// ++ =======================================================================
// >> btnOverDataAddClick() : "<< Add Item"버튼 클릭시 호출되는 핸들러 함수.
//  - 속도 오버라이드 정보를 ListBox에 등록합니다.
// --------------------------------------------------------------------------
procedure TForm1.btnOverDataAddClick(Sender: TObject);
var
    strData : string;
    dOverPos, dOverVel : double;
begin
    dOverPos := StrToFloat(edtOverPosAdd.Text);
    dOverVel := StrToFloat(edtOverVelAdd.Text);

    strData := Format('%20.3f, ', [dOverPos]);
    strData := strData + Format('%20.3f', [dOverVel]);
    m_lstCount := m_lstCount + 1;
    lstOverData.AddItem(strData, TObject(m_lstCount));
end;

// ++ =======================================================================
// >> lstOverDataDblClick() : ListBox 콘트롤 마우스 더블클릭시 호출되는 핸들러 함수.
//  - 등록된 속도 오버라이드 정보중 선택된 Item을 지울때 호출됩니다.
//  - List Box 콘트롤에서 마우스 포인트를 삭제할 Item 으로 이동한 후 마우스
//    왼쪽 버튼을 더블클릭하면 해당 Item이 선택 삭제됩니다.
// --------------------------------------------------------------------------
procedure TForm1.lstOverDataDblClick(Sender: TObject);
var
    nSelectedIndex : integer;
begin
    nSelectedIndex := lstOverData.ItemIndex;
    lstOverData.Items.Delete(nSelectedIndex);
end;

// ++ =======================================================================
// >> OnDblclkLstOverData() : "All Clear Item"버튼 클릭시 호출되는 핸들러 함수.
//  - 등록된 오버라이드 데이타를 모두 지웁니다.
// --------------------------------------------------------------------------
procedure TForm1.btnOverDataClrClick(Sender: TObject);
begin
    lstOverData.Items.Clear();
end;

// ++ =======================================================================
// >> OnTimer(...) : 타이머 이벤트 핸들러 함수.
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
begin
    if (m_lAxisCount < 1) then
    begin
        Result := false;
        exit;
    end;

    dwAbsRelMode := POS_ABS_MODE;
    dwOnOff := 0;

    //++ 지정한 축의 서보온 상태를 반환합니다.
    AxmSignalIsServoOn(m_lAxisNo, @dwOnOff);
    chkServoOn.Checked := iif(dwOnOff);

    //++ 지정한 축의 구동 좌표계 설정값을 확인합니다.
    AxmMotGetAbsRelMode(m_lAxisNo, @dwAbsRelMode);
    if (dwAbsRelMode = POS_ABS_MODE) then
        rdoAbs.Checked := true
    else
        rdoRel.Checked := true;

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
// >> ConvertListBoxToArray(...) : 지정한 콘트롤에 설정되어 있는 텍스트를
//    오버라이드 정보값으로  변환하여 반환하는 함수.
//  - ListBox 콘트롤에 설정된 텍스트를 두개의 오버라이드 정보값으로 변환하여
//    코드를 간결하게 구현하였습니다.
//  - 실제 오버라이드 함수의 위치지정 갯수 제한은 없으나 예제구현 편의상 50개로
//    제한하였습니다.
// --------------------------------------------------------------------------
Function TForm1.ConvertListBoxToArray(pLstItem: TListBox; dpOverPos: PArrOver; dpOverVel: PArrOver) : longint;
var
    strData, strOverPos, strOverVel : string;
    nSection, nLength : integer;
    lArraySize, lCount : longint;
begin
    if ((pLstItem = nil) or (dpOverPos = nil) or (dpOverVel = nil)) then
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
        if (lCount = MAX_OVER_MULTI_POS) then
        begin
            lArraySize := MAX_OVER_MULTI_POS;
            break;
        end;
        strData := pLstItem.Items.ValueFromIndex[lCount];

        nLength := Length(strData);
        nSection := Pos(',', strData);
        strOverPos := copy(strData, 0, nSection - 1);
        strOverVel := copy(strData, nSection + 1, (nLength - nSection));
        strOverPos := Trim(strOverPos);
        strOverVel := Trim(strOverVel);
        dpOverPos[lCount] := StrToFloat(strOverPos);
        dpOverVel[lCount] := StrToFloat(strOverVel);
    end;

    Result := lArraySize;
end;

end.
