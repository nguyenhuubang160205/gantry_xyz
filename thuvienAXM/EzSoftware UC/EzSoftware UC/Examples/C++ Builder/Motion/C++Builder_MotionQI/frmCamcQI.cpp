//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "frmCamcQI.h"

#include "frmStatus.h"
#include "frm3DGraph.h"
#include "frmManualSet.h"

#include "stdio.h "
#include "math.h"


#pragma comment(lib, "AxL.lib")		// Library Link

#define AXIS_EVN(AXIS_NO)		(AXIS_NO - (AXIS_NO % 2))			// Searching for even number axis of axis which makes couple
#define AXIS_ODD(AXIS_NO)		(AXIS_NO + ((AXIS_NO + 1) % 2))		// Searching for odd number axis of axis which makes couple
#define AXIS_QUR(AXIS_NO)		(AXIS_NO % 4)
#define AXIS_N04(AXIS_NO, POS)	(((AXIS_NO / 4) * 4) + POS)			// Change to the axis' location of the one chip
#define AXIS_N01(AXIS_NO)		((AXIS_NO % 4) >> 2)				// Change axis of 0, 1 or 0, 2, 3 to 1
#define AXIS_N02(AXIS_NO)		((AXIS_NO % 4)  % 2)				// Change axis of 0, 2 or 0, 1, 3 to 1
#define COORD_NO  		        0

#define LED_RED(ON)             ((ON == 1) ? clRed : clMaroon)
#define LED_YELLOW(ON)          ((ON == 1) ? clYellow : clOlive)

#define COORD_NO			0
typedef struct _SIGNAL_SEARCH{
	long	nAxis;
	int		nDir;
	int		nSignal;
	int		nStopM;
	double	dVelocity;
	double	dAccel;
	LPVOID	pParent;
}SIGNAL_SEARCH, *PSIGNAL_SEARCH;

typedef struct _REPEAT_MOVE{
	long	nAxis;
	double	dPosition;
	double	dVelocity;
	double	dAccel;
	double	dDecel;
	LPVOID	pParent;
}REPEAT_MOVE, *PREPEAT_MOVE;

TfrmCamcQI *frmCamcQI;
int         g_nIntCnt;
void __stdcall KeMotionInterruptCallback(long lActiveNo, DWORD bwFlag)
{
    g_nIntCnt++;
	DWORD IntBank0;
	DWORD IntBank1;
    char  strData[200];

    AxmInterruptReadAxisFlag(lActiveNo, 0, &IntBank0);
    AxmInterruptReadAxisFlag(lActiveNo, 1, &IntBank1);
    sprintf(strData, "CallBack[%02d]Axis[%02d]Flag[0x%02X, 0x%02X]", g_nIntCnt, lActiveNo, IntBank0, IntBank1);
    frmCamcQI->lstLog->Items->Add(strData);
}

// Signal Search running thread part
UINT SearchThread(LPVOID pFuncData)
{
	long	bySignal;

	DWORD   dwEdge;
	DWORD   dwBusyStatus;
	DWORD   dwEndStatus;
	char	szSignalMethod[30];
	char    strLog[200];

	PSIGNAL_SEARCH	SI_M = (PSIGNAL_SEARCH)pFuncData;
	TfrmCamcQI	*pQI = (TfrmCamcQI *)SI_M->pParent;

	if(SI_M->nSignal < 6)
    {
		dwEdge		= 0;
		bySignal	= SI_M->nSignal;
	}
    else
    {
		dwEdge		= 1;
		bySignal	= SI_M->nSignal - 6;
	}

    if (bySignal > 1)
        bySignal += 2;

	// Re-setup of the maximum value in chart for displaying running speed of each axis on the chart.
	pQI->SetGraphRange(SI_M->nAxis, SI_M->dVelocity);

	// Setup running direction (-) direction
	if(SI_M->nDir == 1)	AxmMoveSignalSearch(SI_M->nAxis, -SI_M->dVelocity, SI_M->dAccel, bySignal, dwEdge, SI_M->nStopM);
	else				AxmMoveSignalSearch(SI_M->nAxis, SI_M->dVelocity, SI_M->dAccel, bySignal, dwEdge, SI_M->nStopM);

	// Standby until running is finished
	do{
		AxmStatusReadInMotion(SI_M->nAxis, &dwBusyStatus);
		Sleep(1);

		if(pQI->m_bTestActive[AXIS_QUR(SI_M->nAxis)] == FALSE)	AxmMoveSStop(SI_M->nAxis);
	}while(dwBusyStatus);
	// Check how running was stopped on certain condition by referring End Status Register. 

  	AxmStatusReadStop(SI_M->nAxis, &dwEndStatus);

	if(bySignal > 3)
    {
		if(dwEndStatus & 0xFFFF)	pQI->lstLog->Items->Add("Search failed.");
		else
        {
			sprintf(szSignalMethod, "%s", pQI->cboDetect->Items->Strings[pQI->cboDetect->ItemIndex]);
			sprintf(strLog, "Search %s complete axis %d", szSignalMethod, SI_M->nAxis);
			pQI->lstLog->Items->Add(strLog);
		}
	}

    pQI->lstLog->TopIndex = pQI->lstLog->Count - 1;
	pQI->m_bTestActive[AXIS_QUR(SI_M->nAxis)]	= false;

	CloseHandle(pQI->m_hTestThread[AXIS_QUR(SI_M->nAxis)]);
	pQI->m_hTestThread[AXIS_QUR(SI_M->nAxis)]	= NULL;
	delete SI_M;

	return 0;
}

// Repeated running thread part
UINT RepeatThread(LPVOID pFuncData)
{
	double	dCurPos;
	DWORD	dwMode;
	DWORD	dwBusyStatus;

	PREPEAT_MOVE	RM_M = (PREPEAT_MOVE)pFuncData;
	TfrmCamcQI	    *pQI = (TfrmCamcQI *)RM_M->pParent;

	// Re-setup of the maximum value in chart for displaying running speed of each axis on the chart.
	AxmStatusGetCmdPos(RM_M->nAxis, &dCurPos);
	AxmMotGetAbsRelMode(RM_M->nAxis, &dwMode);

	pQI->SetGraphRange(RM_M->nAxis, RM_M->dVelocity);
	while(pQI->m_bTestActive[AXIS_QUR(RM_M->nAxis)])
    {
		AxmMoveStartPos(RM_M->nAxis, RM_M->dPosition, RM_M->dVelocity, RM_M->dAccel, RM_M->dAccel);
		do{
			AxmStatusReadInMotion(RM_M->nAxis, &dwBusyStatus);
			Sleep(1);
		}while(dwBusyStatus);

		if(pQI->m_bTestActive[AXIS_QUR(RM_M->nAxis)] == FALSE)	break;

		if(dwMode == POS_ABS_MODE)
        {
			if(dCurPos == RM_M->dPosition)	break;
			AxmMoveStartPos(RM_M->nAxis, dCurPos, RM_M->dVelocity, RM_M->dAccel, RM_M->dAccel);
		}
        else
        {
			if(0 == RM_M->dPosition)		break;
			AxmMoveStartPos(RM_M->nAxis, -RM_M->dPosition, RM_M->dVelocity, RM_M->dAccel, RM_M->dAccel);
		}
		do{
			AxmStatusReadInMotion(RM_M->nAxis, &dwBusyStatus);
			Sleep(1);
		}while(dwBusyStatus);
	}

	pQI->m_bTestActive[AXIS_QUR(RM_M->nAxis)]	= false;
	CloseHandle(pQI->m_hTestThread[AXIS_QUR(RM_M->nAxis)]);
	pQI->m_hTestThread[AXIS_QUR(RM_M->nAxis)]	= NULL;
	delete RM_M;
    
	return 0;
}

BOOL ThreadProc(LPVOID lpData)
{
	TfrmCamcQI *pDlg	= (TfrmCamcQI *)lpData;
	pDlg->ThreadData();
	return TRUE;
}

#pragma package(smart_init)
#pragma resource "*.dfm"

__fastcall TfrmCamcQI::TfrmCamcQI(TComponent* Owner)
        : TForm(Owner)
{
	m_lRange		= 2500;
	for(int i = 0; i < MAX_AXIS_COUNT; i++)
    {
        m_bTestActive[i]	= FALSE;
        m_hTestThread[i]	= NULL;

        m_hHandle[i]		= NULL;
        m_hInterrupt[i] 	= NULL;
        m_bThread[i]		= FALSE;
	}
}

// Combined Library and Module initialize
void __fastcall TfrmCamcQI::FormCreate(TObject *Sender)
{
	//++
	InitLibrary();						// Combined Library and Module initialize
	InitControl();						// Graph and button control initialize

	UpdateAxisInfo();

    tmDisplay->Enabled = true;
    tmGraph->Enabled = true;
}
//---------------------------------------------------------------------------
void __fastcall TfrmCamcQI::FormDestroy(TObject *Sender)
{
    int i;

	m_bTestActive[0] = m_bTestActive[1] = false;
	m_bTestActive[2] = m_bTestActive[3] = false;

	for(i = 0; i < m_lAxisCounts; i++)
    {
		AxmMoveEStop(i);
		AxmSignalWriteOutputBit(i, 0, 0);

        if(m_hInterrupt[i] != NULL){
            m_bThread[i] = false;
            SetEvent(m_hInterrupt[i]);
        }
	}

    for(i = 0; i < 4; i++)
    {
		if(m_hTestThread[i] != NULL)
        {
			TerminateThread(m_hTestThread[i], 0);
			WaitForSingleObject(m_hTestThread[i],  WAIT_ABANDONED);
			CloseHandle(m_hTestThread[i]);
			m_hTestThread[i] = NULL;
		}
	}
    AxlClose();
}

// Combined Library and Module initialize
bool TfrmCamcQI::InitLibrary()
{
	// Initialize AXT board
	if ((AxlOpen(7) != AXT_RT_SUCCESS)){
		ShowMessage("AxlOpen Fail...");
        return FALSE;
    }
	return TRUE;
}

bool TfrmCamcQI::InitControl()
{
    cboDetect->ItemIndex = 4;
    cboDirection->ItemIndex = 1;
    cboStopM->ItemIndex = 1;

    cboPulseOutM->ItemIndex = 0;
    cboEncInputM->ItemIndex = 0;
    cboHomeSignal->ItemIndex = 2;
    cboHomeDir->ItemIndex = 0;

	XYPlot->LeftAxis->Minimum = -2500;
    XYPlot->LeftAxis->Maximum = 2500;
    XYPlot->BottomAxis->Minimum = -2500;
    XYPlot->BottomAxis->Maximum = 2500;

    edtCmdPosX->CharCase = 9;   edtActPosX->CharCase = 9;   edtCmdVelX->CharCase = 9;
    edtCmdPosY->CharCase = 9;   edtActPosY->CharCase = 9;   edtCmdVelY->CharCase = 9;
    edtCmdPosZ->CharCase = 9;   edtActPosZ->CharCase = 9;   edtCmdVelZ->CharCase = 9;
    edtCmdPosU->CharCase = 9;   edtActPosU->CharCase = 9;   edtCmdVelU->CharCase = 9;

    edtUnit->CharCase = 9;      edtPulse->CharCase = 9;     edtStartSpeed->CharCase = 9;
    edtContiNum->CharCase = 10;  edtTotalNum->CharCase = 10;  edtQFree->CharCase = 10;
    edtInMotion->CharCase = 10;

    edtXCen->CharCase = 9;      edtYCen->CharCase = 9;      edtAngle->CharCase = 9;
    edtPosition->CharCase = 9;  edtVelocity->CharCase = 9;  edtAccel->CharCase = 9;
    edtDecel->CharCase = 9;

    edtGearRatio->CharCase = 9;
    edtTrigStartPosition->CharCase = 9;
    edtTrigCycle->CharCase = 9;
    edtTrigPulseWidth->CharCase = 9;
    edtTrigEndPos->CharCase = 9;

    trkXYRange->Position = 5;
	trkXYRange2->Position = 2;

    short   i = 0;
    DWORD   dwModuleID = 0;

    AxmInfoGetAxisCount(&m_lAxisCounts);
    for( i = 0; i < m_lAxisCounts; i++)
    {
        AxmInfoGetAxis(i, NULL, NULL, &dwModuleID);
        switch(dwModuleID)
        {
        case AXT_SMC_4V04:
            cboAxisSet->Items->Add( IntToStr(i) + "-[PCIB-QI4A]");
            break;
        case AXT_SMC_2V04:
            cboAxisSet->Items->Add( IntToStr(i) + "-[PCIB-QI2A]");
            break;
        case AXT_SMC_R1V04A4:
            cboAxisSet->Items->Add( IntToStr(i) + "-[RTEX-A4N]");
            break;
        case AXT_SMC_R1V04:
            cboAxisSet->Items->Add( IntToStr(i) + "-(RTEX-PM)");
            break;
        case AXT_SMC_R1V04MLIISV:
            cboAxisSet->Items->Add( IntToStr(i) + "-[MLII-SGDV]");
            break;
        case AXT_SMC_R1V04MLIIPM:
            cboAxisSet->Items->Add( IntToStr(i) + "-(MLII-PM)");
            break;
        case AXT_SMC_R1V04MLIICL:
            cboAxisSet->Items->Add( IntToStr(i) + "-[MLII-CSDL]");
            break;
        case AXT_SMC_R1V04MLIICR:
            cboAxisSet->Items->Add( IntToStr(i) + "-[MLII-CSDH]");
            break;
        default:
            cboAxisSet->Items->Add( IntToStr(i) + "-[Unknown]");
            break;
         }
    }

    cboAxisSet->ItemIndex = 0;

    return TRUE;
}

