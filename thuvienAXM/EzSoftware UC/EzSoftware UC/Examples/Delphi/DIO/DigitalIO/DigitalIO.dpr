program DigitalIO;

uses
  Forms,
  DIOExample in 'DIOExample.pas' {FormDigitalIO},
  MyThread in 'MyThread.pas';

{$R *.res}

begin
  Application.Initialize;
  Application.CreateForm(TFormDigitalIO, FormDigitalIO);
  Application.Run;
end.
