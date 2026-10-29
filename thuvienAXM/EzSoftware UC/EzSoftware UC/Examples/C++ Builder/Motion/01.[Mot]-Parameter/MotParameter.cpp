// MotParameter.cpp : implementation file
//
// **************************************************************************
// >> [일자]: 2015.12.15
// >> [개요]: 이 예제는 모터 구동에 관련된 파라메타들을 설정변경한 후 파일로
//    저장 또는 불러오기를 할 수 있도록 작성된 예제입니다.
// >> [중요]: 신호설정 함수 사용시 주의사항
//     1) 제품의 종류에 따라서 신호설정에 사용되는 인자가 달라질 수 있습니다.
//     2) 네트웍 제품의 리미트 신호나 원점신호의 레벨 변경은 서보팩 파라메타를
//        변경해서 바꿀수 있습니다.
// **************************************************************************

//---------------------------------------------------------------------------

#include <vcl.h>
#include <stdio.h>
#pragma hdrstop

#include "MotParameter.h"
//---------------------------------------------------------------------------

// ++ =======================================================================
// >> AXL(AjineXtek Library) 관련 Header파일 포함시킵니다.
// ※ [CAUTION] 예제를 복사하여 다른 위치에서 실행시 참조경로 변경이 필요합니다.
// --------------------------------------------------------------------------
#include "../../../../AXL(Library)/C, C++/AXL.h"
#include "../../../../AXL(Library)/C, C++/AXM.h"
#include "../../../../AXL(Library)/C, C++/AXDev.h"
#include "../../../../AXL(Library)/C, C++/AXHS.h"

// ++ =======================================================================
// >> AXL(AjineXtek Library) 관련 Library파일을 Link시킵니다.
// ※ [CAUTION] 예제를 복사하여 다른 위치에서 실행시 참조경로 변경이 필요합니다.
// --------------------------------------------------------------------------
#pragma comment(lib, "../../../../AXL(Library)/Library/CBuilder/AxL.lib")

#define TM_DISPLAY      100
#define Z_PHASE_BIT     1

#pragma package(smart_init)
#pragma resource "*.dfm"

#define L      char*


TForm1 *Form1;
//---------------------------------------------------------------------------
__fastcall TForm1::TForm1(TComponent* Owner)
        : TForm(Owner)
{
	m_lAxisNo = -1;
	m_lAxisCount = 0;
	m_dwModuleID = 0;

	// TEdit 컨트롤들의 값들을 오른쪽정렬로 설정
	SetWindowLong(edtMinVel->Handle, GWL_STYLE,
		GetWindowLong(edtMinVel->Handle, GWL_STYLE) | ES_RIGHT);
	SetWindowLong(edtMaxVel->Handle, GWL_STYLE,
		GetWindowLong(edtMaxVel->Handle, GWL_STYLE) | ES_RIGHT);
	SetWindowLong(edtMovePulse->Handle, GWL_STYLE,
		GetWindowLong(edtMovePulse->Handle, GWL_STYLE) | ES_RIGHT);
	SetWindowLong(edtMoveUnit->Handle, GWL_STYLE,
		GetWindowLong(edtMoveUnit->Handle, GWL_STYLE) | ES_RIGHT);

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
	SetWindowLong(edtHomeClrTime->Handle, GWL_STYLE,
		GetWindowLong(edtHomeClrTime->Handle, GWL_STYLE) | ES_RIGHT);
	SetWindowLong(edtHomeOffset->Handle, GWL_STYLE,
		GetWindowLong(edtHomeOffset->Handle, GWL_STYLE) | ES_RIGHT);
	SetWindowLong(edtSLimitPosN->Handle, GWL_STYLE,
		GetWindowLong(edtSLimitPosN->Handle, GWL_STYLE) | ES_RIGHT);
	SetWindowLong(edtSLimitPosP->Handle, GWL_STYLE,
		GetWindowLong(edtSLimitPosP->Handle, GWL_STYLE) | ES_RIGHT);
	SetWindowLong(edtPosition->Handle, GWL_STYLE,
		GetWindowLong(edtPosition->Handle, GWL_STYLE) | ES_RIGHT);
	SetWindowLong(edtVelocity->Handle, GWL_STYLE,
		GetWindowLong(edtVelocity->Handle, GWL_STYLE) | ES_RIGHT);
	SetWindowLong(edtAccel->Handle, GWL_STYLE,
		GetWindowLong(edtAccel->Handle, GWL_STYLE) | ES_RIGHT);
	SetWindowLong(edtDecel->Handle, GWL_STYLE,
		GetWindowLong(edtDecel->Handle, GWL_STYLE) | ES_RIGHT);
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
		//++ 함수 실행 성공시 지정한 Mot파일의 설정값으로 모션축 설정이 일괄 변경됩니다.
		if (AXT_RT_SUCCESS != AxmMotLoadParaAll((char *)temp.data()))
			ShowMessage("File load fail!");
	}
	UpdateState();	// 변경된 모션축의 상태와 Control들의 상태를 일치시킵니다.
}
//---------------------------------------------------------------------------

// ++ =======================================================================
// >> btnSaveFileClick() : "Save File"버튼 클릭시 호출되는 핸들러 함수.
//  - AXL 라이브러리 함수를 이용해 변경된 설정값들을 지정한 위치에 
//    Mot(AXM에서 사용하는 설정파일 형식) 파일 형식으로 저장합니다.
// --------------------------------------------------------------------------
void __fastcall TForm1::btnSaveFileClick(TObject *Sender)
{
        int         nLength;
        AnsiString  temp, FileType;
        SaveDialog1->Filter = "Data File (*.mot)|*.mot|All Files (*.*)|*.*";
	if(SaveDialog1->Execute()){
        SaveDialog1->FilterIndex = 1;
        temp = SaveDialog1->FileName;
        nLength = temp.Length();

        FileType = temp.SubString(nLength - 3, 4);
        if(FileType != ".mot")
            temp = temp + ".mot";

        //++ 함수 실행 성공시 각각의 모션축 설정값으로 지정한 Mot파일을 생성 및 저장 됩니다.
		if (AXT_RT_SUCCESS != AxmMotSaveParaAll((char *)temp.data()))
            ShowMessage("File save fail!");
    }
}
//---------------------------------------------------------------------------

