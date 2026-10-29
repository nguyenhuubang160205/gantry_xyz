unit OutputWriteMulti;
// OutputWriteMulti.pas : implementation file
//
// **************************************************************************
// >> [일자]: 2016.01.19
// >> [개요]: 이 예제는 AIO모듈의 다중 채널 출력 기능 사용 방법을 학습하는 예제입니다.
// >> [중요]: 출력 관련 함수들
//     1) AxaoSetMultiRange 함수는 지정 다중 출력 채널에 출력 전압 범위를 설정합니다.
//     2) AxaoWriteMultiVoltage 함수는 지정 다중 출력 채널에 특정 전압 값을 출력합니다.
//     3) AxaoReadVoltage 함수는 지정 단일 출력 채널에 출력하고 있는 전압 값을
//        확인합니다.
// **************************************************************************

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, ExtCtrls, StdCtrls, AXL, AXHS, AXA;

type
  TForm1 = class(TForm)
    Label1: TLabel;
    Label2: TLabel;
    Label3: TLabel;
    Label4: TLabel;
    GroupBox1: TGroupBox;
    m_cboModule: TComboBox;
    m_cboVoltageRange: TComboBox;
    m_edtSetVoltCh00: TEdit;
    m_btnSet: TButton;
    m_scrSetVoltCh00: TScrollBar;
    m_stcOutVoltCh00: TEdit;
    m_timer: TTimer;
    m_edtSetVoltCh01: TEdit;
    m_scrSetVoltCh01: TScrollBar;
    m_stcOutVoltCh01: TEdit;
    m_edtSetVoltCh02: TEdit;
    m_scrSetVoltCh02: TScrollBar;
    m_stcOutVoltCh02: TEdit;
    m_edtSetVoltCh03: TEdit;
    m_scrSetVoltCh03: TScrollBar;
    m_stcOutVoltCh03: TEdit;
    procedure FormCreate(Sender: TObject);
    procedure FormDestroy(Sender: TObject);
    procedure m_cboModuleChange(Sender: TObject);
    procedure m_cboVoltageRangeChange(Sender: TObject);
    procedure m_btnSetClick(Sender: TObject);
    procedure m_scrSetVoltCh00Scroll(Sender: TObject;
      ScrollCode: TScrollCode; var ScrollPos: Integer);
    procedure m_scrSetVoltCh01Scroll(Sender: TObject;
      ScrollCode: TScrollCode; var ScrollPos: Integer);
    procedure m_scrSetVoltCh02Scroll(Sender: TObject;
      ScrollCode: TScrollCode; var ScrollPos: Integer);
    procedure m_scrSetVoltCh03Scroll(Sender: TObject;
      ScrollCode: TScrollCode; var ScrollPos: Integer);
    procedure m_timerTimer(Sender: TObject);
    Function InitLibrary() : Boolean; stdcall;
    Function AddModuleChannelInfo() : Boolean; stdcall;
    Function InitControl() : Boolean; stdcall;
    Function UpdateState() : Boolean; stdcall;
    Function ConvertAxaToCombo(pCboItem : TComboBox; dwCurData : DWORD) : DWORD;
    Function ConvertComboToAxa(pCboItem : TComboBox) : DWORD;
    procedure UpdateVoltageRange();
  private
    { Private declarations }
  public
    { Public declarations }
    m_dwModuleID     : DWORD;
    m_lModuleNo      : longInt;
    m_lModuleCount   : longInt;
    m_lChannelNo     : longInt;
    m_lChannelCount  : longInt;
    m_dOldVoltArr    : array[0..3] of double;
  end;

var
  Form1: TForm1;

implementation

{$R *.dfm}

procedure TForm1.FormCreate(Sender: TObject);
begin
     InitLibrary();                          // 라이브러리 초기화 작업을 수행합니다.
     AddModuleChannelInfo();                 // 검색된 모듈과 채널 정보를 ComboBox에 등록/Control들을 초기화합니다.
     UpdateState();                          // AIO모듈의 상태와 Control들의 상태를 일치시킵니다.
