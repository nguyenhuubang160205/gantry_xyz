unit MoveMultiAxes;
// MoveMultiAxes.pas : implementation file
//
// **************************************************************************
// >> [일자]: 2015.12.10
// >> [개요]: 이 예제는 다축구동 함수들의 사용법을 익히고 각 함수들의 인자값을
//    변경하면서 구동해 보는 예제입니다.
// >> [중요]: 다축 구동함수들로 구동중 포함된 축중 한축만 정지해도 다른축들이
//    구동을 정지하게 됩니다.
// >> [중요]: 일정한 거리 비율을 유지하는 다축조그 구동방법
//     1) AxmMoveStartLineVel 함수의 dDis값에 각 축의 거리 비율을 설정합니다.
//     2) dDis[4] = {10.0, 20.0, 30.0, 40.0}으로 설정하였을 경우 0축이 10.0에
//        도달했을 때 1, 2, 3축은 20.0, 30.0, 40.0의 위치에 도달하게 됩니다.
// **************************************************************************

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, ExtCtrls, StdCtrls,
  AXL, AXM, AXHS;

const
    MAX_MULTI_MOVE_AXIS = 4;

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
    stcCmdPos00: TEdit;
    stcActPos00: TEdit;
    stcCmdVel00: TEdit;
    btnPosClear: TButton;
    chkServoOn: TCheckBox;
    OpenDialog1: TOpenDialog;
    m_timer: TTimer;
    stcCmdPos01: TEdit;
    stcCmdPos02: TEdit;
    stcCmdPos03: TEdit;
    chkAxis00: TCheckBox;
    chkAxis01: TCheckBox;
    chkAxis02: TCheckBox;
    chkAxis03: TCheckBox;
    stcActPos01: TEdit;
    stcActPos02: TEdit;
    stcActPos03: TEdit;
    stcCmdVel01: TEdit;
    stcCmdVel02: TEdit;
    stcCmdVel03: TEdit;
    GroupBox3: TGroupBox;
    Label2: TLabel;
    Label3: TLabel;
    Label4: TLabel;
    edtMoveVel00: TEdit;
    edtMoveAcc00: TEdit;
    edtMoveDec00: TEdit;
    btnPosMove: TButton;
    chkMoveBlock: TCheckBox;
    edtMoveVel01: TEdit;
    edtMoveVel02: TEdit;
    edtMoveVel03: TEdit;
    edtMoveAcc01: TEdit;
    edtMoveAcc02: TEdit;
    edtMoveAcc03: TEdit;
    edtMoveDec01: TEdit;
    edtMoveDec02: TEdit;
    edtMoveDec03: TEdit;
    Label5: TLabel;
    edtMovePos00: TEdit;
    edtMovePos01: TEdit;
    edtMovePos02: TEdit;
    edtMovePos03: TEdit;
    btnPosStop: TButton;
    GroupBox4: TGroupBox;
    Label6: TLabel;
    Label7: TLabel;
    Label11: TLabel;
    edtJogVel00: TEdit;
    edtJogAcc00: TEdit;
    edtJogDec00: TEdit;
    btnJogP: TButton;
    edtJogVel01: TEdit;
    edtJogVel02: TEdit;
    edtJogVel03: TEdit;
    edtJogAcc01: TEdit;
    edtJogAcc02: TEdit;
    edtJogAcc03: TEdit;
    edtJogDec01: TEdit;
    edtJogDec02: TEdit;
    edtJogDec03: TEdit;
    btnJogN: TButton;
    GroupBox5: TGroupBox;
    Label12: TLabel;
    Label13: TLabel;
    Label14: TLabel;
    edtLinePos00: TEdit;
    edtLineVel: TEdit;
    edtLineAcc: TEdit;
    btnLineP: TButton;
    edtLinePos01: TEdit;
    edtLinePos02: TEdit;
    edtLinePos03: TEdit;
    edtLineDec: TEdit;
    btnLineN: TButton;
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
    procedure chkAxis00Click(Sender: TObject);
    procedure chkAxis01Click(Sender: TObject);
    procedure chkAxis02Click(Sender: TObject);
    procedure chkAxis03Click(Sender: TObject);
    procedure btnPosClearClick(Sender: TObject);
    procedure chkServoOnClick(Sender: TObject);
    procedure btnPosMoveClick(Sender: TObject);
    procedure btnPosStopClick(Sender: TObject);
    procedure btnJogPMouseDown(Sender: TObject; Button: TMouseButton;
      Shift: TShiftState; X, Y: Integer);
    procedure btnJogNMouseDown(Sender: TObject; Button: TMouseButton;
      Shift: TShiftState; X, Y: Integer);
    procedure btnLinePMouseDown(Sender: TObject; Button: TMouseButton;
      Shift: TShiftState; X, Y: Integer);
    procedure btnLineNMouseDown(Sender: TObject; Button: TMouseButton;
      Shift: TShiftState; X, Y: Integer);
    procedure btnJogPMouseUp(Sender: TObject; Button: TMouseButton;
      Shift: TShiftState; X, Y: Integer);
    procedure btnJogNMouseUp(Sender: TObject; Button: TMouseButton;
      Shift: TShiftState; X, Y: Integer);
    procedure btnLinePMouseUp(Sender: TObject; Button: TMouseButton;
      Shift: TShiftState; X, Y: Integer);
    procedure btnLineNMouseUp(Sender: TObject; Button: TMouseButton;
      Shift: TShiftState; X, Y: Integer);
    procedure m_timerTimer(Sender: TObject);
  private
    { Private declarations }
    m_lAxisNo, m_lAxisCount, m_dwModuleID, m_lMoveMultiAxesCount : integer;
    m_dOldCmdPos : array[0..(MAX_MULTI_MOVE_AXIS - 1)] of Double;
    m_dOldActPos : array[0..(MAX_MULTI_MOVE_AXIS - 1)] of Double;
    m_dOldCmdVel : array[0..(MAX_MULTI_MOVE_AXIS - 1)] of Double;
    m_lMoveMultiAxes : array[0..(MAX_MULTI_MOVE_AXIS - 1)] of integer;

    m_stcCmdPos : array[0..(MAX_MULTI_MOVE_AXIS - 1)] of TEdit;
    m_stcActPos : array[0..(MAX_MULTI_MOVE_AXIS - 1)] of TEdit;
    m_stcCmdVel : array[0..(MAX_MULTI_MOVE_AXIS - 1)] of TEdit;
    m_chkMoveMultiAxes : array[0..(MAX_MULTI_MOVE_AXIS - 1)] of TCheckBox;
    m_edtMovePos : array[0..(MAX_MULTI_MOVE_AXIS - 1)] of TEdit;
    m_edtMoveVel : array[0..(MAX_MULTI_MOVE_AXIS - 1)] of TEdit;
    m_edtMoveAcc : array[0..(MAX_MULTI_MOVE_AXIS - 1)] of TEdit;
    m_edtMoveDec : array[0..(MAX_MULTI_MOVE_AXIS - 1)] of TEdit;
    m_edtJogVel : array[0..(MAX_MULTI_MOVE_AXIS - 1)] of TEdit;
    m_edtJogAcc : array[0..(MAX_MULTI_MOVE_AXIS - 1)] of TEdit;
    m_edtJogDec : array[0..(MAX_MULTI_MOVE_AXIS - 1)] of TEdit;
    m_edtLinePos : array[0..(MAX_MULTI_MOVE_AXIS - 1)] of TEdit;
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
var
    i : integer;
