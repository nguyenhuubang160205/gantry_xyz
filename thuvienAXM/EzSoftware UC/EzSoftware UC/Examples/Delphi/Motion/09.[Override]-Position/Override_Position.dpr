program Override_Position;

{$R 'Override_PositionResource.res' 'Override_PositionResource.rc'}

uses
  Forms,
  OverridePosition in 'OverridePosition.pas' {Form1};

{$R *.res}

begin
  Application.Initialize;
  Application.CreateForm(TForm1, Form1);
  Application.Run;
end.
