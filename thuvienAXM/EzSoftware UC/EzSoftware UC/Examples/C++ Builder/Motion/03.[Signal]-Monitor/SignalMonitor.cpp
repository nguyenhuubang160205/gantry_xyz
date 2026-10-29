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

#include "SignalMonitor.h"
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
	// TEdit 컨트롤들의 값들을 오른쪽정렬로 설정
	SetWindowLong(edtSWPosN->Handle, GWL_STYLE,
		GetWindowLong(edtSWPosN->Handle, GWL_STYLE) | ES_RIGHT);
	SetWindowLong(edtSWPosP->Handle, GWL_STYLE,
		GetWindowLong(edtSWPosP->Handle, GWL_STYLE) | ES_RIGHT);

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
		//++ 함수 실행 성공시 지정한 Mot파일의 설정값으로 모션축 설정이 일괄 변경됩니다.
		if (AXT_RT_SUCCESS != AxmMotLoadParaAll((char *)temp.data()))
			ShowMessage("File load fail!");
	}
	UpdateState();	// 변경된 모션축의 상태와 Control들의 상태를 일치시킵니다.
}
//---------------------------------------------------------------------------

// ++ =======================================================================
// >> chkOut_Changed(...) : "Output Bit" 버튼들 클릭시 호출되는 핸들러 함수.
//  - IDC_CHK_OUT_00 ~ IDC_CHK_OUT_04 버튼의 클릭이벤트 발생시 호출됩니다.
// --------------------------------------------------------------------------
void TForm1::chkOut_Changed(DWORD lBitNo, TCheckBox *chkInpX, TCheckBox *chkOutX)
{
	String strData;
	DWORD	dwRetCode, dwOnOff;

	dwOnOff		= chkInpX->Checked;
	//++ 선택한 축에 지정한 Bit의 출력접점을 변경합니다.
	dwRetCode	= AxmSignalWriteOutputBit(m_lAxisNo, lBitNo, dwOnOff);
	if(dwRetCode != AXT_RT_SUCCESS){
		chkOutX->Checked = false;

		strData = strData.Format("AxmSignalWriteOutputBit return error[Code:%.4d]", ARRAYOFCONST(((int)dwRetCode)));
		ShowMessage(strData);
	}
}

void __fastcall TForm1::chkOut00Click(TObject *Sender)
{
        chkOut_Changed(0, chkInp00, chkOut00);
}
//---------------------------------------------------------------------------

void __fastcall TForm1::chkOut01Click(TObject *Sender)
{
        chkOut_Changed(1, chkInp01, chkOut01);
}
//---------------------------------------------------------------------------

void __fastcall TForm1::chkOut02Click(TObject *Sender)
{
        chkOut_Changed(2, chkInp02, chkOut02);
}
//---------------------------------------------------------------------------

void __fastcall TForm1::chkOut03Click(TObject *Sender)
{
        chkOut_Changed(3, chkInp03, chkOut03);
}
//---------------------------------------------------------------------------

void __fastcall TForm1::chkOut04Click(TObject *Sender)
{
        chkOut_Changed(4, chkInp04, chkOut04);
}
//---------------------------------------------------------------------------

// ++ =======================================================================
// >> cboZPhaseChange() : "Z Phase"콤보박스 Item변경시 호출되는 핸들러 함수.
//  - 선택된 축의 Z상 신호 Active Level을 설정합니다.
// ※ [INFO] 특정 네트웍 제품의 경우 Z상 신호레벨 변경을 지원하지않습니다.
// --------------------------------------------------------------------------
void __fastcall TForm1::cboZPhaseChange(TObject *Sender)
{
        String strData;
	DWORD	dwLevel, dwRetCode;

	// 이더켓은 AxmSignalSetZphaseLevel을 지원하지 않음.
	if (m_dwModuleID != AXT_ECAT_MOTION) {
		dwLevel		= ConvertComboToAxm(cboZPhase);
		//++ 선택한 축의 Z상 Active Level을 설정합니다.
		dwRetCode	= AxmSignalSetZphaseLevel(m_lAxisNo, dwLevel);
		if(dwRetCode != AXT_RT_SUCCESS){
			strData = strData.Format("AxmSignalSetZphaseLevel return error[Code:%.4d]", ARRAYOFCONST(((int)dwRetCode)));
			ShowMessage(strData);
		}
	}
}
//---------------------------------------------------------------------------

