unit StatusMonitor;
// StatusMonitor.pas : implementation file
//
// **************************************************************************
// >> [일자]: 2015.12.09
// >> [개요]: 이 예제는 모션구동과 관련된 상태들을 모니터링하는 예제입니다.
// >> [중요]: 상태함수들 응용범위
//     1) AxmStatusReadMechanical함수는 신호 상태값들을 한번에 읽어 확인할 수
//        있어 각각의 개별 함수들을 이용하는것 보다 효율적입니다.
//     2) AxmStatusReadStop 함수는 구동이 정지된 후 정상구동여부를 확인할 수
//        있습니다. 모션 구동시 목표위치까지 도달하지 않고 정지하였다면 이 함수의
//        반환값을 분석해 정지원인을 파악할 수 있습니다.
//     3) AxmStatusReadMotion 함수는 현재 모션 구동중인지, 어떤 구동중인지등의
//        구동상태를 확인할 수 있습니다.
// **************************************************************************

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls,
  AXL, AXM, AXHS, ExtCtrls;

Const
    MAX_ITEM_END = 14;
    MAX_ITEM_MECH = 14;
    MAX_ITEM_DRIVE = 10;

type
  TForm1 = class(TForm)
    GroupBox1: TGroupBox;
    Label1: TLabel;
    cboSelAxis: TComboBox;
    btnLoadFile: TButton;
    GroupBox2: TGroupBox;
    chkMechBit00: TCheckBox;
    Label2: TLabel;
    Label3: TLabel;
    chkMechBit01: TCheckBox;
    chkMechBit04: TCheckBox;
    Label4: TLabel;
    chkMechBit05: TCheckBox;
    Label5: TLabel;
    chkMechBit06: TCheckBox;
    Label6: TLabel;
    chkMechBit07: TCheckBox;
    Label7: TLabel;
    chkMechBit08: TCheckBox;
    Label8: TLabel;
    chkMechBit09: TCheckBox;
    Label9: TLabel;
    chkMechBit10: TCheckBox;
    Label10: TLabel;
    chkMechBit11: TCheckBox;
    Label11: TLabel;
    chkMechBit12: TCheckBox;
    Label12: TLabel;
    chkMechBit13: TCheckBox;
    Label13: TLabel;
    chkMechBit14: TCheckBox;
    Label14: TLabel;
    chkMechBit17: TCheckBox;
    Label15: TLabel;
    GroupBox3: TGroupBox;
    Label16: TLabel;
    Label17: TLabel;
    Label18: TLabel;
    Label19: TLabel;
    Label20: TLabel;
    Label21: TLabel;
    Label22: TLabel;
    Label23: TLabel;
    Label24: TLabel;
    Label25: TLabel;
    Label26: TLabel;
    Label27: TLabel;
    Label28: TLabel;
    Label29: TLabel;
    chkEndBit00: TCheckBox;
    chkEndBit01: TCheckBox;
    chkEndBit04: TCheckBox;
    chkEndBit05: TCheckBox;
    chkEndBit06: TCheckBox;
    chkEndBit07: TCheckBox;
    chkEndBit08: TCheckBox;
    chkEndBit09: TCheckBox;
    chkEndBit10: TCheckBox;
    chkEndBit11: TCheckBox;
    chkEndBit15: TCheckBox;
    chkEndBit28: TCheckBox;
    chkEndBit30: TCheckBox;
    chkEndBit31: TCheckBox;
    GroupBox4: TGroupBox;
    Label30: TLabel;
    Label31: TLabel;
    Label32: TLabel;
    Label33: TLabel;
    Label34: TLabel;
    Label37: TLabel;
    Label38: TLabel;
    Label39: TLabel;
    Label40: TLabel;
    Label41: TLabel;
    chkDriveBit00: TCheckBox;
    chkDriveBit01: TCheckBox;
    chkDriveBit02: TCheckBox;
    chkDriveBit03: TCheckBox;
    chkDriveBit04: TCheckBox;
    chkDriveBit05: TCheckBox;
    chkDriveBit06: TCheckBox;
    chkDriveBit07: TCheckBox;
    chkDriveBit10: TCheckBox;
    chkDriveBit11: TCheckBox;
    OpenDialog1: TOpenDialog;
    m_timer: TTimer;
    Function InitLibrary() : Boolean; stdcall;
    Function AddAxisInfo() : Boolean; stdcall;
    Function InitControl() : Boolean; stdcall;
    Function UpdateState() : Boolean; stdcall;
    function iif(c: boolean; a, b: integer): integer;
    procedure FormCreate(Sender: TObject);
    procedure FormDestroy(Sender: TObject);
    procedure cboSelAxisChange(Sender: TObject);
    procedure btnLoadFileClick(Sender: TObject);
    procedure m_timerTimer(Sender: TObject);
  private
    { Private declarations }
    m_lAxisNo, m_lAxisCount : integer;
    m_dwModuleID : integer;
  public
    { Public declarations }
  end;