begin
    for i := 0 to (MAX_MULTI_MOVE_AXIS - 1) do
    begin
        m_lMoveMultiAxes[i] := -1;
        m_dOldCmdPos[i] := 0.0;
        m_dOldActPos[i] := 0.0;
        m_dOldCmdVel[i] := 0.0;
    end;

    m_stcCmdPos[0] := stcCmdPos00;
    m_stcCmdPos[1] := stcCmdPos01;
    m_stcCmdPos[2] := stcCmdPos02;
    m_stcCmdPos[3] := stcCmdPos03;

    m_stcActPos[0] := stcActPos00;
    m_stcActPos[1] := stcActPos01;
    m_stcActPos[2] := stcActPos02;
    m_stcActPos[3] := stcActPos03;

    m_stcCmdVel[0] := stcCmdVel00;
    m_stcCmdVel[1] := stcCmdVel01;
    m_stcCmdVel[2] := stcCmdVel02;
    m_stcCmdVel[3] := stcCmdVel03;

    m_chkMoveMultiAxes[0] := chkAxis00;
    m_chkMoveMultiAxes[1] := chkAxis01;
    m_chkMoveMultiAxes[2] := chkAxis02;
    m_chkMoveMultiAxes[3] := chkAxis03;

    m_edtMovePos[0] := edtMovePos00;
    m_edtMovePos[1] := edtMovePos01;
    m_edtMovePos[2] := edtMovePos02;
    m_edtMovePos[3] := edtMovePos03;

    m_edtMoveVel[0] := edtMoveVel00;
    m_edtMoveVel[1] := edtMoveVel01;
    m_edtMoveVel[2] := edtMoveVel02;
    m_edtMoveVel[3] := edtMoveVel03;

    m_edtMoveAcc[0] := edtMoveAcc00;
    m_edtMoveAcc[1] := edtMoveAcc01;
    m_edtMoveAcc[2] := edtMoveAcc02;
    m_edtMoveAcc[3] := edtMoveAcc03;

    m_edtMoveDec[0] := edtMoveDec00;
    m_edtMoveDec[1] := edtMoveDec01;
    m_edtMoveDec[2] := edtMoveDec02;
    m_edtMoveDec[3] := edtMoveDec03;

    m_edtJogVel[0] := edtJogVel00;
    m_edtJogVel[1] := edtJogVel01;
    m_edtJogVel[2] := edtJogVel02;
    m_edtJogVel[3] := edtJogVel03;

    m_edtJogAcc[0] := edtJogAcc00;
    m_edtJogAcc[1] := edtJogAcc01;
    m_edtJogAcc[2] := edtJogAcc02;
    m_edtJogAcc[3] := edtJogAcc03;

    m_edtJogDec[0] := edtJogDec00;
    m_edtJogDec[1] := edtJogDec01;
    m_edtJogDec[2] := edtJogDec02;
    m_edtJogDec[3] := edtJogDec03;

    m_edtLinePos[0] := edtLinePos00;
    m_edtLinePos[1] := edtLinePos01;
    m_edtLinePos[2] := edtLinePos02;
    m_edtLinePos[3] := edtLinePos03;

    // TEdit 컨트롤들의 값들을 오른쪽정렬로 설정
    SetWindowLong(stcCmdPos00.Handle, GWL_STYLE,
        GetWindowLong(stcCmdPos00.Handle, GWL_STYLE) or ES_RIGHT);
    SetWindowLong(stcCmdPos01.Handle, GWL_STYLE,
        GetWindowLong(stcCmdPos01.Handle, GWL_STYLE) or ES_RIGHT);
    SetWindowLong(stcCmdPos02.Handle, GWL_STYLE,
        GetWindowLong(stcCmdPos02.Handle, GWL_STYLE) or ES_RIGHT);
    SetWindowLong(stcCmdPos03.Handle, GWL_STYLE,
        GetWindowLong(stcCmdPos03.Handle, GWL_STYLE) or ES_RIGHT);
    SetWindowLong(stcActPos00.Handle, GWL_STYLE,
        GetWindowLong(stcActPos00.Handle, GWL_STYLE) or ES_RIGHT);
    SetWindowLong(stcActPos01.Handle, GWL_STYLE,
        GetWindowLong(stcActPos01.Handle, GWL_STYLE) or ES_RIGHT);
    SetWindowLong(stcActPos02.Handle, GWL_STYLE,
        GetWindowLong(stcActPos02.Handle, GWL_STYLE) or ES_RIGHT);
    SetWindowLong(stcActPos03.Handle, GWL_STYLE,
        GetWindowLong(stcActPos03.Handle, GWL_STYLE) or ES_RIGHT);
    SetWindowLong(stcCmdVel00.Handle, GWL_STYLE,
        GetWindowLong(stcCmdVel00.Handle, GWL_STYLE) or ES_RIGHT);
    SetWindowLong(stcCmdVel01.Handle, GWL_STYLE,
        GetWindowLong(stcCmdVel01.Handle, GWL_STYLE) or ES_RIGHT);
    SetWindowLong(stcCmdVel02.Handle, GWL_STYLE,
        GetWindowLong(stcCmdVel02.Handle, GWL_STYLE) or ES_RIGHT);
    SetWindowLong(stcCmdVel03.Handle, GWL_STYLE,
        GetWindowLong(stcCmdVel03.Handle, GWL_STYLE) or ES_RIGHT);

    SetWindowLong(edtMovePos00.Handle, GWL_STYLE,
        GetWindowLong(edtMovePos00.Handle, GWL_STYLE) or ES_RIGHT);
    SetWindowLong(edtMovePos01.Handle, GWL_STYLE,
        GetWindowLong(edtMovePos01.Handle, GWL_STYLE) or ES_RIGHT);
    SetWindowLong(edtMovePos02.Handle, GWL_STYLE,
        GetWindowLong(edtMovePos02.Handle, GWL_STYLE) or ES_RIGHT);
    SetWindowLong(edtMovePos03.Handle, GWL_STYLE,
        GetWindowLong(edtMovePos03.Handle, GWL_STYLE) or ES_RIGHT);
    SetWindowLong(edtMoveVel00.Handle, GWL_STYLE,
        GetWindowLong(edtMoveVel00.Handle, GWL_STYLE) or ES_RIGHT);
    SetWindowLong(edtMoveVel01.Handle, GWL_STYLE,
        GetWindowLong(edtMoveVel01.Handle, GWL_STYLE) or ES_RIGHT);
    SetWindowLong(edtMoveVel02.Handle, GWL_STYLE,
        GetWindowLong(edtMoveVel02.Handle, GWL_STYLE) or ES_RIGHT);
    SetWindowLong(edtMoveVel03.Handle, GWL_STYLE,
        GetWindowLong(edtMoveVel03.Handle, GWL_STYLE) or ES_RIGHT);
    SetWindowLong(edtMoveAcc00.Handle, GWL_STYLE,
        GetWindowLong(edtMoveAcc00.Handle, GWL_STYLE) or ES_RIGHT);
    SetWindowLong(edtMoveAcc01.Handle, GWL_STYLE,
        GetWindowLong(edtMoveAcc01.Handle, GWL_STYLE) or ES_RIGHT);
    SetWindowLong(edtMoveAcc02.Handle, GWL_STYLE,
        GetWindowLong(edtMoveAcc02.Handle, GWL_STYLE) or ES_RIGHT);
    SetWindowLong(edtMoveAcc03.Handle, GWL_STYLE,
        GetWindowLong(edtMoveAcc03.Handle, GWL_STYLE) or ES_RIGHT);
    SetWindowLong(edtMoveDec00.Handle, GWL_STYLE,
        GetWindowLong(edtMoveDec00.Handle, GWL_STYLE) or ES_RIGHT);
    SetWindowLong(edtMoveDec01.Handle, GWL_STYLE,
        GetWindowLong(edtMoveDec01.Handle, GWL_STYLE) or ES_RIGHT);
    SetWindowLong(edtMoveDec02.Handle, GWL_STYLE,
        GetWindowLong(edtMoveDec02.Handle, GWL_STYLE) or ES_RIGHT);
    SetWindowLong(edtMoveDec03.Handle, GWL_STYLE,
        GetWindowLong(edtMoveDec03.Handle, GWL_STYLE) or ES_RIGHT);

    SetWindowLong(edtJogVel00.Handle, GWL_STYLE,
        GetWindowLong(edtJogVel00.Handle, GWL_STYLE) or ES_RIGHT);
    SetWindowLong(edtJogVel01.Handle, GWL_STYLE,
        GetWindowLong(edtJogVel01.Handle, GWL_STYLE) or ES_RIGHT);
    SetWindowLong(edtJogVel02.Handle, GWL_STYLE,
        GetWindowLong(edtJogVel02.Handle, GWL_STYLE) or ES_RIGHT);
    SetWindowLong(edtJogVel03.Handle, GWL_STYLE,
        GetWindowLong(edtJogVel03.Handle, GWL_STYLE) or ES_RIGHT);
    SetWindowLong(edtJogAcc00.Handle, GWL_STYLE,
        GetWindowLong(edtJogAcc00.Handle, GWL_STYLE) or ES_RIGHT);
    SetWindowLong(edtJogAcc01.Handle, GWL_STYLE,
        GetWindowLong(edtJogAcc01.Handle, GWL_STYLE) or ES_RIGHT);
    SetWindowLong(edtJogAcc02.Handle, GWL_STYLE,
        GetWindowLong(edtJogAcc02.Handle, GWL_STYLE) or ES_RIGHT);
    SetWindowLong(edtJogAcc03.Handle, GWL_STYLE,
        GetWindowLong(edtJogAcc03.Handle, GWL_STYLE) or ES_RIGHT);
    SetWindowLong(edtJogDec00.Handle, GWL_STYLE,
        GetWindowLong(edtJogDec00.Handle, GWL_STYLE) or ES_RIGHT);
    SetWindowLong(edtJogDec01.Handle, GWL_STYLE,
        GetWindowLong(edtJogDec01.Handle, GWL_STYLE) or ES_RIGHT);
    SetWindowLong(edtJogDec02.Handle, GWL_STYLE,
        GetWindowLong(edtJogDec02.Handle, GWL_STYLE) or ES_RIGHT);
    SetWindowLong(edtJogDec03.Handle, GWL_STYLE,
        GetWindowLong(edtJogDec03.Handle, GWL_STYLE) or ES_RIGHT);

    SetWindowLong(edtLinePos00.Handle, GWL_STYLE,
        GetWindowLong(edtLinePos00.Handle, GWL_STYLE) or ES_RIGHT);
    SetWindowLong(edtLinePos01.Handle, GWL_STYLE,
        GetWindowLong(edtLinePos01.Handle, GWL_STYLE) or ES_RIGHT);
    SetWindowLong(edtLinePos02.Handle, GWL_STYLE,
        GetWindowLong(edtLinePos02.Handle, GWL_STYLE) or ES_RIGHT);
    SetWindowLong(edtLinePos03.Handle, GWL_STYLE,
        GetWindowLong(edtLinePos03.Handle, GWL_STYLE) or ES_RIGHT);
    SetWindowLong(edtLineVel.Handle, GWL_STYLE,
        GetWindowLong(edtLineVel.Handle, GWL_STYLE) or ES_RIGHT);
    SetWindowLong(edtLineAcc.Handle, GWL_STYLE,
        GetWindowLong(edtLineVel.Handle, GWL_STYLE) or ES_RIGHT);
    SetWindowLong(edtLineDec.Handle, GWL_STYLE,
        GetWindowLong(edtLineDec.Handle, GWL_STYLE) or ES_RIGHT);

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
// >> chkAxis00Click(...) : 축 변경이 있을 때 호출되는 핸들러 함수.
//  - 축 번호 선택 체크버튼의 체크상태에 변화가 있을 때 보간 사용축 갯수 및 축
//    번호 배열값을 재할당합니다.
//  - IDC_CHK_AXIS_00 ~ IDC_CHK_AXIS_03 버튼의 클릭이벤트 발생시 호출됩니다.
// --------------------------------------------------------------------------
procedure TForm1.chkAxis00Click(Sender: TObject);
begin
    UpdateState();
