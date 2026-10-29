// HomeSearch.cpp : implementation file
//
// **************************************************************************
// >> [일자]: 2015.12.16
// >> [개요]: 이 예제는 원점검색 함수들의 사용법을 익히고 원점검색 방법과 각
//    단계별 사용하는 원점검색 속도 설정법을 이해하여 빠르고 정밀한 원점 검색 
//    방법에 대해 학습하는 예제입니다.
// >> [중요]: 원점검색 방법 및 원점검색 단계별 속도사용에 대해
//     1) 원점검색은 기본적으로 5번의 신호검출 과정을 거쳐 완료됩니다.
//     2) 원점센서 검출 여부를 판단하여 원점검색 진행 방향으로 신호를 검출할 지
//        원점검색 반대방향으로 신호검출을 진행할지를 판단합니다.
//     3) 1차 원점신호 감지시에는 가감속이 있는 구동을 하여 비교적 빠른 속도로
//        원점신호를 감지합니다.
//     4) 1차 원점신호 감지 후 반대방향으로 2단계 속도로 1차 때와 마찬가지로 
//        가감속이 있는 구동을 하여 기구물이 원점센서의 검색진행 반대편에 위치
//        하도록 합니다.
//     5) 3단계 속도를 이용하여 가감속이 없이 원점신호를 검출하게 됩니다. 
//     6) 이 후 Z상검출 사용여부에 따라 4단계/5단계 신호 검출을 하여 빠르고 
//        정밀하게 원점검출을 완료하게 됩니다.
// >> [중요]: 원점검색 속도설정에 대해
//     1) dVelFirst: 초기 원점신호가 감지되지 않았을 때 원점신호 검색 방향으로 
//        On 상태를 검출할 때의 속도
//     2) dVelSecond: 초기 원점신호가 감지되어 있어 원점신호 검색 반대 방향으로 
//        Off 상태를 검출할 때의 속도
//     3) dVelFirst, dVelSecond속도는 원점검색 반복 정밀도 보다는 원점검색 시간과
//        관련이 깊습니다. 따라서 dVelFirst, dVelSecond 속도는 빠르게 설정합니다.
//     4) dVelThird: 1차 원점신호 위치를 검출하기위해 On상태를 검출할 때의 속도
//     5) dVelLasts: 최종 원점신호 위치를 검출하기위해 On상태를 검출할 때의 속도
//     6) dVelLasts속도는 원점검색 마지막에 사용되어 반복 정밀도와 밀접한 관련이 
//        있으므로 10 PPS정도 설정하면 정밀하게 원점검색을 구현 할 수 있습니다.
// **************************************************************************

//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "HomeSearch.h"
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
        m_lAxisNo	= -1;		     // 제어할 축 번호 초기화
	m_lAxisCount	= 0;		     // 제어 가능한 축갯수 초기화
	m_dwModuleID	= 0;		     // 제어할 축의 모듈ID 초기화
	m_dwOldResult	= HOME_ERR_UNKNOWN;  // 원점검색 결과 초기화

        // TEdit 컨트롤들의 값들을 오른쪽정렬로 설정
        SetWindowLong(stcCmdPos->Handle, GWL_STYLE,
                GetWindowLong(stcCmdPos->Handle, GWL_STYLE) | ES_RIGHT);
        SetWindowLong(stcActPos->Handle, GWL_STYLE,
                GetWindowLong(stcActPos->Handle, GWL_STYLE) | ES_RIGHT);
        SetWindowLong(stcCmdVel->Handle, GWL_STYLE,
                GetWindowLong(stcCmdVel->Handle, GWL_STYLE) | ES_RIGHT);
        SetWindowLong(edtHomeOffset->Handle, GWL_STYLE,
                GetWindowLong(edtHomeOffset->Handle, GWL_STYLE) | ES_RIGHT);
        SetWindowLong(edtHomeClrTime->Handle, GWL_STYLE,
                GetWindowLong(edtHomeClrTime->Handle, GWL_STYLE) | ES_RIGHT);
        SetWindowLong(edtVelFirst->Handle, GWL_STYLE,
                GetWindowLong(edtVelFirst->Handle, GWL_STYLE) | ES_RIGHT);
        SetWindowLong(edtVelSecond->Handle, GWL_STYLE,
                GetWindowLong(edtVelSecond->Handle, GWL_STYLE) | ES_RIGHT);
        SetWindowLong(edtVelThird->Handle, GWL_STYLE,
                GetWindowLong(edtVelThird->Handle, GWL_STYLE) | ES_RIGHT);
        SetWindowLong(edtVelLast->Handle, GWL_STYLE,
                GetWindowLong(edtVelLast->Handle, GWL_STYLE) | ES_RIGHT);
        SetWindowLong(edtAccFirst->Handle, GWL_STYLE,
                GetWindowLong(edtAccFirst->Handle, GWL_STYLE) | ES_RIGHT);
        SetWindowLong(edtAccSecond->Handle, GWL_STYLE,
                GetWindowLong(edtAccSecond->Handle, GWL_STYLE) | ES_RIGHT);
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
		if (AXT_RT_SUCCESS != AxmMotLoadParaAll((char *)temp.data()))
                        ShowMessage("File load fail!");
        }
	UpdateState();
}
//---------------------------------------------------------------------------