// ++ =======================================================================
// >> btnApplyPulseClick() : "Pulse/Encoder Method && Move Parameter Setting"
//    그룹의 "Apply" 버튼을 클릭했을 때 호출되는 핸들러 함수.
//  - 해당 그룹의 모든 설정값들을 각각의 AXL 함수들을 이용하여 적용합니다.
// ※ [CAUTION] 각 콘트롤(ComboBox, Edit) 변경시 AXL에 즉시 반영되지않습니다.
//    반드시 해당 그룹의 "Apply"버튼을 클릭해야 설정변경값이 AXL에 반영됩니다.
// --------------------------------------------------------------------------
void __fastcall TForm1::btnApplyPulseClick(TObject *Sender)
{
        long	lPulse = 1;
	double	dUnit = 1.0, dMinVel = 1.0, dMaxVel = 100.0;
	DWORD	dwMethod = 0, dwAbsRelMode = 0, dwProfileMode = 0;
	
	if(cboPulse->Enabled == TRUE){
		dwMethod = ConvertComboToAxm(cboPulse);
		//++ 지정 축의 펄스 출력 방식을 설정합니다.
		//uMethod : (0)OneHighLowHigh   - 1펄스 방식, PULSE(Active High), 정방향(DIR=Low)  / 역방향(DIR=High)
		//          (1)OneHighHighLow   - 1펄스 방식, PULSE(Active High), 정방향(DIR=High) / 역방향(DIR=Low)
		//          (2)OneLowLowHigh    - 1펄스 방식, PULSE(Active Low),  정방향(DIR=Low)  / 역방향(DIR=High)
		//          (3)OneLowHighLow    - 1펄스 방식, PULSE(Active Low),  정방향(DIR=High) / 역방향(DIR=Low)
		//          (4)TwoCcwCwHigh     - 2펄스 방식, PULSE(CCW:역방향),  DIR(CW:정방향),  Active High
		//          (5)TwoCcwCwLow      - 2펄스 방식, PULSE(CCW:역방향),  DIR(CW:정방향),  Active Low
		//          (6)TwoCwCcwHigh     - 2펄스 방식, PULSE(CW:정방향),   DIR(CCW:역방향), Active High
		//          (7)TwoCwCcwLow      - 2펄스 방식, PULSE(CW:정방향),   DIR(CCW:역방향), Active Low
		//          (8)TwoPhase         - 2상(90' 위상차),  PULSE lead DIR(CW: 정방향), PULSE lag DIR(CCW:역방향)
		//          (9)TwoPhaseReverse  - 2상(90' 위상차),  PULSE lead DIR(CCW: 정방향), PULSE lag DIR(CW:역방향)
		AxmMotSetPulseOutMethod(m_lAxisNo, dwMethod);
	}

	if(cboEncoder->Enabled == TRUE){
		dwMethod = ConvertComboToAxm(cboEncoder);
		//++ 지정 축의 Encoder 입력 방식을 설정합니다.
		// uMethod : (0)ObverseUpDownMode - 정방향 Up/Down
		//           (1)ObverseSqr1Mode   - 정방향 1체배
		//           (2)ObverseSqr2Mode   - 정방향 2체배
		//           (3)ObverseSqr4Mode   - 정방향 4체배
		//           (4)ReverseUpDownMode - 역방향 Up/Down
		//           (5)ReverseSqr1Mode   - 역방향 1체배
		//           (6)ReverseSqr2Mode   - 역방향 2체배
		//           (7)ReverseSqr4Mode   - 역방향 4체배
		AxmMotSetEncInputMethod(m_lAxisNo, dwMethod);
	}

	if(cboAbsRel->Enabled == TRUE){
		dwAbsRelMode = ConvertComboToAxm(cboAbsRel);
		//++ 지정 축의 구동 좌표계를 설정합니다. 
		// dwAbsRelMode : (0)POS_ABS_MODE - 현재 위치와 상관없이 지정한 위치로 절대좌표 이동합니다.
		//                (1)POS_REL_MODE - 현재 위치에서 지정한 양만큼 상대좌표 이동합니다.
		AxmMotSetAbsRelMode(m_lAxisNo, dwAbsRelMode);
	}
	if(cboProfile->Enabled == TRUE){
		dwProfileMode = ConvertComboToAxm(cboProfile);
		//++ 지정 축의 구동 속도 프로파일 모드를 설정합니다.
		// uProfileMode : (0)SYM_TRAPEZOID_MODE  - Symmetric Trapezoid
		//                (1)ASYM_TRAPEZOID_MODE - Asymmetric Trapezoid
		//                (2)QUASI_S_CURVE_MODE  - Symmetric Quasi-S Curve
		//                (3)SYM_S_CURVE_MODE    - Symmetric S Curve
		//                (4)ASYM_S_CURVE_MODE   - Asymmetric S Curve
		AxmMotSetProfileMode(m_lAxisNo, dwProfileMode);
	}

	dMinVel = StrToFloat(edtMinVel->Text);
	//++지정 축의 초기 구동속도를 설정합니다.
	AxmMotSetMinVel(m_lAxisNo, dMinVel);

	dMaxVel = StrToFloat(edtMaxVel->Text);
	//++ 지정 축의 최대 구동속도를 설정합니다.
	AxmMotSetMaxVel(m_lAxisNo, dMaxVel);

	lPulse = StrToInt(edtMovePulse->Text);
	dUnit = StrToFloat(edtMoveUnit->Text);
	//++ 지정 축의 거리/속도/가속도의 제어단위를 설정합니다.
	AxmMotSetMoveUnitPerPulse(m_lAxisNo, dUnit, lPulse);
}
//---------------------------------------------------------------------------

// ++ =======================================================================
// >> btnApplySignalClick() : "Input/Output Signal Setting" 그룹의 "Apply" 버튼을
//    클릭했을 때 호출되는 핸들러 함수.
//  - 해당 그룹의 모든 설정값들을 각각의 AXL 함수들을 이용하여 적용합니다.
// ※ [CAUTION] 각 콘트롤(ComboBox, Edit) 변경시 AXL에 즉시 반영되지않습니다.
//    반드시 해당 그룹의 "Apply"버튼을 클릭해야 설정변경값이 AXL에 반영됩니다.
// --------------------------------------------------------------------------
void __fastcall TForm1::btnApplySignalClick(TObject *Sender)
{
	DWORD	dwUse = 0, dwLevel = 0, dwRetCode;
	DWORD	dwStopMode = 0, dwPosigitaveLevel = 0, dwNegativeLevel = 0;
	DWORD	dwEncoderType = 0;

	dwUse	= ConvertComboToAxm(cboInp);
	//++ 지정 축의 Inposition(위치결정완료) 신호 Active Level/사용유무를 설정합니다.
	// - Inposition 신호를 사용안함으로 설정하면 모션제어 칩에서 펄스출력이 완료될 때 즉시구동 종료됩니다.
	// ※ [CAUTION] Inposition 신호를 사용함으로 설정하면 모션제어 칩에서 펄스출력이 완료된 후 서보팩으로 부터
	//              Inposition(위치결정완료) 신호가 Active될 때 까지 모션 구동중으로 됩니다.
	// ※ [CAUTION] Inposition 신호를 사용할 때 Active Level이 맞지않으면 최초 한번 구동 후 모션구동이 종료되지않아
	//              다음 구동을 할 수 없게 됩니다.
	AxmSignalSetInpos(m_lAxisNo, dwUse);

	if (cboAlarmReset->Enabled) {
		dwLevel	= ConvertComboToAxm(cboAlarmReset);
		//++ 지정 축의 Alarm Reset 신호 Active Level을 설정합니다.
		AxmSignalSetServoAlarmResetLevel(m_lAxisNo, dwLevel);
	}

	//++ 지정 축의 (+/-) End Limit 신호 Active Level/사용유무를 확인합니다.
	dwRetCode = AxmSignalGetLimit(m_lAxisNo, &dwStopMode, NULL, NULL);
	if(dwRetCode == AXT_RT_SUCCESS){
		dwNegativeLevel		= ConvertComboToAxm(cboELimitN);
		dwPosigitaveLevel	= ConvertComboToAxm(cboELimitP);
		//++ 지정 축의 (-) End Limit 신호 Active Level/사용유무를 설정합니다.
		AxmSignalSetLimit(m_lAxisNo, dwStopMode, dwPosigitaveLevel, dwNegativeLevel);
	}

	if (cboZPhaseLev->Enabled) {
		dwLevel		= ConvertComboToAxm(cboZPhaseLev);
		//++ 지정 축의 Z상 Active Level을 설정합니다.
		AxmSignalSetZphaseLevel(m_lAxisNo, dwLevel);
	}

	dwStopMode	= ConvertComboToAxm(cboStopMode);
	dwLevel		= ConvertComboToAxm(cboStopLevel);
	//++ 지정 축의 Emergency 신호 Active Level/사용유무를 설정합니다.
	AxmSignalSetStop(m_lAxisNo, dwStopMode, dwLevel);

	dwLevel		= ConvertComboToAxm(cboServoOn);
	//++ 지정 축의 Servo On/Off 신호 Active Level을 설정합니다.
	dwRetCode	= AxmSignalSetServoOnLevel(m_lAxisNo, dwLevel);

	if (cboAlarm->Enabled) {
		dwUse	= ConvertComboToAxm(cboAlarm);
		//++ 지정 축의 Alarm Reset 신호 Active Level을 설정합니다.
		AxmSignalSetServoAlarm(m_lAxisNo, dwUse);
	}


	dwEncoderType	= ConvertComboToAxm(cboEncoderType);
	//++ 지정 축의 Encoder Input Type를 설정합니다.
    // dwEncoderType : (0)TYPE_INCREMENTAL
	//                 (1)TYPE_ABSOLUTE
	AxmSignalSetEncoderType(m_lAxisNo, dwEncoderType);
}
//---------------------------------------------------------------------------

// ++ =======================================================================
// >> btnApplyHomeClick() : "Home Search Setting" 그룹의 "Apply" 버튼을 클릭했을 때
//    호출되는 핸들러 함수.
//  - 해당 그룹의 모든 설정값들을 각각의 AXL 함수들을 이용하여 적용합니다.
// ※ [CAUTION] 각 콘트롤(ComboBox, Edit) 변경시 AXL에 즉시 반영되지않습니다.
//    반드시 해당 그룹의 "Apply"버튼을 클릭해야 설정변경값이 AXL에 반영됩니다.
// --------------------------------------------------------------------------
void __fastcall TForm1::btnApplyHomeClick(TObject *Sender)
{
	long	lHomeDir = 0;
	DWORD	dwHomeSignal = 0, dwHomeLevel = 0, dwZphas = 0;
	double	dHomeClrTime = 1000.0, dHomeOffset = 0.0;

	dwHomeLevel		= ConvertComboToAxm(cboHomeLevel);
	//++ 지정 축의 원점신호 Active Level을 설정합니다.
	AxmHomeSetSignalLevel(m_lAxisNo, dwHomeLevel);

	dwHomeSignal	= ConvertComboToAxm(cboHomeSignal);
	lHomeDir		= ConvertComboToAxm(cboHomeDir);
	dwZphas			= ConvertComboToAxm(cboZPhaseUse);

	dHomeClrTime	= StrToFloat(edtHomeClrTime->Text);
	dHomeOffset	= StrToFloat(edtHomeOffset->Text);
	//++ 지정 축의 원점검색 관련 정보들을 설정합니다.
	AxmHomeSetMethod(m_lAxisNo, lHomeDir, dwHomeSignal, dwZphas, dHomeClrTime, dHomeOffset);
}
//---------------------------------------------------------------------------

