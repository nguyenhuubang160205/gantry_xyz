unit ContiInterpolation;
// ContiInterpolation.pas : implementation file
//
// **************************************************************************
// >> [일자]: 2015.12.14
// >> [개요]: 이 예제는 보간함수들의 사용법을 익히고 정해진 패턴의 연속보간
//    데이타들을 연속보간 Queue에 예약 및 실행 해 보는 예제입니다.
// >> [중요]: 연속보간 데이타 예약 및 구동하기
//     1) AxmContiSetAxisMap함수를 이용해서 필요한 축수의 좌표계를 맵핑합니다.
//     2) AxmContiSetAbsRelMode함수를 이용해 해당좌표계의 구동모드를 설정합니다.
//     3) AxmContiBeginNode함수를 이용해 보간구동 예약을 시작합니다.
//     4) AxmLineMove, AxmCircleCenterMove등의 보간함수를 이용해 구동을 예약합니다.
//     5) AxmContiEndNode함수를 이용해 보간구동 예약을 종료합니다.
//     6) AxmContiStart함수를 이용해 예약된 보간구동을 시작합니다.
// **************************************************************************

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, ExtCtrls, StdCtrls,
  AXL, AXM, AXHS;

const
    COORD_NO = 0;
    MAX_SPLINE_NODE = 5;
    MAX_INTP_MOVE_AXIS = 4;

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
    Label5: TLabel;
    stcIntpTotalNode: TEdit;
    stcIntpExeNode: TEdit;
    GroupBox4: TGroupBox;
    Label6: TLabel;
    Label7: TLabel;
    Label11: TLabel;
    btnIntpStop: TButton;
    edtMoveVel: TEdit;
    edtMoveAcc: TEdit;
    edtMoveDec: TEdit;
    OpenDialog1: TOpenDialog;
    m_timer: TTimer;
    Shape1: TShape;
    Label3: TLabel;
    Label4: TLabel;
    chkIntpQueueFree: TCheckBox;
    chkIntpInMotion: TCheckBox;
    Label12: TLabel;
    Label13: TLabel;
    Label14: TLabel;
    Shape2: TShape;
    btnIntpLine: TButton;
    btnIntpArc: TButton;
    btnIntpCircle: TButton;
    Shape3: TShape;
    btnIntpLineArc: TButton;
    btnIntpHelical: TButton;
    btnIntpSpline: TButton;
    btnIntpStart: TButton;
    btnIntpClear: TButton;
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
    procedure btnIntpLineClick(Sender: TObject);
    procedure btnIntpArcClick(Sender: TObject);
    procedure btnIntpCircleClick(Sender: TObject);
    procedure btnIntpLineArcClick(Sender: TObject);
    procedure btnIntpHelicalClick(Sender: TObject);
    procedure btnIntpSplineClick(Sender: TObject);
    procedure btnIntpStartClick(Sender: TObject);
    procedure btnIntpClearClick(Sender: TObject);
    procedure btnIntpStopClick(Sender: TObject);
    procedure m_timerTimer(Sender: TObject);
  private
    { Private declarations }
    m_lAxisNo, m_lAxisCount, m_dwModuleID, m_lMoveIntpAxesCount : integer;
    m_dOldCmdPos : array[0..(MAX_INTP_MOVE_AXIS - 1)] of Double;
    m_dOldActPos : array[0..(MAX_INTP_MOVE_AXIS - 1)] of Double;
    m_dOldCmdVel : array[0..(MAX_INTP_MOVE_AXIS - 1)] of Double;
    m_lMoveIntpAxes : array[0..(MAX_INTP_MOVE_AXIS - 1)] of integer;

    m_stcCmdPos : array[0..(MAX_INTP_MOVE_AXIS - 1)] of TEdit;
    m_stcActPos : array[0..(MAX_INTP_MOVE_AXIS - 1)] of TEdit;
    m_stcCmdVel : array[0..(MAX_INTP_MOVE_AXIS - 1)] of TEdit;
    m_chkMoveIntpAxes : array[0..(MAX_INTP_MOVE_AXIS - 1)] of TCheckBox;
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
    for i := 0 to (MAX_INTP_MOVE_AXIS - 1) do
    begin
        m_lMoveIntpAxes[i] := -1;
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

    m_chkMoveIntpAxes[0] := chkAxis00;
    m_chkMoveIntpAxes[1] := chkAxis01;
    m_chkMoveIntpAxes[2] := chkAxis02;
    m_chkMoveIntpAxes[3] := chkAxis03;

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

    SetWindowLong(stcIntpExeNode.Handle, GWL_STYLE,
        GetWindowLong(stcIntpExeNode.Handle, GWL_STYLE) or ES_CENTER);
    SetWindowLong(stcIntpTotalNode.Handle, GWL_STYLE,
        GetWindowLong(stcIntpTotalNode.Handle, GWL_STYLE) or ES_CENTER);

    SetWindowLong(edtMoveVel.Handle, GWL_STYLE,
        GetWindowLong(edtMoveVel.Handle, GWL_STYLE) or ES_RIGHT);
    SetWindowLong(edtMoveAcc.Handle, GWL_STYLE,
        GetWindowLong(edtMoveAcc.Handle, GWL_STYLE) or ES_RIGHT);
    SetWindowLong(edtMoveDec.Handle, GWL_STYLE,
        GetWindowLong(edtMoveDec.Handle, GWL_STYLE) or ES_RIGHT);

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
    m_lAxisNo := cboSelAxis.ItemIndex;  // 축 선택 ComboBox에서 선택된 축번호를 제어할 축 번호 변수에 설정합니다.

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
// >> chkAxis00Click(...) : 보간축 변경이 있을 때 호출되는 핸들러 함수.
//  - 축 번호 선택 체크버튼의 체크상태에 변화가 있을 때 보간 사용축 갯수 및 축
//    번호 배열값을 재할당합니다.
//  - IDC_CHK_AXIS_00 ~ IDC_CHK_AXIS_03 버튼의 클릭이벤트 발생시 호출됩니다.
// --------------------------------------------------------------------------
procedure TForm1.chkAxis00Click(Sender: TObject);
begin
    // 변경된 모션축의 상태와 Control들의 상태를 일치시킵니다.
    UpdateState();
