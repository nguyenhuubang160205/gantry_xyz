// InterruptSetting.cpp : implementation file
//
// **************************************************************************
// >> [일자]: 2015.12.15
// >> [개요]: 이 예제는 인터럽트 함수들의 사용법을 익히고 윈도우 응용프로그램에서
//     여러가지 인터럽트 처리 방법에 대해 학습하는 예제입니다.
// >> [중요]: 인터럽트 사용방법
//     1) AxlInterruptEnable함수를 이용해서 AXL라이브러리에 인터럽트를 허용합니다.
//     2) AxmInterruptSetAxis함수를 이용해 각 축에 인터럽트 처리 방식을 설정합니다.
//     3) AxmInterruptSetUserEnable함수를 이용해 지정한 축에 사용할 인터럽트
//        종류들을 설정합니다. Ex) AxmInterruptSetUserEnable(0, INT_BANK_1, 0x6)
//     4) AxmInterruptSetAxisEnable 함수를 이용해 지정한 축에 인터럽트를 허용합니다.
// **************************************************************************

//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "InterruptSetting.h"
//---------------------------------------------------------------------------

// ++ =======================================================================
// >> AXL(AjineXtek Library) 관련 Header파일 포함시킵니다.
// ※ [CAUTION] 예제를 복사하여 다른 위치에서 실행시 참조경로 변경이 필요합니다.
// --------------------------------------------------------------------------
#include "../../../../AXL(Library)/C, C++/AXL.h"
#include "../../../../AXL(Library)/C, C++/AXM.h"
#include "../../../../AXL(Library)/C, C++/AXHS.h"

// ++ =======================================================================
// >> AXL(AjineXtek Library) 관련 Library파일을 Link시킵니다.
// ※ [CAUTION] 예제를 복사하여 다른 위치에서 실행시 참조경로 변경이 필요합니다.
// --------------------------------------------------------------------------
#pragma comment(lib, "../../../../AXL(Library)/Library/CBuilder/AxL.lib")

#define TM_DISPLAY             - 100
#define WM_CAMC_INTERRUPT       WM_USER + 2009
#define INT_BANK_1              0
#define INT_BANK_2              1
#define MAX_BANK_1              4
#define MAX_BANK_2              6
#define MAX_AXIS_COUNT          64

// 인터럽트 이벤트 처리 쓰레드 프로시져 선언
UINT		ThreadEventProc(LPVOID lpData);
// 인터럽트 콜벡함수 선언
void __stdcall	KeMotionInterruptCallback(long lActiveNo, DWORD dwFlag);

int g_nIntCnt = 0;
bool m_bThread[64];
HANDLE m_hInterrupt[64];

#pragma package(smart_init)
#pragma resource "*.dfm"
TForm1 *Form1;
//---------------------------------------------------------------------------
__fastcall TForm1::TForm1(TComponent* Owner)
		: TForm(Owner)
{
		m_lAxisNo = -1;
		m_lAxisCount = 0;
		m_dwModuleID = 0;
}
//---------------------------------------------------------------------------

BOOL ThreadProc(LPVOID lpData)
{
	TForm1 *pDlg	= (TForm1 *)lpData;
	pDlg->ThreadData();
	return TRUE;
}
//---------------------------------------------------------------------------

void __fastcall TForm1::FormCreate(TObject *Sender)
{
        InitLibrary();
        AddAxisInfo();
        UpdateState();
}
//---------------------------------------------------------------------------

void __fastcall TForm1::FormDestroy(TObject *Sender)
{
    // 인터럽트 처리용 객체 해제
	for(int i = 0; i < MAX_AXIS_COUNT; i++) {
		if(m_hInterrupt[i] != NULL){
			TerminateThread(m_hInterrupt[i], 0);
			WaitForSingleObject(m_hInterrupt[i],  WAIT_ABANDONED);
			CloseHandle(m_hInterrupt[i]);
			m_hInterrupt[i] = NULL;
		}
	}

	//++ AXL 사용을 종료합니다.
	AxlClose();
}
//---------------------------------------------------------------------------

