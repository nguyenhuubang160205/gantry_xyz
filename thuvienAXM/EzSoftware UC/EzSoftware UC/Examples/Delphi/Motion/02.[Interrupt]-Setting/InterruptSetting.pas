unit InterruptSetting;
// InterruptSetting.pas : implementation file
//
// **************************************************************************
// >> [일자]: 2015.12.09
// >> [개요]: 이 예제는 인터럽트 함수들의 사용법을 익히고 윈도우 응용프로그램에서
//     여러가지 인터럽트 처리 방법에 대해 학습하는 예제입니다.
// >> [중요]: 인터럽트 사용방법
//     1) AxlInterruptEnable함수를 이용해서 AXL라이브러리에 인터럽트를 허용합니다.
//     2) AxmInterruptSetAxis함수를 이용해 각 축에 인터럽트 처리 방식을 설정합니다.
//     3) AxmInterruptSetUserEnable함수를 이용해 지정한 축에 사용할 인터럽트
//        종류들을 설정합니다. Ex) AxmInterruptSetUserEnable(0, INT_BANK_1, 0x6)
//     4) AxmInterruptSetAxisEnable 함수를 이용해 지정한 축에 인터럽트를 허용합니다.
// **************************************************************************

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, ExtCtrls,
  AXL, AXM, AXHS;

const
    WM_CAMC_INTERRUPT       = WM_USER + 2009;
    INT_BANK_1              = 0;
    INT_BANK_2              = 1;

    MAX_BANK_1              = 4;
    MAX_BANK_2              = 6;
    MAX_AXIS_COUNT          = 64;

type
    TIntType = (INT_MESSAGE, INT_CALLBACK, INT_EVENT);

type
  TForm1 = class(TForm)
    GroupBox1: TGroupBox;
    Label1: TLabel;
    cboSelAxis: TComboBox;
    grpBank1: TGroupBox;
    Shape1: TShape;
    chkBank1Bit00: TCheckBox;
    chkBank1Bit01: TCheckBox;
    chkBank1Bit02: TCheckBox;
    chkBank1Bit31: TCheckBox;
    grpBank2: TGroupBox;
    Shape2: TShape;
    chkBank2Bit14: TCheckBox;
    chkBank2Bit15: TCheckBox;
    chkBank2Bit16: TCheckBox;
    chkBank2Bit20: TCheckBox;
    btnSetBank1: TButton;
    btnSetBank2: TButton;
    chkBank2Bit21: TCheckBox;
    chkBank2Bit22: TCheckBox;
    GroupBox5: TGroupBox;
    rdoMessage: TRadioButton;
    rdoCallback: TRadioButton;
    rdoEvent: TRadioButton;
    chkIntEnable: TCheckBox;
    lstIntLog: TListBox;
    Function InitLibrary() : Boolean; stdcall;
    Function AddAxisInfo() : Boolean; stdcall;
    Function InitControl() : Boolean; stdcall;
    Function UpdateState() : Boolean; stdcall;
    procedure FormCreate(Sender: TObject);
    function ThreadData():Boolean; stdcall;
    procedure FormDestroy(Sender: TObject);
    procedure cboSelAxisChange(Sender: TObject);
    procedure btnSetBank1Click(Sender: TObject);
    procedure btnSetBank2Click(Sender: TObject);
    procedure chkIntEnableClick(Sender: TObject);
    procedure lstIntLogDblClick(Sender: TObject);
  private
    { Private declarations }
    procedure OnControlMessage(var Msg : TMessage); message WM_CAMC_INTERRUPT;
  public
    { Public declarations }
    m_lAxisNo     : Integer;
    m_lAxisCount : longInt;
    m_lIntCount : DWORD;
    m_dwModuleID  : DWORD;
    m_bTestActive     : array [0..63] of Boolean;
    m_hTestThread     : array [0..63] of THandle;
    m_hHandle         : array [0..63] of THandle;
  end;

var
  Form1: TForm1;
  m_hInterrupt : array [0..63] of DWORD;
  m_bThread : array [0..63] of Boolean;
