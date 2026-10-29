unit SignalMonitor;
// SignalMonitor.pas : implementation file
//
// **************************************************************************
// >> [일자]: 2015.12.09
// >> [개요]: 이 예제는 신호 관련 함수들의 사용법을 익히고 제품별 지원되는
//    기능들을 파악할 수 있도록 작성된 예제입니다.
// >> [중요]: 신호설정 함수 사용시 주의사항
//     1) 제품의 종류에 따라서 신호설정에 사용되는 인자가 달라질 수 있습니다.
//     2) 네트웍 제품의 리미트 신호나 원점신호의 레벨 변경은 서보팩 파라메타를
//        변경해서 바꿀수 있습니다.
// **************************************************************************

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, ExtCtrls,
  AXL, AXM, AXHS;

type
  TForm1 = class(TForm)
    GroupBox1: TGroupBox;
    Label1: TLabel;
    cboSelAxis: TComboBox;
    btnLoadFile: TButton;
    GroupBox2: TGroupBox;
    Shape1: TShape;
    cboZPhase: TComboBox;
    cboAlarm: TComboBox;
    cboELimitN: TComboBox;
    chkZPhase: TCheckBox;
    cboInp: TComboBox;
    chkAlarm: TCheckBox;
    chkELimitN: TCheckBox;
    chkInp: TCheckBox;
    cboEmg: TComboBox;
    cboELimitP: TComboBox;
    chkEmg: TCheckBox;
    chkELimitP: TCheckBox;
    GroupBox3: TGroupBox;
    Shape2: TShape;
    cboServoOn: TComboBox;
    cboAlarmReset: TComboBox;
    Label2: TLabel;
    Label3: TLabel;
    GroupBox4: TGroupBox;
    Shape3: TShape;
    chkInp00: TCheckBox;
    chkInp01: TCheckBox;
    chkInp02: TCheckBox;
    chkInp03: TCheckBox;
    chkInp04: TCheckBox;
    chkOut00: TCheckBox;
    chkOut01: TCheckBox;
    chkOut02: TCheckBox;
    chkOut03: TCheckBox;
    chkOut04: TCheckBox;
    GroupBox5: TGroupBox;
    Shape4: TShape;
    chkSWLimitN: TCheckBox;
    chkSWLimitP: TCheckBox;
    Label4: TLabel;
    cboSWStop: TComboBox;
    Label5: TLabel;
    cboSWRef: TComboBox;
    Label6: TLabel;
    Label7: TLabel;
    edtSWPosN: TEdit;
    edtSWPosP: TEdit;
    chkSWEnable: TCheckBox;
    OpenDialog1: TOpenDialog;
    m_timer: TTimer;
    procedure FormCreate(Sender: TObject);
    Function InitLibrary() : Boolean; stdcall;
    Function AddAxisInfo() : Boolean; stdcall;
    Function InitControl() : Boolean; stdcall;
    Function UpdateState() : Boolean; stdcall;
    Function ConvertAxmToCombo(pCboItem : TComboBox; dwCurData : DWORD) : DWORD;
    Function ConvertComboToAxm(pCboItem : TComboBox) : DWORD;
    function iif(c: boolean; a, b: integer): integer;
    procedure cboSelAxisChange(Sender: TObject);
    procedure btnLoadFileClick(Sender: TObject);
    procedure chkOut_Changed(lBitNo: DWORD; chkInpX: TCheckBox; chkOutX: TCheckBox);
    procedure chkOut00Click(Sender: TObject);
    procedure chkOut01Click(Sender: TObject);
    procedure chkOut02Click(Sender: TObject);
    procedure chkOut03Click(Sender: TObject);
    procedure chkOut04Click(Sender: TObject);
    procedure cboZPhaseChange(Sender: TObject);
    procedure cboAlarmChange(Sender: TObject);
    procedure cboInpChange(Sender: TObject);
    procedure cboEmgChange(Sender: TObject);
    procedure cboELimitNChange(Sender: TObject);
    procedure cboELimitPChange(Sender: TObject);
    procedure cboServoOnChange(Sender: TObject);
    procedure cboAlarmResetChange(Sender: TObject);
    procedure chkSWEnableClick(Sender: TObject);
    procedure m_timerTimer(Sender: TObject);
  private
    { Private declarations }
    m_lAxisNo, m_lAxisCount : DWORD;
    m_dwModuleID : DWORD;

  public
    { Public declarations }
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
// >> chkOut_Changed(...) : "Output Bit" 버튼들 클릭시 호출되는 핸들러 함수.
//  - IDC_CHK_OUT_00 ~ IDC_CHK_OUT_04 버튼의 클릭이벤트 발생시 호출됩니다.
// --------------------------------------------------------------------------
procedure TForm1.chkOut_Changed(lBitNo: DWORD; chkInpX: TCheckBox; chkOutX: TCheckBox);
var
    strData : String;
    dwRetCode, dwOnOff : DWORD;