// Setup distance rate and initial speed by pulse among those initial parameter.
// Change maximum speed to fit if setup distance rate by pulse.
void __fastcall TfrmCamcQI::cboAxisSetChange(TObject *Sender)
{
    m_lAxis = cboAxisSet->ItemIndex;
    UpdateAxisInfo();
}

void TfrmCamcQI::UpdateAxisInfo()
{
    char    strData[200];
 	DWORD	dwMEncInput, dwMPulseOut;
	DWORD	dwAbsRel, dwProfile;

	long	lPulse = 1;
	double	dUnit = 1.0;
	double	dMinVelocity = 1.0;
	double	dInitpos, dInitvel, dInitaccel, dInitdecel;

	DWORD   dwPositiveLevel, dwNegativeLevel, dwAlarmLevel, dwInposLevel;
	DWORD   dwHomeLevel, dwZphaseLevel;
	DWORD	dwStopMode, dwReadEmg;
	double	dGearRatio;
    DWORD   upSlHomeUse;
    char    strGantry[200];

    DWORD    dwModuleID;

    cboAxisSet->ItemIndex = m_lAxis;
    dInitpos = dInitvel = dInitaccel = dInitdecel = 0.0;
    dwPositiveLevel = dwNegativeLevel = dwAlarmLevel = dwInposLevel = 0;
    dwHomeLevel = dwZphaseLevel = dwStopMode = dwReadEmg = upSlHomeUse = 0;

    AxmInfoGetAxis(m_lAxis, NULL, NULL, &dwModuleID);
    switch(dwModuleID)
    {
    case AXT_SMC_4V04:
    case AXT_SMC_2V04:
    case AXT_SMC_2V03:
    case AXT_SMC_R1V04:    // PM
        m_bA4NAxis = false;

        cboEncInputM->Enabled = true;
        cboPulseOutM->Enabled = true;

        chkPElmLevel->AllowGrayed   = true;
        chkNElmLevel->AllowGrayed   = true;
        chkEmgLevel->AllowGrayed   = true;
        chkAlarmLevel->AllowGrayed   = true;
        chkInpLevel->AllowGrayed   = true;
        chkZPhaseLevel->Enabled = true;
        chkHomeLevel->Enabled = true;

        edtTrigStartPosition->Enabled = true;
        edtTrigCycle->Enabled = true;
        edtTrigPulseWidth->Enabled = true;
        edtTrigEndPos->Enabled = true;
        btnTrigAbs->Enabled = true;
        btnTrigOneShot->Enabled = true;
        btnTridPeriod->Enabled = true;
        btnTrigReset->Enabled = true;
        m_grLevel->Caption = "Level Setting";

        if(dwModuleID == AXT_SMC_R1V04){
            btnIntMessage->Enabled = false;
            btnIntEvent->Enabled = false;
            edtIntCallBack->Enabled = false;
            btnIntDisable->Enabled = false;
            btnReadCapture->Enabled = false;
            btnMPGOn->Enabled = false;
            btnMPGOff->Enabled = false;
            btnCRCOn->Enabled = false;
            btnCRCOff->Enabled = false;
        }else{
            btnIntMessage->Enabled = true;
            btnIntEvent->Enabled = true;
            edtIntCallBack->Enabled = true;
            btnIntDisable->Enabled = true;
            btnReadCapture->Enabled = true;
            btnMPGOn->Enabled = true;
            btnMPGOff->Enabled = true;
            btnCRCOn->Enabled = true;
            btnCRCOff->Enabled = true;
        }
        break;

    case AXT_SMC_R1V04A4:  // A4N
        m_bA4NAxis = true;

        cboEncInputM->Enabled = false;
        cboPulseOutM->Enabled = false;

        chkPElmLevel->AllowGrayed   = false;
        chkNElmLevel->AllowGrayed   = false;
        chkEmgLevel->AllowGrayed   = false;
        chkAlarmLevel->AllowGrayed   = false;
        chkInpLevel->AllowGrayed   = false;
        chkZPhaseLevel->Enabled = false;
        chkHomeLevel->Enabled = false;

        edtTrigStartPosition->Enabled = false;
        edtTrigCycle->Enabled = false;
        edtTrigPulseWidth->Enabled = false;
        edtTrigEndPos->Enabled = false;
        btnTrigAbs->Enabled = false;
        btnTrigOneShot->Enabled = false;
        btnTridPeriod->Enabled = false;
        btnTrigReset->Enabled = false;
        btnMPGOn->Enabled = false;
        btnMPGOff->Enabled = false;
        btnCRCOn->Enabled = false;
        btnCRCOff->Enabled = false;
        m_grLevel->Caption = "Level/Usage";

        btnIntMessage->Enabled = false;
        btnIntEvent->Enabled = false;
        edtIntCallBack->Enabled = false;
        btnIntDisable->Enabled = false;
        btnReadCapture->Enabled = false;
        break;
    }

	AxmMotGetParaLoad(m_lAxis, &dInitpos ,&dInitvel, &dInitaccel, &dInitdecel);

	// Display pulse output method after initialization, encoder input method, initial speed, distance rate by pulse on the screen.
	AxmMotGetMoveUnitPerPulse(m_lAxis, &dUnit , &lPulse);
	AxmMotGetMinVel(m_lAxis, &dMinVelocity);

    edtPulse->Text   = FloatToStr(lPulse);
    if (lPulse == 0)
        lPulse = 1;
    edtMoveUnit->Text      = FloatToStr(dUnit/lPulse);
    edtStartSpeed->Text     = FloatToStr(dMinVelocity);

    sprintf(strData, "%.5lf", dUnit);       edtUnit->Text  = strData;
    sprintf(strData, "%ld", lPulse);        edtPulse->Text = strData;
    sprintf(strData, "%lf", dUnit/lPulse);  edtMoveUnit->Text = strData;
    sprintf(strData, "%.3lf", dMinVelocity);edtStartSpeed->Text = strData;

    sprintf(strData, "%.3lf", dInitpos);    edtPosition->Text  = strData;
    sprintf(strData, "%.3lf", dInitvel);    edtVelocity->Text = strData;
    sprintf(strData, "%.3lf", dInitaccel);  edtAccel->Text = strData;
    sprintf(strData, "%.3lf", dInitdecel);  edtDecel->Text = strData;

	AxmMotGetProfileMode(m_lAxis, &dwProfile);
	AxmMotGetAbsRelMode(m_lAxis, &dwAbsRel);

    if (!m_bA4NAxis)
    {
        AxmMotGetEncInputMethod(m_lAxis, &dwMEncInput);
        AxmMotGetPulseOutMethod(m_lAxis, &dwMPulseOut);

        cboEncInputM->ItemIndex = dwMEncInput;
        cboPulseOutM->ItemIndex = dwMPulseOut;
    }

    if(dwAbsRel == 1)
    {
        chkRelative->Checked = true;
        chkAbsolute->Checked = false;
    }
    else
    {
        chkRelative->Checked = false;
        chkAbsolute->Checked = true;
    }

    if((dwProfile == 2) || (dwProfile == 3) || (dwProfile == 4))    chkSCurve->Checked = true;
    else                                                            chkSCurve->Checked = false;

	if((dwProfile == 1) || (dwProfile == 4))
    {
		edtDecel->Enabled = true;
		chkAsym->Checked = true;
	}
    else
    {
		edtDecel->Enabled = false;
		chkAsym->Checked = false;
	}

	AxmSignalGetLimit(m_lAxis, &dwStopMode, &dwPositiveLevel, &dwNegativeLevel);
	AxmSignalGetServoAlarm(m_lAxis, &dwAlarmLevel);
	AxmSignalGetInpos(m_lAxis, &dwInposLevel);

    AxmSignalGetStop(m_lAxis, &dwStopMode, &dwReadEmg);

    if (!m_bA4NAxis)
    {
    	AxmHomeGetSignalLevel(m_lAxis, &dwHomeLevel);
        AxmSignalGetZphaseLevel(m_lAxis, &dwZphaseLevel);

        chkPElmLevel->Checked   = dwPositiveLevel;
        chkNElmLevel->Checked   = dwNegativeLevel;
        chkEmgLevel->Checked    = dwReadEmg;
        chkAlarmLevel->Checked  = dwAlarmLevel;
        chkInpLevel->Checked    = dwInposLevel;
        chkHomeLevel->Checked   = dwHomeLevel;
        chkZPhaseLevel->Checked = dwZphaseLevel;
    }
    else
    {
        if (dwPositiveLevel == UNUSED)    chkPElmLevel->Checked   = 0;
        else                              chkPElmLevel->Checked   = 1;

        if (dwNegativeLevel == UNUSED)    chkNElmLevel->Checked   = 0;
        else                              chkNElmLevel->Checked   = 1;

        if (dwReadEmg == UNUSED)          chkEmgLevel->Checked   = 0;
        else                              chkEmgLevel->Checked   = 1;

        if (dwAlarmLevel == UNUSED)       chkAlarmLevel->Checked   = 0;
        else                              chkAlarmLevel->Checked   = 1;

        if (dwInposLevel == UNUSED)       chkInpLevel->Checked   = 0;
        else                              chkInpLevel->Checked   = 1;
    }

	AxmLinkGetMode(AXIS_EVN(m_lAxis), NULL, &dGearRatio); 
	if(dGearRatio > 0)
    {
		chkGearOnOff->Checked = true;
	}else{
		chkGearOnOff->Checked = false;
	}

    SetTitleBar(m_lAxis);

    AxmGantryGetEnable(m_lAxis, &upSlHomeUse, NULL, NULL, NULL);
    if(upSlHomeUse == 0)        chkGantrySlave->Checked = false;
    else                        chkGantrySlave->Checked = true;

    if(chkGantrySlave->State == 0)
  	sprintf(strGantry, "Do not Search");
    else if(chkGantrySlave->State == 1)
  	sprintf(strGantry, "Do origin revision after Search");
    else if(chkGantrySlave->State == 2)
  	sprintf(strGantry, "Do not origin revision after Search");

    chkGantrySlave->Caption = strGantry;
}

//---------------------------------------------------------------------------
// Setup active level value of (+) End Limit.
void __fastcall TfrmCamcQI::chkPElmLevelClick(TObject *Sender)
{
    DWORD dwNegativeLevel, upStopMode, dwLevel;

    AxmSignalGetLimit(m_lAxis, &upStopMode, 0, &dwNegativeLevel);

    if (!m_bA4NAxis)
    {
        AxmSignalSetLimit(m_lAxis, upStopMode, chkPElmLevel->State, dwNegativeLevel);
    }
    else
    {
        if (chkPElmLevel->Checked == 0)   dwLevel   = 2;
        else                              dwLevel   = 1;
        AxmSignalSetLimit(m_lAxis, upStopMode, dwLevel, dwNegativeLevel);
    }
}
//---------------------------------------------------------------------------

// Setup active level value of (-) End Limit.
void __fastcall TfrmCamcQI::chkNElmLevelClick(TObject *Sender)
{
	DWORD   dwPositiveLevel, upStopMode, dwLevel;

	AxmSignalGetLimit(m_lAxis, &upStopMode, &dwPositiveLevel, NULL);

    if (!m_bA4NAxis)
    {
        AxmSignalSetLimit(m_lAxis, upStopMode, dwPositiveLevel, chkNElmLevel->State);
    }
    else
    {
        if (chkNElmLevel->Checked == 0)   dwLevel   = 2;
        else                              dwLevel   = 1;
        AxmSignalSetLimit(m_lAxis, upStopMode, dwPositiveLevel, dwLevel);
    }
}
//---------------------------------------------------------------------------

// Setup active level value of alarm signal.  High if checked, Low if not checked.
void __fastcall TfrmCamcQI::chkAlarmLevelClick(TObject *Sender)
{
    DWORD   dwLevel;

    if (!m_bA4NAxis)
        AxmSignalSetServoAlarm(m_lAxis, chkAlarmLevel->State);
    else
    {
        if (chkAlarmLevel->Checked == 0)  dwLevel   = 2;
        else                              dwLevel   = 1;
        AxmSignalSetServoAlarm(m_lAxis, dwLevel);
    }
}
//---------------------------------------------------------------------------