implementation

var
    g_nIntCnt   : LongInt;

{$R *.dfm}

function ThreadProc(lpData : Pointer): Boolean; StdCall;
var
    pDlg : TForm1;
begin
	pDlg := TForm1(lpData);
	pDlg.ThreadData();
  Result := true;
end;

procedure TForm1.FormCreate(Sender: TObject);
begin
    InitLibrary();
    AddAxisInfo();
    UpdateState();
end;

procedure TForm1.FormDestroy(Sender: TObject);
var
    i : Integer;
begin
    m_bTestActive[0] := False;
    m_bTestActive[1] := false;
	m_bTestActive[2] := false;
    m_bTestActive[3] := false;
	for i := 0 to  m_lAxisCount do
    begin
		AxmMoveEStop(i);
		AxmSignalWriteOutputBit(i, 0, 0);
    end;

    for i := 0 to 4 do
    begin
	    if(m_hTestThread[i] <> 0)then
        begin
			WaitForSingleObject(m_hTestThread[i],  WAIT_ABANDONED);
			CloseHandle(m_hTestThread[i]);
			m_hTestThread[i] := 0;
        end
    end;

    AxlClose();
end;

// ++ =======================================================================
// >> keMotionInterruptCallback(...) : 인터럽트 처리 콜벡함수.
//  - 인터럽트 방식중 콜벡함수 방식으로 인터럽트를 사용할 경우 라이브러리에서
//    인터럽트 발생시 자동으로 호출되는 인터럽트 콜벡함수입니다.
//  - lActiveNo에는 인터럽트 발생 축 정보가 전달됩니다.
//  - dwFlag에는 인터럽트가 발생된 Bank정보가 전달 됩니다.
// --------------------------------------------------------------------------
procedure keMotionInterruptCallback(lActiveNo : LongInt; dwFlag : DWord); stdcall;
var
    strData: String;
    IntBank0, IntBank1: DWord;
begin
    g_nIntCnt := g_nIntCnt + 1;
	  AxmInterruptReadAxisFlag(lActiveNo, 0, @IntBank0);
	  AxmInterruptReadAxisFlag(lActiveNo, 1, @IntBank1);

    strData := 'Cal[' + Format('%d', [g_nIntCnt]) + ']Axis[' +  Format('%d', [lActiveNo]) + ']Flag[0x' + Format('%X', [dwFlag]) + ']';
	  Form1.lstIntLog.Items.Add(strData);
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
// >> btnSetBank1Click() : "Set Bank 1"버튼 클릭시 호출되는 핸들러 함수.
//  - 인터럽트 Bank1에 설정가능한 인터럽트를 설정합니다.
// --------------------------------------------------------------------------
procedure TForm1.btnSetBank1Click(Sender: TObject);
var
    strData : String;
    dwIntMask, dwRetCode : DWORD;
begin
    dwIntMask := 0;
    if (chkBank1Bit00.Checked = true) then dwIntMask := dwIntMask or QIINTBANK1_0;
    if (chkBank1Bit01.Checked = true) then dwIntMask := dwIntMask or QIINTBANK1_1;
    if (chkBank1Bit02.Checked = true) then dwIntMask := dwIntMask or QIINTBANK1_2;
    if (chkBank1Bit31.Checked = true) then dwIntMask := dwIntMask or QIINTBANK1_31;

    // ++ 지정한 축에 모션구동 시작시, 모셔구동 종료시 등의 인터럽트를 설정합니다.
    dwRetCode := AxmInterruptSetUserEnable(m_lAxisNo, INT_BANK_1, dwIntMask);
    if (dwRetCode <> AXT_RT_SUCCESS) then
    begin
        strData := 'AxmInterruptSetUserEnable return error[Code:' +
                  Format('%.4d]', [dwRetCode]);
        ShowMessage(strData);
    end;

    UpdateState();
end;

