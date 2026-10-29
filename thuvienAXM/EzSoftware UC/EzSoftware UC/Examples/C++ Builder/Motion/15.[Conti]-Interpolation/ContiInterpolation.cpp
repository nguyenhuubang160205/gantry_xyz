// ContiInterpolation.cpp : implementation file
//
// **************************************************************************
// >> [일자]: 2015.12.17
// >> [개요]: 이 예제는 보간함수들의 사용법을 익히고 정해진 패턴의 연속보간
//    데이타들을 연속보간 Queue에 예약 및 실행 해 보는 예제입니다.
// >> [중요]: 연속보간 데이타 예약 및 구동하기
//     1) AxmContiSetAxisMap함수를 이용해서 필요한 축수의 좌표계를 맵핑합니다.
//     2) AxmContiSetAbsRelMode함수를 이용해 해당좌표계의 구동모드를 설정합니다.
//     3) AxmContiBeginNode함수를 이용해 보간구동 예약을 시작합니다.
//     4) AxmLineMove, AxmCircleCenterMove등의 보간함수를 이용해 구동을 예약합니다.
//     5) AxmContiEndNode함수를 이용해 보간구동 예약을 종료합니다.
//     6) AxmContiStart함수를 이용해 예약된 보간구동을 시작합니다.
// **************************************************************************

//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "ContiInterpolation.h"
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
        m_lAxisNo		= -1;		// 제어할 축 번호 초기화
	m_lAxisCount	= 0;		// 제어 가능한 축갯수 초기화
	m_dwModuleID	= 0;		// 제어할 축의 모듈ID 초기화

        for(int i = 0; i < MAX_INTP_MOVE_AXIS; i++) {
                m_lMoveIntpAxes[i] = -1;
                m_dOldCmdPos[i] = 0.0;
                m_dOldActPos[i] = 0.0;
                m_dOldCmdVel[i] = 0.0;
        }

        m_stcCmdPos[0] = stcCmdPos00;
        m_stcCmdPos[1] = stcCmdPos01;
        m_stcCmdPos[2] = stcCmdPos02;
        m_stcCmdPos[3] = stcCmdPos03;

        m_stcActPos[0] = stcActPos00;
        m_stcActPos[1] = stcActPos01;
        m_stcActPos[2] = stcActPos02;
        m_stcActPos[3] = stcActPos03;

        m_stcCmdVel[0] = stcCmdVel00;
        m_stcCmdVel[1] = stcCmdVel01;
        m_stcCmdVel[2] = stcCmdVel02;
        m_stcCmdVel[3] = stcCmdVel03;

        m_chkMoveIntpAxes[0] = chkAxis00;
        m_chkMoveIntpAxes[1] = chkAxis01;
        m_chkMoveIntpAxes[2] = chkAxis02;
        m_chkMoveIntpAxes[3] = chkAxis03;

	memset(m_lMoveIntpAxes, -1, sizeof(m_lMoveIntpAxes));

        // TEdit 컨트롤들의 값들을 오른쪽정렬로 설정
        SetWindowLong(stcCmdPos00->Handle, GWL_STYLE,
            GetWindowLong(stcCmdPos00->Handle, GWL_STYLE) | ES_RIGHT);
        SetWindowLong(stcCmdPos01->Handle, GWL_STYLE,
            GetWindowLong(stcCmdPos01->Handle, GWL_STYLE) | ES_RIGHT);
        SetWindowLong(stcCmdPos02->Handle, GWL_STYLE,
            GetWindowLong(stcCmdPos02->Handle, GWL_STYLE) | ES_RIGHT);
        SetWindowLong(stcCmdPos03->Handle, GWL_STYLE,
            GetWindowLong(stcCmdPos03->Handle, GWL_STYLE) | ES_RIGHT);
        SetWindowLong(stcActPos00->Handle, GWL_STYLE,
            GetWindowLong(stcActPos00->Handle, GWL_STYLE) | ES_RIGHT);
        SetWindowLong(stcActPos01->Handle, GWL_STYLE,
            GetWindowLong(stcActPos01->Handle, GWL_STYLE) | ES_RIGHT);
        SetWindowLong(stcActPos02->Handle, GWL_STYLE,
            GetWindowLong(stcActPos02->Handle, GWL_STYLE) | ES_RIGHT);
        SetWindowLong(stcActPos03->Handle, GWL_STYLE,
            GetWindowLong(stcActPos03->Handle, GWL_STYLE) | ES_RIGHT);
        SetWindowLong(stcCmdVel00->Handle, GWL_STYLE,
            GetWindowLong(stcCmdVel00->Handle, GWL_STYLE) | ES_RIGHT);
        SetWindowLong(stcCmdVel01->Handle, GWL_STYLE,
            GetWindowLong(stcCmdVel01->Handle, GWL_STYLE) | ES_RIGHT);
        SetWindowLong(stcCmdVel02->Handle, GWL_STYLE,
            GetWindowLong(stcCmdVel02->Handle, GWL_STYLE) | ES_RIGHT);
        SetWindowLong(stcCmdVel03->Handle, GWL_STYLE,
            GetWindowLong(stcCmdVel03->Handle, GWL_STYLE) | ES_RIGHT);

        SetWindowLong(stcIntpExeNode->Handle, GWL_STYLE,
            GetWindowLong(stcIntpExeNode->Handle, GWL_STYLE) | ES_CENTER);
        SetWindowLong(stcIntpTotalNode->Handle, GWL_STYLE,
            GetWindowLong(stcIntpTotalNode->Handle, GWL_STYLE) | ES_CENTER);

        SetWindowLong(edtMoveVel->Handle, GWL_STYLE,
            GetWindowLong(edtMoveVel->Handle, GWL_STYLE) | ES_RIGHT);
        SetWindowLong(edtMoveAcc->Handle, GWL_STYLE,
            GetWindowLong(edtMoveAcc->Handle, GWL_STYLE) | ES_RIGHT);
        SetWindowLong(edtMoveDec->Handle, GWL_STYLE,
            GetWindowLong(edtMoveDec->Handle, GWL_STYLE) | ES_RIGHT);
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
// >> chkAxis00Click(...) : 보간축 변경이 있을 때 호출되는 핸들러 함수.
//  - 축 번호 선택 체크버튼의 체크상태에 변화가 있을 때 보간 사용축 갯수 및 축
//    번호 배열값을 재할당합니다.
//  - IDC_CHK_AXIS_00 ~ IDC_CHK_AXIS_03 버튼의 클릭이벤트 발생시 호출됩니다.
// --------------------------------------------------------------------------
void __fastcall TForm1::chkAxis00Click(TObject *Sender)
{
        // 변경된 모션축의 상태와 Control들의 상태를 일치시킵니다.
	UpdateState();
}
//---------------------------------------------------------------------------
void __fastcall TForm1::chkAxis01Click(TObject *Sender)
{
        // 변경된 모션축의 상태와 Control들의 상태를 일치시킵니다.
	UpdateState();
}
//---------------------------------------------------------------------------
void __fastcall TForm1::chkAxis02Click(TObject *Sender)
{
        // 변경된 모션축의 상태와 Control들의 상태를 일치시킵니다.
	UpdateState();
}
//---------------------------------------------------------------------------
void __fastcall TForm1::chkAxis03Click(TObject *Sender)
{
        // 변경된 모션축의 상태와 Control들의 상태를 일치시킵니다.
	UpdateState();
}
//---------------------------------------------------------------------------