// Setup active level value of in-position signal.  High if checked, Low if not checked.
void __fastcall TfrmCamcQI::chkInpLevelClick(TObject *Sender)
{
    DWORD   dwLevel;

    if (!m_bA4NAxis)
        AxmSignalSetInpos(m_lAxis, chkInpLevel->State);
    else
    {
        if (chkInpLevel->Checked == 0)  dwLevel   = 2;
        else                            dwLevel   = 1;
        AxmSignalSetInpos(m_lAxis, dwLevel);
    }
}
//---------------------------------------------------------------------------

void __fastcall TfrmCamcQI::chkZPhaseLevelClick(TObject *Sender)
{
    if (!m_bA4NAxis)
        AxmSignalSetZphaseLevel(m_lAxis, chkZPhaseLevel->State);
}
//---------------------------------------------------------------------------


void __fastcall TfrmCamcQI::btnMPGOnClick(TObject *Sender)
{
    double dVelocity, dAccel;

	dVelocity	= StrToFloat(edtVelocity->Text);
	dAccel		= StrToFloat(edtAccel->Text);

	long   lInputMethod = 3;
	long   lDriveMode   = 4;

	double dMPGPosition		= 1000;
	double dMPGdenominator	= 4096;		// MPG(Manual Pulse Generation device Input) divide value when running (Calculated to add 1 to input value)
	double dMPGnumerator	= 1;		// MPG(Manual Pulse Generation device Input) multiply value when running (Calculated to add 1 to input value)

    // dwNumerator   : Possible to setup maximum (0 to 63)
	// dwDenominator : Possible to setup maximum (0 to 4095)
	AxmMPGSetEnable(m_lAxis, lInputMethod, lDriveMode, dMPGPosition, dVelocity, dAccel);
	AxmMPGSetRatio(m_lAxis, dMPGnumerator, dMPGdenominator);
}
//---------------------------------------------------------------------------
void __fastcall TfrmCamcQI::btnMPGOffClick(TObject *Sender)
{
    AxmMPGReset(m_lAxis);
}
//---------------------------------------------------------------------------
void __fastcall TfrmCamcQI::cboPulseOutMChange(TObject *Sender)
{
    AxmMotSetPulseOutMethod(m_lAxis, cboPulseOutM->ItemIndex);
}
//---------------------------------------------------------------------------
// Setup distance rate and initial speed by pulse among those initial parameter.
// Change maximum speed to fit if setup distance rate by pulse.
void __fastcall TfrmCamcQI::btnSettingClick(TObject *Sender)
{
	long	lPulse;
	char    strData[200];
	double	dMoveUnit, dStartStop;
	double	dUnit, dMinVelocity;
	
	lPulse		= (LONG)StrToInt(edtPulse->Text);
	dMoveUnit	= StrToFloat(edtUnit->Text);
	dStartStop	= StrToFloat(edtStartSpeed->Text);

	AxmMotSetMoveUnitPerPulse(m_lAxis, dMoveUnit, lPulse);
	AxmMotSetMinVel(m_lAxis, dStartStop);
	AxmMotGetMoveUnitPerPulse(m_lAxis, &dUnit , &lPulse);
	AxmMotGetMinVel(m_lAxis, &dMinVelocity);

	sprintf(strData, "%lf", dUnit/lPulse);	    edtMoveUnit->Text = strData;
	sprintf(strData, "%.3lf", dUnit);			edtUnit->Text = strData;
	sprintf(strData, "%ld", lPulse);			edtPulse->Text = strData;
	sprintf(strData, "%.0lf", dMinVelocity);	edtStartSpeed->Text = strData;
}
//---------------------------------------------------------------------------
void __fastcall TfrmCamcQI::cboEncInputMChange(TObject *Sender)
{
    AxmMotSetEncInputMethod(m_lAxis, cboEncInputM->ItemIndex);
}
//---------------------------------------------------------------------------

void __fastcall TfrmCamcQI::btnCountClrClick(TObject *Sender)
{
	AxmStatusSetActPos(AXIS_N04(m_lAxis, 0), 0.0);
	AxmStatusSetActPos(AXIS_N04(m_lAxis, 1), 0.0);
	AxmStatusSetCmdPos(AXIS_N04(m_lAxis, 2), 0.0);
	AxmStatusSetCmdPos(AXIS_N04(m_lAxis, 3), 0.0);

	AxmStatusSetCmdPos(AXIS_N04(m_lAxis, 0), 0.0);
	AxmStatusSetCmdPos(AXIS_N04(m_lAxis, 1), 0.0);
	AxmStatusSetActPos(AXIS_N04(m_lAxis, 2), 0.0);
	AxmStatusSetActPos(AXIS_N04(m_lAxis, 3), 0.0);
     
    Series5->Clear();
    lstLog->Clear();
}
//---------------------------------------------------------------------------

void __fastcall TfrmCamcQI::btnMoveClick(TObject *Sender)
{
    double	dPosition	= StrToFloat(edtPosition->Text);
	double	dVelocity	= StrToFloat(edtVelocity->Text);
	double	dAccel		= StrToFloat(edtAccel->Text);
	double	dDecel		= StrToFloat(edtDecel->Text);

	SetGraphRange(m_lAxis, dVelocity);
	if (chkXYSyn->Checked == TRUE)
    {
		long	lAxis[2];
		double	dMPos[2], dMVel[2], dMAcc[2], dMDec[2];

		lAxis[0] = AXIS_ODD(m_lAxis);
		lAxis[1] = AXIS_EVN(m_lAxis);

		dMPos[0] = dPosition;   dMPos[1] = dPosition;
		dMVel[0] = dVelocity;   dMVel[1] = dVelocity;
		dMAcc[0] = dAccel;      dMAcc[1] = dAccel;
		dMDec[0] = dDecel;      dMDec[1] = dDecel;

		AxmMoveStartMultiPos(2, lAxis, dMPos, dMVel, dMAcc, dMDec);
	}else{
	    AxmMoveStartPos(m_lAxis, dPosition, dVelocity, dAccel, dDecel);
	}
	AxmMotSetParaLoad(m_lAxis, dPosition, dVelocity, dAccel, dDecel);
}
//---------------------------------------------------------------------------
void __fastcall TfrmCamcQI::btnStopClick(TObject *Sender)
{
	if(m_bTestActive[AXIS_QUR(m_lAxis)])	m_bTestActive[AXIS_QUR(m_lAxis)] = FALSE;
	else									AxmMoveSStop(m_lAxis);

    lstLog->Items->Add("Stop move");
    lstLog->TopIndex = lstLog->Count - 1;
}
//---------------------------------------------------------------------------
void __fastcall TfrmCamcQI::chkAsymClick(TObject *Sender)
{
    DWORD dwProfile;
	//ProfileMode: '0' - symmetry Trapezode
	//             '1' - asymmetry Trapezode
	//             '2' - symmetry Quasi-S Curve
	//             '3' - symmetry S Curve
	//             '4' - asymmetry S Curve
	AxmMotGetProfileMode(m_lAxis, &dwProfile);
	if(chkAsym->Checked == TRUE){
		edtDecel->Enabled = TRUE;
		if((dwProfile = 0) || (dwProfile = 3))	dwProfile = dwProfile + 1;
		else									dwProfile  = 4;
	}else{
		edtDecel->Enabled = FALSE;
		if((dwProfile = 1) || (dwProfile = 4))	dwProfile = dwProfile - 1;
		else									dwProfile  = 3;
	}
	AxmMotSetProfileMode(m_lAxis, dwProfile);
}
//---------------------------------------------------------------------------

void __fastcall TfrmCamcQI::chkSCurveClick(TObject *Sender)
{
    DWORD dwProfile;
	//ProfileMode: '0' - symmetry Trapezode
	//             '1' - asymmetry Trapezode
	//             '2' - symmetry Quasi-S Curve
	//             '3' - symmetry S Curve
	//             '4' - asymmetry S Curve
	AxmMotGetProfileMode(m_lAxis, &dwProfile);
	if (chkSCurve->Checked == TRUE){
		if((dwProfile = 0) || (dwProfile = 1))	dwProfile += 3;
		else					   				dwProfile  = 3;
	}else{
		if((dwProfile = 3) || (dwProfile = 4))	dwProfile -= 3;
		else									dwProfile  = 0;
	}
	AxmMotSetProfileMode(m_lAxis, dwProfile);
}
//---------------------------------------------------------------------------
void __fastcall TfrmCamcQI::btnSearchClick(TObject *Sender)
{
	unsigned long	ThreadID;
	if(m_hTestThread[AXIS_QUR(m_lAxis)] == NULL){
		PSIGNAL_SEARCH SI_M = new SIGNAL_SEARCH;

		SI_M->nAxis		= m_lAxis;
		SI_M->nDir		= cboDirection->ItemIndex;
		SI_M->nSignal	= cboDetect->ItemIndex;
		SI_M->nStopM	= cboStopM->ItemIndex;

		SI_M->dVelocity	= StrToFloat(edtVelocity->Text);
		SI_M->dAccel	= StrToFloat(edtAccel->Text);	
		SI_M->pParent	= (LPVOID)frmCamcQI;

		m_bTestActive[AXIS_QUR(m_lAxis)] = true;
		m_hTestThread[AXIS_QUR(m_lAxis)] = CreateThread(NULL, 0, (LPTHREAD_START_ROUTINE)SearchThread, SI_M, 0, &ThreadID);
	}else{
        lstLog->Items->Add("Now moving");
        lstLog->TopIndex = lstLog->Count - 1;
	}
}
//---------------------------------------------------------------------------
void __fastcall TfrmCamcQI::btnHomeAllClick(TObject *Sender)
{
	long    lHmDir		= -1;				// Setup a direction of Home searching.
	long    lHmsig		= HomeSensor;		// Setup Home sensor.
	DWORD   dwZphas		= 0;				// Setup whether Z phase is searching or not.
	double  dHClrTim	= 1000.0;			// Delay time of Position Clear after searching Home sensor.
	double  dHOffset	= 0.0;				// Setup Offset movement value after searching Home sensor.
    DWORD   dwResult    = 0;

	SetGraphRange(AXIS_N04(m_lAxis, 0), 100);
	SetGraphRange(AXIS_N04(m_lAxis, 2), 100);

	// Speed of starting point searching by each step must be changed to fit to the device.
	dwResult = AxmHomeSetVel(AXIS_N04(m_lAxis, 0), 100, 50, 5, 1, 400, 100);
    if (dwResult == AXT_RT_SUCCESS)
    {
    	AxmHomeSetMethod(AXIS_N04(m_lAxis, 0), lHmDir, lHmsig, dwZphas, dHClrTim, dHOffset);
       	AxmHomeSetStart(AXIS_N04(m_lAxis, 0));
        tmHome1->Enabled = true;
    }

    dwResult = AxmHomeSetVel(AXIS_N04(m_lAxis, 1), 100, 50, 5, 1, 400, 100);
    if (dwResult == AXT_RT_SUCCESS)
    {
    	AxmHomeSetMethod(AXIS_N04(m_lAxis, 1), lHmDir, lHmsig, dwZphas, dHClrTim, dHOffset);
       	AxmHomeSetStart(AXIS_N04(m_lAxis, 1));
        tmHome2->Enabled = true;
    }

    dwResult = AxmHomeSetVel(AXIS_N04(m_lAxis, 2), 100, 50, 5, 1, 400, 100);
    if (dwResult == AXT_RT_SUCCESS)
    {
    	AxmHomeSetMethod(AXIS_N04(m_lAxis, 2), lHmDir, lHmsig, dwZphas, dHClrTim, dHOffset);
       	AxmHomeSetStart(AXIS_N04(m_lAxis, 2));
        tmHome3->Enabled = true;
    }

    dwResult = AxmHomeSetVel(AXIS_N04(m_lAxis, 3), 100, 50, 5, 1, 400, 100);
    if (dwResult == AXT_RT_SUCCESS)
    {
    	AxmHomeSetMethod(AXIS_N04(m_lAxis, 3), lHmDir, lHmsig, dwZphas, dHClrTim, dHOffset);
       	AxmHomeSetStart(AXIS_N04(m_lAxis, 3));
        tmHome4->Enabled = true;
    }
}
//---------------------------------------------------------------------------

