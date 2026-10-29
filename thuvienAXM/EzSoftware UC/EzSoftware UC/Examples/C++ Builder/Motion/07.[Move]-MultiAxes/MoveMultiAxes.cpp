// MoveMultiAxes.cpp : implementation file
//
// **************************************************************************
// >> [일자]: 2015.12.16
// >> [개요]: 이 예제는 다축구동 함수들의 사용법을 익히고 각 함수들의 인자값을
//    변경하면서 구동해 보는 예제입니다.
// >> [중요]: 다축 구동함수들로 구동중 포함된 축중 한축만 정지해도 다른축들이
//    구동을 정지하게 됩니다.
// >> [중요]: 일정한 거리 비율을 유지하는 다축조그 구동방법
//     1) AxmMoveStartLineVel 함수의 dDis값에 각 축의 거리 비율을 설정합니다.
//     2) dDis[4] = {10.0, 20.0, 30.0, 40.0}으로 설정하였을 경우 0축이 10.0에
//        도달했을 때 1, 2, 3축은 20.0, 30.0, 40.0의 위치에 도달하게 됩니다.
// **************************************************************************

//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "MoveMultiAxes.h"
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

	memset(m_lMoveMultiAxes, -1, sizeof(m_lMoveMultiAxes));
}
//---------------------------------------------------------------------------