// ++ =======================================================================
// >> btnPosClearClick() : "Clear"버튼 클릭시 호출되는 핸들러 함수.
//  - 선택된 보간축들의 위치정보를 0.0으로 설정합니다.
//  - AxmStatusSetPosMatch함수는 AxmStatusSetCmdPos, AxmStatusSetActPos 함수를 
//    사용하는것과 동일한 효과를 냅니다.
// --------------------------------------------------------------------------
void __fastcall TForm1::btnPosClearClick(TObject *Sender)
{
        long lCount;
	for(lCount = 0; lCount < m_lMoveIntpAxesCount; lCount++){
		//++ Command위치와 Actual위치를 지정한 값으로 설정합니다.
		AxmStatusSetPosMatch(m_lMoveIntpAxes[lCount], 0.0);
	}
}
//---------------------------------------------------------------------------

// ++ =======================================================================
// >> chkServoOnClick() : "Servo On"버튼 클릭시 호출되는 핸들러 함수.
//  - 선택된 보간축들을 체크버튼의 상태에 따라 서보 On/Off 합니다.
// --------------------------------------------------------------------------
void __fastcall TForm1::chkServoOnClick(TObject *Sender)
{
        long lCount;
	for(lCount = 0; lCount < m_lMoveIntpAxesCount; lCount++){
		//++ 지정 축의 Servo On/Off 신호를 출력합니다.
		AxmSignalServoOn(m_lMoveIntpAxes[lCount], chkServoOn->Checked);
	}
}
//---------------------------------------------------------------------------