// ++ =======================================================================
// >> btnApplySoftLimitClick() : "Software Limit Setting " 그룹의 "Apply" 버튼을
//    클릭했을 때 호출되는 핸들러 함수.
//  - 해당 그룹의 모든 설정값들을 각각의 AXL 함수들을 이용하여 적용합니다.
// ※ [CAUTION] 각 콘트롤(ComboBox, Edit) 변경시 AXL에 즉시 반영되지않습니다.
//    반드시 해당 그룹의 "Apply"버튼을 클릭해야 설정변경값이 AXL에 반영됩니다.
// --------------------------------------------------------------------------
void __fastcall TForm1::btnApplySoftLimitClick(TObject *Sender)
{
	DWORD	dwRetCode;
	DWORD	dwUse = 0, dwStopMode = 0, dwSelection = 0;
	double	dPositivePos = 0.0, dNegativePos = 0.0;

	//++ 지정한 축에 Software Limit기능을 확인합니다.
	dwRetCode = AxmSignalGetSoftLimit(m_lAxisNo, &dwUse, &dwStopMode, &dwSelection, NULL, NULL);
	if(dwRetCode == AXT_RT_SUCCESS){
		dNegativePos = StrToFloat(edtSLimitPosN->Text);
		dPositivePos = StrToFloat(edtSLimitPosP->Text);
		dwUse = ConvertComboToAxm(cboSLimitEnable);
		dwStopMode = ConvertComboToAxm(cboSLimitStopMode);
		dwSelection = ConvertComboToAxm(cboSLimitSelect);

		//++ 지정 축의 소프트웨어 리미트를 설정합니다.
		// uUse       : (0)DISABLE        - 소프트웨어 리미트 기능을 사용하지 않습니다.
		//              (1)ENABLE         - 소프트웨어 리미트 기능을 사용합니다.
		// uStopMode  : (0)EMERGENCY_STOP - 소프트웨어 리미트 영역을 벗어날 경우 급정지합니다.
		//              (1)SLOWDOWN_STOP  - 소프트웨어 리미트 영역을 벗어날 경우 감속정지합니다.
		// uSelection : (0)COMMAND        - 기준위치를 지령위치로 합니다.
		//              (1)ACTUAL         - 기준위치를 엔코더 위치로 합니다.
		AxmSignalSetSoftLimit(m_lAxisNo, dwUse, dwStopMode, dwSelection, dPositivePos, dNegativePos);
	}
}
//---------------------------------------------------------------------------

// ++ =======================================================================
// >> btnApplyUserParaClick() : "User Move Parameter Setting " 그룹의 "Apply"
//    버튼을 클릭했을 때 호출되는 핸들러 함수.
//  - 해당 그룹의 모든 설정값들을 각각의 AXL 함수들을 이용하여 적용합니다.
// ※ [CAUTION] 각 콘트롤(ComboBox, Edit) 변경시 AXL에 즉시 반영되지않습니다.
//    반드시 해당 그룹의 "Apply"버튼을 클릭해야 설정변경값이 AXL에 반영됩니다.
// --------------------------------------------------------------------------
void __fastcall TForm1::btnApplyUserParaClick(TObject *Sender)
{
	double  dInitPos, dInitVel, dInitAccel, dInitDecel;

	dInitPos	= StrToFloat(edtPosition->Text);
	dInitVel	= StrToFloat(edtVelocity->Text);
	dInitAccel	= StrToFloat(edtAccel->Text);
	dInitDecel	= StrToFloat(edtDecel->Text);
	//++ 지정 축의 사용자 관련 파라메타들을 설정합니다.
	AxmMotSetParaLoad(m_lAxisNo, dInitPos, dInitVel, dInitAccel, dInitDecel);
}
//---------------------------------------------------------------------------

