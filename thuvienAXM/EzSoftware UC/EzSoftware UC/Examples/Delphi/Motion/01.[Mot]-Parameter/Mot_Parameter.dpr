program Mot_Parameter;

uses
  Forms,
  MotParameter in 'MotParameter.pas' {MotParameter};

{$R *.res}

begin
  Application.Initialize;
  Application.CreateForm(TForm1, Form1);
  Application.Run;
end.