void __fastcall TForm1::FormCreate(TObject *Sender)
{
        for(int i = 0; i < MAX_MULTI_MOVE_AXIS; i++) {
                m_lMoveMultiAxes[i] = -1;
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

        m_chkMoveMultiAxes[0] = chkAxis00;
        m_chkMoveMultiAxes[1] = chkAxis01;
        m_chkMoveMultiAxes[2] = chkAxis02;
        m_chkMoveMultiAxes[3] = chkAxis03;

        m_edtMovePos[0] = edtMovePos00;
        m_edtMovePos[1] = edtMovePos01;
        m_edtMovePos[2] = edtMovePos02;
        m_edtMovePos[3] = edtMovePos03;

        m_edtMoveVel[0] = edtMoveVel00;
        m_edtMoveVel[1] = edtMoveVel01;
        m_edtMoveVel[2] = edtMoveVel02;
        m_edtMoveVel[3] = edtMoveVel03;

        m_edtMoveAcc[0] = edtMoveAcc00;
        m_edtMoveAcc[1] = edtMoveAcc01;
        m_edtMoveAcc[2] = edtMoveAcc02;
        m_edtMoveAcc[3] = edtMoveAcc03;

        m_edtMoveDec[0] = edtMoveDec00;
        m_edtMoveDec[1] = edtMoveDec01;
        m_edtMoveDec[2] = edtMoveDec02;
        m_edtMoveDec[3] = edtMoveDec03;

        m_edtJogVel[0] = edtJogVel00;
        m_edtJogVel[1] = edtJogVel01;
        m_edtJogVel[2] = edtJogVel02;
		m_edtJogVel[3] = edtJogVel03;

        m_edtJogAcc[0] = edtJogAcc00;
        m_edtJogAcc[1] = edtJogAcc01;
        m_edtJogAcc[2] = edtJogAcc02;
        m_edtJogAcc[3] = edtJogAcc03;

        m_edtJogDec[0] = edtJogDec00;
        m_edtJogDec[1] = edtJogDec01;
        m_edtJogDec[2] = edtJogDec02;
        m_edtJogDec[3] = edtJogDec03;

        m_edtLinePos[0] = edtLinePos00;
        m_edtLinePos[1] = edtLinePos01;
        m_edtLinePos[2] = edtLinePos02;
        m_edtLinePos[3] = edtLinePos03;

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

        SetWindowLong(edtMovePos00->Handle, GWL_STYLE,
            GetWindowLong(edtMovePos00->Handle, GWL_STYLE) | ES_RIGHT);
        SetWindowLong(edtMovePos01->Handle, GWL_STYLE,
            GetWindowLong(edtMovePos01->Handle, GWL_STYLE) | ES_RIGHT);
        SetWindowLong(edtMovePos02->Handle, GWL_STYLE,
            GetWindowLong(edtMovePos02->Handle, GWL_STYLE) | ES_RIGHT);
        SetWindowLong(edtMovePos03->Handle, GWL_STYLE,
            GetWindowLong(edtMovePos03->Handle, GWL_STYLE) | ES_RIGHT);
        SetWindowLong(edtMoveVel00->Handle, GWL_STYLE,
            GetWindowLong(edtMoveVel00->Handle, GWL_STYLE) | ES_RIGHT);
		SetWindowLong(edtMoveVel01->Handle, GWL_STYLE,
            GetWindowLong(edtMoveVel01->Handle, GWL_STYLE) | ES_RIGHT);
        SetWindowLong(edtMoveVel02->Handle, GWL_STYLE,
            GetWindowLong(edtMoveVel02->Handle, GWL_STYLE) | ES_RIGHT);
        SetWindowLong(edtMoveVel03->Handle, GWL_STYLE,
            GetWindowLong(edtMoveVel03->Handle, GWL_STYLE) | ES_RIGHT);
        SetWindowLong(edtMoveAcc00->Handle, GWL_STYLE,
            GetWindowLong(edtMoveAcc00->Handle, GWL_STYLE) | ES_RIGHT);
        SetWindowLong(edtMoveAcc01->Handle, GWL_STYLE,
            GetWindowLong(edtMoveAcc01->Handle, GWL_STYLE) | ES_RIGHT);
        SetWindowLong(edtMoveAcc02->Handle, GWL_STYLE,
            GetWindowLong(edtMoveAcc02->Handle, GWL_STYLE) | ES_RIGHT);
        SetWindowLong(edtMoveAcc03->Handle, GWL_STYLE,
            GetWindowLong(edtMoveAcc03->Handle, GWL_STYLE) | ES_RIGHT);
        SetWindowLong(edtMoveDec00->Handle, GWL_STYLE,
            GetWindowLong(edtMoveDec00->Handle, GWL_STYLE) | ES_RIGHT);
        SetWindowLong(edtMoveDec01->Handle, GWL_STYLE,
            GetWindowLong(edtMoveDec01->Handle, GWL_STYLE) | ES_RIGHT);
        SetWindowLong(edtMoveDec02->Handle, GWL_STYLE,
            GetWindowLong(edtMoveDec02->Handle, GWL_STYLE) | ES_RIGHT);
        SetWindowLong(edtMoveDec03->Handle, GWL_STYLE,
            GetWindowLong(edtMoveDec03->Handle, GWL_STYLE) | ES_RIGHT);

        SetWindowLong(edtJogVel00->Handle, GWL_STYLE,
            GetWindowLong(edtJogVel00->Handle, GWL_STYLE) | ES_RIGHT);
        SetWindowLong(edtJogVel01->Handle, GWL_STYLE,
            GetWindowLong(edtJogVel01->Handle, GWL_STYLE) | ES_RIGHT);
        SetWindowLong(edtJogVel02->Handle, GWL_STYLE,
            GetWindowLong(edtJogVel02->Handle, GWL_STYLE) | ES_RIGHT);
        SetWindowLong(edtJogVel03->Handle, GWL_STYLE,
            GetWindowLong(edtJogVel03->Handle, GWL_STYLE) | ES_RIGHT);
        SetWindowLong(edtJogAcc00->Handle, GWL_STYLE,
            GetWindowLong(edtJogAcc00->Handle, GWL_STYLE) | ES_RIGHT);
        SetWindowLong(edtJogAcc01->Handle, GWL_STYLE,
            GetWindowLong(edtJogAcc01->Handle, GWL_STYLE) | ES_RIGHT);
        SetWindowLong(edtJogAcc02->Handle, GWL_STYLE,
            GetWindowLong(edtJogAcc02->Handle, GWL_STYLE) | ES_RIGHT);
        SetWindowLong(edtJogAcc03->Handle, GWL_STYLE,
            GetWindowLong(edtJogAcc03->Handle, GWL_STYLE) | ES_RIGHT);
        SetWindowLong(edtJogDec00->Handle, GWL_STYLE,
            GetWindowLong(edtJogDec00->Handle, GWL_STYLE) | ES_RIGHT);
        SetWindowLong(edtJogDec01->Handle, GWL_STYLE,
            GetWindowLong(edtJogDec01->Handle, GWL_STYLE) | ES_RIGHT);
        SetWindowLong(edtJogDec02->Handle, GWL_STYLE,
            GetWindowLong(edtJogDec02->Handle, GWL_STYLE) | ES_RIGHT);
        SetWindowLong(edtJogDec03->Handle, GWL_STYLE,
            GetWindowLong(edtJogDec03->Handle, GWL_STYLE) | ES_RIGHT);

        SetWindowLong(edtLinePos00->Handle, GWL_STYLE,
            GetWindowLong(edtLinePos00->Handle, GWL_STYLE) | ES_RIGHT);
        SetWindowLong(edtLinePos01->Handle, GWL_STYLE,
            GetWindowLong(edtLinePos01->Handle, GWL_STYLE) | ES_RIGHT);
        SetWindowLong(edtLinePos02->Handle, GWL_STYLE,
            GetWindowLong(edtLinePos02->Handle, GWL_STYLE) | ES_RIGHT);
        SetWindowLong(edtLinePos03->Handle, GWL_STYLE,
            GetWindowLong(edtLinePos03->Handle, GWL_STYLE) | ES_RIGHT);
        SetWindowLong(edtLineVel->Handle, GWL_STYLE,
            GetWindowLong(edtLineVel->Handle, GWL_STYLE) | ES_RIGHT);
        SetWindowLong(edtLineAcc->Handle, GWL_STYLE,
            GetWindowLong(edtLineVel->Handle, GWL_STYLE) | ES_RIGHT);
        SetWindowLong(edtLineDec->Handle, GWL_STYLE,
            GetWindowLong(edtLineDec->Handle, GWL_STYLE) | ES_RIGHT);

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
// >> chkAxis00Click(...) : 축 변경이 있을 때 호출되는 핸들러 함수.
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
void __fastcall TForm1::chkAxis03Click(TObject *Sender)
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

// ++ =======================================================================
// >> btnPosClearClick() : "Clear"버튼 클릭시 호출되는 핸들러 함수.
//  - 선택된 축의 위치정보를 0.0으로 설정합니다.
//  - AxmStatusSetPosMatch함수는 AxmStatusSetCmdPos, AxmStatusSetActPos 함수를
//    사용하는것과 동일한 효과를 냅니다.
// --------------------------------------------------------------------------
void __fastcall TForm1::btnPosClearClick(TObject *Sender)
{
	long lCount;
	for(lCount = 0; lCount < m_lMoveMultiAxesCount; lCount++){

		//++ Command위치와 Actual위치를 지정한 값으로 설정합니다.
		AxmStatusSetPosMatch(m_lMoveMultiAxes[lCount], 0.0);
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
	for(lCount = 0; lCount < m_lMoveMultiAxesCount; lCount++){
		AxmSignalServoOn(m_lMoveMultiAxes[lCount], chkServoOn->Checked);
	}
}
//---------------------------------------------------------------------------

// ++ =======================================================================
// >> btnPosMoveClick() : "Move"버튼 클릭시 호출되는 핸들러 함수.
//  - 선택한 축들을 지정한 거리(또는 위치)/속도/가속도/감속도로 모션구동합니다.
// --------------------------------------------------------------------------
void __fastcall TForm1::btnPosMoveClick(TObject *Sender)
{
	String strData;
	DWORD	dwRetCode;
	long	lCount, lArrayIndex;
	double	dMultiPos[MAX_MULTI_MOVE_AXIS], dMultiVel[MAX_MULTI_MOVE_AXIS], dMultiAcc[MAX_MULTI_MOVE_AXIS], dMultiDec[MAX_MULTI_MOVE_AXIS];

	lArrayIndex = 0;
	for(lCount = 0; lCount < MAX_MULTI_MOVE_AXIS; lCount++){
		if(m_chkMoveMultiAxes[lCount]->Checked){
			dMultiPos[lArrayIndex] = StrToFloat(m_edtMovePos[lCount]->Text);
			dMultiVel[lArrayIndex] = StrToFloat(m_edtMoveVel[lCount]->Text);
			dMultiAcc[lArrayIndex] = StrToFloat(m_edtMoveAcc[lCount]->Text);
			dMultiDec[lArrayIndex] = StrToFloat(m_edtMoveDec[lCount]->Text);
			++lArrayIndex;
		}
	}

	if(chkMoveBlock->Checked){
		//++ 지정한 축들을 지정한 거리(또는 위치)/속도/가속도/감속도로 각각 모션구동하고 모션이 종료되면 함수를 빠져나옵니다.
		dwRetCode = AxmMoveMultiPos(m_lMoveMultiAxesCount, m_lMoveMultiAxes, dMultiPos, dMultiVel, dMultiAcc, dMultiDec);
		if(dwRetCode != AXT_RT_SUCCESS){
			strData = strData.Format("AxmMoveMultiPos return error[Code:%.4d]", ARRAYOFCONST(((int)dwRetCode)));
			ShowMessage(strData);
		}
	}else{
		//++ 지정한 축들을 지정한 거리(또는 위치)/속도/가속도/감속도로 각각 모션구동하고 모션 종료여부와 상관없이 함수를 빠져나옵니다.
		dwRetCode = AxmMoveStartMultiPos(m_lMoveMultiAxesCount, m_lMoveMultiAxes, dMultiPos, dMultiVel, dMultiAcc, dMultiDec);
		if(dwRetCode != AXT_RT_SUCCESS){
						strData = strData.Format("AxmMoveStartMultiPos return error[Code:%.4d]", ARRAYOFCONST(((int)dwRetCode)));
			ShowMessage(strData);
		}
	}
}
//---------------------------------------------------------------------------

// ++ =======================================================================
// >> btnPosStopClick() : "Stop"버튼 클릭시 호출되는 핸들러 함수.
//  - 선택한 축들로 구동정지 함수를 호출하여 구동을 감속정지합니다.
// ※ [CAUTION] 다축 구동함수들로 구동시 포함된 축중 한축만 정지해도 다른축들이
//    구동을 정지하게 됩니다.
// --------------------------------------------------------------------------
void __fastcall TForm1::btnPosStopClick(TObject *Sender)
{
        long lCount;
	for(lCount = 0; lCount < m_lMoveMultiAxesCount; lCount++){
		//++ 지정한 축의 구동을 감속정지합니다.
		AxmMoveSStop(m_lMoveMultiAxes[lCount]);
	}
}
//---------------------------------------------------------------------------

// ++ =======================================================================
// >> btnJogPMouseDown(...) : "Jog(+/-)"버튼 Down시 호출되는 핸들러 함수.
//  - "CJogButton" 버튼 클래스에서 버튼 클릭시 호출되는 WM_LBUTTONDOWN 이벤트를
//    받아 사용자 이벤트로 이 함수를 호출해 줍니다. 이 때 wParam을 통해 전달되는
//    콘트롤 ID로 Jog(+/-)버튼을 구분하게 됩니다.
//  - Jog버튼 Down시 다축구동 함수를 호출하여 Jog 구동을 시작합니다.
// --------------------------------------------------------------------------
void __fastcall TForm1::btnJogPMouseDown(TObject *Sender,
      TMouseButton Button, TShiftState Shift, int X, int Y)
{
	String strData;
	DWORD	dwRetCode;
	long	lCount, lArrayIndex;
	double	dMultiVel[MAX_MULTI_MOVE_AXIS], dMultiAcc[MAX_MULTI_MOVE_AXIS], dMultiDec[MAX_MULTI_MOVE_AXIS];

	lArrayIndex = 0;
	for(lCount = 0; lCount < MAX_MULTI_MOVE_AXIS; lCount++){
		if(m_chkMoveMultiAxes[lCount]->Checked){
			dMultiVel[lArrayIndex] = abs(StrToFloat(m_edtJogVel[lCount]->Text));
			dMultiAcc[lArrayIndex] = abs(StrToFloat(m_edtJogAcc[lCount]->Text));
			dMultiDec[lArrayIndex] = abs(StrToFloat(m_edtJogDec[lCount]->Text));
			++lArrayIndex;
		}
	}

	//++ 선택한 축들을 (+/-)방향으로 지정한 속도/가속도/감속도로 모션구동합니다.
	dwRetCode = AxmMoveStartMultiVel(m_lMoveMultiAxesCount, m_lMoveMultiAxes, dMultiVel, dMultiAcc, dMultiDec);
	if(dwRetCode != AXT_RT_SUCCESS){
		strData = strData.Format("AxmMoveStartMultiVel return error[Code:%.4d]", ARRAYOFCONST(((int)dwRetCode)));
		ShowMessage(strData);
	}
}
//---------------------------------------------------------------------------
void __fastcall TForm1::btnJogNMouseDown(TObject *Sender, TMouseButton Button, TShiftState Shift, int X, int Y)
{
	String strData;
	DWORD	dwRetCode;
	long	lCount, lArrayIndex;
	double	dMultiVel[MAX_MULTI_MOVE_AXIS], dMultiAcc[MAX_MULTI_MOVE_AXIS], dMultiDec[MAX_MULTI_MOVE_AXIS];

	lArrayIndex = 0;
	for(lCount = 0; lCount < MAX_MULTI_MOVE_AXIS; lCount++){
		if(m_chkMoveMultiAxes[lCount]->Checked){
			dMultiVel[lArrayIndex] = -abs(StrToFloat(m_edtJogVel[lCount]->Text));
			dMultiAcc[lArrayIndex] = abs(StrToFloat(m_edtJogAcc[lCount]->Text));
			dMultiDec[lArrayIndex] = abs(StrToFloat(m_edtJogDec[lCount]->Text));
			++lArrayIndex;
		}
	}

	//++ 선택한 축들을 (+/-)방향으로 지정한 속도/가속도/감속도로 모션구동합니다.
	dwRetCode = AxmMoveStartMultiVel(m_lMoveMultiAxesCount, m_lMoveMultiAxes, dMultiVel, dMultiAcc, dMultiDec);
	if(dwRetCode != AXT_RT_SUCCESS){
		strData = strData.Format("AxmMoveStartMultiVel return error[Code:%.4d]", ARRAYOFCONST(((int)dwRetCode)));
		ShowMessage(strData);
	}
}
//---------------------------------------------------------------------------
void __fastcall TForm1::btnLinePMouseDown(TObject *Sender,
      TMouseButton Button, TShiftState Shift, int X, int Y)
{
	String  strData;
	DWORD	dwRetCode;
	long	lCount, lArrayIndex;
	double	dLineVel, dLineAcc, dLineDec;
	double	dLinePos[MAX_MULTI_MOVE_AXIS];

	lArrayIndex = 0;
	for(lCount = 0; lCount < MAX_MULTI_MOVE_AXIS; lCount++){
		if(m_chkMoveMultiAxes[lCount]->Checked){
			dLinePos[lArrayIndex] = abs(StrToFloat(m_edtLinePos[lCount]->Text));
			++lArrayIndex;
		}
	}

	dLineVel = abs(StrToFloat(edtLineVel->Text));
	dLineAcc = abs(StrToFloat(edtLineAcc->Text));
	dLineDec = abs(StrToFloat(edtLineDec->Text));

	//++ 선택한 축들을 (+/-)방향으로 지정한 위치 비율에따른 속도/가속도/감속도로 모션구동합니다.
	dwRetCode = AxmMoveStartLineVel(m_lMoveMultiAxesCount, m_lMoveMultiAxes, dLinePos, dLineVel, dLineAcc, dLineDec);
	if(dwRetCode != AXT_RT_SUCCESS){
		strData = strData.Format("AxmMoveStartLineVel return error[Code:%.4d]", ARRAYOFCONST(((int)dwRetCode)));
		ShowMessage(strData);
	}
}
//---------------------------------------------------------------------------
void __fastcall TForm1::btnLineNMouseDown(TObject *Sender,
      TMouseButton Button, TShiftState Shift, int X, int Y)
{
        String  strData;
	DWORD	dwRetCode;
	long	lCount, lArrayIndex;
	double	dLineVel, dLineAcc, dLineDec;
	double	dLinePos[MAX_MULTI_MOVE_AXIS];

        lArrayIndex = 0;
	for(lCount = 0; lCount < MAX_MULTI_MOVE_AXIS; lCount++){
		if(m_chkMoveMultiAxes[lCount]->Checked){
			dLinePos[lArrayIndex] = -abs(StrToFloat(m_edtLinePos[lCount]->Text));
			++lArrayIndex;
		}
	}

	dLineVel = abs(StrToFloat(edtLineVel->Text));
	dLineAcc = abs(StrToFloat(edtLineAcc->Text));
	dLineDec = abs(StrToFloat(edtLineDec->Text));

	//++ 선택한 축들을 (+/-)방향으로 지정한 위치 비율에따른 속도/가속도/감속도로 모션구동합니다.
	dwRetCode = AxmMoveStartLineVel(m_lMoveMultiAxesCount, m_lMoveMultiAxes, dLinePos, dLineVel, dLineAcc, dLineDec);
	if(dwRetCode != AXT_RT_SUCCESS){
		strData = strData.Format("AxmMoveStartLineVel return error[Code:%.4d]", ARRAYOFCONST(((int)dwRetCode)));
		ShowMessage(strData);
	}
}
//---------------------------------------------------------------------------

// ++ =======================================================================
// >> btnJogPMouseUp(...) : "Jog(+/-)"버튼 Up시 호출되는 핸들러 함수.
//  - "CJogButton" 버튼 클래스에서 버튼 클릭시 호출되는 WM_LBUTTONUP이벤트를
//    받아 사용자 이벤트로 이 함수를 호출해 줍니다. 이 때 wParam을 통해 전달되는
//    콘트롤 ID로 Jog(+/-)버튼을 구분하게 됩니다.
//  - Jog버튼 Up시 구동정지 함수를 호출하여 Jog 구동을 종료합니다.
// --------------------------------------------------------------------------
void __fastcall TForm1::btnJogPMouseUp(TObject *Sender,
      TMouseButton Button, TShiftState Shift, int X, int Y)
{
        btnPosStopClick(Sender);
}
//---------------------------------------------------------------------------
void __fastcall TForm1::btnJogNMouseUp(TObject *Sender,
      TMouseButton Button, TShiftState Shift, int X, int Y)
{
        btnPosStopClick(Sender);
}
//---------------------------------------------------------------------------
void __fastcall TForm1::btnLinePMouseUp(TObject *Sender,
      TMouseButton Button, TShiftState Shift, int X, int Y)
{
        btnPosStopClick(Sender);
}
//---------------------------------------------------------------------------
void __fastcall TForm1::btnLineNMouseUp(TObject *Sender,
      TMouseButton Button, TShiftState Shift, int X, int Y)
{
        btnPosStopClick(Sender);
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

        for(lCount = 0; lCount < MAX_MULTI_MOVE_AXIS; lCount++){
		if(m_chkMoveMultiAxes[lCount]->Checked)
		{
			//++ 지정한 축의 지령(Command)위치를 반환합니다.
			AxmStatusGetCmdPos(m_lMoveMultiAxes[lArrayIndex], &dCmdPos);
			if(m_dOldCmdPos[lCount] != dCmdPos){
								m_stcCmdPos[lCount]->Text = m_stcCmdPos[lCount]->Text.Format("%.3f", ARRAYOFCONST((dCmdPos)));
				m_dOldCmdPos[lCount] = dCmdPos;
			}

			//++ 지정한 축의 실제(Feedback)위치를 반환합니다.
			AxmStatusGetActPos(m_lMoveMultiAxes[lArrayIndex], &dActPos);
			if(m_dOldActPos[lCount] != dActPos){
								m_stcActPos[lCount]->Text = m_stcActPos[lCount]->Text.Format("%.3f", ARRAYOFCONST((dActPos)));
				m_dOldActPos[lCount] = dActPos;
			}

			//++ 지정한 축의 구동 속도를 반환합니다.
			AxmStatusReadVel(m_lMoveMultiAxes[lArrayIndex], &dCmdVel);
			if(m_dOldCmdVel[lCount] != dCmdVel){
								m_stcCmdVel[lCount]->Text = m_stcCmdVel[lCount]->Text.Format("%.3f", ARRAYOFCONST((dCmdVel)));
				m_dOldCmdVel[lCount] = dCmdVel;
			}

			++lArrayIndex;
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

	BOOL	bSelectCheck, bEmptyCheck, bAllCheck;
	String	strData;
	DWORD	dwOnOff = 0;
	long	lCount;
	long	lBoardNo = 0, lModulePos = 0, lFirstAxisNo = 0;

	//++ 지정한 축의 정보를 반환합니다.
	// [INFO] 여러개의 정보를 읽는 함수 사용시 불필요한 정보는 NULL(0)을 입력하면 됩니다.
	AxmInfoGetAxis(m_lAxisNo, &lBoardNo, &lModulePos, NULL);	
	//++ 지정한 보드/모듈의 첫번째 축 번호를 반환합니다.
	AxmInfoGetFirstAxisNo(lBoardNo, lModulePos, &lFirstAxisNo);

	m_lMoveMultiAxesCount	= 0;
	bSelectCheck		= FALSE;
	bEmptyCheck		= FALSE;
	for(lCount = 0; lCount < MAX_MULTI_MOVE_AXIS; lCount++){
		//++ 지정한 축이 제어가 가능한 상태인지 반환합니다.
		if(AxmInfoGetAxisStatus(lFirstAxisNo) == AXT_RT_SUCCESS){
			strData = strData.Format("Axis %.2d", ARRAYOFCONST(((int)lFirstAxisNo)));

			m_chkMoveMultiAxes[lCount]->Enabled = true;

			bSelectCheck	= m_chkMoveMultiAxes[lCount]->Checked;
			bEmptyCheck	|= bSelectCheck;

			if(bSelectCheck == TRUE){
				m_lMoveMultiAxes[m_lMoveMultiAxesCount++] = lFirstAxisNo;
			}

                        m_edtMovePos[lCount]->Enabled = bSelectCheck;
                        m_edtMoveVel[lCount]->Enabled = bSelectCheck;
                        m_edtMoveAcc[lCount]->Enabled = bSelectCheck;
                        m_edtMoveDec[lCount]->Enabled = bSelectCheck;

                        m_edtJogVel[lCount]->Enabled = bSelectCheck;
                        m_edtJogAcc[lCount]->Enabled = bSelectCheck;
                        m_edtJogDec[lCount]->Enabled = bSelectCheck;

                        m_edtLinePos[lCount]->Enabled = bSelectCheck;
		}else{
			m_lMoveMultiAxes[lCount] = -1;
			strData = "Axis --";

						m_chkMoveMultiAxes[lCount]->Enabled = false;
                        m_chkMoveMultiAxes[lCount]->Checked = false;

                        m_edtMovePos[lCount]->Enabled = false;
                        m_edtMoveVel[lCount]->Enabled = false;
                        m_edtMoveAcc[lCount]->Enabled = false;
                        m_edtMoveDec[lCount]->Enabled = false;

                        m_edtJogVel[lCount]->Enabled = false;
                        m_edtJogAcc[lCount]->Enabled = false;
                        m_edtJogDec[lCount]->Enabled = false;

                        m_edtLinePos[lCount]->Enabled = false;
		}

		lFirstAxisNo++;
                m_chkMoveMultiAxes[lCount]->Caption = strData;
	}

        edtLineVel->Enabled = bEmptyCheck;
        edtLineAcc->Enabled = bEmptyCheck;
        edtLineDec->Enabled = bEmptyCheck;

        btnJogN->Enabled = bEmptyCheck;
        btnJogP->Enabled = bEmptyCheck;

        btnLineN->Enabled = bEmptyCheck;
        btnLineP->Enabled = bEmptyCheck;

        btnPosMove->Enabled = bEmptyCheck;
        btnPosStop->Enabled = bEmptyCheck;

        btnPosClear->Enabled = bEmptyCheck;
        chkMoveBlock->Enabled = bEmptyCheck;
        chkServoOn->Enabled = bEmptyCheck;

	bAllCheck = FALSE;
	for(lCount = 0; lCount < m_lMoveMultiAxesCount; lCount++){		
		//++ 지정한 축의 서보온 상태를 반환합니다.
		AxmSignalIsServoOn(m_lMoveMultiAxes[lCount], &dwOnOff);
		// 선택된 보간축들이 모두 서보온 되어있을 때 TRUE 
		bAllCheck &= dwOnOff;
	}	

        chkServoOn->Checked = bAllCheck;

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

