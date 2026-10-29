program Gantry_Motion;

uses
  Forms,
  GantryMotion in 'GantryMotion.pas' {Form1};

{$R *.res}

begin
  Application.Initialize;
  Application.CreateForm(TForm1, Form1);
  Application.Run;
end.
