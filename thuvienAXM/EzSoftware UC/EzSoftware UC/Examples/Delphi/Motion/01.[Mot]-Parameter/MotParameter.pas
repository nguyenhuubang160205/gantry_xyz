unit MotParameter;
// MotParameter.pas : implementation file
//
// **************************************************************************
// >> [일자]: 2015.12.08
// >> [개요]: 이 예제는 모터 구동에 관련된 파라메타들을 설정변경한 후 파일로
//    저장 또는 불러오기를 할 수 있도록 작성된 예제입니다.
// >> [중요]: 신호설정 함수 사용시 주의사항
//     1) 제품의 종류에 따라서 신호설정에 사용되는 인자가 달라질 수 있습니다.
//     2) 네트웍 제품의 리미트 신호나 원점신호의 레벨 변경은 서보팩 파라메타를
//        변경해서 바꿀수 있습니다.
// **************************************************************************

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  AXL, AXHS, AXM, Dialogs, StdCtrls, ExtCtrls;

type
  TForm1 = class(TForm)
    GroupBox1: TGroupBox;
    Label1: TLabel;
    cboSelAxis: TComboBox;
    btnLoadFile: TButton;
    btnSaveFile: TButton;
    GroupBox2: TGroupBox;
    Label2: TLabel;
    Label3: TLabel;
    Label4: TLabel;
    Label5: TLabel;
    cboPulse: TComboBox;
    cboEncoder: TComboBox;
    cboAbsRel: TComboBox;
    cboProfile: TComboBox;
    Label6: TLabel;
    Label7: TLabel;
    Label8: TLabel;
    Label9: TLabel;
    edtMinVel: TEdit;
    edtMaxVel: TEdit;
    edtMovePulse: TEdit;
    edtMoveUnit: TEdit;
    Shape1: TShape;
    GroupBox3: TGroupBox;
    Label10: TLabel;
    Label11: TLabel;
    Label12: TLabel;
    Label13: TLabel;
    Label14: TLabel;
    Label15: TLabel;
    Label16: TLabel;
    Label17: TLabel;
    Shape2: TShape;
    cboInp: TComboBox;
    Label18: TLabel;
    chkInp: TCheckBox;
    chkAlarm: TCheckBox;
    cboAlarm: TComboBox;
    chkELimitP: TCheckBox;
    cboELimitP: TComboBox;
    chkELimitN: TCheckBox;
    cboELimitN: TComboBox;
    cboServoOn: TComboBox;
    Label19: TLabel;
    chkZPhase: TCheckBox;
    cboZPhaseLev: TComboBox;
    cboStopMode: TComboBox;
    cboStopLevel: TComboBox;
    cboAlarmReset: TComboBox;
    cboEncoderType: TComboBox;
    chkEmg: TCheckBox;
    GroupBox4: TGroupBox;
    Label20: TLabel;
    Label21: TLabel;
    Label22: TLabel;
    Label23: TLabel;
    Label24: TLabel;
    Shape3: TShape;
    Label28: TLabel;
    cboHomeSignal: TComboBox;
    cboHomeLevel: TComboBox;
    cboHomeDir: TComboBox;
    cboZPhaseUse: TComboBox;
    Label30: TLabel;
    Label25: TLabel;
    Label26: TLabel;
    Label27: TLabel;
    Label29: TLabel;
    Label31: TLabel;
    edtVelFirst: TEdit;
    edtVelSecond: TEdit;
    edtVelThird: TEdit;
    edtVelLast: TEdit;
    edtAccFirst: TEdit;
    edtAccSecond: TEdit;
    edtHomeClrTime: TEdit;
    edtHomeOffset: TEdit;
    Shape4: TShape;
    Shape5: TShape;
    GroupBox5: TGroupBox;
    Label32: TLabel;
    Label33: TLabel;
    Label34: TLabel;
    Label37: TLabel;
    Label38: TLabel;
    Shape6: TShape;
    cboSLimitEnable: TComboBox;
    cboSLimitSelect: TComboBox;
    edtSLimitPosP: TEdit;
    edtSLimitPosN: TEdit;
    cboSLimitStopMode: TComboBox;
    GroupBox6: TGroupBox;
    Label35: TLabel;
    Label36: TLabel;
    Label40: TLabel;
    Shape7: TShape;
    edtDecel: TEdit;
    edtVelocity: TEdit;
    Label39: TLabel;
    edtAccel: TEdit;
    edtPosition: TEdit;
    btnApplyAllAxes: TButton;
    btnApplyPulse: TButton;
    btnApplySignal: TButton;
    btnApplyHome: TButton;
    btnApplySoftLimit: TButton;
    btnApplyUserPara: TButton;
    OpenDialog1: TOpenDialog;
    SaveDialog1: TSaveDialog;
    m_timer: TTimer;
    procedure FormCreate(Sender: TObject);
    procedure cboSelAxisChange(Sender: TObject);
    procedure btnLoadFileClick(Sender: TObject);
    procedure btnSaveFileClick(Sender: TObject);
    procedure btnApplyPulseClick(Sender: TObject);
    procedure btnApplySignalClick(Sender: TObject);
    procedure btnApplyHomeClick(Sender: TObject);
    procedure btnApplySoftLimitClick(Sender: TObject);
    procedure btnApplyUserParaClick(Sender: TObject);
    procedure btnApplyAllAxesClick(Sender: TObject);
    procedure m_timerTimer(Sender: TObject);
    Function InitLibrary() : Boolean; stdcall;
    Function AddAxisInfo() : Boolean; stdcall;
    Function InitControl() : Boolean; stdcall;
    Function UpdateState() : Boolean; stdcall;
    Function ConvertAxmToCombo(pCboItem : TComboBox; dwCurData : DWORD) : DWORD;
    Function ConvertComboToAxm(pCboItem : TComboBox) : DWORD;
    function iif(c: boolean; a, b: integer): integer;
  private
    { Private declarations }
  public
    { Public declarations }
    m_lAxisNo     : Integer;
    m_lAxisCounts : longInt;
    m_dwModuleID  : DWORD;

    procedure WMSysCommand(var Msg: TWMSysCommand); message WM_SYSCOMMAND;
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

    // TEdit 컨트롤들의 값들을 오른쪽정렬로 설정
    SetWindowLong(edtMinVel.Handle, GWL_STYLE,
        GetWindowLong(edtMinVel.Handle, GWL_STYLE) or ES_RIGHT);
    SetWindowLong(edtMaxVel.Handle, GWL_STYLE,
        GetWindowLong(edtMaxVel.Handle, GWL_STYLE) or ES_RIGHT);
    SetWindowLong(edtMovePulse.Handle, GWL_STYLE,
        GetWindowLong(edtMovePulse.Handle, GWL_STYLE) or ES_RIGHT);
    SetWindowLong(edtMoveUnit.Handle, GWL_STYLE,
        GetWindowLong(edtMoveUnit.Handle, GWL_STYLE) or ES_RIGHT);
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
    SetWindowLong(edtHomeClrTime.Handle, GWL_STYLE,
        GetWindowLong(edtHomeClrTime.Handle, GWL_STYLE) or ES_RIGHT);
    SetWindowLong(edtHomeOffset.Handle, GWL_STYLE,
        GetWindowLong(edtHomeOffset.Handle, GWL_STYLE) or ES_RIGHT);
    SetWindowLong(edtSLimitPosN.Handle, GWL_STYLE,
        GetWindowLong(edtSLimitPosN.Handle, GWL_STYLE) or ES_RIGHT);
    SetWindowLong(edtSLimitPosP.Handle, GWL_STYLE,
        GetWindowLong(edtSLimitPosP.Handle, GWL_STYLE) or ES_RIGHT);
    SetWindowLong(edtPosition.Handle, GWL_STYLE,
        GetWindowLong(edtPosition.Handle, GWL_STYLE) or ES_RIGHT);
    SetWindowLong(edtVelocity.Handle, GWL_STYLE,
        GetWindowLong(edtVelocity.Handle, GWL_STYLE) or ES_RIGHT);
    SetWindowLong(edtAccel.Handle, GWL_STYLE,
        GetWindowLong(edtAccel.Handle, GWL_STYLE) or ES_RIGHT);
    SetWindowLong(edtDecel.Handle, GWL_STYLE,
        GetWindowLong(edtDecel.Handle, GWL_STYLE) or ES_RIGHT);
end;

// **************************************************************************
// >> [구분]: Control에 이벤트가 발생했을 때 처리하는 함수들 모음
// **************************************************************************
//
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
//   - 임의 위치에 있는 Mot(AXM에서 사용하는 설정파일 형식) 파일을 불러옵니다.
//   - 이 함수를 통해 임의의 Mot파일을 불러오면 모션축의 설정값들이 Mot파일의
//       설정값들로 일괄 변경됩니다.
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
// >> btnSaveFileClick() : "Save File"버튼 클릭시 호출되는 핸들러 함수.
//  - AXL 라이브러리 함수를 이용해 변경된 설정값들을 지정한 위치에
//    Mot(AXM에서 사용하는 설정파일 형식) 파일 형식으로 저장합니다.
// --------------------------------------------------------------------------
procedure TForm1.btnSaveFileClick(Sender: TObject);
var
    temp, FileType  :   AnsiString;
begin
    SaveDialog1.Filter := 'Data File (*.mot)|*.mot|All Files (*.*)|*.*';
    SaveDialog1.Title := 'Save';
	  if(SaveDialog1.Execute())then
    begin
        SaveDialog1.FilterIndex := 1;
        temp := SaveDialog1.FileName;

        if(FileType <> '.mot')then
            temp := temp + '.mot';

		    if (AXT_RT_SUCCESS <> AxmMotSaveParaAll(PChar(temp)))then
            ShowMessage('File save fail!');
    end;
end;

