program NormalTrigger_Single;

uses
  Forms,
  NormalTriggerSingle in 'NormalTriggerSingle.pas' {Form1};

{$R *.res}

begin
  Application.Initialize;
  Application.CreateForm(TForm1, Form1);
  Application.Run;
end.
