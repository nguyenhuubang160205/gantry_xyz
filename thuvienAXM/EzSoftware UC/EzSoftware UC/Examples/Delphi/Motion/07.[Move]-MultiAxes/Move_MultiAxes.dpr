program Move_MultiAxes;

uses
  Forms,
  MoveMultiAxes in 'MoveMultiAxes.pas' {Form1};

{$R *.res}

begin
  Application.Initialize;
  Application.CreateForm(TForm1, Form1);
  Application.Run;
end.
