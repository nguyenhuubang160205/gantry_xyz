//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "DIOExample.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"
#pragma comment(lib, "AxL.lib")
TForm1 *Form1;
//---------------------------------------------------------------------------
__fastcall TForm1::TForm1(TComponent* Owner)
        : TForm(Owner)
{
    m_hHandle = NULL;
    m_hInterrupt = NULL;
    m_bThread = FALSE;
}
//---------------------------------------------------------------------------

void __fastcall TForm1::FormCreate(TObject *Sender)
{
    m_in  = new TCheckBox*[IO_SU];
    m_out = new TCheckBox*[IO_SU];

    m_in[0] = m_chkHigh00;        m_out[0] = m_chkLow00;
    m_in[1] = m_chkHigh01;        m_out[1] = m_chkLow01;
    m_in[2] = m_chkHigh02;        m_out[2] = m_chkLow02;
    m_in[3] = m_chkHigh03;        m_out[3] = m_chkLow03;
    m_in[4] = m_chkHigh04;        m_out[4] = m_chkLow04;
    m_in[5] = m_chkHigh05;        m_out[5] = m_chkLow05;
    m_in[6] = m_chkHigh06;        m_out[6] = m_chkLow06;
    m_in[7] = m_chkHigh07;        m_out[7] = m_chkLow07;
    m_in[8] = m_chkHigh08;        m_out[8] = m_chkLow08;
    m_in[9] = m_chkHigh09;        m_out[9] = m_chkLow09;
    m_in[10] = m_chkHigh10;       m_out[10] = m_chkLow10;
    m_in[11] = m_chkHigh11;       m_out[11] = m_chkLow11;
    m_in[12] = m_chkHigh12;       m_out[12] = m_chkLow12;
    m_in[13] = m_chkHigh13;       m_out[13] = m_chkLow13;
    m_in[14] = m_chkHigh14;       m_out[14] = m_chkLow14;
    m_in[15] = m_chkHigh15;       m_out[15] = m_chkLow15;

    // Library and Motion initialize.
    if(OpenDevice())
    {
        m_cbModuleChange(0);

        Timer1->Enabled = true;
    }
}
//---------------------------------------------------------------------------
BOOL TForm1::OpenDevice()
{
    //++
    // Library initialize.
    if (AxlOpen(7) == AXT_RT_SUCCESS)
    {
        DWORD dwStatus;

        if (AxdInfoIsDIOModule(&dwStatus) == AXT_RT_SUCCESS)
        {
            if (dwStatus == STATUS_EXIST)
            {
                long	lModuleCounts;
                if (AxdInfoGetModuleCount(&lModuleCounts) == AXT_RT_SUCCESS)
                {
                    short	i;
                    long	lBoardNo;
                    long	lModulePos;
                    DWORD	dwModuleID;
                    String	strData;
                    char szModuleName[50] = "";

                    for (i = 0; i < lModuleCounts; i++)
                    {
                        if (AxdInfoGetModule(i, &lBoardNo, &lModulePos, &dwModuleID) == AXT_RT_SUCCESS)
                        {
                            switch (dwModuleID)
                            {
                            case AXT_SIO_DI32:          strData = strData.Format("[BD No:%d - MD No:%d] SIO-DI32", ARRAYOFCONST(((int)lBoardNo, i))); 	break;
                            case AXT_SIO_DO32P:         strData = strData.Format("[BD No:%d - MD No:%d] SIO-DO32P", ARRAYOFCONST(((int)lBoardNo, i))); 	break;
                            case AXT_SIO_DB32P:         strData = strData.Format("[BD No:%d - MD No:%d] SIO-DB32P", ARRAYOFCONST(((int)lBoardNo, i))); 	break;
                            case AXT_SIO_DO32T:         strData = strData.Format("[BD No:%d - MD No:%d] SIO-DO32T", ARRAYOFCONST(((int)lBoardNo, i))); 	break;
                            case AXT_SIO_DB32T:         strData = strData.Format("[BD No:%d - MD No:%d] SIO-DB32T", ARRAYOFCONST(((int)lBoardNo, i))); 	break;
                            case AXT_SIO_RDI32:         strData = strData.Format("[BD No:%d - MD No:%d] SIO_RDI32", ARRAYOFCONST(((int)lBoardNo, i))); 	break;
                            case AXT_SIO_RDO32:         strData = strData.Format("[BD No:%d - MD No:%d] SIO_RDO32", ARRAYOFCONST(((int)lBoardNo, i))); 	break;
                            case AXT_SIO_RDB128MLII:    strData = strData.Format("[BD No:%d - MD No:%d] SIO_RDB128MLII", ARRAYOFCONST(((int)lBoardNo, i))); 	break;
                            case AXT_SIO_RSIMPLEIOMLII: strData = strData.Format("[BD No:%d - MD No:%d] SIO_RSIMPLEIOMLII", ARRAYOFCONST(((int)lBoardNo, i))); 	break;
                            case AXT_SIO_RDI16MLII:     strData = strData.Format("[BD No:%d - MD No:%d] SIO_RDI16MLII", ARRAYOFCONST(((int)lBoardNo, i))); 	break;
                            case AXT_SIO_RDO16AMLII:    strData = strData.Format("[BD No:%d - MD No:%d] SIO_RDO16AMLII", ARRAYOFCONST(((int)lBoardNo, i))); 	break;
                            case AXT_SIO_RDO16BMLII:    strData = strData.Format("[BD No:%d - MD No:%d] SIO_RDO16BMLII", ARRAYOFCONST(((int)lBoardNo, i))); 	break;
                            case AXT_SIO_RDB96MLII:     strData = strData.Format("[BD No:%d - MD No:%d] SIO_RDB96MLII", ARRAYOFCONST(((int)lBoardNo, i))); 	break;
                            case AXT_SIO_RDO32RTEX:     strData = strData.Format("[BD No:%d - MD No:%d] SIO_RDO32RTEX", ARRAYOFCONST(((int)lBoardNo, i))); 	break;
                            case AXT_SIO_RDI32RTEX:     strData = strData.Format("[BD No:%d - MD No:%d] SIO_RDI32RTEX", ARRAYOFCONST(((int)lBoardNo, i))); 	break;
                            case AXT_SIO_RDB32RTEX:     strData = strData.Format("[BD No:%d - MD No:%d] SIO_RDB32RTEX", ARRAYOFCONST(((int)lBoardNo, i))); 	break;
                            case AXT_SIO_DI32_P:        strData = strData.Format("[BD No:%d - MD No:%d] SIO_SIO_DI32_P", ARRAYOFCONST(((int)lBoardNo, i))); 	break;
                            case AXT_SIO_DO32T_P:       strData = strData.Format("[BD No:%d - MD No:%d] SIO_SIO_DO32T_P", ARRAYOFCONST(((int)lBoardNo, i))); 	break;
                            case AXT_SIO_RDB32T:        strData = strData.Format("[BD No:%d - MD No:%d] SIO_RDB32T", ARRAYOFCONST(((int)lBoardNo, i))); 	break;
                            case AXT_ECAT_DIO:
                                {
                                    AxdInfoGetModuleEx(i, NULL, szModuleName, NULL);
                                    strData = strData.Format("[BD No:%d - MD No:%d] %s", ARRAYOFCONST(((int)lBoardNo, i, szModuleName)));
                                    break;
                                }
                            }
                            m_cbModule->Items->Add(strData);
                        }
                    }
                }
                m_cbModule->ItemIndex = 0;
            }
            else
            {
                ShowMessage("Module does not exist.");
                return	FALSE;
            }
        }
        else
        {
            ShowMessage("AxdInfoIsDIOModule Error!!"); 
            return	FALSE;
        }
    }
    else
    {
        ShowMessage("Open Error!");   
        return	FALSE;
    }

    return	TRUE;
}