end;

procedure TForm1.chkAxis01Click(Sender: TObject);
begin
    UpdateState();
end;

procedure TForm1.chkAxis02Click(Sender: TObject);
begin
    UpdateState();
end;

procedure TForm1.chkAxis03Click(Sender: TObject);
begin
    UpdateState();
end;

// ++ =======================================================================
// >> btnPosClearClick() : "Clear"버튼 클릭시 호출되는 핸들러 함수.
//  - 선택된 축의 위치정보를 0.0으로 설정합니다.
//  - AxmStatusSetPosMatch함수는 AxmStatusSetCmdPos, AxmStatusSetActPos 함수를
//    사용하는것과 동일한 효과를 냅니다.
// --------------------------------------------------------------------------
procedure TForm1.btnPosClearClick(Sender: TObject);
var
    lCount : Longint;
begin
    for lCount := 0 to (m_lMoveMultiAxesCount - 1) do
    begin
        AxmStatusSetPosMatch(m_lMoveMultiAxes[lCount], 0.0);
    end;
    AxmStatusSetPosMatch(m_lAxisNo, 0.0);
end;

// ++ =======================================================================
// >> OnChkServoOn() : "Servo On"버튼 클릭시 호출되는 핸들러 함수.
//  - 선택된 보간축들을 체크버튼의 상태에 따라 서보 On/Off 합니다.
// --------------------------------------------------------------------------
procedure TForm1.chkServoOnClick(Sender: TObject);
var
    lCount : Longint;
    dwIsChecked : DWORD;