// ++ =======================================================================
// >> btnIntpLineClick() : "Line"버튼 클릭시 호출되는 핸들러 함수.
//  - 선택된 보간축들 중 2축을 이용해 단위 직선보간을 하는 함수입니다.
// --------------------------------------------------------------------------
void __fastcall TForm1::btnIntpLineClick(TObject *Sender)
{
        DWORD	dwRetCode;
	double  dMovePos[2];
	double	dVelocity, dAccel, dDecel;

	dVelocity	= StrToFloat(edtMoveVel->Text);
	dAccel		= StrToFloat(edtMoveAcc->Text);
	dDecel		= StrToFloat(edtMoveDec->Text);

	dMovePos[0]	= 100.0;	// 첫번째 축의 이동할 위치값
	dMovePos[1]	= 200.0;	// 두번째 축의 이동할 위치값

	//++ 지정한 좌표계에 연속보간 축들을 맵핑합니다.
	AxmContiSetAxisMap(COORD_NO, 2, m_lMoveIntpAxes);
	//++ 지정한 좌표계에 구동모드을 설정합니다.(절대구동/상대구동)
	AxmContiSetAbsRelMode(COORD_NO, POS_REL_MODE);

	//++ 지정한 좌표계의 축들을 이용해 직선보간구동을 수행합니다.
	dwRetCode = AxmLineMove(COORD_NO, dMovePos, dVelocity, dAccel, dDecel);
	if(dwRetCode != AXT_RT_SUCCESS){
		String strData;
		strData = strData.Format("AxmLineMove return error[Code:%.4d]", ARRAYOFCONST(((int)dwRetCode)));
		ShowMessage(strData);
	}
}
//---------------------------------------------------------------------------

// ++ =======================================================================
// >> btnIntpArcClick() : "Arc"버튼 클릭시 호출되는 핸들러 함수.
//  - 선택된 보간축들 중 2축을 이용해 단위 Arc보간을 하는 함수입니다.
// --------------------------------------------------------------------------
void __fastcall TForm1::btnIntpArcClick(TObject *Sender)
{
        double  dEndPos[2], dRadius;	
	double	dVelocity, dAccel, dDecel;
	DWORD	dwRetCode, dwArcDir, dwShortDis;
	
	dVelocity	= StrToFloat(edtMoveVel->Text);
	dAccel		= StrToFloat(edtMoveAcc->Text);
	dDecel		= StrToFloat(edtMoveDec->Text);
	
	dEndPos[0]	= 100.0;
	dEndPos[1]	= 100.0;
	dRadius		= 141.0;	
	dwArcDir	= DIR_CW;
	dwShortDis	= LONG_DISTANCE;
	
	//++ 지정한 좌표계에 연속보간 축들을 맵핑합니다.
	AxmContiSetAxisMap(COORD_NO, 2, m_lMoveIntpAxes);
	//++ 지정한 좌표계에 구동모드을 설정합니다.(절대구동/상대구동)
	AxmContiSetAbsRelMode(COORD_NO, POS_ABS_MODE);
	
	//++ 지정한 좌표계의 축들 중 특정 2축에 반지름을 이용한 원호보간구동을 수행합니다.  
	dwRetCode = AxmCircleRadiusMove(COORD_NO, m_lMoveIntpAxes, dRadius, dEndPos, dVelocity, dAccel, dDecel, dwArcDir, dwShortDis);
	if(dwRetCode != AXT_RT_SUCCESS){
		String strData;
		strData = strData.Format("AxmCircleRadiusMove return error[Code:%.4d]", ARRAYOFCONST(((int)dwRetCode)));
		ShowMessage(strData);
	}
}
//---------------------------------------------------------------------------

// ++ =======================================================================
// >> btnIntpCircleClick() : "Circle"버튼 클릭시 호출되는 핸들러 함수.
//  - 선택된 보간축들 중 2축을 이용해 단위 원호보간을 하는 함수입니다.
// --------------------------------------------------------------------------
void __fastcall TForm1::btnIntpCircleClick(TObject *Sender)
{
        DWORD	dwRetCode, dwArcDir;
	double  dCenterPos[2], dAngle;	
	double	dVelocity, dAccel, dDecel;
	
	dVelocity	= StrToFloat(edtMoveVel->Text);
	dAccel		= StrToFloat(edtMoveAcc->Text);
	dDecel		= StrToFloat(edtMoveDec->Text);
	
	dCenterPos[0]	= 200.0;
	dCenterPos[1]	= 200.0;
	dAngle			= 360.0;	
	dwArcDir		= DIR_CCW;
	
	//++ 지정한 좌표계에 연속보간 축들을 맵핑합니다.
	AxmContiSetAxisMap(COORD_NO, 2, m_lMoveIntpAxes);
	//++ 지정한 좌표계에 구동모드을 설정합니다.(절대구동/상대구동)
	AxmContiSetAbsRelMode(COORD_NO, POS_ABS_MODE);
	
	//++ 지정한 좌표계의 축들 중 특정 2축에, 회전중심과 회전각도를 이용한 원호보간 구동을 수행합니다.
	Sleep(1);
	dwRetCode = AxmCircleAngleMove(COORD_NO, m_lMoveIntpAxes, dCenterPos, dAngle, dVelocity, dAccel, dDecel, dwArcDir);
	if(dwRetCode != AXT_RT_SUCCESS){
		String strData;
		strData = strData.Format("AxmCircleAngleMove return error[Code:%.4d]", ARRAYOFCONST(((int)dwRetCode)));
		ShowMessage(strData);
	}
}
//---------------------------------------------------------------------------