void __fastcall TfrmCamcQI::btnHomeSingleClick(TObject *Sender)
{
 	DWORD   dwZphas		= 0;				// Setup whether Z phase is searching or not.
	double  dHClrTim	= 1000.0;			// Delay time of Position Clear after searching Home sensor.
	double  dHOffset	= 0.0;				// Setup Offset movement value after searching Home sensor.

	double	dVelFirst	= StrToFloat(edtHomeVelFirst->Text);
	double	dVelSecond	= StrToFloat(edtHomeVelSecond->Text);
	double	dVelThird	= StrToFloat(edtHomeVelThird->Text);
	double	dVelLast	= StrToFloat(edtHomeVelLast->Text);

	long    lHmsig		= cboHomeSignal->ItemIndex;		// Setup Home sensor.
	long    lHmDir		= cboHomeDir->ItemIndex;		// Setup a direction of Home searching.
    TTimer  *tmHomer[4];

    tmHomer[0] = tmHome1;    tmHomer[1] = tmHome2;
    tmHomer[2] = tmHome3;    tmHomer[3] = tmHome4;

    if (lHmsig > 1)
        lHmsig += 2;

	SetGraphRange(m_lAxis, dVelFirst);

	if(chkGantrySlave->Checked){
		AxmHomeSetVel(AXIS_EVN(m_lAxis), dVelFirst, dVelSecond, dVelThird, dVelLast, dVelFirst * 4, dVelSecond * 10);
		AxmHomeSetVel(AXIS_ODD(m_lAxis), dVelFirst, dVelSecond, dVelThird, dVelLast, dVelFirst * 4, dVelSecond * 10);

		AxmHomeSetMethod(AXIS_EVN(m_lAxis), lHmDir, lHmsig, dwZphas, dHClrTim, dHOffset);
		AxmHomeSetMethod(AXIS_ODD(m_lAxis), lHmDir, lHmsig, dwZphas, dHClrTim, dHOffset);

		AxmHomeSetStart(AXIS_EVN(m_lAxis));

        tmHomer[AXIS_EVN(m_lAxis)]->Enabled = true;
	}else{
		AxmHomeSetVel(m_lAxis, dVelFirst, dVelSecond, dVelThird, dVelLast, dVelFirst * 4, dVelSecond * 10);

		AxmHomeSetMethod(m_lAxis, lHmDir, lHmsig, dwZphas, dHClrTim, dHOffset);
		AxmHomeSetStart(m_lAxis);
        tmHomer[AXIS_QUR(m_lAxis)]->Enabled = true;
	}
}
//---------------------------------------------------------------------------
void TfrmCamcQI::SetTitleBar(long lAxis)
{
	char    strCaption[200];
	DWORD	dwModuleID;
	long	lAxtBoardNo = 0, lModulePos = 0;

	AxmInfoGetAxis(lAxis, &lAxtBoardNo, &lModulePos, &dwModuleID);
    sprintf(strCaption, "Ajinextek Motion Board No[%02d], Module Pos[%02d], Module ID[0x%02X]", lAxtBoardNo, lModulePos, dwModuleID);
    frmCamcQI->Caption = strCaption;
}

bool TfrmCamcQI::SetGraphRange(long lAxis, double dVelocity)
{
	if(dVelocity <= 0)	return FALSE;

	// Re-setup of the maximum value in chart for displaying running speed of each axis on the chart.
	if(AXIS_QUR(lAxis) < 2)	GraphX->LeftAxis->Maximum = dVelocity + (dVelocity * 0.2);
	else					GraphY->LeftAxis->Maximum = dVelocity + (dVelocity * 0.2);

	return true;
}

void __fastcall TfrmCamcQI::btnContiSplineClick(TObject *Sender)
{
	long    lAxis[2];
	double  dPosX[5];
	double  dPosY[5];
	double	dVelocity, dAccel, dDecel;

	dVelocity	= StrToFloat(edtVelocity->Text);
	dAccel		= StrToFloat(edtAccel->Text);
	dDecel		= StrToFloat(edtDecel->Text);

	lAxis[0]	= AXIS_N04(m_lAxis, 0); 
	lAxis[1]	= AXIS_N04(m_lAxis, 1); 

	SetGraphRange(lAxis[0], dVelocity);	

	AxmContiSetAxisMap(COORD_NO, 2, lAxis);
	AxmContiWriteClear(COORD_NO);
    AxmContiSetAbsRelMode(COORD_NO, POS_ABS_MODE);

	dPosX[0] = 0   , dPosY[0] = 0;
	dPosX[1] = 450,  dPosY[1] = 100;
	dPosX[2] = 750,  dPosY[2] = 450;
	dPosX[3] = 1080, dPosY[3] = 750;
	dPosX[4] = 1300, dPosY[4] = 700;
	AxmContiBeginNode(COORD_NO);

	AxmSplineWrite(COORD_NO, 5, dPosX, dPosY, dVelocity, dAccel, dDecel, 0, 100);
	AxmContiEndNode(COORD_NO);
}
//---------------------------------------------------------------------------
void __fastcall TfrmCamcQI::btnContiTestClick(TObject *Sender)
{
	double dVelocity, dAccel;

	long    lAxis[2];
	double  dPos[2];
	long    lPosSize = 2;
	double  dCenPos[2];
	double  dEndPos[2];

	lAxis[0]    = 0;
	lAxis[1]    = 1;
 	dVelocity	= StrToFloat(edtVelocity->Text);
	dAccel		= StrToFloat(edtAccel->Text);
	SetGraphRange(lAxis[0], dVelocity);

	AxmContiWriteClear(COORD_NO);
	AxmContiSetAxisMap(COORD_NO, lPosSize, lAxis);
	AxmContiSetAbsRelMode(COORD_NO, POS_REL_MODE);

	AxmContiBeginNode(COORD_NO); dPos[0] = -15000 , dPos[1] = 0;

	AxmLineMove(COORD_NO, dPos, dVelocity, dAccel, dAccel);										//1
	dCenPos[0] = 0 , dCenPos[1] = 5000; dEndPos[0] = -5000; dEndPos[1] = 5000;
	AxmCircleCenterMove(COORD_NO, lAxis, dCenPos, dEndPos, dVelocity, dAccel, dAccel, DIR_CW);  //2	
	dPos[0] = 0 , dPos[1] = 30000;
	AxmLineMove(COORD_NO, dPos, dVelocity, dAccel, dAccel);										//3
	dCenPos[0] = 5000 , dCenPos[1] = 0; dEndPos[0] = 5000; dEndPos[1] = 5000;
	AxmCircleCenterMove(COORD_NO, lAxis, dCenPos, dEndPos, dVelocity, dAccel, dAccel, DIR_CW);  //4
	dPos[0] = 30000 , dPos[1] = 0;
	AxmLineMove(COORD_NO, dPos, dVelocity, dAccel, dAccel);										//5
	dCenPos[0] = 0 , dCenPos[1] = -5000; dEndPos[0] = 5000; dEndPos[1] = -5000;
	AxmCircleCenterMove(COORD_NO, lAxis, dCenPos, dEndPos,  dVelocity, dAccel, dAccel, DIR_CW);	//6
	dPos[0] = 0 , dPos[1] = -30000;
	AxmLineMove(COORD_NO, dPos, dVelocity, dAccel, dAccel);										//7
	dCenPos[0] = -5000 , dCenPos[1] = 0; dEndPos[0] = -5000; dEndPos[1] = -5000;
	AxmCircleCenterMove(COORD_NO, lAxis, dCenPos, dEndPos, dVelocity, dAccel, dAccel, DIR_CW);	//8
	dPos[0] = -15000 , dPos[1] = 0;

	AxmLineMove(COORD_NO, dPos, dVelocity, dAccel, dAccel);										//9
	dPos[0] = -10000 , dPos[1] = 0;

	AxmLineMove(COORD_NO, dPos, dVelocity, dAccel, dAccel);										//10
	dCenPos[0] = 0 , dCenPos[1] = 10000; dEndPos[0] = -10000; dEndPos[1] = 10000;
	AxmCircleCenterMove(COORD_NO, lAxis, dCenPos, dEndPos, dVelocity, dAccel, dAccel, DIR_CW);	//11
	dPos[0] = 0 , dPos[1] = 20000;
	AxmLineMove(COORD_NO, dPos, dVelocity, dAccel, dAccel);										//12
	dCenPos[0] = 10000 , dCenPos[1] = 0; dEndPos[0] = 10000; dEndPos[1] = 10000;
	AxmCircleCenterMove(COORD_NO, lAxis, dCenPos, dEndPos, dVelocity, dAccel, dAccel, DIR_CW);	//13
	dPos[0] = 20000 , dPos[1] = 0;
	AxmLineMove(COORD_NO, dPos, dVelocity, dAccel, dAccel);										//14
	dCenPos[0] = 0 , dCenPos[1] = -10000; dEndPos[0] = 10000; dEndPos[1] = -10000;
	AxmCircleCenterMove(COORD_NO, lAxis, dCenPos, dEndPos, dVelocity, dAccel, dAccel, DIR_CW);	//15
	dPos[0] = 0 , dPos[1] = -20000;
	AxmLineMove(COORD_NO, dPos, dVelocity, dAccel, dAccel);										//16
	dCenPos[0] = -10000 , dCenPos[1] = 0; dEndPos[0] = -10000; dEndPos[1] = -10000;
	AxmCircleCenterMove(COORD_NO, lAxis, dCenPos, dEndPos, dVelocity, dAccel, dAccel, DIR_CW);	//17
	dPos[0] = -10000 , dPos[1] = 0;
	AxmLineMove(COORD_NO, dPos, dVelocity, dAccel, dAccel);										//18
	dCenPos[0] = 0 , dCenPos[1] = 20000; dEndPos[0] = 0; dEndPos[1] = 0;
	AxmCircleCenterMove(COORD_NO, lAxis, dCenPos, dEndPos, dVelocity, dAccel, dAccel, DIR_CW);  //19
	dCenPos[0] = 0 , dCenPos[1] = 10000; dEndPos[0] = -7071; dEndPos[1] = 2929;
	AxmCircleCenterMove(COORD_NO, lAxis,  dCenPos, dEndPos, dVelocity, dAccel, dAccel, DIR_CW); //20

	dPos[0] = -10000 , dPos[1] = 10000;
	AxmLineMove(COORD_NO, dPos, dVelocity, dAccel, dAccel);										//21
	dCenPos[0] = 7071 , dCenPos[1] = 7071; dEndPos[0] =0; dEndPos[1] = 14142;
	AxmCircleCenterMove(COORD_NO, lAxis,  dCenPos, dEndPos, dVelocity, dAccel, dAccel, DIR_CW); //22
	dPos[0] = 10000 , dPos[1] = 10000;
	AxmLineMove(COORD_NO, dPos, dVelocity, dAccel, dAccel);										//23
	dCenPos[0] = 7071 , dCenPos[1] = -7071; dEndPos[0] = 14142; dEndPos[1] = 0;
	AxmCircleCenterMove(COORD_NO, lAxis,  dCenPos, dEndPos, dVelocity, dAccel, dAccel, DIR_CW); //24
	dPos[0] = 10000 , dPos[1] = -10000;
	AxmLineMove(COORD_NO, dPos, dVelocity, dAccel, dAccel);										//25
	dCenPos[0] = -7071 , dCenPos[1] = -7071; dEndPos[0] = 0; dEndPos[1] = -14142;
	AxmCircleCenterMove(COORD_NO, lAxis,  dCenPos, dEndPos, dVelocity, dAccel, dAccel, DIR_CW); //26
	dPos[0] = -10000 , dPos[1] = -10000;
	AxmLineMove(COORD_NO, dPos, dVelocity, dAccel, dAccel);										//27
	dCenPos[0] = -7071 , dCenPos[1] = 7071; dEndPos[0] = -7071; dEndPos[1] = -2929;	

	AxmCircleCenterMove(COORD_NO, lAxis,  dCenPos, dEndPos, dVelocity, dAccel, dAccel, DIR_CW);	//28
	dCenPos[0] = 0 , dCenPos[1] = 10000; dEndPos[0] = 0; dEndPos[1] = 20000;
	AxmCircleCenterMove(COORD_NO, lAxis,  dCenPos, dEndPos, dVelocity, dAccel, dAccel, DIR_CW); //29
	dCenPos[0] = 0 , dCenPos[1] = 10000; dEndPos[0] = 0; dEndPos[1] = 20000;	
	AxmCircleCenterMove(COORD_NO, lAxis,  dCenPos, dEndPos, dVelocity, dAccel, dAccel, DIR_CCW);//30
	dCenPos[0] = 0 , dCenPos[1] = -5000; dEndPos[0] = 0; dEndPos[1] = -10000;
	AxmCircleCenterMove(COORD_NO, lAxis,  dCenPos, dEndPos, dVelocity, dAccel, dAccel, DIR_CCW);//31

	dCenPos[0] = 0 , dCenPos[1] = -5000; dEndPos[0] = 0; dEndPos[1] = -10000;
	AxmCircleCenterMove(COORD_NO, lAxis,  dCenPos, dEndPos, dVelocity, dAccel, dAccel, DIR_CW); //32
	dCenPos[0] = 0 , dCenPos[1] = -5000; dEndPos[0] = 0; dEndPos[1] = -10000;
	AxmCircleCenterMove(COORD_NO, lAxis,  dCenPos, dEndPos, dVelocity, dAccel, dAccel, DIR_CCW);//33
	dCenPos[0] = 0 , dCenPos[1] = -5000; dEndPos[0] = 0; dEndPos[1] = -10000;
	AxmCircleCenterMove(COORD_NO, lAxis,  dCenPos, dEndPos, dVelocity, dAccel, dAccel, DIR_CW); //34

	AxmContiEndNode(COORD_NO);
}
//---------------------------------------------------------------------------