end;

procedure TForm1.chkAxis01Click(Sender: TObject);
begin
    // 변경된 모션축의 상태와 Control들의 상태를 일치시킵니다.
    UpdateState();
end;

procedure TForm1.chkAxis02Click(Sender: TObject);
begin
    // 변경된 모션축의 상태와 Control들의 상태를 일치시킵니다.
    UpdateState();
end;

procedure TForm1.chkAxis03Click(Sender: TObject);
begin
    // 변경된 모션축의 상태와 Control들의 상태를 일치시킵니다.
    UpdateState();
end;

// ++ =======================================================================
// >> btnPosClearClick() : "Clear"버튼 클릭시 호출되는 핸들러 함수.
//  - 선택된 보간축들의 위치정보를 0.0으로 설정합니다.
//  - AxmStatusSetPosMatch함수는 AxmStatusSetCmdPos, AxmStatusSetActPos 함수를
//    사용하는것과 동일한 효과를 냅니다.
// --------------------------------------------------------------------------
procedure TForm1.btnPosClearClick(Sender: TObject);
var
    lCount : Longint;
begin
    for lCount := 0 to (m_lMoveIntpAxesCount - 1) do
    begin
        AxmStatusSetPosMatch(m_lMoveIntpAxes[lCount], 0.0);
    end;
    //++ Command위치와 Actual위치를 지정한 값으로 설정합니다.
    AxmStatusSetPosMatch(m_lAxisNo, 0.0);
end;

// ++ =======================================================================
// >> chkServoOnClick() : "Servo On"버튼 클릭시 호출되는 핸들러 함수.
//  - 선택된 보간축들을 체크버튼의 상태에 따라 서보 On/Off 합니다.
// --------------------------------------------------------------------------
procedure TForm1.chkServoOnClick(Sender: TObject);
var
    lCount : Longint;
    dwIsChecked : DWORD;
begin
    for lCount := 0 to (m_lMoveIntpAxesCount - 1) do
    begin
        dwIsChecked := iif(chkServoOn.Checked, 1, 0);
        //++ 지정 축의 Servo On/Off 신호를 출력합니다.
        AxmSignalServoOn(m_lMoveIntpAxes[lCount], dwIsChecked);
    end;
end;

