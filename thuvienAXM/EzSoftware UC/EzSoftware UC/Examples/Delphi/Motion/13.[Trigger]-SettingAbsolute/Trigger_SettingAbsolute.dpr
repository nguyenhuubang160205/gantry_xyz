program Trigger_SettingAbsolute;

uses
  Forms,
  TriggerSettingAbsolute in 'TriggerSettingAbsolute.pas' {Form1};

{$R *.res}

begin
  Application.Initialize;
  Application.CreateForm(TForm1, Form1);
  Application.Run;
end.