// ++ =======================================================================
// >> btnApplyPulseClick() : "Pulse/Encoder Method && Move Parameter Setting"
//    그룹의 "Apply" 버튼을 클릭했을 때 호출되는 핸들러 함수.
//  - 해당 그룹의 모든 설정값들을 각각의 AXL 함수들을 이용하여 적용합니다.
// ※ [CAUTION] 각 콘트롤(ComboBox, Edit) 변경시 AXL에 즉시 반영되지않습니다.
//    반드시 해당 그룹의 "Apply"버튼을 클릭해야 설정변경값이 AXL에 반영됩니다.
// --------------------------------------------------------------------------
procedure TForm1.btnApplyPulseClick(Sender: TObject);
var
    dwPulse, dwMethod, dwAbsRelMode, dwProfileMode : DWORD;
    dUnit, dMinVel, dMaxVel : Double;
begin
    if (cboPulse.Enabled = true) then
    begin
        dwMethod := ConvertComboToAxm(cboPulse);
//         ++ 지정 축의 펄스 출력 방식을 설정합니다.
//         uMethod : (0)OneHighLowHigh   - 1펄스 방식, PULSE(Active High), 정방향(DIR=Low)  / 역방향(DIR=High)
//                   (1)OneHighHighLow   - 1펄스 방식, PULSE(Active High), 정방향(DIR=High) / 역방향(DIR=Low)
//                   (2)OneLowLowHigh    - 1펄스 방식, PULSE(Active Low),  정방향(DIR=Low)  / 역방향(DIR=High)
//                   (3)OneLowHighLow    - 1펄스 방식, PULSE(Active Low),  정방향(DIR=High) / 역방향(DIR=Low)
//                   (4)TwoCcwCwHigh     - 2펄스 방식, PULSE(CCW:역방향),  DIR(CW:정방향),  Active High
//                   (5)TwoCcwCwLow      - 2펄스 방식, PULSE(CCW:역방향),  DIR(CW:정방향),  Active Low
//                   (6)TwoCwCcwHigh     - 2펄스 방식, PULSE(CW:정방향),   DIR(CCW:역방향), Active High
//                   (7)TwoCwCcwLow      - 2펄스 방식, PULSE(CW:정방향),   DIR(CCW:역방향), Active Low
//                   (8)TwoPhase         - 2상(90' 위상차),  PULSE lead DIR(CW: 정방향), PULSE lag DIR(CCW:역방향)
//                   (9)TwoPhaseReverse  - 2상(90' 위상차),  PULSE lead DIR(CCW: 정방향), PULSE lag DIR(CW:역방향)
        AxmMotSetPulseOutMethod(m_lAxisNo, dwMethod);
    end;

    if (cboEncoder.Enabled = true) then
    begin
        dwMethod := ConvertComboToAxm(cboEncoder);
//         ++ 지정 축의 Encoder 입력 방식을 설정합니다.
//         uMethod : (0)ObverseUpDownMode - 정방향 Up/Down
//                   (1)ObverseSqr1Mode   - 정방향 1체배
//                   (2)ObverseSqr2Mode   - 정방향 2체배
//                   (3)ObverseSqr4Mode   - 정방향 4체배
//                   (4)ReverseUpDownMode - 역방향 Up/Down
//                   (5)ReverseSqr1Mode   - 역방향 1체배
//                   (6)ReverseSqr2Mode   - 역방향 2체배
//                   (7)ReverseSqr4Mode   - 역방향 4체배
        AxmMotSetEncInputMethod(m_lAxisNo, dwMethod);
    end;

    if (cboAbsRel.Enabled = true) then
    begin
        dwAbsRelMode := ConvertComboToAxm(cboAbsRel);
//         ++ 지정 축의 구동 좌표계를 설정합니다.
//         dwAbsRelMode : (0)POS_ABS_MODE - 현재 위치와 상관없이 지정한 위치로 절대좌표 이동합니다.
//                        (1)POS_REL_MODE - 현재 위치에서 지정한 양만큼 상대좌표 이동합니다.
        AxmMotSetAbsRelMode(m_lAxisNo, dwAbsRelMode);
    end;

    if (cboProfile.Enabled = true) then
    begin
        dwProfileMode := ConvertComboToAxm(cboProfile);
//         ++ 지정 축의 구동 속도 프로파일 모드를 설정합니다.
//         uProfileMode : (0)SYM_TRAPEZOID_MODE  - Symmetric Trapezoid
//                        (1)ASYM_TRAPEZOID_MODE - Asymmetric Trapezoid
//                        (2)QUASI_S_CURVE_MODE  - Symmetric Quasi-S Curve
//                        (3)SYM_S_CURVE_MODE    - Symmetric S Curve
//                        (4)ASYM_S_CURVE_MODE   - Asymmetric S Curve
        AxmMotSetProfileMode(m_lAxisNo, dwProfileMode);
    end;

    dMinVel := StrToFloat(edtMinVel.Text);
    // ++ 지정 축의 최소 구동속도를 설정합니다.
    AxmMotSetMinVel(m_lAxisNo, dMinVel);

    dMaxVel := StrToFloat(edtMaxVel.Text);
    // ++ 지정 축의 최대 구동속도를 설정합니다.
    AxmMotSetMaxVel(m_lAxisNo, dMaxVel);

    dwPulse := StrToInt(edtMovePulse.Text);
    dUnit := StrToFloat(edtMoveUnit.Text);
    // ++ 지정 축의 거리/속도/가속도의 제어단위를 설정합니다.
    AxmMotSetMoveUnitPerPulse(m_lAxisNo, dUnit, dwPulse);
end;

// ++ =======================================================================
// >> btnApplySignalClick() : "Input/Output Signal Setting" 그룹의 "Apply" 버튼을
//    클릭했을 때 호출되는 핸들러 함수.
//  - 해당 그룹의 모든 설정값들을 각각의 AXL 함수들을 이용하여 적용합니다.
// ※ [CAUTION] 각 콘트롤(ComboBox, Edit) 변경시 AXL에 즉시 반영되지않습니다.
//    반드시 해당 그룹의 "Apply"버튼을 클릭해야 설정변경값이 AXL에 반영됩니다.
// --------------------------------------------------------------------------
procedure TForm1.btnApplySignalClick(Sender: TObject);
var
    dwUse, dwLevel, dwRetCode, dwStopMode : DWORD;
    dwPositiveLevel, dwNegativeLevel, dwEncoderType : DWORD;
begin
    dwUse := ConvertComboToAxm(cboInp);
//     ++ 지정 축의 Inposition(위치결정완료) 신호 Active Level/사용유무를 설정합니다.
//     - Inposition 신호를 사용안함으로 설정하면 모션제어 칩에서 펄스출력이 완료될 때 즉시구동 종료됩니다.
//     ※ [CAUTION] Inposition 신호를 사용함으로 설정하면 모션제어 칩에서 펄스출력이 완료된 후 서보팩으로 부터
//                  Inposition(위치결정완료) 신호가 Active될 때 까지 모션 구동중으로 됩니다.
//     ※ [CAUTION] Inposition 신호를 사용할 때 Active Level이 맞지않으면 최초 한번 구동 후 모션구동이 종료되지않아
//                  다음 구동을 할 수 없게 됩니다.
    AxmSignalSetInpos(m_lAxisNo, dwUse);

    if cboAlarmReset.Enabled then
    begin
      dwLevel := ConvertComboToAxm(cboAlarmReset);
      // ++ 지정 축의 Alarm Reset 신호 Active Level을 설정합니다.
      AxmSignalSetServoAlarmResetLevel(m_lAxisNo, dwLevel);
    end;

    // ++ 지정 축의 (+/-) End Limit 신호 Active Level/사용유무를 확인합니다.
    dwRetCode := AxmSignalGetLimit(m_lAxisNo, @dwStopMode, nil, nil);
    if (dwRetCode = AXT_RT_SUCCESS) then
    begin
        dwNegativeLevel := ConvertComboToAxm(cboELimitN);
        dwPositiveLevel := ConvertComboToAxm(cboELimitP);
        // ++ 지정 축의 (-) End Limit 신호 Active Level/사용유무를 설정합니다.
        AxmSignalSetLimit(m_lAxisNo, dwStopMode, dwPositiveLevel, dwNegativeLevel);
    end;

    if cboZPhaseLev.Enabled then
    begin
      dwLevel := ConvertComboToAxm(cboZPhaseLev);
      // ++ 지정 축의 Z상 Active Level을 설정합니다.
      AxmSignalSetZphaseLevel(m_lAxisNo, dwLevel);
    end;


    dwStopMode := ConvertComboToAxm(cboStopMode);
    dwLevel := ConvertComboToAxm(cboStopLevel);
    // ++ 지정 축의 Emergency 신호 Active Level/사용유무를 설정합니다.
    AxmSignalSetStop(m_lAxisNo, dwStopMode, dwLevel);

    dwLevel := ConvertComboToAxm(cboServoOn);
    // ++ 지정 축의 Servo On/Off 신호 Active Level을 설정합니다.
    AxmSignalSetServoOnLevel(m_lAxisNo, dwLevel);

    if cboAlarm.Enabled then
    begin
      dwUse := ConvertComboToAxm(cboAlarm);
      // ++ 지정 축의 Alarm Reset 신호 Active Level을 설정합니다.
      AxmSignalSetServoAlarm(m_lAxisNo, dwUse);
    end;

    // dwEncoderType := ConvertComboToAxm(cboEncoderType);
    //     ++ 지정 축의 Encoder Input Type를 설정합니다.
    //      dwEncoderType : (0)TYPE_INCREMENTAL
    //                      (1)TYPE_ABSOLUTE
    // AxmSignalSetEncoderType(m_lAxisNo, dwEncoderType);
end;

// ++ =======================================================================
// >> btnApplyHomeClick() : "Home Search Setting" 그룹의 "Apply" 버튼을 클릭했을 때
//    호출되는 핸들러 함수.
//  - 해당 그룹의 모든 설정값들을 각각의 AXL 함수들을 이용하여 적용합니다.
// ※ [CAUTION] 각 콘트롤(ComboBox, Edit) 변경시 AXL에 즉시 반영되지않습니다.
//    반드시 해당 그룹의 "Apply"버튼을 클릭해야 설정변경값이 AXL에 반영됩니다.
// --------------------------------------------------------------------------
procedure TForm1.btnApplyHomeClick(Sender: TObject);
var
    dwHomeDir, dwHomeSignal, dwHomeLevel, dwZPhas : DWORD;
    dHomeClrTime, dHomeOffset : Double;