begin
    for lCount := 0 to (m_lMoveMultiAxesCount - 1) do
    begin
        dwIsChecked := iif(chkServoOn.Checked, 1, 0);
        AxmSignalServoOn(m_lMoveMultiAxes[lCount], dwIsChecked);
    end;
end;

// ++ =======================================================================
// >> btnPosMoveClick() : "Move"버튼 클릭시 호출되는 핸들러 함수.
//  - 선택한 축들을 지정한 거리(또는 위치)/속도/가속도/감속도로 모션구동합니다.
// --------------------------------------------------------------------------
procedure TForm1.btnPosMoveClick(Sender: TObject);
var
    strData : string;
    dwRetCode : DWORD;
    lCount, lArrayIndex : longint;
    dMultiPos, dMultiVel, dMultiAcc, dMultiDec : array[0..(MAX_MULTI_MOVE_AXIS - 1)] of Double;
begin
    lArrayIndex := 0;
    for lCount := 0 to (MAX_MULTI_MOVE_AXIS - 1) do
    begin
        if (m_chkMoveMultiAxes[lCount].Checked = true) then
        begin
            dMultiPos[lArrayIndex] := StrToFloat(m_edtMovePos[lCount].Text);
            dMultiVel[lArrayIndex] := StrToFloat(m_edtMoveVel[lCount].Text);
            dMultiAcc[lArrayIndex] := StrToFloat(m_edtMoveAcc[lCount].Text);
            dMultiDec[lArrayIndex] := StrToFloat(m_edtMoveDec[lCount].Text);
            lArrayIndex := lArrayIndex + 1;
        end;
    end;

    if (chkMoveBlock.Checked = true) then
    begin
        //++ 지정한 축들을 지정한 거리(또는 위치)/속도/가속도/감속도로 각각 모션구동하고 모션이 종료되면 함수를 빠져나옵니다.
        dwRetCode := AxmMoveMultiPos(m_lMoveMultiAxesCount, @m_lMoveMultiAxes, @dMultiPos, @dMultiVel, @dMultiAcc, @dMultiDec);
        if (dwRetCode <> AXT_RT_SUCCESS) then
        begin
            strData := Format('AxmMoveMultiPos return error[Code:%.4d]', [dwRetCode]);
           ShowMessage(strData);
        end
    end
    else
    begin
        //++ 지정한 축들을 지정한 거리(또는 위치)/속도/가속도/감속도로 각각 모션구동하고 모션 종료여부와 상관없이 함수를 빠져나옵니다.
        dwRetCode := AxmMoveStartMultiPos(m_lMoveMultiAxesCount, @m_lMoveMultiAxes, @dMultiPos, @dMultiVel, @dMultiAcc, @dMultiDec);
        if (dwRetCode <> AXT_RT_SUCCESS) then
        begin
            strData := Format('AxmMoveStartMultiPos return error[Code:%.4d]', [dwRetCode]);
           ShowMessage(strData);
        end;
    end;
