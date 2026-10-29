program AnalogInput;

uses
  Forms,
  AIExample in 'AIExample.pas' {FormAnalogInput},
  MyThread in 'MyThread.pas';

{$R *.res}

begin
  Application.Initialize;
  Application.CreateForm(TFormAnalogInput, FormAnalogInput);
  Application.Run;
end.