// ++ =======================================================================
// >> btnIntpLineArcClick() : "Line & Arc"버튼 클릭시 호출되는 핸들러 함수.
//  - 선택된 보간축들 중 2축을 이용해 연속 직선/원호보간을 하는 함수입니다.
// --------------------------------------------------------------------------
void __fastcall TForm1::btnIntpLineArcClick(TObject *Sender)
{
        double  dMovePos[2];
	double  dCenPos[2];	
	double  dEndPos[2];
	double	dVelocity, dAccel, dDecel;
	
	dVelocity	= StrToFloat(edtMoveVel->Text);
	dAccel		= StrToFloat(edtMoveAcc->Text);
	dDecel		= StrToFloat(edtMoveDec->Text);
	
	//++ 지정한 좌표계에 연속보간 축들을 맵핑합니다.
	AxmContiSetAxisMap(COORD_NO, 2, m_lMoveIntpAxes);
	//++ 지정한 좌표계에 등록되어있는 보간데이타를 모두 지웁니다.
	AxmContiWriteClear(COORD_NO);
	//++ 지정한 좌표계에 구동모드을 설정합니다.(절대구동/상대구동)
	AxmContiSetAbsRelMode(COORD_NO, POS_ABS_MODE);
	
	//++ 지정한 좌표계에 연속보간을 수행할 작업 등록을 시작합니다.
	// ※ [CAUTION] 이 함수가 실행된 후 에는 보간함수들이 즉시 구동되지 않고 보간데이타 Queue에 예약됩니다.
	AxmContiBeginNode(COORD_NO); 	

	dMovePos[0] = 0.0 , dMovePos[1] = 200.0;	
	//++ 지정한 좌표계에 직선보간 구동을 예약합니다.
	AxmLineMove(COORD_NO, dMovePos, dVelocity, dAccel, dDecel);
	
	dMovePos[0] = 180.0, dMovePos[1] = 200.0;	
	AxmLineMove(COORD_NO, dMovePos, dVelocity, dAccel, dDecel);	
	
	dCenPos[0] = 180.0, dCenPos[1] = 180.0; 
	dEndPos[0] = 200.0, dEndPos[1] = 180.0;
	//++ 지정한 좌표계에 중심점과 종료점을 이용하는 원호보간 구동을 예약합니다.
	AxmCircleCenterMove(COORD_NO, m_lMoveIntpAxes, dCenPos, dEndPos, dVelocity, dAccel, dDecel, DIR_CW);
	
	dMovePos[0] = 200.0, dMovePos[1] = -180.0;
	AxmLineMove(COORD_NO, dMovePos, dVelocity, dAccel, dDecel);	
	
	dCenPos[0] = 180.0, dCenPos[1] = -180.0; 
	dEndPos[0] = 180.0, dEndPos[1] = -200.0;
	AxmCircleCenterMove(COORD_NO, m_lMoveIntpAxes, dCenPos, dEndPos, dVelocity, dAccel, dDecel, DIR_CW);
	
	dMovePos[0] = -180.0, dMovePos[1] = -200.0;
	AxmLineMove(COORD_NO, dMovePos, dVelocity, dAccel, dDecel);	
	
	dCenPos[0] = -180.0, dCenPos[1] = -180.0; 
	dEndPos[0] = -200.0, dEndPos[1] = -180.0;
	AxmCircleCenterMove(COORD_NO, m_lMoveIntpAxes, dCenPos, dEndPos, dVelocity, dAccel, dDecel, DIR_CW);
	
	dMovePos[0] = -200.0, dMovePos[1] = 180.0;
	AxmLineMove(COORD_NO, dMovePos, dVelocity, dAccel, dDecel);	
	
	dCenPos[0] = -180.0, dCenPos[1] = 180.0; 
	dEndPos[0] = -180.0, dEndPos[1] = 200.0;
	AxmCircleCenterMove(COORD_NO, m_lMoveIntpAxes, dCenPos, dEndPos, dVelocity, dAccel, dDecel, DIR_CW);
	
	dMovePos[0] = 0.0, dMovePos[1] = 200.0;
	AxmLineMove(COORD_NO, dMovePos, dVelocity, dAccel, dDecel);	
	
	//++ 지정한 좌표계에 연속보간을 수행할 작업 등록을 종료합니다.
	// ※ [CAUTION] AxmContiBeginNode 함수 실행후 연속보간 작업을 등록한 후 반드시 이 함수로 등록을 종료해야
	//              연속보간 구동을 실행할 수 있습니다.
	AxmContiEndNode(COORD_NO);
}
//---------------------------------------------------------------------------