end;

// ++ =======================================================================
// >> btnPosStopClick() : "Stop"버튼 클릭시 호출되는 핸들러 함수.
//  - 선택한 축들로 구동정지 함수를 호출하여 구동을 감속정지합니다.
// ※ [CAUTION] 다축 구동함수들로 구동시 포함된 축중 한축만 정지해도 다른축들이
//    구동을 정지하게 됩니다.
// --------------------------------------------------------------------------
procedure TForm1.btnPosStopClick(Sender: TObject);
var
    lCount : Longint;
begin
    for lCount := 0 to (m_lMoveMultiAxesCount - 1) do
    begin
        AxmMoveSStop(m_lMoveMultiAxes[lCount]);
    end;
end;

// ++ =======================================================================
// >> btnJogPMouseDown(...) : "Jog(+/-)"버튼 Down시 호출되는 핸들러 함수.
//  - "CJogButton" 버튼 클래스에서 버튼 클릭시 호출되는 WM_LBUTTONDOWN 이벤트를
//    받아 사용자 이벤트로 이 함수를 호출해 줍니다. 이 때 wParam을 통해 전달되는
//    콘트롤 ID로 Jog(+/-)버튼을 구분하게 됩니다.
//  - Jog버튼 Down시 다축구동 함수를 호출하여 Jog 구동을 시작합니다.
// --------------------------------------------------------------------------
procedure TForm1.btnJogPMouseDown(Sender: TObject; Button: TMouseButton;
  Shift: TShiftState; X, Y: Integer);