// **************************************************************************
// >> [구분]: Control에 이벤트가 발생했을 때 처리하는 함수들 모음
// **************************************************************************

// ++ =======================================================================
// >> cboSelAxisChange() : 축 번호 변경시 호출되는 핸들러 함수.
//  - 축 번호가 변경되었을 때 변경된 축의 모듈 ID와 Control들을 갱신합니다.
// --------------------------------------------------------------------------
void __fastcall TForm1::cboSelAxisChange(TObject *Sender)
{
	m_lAxisNo = cboSelAxis->ItemIndex;		// 축 선택 ComboBox에서 선택된 축번호를 제어할 축 번호 변수에 설정합니다.

	//++ 지정한 축번호의 모듈ID를 반환합니다.
	// [INFO] 여러개의 정보를 읽는 함수 사용시 불필요한 정보는 NULL(0)을 입력하면 됩니다.
	AxmInfoGetAxis(m_lAxisNo, NULL, NULL, &m_dwModuleID);

	UpdateState();	// 변경한 축의 상태와 Control들의 상태를 일치시킵니다.
}
//---------------------------------------------------------------------------

// ++ =======================================================================
// >> btnSetBank1Click() : "Set Bank 1"버튼 클릭시 호출되는 핸들러 함수.
//  - 인터럽트 Bank1에 설정가능한 인터럽트를 설정합니다.
// --------------------------------------------------------------------------
void __fastcall TForm1::btnSetBank1Click(TObject *Sender)
{
	int		i;
	String strIntMask, strData;
	DWORD	dwIntMask = 0, dwRetCode;

		dwIntMask = 0;
		if(chkBank1Bit00->Checked == true) dwIntMask |= QIINTBANK1_0;
		if(chkBank1Bit01->Checked == true) dwIntMask |= QIINTBANK1_1;
		if(chkBank1Bit02->Checked == true) dwIntMask |= QIINTBANK1_2;
		if(chkBank1Bit31->Checked == true) dwIntMask |= QIINTBANK1_31;

	//++ 지정한 축에 모션구동 시작시, 모셔구동 종료시 등의 인터럽트를 설정합니다.
	dwRetCode = AxmInterruptSetUserEnable(m_lAxisNo, INT_BANK_1, dwIntMask);
	if(dwRetCode != AXT_RT_SUCCESS){
		strData = strData.Format("AxmInterruptSetUserEnable return error[Code:%.4d]", ARRAYOFCONST(((int)dwRetCode)));
		ShowMessage(strData);
	}

	UpdateState();
}
//---------------------------------------------------------------------------

// ++ =======================================================================
// >> OnBtnSetBank2() : "Set Bank 2"버튼 클릭시 호출되는 핸들러 함수.
//  - 인터럽트 Bank2에 설정가능한 인터럽트를 설정합니다.
// --------------------------------------------------------------------------
void __fastcall TForm1::btnSetBank2Click(TObject *Sender)
{
	int		i;
	String strIntMask, strData;
	DWORD	dwIntMask = 0, dwRetCode;

		dwIntMask = 0;
		if(chkBank2Bit14->Checked == true) dwIntMask |= QIINTBANK2_14;
		if(chkBank2Bit15->Checked == true) dwIntMask |= QIINTBANK2_15;
		if(chkBank2Bit16->Checked == true) dwIntMask |= QIINTBANK2_16;
		if(chkBank2Bit20->Checked == true) dwIntMask |= QIINTBANK2_20;
		if(chkBank2Bit21->Checked == true) dwIntMask |= QIINTBANK2_21;
		if(chkBank2Bit22->Checked == true) dwIntMask |= QIINTBANK2_22;

	//++ 지정한 축에 범용입력 변화시, 범용출력 변화시 등의 인터럽트를 설정합니다.
	dwRetCode = AxmInterruptSetUserEnable(m_lAxisNo, INT_BANK_2, dwIntMask);
	if(dwRetCode != AXT_RT_SUCCESS){
		strData = strData.Format("AxmInterruptSetUserEnable return error[Code:%.4d]", ARRAYOFCONST(((int)dwRetCode)));
		ShowMessage(strData);
	}

	UpdateState();
}
//---------------------------------------------------------------------------