void __fastcall TForm1::m_cbModuleChange(TObject *Sender)
{
    long	lModuleCounts;
    AxdInfoGetModuleCount(&lModuleCounts);
    if (lModuleCounts > 0)
    {
        long	lBoardNo;
        long	lModulePos;
        DWORD	dwModuleID;
        short	nIndex;
        DWORD	dwDataHigh;
        DWORD	dwDataLow;
        BOOL	bFlagHigh;
        BOOL	bFlagLow;
        DWORD	dwUse, dwInterrupt;
        String	strData;
        long	lInCount = 0, lOutCount = 0;

        AxdInfoGetModule(m_cbModule->ItemIndex, &lBoardNo, &lModulePos, &dwModuleID);
        switch (dwModuleID)
        {
        case AXT_SIO_DI32:
        case AXT_SIO_RDI32:
        case AXT_SIO_RDI16MLII:
        case AXT_SIO_RDI32RTEX:
        case AXT_SIO_DI32_P:
            m_stcHIGH->Caption = "INPUT 0Bit ~ 15Bit";
            m_stcLOW->Caption = "INPUT 16Bit ~ 31Bit";

            if(dwModuleID == AXT_SIO_RDI32){
                m_chkInterrupt->Enabled = false;
                m_chkRising->Enabled = false;
                m_chkFalling->Enabled = false;
                m_rdoMessage->Enabled = false;
                m_rdoCallback->Enabled = false;
                m_rdoEvent->Enabled = false;
            }else{
                m_chkInterrupt->Enabled = true;
                m_chkRising->Enabled = true;
                m_chkFalling->Enabled = true;
                m_rdoMessage->Enabled = true;
                m_rdoCallback->Enabled = true;
                m_rdoEvent->Enabled = true;

                AxdiInterruptGetModuleEnable(m_cbModule->ItemIndex, &dwInterrupt);
                m_chkInterrupt->Checked = dwInterrupt;

                AxdiInterruptEdgeGetWord(m_cbModule->ItemIndex, 0, UP_EDGE, &dwDataHigh);
                if (dwDataHigh == 0xFFFF)	m_chkRising->Checked = true;
                else                        m_chkRising->Checked = false;

				AxdiInterruptEdgeGetWord(m_cbModule->ItemIndex, 0, DOWN_EDGE, &dwDataHigh);
				if (dwDataHigh == 0xFFFF)	m_chkFalling->Checked = true;
				else    					m_chkFalling->Checked = false;
            }
            for (nIndex = 0; nIndex < 16; nIndex++)
            {
                m_in[nIndex]->Caption = IntToStr(nIndex);
                m_out[nIndex]->Caption = IntToStr(nIndex + 16);
            }
            break;

        case AXT_SIO_DO32P:
        case AXT_SIO_DO32T:
        case AXT_SIO_RDO32:
            m_stcHIGH->Caption = "OUTPUT 0Bit ~ 15Bit";
            m_stcLOW->Caption = "OUTPUT 16Bit ~ 31Bit";

            m_chkInterrupt->Enabled = false;
            m_chkRising->Enabled = false;
            m_chkFalling->Enabled = false;
            m_rdoMessage->Enabled = false;
            m_rdoCallback->Enabled = false;
            m_rdoEvent->Enabled = false;

            // Read the signal to become output to WORD.
            AxdoReadOutportWord(m_cbModule->ItemIndex, 0, &dwDataHigh);
            AxdoReadOutportWord(m_cbModule->ItemIndex, 1, &dwDataLow);

            for (nIndex = 0; nIndex < 16; nIndex++)
            {
                // Confirm a last bit price of data to read.
                bFlagHigh	= dwDataHigh & 0x0001;
                bFlagLow	= dwDataLow & 0x0001;

                // One bit does Shift to right.
                dwDataHigh	= dwDataHigh >> 1;
                dwDataLow	= dwDataLow >> 1;

                // Update orders a bit price at Control.
                m_in[nIndex]->Checked = bFlagHigh;
                m_out[nIndex]->Checked = bFlagLow;

                m_in[nIndex]->Caption = IntToStr(nIndex);
                m_out[nIndex]->Caption = IntToStr(nIndex + 16);
            }
            break;

        case AXT_SIO_DB32P:
        case AXT_SIO_DB32T:
        case AXT_SIO_RDB128MLII:
            m_stcHIGH->Caption = "INPUT 0Bit ~ 15Bit";
            m_stcLOW->Caption = "OUTPUT 0Bit ~ 15Bit";

            m_chkInterrupt->Enabled = true;
            m_chkRising->Enabled = true;
            m_chkFalling->Enabled = true;
            m_rdoMessage->Enabled = true;
            m_rdoCallback->Enabled = true;
            m_rdoEvent->Enabled = true;

            AxdiInterruptGetModuleEnable(m_cbModule->ItemIndex, &dwInterrupt);
            m_chkInterrupt->Checked = dwInterrupt;

            AxdiInterruptEdgeGetWord(m_cbModule->ItemIndex, 0, UP_EDGE, &dwDataHigh);
            if (dwDataHigh == 0xFFFF)	m_chkRising->Checked = true;
            else                        m_chkRising->Checked = false;

			AxdiInterruptEdgeGetWord(m_cbModule->ItemIndex, 0, DOWN_EDGE, &dwDataHigh);
			if (dwDataHigh == 0xFFFF)	m_chkFalling->Checked = true;
			else    					m_chkFalling->Checked = false;

            // Read the signal to become output to WORD.
            AxdiReadInportWord(m_cbModule->ItemIndex, 0, &dwDataHigh);
            AxdoReadOutportWord(m_cbModule->ItemIndex, 0, &dwDataLow);
            for (nIndex = 0; nIndex < 16; nIndex++)
            {
                // Confirm a last bit price of data to read.
                bFlagLow	= dwDataLow & 0x0001;
                bFlagHigh	= dwDataHigh & 0x0001;

                // One bit does Shift to right.
                dwDataLow	= dwDataLow >> 1;
                dwDataHigh	= dwDataHigh >> 1;

                // Update orders a bit price at Control.
                m_in[nIndex]->Checked = bFlagHigh;
                m_out[nIndex]->Checked = bFlagLow;

                m_in[nIndex]->Caption = IntToStr(nIndex);
                m_out[nIndex]->Caption = IntToStr(nIndex);
            }
            break;

        case AXT_ECAT_DIO:
                AxdInfoGetInputCount(m_cbModule->ItemIndex, &lInCount);
                AxdInfoGetOutputCount(m_cbModule->ItemIndex, &lOutCount);

                if (lInCount > 16)
                {
                    m_stcHIGH->Caption = "INPUT  0bit ~ 15Bit";
                    m_stcLOW->Caption  = "INPUT 16bit ~ 31Bit";

                    for (nIndex = 0; nIndex < 16; nIndex++)
                    {
                        m_out[nIndex]->Enabled = false;
                        m_out[nIndex]->Caption = IntToStr(nIndex+16);
                    }
                    for (nIndex = 0; nIndex < 16; nIndex++)
                    {
                        m_in[nIndex]->Enabled = false;
                    }
                }
                else if (lInCount > 0)
                {
                    m_stcHIGH->Caption = "INPUT  0bit ~ 15Bit";
                    for (nIndex = 0; nIndex < 16; nIndex++)
                    {
                        m_in[nIndex]->Enabled = false;
                    }

                    if (lOutCount > 0)
                    {
                        m_stcLOW->Caption = "OUTPUT  0bit ~ 15Bit";

                        AxdoReadOutportWord(m_cbModule->ItemIndex, 0, &dwDataLow);
                        for (nIndex = 0; nIndex < 16; nIndex++)
                    {
                            m_out[nIndex]->Enabled  = true;
                            m_out[nIndex]->Caption = IntToStr(nIndex);
                        }
                    }
                    else
                    {
                        m_stcLOW->Caption = "";
                    }
                }
                else
                {
                    if (lOutCount > 16)
                    {
                        m_stcHIGH->Caption = "OUTPUT  0bit ~ 15Bit";
                        m_stcLOW->Caption = "OUTPUT 16bit ~ 31Bit";

                        AxdoReadOutportWord(m_cbModule->ItemIndex, 0, &dwDataHigh);
                        AxdoReadOutportWord(m_cbModule->ItemIndex, 1, &dwDataLow);

                        for (nIndex = 0; nIndex < 16; nIndex++)
                        {
                            m_in[nIndex]->Checked = true;
                        }

                        for (nIndex = 0; nIndex < 16; nIndex++)
                        {
                            m_out[nIndex]->Checked = true;
                            m_out[nIndex]->Caption = IntToStr(nIndex+16);
                        }
                    }
                    else if(lOutCount > 0)
                    {
                        m_stcHIGH->Caption = "OUTPUT  0bit ~ 15Bit";
                        m_stcLOW->Caption = "";
                        AxdoReadOutportWord(m_cbModule->ItemIndex, 0, &dwDataHigh);

                        for (nIndex = 0; nIndex < 16; nIndex++)
                        {
                            m_in[nIndex]->Checked = true;
                        }
                    }
                }

                m_chkInterrupt->Enabled = false;
                m_chkRising->Enabled = false;
                m_chkFalling->Enabled = false;
                m_rdoMessage->Enabled = false;
                m_rdoCallback->Enabled = false;
                m_rdoEvent->Enabled = false;

                for (nIndex = 0; nIndex < 16; nIndex++)
                {
                    // Verify the last bit value of data read
                    bFlagLow	= dwDataLow & 0x0001;
                    bFlagHigh	= dwDataHigh & 0x0001;

                    // Shift rightward by bit by bit
                    dwDataLow	= dwDataLow >> 1;
                    dwDataHigh	= dwDataHigh >> 1;

                    // Updat bit value in control
                    if (bFlagLow == 1)
                        m_out[nIndex]->Checked	= true;
                    else
                        m_out[nIndex]->Checked	= false;
                    if (lOutCount  > 16)
                    {
                        if (bFlagHigh == 1)
                            m_in[nIndex]->Checked = true;
                        else
                            m_in[nIndex]->Checked = false;
                    }
                }
                break;
        }
    }
}
//---------------------------------------------------------------------------

