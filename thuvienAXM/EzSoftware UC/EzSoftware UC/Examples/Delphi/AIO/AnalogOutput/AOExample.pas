unit AOExample;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, ComCtrls, ExtCtrls, StdCtrls, AXL, AXHS ,AXA;

type
  TFormAnalogOutput = class(TForm)
    Label6: TLabel;
    Label7: TLabel;
    Label8: TLabel;
    Label9: TLabel;
    Label10: TLabel;
    Label11: TLabel;
    Label12: TLabel;
    Label13: TLabel;
    m_stcModulenum0: TLabel;
    m_stcModulenum1: TLabel;
    m_stcModulenum2: TLabel;
    m_stcModulenum3: TLabel;
    m_stcModuleid0: TLabel;
    m_stcModuleid1: TLabel;
    m_stcModuleid2: TLabel;
    m_stcModuleid3: TLabel;
    Label2: TLabel;
    m_btnClose: TButton;
    m_cbModulenum: TComboBox;
    m_chkChannel0: TCheckBox;
    m_chkChannel1: TCheckBox;
    m_chkChannel2: TCheckBox;
    m_chkChannel3: TCheckBox;
    m_cbWave0: TComboBox;
    m_cbWave1: TComboBox;
    m_cbWave2: TComboBox;
    m_cbWave3: TComboBox;
    m_edtPeriod0: TEdit;
    m_edtPeriod1: TEdit;
    m_edtPeriod2: TEdit;
    m_edtPeriod3: TEdit;
    m_cbVRange0: TComboBox;
    m_cbVRange1: TComboBox;
    m_cbVRange2: TComboBox;
    m_cbVRange3: TComboBox;
    m_edtValtage0: TEdit;
    m_edtValtage1: TEdit;
    m_edtValtage2: TEdit;
    m_edtValtage3: TEdit;
    m_cbGap: TComboBox;
    m_btnStart: TButton;
    Timer1: TTimer;
    m_spnVoltage0: TUpDown;
    m_spnVoltage1: TUpDown;
    m_spnVoltage2: TUpDown;
    m_spnVoltage3: TUpDown;
    procedure FormCreate(Sender: TObject);
    procedure m_btnCloseClick(Sender: TObject);
    procedure m_btnStartClick(Sender: TObject);
    procedure Timer1Timer(Sender: TObject);
    procedure m_cbModulenumChange(Sender: TObject);
    procedure m_edtValtage0Change(Sender: TObject);
    procedure m_edtValtage1Change(Sender: TObject);
    procedure m_edtValtage2Change(Sender: TObject);
    procedure m_edtValtage3Change(Sender: TObject);
    procedure m_cbVRange0Change(Sender: TObject);
    procedure m_cbVRange1Change(Sender: TObject);
    procedure m_cbVRange2Change(Sender: TObject);
    procedure m_cbVRange3Change(Sender: TObject);
  private
    { Private declarations }
    procedure InitControl();
    procedure InitDeviceInformation();
    procedure ChangeModuleNum();

  public
    { Public declarations }
    procedure VoltageChange(ch: Integer);
    procedure VRangeChange(ch: Integer);
  end;

var
  FormAnalogOutput: TFormAnalogOutput;
  m_AOCH   : array[0..3] of TCheckBox;
  m_AOModuleNum     : array[0..3] of TLabel;
  m_AOModuleID      : array[0..3] of TLabel;
  m_AOWave          : array[0..3] of TComboBox;
  m_AOPeriod        : array[0..3] of TEdit;
  m_AOVoltRange     : array[0..3] of TComboBox;
  m_AOValtage       : array[0..3] of TEdit;
  m_AOValtageUpDown : array[0..3] of TUpDown;

  m_lAOModuleNum    : array[0..9] of Integer;
  m_lAOIndex        : array[0..9] of Integer;
  lChannelCount, m_nGap     : Integer;
  m_bStart          : Boolean;
implementation

{$R *.dfm}

procedure TFormAnalogOutput.FormCreate(Sender: TObject);
begin
  // Library and Motion initialize.
	InitDeviceInformation();
end;

procedure TFormAnalogOutput.m_btnCloseClick(Sender: TObject);
var
  i : SmallInt;
