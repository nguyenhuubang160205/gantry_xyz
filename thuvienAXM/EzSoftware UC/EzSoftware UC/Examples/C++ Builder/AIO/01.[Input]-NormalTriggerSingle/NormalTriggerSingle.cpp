// NormalTriggerSingle.cpp : implementation file
//
// **************************************************************************
// >> [일자]: 2016.01.20
// >> [개요]: 이 예제는 AIO모듈의 Normal Trigger 관련 함수들의 사용법을 익히고
//    단일 채널의 아날로그 입력 값을 전압 혹은 Digit 값으로 반환하는 방법을
//    학습하는 예제입니다.
// >> [중요]: Normal Trigger 관련 함수들
//     1) AxaiSetRange 함수는 지정 단일 입력 채널에 입력 전압 범위를 설정합니다.
//     2) AxaiSetTriggerMode 함수는 지정 단일 입력 모듈에 A/D변환 방식을 설정합니다.
//     3) AxaiSwReadVoltage 함수는 지정 단일 입력 채널의 아날로그 입력 값을
//        전압으로 반환합니다.
//     4) AxaiSwReadDigit 함수는 지정 단일 입력 채널의 아날로그 입력 값을
//        Digit 값으로 반환합니다.
//     ※ AxaiSwReadVoltage 함수를 사용하기 전에 AxaiSetTriggerMode 함수를 사용하여
//        Normal Trigger Mode로 설정해야 합니다.
// **************************************************************************

//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "NormalTriggerSingle.h"
//---------------------------------------------------------------------------

// ++ =======================================================================
// >> AXL(AjineXtek Library) 관련 Header파일 포함시킵니다.
// ※ [CAUTION] 예제를 복사하여 다른 위치에서 실행시 참조경로 변경이 필요합니다.
// --------------------------------------------------------------------------
#include "../../../../AXL(Library)/C, C++/AXL.h"
#include "../../../../AXL(Library)/C, C++/AXA.h"
#include "../../../../AXL(Library)/C, C++/AXHS.h"

// ++ =======================================================================
// >> AXL(AjineXtek Library) 관련 Library파일을 Link시킵니다.
// ※ [CAUTION] 예제를 복사하여 다른 위치에서 실행시 참조경로 변경이 필요합니다.
// --------------------------------------------------------------------------
#pragma comment(lib, "../../../../AXL(Library)/Library/CBuilder/AxL.lib")

#pragma package(smart_init)
#pragma resource "*.dfm"
TForm1 *Form1;
//---------------------------------------------------------------------------
__fastcall TForm1::TForm1(TComponent* Owner)
    : TForm(Owner)
{
}
//---------------------------------------------------------------------------
void __fastcall TForm1::FormCreate(TObject *Sender)
{
    //++
	InitLibrary();					// 라이브러리 초기화 작업을 수행합니다.
	AddModuleChannelInfo();			// 검색된 모듈과 채널 정보를 ComboBox에 등록/Control들을 초기화합니다.
	UpdateState();					// AIO모듈의 상태와 Control들의 상태를 일치시킵니다.
}
//---------------------------------------------------------------------------
void __fastcall TForm1::FormDestroy(TObject *Sender)
{
    //++ AXL 사용을 종료합니다.
	AxlClose();
}
//---------------------------------------------------------------------------

// **************************************************************************
// >> [구분]: Control에 이벤트가 발생했을 때 처리하는 함수들 모음 
// **************************************************************************

