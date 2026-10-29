// OverrideVelocity.cpp : implementation file
//
// **************************************************************************
// >> [일자]: 2015.12.17
// >> [개요]: 이 예제는 속도 오버라이드 관련 함수들의 사용법을 익히고 구동중 
//    간단히 속도 오버라이드의 사용법을 확인할 수 있는 예제입니다.
// >> [중요]: 속도오버라이드 제약사항
//     1) AxmOverrideVel 함수는 가속 중에 실행 시 등속 구간에서 반영되며 
//        감속 중에는 반영되지 않습니다.
//	   2) AxmOverrideAccelVelDecel 함수는 가속 / 감속 중에 모두 반영 됩니다.
//     3) 등속구간 진입시 가속/감속 중에 변경한 속도값이 반영됩니다.
//     4) 속도오버라이드 함수는 모션 구동중에만 정상적으로 구동됩니다. 다시말해
//        모션이 정지된 상태에서는 에러코드를 반환하며 무시됩니다.
//     5) 최초 모터 구동속도 보다 높은 속도로 오버라이드 할 경우 모터 구동전 
//        매번 AxmOverrideSetMaxVel 함수로 변경을 원하는 최고 높은속도를 지정한
//        후 모터구동을 해야 초기 구동속도 보다 높은 속도로 오버라이드가 됩니다.
//     6) 최초 모터 구동속도 보다 항상 낮은 속도로 오버라이드 할 경우에는 모터
//        구동전 AxmOverrideSetMaxVel함수를 호출하지 않아도 됩니다.
// **************************************************************************

//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "OverrideVelocity.h"
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
		m_lAxisNo		= -1;		     // 제어할 축 번호 초기화
		m_lAxisCount	= 0;		     // 제어 가능한 축갯수 초기화
		m_dwModuleID	= 0;		     // 제어할 축의 모듈ID 초기화
        m_bSetMaxVel    = false;

        m_dOldCmdPos = 0.0;
        m_dOldActPos = 0.0;
        m_dOldCmdVel = 0.0;

        // TEdit 컨트롤들의 값들을 오른쪽정렬로 설정
        SetWindowLong(stcCmdPos->Handle, GWL_STYLE,
            GetWindowLong(stcCmdPos->Handle, GWL_STYLE) | ES_RIGHT);
        SetWindowLong(stcActPos->Handle, GWL_STYLE,
            GetWindowLong(stcActPos->Handle, GWL_STYLE) | ES_RIGHT);
        SetWindowLong(stcCmdVel->Handle, GWL_STYLE,
            GetWindowLong(stcCmdVel->Handle, GWL_STYLE) | ES_RIGHT);
        SetWindowLong(edtMovePos->Handle, GWL_STYLE,
            GetWindowLong(edtMovePos->Handle, GWL_STYLE) | ES_RIGHT);
        SetWindowLong(edtMoveVel->Handle, GWL_STYLE,
            GetWindowLong(edtMoveVel->Handle, GWL_STYLE) | ES_RIGHT);
        SetWindowLong(edtMoveAccDec->Handle, GWL_STYLE,
            GetWindowLong(edtMoveAccDec->Handle, GWL_STYLE) | ES_RIGHT);
        SetWindowLong(edtJogVel->Handle, GWL_STYLE,
            GetWindowLong(edtJogVel->Handle, GWL_STYLE) | ES_RIGHT);
        SetWindowLong(edtJogAccDec->Handle, GWL_STYLE,
            GetWindowLong(edtJogAccDec->Handle, GWL_STYLE) | ES_RIGHT);
        SetWindowLong(edtOverrideMaxVel->Handle, GWL_STYLE,
            GetWindowLong(edtOverrideMaxVel->Handle, GWL_STYLE) | ES_RIGHT);
        SetWindowLong(edtOverrideVel->Handle, GWL_STYLE,
            GetWindowLong(edtOverrideVel->Handle, GWL_STYLE) | ES_RIGHT);
        SetWindowLong(edtOverrideAcc->Handle, GWL_STYLE,
            GetWindowLong(edtOverrideAcc->Handle, GWL_STYLE) | ES_RIGHT);
        SetWindowLong(edtOverrideDec->Handle, GWL_STYLE,
            GetWindowLong(edtOverrideDec->Handle, GWL_STYLE) | ES_RIGHT);
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
// >> rdoAbsClick(...) : "Absolute/Relative"버튼 클릭시 호출되는 핸들러 함수.
//  - 지정한 축의 구동 좌표계를 설정합니다.
//  - 설정된 좌표계에 따라 구동 함수들에 전달되는 dPos의 값은 절대위치 또는
//    상대 이동량이 됩니다.
//  - Ex1) 현재 Command위치 100으로 가정
//     1) AxmMotSetAbsRelMode(0, POS_ABS_MODE)
//     2) AxmMoveStartPos(0, 200, ...)
//     -> Command위치 기준 200 위치로 이동, 즉 (+)방향으로 100만큼 이동함
//  - Ex2) 현재 Command위치 100으로 가정
//     1) AxmMotSetAbsRelMode(0, POS_REL_MODE)
//     2) AxmMoveStartPos(0, 200, ...)
//     -> Command위치 기준 300 위치로 이동, 즉 (+)방향으로 200만큼 이동함
// --------------------------------------------------------------------------
void __fastcall TForm1::rdoAbsClick(TObject *Sender)
{
	String strData;
	DWORD	dwRetCode;

	dwRetCode = AxmMotSetAbsRelMode(m_lAxisNo, POS_ABS_MODE);
	if(dwRetCode != AXT_RT_SUCCESS)
	{
		strData = strData.Format("AxmMotSetAbsRelMode return error[Code:%.4d]", ARRAYOFCONST(((int)dwRetCode)));
		ShowMessage(strData);
	}

        UpdateState();
}
//---------------------------------------------------------------------------