// ++ =======================================================================
// >> btnApplyAllAxesClick() : "Apply All Axes" 버튼을 클릭시 호출되는 핸들러 함수.
//  - 모든 설정값들을 각각의 AXL 함수들을 이용하여 모든 축에 적용합니다.
// ※ [CAUTION] 모든 축에 설정값 동일하게 적용시 모션축의 종류에 따라 적용
//    되지않는 파라메타가 있을 수 있습니다. 
// --------------------------------------------------------------------------
void __fastcall TForm1::btnApplyAllAxesClick(TObject *Sender)
{
        int	lAxisNo = 0;
	long	lMovePulse = 1;
	DWORD	dwModeProfile = 0, dwUseAlarm;
	DWORD	dwMethodPulse = 0, dwMethodEncoder = 0, dwModeAbsRel = 0;	
	double	dVelocityMin = 1.0, dVelocityMax = 100.0, dMoveUnit = 1.0;
	
	DWORD	dwUseInp, dwLevelAlmRst, dwRetCode;
	DWORD	dwLevelLimitN = 0, dwLevelLimitP = 0, dwLevelZPhase = 0;	
	DWORD	dwModeStop = 0, dwLevelStop = 0, dwLevelServoOn = 0;
	DWORD	dwTypeEncoder = 0;

	long	lHomeDir = 0;
	DWORD	dwHomeSignal = 0, dwLevelHome = 0, dwZphas = 0;
	double	dHomeClrTime = 1000.0, dHomeOffset = 0.0;

	DWORD	dwUse = 0, dwStopMode = 0, dwSelection = 0;
	double	dPositivePos = 0.0, dNegativePos = 0.0;

	double  dInitPos, dInitVel, dInitAccel, dInitDecel;
	
	// Pulse/Encoder Method && Move Parameter Setting
	dwMethodPulse	= ConvertComboToAxm(cboPulse);
	dwMethodEncoder = ConvertComboToAxm(cboEncoder);
	dwUseAlarm	= ConvertComboToAxm(cboAlarm);
	dwModeAbsRel	= ConvertComboToAxm(cboAbsRel);
	dwModeProfile   = ConvertComboToAxm(cboProfile);
	dVelocityMin	= StrToFloat(edtMinVel->Text);
	dVelocityMax	= StrToFloat(edtMaxVel->Text);
	lMovePulse	= StrToInt(edtMovePulse->Text);
	dMoveUnit	= StrToFloat(edtMoveUnit->Text);

	// Input/Output Signal Setting
	dwUseInp	= ConvertComboToAxm(cboInp);
	dwLevelAlmRst	= ConvertComboToAxm(cboAlarmReset);
	dwLevelLimitN	= ConvertComboToAxm(cboELimitN);
	dwLevelLimitP	= ConvertComboToAxm(cboELimitP);
	dwLevelZPhase	= ConvertComboToAxm(cboZPhaseLev);
	dwModeStop	= ConvertComboToAxm(cboStopMode);
	dwLevelStop	= ConvertComboToAxm(cboStopLevel);
	dwLevelServoOn	= ConvertComboToAxm(cboServoOn);
	dwTypeEncoder	= ConvertComboToAxm(cboEncoderType);

	// Home Search Setting
	dwLevelHome	= ConvertComboToAxm(cboHomeLevel);
	dwHomeSignal	= ConvertComboToAxm(cboHomeSignal);
	lHomeDir	= ConvertComboToAxm(cboHomeDir);
	dwZphas		= ConvertComboToAxm(cboZPhaseUse);
	lHomeDir	= ConvertComboToAxm(cboHomeDir);
	dHomeClrTime	= StrToFloat(edtHomeClrTime->Text);
	dHomeOffset	= StrToFloat(edtHomeOffset->Text);

	// Software Limit Setting
	dNegativePos	= StrToFloat(edtSLimitPosN->Text);
	dPositivePos	= StrToFloat(edtSLimitPosP->Text);

	// User Move Parameter Setting
	dInitPos	= StrToFloat(edtPosition->Text);
	dInitVel	= StrToFloat(edtVelocity->Text);
	dInitAccel	= StrToFloat(edtAccel->Text);
	dInitDecel	= StrToFloat(edtDecel->Text);

	for(lAxisNo = 0; lAxisNo < m_lAxisCount; lAxisNo++){	
		
		// Pulse/Encoder Method && Move Parameter Setting
		if(cboPulse->Enabled == TRUE){ 			
			//++ 지정 축의 펄스 출력 방식을 설정합니다.
			//uMethod : (0)OneHighLowHigh   - 1펄스 방식, PULSE(Active High), 정방향(DIR=Low)  / 역방향(DIR=High)
			//          (1)OneHighHighLow   - 1펄스 방식, PULSE(Active High), 정방향(DIR=High) / 역방향(DIR=Low)
			//          (2)OneLowLowHigh    - 1펄스 방식, PULSE(Active Low),  정방향(DIR=Low)  / 역방향(DIR=High)
			//          (3)OneLowHighLow    - 1펄스 방식, PULSE(Active Low),  정방향(DIR=High) / 역방향(DIR=Low)
			//          (4)TwoCcwCwHigh     - 2펄스 방식, PULSE(CCW:역방향),  DIR(CW:정방향),  Active High     
			//          (5)TwoCcwCwLow      - 2펄스 방식, PULSE(CCW:역방향),  DIR(CW:정방향),  Active Low     
			//          (6)TwoCwCcwHigh     - 2펄스 방식, PULSE(CW:정방향),   DIR(CCW:역방향), Active High
			//          (7)TwoCwCcwLow      - 2펄스 방식, PULSE(CW:정방향),   DIR(CCW:역방향), Active Low
			//          (8)TwoPhase         - 2상(90' 위상차),  PULSE lead DIR(CW: 정방향), PULSE lag DIR(CCW:역방향)
			//          (9)TwoPhaseReverse  - 2상(90' 위상차),  PULSE lead DIR(CCW: 정방향), PULSE lag DIR(CW:역방향)
			AxmMotSetPulseOutMethod(lAxisNo, dwMethodPulse);
		}
		
		if(cboEncoder->Enabled == TRUE){
			//++ 지정 축의 Encoder 입력 방식을 설정합니다.
			// uMethod : (0)ObverseUpDownMode - 정방향 Up/Down
			//           (1)ObverseSqr1Mode   - 정방향 1체배
			//           (2)ObverseSqr2Mode   - 정방향 2체배
			//           (3)ObverseSqr4Mode   - 정방향 4체배
			//           (4)ReverseUpDownMode - 역방향 Up/Down
			//           (5)ReverseSqr1Mode   - 역방향 1체배
			//           (6)ReverseSqr2Mode   - 역방향 2체배
			//           (7)ReverseSqr4Mode   - 역방향 4체배
			AxmMotSetEncInputMethod(lAxisNo, dwMethodEncoder);
		}

		if(cboAlarm->Enabled == TRUE){
			//++ 지정 축의 비상정지 신호 사용유무/Active Level을 설정합니다.
			AxmSignalSetServoAlarm(lAxisNo, dwUseAlarm);
		}
		if(cboAbsRel->Enabled == TRUE){
			//++ 지정 축의 구동 좌표계를 설정합니다.
			// dwAbsRelMode : (0)POS_ABS_MODE - 현재 위치와 상관없이 지정한 위치로 절대좌표 이동합니다.
			//                (1)POS_REL_MODE - 현재 위치에서 지정한 양만큼 상대좌표 이동합니다.
			AxmMotSetAbsRelMode(lAxisNo, dwMethodPulse);
		}
		if(cboProfile->Enabled == TRUE){
			// dwProfileMode : (0)SYM_TRAPEZOID_MODE  - Symmetric Trapezoid
			//                 (1)ASYM_TRAPEZOID_MODE - Asymmetric Trapezoid
			//                 (2)QUASI_S_CURVE_MODE  - Symmetric Quasi-S Curve
			//                 (3)SYM_S_CURVE_MODE    - Symmetric S Curve
			//                 (4)ASYM_S_CURVE_MODE   - Asymmetric S Curve
			AxmMotSetProfileMode(lAxisNo, dwModeProfile);
		}
		
		//++ 지정 축의 초기 구동속도를 설정합니다.
		AxmMotSetMinVel(lAxisNo, dVelocityMin);
		
		//++ 지정 축의 최대 구동속도를 설정합니다.
		AxmMotSetMaxVel(lAxisNo, dVelocityMax);
		
		//++ 지정 축의 거리/속도/가속도의 제어단위를 설정합니다.
		AxmMotSetMoveUnitPerPulse(lAxisNo, dMoveUnit, lMovePulse);

		// Input/Output Signal Setting
		//++ 지정 축의 Inposition(위치결정완료) 신호 Active Level/사용유무를 설정합니다.
		// - Inposition 신호를 사용안함으로 설정하면 모션제어 칩에서 펄스출력이 완료될 때 즉시구동 종료됩니다.
		// ※ [CAUTION] Inposition 신호를 사용함으로 설정하면 모션제어 칩에서 펄스출력이 완료된 후 서보팩으로 부터 
		//              Inposition(위치결정완료) 신호가 Active될 때 까지 모션 구동중으로 됩니다.
		// ※ [CAUTION] Inposition 신호를 사용할 때 Active Level이 맞지않으면 최초 한번 구동 후 모션구동이 종료되지않아 
		//              다음 구동을 할 수 없게 됩니다. 
		AxmSignalSetInpos(lAxisNo, dwUseInp);	
		
		//++ 지정 축의 Alarm Reset 신호 Active Level을 설정합니다.
		AxmSignalSetServoAlarmResetLevel(lAxisNo, dwLevelAlmRst);
		
		//++ 지정 축의 (+/-) End Limit 신호 Active Level/사용유무를 확인합니다.
		dwRetCode = AxmSignalGetLimit(lAxisNo, &dwStopMode, NULL, NULL);
		if(dwRetCode == AXT_RT_SUCCESS){
			//++ 지정 축의 (-) End Limit 신호 Active Level/사용유무를 설정합니다.
			AxmSignalSetLimit(lAxisNo, dwStopMode, dwLevelLimitP, dwLevelLimitN);
		}
		
		//++ 지정 축의 Z상 Active Level을 설정합니다.
		AxmSignalSetZphaseLevel(lAxisNo, dwLevelZPhase);	
		
		//++ 지정 축의 Emergency 신호 Active Level/사용유무를 설정합니다.
		AxmSignalSetStop(lAxisNo, dwModeStop, dwLevelStop);
		
		//++ 지정 축의 Servo On/Off 신호 Active Level을 설정합니다.
		AxmSignalSetServoOnLevel(lAxisNo, dwLevelServoOn);
		
		//++ 지정 축의 Encoder Input Type를 설정합니다.
		// dwEncoderType : (0)TYPE_INCREMENTAL
		//                 (1)TYPE_ABSOLUTE
		AxmSignalSetEncoderType(lAxisNo, dwTypeEncoder);		
		
		// Home Search Setting
		//++ 지정 축의 원점신호 Active Level을 설정합니다.
		AxmHomeSetSignalLevel(lAxisNo, dwLevelHome);
		
		//++ 지정 축의 원점검색 관련 정보들을 설정합니다.
		AxmHomeSetMethod(lAxisNo, lHomeDir, dwHomeSignal, dwZphas, dHomeClrTime, dHomeOffset);

		// Software Limit Setting
		//++ 지정한 축에 Software Limit기능을 확인합니다.
		dwRetCode = AxmSignalGetSoftLimit(lAxisNo, &dwUse, &dwStopMode, &dwSelection, NULL, NULL);
		if(dwRetCode == AXT_RT_SUCCESS){
			dwUse = ConvertComboToAxm(cboSLimitEnable);
			dwStopMode = ConvertComboToAxm(cboSLimitStopMode);
			dwSelection = ConvertComboToAxm(cboSLimitSelect);

			//++ 지정 축의 소프트웨어 리미트를 설정합니다.
			// uUse       : (0)DISABLE        - 소프트웨어 리미트 기능을 사용하지 않습니다.
			//              (1)ENABLE         - 소프트웨어 리미트 기능을 사용합니다.
			// uStopMode  : (0)EMERGENCY_STOP - 소프트웨어 리미트 영역을 벗어날 경우 급정지합니다.
			//              (1)SLOWDOWN_STOP  - 소프트웨어 리미트 영역을 벗어날 경우 감속정지합니다.
			// uSelection : (0)COMMAND        - 기준위치를 지령위치로 합니다.
			//              (1)ACTUAL         - 기준위치를 엔코더 위치로 합니다.
			AxmSignalSetSoftLimit(lAxisNo, dwUse, dwStopMode, dwSelection, dPositivePos, dNegativePos);
		}

		//++ 지정 축의 사용자 관련 파라메타들을 설정합니다.
		AxmMotSetParaLoad(lAxisNo, dInitPos, dInitVel, dInitAccel, dInitDecel);
	}
}
//---------------------------------------------------------------------------