// ++ =======================================================================
// >> btnIntpLineClick() : "Line"버튼 클릭시 호출되는 핸들러 함수.
//  - 선택된 보간축들 중 2축을 이용해 단위 직선보간을 하는 함수입니다.
// --------------------------------------------------------------------------
procedure TForm1.btnIntpLineClick(Sender: TObject);
var
    strData : string;
    dwRetCode : DWORD;
    dVelocity, dAccel, dDecel : double;
    dMovePos : array[0..1] of double;
begin
    dVelocity := StrToFloat(edtMoveVel.Text);
    dAccel := StrToFloat(edtMoveAcc.Text);
    dDecel := StrToFloat(edtMoveDec.Text);

    dMovePos[0] := 100.0; // 첫번째 축의 이동할 위치값
    dMovePos[1] := 200.0; // 두번째 축의 이동할 위치값

    //++ 지정한 좌표계에 연속보간 축들을 맵핑합니다.
    AxmContiSetAxisMap(COORD_NO, 2, @m_lMoveIntpAxes);
    //++ 지정한 좌표계에 구동모드을 설정합니다.(절대구동/상대구동)
    AxmContiSetAbsRelMode(COORD_NO, POS_REL_MODE);

    //++ 지정한 좌표계의 축들을 이용해 직선보간구동을 수행합니다.
    dwRetCode := AxmLineMove(COORD_NO, @dMovePos, dVelocity, dAccel, dDecel);
    if (dwRetCode <> AXT_RT_SUCCESS) then
    begin
        strData := Format('AxmLineMove return error[Code:%.4d]', [dwRetCode]);
        ShowMessage(strData);
    end;
end;

// ++ =======================================================================
// >> btnIntpArcClick() : "Arc"버튼 클릭시 호출되는 핸들러 함수.
//  - 선택된 보간축들 중 2축을 이용해 단위 Arc보간을 하는 함수입니다.
// --------------------------------------------------------------------------
procedure TForm1.btnIntpArcClick(Sender: TObject);
var
    strData : string;
    dwRetCode : DWORD;
    dwArcDir, dwShortDis : DWORD;
    dVelocity, dAccel, dDecel, dRadius : double;
    dEndPos : array[0..1] of double;
begin
    dVelocity := StrToFloat(edtMoveVel.Text);
    dAccel := StrToFloat(edtMoveAcc.Text);
    dDecel := StrToFloat(edtMoveDec.Text);

    dEndPos[0] := 100.0;
    dEndPos[1] := 100.0;
    dRadius := 141.0;
    dwArcDir := DIR_CW;
    dwShortDIs := LONG_DISTANCE;

    //++ 지정한 좌표계에 연속보간 축들을 맵핑합니다.
    AxmContiSetAxisMap(COORD_NO, 2, @m_lMoveIntpAxes);
    //++ 지정한 좌표계에 구동모드을 설정합니다.(절대구동/상대구동)
    AxmContiSetAbsRelMode(COORD_NO, POS_ABS_MODE);

    //++ 지정한 좌표계의 축들 중 특정 2축에 반지름을 이용한 원호보간구동을 수행합니다.
    dwRetCode := AxmCircleRadiusMove(COORD_NO, @m_lMoveIntpAxes, dRadius, @dEndPos, dVelocity, dAccel, dDecel, dwArcDir, dwShortDis);
    if (dwRetCode <> AXT_RT_SUCCESS) then
    begin
        strData := Format('AxmCircleRadiusMove return error[Code:%.4d]', [dwRetCode]);
        ShowMessage(strData);
    end;
end;

// ++ =======================================================================
// >> btnIntpCircleClick() : "Circle"버튼 클릭시 호출되는 핸들러 함수.
//  - 선택된 보간축들 중 2축을 이용해 단위 원호보간을 하는 함수입니다.
// --------------------------------------------------------------------------
procedure TForm1.btnIntpCircleClick(Sender: TObject);
var
    strData : string;
    dwRetCode : DWORD;
    dwArcDir : DWORD;
    dVelocity, dAccel, dDecel, dAngle : double;
    dCenterPos : array[0..1] of double;