void __fastcall TForm1::rdoRelClick(TObject *Sender)
{
	String strData;
	DWORD	dwRetCode;

	dwRetCode = AxmMotSetAbsRelMode(m_lAxisNo, POS_REL_MODE);
	if(dwRetCode != AXT_RT_SUCCESS)
	{
		strData = strData.Format("AxmMotSetAbsRelMode return error[Code:%.4d]", ARRAYOFCONST(((int)dwRetCode)));
		ShowMessage(strData);
	}

        UpdateState();
}
//---------------------------------------------------------------------------

// ++ =======================================================================
// >> btnMove1Click() : "Move Target"버튼 클릭시 호출되는 핸들러 함수.
//  - 선택한 축을 "Target Position" Edit콘트롤에 입력된 거리(또는 위치)/속도/
//    가속도/감속도로 모션구동합니다.
// --------------------------------------------------------------------------
void __fastcall TForm1::btnMove1Click(TObject *Sender)
{
	String strData;
	DWORD	dwRetCode;
	double	dMovePos, dMoveVel, dMoveAcc, dMoveDec;

	dMovePos = StrToFloat(edtMovePos->Text);
	dMoveVel = StrToFloat(edtMoveVel->Text);
	dMoveAcc = StrToFloat(edtMoveAccDec->Text);
	dMoveDec = dMoveAcc;

        if(m_bSetMaxVel) {
                m_bSetMaxVel = false;
        } else {
				stcOverrideMaxVel->Caption = stcOverrideMaxVel->Caption.Format("%.3f", ARRAYOFCONST((dMoveVel)));
        }

	//++ 지정한 축을 지정한 거리(또는 위치)/속도/가속도/감속도로 모션구동하고 모션 종료여부와 상관없이 함수를 빠져나옵니다.
	dwRetCode = AxmMoveStartPos(m_lAxisNo, dMovePos, dMoveVel, dMoveAcc, dMoveDec);
	if(dwRetCode != AXT_RT_SUCCESS){
		strData = strData.Format("AxmMoveStartPos return error[Code:%.4d]", ARRAYOFCONST(((int)dwRetCode)));
		ShowMessage(strData);
	}
}
//---------------------------------------------------------------------------

// ++ =======================================================================
// >> btnSStopClick() : "Move SStop"버튼 클릭시 호출되는 핸들러 함수.
//  - 선택한 축에 구동정지 함수를 호출하여 구동을 감속정지합니다.
// --------------------------------------------------------------------------
void __fastcall TForm1::btnSStopClick(TObject *Sender)
{
	//++ 지정한 축의 구동을 감속정지합니다.
	AxmMoveSStop(m_lAxisNo);
}
//---------------------------------------------------------------------------