begin
  for i :=0 to lChannelCount-1 do
  begin
	  AxaoWriteVoltage(i, 0);
  end;

  AxlClose();
  Close();
end;

procedure TFormAnalogOutput.InitDeviceInformation();
var
    dwStatus : DWORD;
    lModuleCount   : Integer;

begin
	//++
	// Library initialize.
	if (AxlOpenNoReset(7) = AXT_RT_SUCCESS) then
  begin
		if (AxaInfoIsAIOModule(@dwStatus) = AXT_RT_SUCCESS) then
		begin
			if (dwStatus = STATUS_EXIST) then
			begin
				if (AxaInfoGetModuleCount(@lModuleCount) = AXT_RT_SUCCESS) then
				begin
					InitControl();
				end
				else
				begin
					Application.MessageBox('AO Module Not initialized.', 'Ajinextek', MB_OK);
				end;
      end
			else
			begin
				Application.MessageBox('SIO-AO4R Module Not Exist.', 'Ajinextek', MB_OK);
			end;
		end
		else
		begin
			Application.MessageBox('AxaIsAOModule Error!!', 'Ajinextek', MB_OK);
    end;
	end
	else
	begin
		Application.MessageBox('Drive Not opend.', 'Ajinextek', MB_OK);
	end;
end;

procedure TFormAnalogOutput.InitControl();
var
    i, j : SmallInt;
    strVoltRange   : array[0..3] of String;
    strWave   : array[0..3] of String;
begin
    m_AOCH[0] := m_chkChannel0;
    m_AOCH[1] := m_chkChannel1;
    m_AOCH[2] := m_chkChannel2;
    m_AOCH[3] := m_chkChannel3;

    m_AOModuleNum[0] := m_stcModulenum0;
    m_AOModuleNum[1] := m_stcModulenum1;
    m_AOModuleNum[2] := m_stcModulenum2;
    m_AOModuleNum[3] := m_stcModulenum3;

    m_AOModuleID[0] := m_stcModuleid0;
    m_AOModuleID[1] := m_stcModuleid1;
    m_AOModuleID[2] := m_stcModuleid2;
    m_AOModuleID[3] := m_stcModuleid3;

    m_AOWave[0]     := m_cbWave0;
    m_AOWave[1]     := m_cbWave1;
    m_AOWave[2]     := m_cbWave2;
    m_AOWave[3]     := m_cbWave3;

    m_AOPeriod[0]   := m_edtPeriod0;
    m_AOPeriod[1]   := m_edtPeriod1;
    m_AOPeriod[2]   := m_edtPeriod2;
    m_AOPeriod[3]   := m_edtPeriod3;

    m_AOVoltRange[0] := m_cbVRange0;
    m_AOVoltRange[1] := m_cbVRange1;
    m_AOVoltRange[2] := m_cbVRange2;
    m_AOVoltRange[3] := m_cbVRange3;

    m_AOValtage[0] := m_edtValtage0;
    m_AOValtage[1] := m_edtValtage1;
    m_AOValtage[2] := m_edtValtage2;
    m_AOValtage[3] := m_edtValtage3;

    m_AOValtageUpDown[0] := m_spnVoltage0;
    m_AOValtageUpDown[1] := m_spnVoltage1;
    m_AOValtageUpDown[2] := m_spnVoltage2;
    m_AOValtageUpDown[3] := m_spnVoltage3;

    // Interval
    m_cbGap.Items.Add('1ms');
    m_cbGap.Items.Add('5ms');
    m_cbGap.Items.Add('10ms');
    m_cbGap.ItemIndex := 0;

    // In/Output Volt Range
    strVoltRange[0] := '-10V~10V';

    // Wave
    strWave[0] := 'Sin';
    strWave[1] := 'Triangle';
    strWave[2] := 'Rectangle';
    strWave[3] := 'Volt';

    // Init valiable
    for i:=0 to 3 do
    begin
      for j:=0 to 3 do
      begin
        m_AOVoltRange[i].Items.Add(strVoltRange[j]);
        m_AOWave[i].Items.Add(strWave[j]);
      end;

      m_AOWave[i].ItemIndex := 0;
      m_AOVoltRange[i].ItemIndex := 0;
      m_AOValtageUpDown[i].Min := -10;
      m_AOValtageUpDown[i].Max := 10;
    end;

    ChangeModuleNum();