begin
    dwHomeLevel := ConvertComboToAxm(cboHomeLevel);
    // ++ 지정 축의 원점신호 Active Level을 설정합니다.
    AxmHomeSetSignalLevel(m_lAxisNo, dwHomeLevel);

    dwHomeSignal := ConvertComboToAxm(cboHomeSignal);
    dwHomeDir := ConvertComboToAxm(cboHomeDir);
    dwZPhas := ConvertComboToAxm(cboZPhaseUse);

    dHomeClrTime := StrToFloat(edtHomeClrTime.Text);
    dHomeOffset := StrToFloat(edtHomeOffset.Text);
    // ++ 지정 축의 원점검색 관련 정보들을 설정합니다.
    AxmHomeSetMethod(m_lAxisNo, dwHomeDir, dwHomeSignal, dwZPhas, dHomeClrTime, dHomeOffset);
end;

// ++ =======================================================================
// >> btnApplySoftLimitClick() : "Software Limit Setting " 그룹의 "Apply" 버튼을
//    클릭했을 때 호출되는 핸들러 함수.
//  - 해당 그룹의 모든 설정값들을 각각의 AXL 함수들을 이용하여 적용합니다.
// ※ [CAUTION] 각 콘트롤(ComboBox, Edit) 변경시 AXL에 즉시 반영되지않습니다.
//    반드시 해당 그룹의 "Apply"버튼을 클릭해야 설정변경값이 AXL에 반영됩니다.
// --------------------------------------------------------------------------
procedure TForm1.btnApplySoftLimitClick(Sender: TObject);
var
    dwRetCode, dwUse, dwStopMode, dwSelection : DWORD;
    dPositivePos, dNegativePos : Double;
begin
    // ++ 지정한 축에 Software Limit기능을 확인합니다.
    dwRetCode := AxmSignalGetSoftLimit(m_lAxisNo, @dwUse, @dwStopMode,
                              @dwSelection, nil, nil);
    if (dwRetCode = AXT_RT_SUCCESS) then
    begin
        dNegativePos := StrToFloat(edtSLimitPosN.Text);
        dPositivePos := StrToFloat(edtSLimitPosP.Text);

        dwUse := ConvertComboToAxm(cboSLimitEnable);
        dwStopMode := ConvertComboToAxm(cboSLimitStopMode);
        dwSelection := ConvertComboToAxm(cboSLimitSelect);

//         ++ 지정 축의 소프트웨어 리미트를 설정합니다.
//         uUse       : (0)DISABLE        - 소프트웨어 리미트 기능을 사용하지 않습니다.
//                      (1)ENABLE         - 소프트웨어 리미트 기능을 사용합니다.
//         uStopMode  : (0)EMERGENCY_STOP - 소프트웨어 리미트 영역을 벗어날 경우 급정지합니다.
//                      (1)SLOWDOWN_STOP  - 소프트웨어 리미트 영역을 벗어날 경우 감속정지합니다.
//         uSelection : (0)COMMAND        - 기준위치를 지령위치로 합니다.
//                      (1)ACTUAL         - 기준위치를 엔코더 위치로 합니다.
        AxmSignalSetSoftLimit(m_lAxisNo, dwUse, dwStopMode, dwSelection, dPositivePos, dNegativePos);
    end;
end;

// ++ =======================================================================
// >> btnApplyUserParaClick() : "User Move Parameter Setting " 그룹의 "Apply"
//    버튼을 클릭했을 때 호출되는 핸들러 함수.
//  - 해당 그룹의 모든 설정값들을 각각의 AXL 함수들을 이용하여 적용합니다.
// ※ [CAUTION] 각 콘트롤(ComboBox, Edit) 변경시 AXL에 즉시 반영되지않습니다.
//    반드시 해당 그룹의 "Apply"버튼을 클릭해야 설정변경값이 AXL에 반영됩니다.
// --------------------------------------------------------------------------
procedure TForm1.btnApplyUserParaClick(Sender: TObject);
var
    dInitPos, dInitVel, dInitAccel, dInitDecel : Double;
begin
    dInitPos := StrToFloat(edtPosition.Text);
    dInitVel := StrToFloat(edtVelocity.Text);
    dInitAccel := StrToFloat(edtAccel.Text);
    dInitDecel := StrToFloat(edtDecel.Text);

    // ++ 지정 축의 사용자 관련 파라메타들을 설정합니다.
    AxmMotSetParaLoad(m_lAxisNo, dInitPos, dInitVel, dInitAccel, dInitDecel);
end;

// ++ =======================================================================
// >> btnApplyAllAxesClick() : "Apply All Axes" 버튼을 클릭시 호출되는 핸들러 함수.
//  - 모든 설정값들을 각각의 AXL 함수들을 이용하여 모든 축에 적용합니다.
// ※ [CAUTION] 모든 축에 설정값 동일하게 적용시 모션축의 종류에 따라 적용
//    되지않는 파라메타가 있을 수 있습니다.
// --------------------------------------------------------------------------
procedure TForm1.btnApplyAllAxesClick(Sender: TObject);
var
    dwAxisNo, dwMovePulse, dwModeProfile, dwUseAlarm, dwMethodPulse : DWORD;
    dwMethodEncoder, dwModeAbsRel, dwUseInp, dwLevelAlarmReset : DWORD;
    dwRetCode, dwLevelLimitN, dwLevelLimitP, dwLevelZPhase : DWORD;
    dwModeStop, dwLevelStop, dwLevelServoOn, dwTypeEncoder : DWORD;
    dwHomeDir, dwHomeSignal, dwLevelHome, dwZPhas, dwUse : DWORD;
    dwStopMode, dwSelection : DWORD;
    dVelocityMin, dVelocityMax, dMoveUnit : Double;
    dHomeClrTime, dHomeOffset, dPositivePos, dNegativePos : Double;
    dInitPos, dInitVel, dInitAccel, dInitDecel : Double;
begin
    // Pulse/Encoder Method && Move Parameter Setting
    dwMethodPulse := ConvertComboToAxm(cboPulse);
    dwMethodEncoder := ConvertComboToAxm(cboEncoder);
    dwUseAlarm := ConvertComboToAxm(cboAlarm);
    dwModeAbsRel := ConvertComboToAxm(cboAbsRel);
    dwModeProfile := ConvertComboToAxm(cboProfile);
    dVelocityMin := StrToFloat(edtMinVel.Text);
    dVelocityMax := StrToFloat(edtMaxVel.Text);
    dwMovePulse := StrToInt(edtMovePulse.Text);
    dMoveUnit := StrToFloat(edtMoveUnit.Text);

    // Input/Output Signal Setting
    dwUseInp := ConvertComboToAxm(cboInp);
    dwLevelAlarmReset := ConvertComboToAxm(cboAlarmReset);
    dwLevelLimitN := ConvertComboToAxm(cboELimitN);
    dwLevelLimitP := ConvertComboToAxm(cboELimitP);
    dwLevelZPhase := ConvertComboToAxm(cboZPhaseLev);
    dwModeStop := ConvertComboToAxm(cboStopMode);
    dwLevelStop := ConvertComboToAxm(cboStopLevel);
    dwLevelServoOn := ConvertComboToAxm(cboServoOn);
    dwTypeEncoder := ConvertComboToAxm(cboEncoderType);

    // Home Search Setting
    dwLevelHome := ConvertComboToAxm(cboHomeLevel);
    dwHomeSignal := ConvertComboToAxm(cboHomeSignal);
    dwHomeDir := ConvertComboToAxm(cboHomeDir);
    dwZPhas := ConvertComboToAxm(cboZPhaseUse);
    dHomeClrTime := StrToFloat(edtHomeClrTime.Text);
    dHomeOffset := StrToFloat(edtHomeOffset.Text);

    // Software Limit Setting
    dNegativePos := StrToFloat(edtSLimitPosN.Text);
    dPositivePos := StrToFloat(edtSLimitPosP.Text);

    // User Move Parameter Setting
    dInitPos := StrToFloat(edtPosition.Text);
    dInitVel := StrToFloat(edtVelocity.Text);
    dInitAccel := StrToFloat(edtAccel.Text);
    dInitDecel := StrToFloat(edtDecel.Text);

    for dwAxisNo := 0 to (m_lAxisCounts - 1) do
    begin
        // Pulse/Encoder Method && Move Parameter Setting
        if (cboPulse.Enabled = true) then
        begin
//             ++ 지정 축의 펄스 출력 방식을 설정합니다.
//            uMethod : (0)OneHighLowHigh   - 1펄스 방식, PULSE(Active High), 정방향(DIR=Low)  / 역방향(DIR=High)
//                      (1)OneHighHighLow   - 1펄스 방식, PULSE(Active High), 정방향(DIR=High) / 역방향(DIR=Low)
//                      (2)OneLowLowHigh    - 1펄스 방식, PULSE(Active Low),  정방향(DIR=Low)  / 역방향(DIR=High)
//                      (3)OneLowHighLow    - 1펄스 방식, PULSE(Active Low),  정방향(DIR=High) / 역방향(DIR=Low)
//                      (4)TwoCcwCwHigh     - 2펄스 방식, PULSE(CCW:역방향),  DIR(CW:정방향),  Active High
//                      (5)TwoCcwCwLow      - 2펄스 방식, PULSE(CCW:역방향),  DIR(CW:정방향),  Active Low
//                      (6)TwoCwCcwHigh     - 2펄스 방식, PULSE(CW:정방향),   DIR(CCW:역방향), Active High
//                      (7)TwoCwCcwLow      - 2펄스 방식, PULSE(CW:정방향),   DIR(CCW:역방향), Active Low
//                      (8)TwoPhase         - 2상(90' 위상차),  PULSE lead DIR(CW: 정방향), PULSE lag DIR(CCW:역방향)
//                      (9)TwoPhaseReverse  - 2상(90' 위상차),  PULSE lead DIR(CCW: 정방향), PULSE lag DIR(CW:역방향)
            AxmMotSetPulseOutMethod(dwAxisNo, dwMethodPulse);
        end;

        // Pulse/Encoder Method && Move Parameter Setting
        if (cboEncoder.Enabled = true) then
        begin
