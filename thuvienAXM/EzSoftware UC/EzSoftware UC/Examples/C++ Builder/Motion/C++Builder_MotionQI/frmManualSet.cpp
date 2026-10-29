//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "stdio.h"
#include "frmManualSet.h"

#include "AXM.h"
#include "AXL.h"
#include "AXDev.h"

//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"
TfrmManualSet *frmManualSet;
//---------------------------------------------------------------------------
__fastcall TfrmManualSet::TfrmManualSet(TComponent* Owner)
    : TForm(Owner)
{
	m_lAxisCount	= 0;
	m_lAxisNo		= 0;
}
//---------------------------------------------------------------------------
void __fastcall TfrmManualSet::FormCreate(TObject *Sender)
{
    AxmInfoGetAxisCount(&m_lAxisCount);
    
	char    strAxis[200];
	for( int i=0; i < m_lAxisCount; i++){
		sprintf(strAxis, "%d Axis", i);
		cboAxisSel->Items->Add(strAxis);
	}

	cboAxisSel->ItemIndex = 0;
	cboPort->ItemIndex = 0;
	chkHex->Checked = true;
    tmMonitor->Enabled = true;
}
//---------------------------------------------------------------------------
void	TfrmManualSet::UpdateAxis(long lAxis)
{
	m_lAxisNo = lAxis;
	cboAxisSel->ItemIndex = m_lAxisNo;
}

void __fastcall TfrmManualSet::btnCmdClick(TObject *Sender)
{
	AnsiString  strTemp;
	BYTE	    bCmd;
	DWORD	    dwData;
	long	    lTempData;

    strTemp = edtCmd->Text;

	if(strTemp.IsEmpty())										                lTempData = 0;
	else if(strTemp.SubString(0, 2) == "0x" || strTemp.SubString(0, 2) == "0X")	strTemp.sprintf("%x", lTempData);
	else														                strTemp.sprintf("%d", lTempData);

	bCmd	=	0x000000FF & lTempData;
    strTemp = edtData->Text;

	if(strTemp.IsEmpty())										                lTempData = 0;
	else if(strTemp.SubString(0, 2) == "0x" || strTemp.SubString(0, 2) == "0X")	strTemp.sprintf("%x", lTempData);
	else														                strTemp.sprintf("%d", lTempData);

	dwData	=	0xFFFFFFFF & lTempData; 
	if(0x80 & bCmd)	AxmSetCommandData32Qi(m_lAxisNo, (QICOMMAND)bCmd, dwData);
	else			AxmGetCommandData32Qi(m_lAxisNo, (QICOMMAND)bCmd, &dwData);

	if(chkHex->Checked)	strTemp.sprintf("0x%08x", dwData);
	else				strTemp.sprintf("%d", dwData);
	
    edtData->Text = strTemp;
}
//---------------------------------------------------------------------------
void __fastcall TfrmManualSet::btnRdClick(TObject *Sender)
{
	long	    lTempData;
	AnsiString  strTemp;
	BYTE	    bCmd;
	WORD	    dwData, wOffset;

	lTempData = cboPort->ItemIndex;
	wOffset = 0x200 | ((0xFF & lTempData) << 2);
	AxmGetPortDataQi(m_lAxisNo, wOffset, &dwData);
	
	if(chkHex->Checked)	strTemp.sprintf("0x%08x", dwData);
	else			   	strTemp.sprintf("%d", dwData);
	
    edtData->Text = strTemp;
}
//---------------------------------------------------------------------------

void __fastcall TfrmManualSet::btnWrClick(TObject *Sender)
{
	AnsiString strTemp;
	BYTE	    bCmd;
	DWORD	    dwData, wOffset;
	long	    lTempData;
	lTempData = cboPort->ItemIndex;
	wOffset = 0x200 | ((0xFF & lTempData) << 2);

    strTemp = edtData->Text;

	if(strTemp.IsEmpty())										                lTempData = 0;
	else if(strTemp.SubString(0, 2) == "0x" || strTemp.SubString(0, 2) == "0X")	strTemp.sprintf("%x", lTempData);
	else														                strTemp.sprintf("%d", lTempData);

	dwData = lTempData;
	AxmSetPortDataQi(m_lAxisNo, wOffset, dwData);

	if(chkHex->Checked)	strTemp.sprintf("0x%08x", dwData);
	else			  	strTemp.sprintf("%d", dwData);

	edtData->Text = strTemp;
}
//---------------------------------------------------------------------------

void __fastcall TfrmManualSet::tmMonitorTimer(TObject *Sender)
{
    DWORD       dwReturn;
	AnsiString  strTemp;
	DWORD	    dwCmd;
	DWORD	    dwData;
	long	    lTempData;
	int		    i;
    TCheckBox   *chkOnOff;
    TEdit       *edtData, *edtCmd;
    String      strName;
    char        strData[200];

	for(i = 0; i < 6; i++){
        strName = "chkOnOff"+IntToStr(i+1);
        chkOnOff = (TCheckBox *)this->FindComponent(strName);
		if(chkOnOff->Checked){
            strName = "edtCmd"+IntToStr(i+1);
            edtCmd = (TEdit *)this->FindComponent(strName);
            strName = "edtData"+IntToStr(i+1);
            edtData = (TEdit *)this->FindComponent(strName);

            strTemp = edtCmd->Text;
			dwCmd	=	0x0000007F & lTempData;
			AxmGetCommandData32Qi(m_lAxisNo, (QICOMMAND)dwCmd, &dwData);

			if(chkHex->Checked)	strTemp.sprintf("0x%08x", dwData);
			else			  	strTemp.sprintf("%d", dwData);

            edtData->Text = strTemp;
		}
	}
}
//---------------------------------------------------------------------------

void __fastcall TfrmManualSet::cboAxisSelClick(TObject *Sender)
{
	m_lAxisNo = cboAxisSel->ItemIndex;
}
//---------------------------------------------------------------------------