void __fastcall TForm1::Timer1Timer(TObject *Sender)
{
    short		nIndex;
    DWORD		dwDataHigh;
    DWORD		dwDataLow;
    BOOL		bFlagHigh;
    BOOL		bFlagLow;
    long		lBoardNo;
    long		lModulePos;
    DWORD		dwModuleID;
    long        lCount = 0;

    AxdInfoGetModule(m_cbModule->ItemIndex, &lBoardNo, &lModulePos, &dwModuleID);

    switch (dwModuleID)
    {
    case AXT_SIO_DI32:
    case AXT_SIO_RDI32:
    case AXT_SIO_RDI16MLII:
    case AXT_SIO_RDI32RTEX:
    case AXT_SIO_DI32_P:
        //++
        // Read the signal to become input to WORD.
        AxdiReadInportWord(m_cbModule->ItemIndex, 0, &dwDataHigh);
        AxdiReadInportWord(m_cbModule->ItemIndex, 1, &dwDataLow);

        for (nIndex = 0; nIndex < 16; nIndex++)
        {
            // Confirm a last bit price of data to read.
            bFlagHigh	= dwDataHigh & 0x0001;
            bFlagLow	= dwDataLow & 0x0001;

            // One bit does Shift to right.
            dwDataHigh	= dwDataHigh >> 1;
            dwDataLow	= dwDataLow >> 1;

            // Update orders a bit price at Control.
            m_in[nIndex]->Checked = bFlagHigh;
            m_out[nIndex]->Checked = bFlagLow;
        }
        break;
    case AXT_SIO_DB32P:
    case AXT_SIO_DB32T:
    case AXT_SIO_RDB32RTEX:
    case AXT_SIO_RDB32T:
    case AXT_SIO_RDB96MLII:
    case AXT_SIO_RDB128MLII:
    case AXT_SIO_RSIMPLEIOMLII:
        //++
        // Read the signal to become input to WORD.
        AxdiReadInportWord(m_cbModule->ItemIndex, 0, &dwDataHigh);

        for (nIndex = 0; nIndex < 16; nIndex++)
        {
            // Confirm a last bit price of data to read.
            bFlagHigh	= dwDataHigh & 0x0001;

            // One bit does Shift to right.
            dwDataHigh	= dwDataHigh >> 1;

            // Update orders a bit price at Control.
            m_in[nIndex]->Checked = bFlagHigh;
        }
        break;
    case AXT_ECAT_DIO:
            // Read input connect
            AxdInfoGetInputCount(m_cbModule->ItemIndex, &lCount);

            if(lCount > 0)
            {
                AxdiReadInportWord(m_cbModule->ItemIndex, 0, &dwDataHigh);
                AxdiReadInportWord(m_cbModule->ItemIndex, 1, &dwDataLow);

                for (nIndex = 0; nIndex < 16; nIndex++)
                {
                    // Verify the last bit value of data read
                    bFlagHigh	= dwDataHigh & 0x0001;
                    bFlagLow	= dwDataLow & 0x0001;

                    // Shift rightward by bit by bit
                    dwDataHigh	= dwDataHigh >> 1;
                    dwDataLow	= dwDataLow >> 1;

                    // Updat bit value in control
                    if (bFlagHigh == 1)
                        m_in[nIndex]->Checked = true;
                    else
                        m_in[nIndex]->Checked = false;
                    if (lCount > 16)
                    {
                        if (bFlagLow  == 1)
                            m_out[nIndex]->Checked = true;
                        else
                            m_out[nIndex]->Checked = false;
                    }
                }
            }
            break;
    }
}
//---------------------------------------------------------------------------