// ++ =======================================================================
// >> cboAlarmChange() : "Servo Alarm"콤보박스 Item변경시 호출되는 핸들러 함수.
//  - 선택된 축의 Servo Alarm 신호 Active Level/사용유무를 설정합니다.
//  - Servo Alarm 신호를 사용안함으로 설정하면 구동중  Alarm신호가 Active되어도
//    계속해서 목표지점까지 구동하게됩니다.
// ※ [INFO] 특정 네트웍 제품의 경우 Servo Alarm 신호레벨 변경을 지원하지않습니다.
// --------------------------------------------------------------------------
void __fastcall TForm1::cboAlarmChange(TObject *Sender)
{
        String strData;
	DWORD	dwLevel, dwRetCode;

	// 이더켓은 AxmSignalSetServoAlarm 지원하지 않음.
	if (m_dwModuleID != AXT_ECAT_MOTION) {
		dwLevel		= ConvertComboToAxm(cboAlarm);
		//++ 선택한 축의 Servo Alarm 신호 Active Level/사용유무를 설정합니다.
		dwRetCode	= AxmSignalSetServoAlarm(m_lAxisNo, dwLevel);
		if(dwRetCode != AXT_RT_SUCCESS){
			strData = strData.Format("AxmSignalSetServoAlarm return error[Code:%.4d]", ARRAYOFCONST(((int)dwRetCode)));
			ShowMessage(strData);
		}
	}
}
//---------------------------------------------------------------------------

// ++ =======================================================================
// >> cboInpChange() : "Inposition"콤보박스 Item변경시 호출되는 핸들러 함수.
//  - 선택된 축의 Inposition 신호 Active Level/사용유무를 설정합니다.
// ※ [INFO] 특정 네트웍 제품의 경우 Inposition 신호레벨 변경을 지원하지않습니다.
// --------------------------------------------------------------------------
void __fastcall TForm1::cboInpChange(TObject *Sender)
{
        String strData;
	DWORD	dwLevel, dwRetCode;

	dwLevel		= ConvertComboToAxm(cboInp);
	//++ 선택한 축의 Inposition(위치결정완료) 신호 Active Level/사용유무를 설정합니다.
	// - Inposition 신호를 사용안함으로 설정하면 모션제어 칩에서 펄스출력이 완료될 때 즉시구동 종료됩니다.
	// ※ [CAUTION] Inposition 신호를 사용함으로 설정하면 모션제어 칩에서 펄스출력이 완료된 후 서보팩으로 부터
	//              Inposition(위치결정완료) 신호가 Active될 때 까지 모션 구동중으로 됩니다.
	// ※ [CAUTION] Inposition 신호를 사용할 때 Active Level이 맞지않으면 최초 한번 구동 후 모션구동이 종료되지않아
	//              다음 구동을 할 수 없게 됩니다.
	dwRetCode	= AxmSignalSetInpos(m_lAxisNo, dwLevel);
	if(dwRetCode != AXT_RT_SUCCESS){
		strData = strData.Format("AxmSignalSetInpos return error[Code:%.4d]", ARRAYOFCONST(((int)dwRetCode)));
		ShowMessage(strData);
	}
}
//---------------------------------------------------------------------------

// ++ =======================================================================
// >> cboEmgChange() : "Emergency"콤보박스 Item변경시 호출되는 핸들러 함수.
//  - 선택된 축의 Emergency 신호 Active Level/사용유무를 설정합니다.
//  - Emergency 신호를 사용안함으로 설정하면 구동중  EMG신호가 Active되어도
//    계속해서 목표지점까지 구동하게됩니다.
// ※ [INFO] 특정 네트웍 제품의 경우 Emergency 신호를 지원하지않습니다.
// --------------------------------------------------------------------------
void __fastcall TForm1::cboEmgChange(TObject *Sender)
{
        String strData;
	DWORD	dwRetCode, dwStopMode, dwLevel;

	//++ 선택한 축의 Emergency 신호 Active Level/사용유무를 확인합니다.
	dwRetCode = AxmSignalGetStop(m_lAxisNo, &dwStopMode, &dwLevel);
	if(dwRetCode == AXT_RT_SUCCESS){
		dwLevel = ConvertComboToAxm(cboEmg);
		//++ 선택한 축의 Emergency 신호 Active Level/사용유무를 설정합니다.
		AxmSignalSetStop(m_lAxisNo, dwStopMode, dwLevel);
	}else{
		strData = strData.Format("AxmSignalGetStop return error[Code:%.4d]", ARRAYOFCONST(((int)dwRetCode)));
		ShowMessage(strData);
	}
}
//---------------------------------------------------------------------------

