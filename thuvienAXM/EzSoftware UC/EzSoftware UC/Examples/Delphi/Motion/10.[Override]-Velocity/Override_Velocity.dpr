program Override_Velocity;

uses
  Forms,
  OverrideVelocity in 'OverrideVelocity.pas' {Form1};

{$R *.res}

begin
  Application.Initialize;
  Application.CreateForm(TForm1, Form1);
  Application.Run;
end.
