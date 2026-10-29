//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "AOExample.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"
#pragma comment(lib, "AxL.lib")

TFormAnalogOutput *FormAnalogOutput;
//---------------------------------------------------------------------------
__fastcall TFormAnalogOutput::TFormAnalogOutput(TComponent* Owner)
        : TForm(Owner)
{
    m_bStart = false;
    m_lChannelCount = -1;
}
//---------------------------------------------------------------------------
void __fastcall TFormAnalogOutput::FormCreate(TObject *Sender)
{
    // Library and Motion initialize.
    InitDeviceInformation();
}
//---------------------------------------------------------------------------

void __fastcall TFormAnalogOutput::m_btnCloseClick(TObject *Sender)
{
    for (int i = 0; i < m_lChannelCount; i++)
    {
        AxaoWriteVoltage(i, 0);
    }

    AxlClose();
    Close();
}
//---------------------------------------------------------------------------

void TFormAnalogOutput::InitDeviceInformation()
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
                    ShowMessage("AO Module Not initialized.");
                }
            }
            else
            {
                ShowMessage("Module Not Exist.");

                return	;
            }
        }
        else
        {
            ShowMessage("AxaIsAOModule Error!!");

            return	;
        }
    }
    else
    {
        ShowMessage("Drive Not opend.");
        return	;
    }
}

void TFormAnalogOutput::InitControl()
{
    int i, j;

    m_AOCH[0] = m_chkChannel0;
    m_AOCH[1] = m_chkChannel1;
    m_AOCH[2] = m_chkChannel2;
    m_AOCH[3] = m_chkChannel3;

    m_AOModuleNum[0] = m_stcModulenum0;
    m_AOModuleNum[1] = m_stcModulenum1;
    m_AOModuleNum[2] = m_stcModulenum2;
    m_AOModuleNum[3] = m_stcModulenum3;

    m_AOModuleID[0] = m_stcModuleid0;
    m_AOModuleID[1] = m_stcModuleid1;
    m_AOModuleID[2] = m_stcModuleid2;
    m_AOModuleID[3] = m_stcModuleid3;

    m_AOWave[0]     = m_cbWave0;
    m_AOWave[1]     = m_cbWave1;
    m_AOWave[2]     = m_cbWave2;
    m_AOWave[3]     = m_cbWave3;

    m_AOPeriod[0]   = m_edtPeriod0;
    m_AOPeriod[1]   = m_edtPeriod1;
    m_AOPeriod[2]   = m_edtPeriod2;
    m_AOPeriod[3]   = m_edtPeriod3;

    m_AOVoltRange[0] = m_cbVRange0;
    m_AOVoltRange[1] = m_cbVRange1;
    m_AOVoltRange[2] = m_cbVRange2;
    m_AOVoltRange[3] = m_cbVRange3;

    m_AOValtage[0] = m_edtValtage0;
    m_AOValtage[1] = m_edtValtage1;
    m_AOValtage[2] = m_edtValtage2;
    m_AOValtage[3] = m_edtValtage3;

    m_AOValtageUpDown[0] = m_spnVoltage0;
    m_AOValtageUpDown[1] = m_spnVoltage1;
    m_AOValtageUpDown[2] = m_spnVoltage2;
    m_AOValtageUpDown[3] = m_spnVoltage3;

    // Interval
    m_cbGap->Items->Add("1ms");
    m_cbGap->Items->Add("5ms");
    m_cbGap->Items->Add("10ms");
    m_cbGap->ItemIndex = 0;

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
                if (dwModuleID == AXT_SIO_AO4RB)
                {
                    strData = "BoardNo = " + IntToStr(lBoardNo)+", " + "ModulePos = " + IntToStr(lModulePos);
                    m_cbModulenum->Items->Add(strData);
                    m_lAOModuleNum[nCount++] = i;
                }
            }
        }
    }
    m_cbModulenum->ItemIndex = 0;

    // In/Output Volt Range, Wave
    char szVoltRange[][10]={"-10V~10V"};
    char szWave[][10]={"Sin","Triangle","Rectangle","Volt"};
    for(i = 0; i < 4; i++)
    {
        m_AOVoltRange[i]->Items->Add(szVoltRange[0]);

        for(j = 0; j < 4; j++)
        {
            m_AOWave[i]->Items->Add(szWave[j]);
        }

        m_AOWave[i]->ItemIndex = 0;
        m_AOVoltRange[i]->ItemIndex = 0;
        m_AOValtageUpDown[i]->Min = -10;
        m_AOValtageUpDown[i]->Max = 10;
    }

    m_cbModulenumChange(0);
}