// ++ =======================================================================
// >> cboELimitNChange() : "(-) End Limit"콤보박스 Item변경시 호출되는 핸들러 함수.
//  - 선택된 축의 (-) End Limit 신호 Active Level/사용유무를 설정합니다.
//  - (-) End Limit 신호를 사용안함으로 설정하면 (-)방향으로 구동중  (-) End Limit신호가
//    Active되어도 계속해서 목표지점까지 구동하게됩니다.
// ※ [INFO] 특정 네트웍 제품의 경우 (-) End Limit 신호레벨 변경을 지원하지않습니다.
// --------------------------------------------------------------------------
void __fastcall TForm1::cboELimitNChange(TObject *Sender)
{
        String strData;
	DWORD	dwRetCode, dwStopMode = 0, dwPLevel = 0, dwNLevel = 0;

	//++ 선택한 축의 (+/-) End Limit 신호 Active Level/사용유무를 확인합니다.
	dwRetCode = AxmSignalGetLimit(m_lAxisNo, &dwStopMode, &dwPLevel, &dwNLevel);
	if(dwRetCode == AXT_RT_SUCCESS){
		dwNLevel = ConvertComboToAxm(cboELimitN);
		//++ 선택한 축의 (-) End Limit 신호 Active Level/사용유무를 설정합니다.
		AxmSignalSetLimit(m_lAxisNo, dwStopMode, dwPLevel, dwNLevel);
	}else{
		strData = strData.Format("AxmSignalSetLimit return error[Code:%.4d]", ARRAYOFCONST(((int)dwRetCode)));
		ShowMessage(strData);
	}
}
//---------------------------------------------------------------------------

// ++ =======================================================================
// >> cboELimitPChange() : "(+) End Limit"콤보박스 Item변경시 호출되는 핸들러 함수.
//  - 선택된 축의 (+) End Limit 신호 Active Level/사용유무를 설정합니다.
//  - (+) End Limit 신호를 사용안함으로 설정하면 (+)방향으로 구동중  (+) End Limit신호가
//    Active되어도 계속해서 목표지점까지 구동하게됩니다.
// ※ [INFO] 특정 네트웍 제품의 경우 (+) End Limit 신호레벨 변경을 지원하지않습니다.
// --------------------------------------------------------------------------
void __fastcall TForm1::cboELimitPChange(TObject *Sender)
{
        String strData;
	DWORD	dwRetCode, dwStopMode = 0, dwPLevel = 0, dwNLevel = 0;

	//++ 선택한 축의 (+/-) End Limit 신호 Active Level/사용유무를 확인합니다.
	dwRetCode = AxmSignalGetLimit(m_lAxisNo, &dwStopMode, &dwPLevel, &dwNLevel);
	if(dwRetCode == AXT_RT_SUCCESS){
		dwPLevel = ConvertComboToAxm(cboELimitP);
		//++ 선택한 축의 (-) End Limit 신호 Active Level/사용유무를 설정합니다.
		AxmSignalSetLimit(m_lAxisNo, dwStopMode, dwPLevel, dwNLevel);
	}else{
		strData = strData.Format("AxmSignalSetLimit return error[Code:%.4d]", ARRAYOFCONST(((int)dwRetCode)));
		ShowMessage(strData);
	}
}
//---------------------------------------------------------------------------

// ++ =======================================================================
// >> cboServoOnChange() : "Servo On Level"콤보박스 Item변경시 호출되는 핸들러 함수.
//  - 선택된 축의 Servo On/Off 신호 Active Level을 설정합니다.
// ※ [INFO] 특정 네트웍 제품의 경우 Servo On/Off 신호레벨 변경을 지원하지않습니다.
// --------------------------------------------------------------------------
void __fastcall TForm1::cboServoOnChange(TObject *Sender)
{
	String strData;
	DWORD	dwLevel, dwRetCode;

	// 이더켓은 AxmSignalSetServoOnLevel 지원하지 않음.
	if (m_dwModuleID != AXT_ECAT_MOTION) {
		dwLevel		= ConvertComboToAxm(cboServoOn);
		//++ 선택된 축의 Servo On/Off 신호 Active Level을 설정합니다.
		dwRetCode	= AxmSignalSetServoOnLevel(m_lAxisNo, dwLevel);
		if(dwRetCode != AXT_RT_SUCCESS){
			strData = strData.Format("AxmSignalSetServoOnLevel return error[Code:%.4d]", ARRAYOFCONST(((int)dwRetCode)));
			ShowMessage(strData);
		}
	}
}
//---------------------------------------------------------------------------

