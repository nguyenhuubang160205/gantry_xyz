program AnalogOutput;

uses
  Forms,
  AOExample in 'AOExample.pas' {FormAnalogOutput};

{$R *.res}

begin
  Application.Initialize;
  Application.CreateForm(TFormAnalogOutput, FormAnalogOutput);
  Application.Run;
end.