void __fastcall TFormAnalogOutput::m_btnStartClick(TObject *Sender)
{
    int i;
    double	dVoltRangeMin, dVoltRangeMax;

    if (m_lChannelCount < 0)
    {
        ShowMessage("AO Module Not Selected!!");
        return;
    }

    if (m_bStart)
    {
        Timer1->Enabled = false;

        m_btnStart->Caption = "Start(&S)";
        m_bStart = false;

        m_cbGap->Enabled = 1;
    }
    else
    {
        for(i = 0; i < 4; i++)
        {
            if(m_AOCH[i]->Checked)
            {
                dVoltRangeMin = -10;
                dVoltRangeMax = 10;

                AxaoSetRange(i, dVoltRangeMin, dVoltRangeMax);
            }
        }

        if (m_cbGap->ItemIndex)
            m_nGap = 5;
        else if (m_cbGap->ItemIndex == 2)
            m_nGap = 10;
        else
            m_nGap = 1;

        if(m_AOCH[0]->Checked == true || m_AOCH[1]->Checked == true ||
            m_AOCH[2]->Checked == true || m_AOCH[3]->Checked == true)
            Timer1->Enabled = true;

        m_btnStart->Caption = "Stop(&S)";
        m_bStart = true;

        m_cbGap->Enabled = 0;
    }
}
//---------------------------------------------------------------------------


void __fastcall TFormAnalogOutput::Timer1Timer(TObject *Sender)
{
    short			i, nIndex;
    double			dVRange;
    double			dValue;
    double			dPeriod;
    String			strPeriod, str;

    for (i = 0; i < m_lChannelCount;i++)
    {
        dVRange	= 10.0;

        nIndex = m_lAOIndex[i];
        dPeriod = StrToFloat(m_AOPeriod[i]->Text);

        if (m_lAOIndex[i] >= dPeriod)
            m_lAOIndex[i]	= 0;
        else
            m_lAOIndex[i] += m_nGap;

        if (m_AOCH[i]->Checked)
        {
            switch (m_AOWave[i]->ItemIndex)
            {
            case 0:		// Sin wave
                dPeriod	= (double)(dPeriod / 2.0);
                dValue	= (double)sin(nIndex * 3.141592 / dPeriod) * dVRange;

                AxaoWriteVoltage(i, dValue);
                break;

            case 1:		// Triangle wave
                // under the rise which the interval is big than 0 (case which the interval is 100 0 ~ 24)
                if (nIndex < dPeriod / 4.0)
                    dValue	= dVRange / (dPeriod / 4) * nIndex;

                // under the falling which the interval (case which the interval is 100 25 ~ 74)
                else if (nIndex < ((dPeriod / 4.0) * 3))
                    dValue	= (double)-((dVRange / (dPeriod / 4)) * nIndex) + dVRange * 2.0;

                // under the rise which the interval is small than 0 (case which the interval is 100 75 ~ 99)
                else
                    dValue	= (double)((dVRange / (dPeriod / 4)) * nIndex) - dVRange * 4.0;

                AxaoWriteVoltage(i, dValue);
                break;

            case 2:		// Rectangle wave
                // under the rise which the interval (case which the interval is 100 0 ~ 49)
                if (nIndex < dPeriod / 2.0)
                    dValue	= dVRange;

                // under the falling which the interval (case which the interval is 100 50 ~ 99)
                else
                    dValue	= -dVRange;

                AxaoWriteVoltage(i, dValue);
                break;

            case 3:    // Voltage
                AxaoWriteVoltage(i, StrToFloat(m_AOValtage[i]->Text));
                break;
            }
        }
    }
}
//---------------------------------------------------------------------------