var
    dwRetCode : DWORD;
    lArrayIndex, lCount : longint;
    strData : string;
    dMultiVel, dMultiAcc, dMultiDec : array[0..(MAX_MULTI_MOVE_AXIS - 1)] of Double;
begin
    lArrayIndex := 0;
    for lCount := 0 to (MAX_MULTI_MOVE_AXIS - 1) do
    begin
        if (m_chkMoveMultiAxes[lCount].Checked = true) then
        begin
            dMultiVel[lArrayIndex] := abs(StrToFloat(m_edtJogVel[lCount].Text));
            dMultiAcc[lArrayIndex] := abs(StrToFloat(m_edtJogAcc[lCount].Text));
            dMultiDec[lArrayIndex] := abs(StrToFloat(m_edtJogDec[lCount].Text));
            lArrayIndex := lArrayIndex + 1;
        end;
    end;

    //++ 선택한 축들을 (+/-)방향으로 지정한 속도/가속도/감속도로 모션구동합니다.
    dwRetCode := AxmMoveStartMultiVel(m_lMoveMultiAxesCount, @m_lMoveMultiAxes, @dMultiVel, @dMultiAcc, @dMultiDec);
    if (dwRetCode <> AXT_RT_SUCCESS) then
    begin
        strData := Format('AxmMoveStartMultiVel return error[Code:%.4d]', [dwRetCode]);
        ShowMessage(strData);
    end;
end;

procedure TForm1.btnJogNMouseDown(Sender: TObject; Button: TMouseButton;
  Shift: TShiftState; X, Y: Integer);
var
    dwRetCode : DWORD;
    lArrayIndex, lCount : longint;
    strData : string;
    dMultiVel, dMultiAcc, dMultiDec : array[0..(MAX_MULTI_MOVE_AXIS - 1)] of Double;
begin
    lArrayIndex := 0;
    for lCount := 0 to (MAX_MULTI_MOVE_AXIS - 1) do
    begin
        if (m_chkMoveMultiAxes[lCount].Checked = true) then
        begin
            dMultiVel[lArrayIndex] := -abs(StrToFloat(m_edtJogVel[lCount].Text));
            dMultiAcc[lArrayIndex] := abs(StrToFloat(m_edtJogAcc[lCount].Text));
            dMultiDec[lArrayIndex] := abs(StrToFloat(m_edtJogDec[lCount].Text));
            lArrayIndex := lArrayIndex + 1;
        end;
    end;

    dwRetCode := AxmMoveStartMultiVel(m_lMoveMultiAxesCount, @m_lMoveMultiAxes, @dMultiVel, @dMultiAcc, @dMultiDec);
    if (dwRetCode <> AXT_RT_SUCCESS) then
    begin
        strData := Format('AxmMoveStartMultiVel return error[Code:%.4d]', [dwRetCode]);
        ShowMessage(strData);
    end;
end;

procedure TForm1.btnLinePMouseDown(Sender: TObject; Button: TMouseButton;
  Shift: TShiftState; X, Y: Integer);
var
    dwRetCode : DWORD;
    lArrayIndex, lCount : longint;
    strData : string;
    dLinePos : array[0..(MAX_MULTI_MOVE_AXIS - 1)] of Double;
    dLineVel, dLineAcc, dLineDec : double;
