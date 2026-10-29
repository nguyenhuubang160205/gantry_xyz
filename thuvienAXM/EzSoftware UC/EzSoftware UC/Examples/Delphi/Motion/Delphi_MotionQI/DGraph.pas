unit DGraph;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  AXL,AXM,AXHS,
  Dialogs, ExtCtrls, StdCtrls, OleCtrls, AxtGraph3DLib_TLB;

const
    COORDINATE = 0;

type
  Tfrm3DGraph = class(TForm)
    btnHelical: TButton;
    btnHelicalPlay: TButton;
    btnSpline: TButton;
    btnSplinePlay: TButton;
    btnClear: TButton;
    btnClose: TButton;
    tmGraph: TTimer;
    Trigger: TGroupBox;
    StaticText50: TStaticText;
    StaticText51: TStaticText;
    cboAxisReset: TComboBox;
    cboDimension: TComboBox;
    editXCMD: TEdit;
    editYCMD: TEdit;
    editZCMD: TEdit;
    chkBoxEnable: TCheckBox;
    editRangeX: TEdit;
    editRangeY: TEdit;
    editRangeZ: TEdit;
    RangeX: TStaticText;
    RangeY: TStaticText;
    RangeZ: TStaticText;
    btnSetRange: TButton;
    Edit1: TEdit;
    Edit2: TEdit;
    Edit3: TEdit;
    AxtGraph3D: TAxtGraph3D;
    procedure btnHelicalClick(Sender: TObject);
    procedure btnHelicalPlayClick(Sender: TObject);
    procedure btnSplineClick(Sender: TObject);
    procedure btnSplinePlayClick(Sender: TObject);
    procedure tmGraphTimer(Sender: TObject);
    procedure btnClearClick(Sender: TObject);
    procedure btnCloseClick(Sender: TObject);
    procedure FormCreate(Sender: TObject);
    procedure chkBoxEnableClick(Sender: TObject);
    procedure btnSetRangeClick(Sender: TObject);
    procedure cboAxisResetChange(Sender: TObject);
    procedure cboDimensionChange(Sender: TObject);


  private
    { Private declarations }
  public
    { Public declarations }
    procedure UpdateAxis(lAxis : LongInt);
     end;

var
  frm3DGraph: Tfrm3DGraph;

implementation

uses CamcQI;

var
    m_aAxis : array[0..3] of LongInt;

{$R *.dfm}
Function AXIS_N04(nAxis, nPos : smallInt)  : Integer ;       // 한 칩의 축 위치로 변경(0~3)
Begin
    Result :=   ((nAxis div 4) * 4) + nPos;
End;

procedure Tfrm3DGraph.UpdateAxis(lAxis : LongInt);
begin
	m_aAxis[0]	:= AXIS_N04(lAxis, 0);
	m_aAxis[1]	:= AXIS_N04(lAxis, 1);
	m_aAxis[2]	:= AXIS_N04(lAxis, 2);
    m_aAxis[3]	:= AXIS_N04(lAxis, 3);
end;

procedure Tfrm3DGraph.btnHelicalClick(Sender: TObject);
var
    dVelocity, dAccel : Double;