// ++ =======================================================================
// >> btnJogMoveClick() : "Velocity Move"버튼 클릭시 호출되는 핸들러 함수.
//  - 선택한 축을 "Jog Velocity" Edit콘트롤에 입력된 속도/가속도/감속도로
//    모션구동합니다.
// --------------------------------------------------------------------------
void __fastcall TForm1::btnJogMoveClick(TObject *Sender)
{
	String strData;
	DWORD	dwRetCode;
	double	dJogVel, dJogAcc, dJogDec;

	dJogVel = StrToFloat(edtJogVel->Text);
	dJogAcc = StrToFloat(edtJogAccDec->Text);
	dJogDec = dJogAcc;

        if(m_bSetMaxVel) {
                m_bSetMaxVel = false;
        } else {
				stcOverrideMaxVel->Caption = stcOverrideMaxVel->Caption.Format("%.3f", ARRAYOFCONST((dJogVel)));
        }

	//++ 지정한 축을 지정한 거리(또는 위치)/속도/가속도/감속도로 모션구동하고 모션 종료여부와 상관없이 함수를 빠져나옵니다.
	dwRetCode = AxmMoveVel(m_lAxisNo, dJogVel, dJogAcc, dJogDec);
	if(dwRetCode != AXT_RT_SUCCESS){
		strData = strData.Format("AxmMoveVel return error[Code:%.4d]", ARRAYOFCONST(((int)dwRetCode)));
		ShowMessage(strData);
	}
}
//---------------------------------------------------------------------------

// ++ =======================================================================
// >> btnJogStopClick() : "Velocity Stop"버튼 클릭시 호출되는 핸들러 함수.
//  - 선택한 축에 구동정지 함수를 호출하여 Jog구동을 감속정지합니다.
// --------------------------------------------------------------------------
void __fastcall TForm1::btnJogStopClick(TObject *Sender)
{
	//++ 지정한 축의 구동을 감속정지합니다.
	AxmMoveSStop(m_lAxisNo);
}
//---------------------------------------------------------------------------

// ++ =======================================================================
// >> chkOverrideOnlyVelClick() : "Over Only Vel"버튼 클릭시 호출되는 핸들러 함수.
//  - 선택한 축에 오버라이드 할 함수의 종류를 설정합니다.
// --------------------------------------------------------------------------
void __fastcall TForm1::chkOverrideOnlyVelClick(TObject *Sender)
{
	edtOverrideAcc->Enabled = !(chkOverrideOnlyVel->Checked);
	edtOverrideDec->Enabled = !(chkOverrideOnlyVel->Checked);
}
//---------------------------------------------------------------------------

// ++ =======================================================================
// >> btnSetOverrideMaxVelClick() : "Set Velocity"버튼 클릭시 호출되는 핸들러 함수.
//  - 선택한 축에 구동전 오버라이드 할 최대속도를 설정합니다.
//  - 모터 구동전 이함수를 이용하여 오버라이드 할 최대 속도를 지정하지않으면
//    최초 모터구동 속도가 자동으로 오버라이드 할 최대 속도가 됩니다.
// --------------------------------------------------------------------------
void __fastcall TForm1::btnSetOverrideMaxVelClick(TObject *Sender)
{
	String strData;
	DWORD	dwRetCode;
	double	dOverrideMaxVel;

	m_bSetMaxVel	= TRUE;
	dOverrideMaxVel = StrToFloat(edtOverrideMaxVel->Text);

        //++ 지정 축으로 구동전 속도오버라이드 할 최고 속도를 설정합니다.
	// ※ [CAUTION] 최초 모터 구동속도 보다 높은 속도로 오버라이드 할 경우 모터 구동전 매번
	//    AxmOverrideSetMaxVel 함수로 변경을 원하는 최고 높은속도를 지정한 후 모터구동을 해야
	//    초기 구동속도 보다 높은 속도로 오버라이드가 됩니다.
	dwRetCode = AxmOverrideSetMaxVel(m_lAxisNo, dOverrideMaxVel);
	if(dwRetCode == AXT_RT_SUCCESS)
                stcOverrideMaxVel->Caption = stcOverrideMaxVel->Caption.Format("%.3f", ARRAYOFCONST((dOverrideMaxVel)));
	else{
		strData = strData.Format("AxmOverrideSetMaxVel return error[Code:%.4d]", ARRAYOFCONST(((int)dwRetCode)));
		ShowMessage(strData);
	}
}
//---------------------------------------------------------------------------