// ++ =======================================================================
// >> btnPosClearClick() : "Position Clear"버튼 클릭시 호출되는 핸들러 함수.
//  - 선택된 축의 위치정보를 0.0으로 설정합니다.
//  - AxmStatusSetPosMatch함수는 AxmStatusSetCmdPos, AxmStatusSetActPos 함수를
//    사용하는것과 동일한 효과를 냅니다.
// --------------------------------------------------------------------------
void __fastcall TForm1::btnPosClearClick(TObject *Sender)
{
        //++ Command위치와 Actual위치를 지정한 값으로 설정합니다.
        AxmStatusSetPosMatch(m_lAxisNo, 0.0);
}
//---------------------------------------------------------------------------

// ++ =======================================================================
// >> chkServoOnClick() : "Servo On"버튼 클릭시 호출되는 핸들러 함수.
//  - 선택된 축을 체크버튼의 상태에 따라 서보 On/Off 합니다.
// --------------------------------------------------------------------------
void __fastcall TForm1::chkServoOnClick(TObject *Sender)
{
        DWORD dwOnOff;
	dwOnOff = chkServoOn->Checked;
	//++ 지정 축의 Servo On/Off 신호를 출력합니다.
	AxmSignalServoOn(m_lAxisNo, dwOnOff);
}
//---------------------------------------------------------------------------

// ++ =======================================================================
// >> cboHomeLevelChange() : "Home Level"콤보박스 Item변경시 호출되는 핸들러 함수.
//  - 선택된 축의 원점신호 Active Level을 설정합니다.
// ※ [CAUTION] 특정 네트웍 제품의 경우 원점신호레벨 변경을 지원하지않습니다.
// --------------------------------------------------------------------------
void __fastcall TForm1::cboHomeLevelChange(TObject *Sender)
{
        DWORD	dwLevel, dwRetCode;

    // 이더켓은 AxmHomeSetSignalLevel을 지원하지 않음.
	if (m_dwModuleID != AXT_ECAT_MOTION) {
		dwLevel		= ConvertComboToAxm(cboHomeLevel);
		//++ 지정한 축의 원점신호 Active Level을 변경합니다.
		dwRetCode	= AxmHomeSetSignalLevel(m_lAxisNo, dwLevel);
		if(dwRetCode != AXT_RT_SUCCESS){
			String strData;
			strData = strData.Format("AxmHomeSetSignalLevel return error[Code:%.4d]", ARRAYOFCONST(((int)dwRetCode)));
			ShowMessage(strData);
		}
	}
}
//---------------------------------------------------------------------------