// ++ =======================================================================
// >> m_timerTimer(...) : 타이머 이벤트 핸들러 함수.
//  - 일정한 주기로 변경되는 위치/속도/정보등을 Control에 반영합니다.
// --------------------------------------------------------------------------
void __fastcall TForm1::m_timerTimer(TObject *Sender)
{
        DWORD	dwState1 = 0, dwState2 = 0, dwRetCode;

        //++ Z상 신호의 상태를 확인합니다.
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
		case AXT_SMC_4V04:  			strData = strData.Format("%.2d-[4V04]", ARRAYOFCONST((i)));	break;
		case AXT_SMC_R1V04:				strData = strData.Format("%.2d-[R1V04]", ARRAYOFCONST((i)));	break;
		case AXT_SMC_2V04:				strData = strData.Format("%.2d-[2V04]", ARRAYOFCONST((i)));	break;
		case AXT_SMC_R1V04MLIIPM:		strData = strData.Format("%.2d-[R1V04MLIIPM]", ARRAYOFCONST((i)));	break;
		case AXT_SMC_R1V04PM2Q:			strData = strData.Format("%.2d-[R1V04PM2Q]", ARRAYOFCONST((i)));	break;
		case AXT_SMC_R1V04PM2QE:		strData = strData.Format("%.2d-[R1V04PM2QE]", ARRAYOFCONST((i)));	break;
		case AXT_SMC_R1V04MLIIIPM:		strData = strData.Format("%.2d-[R1V04MLIIIPM]", ARRAYOFCONST((i)));	break;
		case AXT_SMC_R1V04MLIISV:		strData = strData.Format("%.2d-[R1V04MLIISV]", ARRAYOFCONST((i)));	break;
		case AXT_SMC_R1V04A5:			strData = strData.Format("%.2d-[R1V04A5]", ARRAYOFCONST((i)));	break;
		case AXT_SMC_R1V04A4:			strData = strData.Format("%.2d-[R1V04A4]", ARRAYOFCONST((i)));	break;
		case AXT_SMC_R1V04SIIIHMIV:		strData = strData.Format("%.2d-[R1V04SIIIHMIV]", ARRAYOFCONST((i)));	break;
		case AXT_SMC_R1V04SIIIHMIV_R:	strData = strData.Format("%.2d-[R1V04SIIIHMIV_R]", ARRAYOFCONST((i)));	break;
		case AXT_SMC_R1V04MLIIISV:		strData = strData.Format("%.2d-[R1V04MLIIISV]", ARRAYOFCONST((i)));	break;
		case AXT_SMC_R1V04MLIIISV_MD:	strData = strData.Format("%.2d-[R1V04MLIIISV_MD]", ARRAYOFCONST((i)));	break;
		case AXT_SMC_R1V04MLIIIS7S:		strData = strData.Format("%.2d-[R1V04MLIIIS7S]", ARRAYOFCONST((i)));	break;
		case AXT_SMC_R1V04MLIIIS7W:		strData = strData.Format("%.2d-[R1V04MLIIIS7W]", ARRAYOFCONST((i)));	break;
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

	long	lPulse = 1;
	double  dUnit = 1.0, dMinVel = 1.0, dMaxVel = 100.0;
	double  dSWLimitP = 0.0, dSWLimitN = 0.0;
	DWORD	dwMethod = 0, dwStopMode = 0, dwUse = 0;
	DWORD	dwPositiveLevel = 0, dwNegativeLevel = 0;
	DWORD	dwSWEnable = 0, dwSWStopMode = 0, dwSWRef = 0;
	DWORD	dwLevel = 0, dwAbsRelMode = 0, dwProfileMode = 0, dwRetCode;
	DWORD	dwEncoderType = 0;

	long	lHmDir = 0;
	DWORD	dwHomeSignal = 0, dwZphas = 0;
	double	dHomeClrTime = 1000.0, dHomeOffset = 0.0;

	double  dInitPos = 100.0, dInitVel = 100.0, dInitAccel = 400.0, dInitDecel = 400.0;
	double	dVelFirst = 100.0, dVelSecond = 10.0, dVelThird = 5.0, dVelLast = 1.0, dAccFirst = 400.0, dAccSecond = 40.0;

        // 각 제품별 지원여부에 따라 콘트롤 값들을 변경합니다.
	switch(m_dwModuleID){

			case AXT_SMC_4V04:
            case AXT_SMC_R1V04:
            case AXT_SMC_2V04:
            case AXT_SMC_R1V04PM2Q:
            case AXT_SMC_R1V04PM2QE:
            case AXT_SMC_R1V04MLIIIPM:
                 cboPulse->Items->Clear();
                 cboPulse->Enabled = true;
                 cboPulse->Items->Add("00:OneHighLowHigh");
                 cboPulse->Items->Add("01:OneHighHighLow");
                 cboPulse->Items->Add("02:OneLowLowHigh");
                 cboPulse->Items->Add("03:OneLowHighLow");
                 cboPulse->Items->Add("04:TwoCcwCwHigh");
                 cboPulse->Items->Add("05:TwoCcwCwLow");
                 cboPulse->Items->Add("06:TwoCwCcwHigh");
                 cboPulse->Items->Add("07:TwoCwCcwLow");
                 cboPulse->Items->Add("08:TwoPhase");
                 cboPulse->Items->Add("09:TwoPhaseReverse");

                 cboEncoder->Items->Clear();
                 cboEncoder->Enabled = true;
                 cboEncoder->Items->Add("00:ObverseUpDownMode");
                 cboEncoder->Items->Add("01:ObverseSqr1Mode");
                 cboEncoder->Items->Add("02:ObverseSqr2Mode");
                 cboEncoder->Items->Add("03:ObverseSqr4Mode");
                 cboEncoder->Items->Add("04:ReverseUpDownMode");
                 cboEncoder->Items->Add("05:ReverseSqr1Mode");
                 cboEncoder->Items->Add("06:ReverseSqr2Mode");
                 cboEncoder->Items->Add("07:ReverseSqr4Mode");

                 cboAbsRel->Items->Clear();
                 cboAbsRel->Enabled = true;
                 cboAbsRel->Items->Add("00:POS_ABS_MODE");
                 cboAbsRel->Items->Add("01:POS_REL_MODE");

                 cboProfile->Items->Clear();
                 cboProfile->Enabled = true;
                 cboProfile->Items->Add("00:SYM_TRAPEZOIDE_MODE");
                 cboProfile->Items->Add("01:ASYM_TRAPEZOIDE_MODE");
                 cboProfile->Items->Add("02:QUASI_S_CURVE_MODE");
                 cboProfile->Items->Add("03:SYM_S_CURVE_MODE");
                 cboProfile->Items->Add("04:ASYM_S_CURVE_MODE");

                 cboZPhaseLev->Items->Clear();
                 cboZPhaseLev->Enabled = true;
                 cboZPhaseLev->Items->Add("00:LOW");
                 cboZPhaseLev->Items->Add("01:HIGH");

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

                 cboStopMode->Items->Clear();
                 cboStopMode->Enabled = true;
                 cboStopMode->Items->Add("00:EMERGENCY");
                 cboStopMode->Items->Add("01:SLOWDOWN");

                 cboStopLevel->Items->Clear();
                 cboStopLevel->Enabled = true;
                 cboStopLevel->Items->Add("00:LOW");
                 cboStopLevel->Items->Add("01:HIGH");
                 cboStopLevel->Items->Add("02:UNUSED");

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

                 edtSLimitPosN->Enabled = true;
                 edtSLimitPosP->Enabled = true;

                 cboEncoderType->Items->Clear();
                 cboEncoderType->Enabled = false;
                 cboEncoderType->Items->Add("00:INCREMENTAL");

                 cboHomeSignal->Items->Clear();
                 cboHomeSignal->Enabled = true;
                 cboHomeSignal->Items->Add("00:PosEndLimit");
                 cboHomeSignal->Items->Add("01:NegEndLimit");
                 cboHomeSignal->Items->Add("04:HomeSensor");
                 cboHomeSignal->Items->Add("05:EncodZPhase");

                 cboHomeLevel->Items->Clear();
                 cboHomeLevel->Enabled = true;
                 cboHomeLevel->Items->Add("00:LOW");
                 cboHomeLevel->Items->Add("01:HIGH");

                 cboHomeDir->Items->Clear();
                 cboHomeDir->Enabled = true;
                 cboHomeDir->Items->Add("00:(-)DIR_CCW");
                 cboHomeDir->Items->Add("01:(+)DIR_CW");

                 cboZPhaseUse->Items->Clear();
                 cboZPhaseUse->Enabled = true;
                 cboZPhaseUse->Items->Add("00:UNUSED");
                 cboZPhaseUse->Items->Add("01:(+)DIR_CW");
                 cboZPhaseUse->Items->Add("02:(-)DIR_CCW");
                 break;

			case AXT_SMC_R1V04A4:
                 cboPulse->Items->Clear();
                 cboPulse->Enabled = false;
                 cboPulse->Items->Add("00:OneHighLowHigh");

                 cboEncoder->Items->Clear();
                 cboEncoder->Enabled = false;
                 cboEncoder->Items->Add("00:ObverseUpDownMode");

                 cboAbsRel->Items->Clear();
                 cboAbsRel->Enabled = true;
                 cboAbsRel->Items->Add("00:POS_ABS_MODE");
                 cboAbsRel->Items->Add("01:POS_REL_MODE");

                 cboProfile->Items->Clear();
                 cboProfile->Enabled = true;
                 cboProfile->Items->Add("00:SYM_TRAPEZOIDE_MODE");
                 cboProfile->Items->Add("01:ASYM_TRAPEZOIDE_MODE");
                 cboProfile->Items->Add("02:QUASI_S_CURVE_MODE");
                 cboProfile->Items->Add("03:SYM_S_CURVE_MODE");
                 cboProfile->Items->Add("04:ASYM_S_CURVE_MODE");

                 cboZPhaseLev->Items->Clear();
                 cboZPhaseLev->Enabled = false;
                 cboZPhaseLev->Items->Add("02:UNUSED");

                 cboAlarm->Items->Clear();
                 cboAlarm->Enabled = true;
                 cboAlarm->Items->Add("01:HIGH");
                 cboAlarm->Items->Add("02:UNUSED");

                 cboInp->Items->Clear();
                 cboInp->Enabled = true;
                 cboInp->Items->Add("01:HIGH");
                 cboInp->Items->Add("02:UNUSED");

                 cboStopMode->Items->Clear();
                 cboStopMode->Enabled = true;
                 cboStopMode->Items->Add("00:EMERGENCY");
                 cboStopMode->Items->Add("01:SLOWDOWN");

                 cboStopLevel->Items->Clear();
                 cboStopLevel->Enabled = true;
                 cboStopLevel->Items->Add("00:LOW");
                 cboStopLevel->Items->Add("02:UNUSED");

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

                 edtSLimitPosN->Enabled = false;
                 edtSLimitPosP->Enabled = false;

                 cboEncoderType->Items->Clear();
                 cboEncoderType->Enabled = false;
                 cboEncoderType->Items->Add("00:INCREMENTAL");

                 cboHomeSignal->Items->Clear();
                 cboHomeSignal->Enabled = true;
                 cboHomeSignal->Items->Add("00:PosEndLimit");
                 cboHomeSignal->Items->Add("01:NegEndLimit");
                 cboHomeSignal->Items->Add("04:HomeSensor");

                 cboHomeLevel->Items->Clear();
                 cboHomeLevel->Enabled = true;
                 cboHomeLevel->Items->Add("00:LOW");
                 cboHomeLevel->Items->Add("01:HIGH");

                 cboHomeDir->Items->Clear();
                 cboHomeLevel->Enabled = true;
                 cboHomeLevel->Items->Add("00:(-)DIR_CCW");
                 cboHomeLevel->Items->Add("01:(+)DIR_CW");

                 cboZPhaseUse->Items->Clear();
                 cboZPhaseUse->Enabled = false;
                 cboZPhaseUse->Items->Add("00:UNUSED");
		 break;

	case AXT_SMC_R1V04MLIIPM:
                 cboPulse->Items->Clear();
                 cboPulse->Enabled = true;
                 cboPulse->Items->Add("00:OneHighLowHigh");
                 cboPulse->Items->Add("06:TwoCwCcwHigh");

                 cboEncoder->Items->Clear();
                 cboEncoder->Enabled = false;
                 cboEncoder->Items->Add("00:ObverseUpDownMode");

                 cboAbsRel->Items->Clear();
                 cboAbsRel->Enabled = true;
                 cboAbsRel->Items->Add("00:POS_ABS_MODE");
                 cboAbsRel->Items->Add("01:POS_REL_MODE");

                 cboProfile->Items->Clear();
                 cboProfile->Enabled = true;
                 cboProfile->Items->Add("00:SYM_TRAPEZOIDE_MODE");
                 cboProfile->Items->Add("01:ASYM_TRAPEZOIDE_MODE");
                 cboProfile->Items->Add("02:QUASI_S_CURVE_MODE");
                 cboProfile->Items->Add("03:SYM_S_CURVE_MODE");
                 cboProfile->Items->Add("04:ASYM_S_CURVE_MODE");

                 cboZPhaseLev->Items->Clear();
                 cboZPhaseLev->Enabled = false;
                 cboZPhaseLev->Items->Add("02:UNUSED");

                 cboAlarm->Items->Clear();
                 cboAlarm->Enabled = false;
                 cboAlarm->Items->Add("02:UNUSED");

                 cboInp->Items->Clear();
                 cboInp->Enabled = false;
                 cboInp->Items->Add("02:UNUSED");

                 cboStopMode->Items->Clear();
                 cboStopMode->Enabled = false;
                 cboStopMode->Items->Add("00:EMERGENCY");

                 cboStopLevel->Items->Clear();
                 cboStopLevel->Enabled = false;
                 cboStopLevel->Items->Add("02:UNUSED");

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

                 edtSLimitPosN->Enabled = false;
                 edtSLimitPosP->Enabled = false;

                 cboEncoderType->Items->Clear();
                 cboEncoderType->Enabled = false;
                 cboEncoderType->Items->Add("00:INCREMENTAL");

                 cboHomeSignal->Items->Clear();
                 cboHomeSignal->Enabled = false;
                 cboHomeSignal->Items->Add("04:HomeSensor");

                 cboHomeLevel->Items->Clear();
                 cboHomeLevel->Enabled = false;
                 cboHomeLevel->Items->Add("01:HIGH");

                 cboHomeDir->Items->Clear();
                 cboHomeLevel->Enabled = true;
                 cboHomeLevel->Items->Add("00:(-)DIR_CCW");
                 cboHomeLevel->Items->Add("01:(+)DIR_CW");

                 cboZPhaseUse->Items->Clear();
                 cboZPhaseUse->Enabled = false;
                 cboZPhaseUse->Items->Add("00:UNUSED");
		 break;

    case AXT_SMC_R1V04MLIISV:
    case AXT_SMC_R1V04A5:
    case AXT_SMC_R1V04MLIICL:
    case AXT_SMC_R1V04MLIICR:
    case AXT_SMC_R1V04MLIIORI:
    case AXT_SMC_R1V04SIIIHMIV:
    case AXT_SMC_R1V04SIIIHMIV_R:
                 cboPulse->Items->Clear();
                 cboPulse->Enabled = false;
                 cboPulse->Items->Add("00:OneHighLowHigh");

                 cboEncoder->Items->Clear();
                 cboEncoder->Enabled = false;
                 cboEncoder->Items->Add("00:ObverseUpDownMode");

                 cboZPhaseLev->Items->Clear();
                 cboZPhaseLev->Enabled = false;
                 cboZPhaseLev->Items->Add("02:UNUSED");

                 cboAlarm->Items->Clear();
                 cboAlarm->Enabled = true;
                 cboAlarm->Items->Add("01:HIGH");
                 cboAlarm->Items->Add("02:UNUSED");

                 cboInp->Items->Clear();
                 cboInp->Enabled = true;
                 cboInp->Items->Add("01:HIGH");
                 cboInp->Items->Add("02:UNUSED");

                 cboStopMode->Items->Clear();
                 cboStopMode->Enabled = false;
                 cboStopMode->Items->Add("00:EMERGENCY");

                 cboStopLevel->Items->Clear();
                 cboStopLevel->Enabled = false;
                 cboStopLevel->Items->Add("02:UNUSED");

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

                 edtSLimitPosN->Enabled = false;
                 edtSLimitPosP->Enabled = false;

                 cboEncoderType->Items->Clear();
                 cboEncoderType->Enabled = true;
                 cboEncoderType->Items->Add("00:INCREMENTAL");
                 cboEncoderType->Items->Add("01:ABSOLUTE");

                 cboHomeSignal->Items->Clear();
                 cboHomeSignal->Enabled = true;
                 cboHomeSignal->Items->Add("00:PosEndLimit");
                 cboHomeSignal->Items->Add("01:NegEndLimit");
                 cboHomeSignal->Items->Add("04:HomeSensor");

                 cboHomeLevel->Items->Clear();
                 cboHomeLevel->Enabled = false;
                 cboHomeLevel->Items->Add("01:HIGH");

                 cboHomeDir->Items->Clear();
                 cboHomeLevel->Enabled = true;
                 cboHomeLevel->Items->Add("00:(-)DIR_CCW");
                 cboHomeLevel->Items->Add("01:(+)DIR_CW");

                 cboZPhaseUse->Items->Clear();
                 cboZPhaseUse->Enabled = true;
                 cboZPhaseUse->Items->Add("00:UNUSED");
                 cboZPhaseUse->Items->Add("01:(+)DIR_CW");
                 cboZPhaseUse->Items->Add("02:(-)DIR_CCW");
	         break;
	case AXT_SMC_R1V04MLIIISV:
	case AXT_SMC_R1V04MLIIISV_MD:
	case AXT_SMC_R1V04MLIIIS7S:
	case AXT_SMC_R1V04MLIIIS7W:
		 cboPulse->Items->Clear();
                 cboPulse->Enabled = false;
                 cboPulse->Items->Add("00:OneHighLowHigh");

                 cboEncoder->Items->Clear();
                 cboEncoder->Enabled = false;
                 cboEncoder->Items->Add("00:ObverseUpDownMode");

                 cboZPhaseLev->Items->Clear();
                 cboZPhaseLev->Enabled = false;
                 cboZPhaseLev->Items->Add("02:UNUSED");

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

                 cboStopMode->Items->Clear();
                 cboStopMode->Enabled = false;
                 cboStopMode->Items->Add("00:EMERGENCY");

                 cboStopLevel->Items->Clear();
                 cboStopLevel->Enabled = false;
                 cboStopLevel->Items->Add("02:UNUSED");

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
                 cboServoOn->Enabled = false;
                 cboServoOn->Items->Add("01:HIGH");

                 cboAlarmReset->Items->Clear();
                 cboAlarmReset->Enabled = false;
                 cboAlarmReset->Items->Add("01:HIGH");

                 edtSLimitPosN->Enabled = false;
                 edtSLimitPosP->Enabled = false;

                 cboEncoderType->Items->Clear();
                 cboEncoderType->Enabled = true;
                 cboEncoderType->Items->Add("00:INCREMENTAL");
                 cboEncoderType->Items->Add("01:ABSOLUTE");

                 cboHomeSignal->Items->Clear();
                 cboHomeSignal->Enabled = true;
                 cboHomeSignal->Items->Add("00:PosEndLimit");
                 cboHomeSignal->Items->Add("01:NegEndLimit");
                 cboHomeSignal->Items->Add("04:HomeSensor");

                 cboHomeLevel->Items->Clear();
                 cboHomeLevel->Enabled = true;
                 cboHomeLevel->Items->Add("00:LOW");
                 cboHomeLevel->Items->Add("01:HIGH");

                 cboHomeDir->Items->Clear();
                 cboHomeLevel->Enabled = true;
                 cboHomeLevel->Items->Add("00:(-)DIR_CCW");
                 cboHomeLevel->Items->Add("01:(+)DIR_CW");

                 cboZPhaseUse->Items->Clear();
                 cboZPhaseUse->Enabled = true;
                 cboZPhaseUse->Items->Add("00:UNUSED");
                 cboZPhaseUse->Items->Add("01:(+)DIR_CW");
                 cboZPhaseUse->Items->Add("02:(-)DIR_CCW");
		 break;

		 case AXT_ECAT_MOTION:
                 cboPulse->Items->Clear();
				 cboPulse->Enabled = false;
				 cboPulse->Items->Add("00:OneHighLowHigh");

				 cboEncoder->Items->Clear();
				 cboEncoder->Enabled = false;
				 cboEncoder->Items->Add("00:ObverseUpDownMode");

				 cboAbsRel->Items->Clear();
				 cboAbsRel->Enabled = true;
				 cboAbsRel->Items->Add("00:POS_ABS_MODE");
				 cboAbsRel->Items->Add("01:POS_REL_MODE");

				 cboProfile->Items->Clear();
				 cboProfile->Enabled = true;
				 cboProfile->Items->Add("00:SYM_TRAPEZOIDE_MODE");
				 cboProfile->Items->Add("01:ASYM_TRAPEZOIDE_MODE");
				 cboProfile->Items->Add("02:QUASI_S_CURVE_MODE");
				 cboProfile->Items->Add("03:SYM_S_CURVE_MODE");
				 cboProfile->Items->Add("04:ASYM_S_CURVE_MODE");

				 cboZPhaseLev->Items->Clear();
				 cboZPhaseLev->Enabled = false;
				 cboZPhaseLev->Items->Add("02:UNUSED");

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

                 cboStopMode->Items->Clear();
                 cboStopMode->Enabled = true;
                 cboStopMode->Items->Add("00:EMERGENCY");
                 cboStopMode->Items->Add("01:SLOWDOWN");

                 cboStopLevel->Items->Clear();
                 cboStopLevel->Enabled = true;
                 cboStopLevel->Items->Add("00:LOW");
                 cboStopLevel->Items->Add("01:HIGH");
				 cboStopLevel->Items->Add("02:UNUSED");
				 cboStopLevel->Items->Add("03:USED");

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

				 edtSLimitPosN->Enabled = false;
				 edtSLimitPosP->Enabled = false;

				 cboEncoderType->Items->Clear();
				 cboEncoderType->Enabled = false;
				 cboEncoderType->Items->Add("00:INCREMENTAL");

				 cboHomeSignal->Items->Clear();
				 cboHomeSignal->Enabled = true;
                 cboHomeSignal->Items->Add("00:PosEndLimit");
                 cboHomeSignal->Items->Add("01:NegEndLimit");
                 cboHomeSignal->Items->Add("04:HomeSensor");
                 cboHomeSignal->Items->Add("05:EncodZPhase");

				 cboHomeLevel->Items->Clear();
                 cboHomeLevel->Enabled = true;
				 cboHomeLevel->Items->Add("00:LOW");
				 cboHomeLevel->Items->Add("01:HIGH");

                 cboHomeDir->Items->Clear();
                 cboHomeDir->Enabled = true;
				 cboHomeDir->Items->Add("00:(-)DIR_CCW");
				 cboHomeDir->Items->Add("01:(+)DIR_CW");

                 cboZPhaseUse->Items->Clear();
                 cboZPhaseUse->Enabled = true;
				 cboZPhaseUse->Items->Add("00:UNUSED");
				 cboZPhaseUse->Items->Add("01:(+)DIR_CW");
				 cboZPhaseUse->Items->Add("02:(-)DIR_CCW");
				 break;
	}

	//++ 지정 축의 펄스 출력방식 설정값을 확인합니다.
	dwRetCode = AxmMotGetPulseOutMethod(m_lAxisNo, &dwMethod);
	if(dwRetCode != AXT_RT_SUCCESS)	dwMethod = OneHighLowHigh;
	ConvertAxmToCombo(cboPulse, dwMethod);

	//++ 지정 축의 엔코더 입력방식 설정값을 확인합니다.
	dwRetCode = AxmMotGetEncInputMethod(m_lAxisNo, &dwMethod);
	if(dwRetCode != AXT_RT_SUCCESS)	dwMethod = ObverseUpDownMode;
	ConvertAxmToCombo(cboEncoder, dwMethod);

	dwRetCode = AxmSignalGetServoAlarm(m_lAxisNo, &dwUse);
	if(dwRetCode != AXT_RT_SUCCESS)	dwUse = UNUSED;
	ConvertAxmToCombo(cboAlarm, dwUse);

	//++ 지정 축에 Software Limit기능을 확인합니다.
	dwRetCode = AxmMotGetMinVel(m_lAxisNo, &dMinVel);
	if(dwRetCode != AXT_RT_SUCCESS)	dMinVel = 1.0;
		//edtMinVel->Text = edtMinVel->Text.sprintf("%.3f", dMinVel);
                edtMinVel->Text = edtMinVel->Text.Format("%.3f", ARRAYOFCONST((dMinVel)));

	//++ 지정 축의 초기구동 속도를 확인합니다.
	dwRetCode = AxmMotGetMaxVel(m_lAxisNo, &dMaxVel);
	if(dwRetCode != AXT_RT_SUCCESS)	dMaxVel = 1.0;

	//edtMaxVel->Text = edtMaxVel->Text.sprintf("%.3f", dMaxVel);
        edtMaxVel->Text = edtMaxVel->Text.Format("%.3f", ARRAYOFCONST((dMaxVel)));

	//++ 지정 축의 거리/속도/가속도의 제어단위/설정값들을 확인합니다.
	dwRetCode = AxmMotGetMoveUnitPerPulse(m_lAxisNo, &dUnit, &lPulse);
	if(dwRetCode != AXT_RT_SUCCESS)	dUnit = 1.0;

        //edtMoveUnit->Text = edtMoveUnit->Text.sprintf("%.3f", dUnit);
	//edtMovePulse->Text = edtMovePulse->Text.sprintf("%.3d", lPulse);
        edtMoveUnit->Text = edtMoveUnit->Text.Format("%.3f", ARRAYOFCONST((dUnit)));
        edtMovePulse->Text = edtMovePulse->Text.Format("%.3d", ARRAYOFCONST(((int)lPulse)));

	//++ 지정 축의 Z상 신호 Active Level 설정값을 확인합니다.
	dwRetCode = AxmSignalGetZphaseLevel(m_lAxisNo, &dwLevel);
	if(dwRetCode != AXT_RT_SUCCESS)	dwLevel = UNUSED;
	ConvertAxmToCombo(cboZPhaseLev, dwLevel);

	//++ 지정 축의 Servo Alarm 신호 Active Level/사용유무를 확인합니다.
	dwRetCode = AxmSignalGetServoAlarm(m_lAxisNo, &dwUse);
	if(dwRetCode != AXT_RT_SUCCESS)	dwUse = UNUSED;
	ConvertAxmToCombo(cboAlarm, dwUse);

	//++ 지정 축의 Inposition(위치결정완료) 신호 Active Level/사용유무를 확인합니다.
	dwRetCode = AxmSignalGetInpos(m_lAxisNo, &dwUse);
	if(dwRetCode != AXT_RT_SUCCESS)	dwUse = UNUSED;
	ConvertAxmToCombo(cboInp, dwUse);

	//++ 지정 축의 Emergency 신호 Active Level/사용유무를 확인합니다.
	dwRetCode = AxmSignalGetStop(m_lAxisNo, &dwStopMode, &dwLevel);
	if(dwRetCode != AXT_RT_SUCCESS)	dwLevel = UNUSED;
	ConvertAxmToCombo(cboStopMode, dwStopMode);
	ConvertAxmToCombo(cboStopLevel, dwLevel);

	//++ 지정 축의 (+/-) End Limit 신호 Active Level/사용유무를 확인합니다.
	dwRetCode = AxmSignalGetLimit(m_lAxisNo, NULL, &dwPositiveLevel, &dwNegativeLevel);
	if(dwRetCode != AXT_RT_SUCCESS)	dwPositiveLevel = dwNegativeLevel = UNUSED;
	ConvertAxmToCombo(cboELimitP, dwPositiveLevel);
	ConvertAxmToCombo(cboELimitN, dwNegativeLevel);

	//++ 지정 축의 Servo On/Off 신호 Active Level을 확인합니다.
	dwRetCode = AxmSignalGetServoOnLevel(m_lAxisNo, &dwLevel);
	if(dwRetCode != AXT_RT_SUCCESS)	dwLevel = UNUSED;
	ConvertAxmToCombo(cboServoOn, dwLevel);
	
	//++ 지정 축의 Alarm Reset 신호 Active Level을 확인합니다.
	dwRetCode = AxmSignalGetServoAlarmResetLevel(m_lAxisNo, &dwLevel);
	if(dwRetCode != AXT_RT_SUCCESS)	dwLevel = UNUSED;
	ConvertAxmToCombo(cboAlarmReset, dwLevel);

	//++ 지정한 축에 Software Limit기능을 확인합니다.
	dwRetCode = AxmSignalGetSoftLimit(m_lAxisNo, &dwSWEnable, &dwSWStopMode, &dwSWRef, &dSWLimitP, &dSWLimitN);
	if(dwRetCode != AXT_RT_SUCCESS)	dwSWStopMode = dwSWRef = UNUSED;

	cboSLimitEnable->Items->Clear();
	cboSLimitEnable->Enabled = true;
	cboSLimitEnable->Items->Add("00:DISABLE");
	cboSLimitEnable->Items->Add("01:ENABLE");

	cboSLimitStopMode->Items->Clear();
	cboSLimitStopMode->Enabled = true;
	cboSLimitStopMode->Items->Add("00:EMERGENCY_STOP");
	cboSLimitStopMode->Items->Add("01:SLOWDOWN_STOP");

	cboSLimitSelect->Items->Clear();
	cboSLimitSelect->Enabled = true;
	cboSLimitSelect->Items->Add("00:COMMAND");
	cboSLimitSelect->Items->Add("01:ACTUAL");

	ConvertAxmToCombo(cboSLimitEnable, dwSWEnable);
	ConvertAxmToCombo(cboSLimitStopMode, dwSWStopMode);
	ConvertAxmToCombo(cboSLimitSelect, dwSWRef);

	//edtSLimitPosP->Text = edtSLimitPosP->Text.sprintf("%.3f", dSWLimitP);
	//edtSLimitPosN->Text = edtSLimitPosN->Text.sprintf("%.3f", dSWLimitN);
        edtSLimitPosP->Text = edtSLimitPosP->Text.Format("%.3f", ARRAYOFCONST((dSWLimitP)));
        edtSLimitPosN->Text = edtSLimitPosN->Text.Format("%.3f", ARRAYOFCONST((dSWLimitN)));

	//++ 지정한 축에 설정된 구동 좌표계를 확인합니다.
	dwRetCode = AxmMotGetAbsRelMode(m_lAxisNo, &dwAbsRelMode);
	if(dwRetCode != AXT_RT_SUCCESS)	dwAbsRelMode = POS_ABS_MODE;
	ConvertAxmToCombo(cboAbsRel, dwAbsRelMode);

	//++ 지정한 축에 설정된 구동 프로파일 모드를 확인합니다.
	dwRetCode = AxmMotGetProfileMode(m_lAxisNo, &dwProfileMode);
	if(dwRetCode != AXT_RT_SUCCESS)	dwProfileMode = SYM_TRAPEZOIDE_MODE;
	ConvertAxmToCombo(cboProfile, dwProfileMode);
	
	//++ 지정한 축에 설정된 Encoder Type을 확인합니다.
	dwRetCode = AxmSignalGetEncoderType(m_lAxisNo, &dwEncoderType);
	if(dwRetCode != AXT_RT_SUCCESS)	dwEncoderType = 0;
	ConvertAxmToCombo(cboEncoderType, dwEncoderType);

	//++ 지정한 축에 원점검색 신호 Active Level을 확인합니다.
	AxmHomeGetSignalLevel(m_lAxisNo, &dwLevel);
	ConvertAxmToCombo(cboHomeLevel, dwLevel);

	//++ 지정한 축에 원점검색 방법 설정값을 확인합니다.
	AxmHomeGetMethod(m_lAxisNo, &lHmDir, &dwHomeSignal, &dwZphas, &dHomeClrTime, &dHomeOffset);
	ConvertAxmToCombo(cboHomeDir, lHmDir);
	ConvertAxmToCombo(cboHomeSignal, dwHomeSignal);
	ConvertAxmToCombo(cboZPhaseUse, dwZphas);

	//edtHomeClrTime->Text = edtHomeClrTime->Text.sprintf("%.3f", dHomeClrTime);
	//edtHomeOffset->Text = edtHomeOffset->Text.sprintf("%.3f", dHomeOffset);
        edtHomeClrTime->Text = edtHomeClrTime->Text.Format("%.3f", ARRAYOFCONST((dHomeClrTime)));
	edtHomeOffset->Text = edtHomeOffset->Text.Format("%.3f", ARRAYOFCONST((dHomeOffset)));

	//++ 지정한 축에 원점검색 속도/가속도 설정값을 확인합니다.
	AxmHomeGetVel(m_lAxisNo, &dVelFirst, &dVelSecond, &dVelThird, &dVelLast, &dAccFirst, &dAccSecond);
	//edtVelFirst->Text = edtVelFirst->Text.sprintf("%.3f", dVelFirst);
	//edtVelSecond->Text = edtVelSecond->Text.sprintf("%.3f", dVelSecond);
	//edtVelThird->Text = edtVelThird->Text.sprintf("%.3f", dVelThird);
	//edtVelLast->Text = edtVelLast->Text.sprintf("%.3f", dVelLast);
        edtVelFirst->Text = edtVelFirst->Text.Format("%.3f", ARRAYOFCONST((dVelFirst)));
	edtVelSecond->Text = edtVelSecond->Text.Format("%.3f", ARRAYOFCONST((dVelSecond)));
	edtVelThird->Text = edtVelThird->Text.Format("%.3f", ARRAYOFCONST((dVelThird)));
	edtVelLast->Text = edtVelLast->Text.Format("%.3f", ARRAYOFCONST((dVelLast)));

	//edtAccFirst->Text = edtAccFirst->Text.sprintf("%.3f", dAccFirst);
	//edtAccSecond->Text = edtAccSecond->Text.sprintf("%.3f", dAccSecond);
        edtAccFirst->Text = edtAccFirst->Text.Format("%.3f", ARRAYOFCONST((dAccFirst)));
	edtAccSecond->Text = edtAccSecond->Text.Format("%.3f", ARRAYOFCONST((dAccSecond)));

	//++ 지정한 축에 원점검색 속도/가속도 설정값을 확인합니다.
	AxmMotGetParaLoad(m_lAxisNo, &dInitPos, &dInitVel, &dInitAccel, &dInitDecel);

	//edtPosition->Text = edtPosition->Text.sprintf("%.3f", dInitPos);
	//edtVelocity->Text = edtVelocity->Text.sprintf("%.3f", dInitVel);
	//edtAccel->Text = edtAccel->Text.sprintf("%.3f", dInitAccel);
	//edtDecel->Text = edtDecel->Text.sprintf("%.3f", dInitDecel);
        edtPosition->Text = edtPosition->Text.Format("%.3f", ARRAYOFCONST((dInitPos)));
	edtVelocity->Text = edtVelocity->Text.Format("%.3f", ARRAYOFCONST((dInitVel)));
	edtAccel->Text = edtAccel->Text.Format("%.3f", ARRAYOFCONST((dInitAccel)));
	edtDecel->Text = edtDecel->Text.Format("%.3f", ARRAYOFCONST((dInitDecel)));

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

	AnsiString strText;
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
	AnsiString strText;

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


