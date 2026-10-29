unit MyThread;

interface

uses
  Windows, SysUtils, Classes, AXL, AXHS, AXA;

type
  TMyThread = class(TThread)
  constructor Create; 
  private
    { Private declarations }
  protected
    procedure Execute; override;
  end;

implementation
uses
  AIExample;

constructor TMyThread.Create;
begin 
  inherited Create(false);
  Priority := tpLower;
end;

procedure TMyThread.Execute;
var
  pdCBuffer : array [0..3, 0..1023] of Double;
  pdBuffer : array[0..3] of PDouble;

  i, j, nChNum  : SmallInt;
  pnCHList : array[0..3] of LongInt;
  pwSize : array[0..3] of LongInt;
  dInVolt : double;
  nLength : Integer;
  bExeMode, fDone : Boolean;
	lSize : LongInt;
begin

  pdBuffer[0] := @pdCBuffer[0,0];
  pdBuffer[1] := @pdCBuffer[1,0];
  pdBuffer[2] := @pdCBuffer[2,0];
  pdBuffer[3] := @pdCBuffer[3,0];

  pnCHList[0] := 0;
  pnCHList[1] := 1;
  pnCHList[2] := 2;
  pnCHList[3] := 3;

  pwSize[0] := 0;
  pwSize[1] := 1;
  pwSize[2] := 2;
  pwSize[3] := 3;

  nLength := StrToInt(FormAnalogInput.m_edtLength.Text);
  bExeMode := true ;     // bExeMode == 0 : to buffer length, bExeMode == 1 : Repeat

  nChNum := 0;
  for i := 0 to 3 do
  begin
    if (m_AICH[i].Checked) then
    begin
      pnCHList[nChNum] := i;	                // All Channel number
			pwSize[nChNum]	 := nLength;
      pdBuffer[nChNum] := @pdCBuffer[nChNum, 0];
			Inc(nChNum);
    end;
  end;

  while m_bThread do
  begin
     begin
      if (StrToInt(FormAnalogInput.m_edtLength.Text) = m_lAICount) then
        m_lAICount := 0;

      FormAnalogInput.m_lstAIData.RowCount := m_lAICount;
      FormAnalogInput.m_lstAIData.Cells[0, m_lAICount] := IntToStr(m_lAICount);

      for i:=0 to 7 do
      begin
        if (m_AICH[i].Checked) then
        begin
          AxaiSwReadVoltage(i, @dInVolt);
          FormAnalogInput.m_lstAIData.Cells[i+1, m_lAICount] := FloatToStr(dInVolt);
        end;
      end;
      Inc(m_lAICount);
    end;

    // String Grid Auto Scroll Function
    if((FormAnalogInput.m_lstAIData.TopRow + FormAnalogInput.m_lstAIData.VisibleRowCount) < FormAnalogInput.m_lstAIData.RowCount) then
      FormAnalogInput.m_lstAIData.TopRow := FormAnalogInput.m_lstAIData.TopRow + FormAnalogInput.m_lstAIData.VisibleRowCount;

    if (not bExeMode) then //Allow buffer length only, and Stop If buffer is full
    begin
      m_bStart := true ;
      FormAnalogInput.StartClick();
    end;
  end;

  m_bThread := false;

end;

end.
 