// ++ =======================================================================
// >> btnSetMethodClick() : "Set Method"버튼 클릭시 호출되는 핸들러 함수.
//  - 선택된 축의 원점검색 방향, 신호, Z상 검출여부, Offset등을 설정합니다.
//  - 원점검색시 Z상 신호의 검출을 사용함으로 설정하였을 경우 1차로 지정한
//    원점신호를 검출 완료한 후 Z상 신호를 추가적으로 검출하게 됩니다.
// ※ [CAUTION] Z상의 경우 모터와 Ballscrew를 연결해주는 커플링이 풀리거나
//    해체할 경우 Z상 위치가 변경되므로 원점검색 위치가 달라지게됩니다.
// --------------------------------------------------------------------------
void __fastcall TForm1::btnSetMethodClick(TObject *Sender)
{
        long	lHomeDir = 0;
	DWORD	dwRetCode;
	DWORD   dwHomeSignal = HomeSensor, dwZPhaseUse = DISABLE;
	double	dHomeClrTime = 0.0, dHomeOffset = 0.0;

	lHomeDir	= ConvertComboToAxm(cboHomeDir);
	dwHomeSignal	= ConvertComboToAxm(cboHomeSignal);
	dwZPhaseUse	= ConvertComboToAxm(cboZPhaseUse);

	dHomeOffset	= StrToFloat(edtHomeOffset->Text);
	dHomeClrTime	= StrToFloat(edtHomeClrTime->Text);

	//++ 지정한 축의 원점검색 방법을 변경합니다.
	dwRetCode = AxmHomeSetMethod(m_lAxisNo, lHomeDir, dwHomeSignal, dwZPhaseUse, dHomeClrTime, dHomeOffset);
	if(dwRetCode != AXT_RT_SUCCESS){
                String strData;
		strData = strData.Format("AxmHomeSetMethod return error[Code:%.4d]", ARRAYOFCONST(((int)dwRetCode)));
		ShowMessage(strData);
	}
}
//---------------------------------------------------------------------------

// ++ =======================================================================
// >> btnSetVelocityClick() : "Set Velocity"버튼 클릭시 호출되는 핸들러 함수.
//  - 선택된 축의 단계별 원점검색 속도를 설정합니다.
//  - 원점검색의 단계를 세분화해 빠르고 정밀하게 원점검색을 구현할 수 있습니다.
// ※ [CAUTION] dVelFirst, dVelSecond는 초기 원점검색 속도로 원점검색 반복 정밀도
//    보다는 원점검색 시간과 관련이 깊습니다. 따라서 dVelFirst, dVelSecond 속도는
//    비교적 빠르게 설정하고 원점검색 마지막에 사용되어 반복 정밀도와 밀접한 관련이
//    있는 dVelLasts속도 10 PPS정도에 설정하면 빠르고 정밀하게 원점검색을 구현
//    할 수 있습니다.
// --------------------------------------------------------------------------
void __fastcall TForm1::btnSetVelocityClick(TObject *Sender)
{
        DWORD	dwRetCode;
	double	dVelFirst, dVelSecond, dVelThird, dVelLast, dAccFirst, dAccSecond;

	// 각각의 Edit 콘트롤에서 설정값을 가져옴
	dVelFirst	= StrToFloat(edtVelFirst->Text);
	dVelSecond	= StrToFloat(edtVelSecond->Text);
	dVelThird	= StrToFloat(edtVelThird->Text);
	dVelLast	= StrToFloat(edtVelLast->Text);

	dAccFirst	= StrToFloat(edtAccFirst->Text);
	dAccSecond	= StrToFloat(edtAccSecond->Text);

	//++ 원점검색에 사용되는 단계별 속도를 설정합니다.
	dwRetCode	= AxmHomeSetVel(m_lAxisNo, dVelFirst, dVelSecond, dVelThird, dVelLast, dAccFirst, dAccSecond);
	if(dwRetCode != AXT_RT_SUCCESS){
		String strData;
		strData = strData.Format("AxmHomeSetVel return error[Code:%.4d]", ARRAYOFCONST(((int)dwRetCode)));
		ShowMessage(strData);
	}
}
//---------------------------------------------------------------------------

// ++ =======================================================================
// >> btnHomeStartClick() : "Home Start"버튼 클릭시 호출되는 핸들러 함수.
//  - 선택한 축으로 원점검색을 진행합니다.
//  - 원점검색의 단계를 세분화해 빠르고 정밀하게 원점검색을 구현할 수 있습니다.
// ※ [CAUTION] 원점검색시 라이브러리 내부에서 해당축의 원점검색을 수행 할 쓰레드가
//    자동 생성되어 원점검색을 순차적으로 수행한 후 자동 종료됩니다. 따라서 단일
//    CPU시스템의 경우 사용자 프로그램에서 CPU를 100% 점유할 경우 원점 검색 진행이
//    원할하게 되지 않을 수 있습니다.
// --------------------------------------------------------------------------
void __fastcall TForm1::btnHomeStartClick(TObject *Sender)
{
        DWORD	dwRetCode;

	//++ 지정한 축에 원점검색을 진행합니다.
	dwRetCode = AxmHomeSetStart(m_lAxisNo);
	if(dwRetCode != AXT_RT_SUCCESS){
		String strData;
		strData = strData.Format("AxmHomeSetStart return error[Code:%.4d]", ARRAYOFCONST(((int)dwRetCode)));
		ShowMessage(strData);
	}
}
//---------------------------------------------------------------------------