void __fastcall TForm1::m_btnCloseClick(TObject *Sender)
{
    // Confirmes whether the library is possible the utility.
    if (AxlIsOpened())
    {
        AxlClose();
        Close();
    }
    else
    {
        Close();
    }
}
//---------------------------------------------------------------------------

void __fastcall TForm1::FormDestroy(TObject *Sender)
{
    if(m_in != NULL)
    {
        delete[] m_in;
	}

    if(m_out != NULL)
    {
        delete[] m_out;
    }
}
//---------------------------------------------------------------------------

//++
// Event in click the collation box in the output case to happen.
void __fastcall TForm1::m_chkHighClick(TObject *Sender)
{
    long	lModuleCounts;
    TCheckBox *chkBox;

    AxdInfoGetModuleCount(&lModuleCounts);

    if (lModuleCounts > 0)
    {
        long	lBoardNo;
        long	lModulePos;
        DWORD	dwModuleID;
        long 	lCount = 0;

        AxdInfoGetModule(m_cbModule->ItemIndex, &lBoardNo, &lModulePos, &dwModuleID);

        switch (dwModuleID)
        {
        case AXT_SIO_DO32P:
        case AXT_SIO_DO32T:
        case AXT_SIO_RDO32:
            chkBox = (TCheckBox *)Sender;

            AxdoWriteOutportBit(m_cbModule->ItemIndex, chkBox->Tag, m_in[chkBox->Tag]->Checked);
            break;
        case AXT_ECAT_DIO:
            AxdInfoGetOutputCount(m_cbModule->ItemIndex, &lCount);
            if(lCount > 0)
            {
                chkBox = (TCheckBox *) Sender;

                AxdoWriteOutportBit(m_cbModule->ItemIndex, chkBox->Tag, m_in[chkBox->Tag]->Checked);
            }
            break;
        }
    }
}
//---------------------------------------------------------------------------