//             ++ 지정 축의 Encoder 입력 방식을 설정합니다.
//             uMethod : (0)ObverseUpDownMode - 정방향 Up/Down
//                       (1)ObverseSqr1Mode   - 정방향 1체배
//                       (2)ObverseSqr2Mode   - 정방향 2체배
//                       (3)ObverseSqr4Mode   - 정방향 4체배
//                       (4)ReverseUpDownMode - 역방향 Up/Down
//                       (5)ReverseSqr1Mode   - 역방향 1체배
//                       (6)ReverseSqr2Mode   - 역방향 2체배
//                       (7)ReverseSqr4Mode   - 역방향 4체배
            AxmMotSetEncInputMethod(dwAxisNo, dwMethodEncoder);
        end;

        if (cboAlarm.Enabled = true) then
        begin
            // ++ 지정 축의 비상정지 신호 사용유무/Active Level을 설정합니다.
            AxmSignalSetServoAlarm(dwAxisNo, dwUseAlarm);
        end;

        if (cboAbsRel.Enabled = true) then
        begin
//             ++ 지정 축의 구동 좌표계를 설정합니다.
//             dwAbsRelMode : (0)POS_ABS_MODE - 현재 위치와 상관없이 지정한 위치로 절대좌표 이동합니다.
//                            (1)POS_REL_MODE - 현재 위치에서 지정한 양만큼 상대좌표 이동합니다.
            AxmMotSetAbsRelMode(dwAxisNo, dwMethodPulse);
        end;

        if (cboProfile.Enabled = true) then
        begin
//             dwProfileMode : (0)SYM_TRAPEZOID_MODE  - Symmetric Trapezoid
//                             (1)ASYM_TRAPEZOID_MODE - Asymmetric Trapezoid
//                             (2)QUASI_S_CURVE_MODE  - Symmetric Quasi-S Curve
//                             (3)SYM_S_CURVE_MODE    - Symmetric S Curve
//                             (4)ASYM_S_CURVE_MODE   - Asymmetric S Curve
            AxmMotSetProfileMode(dwAxisNo, dwModeProfile);
        end;

        // ++ 지정 축의 초기 구동속도를 설정합니다.
        AxmMotSetMinVel(dwAxisNo, dVelocityMin);
        // ++ 지정 축의 최대 구동속도를 설정합니다.
        AxmMotSetMaxVel(dwAxisNo, dVelocityMax);
        // ++ 지정 축의 거리/속도/가속도의 제어단위를 설정합니다.
        AxmMotSetMoveUnitPerPulse(dwAxisNo, dMoveUnit, dwMovePulse);

//         Input/Output Signal Setting
//         ++ 지정 축의 Inposition(위치결정완료) 신호 Active Level/사용유무를 설정합니다.
//          - Inposition 신호를 사용안함으로 설정하면 모션제어 칩에서 펄스출력이 완료될 때 즉시구동 종료됩니다.
//          ※ [CAUTION] Inposition 신호를 사용함으로 설정하면 모션제어 칩에서 펄스출력이 완료된 후 서보팩으로 부터
//                       Inposition(위치결정완료) 신호가 Active될 때 까지 모션 구동중으로 됩니다.
//          ※ [CAUTION] Inposition 신호를 사용할 때 Active Level이 맞지않으면 최초 한번 구동 후 모션구동이 종료되지않아
//                       다음 구동을 할 수 없게 됩니다.
        AxmSignalSetInpos(dwAxisNo, dwUseInp);

        // ++ 지정 축의 Alarm Reset 신호 Active Level을 설정합니다.
        AxmSignalSetServoAlarmResetLevel(dwAxisNo, dwLevelAlarmReset);

        // ++ 지정 축의 (+/-) End Limit 신호 Active Level/사용유무를 확인합니다.
        dwRetCode := AxmSignalGetLimit(dwAxisNo, @dwStopMode, nil, nil);
        if (dwRetCode = AXT_RT_SUCCESS) then
            //++ 지정 축의 (-) End Limit 신호 Active Level/사용유무를 설정합니다.
            AxmSignalSetLimit(dwAxisNo, dwStopMode, dwLevelLimitP, dwLevelLimitN);

        // ++ 지정 축의 Z상 Active Level을 설정합니다.
        AxmSignalSetZphaseLevel(dwAxisNo, dwLevelZPhase);

        // ++ 지정 축의 Emergency 신호 Active Level/사용유무를 설정합니다.
        AxmSignalSetStop(dwAxisNo, dwModeStop, dwLevelStop);

        // ++ 지정 축의 Servo On/Off 신호 Active Level을 설정합니다.
        AxmSignalSetServoOnLevel(dwAxisNo, dwLevelServoOn);

//         ++ 지정 축의 Encoder Input Type를 설정합니다.
//          dwEncoderType : (0)TYPE_INCREMENTAL
//                          (1)TYPE_ABSOLUTE
        //AxmSignalSetEncoderType(dwAxisNo, dwTypeEncoder);

//         Home Search Setting
//         ++ 지정 축의 원점신호 Active Level을 설정합니다.
        AxmHomeSetSignalLevel(dwAxisNo, dwLevelHome);

        // ++ 지정 축의 원점검색 관련 정보들을 설정합니다.
        AxmHomeSetMethod(dwAxisNo, dwHomeDir, dwHomeSignal, dwZPhas, dHomeClrTime, dHomeOffset);

//         Software Limit Setting
//         ++ 지정한 축에 Software Limit기능을 확인합니다.
        dwRetCode := AxmSignalGetSoftLimit(dwAxisNo, @dwUse, @dwStopMode, @dwSelection, nil, nil);
        if (dwRetCode = AXT_RT_SUCCESS) then
        begin
            dwUse := ConvertComboToAxm(cboSLimitEnable);
            dwStopMode := ConvertComboToAxm(cboSLimitStopMode);
            dwSelection := ConvertComboToAxm(cboSLimitSelect);

//             ++ 지정 축의 소프트웨어 리미트를 설정합니다.
//             uUse       : (0)DISABLE        - 소프트웨어 리미트 기능을 사용하지 않습니다.
//                          (1)ENABLE         - 소프트웨어 리미트 기능을 사용합니다.
//             uStopMode  : (0)EMERGENCY_STOP - 소프트웨어 리미트 영역을 벗어날 경우 급정지합니다.
//                          (1)SLOWDOWN_STOP  - 소프트웨어 리미트 영역을 벗어날 경우 감속정지합니다.
//             uSelection : (0)COMMAND        - 기준위치를 지령위치로 합니다.
//                          (1)ACTUAL         - 기준위치를 엔코더 위치로 합니다.
            AxmSignalSetSoftLimit(dwAxisNo, dwUse, dwStopMode, dwSelection, dPositivePos, dNegativePos);
        end;

        // ++ 지정 축의 사용자 관련 파라메타들을 설정합니다.
        AxmMotSetParaLoad(dwAxisNo, dInitPos, dInitVel, dInitAccel, dInitDecel);
    end;
end;

// ++ =======================================================================
// >> m_timer_Tick(...) : 타이머 이벤트 핸들러 함수.
//  - 일정한 주기로 변경되는 위치/속도/정보등을 Control에 반영합니다.
// --------------------------------------------------------------------------
procedure TForm1.m_timerTimer(Sender: TObject);
var
    dwState1, dwState2, dwRetCode : DWORD;
begin
    // ++ Z상 신호의 상태를 확인합니다.
    dwRetCode := AxmStatusReadMechanical(m_lAxisNo, @dwState1);
    if (dwRetCode = AXT_RT_SUCCESS) then
    begin
        dwState1 := iif(((dwState1 and QIMECHANICAL_ZPHASE_LEVEL) = 0), 0, 1);
        if (dwState1 = 1) then chkZPhase.Checked := true
        else chkZPhase.Checked := false;
    end;

    // ++ Servo Alarm 신호의 상태를 확인합니다.
    dwRetCode := AxmSignalReadServoAlarm(m_lAxisNo, @dwState1);
    if (dwRetCode = AXT_RT_SUCCESS) then
    begin
        if (dwState1 = 1) then chkAlarm.Checked := true
        else chkAlarm.Checked := false;
    end;

    // ++ Inposition(위치결정완료) 신호의 상태를 확인합니다.
    dwRetCode := AxmSignalReadInpos(m_lAxisNo, @dwState1);
    if (dwRetCode = AXT_RT_SUCCESS) then
    begin
        if (dwState1 = 1) then chkInp.Checked := true
        else chkInp.Checked := false;
    end;

    // ++ Emergency 신호의 상태를 확인합니다.
    dwRetCode := AxmSignalReadStop(m_lAxisNo, @dwState1);
    if (dwRetCode = AXT_RT_SUCCESS) then
    begin
        if (dwState1 = 1) then chkEmg.Checked := true
        else chkEmg.Checked := false;
    end;

    // ++ (+/-)End Limit신호의 상태를 확인합니다.
    dwRetCode := AxmSignalReadLimit(m_lAxisNo, @dwState1, @dwState2);
    if (dwRetCode = AXT_RT_SUCCESS) then
    begin
        if (dwState1 = 1) then chkELimitP.Checked := true
        else chkELimitP.Checked := false;

        if (dwState2 = 1) then chkELimitN.Checked := true
        else chkELimitN.Checked := false;
    end;
end;

// **************************************************************************
// >> [구분]: 별도의 기능을 구현하기위해 만든 사용자 정의 함수들 모음
// **************************************************************************
//
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
    szModuleName :  PAnsiChar;