void __fastcall TfrmCamcQI::btnContiClearClick(TObject *Sender)
{
    AxmContiWriteClear(COORD_NO);
}
//---------------------------------------------------------------------------

void __fastcall TfrmCamcQI::chkGearOnOffClick(TObject *Sender)
{
	double dRatio = StrToFloat(edtGearRatio->Text);

	// It is a function to setup gear rate of Master axis and Slave axis on Electric Gear mode.
	if(chkGearOnOff->Checked)	AxmLinkSetMode(AXIS_EVN(m_lAxis), AXIS_ODD(m_lAxis), dRatio);
	else						AxmLinkResetMode(AXIS_EVN(m_lAxis));
}
//---------------------------------------------------------------------------
void __fastcall TfrmCamcQI::btnTrigOneShotClick(TObject *Sender)
{
    int pulse_width	= StrToFloat(edtTrigPulseWidth->Text);
	// It is the function that user outputting one trigger pulse by force.
	AxmTriggerSetTimeLevel(m_lAxis, pulse_width, HIGH, COMMAND, ENABLE);
	AxmTriggerOneShot(m_lAxis);
}
//---------------------------------------------------------------------------
void __fastcall TfrmCamcQI::btnTrigAbsClick(TObject *Sender)
{
    DWORD	uErrorCode;
	double	trig_pos[1];
	int		pulse_width	= StrToFloat(edtTrigPulseWidth->Text);
	trig_pos[0] = StrToFloat(edtTrigStartPosition->Text);
    
	AxmTriggerSetReset(m_lAxis);
	AxmTriggerSetTimeLevel(m_lAxis, pulse_width, HIGH, COMMAND, ENABLE);

	uErrorCode = AxmTriggerOnlyAbs(m_lAxis, 1, trig_pos);
	if(uErrorCode == AXT_RT_SUCCESS)    lstLog->Items->Add("Trigger absolute position set");
	else                                lstLog->Items->Add("Trigger absolute position not set");
}
//---------------------------------------------------------------------------
void __fastcall TfrmCamcQI::btnTridPeriodClick(TObject *Sender)
{
    DWORD	uErrorCode;
	double	start_pos	= StrToFloat(edtTrigStartPosition->Text);
	double  cycle       = StrToFloat(edtTrigCycle->Text);
	double	end_pos		= StrToFloat(edtTrigEndPos->Text);
	int		pulse_width	= StrToFloat(edtTrigPulseWidth->Text);

	AxmTriggerSetReset(m_lAxis);
	AxmTriggerSetTimeLevel(m_lAxis, pulse_width, HIGH, COMMAND, ENABLE);

	uErrorCode = AxmTriggerSetBlock(m_lAxis, start_pos, end_pos, cycle);
	if(uErrorCode == AXT_RT_SUCCESS)    lstLog->Items->Add("Trigger cycle position set");
	else                                lstLog->Items->Add("Trigger cycle position not set");
}
//---------------------------------------------------------------------------
void __fastcall TfrmCamcQI::btnTrigResetClick(TObject *Sender)
{
	AxmTriggerSetReset(m_lAxis);
}
//---------------------------------------------------------------------------
void __fastcall TfrmCamcQI::btnSigCaptureClick(TObject *Sender)
{
	BYTE	bySignal;	
	DWORD   dwEdge;
	long	lDirect;
	long	lSignalMethod;
	double	dVelocity, dAccel;

	dVelocity		= StrToFloat(edtVelocity->Text);
	dAccel			= StrToFloat(edtAccel->Text);

	bySignal		= cboDetect->ItemIndex;
	lDirect			= cboDirection->ItemIndex;
	lSignalMethod	= cboStopM->ItemIndex;

	// Re-setup of the maximum value in chart for displaying running speed of each axis on the chart.
	SetGraphRange(m_lAxis, dVelocity);

	if(bySignal < 8){
		dwEdge	 = 0;
		bySignal = cboDetect->ItemIndex;
	}else{
		dwEdge	 = 1;
		bySignal = cboDetect->ItemIndex - 8;
	}

	if(lDirect == 0)
		AxmMoveSignalCapture(m_lAxis, dVelocity, dAccel, bySignal, dwEdge, COMMAND, lSignalMethod);
	else
		AxmMoveSignalCapture(m_lAxis, -dVelocity, dAccel, bySignal, dwEdge, COMMAND, lSignalMethod);
}
//---------------------------------------------------------------------------
void __fastcall TfrmCamcQI::btnVelOverrideClick(TObject *Sender)
{
    double dDistance = StrToFloat(edtPosition->Text);
	double dVelocity = fabs(StrToFloat(edtVelocity->Text));
	double dAccel	 = fabs(StrToFloat(edtAccel->Text));
	double dDecel	 = fabs(StrToFloat(edtDecel->Text));

 	SetGraphRange(m_lAxis, dVelocity*2);
	AxmOverrideVelAtPos(m_lAxis, dDistance, dVelocity, dAccel, dDecel, dDistance/4,dVelocity*2, COMMAND);
}
//---------------------------------------------------------------------------
void __fastcall TfrmCamcQI::btnIntMessageClick(TObject *Sender)
{
    char  strData[200];
	DWORD dInterruptNum;

	g_nIntCnt = 0;
        AxlInterruptEnable();
	AxmInterruptSetAxisEnable(m_lAxis, ENABLE);

	// Setup whether interrupt is generated which user of the designated axis set.
	// lBank : Possible to setup interrupt bank number (0 - 1).
	// lInterruptNum : Setup interrupt
	AxmInterruptSetUserEnable(m_lAxis, 1, QIINTBANK2_29);			// Input signal of limit signal (PELM, NELM).
	AxmInterruptSetAxis(m_lAxis, frmCamcQI->Handle, WM_AXL_INTERRUPT, NULL, NULL);

	AxmInterruptGetUserEnable(m_lAxis, 1, &dInterruptNum);
	sprintf(strData, "Limit Int Enable[1][%08X]", dInterruptNum);
 	lstLog->Items->Add(strData);
}
//---------------------------------------------------------------------------
void __fastcall TfrmCamcQI::edtIntCallBackClick(TObject *Sender)
{
	char strData[200];
	DWORD dInterruptNum;

	g_nIntCnt = 0;
    AxlInterruptEnable();
	AxmInterruptSetAxisEnable(m_lAxis, ENABLE);

	// Setup whether interrupt is generated which user of the designated axis set.
	// lBank : Possible to setup interrupt bank number (0 - 1).
	// lInterruptNum : Setup interrupt
	AxmInterruptSetUserEnable(m_lAxis, 0, QIINTBANK1_1);			// When running is finished
	AxmInterruptSetAxis(m_lAxis, NULL, NULL, KeMotionInterruptCallback, NULL);

	AxmInterruptGetUserEnable(m_lAxis, 0, &dInterruptNum);
	sprintf(strData, "Done Int Enable[0][%08X]", dInterruptNum);
	lstLog->Items->Add(strData);
}
//---------------------------------------------------------------------------
void __fastcall TfrmCamcQI::btnIntEventClick(TObject *Sender)
{
	char    strData[200];
	DWORD   dInterruptNum;

	g_nIntCnt = 0;
        AxlInterruptEnable();
	AxmInterruptSetAxisEnable(m_lAxis, ENABLE);
	// Setup whether interrupt is generated which user of the designated axis set.
	// lBank : Possible to setup interrupt bank number (0 - 1).
	// lInterruptNum : Setup interrupt
	AxmInterruptSetUserEnable(m_lAxis, 0, QIINTBANK1_29);
	AxmInterruptSetAxis(m_lAxis, NULL, NULL, NULL, &m_hInterrupt[m_lAxis]);

	AxmInterruptGetUserEnable(m_lAxis, 0, &dInterruptNum);
	sprintf(strData, "Alarm Int Enable[0][%08X]", dInterruptNum);
	lstLog->Items->Add(strData);

	if(m_hHandle[m_lAxis])
	{
		m_bThread[m_lAxis]	= FALSE;
		m_hHandle[m_lAxis]	= NULL;
	}

	if (!m_bThread[m_lAxis])
	{
		m_bThread[m_lAxis]	= TRUE;
		m_hHandle[m_lAxis]	= CreateThread(NULL, 0, (LPTHREAD_START_ROUTINE)ThreadProc, frmCamcQI, NULL, NULL);
	}
}
//---------------------------------------------------------------------------
void __fastcall TfrmCamcQI::btnIntDisableClick(TObject *Sender)
{
	if (m_hHandle[m_lAxis])
	{
		m_bThread[m_lAxis]	= FALSE;
		m_hHandle[m_lAxis]	= NULL;
	}

	g_nIntCnt = 0;                                                  // 인터럽트 카운트 클리어
        AxlInterruptDisable();
	AxmInterruptSetAxis(m_lAxis, frmCamcQI->Handle, NULL, NULL, NULL);  // Cancel interrupt method
	AxmInterruptSetAxisEnable(m_lAxis, DISABLE);                    // Interrupt DISABLE
}
//---------------------------------------------------------------------------
void __fastcall TfrmCamcQI::tmGraphTimer(TObject *Sender)
{
    char    strData[200];
    long    lCount = 0;
    double  dX1 = 0.0, dY1 = 0.0;
 	double  dCurVelX[2], dCurVelY[2];
    DWORD   dwResult = 0, dwResult2 = 0;

    dCurVelX[0] = dCurVelX[1] = 0.0;
    dCurVelY[0] = dCurVelY[1] = 0.0;

    dwResult = AxmStatusGetCmdPos(AXIS_EVN(m_lAxis), &dX1);
    if (dwResult != AXT_RT_SUCCESS) return;
	AxmStatusGetCmdPos(AXIS_ODD(m_lAxis), &dY1);

    // Coordinate graph of X, Y axis
    Series5->AddXY(dX1, dY1, "", (TColor)clYellow);

	dwResult = AxmStatusReadVel(AXIS_N04(m_lAxis, 0), &dCurVelX[0]);
    if (dwResult == AXT_RT_SUCCESS)
    {
        sprintf(strData, "%.3lf", dCurVelX[0]);    edtCmdVelX->Text =  strData;
    }

    dwResult2 = AxmStatusReadVel(AXIS_N04(m_lAxis, 1), &dCurVelX[1]);
    if (dwResult2 == AXT_RT_SUCCESS)
    {
        sprintf(strData, "%.3lf", dCurVelX[1]);     edtCmdVelY->Text =  strData;
    }
    if (dwResult != AXT_RT_SUCCESS) return;

    // Speed graph of X, Y axis
    if (dCurVelX[0] > 0.0 || dCurVelX[1] > 0.0){
        lCount = Series1->XValues->Count();
        Series1->AddXY(lCount, dCurVelX[0], "", (TColor)clRed);
        Series2->AddXY(lCount, dCurVelX[1], "", (TColor)clGreen);

        GraphX->BottomAxis->Automatic = False;
        GraphX->BottomAxis->Maximum = Series1->XValues->Last();
        GraphX->BottomAxis->Minimum = GraphX->BottomAxis->Maximum - 200;
    }

	dwResult = AxmStatusReadVel(AXIS_N04(m_lAxis, 2), &dCurVelY[0]);
    if (dwResult == AXT_RT_SUCCESS)
    {
        sprintf(strData, "%.3lf", dCurVelY[0]);     edtCmdVelZ->Text =  strData;
    }

	dwResult2 = AxmStatusReadVel(AXIS_N04(m_lAxis, 3), &dCurVelY[1]);
    if (dwResult2 == AXT_RT_SUCCESS)
    {
        sprintf(strData, "%.3lf", dCurVelY[1]);     edtCmdVelU->Text =  strData;
    }

    if (dwResult != AXT_RT_SUCCESS) return;

    // Speed graph of Z, U axis
    if (dCurVelY[0] > 0.0 || dCurVelY[1] > 0.0){
        lCount = Series3->XValues->Count();
        Series3->AddXY(lCount, dCurVelY[0], "", (TColor)clYellow);
        Series4->AddXY(lCount, dCurVelY[1], "", (TColor)clAqua);

        GraphY->BottomAxis->Automatic = False;
        GraphY->BottomAxis->Maximum = Series3->XValues->Last();
        GraphY->BottomAxis->Minimum = GraphY->BottomAxis->Maximum - 200;
    }
}
//---------------------------------------------------------------------------
void __fastcall TfrmCamcQI::tmDisplayTimer(TObject *Sender)
{
    char    strData[200];
    DWORD   dwResult = 0;

    DWORD   wReadInput = 0, wReadOuput = 0, wBusyStatus = 0, wReadHome = 0;
	DWORD   wReadInterpolationQueueFree = 0, wIsContMotion = 0, wMechanicalStatus = 0;

	lsByte  bUnivInput, bUnivOutput, bMechanic;
	double  dCmdPos[4], dActPos[4], dpCapPotition;
	long    lNodeNum1 = 0, lTotalNodeNum1 = 0;

    dwResult = AxmStatusGetCmdPos(AXIS_N04(m_lAxis, 0), &dCmdPos[0]);
    if (dwResult == AXT_RT_SUCCESS)
    {
        sprintf(strData, "%.3lf", dCmdPos[0]);     edtCmdPosX->Text =  strData;
    }
    dwResult = AxmStatusGetActPos(AXIS_N04(m_lAxis, 0), &dActPos[0]);
    if (dwResult == AXT_RT_SUCCESS)
    {
        sprintf(strData, "%.3lf", dActPos[0]);     edtActPosX->Text =  strData;
    }

	dwResult = AxmStatusGetCmdPos(AXIS_N04(m_lAxis, 1), &dCmdPos[1]);
    if (dwResult == AXT_RT_SUCCESS)
    {
        sprintf(strData, "%.3lf", dCmdPos[1]);     edtCmdPosY->Text =  strData;
    }
	dwResult = AxmStatusGetActPos(AXIS_N04(m_lAxis, 1), &dActPos[1]);
    if (dwResult == AXT_RT_SUCCESS)
    {
        sprintf(strData, "%.3lf", dActPos[1]);     edtActPosY->Text =  strData;
    }

	dwResult = AxmStatusGetCmdPos(AXIS_N04(m_lAxis, 2), &dCmdPos[2]);
    if (dwResult == AXT_RT_SUCCESS)
    {
        sprintf(strData, "%.3lf", dCmdPos[2]);     edtCmdPosZ->Text =  strData;
    }
	dwResult = AxmStatusGetActPos(AXIS_N04(m_lAxis, 2), &dActPos[2]);
    if (dwResult == AXT_RT_SUCCESS)
    {
        sprintf(strData, "%.3lf", dActPos[2]);     edtActPosZ->Text =  strData;
    }

	dwResult = AxmStatusGetCmdPos(AXIS_N04(m_lAxis, 3), &dCmdPos[3]);
    if (dwResult == AXT_RT_SUCCESS)
    {
        sprintf(strData, "%.3lf", dCmdPos[3]);     edtCmdPosU->Text =  strData;
    }
	dwResult = AxmStatusGetActPos(AXIS_N04(m_lAxis, 3), &dActPos[3]);
    if (dwResult == AXT_RT_SUCCESS)
    {
        sprintf(strData, "%.3lf", dActPos[3]);     edtActPosU->Text =  strData;
    }

	AxmSignalReadInput(m_lAxis, &wReadInput);
	AxmSignalReadOutput(m_lAxis, &wReadOuput);
	AxmStatusReadMechanical(m_lAxis, &wMechanicalStatus);

    bUnivInput.bByte	= (BYTE)wReadInput;
	bUnivOutput.bByte	= (BYTE)wReadOuput;
	bMechanic.wWord     = (WORD)wMechanicalStatus;

    // General output
    LedOut0->Color  = LED_RED(bUnivOutput.bit.b0);
    LedOut1->Color  = LED_RED(bUnivOutput.bit.b1);
    LedOut2->Color  = LED_RED(bUnivOutput.bit.b2);
    LedOut3->Color  = LED_RED(bUnivOutput.bit.b3);
    LedOut4->Color  = LED_RED(bUnivOutput.bit.b4);
 //   LedOut5->Color  = LED_RED(bUnivOutput.bit.b5);

    AxmHomeReadSignal(m_lAxis, &wReadHome);
    LedHome->Color  = LED_RED(wReadHome);

    // General input
    LedIn0->Color    = LED_RED(wReadHome);
    LedIn1->Color    = LED_RED(bUnivInput.bit.b1);
    LedIn2->Color    = LED_RED(bUnivInput.bit.b2);
    LedIn3->Color    = LED_RED(bUnivInput.bit.b3);
    LedIn4->Color    = LED_RED(bUnivInput.bit.b4);
 //   LedIn5->Color    = LED_RED(bUnivInput.bit.b5);

	// Hardware signal
	LedPElm->Color  = LED_RED(bMechanic.wbit.b0);
	LedNElm->Color  = LED_RED(bMechanic.wbit.b1);
	LedAlarm->Color = LED_RED(bMechanic.wbit.b4);
	LedInp->Color   = LED_RED(bMechanic.wbit.b5);
	LedEmg->Color   = LED_RED(bMechanic.wbit.b6);
    LedZPhase->Color= LED_RED(bMechanic.wbit.b8);
	LedEXPP->Color  = LED_RED(bMechanic.wbit.b11);
	LedEXMP->Color  = LED_RED(bMechanic.wbit.b12);
 
    AxmStatusReadInMotion(AXIS_EVN(m_lAxis), &wBusyStatus);
    LedBusyX->Color = LED_YELLOW(wBusyStatus);

    AxmStatusReadInMotion(AXIS_ODD(m_lAxis), &wBusyStatus);
    LedBusyY->Color = LED_YELLOW(wBusyStatus);

	AxmContiReadFree(COORD_NO, &wReadInterpolationQueueFree);
	// A function which checks running of serial interpolation
	AxmContiIsMotion(COORD_NO, &wIsContMotion);
	// A function which reads current index value in interpolation queue
	AxmContiGetNodeNum(COORD_NO, &lNodeNum1);
	AxmContiGetTotalNodeNum(COORD_NO, &lTotalNodeNum1);

    sprintf(strData, "%ld", lTotalNodeNum1);
    edtTotalNum->Text = strData;

    sprintf(strData, "%ld", lNodeNum1);
    edtContiNum->Text = strData;

    sprintf(strData, "%ld", wIsContMotion);
    edtInMotion->Text = strData;

    sprintf(strData, "%ld", wReadInterpolationQueueFree);
    edtQFree->Text = strData;

    sprintf(strData, "%ld", g_nIntCnt);
    edtIntCount->Text = strData;
}
//---------------------------------------------------------------------------

