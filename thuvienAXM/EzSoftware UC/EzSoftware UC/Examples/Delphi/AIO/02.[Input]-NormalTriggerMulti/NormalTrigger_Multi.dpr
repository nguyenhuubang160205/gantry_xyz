program NormalTrigger_Multi;

uses
  Forms,
  NormalTriggerMulti in 'NormalTriggerMulti.pas' {Form1};

{$R *.res}

begin
  Application.Initialize;
  Application.CreateForm(TForm1, Form1);
  Application.Run;
end.