void __fastcall TForm1::m_chkLowClick(TObject *Sender)
{
    long	lModuleCounts;
    TCheckBox *chkBox;

    AxdInfoGetModuleCount(&lModuleCounts);

    if (lModuleCounts > 0)
    {
        long	lBoardNo;
        long	lModulePos;
        DWORD	dwModuleID;
        long 	lCount = 0;

        AxdInfoGetModule(m_cbModule->ItemIndex, &lBoardNo, &lModulePos, &dwModuleID);

        switch (dwModuleID)
        {
        case AXT_SIO_DB32P:
        case AXT_SIO_DB32T:
		case AXT_SIO_RDB128MLII:
            chkBox = (TCheckBox *)Sender;
            AxdoWriteOutportBit(m_cbModule->ItemIndex, chkBox->Tag , m_out[chkBox->Tag]->Checked);
			break;
        case AXT_SIO_DO32P:
        case AXT_SIO_DO32T:
        case AXT_SIO_RDO32:
            chkBox = (TCheckBox *)Sender;
            AxdoWriteOutportBit(m_cbModule->ItemIndex, chkBox->Tag+16, m_out[chkBox->Tag]->Checked);
            break;
        case AXT_ECAT_DIO:
            AxdInfoGetOutputCount(m_cbModule->ItemIndex, &lCount);
            if(lCount > 16)
            {
                chkBox = (TCheckBox *)Sender;
                AxdoWriteOutportBit(m_cbModule->ItemIndex, chkBox->Tag+16, m_out[chkBox->Tag]->Checked);
            }
            else if (lCount > 0)
           {
                chkBox = (TCheckBox *)Sender;
                AxdoWriteOutportBit(m_cbModule->ItemIndex, chkBox->Tag, m_out[chkBox->Tag]->Checked);
           }
            break;
       }
    }
}
//---------------------------------------------------------------------------

