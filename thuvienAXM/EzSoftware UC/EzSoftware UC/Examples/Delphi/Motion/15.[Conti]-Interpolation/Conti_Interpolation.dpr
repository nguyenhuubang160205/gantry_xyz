program Conti_Interpolation;

uses
  Forms,
  ContiInterpolation in 'ContiInterpolation.pas' {Form1};

{$R *.res}

begin
  Application.Initialize;
  Application.CreateForm(TForm1, Form1);
  Application.Run;
end.
