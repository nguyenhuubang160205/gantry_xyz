unit AIExample;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, AXL, AXHS, AXA, Grids, StdCtrls, ExtCtrls, MyThread;

type
  TFormAnalogInput = class(TForm)
    Label1: TLabel;
    Label2: TLabel;
    Label3: TLabel;
    Label5: TLabel;
    m_cbModulenum: TComboBox;
    m_chkChannel0: TCheckBox;
    m_chkChannel1: TCheckBox;
    m_chkChannel2: TCheckBox;
    m_chkChannel3: TCheckBox;
    m_cbVoltagerange0: TComboBox;
    m_cbVoltagerange1: TComboBox;
    m_cbVoltagerange2: TComboBox;
    m_cbVoltagerange3: TComboBox;
    m_edtLength: TEdit;
    Button1: TButton;
    m_btnStart: TButton;
    m_lstAIData: TStringGrid;
    m_chkChannel4: TCheckBox;
    m_chkChannel5: TCheckBox;
    m_chkChannel6: TCheckBox;
    m_chkChannel7: TCheckBox;
    m_cbVoltagerange4: TComboBox;
    m_cbVoltagerange5: TComboBox;
    m_cbVoltagerange6: TComboBox;
    m_cbVoltagerange7: TComboBox;
    Label4: TLabel;
    Label6: TLabel;
    procedure FormCreate(Sender: TObject);
    procedure Button1Click(Sender: TObject);
    procedure m_btnStartClick(Sender: TObject);

  private
    { Private declarations }
    ThreadFlag:TMyThread;

    procedure InitControl();
    procedure InitDeviceInformation();
    
  public
    { Public declarations }
    procedure StartClick();
  end;

var
  FormAnalogInput: TFormAnalogInput;
  m_AICH   : array[0..7] of TCheckBox;
  m_AIVoltRange     : array[0..7] of TComboBox;

  m_lAIModuleNum    : array[0..9] of Integer;
  m_lAIIndex        : array[0..9] of Integer;
  m_lAICount        : Integer;
  m_bStart          : Boolean;
  m_bThread         : Boolean;

  // Event Flag
  g_fChannelEvent : array[0..3] of Boolean;

implementation

{$R *.dfm}

procedure TFormAnalogInput.FormCreate(Sender: TObject);
begin
  m_bStart := false;
  m_bThread := false;

  // Library and Motion initialize.
	InitDeviceInformation();
end;

procedure TFormAnalogInput.Button1Click(Sender: TObject);
begin
  AxlClose();
  Close();
end;

procedure TFormAnalogInput.InitDeviceInformation();
var
  dwStatus  : DWORD;
  lModuleCounts : Integer;

begin
	//++
	// Library initialize.
	if (AxlOpenNoReset(7) = AXT_RT_SUCCESS) then
	begin
		if (AxaInfoIsAIOModule(@dwStatus) = AXT_RT_SUCCESS) then
		begin
			if (dwStatus = STATUS_EXIST) then
			begin
				if (AxaInfoGetModuleCount(@lModuleCounts) = AXT_RT_SUCCESS) then
        begin
					InitControl();
        end
				else
        begin
					ShowMessage('AI Module Not initialized.');
        end;
			end
			else
      begin
				ShowMessage('AIO Module Not Exist.');
      end;
		end
		else
		begin
			ShowMessage('AxaIsAIModule Error!!');
		end;
	end
	else
	begin
		ShowMessage('Drive Not opend.');
	end;
end;

procedure TFormAnalogInput.InitControl();
var
    i, j : SmallInt;
    lModuleCount, lBoardNo, lModulePos, nCount : Integer;
    strVoltRange  : String;
		dwModuleID  : DWORD;
		strData     : String;