// ++ =======================================================================
// >> m_cboModuleChange() : 모듈 변경시 호출되는 핸들러 함수.
//  - 모듈이 변경되었을 때 변경된 모듈의 ID와 Control들을 갱신합니다.
// --------------------------------------------------------------------------
void __fastcall TForm1::m_cboModuleChange(TObject *Sender)
{
    DWORD dwRetCode = 0;
	long lBoardNo = 0, lModulePos = 0;	
	AnsiString strChNum;
	
    m_lModuleNo = m_cboModule->ItemIndex;
	// 변경된 모듈의 ID를 가져옵니다.
	AxaInfoGetModule(m_lModuleNo, &lBoardNo, &lModulePos, &m_dwModuleID);

	// 채널 업데이트
	m_cboChannel->Clear();
	// 변경된 모듈의 채널 수를 가져옵니다.
	AxaInfoGetInputCount(m_lModuleNo, &m_lChannelCount);
	for(int i=0; i < m_lChannelCount; i++)
	{
		//strChNum.Format("%02d", i);
        strChNum = strChNum.Format("%.2d", ARRAYOFCONST((i)));
        m_cboChannel->Items->Add(strChNum);
	}
	m_cboChannel->ItemIndex = 0;
	m_lChannelNo = 0;

	// 전압 범위 업데이트
	//++ 지정 입력 채널에 설정한 입력 전압 범위를 확인합니다.
	UpdateVoltageRange();

	// Normal 트리거 설정
	// 현재 SIO_AI8AO4F 모듈이 등록되어있지 않아서 지원하지 않는 하드웨어라고 뜨는 것으로 보임.
	/*
	DWORD a = 100;
	dwRetCode = AxaiGetTriggerMode(m_lModuleNo, &a);
	dwRetCode = AxaiSetTriggerMode(m_lModuleNo, NORMAL_MODE);
	if(dwRetCode != AXT_RT_SUCCESS)
	{
		AnsiString strData;
		strData.Format("AxaiSetTriggerMode return error[Code:%04d]", dwRetCode);
		MessageBox(strData, "Error", MB_OK | MB_ICONERROR);
	}
	*/
}
//---------------------------------------------------------------------------

// ++ =======================================================================
// >> m_cboChannelChange() : 채널 변경시 호출되는 핸들러 함수.
//  - 채널이 변경되었을 때 변경된 채널에 대한 정보로 갱신합니다.
// --------------------------------------------------------------------------
void __fastcall TForm1::m_cboChannelChange(TObject *Sender)
{
    m_lChannelNo = ConvertComboToAxa(m_cboChannel);

	// 전압 범위 업데이트
	//++ 지정 입력 채널에 설정한 입력 전압 범위를 확인합니다.
	UpdateState();
}
//---------------------------------------------------------------------------

// ++ =======================================================================
// >> m_cboVoltageRangeChange() : 입력 전압 범위 변경시 호출되는 핸들러 함수.
//  - 해당 채널의 입력 전압 범위를 갱신합니다.
//  - 입력 전압 범위는 A/D변환 성능과 관련이 있으므로 측정 범위 확인 후 설정하시기 바랍니다.
//  - 모듈별로 허용 입력 전압이 정해져 있습니다. 
//  - 사용자가 입력 전압 설정범위 이외 전압을 입력하면 자동으로 그 값을 포함하는 근삿값으로 자동 설정됩니다.
// --------------------------------------------------------------------------
void __fastcall TForm1::m_cboVoltageRangeChange(TObject *Sender)
{
    DWORD	dwRetCode = 0;
	double	dMinVolt = 0.0, dMaxVolt = 0.0;

	switch(m_cboVoltageRange->ItemIndex)
	{
	case 0:
		dMinVolt = -10.0;
		dMaxVolt = 10.0;
		break;
		
	case 1:
		dMinVolt = -5.0;
		dMaxVolt = 5.0;
		break;
		
	case 2:
		dMinVolt = 0.0;
		dMaxVolt = 10.0;
		break;
		
	case 3:
		dMinVolt = 0.0;
		dMaxVolt = 5.0;
		break;
		
	default:
		break;
	}
	
	// 입력 전압 범위를 설정합니다.
	dwRetCode = AxaiSetRange(m_lChannelNo, dMinVolt, dMaxVolt);
	if(dwRetCode != AXT_RT_SUCCESS)
	{
		AnsiString strData;
		strData = strData.Format("AxaiSetRange return error[Code:%04d]", ARRAYOFCONST(((int)dwRetCode)));
		ShowMessage(strData);
	}
}
//---------------------------------------------------------------------------

// ++ =======================================================================
// >> m_cboValueTypeChange() : 입력 정보 종류를 변경시 호출되는 핸들러 함수.
//  - 입력값을 전압 또는 10진수로 출력할 때 설정합니다.
// --------------------------------------------------------------------------
void __fastcall TForm1::m_cboValueTypeChange(TObject *Sender)
{
    int nValueType = 0;
	
	nValueType = ConvertComboToAxa(m_cboValueType);
	if (nValueType == 0)
	{
		m_bIsReadVoltage = TRUE;
        m_stcValueType->Caption = "Volt";
	}
	else
	{
		m_bIsReadVoltage = FALSE;
		m_stcValueType->Caption = "Digit";
	}
}
//---------------------------------------------------------------------------

