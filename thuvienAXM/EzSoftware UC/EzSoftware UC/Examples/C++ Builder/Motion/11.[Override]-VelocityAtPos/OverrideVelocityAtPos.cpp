// OverrideVelocityAtPos.cpp : implementation file
//
// **************************************************************************
// >> [일자]: 2015.12.17
// >> [개요]: 이 예제는 지정한 위치에서 속도 오버라이드하는 함수들의 사용법을
//    익히고 여러 위치에서 다중 속도 오버라이드를 확인할 수 있는 예제입니다.
// >> [중요]: 속도오버라이드 제약사항
//     1) 속도오버라이드는 가속/감속 중에는 반영되지 않습니다.
//     2) 등속구간 진입시 가속/감속 중에 변경한 속도값이 반영됩니다.
//     3) AxmOverrideVelAtMultiPos 함수를 이용해서 오버라이드 구동중에는 별도의
//        속도 오버라이드 함수를 호출하여 속도를 변경하면 지정한 오버라이드
//        위치에서 지정한 속도가 되도록 하는 기능은 보장 할 수 없습니다.
// **************************************************************************

//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "OverrideVelocityAtPos.h"
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
        SetWindowLong(edtSetPos->Handle, GWL_STYLE,
            GetWindowLong(edtSetPos->Handle, GWL_STYLE) | ES_RIGHT);
        SetWindowLong(edtMovePos->Handle, GWL_STYLE,
            GetWindowLong(edtMovePos->Handle, GWL_STYLE) | ES_RIGHT);
        SetWindowLong(edtMoveVel->Handle, GWL_STYLE,
            GetWindowLong(edtMoveVel->Handle, GWL_STYLE) | ES_RIGHT);
        SetWindowLong(edtMoveAcc->Handle, GWL_STYLE,
            GetWindowLong(edtMoveAcc->Handle, GWL_STYLE) | ES_RIGHT);
        SetWindowLong(edtMoveDec->Handle, GWL_STYLE,
            GetWindowLong(edtMoveDec->Handle, GWL_STYLE) | ES_RIGHT);
        SetWindowLong(edtOverPos->Handle, GWL_STYLE,
            GetWindowLong(edtOverPos->Handle, GWL_STYLE) | ES_RIGHT);
        SetWindowLong(edtOverVel->Handle, GWL_STYLE,
            GetWindowLong(edtOverVel->Handle, GWL_STYLE) | ES_RIGHT);
        SetWindowLong(edtOverPosAdd->Handle, GWL_STYLE,
            GetWindowLong(edtOverPosAdd->Handle, GWL_STYLE) | ES_RIGHT);
        SetWindowLong(edtOverVelAdd->Handle, GWL_STYLE,
			GetWindowLong(edtOverVelAdd->Handle, GWL_STYLE) | ES_RIGHT);
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
// >> btnPosSetClick() : "Position Setting"버튼 클릭시 호출되는 핸들러 함수.
//  - 선택된 축의 위치정보를 지정한 값으로 설정합니다.
//  - AxmStatusSetPosMatch함수는 AxmStatusSetCmdPos, AxmStatusSetActPos 함수를
//    사용하는것과 동일한 효과를 냅니다.
// --------------------------------------------------------------------------
void __fastcall TForm1::btnPosSetClick(TObject *Sender)
{
	double dSetPos;
	dSetPos = StrToFloat(edtSetPos->Text);

	//++ Command위치와 Actual위치를 지정한 값으로 설정합니다.
	AxmStatusSetPosMatch(m_lAxisNo, dSetPos);
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
// >> chkOverMultiClick() : "Override Vel At Multi Pos Use"버튼 클릭시 호출되는 핸들러 함수.
//  - 선택한 축에 오버라이드 할 함수의 종류를 설정합니다.
//  - 오버라이드 함수에 따라 필요한 인자들을 활성화/비활성화 시킵니다.
// --------------------------------------------------------------------------
void __fastcall TForm1::chkOverMultiClick(TObject *Sender)
{
        BOOL bEnableMulti;
		bEnableMulti = chkOverMulti->Checked;

        edtOverPos->Enabled = !bEnableMulti;
        edtOverVel->Enabled = !bEnableMulti;
        btnOverVelAtPos->Enabled = !bEnableMulti;

        cboOverMode->Enabled = bEnableMulti;
        lstOverData->Enabled = bEnableMulti;
        btnOverVelAtMPos->Enabled = bEnableMulti;
        btnOverDataAdd->Enabled = bEnableMulti;
		btnOverDataClr->Enabled = bEnableMulti;
		edtOverPosAdd->Enabled = bEnableMulti;
		edtOverVelAdd->Enabled = bEnableMulti;
}
//---------------------------------------------------------------------------

// ++ =======================================================================
// >> btnOverVelAtPosClick() : "Override At Pos"버튼 클릭시 호출되는 핸들러 함수.
//  - 선택한 축에 지정한 위치에서 정확하게 오버라이드하는 구동을 시작합니다.
// --------------------------------------------------------------------------
void __fastcall TForm1::btnOverVelAtPosClick(TObject *Sender)
{
	DWORD	dwRetCode;
	String strData;
	long	lCampTarget;
	double	dMovePos, dMoveVel, dMoveAcc, dMoveDec, dOverPos, dOverVel;

	dMovePos	= StrToFloat(edtMovePos->Text);
	dMoveVel	= StrToFloat(edtMoveVel->Text);
	dMoveAcc	= StrToFloat(edtMoveAcc->Text);
	dMoveDec	= StrToFloat(edtMoveDec->Text);

	dOverPos	= StrToFloat(edtOverPos->Text);
	dOverVel	= StrToFloat(edtOverVel->Text);

	lCampTarget	= ConvertComboToAxm(cboCampTarget);
	//++ 선택한 축에 모션 구동중 지정한 위치에서 속도 오버라이드 하는 구동을 시작합니다.
	dwRetCode	= AxmOverrideVelAtPos(m_lAxisNo, dMovePos, dMoveVel, dMoveAcc, dMoveDec, dOverPos, dOverVel, lCampTarget);
	if(dwRetCode != AXT_RT_SUCCESS){
		strData = strData.Format("AxmOverrideVelAtPos return error[Code:%.4d]", ARRAYOFCONST(((int)dwRetCode)));
		ShowMessage(strData);
	}
}
//---------------------------------------------------------------------------

// ++ =======================================================================
// >> btnOverVelAtMPosClick() : "Multi At Pos"버튼 클릭시 호출되는 핸들러 함수.
//  - 선택한 축에 여러개의 지정한 위치에서 정확하게 오버라이드하는 구동을 시작합니다.
//  - 실제 오버라이드 함수의 위치지정 갯수 제한은 없으나 예제 구현 편의상 50개로
//    제한하였습니다.
// --------------------------------------------------------------------------
void __fastcall TForm1::btnOverVelAtMPosClick(TObject *Sender)
{
	DWORD	dwRetCode;
	String 	strData;
	long	lCampTarget, lOverMode, lArraySize;
	double	dMovePos, dMoveVel, dMoveAcc, dMoveDec;
	double  daOverPos[MAX_OVER_MULTI_POS], daOverVel[MAX_OVER_MULTI_POS];

	dMovePos	= StrToFloat(edtMovePos->Text);
	dMoveVel	= StrToFloat(edtMoveVel->Text);
	dMoveAcc	= StrToFloat(edtMoveAcc->Text);
	dMoveDec	= StrToFloat(edtMoveDec->Text);

	lCampTarget	= ConvertComboToAxm(cboCampTarget);
	lOverMode	= ConvertComboToAxm(cboOverMode);
	lArraySize	= ConvertListBoxToArray(lstOverData, daOverPos, daOverVel);

	//++ 선택한 축에 모션 구동중 여러개의 지정한 위치에서 속도 오버라이드 하는 구동을 시작합니다.
	//   함수 사용시 진행 방향 기준으로 먼저 도달하는 포지션부터 배열에 입력이 되어야 합니다.
		//   dwOverrideMode : (0)OVERRIDE_POS_START 지정한 위치에서 지정한 속도로 오버라이드 시작함
        //                  : (1)OVERRIDE_POS_END 지정한 위치에서 지정한 속도가 되도록 미리 오버라이드 시작함
	dwRetCode	= AxmOverrideVelAtMultiPos(m_lAxisNo, dMovePos, dMoveVel, dMoveAcc, dMoveDec, lArraySize, daOverPos, daOverVel, lCampTarget, lOverMode);
	if(dwRetCode != AXT_RT_SUCCESS){
		strData = strData.Format("AxmOverrideVelAtMultiPos return error[Code:%.4d]", ARRAYOFCONST(((int)dwRetCode)));
		ShowMessage(strData);
	}
}
//---------------------------------------------------------------------------

// ++ =======================================================================
// >> btnStopClick() : "Move Stop"버튼 클릭시 호출되는 핸들러 함수.
//  - 선택한 축에 구동정지 함수를 호출하여 구동을 감속정지합니다.
// --------------------------------------------------------------------------
void __fastcall TForm1::btnStopClick(TObject *Sender)
{
	//++ 지정한 축의 구동을 감속정지합니다.
	AxmMoveSStop(m_lAxisNo);
}
//---------------------------------------------------------------------------

// ++ =======================================================================
// >> btnOverDataAddClick() : "<< Add Item"버튼 클릭시 호출되는 핸들러 함수.
//  - 속도 오버라이드 정보를 ListBox에 등록합니다.
// --------------------------------------------------------------------------
void __fastcall TForm1::btnOverDataAddClick(TObject *Sender)
{
	String strData;
	double	dOverPos, dOverVel;

	dOverPos = StrToFloat(edtOverPosAdd->Text);
	dOverVel = StrToFloat(edtOverVelAdd->Text);

	strData = strData.Format("%18.3lf, %18.3lf", ARRAYOFCONST((dOverPos, dOverVel)));
		lstOverData->Items->Add(strData);
}
//---------------------------------------------------------------------------

// ++ =======================================================================
// >> lstOverDataDblClick() : ListBox 콘트롤 마우스 더블클릭시 호출되는 핸들러 함수.
//  - 등록된 속도 오버라이드 정보중 선택된 Item을 지울때 호출됩니다.
//  - List Box 콘트롤에서 마우스 포인트를 삭제할 Item 으로 이동한 후 마우스
//    왼쪽 버튼을 더블클릭하면 해당 Item이 선택 삭제됩니다.
// --------------------------------------------------------------------------
void __fastcall TForm1::lstOverDataDblClick(TObject *Sender)
{
		long lSelItem;

		lSelItem = lstOverData->ItemIndex;
		lstOverData->Items->Delete(lSelItem);
}
//---------------------------------------------------------------------------

// ++ =======================================================================
// >> btnOverDataClrClick() : "All Clear Item"버튼 클릭시 호출되는 핸들러 함수.
//  - 등록된 오버라이드 데이타를 모두 지웁니다.
// --------------------------------------------------------------------------
void __fastcall TForm1::btnOverDataClrClick(TObject *Sender)
{
		lstOverData->Items->Clear();
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

// ++ =======================================================================
// >> ConvertListBoxToArray(...) : 지정한 콘트롤에 설정되어 있는 텍스트를
//    오버라이드 정보값으로  변환하여 반환하는 함수.
//  - ListBox 콘트롤에 설정된 텍스트를 두개의 오버라이드 정보값으로 변환하여
//    코드를 간결하게 구현하였습니다.
//  - 실제 오버라이드 함수의 위치지정 갯수 제한은 없으나 예제구현 편의상 50개로
//    제한하였습니다.
// --------------------------------------------------------------------------
long TForm1::ConvertListBoxToArray(TListBox *pLstItem, double *dpOverVel, double *dpOverAcc)
{
	if(pLstItem == NULL)	return 0;
	if(dpOverVel == NULL)	return 0;
	if(dpOverAcc == NULL)	return 0;

	String strData, strOverPos, strOverVel;
	int	nSection, nLength;
	long	lCount, lArraySize;

	lArraySize = pLstItem->Count;
	if(lArraySize == 0)	return 0;

	for(lCount = 0; lCount < lArraySize; lCount++){
		if(lCount == MAX_OVER_MULTI_POS){
			lArraySize = MAX_OVER_MULTI_POS;
			break;
		}
				strData = pLstItem->Items->operator [](lCount);


				nLength			= strData.Length();
				nSection		= strData.Pos(",");
				strOverPos      = strData.SubString(0, nSection - 1);
				strOverVel      = strData.SubString(nSection + 1, (nLength - nSection + 1));
				strOverPos      = strOverPos.Trim();
				strOverVel      = strOverVel.Trim();
				dpOverVel[lCount] = StrToFloat(strOverPos);
				dpOverAcc[lCount] = StrToFloat(strOverVel);
	}

	return lArraySize;
}