begin
    dVelocity := StrToFloat(edtMoveVel.Text);
    dAccel := StrToFloat(edtMoveAcc.Text);
    dDecel := StrToFloat(edtMoveDec.Text);

    dCenterPos[0] := 200.0;
    dCenterPos[1] := 200.0;
    dAngle := 360.0;
    dwArcDir := DIR_CCW;

    //++ 지정한 좌표계에 연속보간 축들을 맵핑합니다.
    AxmContiSetAxisMap(COORD_NO, 2, @m_lMoveIntpAxes);
    //++ 지정한 좌표계에 구동모드을 설정합니다.(절대구동/상대구동)
    AxmContiSetAbsRelMode(COORD_NO, POS_ABS_MODE);

    //++ 지정한 좌표계의 축들 중 특정 2축에, 회전중심과 회전각도를 이용한 원호보간 구동을 수행합니다.
    sleep(1);
    dwRetCode := AxmCircleAngleMove(COORD_NO, @m_lMoveIntpAxes, @dCenterPos, dAngle, dVelocity, dAccel, dDecel, dwArcDir);
    if (dwRetCode <> AXT_RT_SUCCESS) then
    begin
        strData := Format('AxmCircleAngleMove return error[Code:%.4d]', [dwRetCode]);
        ShowMessage(strData);
    end;
end;

// ++ =======================================================================
// >> btnIntpLineArcClick() : "Line & Arc"버튼 클릭시 호출되는 핸들러 함수.
//  - 선택된 보간축들 중 2축을 이용해 연속 직선/원호보간을 하는 함수입니다.
// --------------------------------------------------------------------------
procedure TForm1.btnIntpLineArcClick(Sender: TObject);
var
    dVelocity, dAccel, dDecel : double;
    dMovePos, dCenterPos, dEndPos : array[0..1] of double;
begin
    dVelocity := StrToFloat(edtMoveVel.Text);
    dAccel := StrToFloat(edtMoveAcc.Text);
    dDecel := StrToFloat(edtMoveDec.Text);

    //++ 지정한 좌표계에 연속보간 축들을 맵핑합니다.
    AxmContiSetAxisMap(COORD_NO, 2, @m_lMoveIntpAxes);
    //++ 지정한 좌표계에 등록되어있는 보간데이타를 모두 지웁니다.
    AxmContiWriteClear(COORD_NO);
    //++ 지정한 좌표계에 구동모드을 설정합니다.(절대구동/상대구동)
    AxmContiSetAbsRelMode(COORD_NO, POS_ABS_MODE);

    //++ 지정한 좌표계에 연속보간을 수행할 작업 등록을 시작합니다.
	  // ※ [CAUTION] 이 함수가 실행된 후 에는 보간함수들이 즉시 구동되지 않고 보간데이타 Queue에 예약됩니다.
    AxmContiBeginNode(COORD_NO);

    dMovePos[0] := 0.0;
    dMovePos[1] := 200.0;
    //++ 지정한 좌표계에 직선보간 구동을 예약합니다.
    AxmLineMove(COORD_NO, @dMovePos, dVelocity, dAccel, dDecel);

    dMovePos[0] := 180.0;
    dMovePos[1] := 200.0;
    AxmLineMove(COORD_NO, @dMovePos, dVelocity, dAccel, dDecel);

    dCenterPos[0] := 180.0;
    dCenterPos[1] := 180.0;
    dEndPos[0] := 200.0;
    dEndPos[1] := 180.0;
    //++ 지정한 좌표계에 중심점과 종료점을 이용하는 원호보간 구동을 예약합니다.
    AxmCircleCenterMove(COORD_NO, @m_lMoveIntpAxes, @dCenterPos, @dEndPos, dVelocity, dAccel, dDecel, DIR_CW);

    dMovePos[0] := 200.0;
    dMovePos[1] := -180.0;
    AxmLineMove(COORD_NO, @dMovePos, dVelocity, dAccel, dDecel);

    dCenterPos[0] := 180.0;
    dCenterPos[1] := -180.0;
    dEndPos[0] := 180.0;
    dEndPos[1] := -200.0;
    AxmCircleCenterMove(COORD_NO, @m_lMoveIntpAxes, @dCenterPos, @dEndPos, dVelocity, dAccel, dDecel, DIR_CW);

    dMovePos[0] := -180.0;
    dMovePos[1] := -200.0;
    AxmLineMove(COORD_NO, @dMovePos, dVelocity, dAccel, dDecel);

    dCenterPos[0] := -180.0;
    dCenterPos[1] := -180.0;
    dEndPos[0] := -200.0;
    dEndPos[1] := -180.0;
    AxmCircleCenterMove(COORD_NO, @m_lMoveIntpAxes, @dCenterPos, @dEndPos, dVelocity, dAccel, dDecel, DIR_CW);

    dMovePos[0] := -200.0;
    dMovePos[1] := 180.0;
    AxmLineMove(COORD_NO, @dMovePos, dVelocity, dAccel, dDecel);

    dCenterPos[0] := -180.0;
    dCenterPos[1] := 180.0;
    dEndPos[0] := -180.0;
    dEndPos[1] := 200.0;
    AxmCircleCenterMove(COORD_NO, @m_lMoveIntpAxes, @dCenterPos, @dEndPos, dVelocity, dAccel, dDecel, DIR_CW);

    dMovePos[0] := 0.0;
    dMovePos[1] := 200.0;
    AxmLineMove(COORD_NO, @dMovePos, dVelocity, dAccel, dDecel);

    //++ 지정한 좌표계에 연속보간을 수행할 작업 등록을 종료합니다.
	  // ※ [CAUTION] AxmContiBeginNode 함수 실행후 연속보간 작업을 등록한 후 반드시 이 함수로 등록을 종료해야
	  //              연속보간 구동을 실행할 수 있습니다.
    AxmContiEndNode(COORD_NO);
