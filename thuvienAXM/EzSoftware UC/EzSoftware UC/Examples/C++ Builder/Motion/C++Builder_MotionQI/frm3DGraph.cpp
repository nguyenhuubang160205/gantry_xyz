//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "AXL.h"
#include "AXM.h"
#include "frm3DGraph.h"
#include "stdio.h "
//---------------------------------------------------------------------------
#pragma package(smart_init)

#pragma link "AXTGRAPH3DLib_OCX"
#pragma resource "*.dfm"
Tfrm3DGraph *frm3DGraph;

#define COORDINATE		0
#define AXIS_N04(AXIS_NO, POS)	(((AXIS_NO / 4) * 4) + POS)
//---------------------------------------------------------------------------
__fastcall Tfrm3DGraph::Tfrm3DGraph(TComponent* Owner)
        : TForm(Owner)
{

}
//---------------------------------------------------------------------------
void Tfrm3DGraph::UpdateAxis(long lAxis)
{
	m_aAxis[0]	= AXIS_N04(lAxis, 0);
	m_aAxis[1]	= AXIS_N04(lAxis, 1);
	m_aAxis[2]	= AXIS_N04(lAxis, 2);
    m_aAxis[3]	= AXIS_N04(lAxis, 3);
}

void __fastcall Tfrm3DGraph::btnHelicalClick(TObject *Sender)
{
	double  dVelocity = 2000, dAccel = 4000;

	AxmContiSetAxisMap(COORDINATE, 4, m_aAxis);
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
}
//---------------------------------------------------------------------------

void __fastcall Tfrm3DGraph::btnHelicalPlayClick(TObject *Sender)
{
	AxmContiStart(COORDINATE , 0, 0);
}
//---------------------------------------------------------------------------

void __fastcall Tfrm3DGraph::btnSplineClick(TObject *Sender)
{
 	double  dVelocity = 2000, dAccel = 4000;
	double  dPosX[5];
	double  dPosY[5];

	AxmContiSetAxisMap(COORDINATE, 3, m_aAxis);
	AxmContiWriteClear(COORDINATE);
    AxmContiSetAbsRelMode(COORDINATE, POS_ABS_MODE);

	dPosX[0] = 0,		dPosY[0] = 0;
	dPosX[1] = 450,		dPosY[1] = 100;
	dPosX[2] = 750,		dPosY[2] = 450;
	dPosX[3] = 1080,	dPosY[3] = 750;
	dPosX[4] = 1300,	dPosY[4] = 700;

	AxmContiBeginNode(COORDINATE);
	AxmSplineWrite(COORDINATE, 5, dPosX, dPosY, dVelocity, dAccel, dAccel, 1, 100);
	AxmContiEndNode(COORDINATE);
}
//---------------------------------------------------------------------------
void __fastcall Tfrm3DGraph::btnSplinePlayClick(TObject *Sender)
{
	AxmContiStart(COORDINATE, 0, 0);
}
//---------------------------------------------------------------------------
void __fastcall Tfrm3DGraph::tmDisplay(TObject *Sender)
{
	double dCmdX = 0.0, dCmdY = 0.0, dCmdZ = 0.0;
	double dVelX = 0.0, dVelY = 0.0, dVelZ = 0.0;
    char   strData[200];

    AxmStatusReadVel(m_aAxis[0], &dVelX);
	AxmStatusReadVel(m_aAxis[1], &dVelY);
	AxmStatusReadVel(m_aAxis[2], &dVelZ);
    if(dVelX >= 0.0 || dVelY >= 0.0 || dVelZ >= 0.0){
	    AxmStatusGetCmdPos(m_aAxis[0], &dCmdX);
	    AxmStatusGetCmdPos(m_aAxis[1], &dCmdY);
	    AxmStatusGetCmdPos(m_aAxis[2], &dCmdZ);
        sprintf(strData, "%.3lf", dCmdX);
        editXCMD->Text = strData;
        sprintf(strData, "%.3lf", dCmdY);
        editYCMD->Text = strData;
        sprintf(strData, "%.3lf", dCmdZ);
        editZCMD->Text = strData;

        AxtGraph3D->AddPoint(dCmdX, dCmdY, dCmdZ);
    }
}
//---------------------------------------------------------------------------
void __fastcall Tfrm3DGraph::FormCreate(TObject *Sender)
{
    cboAxisReset->ItemIndex =3;
    cboDimension->ItemIndex =3;
    editXCMD->Text ="0.000";
    editYCMD->Text ="0.000";
    editZCMD->Text ="0.000";
    editRangeX->Text ="2500";
    editRangeY->Text ="2500";
    editRangeZ->Text ="2500";

    editXCMD->CharCase = 9;
    editYCMD->CharCase = 9;
    editZCMD->CharCase = 9;

    editRangeX->CharCase = 9;
    editRangeY->CharCase = 9;
    editRangeZ->CharCase = 9;
}