// ++ =======================================================================
// >> chkIntEnableClick() : "Interrupt Enable"버튼 클릭시 호출되는 핸들러 함수.
//  - 인터럽트 처리 방식에 따라 인터럽트를 설정합니다.
// ※ [CAUTION] 인터럽트 사용시 사용자가 구현하는 인터럽트 처리함수는 되도록이면
//    간결하게 작성하는게 좋습니다(콘트롤 업데이트등은 옳지 않음). 왜냐하면
//    인터럽트가 발생하는 시간보다 함수처리 시간이 길어지게되면 놓치는 경우가
//    빈번하게 발생할 수 있기 때문입니다.
// --------------------------------------------------------------------------
void __fastcall TForm1::chkIntEnableClick(TObject *Sender)
{
	String strData;
	DWORD	dwRetCode;

	if(chkIntEnable->Checked) {
		if(rdoMessage->Checked) {
			//++ 인터럽트 처리방식을 윈도우메세지 방식으로 지정함
			AxmInterruptSetAxis(m_lAxisNo, Form1->Handle, WM_AXL_INTERRUPT, NULL, NULL);
		} else if(rdoCallback->Checked) {
			//++ 인터럽트 처리방식을 콜벡함수 방식으로 지정함
			AxmInterruptSetAxis(m_lAxisNo, Form1->Handle, 0, KeMotionInterruptCallback, NULL);
		} else if(rdoEvent->Checked) {
			g_nIntCnt = 0;
			//++ 인터럽트 처리방식을 이벤트 방식으로 지정함
			AxmInterruptSetAxis(m_lAxisNo, 0, 0, NULL, &m_hInterrupt[m_lAxisNo]);
			if(m_hHandle[m_lAxisNo]) {
				m_bThread[m_lAxisNo] = false;
				m_hHandle[m_lAxisNo] = 0;
			}

			if(m_bThread[m_lAxisNo] == false) {
				m_bThread[m_lAxisNo] = true;
				// 해당축의 인터럽트 이벤트를 대기할 쓰레드 생성
				m_hHandle[m_lAxisNo] = CreateThread(NULL, 0, (LPTHREAD_START_ROUTINE)ThreadProc, Form1, NULL, NULL);
			}
		}

		//++ AXL라이브러리의 인터럽트 발생을 허용합니다.
		AxlInterruptEnable();
		//++ 지정한 축에 인터럽트 발생을 허용합니다.
		dwRetCode = AxmInterruptSetAxisEnable(m_lAxisNo, ENABLE);
		if(dwRetCode != AXT_RT_SUCCESS){
			chkIntEnable->Checked = false;

			strData = strData.Format("AxmInterruptSetAxisEnable return error[Code:%.4d]", ARRAYOFCONST(((int)dwRetCode)));
			ShowMessage(strData);
		}
	}else{
		//++ AXL라이브러리의 인터럽트 발생을 금지합니다.
		AxlInterruptDisable();
		//++ 지정한 축에 인터럽트 발생을 금지합니다.
		dwRetCode = AxmInterruptSetAxisEnable(m_lAxisNo, DISABLE);
		if(dwRetCode != AXT_RT_SUCCESS){
			chkIntEnable->Checked = true;

			strData = strData.Format("AxmInterruptSetAxisEnable return error[Code:%.4d]", ARRAYOFCONST(((int)dwRetCode)));
			ShowMessage(strData);
		}
	}
}
//---------------------------------------------------------------------------