void __fastcall TFormAnalogOutput::m_cbModulenumChange(TObject *Sender)
{
    long	lBoardNo, lModuleNum;
    long	lModulePos;
    DWORD	dwModuleID;
    String	strData;
    int     i, nCount = 0;
    long    lModuleCount;

    AxaoInfoGetChannelCount(&m_lChannelCount);
    for (i = 0; i < m_lChannelCount; i++)
    {
        AxaoSetRange(i, -5, 5);
        AxaoWriteVoltage(i, 0);

        m_AOModuleNum[i]->Caption = IntToStr(lModuleNum);
        m_AOModuleID[i]->Caption = FloatToStr(dwModuleID);
        m_lAOIndex[i] = 0;
    }
}
//---------------------------------------------------------------------------

void __fastcall TFormAnalogOutput::m_edtValtage0Change(TObject *Sender)
{
    if (m_cbWave0->ItemIndex == 3)
    {
        VoltageChange(0);
    }
}
//---------------------------------------------------------------------------

void __fastcall TFormAnalogOutput::m_edtValtage1Change(TObject *Sender)
{
    if (m_cbWave0->ItemIndex == 3)
    {
        VoltageChange(1);
    }
}
//---------------------------------------------------------------------------

void __fastcall TFormAnalogOutput::m_edtValtage2Change(TObject *Sender)
{
    if (m_cbWave0->ItemIndex == 3)
    {
        VoltageChange(2);
    }
}
//---------------------------------------------------------------------------

void __fastcall TFormAnalogOutput::m_edtValtage3Change(TObject *Sender)
{
    if (m_cbWave0->ItemIndex == 3)
    {
        VoltageChange(3);
    }
}
//---------------------------------------------------------------------------

void TFormAnalogOutput::VoltageChange(int ch)
{
    double dMaxValue, dMinValue, dVoltage;

    m_AOValtageUpDown[ch]->Min = -10;
    m_AOValtageUpDown[ch]->Max = 10;
    dMaxValue = 10;
    dMinValue = -10;

    dVoltage = StrToFloat(m_AOValtage[ch]->Text);
    if (dVoltage > dMaxValue)
    {
        dVoltage = dMaxValue;
        m_AOValtage[ch]->Text = FloatToStr(dMaxValue);
    }
    else if (dVoltage < dMinValue)
    {
        dVoltage = dMinValue;
        m_AOValtage[ch]->Text = FloatToStr(dMinValue);
    }

    if (m_AOCH[ch]->Checked)
        AxaoWriteVoltage(ch, dVoltage);
}

void __fastcall TFormAnalogOutput::m_cbVRange0Change(TObject *Sender)
{
    VRangeChange(0);
}
//---------------------------------------------------------------------------

void __fastcall TFormAnalogOutput::m_cbVRange1Change(TObject *Sender)
{
    VRangeChange(1);
}
//---------------------------------------------------------------------------

void __fastcall TFormAnalogOutput::m_cbVRange2Change(TObject *Sender)
{
    VRangeChange(2);
}
//---------------------------------------------------------------------------

void __fastcall TFormAnalogOutput::m_cbVRange3Change(TObject *Sender)
{
    VRangeChange(3);
}
//---------------------------------------------------------------------------

void TFormAnalogOutput::VRangeChange(int ch)
{
    AxaoSetRange(ch, -10, 10);

    m_AOValtage[ch]->Text = "0";
    AxaoWriteVoltage(ch, 0);
}