//---------------------------------------------------------------------------
void __fastcall Tfrm3DGraph::btnCloseClick(TObject *Sender)
{
    this->Hide();
}

//---------------------------------------------------------------------------
void __fastcall Tfrm3DGraph::cboAxisResetChange(TObject *Sender)
{
   switch(cboAxisReset->ItemIndex){

     case 0:                  // X,Y Axis Reset
         AxtGraph3D->SetRangeX = 2500;
         AxtGraph3D->SetRangeY = 2500;
     break;

     case 1:                 // Y,Z Axis Reset
         AxtGraph3D->SetRangeY = 2500;
         AxtGraph3D->SetRangeZ = 2500;
      break;

     case 2:                  // X,Z Axis Reset
         AxtGraph3D->SetRangeX = 2500;
         AxtGraph3D->SetRangeZ = 2500;
      break;

     case 3:                  // ALL (X,Y,Z)
         AxtGraph3D->SetRange3Axis(2500, 2500, 2500);
     break;
     }

}
//---------------------------------------------------------------------------

void __fastcall Tfrm3DGraph::cboDimensionChange(TObject *Sender)
{
    switch(cboDimension->ItemIndex){

     case 0:                  // X,Y
         AxtGraph3D->SetDimensionXY();
     break;

     case 1:                 // Y,Z
         AxtGraph3D->SetDimensionYZ();
     break;

     case 2:                  // X,Z 
       AxtGraph3D->SetDimensionXZ();
     break;

     case 3:                  // ALL (X,Y,Z)
        AxtGraph3D->SetDimensionXYZ();
     break;
     }
}
//---------------------------------------------------------------------------

void __fastcall Tfrm3DGraph::chkBoxEnableClick(TObject *Sender)
{
     if( chkBoxEnable->Checked)
         AxtGraph3D->SetBoxEnable = true;
     else
         AxtGraph3D->SetBoxEnable = false;
}

//---------------------------------------------------------------------------

void __fastcall Tfrm3DGraph::btnSetRangeClick(TObject *Sender)
{
    float flRangeX= StrToFloat(editRangeX->Text);
    float flRangeY= StrToFloat(editRangeY->Text);
    float flRangeZ= StrToFloat(editRangeZ->Text);

    AxtGraph3D->SetRangeX =flRangeX;
    AxtGraph3D->SetRangeY =flRangeY;
    AxtGraph3D->SetRangeZ =flRangeZ;
}
//---------------------------------------------------------------------------


//---------------------------------------------------------------------------

void __fastcall Tfrm3DGraph::btnClearClick(TObject *Sender)
{
   AxmStatusSetActPos(m_aAxis[0], 0.0);
   AxmStatusSetActPos(m_aAxis[1], 0.0);
   AxmStatusSetActPos(m_aAxis[2], 0.0);
   AxmStatusSetActPos(m_aAxis[3], 0.0);

   AxmStatusSetCmdPos(m_aAxis[0], 0.0);
   AxmStatusSetCmdPos(m_aAxis[1], 0.0);
   AxmStatusSetCmdPos(m_aAxis[2], 0.0);
   AxmStatusSetCmdPos(m_aAxis[3], 0.0);

   AxmContiWriteClear(COORDINATE);

   AxtGraph3D->Clear();

   editXCMD->Text ="0.000";
   editYCMD->Text ="0.000";
   editZCMD->Text ="0.000";
}
//---------------------------------------------------------------------------