// ++ =======================================================================
// >> cboAlarmResetChange() : "Alm Reset Level"콤보박스 Item변경시 호출되는 핸들러 함수.
//  - 선택된 축의 Alarm Reset 신호 Active Level을 설정합니다.
// ※ [INFO] 특정 네트웍 제품의 경우 Alarm Reset 신호레벨 변경을 지원하지않습니다.
// --------------------------------------------------------------------------
void __fastcall TForm1::cboAlarmResetChange(TObject *Sender)
{
        String strData;
	DWORD dwLevel, dwRetCode;

	// 이더켓은 AxmSignalSetServoAlarmResetLevel 지원하지 않음.
	if (m_dwModuleID != AXT_ECAT_MOTION) {
		dwLevel		= ConvertComboToAxm(cboAlarmReset);
		//++ 선택된 축의 Alarm Reset 신호 Active Level을 설정합니다.
		dwRetCode	= AxmSignalSetServoAlarmResetLevel(m_lAxisNo, dwLevel);
		if(dwRetCode != AXT_RT_SUCCESS){
			strData = strData.Format("AxmSignalSetServoAlarmResetLevel return error[Code:%.4d]", ARRAYOFCONST(((int)dwRetCode)));
			ShowMessage(strData);
		}
	}
}
//---------------------------------------------------------------------------

// ++ =======================================================================
// >> chkSWEnableClick() : "Enable"버튼 클릭시 호출되는 핸들러 함수.
//  - 선택된 축에 Software Limit기능을 설정합니다.
// --------------------------------------------------------------------------
void __fastcall TForm1::chkSWEnableClick(TObject *Sender)
{
        String strData;
	double	dSWLimitP, dSWLimitN;
	DWORD	dwSWEnable, dwSWStopMode, dwSWRef, dwRetCode;

	dwSWEnable		= chkSWEnable->Checked;
	dwSWStopMode	        = ConvertComboToAxm(cboSWStop);
	dwSWRef			= ConvertComboToAxm(cboSWRef);
	dSWLimitP		= StrToFloat(edtSWPosP->Text);
	dSWLimitN		= StrToFloat(edtSWPosN->Text);

	//++ 지정한 축에 Software Limit기능을 설정합니다.
	// ※ [INFO] Software Limit 기능은 원점검색시 무시됩니다. 원점검색이 완료되면 자동으로 이전 상태가 됩니다.
	dwRetCode = AxmSignalSetSoftLimit(m_lAxisNo, dwSWEnable, dwSWStopMode, dwSWRef, dSWLimitP, dSWLimitN);
	if(dwRetCode != AXT_RT_SUCCESS){
		chkSWEnable->Checked = false;

		strData = strData.Format("AxmSignalSetSoftLimit return error[Code:%.4d]", ARRAYOFCONST(((int)dwRetCode)));
		ShowMessage(strData);
	}
}
//---------------------------------------------------------------------------