// ++ =======================================================================
// >> btnIntpHelicalClick() : "Helical"버튼 클릭시 호출되는 핸들러 함수.
//  - 선택된 보간축들 중 4축을 이용해 연속 헬리컬 보간을 하는 함수입니다.
// --------------------------------------------------------------------------
void __fastcall TForm1::btnIntpHelicalClick(TObject *Sender)
{
        DWORD	dwArcDir;
	double	dVelocity, dAccel, dDecel;
	double  dCenterPosX, dCenterPosY, dEndPosX, dEndPosY, dZPos;
	
	dVelocity	= StrToFloat(edtMoveVel->Text);
	dAccel		= StrToFloat(edtMoveAcc->Text);
	dDecel		= StrToFloat(edtMoveDec->Text);
	
	dCenterPosX	= 100.0;	
	dCenterPosY     = 100.0;
	dEndPosX	= 0.0;		
	dEndPosY	= 0.0;
	dZPos		= 10.0;
	dwArcDir	= DIR_CW;

	//++ 지정한 좌표계에 연속보간 축들을 맵핑합니다.
	AxmContiSetAxisMap(COORD_NO, 4, m_lMoveIntpAxes);
	//++ 지정한 좌표계에 등록되어있는 보간데이타를 모두 지웁니다.
	AxmContiWriteClear(COORD_NO);
	//++ 지정한 좌표계에 구동모드을 설정합니다.(절대구동/상대구동)
	AxmContiSetAbsRelMode(COORD_NO, POS_REL_MODE);

	//++ 지정한 좌표계에 연속보간을 수행할 작업 등록을 시작합니다.
	// ※ [CAUTION] 이 함수가 실행된 후 에는 보간함수들이 즉시 구동되지 않고 보간데이타 Queue에 예약됩니다.
	AxmContiBeginNode(COORD_NO);
	//++ 지정한 좌표계에 중심점과 종료점을 이용하는 헬리컬 보간구동을 예약합니다.
	AxmHelixCenterMove(COORD_NO, dCenterPosX, dCenterPosY, dEndPosX, dEndPosY, dZPos, dVelocity, dAccel, dAccel, dwArcDir);
	AxmHelixCenterMove(COORD_NO, dCenterPosX, dCenterPosY, dEndPosX, dEndPosY, dZPos, dVelocity, dAccel, dAccel, dwArcDir);
	AxmHelixCenterMove(COORD_NO, dCenterPosX, dCenterPosY, dEndPosX, dEndPosY, dZPos, dVelocity, dAccel, dAccel, dwArcDir);
	AxmHelixCenterMove(COORD_NO, dCenterPosX, dCenterPosY, dEndPosX, dEndPosY, dZPos, dVelocity, dAccel, dAccel, dwArcDir);
	AxmHelixCenterMove(COORD_NO, dCenterPosX, dCenterPosY, dEndPosX, dEndPosY, dZPos, dVelocity, dAccel, dAccel, dwArcDir);
	AxmHelixCenterMove(COORD_NO, dCenterPosX, dCenterPosY, dEndPosX, dEndPosY, dZPos, dVelocity, dAccel, dAccel, dwArcDir);
	AxmHelixCenterMove(COORD_NO, dCenterPosX, dCenterPosY, dEndPosX, dEndPosY, dZPos, dVelocity, dAccel, dAccel, dwArcDir);
	AxmHelixCenterMove(COORD_NO, dCenterPosX, dCenterPosY, dEndPosX, dEndPosY, dZPos, dVelocity, dAccel, dAccel, dwArcDir);
	AxmHelixCenterMove(COORD_NO, dCenterPosX, dCenterPosY, dEndPosX, dEndPosY, dZPos, dVelocity, dAccel, dAccel, dwArcDir);
	AxmHelixCenterMove(COORD_NO, dCenterPosX, dCenterPosY, dEndPosX, dEndPosY, dZPos, dVelocity, dAccel, dAccel, dwArcDir);

	//++ 지정한 좌표계에 연속보간을 수행할 작업 등록을 종료합니다.
	// ※ [CAUTION] AxmContiBeginNode 함수 실행후 연속보간 작업을 등록한 후 반드시 이 함수로 등록을 종료해야
	//              연속보간 구동을 실행할 수 있습니다.
	AxmContiEndNode(COORD_NO);
}
//---------------------------------------------------------------------------