// ++ =======================================================================
// >> lstIntLogDblClick() : ListBox 콘트롤 마우스 더블클릭시 호출되는 핸들러 함수.
//  - 등록된 인터럽트 로그를 지울때 호출됩니다.
//  - List Box 콘트롤에서 마우스 오르쪽 버튼을 더블클릭하면 이 함수가 호출됩니다.
// --------------------------------------------------------------------------
void __fastcall TForm1::lstIntLogDblClick(TObject *Sender)
{
		g_nIntCnt = 0;
		lstIntLog->Items->Clear();
}
//---------------------------------------------------------------------------

// **************************************************************************
// >> [구분]: 별도의 기능을 구현하기위해 만든 사용자 정의 함수들 모음
// **************************************************************************

// ++ =======================================================================
// >> InitLibrary() : 라이브러리 초기화 및 Mot파일을 불러오는 함수.
//  - AXL(AjineXtek Library)을 사용가능하게 합니다.
//  - EzConfig 프로그램이 설치되어있는 폴더에서 기본 Mot파일(모션 설정파일)을
//    지정해 모션관련 기본설정을 자동으로 합니다.
// --------------------------------------------------------------------------
BOOL TForm1::InitLibrary()
{
        //++ AXL(AjineXtek Library)을 사용가능하게 하고 장착된 보드들을 초기화합니다.
	if ((AxlOpen(7) != AXT_RT_SUCCESS)){
		ShowMessage("AxlOpen Fail...");
		return FALSE;
	}

        return true;
}

// ++ =======================================================================
// >> AddAxisInfo() : 시스템에 장착된 모션축들을 ComboBox에 등록하는 함수.
//  - AXL Open시 검색된 축들의 정보를 읽어 ComboBox에 등록하여 사용자가 선택
//    제어할 수 있도록 합니다.
//  - 유효한 축이 검색되었을 때 Control들을 초기화 하고, 정보 갱신용 타이머를 
//    100msec 주기로 동작시킵니다.
// --------------------------------------------------------------------------
BOOL TForm1::AddAxisInfo()
{
        String	strData;
	DWORD	dwModuleID;
	
	//++ 유효한 전체 모션축수를 반환합니다.
	AxmInfoGetAxisCount(&m_lAxisCount);
	if(m_lAxisCount < 1)	return FALSE;

	m_lAxisNo = 0;
	//++ 지정한 축의 정보를 반환합니다.
	// [INFO] 여러개의 정보를 읽는 함수 사용시 불필요한 정보는 NULL(0)을 입력하면 됩니다.
	AxmInfoGetAxis(m_lAxisNo, NULL, NULL, &m_dwModuleID);

	// 유효한 전체 모션축수의 정보를 읽어 ComboBox에 등록합니다.
	for(int i = 0; i < m_lAxisCount; i++)
	{
		//++ 지정한 축의 정보를 반환합니다.
		// [INFO] 여러개의 정보를 읽는 함수 사용시 불필요한 정보는 NULL(0)을 입력하면 됩니다.
		AxmInfoGetAxis(i, NULL, NULL, &dwModuleID);
		switch(dwModuleID){
		case AXT_SMC_4V04:  strData = strData.Format("%.2d-[4V04]", ARRAYOFCONST((i)));	break;
		case AXT_SMC_R1V04:	strData = strData.Format("%.2d-[R1V04]", ARRAYOFCONST((i)));	break;
		case AXT_SMC_2V04:	strData = strData.Format("%.2d-[2V04]", ARRAYOFCONST((i)));	break;
		case AXT_SMC_R1V04MLIIPM:	strData = strData.Format("%.2d-[R1V04MLIIPM]", ARRAYOFCONST((i)));	break;
		case AXT_SMC_R1V04PM2Q:		strData = strData.Format("%.2d-[R1V04PM2Q]", ARRAYOFCONST((i)));	break;
		case AXT_SMC_R1V04PM2QE:	strData = strData.Format("%.2d-[R1V04PM2QE]", ARRAYOFCONST((i)));	break;
		case AXT_SMC_R1V04MLIIIPM:	strData = strData.Format("%.2d-[R1V04MLIIIPM]", ARRAYOFCONST((i)));	break;
		case AXT_SMC_R1V04MLIISV:	strData = strData.Format("%.2d-[R1V04MLIISV]", ARRAYOFCONST((i)));	break;
		case AXT_SMC_R1V04A5:		strData = strData.Format("%.2d-[R1V04A5]", ARRAYOFCONST((i)));	break;
		case AXT_SMC_R1V04A4:		strData = strData.Format("%.2d-[R1V04A4]", ARRAYOFCONST((i)));	break;
		case AXT_SMC_R1V04SIIIHMIV:	strData = strData.Format("%.2d-[R1V04SIIIHMIV]", ARRAYOFCONST((i)));	break;
		case AXT_SMC_R1V04SIIIHMIV_R:	strData = strData.Format("%.2d-[R1V04SIIIHMIV_R]", ARRAYOFCONST((i)));	break;
		case AXT_SMC_R1V04MLIIISV:	strData = strData.Format("%.2d-[R1V04MLIIISV]", ARRAYOFCONST((i)));	break;
		case AXT_SMC_R1V04MLIIISV_MD:	strData = strData.Format("%.2d-[R1V04MLIIISV_MD]", ARRAYOFCONST((i)));	break;
		case AXT_SMC_R1V04MLIIIS7S:	strData = strData.Format("%.2d-[R1V04MLIIIS7S]", ARRAYOFCONST((i)));	break;
		case AXT_SMC_R1V04MLIIIS7W:	strData = strData.Format("%.2d-[R1V04MLIIIS7W]", ARRAYOFCONST((i)));	break;
		case AXT_ECAT_MOTION:
			{
				char szModuleName[50];
				AxmInfoGetAxisEx(i, NULL, szModuleName, NULL);
				strData = strData.Format("%.2d-[ECAT-%s]", ARRAYOFCONST((i, szModuleName)));
				break;
			}
		default:			strData = strData.Format("%.2d-[Unknown]", ARRAYOFCONST((i)));
		}

                cboSelAxis->Items->Add(strData);
	}
		
	InitControl();							// Control 변수들을 등록하고, 초기 설정값들을 설정합니다.

        return true;
}