end;

procedure TForm1.FormDestroy(Sender: TObject);
begin
     //++ AXL 사용을 종료합니다.
     if(AxlIsOpened()) then
          AxlClose();
end;

// **************************************************************************
// >> [구분]: Control에 이벤트가 발생했을 때 처리하는 함수들 모음
// **************************************************************************

// ++ =======================================================================
// >> m_cboModuleChange() : 모듈 변경시 호출되는 핸들러 함수.
//  - 모듈이 변경되었을 때 변경된 모듈의 ID와 Control들을 갱신합니다.
// --------------------------------------------------------------------------
procedure TForm1.m_cboModuleChange(Sender: TObject);
var
     dwRetCode : DWord;
     lBoardNo, lModulePos : longInt;
     strChNum, strData, strValue : String;
     dVoltArr : array[0..3] of double;
     lChannelArr : array[0..3] of longInt;
     i : Integer;
begin
     m_lModuleNo := m_cboModule.ItemIndex;
     // 변경된 모듈의 ID를 가져옵니다.
     AxaInfoGetModule(m_lModuleNo, @lBoardNo, @lModulePos, @m_dwModuleID);

     // 변경된 모듈의 채널 수를 가져옵니다.
	 AxaInfoGetInputCount(m_lModuleNo, @m_lChannelCount);

     // 전압 범위 업데이트
	 //++ 지정 입력 채널에 설정한 입력 전압 범위를 확인합니다.
	 UpdateVoltageRange();

     //++ 모듈 변경 시 0번 채널에서 출력하던 값 그대로 EDIT와 슬라이더에도 반영
     dVoltArr[0] := 0.0;
     dVoltArr[1] := 0.0;
     dVoltArr[2] := 0.0;
     dVoltArr[3] := 0.0;
     lChannelArr[0] := 0;
     lChannelArr[1] := 1;
     lChannelArr[2] := 2;
     lChannelArr[3] := 3;
	 dwRetCode := AxaoReadMultiVoltage(4, @lChannelArr[0], @dVoltArr[0]);
     if (dwRetCode <> AXT_RT_SUCCESS) then
     begin
          strData := format('AxaoReadMultiVoltage return error[Code:%.4d]', [dwRetCode]);
          ShowMessage(strData);
     end;
     strValue := format('%.4f', [dVoltArr[0]]);
     m_edtSetVoltCh00.Text := strValue;
     m_scrSetVoltCh00.Position := Trunc(dVoltArr[0]);

     strValue := format('%.4f', [dVoltArr[1]]);
     m_edtSetVoltCh01.Text := strValue;
     m_scrSetVoltCh01.Position := Trunc(dVoltArr[1]);

     strValue := format('%.4f', [dVoltArr[2]]);
     m_edtSetVoltCh02.Text := strValue;
     m_scrSetVoltCh02.Position := Trunc(dVoltArr[2]);

     strValue := format('%.4f', [dVoltArr[3]]);
     m_edtSetVoltCh03.Text := strValue;
     m_scrSetVoltCh03.Position := Trunc(dVoltArr[3]);
end;

// ++ ======================================================================
// >> m_cboVoltageRangeChange() : 출력 전압 범위 변경시 호출되는 핸들러 함수.
//  - 해당 채널의 출력 전압 범위를 갱신합니다.
//  - 출력 전압 범위는 A/D변환 성능과 관련이 있으므로 측정 범위 확인 후 설정하시기 바랍니다.
//  - 모듈별로 허용 출력 전압이 정해져 있습니다. 
//  - 사용자가 출력 전압 설정범위 이외 전압을 입력하면 자동으로 그 값을 포함하는 근삿값으로 자동 설정됩니다.
// --------------------------------------------------------------------------
procedure TForm1.m_cboVoltageRangeChange(Sender: TObject);
var
     dwRetCode : DWord;
     dMinVolt, dMaxVolt : double;
     lChannelArr : array[0..3] of longInt;
     strData : String;