begin
    if (chkInpX.Checked = true) then dwOnOff := 1
    else dwOnOff := 0;
    // ++ 선택한 축에 지정한 Bit의 출력접점을 변경합니다.
    dwRetCode := AxmSignalWriteOutputBit(m_lAxisNo, lBitNo, dwOnOff);
    if (dwRetCode <> AXT_RT_SUCCESS) then
    begin
        chkOutX.Checked := false;
        strData := Format('%.2d', [lBitNo]) + 'bit AxmSignalWriteOutputBit return error[Code:' +
            Format('%.4d]', [dwRetCode]);
        ShowMessage(strData);
    end;
end;

procedure TForm1.chkOut00Click(Sender: TObject);
begin
    chkOut_Changed(0, chkInp00, chkOut00);
end;

procedure TForm1.chkOut01Click(Sender: TObject);
begin
    chkOut_Changed(1, chkInp01, chkOut01);
end;

procedure TForm1.chkOut02Click(Sender: TObject);
begin
    chkOut_Changed(2, chkInp02, chkOut02);
end;

procedure TForm1.chkOut03Click(Sender: TObject);
begin
    chkOut_Changed(3, chkInp03, chkOut03);
end;

procedure TForm1.chkOut04Click(Sender: TObject);
begin
    chkOut_Changed(4, chkInp04, chkOut04);
end;

// ++ =======================================================================
// >> cboZPhaseChange() : "Z Phase"콤보박스 Item변경시 호출되는 핸들러 함수.
//  - 선택된 축의 Z상 신호 Active Level을 설정합니다.
// ※ [INFO] 특정 네트웍 제품의 경우 Z상 신호레벨 변경을 지원하지않습니다.
// --------------------------------------------------------------------------
procedure TForm1.cboZPhaseChange(Sender: TObject);
var
    strData : String;
    dwRetCode, dwLevel : DWORD;
begin
    // 이더켓은 AxmSignalSetZphaseLevel을 지원하지 않음.
    if (m_dwModuleID <> AXT_ECAT_MOTION) then
    begin
      dwLevel := ConvertComboToAxm(cboZPhase);
      // ++ 선택한 축의 Z상 Active Level을 설정합니다.
      dwRetCode := AxmSignalSetZphaseLevel(m_lAxisNo, dwLevel);
      if (dwRetCode <> AXT_RT_SUCCESS) then
      begin
          strData := Format('AxmSignalSetZphaseLevel return error[Code:%.4d]', [dwRetCode]);
          ShowMessage(strData);
      end;
    end;
end;

// ++ =======================================================================
// >> cboAlarmChange() : "Servo Alarm"콤보박스 Item변경시 호출되는 핸들러 함수.
//  - 선택된 축의 Servo Alarm 신호 Active Level/사용유무를 설정합니다.
//  - Servo Alarm 신호를 사용안함으로 설정하면 구동중  Alarm신호가 Active되어도
//    계속해서 목표지점까지 구동하게됩니다.
// ※ [INFO] 특정 네트웍 제품의 경우 Servo Alarm 신호레벨 변경을 지원하지않습니다.
// --------------------------------------------------------------------------
procedure TForm1.cboAlarmChange(Sender: TObject);
var
    strData : String;
    dwRetCode, dwLevel : DWORD;
