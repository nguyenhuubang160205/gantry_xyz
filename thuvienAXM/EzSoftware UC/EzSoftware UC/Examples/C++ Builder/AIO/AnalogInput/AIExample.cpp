//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "AIExample.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"
#pragma comment(lib, "AxL.lib")

// Event Flag
BOOL g_fChannelEvent[8];

TFormAnalogInput *FormAnalogInput;
//---------------------------------------------------------------------------
__fastcall TFormAnalogInput::TFormAnalogInput(TComponent* Owner)
        : TForm(Owner)
{
    m_bStart = false;
    m_bThread = false;
}
//---------------------------------------------------------------------------

void __fastcall TFormAnalogInput::FormCreate(TObject *Sender)
{
    // Library and Motion initialize.
    InitDeviceInformation();
}
//---------------------------------------------------------------------------

void __fastcall TFormAnalogInput::Button1Click(TObject *Sender)
{
    AxlClose();
    Close();
}
//---------------------------------------------------------------------------

void TFormAnalogInput::InitDeviceInformation()
{
    //++
    // Library initialize.
    if (AxlOpenNoReset(7) == AXT_RT_SUCCESS)
    {
        DWORD dwStatus;

        if (AxaInfoIsAIOModule(&dwStatus) == AXT_RT_SUCCESS)
        {
            if (dwStatus == STATUS_EXIST)
            {
                long	lModuleCounts;

                if (AxaInfoGetModuleCount(&lModuleCounts) == AXT_RT_SUCCESS)
                {
                    InitControl();
                }
                else
                {
                    ShowMessage("AI Module Not initialized.");
                }
            }
            else
            {
                ShowMessage("AI Module Not Exist.");

                return	;
            }
        }
        else
        {
            ShowMessage("AxaIsAIModule Error!!");

            return	;
        }
    }
    else
    {
        ShowMessage("Drive Not opend.");
        return	;
    }
}

void TFormAnalogInput::InitControl()
{
    short i, j;

    m_AICH[0] = m_chkChannel1;
    m_AICH[1] = m_chkChannel2;
    m_AICH[2] = m_chkChannel3;
    m_AICH[3] = m_chkChannel4;
    m_AICH[4] = m_chkChannel5;
    m_AICH[5] = m_chkChannel6;
    m_AICH[6] = m_chkChannel7;
    m_AICH[7] = m_chkChannel8;

    m_AIVoltRange[0] = m_cbVoltagerange1;
    m_AIVoltRange[1] = m_cbVoltagerange2;
    m_AIVoltRange[2] = m_cbVoltagerange3;
    m_AIVoltRange[3] = m_cbVoltagerange4;
    m_AIVoltRange[4] = m_cbVoltagerange5;
    m_AIVoltRange[5] = m_cbVoltagerange6;
    m_AIVoltRange[6] = m_cbVoltagerange7;
    m_AIVoltRange[7] = m_cbVoltagerange8;

    // In/Output Volt Range
    char szVoltRange[][10]={"-10V~10V"};
    for(i = 0; i < 8; i++)
    {
        for(j = 0; j < 1; j++)
        {
            m_AIVoltRange[i]->Items->Add(szVoltRange[j]);
        }
        m_AIVoltRange[i]->ItemIndex = 0;
    }

    // String Grid
    m_lstAIData->Col = 8;
    m_lstAIData->Cells[0][0] = "No.";
    m_lstAIData->Cells[1][0] = "CH #0";
    m_lstAIData->Cells[2][0] = "CH #1";
    m_lstAIData->Cells[3][0] = "CH #2";
    m_lstAIData->Cells[4][0] = "CH #3";
    m_lstAIData->Cells[5][0] = "CH #4";
    m_lstAIData->Cells[6][0] = "CH #5";
    m_lstAIData->Cells[7][0] = "CH #6";
    m_lstAIData->Cells[8][0] = "CH #7";

    long    lModuleCount;
    if (AxaInfoGetModuleCount(&lModuleCount) == AXT_RT_SUCCESS)
    {
        long	lBoardNo;
        long	lModulePos;
        DWORD	dwModuleID;
        String	strData;
        int     nCount = 0;

        for (i = 0; i < lModuleCount; i++)
        {
            if (AxaInfoGetModule(i, &lBoardNo, &lModulePos, &dwModuleID) == AXT_RT_SUCCESS)
            {
                if (dwModuleID == AXT_SIO_AI4RB)
                {
                    strData = "BoardNo = " + IntToStr(lBoardNo)+", " + "ModulePos = " + IntToStr(lModulePos);
                    m_cbModulenum->Items->Add(strData);
                    m_lAIModuleNum[nCount++] = i;
                }
            }
        }
    }
    m_cbModulenum->ItemIndex = 0;
}

BOOL ThreadProc(LPVOID lpData)
{
    FormAnalogInput->ThreadData();

    return TRUE;
}

void __fastcall TFormAnalogInput::m_btnStartClick(TObject *Sender)
{
    short   nTrig;
    short	nVoltRange, nDefaultVoltRange;
    double	dVoltRangeMin, dVoltRangeMax;
    short   i;

    m_lAICount= 1;

    if (m_cbModulenum->ItemIndex < 0)
    {
        ShowMessage("AI Module Not Selected!!");
        return;
    }

    // Get specified module position
    long lModuleNum = m_lAIModuleNum[m_cbModulenum->ItemIndex];

    if (m_bStart)
    {
        // Tread End
        m_bThread = false;

        m_btnStart->Caption = "Start(&S)";
        m_bStart = false;
    }
    else
    {
        // Set trigger mode
        AxaiSetTriggerMode(lModuleNum, 1);

        for(i = 0; i < 8; i++)
        {
            if(m_AICH[i]->Checked)
            {
                dVoltRangeMin = -10;
                dVoltRangeMax = 10;

                AxaiSetRange(i, dVoltRangeMin, dVoltRangeMax);      // Set Volt Range at will Input
            }
        }

        for(i = 1; i < m_lstAIData->RowCount; i++)
        {
            m_lstAIData->Rows[i]->Clear();
        }

        for (i = 0; i < 8; i++)
        {
            g_fChannelEvent[i] = FALSE;
        }

        // Thread Setting
        if (!m_bThread)
        {
            m_bThread	= TRUE;
            CreateThread(NULL, 0, (LPTHREAD_START_ROUTINE)ThreadProc, this, NULL, NULL);
        }
        m_btnStart->Caption = "Stop(&S)";
        m_bStart = true;
    }
}
//---------------------------------------------------------------------------

BOOL TFormAnalogInput::ThreadData()
{
    short   i = 0;
    double dInVolt;

    while(m_bThread)
    {
        if (m_lAICount > 1000)
            m_lAICount = 1;

        m_lstAIData->RowCount = m_lAICount;
        m_lstAIData->Cells[0][m_lAICount] = IntToStr(m_lAICount);

        for (i =0; i < 8;i++)
        {
            if(m_AICH[i]->Checked)
            {
                AxaiSwReadVoltage(i, &dInVolt);
                m_lstAIData->Cells[i+1][m_lAICount] = FloatToStr(dInVolt);
            }
        }
        m_lAICount++;

        // String Grid Auto Scroll Function
        if((m_lstAIData->TopRow + m_lstAIData->VisibleRowCount) < m_lstAIData->RowCount)
            m_lstAIData->TopRow = m_lstAIData->TopRow + m_lstAIData->VisibleRowCount;
    }

    m_bThread = false;

    return TRUE;
}