begin
     lChannelArr[0] := 0;
     lChannelArr[1] := 1;
     lChannelArr[2] := 2;
     lChannelArr[3] := 3;
     case m_cboVoltageRange.ItemIndex of
     0 :
     begin
          dMinVolt := -10.0;
          dMaxVolt := 10.0;
     end;
     1 :
     begin
          dMinVolt := -5.0;
          dMaxVolt := 5.0;
     end;
     2 :
     begin
          dMinVolt := 0.0;
          dMaxVolt := 10.0;
     end;
     3 :
     begin
          dMinVolt := 0.0;
          dMaxVolt := 5.0;
     end;
     else
         dMinVolt := -10.0;
         dMaxVolt := 10.0;
     end;
     // 출력 전압 범위를 설정합니다.
    dwRetCode := AxaoSetMultiRange(4, @lChannelArr[0], dMinVolt, dMaxVolt);
    if (dwRetCode <> AXT_RT_SUCCESS) then
    begin
         strData := format('AxaoSetMultiRange return error[Code:%.4d]', [dwRetCode]);
         ShowMessage(strData);
    end;
end;

// ++ =======================================================================
// >> m_btnSetClick() : "Set"버튼 클릭시 호출되는 핸들러 함수.
//  - 단일 채널에 들어오는 값을 Normal Trigger로 읽기 시작합니다.
// --------------------------------------------------------------------------
procedure TForm1.m_btnSetClick(Sender: TObject);
var
     strValue : array[0..3] of String;
     strData : String;
     dOutputVoltArr : array[0..3] of double;
     dwRetCode : DWord;
     lChannelArr : array[0..3] of longInt;
begin
     dwRetCode := 0;
     lChannelArr[0] := 0;
     lChannelArr[1] := 1;
     lChannelArr[2] := 2;
     lChannelArr[3] := 3;

     strValue[0] := m_edtSetVoltCh00.Text;
     strValue[1] := m_edtSetVoltCh01.Text;
     strValue[2] := m_edtSetVoltCh02.Text;
     strValue[3] := m_edtSetVoltCh03.Text;
     dOutputVoltArr[0] := StrToFloat(strValue[0]);
     dOutputVoltArr[1] := StrToFloat(strValue[1]);
     dOutputVoltArr[2] := StrToFloat(strValue[2]);
     dOutputVoltArr[3] := StrToFloat(strValue[3]);

     //++ 출력 전압 변경
	 dwRetCode := AxaoWriteMultiVoltage(4, @lChannelArr[0], @dOutputVoltArr[0]);
     if (dwRetCode <> AXT_RT_SUCCESS) then
     begin
          strData := format('AxaoWriteMultiVoltage return error[Code:%.4d]', [dwRetCode]);
          ShowMessage(strData);
     end;

     //++ 스크롤바 변경
     m_scrSetVoltCh00.Position := Trunc(dOutputVoltArr[0]);
     m_scrSetVoltCh01.Position := Trunc(dOutputVoltArr[1]);
     m_scrSetVoltCh02.Position := Trunc(dOutputVoltArr[2]);
     m_scrSetVoltCh03.Position := Trunc(dOutputVoltArr[3]);
end;

// ++ =======================================================================
// >> m_scrSetVoltChXXScroll(...) : 출력 전압 스크롤바 조작 시 호출되는 핸들러 함수.
//  - 출력 전압 스크롤바를 조작하여 출력 전압을 실시간으로 적용합니다.
// --------------------------------------------------------------------------
procedure TForm1.m_scrSetVoltCh00Scroll(Sender: TObject;
  ScrollCode: TScrollCode; var ScrollPos: Integer);
var
     strData : String;
     dwRetCode : DWord;
     iSliderPos : integer;
     dSliderPos : double;