begin
    // 이더켓은 AxmSignalSetServoAlarm를 지원하지 않음.
    if (m_dwModuleID <> AXT_ECAT_MOTION) then
    begin
      dwLevel := ConvertComboToAxm(cboAlarm);
      // ++ 선택한 축의 Servo Alarm 신호 Active Level/사용유무를 설정합니다.
      dwRetCode := AxmSignalSetServoAlarm(m_lAxisNo, dwLevel);
      if (dwRetCode <> AXT_RT_SUCCESS) then
      begin
          strData := Format('AxmSignalSetServoAlarm return error[Code:%.4d]', [dwRetCode]);
          ShowMessage(strData);
      end;
    end;
end;

// ++ =======================================================================
// >> cboInpChange() : "Inposition"콤보박스 Item변경시 호출되는 핸들러 함수.
//  - 선택된 축의 Inposition 신호 Active Level/사용유무를 설정합니다.
// ※ [INFO] 특정 네트웍 제품의 경우 Inposition 신호레벨 변경을 지원하지않습니다.
// --------------------------------------------------------------------------
procedure TForm1.cboInpChange(Sender: TObject);
var
    strData : String;
    dwRetCode, dwLevel : DWORD;
begin
    dwLevel := ConvertComboToAxm(cboInp);
    //++ 선택한 축의 Inposition(위치결정완료) 신호 Active Level/사용유무를 설정합니다.
	  // - Inposition 신호를 사용안함으로 설정하면 모션제어 칩에서 펄스출력이 완료될 때 즉시구동 종료됩니다.
	  // ※ [CAUTION] Inposition 신호를 사용함으로 설정하면 모션제어 칩에서 펄스출력이 완료된 후 서보팩으로 부터
	  //              Inposition(위치결정완료) 신호가 Active될 때 까지 모션 구동중으로 됩니다.
	  // ※ [CAUTION] Inposition 신호를 사용할 때 Active Level이 맞지않으면 최초 한번 구동 후 모션구동이 종료되지않아
	  //              다음 구동을 할 수 없게 됩니다.
    dwRetCode := AxmSignalSetInpos(m_lAxisNo, dwLevel);
    if (dwRetCode <> AXT_RT_SUCCESS) then
    begin
        strData := Format('AxmSignalSetInpos return error[Code:%.4d]', [dwRetCode]);
        ShowMessage(strData);
    end;
end;

// ++ =======================================================================
// >> OnSelchangeCboEmg() : "Emergency"콤보박스 Item변경시 호출되는 핸들러 함수.
//  - 선택된 축의 Emergency 신호 Active Level/사용유무를 설정합니다.
//  - Emergency 신호를 사용안함으로 설정하면 구동중  EMG신호가 Active되어도
//    계속해서 목표지점까지 구동하게됩니다.
// ※ [INFO] 특정 네트웍 제품의 경우 Emergency 신호를 지원하지않습니다.
// --------------------------------------------------------------------------
procedure TForm1.cboEmgChange(Sender: TObject);
var
    strData : String;
    dwRetCode, dwStopMode, dwLevel : DWORD;
begin
    // ++ 선택한 축의 Emergency 신호 Active Level/사용유무를 확인합니다.
    dwRetCode := AxmSignalGetStop(m_lAxisNo, @dwStopMode, @dwLevel);
    if (dwRetCode = AXT_RT_SUCCESS) then
    begin
        dwLevel := ConvertComboToAxm(cboEmg);
        // ++ 선택한 축의 Emergency 신호 Active Level/사용유무를 설정합니다.
        AxmSignalSetStop(m_lAxisNo, dwStopMode, dwLevel);
    end
    else
    begin
        strData := Format('AxmSignalGetStop return error[Code:%.4d]', [dwRetCode]);
        ShowMessage(strData);
    end;
end;