var
  Form1: TForm1;

implementation

{$R *.dfm}

procedure TForm1.FormCreate(Sender: TObject);
begin
    m_lAxisNo := -1;
    m_lAxisCount := 0;
    m_dwModuleID := 0;

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
// >> m_timerTimer(...) : 타이머 이벤트 핸들러 함수.
//  - 일정한 주기로 변경되는 위치/속도/정보등을 Control에 반영합니다.
// --------------------------------------------------------------------------
procedure TForm1.m_timerTimer(Sender: TObject);
var
    lDigitEnd : array[0..(MAX_ITEM_END - 1)] of integer;
    lDigitMech : array[0..(MAX_ITEM_MECH - 1)] of integer;
    lDigitDrive : array[0..(MAX_ITEM_DRIVE - 1)] of integer;
    chkGroupInpMech : array[0..(MAX_ITEM_MECH - 1)] of TCheckBox;
    chkGroupInpEnd : array[0..(MAX_ITEM_END - 1)] of TCheckBox;
    chkGroupInpDrive : array[0..(MAX_ITEM_DRIVE - 1)] of TCheckBox;
    lCheck, lIndex, dwRetCode, dwStatus : DWORD;
begin
    // 중요한 정보들만 모니터링 하도록 선택했습니다.
    lDigitEnd[0] := 0;
    lDigitEnd[1] := 1;
    lDigitEnd[2] := 4;
    lDigitEnd[3] := 5;
    lDigitEnd[4] := 6;
    lDigitEnd[5] := 7;
    lDigitEnd[6] := 8;
    lDigitEnd[7] := 9;
    lDigitEnd[8] := 10;
    lDigitEnd[9] := 11;
    lDigitEnd[10] := 15;
    lDigitEnd[11] := 28;
    lDigitEnd[12] := 30;
    lDigitEnd[13] := 31;

    lDigitMech[0] := 0;
    lDigitMech[1] := 1;
    lDigitMech[2] := 4;
    lDigitMech[3] := 5;
    lDigitMech[4] := 6;
    lDigitMech[5] := 7;
    lDigitMech[6] := 8;
    lDigitMech[7] := 9;
    lDigitMech[8] := 10;
    lDigitMech[9] := 11;
    lDigitMech[10] := 12;
    lDigitMech[11] := 13;
    lDigitMech[12] := 14;
    lDigitMech[13] := 17;

    lDigitDrive[0] := 0;
    lDigitDrive[1] := 1;
    lDigitDrive[2] := 2;
    lDigitDrive[3] := 3;
    lDigitDrive[4] := 4;
    lDigitDrive[5] := 5;
    lDigitDrive[6] := 6;
    lDigitDrive[7] := 7;
    lDigitDrive[8] := 10;
    lDigitDrive[9] := 11;

    chkGroupInpMech[0] := chkMechBit00;
    chkGroupInpMech[1] := chkMechBit01;
    chkGroupInpMech[2] := chkMechBit04;
    chkGroupInpMech[3] := chkMechBit05;
    chkGroupInpMech[4] := chkMechBit06;
    chkGroupInpMech[5] := chkMechBit07;
    chkGroupInpMech[6] := chkMechBit08;
    chkGroupInpMech[7] := chkMechBit09;
    chkGroupInpMech[8] := chkMechBit10;
    chkGroupInpMech[9] := chkMechBit11;
    chkGroupInpMech[10] := chkMechBit12;
    chkGroupInpMech[11] := chkMechBit13;
    chkGroupInpMech[12] := chkMechBit14;
    chkGroupInpMech[13] := chkMechBit17;

    chkGroupInpEnd[0] := chkEndBit00;
    chkGroupInpEnd[1] := chkEndBit01;
    chkGroupInpEnd[2] := chkEndBit04;
    chkGroupInpEnd[3] := chkEndBit05;
    chkGroupInpEnd[4] := chkEndBit06;
    chkGroupInpEnd[5] := chkEndBit07;
    chkGroupInpEnd[6] := chkEndBit08;
    chkGroupInpEnd[7] := chkEndBit09;
    chkGroupInpEnd[8] := chkEndBit10;
    chkGroupInpEnd[9] := chkEndBit11;
    chkGroupInpEnd[10] := chkEndBit15;
    chkGroupInpEnd[11] := chkEndBit28;
    chkGroupInpEnd[12] := chkEndBit30;
    chkGroupInpEnd[13] := chkEndBit31;

    chkGroupInpDrive[0] := chkDriveBit00;
    chkGroupInpDrive[1] := chkDriveBit01;
    chkGroupInpDrive[2] := chkDriveBit02;
    chkGroupInpDrive[3] := chkDriveBit03;
    chkGroupInpDrive[4] := chkDriveBit04;
    chkGroupInpDrive[5] := chkDriveBit05;
    chkGroupInpDrive[6] := chkDriveBit06;
    chkGroupInpDrive[7] := chkDriveBit07;
    chkGroupInpDrive[8] := chkDriveBit10;
    chkGroupInpDrive[9] := chkDriveBit11;

    //++ 지정 축의 Mechanical Signal Data(현재 기계적인 신호상태)를 확인합니다.
		// ※ [CAUTION] 각 제품별로 하드웨어적인 신호가 다르기 때문에 매뉴얼 및 AXHS.xxx파일을 참고하십시요.
    dwRetCode := AxmStatusReadMechanical(m_lAxisNo, @dwStatus);
    if (dwRetCode = AXT_RT_SUCCESS) then
    begin
        for lIndex := 0 to (MAX_ITEM_MECH - 1) do
        begin
            lCheck := (dwStatus shr lDigitMech[lIndex]) and $1;
            if (lCheck = 1) then chkGroupInpMech[lIndex].Checked := true
            else chkGroupInpMech[lIndex].Checked := false;
        end;
    end;

    //++ 지정 축의 End Status(정지 상태)를 확인합니다.
		// ※ [CAUTION] 각 제품별로 정지 상태가 다르기 때문에 매뉴얼 및 AXHS.xxx 파일을 참고하십시요.
    dwRetCode := AxmStatusReadStop(m_lAxisNo, @dwStatus);
    if (dwRetCode = AXT_RT_SUCCESS) then
    begin
        for lIndex := 0 to (MAX_ITEM_END - 1) do
        begin
            lCheck := (dwStatus shr lDigitEnd[lIndex]) and $1;
            if (lCheck = 1) then chkGroupInpEnd[lIndex].Checked := true
            else chkGroupInpEnd[lIndex].Checked := false;
        end;
    end;

    //++ 지정 축의 Drive Status(모션중 상태)를 확인합니다.
		// ※ [CAUTION] 각 제품별로 모션중 상태가 다르기 때문에 매뉴얼 및 AXHS.xxx 파일을 참고하십시요.
    dwRetCode := AxmStatusReadMotion(m_lAxisNo, @dwStatus);
    if (dwRetCode = AXT_RT_SUCCESS) then
    begin
        for lIndex := 0 to (MAX_ITEM_DRIVE - 1) do
        begin
            lCheck := (dwStatus shr lDigitDrive[lIndex]) and $1;
            if (lCheck = 1) then chkGroupInpDrive[lIndex].Checked := true
            else chkGroupInpDrive[lIndex].Checked := false;
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
begin
    if (m_lAxisCount < 1) then
    begin
        Result := true;
        exit;
    end;

    Result := true;
end;

function TForm1.iif(c: boolean; a, b: integer): integer;
begin
  if c then
    Result := a
  else
    Result := b;
end;

end.