begin
     // 변경된 스크롤바 위치를 에디트 컨트롤에 반영
     iSliderPos := m_scrSetVoltCh00.Position;
     dSliderPos := iSliderPos;
     strData := format('%.4f', [dSliderPos]);
     m_edtSetVoltCh00.Text := strData;

     //++ 출력값을 변경합니다.
     dwRetCode := AxaoWriteVoltage(0, dSliderPos);
     if (dwRetCode <> AXT_RT_SUCCESS) then
     begin
          strData := format('AxaoWriteVoltage return error[Code:%.4d]', [dwRetCode]);
          ShowMessage(strData);
     end;
end;

procedure TForm1.m_scrSetVoltCh01Scroll(Sender: TObject;
  ScrollCode: TScrollCode; var ScrollPos: Integer);
var
     strData : String;
     dwRetCode : DWord;
     iSliderPos : integer;
     dSliderPos : double;
begin
     // 변경된 스크롤바 위치를 에디트 컨트롤에 반영
     iSliderPos := m_scrSetVoltCh01.Position;
     dSliderPos := iSliderPos;
     strData := format('%.4f', [dSliderPos]);
     m_edtSetVoltCh01.Text := strData;

     //++ 출력값을 변경합니다.
     dwRetCode := AxaoWriteVoltage(1, dSliderPos);
     if (dwRetCode <> AXT_RT_SUCCESS) then
     begin
          strData := format('AxaoWriteVoltage return error[Code:%.4d]', [dwRetCode]);
          ShowMessage(strData);
     end;
end;

procedure TForm1.m_scrSetVoltCh02Scroll(Sender: TObject;
  ScrollCode: TScrollCode; var ScrollPos: Integer);
var
     strData : String;
     dwRetCode : DWord;
     iSliderPos : integer;
     dSliderPos : double;
begin
     // 변경된 스크롤바 위치를 에디트 컨트롤에 반영
     iSliderPos := m_scrSetVoltCh02.Position;
     dSliderPos := iSliderPos;
     strData := format('%.4f', [dSliderPos]);
     m_edtSetVoltCh02.Text := strData;

     //++ 출력값을 변경합니다.
     dwRetCode := AxaoWriteVoltage(2, dSliderPos);
     if (dwRetCode <> AXT_RT_SUCCESS) then
     begin
          strData := format('AxaoWriteVoltage return error[Code:%.4d]', [dwRetCode]);
          ShowMessage(strData);
     end;
end;

procedure TForm1.m_scrSetVoltCh03Scroll(Sender: TObject;
  ScrollCode: TScrollCode; var ScrollPos: Integer);
var
     strData : String;
     dwRetCode : DWord;
     iSliderPos : integer;
     dSliderPos : double;
begin
     // 변경된 스크롤바 위치를 에디트 컨트롤에 반영
     iSliderPos := m_scrSetVoltCh03.Position;
     dSliderPos := iSliderPos;
     strData := format('%.4f', [dSliderPos]);
     m_edtSetVoltCh03.Text := strData;

     //++ 출력값을 변경합니다.
     dwRetCode := AxaoWriteVoltage(3, dSliderPos);
     if (dwRetCode <> AXT_RT_SUCCESS) then
     begin
          strData := format('AxaoWriteVoltage return error[Code:%.4d]', [dwRetCode]);
          ShowMessage(strData);
     end;
end;

// ++ =======================================================================
// >> m_timerTimer(...) : 타이머 이벤트 핸들러 함수.
//  - 출력되고 있는 전압 값을 주기적으로 갱신합니다.
// --------------------------------------------------------------------------
procedure TForm1.m_timerTimer(Sender: TObject);
var
     dVoltArr : array[0..3] of double;
     lChannelArr : array[0..3] of longInt;
     strValue : String;