begin
    // ++ 유효한 전체 모션축수를 반환합니다.
    AxmInfoGetAxisCount(@m_lAxisCounts);
    if (m_lAxisCounts < 1) then
    begin
        Result := false;
        exit;
    end;

    m_lAxisNo := 0;
    // ++ 지정한 축의 정보를 반환합니다.
    // [INFO] 여러개의 정보를 읽는 함수 사용시 불필요한 정보는 nil을 입력하면 됩니다.
    AxmInfoGetAxis(m_lAxisNo, @dwBoardNo, @dwModulePos, @m_dwModuleID);

    // 유효한 전체 모션축수의 정보를 읽어 ComboBox에 등록합니다.
    For i := 0 to (m_lAxisCounts - 1) do
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
    dwPulse, dwMethod, dwStopMode, dwUse, dwPositiveLevel, dwNegativeLevel : DWORD;
    dwSWEnable, dwSWStopMode, dwSWRef, dwLevel, dwAbsRelMode : DWORD;
    dwProfileMode, dwRetCode, dwEncoderType, dwHmDir, dwHomeSignal, dwZPhas : DWORD;
    dUnit, dMinVel, dMaxVel, dSWLimitP, dSWLimitN, dHomeClrTime, dHomeOffset : Double;
    dInitPos, dInitVel, dInitAccel, dInitDecel, dVelFirst, dVelSecond : Double;
    dVelThird, dVelLast, dAccFirst, dAccSecond : Double;
