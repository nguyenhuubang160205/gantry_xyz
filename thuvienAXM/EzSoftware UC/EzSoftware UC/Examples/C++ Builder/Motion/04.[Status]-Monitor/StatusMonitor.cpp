// SignalMonitor.cpp : implementation file
//
// **************************************************************************
// >> [일자]: 2015.12.15
// >> [개요]: 이 예제는 신호 관련 함수들의 사용법을 익히고 제품별 지원되는
//    기능들을 파악할 수 있도록 작성된 예제입니다.
// >> [중요]: 신호설정 함수 사용시 주의사항
//     1) 제품의 종류에 따라서 신호설정에 사용되는 인자가 달라질 수 있습니다.
//     2) 네트웍 제품의 리미트 신호나 원점신호의 레벨 변경은 서보팩 파라메타를
//        변경해서 바꿀수 있습니다.
// **************************************************************************

//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "StatusMonitor.h"
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

#pragma package(smart_init)
#pragma resource "*.dfm"
TForm1 *Form1;
//---------------------------------------------------------------------------
__fastcall TForm1::TForm1(TComponent* Owner)
        : TForm(Owner)
{
	m_lAxisNo		= -1;	  	// 제어할 축 번호 초기화
	m_lAxisCount	= 0;	  	// 제어 가능한 축갯수 초기화
	m_dwModuleID	= 0;	  	// 제어할 축의 모듈ID 초기화
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
	AxlClose();
}
//---------------------------------------------------------------------------

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

	UpdateState();
}
//---------------------------------------------------------------------------
// ++ =======================================================================
// >> btnLoadFileClick() : "Load File"버튼 클릭시 호출되는 핸들러 함수.
//  - 임의 위치에 있는 Mot(AXM에서 사용하는 설정파일 형식) 파일을 불러옵니다.
//  - 이 함수를 통해 임의의 Mot파일을 불러오면 모션축의 설정값들이 Mot파일의
//    설정값들로 일괄 변경됩니다.
// --------------------------------------------------------------------------
void __fastcall TForm1::btnLoadFileClick(TObject *Sender)
{
	AnsiString    temp;
	OpenDialog1->Filter = "Data File (*.mot)|*.mot|All Files (*.*)|*.*";
	if(OpenDialog1->Execute()){
				temp = OpenDialog1->FileName;
		if (AXT_RT_SUCCESS != AxmMotLoadParaAll((char *)temp.data()))
				ShowMessage("File load fail!");
        }
	UpdateState();
}
//---------------------------------------------------------------------------

// ++ =======================================================================
// >> m_timerTimer(...) : 타이머 이벤트 핸들러 함수.
//  - 일정한 주기로 변경되는 위치/속도/정보등을 Control에 반영합니다.
// --------------------------------------------------------------------------
void __fastcall TForm1::m_timerTimer(TObject *Sender)
{
		// 중요한 정보들만 모니터링 하도록 선택했습니다.
	long	lDigitEnd[MAX_ITEM_END]		= {0, 1, 4, 5, 6, 7, 8, 9, 10, 11, 15, 28, 30, 31};
	long	lDigitMech[MAX_ITEM_MECH]	= {0, 1, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 17};
	long	lDigitDrive[MAX_ITEM_DRIVE]	= {0, 1, 2, 3, 4, 5, 6, 7, 10, 11};
		TCheckBox *chkGroupInpMech[MAX_ITEM_MECH] =
                {chkMechBit00, chkMechBit01, chkMechBit04, chkMechBit05, chkMechBit06,
                chkMechBit07, chkMechBit08, chkMechBit09, chkMechBit10, chkMechBit11,
                chkMechBit12, chkMechBit13, chkMechBit14, chkMechBit17};

        TCheckBox *chkGroupInpEnd[MAX_ITEM_END] =
                {chkEndBit00, chkEndBit01, chkEndBit04, chkEndBit05, chkEndBit06,
                chkEndBit07, chkEndBit08, chkEndBit09, chkEndBit10, chkEndBit11,
                chkEndBit15, chkEndBit28, chkEndBit30, chkEndBit31};

        TCheckBox *chkGroupInpDrive[MAX_ITEM_DRIVE] =
                {chkDriveBit00, chkDriveBit01, chkDriveBit02, chkDriveBit03, chkDriveBit04,
                chkDriveBit05, chkDriveBit06, chkDriveBit07, chkDriveBit10, chkDriveBit11};

	long	lIndex = 0, lCheck = 0;
	DWORD	dwRetCode,  dwStatus = 0;

        //++ 지정 축의 Mechanical Signal Data(현재 기계적인 신호상태)를 확인합니다.
        // ※ [CAUTION] 각 제품별로 하드웨어적인 신호가 다르기 때문에 매뉴얼 및 AXHS.xxx파일을 참고하십시요.
	dwRetCode = AxmStatusReadMechanical(m_lAxisNo, &dwStatus);
	if(dwRetCode == AXT_RT_SUCCESS){
		for(lIndex = 0; lIndex < MAX_ITEM_MECH; lIndex++){
			lCheck = (dwStatus >>  lDigitMech[lIndex]) & 0x1;
                        chkGroupInpMech[lIndex]->Checked = lCheck;
		}
	}

	//++ 지정 축의 End Status(정지 상태)를 확인합니다.
	// ※ [CAUTION] 각 제품별로 정지 상태가 다르기 때문에 매뉴얼 및 AXHS.xxx 파일을 참고하십시요.
	dwRetCode = AxmStatusReadStop(m_lAxisNo, &dwStatus);
	if(dwRetCode == AXT_RT_SUCCESS){
		for(lIndex = 0; lIndex < MAX_ITEM_END; lIndex++){
			lCheck = (dwStatus >>  lDigitEnd[lIndex]) & 0x1;
                        chkGroupInpEnd[lIndex]->Checked = lCheck;
		}
	}

	//++ 지정 축의 Drive Status(모션중 상태)를 확인합니다.
	// ※ [CAUTION] 각 제품별로 모션중 상태가 다르기 때문에 매뉴얼 및 AXHS.xxx 파일을 참고하십시요.
	dwRetCode = AxmStatusReadMotion(m_lAxisNo, &dwStatus);
	if(dwRetCode == AXT_RT_SUCCESS){
		for(lIndex = 0; lIndex < MAX_ITEM_DRIVE; lIndex++){
			lCheck = (dwStatus >>  lDigitDrive[lIndex]) & 0x1;
                        chkGroupInpDrive[lIndex]->Checked = lCheck;
		}
	}
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

	// ※ [CAUTION] 아래와 다른 Mot파일(모션 설정파일)을 사용할 경우 경로를 변경하십시요.
	char szFilePath[] = "..\\..\\..\\EzSoftware\\MotionDefault.mot";

	//++ 지정한 Mot파일의 설정값들로 모션보드의 설정값들을 일괄변경 적용합니다.
	if(AxmMotLoadParaAll(szFilePath) != AXT_RT_SUCCESS){
		ShowMessage("Mot File Not Found.");
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
			 //		strData = strData.Format("%.2d-[ECAT_MOTION]", ARRAYOFCONST((i)));	break;
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