// ++ =======================================================================
// >> cboELimitNChange() : "(-) End Limit"콤보박스 Item변경시 호출되는 핸들러 함수.
//  - 선택된 축의 (-) End Limit 신호 Active Level/사용유무를 설정합니다.
//  - (-) End Limit 신호를 사용안함으로 설정하면 (-)방향으로 구동중  (-) End Limit신호가
//    Active되어도 계속해서 목표지점까지 구동하게됩니다.
// ※ [INFO] 특정 네트웍 제품의 경우 (-) End Limit 신호레벨 변경을 지원하지않습니다.
// --------------------------------------------------------------------------
procedure TForm1.cboELimitNChange(Sender: TObject);
var
    strData : String;
    dwRetCode, dwStopMode, dwPLevel, dwNLevel : DWORD;
begin
    // ++ 선택한 축의 (+/-) End Limit 신호 Active Level/사용유무를 확인합니다.
    dwRetCode := AxmSignalGetLimit(m_lAxisNo, @dwStopMode, @dwPLevel, @dwNLevel);
    if (dwRetCode = AXT_RT_SUCCESS) then
    begin
        dwNLevel := ConvertComboToAxm(cboELimitN);
        // ++ 선택한 축의 (-) End Limit 신호 Active Level/사용유무를 설정합니다.
        AxmSignalSetLimit(m_lAxisNo, dwStopMode, dwPLevel, dwNLevel);
    end
    else
    begin
        strData := Format('AxmSignalSetLimit return error[Code:%.4d]', [dwRetCode]);
        ShowMessage(strData);
    end;
end;

// ++ =======================================================================
// >> cboELimitPChange() : "(+) End Limit"콤보박스 Item변경시 호출되는 핸들러 함수.
//  - 선택된 축의 (+) End Limit 신호 Active Level/사용유무를 설정합니다.
//  - (+) End Limit 신호를 사용안함으로 설정하면 (+)방향으로 구동중  (+) End Limit신호가
//    Active되어도 계속해서 목표지점까지 구동하게됩니다.
// ※ [INFO] 특정 네트웍 제품의 경우 (+) End Limit 신호레벨 변경을 지원하지않습니다.
// --------------------------------------------------------------------------
procedure TForm1.cboELimitPChange(Sender: TObject);
var
    strData : String;
    dwRetCode, dwStopMode, dwPLevel, dwNLevel : DWORD;
begin
    dwRetCode := AxmSignalGetLimit(m_lAxisNo, @dwStopMode, @dwPLevel, @dwNLevel);
    if (dwRetCode = AXT_RT_SUCCESS) then
    begin
        dwPLevel := ConvertComboToAxm(cboELimitP);
        // ++ 선택한 축의 (+) End Limit 신호 Active Level/사용유무를 설정합니다.
        AxmSignalSetLimit(m_lAxisNo, dwStopMode, dwPLevel, dwNLevel);
    end
    else
    begin
        strData := Format('AxmSignalSetLimit return error[Code:%.4d]', [dwRetCode]);
        ShowMessage(strData);
    end;
end;

// ++ =======================================================================
// >> cboServoOnChange() : "Servo On Level"콤보박스 Item변경시 호출되는 핸들러 함수.
//  - 선택된 축의 Servo On/Off 신호 Active Level을 설정합니다.
// ※ [INFO] 특정 네트웍 제품의 경우 Servo On/Off 신호레벨 변경을 지원하지않습니다.
// --------------------------------------------------------------------------
procedure TForm1.cboServoOnChange(Sender: TObject);
var
    strData : String;
    dwRetCode, dwLevel : DWORD;
begin
    // 이더켓은 AxmSignalSetServoOnLevel을 지원하지 않음.
    if (m_dwModuleID <> AXT_ECAT_MOTION) then
    begin
      dwLevel := ConvertComboToAxm(cboServoOn);
      // ++ 선택된 축의 Servo On/Off 신호 Active Level을 설정합니다.
      dwRetCode := AxmSignalSetServoOnLevel(m_lAxisNo, dwLevel);
      if (dwRetCode <> AXT_RT_SUCCESS) then
      begin
          strData := Format('AxmSignalSetServoOnLevel return error[Code:%.4d]', [dwRetCode]);
          ShowMessage(strData);
      end;
    end;