// ++ =======================================================================
// >> btnSetOverrideClick() : "Override"버튼 클릭시 호출되는 핸들러 함수.
//  - 선택한 축에 속도오버라이드를 실시합니다.
//  - 모터 구동전 이함수를 이용하여 오버라이드 할 최대 속도를 지정하지않으면
//    최초 모터구동 속도가 자동으로 오버라이드 할 최대 속도가 됩니다.
// --------------------------------------------------------------------------
void __fastcall TForm1::btnSetOverrideClick(TObject *Sender)
{
	String strData;
	DWORD	dwRetCode;
	double dOverrideVel, dOverrideAcc, dOverrideDec;

	dOverrideVel = StrToFloat(edtOverrideVel->Text);
	dOverrideAcc = StrToFloat(edtOverrideAcc->Text);
	dOverrideDec = StrToFloat(edtOverrideDec->Text);

	if(chkOverrideOnlyVel->Checked){
		//++ 지정한 축의 구동 속도를 변경합니다.
		// ※ [CAUTION] AxmOverrideVel 함수는 가속 중에 실행 시 등속 구간에서 반영이되며
		// 감속 중에는 반영되지 않습니다.
		// ※ [CAUTION] AxmOverrideAccelVelDecel 함수는 가속/감속 중에 모두 반영됩니다.
		// ※ [CAUTION] 등속구간 진입시 가속/감속 중에 변경한 속도값이 반영됩니다.
		// ※ [CAUTION] 최초 모터 구동속도 보다 높은 속도로 오버라이드 할 경우 모터 구동전 매번
		//    AxmOverrideSetMaxVel 함수로 변경을 원하는 최고 높은속도를 지정한 후 모터구동을 해야
		//    초기 구동속도 보다 높은 속도로 오버라이드가 됩니다.
		dwRetCode = AxmOverrideVel(m_lAxisNo, dOverrideVel);
		if(dwRetCode != AXT_RT_SUCCESS){
			strData = strData.Format("AxmOverrideVel return error[Code:%.4d]", ARRAYOFCONST(((int)dwRetCode)));
		        ShowMessage(strData);
		}
	}else{
		//++ 지정한 축의 구동 속도/가속도/감속도를 변경합니다.
		// ※ [CAUTION] AxmOverrideVel 함수는 가속 중에 실행 시 등속 구간에서 반영이되며
		// 감속 중에는 반영되지 않습니다.
		// ※ [CAUTION] AxmOverrideAccelVelDecel 함수는 가속/감속 중에 모두 반영됩니다.
		// ※ [CAUTION] 등속구간 진입시 가속/감속 중에 변경한 속도값이 반영됩니다.
		// ※ [CAUTION] 최초 모터 구동속도 보다 높은 속도로 오버라이드 할 경우 모터 구동전 매번
		//    AxmOverrideSetMaxVel 함수로 변경을 원하는 최고 높은속도를 지정한 후 모터구동을 해야
		//    초기 구동속도 보다 높은 속도로 오버라이드가 됩니다.
		dwRetCode = AxmOverrideAccelVelDecel(m_lAxisNo, dOverrideVel, dOverrideAcc, dOverrideDec);
		if(dwRetCode != AXT_RT_SUCCESS){
			strData = strData.Format("AxmOverrideAccelVelDecel return error[Code:%.4d]", ARRAYOFCONST(((int)dwRetCode)));
		        ShowMessage(strData);
		}
	}
}
//---------------------------------------------------------------------------

// ++ =======================================================================
// >> m_timerTimer(...) : 타이머 이벤트 핸들러 함수.
//  - 일정한 주기로 변경되는 위치/속도/정보등을 Control에 반영합니다.
// --------------------------------------------------------------------------
void __fastcall TForm1::m_timerTimer(TObject *Sender)
{
	double dCmdPos = 0.0, dActPos = 0.0, dCmdVel = 0.0;

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

	DWORD dwAbsRelMode = POS_ABS_MODE, dwOnOff = 0;

	//++ 지정한 축의 서보온 상태를 반환합니다.
	AxmSignalIsServoOn(m_lAxisNo, &dwOnOff);
        chkServoOn->Checked = dwOnOff;

	//++ 지정한 축의 구동 좌표계 설정값을 확인합니다.
	AxmMotGetAbsRelMode(m_lAxisNo, &dwAbsRelMode);
        if(dwAbsRelMode == POS_ABS_MODE)
                rdoAbs->Checked = true;
        else
                rdoRel->Checked = true;

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