begin
    dVelocity := 2000; dAccel := 4000;

	AxmContiSetAxisMap(COORDINATE, 4, @m_aAxis);
	AxmContiWriteClear(COORDINATE);
	AxmContiSetAbsRelMode(COORDINATE, POS_REL_MODE);

	AxmContiBeginNode(COORDINATE);
      AxmHelixCenterMove(COORDINATE, 500, 500, 0, 0, 100, dVelocity, dAccel, dAccel, DIR_CW);
	    AxmHelixCenterMove(COORDINATE, 500, 500, 0, 0, 100, dVelocity, dAccel, dAccel, DIR_CW);
	    AxmHelixCenterMove(COORDINATE, 500, 500, 0, 0, 100, dVelocity, dAccel, dAccel, DIR_CW);
	    AxmHelixCenterMove(COORDINATE, 500, 500, 0, 0, 100, dVelocity, dAccel, dAccel, DIR_CW);
	    AxmHelixCenterMove(COORDINATE, 500, 500, 0, 0, 100, dVelocity, dAccel, dAccel, DIR_CW);
	    AxmHelixCenterMove(COORDINATE, 500, 500, 0, 0, 100, dVelocity, dAccel, dAccel, DIR_CW);
	    AxmHelixCenterMove(COORDINATE, 500, 500, 0, 0, 100, dVelocity, dAccel, dAccel, DIR_CW);
	    AxmHelixCenterMove(COORDINATE, 500, 500, 0, 0, 100, dVelocity, dAccel, dAccel, DIR_CW);
	    AxmHelixCenterMove(COORDINATE, 500, 500, 0, 0, 100, dVelocity, dAccel, dAccel, DIR_CW);
	    AxmHelixCenterMove(COORDINATE, 500, 500, 0, 0, 100, dVelocity, dAccel, dAccel, DIR_CW);
	    AxmHelixCenterMove(COORDINATE, 500, 500, 0, 0, 100, dVelocity, dAccel, dAccel, DIR_CW);
	    AxmHelixCenterMove(COORDINATE, 500, 500, 0, 0, 100, dVelocity, dAccel, dAccel, DIR_CW);
	    AxmHelixCenterMove(COORDINATE, 500, 500, 0, 0, 100, dVelocity, dAccel, dAccel, DIR_CW);
	AxmContiEndNode(COORDINATE);
end;

procedure Tfrm3DGraph.btnHelicalPlayClick(Sender: TObject);
begin
	AxmContiStart(COORDINATE , 0, 0);
end;

procedure Tfrm3DGraph.btnSplineClick(Sender: TObject);
var
    dVelocity : Double;
    dAccel : Double;
	dPosX : array[0..4] of Double;
	dPosY : array[0..4]  of Double;
begin
    dVelocity := 2000; dAccel := 4000;

	AxmContiWriteClear(COORDINATE);
	AxmContiSetAxisMap(COORDINATE, 3, @m_aAxis);
	AxmContiSetAbsRelMode(COORDINATE, POS_ABS_MODE);

	dPosX[0] := 0;		dPosY[0] := 0;
	dPosX[1] := 450;	dPosY[1] := 100;
	dPosX[2] := 750;	dPosY[2] := 450;
	dPosX[3] := 1080;	dPosY[3] := 750;
	dPosX[4] := 1300;	dPosY[4] := 700;

	AxmContiBeginNode(COORDINATE);
	AxmSplineWrite(COORDINATE, 5, @dPosX, @dPosY, dVelocity, dAccel, dAccel, 1, 100);
	AxmContiEndNode(COORDINATE);
end;

procedure Tfrm3DGraph.btnSplinePlayClick(Sender: TObject);
begin
    AxmContiStart(COORDINATE, 0, 0);
end;

procedure Tfrm3DGraph.tmGraphTimer(Sender: TObject);
var
    dCmdX, dCmdY, dCmdZ : Double;

	  dVelX, dVelY, dVelZ : Double;
begin
    dVelX := 0; dVelY := 0; dVelZ := 0;
	AxmStatusReadVel(m_aAxis[0], @dVelX);
	AxmStatusReadVel(m_aAxis[1], @dVelY);
	AxmStatusReadVel(m_aAxis[2], @dVelZ);
	if((dVelX >= 0.0) or (dVelY >= 0.0) or (dVelZ >= 0.0))then
    begin
        dCmdX := 0; dCmdY := 0; dCmdZ := 0;
		AxmStatusGetCmdPos(m_aAxis[0], @dCmdX);
		AxmStatusGetCmdPos(m_aAxis[1], @dCmdY);
		AxmStatusGetCmdPos(m_aAxis[2], @dCmdZ);
        editXCMD.Text := FormatFloat('0.##0', dCmdX);
        editYCMD.Text := FormatFloat('0.##0', dCmdY);
        editZCMD.Text := FormatFloat('0.##0', dCmdZ);

        AxtGraph3D.AddPoint(dCmdX, dCmdY, dCmdZ) ;
    end;