end;

// ++ =======================================================================
// >> cboAlarmResetChange() : "Alm Reset Level"콤보박스 Item변경시 호출되는 핸들러 함수.
//  - 선택된 축의 Alarm Reset 신호 Active Level을 설정합니다.
// ※ [INFO] 특정 네트웍 제품의 경우 Alarm Reset 신호레벨 변경을 지원하지않습니다.
// --------------------------------------------------------------------------
procedure TForm1.cboAlarmResetChange(Sender: TObject);
var
    strData : String;
    dwRetCode, dwLevel : DWORD;
begin
    // 이더켓은 AxmSignalSetServoAlarmResetLevel 지원하지 않음.
    if (m_dwModuleID <> AXT_ECAT_MOTION) then
    begin
      dwLevel := ConvertComboToAxm(cboAlarmReset);
      // ++ 선택된 축의 Alarm Reset 신호 Active Level을 설정합니다.
      dwRetCode := AxmSignalSetServoAlarmResetLevel(m_lAxisNo, dwLevel);
      if (dwRetCode <> AXT_RT_SUCCESS) then
      begin
          strData := Format('AxmSignalSetServoAlarmResetLevel return error[Code:%.4d]', [dwRetCode]);
          ShowMessage(strData);
      end;
    end;
end;

// ++ =======================================================================
// >> chkSWEnableClick() : "Enable"버튼 클릭시 호출되는 핸들러 함수.
//  - 선택된 축에 Software Limit기능을 설정합니다.
// --------------------------------------------------------------------------
procedure TForm1.chkSWEnableClick(Sender: TObject);
var
    strData : String;
    dwRetCode, dwSWEnable, dwSWStopMode, dwSWRef : DWORD;
    dSWLimitP, dSWLimitN : Double;
begin
    if (chkSWEnable.Checked = true) then dwSWEnable := 1
    else dwSWEnable := 0;
    dwSWStopMode := ConvertComboToAxm(cboSWStop);
    dwSWRef := ConvertComboToAxm(cboSWRef);
    dSWLimitP := StrToFloat(edtSWPosP.Text);
    dSWLimitN := StrToFloat(edtSWPosN.Text);

    //++ 지정한 축에 Software Limit기능을 설정합니다.
	  // ※ [INFO] Software Limit 기능은 원점검색시 무시됩니다. 원점검색이 완료되면 자동으로 이전 상태가 됩니다.
    dwRetCode := AxmSignalSetSoftLimit(m_lAxisNo, dwSWEnable, dwSWStopMode,
              dwSWRef, dSWLimitP, dSWLimitN);
    if (dwRetCode <> AXT_RT_SUCCESS) then
    begin
        strData := Format('AxmSignalSetSoftLimit return error[Code:%.4d]', [dwRetCode]);
        ShowMessage(strData);
    end;
end;

// ++ =======================================================================
// >> m_timerTimer(...) : 타이머 이벤트 핸들러 함수.
//  - 일정한 주기로 변경되는 위치/속도/정보등을 Control에 반영합니다.
// --------------------------------------------------------------------------
procedure TForm1.m_timerTimer(Sender: TObject);
var
    dwState1, dwState2, dwRetCode, lBitNo : DWORD;
    chkGroupInp : array[0..4] of TCheckBox;
    chkGroupOut : array[0..4] of TCheckBox;