void __fastcall TfrmCamcQI::tmHomeTimer(TObject *Sender)
{
    char    strData[200];
    DWORD   wHomeResult0, wHomeResult1, wHomeResult2, wHomeResult3;

    if(dynamic_cast<TTimer *>(Sender) == tmHome1){
        AxmHomeGetResult(AXIS_N04(m_lAxis, 0), &wHomeResult0);
    	if(wHomeResult0 != HOME_SEARCHING){
          tmHome1->Enabled = false;
    		if(wHomeResult0 == HOME_SUCCESS)    ShowMessage("Home Search 1 Success");
    		else{
                sprintf(strData, "Home Search 1 Fail[0x%x]", wHomeResult0);
		    	ShowMessage(strData);
    		}
        }
    }else if(dynamic_cast<TTimer *>(Sender) == tmHome2){
        AxmHomeGetResult(AXIS_N04(m_lAxis, 1), &wHomeResult1);
    	if(wHomeResult1 != HOME_SEARCHING){
          tmHome2->Enabled = false;
    		if(wHomeResult1 == HOME_SUCCESS)    ShowMessage("Home Search 2 Success");
    		else{
                sprintf(strData, "Home Search 2 Fail[0x%x]", wHomeResult1);
		    	ShowMessage(strData);
    		}
        }
   }else if(dynamic_cast<TTimer *>(Sender) == tmHome3){
        AxmHomeGetResult(AXIS_N04(m_lAxis, 2), &wHomeResult2);
    	if(wHomeResult2 != HOME_SEARCHING){
          tmHome3->Enabled = false;
    		if(wHomeResult2 == HOME_SUCCESS)    ShowMessage("Home Search 3 Success");
    		else{
                sprintf(strData, "Home Search 3 Fail[0x%x]", wHomeResult2);
		    	ShowMessage(strData);
    		}
        }
    }else if(dynamic_cast<TTimer *>(Sender) == tmHome4){
       AxmHomeGetResult(AXIS_N04(m_lAxis, 3), &wHomeResult3);
    	if(wHomeResult3 != HOME_SEARCHING){
          tmHome4->Enabled = false;
    		if(wHomeResult3 == HOME_SUCCESS)    ShowMessage("Home Search 4 Success");
    		else{
                sprintf(strData, "Home Search 4 Fail[0x%x]", wHomeResult3);
		    	ShowMessage(strData);
    		}
        }
    }
}
//---------------------------------------------------------------------------


void __fastcall TfrmCamcQI::btnCRCOnClick(TObject *Sender)
{
	// Level   : LOW(0), HIGH(1), UNUSED(2), USED(3)
	// uMethod : Remove remaining pulse, possible to setup output signal pulse range of 0 - 6 (Only use QI, Not use IP)
	// (0 : 10 uSec , 1 : 100 uSec, 2: 500 uSec, 3:1 mSec, 4:10 mSec, 5:50 mSec, 6:100 mSec)
	AxmCrcSetMaskLevel(m_lAxis, HIGH, 6);
}
//---------------------------------------------------------------------------

void __fastcall TfrmCamcQI::btnCRCOffClick(TObject *Sender)
{
	AxmCrcSetMaskLevel(m_lAxis, UNUSED, 6);
}
//---------------------------------------------------------------------------
void __fastcall TfrmCamcQI::chkEmgLevelClick(TObject *Sender)
{
    DWORD   dwLevel;

    if (!m_bA4NAxis)
        AxmSignalSetStop(m_lAxis, EMERGENCY_STOP, chkEmgLevel->State);
    else
    {
        if (chkEmgLevel->Checked == 0)  dwLevel   = 2;
        else                            dwLevel   = 1;
        AxmSignalSetStop(m_lAxis, EMERGENCY_STOP, dwLevel);
    }
    if (!m_bA4NAxis)
        AxmSignalSetStop(m_lAxis, EMERGENCY_STOP, chkEmgLevel->State);
    else
        AxmSignalSetStop(m_lAxis, EMERGENCY_STOP, chkEmgLevel->Checked);
}
//---------------------------------------------------------------------------

void __fastcall TfrmCamcQI::chkHomeLevelClick(TObject *Sender)
{
    if (!m_bA4NAxis)
        AxmHomeSetSignalLevel(m_lAxis, chkHomeLevel->Checked) ;
}
//---------------------------------------------------------------------------