// ++ =======================================================================
// >> btnSetBank2Click() : "Set Bank 2"버튼 클릭시 호출되는 핸들러 함수.
//  - 인터럽트 Bank2에 설정가능한 인터럽트를 설정합니다.
// --------------------------------------------------------------------------
procedure TForm1.btnSetBank2Click(Sender: TObject);
var
    strData : String;
    dwIntMask, dwRetCode : DWORD;
begin
    dwIntMask := 0;
    if (chkBank2Bit14.Checked = true) then dwIntMask := dwIntMask or QIINTBANK2_14;
    if (chkBank2Bit15.Checked = true) then dwIntMask := dwIntMask or QIINTBANK2_15;
    if (chkBank2Bit16.Checked = true) then dwIntMask := dwIntMask or QIINTBANK2_16;
    if (chkBank2Bit20.Checked = true) then dwIntMask := dwIntMask or QIINTBANK2_20;
    if (chkBank2Bit21.Checked = true) then dwIntMask := dwIntMask or QIINTBANK2_21;
    if (chkBank2Bit22.Checked = true) then dwIntMask := dwIntMask or QIINTBANK2_22;

    // ++ 지정한 축에 범용입력 변화시, 범용출력 변화시 등의 인터럽트를 설정합니다.
    dwRetCode := AxmInterruptSetUserEnable(m_lAxisNo, INT_BANK_2, dwIntMask);
    if (dwRetCode <> AXT_RT_SUCCESS) then
    begin
        strData := 'AxmInterruptSetUserEnable return error[Code:' +
                  Format('%.4d]', [dwRetCode]);
        ShowMessage(strData);
    end;

    UpdateState();
end;

// ++ =======================================================================
// >> chkIntEnableClick() : "Interrupt Enable"버튼 클릭시 호출되는 핸들러 함수.
//  - 인터럽트 처리 방식에 따라 인터럽트를 설정합니다.
// ※ [CAUTION] 인터럽트 사용시 사용자가 구현하는 인터럽트 처리함수는 되도록이면
//    간결하게 작성하는게 좋습니다(콘트롤 업데이트등은 옳지 않음). 왜냐하면
//    인터럽트가 발생하는 시간보다 함수처리 시간이 길어지게되면 놓치는 경우가
//    빈번하게 발생할 수 있기 때문입니다.
// --------------------------------------------------------------------------
procedure TForm1.chkIntEnableClick(Sender: TObject);
var
    strData : String;
    dwRetCode, ThreadID : DWORD;
begin
    if (chkIntEnable.Checked = true) then
    begin
        if (rdoMessage.Checked = true) then
            // ++ 인터럽트 처리방식을 윈도우메세지 방식으로 지정함
            AxmInterruptSetAxis(m_lAxisNo, Form1.Handle, WM_CAMC_INTERRUPT, nil, nil)
        else
        if (rdoCallback.Checked = true) then
            // ++ 인터럽트 처리방식을 콜벡함수 방식으로 지정함
            AxmInterruptSetAxis(m_lAxisNo, Form1.Handle, 0, keMotionInterruptCallback, nil)
        else
        if (rdoEvent.Checked = true) then
        begin
            g_nIntCnt := 0;
            // ++ 인터럽트 처리방식을 이벤트 방식으로 지정함
            AxmInterruptSetAxis(m_lAxisNo, 0, 0, nil, @m_hInterrupt[m_lAxisNo]);
            if(m_hHandle[m_lAxisNo] <> 0)then
            begin
            		m_bThread[m_lAxisNo]	:= False;
            		m_hHandle[m_lAxisNo]	:= 0;
          	end;

          	if (m_bThread[m_lAxisNo] = False)then
            begin
            		m_bThread[m_lAxisNo]	:= TRUE;
                // 해당축의 인터럽트 이벤트를 대기할 쓰레드 생성
                m_hHandle[m_lAxisNo]	:= CreateThread(nil, 0, @ThreadProc, Pointer(@Form1), 0, ThreadID);
            end;
        end;

        // ++ AXL라이브러리의 인터럽트 발생을 허용합니다.
        AxlInterruptEnable();
        // ++ 지정한 축에 인터럽트 발생을 허용합니다.
        dwRetCode := AxmInterruptSetAxisEnable(m_lAxisNo, ENABLE);
        if (dwRetCode <> AXT_RT_SUCCESS) then
        begin
            strData := 'AxmInterruptSetAxisEnable return error[Code:' +
                      Format('%.4d]', [dwRetCode]);
            ShowMessage(strData);
        end;
    end
    else
    begin
        // ++ AXL라이브러리의 인터럽트 발생을 금지합니다.
        AxlInterruptDisable();
        // ++ 지정한 축에 인터럽트 발생을 금지합니다.
        dwRetCode := AxmInterruptSetAxisEnable(m_lAxisNo, DISABLE);
        if (dwRetCode <> AXT_RT_SUCCESS) then
        begin
            strData := 'AxmInterruptSetAxisEnable return error[Code:' +
                      Format('%.4d]', [dwRetCode]);
            ShowMessage(strData);
        end;
    end;