// ++ =======================================================================
// >> InitControl() : Control들에 초기값을 설정하는 함수.
//  - Control 변수들을 등록하고, 초기 설정값들을 설정합니다.
// --------------------------------------------------------------------------
BOOL TForm1::InitControl()
{
        cboSelAxis->ItemIndex = m_lAxisNo;

        return true;
}

// ++ =======================================================================
// >> UpdateState() : 지정한 축의 설정값들을 읽어 Control과 일치시키는 함수.
//  - 축번호가 변경되었을 때 변경한 축의 설정값들과 Control들과 일치시키는 
//    역할을하는 함수입니다.
//  - 지정한 축의 모델별 제약들을 Control에 반영하는 역할을 합니다.
//  - 프로그램 초기 실행시, Mot파일 불러올 때, 축 번호 바뀔 때 사용됩니다.
// --------------------------------------------------------------------------
BOOL TForm1::UpdateState()
{
        if(m_lAxisCount < 1)	return FALSE;
	
	DWORD dwIntMask = 0;
        String strIntMask;

        //++ 지정한 축의 인터럽트 Bank1의 설정값을 확인합니다.
	AxmInterruptGetUserEnable(m_lAxisNo, INT_BANK_1, &dwIntMask);
		strIntMask = strIntMask.Format("Interrupt Event Bank 1 [0x%.8X]", ARRAYOFCONST(((int)dwIntMask)));
	grpBank1->Caption = strIntMask;

	// 인터럽트 설정값 해당 콘트롤에 적용
	chkBank1Bit00->Checked = dwIntMask & QIINTBANK1_0;
		chkBank1Bit01->Checked = dwIntMask & QIINTBANK1_1;
		chkBank1Bit02->Checked = dwIntMask & QIINTBANK1_2;
		chkBank1Bit31->Checked = dwIntMask & QIINTBANK1_31;

	//++ 지정한 축의 인터럽트 Bank2의 설정값을 확인합니다.
	AxmInterruptGetUserEnable(m_lAxisNo, INT_BANK_2, &dwIntMask);
	strIntMask = strIntMask.Format("Interrupt Event Bank 2 [0x%.8X]", ARRAYOFCONST(((int)dwIntMask)));
		grpBank2->Caption = strIntMask;

	// 인터럽트 설정값 해당 콘트롤에 적용
		chkBank2Bit14->Checked = dwIntMask & QIINTBANK2_14;
		chkBank2Bit15->Checked = dwIntMask & QIINTBANK2_15;
		chkBank2Bit16->Checked = dwIntMask & QIINTBANK2_16;
		chkBank2Bit20->Checked = dwIntMask & QIINTBANK2_20;
		chkBank2Bit21->Checked = dwIntMask & QIINTBANK2_21;
		chkBank2Bit22->Checked = dwIntMask & QIINTBANK2_22;

		return true;
}