void __fastcall TForm1::m_btnClearClick(TObject *Sender)
{
    m_lstInterrupt->Clear();
}
//---------------------------------------------------------------------------

void __fastcall TForm1::m_chkInterruptClick(TObject *Sender)
{
    long	lModuleCounts;
	AxdInfoGetModuleCount(&lModuleCounts);
	if (lModuleCounts > 0)
	{
		long	lBoardNo;
		long	lModulePos;
		DWORD	dwModuleID;

		AxdInfoGetModule(m_cbModule->ItemIndex, &lBoardNo, &lModulePos, &dwModuleID);
		switch (dwModuleID)
		{
		case AXT_SIO_DI32:
		case AXT_SIO_DB32P:
		case AXT_SIO_DB32T:
			if (m_chkInterrupt->Checked)
            {
                AxlInterruptEnable();
				AxdiInterruptSetModuleEnable(m_cbModule->ItemIndex, ENABLE);
            }
			else
			{
				AxdiInterruptSetModuleEnable(m_cbModule->ItemIndex, DISABLE);
				AxdiInterruptSetModule(m_cbModule->ItemIndex, Form1->Handle, NULL, NULL, NULL); // Interrupt method release.
                AxlInterruptDisable();
			}
			break;

		default:
			m_chkInterrupt->Checked = false;
			break;
		}
	}
}
//---------------------------------------------------------------------------