// ++ =======================================================================
// >> m_btnStartClick() : "Start"버튼 클릭시 호출되는 핸들러 함수.
//  - 단일 채널에 들어오는 값을 Normal Trigger로 읽기 시작합니다.
// --------------------------------------------------------------------------
void __fastcall TForm1::m_btnStartClick(TObject *Sender)
{
    m_cboModule->Enabled = FALSE;
	m_cboChannel->Enabled = FALSE;
	m_cboVoltageRange->Enabled = FALSE;
	m_cboValueType->Enabled = FALSE;
	m_btnStart->Enabled = FALSE;
	m_btnStop->Enabled = TRUE;

	m_dOldVolt = 0.0;
	m_dwOldDigit = 0;

    m_timer->Enabled = TRUE;        // Normal Trigger 시작
}
//---------------------------------------------------------------------------

// ++ =======================================================================
// >> m_btnStopClick() : "Stop"버튼 클릭시 호출되는 핸들러 함수.
//  - 작업을 중지합니다.
// --------------------------------------------------------------------------
void __fastcall TForm1::m_btnStopClick(TObject *Sender)
{
    m_cboModule->Enabled = TRUE;
	m_cboChannel->Enabled = TRUE;
	m_cboVoltageRange->Enabled = TRUE;
	m_cboValueType->Enabled = TRUE;
	m_btnStart->Enabled = TRUE;
	m_btnStop->Enabled = FALSE;

    m_timer->Enabled = FALSE;       // Normal Trigger 종료
}
//---------------------------------------------------------------------------

// ++ =======================================================================
// >> m_timerTimer(...) : 타이머 이벤트 핸들러 함수.
//  - Normal Trigger로 입력 값을 주기적으로 갱신합니다.
// --------------------------------------------------------------------------
void __fastcall TForm1::m_timerTimer(TObject *Sender)
{
    AnsiString strValue;

    if (m_bIsReadVoltage)
	{
		double dVolt = 0.0;
		// 지정 채널로 들어오는 값을 전압 단위로 읽어옵니다.
		AxaiSwReadVoltage(m_lChannelNo, &dVolt);
		if (m_dOldVolt != dVolt)
		{
			strValue = strValue.Format("%.4f", ARRAYOFCONST((dVolt)));
            m_stcReadValue->Text = strValue;
			m_dOldVolt = dVolt;
		}
	}
	else
	{
		DWORD dwDigit;
		// 지정 채널로 들어오는 값을 10진수 단위로 읽어옵니다.
		AxaiSwReadDigit(m_lChannelNo, &dwDigit);
		if (m_dwOldDigit != dwDigit)
		{
			strValue = strValue.Format("%d", ARRAYOFCONST(((int)dwDigit)));
			m_stcReadValue->Text= strValue;
			m_dwOldDigit = dwDigit;
		}
	}
}
//---------------------------------------------------------------------------

// **************************************************************************
// >> [구분]: 별도의 기능을 구현하기위해 만든 사용자 정의 함수들 모음 
// **************************************************************************

// ++ =======================================================================
// >> InitLibrary() : 라이브러리 초기화 함수.
//  - AXL(AjineXtek Library)을 사용가능하게 합니다. 
// --------------------------------------------------------------------------
BOOL TForm1::InitLibrary()
{
	//++ AXL(AjineXtek Library)을 사용가능하게 하고 장착된 보드들을 초기화합니다.
	DWORD dwStatus = 0;
	DWORD dwRetCode = AxlOpenNoReset(7);			// 설정값들을 초기화하지 않음

	if (dwRetCode != AXT_RT_SUCCESS){
		ShowMessage("AxlOpen Fail...");
		return FALSE;
	}

	//TRACE("The library became the initialization.\n");
	dwRetCode = AxaInfoIsAIOModule(&dwStatus);		// AIO모듈 존재여부를 확인합니다
	if (dwStatus != STATUS_EXIST)
	{
		ShowMessage("The module does not exist...");
		return FALSE;
	}

	//TRACE("AIO module exists.\n");
	return TRUE;
}

