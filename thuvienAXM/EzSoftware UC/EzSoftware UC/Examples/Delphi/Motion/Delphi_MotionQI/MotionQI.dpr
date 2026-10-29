program MotionQI;

uses
  Forms,
  ManualSet in 'ManualSet.pas' {frmManualSet},
  Status in 'Status.pas' {frmStatus},
  DGraph in 'DGraph.pas' {frm3DGraph},
  CamcQI in 'CamcQI.pas' {frmCamcQI};

{$R *.res}

begin
  Application.Initialize;
  Application.CreateForm(TfrmCamcQI, frmCamcQI);
  Application.CreateForm(TfrmManualSet, frmManualSet);
  Application.CreateForm(TfrmStatus, frmStatus);
  Application.CreateForm(Tfrm3DGraph, frm3DGraph);
  Application.Run;
end.