begin
    chkGroupInp[0] := chkInp00;
    chkGroupInp[1] := chkInp01;
    chkGroupInp[2] := chkInp02;
    chkGroupInp[3] := chkInp03;
    chkGroupInp[4] := chkInp04;

    chkGroupOut[0] := chkOut00;
    chkGroupOut[1] := chkOut01;
    chkGroupOut[2] := chkOut02;
    chkGroupOut[3] := chkOut03;
    chkGroupOut[4] := chkOut04;

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

    for lBitNo := 0 to (UIO_OUT5 - 1) do
    begin
        // ++ 범용입력 신호의(Bit00-Bit04) 상태를 확인합니다.
        dwRetCode := AxmSignalReadInputBit(m_lAxisNo, lBitNo, @dwState1);
        if (dwRetCode = AXT_RT_SUCCESS) then
        begin
            if (dwState1 = 1) then chkGroupInp[lBitNo].Checked := true
            else chkGroupInp[lBitNo].Checked := false;
        end;

        // ++ 범용출력 신호의(Bit00-Bit04) 상태를 확인합니다.
        dwRetCode := AxmSignalReadOutputBit(m_lAxisNo, lBitNo, @dwState2);
        if (dwRetCode = AXT_RT_SUCCESS) then
        begin
            if (dwState2 = 1) then chkGroupOut[lBitNo].Checked := true
            else chkGroupOut[lBitNo].Checked := false;
        end;
    end;

    // ++ (+/-)Software Limit의 Active 상태를 확인합니다.
    dwRetCode := AxmSignalReadSoftLimit(m_lAxisNo, @dwState1, @dwState2);
    if (dwRetCode = AXT_RT_SUCCESS) then
    begin
        if (dwState1 = 1) then chkSWLimitP.Checked := true
        else chkSWLimitP.Checked := false;

        if (dwState2 = 1) then chkSWLimitN.Checked := true
        else chkSWLimitN.Checked := false;
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
    dwUse, dwPositiveLevel, dwNegativeLevel : DWORD;
    dwSWEnable, dwSWStopMode, dwSWRef, dwLevel : DWORD;
    dwRetCode: DWORD;
    dSWLimitP, dSWLimitN : Double;
