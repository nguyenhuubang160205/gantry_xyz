unit MyThread;

interface

uses
  Classes, Windows, SysUtils, AXL, AXHS, AXD;

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
  DIOExample;

{ Important: Methods and properties of objects in visual components can only be
  used in a method called using Synchronize, for example,

      Synchronize(UpdateCaption);

  and UpdateCaption could look like,

    procedure MyThread.UpdateCaption;
    begin
      Form1.Caption := 'Updated in a thread';
    end; }

{ MyThread }

constructor TMyThread.Create; 
begin 
  inherited Create(false);
  Priority := tpLower;
end;

procedure TMyThread.Execute;
var
  i, j : SmallInt;
  lModuleNo : LongInt;
  dwFlag, dwValue : DWORD;
  strInt : String;
begin
    while m_bThread do
	begin
		if (WaitForSingleObject(Cardinal(m_hInterrupt), INFINITE) = WAIT_OBJECT_0) then
		begin
			AxdiInterruptRead(@lModuleNo, @dwFlag);

			for i := 0 to 3 do
			begin
				for j := 0 to 7 do
				begin
					if ((((dwFlag shr (i * 8)) shr j) and $01) = 1) then
					begin
						AxdiReadInportBit(lModuleNo, ((i * 8)+ j), @dwValue);

						if (dwValue = 1) then
                        begin  strInt := '[Event] °„Rising Int Set Bit ' + IntToStr((i * 8)+ j); end
                        else
                        begin  strInt := '[Event] °ÂFalling Int Set Bit ' + IntToStr((i * 8)+ j); end;

                        FormDigitalIO.m_lstInterrupt.Items.Add(strInt);
                        FormDigitalIO.m_lstInterrupt.Selected[FormDigitalIO.m_lstInterrupt.Count - 1] := true;
                    end;
                end;
			end;
		end;
	end;
end;

end.