begin
    lArrayIndex := 0;
    for lCount := 0 to (MAX_MULTI_MOVE_AXIS - 1) do
    begin
        if (m_chkMoveMultiAxes[lCount].Checked = true) then
        begin
            dLinePos[lArrayIndex] := abs(StrToFloat(m_edtJogVel[lCount].Text));
            lArrayIndex := lArrayIndex + 1;
        end;
    end;

    dLineVel := abs(StrToFloat(edtLineVel.Text));
    dLineAcc := abs(StrToFloat(edtLineAcc.Text));
    dLineDec := abs(StrToFloat(edtLineDec.Text));

    //++ 선택한 축들을 (+/-)방향으로 지정한 위치 비율에따른 속도/가속도/감속도로 모션구동합니다.
    dwRetCode := AxmMoveStartLineVel(m_lMoveMultiAxesCount, @m_lMoveMultiAxes, @dLinePos, dLineVel, dLineAcc, dLineDec);
    if (dwRetCode <> AXT_RT_SUCCESS) then
    begin
        strData := Format('AxmMoveStartLineVel return error[Code:%.4d]', [dwRetCode]);
        ShowMessage(strData);
    end;
end;

procedure TForm1.btnLineNMouseDown(Sender: TObject; Button: TMouseButton;
  Shift: TShiftState; X, Y: Integer);
var
    dwRetCode : DWORD;
    lArrayIndex, lCount : longint;
    strData : string;
    dLinePos : array[0..(MAX_MULTI_MOVE_AXIS - 1)] of Double;
    dLineVel, dLineAcc, dLineDec : double;
begin
    lArrayIndex := 0;
    for lCount := 0 to (MAX_MULTI_MOVE_AXIS - 1) do
    begin
        if (m_chkMoveMultiAxes[lCount].Checked = true) then
        begin
            dLinePos[lArrayIndex] := -abs(StrToFloat(m_edtJogVel[lCount].Text));
            lArrayIndex := lArrayIndex + 1;
        end;
    end;

    dLineVel := abs(StrToFloat(edtLineVel.Text));
    dLineAcc := abs(StrToFloat(edtLineAcc.Text));
    dLineDec := abs(StrToFloat(edtLineDec.Text));

    dwRetCode := AxmMoveStartLineVel(m_lMoveMultiAxesCount, @m_lMoveMultiAxes, @dLinePos, dLineVel, dLineAcc, dLineDec);
    if (dwRetCode <> AXT_RT_SUCCESS) then
    begin
        strData := Format('AxmMoveStartLineVel return error[Code:%.4d]', [dwRetCode]);
        ShowMessage(strData);
    end;
end;

// ++ =======================================================================
// >> btnJogPMouseUp(...) : "Jog(+/-)"버튼 Up시 호출되는 핸들러 함수.
//  - "CJogButton" 버튼 클래스에서 버튼 클릭시 호출되는 WM_LBUTTONUP이벤트를
//    받아 사용자 이벤트로 이 함수를 호출해 줍니다. 이 때 wParam을 통해 전달되는
//    콘트롤 ID로 Jog(+/-)버튼을 구분하게 됩니다.
//  - Jog버튼 Up시 구동정지 함수를 호출하여 Jog 구동을 종료합니다.
// --------------------------------------------------------------------------
procedure TForm1.btnJogPMouseUp(Sender: TObject; Button: TMouseButton;
  Shift: TShiftState; X, Y: Integer);
begin
    btnPosStopClick(nil);
end;

procedure TForm1.btnJogNMouseUp(Sender: TObject; Button: TMouseButton;
  Shift: TShiftState; X, Y: Integer);
begin
    btnPosStopClick(nil);
end;

procedure TForm1.btnLinePMouseUp(Sender: TObject; Button: TMouseButton;
  Shift: TShiftState; X, Y: Integer);
begin
    btnPosStopClick(nil);
end;

procedure TForm1.btnLineNMouseUp(Sender: TObject; Button: TMouseButton;
  Shift: TShiftState; X, Y: Integer);
begin
    btnPosStopClick(nil);
end;

// ++ =======================================================================
// >> m_timerTimer(...) : 타이머 이벤트 핸들러 함수.
//  - 일정한 주기로 변경되는 위치/속도/정보등을 Control에 반영합니다.
// --------------------------------------------------------------------------
procedure TForm1.m_timerTimer(Sender: TObject);
var
    dCmdPos, dActPos, dCmdVel : Double;
    lArrayIndex, lCount : longint;
begin
    lArrayIndex := 0;
    for lCount := 0 to (MAX_MULTI_MOVE_AXIS - 1) do
    begin
        if (m_chkMoveMultiAxes[lCount].Checked = true) then
        begin
            AxmStatusGetCmdPos(m_lMoveMultiAxes[lArrayIndex], @dCmdPos);
            if (m_dOldCmdPos[lCount] <> dCmdPos) then
            begin
                m_stcCmdPos[lCount].Text := Format('%*.*f', [1, 3, dCmdPos]);
                m_dOldCmdPos[lCount] := dCmdPos;
            end;

            AxmStatusGetActPos(m_lMoveMultiAxes[lArrayIndex], @dActPos);
            if (m_dOldActPos[lCount] <> dActPos) then
            begin
                m_stcActPos[lCount].Text := Format('%*.*f', [1, 3, dActPos]);
                m_dOldActPos[lCount] := dActPos;
            end;

            AxmStatusReadVel(m_lMoveMultiAxes[lArrayIndex], @dCmdVel);
            if (m_dOldCmdVel[lCount] <> dCmdVel) then
            begin
                m_stcCmdVel[lCount].Text := Format('%*.*f', [1, 3, dCmdVel]);
                m_dOldCmdVel[lCount] := dCmdVel;
            end;

            lArrayIndex := lArrayIndex + 1;
        end;
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
    bSelectCheck, bEmptyCheck, bAllCheck : boolean;
    strData : String;
    dwOnOff : DWORD;
    lBoardNo, lModulePos, lFirstAxisNo, lCount : Longint;