end;

procedure TFormAnalogOutput.m_btnStartClick(Sender: TObject);
var
  i : SmallInt;
  dVoltRangeMin, dVoltRangeMax : double;
begin
    // Get an appoint module location
//	long lModuleNum = m_lAOModuleNum[m_cbModulenum->ItemIndex];
    dVoltRangeMin := 0;
    dVoltRangeMax := 0;

    if (m_bStart) then
    begin
      Timer1.Enabled := false;

      m_btnStart.Caption := 'Start(&S)';
      m_bStart := false;

      m_cbGap.Enabled := true;
    end
    else
    begin
      for i:=0 to 3 do
      begin
        if (m_AOCH[i].Checked) then
        begin
          // Get an output Volt range
          case m_AOVoltRange[i].ItemIndex of
            0:
            begin
              dVoltRangeMin := -10;
              dVoltRangeMax := 10;
            end;
          end;
        end;
      end;
      
      case m_cbGap.ItemIndex of
      0: m_nGap := 1;
      1: m_nGap := 5;
      2: m_nGap := 10;
      end;

      if (m_AOCH[0].Checked = true or m_AOCH[1].Checked = true or m_AOCH[2].Checked = true or m_AOCH[3].Checked = true) then
      begin
        Timer1.Enabled := true;
      end;

      m_btnStart.Caption := 'Stop(&S)';
      m_bStart := true;

      m_cbGap.Enabled := false;
    end;
end;

procedure TFormAnalogOutput.Timer1Timer(Sender: TObject);
var
  i, nIndex : SmallInt;
  dVRange, dValue, dPeriod : double;
begin
  dVRange := 0;

	for i := 0 to lChannelCount-1 do
	begin
    case m_AOVoltRange[i].ItemIndex of
			0:	dVRange	:= 10.0;
		end;

    nIndex := m_lAOIndex[i];
    dPeriod := StrToFloat(m_AOPeriod[i].Text);

		if (m_lAOIndex[i] >= dPeriod) then
    begin
			m_lAOIndex[i]	:= 0;
    end
		else
    begin
			m_lAOIndex[i] := m_lAOIndex[i] + m_nGap;
    end;

		if (m_AOCH[i].Checked) then
    begin
			case m_AOWave[i].ItemIndex of
				0:		// Sin wave
        begin
  				dPeriod	:= dPeriod / 2.0;
	  			dValue	:= sin(nIndex * 3.141592 / dPeriod) * dVRange;

				  AxaoWriteVoltage(i, dValue);
				end;

			  1:		// Triangle wave
        begin
  				// under the rise which the interval is big than 0 (case which the interval is 100 0 ~ 24)
	  			if (nIndex < (dPeriod / 4.0)) then
          begin
					  dValue	:= dVRange / (dPeriod / 4) * nIndex;
          end

  				// under the falling which the interval (case which the interval is 100 25 ~ 74)
	  			else if (nIndex < ((dPeriod / 4.0) * 3)) then
          begin
  					dValue	:= -((dVRange / (dPeriod / 4)) * nIndex) + dVRange * 2.0;
          end

  				// under the rise which the interval is small than 0 (case which the interval is 100 75 ~ 99)
	  			else
          begin
  					dValue	:= (dVRange / (dPeriod / 4) * nIndex) - dVRange * 4.0;
          end;

  				AxaoWriteVoltage(i, dValue);
				end;

			  2:		// Rectangle wave
        begin
  				// under the rise which the interval (case which the interval is 100 0 ~ 49)
	  			if (nIndex < dPeriod / 2.0) then
          begin
  					dValue	:= dVRange;
          end
  				// under the falling which the interval (case which the interval is 100 50 ~ 99)
	  			else
          begin
  					dValue	:= -dVRange;
          end;

  				AxaoWriteVoltage(i, dValue);
				end;
			end;
		end;
	end;
end;

procedure TFormAnalogOutput.m_cbModulenumChange(Sender: TObject);
begin
  ChangeModuleNum();
end;

procedure TFormAnalogOutput.ChangeModuleNum();
var
    i, nCount : SmallInt;
    lBoardNo, lModulePos, lModuleCount, lModuleNum : Integer;
    dwModuleID  : DWORD;
    strData : String;