end;

// ++ =======================================================================
// >> lstIntLogDblClick() : ListBox 콘트롤 마우스 더블클릭시 호출되는 핸들러 함수.
//  - 등록된 인터럽트 로그를 지울때 호출됩니다.
//  - List Box 콘트롤에서 마우스 오르쪽 버튼을 더블클릭하면 이 함수가 호출됩니다.
// --------------------------------------------------------------------------
procedure TForm1.lstIntLogDblClick(Sender: TObject);
begin
    lstIntLog.Clear;
end;

// ++ =======================================================================
// >> OnControlMessage(...) : 인터럽트 메시지 핸들러 함수.
//  - 인터럽트 방식중 윈도 메세지 방식으로 인터럽트를 사용할 경우 라이브러리에서
//    인터럽트 발생시 자동으로 호출되는 인터럽트 메세지 처리 함수입니다.
//  - wParam에는 축정보가 전달됩니다.
//  - lParam에는 인터럽트가 발생된 Bank정보가 전달 됩니다.
// --------------------------------------------------------------------------
procedure TForm1.OnControlMessage(var Msg : TMessage);
var
    strData : String;
    lAxisNo: SmallInt;
    nIntrFlag: SmallInt;
    IntBank0, IntBank1: DWord;
begin
	lAxisNo := LOBYTE(Msg.WParam);		// Interrupt generation axis number.
	nIntrFlag := Msg.LParam;	        // Interrupt generation axis location.

	AxmInterruptReadAxisFlag(lAxisNo, 0, @IntBank0);
	AxmInterruptReadAxisFlag(lAxisNo, 1, @IntBank1);

	g_nIntCnt := g_nIntCnt + 1;
    strData := 'Msg[' + Format('%d', [g_nIntCnt]) + ']Axis[' +  Format('%d', [lAxisNo]) + ']Flag[0x' + Format('%X', [nIntrFlag]) + ']';
	lstIntLog.Items.Add(strData);
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
begin
    if ((AxlOpen(7) <> AXT_RT_SUCCESS))then
    begin
	    ShowMessage('AxlOpen Fail...');
      Result := false;
      exit;
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
    AxmInfoGetAxis(m_lAxisNo, nil, nil, @m_dwModuleID);

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

      cboSelAxis.AddItem(strData, TObject(i));

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

    rdoMessage.Checked := true;

    Result := true;
end;

// ++ =======================================================================
// >> UpdateState() : 지정한 축의 설정값들을 읽어 Control과 일치시키는 함수.
//  - 축번호가 변경되었을 때 변경한 축의 설정값들과 Control들과 일치시키는
//    역할을하는 함수입니다.
//  - 지정한 축의 모델별 제약들을 Control에 반영하는 역할을 합니다.
//  - 프로그램 초기 실행시, Mot파일 불러올 때, 축 번호 바뀔 때 사용됩니다.
// --------------------------------------------------------------------------
Function TForm1.UpdateState() : Boolean; stdcall;
var
    dwIntMask : DWORD;
    strIntMask : String;