void __fastcall TForm1::m_chkRisingClick(TObject *Sender)
{
    long	lModuleCounts;
	AxdInfoGetModuleCount(&lModuleCounts);
	if (lModuleCounts > 0)
	{
		long	lBoardNo;
		long	lModulePos;
		DWORD	dwModuleID;

		AxdInfoGetModule(m_cbModule->ItemIndex, &lBoardNo, &lModulePos, &dwModuleID);
		switch (dwModuleID)
		{
		case AXT_SIO_DI32:
			if (m_chkRising->Checked)
			{
				AxdiInterruptEdgeSetWord(m_cbModule->ItemIndex, 0, UP_EDGE, 0xFFFF);
				AxdiInterruptEdgeSetWord(m_cbModule->ItemIndex, 1, UP_EDGE, 0xFFFF);
			}
			else
			{
				AxdiInterruptEdgeSetWord(m_cbModule->ItemIndex, 0, UP_EDGE, 0x0000);
				AxdiInterruptEdgeSetWord(m_cbModule->ItemIndex, 1, UP_EDGE, 0x0000);
			}
			break;

		case AXT_SIO_DB32P:
		case AXT_SIO_DB32T:
			if (m_chkRising->Checked)
			{
				AxdiInterruptEdgeSetWord(m_cbModule->ItemIndex, 0, UP_EDGE, 0xFFFF);
			}
			else
			{
				AxdiInterruptEdgeSetWord(m_cbModule->ItemIndex, 0, UP_EDGE, 0x0000);
			}
			break;

		default:
			m_chkRising->Checked = false;
			break;
		}
	}
}
//---------------------------------------------------------------------------

void __fastcall TForm1::m_chkFallingClick(TObject *Sender)
{
    long	lModuleCounts;
	AxdInfoGetModuleCount(&lModuleCounts);
	if (lModuleCounts > 0)
	{
		long	lBoardNo;
		long	lModulePos;
		DWORD	dwModuleID;

		AxdInfoGetModule(m_cbModule->ItemIndex, &lBoardNo, &lModulePos, &dwModuleID);
		switch (dwModuleID)
		{
		case AXT_SIO_DI32:
			if (m_chkFalling->Checked)
			{
				AxdiInterruptEdgeSetWord(m_cbModule->ItemIndex, 0, DOWN_EDGE, 0xFFFF);
				AxdiInterruptEdgeSetWord(m_cbModule->ItemIndex, 1, DOWN_EDGE, 0xFFFF);
			}
			else
			{
				AxdiInterruptEdgeSetWord(m_cbModule->ItemIndex, 0, DOWN_EDGE, 0x0000);
				AxdiInterruptEdgeSetWord(m_cbModule->ItemIndex, 1, DOWN_EDGE, 0x0000);
			}
			break;

		case AXT_SIO_DB32P:
		case AXT_SIO_DB32T:
			if (m_chkFalling->Checked)
			{
				AxdiInterruptEdgeSetWord(m_cbModule->ItemIndex, 0, DOWN_EDGE, 0xFFFF);
			}
			else
			{
				AxdiInterruptEdgeSetWord(m_cbModule->ItemIndex, 0, DOWN_EDGE, 0x0000);
			}
			break;

		default:
			m_chkFalling->Checked = false;
			break;
		}	
	}
}
//---------------------------------------------------------------------------
void __fastcall TForm1::m_rdoMessageClick(TObject *Sender)
{
    AxdiInterruptSetModule(m_cbModule->ItemIndex, Form1->Handle, NULL, NULL, NULL); // Interrupt method release.
	AxdiInterruptSetModuleEnable(m_cbModule->ItemIndex, DISABLE);
	if (m_hHandle)
	{
		WaitForSingleObject(m_hHandle, WAIT_ABANDONED);
		CloseHandle(m_hHandle);
		m_bThread	= NULL;
		m_hHandle	= NULL;
	}

	AxdiInterruptSetModuleEnable(m_cbModule->ItemIndex, ENABLE);
	AxdiInterruptSetModule(m_cbModule->ItemIndex, Form1->Handle, WM_AXL_INTERRUPT, NULL, NULL);
}
//---------------------------------------------------------------------------
void __fastcall TForm1::m_rdoCallbackClick(TObject *Sender)
{
    AxdiInterruptSetModule(m_cbModule->ItemIndex, Form1->Handle, NULL, NULL, NULL); // Interrupt method release.
	AxdiInterruptSetModuleEnable(m_cbModule->ItemIndex, DISABLE);

	if (m_hHandle)
	{
		WaitForSingleObject(m_hHandle, WAIT_ABANDONED);
		CloseHandle(m_hHandle);
		m_bThread	= NULL;
		m_hHandle	= NULL;
	}

	AxdiInterruptSetModuleEnable(m_cbModule->ItemIndex, ENABLE);
	AxdiInterruptSetModule(m_cbModule->ItemIndex, 0, 0, InterruptCallback, NULL);
}
//---------------------------------------------------------------------------