begin
    // 각 제품별 지원여부에 따라 콘트롤 값들을 변경합니다.
    case m_dwModuleID of
        AXT_SMC_4V04, AXT_SMC_R1V04, AXT_SMC_2V04, AXT_SMC_R1V04PM2Q, AXT_SMC_R1V04PM2QE, AXT_SMC_R1V04MLIIIPM :
        begin
           cboZPhase.Items.Clear();
           cboZPhase.Enabled := true;
           cboZPhase.AddItem('00:LOW', TObject(00));
           cboZPhase.AddItem('01:HIGH', TObject(01));

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

           cboEmg.Items.Clear();
           cboEmg.Enabled := true;
           cboEmg.AddItem('00:LOW', TObject(00));
           cboEmg.AddItem('01:HIGH', TObject(01));
           cboEmg.AddItem('02:UNUSED', TObject(02));

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

           cboSWRef.Items.Clear();
           cboSWRef.Enabled := true;
           cboSWRef.AddItem('00:COMMAND', TObject(00));
           cboSWRef.AddItem('01:ACTUAL', TObject(01));

           cboSWStop.Items.Clear();
           cboSWStop.Enabled := true;
           cboSWStop.AddItem('00:E_STOP', TObject(00));
           cboSWStop.AddItem('01:S_STOP', TObject(01));

           edtSWPosN.Enabled := true;
           edtSWPosP.Enabled := true;
           chkSWEnable.Enabled := true;
        end;

        AXT_SMC_R1V04A4 :
        begin
           cboZPhase.Items.Clear();
           cboZPhase.Enabled := false;
           cboZPhase.AddItem('02:UNUSED', TObject(02));

           cboAlarm.Items.Clear();
           cboAlarm.Enabled := true;
           cboAlarm.AddItem('01:HIGH', TObject(01));
           cboAlarm.AddItem('02:UNUSED', TObject(02));

           cboInp.Items.Clear();
           cboInp.Enabled := true;
           cboInp.AddItem('01:HIGH', TObject(01));
           cboInp.AddItem('02:UNUSED', TObject(02));

           cboEmg.Items.Clear();
           cboEmg.Enabled := true;
           cboEmg.AddItem('00:LOW', TObject(00));
           cboEmg.AddItem('02:UNUSED', TObject(02));

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

           cboSWRef.Items.Clear();
           cboSWRef.Enabled := false;
           cboSWRef.AddItem('02:UNUSED', TObject(02));

           cboSWStop.Items.Clear();
           cboSWStop.Enabled := false;
           cboSWStop.AddItem('02:UNUSED', TObject(02));

           edtSWPosN.Enabled := false;
           edtSWPosP.Enabled := false;
           chkSWEnable.Enabled := false;
        end;

        AXT_SMC_R1V04MLIIPM :
        begin
           cboZPhase.Items.Clear();
           cboZPhase.Enabled := false;
           cboZPhase.AddItem('02:UNUSED', TObject(02));

           cboAlarm.Items.Clear();
           cboAlarm.Enabled := false;
           cboAlarm.AddItem('02:UNUSED', TObject(02));

           cboInp.Items.Clear();
           cboInp.Enabled := false;
           cboInp.AddItem('02:UNUSED', TObject(02));

           cboEmg.Items.Clear();
           cboEmg.Enabled := false;
           cboEmg.AddItem('02:UNUSED', TObject(02));

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

           cboSWRef.Items.Clear();
           cboSWRef.Enabled := false;
           cboSWRef.AddItem('02:UNUSED', TObject(02));

           cboSWStop.Items.Clear();
           cboSWStop.Enabled := false;
           cboSWStop.AddItem('02:UNUSED', TObject(02));

           edtSWPosN.Enabled := false;
           edtSWPosP.Enabled := false;
           chkSWEnable.Enabled := false;
        end;

        AXT_SMC_R1V04MLIISV, AXT_SMC_R1V04A5, AXT_SMC_R1V04MLIICL, AXT_SMC_R1V04MLIICR, AXT_SMC_R1V04MLIIORI, AXT_SMC_R1V04SIIIHMIV, AXT_SMC_R1V04SIIIHMIV_R :
        begin
           cboZPhase.Items.Clear();
           cboZPhase.Enabled := false;
           cboZPhase.AddItem('02:UNUSED', TObject(02));

           cboAlarm.Items.Clear();
           cboAlarm.Enabled := true;
           cboAlarm.AddItem('01:HIGH', TObject(01));
           cboAlarm.AddItem('02:UNUSED', TObject(02));

           cboInp.Items.Clear();
           cboInp.Enabled := true;
           cboInp.AddItem('01:HIGH', TObject(01));
           cboInp.AddItem('02:UNUSED', TObject(02));

           cboEmg.Items.Clear();
           cboEmg.Enabled := false;
           cboEmg.AddItem('02:UNUSED', TObject(02));

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

           cboSWRef.Items.Clear();
           cboSWRef.Enabled := false;
           cboSWRef.AddItem('02:UNUSED', TObject(02));

           cboSWStop.Items.Clear();
           cboSWStop.Enabled := false;
           cboSWStop.AddItem('02:UNUSED', TObject(02));

           edtSWPosN.Enabled := false;
           edtSWPosP.Enabled := false;
           chkSWEnable.Enabled := false;
        end;

        AXT_SMC_R1V04MLIIISV, AXT_SMC_R1V04MLIIISV_MD, AXT_SMC_R1V04MLIIIS7S, AXT_SMC_R1V04MLIIIS7W :
        begin
           cboZPhase.Items.Clear();
           cboZPhase.Enabled := false;
           cboZPhase.AddItem('02:UNUSED', TObject(02));

           cboAlarm.Items.Clear();
           cboAlarm.Enabled := true;
           cboAlarm.AddItem('00:LOW', TObject(00));
           cboAlarm.AddItem('01:HIGH', TObject(01));
           cboAlarm.AddItem('02:UNUSED', TObject(02));

           cboInp.Items.Clear();
           cboInp.Enabled := true;
           cboInp.AddItem('01:HIGH', TObject(01));
           cboInp.AddItem('02:UNUSED', TObject(02));

           cboEmg.Items.Clear();
           cboEmg.Enabled := false;
           cboEmg.AddItem('02:UNUSED', TObject(02));

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
           cboServoOn.AddItem('00:LOW', TObject(00));
           cboServoOn.AddItem('01:HIGH', TObject(01));

           cboAlarmReset.Items.Clear();
           cboAlarmReset.Enabled := false;
           cboAlarmReset.AddItem('01:HIGH', TObject(01));

           cboSWRef.Items.Clear();
           cboSWRef.Enabled := false;
           cboSWRef.AddItem('02:UNUSED', TObject(02));

           cboSWStop.Items.Clear();
           cboSWStop.Enabled := false;
           cboSWStop.AddItem('02:UNUSED', TObject(02));

           edtSWPosN.Enabled := false;
           edtSWPosP.Enabled := false;
           chkSWEnable.Enabled := false;
        end;

        AXT_ECAT_MOTION :
        begin
           cboZPhase.Items.Clear();
           cboZPhase.Enabled := false;
           cboZPhase.AddItem('02:UNUSED', TObject(02));

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

           cboEmg.Items.Clear();
           cboEmg.Enabled := true;
           cboEmg.AddItem('00:LOW', TObject(00));
           cboEmg.AddItem('01:HIGH', TObject(01));
           cboEmg.AddItem('02:UNUSED', TObject(02));
           cboEmg.AddItem('03:USED', TObject(03));

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
           cboELimitP.AddItem('02:UNUSED', TObject(02));

           cboServoOn.Items.Clear();
           cboServoOn.Enabled := false;
           cboServoOn.AddItem('01:HIGH', TObject(01));

           cboAlarmReset.Items.Clear();
           cboAlarmReset.Enabled := false;
           cboAlarmReset.AddItem('01:HIGH', TObject(01));

           cboSWRef.Items.Clear();
           cboSWRef.Enabled := false;
           cboSWRef.AddItem('02:UNUSED', TObject(02));

           cboSWStop.Items.Clear();
           cboSWStop.Enabled := false;
           cboSWStop.AddItem('02:UNUSED', TObject(02));

           edtSWPosN.Enabled := false;
           edtSWPosP.Enabled := false;
           chkSWEnable.Enabled := false;
        end;

    end;

    // ++ 지정 축의 Z상 신호 Active Level 설정값을 확인합니다.
    dwRetCode := AxmSignalGetZphaseLevel(m_lAxisNo, @dwLevel);
    if (dwRetCode <> AXT_RT_SUCCESS) then
    begin
        dwLevel := UNUSED;
    end;
    ConvertAxmToCombo(cboZPhase, dwLevel);

    // ++ 지정 축의 Servo Alarm 신호 Active Level/사용유무를 확인합니다.
    dwRetCode := AxmSignalGetServoAlarm(m_lAxisNo, @dwUse);
    if (dwRetCode <> AXT_RT_SUCCESS) then
    begin
        dwUse := UNUSED;
    end;
    ConvertAxmToCombo(cboAlarm, dwUse);

    // ++ 지정 축의 Inposition(위치결정완료) 신호 Active Level/사용유무를 확인합니다.
    dwRetCode := AxmSignalGetInpos(m_lAxisNo, @dwUse);
    if (dwRetCode <> AXT_RT_SUCCESS) then
    begin
        dwUse := UNUSED;
    end;
    ConvertAxmToCombo(cboInp, dwUse);

    // ++ 지정 축의 Emergency 신호 Active Level/사용유무를 확인합니다.
    dwRetCode := AxmSignalGetStop(m_lAxisNo, nil, @dwLevel);
    if (dwRetCode <> AXT_RT_SUCCESS) then
    begin
        dwLevel := UNUSED;
    end;
    ConvertAxmToCombo(cboEmg, dwLevel);

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
    ConvertAxmToCombo(cboSWStop, dwSWStopMode);
    ConvertAxmToCombo(cboSWRef, dwSWRef);
    edtSWPosP.Text := Format('%*.*f', [1, 3, dSWLimitP]);
    edtSWPosN.Text := Format('%*.*f', [1, 3, dSWLimitN]);

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
    dwCount, dwSelData : DWORD;
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

end.