begin
    if (m_lAxisCount < 1) then
    begin
        Result := false;
        exit;
    end;

    //++ 지정한 축의 정보를 반환합니다.
  	// [INFO] 여러개의 정보를 읽는 함수 사용시 불필요한 정보는 NULL(0)을 입력하면 됩니다.
    AxmInfoGetAxis(m_lAxisNo, @lBoardNo, @lModulePos, nil);
    //++ 지정한 보드/모듈의 첫번째 축 번호를 반환합니다.
    AxmInfoGetFirstAxisNo(lBoardNo, lModulePos, @lFirstAxisNo);

    m_lMoveMultiAxesCount := 0;
    bEmptyCheck := false;
    for lCount := 0 to (MAX_MULTI_MOVE_AXIS - 1) do
    begin
        //++ 지정한 축이 제어가 가능한 상태인지 반환합니다.
        if (AxmInfoGetAxisStatus(lFirstAxisNo) = AXT_RT_SUCCESS) then
        begin
            strData := Format('Axis %.2d', [lFirstAxisNo]);
            m_chkMoveMultiAxes[lCount].Enabled := true;
            bSelectCheck := m_chkMoveMultiAxes[lCount].Checked;
            bEmptyCheck := bEmptyCheck or bSelectCheck;

            if (bSelectCheck = true) then
            begin
                m_lMoveMultiAxes[m_lMoveMultiAxesCount] := lFirstAxisNo;
                m_lMoveMultiAxesCount := m_lMoveMultiAxesCount + 1;
            end;

            m_edtMovePos[lCount].Enabled := bSelectCheck;
            m_edtMoveVel[lCount].Enabled := bSelectCheck;
            m_edtMoveAcc[lCount].Enabled := bSelectCheck;
            m_edtMoveDec[lCount].Enabled := bSelectCheck;

            m_edtJogVel[lCount].Enabled := bSelectCheck;
            m_edtJogAcc[lCount].Enabled := bSelectCheck;
            m_edtJogDec[lCount].Enabled := bSelectCheck;

            m_edtLinePos[lCount].Enabled := bSelectCheck;
        end
        else
        begin
            m_lMoveMultiAxes[lCount] := -1;
            strData := 'Axis --';
            m_chkMoveMultiAxes[lCount].Enabled := false;
            m_chkMoveMultiAxes[lCount].Checked := false;

            m_edtMovePos[lCount].Enabled := false;
            m_edtMoveVel[lCount].Enabled := false;
            m_edtMoveAcc[lCount].Enabled := false;
            m_edtMoveDec[lCount].Enabled := false;

            m_edtJogVel[lCount].Enabled := false;
            m_edtJogAcc[lCount].Enabled := false;
            m_edtJogDec[lCount].Enabled := false;

            m_edtLinePos[lCount].Enabled := false;
        end;

        lFirstAxisNo := lFirstAxisNo + 1;
        m_chkMoveMultiAxes[lCount].Caption := strData;
    end;

    edtLineVel.Enabled := bEmptyCheck;
    edtLineAcc.Enabled := bEmptyCheck;
    edtLineDec.Enabled := bEmptyCheck;

    btnJogN.Enabled := bEmptyCheck;
    btnJogP.Enabled := bEmptyCheck;

    btnLineN.Enabled := bEmptyCheck;
    btnLineP.Enabled := bEmptyCheck;

    btnPosMove.Enabled := bEmptyCheck;
    btnPosStop.Enabled := bEmptyCheck;

    btnPosClear.Enabled := bEmptyCheck;
    chkMoveBlock.Enabled := bEmptyCheck;
    chkServoOn.Enabled := bEmptyCheck;

    bAllCheck := true;
    for lCount := 0 to (m_lMoveMultiAxesCount - 1) do
    begin
        //++ 지정한 축의 서보온 상태를 반환합니다.
        AxmSignalIsServoOn(m_lMoveMultiAxes[lCount], @dwOnOff);
        // 선택된 보간축들이 모두 서보온 되어있을 때 TRUE
        if (dwOnOff = 0) then
        begin
            bAllCheck := false;
            break;
        end;
    end;
    chkServoOn.Checked := bAllCheck;

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