void __fastcall TfrmCamcQI::btnJogMouseDown(TObject *Sender,
      TMouseButton Button, TShiftState Shift, int X, int Y)
{
    long	lAxisNo;
	long	lAxis[2];
	double	dMVel[2], dMAcc[2], dMDec[2];

	double	dVelocity	=  fabs(StrToFloat(edtVelocity->Text));
	double	dAccel 		=  fabs(StrToFloat(edtAccel->Text));
	double	dDecel		=  fabs(StrToFloat(edtDecel->Text));

   	dMAcc[0] = dMAcc[1] = dAccel;
	dMDec[0] = dMDec[1] = dDecel;

    switch(((TButton *)Sender)->Tag){
    case 0:
		lAxisNo		= AXIS_N04(m_lAxis, 0);
		lAxis[0]	= AXIS_N04(m_lAxis, 0);
		lAxis[1]	= AXIS_N04(m_lAxis, 1);
		dMVel[0]	= dVelocity;
		dMVel[1]	= dVelocity;
        break;

	case 1:
		lAxisNo		= AXIS_N04(m_lAxis, 0);
		lAxis[0]	= AXIS_N04(m_lAxis, 0);
		lAxis[1]	= AXIS_N04(m_lAxis, 1);
		dMVel[0]	= -dVelocity;
		dMVel[1]	= -dVelocity;
		break;

	case 2:
		lAxisNo		= AXIS_N04(m_lAxis, 1);
		lAxis[0]	= AXIS_N04(m_lAxis, 0);
		lAxis[1]	= AXIS_N04(m_lAxis, 1);
		dMVel[0]	= dVelocity;
		dMVel[1]	= dVelocity;
		break;

	case 3:
		lAxisNo		= AXIS_N04(m_lAxis, 1);
		lAxis[0]	= AXIS_N04(m_lAxis, 0);
		lAxis[1]	= AXIS_N04(m_lAxis, 1);
		dMVel[0]	= -dVelocity;
		dMVel[1]	= -dVelocity;
		break;

	case 4:
		lAxisNo		= AXIS_N04(m_lAxis, 2);
		lAxis[0]	= AXIS_N04(m_lAxis, 2);
		lAxis[1]	= AXIS_N04(m_lAxis, 3);
		dMVel[0]	= dVelocity;
		dMVel[1]	= dVelocity;
		break;

	case 5:
		lAxisNo		= AXIS_N04(m_lAxis, 2);
		lAxis[0]	= AXIS_N04(m_lAxis, 2);
		lAxis[1]	= AXIS_N04(m_lAxis, 3);
		dMVel[0]	= -dVelocity;
		dMVel[1]	= -dVelocity;
		break;

	case 6:
		lAxisNo		= AXIS_N04(m_lAxis, 3);
		lAxis[0]	= AXIS_N04(m_lAxis, 2);
		lAxis[1]	= AXIS_N04(m_lAxis, 3);
		dMVel[0]	= dVelocity;
		dMVel[1]	= dVelocity;
		break;

	case 7:
		lAxisNo		= AXIS_N04(m_lAxis, 3);
		lAxis[0]	= AXIS_N04(m_lAxis, 2);
		lAxis[1]	= AXIS_N04(m_lAxis, 3);
		dMVel[0]	= -dVelocity;
		dMVel[1]	= -dVelocity;
		break;
	}

    // Re-setup of the maximum value in chart for displaying running speed of each axis on the chart.
    if(((TButton *)Sender)->Tag < 4)
        GraphX->LeftAxis->Maximum = dVelocity + (dVelocity * 0.2);
    else
        GraphY->LeftAxis->Maximum = dVelocity + (dVelocity * 0.2);

	if (chkXYSyn->Checked == TRUE){
		if(chkAsym->Checked == TRUE)	AxmMoveStartMultiVel(2, lAxis, dMVel, dMAcc, dMDec);
		else					        AxmMoveStartMultiVel(2, lAxis, dMVel, dMAcc, dMAcc);
	}else{
		if(chkAsym->Checked == TRUE)	AxmMoveVel(lAxisNo, dMVel[0], dAccel, dDecel);
		else					        AxmMoveVel(lAxisNo, dMVel[0], dAccel, dAccel);
	}
}
//---------------------------------------------------------------------------
void __fastcall TfrmCamcQI::btnJogMouseUp(TObject *Sender,
      TMouseButton Button, TShiftState Shift, int X, int Y)
{
    long    lAxisNo;
    lAxisNo	= AXIS_N04(m_lAxis, ((TButton *)Sender)->Tag / 2);
    AxmMoveSStop(lAxisNo);
}
//---------------------------------------------------------------------------
// Repeated running after reading running parameter from edit box.
// Create thread for repeated running.
void __fastcall TfrmCamcQI::btnRepeatClick(TObject *Sender)
{
	unsigned long	ThreadID;
	if(m_hTestThread[AXIS_QUR(m_lAxis)] == NULL){
		PREPEAT_MOVE RM_M = new REPEAT_MOVE;

		RM_M->nAxis		= m_lAxis;
		RM_M->dPosition	= StrToFloat(edtPosition->Text);
		RM_M->dVelocity	= StrToFloat(edtVelocity->Text);
		RM_M->dAccel	= StrToFloat(edtAccel->Text);
		RM_M->dDecel	= StrToFloat(edtDecel->Text);
		RM_M->pParent	= (LPVOID)frmCamcQI;

		m_bTestActive[AXIS_QUR(m_lAxis)] = TRUE;
		m_hTestThread[AXIS_QUR(m_lAxis)] = CreateThread(NULL, 0, (LPTHREAD_START_ROUTINE)RepeatThread, RM_M, 0, &ThreadID);
	}else{
        lstLog->Items->Add("Now moving.");
        lstLog->TopIndex = lstLog->Count - 1;
	}
}
//---------------------------------------------------------------------------
void __fastcall TfrmCamcQI::btn3DGraphClick(TObject *Sender)
{
    frm3DGraph->UpdateAxis(m_lAxis);
    frm3DGraph->Show();
    frm3DGraph->tmGraph->Enabled = true;
}
//---------------------------------------------------------------------------

void __fastcall TfrmCamcQI::btnStatusClick(TObject *Sender)
{
    frmReadStatus->UpdateAxis(m_lAxis);
    frmReadStatus->Show();
}
//---------------------------------------------------------------------------

void __fastcall TfrmCamcQI::btnManualSetClick(TObject *Sender)
{
    frmManualSet->UpdateAxis(m_lAxis);
    frmManualSet->Show();
}
//---------------------------------------------------------------------------

void __fastcall TfrmCamcQI::chkGantryClick(TObject *Sender)
{
	char    strMsg[200];
	DWORD	uErrorCode; 
    if(chkGantry->Checked == True){
    	uErrorCode = AxmGantrySetEnable(AXIS_EVN(m_lAxis), AXIS_ODD(m_lAxis), chkGantrySlave->Checked == TRUE, 0.0, 100000.0);
        sprintf(strMsg, "Gantry Enable ErrCode: %d", uErrorCode);
        lstLog->Items->Add(strMsg);
    }else{
		AxmGantrySetDisable(AXIS_EVN(m_lAxis), AXIS_ODD(m_lAxis));
        lstLog->Items->Add("Gantry Disable");
    }
}
//---------------------------------------------------------------------------
void __fastcall TfrmCamcQI::btnContiBlendClick(TObject *Sender)
{
	long    lAxis[2];
	double  dPos[2];
	double  dCenPos[2];	
	double  dEndPos[2];
	double	dVelocity, dAccel, dDecel;

	dVelocity	= StrToFloat(edtVelocity->Text);
	dAccel		= StrToFloat(edtAccel->Text);
	dDecel		= StrToFloat(edtDecel->Text);

	lAxis[0]	= AXIS_N04(m_lAxis, 0); 
	lAxis[1]	= AXIS_N04(m_lAxis, 1); 

	SetGraphRange(lAxis[0], dVelocity);	

	AxmContiSetAxisMap(COORD_NO, 2, lAxis);
	AxmContiWriteClear(COORD_NO);

	AxmContiSetAbsRelMode(COORD_NO, POS_ABS_MODE);

	AxmContiBeginNode(COORD_NO); 	
	dPos[0] = 0 , dPos[1] = 2000;
	AxmLineMove(COORD_NO, dPos, dVelocity, dAccel, dDecel);	
	
	dPos[0] = 1800 , dPos[1] = 2000;
	AxmLineMove(COORD_NO, dPos, dVelocity, dAccel, dDecel);	
	
	dCenPos[0] = 1800 , dCenPos[1] = 1800; dEndPos[0] = 2000; dEndPos[1] = 1800;
	AxmCircleCenterMove(COORD_NO, lAxis, dCenPos, dEndPos, dVelocity, dAccel, dAccel, DIR_CW);
	
	dPos[0] = 2000 , dPos[1] = -1800;
	AxmLineMove(COORD_NO, dPos, dVelocity, dAccel, dAccel);	
	
	dCenPos[0] = 1800 , dCenPos[1] = -1800; dEndPos[0] = 1800; dEndPos[1] = -2000;
	AxmCircleCenterMove(COORD_NO, lAxis, dCenPos, dEndPos, dVelocity, dAccel, dAccel, DIR_CW);

	dPos[0] = -1800 , dPos[1] = -2000;
	AxmLineMove(COORD_NO, dPos, dVelocity, dAccel, dAccel);	
	
	dCenPos[0] = -1800 , dCenPos[1] = -1800; dEndPos[0] = -2000; dEndPos[1] = -1800;
	AxmCircleCenterMove(COORD_NO, lAxis, dCenPos, dEndPos, dVelocity, dAccel, dAccel, DIR_CW);

	dPos[0] = -2000 , dPos[1] = 1800;
	AxmLineMove(COORD_NO, dPos, dVelocity, dAccel, dAccel);	
	
	dCenPos[0] = -1800 , dCenPos[1] = 1800; dEndPos[0] = -1800; dEndPos[1] = 2000;
	AxmCircleCenterMove(COORD_NO, lAxis, dCenPos, dEndPos, dVelocity, dAccel, dAccel, DIR_CW);

	dPos[0] = 0 , dPos[1] = 2000;
	AxmLineMove(COORD_NO, dPos, dVelocity, dAccel, dAccel);	
	
	AxmContiEndNode(COORD_NO);
}
//---------------------------------------------------------------------------

void __fastcall TfrmCamcQI::btnContiCircleClick(TObject *Sender)
{
	long    lAxis[2];
	double	dVelocity, dAccel, dDecel;
	double  dCenPos[2], dEndPos[2];

	dVelocity	= StrToFloat(edtVelocity->Text);
	dAccel		= StrToFloat(edtAccel->Text);
	dDecel		= StrToFloat(edtDecel->Text);

	lAxis[0]	= AXIS_N04(m_lAxis, 0); 
	lAxis[1]	= AXIS_N04(m_lAxis, 1); 

	SetGraphRange(lAxis[0], dVelocity);	

	AxmContiWriteClear(COORD_NO);
	AxmContiSetAxisMap(COORD_NO, 2, lAxis);
	AxmContiSetAbsRelMode(COORD_NO, POS_ABS_MODE);

	AxmContiBeginNode(COORD_NO);

	dCenPos[0] = 1000 , dCenPos[1] = 1000; dEndPos[0] = 0; dEndPos[1] = 0;
	AxmCircleCenterMove(COORD_NO, lAxis, dCenPos, dEndPos, dVelocity, dAccel, dDecel, DIR_CCW);

	dCenPos[0] = -1000 , dCenPos[1] = 1000; dEndPos[0] = 0; dEndPos[1] = 0;
	AxmCircleCenterMove(COORD_NO, lAxis, dCenPos, dEndPos, dVelocity, dAccel, dDecel, DIR_CCW);

	dCenPos[0] = -1000 , dCenPos[1] = -1000; dEndPos[0] = 0; dEndPos[1] = 0;
	AxmCircleCenterMove(COORD_NO, lAxis, dCenPos, dEndPos, dVelocity, dAccel, dDecel, DIR_CCW);

	dCenPos[0] = 1000 , dCenPos[1] = -1000; dEndPos[0] = 0; dEndPos[1] = 0;
	AxmCircleCenterMove(COORD_NO, lAxis, dCenPos, dEndPos, dVelocity, dAccel, dDecel, DIR_CCW);

	AxmContiEndNode(COORD_NO);
}
//---------------------------------------------------------------------------

void __fastcall TfrmCamcQI::btnContiLineClick(TObject *Sender)
{
    long    lAxis[3];
	double  dPos[3];
	double	dVelocity, dAccel, dDecel;

	dVelocity	= StrToFloat(edtVelocity->Text);
	dAccel		= StrToFloat(edtAccel->Text);
	dDecel		= StrToFloat(edtDecel->Text);

	lAxis[0]	= AXIS_N04(m_lAxis, 0);
	lAxis[1]	= AXIS_N04(m_lAxis, 1);
	lAxis[2]	= AXIS_N04(m_lAxis, 2);

	SetGraphRange(lAxis[0], dVelocity);	
	SetGraphRange(lAxis[2], dVelocity);	

	AxmContiSetAxisMap(COORD_NO, 3, lAxis);
	AxmContiWriteClear(COORD_NO);
    AxmContiSetAbsRelMode(COORD_NO, POS_ABS_MODE);

	AxmContiBeginNode(COORD_NO);

	dPos[0] = 0 , dPos[1] = 0, dPos[2] = 0;
	AxmLineMove(COORD_NO, dPos, dVelocity, dAccel, dDecel);

	dPos[0] = 0 , dPos[1] = 2000, dPos[2] = 0;
	AxmLineMove(COORD_NO, dPos, dVelocity, dAccel, dDecel);

	dPos[0] = 0 , dPos[1] = 2000, dPos[2] = 2000;
	AxmLineMove(COORD_NO, dPos, dVelocity, dAccel, dDecel);

	dPos[0] = 2000 , dPos[1] = 0, dPos[2] = 2000;
	AxmLineMove(COORD_NO, dPos, dVelocity, dAccel, dDecel);

	dPos[0] = 0 , dPos[1] = -2000, dPos[2] = 2000;
	AxmLineMove(COORD_NO, dPos, dVelocity, dAccel, dDecel);

	dPos[0] = -2000 , dPos[1] = 0, dPos[2] = 2000;
	AxmLineMove(COORD_NO, dPos, dVelocity, dAccel, dDecel);

	dPos[0] = 0 , dPos[1] = 2000, dPos[2] = 2000;
	AxmLineMove(COORD_NO, dPos, dVelocity, dAccel, dDecel);

	dPos[0] = 0 , dPos[1] = 2000, dPos[2] = 0;
	AxmLineMove(COORD_NO, dPos, dVelocity, dAccel, dDecel);

	dPos[0] = 0 , dPos[1] = 0, dPos[2] = 0;
	AxmLineMove(COORD_NO, dPos, dVelocity, dAccel, dDecel);

    AxmContiEndNode(COORD_NO);
}
//---------------------------------------------------------------------------
// Straight line interpolation running
void __fastcall TfrmCamcQI::btnLinearClick(TObject *Sender)
{
	char    strMsg[200];
	long    lAxis[2];
	double  dPos[2];
	DWORD	uErrorCode;
	double	dXend, dYend, dVelocity, dAccel, dDecel;

	dVelocity	= StrToFloat(edtVelocity->Text);
	dAccel		= StrToFloat(edtAccel->Text);
	dDecel		= StrToFloat(edtDecel->Text);

	dPos[0]		= StrToFloat(edtXCen->Text);
	dPos[1]		= StrToFloat(edtXCen->Text);

	lAxis[0]	= AXIS_EVN(m_lAxis);
	lAxis[1]	= AXIS_ODD(m_lAxis);

	SetGraphRange(lAxis[0], dVelocity);

	AxmContiSetAxisMap(COORD_NO, 2, lAxis);
	AxmContiWriteClear(COORD_NO);

	SetCoordMovePara();
	uErrorCode = AxmLineMove(COORD_NO, dPos, dVelocity, dAccel, dDecel);

	sprintf(strMsg, "Linear Error Code: %d", uErrorCode);
	if(uErrorCode != AXT_RT_SUCCESS)	lstLog->Items->Add(strMsg);

	double	dPosition;
	AxmMotGetParaLoad(m_lAxis, &dPosition, 0, 0, 0);
	AxmMotSetParaLoad(m_lAxis, dPosition, dVelocity, dAccel, dDecel);

}
//---------------------------------------------------------------------------