begin
    // 각 제품별 지원여부에 따라 콘트롤 값들을 변경합니다.
    case m_dwModuleID of
        AXT_SMC_4V04, AXT_SMC_R1V04, AXT_SMC_2V04, AXT_SMC_R1V04PM2Q, AXT_SMC_R1V04PM2QE, AXT_SMC_R1V04MLIIIPM :
        begin
           cboPulse.Items.Clear();
           cboPulse.Enabled := true;
           cboPulse.AddItem('00:OneHighLowHigh', TObject(00));
           cboPulse.AddItem('01:OneHighHighLow', TObject(01));
           cboPulse.AddItem('02:OneLowLowHigh', TObject(002));
           cboPulse.AddItem('03:OneLowHighLow', TObject(03));
           cboPulse.AddItem('04:TwoCcwCwHigh', TObject(04));
           cboPulse.AddItem('05:TwoCcwCwLow', TObject(05));
           cboPulse.AddItem('06:TwoCwCcwHigh', TObject(06));
           cboPulse.AddItem('07:TwoCwCcwLow', TObject(07));
           cboPulse.AddItem('08:TwoPhase', TObject(08));
           cboPulse.AddItem('09:TwoPhaseReverse', TObject(09));

           cboEncoder.Items.Clear();
           cboEncoder.Enabled := true;
           cboEncoder.AddItem('00:ObverseUpDownMode', TObject(00));
           cboEncoder.AddItem('01:ObverseSqr1Mode', TObject(01));
           cboEncoder.AddItem('02:ObverseSqr2Mode', TObject(02));
           cboEncoder.AddItem('03:ObverseSqr4Mode', TObject(03));
           cboEncoder.AddItem('04:ReverseUpDownMode', TObject(04));
           cboEncoder.AddItem('05:ReverseSqr1Mode', TObject(05));
           cboEncoder.AddItem('06:ReverseSqr2Mode', TObject(06));
           cboEncoder.AddItem('07:ReverseSqr4Mode', TObject(07));

           cboAbsRel.Items.Clear();
           cboAbsRel.Enabled := true;
           cboAbsRel.AddItem('00:POS_ABS_MODE', TObject(00));
           cboAbsRel.AddItem('01:POS_REL_MODE', TObject(01));

           cboProfile.Items.Clear();
           cboProfile.Enabled := true;
           cboProfile.AddItem('00:SYM_TRAPEZOIDE_MODE', TObject(00));
           cboProfile.AddItem('01:ASYM_TRAPEZOIDE_MODE', TObject(01));
           cboProfile.AddItem('02:QUASI_S_CURVE_MODE', TObject(02));
           cboProfile.AddItem('03:SYM_S_CURVE_MODE', TObject(03));
           cboProfile.AddItem('04:ASYM_S_CURVE_MODE', TObject(04));

           cboZPhaseLev.Items.Clear();
           cboZPhaseLev.Enabled := true;
           cboZPhaseLev.AddItem('00:LOW', TObject(00));
           cboZPhaseLev.AddItem('01:HIGH', TObject(01));

           cboAlarm.Items.Clear();
           cboAlarm.Enabled := true;
           cboAlarm.AddItem('00:LOW', TObject(00));
           cboAlarm.AddItem('01:HIGH', TObject(01));
           cboAlarm.AddItem('02:UNUSED', TObject(02));

           cboInp.Items.Clear();
           cboInp.Enabled := true;
           cboInp.AddItem('00:LOW', TObject(00));
           cboInp.AddItem('01:HIGH', TObject(01));
           cboInp.AddItem('02:UNUSED', TObject(02));

           cboStopMode.Items.Clear();
           cboStopMode.Enabled := true;
           cboStopMode.AddItem('00:EMERGENCY', TObject(00));
           cboStopMode.AddItem('01:SLOWDOWN', TObject(01));

           cboStopLevel.Items.Clear();
           cboStopLevel.Enabled := true;
           cboStopLevel.AddItem('00:LOW', TObject(00));
           cboStopLevel.AddItem('01:HIGH', TObject(01));
           cboStopLevel.AddItem('02:UNUSED', TObject(02));

           cboELimitN.Items.Clear();
           cboELimitN.Enabled := true;
           cboELimitN.AddItem('00:LOW', TObject(00));
           cboELimitN.AddItem('01:HIGH', TObject(01));
           cboELimitN.AddItem('02:UNUSED', TObject(02));

           cboELimitP.Items.Clear();
           cboELimitP.Enabled := true;
           cboELimitP.AddItem('00:LOW', TObject(00));
           cboELimitP.AddItem('01:HIGH', TObject(01));
           cboELimitP.AddItem('02:UNUSED', TObject(02));

           cboServoOn.Items.Clear();
           cboServoOn.Enabled := true;
           cboServoOn.AddItem('00:LOW', TObject(00));
           cboServoOn.AddItem('01:HIGH', TObject(01));

           cboAlarmReset.Items.Clear();
           cboAlarmReset.Enabled := true;
           cboAlarmReset.AddItem('00:LOW', TObject(00));
                cboAlarmReset.AddItem('01:HIGH', TObject(01));

                edtSLimitPosN.Enabled := true;
                edtSLimitPosP.Enabled := true;

                cboEncoderType.Items.Clear();
           cboEncoderType.Enabled := false;
           cboEncoderType.AddItem('00:INCREMENTAL', TObject(00));

           cboHomeSignal.Items.Clear();
           cboHomeSignal.Enabled := true;
           cboHomeSignal.AddItem('00:PosEndLimit', TObject(00));
           cboHomeSignal.AddItem('01:NegEndLimit', TObject(01));
           cboHomeSignal.AddItem('04:HomeSensor', TObject(04));
           cboHomeSignal.AddItem('05:EncodZPhase', TObject(05));

           cboHomeLevel.Items.Clear();
           cboHomeLevel.Enabled := true;
           cboHomeLevel.AddItem('00:LOW', TObject(00));
           cboHomeLevel.AddItem('01:HIGH', TObject(01));

           cboHomeDir.Items.Clear();
           cboHomeDir.Enabled := true;
           cboHomeDir.AddItem('00:(-)DIR_CCW', TObject(00));
           cboHomeDir.AddItem('01:(+)DIR_CW', TObject(01));

           cboZPhaseUse.Items.Clear();
           cboZPhaseUse.Enabled := true;
           cboZPhaseUse.AddItem('00:UNUSED', TObject(00));
           cboZPhaseUse.AddItem('01:(+)DIR_CW', TObject(01));
           cboZPhaseUse.AddItem('02:(-)DIR_CCW', TObject(02));
        end;

        AXT_SMC_R1V04A4 :
        begin
           cboPulse.Items.Clear();
           cboPulse.Enabled := false;
           cboPulse.AddItem('00:OneHighLowHigh', TObject(00));

           cboEncoder.Items.Clear();
           cboEncoder.Enabled := false;
           cboEncoder.AddItem('00:ObverseUpDownMode', TObject(00));

           cboAbsRel.Items.Clear();
           cboAbsRel.Enabled := true;
           cboAbsRel.AddItem('00:POS_ABS_MODE', TObject(00));
           cboAbsRel.AddItem('01:POS_REL_MODE', TObject(01));

           cboProfile.Items.Clear();
           cboProfile.Enabled := true;
           cboProfile.AddItem('00:SYM_TRAPEZOIDE_MODE', TObject(00));
           cboProfile.AddItem('01:ASYM_TRAPEZOIDE_MODE', TObject(01));
           cboProfile.AddItem('02:QUASI_S_CURVE_MODE', TObject(02));
           cboProfile.AddItem('03:SYM_S_CURVE_MODE', TObject(03));
           cboProfile.AddItem('04:ASYM_S_CURVE_MODE', TObject(04));

           cboZPhaseLev.Items.Clear();
           cboZPhaseLev.Enabled := false;
           cboZPhaseLev.AddItem('02:UNUSED', TObject(02));

           cboAlarm.Items.Clear();
           cboAlarm.Enabled := true;
           cboAlarm.AddItem('01:HIGH', TObject(01));
           cboAlarm.AddItem('02:UNUSED', TObject(02));

           cboInp.Items.Clear();
           cboInp.Enabled := true;
           cboInp.AddItem('01:HIGH', TObject(01));
           cboInp.AddItem('02:UNUSED', TObject(02));

           cboStopMode.Items.Clear();
           cboStopMode.Enabled := true;
           cboStopMode.AddItem('00:EMERGENCY', TObject(00));
           cboStopMode.AddItem('01:SLOWDOWN', TObject(01));

           cboStopLevel.Items.Clear();
           cboStopLevel.Enabled := true;
           cboStopLevel.AddItem('00:LOW', TObject(00));
           cboStopLevel.AddItem('02:UNUSED', TObject(02));

           cboELimitN.Items.Clear();
           cboELimitN.Enabled := true;
           cboELimitN.AddItem('00:LOW', TObject(00));
           cboELimitN.AddItem('02:UNUSED', TObject(02));

           cboELimitP.Items.Clear();
           cboELimitP.Enabled := true;
           cboELimitP.AddItem('00:LOW', TObject(00));
           cboELimitP.AddItem('02:UNUSED', TObject(02));

           cboServoOn.Items.Clear();
           cboServoOn.Enabled := false;
           cboServoOn.AddItem('01:HIGH', TObject(01));

           cboAlarmReset.Items.Clear();
           cboAlarmReset.Enabled := false;
           cboAlarmReset.AddItem('01:HIGH', TObject(01));

           edtSLimitPosN.Enabled := false;
           edtSLimitPosP.Enabled := false;

           cboEncoderType.Items.Clear();
           cboEncoderType.Enabled := false;
           cboEncoderType.AddItem('00:INCREMENTAL', TObject(00));

           cboHomeSignal.Items.Clear();
           cboHomeSignal.Enabled := true;
           cboHomeSignal.AddItem('00:PosEndLimit', TObject(00));
           cboHomeSignal.AddItem('01:NegEndLimit', TObject(01));
           cboHomeSignal.AddItem('04:HomeSensor', TObject(04));

           cboHomeLevel.Items.Clear();
           cboHomeLevel.Enabled := true;
           cboHomeLevel.AddItem('00:LOW', TObject(00));
           cboHomeLevel.AddItem('01:HIGH', TObject(01));

           cboHomeDir.Items.Clear();
           cboHomeLevel.Enabled := true;
           cboHomeLevel.AddItem('00:(-)DIR_CCW', TObject(00));
           cboHomeLevel.AddItem('01:(+)DIR_CW', TObject(01));

           cboZPhaseUse.Items.Clear();
           cboZPhaseUse.Enabled := false;
           cboZPhaseUse.AddItem('00:UNUSED', TObject(00));
        end;

        AXT_SMC_R1V04MLIIPM :
        begin
           cboPulse.Items.Clear();
           cboPulse.Enabled := true;
           cboPulse.AddItem('00:OneHighLowHigh', TObject(00));
           cboPulse.AddItem('06:TwoCwCcwHigh', TObject(06));

           cboEncoder.Items.Clear();
           cboEncoder.Enabled := false;
           cboEncoder.AddItem('00:ObverseUpDownMode', TObject(00));

           cboAbsRel.Items.Clear();
           cboAbsRel.Enabled := true;
           cboAbsRel.AddItem('00:POS_ABS_MODE', TObject(00));
           cboAbsRel.AddItem('01:POS_REL_MODE', TObject(01));

           cboProfile.Items.Clear();
           cboProfile.Enabled := true;
           cboProfile.AddItem('00:SYM_TRAPEZOIDE_MODE', TObject(00));
           cboProfile.AddItem('01:ASYM_TRAPEZOIDE_MODE', TObject(01));
           cboProfile.AddItem('02:QUASI_S_CURVE_MODE', TObject(02));
           cboProfile.AddItem('03:SYM_S_CURVE_MODE', TObject(03));
           cboProfile.AddItem('04:ASYM_S_CURVE_MODE', TObject(04));

           cboZPhaseLev.Items.Clear();
           cboZPhaseLev.Enabled := false;
           cboZPhaseLev.AddItem('02:UNUSED', TObject(02));

           cboAlarm.Items.Clear();
           cboAlarm.Enabled := false;
           cboAlarm.AddItem('02:UNUSED', TObject(02));

           cboInp.Items.Clear();
           cboInp.Enabled := false;
           cboInp.AddItem('02:UNUSED', TObject(02));

           cboStopMode.Items.Clear();
           cboStopMode.Enabled := false;
           cboStopMode.AddItem('00:EMERGENCY', TObject(00));

           cboStopLevel.Items.Clear();
           cboStopLevel.Enabled := false;
           cboStopLevel.AddItem('02:UNUSED', TObject(02));

           cboELimitN.Items.Clear();
           cboELimitN.Enabled := false;
           cboELimitN.AddItem('02:UNUSED', TObject(02));

           cboELimitP.Items.Clear();
           cboELimitP.Enabled := false;
           cboELimitP.AddItem('02:UNUSED', TObject(02));

           cboServoOn.Items.Clear();
           cboServoOn.Enabled := false;
           cboServoOn.AddItem('01:HIGH', TObject(01));

           cboAlarmReset.Items.Clear();
           cboAlarmReset.Enabled := false;
           cboAlarmReset.AddItem('01:HIGH', TObject(01));

           edtSLimitPosN.Enabled := false;
           edtSLimitPosP.Enabled := false;

           cboEncoderType.Items.Clear();
           cboEncoderType.Enabled := false;
           cboEncoderType.AddItem('00:INCREMENTAL', TObject(00));

           cboHomeSignal.Items.Clear();
           cboHomeSignal.Enabled := false;
           cboHomeSignal.AddItem('04:HomeSensor', TObject(04));

           cboHomeLevel.Items.Clear();
           cboHomeLevel.Enabled := false;
           cboHomeLevel.AddItem('01:HIGH', TObject(01));

           cboHomeDir.Items.Clear();
           cboHomeLevel.Enabled := true;
           cboHomeLevel.AddItem('00:(-)DIR_CCW', TObject(00));
           cboHomeLevel.AddItem('01:(+)DIR_CW', TObject(01));

           cboZPhaseUse.Items.Clear();
           cboZPhaseUse.Enabled := false;
           cboZPhaseUse.AddItem('00:UNUSED', TObject(00));
        end;

        AXT_SMC_R1V04MLIISV, AXT_SMC_R1V04A5, AXT_SMC_R1V04MLIICL, AXT_SMC_R1V04MLIICR, AXT_SMC_R1V04MLIIORI, AXT_SMC_R1V04SIIIHMIV, AXT_SMC_R1V04SIIIHMIV_R :
        begin
           cboPulse.Items.Clear();
           cboPulse.Enabled := false;
           cboPulse.AddItem('00:OneHighLowHigh', TObject(00));

           cboEncoder.Items.Clear();
           cboEncoder.Enabled := false;
           cboEncoder.AddItem('00:ObverseUpDownMode', TObject(00));

           cboZPhaseLev.Items.Clear();
           cboZPhaseLev.Enabled := false;
           cboZPhaseLev.AddItem('02:UNUSED', TObject(02));

           cboAlarm.Items.Clear();
           cboAlarm.Enabled := true;
           cboAlarm.AddItem('01:HIGH', TObject(01));
           cboAlarm.AddItem('02:UNUSED', TObject(02));

           cboInp.Items.Clear();
           cboInp.Enabled := true;
           cboInp.AddItem('01:HIGH', TObject(01));
           cboInp.AddItem('02:UNUSED', TObject(02));

           cboStopMode.Items.Clear();
           cboStopMode.Enabled := false;
           cboStopMode.AddItem('00:EMERGENCY', TObject(00));

           cboStopLevel.Items.Clear();
           cboStopLevel.Enabled := false;
           cboStopLevel.AddItem('02:UNUSED', TObject(02));

           cboELimitN.Items.Clear();
           cboELimitN.Enabled := true;
           cboELimitN.AddItem('01:HIGH', TObject(01));
           cboELimitN.AddItem('02:UNUSED', TObject(02));

           cboELimitP.Items.Clear();
           cboELimitP.Enabled := true;
           cboELimitP.AddItem('01:HIGH', TObject(01));
           cboELimitP.AddItem('02:UNUSED', TObject(02));

           cboServoOn.Items.Clear();
           cboServoOn.Enabled := false;
           cboServoOn.AddItem('01:HIGH', TObject(01));

           cboAlarmReset.Items.Clear();
           cboAlarmReset.Enabled := false;
           cboAlarmReset.AddItem('01:HIGH', TObject(01));

           edtSLimitPosN.Enabled := false;
           edtSLimitPosP.Enabled := false;

           cboEncoderType.Items.Clear();
           cboEncoderType.Enabled := true;
           cboEncoderType.AddItem('00:INCREMENTAL', TObject(00));
           cboEncoderType.AddItem('01:ABSOLUTE', TObject(01));

           cboHomeSignal.Items.Clear();
           cboHomeSignal.Enabled := true;
           cboHomeSignal.AddItem('00:PosEndLimit', TObject(00));
           cboHomeSignal.AddItem('01:NegEndLimit', TObject(01));
           cboHomeSignal.AddItem('04:HomeSensor', TObject(04));

           cboHomeLevel.Items.Clear();
           cboHomeLevel.Enabled := false;
           cboHomeLevel.AddItem('01:HIGH', TObject(01));

           cboHomeDir.Items.Clear();
           cboHomeLevel.Enabled := true;
           cboHomeLevel.AddItem('00:(-)DIR_CCW', TObject(00));
           cboHomeLevel.AddItem('01:(+)DIR_CW', TObject(01));

           cboZPhaseUse.Items.Clear();
           cboZPhaseUse.Enabled := true;
           cboZPhaseUse.AddItem('00:UNUSED', TObject(00));
           cboZPhaseUse.AddItem('01:(+)DIR_CW', TObject(01));
           cboZPhaseUse.AddItem('02:(-)DIR_CCW', TObject(02));
        end;

        AXT_SMC_R1V04MLIIISV, AXT_SMC_R1V04MLIIISV_MD, AXT_SMC_R1V04MLIIIS7S, AXT_SMC_R1V04MLIIIS7W :
        begin
           cboPulse.Items.Clear();
           cboPulse.Enabled := false;
           cboPulse.AddItem('00:OneHighLowHigh', TObject(00));

           cboEncoder.Items.Clear();
           cboEncoder.Enabled := false;
           cboEncoder.AddItem('00:ObverseUpDownMode', TObject(00));

           cboZPhaseLev.Items.Clear();
           cboZPhaseLev.Enabled := false;
           cboZPhaseLev.AddItem('02:UNUSED', TObject(02));

           cboAlarm.Items.Clear();
           cboAlarm.Enabled := true;
           cboAlarm.AddItem('00:LOW', TObject(00));
           cboAlarm.AddItem('01:HIGH', TObject(01));
           cboAlarm.AddItem('02:UNUSED', TObject(02));

           cboInp.Items.Clear();
           cboInp.Enabled := true;
           cboInp.AddItem('00:LOW', TObject(00));
           cboInp.AddItem('01:HIGH', TObject(01));
           cboInp.AddItem('02:UNUSED', TObject(02));

           cboStopMode.Items.Clear();
           cboStopMode.Enabled := false;
           cboStopMode.AddItem('00:EMERGENCY', TObject(00));

           cboStopLevel.Items.Clear();
           cboStopLevel.Enabled := false;
           cboStopLevel.AddItem('02:UNUSED', TObject(02));

           cboELimitN.Items.Clear();
           cboELimitN.Enabled := true;
           cboELimitN.AddItem('00:LOW', TObject(00));
           cboELimitN.AddItem('01:HIGH', TObject(01));
           cboELimitN.AddItem('02:UNUSED', TObject(02));

           cboELimitP.Items.Clear();
           cboELimitP.Enabled := true;
           cboELimitP.AddItem('00:LOW', TObject(00));
           cboELimitP.AddItem('01:HIGH', TObject(01));
           cboELimitP.AddItem('02:UNUSED', TObject(02));

           cboServoOn.Items.Clear();
           cboServoOn.Enabled := false;
           cboServoOn.AddItem('01:HIGH', TObject(01));

           cboAlarmReset.Items.Clear();
           cboAlarmReset.Enabled := false;
           cboAlarmReset.AddItem('01:HIGH', TObject(01));

           edtSLimitPosN.Enabled := false;
           edtSLimitPosP.Enabled := false;

           cboEncoderType.Items.Clear();
           cboEncoderType.Enabled := true;
           cboEncoderType.AddItem('00:INCREMENTAL', TObject(00));
           cboEncoderType.AddItem('01:ABSOLUTE', TObject(01));

           cboHomeSignal.Items.Clear();
           cboHomeSignal.Enabled := true;
           cboHomeSignal.AddItem('00:PosEndLimit', TObject(00));
           cboHomeSignal.AddItem('01:NegEndLimit', TObject(01));
           cboHomeSignal.AddItem('04:HomeSensor', TObject(04));

           cboHomeLevel.Items.Clear();
           cboHomeLevel.Enabled := true;
           cboHomeLevel.AddItem('00:LOW', TObject(00));
           cboHomeLevel.AddItem('01:HIGH', TObject(01));

           cboHomeDir.Items.Clear();
           cboHomeLevel.Enabled := true;
           cboHomeLevel.AddItem('00:(-)DIR_CCW', TObject(00));
           cboHomeLevel.AddItem('01:(+)DIR_CW', TObject(01));

           cboZPhaseUse.Items.Clear();
           cboZPhaseUse.Enabled := true;
           cboZPhaseUse.AddItem('00:UNUSED', TObject(00));
           cboZPhaseUse.AddItem('01:(+)DIR_CW', TObject(01));
           cboZPhaseUse.AddItem('02:(-)DIR_CCW', TObject(02));
        end;

        AXT_ECAT_MOTION :
        begin
           cboPulse.Items.Clear();
           cboPulse.Enabled := false;
           cboPulse.AddItem('00:OneHighLowHigh', TObject(00));

           cboEncoder.Items.Clear();
           cboEncoder.Enabled := false;
           cboEncoder.AddItem('00:ObverseUpDownMode', TObject(00));

           cboAbsRel.Items.Clear();
           cboAbsRel.Enabled := true;
           cboAbsRel.AddItem('00:POS_ABS_MODE', TObject(00));
           cboAbsRel.AddItem('01:POS_REL_MODE', TObject(01));

           cboProfile.Items.Clear();
           cboProfile.Enabled := true;
           cboProfile.AddItem('00:SYM_TRAPEZOIDE_MODE', TObject(00));
           cboProfile.AddItem('01:ASYM_TRAPEZOIDE_MODE', TObject(01));
           cboProfile.AddItem('02:QUASI_S_CURVE_MODE', TObject(02));
           cboProfile.AddItem('03:SYM_S_CURVE_MODE', TObject(03));
           cboProfile.AddItem('04:ASYM_S_CURVE_MODE', TObject(04));

           cboZPhaseLev.Items.Clear();
           cboZPhaseLev.Enabled := false;
           cboZPhaseLev.AddItem('02:UNUSED', TObject(02));

           cboAlarm.Items.Clear();
           cboAlarm.Enabled := true;
           cboAlarm.AddItem('01:HIGH', TObject(01));
           cboAlarm.AddItem('02:UNUSED', TObject(02));

           cboInp.Items.Clear();
           cboInp.Enabled := true;
           cboInp.AddItem('00:LOW', TObject(00));
           cboInp.AddItem('01:HIGH', TObject(01));
           cboInp.AddItem('02:UNUSED', TObject(02));
           cboInp.AddItem('03:USED', TObject(03));

           cboStopMode.Items.Clear();
           cboStopMode.Enabled := true;
           cboStopMode.AddItem('00:EMERGENCY', TObject(00));
           cboStopMode.AddItem('01:SLOWDOWN', TObject(01));

           cboStopLevel.Items.Clear();
           cboStopLevel.Enabled := true;
           cboStopLevel.AddItem('00:LOW', TObject(00));
           cboStopLevel.AddItem('01:HIGH', TObject(01));
           cboStopLevel.AddItem('02:UNUSED', TObject(02));
           cboStopLevel.AddItem('03:USED', TObject(03));

           cboELimitN.Items.Clear();
           cboELimitN.Enabled := true;
           cboELimitN.AddItem('00:LOW', TObject(00));
           cboELimitN.AddItem('01:HIGH', TObject(01));
           cboELimitN.AddItem('02:UNUSED', TObject(02));
           cboELimitN.AddItem('03:USED', TObject(03));

           cboELimitP.Items.Clear();
           cboELimitP.Enabled := true;
           cboELimitP.AddItem('00:LOW', TObject(00));
           cboELimitP.AddItem('01:HIGH', TObject(01));
           cboELimitP.AddItem('02:UNUSED', TObject(02));
           cboELimitP.AddItem('03:USED', TObject(03));

           cboServoOn.Items.Clear();
           cboServoOn.Enabled := false;
           cboServoOn.AddItem('01:HIGH', TObject(01));

           cboAlarmReset.Items.Clear();
           cboAlarmReset.Enabled := false;
           cboAlarmReset.AddItem('01:HIGH', TObject(01));

           edtSLimitPosN.Enabled := false;
           edtSLimitPosP.Enabled := false;

           cboEncoderType.Items.Clear();
           cboEncoderType.Enabled := false;
           cboEncoderType.AddItem('00:INCREMENTAL', TObject(00));

           cboHomeSignal.Items.Clear();
           cboHomeSignal.Enabled := true;
           cboHomeSignal.AddItem('00:PosEndLimit', TObject(00));
           cboHomeSignal.AddItem('01:NegEndLimit', TObject(01));
           cboHomeSignal.AddItem('04:HomeSensor', TObject(04));
           cboHomeSignal.AddItem('05:EncodZPhase', TObject(05));

           cboHomeLevel.Items.Clear();
           cboHomeLevel.Enabled := true;
           cboHomeLevel.AddItem('00:LOW', TObject(00));
           cboHomeLevel.AddItem('01:HIGH', TObject(01));

           cboHomeDir.Items.Clear();
           cboHomeDir.Enabled := true;
           cboHomeDir.AddItem('00:(-)DIR_CCW', TObject(00));
           cboHomeDir.AddItem('01:(+)DIR_CW', TObject(01));

           cboZPhaseUse.Items.Clear();
           cboZPhaseUse.Enabled := true;
           cboZPhaseUse.AddItem('00:UNUSED', TObject(00));
           cboZPhaseUse.AddItem('01:(+)DIR_CW', TObject(01));
           cboZPhaseUse.AddItem('02:(-)DIR_CCW', TObject(02));
        end;

    end;

    // ++ 지정 축의 펄스 출력방식 설정값을 확인합니다.
    dwRetCode := AxmMotGetPulseOutMethod(m_lAxisNo, @dwMethod);
    if (dwRetCode <> AXT_RT_SUCCESS) then
    begin
        dwMethod := OneHighLowHigh;
    end;
    ConvertAxmToCombo(cboPulse, dwMethod);

    // ++ 지정 축의 엔코더 입력방식 설정값을 확인합니다.
    dwRetCode := AxmMotGetEncInputMethod(m_lAxisNo, @dwMethod);
    if (dwRetCode <> AXT_RT_SUCCESS) then
    begin
        dwMethod := ObverseUpDownMode;
    end;
    ConvertAxmToCombo(cboEncoder, dwMethod);

    // ++ 지정 축의 Servo Alarm 신호 Active Level/사용유무를 확인합니다.
    dwRetCode := AxmSignalGetServoAlarm(m_lAxisNo, @dwUse);
    if (dwRetCode <> AXT_RT_SUCCESS) then
    begin
        dwUse := UNUSED;
    end;
    ConvertAxmToCombo(cboAlarm, dwUse);

    // ++ 지정 축의 최저속도를 확인합니다.
    dwRetCode := AxmMotGetMinVel(m_lAxisNo, @dMinVel);
    if (dwRetCode <> AXT_RT_SUCCESS) then
    begin
        dMinVel := 1.0;
    end;
    edtMinVel.Text := Format('%*.*f', [1, 3, dMinVel]);

    // ++ 지정 축의 최고속도를 확인합니다.
    dwRetCode := AxmMotGetMaxVel(m_lAxisNo, @dMaxVel);
    if (dwRetCode <> AXT_RT_SUCCESS) then
    begin
        dMaxVel := 1.0;
    end;
    edtMaxVel.Text := Format('%*.*f', [1, 3, dMaxVel]);

    // ++ 지정 축의 거리/속도/가속도의 제어단위/설정값들을 확인합니다.
    dwRetCode := AxmMotGetMoveUnitPerPulse(m_lAxisNo, @dUnit, @dwPulse);
    if (dwRetCode <> AXT_RT_SUCCESS) then
    begin
        dUnit := 1.0;
        dwPulse := 1;
    end;
    edtMoveUnit.Text := Format('%*.*f', [1, 3, dUnit]);
    edtMovePulse.Text := Format('%d', [dwPulse]);

    // ++ 지정 축의 Z상 신호 Active Level 설정값을 확인합니다.
    dwRetCode := AxmSignalGetZphaseLevel(m_lAxisNo, @dwLevel);
    if (dwRetCode <> AXT_RT_SUCCESS) then
    begin
        dwLevel := UNUSED;
    end;
    ConvertAxmToCombo(cboZPhaseLev, dwLevel);

    // ++ 지정 축의 Inposition(위치결정완료) 신호 Active Level/사용유무를 확인합니다.
    dwRetCode := AxmSignalGetInpos(m_lAxisNo, @dwUse);
    if (dwRetCode <> AXT_RT_SUCCESS) then
    begin
        dwUse := UNUSED;
    end;
    ConvertAxmToCombo(cboInp, dwUse);

    // ++ 지정 축의 Emergency 신호 Active Level/사용유무를 확인합니다.
    dwRetCode := AxmSignalGetStop(m_lAxisNo, @dwStopMode, @dwLevel);
    if (dwRetCode <> AXT_RT_SUCCESS) then
    begin
        dwStopMode := UNUSED;
        dwLevel := UNUSED;
    end;
    ConvertAxmToCombo(cboStopMode, dwStopMode);
    ConvertAxmToCombo(cboStopLevel, dwLevel);

    // ++ 지정 축의 (+/-) End Limit 신호 Active Level/사용유무를 확인합니다.
    dwRetCode := AxmSignalGetLimit(m_lAxisNo, nil, @dwPositiveLevel, @dwNegativeLevel);
    if (dwRetCode <> AXT_RT_SUCCESS) then
    begin
        dwPositiveLevel := UNUSED;
        dwNegativeLevel := UNUSED;
    end;
    ConvertAxmToCombo(cboELimitP, dwPositiveLevel);
    ConvertAxmToCombo(cboELimitN, dwNegativeLevel);

    // ++ 지정 축의 Servo On/Off 신호 Active Level을 확인합니다.
    dwRetCode := AxmSignalGetServoOnLevel(m_lAxisNo, @dwLevel);
    if (dwRetCode <> AXT_RT_SUCCESS) then
    begin
        dwLevel := UNUSED;
    end;
    ConvertAxmToCombo(cboServoOn, dwLevel);

    // ++ 지정 축의 Alarm Reset 신호 Active Level을 확인합니다.
    dwRetCode := AxmSignalGetServoAlarmResetLevel(m_lAxisNo, @dwLevel);
    if (dwRetCode <> AXT_RT_SUCCESS) then
    begin
        dwLevel := UNUSED;
    end;
    ConvertAxmToCombo(cboAlarmReset, dwLevel);

    // ++ 지정 축의 Software Limit기능을 확인합니다.
    dwRetCode := AxmSignalGetSoftLimit(m_lAxisNo, @dwSWEnable, @dwSWStopMode,
                                      @dwSWRef, @dSWLimitP, @dSWLimitN);
    if (dwRetCode <> AXT_RT_SUCCESS) then
    begin
        dwSWEnable := DISABLE;
        dwSWStopMode := EMERGENCY_STOP;
        dwSWRef := UNUSED;
    end;
    cboSLimitEnable.Items.Clear();
    cboSLimitEnable.Enabled := true;
    cboSLimitEnable.AddItem('00:DISABLE', TObject(00));
    cboSLimitEnable.AddItem('01:ENABLE', TObject(01));
    cboSLimitStopMode.Items.Clear();
    cboSLimitStopMode.Enabled := true;
    cboSLimitStopMode.AddItem('00:EMERGENCY_STOP', TObject(00));
    cboSLimitStopMode.AddItem('01:SLOWDOWN_STOP', TObject(01));
    cboSLimitSelect.Items.Clear();
    cboSLimitSelect.Enabled := true;
    cboSLimitSelect.AddItem('00:COMMAND', TObject(00));
    cboSLimitSelect.AddItem('01:ACTUAL', TObject(01));
    ConvertAxmToCombo(cboSLimitEnable, dwSWEnable);
    ConvertAxmToCombo(cboSLimitStopMode, dwSWStopMode);
    ConvertAxmToCombo(cboSLimitSelect, dwSWRef);

    edtSLimitPosP.Text := Format('%*.*f', [1, 3, dSWLimitP]);
    edtSLimitPosN.Text := Format('%*.*f', [1, 3, dSWLimitN]);

    // ++ 지정한 축에 설정된 구동 좌표계를 확인합니다.
    dwRetCode := AxmMotGetAbsRelMode(m_lAxisNo, @dwAbsRelMode);
    if (dwRetCode <> AXT_RT_SUCCESS) then
    begin
        dwAbsRelMode := POS_ABS_MODE;
    end;
    ConvertAxmToCombo(cboAbsRel, dwAbsRelMode);

    // ++ 지정한 축에 설정된 구동 프로파일 모드를 확인합니다.
    dwRetCode := AxmMotGetProfileMode(m_lAxisNo, @dwProfileMode);
    if (dwRetCode <> AXT_RT_SUCCESS) then
    begin
        dwProfileMode := SYM_TRAPEZOIDE_MODE;
    end;
    ConvertAxmToCombo(cboProfile, dwProfileMode);

    // ++ 지정한 축에 설정된 Encoder Type을 확인합니다.
    //dwRetCode := AxmSignalGetEncoderType(m_lAxisNo, @dwEncoderType);
    dwRetCode := 0;
    if (dwRetCode <> AXT_RT_SUCCESS) then
    begin
        dwEncoderType := 0;
    end;
    ConvertAxmToCombo(cboEncoderType, dwEncoderType);

    // ++ 지정한 축에 원점검색 신호 Active Level을 확인합니다.
    dwRetCode := AxmHomeGetSignalLevel(m_lAxisNo, @dwLevel);
    if (dwRetCode <> AXT_RT_SUCCESS) then
    begin
        dwLevel := UNUSED;
    end;
    ConvertAxmToCombo(cboHomeLevel, dwLevel);

    // ++ 지정한 축에 원점검색 방법 설정값을 확인합니다.
    dwRetCode := AxmHomeGetMethod(m_lAxisNo, @dwHmDir, @dwHomeSignal,
                                @dwZPhas, @dHomeClrTime, @dHomeOffset);
    if (dwRetCode <> AXT_RT_SUCCESS) then
    begin
        dwHmDir := DIR_CCW;
        dwHomeSignal := HomeSensor;
        dwZPhas := UNUSED;
        dHomeClrTime := 1000.0;
        dHomeOffset := 0.0;
    end;
    ConvertAxmToCombo(cboHomeDir, dwHmDir);
    ConvertAxmToCombo(cboHomeSignal, dwHomeSignal);
    ConvertAxmToCombo(cboZPhaseUse, dwZPhas);
    edtHomeClrTime.Text := Format('%*.*f', [1, 3, dHomeClrTime]);
    edtHomeOffset.Text := Format('%*.*f', [1, 3, dHomeOffset]);

    // ++ 지정한 축에 원점검색 속도/가속도 설정값을 확인합니다.
    dwRetCode := AxmHomeGetVel(m_lAxisNo, @dVelFirst, @dVelSecond,
                                @dVelThird, @dVelLast, @dAccFirst, @dAccSecond);
    if (dwRetCode <> AXT_RT_SUCCESS) then
    begin
        dVelFirst := 100.0;
        dVelSecond := 100.0;
        dVelThird := 20.0;
        dVelLast := 1.0;
        dAccFirst := 400.0;
        dAccSecond := 400.0;
    end;
    edtVelFirst.Text := Format('%*.*f', [1, 3, dVelFirst]);
    edtVelSecond.Text := Format('%*.*f', [1, 3, dVelSecond]);
    edtVelThird.Text := Format('%*.*f', [1, 3, dVelThird]);
    edtVelLast.Text := Format('%*.*f', [1, 3, dVelLast]);
    edtAccFirst.Text := Format('%*.*f', [1, 3, dAccFirst]);
    edtAccSecond.Text := Format('%*.*f', [1, 3, dAccSecond]);

    // ++ 지정한 축에 원점검색 속도/가속도 설정값을 확인합니다.
    dwRetCode := AxmMotGetParaLoad(m_lAxisNo, @dInitPos, @dInitVel,
                                @dInitAccel, @dInitDecel);
    if (dwRetCode <> AXT_RT_SUCCESS) then
    begin
        dInitPos := 1000.0;
        dInitVel := 200.0;
        dInitAccel := 400.0;
        dInitDecel := 400.0;
    end;
    edtPosition.Text := Format('%*.*f', [1, 3, dInitPos]);
    edtVelocity.Text := Format('%*.*f', [1, 3, dInitVel]);
    edtAccel.Text := Format('%*.*f', [1, 3, dInitAccel]);
    edtDecel.Text := Format('%*.*f', [1, 3, dInitDecel]);

    Result := true;
end;

procedure TForm1.WMSysCommand(var Msg: TWMSysCommand);
begin
    if (Msg.CmdType = SC_MINIMIZE) or (Msg.CmdType = SC_MAXIMIZE) then
        Msg.CmdType := SC_RESTORE;

    DefaultHandler(Msg);
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
    strText : String;
    dwSelData : Integer;
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

end.