BOOL ThreadProc(LPVOID lpData)
{
	Form1->ThreadData();

	return TRUE;
}

void __fastcall TForm1::m_rdoEventClick(TObject *Sender)
{
    AxdiInterruptSetModule(m_cbModule->ItemIndex, Form1->Handle, NULL, NULL, NULL); // Interrupt method release.
	AxdiInterruptSetModuleEnable(m_cbModule->ItemIndex, DISABLE);

	AxdiInterruptSetModuleEnable(m_cbModule->ItemIndex, ENABLE);
	AxdiInterruptSetModule(m_cbModule->ItemIndex, NULL, NULL, NULL, &m_hInterrupt);

	if (m_hHandle)
	{
		WaitForSingleObject(m_hHandle, WAIT_ABANDONED);
		CloseHandle(m_hHandle);
		m_bThread	= NULL;
		m_hHandle	= NULL;
	}

	if (!m_bThread)
   	{
        m_bThread	= TRUE;
        m_hHandle	= CreateThread(NULL, 0, (LPTHREAD_START_ROUTINE)ThreadProc, this, NULL, NULL);
    }
}
//---------------------------------------------------------------------------

// Interrupt message
void TForm1::OnInterruptMessage(TMessage Msg)
{
    int nModule		= Msg.WParamLo;	// Interrupt occurrence module number. ( 0, 1, 2, 3)
	int nIntrFlag	= Msg.LParam;	// Interrupt occurrence Flag (Interrupt occurrence authenticate in Input Port.)
	String			strInt;
	DWORD			dwValue;

	for (int i = 0; i < 4; i++)
	{
		for (int j = 0; j < 8; j++)
		{
			if (((nIntrFlag >> (i * 8))>> j)& 0x01)
			{
				AxdiReadInportBit(nModule, ((i * 8)+ j), &dwValue);
				if (dwValue)
                    strInt = "[Message] ¡ãRising Int Set Bit " + IntToStr((i * 8)+ j);
				else
                    strInt = "[Message] ¡åFalling Int Set Bit " + IntToStr((i * 8)+ j);

                m_lstInterrupt->Items->Add(strInt);
			}
		}
	}
}

BOOL TForm1::ThreadData()
{
	while(m_bThread)
	{
		if (WaitForSingleObject(m_hInterrupt, INFINITE) == WAIT_OBJECT_0)
		{
			long	lModuleNo;
			DWORD	dwFlag;
			String	strInt;
			DWORD	dwValue;

			AxdiInterruptRead(&lModuleNo, &dwFlag);

			for (int i = 0; i < 4; i++)
			{
				for (int j = 0; j < 8; j++)
				{
					if (((dwFlag >> (i * 8)) >> j)& 0x01)
					{
						AxdiReadInportBit(lModuleNo, ((i * 8)+ j), &dwValue);

						if (dwValue)
                            strInt = "[Event] ¡ãRising Int Set Bit " + IntToStr((i * 8)+ j);
                		else
                            strInt = "[Event] ¡åFalling Int Set Bit " + IntToStr((i * 8)+ j);

                        m_lstInterrupt->Items->Add(strInt);
                    }
                }
			}
		}
	}

	return TRUE;
}

// Interrupt callback
void __stdcall InterruptCallback (long lActiveNo, DWORD uFlag)
{	
	String  strInt;
	DWORD   dwValue;

	for (int i = 0; i < 4; i++)
	{
		for (int j = 0; j < 8; j++)
		{
			if (((uFlag >> (i * 8))>> j)& 0x01)
			{
				AxdiReadInportBit(lActiveNo, ((i * 8)+ j), &dwValue);

				if (dwValue)
                    strInt = "[Callback] ¡ãRising Int Set Bit " + IntToStr((i * 8)+ j);
				else
                    strInt = "[Callback] ¡åFalling Int Set Bit " + IntToStr((i * 8)+ j);

                Form1->m_lstInterrupt->Items->Add(strInt);
            
        