begin
     dVoltArr[0] := 0.0;
     dVoltArr[1] := 0.0;
     dVoltArr[2] := 0.0;
     dVoltArr[3] := 0.0;
     lChannelArr[0] := 0;
     lChannelArr[1] := 1;
     lChannelArr[2] := 2;
     lChannelArr[3] := 3;

     //++ 지정 채널에 출력하고 있는 값을 전압 단위로 읽어옵니다.
     AxaoReadMultiVoltage(4, @lChannelArr, @dVoltArr[0]);
     if (m_dOldVoltArr[0] <> dVoltArr[0]) then
     begin
          strValue := format('%.4f', [dVoltArr[0]]);
          m_stcOutVoltCh00.Text := strValue;
          m_dOldVoltArr[0] := dVoltArr[0];
     end;
     if (m_dOldVoltArr[1] <> dVoltArr[1]) then
     begin
          strValue := format('%.4f', [dVoltArr[1]]);
          m_stcOutVoltCh01.Text := strValue;
          m_dOldVoltArr[1] := dVoltArr[1];
     end;
     if (m_dOldVoltArr[2] <> dVoltArr[2]) then
     begin
          strValue := format('%.4f', [dVoltArr[2]]);
          m_stcOutVoltCh02.Text := strValue;
          m_dOldVoltArr[2] := dVoltArr[2];
     end;
     if (m_dOldVoltArr[3] <> dVoltArr[3]) then
     begin
          strValue := format('%.4f', [dVoltArr[3]]);
          m_stcOutVoltCh03.Text := strValue;
          m_dOldVoltArr[3] := dVoltArr[3];
     end;
end;

// **************************************************************************
// >> [구분]: 별도의 기능을 구현하기위해 만든 사용자 정의 함수들 모음 
// **************************************************************************

// ++ =======================================================================
// >> InitLibrary() : 라이브러리 초기화 함수.
//  - AXL(AjineXtek Library)을 사용가능하게 합니다. 
// --------------------------------------------------------------------------
Function TForm1.InitLibrary() : Boolean;
var
     dwStatus, dwRetCode : DWord;
begin
     dwStatus := 0;
     dwRetCode := AxlOpenNoReset(7);
     if (dwRetCode <> AXT_RT_SUCCESS) then
     begin
          ShowMessage('AxlOpen Fail...');
          Result := false;
     end;

     dwRetCode := AxaInfoIsAIOModule(@dwStatus);
     if (dwStatus <> STATUS_EXIST) then
     begin
          ShowMessage('The module does not exist...');
          Result := false;
     end;

     Result := True;
end;

// ++ =======================================================================
// >> InitControl() : Control들에 초기값을 설정하는 함수.
//  - Control 변수들을 등록하고, 초기 설정값들을 설정합니다.
// --------------------------------------------------------------------------
Function TForm1.InitControl() : Boolean;
begin
     m_lModuleNo := 0;

     m_cboModule.ItemIndex := 0;

     // 첫번째 모듈의 ID를 가져옵니다.
	 AxaInfoGetModule(m_lModuleNo, nil, nil, @m_dwModuleID);

     Result := True;
end;

// ++ =======================================================================
// >> AddModuleChannelInfo() : 시스템에 장착된 AIO모듈들을 ComboBox에 등록하는 함수.
//  - AIO모듈 정보를 읽어 ComboBox에 등록하여 사용자가 선택
//    제어할 수 있도록 합니다.
//  - 유효한 모듈이 검색되었을 때 Control들을 초기화 합니다.
// --------------------------------------------------------------------------
Function TForm1.AddModuleChannelInfo() : Boolean;
var
     strData, strChNum : String;
     lOutputCount, lBoardNo, lModulePos : longInt;
     dwModuleID, dwRetCode : DWord;
     iModuleNo, i : integer;
     szModuleName : PAnsiChar;