// ++ =======================================================================
// >> m_timerTimer(...) : 타이머 이벤트 핸들러 함수.
//  - 일정한 주기로 변경되는 위치/속도/정보등을 Control에 반영합니다.
// --------------------------------------------------------------------------
void __fastcall TForm1::m_timerTimer(TObject *Sender)
{
        long	lBitNo = 0;
	DWORD	dwState1 = 0, dwState2 = 0, dwRetCode;
        TCheckBox *chkGroupInp[5] = {chkInp00, chkInp01, chkInp02, chkInp03, chkInp04};
        TCheckBox *chkGroupOut[5] = {chkOut00, chkOut01, chkOut02, chkOut03, chkOut04};

        dwRetCode = AxmStatusReadMechanical(m_lAxisNo, &dwState1);
        if(dwRetCode == AXT_RT_SUCCESS){
                dwState1  = ((dwState1 & QIMECHANICAL_ZPHASE_LEVEL) == 0) ? 0 : 1;
                chkZPhase->Checked = dwState1;
        }

        //++ Servo Alarm 신호의 상태를 확인합니다.
        dwRetCode = AxmSignalReadServoAlarm(m_lAxisNo, &dwState1);
        if(dwRetCode == AXT_RT_SUCCESS){
                chkAlarm->Checked = dwState1;
        }

        //++ Inposition(위치결정완료) 신호의 상태를 확인합니다.
        dwRetCode = AxmSignalReadInpos(m_lAxisNo, &dwState1);
        if(dwRetCode == AXT_RT_SUCCESS){
                chkInp->Checked = dwState1;
        }

        //++ Emergency 신호의 상태를 확인합니다.
        dwRetCode = AxmSignalReadStop(m_lAxisNo, &dwState1);
        if(dwRetCode == AXT_RT_SUCCESS){
                chkEmg->Checked = dwState1;
        }

        //++ (+/-)End Limit신호의 상태를 확인합니다.
        dwRetCode = AxmSignalReadLimit(m_lAxisNo, &dwState1, &dwState2);
        if(dwRetCode == AXT_RT_SUCCESS){
                chkELimitP->Checked = dwState1;
                chkELimitN->Checked = dwState2;
        }

        for(lBitNo = 0; lBitNo < UIO_OUT5; lBitNo++){
                //++ 범용입력 신호의(Bit00-Bit04) 상태를 확인합니다.
		dwRetCode = AxmSignalReadInputBit(m_lAxisNo, lBitNo, &dwState1);
		if(dwRetCode == AXT_RT_SUCCESS)
                        chkGroupInp[lBitNo]->Checked = dwState1;

		//++ 범용출력 신호의(Bit00-Bit04) 상태를 확인합니다.
		dwRetCode = AxmSignalReadOutputBit(m_lAxisNo, lBitNo, &dwState2);
		if(dwRetCode == AXT_RT_SUCCESS)
                        chkGroupOut[lBitNo]->Checked = dwState2;
        }

	//++ (+/-)Software Limit의 Active 상태를 확인합니다.
	dwRetCode = AxmSignalReadSoftLimit(m_lAxisNo, &dwState1, &dwState2);
	if(dwRetCode == AXT_RT_SUCCESS){
                chkSWLimitP->Checked = dwState1;
                chkSWLimitN->Checked = dwState2;
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
	
	double  dSWLimitP = 0.0, dSWLimitN = 0.0;
	DWORD	dwSWEnable = 0, dwSWStopMode = 0, dwSWRef = 0;
	DWORD	dwLevel1 = 0, dwLevel2 = 0, dwRetCode;

        // 각 제품별 지원여부에 따라 콘트롤 값들을 변경합니다.
	switch(m_dwModuleID){

            case AXT_SMC_4V04:
            case AXT_SMC_R1V04:
			case AXT_SMC_2V04:
            case AXT_SMC_R1V04PM2Q:
            case AXT_SMC_R1V04PM2QE:
            case AXT_SMC_R1V04MLIIIPM:
                 cboZPhase->Items->Clear();
                 cboZPhase->Enabled = true;
                 cboZPhase->Items->Add("00:LOW");
                 cboZPhase->Items->Add("01:HIGH");

                 cboAlarm->Items->Clear();
                 cboAlarm->Enabled = true;
                 cboAlarm->Items->Add("00:LOW");
                 cboAlarm->Items->Add("01:HIGH");
                 cboAlarm->Items->Add("02:UNUSED");

                 cboInp->Items->Clear();
                 cboInp->Enabled = true;
                 cboInp->Items->Add("00:LOW");
                 cboInp->Items->Add("01:HIGH");
                 cboInp->Items->Add("02:UNUSED");

                 cboEmg->Items->Clear();
                 cboEmg->Enabled = true;
                 cboEmg->Items->Add("00:LOW");
                 cboEmg->Items->Add("01:HIGH");
                 cboEmg->Items->Add("02:UNUSED");

                 cboELimitN->Items->Clear();
                 cboELimitN->Enabled = true;
                 cboELimitN->Items->Add("00:LOW");
                 cboELimitN->Items->Add("01:HIGH");
                 cboELimitN->Items->Add("02:UNUSED");

                 cboELimitP->Items->Clear();
                 cboELimitP->Enabled = true;
                 cboELimitP->Items->Add("00:LOW");
                 cboELimitP->Items->Add("01:HIGH");
                 cboELimitP->Items->Add("02:UNUSED");

                 cboServoOn->Items->Clear();
                 cboServoOn->Enabled = true;
                 cboServoOn->Items->Add("00:LOW");
                 cboServoOn->Items->Add("01:HIGH");

                 cboAlarmReset->Items->Clear();
                 cboAlarmReset->Enabled = true;
                 cboAlarmReset->Items->Add("00:LOW");
                 cboAlarmReset->Items->Add("01:HIGH");

                 cboSWRef->Items->Clear();
                 cboSWRef->Enabled = true;
                 cboSWRef->Items->Add("00:COMMAND");
                 cboSWRef->Items->Add("01:ACTUAL");

                 cboSWStop->Items->Clear();
                 cboSWStop->Enabled = true;
                 cboSWStop->Items->Add("00:E_STOP");
                 cboSWStop->Items->Add("01:S_STOP");

                 edtSWPosN->Enabled = true;
                 edtSWPosP->Enabled = true;
                 chkSWEnable->Enabled = true;
                 break;

	case AXT_SMC_R1V04A4:
                 cboZPhase->Items->Clear();
                 cboZPhase->Enabled = false;
                 cboZPhase->Items->Add("02:UNUSED");

                 cboAlarm->Items->Clear();
                 cboAlarm->Enabled = true;
                 cboAlarm->Items->Add("01:HIGH");
                 cboAlarm->Items->Add("02:UNUSED");

                 cboInp->Items->Clear();
                 cboInp->Enabled = true;
                 cboInp->Items->Add("01:HIGH");
                 cboInp->Items->Add("02:UNUSED");

                 cboEmg->Items->Clear();
                 cboEmg->Enabled = true;
                 cboEmg->Items->Add("00:LOW");
                 cboEmg->Items->Add("02:UNUSED");

                 cboELimitN->Items->Clear();
                 cboELimitN->Enabled = true;
                 cboELimitN->Items->Add("00:LOW");
                 cboELimitN->Items->Add("02:UNUSED");

                 cboELimitP->Items->Clear();
                 cboELimitP->Enabled = true;
                 cboELimitP->Items->Add("00:LOW");
                 cboELimitP->Items->Add("02:UNUSED");

                 cboServoOn->Items->Clear();
                 cboServoOn->Enabled = false;
                 cboServoOn->Items->Add("01:HIGH");

                 cboAlarmReset->Items->Clear();
                 cboAlarmReset->Enabled = false;
                 cboAlarmReset->Items->Add("01:HIGH");

                 cboSWRef->Items->Clear();
                 cboSWRef->Enabled = false;
				 cboSWRef->Items->Add("02:UNUSED");

                 cboSWStop->Items->Clear();
                 cboSWStop->Enabled = false;
                 cboSWStop->Items->Add("02:UNUSED");

                 edtSWPosN->Enabled = false;
                 edtSWPosP->Enabled = false;
                 chkSWEnable->Enabled = false;
		 break;

	case AXT_SMC_R1V04MLIIPM:
                 cboZPhase->Items->Clear();
                 cboZPhase->Enabled = false;
                 cboZPhase->Items->Add("02:UNUSED");

                 cboAlarm->Items->Clear();
                 cboAlarm->Enabled = false;
                 cboAlarm->Items->Add("02:UNUSED");

                 cboInp->Items->Clear();
                 cboInp->Enabled = false;
                 cboInp->Items->Add("02:UNUSED");

                 cboEmg->Items->Clear();
                 cboEmg->Enabled = false;
                 cboEmg->Items->Add("02:UNUSED");

                 cboELimitN->Items->Clear();
                 cboELimitN->Enabled = false;
                 cboELimitN->Items->Add("02:UNUSED");

                 cboELimitP->Items->Clear();
                 cboELimitP->Enabled = false;
                 cboELimitP->Items->Add("02:UNUSED");

                 cboServoOn->Items->Clear();
                 cboServoOn->Enabled = false;
                 cboServoOn->Items->Add("01:HIGH");

                 cboAlarmReset->Items->Clear();
                 cboAlarmReset->Enabled = false;
                 cboAlarmReset->Items->Add("01:HIGH");

                 cboSWRef->Items->Clear();
                 cboSWRef->Enabled = false;
                 cboSWRef->Items->Add("02:UNUSED");

                 cboSWStop->Items->Clear();
                 cboSWStop->Enabled = false;
                 cboSWStop->Items->Add("02:UNUSED");

                 edtSWPosN->Enabled = false;
                 edtSWPosP->Enabled = false;
                 chkSWEnable->Enabled = false;
		 break;

    case AXT_SMC_R1V04MLIISV:
    case AXT_SMC_R1V04A5:
    case AXT_SMC_R1V04MLIICL:
    case AXT_SMC_R1V04MLIICR:
    case AXT_SMC_R1V04MLIIORI:
    case AXT_SMC_R1V04SIIIHMIV:
    case AXT_SMC_R1V04SIIIHMIV_R:
                 cboZPhase->Items->Clear();
                 cboZPhase->Enabled = false;
                 cboZPhase->Items->Add("02:UNUSED");

                 cboAlarm->Items->Clear();
                 cboAlarm->Enabled = true;
                 cboAlarm->Items->Add("01:HIGH");
                 cboAlarm->Items->Add("02:UNUSED");

                 cboInp->Items->Clear();
                 cboInp->Enabled = true;
                 cboInp->Items->Add("01:HIGH");
                 cboInp->Items->Add("02:UNUSED");

                 cboEmg->Items->Clear();
                 cboEmg->Enabled = false;
                 cboEmg->Items->Add("02:UNUSED");

                 cboELimitN->Items->Clear();
                 cboELimitN->Enabled = true;
                 cboELimitN->Items->Add("01:HIGH");
                 cboELimitN->Items->Add("02:UNUSED");

                 cboELimitP->Items->Clear();
                 cboELimitP->Enabled = true;
                 cboELimitP->Items->Add("01:HIGH");
                 cboELimitP->Items->Add("02:UNUSED");

                 cboServoOn->Items->Clear();
                 cboServoOn->Enabled = false;
                 cboServoOn->Items->Add("01:HIGH");

                 cboAlarmReset->Items->Clear();
                 cboAlarmReset->Enabled = false;
                 cboAlarmReset->Items->Add("01:HIGH");

                 cboSWRef->Items->Clear();
                 cboSWRef->Enabled = false;
                 cboSWRef->Items->Add("02:UNUSED");

				 cboSWStop->Items->Clear();
                 cboSWStop->Enabled = false;
                 cboSWStop->Items->Add("02:UNUSED");

                 edtSWPosN->Enabled = false;
                 edtSWPosP->Enabled = false;
                 chkSWEnable->Enabled = false;
	         break;
	case AXT_SMC_R1V04MLIIISV:
	case AXT_SMC_R1V04MLIIISV_MD:
	case AXT_SMC_R1V04MLIIIS7S:
	case AXT_SMC_R1V04MLIIIS7W:
		 cboZPhase->Items->Clear();
                 cboZPhase->Enabled = false;
                 cboZPhase->Items->Add("02:UNUSED");

                 cboAlarm->Items->Clear();
                 cboAlarm->Enabled = true;
                 cboAlarm->Items->Add("00:LOW");
                 cboAlarm->Items->Add("01:HIGH");
                 cboAlarm->Items->Add("02:UNUSED");

                 cboInp->Items->Clear();
                 cboInp->Enabled = true;
                 cboInp->Items->Add("01:HIGH");
                 cboInp->Items->Add("02:UNUSED");

                 cboEmg->Items->Clear();
                 cboEmg->Enabled = false;
                 cboEmg->Items->Add("02:UNUSED");

                 cboELimitN->Items->Clear();
                 cboELimitN->Enabled = true;
                 cboELimitN->Items->Add("00:LOW");
                 cboELimitN->Items->Add("01:HIGH");
                 cboELimitN->Items->Add("02:UNUSED");

                 cboELimitP->Items->Clear();
                 cboELimitP->Enabled = true;
                 cboELimitP->Items->Add("00:LOW");
                 cboELimitP->Items->Add("01:HIGH");
                 cboELimitP->Items->Add("02:UNUSED");

                 cboServoOn->Items->Clear();
                 cboServoOn->Enabled = true;
                 cboServoOn->Items->Add("00:LOW");
                 cboServoOn->Items->Add("01:HIGH");

                 cboAlarmReset->Items->Clear();
                 cboAlarmReset->Enabled = false;
                 cboAlarmReset->Items->Add("01:HIGH");

                 cboSWRef->Items->Clear();
                 cboSWRef->Enabled = false;
                 cboSWRef->Items->Add("02:UNUSED");

                 cboSWStop->Items->Clear();
                 cboSWStop->Enabled = false;
                 cboSWStop->Items->Add("02:UNUSED");

                 edtSWPosN->Enabled = false;
                 edtSWPosP->Enabled = false;
                 chkSWEnable->Enabled = false;
		 break;

		 case AXT_ECAT_MOTION:
				 cboZPhase->Items->Clear();
				 cboZPhase->Enabled = false;
                 cboZPhase->Items->Add("02:UNUSED");

                 cboAlarm->Items->Clear();
				 cboAlarm->Enabled = true;
				 cboAlarm->Items->Add("01:HIGH");
				 cboAlarm->Items->Add("02:UNUSED");

				 cboInp->Items->Clear();
				 cboInp->Enabled = true;
				 cboInp->Items->Add("00:LOW");
				 cboInp->Items->Add("01:HIGH");
				 cboInp->Items->Add("02:UNUSED");
				 cboInp->Items->Add("03:USED");

                 cboEmg->Items->Clear();
                 cboEmg->Enabled = true;
                 cboEmg->Items->Add("00:LOW");
                 cboEmg->Items->Add("01:HIGH");
				 cboEmg->Items->Add("02:UNUSED");
				 cboEmg->Items->Add("03:USED");

                 cboELimitN->Items->Clear();
                 cboELimitN->Enabled = true;
                 cboELimitN->Items->Add("00:LOW");
                 cboELimitN->Items->Add("01:HIGH");
				 cboELimitN->Items->Add("02:UNUSED");
				 cboELimitN->Items->Add("03:USED");

				 cboELimitP->Items->Clear();
				 cboELimitP->Enabled = true;
				 cboELimitP->Items->Add("00:LOW");
				 cboELimitP->Items->Add("01:HIGH");
				 cboELimitP->Items->Add("02:UNUSED");
				 cboELimitP->Items->Add("03:USED");

                 cboServoOn->Items->Clear();
				 cboServoOn->Enabled = false;
				 cboServoOn->Items->Add("01:HIGH");

				 cboAlarmReset->Items->Clear();
				 cboAlarmReset->Enabled = false;
                 cboAlarmReset->Items->Add("01:HIGH");

                 cboSWRef->Items->Clear();
				 cboSWRef->Enabled = false;
				 cboSWRef->Items->Add("02:UNUSED");

				 cboSWStop->Items->Clear();
				 cboSWStop->Enabled = false;
				 cboSWStop->Items->Add("02:UNUSED");

				 edtSWPosN->Enabled = false;
				 edtSWPosP->Enabled = false;
                 chkSWEnable->Enabled = false;
				 break;
	}

	//++ 선택한 축의 Z상 신호 Active Level 설정값을 확인합니다.
	dwRetCode = AxmSignalGetZphaseLevel(m_lAxisNo, &dwLevel1);
	if(dwRetCode != AXT_RT_SUCCESS)	dwLevel1 = UNUSED;
	ConvertAxmToCombo(cboZPhase, dwLevel1);

	//++ 선택한 축의 Servo Alarm 신호 Active Level/사용유무를 확인합니다.
	dwRetCode = AxmSignalGetServoAlarm(m_lAxisNo, &dwLevel1);
	if(dwRetCode != AXT_RT_SUCCESS)	dwLevel1 = UNUSED;
	ConvertAxmToCombo(cboAlarm, dwLevel1);

	//++ 선택한 축의 Inposition(위치결정완료) 신호 Active Level/사용유무를 확인합니다.
	dwRetCode = AxmSignalGetInpos(m_lAxisNo, &dwLevel1);
	if(dwRetCode != AXT_RT_SUCCESS)	dwLevel1 = UNUSED;
	ConvertAxmToCombo(cboInp, dwLevel1);

	//++ 선택한 축의 Emergency 신호 Active Level/사용유무를 확인합니다.
	dwRetCode = AxmSignalGetStop(m_lAxisNo, NULL, &dwLevel1);
	if(dwRetCode != AXT_RT_SUCCESS)	dwLevel1 = UNUSED;
	ConvertAxmToCombo(cboEmg, dwLevel1);

	//++ 선택한 축의 (+/-) End Limit 신호 Active Level/사용유무를 확인합니다.
	dwRetCode = AxmSignalGetLimit(m_lAxisNo, NULL, &dwLevel1, &dwLevel2);
	if(dwRetCode != AXT_RT_SUCCESS)	dwLevel1 = dwLevel2 = UNUSED;
	ConvertAxmToCombo(cboELimitP, dwLevel1);
	ConvertAxmToCombo(cboELimitN, dwLevel2);

	//++ 선택된 축의 Servo On/Off 신호 Active Level을 확인합니다.
	dwRetCode = AxmSignalGetServoOnLevel(m_lAxisNo, &dwLevel1);
	if(dwRetCode != AXT_RT_SUCCESS)	dwLevel1 = UNUSED;
	ConvertAxmToCombo(cboServoOn, dwLevel1);

	//++ 선택된 축의 Alarm Reset 신호 Active Level을 확인합니다.
	dwRetCode = AxmSignalGetServoAlarmResetLevel(m_lAxisNo, &dwLevel1);
	if(dwRetCode != AXT_RT_SUCCESS)	dwLevel1 = UNUSED;
	ConvertAxmToCombo(cboAlarmReset, dwLevel1);

	//++ 지정한 축에 Software Limit기능을 확인합니다.
	dwRetCode = AxmSignalGetSoftLimit(m_lAxisNo, &dwSWEnable, &dwSWStopMode, &dwSWRef, &dSWLimitP, &dSWLimitN);
	if(dwRetCode != AXT_RT_SUCCESS)	dwSWStopMode = dwSWRef = UNUSED;

	ConvertAxmToCombo(cboSWRef, dwSWRef);
	ConvertAxmToCombo(cboSWStop, dwSWStopMode);
	edtSWPosP->Text = edtSWPosP->Text.Format("%.3f", ARRAYOFCONST((dSWLimitP)));
	edtSWPosN->Text = edtSWPosN->Text.Format("%.3f", ARRAYOFCONST((dSWLimitN)));
	chkSWEnable->Checked = (dwSWEnable == 1) ? true : false;

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