begin
    if (m_lAxisCount < 1) then
    begin
        Result := false;
        exit;
    end;

    // ++ 지정한 축의 인터럽트 Bank1의 설정값을 확인합니다.
    AxmInterruptGetUserEnable(m_lAxisNo, INT_BANK_1, @dwIntMask);
    strIntMask := Format('Interrupt Event Bank 1 [0x%.8x]', [dwIntMask]);
    grpBank1.Caption := strIntMask;

    // ++ 인터럽트 설정값 해당 콘트롤에 적용
    if (dwIntMask and QIINTBANK1_0 <> 0) then chkBank1Bit00.Checked := true
    else chkBank1Bit00.Checked := false;
    if (dwIntMask and QIINTBANK1_1 <> 0) then chkBank1Bit01.Checked := true
    else chkBank1Bit01.Checked := false;
    if (dwIntMask and QIINTBANK1_2 <> 0) then chkBank1Bit02.Checked := true
    else chkBank1Bit02.Checked := false;
    if (dwIntMask and QIINTBANK1_31 <> 0) then chkBank1Bit31.Checked := true
    else chkBank1Bit31.Checked := false;

    // ++ 지정한 축의 인터럽트 Bank2의 설정값을 확인합니다.
    AxmInterruptGetUserEnable(m_lAxisNo, INT_BANK_2, @dwIntMask);
    strIntMask := Format('Interrupt Event Bank 2 [0x%.8x]', [dwIntMask]);
    grpBank2.Caption := strIntMask;

    // 인터럽트 설정값 해당 콘트롤에 적용
    if (dwIntMask and QIINTBANK2_14 <> 0) then chkBank2Bit14.Checked := true
    else chkBank2Bit14.Checked := false;
    if (dwIntMask and QIINTBANK2_15 <> 0) then chkBank2Bit15.Checked := true
    else
        chkBank2Bit15.Checked := False;
    if (dwIntMask and QIINTBANK2_16 <> 0) then
        chkBank2Bit16.Checked := true
    else
        chkBank2Bit16.Checked := False;
    if (dwIntMask and QIINTBANK2_20 <> 0) then chkBank2Bit20.Checked := true
    else chkBank2Bit20.Checked := false;
    if (dwIntMask and QIINTBANK2_21 <> 0) then chkBank2Bit21.Checked := true
    else chkBank2Bit21.Checked := false;
    if (dwIntMask and QIINTBANK2_22 <> 0) then chkBank2Bit22.Checked := true
    else chkBank2Bit22.Checked := false;

    Result := true;
end;

// ++ =======================================================================
// >> ThreadData(...) : 인터럽트 이벤트 처리 쓰레드.
//  - 인터럽트 방식중 이벤트 방식으로 인터럽트를 사용할 경우 라이브러리에서
//    인터럽트 발생시 자동으로 발생되는 인터럽트 이벤트 처리용 쓰레드입니다.
// --------------------------------------------------------------------------
function TForm1.ThreadData():Boolean; stdcall;
var
    lAxisNo: LongInt;
    strData: String;
    IntBank0, IntBank1: DWord;
begin
    lAxisNo := m_lAxisNo;
    while m_bThread[lAxisNo] = True do
    begin
        if (WaitForSingleObject(m_hInterrupt[lAxisNo], INFINITE) = WAIT_OBJECT_0) then
    	  begin
          AxmInterruptReadAxisFlag(lAxisNo, 0, @IntBank0);
        	AxmInterruptReadAxisFlag(lAxisNo, 1, @IntBank1);

        	g_nIntCnt := g_nIntCnt + 1;
          strData := 'Event[' + Format('%d', [g_nIntCnt]) + ']Axis[' +  Format('%d', [lAxisNo]) + ']Flag[0x' + Format('%X', [IntBank0]) + Format(', 0x%X', [IntBank1]) + ']';
        	Form1.lstIntLog.Items.Add(strData);
        end;
    end;

    Result := true;
end;

end.