// ++ =======================================================================
// >> InitControl() : Control들에 초기값을 설정하는 함수.
//  - Control 변수들을 등록하고, 초기 설정값들을 설정합니다.
// --------------------------------------------------------------------------
BOOL TForm1::InitControl()
{
	m_lModuleNo = 0;
	m_lChannelNo = 0;
	m_bIsReadVoltage = TRUE;

	m_cboModule->ItemIndex = 0;
	m_cboChannel->ItemIndex = 0;
	m_cboValueType->ItemIndex = 0;

    m_btnStop->Enabled = FALSE;

	// 첫번째 모듈의 ID를 가져옵니다.
	AxaInfoGetModule(m_lModuleNo, NULL, NULL, &m_dwModuleID);

	return TRUE;
}

// ++ =======================================================================
// >> AddModuleChannelInfo() : 시스템에 장착된 AIO모듈들을 ComboBox에 등록하는 함수.
//  - AIO모듈 정보를 읽어 ComboBox에 등록하여 사용자가 선택
//    제어할 수 있도록 합니다.
//  - 유효한 모듈이 검색되었을 때 Control들을 초기화 합니다.
// --------------------------------------------------------------------------
BOOL TForm1::AddModuleChannelInfo()
{
	AnsiString strData;
	char szModuleName[50] = "";
	long lInputCount = 0, lBoardNo = 0, lModulePos = 0;
	DWORD dwModuleID = 0;
	// 시스템에 장착된 모든AIO 모듈의 개수를 확인합니다.
	DWORD dwRetCode = AxaInfoGetModuleCount(&m_lModuleCount);
	if (dwRetCode == AXT_RT_SUCCESS)
	{
		//TRACE("The number of AIO module: %d\n",m_lModuleCount);
	}
	else
	{
		//TRACE("AxaGetModuleCount() : ERROR code Ox%x\n",dwRetCode);
	}

    
	for (int iModuleNo = 0; iModuleNo < m_lModuleCount; iModuleNo++)
	{
		// 각 모듈의 입력 채널 수를 확인합니다.
		AxaInfoGetInputCount(iModuleNo, &lInputCount);
		if (lInputCount > 0)
		{
			// 해당 모듈의 정보를 가져옵니다.
			dwRetCode = AxaInfoGetModule(iModuleNo, &lBoardNo, &lModulePos, &dwModuleID);
			if (dwRetCode == AXT_RT_SUCCESS)
			{

				switch (dwModuleID)
				{
				case AXT_SIO_AI4RB:
					strData = strData.Format("[BD No:%d - MD No:%d] SIO_AI4RB [Input : %d]", ARRAYOFCONST(((int)lBoardNo, iModuleNo, (int)lInputCount)));
					break;
				case AXT_SIO_AI16H:
					strData = strData.Format("[BD No:%d - MD No:%d] SIO_AI16H [Input : %d]", ARRAYOFCONST(((int)lBoardNo, iModuleNo, (int)lInputCount)));
					break;
				case AXT_SIO_AI16HB:
					strData = strData.Format("[BD No:%d - MD No:%d] SIO_AI16HB [Input : %d]", ARRAYOFCONST(((int)lBoardNo, iModuleNo, (int)lInputCount)));
					break;
				case AXT_SIO_RAI8RB:
					strData = strData.Format("[BD No:%d - MD No:%d] SIO_RAI8RB [Input : %d]", ARRAYOFCONST(((int)lBoardNo, iModuleNo, (int)lInputCount)));
					break;
				case AXT_SIO_RAI4MLII:
					strData = strData.Format("[BD No:%d - MD No:%d] SIO_RAI4MLII [Input : %d]", ARRAYOFCONST(((int)lBoardNo, iModuleNo, (int)lInputCount)));
					break;
				case AXT_SIO_RAI16RB:
					strData = strData.Format("[BD No:%d - MD No:%d] SIO_RAI16RB [Input : %d]", ARRAYOFCONST(((int)lBoardNo, iModuleNo, (int)lInputCount)));
					break;
				case AXT_SIO_RAVCI4MLII:
					strData = strData.Format("[BD No:%d - MD No:%d] SIO_RAVCI4MLII [Input : %d]", ARRAYOFCONST(((int)lBoardNo, iModuleNo, (int)lInputCount)));
					break;
				case AXT_SIO_RATI4MLII:
					strData = strData.Format("[BD No:%d - MD No:%d] SIO_RATI4MLII [Input : %d]", ARRAYOFCONST(((int)lBoardNo, iModuleNo, (int)lInputCount)));
					break;
				case AXT_SIO_RARTDI4MLII:
					strData = strData.Format("[BD No:%d - MD No:%d] SIO_RARTDI4MLII [Input : %d]", ARRAYOFCONST(((int)lBoardNo, iModuleNo, (int)lInputCount)));
					break;
				case AXT_SIO_RAO08RTEX:
					strData = strData.Format("[BD No:%d - MD No:%d] SIO_RAO08RTEX [Input : %d]", ARRAYOFCONST(((int)lBoardNo, iModuleNo, (int)lInputCount)));
					break;
				case AXT_SIO_AI8F:
					strData = strData.Format("[BD No:%d - MD No:%d] SIO_AI8F [Input : %d]", ARRAYOFCONST(((int)lBoardNo, iModuleNo, (int)lInputCount)));
					break;
				case AXT_SIO_AI8AO4F:
					strData = strData.Format("[BD No:%d - MD No:%d] SIO_AI8A04F [Input : %d]", ARRAYOFCONST(((int)lBoardNo, iModuleNo, (int)lInputCount)));
					break;
				case AXT_ECAT_AIO:
					if(lInputCount > 0)
					{
						// EtherCAT AIO 전용 모듈 정보 추출
						AxaInfoGetModuleEx(iModuleNo, NULL, szModuleName, NULL);
						strData = strData.Format("[BD No:%d - MD No:%d] %s [Input : %d]", ARRAYOFCONST(((int)lBoardNo, iModuleNo, szModuleName, (int)lInputCount)));
					}
					break;
                };

                int temp = 0;

                m_cboModule->Items->Add(strData);

				for(int i=0; i < lInputCount; i++)
				{
					AnsiString strChNum;
					strChNum = strChNum.Format("%.2d", ARRAYOFCONST((i)));
                    m_cboChannel->Items->Add(strChNum);
				}

			}
		}
	}

	InitControl();

	return TRUE;
}