// ++ =======================================================================
// >> ConvertComboToAxm(...) : ComboBox콘트롤에 현재 선택된 Item Index를 모션
//    보드에 설정할 값으로 변경하는 함수.
//  - ComboBox에 선택된 Item Index와 실제 모션보드에 설정되는 값이 다르므로
//    선택된 문자열에서 모션보드에 설정할 값을 추출해서 반환하는 함수입니다.
//  - 변환 할 ComboBox 콘트롤의 포인트를 인자로 전달합니다.
//  - 이 함수를 사용하고자 할 때 데이타 등록을 지정된 양식으로 설정해야됩니다.
//    Format) XX: String, XX=라이브러리로 전달될 값, String=인자 설명
//    Ex) "01: HIGH", "00: COMMAND", "04: HomeSensor"
// --------------------------------------------------------------------------
DWORD TForm1::ConvertComboToAxm(TComboBox *pCboItem)
{
	if(pCboItem == NULL)	return 0;

	String strText;
	long	lCount, lSelData, idxColon;

		lCount = pCboItem->Items->Count;
	if(lCount == 0)		return 0;

		lSelData = pCboItem->ItemIndex;
	if(lSelData < 0)	return 0;

		strText = pCboItem->Items->Strings[lSelData];
		idxColon = strText.Pos(":");
		return StrToInt(strText.SubString(0, idxColon - 1));
}

// ++ =======================================================================
// >> ConvertComboToAxm(...) : 지정한 모션보드에 설정값과 ComboBox콘트롤의
//    Item과 일치하는 Item을 찾아 선택하는 함수.
//  - 실제 모션보드에 설정되는 값과 ComboBox의 Item Index와  다르므로 지정한
//    값과 일치하는 Item을 찾아 선택하고 선택된 Item의 Index를 반환합니다.
//  - 변경하고자하는 ComboBox 콘트롤의 포인트를 인자로 전달합니다.
//  - 이 함수를 사용하고자 할 때 데이타 등록을 지정된 양식으로 설정해야됩니다.
//    Format) XX: String, XX=라이브러리로 전달될 값, String=인자 설명
//    Ex) "01: HIGH", "00: COMMAND", "04: HomeSensor"
// --------------------------------------------------------------------------
long TForm1::ConvertAxmToCombo(TComboBox *pCboItem, DWORD dwCurData)
{
	if(pCboItem == NULL)	return 0;

	long	lCount, lSelData, idxColon;
	String strText;

	lCount = pCboItem->Items->Count;
	if(lCount == 0)	return 0;

	for(int i = 0; i < lCount; i++){
		strText = pCboItem->Items->Strings[i];
				idxColon = strText.Pos(":");
		lSelData = StrToInt(strText.SubString(0, idxColon - 1));
		if(lSelData == (long)dwCurData){
						pCboItem->ItemIndex = i;
						return i;
		}
	}

	pCboItem->ItemIndex = 0;
	return 0;
}
//---------------------------------------------------------------------------