end;

// ++ =======================================================================
// >> btnIntpHelicalClick() : "Helical"버튼 클릭시 호출되는 핸들러 함수.
//  - 선택된 보간축들 중 4축을 이용해 연속 헬리컬 보간을 하는 함수입니다.
// --------------------------------------------------------------------------
procedure TForm1.btnIntpHelicalClick(Sender: TObject);
var
    dwArcDir : DWORD;
    dVelocity, dAccel, dDecel : double;
    dCenterPosX, dCenterPosY, dEndPosX, dEndPosY, dZPos : double;
begin
    dVelocity := StrToFloat(edtMoveVel.Text);
    dAccel := StrToFloat(edtMoveAcc.Text);
    dDecel := StrToFloat(edtMoveDec.Text);

    dCenterPosX := 100.0;
    dCenterPosY := 100.0;
    dEndPosX := 0.0;
    dEndPosY := 0.0;
    dZPos := 10.0;
    dwArcDir := DIR_CW;

    //++ 지정한 좌표계에 연속보간 축들을 맵핑합니다.
    AxmContiSetAxisMap(COORD_NO, 4, @m_lMoveIntpAxes);
    //++ 지정한 좌표계에 등록되어있는 보간데이타를 모두 지웁니다.
    AxmContiWriteClear(COORD_NO);
    //++ 지정한 좌표계에 구동모드을 설정합니다.(절대구동/상대구동)
    AxmContiSetAbsRelMode(COORD_NO, POS_REL_MODE);

    //++ 지정한 좌표계에 연속보간을 수행할 작업 등록을 시작합니다.
	  // ※ [CAUTION] 이 함수가 실행된 후 에는 보간함수들이 즉시 구동되지 않고 보간데이타 Queue에 예약됩니다.
    AxmContiBeginNode(COORD_NO);

    //++ 지정한 좌표계에 중심점과 종료점을 이용하는 헬리컬 보간구동을 예약합니다.
    AxmHelixCenterMove(COORD_NO, dCenterPosX, dCenterPosY, dEndPosX, dEndPosY, dZPos, dVelocity, dAccel, dDecel, dwArcDir);
    AxmHelixCenterMove(COORD_NO, dCenterPosX, dCenterPosY, dEndPosX, dEndPosY, dZPos, dVelocity, dAccel, dDecel, dwArcDir);
    AxmHelixCenterMove(COORD_NO, dCenterPosX, dCenterPosY, dEndPosX, dEndPosY, dZPos, dVelocity, dAccel, dDecel, dwArcDir);
    AxmHelixCenterMove(COORD_NO, dCenterPosX, dCenterPosY, dEndPosX, dEndPosY, dZPos, dVelocity, dAccel, dDecel, dwArcDir);
    AxmHelixCenterMove(COORD_NO, dCenterPosX, dCenterPosY, dEndPosX, dEndPosY, dZPos, dVelocity, dAccel, dDecel, dwArcDir);
    AxmHelixCenterMove(COORD_NO, dCenterPosX, dCenterPosY, dEndPosX, dEndPosY, dZPos, dVelocity, dAccel, dDecel, dwArcDir);
    AxmHelixCenterMove(COORD_NO, dCenterPosX, dCenterPosY, dEndPosX, dEndPosY, dZPos, dVelocity, dAccel, dDecel, dwArcDir);
    AxmHelixCenterMove(COORD_NO, dCenterPosX, dCenterPosY, dEndPosX, dEndPosY, dZPos, dVelocity, dAccel, dDecel, dwArcDir);
    AxmHelixCenterMove(COORD_NO, dCenterPosX, dCenterPosY, dEndPosX, dEndPosY, dZPos, dVelocity, dAccel, dDecel, dwArcDir);
    AxmHelixCenterMove(COORD_NO, dCenterPosX, dCenterPosY, dEndPosX, dEndPosY, dZPos, dVelocity, dAccel, dDecel, dwArcDir);

    //++ 지정한 좌표계에 연속보간을 수행할 작업 등록을 종료합니다.
	  // ※ [CAUTION] AxmContiBeginNode 함수 실행후 연속보간 작업을 등록한 후 반드시 이 함수로 등록을 종료해야
	  //              연속보간 구동을 실행할 수 있습니다.
    AxmContiEndNode(COORD_NO);