// ++ =======================================================================
// >> UpdateState() : 지정한 모듈의 설정값들을 읽어 Control과 일치시키는 함수.
//  - 모듈이 변경되었을 때 변경한 모듈의 설정값들과 Control들과 일치시키는 
//    역할을하는 함수입니다.
//  - 지정한 모듈의 모델별 제약들을 Control에 반영하는 역할을 합니다.
//  - 프로그램 초기 실행시, 모듈 번호 바뀔 때 사용됩니다.
// --------------------------------------------------------------------------
BOOL TForm1::UpdateState()
{
	if(m_lModuleCount < 1) return FALSE;
	
	//++ 각 모듈별 지원여부에 따라 콘트롤 값들을 변경합니다.
	m_cboVoltageRange->Clear();
	m_cboVoltageRange->Enabled = TRUE;
	switch(m_dwModuleID) {
	case AXT_SIO_AI4RB:
	case AXT_SIO_AO4RB:
	case AXT_SIO_AI8AO4F:
		m_cboVoltageRange->Items->Add("00: -10V ~ +10V");
		m_cboVoltageRange->Items->Add("01: -5V ~ +5V");
		m_cboVoltageRange->Items->Add("02: 0V ~ +10V");
		m_cboVoltageRange->Items->Add("03: 0V ~ +5V");
		break;

	case AXT_SIO_AI8F:
	case AXT_SIO_AO4F:
		m_cboVoltageRange->Items->Add("00: -10V ~ +10V");
		m_cboVoltageRange->Items->Add("01: -5V ~ +5V");
		break;

	default:
		break;
	}

	//++ 지정 입력 채널에 설정한 입력 전압 범위를 확인합니다.
	UpdateVoltageRange();

	return TRUE;
}