end;

procedure Tfrm3DGraph.btnClearClick(Sender: TObject);
begin
  AxmStatusSetActPos(m_aAxis[0], 0.0);
	AxmStatusSetActPos(m_aAxis[1], 0.0);
	AxmStatusSetActPos(m_aAxis[2], 0.0);
	AxmStatusSetActPos(m_aAxis[3], 0.0);

	AxmStatusSetCmdPos(m_aAxis[0], 0.0);
	AxmStatusSetCmdPos(m_aAxis[1], 0.0);
	AxmStatusSetCmdPos(m_aAxis[2], 0.0);
	AxmStatusSetCmdPos(m_aAxis[3], 0.0);

	AxmContiWriteClear(COORDINATE);

    AxtGraph3D.Clear();
    editXCMD.Text := FormatFloat('0.##0', 0);
    editYCMD.Text := FormatFloat('0.##0', 0);
    editZCMD.Text := FormatFloat('0.##0', 0);
    EditRangeX.Text    := FormatFloat('0.##0', 2500);
    EditRangeY.Text    := FormatFloat('0.##0', 2500);
    EditRangeZ.Text    := FormatFloat('0.##0', 2500);
end;

procedure Tfrm3DGraph.btnCloseClick(Sender: TObject);
begin
    frm3DGraph.Close;
end;

procedure Tfrm3DGraph.FormCreate(Sender: TObject);
begin
    editXCMD.Text := FormatFloat('0.##0', 0);
    editYCMD.Text := FormatFloat('0.##0', 0);
    editZCMD.Text := FormatFloat('0.##0', 0);

    cboAxisReset.ItemIndex := 3;
    cboDimension.ItemIndex := 3;

   end;

procedure Tfrm3DGraph.chkBoxEnableClick(Sender: TObject);
begin
    if (chkBoxEnable.Checked = TRUE)then
    begin
	    AxtGraph3D.SetBoxEnable := TRUE;
        end
	else
    begin
		 AxtGraph3D.SetBoxEnable := FALSE;
    end;
end;

procedure Tfrm3DGraph.btnSetRangeClick(Sender: TObject);
var
  	dRangeX, dRangeY, dRangeZ : Double;

begin
   dRangeX	:= StrToFloat(EditRangeX.Text);
   dRangeY	:= StrToFloat(EditRangeY.Text);
   dRangeZ	:= StrToFloat(EditRangeZ.Text);

   AxtGraph3D.SetRangeX := dRangeX;
   AxtGraph3D.SetRangeY := dRangeY;
   AxtGraph3D.SetRangeZ := dRangeZ;

end;

procedure Tfrm3DGraph.cboAxisResetChange(Sender: TObject);
begin
       case (cboAxisReset.ItemIndex) of
    0:  begin             // X,Y Reset
        AxtGraph3D.SetRangeX := 2500;
        AxtGraph3D.SetRangeY := 2500;
        end;
    1:  begin             // Y,Z Reset
	      AxtGraph3D.SetRangeY := 2500;
        AxtGraph3D.SetRangeZ := 2500;
	    end;
  	2:  begin               // X,Z Reset
	      AxtGraph3D.SetRangeX := 2500;
        AxtGraph3D.SetRangeZ := 2500;
	    end;
  	3:  begin
       AxtGraph3D.SetRange3Axis(2500, 2500, 2500);
	    end;
      end;
end;

procedure Tfrm3DGraph.cboDimensionChange(Sender: TObject);
begin
         case (cboDimension.ItemIndex) of
    0:  begin             // X,Y Dimension
        AxtGraph3D.SetDimensionXY();
        end;
    1:  begin             // Y,Z Dimension
	      AxtGraph3D.SetDimensionYZ();
	    end;
  	2:  begin               // X,Z Dimension
	      AxtGraph3D.SetDimensionXZ()
	    end;
  	3:  begin                // X,Y,Z Dimension
        AxtGraph3D.SetDimensionXYZ();
	    end;
      end;
end;

end.