begin
     lOutputCount := 0;
     lBoardNo := 0;
     lModulePos := 0;
     dwModuleID := 0;

     // 시스템에 장착된 모든AIO 모듈의 개수를 확인합니다.
     dwRetCode := AxaInfoGetModuleCount(@m_lModuleCount);
     for iModuleNo := 0 To (m_lModuleCount - 1) do
     begin
          // 각 모듈의 입력 채널 수를 확인합니다.
          AxaInfoGetOutputCount(iModuleNo, @lOutputCount);
          if (lOutputCount > 0) then
          begin
               // 해당 모듈의 정보를 가져옵니다.
               dwRetCode := AxaInfoGetModule(iModuleNo, @lBoardNo, @lModulePos, @dwModuleID);
               if (dwRetCode = AXT_RT_SUCCESS) then
               begin
                    case dwModuleID of
                    AXT_SIO_AI4RB : strData := format('[BD No:%d - MD No:%d] SIO_AI4RB [Output : %d]', [lBoardNo, iModuleNo, lOutputCount]);
                    AXT_SIO_AI16H : strData := format('[BD No:%d - MD No:%d] SIO_AI16H [Output : %d]', [lBoardNo, iModuleNo, lOutputCount]);
                    AXT_SIO_AI16HB : strData := format('[BD No:%d - MD No:%d] SIO_AI16HB [Output : %d]', [lBoardNo, iModuleNo, lOutputCount]);
                    AXT_SIO_RAI8RB : strData := format('[BD No:%d - MD No:%d] SIO_RAI8RB [Output : %d]', [lBoardNo, iModuleNo, lOutputCount]);
                    AXT_SIO_RAI4MLII : strData := format('[BD No:%d - MD No:%d] SIO_RAI4MLII [Output : %d]', [lBoardNo, iModuleNo, lOutputCount]);
                    AXT_SIO_RAI16RB : strData := format('[BD No:%d - MD No:%d] SIO_RAI16RB [Output : %d]', [lBoardNo, iModuleNo, lOutputCount]);
                    AXT_SIO_RAVCI4MLII : strData := format('[BD No:%d - MD No:%d] SIO_RAVCI4MLII [Output : %d]', [lBoardNo, iModuleNo, lOutputCount]);
                    AXT_SIO_RATI4MLII : strData := format('[BD No:%d - MD No:%d] SIO_RATI4MLII [Output : %d]', [lBoardNo, iModuleNo, lOutputCount]);
                    AXT_SIO_RARTDI4MLII : strData := format('[BD No:%d - MD No:%d] SIO_RARTDI4MLII [Output : %d]', [lBoardNo, iModuleNo, lOutputCount]);
                    AXT_SIO_RAO08RTEX : strData := format('[BD No:%d - MD No:%d] SIO_RAO08RTEX [Output : %d]', [lBoardNo, iModuleNo, lOutputCount]);
                    AXT_SIO_AI8F : strData := format('[BD No:%d - MD No:%d] SIO_AI8F [Output : %d]', [lBoardNo, iModuleNo, lOutputCount]);
                    AXT_SIO_AI8AO4F : strData := format('[BD No:%d - MD No:%d] SIO_AI8A04F [Output : %d]', [lBoardNo, iModuleNo, lOutputCount]);
                    AXT_ECAT_AIO :
                        begin
                            // EtherCAT AIO 전용 모듈 정보 추출
                            szModuleName := Allocmem(50);
                            AxaInfoGetModuleEx(iModuleNo, nil, PChar(szModuleName), nil);
                            strData := format('[BD No:%d - MD No:%d] %s [Output : %d]', [lBoardNo, iModuleNo, szModuleName, lOutputCount]);
                        end;
                    else
                        ;
                    end;
                    m_cboModule.Items.Add(strData);
               end;
          end;
     end;

     InitControl();
     Result := true;
end;

