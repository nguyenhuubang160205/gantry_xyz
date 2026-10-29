program Trigger_SettingBlock;

uses
  Forms,
  TriggerSettingBlock in 'TriggerSettingBlock.pas' {Form1};

{$R *.res}

begin
  Application.Initialize;
  Application.CreateForm(TForm1, Form1);
  Application.Run;
end.