// ++ =======================================================================
// >> OnControlMessage(...) : 인터럽트 메시지 핸들러 함수.
//  - 인터럽트 방식중 윈도 메세지 방식으로 인터럽트를 사용할 경우 라이브러리에서
//    인터럽트 발생시 자동으로 호출되는 인터럽트 메세지 처리 함수입니다.
//  - wParam에는 축정보가 전달됩니다.
//  - lParam에는 인터럽트가 발생된 Bank정보가 전달 됩니다.
// --------------------------------------------------------------------------
void TForm1::OnControlMessage(TMessage Msg)
{
	String strData;

	int	lAxisNo = Msg.WParamLo;		    // Interrupt generation axis number.
	int	nIntrFlag = (int)Msg.LParam;	// Interrupt generation axis location.

	DWORD IntBank0, IntBank1;
	//++ 지정한 축의 인터럽트 발생 Flag를 확인합니다.
	AxmInterruptReadAxisFlag(lAxisNo, 0, &IntBank0);
	AxmInterruptReadAxisFlag(lAxisNo, 1, &IntBank1);

	g_nIntCnt++;
	strData = strData.Format("Msg[%.2d]Axis[%.2d]Flag[0x%.2X]", ARRAYOFCONST((g_nIntCnt, lAxisNo, nIntrFlag)));
		lstIntLog->Items->Add(strData);
}

// ++ =======================================================================
// >> KeMotionInterruptCallback(...) : 인터럽트 처리 콜벡함수.
//  - 인터럽트 방식중 콜벡함수 방식으로 인터럽트를 사용할 경우 라이브러리에서
//    인터럽트 발생시 자동으로 호출되는 인터럽트 콜벡함수입니다.
//  - lActiveNo에는 인터럽트 발생 축 정보가 전달됩니다.
//  - dwFlag에는 인터럽트가 발생된 Bank정보가 전달 됩니다.
// --------------------------------------------------------------------------
void __stdcall KeMotionInterruptCallback(long lActiveNo, DWORD bwFlag)
{
	g_nIntCnt++;
	DWORD IntBank0;
	DWORD IntBank1;
	String strData;

    //++ 지정한 축의 인터럽트 발생 Flag를 확인합니다.
	AxmInterruptReadAxisFlag(lActiveNo, 0, &IntBank0);
	AxmInterruptReadAxisFlag(lActiveNo, 1, &IntBank1);
	strData = strData.Format("CallBack[%.2d]Axis[%.2d]Flag[0x%.2X, 0x%.2X]", ARRAYOFCONST((g_nIntCnt, (int)lActiveNo, (int)IntBank0, (int)IntBank1)));
	Form1->lstIntLog->Items->Add(strData);
}
//---------------------------------------------------------------------------

// ++ =======================================================================
// >> ThreadData(...) : 인터럽트 이벤트 처리 쓰레드.
//  - 인터럽트 방식중 이벤트 방식으로 인터럽트를 사용할 경우 라이브러리에서
//    인터럽트 발생시 자동으로 발생되는 인터럽트 이벤트 처리용 쓰레드입니다.
// --------------------------------------------------------------------------
BOOL TForm1::ThreadData()
{
	int	lAxisNo;
	String  strData;
	DWORD	dwFlag;
	DWORD	IntBank0, IntBank1;

	lAxisNo = m_lAxisNo;

	while(m_bThread[lAxisNo])
	{
		if (WaitForSingleObject(m_hInterrupt[lAxisNo], INFINITE) == WAIT_OBJECT_0)
		{
			AxmInterruptReadAxisFlag(lAxisNo, 0, &IntBank0);
			AxmInterruptReadAxisFlag(lAxisNo, 1, &IntBank1);

			g_nIntCnt++;
			strData = strData.Format("Event[%.2d]Axis[%.2d]Flag[0x%.2X, 0x%.2X]", ARRAYOFCONST((g_nIntCnt, lAxisNo, (int)IntBank0, (int)IntBank1)));
			lstIntLog->Items->Add(strData);
		}
	}

	return TRUE;
}