end;

// ++ =======================================================================
// >> btnIntpSplineClick() : "Spline"버튼 클릭시 호출되는 핸들러 함수.
//  - 선택된 보간축들 중 3축을 이용해 스플라인 보간을 하는 함수입니다.
// --------------------------------------------------------------------------
procedure TForm1.btnIntpSplineClick(Sender: TObject);
var
    lPointFactor : longint;
    dVelocity, dAccel, dDecel : double;
    dPosX, dPosY : array[0..(MAX_SPLINE_NODE - 1)] of double;
    dPosZ : double;
begin
    dVelocity := StrToFloat(edtMoveVel.Text);
    dAccel := StrToFloat(edtMoveAcc.Text);
    dDecel := StrToFloat(edtMoveDec.Text);

    //++ 지정한 좌표계에 연속보간 축들을 맵핑합니다.
    AxmContiSetAxisMap(COORD_NO, 3, @m_lMoveIntpAxes);
    //++ 지정한 좌표계에 등록되어있는 보간데이타를 모두 지웁니다.
    AxmContiWriteClear(COORD_NO);
    //++ 지정한 좌표계에 구동모드을 설정합니다.(절대구동/상대구동)
    AxmContiSetAbsRelMode(COORD_NO, POS_ABS_MODE);

    dPosX[0] := 0.0;
    dPosY[0] := 0.0;
    dPosX[1] := 45.0;
    dPosY[1] := 10.0;
    dPosX[2] := 75.0;
    dPosY[2] := 45.0;
    dPosX[3] := 108.0;
    dPosY[3] := 75.0;
    dPosX[4] := 130.0;
    dPosY[4] := 70.0;
    dPosZ := 1.0;
    lPointFactor := 100;

    //++ 지정한 좌표계에 연속보간을 수행할 작업 등록을 시작합니다.
	  // ※ [CAUTION] 이 함수가 실행된 후 에는 보간함수들이 즉시 구동되지 않고 보간데이타 Queue에 예약됩니다.
    AxmContiBeginNode(COORD_NO);
    //++ 지정한 좌표계에 X좌표, Y좌표, Z좌표를 이용하는 스플라인 보간구동을 예약합니다.
    AxmSplineWrite(COORD_NO, MAX_SPLINE_NODE, @dPosX, @dPosY, dVelocity, dAccel, dDecel, dPosZ, lPointFactor);

    dPosX[0] := 130.0;
    dPosY[0] := 70.0;
    dPosX[1] := 108.0;
    dPosY[1] := 75.0;
    dPosX[2] := 75.0;
    dPosY[2] := 45.0;
    dPosX[3] := 45.0;
    dPosY[3] := 10.0;
    dPosX[4] := 0.0;
    dPosY[4] := 0.0;
    dPosZ := 1.0;
    lPointFactor := 100;

    AxmSplineWrite(COORD_NO, MAX_SPLINE_NODE, @dPosX, @dPosY, dVelocity, dAccel, dDecel, dPosZ, lPointFactor);

    //++ 지정한 좌표계에 연속보간을 수행할 작업 등록을 종료합니다.
	  // ※ [CAUTION] AxmContiBeginNode 함수 실행후 연속보간 작업을 등록한 후 반드시 이 함수로 등록을 종료해야
	  //              연속보간 구동을 실행할 수 있습니다.
    AxmContiEndNode(COORD_NO);
end;