// ++ =======================================================================
// >> btnIntpSplineClick() : "Spline"버튼 클릭시 호출되는 핸들러 함수.
//  - 선택된 보간축들 중 3축을 이용해 스플라인 보간을 하는 함수입니다.
// --------------------------------------------------------------------------
void __fastcall TForm1::btnIntpSplineClick(TObject *Sender)
{
        long	lPointFactor;
	double	dVelocity, dAccel, dDecel;
	double	dPosX[MAX_SPLINE_NODE], dPosY[MAX_SPLINE_NODE], dPosZ;

	dVelocity	= StrToFloat(edtMoveVel->Text);
	dAccel		= StrToFloat(edtMoveAcc->Text);
	dDecel		= StrToFloat(edtMoveDec->Text);
	
	//++ 지정한 좌표계에 연속보간 축들을 맵핑합니다.
	AxmContiSetAxisMap(COORD_NO, 3, m_lMoveIntpAxes);
	//++ 지정한 좌표계에 등록되어있는 보간데이타를 모두 지웁니다.
	AxmContiWriteClear(COORD_NO);
	//++ 지정한 좌표계에 구동모드을 설정합니다.(절대구동/상대구동)
	AxmContiSetAbsRelMode(COORD_NO, POS_ABS_MODE);
	
	dPosX[0] = 0,	dPosY[0] = 0;
	dPosX[1] = 45,  dPosY[1] = 10;
	dPosX[2] = 75,  dPosY[2] = 45;
	dPosX[3] = 108, dPosY[3] = 75;
	dPosX[4] = 130, dPosY[4] = 70;
	dPosZ	 = 1.0;
	lPointFactor = 100;

	//++ 지정한 좌표계에 연속보간을 수행할 작업 등록을 시작합니다.
	// ※ [CAUTION] 이 함수가 실행된 후 에는 보간함수들이 즉시 구동되지 않고 보간데이타 Queue에 예약됩니다.
	AxmContiBeginNode(COORD_NO);
	//++ 지정한 좌표계에 X좌표, Y좌표, Z좌표를 이용하는 스플라인 보간구동을 예약합니다.
	AxmSplineWrite(COORD_NO, MAX_SPLINE_NODE, dPosX, dPosY, dVelocity, dAccel, dAccel, dPosZ, lPointFactor);

	dPosX[0] = 130,	dPosY[0] = 70;
	dPosX[1] = 108, dPosY[1] = 75;
	dPosX[2] = 75,  dPosY[2] = 45;
	dPosX[3] = 45,  dPosY[3] = 10;
	dPosX[4] = 0,   dPosY[4] = 0;
	dPosZ		= 1.0;
	lPointFactor= 100;
	AxmSplineWrite(COORD_NO, MAX_SPLINE_NODE, dPosX, dPosY, dVelocity, dAccel, dAccel, dPosZ, lPointFactor);

	//++ 지정한 좌표계에 연속보간을 수행할 작업 등록을 종료합니다.
	// ※ [CAUTION] AxmContiBeginNode 함수 실행후 연속보간 작업을 등록한 후 반드시 이 함수로 등록을 종료해야
	//              연속보간 구동을 실행할 수 있습니다.
	AxmContiEndNode(COORD_NO);
}
//---------------------------------------------------------------------------

// ++ =======================================================================
// >> btnIntpStartClick() : "Start"버튼 클릭시 호출되는 핸들러 함수.
//  - 예약된 연속보간 데이타들을 이용하여 연속보간을 시작하는 함수입니다.
// --------------------------------------------------------------------------
void __fastcall TForm1::btnIntpStartClick(TObject *Sender)
{
        DWORD dwRetCode;

	//++ 지정한 좌표계의 연속보간 구동을 시작합니다.
	dwRetCode = AxmContiStart(COORD_NO, CONTI_NODE_VELOCITY, 0);
	if(dwRetCode != AXT_RT_SUCCESS){
		String strData;
		strData = strData.Format("AxmContiStart return error[Code:%.4d]", ARRAYOFCONST(((int)dwRetCode)));
		ShowMessage(strData);
	}
}
//---------------------------------------------------------------------------

// ++ =======================================================================
// >> btnIntpClearClick() : "Clear"버튼 클릭시 호출되는 핸들러 함수.
//  - 예약된 연속보간 데이타들을 지우는 함수입니다.
// --------------------------------------------------------------------------
void __fastcall TForm1::btnIntpClearClick(TObject *Sender)
{
        DWORD dwRetCode;

	//++ 지정한 좌표계에 연속 보간 구동을 위해 예약된 보간데이타를 모두 삭제합니다.
	dwRetCode = AxmContiWriteClear(COORD_NO);
	if(dwRetCode != AXT_RT_SUCCESS){
		String strData;
		strData = strData.Format("AxmContiWriteClear return error[Code:%.4d]", ARRAYOFCONST(((int)dwRetCode)));
		ShowMessage(strData);
	}
}
//---------------------------------------------------------------------------

// ++ =======================================================================
// >> btnIntpStopClick() : "Stop"버튼 클릭시 호출되는 핸들러 함수.
//  - 연속보간을 정지하는 함수입니다.
// --------------------------------------------------------------------------
void __fastcall TForm1::btnIntpStopClick(TObject *Sender)
{
        long lCount;
	for(lCount = 0; lCount < m_lMoveIntpAxesCount; lCount++){
		//++ 지정한 좌표계에 연속 보간 구동을 감속정지합니다.
		// [INFO] 좌표계에 포함된 한 축을 정지하면 연속보간은 정지됩니다.
		AxmMoveSStop(m_lMoveIntpAxes[lCount]);
	}
}
//---------------------------------------------------------------------------