// ++ =======================================================================
// >> btnMoveStopClick() : "Move Stop"버튼 클릭시 호출되는 핸들러 함수.
//  - 지정한 축의 구동을 종료합니다. 만약 원점검색 중이면 검색을 중단하고 원점검색
//    결과를 HOME_ERR_USER_BREAK로 설정합니다.
// --------------------------------------------------------------------------
void __fastcall TForm1::btnMoveStopClick(TObject *Sender)
{
        AxmMoveSStop(m_lAxisNo);
}
//---------------------------------------------------------------------------

// ++ =======================================================================
// >> m_timerDisplayTimer(...) : 타이머 이벤트 핸들러 함수.
//  - 일정한 주기로 변경되는 위치/속도/정보등을 Control에 반영합니다.
// --------------------------------------------------------------------------
void __fastcall TForm1::m_timerDisplayTimer(TObject *Sender)
{
        double	dCmdPos = 0.0, dActPos = 0.0, dCmdVel = 0.0;

        //++ 지정한 축의 지령(Command)위치를 반환합니다.
	AxmStatusGetCmdPos(m_lAxisNo, &dCmdPos);
	if(m_dOldCmdPos != dCmdPos){
		stcCmdPos->Text = stcCmdPos->Text.Format("%.3f", ARRAYOFCONST((dCmdPos)));
		m_dOldCmdPos = dCmdPos;
	}

	//++ 지정한 축의 실제(Feedback)위치를 반환합니다.
	AxmStatusGetActPos(m_lAxisNo, &dActPos);
	if(m_dOldActPos != dActPos){
				stcActPos->Text = stcActPos->Text.Format("%.3f", ARRAYOFCONST((dActPos)));
		m_dOldActPos = dActPos;
	}

	//++ 지정한 축의 구동 속도를 반환합니다.
	AxmStatusReadVel(m_lAxisNo, &dCmdVel);
	if(m_dOldCmdVel != dCmdVel){
				stcCmdVel->Text = stcCmdVel->Text.Format("%.3f", ARRAYOFCONST((dCmdVel)));
		m_dOldCmdVel = dCmdVel;
	}
}
//---------------------------------------------------------------------------