// ++ =======================================================================
// >> btnIntpStartClick() : "Start"버튼 클릭시 호출되는 핸들러 함수.
//  - 예약된 연속보간 데이타들을 이용하여 연속보간을 시작하는 함수입니다.
// --------------------------------------------------------------------------
procedure TForm1.btnIntpStartClick(Sender: TObject);
var
    strData : string;
    dwRetCode : DWORD;
begin
    //++ 지정한 좌표계의 연속보간 구동을 시작합니다.
    dwRetCode := AxmContiStart(COORD_NO, CONTI_NODE_VELOCITY, 0);
    if (dwRetCode <> AXT_RT_SUCCESS) then
    begin
        strData := Format('AxmContiStart return error[Code:%.4d]', [dwRetCode]);
        ShowMessage(strData);
    end;
end;

// ++ =======================================================================
// >> btnIntpClearClick() : "Clear"버튼 클릭시 호출되는 핸들러 함수.
//  - 예약된 연속보간 데이타들을 지우는 함수입니다.
// --------------------------------------------------------------------------
procedure TForm1.btnIntpClearClick(Sender: TObject);
var
    strData : string;
    dwRetCode : DWORD;
begin
    //++ 지정한 좌표계에 연속 보간 구동을 위해 예약된 보간데이타를 모두 삭제합니다.
    dwRetCode := AxmContiWriteClear(COORD_NO);
    if (dwRetCode <> AXT_RT_SUCCESS) then
    begin
        strData := Format('AxmContiWriteClear return error[Code:%.4d]', [dwRetCode]);
        ShowMessage(strData);
    end;
end;

// ++ =======================================================================
// >> btnIntpStopClick() : "Stop"버튼 클릭시 호출되는 핸들러 함수.
//  - 연속보간을 정지하는 함수입니다.
// --------------------------------------------------------------------------
procedure TForm1.btnIntpStopClick(Sender: TObject);
var
    lCount : longint;
begin
    for lCount := 0 to (m_lMoveIntpAxesCount - 1) do
        //++ 지정한 좌표계에 연속 보간 구동을 감속정지합니다.
		    // [INFO] 좌표계에 포함된 한 축을 정지하면 연속보간은 정지됩니다.
        AxmMoveSStop(m_lMoveIntpAxes[lCount]);
end;

// ++ =======================================================================
// >> m_timerTimer(...) : 타이머 이벤트 핸들러 함수.
//  - 일정한 주기로 변경되는 위치/속도/정보등을 Control에 반영합니다.
// --------------------------------------------------------------------------
procedure TForm1.m_timerTimer(Sender: TObject);
var
    dCmdPos, dActPos, dCmdVel : Double;
    lArrayIndex, lCount, dwQueueFree, dwIntpInMotion : longint;
    lExeNode, lTotalNode : longint;
    isTrue : boolean;