begin
    m_AICH[0] := m_chkChannel0;
    m_AICH[1] := m_chkChannel1;
    m_AICH[2] := m_chkChannel2;
    m_AICH[3] := m_chkChannel3;
    m_AICH[4] := m_chkChannel4;
    m_AICH[5] := m_chkChannel5;
    m_AICH[6] := m_chkChannel6;
    m_AICH[7] := m_chkChannel7;

    m_AIVoltRange[0] := m_cbVoltagerange0;
    m_AIVoltRange[1] := m_cbVoltagerange1;
    m_AIVoltRange[2] := m_cbVoltagerange2;
    m_AIVoltRange[3] := m_cbVoltagerange3;
    m_AIVoltRange[4] := m_cbVoltagerange4;
    m_AIVoltRange[5] := m_cbVoltagerange5;
    m_AIVoltRange[6] := m_cbVoltagerange6;
    m_AIVoltRange[7] := m_cbVoltagerange7;

    // In/Output Volt Range
    strVoltRange := '-10V~10V';

    // Init Variable
    for i:=0 to 7 do
    begin
      m_AIVoltRange[i].Items.Add(strVoltRange);
      m_AIVoltRange[i].ItemIndex := 0;
    end;

    // String Grid
    m_lstAIData.Col := 8;
    m_lstAIData.Cells[0,0] := 'No';
    m_lstAIData.Cells[1,0] := 'CH #0';
    m_lstAIData.Cells[2,0] := 'CH #1';
    m_lstAIData.Cells[3,0] := 'CH #2';
    m_lstAIData.Cells[4,0] := 'CH #3';
    m_lstAIData.Cells[5,0] := 'CH #4';
    m_lstAIData.Cells[6,0] := 'CH #5';
    m_lstAIData.Cells[7,0] := 'CH #6';
    m_lstAIData.Cells[8,0] := 'CH #7';

    if (AxaInfoGetModuleCount(@lModuleCount) = AXT_RT_SUCCESS) then
    begin
      nCount := 0;

  		for i := 0 to lModuleCount-1 do
		  begin
  			if (AxaInfoGetModule(i, @lBoardNo, @lModulePos, @dwModuleID) = AXT_RT_SUCCESS) then
        begin
          if (dwModuleID = AXT_SIO_RAI8RB) then
          begin
            strData := 'BoardNo = ' + IntToStr(lBoardNo)+', ' + 'ModulePos = ' + IntToStr(lModulePos);
            m_cbModulenum.Items.Add(strData);
            m_lAIModuleNum[nCount] := i;
            Inc(nCount);
          end;
			end;
		end;
	end;

  m_cbModulenum.ItemIndex := 0;
end;

procedure TFormAnalogInput.StartClick();
var
  i, k, nVoltRange : SmallInt;
  dVoltRangeMin, dVoltRangeMax : double;
  nSampleRate, nDataLength : Integer;
  lModuleNum  : LongInt;
  pnCHList : array [0..7] of LongInt;

begin
  m_lAICount := 1;

  pnCHList[0] := 0;
  pnCHList[1] := 1;
  pnCHList[2] := 2;
  pnCHList[3] := 3;
  pnCHList[4] := 4;
  pnCHList[5] := 5;
  pnCHList[6] := 6;
  pnCHList[7] := 7;

  // Get specified module position
	lModuleNum := m_lAIModuleNum[m_cbModulenum.ItemIndex];

  if (m_bStart) then
  begin
    // Tread End
    m_bThread := false;
    ThreadFlag.Terminate;

    m_btnStart.Caption := 'Start(&S)';
    m_bStart := false;
  end
  else
  begin

     // Set Data Length at Buffer will save
   nDataLength := StrToInt(m_edtLength.Text);
  AxaiHwSetMultiLimit(8, @pnCHList, 0, nDataLength);

    dVoltRangeMin := -10;
    dVoltRangeMax := 10;

    for k:=0 to m_lstAIData.RowCount-1 do
    begin
      m_lstAIData.Rows[k].Clear();
    end;
    for i :=0 to 7 do
		begin
			g_fChannelEvent[i] := false;
		end;

    // Thread Setting
    if (not m_bThread) then
    begin
      m_bThread	:= TRUE;

      ThreadFlag := TMyThread.Create;
    end;
      m_btnStart.Caption := 'Stop(&S)';
        m_bStart := true;
  end;
end;

procedure TFormAnalogInput.m_btnStartClick(Sender: TObject);
begin;
  StartClick();
end;

end.