begin
    nCount := 0;
               
    if (AxaInfoGetModuleCount(@lModuleCount) = AXT_RT_SUCCESS) then
    begin
  		for i := 0 to lModuleCount do
		  begin
  			if (AxaInfoGetModule(i, @lBoardNo, @lModulePos, @dwModuleID) = AXT_RT_SUCCESS) then
			  begin
          if (dwModuleID = AXT_SIO_AO4RB) then
          begin
            strData := 'BoardNo = ' + IntToStr(lBoardNo)+', ' + 'ModulePos = ' + IntToStr(lModulePos);
            m_cbModulenum.Items.Add(strData);
            m_lAOModuleNum[nCount] := i;
            Inc(nCount);
          end
          else if (dwModuleID = AXT_SIO_RAO4RB) then
          begin
            strData := 'BoardNo = ' + IntToStr(lBoardNo)+', ' + 'ModulePos = ' + IntToStr(lModulePos);
            m_cbModulenum.Items.Add(strData);
            m_lAOModuleNum[nCount] := i;
            Inc(nCount);
          end;
        end;
			end;
		end;

    m_cbModulenum.ItemIndex := 0;

    lModuleNum := m_lAOModuleNum[m_cbModulenum.ItemIndex];
    AxaoInfoGetChannelCount(@lChannelCount);

	for i := 0 to lChannelCount-1 do
	begin
		AxaoWriteVoltage(i, 0);

    m_AOModuleNum[i].Caption := IntToStr(lModuleNum);
    m_AOModuleID[i].Caption := FloatToStr(dwModuleID);
    m_lAOIndex[i] := 0;
	end;
end;

procedure TFormAnalogOutput.m_edtValtage0Change(Sender: TObject);
begin
  if (m_cbWave0.ItemIndex = 3) then
    VoltageChange(0);
end;

procedure TFormAnalogOutput.m_edtValtage1Change(Sender: TObject);
begin
  if (m_cbWave1.ItemIndex = 3) then
    VoltageChange(1);
end;

procedure TFormAnalogOutput.m_edtValtage2Change(Sender: TObject);
begin
  if (m_cbWave2.ItemIndex = 3) then
    VoltageChange(2);
end;

procedure TFormAnalogOutput.m_edtValtage3Change(Sender: TObject);
begin
  if (m_cbWave3.ItemIndex = 3) then
    VoltageChange(3);
end;

procedure TFormAnalogOutput.VoltageChange(ch: Integer);
var
  dMaxValue, dMinValue, dVoltage : double;

begin
  dMaxValue := 0;
  dMinValue := 0;
  
	case m_AOVoltRange[ch].ItemIndex of
	0:
    begin
	  	AxaoSetRange(ch, -10, 10);
      m_AOValtageUpDown[ch].Min := -10;
      m_AOValtageUpDown[ch].Max := 10;
      dMaxValue := 10;
      dMinValue := -10;
    end;
	end;

  dVoltage := StrToFloat(m_AOValtage[ch].Text);
  if (dVoltage > dMaxValue) then
  begin
    dVoltage := dMaxValue;
    m_AOValtage[ch].Text := FloatToStr(dMaxValue);
  end
  else if (dVoltage < dMinValue) then
  begin
    dVoltage := dMinValue;
    m_AOValtage[ch].Text := FloatToStr(dMinValue);
  end;

	if (m_AOCH[ch].Checked) then
		AxaoWriteVoltage(ch, dVoltage);

end;

procedure TFormAnalogOutput.m_cbVRange0Change(Sender: TObject);
begin
  VRangeChange(0);
end;

procedure TFormAnalogOutput.m_cbVRange1Change(Sender: TObject);
begin
  VRangeChange(1);
end;

procedure TFormAnalogOutput.m_cbVRange2Change(Sender: TObject);
begin
  VRangeChange(2);
end;

procedure TFormAnalogOutput.m_cbVRange3Change(Sender: TObject);
begin
  VRangeChange(3);
end;

procedure TFormAnalogOutput.VRangeChange(ch: Integer);
begin
  case m_AOVoltRange[ch].ItemIndex of
	  0:  AxaoSetRange(ch, -10, 10);
	end;

	m_AOValtage[ch].Text := '0';
	AxaoWriteVoltage(ch, 0);
end;

end.