begin
    lArrayIndex := 0;
    dwQueueFree := 0;
    dwIntpInMotion := 0;
    lExeNode := 0;
    lTotalNode := 0;

    for lCount := 0 to (MAX_INTP_MOVE_AXIS - 1) do
    begin
        // 버튼 콘트롤의 체크 상태를 확인합니다.
        if (m_chkMoveIntpAxes[lCount].Checked = true) then
        begin
            //++ 지정한 축의 지령(Command)위치를 반환합니다.
            AxmStatusGetCmdPos(m_lMoveIntpAxes[lArrayIndex], @dCmdPos);
            if (m_dOldCmdPos[lCount] <> dCmdPos) then
            begin
                m_stcCmdPos[lCount].Text := Format('%*.*f', [1, 3, dCmdPos]);
                m_dOldCmdPos[lCount] := dCmdPos;
            end;

            //++ 지정한 축의 실제(Feedback)위치를 반환합니다.
            AxmStatusGetActPos(m_lMoveIntpAxes[lArrayIndex], @dActPos);
            if (m_dOldActPos[lCount] <> dActPos) then
            begin
                m_stcActPos[lCount].Text := Format('%*.*f', [1, 3, dActPos]);
                m_dOldActPos[lCount] := dActPos;
            end;

            //++ 지정한 축의 구동 속도를 반환합니다.
            AxmStatusReadVel(m_lMoveIntpAxes[lArrayIndex], @dCmdVel);
            if (m_dOldCmdVel[lCount] <> dCmdVel) then
            begin
                m_stcCmdVel[lCount].Text := Format('%*.*f', [1, 3, dCmdVel]);
                m_dOldCmdVel[lCount] := dCmdVel;
            end;

            lArrayIndex := lArrayIndex + 1;
        end;
    end;

    //++ 지정한 좌표계에 연속보간 Queue가 비었는지 확인합니다.
    AxmContiReadFree(COORD_NO, @dwQueueFree);
    isTrue := iif(dwQueueFree);
    chkIntpQueueFree.Checked := isTrue;

    //++ 지정한 좌표계가 연속보간 구동중인지 확인합니다.
    AxmContiIsMotion(COORD_NO, @dwIntpInMotion);
    isTrue := iif(dwIntpInMotion);
    chkIntpInMotion.Checked := isTrue;

    //++ 지정한 좌표계가 연속보간 구동중 현재 실행중인 Node의 Index를 확인합니다.
    AxmContiGetNodeNum(COORD_NO, @lExeNode);
    if (StrToInt(stcIntpExeNode.Text) <> lExeNode) then
        stcIntpExeNode.Text := Format('%d', [lExeNode]);

    //++ 지정한 좌표계에 예약된 연속보간 데이타의 전체 갯수를 확인합니다.
    AxmContiGetTotalNodeNum(COORD_NO, @lTotalNode);
    if (StrToInt(stcIntpTotalNode.Text) <> lTotalNode) then
        stcIntpTotalNode.Text := Format('%d', [lTotalNode]);
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

    m_lMoveIntpAxesCount := 0;
    bEmptyCheck := false;
    for lCount := 0 to (MAX_INTP_MOVE_AXIS - 1) do
    begin
        //++ 지정한 축이 제어가 가능한 상태인지 반환합니다.
        if (AxmInfoGetAxisStatus(lFirstAxisNo) = AXT_RT_SUCCESS) then
        begin
            strData := Format('Axis %.2d', [lFirstAxisNo]);
            m_chkMoveIntpAxes[lCount].Enabled := true;
            bSelectCheck := m_chkMoveIntpAxes[lCount].Checked;
            bEmptyCheck := bEmptyCheck or bSelectCheck;

            if (bSelectCheck = true) then
            begin
                m_lMoveIntpAxes[m_lMoveIntpAxesCount] := lFirstAxisNo;
                m_lMoveIntpAxesCount := m_lMoveIntpAxesCount + 1;
            end;
        end
        else
        begin
            m_lMoveIntpAxes[lCount] := -1;
            strData := 'Axis --';
            m_chkMoveIntpAxes[lCount].Enabled := false;
            m_chkMoveIntpAxes[lCount].Checked := false;
        end;
        lFirstAxisNo := lFirstAxisNo + 1;
        m_chkMoveIntpAxes[lCount].Caption := strData;
    end;

    // 선택된 축이 없으면 Disable처리
    chkServoOn.Enabled := bEmptyCheck;

    bAllCheck := true;
    for lCount := 0 to (m_lMoveIntpAxesCount - 1) do
    begin
        //++ 지정한 축의 서보온 상태를 반환합니다.
        AxmSignalIsServoOn(m_lMoveIntpAxes[lCount], @dwOnOff);
        if (dwOnOff = 0) then
        begin
            bAllCheck := false;
            break;
        end;
    end;
    // 선택된 보간축들이 모두 서보온 되어있을 때 TRUE
    chkServoOn.Checked := bAllCheck;

    // 선택된 축수에 따라 사용가능한 보간버튼들을 활성화시킵니다.
    if (m_lMoveIntpAxesCount < 2) then
    begin
        btnIntpLine.Enabled := false;
        btnIntpArc.Enabled := false;
        btnIntpCircle.Enabled := false;
        btnIntpLineArc.Enabled := false;
        btnIntpHelical.Enabled := false;
        btnIntpSpline.Enabled := false;
    end
    else
    begin
        btnIntpLine.Enabled := true;
        btnIntpArc.Enabled := true;
        btnIntpCircle.Enabled := true;
        btnIntpLineArc.Enabled := true;
        if (m_lMoveIntpAxesCount >= 3) then
            btnIntpSpline.Enabled := true
        else
            btnIntpSpline.Enabled := false;
        if (m_lMoveIntpAxesCount = 4) then
            btnIntpHelical.Enabled := true
        else
            btnIntpHelical.Enabled := false;
    end;

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