void __fastcall TForm1::m_timerHomeInfoTimer(TObject *Sender)
{
        DWORD	dwRetCode, dwState = 0;
	DWORD	dwStepMain = 0, dwStepSub = 0;

        //++ 지정한 축의 원점신호의 상태를 확인합니다.
	dwRetCode = AxmHomeReadSignal(m_lAxisNo, &dwState);
	if(dwRetCode == AXT_RT_SUCCESS){
                chkHomeState->Checked = dwState;
	}

	//++ 지정한 축의 원점검색 결과를 확인합니다.
	AxmHomeGetResult(m_lAxisNo, &dwState);
	if(m_dwOldResult != dwState){
                stcHomeResult->Text = TranslateHomeResult(dwState);
		m_dwOldResult = dwState;
	}

	//++ 지정한 축의 원점검색 진행율을 확인합니다.
	dwRetCode = AxmHomeGetRate(m_lAxisNo, &dwStepMain, &dwStepSub);
	if(dwRetCode == AXT_RT_SUCCESS){
		if(StrToInt(stcHomeStepMain->Text) != dwStepMain)
						stcHomeStepMain->Text = stcHomeStepMain->Text.Format("%d", ARRAYOFCONST(((int)dwStepMain)));

                if(StrToInt(stcHomeStepSub->Text) != dwStepSub)
						stcHomeStepSub->Text = stcHomeStepSub->Text.Format("%d", ARRAYOFCONST(((int)dwStepSub)));

                prgHomeRate->Position = dwStepSub;
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
	
	long	lHomeDir = 0;
	DWORD	dwRetCode, dwLevel = 0;
	DWORD	dwHomeSignal = 0, dwZPhaseUse = 0;
	double	dHomeClrTime = 0.0, dHomeOffset = 0.0;

	double	dVelFirst = 100.0, dVelSecond = 50.0, dVelThird = 5.0, dVelLast = 1.0, dAccFirst = 400.0, dAccSecond = 100.0;

	// 각 제품별 지원여부에 따라 콘트롤 값들을 변경합니다.
	switch(m_dwModuleID){      
	case AXT_SMC_4V04:
	case AXT_SMC_R1V04:
	case AXT_SMC_2V04:
	case AXT_SMC_R1V04PM2Q:
	case AXT_SMC_R1V04PM2QE:
	case AXT_SMC_R1V04MLIIIPM:
	case AXT_SMC_R1V04MLIIISV:
	case AXT_SMC_R1V04MLIIISV_MD:
	case AXT_SMC_R1V04MLIIIS7S:
	case AXT_SMC_R1V04MLIIIS7W:
	case AXT_ECAT_MOTION:
		cboHomeLevel->Items->Clear();
		cboHomeLevel->Enabled = true;
		cboHomeLevel->Items->Add("00: LOW");
		cboHomeLevel->Items->Add("01: HIGH");

		cboHomeSignal->Items->Clear();
		cboHomeSignal->Enabled = true;
		cboHomeSignal->Items->Add("00: PosEndLimit");
		cboHomeSignal->Items->Add("01: NegEndLimit");
		cboHomeSignal->Items->Add("04: HomeSensor");
		cboHomeSignal->Items->Add("05: EncodZPhase");

		cboZPhaseUse->Items->Clear();
		cboZPhaseUse->Enabled = true;
		cboZPhaseUse->Items->Add("00: DISABLE");
		cboZPhaseUse->Items->Add("01: DIR_CHOME");
		cboZPhaseUse->Items->Add("02: DIR_HOME");
		break;

	case AXT_SMC_R1V04A4:
		cboHomeLevel->Items->Clear();
		cboHomeLevel->Enabled = true;
		cboHomeLevel->Items->Add("01: HIGH");
		cboHomeLevel->Items->Add("02: UNUSED");

		cboHomeSignal->Items->Clear();
		cboHomeSignal->Enabled = true;
		cboHomeSignal->Items->Add("00: PosEndLimit");
		cboHomeSignal->Items->Add("01: NegEndLimit");
		cboHomeSignal->Items->Add("04: HomeSensor");

		cboZPhaseUse->Items->Clear();
		cboZPhaseUse->Enabled = true;
		cboZPhaseUse->Items->Add("00: DISABLE");
		cboZPhaseUse->Items->Add("01: DIR_CHOME");
		cboZPhaseUse->Items->Add("02: DIR_HOME");
		break;

	case AXT_SMC_R1V04MLIIPM:
		cboHomeLevel->Items->Clear();
		cboHomeLevel->Enabled = true;
		cboHomeLevel->Items->Add("01: HIGH");
		cboHomeLevel->Items->Add("02: UNUSED");

		cboZPhaseUse->Items->Clear();
		cboZPhaseUse->Enabled = true;
		cboZPhaseUse->Items->Add("00: DISABLE");

		cboHomeSignal->Items->Clear();
		cboHomeSignal->Enabled = true;
		cboHomeSignal->Items->Add("04: HomeSensor");
		break;

	case AXT_SMC_R1V04MLIISV:
	case AXT_SMC_R1V04A5:
	case AXT_SMC_R1V04MLIICL:
	case AXT_SMC_R1V04MLIICR:
	case AXT_SMC_R1V04MLIIORI:
	case AXT_SMC_R1V04SIIIHMIV:
	case AXT_SMC_R1V04SIIIHMIV_R:
		cboHomeLevel->Items->Clear();
		cboHomeLevel->Enabled = true;
		cboHomeLevel->Items->Add("01: HIGH");
		cboHomeLevel->Items->Add("02: UNUSED");

		cboHomeSignal->Items->Clear();
		cboHomeSignal->Enabled = true;
		cboHomeSignal->Items->Add("00: PosEndLimit");
		cboHomeSignal->Items->Add("01: NegEndLimit");
		cboHomeSignal->Items->Add("04: HomeSensor");

		cboZPhaseUse->Items->Clear();
		cboZPhaseUse->Enabled = true;
		cboZPhaseUse->Items->Add("00: DISABLE");
		cboZPhaseUse->Items->Add("01: DIR_CHOME");
		cboZPhaseUse->Items->Add("02: DIR_HOME");
		break;
	}

	//++ 지정한 축의 서보온 상태를 반환합니다.
	AxmSignalIsServoOn(m_lAxisNo, &dwLevel);
	chkServoOn->Checked = dwLevel;

	//++ 선택한 축의 원점신호 Active Level 설정값을 확인합니다.
	dwRetCode = AxmHomeGetSignalLevel(m_lAxisNo, &dwLevel);
	if(dwRetCode != AXT_RT_SUCCESS)	dwLevel = UNUSED;
	ConvertAxmToCombo(cboHomeLevel, dwLevel);

	//++ 선택한 축의 원점검출 속도 설정값을 확인합니다.
        dwRetCode = AxmHomeGetVel(m_lAxisNo, &dVelFirst, &dVelSecond, &dVelThird, &dVelLast, &dAccFirst, &dAccSecond);
	edtVelFirst->Text = edtVelFirst->Text.Format("%.3f", ARRAYOFCONST((dVelFirst)));
	edtVelSecond->Text = edtVelSecond->Text.Format("%.3f", ARRAYOFCONST((dVelSecond)));
	edtVelThird->Text = edtVelThird->Text.Format("%.3f", ARRAYOFCONST((dVelThird)));
	edtVelLast->Text = edtVelLast->Text.Format("%.3f", ARRAYOFCONST((dVelLast)));

		edtAccFirst->Text = edtAccFirst->Text.Format("%.3f", ARRAYOFCONST((dAccFirst)));
		edtAccSecond->Text = edtAccSecond->Text.Format("%.3f", ARRAYOFCONST((dAccSecond)));

   	//++ 선택한 축의 원점검출 방법 설정값을 확인합니다.
	dwRetCode = AxmHomeGetMethod(m_lAxisNo, &lHomeDir, &dwHomeSignal, &dwZPhaseUse, &dHomeClrTime, &dHomeOffset);
	ConvertAxmToCombo(cboHomeDir, lHomeDir);
	ConvertAxmToCombo(cboHomeSignal, dwHomeSignal);
	ConvertAxmToCombo(cboZPhaseUse, dwZPhaseUse);

		edtHomeClrTime->Text = edtHomeClrTime->Text.Format("%.3f", ARRAYOFCONST((dHomeClrTime)));
		edtHomeOffset->Text = edtHomeOffset->Text.Format("%.3f", ARRAYOFCONST((dHomeOffset)));


	return TRUE;
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

// ++ =======================================================================
// >> TranslateHomeResult(...) : 지정한 원점검색 결과에 해당하는 문자열을 반환
//    하는 함수.
//  - "AXHS.h"에 정의되어있는 AXT_MOTION_HOME_RESULT 구조체를 기반으로 합니다.
// --------------------------------------------------------------------------
String  TForm1::TranslateHomeResult(DWORD dwHomeResult)
{
	String strResult;

	switch(dwHomeResult){
	case HOME_SUCCESS:		strResult = "[01H] HOME_SUCCESS";			break;
	case HOME_SEARCHING:		strResult = "[02H] HOME_SEARCHING";		break;
	case HOME_ERR_GNT_RANGE:	strResult = "[10H] HOME_ERR_GNT_RANGE";	break;
	case HOME_ERR_USER_BREAK:	strResult = "[11H] HOME_ERR_USER_BREAK";	break;
	case HOME_ERR_VELOCITY:		strResult = "[12H] HOME_ERR_VELOCITY";	break;
	case HOME_ERR_AMP_FAULT:	strResult = "[13H] HOME_ERR_AMP_FAULT";	break;
	case HOME_ERR_NEG_LIMIT:	strResult = "[14H] HOME_ERR_NEG_LIMIT";	break;
	case HOME_ERR_POS_LIMIT:	strResult = "[15H] HOME_ERR_POS_LIMIT";	break;
	case HOME_ERR_NOT_DETECT:	strResult = "[16H] HOME_ERR_NOT_DETECT";	break;
	case HOME_ERR_UNKNOWN:		strResult = "[FFH] HOME_ERR_UNKNOWN";		break;
	}

	return strResult;
}