// ++ =======================================================================
// >> m_timerTimer(...) : 타이머 이벤트 핸들러 함수.
//  - 일정한 주기로 변경되는 위치/속도/정보등을 Control에 반영합니다.
// --------------------------------------------------------------------------
void __fastcall TForm1::m_timerTimer(TObject *Sender)
{
        long	lCount, lArrayIndex = 0;
	double	dCmdPos, dActPos, dCmdVel;
	long	lExeNode = 0, lTotalNode = 0; 
	DWORD	dwQueueFree = 0, dwIntpInMotion= 0;

        for(lCount = 0; lCount < MAX_INTP_MOVE_AXIS; lCount++){
		// 버튼 콘트롤의 체크 상태를 확인합니다.
		if(m_chkMoveIntpAxes[lCount]->Checked)
		{
			//++ 지정한 축의 지령(Command)위치를 반환합니다.
			AxmStatusGetCmdPos(m_lMoveIntpAxes[lArrayIndex], &dCmdPos);
			if(m_dOldCmdPos[lCount] != dCmdPos){
								m_stcCmdPos[lCount]->Text = m_stcCmdPos[lCount]->Text.Format("%.3f", ARRAYOFCONST((dCmdPos)));
				m_dOldCmdPos[lCount] = dCmdPos;
			}

			//++ 지정한 축의 실제(Feedback)위치를 반환합니다.
			AxmStatusGetActPos(m_lMoveIntpAxes[lArrayIndex], &dActPos);
			if(m_dOldActPos[lCount] != dActPos){
								m_stcActPos[lCount]->Text = m_stcActPos[lCount]->Text.Format("%.3f", ARRAYOFCONST((dActPos)));
				m_dOldActPos[lCount] = dActPos;
			}

			//++ 지정한 축의 구동 속도를 반환합니다.
			AxmStatusReadVel(m_lMoveIntpAxes[lArrayIndex], &dCmdVel);
			if(m_dOldCmdVel[lCount] != dCmdVel){
                                m_stcCmdVel[lCount]->Text = m_stcCmdVel[lCount]->Text.Format("%.3f", ARRAYOFCONST((dCmdVel)));
				m_dOldCmdVel[lCount] = dCmdVel;
			}

			++lArrayIndex;
		}
	}

	//++ 지정한 좌표계에 연속보간 Queue가 비었는지 확인합니다.
	AxmContiReadFree(COORD_NO, &dwQueueFree);
        chkIntpQueueFree->Checked = dwQueueFree;

	//++ 지정한 좌표계가 연속보간 구동중인지 확인합니다.
	AxmContiIsMotion(COORD_NO, &dwIntpInMotion);
        chkIntpInMotion->Checked = dwIntpInMotion;

	//++ 지정한 좌표계가 연속보간 구동중 현재 실행중인 Node의 Index를 확인합니다.
	AxmContiGetNodeNum(COORD_NO, &lExeNode);
	if(StrToInt(stcIntpExeNode->Text) != (UINT)lExeNode)
				stcIntpExeNode->Text = stcIntpExeNode->Text.Format("%d", ARRAYOFCONST(((int)lExeNode)));

	//++ 지정한 좌표계에 예약된 연속보간 데이타의 전체 갯수를 확인합니다.
	AxmContiGetTotalNodeNum(COORD_NO, &lTotalNode);
	if(StrToInt(stcIntpTotalNode->Text) != (UINT)lTotalNode)
                stcIntpTotalNode->Text = stcIntpTotalNode->Text.Format("%d", ARRAYOFCONST(((int)lTotalNode)));
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
		case AXT_SMC_R1V04MLIIPM:	strData = strData.Format("%.2ld-[R1V04MLIIPM]", ARRAYOFCONST((i)));	break;
		case AXT_SMC_R1V04PM2Q:		strData = strData.Format("%.2ld-[R1V04PM2Q]", ARRAYOFCONST((i)));	break;
		case AXT_SMC_R1V04PM2QE:	strData = strData.Format("%.2ld-[R1V04PM2QE]", ARRAYOFCONST((i)));	break;
		case AXT_SMC_R1V04MLIIIPM:	strData = strData.Format("%.2ld-[R1V04MLIIIPM]", ARRAYOFCONST((i)));	break;
		case AXT_SMC_R1V04MLIISV:	strData = strData.Format("%.2ld-[R1V04MLIISV]", ARRAYOFCONST((i)));	break;
		case AXT_SMC_R1V04A5:		strData = strData.Format("%.2ld-[R1V04A5]", ARRAYOFCONST((i)));	break;
		case AXT_SMC_R1V04A4:		strData = strData.Format("%.2ld-[R1V04A4]", ARRAYOFCONST((i)));	break;
		case AXT_SMC_R1V04SIIIHMIV:	strData = strData.Format("%.2ld-[R1V04SIIIHMIV]", ARRAYOFCONST((i)));	break;
		case AXT_SMC_R1V04SIIIHMIV_R:	strData = strData.Format("%.2ld-[R1V04SIIIHMIV_R]", ARRAYOFCONST((i)));	break;
		case AXT_SMC_R1V04MLIIISV:	strData = strData.Format("%.2ld-[R1V04MLIIISV]", ARRAYOFCONST((i)));	break;
		case AXT_SMC_R1V04MLIIISV_MD:	strData = strData.Format("%.2ld-[R1V04MLIIISV_MD]", ARRAYOFCONST((i)));	break;
		case AXT_SMC_R1V04MLIIIS7S:	strData = strData.Format("%.2ld-[R1V04MLIIIS7S]", ARRAYOFCONST((i)));	break;
		case AXT_SMC_R1V04MLIIIS7W:	strData = strData.Format("%.2ld-[R1V04MLIIIS7W]", ARRAYOFCONST((i)));	break;
		case AXT_ECAT_MOTION:			strData = strData.Format("%.2ld-[ECAT_MOTION]", ARRAYOFCONST((i)));	break;
		default:			strData = strData.Format("%.2ld-[Unknown]", ARRAYOFCONST((i)));
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

	String	strData;
	DWORD	dwOnOff = 0;
	long	lCount, lTotalCount = 0;
	BOOL	bSelectCheck, bEmptyCheck, bAllCheck;
	long	lBoardNo = 0, lModulePos = 0, lFirstAxisNo = 0;

	//++ 지정한 축의 정보를 반환합니다.
	// [INFO] 여러개의 정보를 읽는 함수 사용시 불필요한 정보는 NULL(0)을 입력하면 됩니다.
	AxmInfoGetAxis(m_lAxisNo, &lBoardNo, &lModulePos, NULL);
	//++ 지정한 보드/모듈의 첫번째 축 번호를 반환합니다.
	AxmInfoGetFirstAxisNo(lBoardNo, lModulePos, &lFirstAxisNo);

	bSelectCheck	= FALSE;
	bEmptyCheck	= FALSE;
	m_lMoveIntpAxesCount = 0;
	for(lCount = 0; lCount < MAX_INTP_MOVE_AXIS; lCount++){
		//++ 지정한 축이 제어가 가능한 상태인지 반환합니다.
		if(AxmInfoGetAxisStatus(lFirstAxisNo) == AXT_RT_SUCCESS){
			strData = strData.Format("Axis %.2d", ARRAYOFCONST(((int)lFirstAxisNo)));

			m_chkMoveIntpAxes[lCount]->Enabled = true;
			bSelectCheck = m_chkMoveIntpAxes[lCount]->Checked;
			bEmptyCheck  |= bSelectCheck;
			
			if(bSelectCheck == TRUE){
				m_lMoveIntpAxes[m_lMoveIntpAxesCount++] = lFirstAxisNo; 
			}
		}else{
			m_lMoveIntpAxes[lCount] = -1; 
			strData = "Axis --";

			m_chkMoveIntpAxes[lCount]->Enabled = false;
			m_chkMoveIntpAxes[lCount]->Checked = false;
		}
		
		lFirstAxisNo++;
		m_chkMoveIntpAxes[lCount]->Caption = strData;
	}
	
	// 선택된 축이 없으면 Disable처리
	chkServoOn->Enabled = bEmptyCheck;
	
	bAllCheck = TRUE;
	for(lCount = 0; lCount < m_lMoveIntpAxesCount; lCount++){
		//++ 지정한 축의 서보온 상태를 반환합니다.
		AxmSignalIsServoOn(m_lMoveIntpAxes[lCount], &dwOnOff);
		// 선택된 보간축들이 모두 서보온 되어있을 때 TRUE 
		bAllCheck &= dwOnOff;
	}		

	chkServoOn->Checked = bAllCheck;

	// 선택된 축수에 따라 사용가능한 보간버튼들을 활성화시킵니다.
	if(m_lMoveIntpAxesCount < 2){
		btnIntpLine->Enabled = DISABLE;
		btnIntpArc->Enabled = DISABLE;
		btnIntpCircle->Enabled = DISABLE;
		btnIntpLineArc->Enabled = DISABLE;
		btnIntpHelical->Enabled = DISABLE;
		btnIntpSpline->Enabled = DISABLE;
	}else{
		btnIntpLine->Enabled = ENABLE;
		btnIntpArc->Enabled = ENABLE;
		btnIntpCircle->Enabled = ENABLE;
		btnIntpLineArc->Enabled = ENABLE;
		btnIntpSpline->Enabled = ENABLE;

		if(m_lMoveIntpAxesCount >= 3)
                        btnIntpSpline->Enabled = ENABLE;
		else
                	btnIntpSpline->Enabled = DISABLE;

		if(m_lMoveIntpAxesCount == 4)
                        btnIntpHelical->Enabled = ENABLE;
		else
                        btnIntpHelical->Enabled = DISABLE;
	}

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