// ++ =======================================================================
// >> ConvertComboToAxa(...) : ComboBox콘트롤에 현재 선택된 Item Index를 모션
//    보드에 설정할 값으로 변경하는 함수.
//  - ComboBox에 선택된 Item Index와 실제 모듈에 설정되는 값이 다르므로 
//    선택된 문자열에서 모듈에 설정할 값을 추출해서 반환하는 함수입니다.
//  - 변환 할 ComboBox 콘트롤의 포인터를 인자로 전달합니다.
//  - 이 함수를 사용하고자 할 때 데이타 등록을 지정된 양식으로 설정해야됩니다.
//    Format) XX: String, XX=라이브러리로 전달될 값, String=인자 설명
//    Ex) "00: Volt", "01: Digit"
// --------------------------------------------------------------------------
DWORD TForm1::ConvertComboToAxa(TComboBox *pCboItem)
{
	if(pCboItem == NULL)	return 0;

	AnsiString strText;
	long	lCount, lSelData, idxColon;

	lCount = pCboItem->Items->Count;
	if(lCount == 0)		return 0;

	lSelData = pCboItem->ItemIndex;
	if(lSelData < 0)	return 0;

	strText = pCboItem->Items->Strings[lSelData];
	idxColon = strText.Pos(":");
    if(idxColon == 0)
    {
        return StrToInt(strText);
    }
    else {
        return StrToInt(strText.SubString(0, idxColon - 1));
    }
}

// ++ =======================================================================
// >> ConvertAxaToCombo(...) : 지정한 모듈의 설정값과 ComboBox콘트롤의
//    Item과 일치하는 Item을 찾아 선택하는 함수.
//  - 실제 모듈값과 ComboBox의 Item Index가  다르므로 지정한
//    값과 일치하는 Item을 찾아 선택하고 선택된 Item의 Index를 반환합니다.
//  - 변경하고자하는 ComboBox 콘트롤의 포인터를 인자로 전달합니다.
//  - 이 함수를 사용하고자 할 때 데이타 등록을 지정된 양식으로 설정해야됩니다.
//    Format) XX: String, XX=라이브러리로 전달될 값, String=인자 설명
//    Ex) "00: Volt", "01: Digit"
// --------------------------------------------------------------------------
long TForm1::ConvertAxaToCombo(TComboBox *pCboItem, DWORD dwCurData)
{
	if(pCboItem == NULL)	return 0;

	long	lCount, lSelData, idxColon;
	AnsiString strText;

	lCount = pCboItem->Items->Count;
	if(lCount == 0)	return 0;

	for(int i = 0; i < lCount; i++){
		strText = pCboItem->Items->Strings[i];
		idxColon = strText.Pos(":");
        if(idxColon == 0)
        {
            lSelData = StrToInt(strText);
        }
        else
        {
            lSelData = StrToInt(strText.SubString(0, idxColon - 1));
        }
		if(lSelData == (long)dwCurData){
			pCboItem->ItemIndex = i;
			return i;
		}
	}

	pCboItem->ItemIndex = 0;
	return 0;
}

// ++ =======================================================================
// >> UpdateVoltageRange(...) : 전압 범위를 갱신하는 함수.
//  - 모듈이나 채널 변경 시 해당 채널의 입력 전압 범위로
//    Control값을 변경합니다.
// --------------------------------------------------------------------------
void TForm1::UpdateVoltageRange()
{
	DWORD	dwRetCode = 0;
	double	dMinVolt = 0.0, dMaxVolt = 0.0;

	//++ 지정 입력 채널에 설정한 입력 전압 범위를 확인합니다.
	dwRetCode = AxaiGetRange(m_lChannelNo, &dMinVolt, &dMaxVolt);
	if(dwRetCode == AXT_RT_SUCCESS)
	{
		if(dMinVolt == -10.0 && dMaxVolt == 10.0)
            m_cboVoltageRange->ItemIndex = 0;
		else if(dMinVolt == -5.0 && dMaxVolt == 5.0)
			m_cboVoltageRange->ItemIndex = 1;
		else if(dMinVolt == 0.0 && dMaxVolt == 10.0)
			m_cboVoltageRange->ItemIndex = 2;
		else if(dMinVolt == 0.0 && dMaxVolt == 5.0)
			m_cboVoltageRange->ItemIndex = 3;
	}
	else
	{
		m_cboVoltageRange->ItemIndex = 0;
	}
}