// ++ =======================================================================
// >> UpdateState() : 지정한 모듈의 설정값들을 읽어 Control과 일치시키는 함수.
//  - 모듈이 변경되었을 때 변경한 모듈의 설정값들과 Control들과 일치시키는 
//    역할을하는 함수입니다.
//  - 지정한 모듈의 모델별 제약들을 Control에 반영하는 역할을 합니다.
//  - 프로그램 초기 실행시, 모듈 번호 바뀔 때 사용됩니다.
// --------------------------------------------------------------------------
Function TForm1.UpdateState() : Boolean;
begin
     if (m_lModuleCount < 1) then Result := False;

     //++ 각 모듈별 지원여부에 따라 콘트롤 값들을 변경합니다.
     m_cboVoltageRange.Clear();
     m_cboVoltageRange.Enabled := True;
     case m_dwModuleID of
     AXT_SIO_AI4RB, AXT_SIO_AO4RB, AXT_SIO_AI8AO4F :
     begin
          m_cboVoltageRange.Items.Add('00: -10V ~ +10V');
          m_cboVoltageRange.Items.Add('01: -5V ~ +5V');
          m_cboVoltageRange.Items.Add('02: 0V ~ +10V');
          m_cboVoltageRange.Items.Add('03: 0V ~ +5V');
     end;
     AXT_SIO_AI8F, AXT_SIO_AO4F :
     begin
          m_cboVoltageRange.Items.Add('00: -10V ~ +10V');
          m_cboVoltageRange.Items.Add('01: -5V ~ +5V');
     end;
     end;

     //++ 지정 입력 채널에 설정한 입력 전압 범위를 확인합니다.
     UpdateVoltageRange();

     Result := True;
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
Function TForm1.ConvertAxaToCombo(pCboItem : TComboBox; dwCurData : DWORD) : DWORD;
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
Function TForm1.ConvertComboToAxa(pCboItem : TComboBox) : DWORD;
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

// ++ =======================================================================
// >> UpdateVoltageRange(...) : 전압 범위를 갱신하는 함수.
//  - 모듈 변경 시 0번 채널의 출력 전압 범위로
//    Control값을 변경합니다.
// --------------------------------------------------------------------------
procedure TForm1.UpdateVoltageRange();
var
     dwRetCode : DWord;
     dMinVolt, dMaxVolt : double;
     strData : String;
begin
     dMinVolt := 0.0;
     dMaxVolt := 0.0;
     //++ 0번 출력 채널에 설정한 출력 전압 범위를 확인합니다.
	 dwRetCode := AxaoGetRange(0, @dMinVolt, @dMaxVolt);
     if(dwRetCode = AXT_RT_SUCCESS) then
     begin
          if((dMinVolt = -10.0) and (dMaxVolt = 10.0)) then
              m_cboVoltageRange.ItemIndex := 0
          else if((dMinVolt = -5.0) and (dMaxVolt = 5.0)) then
              m_cboVoltageRange.ItemIndex := 1
          else if((dMinVolt = 0.0) and (dMaxVolt = 10.0)) then
              m_cboVoltageRange.ItemIndex := 2
          else if((dMinVolt = 0.0) and (dMaxVolt = 5.0)) then
              m_cboVoltageRange.ItemIndex := 3;
          m_scrSetVoltCh00.SetParams(0, Trunc(dMinVolt), Trunc(dMaxVolt));
          m_scrSetVoltCh01.SetParams(0, Trunc(dMinVolt), Trunc(dMaxVolt));
          m_scrSetVoltCh02.SetParams(0, Trunc(dMinVolt), Trunc(dMaxVolt));
          m_scrSetVoltCh03.SetParams(0, Trunc(dMinVolt), Trunc(dMaxVolt));
     end
     else
     begin
          m_cboVoltageRange.ItemIndex := 0;
          m_scrSetVoltCh00.SetParams(0, -10, 10);
          m_scrSetVoltCh01.SetParams(0, -10, 10);
          m_scrSetVoltCh02.SetParams(0, -10, 10);
          m_scrSetVoltCh03.SetParams(0, -10, 10);
     end;
end;

end.