void __fastcall TfrmCamcQI::btnCircularClick(TObject *Sender)
{
	char    strMsg[200];
	long    lAxis[2];
	double  dCenPos[2];	
	DWORD	uErrorCode;
	double	dVelocity, dAccel, dDecel, dAngle;

	dVelocity	= StrToFloat(edtVelocity->Text);
	dAccel		= StrToFloat(edtAccel->Text);
	dDecel		= StrToFloat(edtDecel->Text);
	dAngle		= StrToFloat(edtAngle->Text);

	dCenPos[0]	= StrToFloat(edtXCen->Text);
	dCenPos[1]	= StrToFloat(edtYCen->Text);

	lAxis[0]	= AXIS_EVN(m_lAxis);
	lAxis[1]	= AXIS_ODD(m_lAxis);

	SetGraphRange(lAxis[0], dVelocity);	

	AxmContiSetAxisMap(COORD_NO, 2, lAxis);
	AxmContiWriteClear(COORD_NO);

	SetCoordMovePara();
	if(chkCwCcw->Checked)	uErrorCode = AxmCircleAngleMove(COORD_NO, lAxis, dCenPos, dAngle, dVelocity, dAccel, dDecel, 0);
	else					uErrorCode = AxmCircleAngleMove(COORD_NO, lAxis, dCenPos, dAngle, dVelocity, dAccel, dDecel, 1);

	sprintf(strMsg, "Circular Error Code: %d", uErrorCode);	
	if(uErrorCode != AXT_RT_SUCCESS)	lstLog->Items->Add(strMsg);

	double	dPosition;
	AxmMotGetParaLoad(m_lAxis, &dPosition, 0, 0, 0);
	AxmMotSetParaLoad(m_lAxis, dPosition, dVelocity, dAccel, dDecel);	
}
//---------------------------------------------------------------------------
void __fastcall TfrmCamcQI::chkAbsoluteClick(TObject *Sender)
{
    if (chkAbsolute->Checked == TRUE){
		chkRelative->Checked = FALSE;
		AxmMotSetAbsRelMode(m_lAxis, POS_ABS_MODE);
	}else{
		chkRelative->Checked = TRUE;
		AxmMotSetAbsRelMode(m_lAxis, POS_REL_MODE);
	}
}
//---------------------------------------------------------------------------

void __fastcall TfrmCamcQI::chkRelativeClick(TObject *Sender)
{
    if (chkRelative->Checked == TRUE){
		chkAbsolute->Checked = FALSE;
		AxmMotSetAbsRelMode(m_lAxis, POS_REL_MODE);
	}else{
		chkAbsolute->Checked = TRUE;
		AxmMotSetAbsRelMode(m_lAxis, POS_ABS_MODE);
	}
}
//---------------------------------------------------------------------------
void __fastcall TfrmCamcQI::trkXYRangeChange(TObject *Sender)
{
	int		nTicPos, nTicPos2;
	double  dRange;	
	double	dUnit;
	long	lPulse;

	nTicPos		= trkXYRange->Position;
	nTicPos2	= trkXYRange2->Position;

	AxmMotGetMoveUnitPerPulse(m_lAxis, &dUnit, &lPulse);
   	m_lRange	= (nTicPos * 5) * pow(10, nTicPos2) * (dUnit / lPulse);

	XYPlot->LeftAxis->Minimum = -m_lRange;
    XYPlot->LeftAxis->Maximum = m_lRange;
    XYPlot->BottomAxis->Minimum = -m_lRange;
    XYPlot->BottomAxis->Maximum = m_lRange;
}
//---------------------------------------------------------------------------
void __fastcall TfrmCamcQI::btnReadCaptureClick(TObject *Sender)
{
    char    strData[128];
	double	dCapPos =0.0;

    AxmMoveGetCapturePos(m_lAxis, &dCapPos);
    sprintf(strData, "%lf", dCapPos);
    edtCapturePos->Text = strData;
}
//---------------------------------------------------------------------------

void __fastcall TfrmCamcQI::LedOut0Click(TObject *Sender)
{
	DWORD   dwOnOff;
	AxmSignalIsServoOn(m_lAxis, &dwOnOff);		
	if(dwOnOff)	AxmSignalServoOn(m_lAxis, FALSE);
	else		AxmSignalServoOn(m_lAxis, TRUE);		
}
//---------------------------------------------------------------------------
void __fastcall TfrmCamcQI::LedOut1Click(TObject *Sender)
{
	DWORD   dwOutBit;
	AxmSignalReadOutputBit(m_lAxis, 1, &dwOutBit);
	if (dwOutBit)	AxmSignalServoAlarmReset(m_lAxis, FALSE);
	else			AxmSignalServoAlarmReset(m_lAxis, TRUE);
}
//---------------------------------------------------------------------------
void __fastcall TfrmCamcQI::LedOut2Click(TObject *Sender)
{
	DWORD   dwOutBit;
	AxmSignalReadOutputBit(m_lAxis, 2, &dwOutBit);	
	if(dwOutBit)	AxmSignalWriteOutputBit(m_lAxis, 2, FALSE);
	else			AxmSignalWriteOutputBit(m_lAxis, 2, TRUE);
}
//---------------------------------------------------------------------------
void __fastcall TfrmCamcQI::LedOut3Click(TObject *Sender)
{
	DWORD   dwOutBit;
	AxmSignalReadOutputBit(m_lAxis, 3, &dwOutBit);	
	if(dwOutBit)	AxmSignalWriteOutputBit(m_lAxis, 3, FALSE);
	else			AxmSignalWriteOutputBit(m_lAxis, 3, TRUE);
}
//---------------------------------------------------------------------------
void __fastcall TfrmCamcQI::LedOut4Click(TObject *Sender)
{
	DWORD   dwOutBit;
	AxmSignalReadOutputBit(m_lAxis, 4, &dwOutBit);	
	if(dwOutBit)	AxmSignalWriteOutputBit(m_lAxis, 4, FALSE);
	else			AxmSignalWriteOutputBit(m_lAxis, 4, TRUE);	
}
//---------------------------------------------------------------------------
void __fastcall TfrmCamcQI::LedOut5Click(TObject *Sender)
{
	DWORD   dwOutBit;
	AxmSignalReadOutputBit(m_lAxis, 5, &dwOutBit);	
	if(dwOutBit)	AxmSignalWriteOutputBit(m_lAxis, 5, FALSE);
	else			AxmSignalWriteOutputBit(m_lAxis, 5, TRUE);	
}
//---------------------------------------------------------------------------
void TfrmCamcQI::OnControlMessage(TMessage Msg)
{
	char    strData[200];

	int		nBoard = Msg.WParamHi;		    // Interrupt generation board number.
	long	lAxisNo = Msg.WParamLo;		    // Interrupt generation axis number.
	int		nIntrFlag = (int)Msg.LParam;	// Interrupt generation axis location.

	DWORD IntBank0, IntBank1;
	AxmInterruptReadAxisFlag(lAxisNo, 0, &IntBank0);
	AxmInterruptReadAxisFlag(lAxisNo, 1, &IntBank1);

	g_nIntCnt++;
	sprintf(strData, "Msg[%02d]Axis[%02d]Flag[0x%02X]", g_nIntCnt, lAxisNo, nIntrFlag);
    lstLog->Items->Add(strData);
}
void TfrmCamcQI::SetCoordMovePara()
{
	if(chkAbsolute->Checked)	AxmContiSetAbsRelMode(COORD_NO, POS_ABS_MODE);
	else			  	        AxmContiSetAbsRelMode(COORD_NO, POS_REL_MODE);
}

BOOL TfrmCamcQI::ThreadData()
{
	long	lAxisNo;
	char    strData[200];
	DWORD	dwFlag;
	DWORD	IntBank0, IntBank1;

	lAxisNo = m_lAxis;

	while(m_bThread[lAxisNo])
    {
		if (WaitForSingleObject(m_hInterrupt[lAxisNo], INFINITE) == WAIT_OBJECT_0)
        {
            AxmInterruptReadAxisFlag(lAxisNo, 0, &IntBank0);
            AxmInterruptReadAxisFlag(lAxisNo, 1, &IntBank1);

			g_nIntCnt++;
	        sprintf(strData, "Event[%02d]Axis[%02d]Flag[0x%02X, 0x%02X]", g_nIntCnt, lAxisNo, IntBank0, IntBank1);
			lstLog->Items->Add(strData);
		}
	}

	return TRUE;
}

void __fastcall TfrmCamcQI::btnEStopClick(TObject *Sender)
{
	m_bTestActive[AXIS_QUR(0)] = FALSE;
	m_bTestActive[AXIS_QUR(1)] = FALSE;
	m_bTestActive[AXIS_QUR(2)] = FALSE;
	m_bTestActive[AXIS_QUR(3)] = FALSE;

	for(int i = 0; i < m_lAxisCounts; i++){
		AxmMoveEStop(i);
	}

	lstLog->Items->Add("All axis emergency stopped.");
    lstLog->TopIndex = lstLog->Count - 1;
}
//---------------------------------------------------------------------------

void __fastcall TfrmCamcQI::btnContiStartClick(TObject *Sender)
{
    AxmContiStart(COORD_NO, 0, 0);    
}
//---------------------------------------------------------------------------
void __fastcall TfrmCamcQI::btnLoadClick(TObject *Sender)
{
    AnsiString    temp;
    OpenDlg->Filter = "Data File (*.mot)|*.mot|All Files (*.*)|*.*";
	if(OpenDlg->Execute()){
        temp = OpenDlg->FileName;
		if (AXT_RT_SUCCESS != AxmMotLoadParaAll((char *)temp.data()))
            lstLog->Items->Add("File load fail!");

        lstLog->TopIndex = lstLog->Count - 1;
    }
	UpdateAxisInfo();
}
//---------------------------------------------------------------------------
void __fastcall TfrmCamcQI::btnSaveClick(TObject *Sender)
{
    int         nLength;
    AnsiString  temp, FileType;
    SaveDlg->Filter = "Data File (*.mot)|*.mot|All Files (*.*)|*.*";
	if(SaveDlg->Execute()){
        SaveDlg->FilterIndex = 1;
        temp = SaveDlg->FileName;
        nLength = temp.Length();

        FileType = temp.SubString(nLength - 3, 4);
        if(FileType != ".mot")
            temp = temp + ".mot";

		if (AXT_RT_SUCCESS != AxmMotSaveParaAll((char *)temp.data()))
            lstLog->Items->Add("File save fail!");
    }
}
//---------------------------------------------------------------------------
void __fastcall TfrmCamcQI::lstLogDblClick(TObject *Sender)
{
    lstLog->Clear();
}
//---------------------------------------------------------------------------
void __fastcall TfrmCamcQI::chkGantrySlaveClick(TObject *Sender)
{
  char  strGantry[200];

     if(chkGantrySlave->State == 0)
  	sprintf(strGantry, "Do not Search");
    else if(chkGantrySlave->State == 1)
  	sprintf(strGantry, "Do origin revision after Search");
    else if(chkGantrySlave->State == 2)
  	sprintf(strGantry, "Do not origin revision after Search");

    chkGantrySlave->Caption = strGantry;
}
//---------------------------------------------------------------------------

