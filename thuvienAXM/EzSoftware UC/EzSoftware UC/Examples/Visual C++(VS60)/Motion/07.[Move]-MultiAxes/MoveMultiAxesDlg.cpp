// MoveMultiAxesDlg.cpp : implementation file
//
// **************************************************************************
// >> [일자]: 2016.01.05
// >> [개요]: 이 예제는 다축구동 함수들의 사용법을 익히고 각 함수들의 인자값을 
//    변경하면서 구동해 보는 예제입니다.
// >> [중요]: 다축 구동함수들로 구동중 포함된 축중 한축만 정지해도 다른축들이
//    구동을 정지하게 됩니다.
// >> [중요]: 일정한 거리 비율을 유지하는 다축조그 구동방법
//     1) AxmMoveStartLineVel 함수의 dDis값에 각 축의 거리 비율을 설정합니다.
//     2) dDis[4] = {10.0, 20.0, 30.0, 40.0}으로 설정하였을 경우 0축이 10.0에
//        도달했을 때 1, 2, 3축은 20.0, 30.0, 40.0의 위치에 도달하게 됩니다.
// **************************************************************************

#include "stdafx.h"
#include "math.h"
#include "MoveMultiAxes.h"
#include "MoveMultiAxesDlg.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

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
#ifdef  _M_X64
#pragma comment(lib, "../../../../AXL(Library)/Library/64Bit/AxL.lib")
#else
#pragma comment(lib, "../../../../AXL(Library)/Library/32Bit/AxL.lib")
#endif

#define	TM_DISPLAY		100

/////////////////////////////////////////////////////////////////////////////
// CMoveMultiAxesDlg dialog

CMoveMultiAxesDlg::CMoveMultiAxesDlg(CWnd* pParent /*=NULL*/)
	: CDialog(CMoveMultiAxesDlg::IDD, pParent)
{
	//{{AFX_DATA_INIT(CMoveMultiAxesDlg)
	//}}AFX_DATA_INIT
	// Note that LoadIcon does not require a subsequent DestroyIcon in Win32
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);

	//++
	m_lAxisNo		= -1;		// 제어할 축 번호 초기화
	m_lAxisCount	= 0;		// 제어 가능한 축갯수 초기화
	m_dwModuleID	= 0;		// 제어할 축의 모듈ID 초기화	

	memset(m_lMoveMultiAxes, -1, sizeof(m_lMoveMultiAxes));
}

void CMoveMultiAxesDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CMoveMultiAxesDlg)
	DDX_Control(pDX, IDC_CHK_SERVO_ON, m_chkServoOn);
	DDX_Control(pDX, IDC_CHK_MOVE_BLOCK, m_chkMoveBlock);
	DDX_Control(pDX, IDC_BTN_LINE_P, m_btnLineP);
	DDX_Control(pDX, IDC_BTN_LINE_N, m_btnLineN);
	DDX_Control(pDX, IDC_BTN_JOG_P, m_btnJogP);
	DDX_Control(pDX, IDC_BTN_JOG_N, m_btnJogN);
	DDX_Control(pDX, IDC_BTN_POS_STOP, m_btnPosStop);
	DDX_Control(pDX, IDC_BTN_POS_MOVE, m_btnPosMove);
	DDX_Control(pDX, IDC_BTN_POS_CLEAR, m_btnPosClear);
	DDX_Control(pDX, IDC_CBO_SEL_AXIS, m_cboSelAxis);
	//}}AFX_DATA_MAP
}

BEGIN_MESSAGE_MAP(CMoveMultiAxesDlg, CDialog)
	//{{AFX_MSG_MAP(CMoveMultiAxesDlg)
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	ON_CBN_SELCHANGE(IDC_CBO_SEL_AXIS, OnSelchangeCboSelAxis)
	ON_WM_TIMER()
	ON_BN_CLICKED(IDC_BTN_POS_CLEAR, OnBtnPosClear)
	ON_BN_CLICKED(IDC_CHK_SERVO_ON, OnChkServoOn)
	ON_BN_CLICKED(IDC_BTN_POS_MOVE, OnBtnPosMove)
	ON_BN_CLICKED(IDC_BTN_POS_STOP, OnBtnPosStop)
	ON_WM_DESTROY()
	ON_BN_CLICKED(IDC_BTN_LOAD_FILE, OnBtnLoadFile)
	//}}AFX_MSG_MAP
	ON_MESSAGE(UM_JOG_BTN_DN, OnJogBtnDn)
	ON_MESSAGE(UM_JOG_BTN_UP, OnJogBtnUp)
	ON_COMMAND_RANGE(IDC_CHK_AXIS_00, IDC_CHK_AXIS_03, OnChkAxis)

END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CMoveMultiAxesDlg message handlers

BOOL CMoveMultiAxesDlg::OnInitDialog()
{
	CDialog::OnInitDialog();

	// Set the icon for this dialog.  The framework does this automatically
	//  when the application's main window is not a dialog
	SetIcon(m_hIcon, TRUE);			// Set big icon
	SetIcon(m_hIcon, FALSE);		// Set small icon
	
	//++
	InitLibrary();					// 라이브러리 초기화 및 Mot파일을 불러옵니다.
	AddAxisInfo();					// 검색된 축 정보를 ComboBox에 등록/Control들을 초기화합니다.
	UpdateState();					// 모션보드의 상태와 Control들의 상태를 일치시킵니다.
	
	return TRUE;  // return TRUE  unless you set the focus to a control
}

// If you add a minimize button to your dialog, you will need the code below
//  to draw the icon.  For MFC applications using the document/view model,
//  this is automatically done for you by the framework.

void CMoveMultiAxesDlg::OnPaint() 
{
	if (IsIconic())
	{
		CPaintDC dc(this); // device context for painting

		SendMessage(WM_ICONERASEBKGND, (WPARAM) dc.GetSafeHdc(), 0);

		// Center icon in client rectangle
		int cxIcon = GetSystemMetrics(SM_CXICON);
		int cyIcon = GetSystemMetrics(SM_CYICON);
		CRect rect;
		GetClientRect(&rect);
		int x = (rect.Width() - cxIcon + 1) / 2;
		int y = (rect.Height() - cyIcon + 1) / 2;

		// Draw the icon
		dc.DrawIcon(x, y, m_hIcon);
	}
	else
	{
		CDialog::OnPaint();
	}
}

// The system calls this to obtain the cursor to display while the user drags
//  the minimized window.
HCURSOR CMoveMultiAxesDlg::OnQueryDragIcon()
{
	return (HCURSOR) m_hIcon;
}

void CMoveMultiAxesDlg::OnDestroy() 
{
	CDialog::OnDestroy();
	
	//++ AXL 사용을 종료합니다.
	AxlClose();	
}

// **************************************************************************
// >> [구분]: Control에 이벤트가 발생했을 때 처리하는 함수들 모음 
// **************************************************************************

// ++ =======================================================================
// >> OnSelchangeCboSelAxis() : 축 번호 변경시 호출되는 핸들러 함수.
//  - 축 번호가 변경되었을 때 변경된 축의 모듈 ID와 Control들을 갱신합니다.
// --------------------------------------------------------------------------
void CMoveMultiAxesDlg::OnSelchangeCboSelAxis() 
{
	m_lAxisNo = m_cboSelAxis.GetCurSel();		// 축 선택 ComboBox에서 선택된 축번호를 제어할 축 번호 변수에 설정합니다.	

	//++ 지정한 축번호의 모듈ID를 반환합니다.
	// [INFO] 여러개의 정보를 읽는 함수 사용시 불필요한 정보는 NULL(0)을 입력하면 됩니다.
	AxmInfoGetAxis(m_lAxisNo, NULL, NULL, &m_dwModuleID);
	
	UpdateState();		// 변경한 축의 상태와 Control들의 상태를 일치시킵니다.	
}

// ++ =======================================================================
// >> OnBtnLoadFile() : "Load File"버튼 클릭시 호출되는 핸들러 함수.
//  - 임의 위치에 있는 Mot(AXM에서 사용하는 설정파일 형식) 파일을 불러옵니다.
//  - 이 함수를 통해 임의의 Mot파일을 불러오면 모션축의 설정값들이 Mot파일의 
//    설정값들로 일괄 변경됩니다.
// --------------------------------------------------------------------------
void CMoveMultiAxesDlg::OnBtnLoadFile() 
{
	CString	temp;
	CFileDialog dlg(TRUE, "Mot", NULL, OFN_HIDEREADONLY, "AXM File (*.mot)|*.mot|All Files (*.*)|*.*||");
	
	if (dlg.DoModal() == IDOK){
		LPTSTR nFilename;
		temp		= dlg.GetPathName();
		nFilename	= temp.GetBuffer(0);

		//++ 함수 실행 성공시 지정한 Mot파일의 설정값으로 모션축 설정이 일괄 변경됩니다.
		if (AxmMotLoadParaAll(nFilename) != AXT_RT_SUCCESS)
			AfxMessageBox("File load fail!");		
		else
			UpdateState();		// 변경된 모션축의 상태와 Control들의 상태를 일치시킵니다.
	}		
}

// ++ =======================================================================
// >> OnChkAxis(...) : 축 변경이 있을 때 호출되는 핸들러 함수. 
//  - 축 번호 선택 체크버튼의 체크상태에 변화가 있을 때 보간 사용축 갯수 및 축
//    번호 배열값을 재할당합니다.
//  - IDC_CHK_AXIS_00 ~ IDC_CHK_AXIS_03 버튼의 클릭이벤트 발생시 호출됩니다.
// --------------------------------------------------------------------------
void CMoveMultiAxesDlg::OnChkAxis(UINT nID) 
{
	// 변경된 모션축의 상태와 Control들의 상태를 일치시킵니다.
	UpdateState();	
}

// ++ =======================================================================
// >> OnBtnPosClear() : "Clear"버튼 클릭시 호출되는 핸들러 함수.
//  - 선택된 축의 위치정보를 0.0으로 설정합니다.
//  - AxmStatusSetPosMatch함수는 AxmStatusSetCmdPos, AxmStatusSetActPos 함수를 
//    사용하는것과 동일한 효과를 냅니다.
// --------------------------------------------------------------------------
void CMoveMultiAxesDlg::OnBtnPosClear() 
{
	long lCount;
	for(lCount = 0; lCount < m_lMoveMultiAxesCount; lCount++){
		//++ Command위치와 Actual위치를 지정한 값으로 설정합니다.
		AxmStatusSetPosMatch(m_lMoveMultiAxes[lCount], 0.0);
	}
}

// ++ =======================================================================
// >> OnChkServoOn() : "Servo On"버튼 클릭시 호출되는 핸들러 함수.
//  - 선택된 보간축들을 체크버튼의 상태에 따라 서보 On/Off 합니다.
// --------------------------------------------------------------------------
void CMoveMultiAxesDlg::OnChkServoOn() 
{
	long lCount;
	for(lCount = 0; lCount < m_lMoveMultiAxesCount; lCount++){
		AxmSignalServoOn(m_lMoveMultiAxes[lCount], m_chkServoOn.GetCheck());
	}	
}

// ++ =======================================================================
// >> OnBtnPosMove() : "Move"버튼 클릭시 호출되는 핸들러 함수.
//  - 선택한 축들을 지정한 거리(또는 위치)/속도/가속도/감속도로 모션구동합니다.
// --------------------------------------------------------------------------
void CMoveMultiAxesDlg::OnBtnPosMove() 
{
	CString strData;
	DWORD	dwRetCode;
	long	lCount, lArrayIndex;
	double	dMultiPos[MAX_MULTI_MOVE_AXIS], dMultiVel[MAX_MULTI_MOVE_AXIS], dMultiAcc[MAX_MULTI_MOVE_AXIS], dMultiDec[MAX_MULTI_MOVE_AXIS];
	
	lArrayIndex = 0;
	for(lCount = 0; lCount < MAX_MULTI_MOVE_AXIS; lCount++){
		if(m_chkMoveMultiAxes[lCount].GetCheck()){
			dMultiPos[lArrayIndex] = GetDlgItemDouble(IDC_EDT_MOVE_POS_00 + lCount);
			dMultiVel[lArrayIndex] = GetDlgItemDouble(IDC_EDT_MOVE_VEL_00 + lCount);
			dMultiAcc[lArrayIndex] = GetDlgItemDouble(IDC_EDT_MOVE_ACC_00 + lCount);
			dMultiDec[lArrayIndex] = GetDlgItemDouble(IDC_EDT_MOVE_DEC_00 + lCount);
			++lArrayIndex;
		}
	}

	if(m_chkMoveBlock.GetCheck()){
		//++ 지정한 축들을 지정한 거리(또는 위치)/속도/가속도/감속도로 각각 모션구동하고 모션이 종료되면 함수를 빠져나옵니다.
		dwRetCode = AxmMoveMultiPos(m_lMoveMultiAxesCount, m_lMoveMultiAxes, dMultiPos, dMultiVel, dMultiAcc, dMultiDec);
		if(dwRetCode != AXT_RT_SUCCESS){
			strData.Format("AxmMoveMultiPos return error[Code:%04d]", dwRetCode);
			MessageBox(strData, "Error", MB_OK | MB_ICONERROR);
		}
	}else{
		//++ 지정한 축들을 지정한 거리(또는 위치)/속도/가속도/감속도로 각각 모션구동하고 모션 종료여부와 상관없이 함수를 빠져나옵니다.
		dwRetCode = AxmMoveStartMultiPos(m_lMoveMultiAxesCount, m_lMoveMultiAxes, dMultiPos, dMultiVel, dMultiAcc, dMultiDec);
		if(dwRetCode != AXT_RT_SUCCESS){
			strData.Format("AxmMoveStartMultiPos return error[Code:%04d]", dwRetCode);
			MessageBox(strData, "Error", MB_OK | MB_ICONERROR);
		}
	}
}

// ++ =======================================================================
// >> OnBtnPosStop() : "Stop"버튼 클릭시 호출되는 핸들러 함수.
//  - 선택한 축들로 구동정지 함수를 호출하여 구동을 감속정지합니다.
// ※ [CAUTION] 다축 구동함수들로 구동시 포함된 축중 한축만 정지해도 다른축들이 
//    구동을 정지하게 됩니다.
// --------------------------------------------------------------------------
void CMoveMultiAxesDlg::OnBtnPosStop() 
{
	long lCount;
	for(lCount = 0; lCount < m_lMoveMultiAxesCount; lCount++){
		//++ 지정한 축의 구동을 감속정지합니다.
		AxmMoveSStop(m_lMoveMultiAxes[lCount]);
	}		
}

// ++ =======================================================================
// >> OnJogBtnDn(...) : "Jog(+/-)"버튼 Down시 호출되는 핸들러 함수.
//  - "CJogButton" 버튼 클래스에서 버튼 클릭시 호출되는 WM_LBUTTONDOWN 이벤트를 
//    받아 사용자 이벤트로 이 함수를 호출해 줍니다. 이 때 wParam을 통해 전달되는
//    콘트롤 ID로 Jog(+/-)버튼을 구분하게 됩니다.
//  - Jog버튼 Down시 다축구동 함수를 호출하여 Jog 구동을 시작합니다.
// --------------------------------------------------------------------------
LRESULT CMoveMultiAxesDlg::OnJogBtnDn(WPARAM wParam, LPARAM lParam)
{
	CString strData;
	DWORD	dwRetCode;
	long	lCount, lArrayIndex;
	double	dLineVel, dLineAcc, dLineDec;
	double	dLinePos[MAX_MULTI_MOVE_AXIS], dMultiVel[MAX_MULTI_MOVE_AXIS], dMultiAcc[MAX_MULTI_MOVE_AXIS], dMultiDec[MAX_MULTI_MOVE_AXIS];
	
	if((wParam == IDC_BTN_JOG_P) || (wParam == IDC_BTN_JOG_N)){
		
		lArrayIndex = 0;
		for(lCount = 0; lCount < MAX_MULTI_MOVE_AXIS; lCount++){
			if(m_chkMoveMultiAxes[lCount].GetCheck()){				
				if(wParam == IDC_BTN_JOG_P)
					dMultiVel[lArrayIndex] = fabs(GetDlgItemDouble(IDC_EDT_JOG_VEL_00 + lCount));
				else
					dMultiVel[lArrayIndex] = -fabs(GetDlgItemDouble(IDC_EDT_JOG_VEL_00 + lCount));
				
				dMultiAcc[lArrayIndex] = fabs(GetDlgItemDouble(IDC_EDT_JOG_ACC_00 + lCount));
				dMultiDec[lArrayIndex] = fabs(GetDlgItemDouble(IDC_EDT_JOG_DEC_00 + lCount));
				++lArrayIndex;
			}
		}		
		
		//++ 선택한 축들을 (+/-)방향으로 지정한 속도/가속도/감속도로 모션구동합니다.
		dwRetCode = AxmMoveStartMultiVel(m_lMoveMultiAxesCount, m_lMoveMultiAxes, dMultiVel, dMultiAcc, dMultiDec);
		if(dwRetCode != AXT_RT_SUCCESS){
			strData.Format("AxmMoveStartMultiPos return error[Code:%04d]", dwRetCode);
			MessageBox(strData, "Error", MB_OK | MB_ICONERROR);
		}
	}else if((wParam == IDC_BTN_LINE_P) || (wParam == IDC_BTN_LINE_N)){
		
		lArrayIndex = 0;
		for(lCount = 0; lCount < MAX_MULTI_MOVE_AXIS; lCount++){
			if(m_chkMoveMultiAxes[lCount].GetCheck()){				
				if(wParam == IDC_BTN_LINE_P)
					dLinePos[lArrayIndex] = fabs(GetDlgItemDouble(IDC_EDT_LINE_POS_00 + lCount));
				else
					dLinePos[lArrayIndex] = -fabs(GetDlgItemDouble(IDC_EDT_LINE_POS_00 + lCount));
				
				++lArrayIndex;
			}
		}
		
		dLineVel = fabs(GetDlgItemDouble(IDC_EDT_LINE_VEL));
		dLineAcc = fabs(GetDlgItemDouble(IDC_EDT_LINE_ACC));
		dLineDec = fabs(GetDlgItemDouble(IDC_EDT_LINE_DEC));
		
		//++ 선택한 축들을 (+/-)방향으로 지정한 위치 비율에따른 속도/가속도/감속도로 모션구동합니다.
		dwRetCode = AxmMoveStartLineVel(m_lMoveMultiAxesCount, m_lMoveMultiAxes, dLinePos, dLineVel, dLineAcc, dLineDec);
		if(dwRetCode != AXT_RT_SUCCESS){
			strData.Format("AxmMoveStartMultiPos return error[Code:%04d]", dwRetCode);
			MessageBox(strData, "Error", MB_OK | MB_ICONERROR);
		}
	}	
	
	return 0;
}

// ++ =======================================================================
// >> OnJogBtnUp(...) : "Jog(+/-)"버튼 Up시 호출되는 핸들러 함수.
//  - "CJogButton" 버튼 클래스에서 버튼 클릭시 호출되는 WM_LBUTTONUP이벤트를 
//    받아 사용자 이벤트로 이 함수를 호출해 줍니다. 이 때 wParam을 통해 전달되는
//    콘트롤 ID로 Jog(+/-)버튼을 구분하게 됩니다.
//  - Jog버튼 Up시 구동정지 함수를 호출하여 Jog 구동을 종료합니다.
// --------------------------------------------------------------------------
LRESULT CMoveMultiAxesDlg::OnJogBtnUp(WPARAM wParam, LPARAM lParam)
{
	OnBtnPosStop();
	
	return 0;
}

// ++ =======================================================================
// >> OnTimer(...) : 타이머 이벤트 핸들러 함수.
//  - 일정한 주기로 변경되는 위치/속도/정보등을 Control에 반영합니다.
// --------------------------------------------------------------------------
void CMoveMultiAxesDlg::OnTimer(UINT nIDEvent) 
{
	long	lCount, lArrayIndex = 0;
	double	dCmdPos, dActPos, dCmdVel;

	switch(nIDEvent){
	case TM_DISPLAY:
		for(lCount = 0; lCount < MAX_MULTI_MOVE_AXIS; lCount++){
			if(m_chkMoveMultiAxes[lCount].GetCheck())
			{
				//++ 지정한 축의 지령(Command)위치를 반환합니다.
				AxmStatusGetCmdPos(m_lMoveMultiAxes[lArrayIndex], &dCmdPos);
				if(m_dOldCmdPos[lCount] != dCmdPos){
					SetDlgItemDouble(IDC_STC_CMD_POS_00 + lCount, dCmdPos);
					m_dOldCmdPos[lCount] = dCmdPos;
				}

				//++ 지정한 축의 실제(Feedback)위치를 반환합니다.
				AxmStatusGetActPos(m_lMoveMultiAxes[lArrayIndex], &dActPos);
				if(m_dOldActPos[lCount] != dActPos){
					SetDlgItemDouble(IDC_STC_ACT_POS_00 + lCount, dActPos);
					m_dOldActPos[lCount] = dActPos;
				}

				//++ 지정한 축의 구동 속도를 반환합니다.
				AxmStatusReadVel(m_lMoveMultiAxes[lArrayIndex], &dCmdVel);
				if(m_dOldCmdVel[lCount] != dCmdVel){
					SetDlgItemDouble(IDC_STC_CMD_VEL_00 + lCount, dCmdVel);
					m_dOldCmdVel[lCount] = dCmdVel;
				}

				++lArrayIndex;
			}
		}
		break;
	}
	CDialog::OnTimer(nIDEvent);
}

// **************************************************************************
// >> [구분]: 별도의 기능을 구현하기위해 만든 사용자 정의 함수들 모음 
// **************************************************************************

// ++ =======================================================================
// >> InitLibrary() : 라이브러리 초기화 및 Mot파일을 불러오는 함수.
//  - AXL(AjineXtek Library)을 사용가능하게 합니다. 
//  - EzConfig 프로그램이 설치되어있는 폴더에서 기본 Mot파일(모션 설정파일)을
//    지정해 모션관련 기본설정을 자동으로 합니다.
// --------------------------------------------------------------------------
BOOL CMoveMultiAxesDlg::InitLibrary()
{
	//++ AXL(AjineXtek Library)을 사용가능하게 하고 장착된 보드들을 초기화합니다.
	if ((AxlOpen(7) != AXT_RT_SUCCESS)){
		AfxMessageBox("AxlOpen Fail...");
		return FALSE;
	}
	
	// ※ [CAUTION] 아래와 다른 Mot파일(모션 설정파일)을 사용할 경우 경로를 변경하십시요.
	char szFilePath[] = "..\\..\\..\\..\\EzSoftware\\MotionDefault.mot";
	
	//++ 지정한 Mot파일의 설정값들로 모션보드의 설정값들을 일괄변경 적용합니다.
	if(AxmMotLoadParaAll(szFilePath) != AXT_RT_SUCCESS){
		AfxMessageBox("Mot File Not Found.");
	}	
	return TRUE;
}

// ++ =======================================================================
// >> AddAxisInfo() : 시스템에 장착된 모션축들을 ComboBox에 등록하는 함수.
//  - AXL Open시 검색된 축들의 정보를 읽어 ComboBox에 등록하여 사용자가 선택
//    제어할 수 있도록 합니다.
//  - 유효한 축이 검색되었을 때 Control들을 초기화 하고, 정보 갱신용 타이머를 
//    100msec 주기로 동작시킵니다.
// --------------------------------------------------------------------------
BOOL CMoveMultiAxesDlg::AddAxisInfo()
{
	CString	strData;
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
		case AXT_SMC_4V04:			strData.Format("%02ld-[PCIB-QI4A]",i);		break;
		case AXT_SMC_2V04:			strData.Format("%02ld-[PCIB-QI2A]",i);		break;
		case AXT_SMC_R1V04A4:		strData.Format("%02ld-[RTEX-A4N]", i);		break;
		case AXT_SMC_R1V04A5:		strData.Format("%02ld-[RTEX-A5N]", i);		break;
		case AXT_SMC_R1V04:			strData.Format("%02ld-[RTEX-PM]", i);		break;
		case AXT_SMC_R1V04PM2Q:		strData.Format("%02ld-[RTEX-PM2Q]", i);		break;
		case AXT_SMC_R1V04PM2QE:	strData.Format("%02ld-[RTEX-PM2QE]", i);	break;
		case AXT_SMC_R1V04MLIISV:	strData.Format("%02ld-[MLII-SGDV]", i);		break;
		case AXT_SMC_R1V04MLIIPM:	strData.Format("%02ld-[MLII-PM]", i);		break;
		case AXT_SMC_R1V04MLIICL:	strData.Format("%02ld-[MLII-CSDL]", i);		break;
		case AXT_SMC_R1V04MLIICR:	strData.Format("%02ld-[MLII-CSDH]", i);		break;
		case AXT_SMC_R1V04SIIIHMIV:	strData.Format("%02ld-[SIIIH-MRJ4]", i);	break;
		case AXT_ECAT_MOTION:		
			{
				char szModuleName[50];
				AxmInfoGetAxisEx(i, NULL, szModuleName, NULL);
				strData.Format("%02ld-[ECAT-%s]", i, szModuleName);	
				break;
			}
		default:					strData.Format("%02ld-[Unknown]",i);
		}
		
		m_cboSelAxis.AddString(strData);
	}
		
	InitControl();						// Control 변수들을 등록하고, 초기 설정값들을 설정합니다.

	SetTimer(TM_DISPLAY, 100, NULL);	// 일정한 주기로 변경되는 위치/속도/정보등을 Control에 반영할 타이머를 실행합니다.	
	return TRUE;
}

// ++ =======================================================================
// >> InitControl() : Control들에 초기값을 설정하는 함수.
//  - Control 변수들을 등록하고, 초기 설정값들을 설정합니다.
// --------------------------------------------------------------------------
BOOL CMoveMultiAxesDlg::InitControl()
{
	m_cboSelAxis.SetCurSel(m_lAxisNo);
	
	long	lCount;
	for(lCount = 0; lCount < MAX_MULTI_MOVE_AXIS; lCount++){		
		m_chkMoveMultiAxes[lCount].SubclassDlgItem(IDC_CHK_AXIS_00 + lCount, this); 

		m_edtMovePos[lCount].SubclassDlgItem(IDC_EDT_MOVE_POS_00 + lCount, this); 
		m_edtMovePos[lCount].SetWindowText("100.000");

		m_edtMoveVel[lCount].SubclassDlgItem(IDC_EDT_MOVE_VEL_00 + lCount, this); 
		m_edtMoveVel[lCount].SetWindowText("100.000");

		m_edtMoveAcc[lCount].SubclassDlgItem(IDC_EDT_MOVE_ACC_00 + lCount, this); 
		m_edtMoveAcc[lCount].SetWindowText("400.000");

		m_edtMoveDec[lCount].SubclassDlgItem(IDC_EDT_MOVE_DEC_00 + lCount, this); 
		m_edtMoveDec[lCount].SetWindowText("400.000");

		m_edtJogVel[lCount].SubclassDlgItem(IDC_EDT_JOG_VEL_00 + lCount, this); 
		m_edtJogVel[lCount].SetWindowText("100.000");

		m_edtJogAcc[lCount].SubclassDlgItem(IDC_EDT_JOG_ACC_00 + lCount, this); 
		m_edtJogAcc[lCount].SetWindowText("400.000");

		m_edtJogDec[lCount].SubclassDlgItem(IDC_EDT_JOG_DEC_00 + lCount, this); 		
		m_edtJogDec[lCount].SetWindowText("400.000");

		m_edtLinePos[lCount].SubclassDlgItem(IDC_EDT_LINE_POS_00 + lCount, this); 
		m_edtLinePos[lCount].SetWindowText("100.000");
	}	

	// Edit Control에 초기값 설정
	m_edtLineVel.SubclassDlgItem(IDC_EDT_LINE_VEL, this); 
	m_edtLineVel.SetWindowText("100.000");

	m_edtLineAcc.SubclassDlgItem(IDC_EDT_LINE_ACC, this); 
	m_edtLineAcc.SetWindowText("400.000");

	m_edtLineDec.SubclassDlgItem(IDC_EDT_LINE_DEC, this); 
	m_edtLineDec.SetWindowText("200.000");

	return TRUE;
}

// ++ =======================================================================
// >> UpdateState() : 지정한 축의 설정값들을 읽어 Control과 일치시키는 함수.
//  - 축번호가 변경되었을 때 변경한 축의 설정값들과 Control들과 일치시키는 
//    역할을하는 함수입니다.
//  - 지정한 축의 모델별 제약들을 Control에 반영하는 역할을 합니다.
//  - 프로그램 초기 실행시, Mot파일 불러올 때, 축 번호 바뀔 때 사용됩니다.
// --------------------------------------------------------------------------
BOOL CMoveMultiAxesDlg::UpdateState()
{
	if(m_lAxisCount < 1)	return FALSE;

	BOOL	bSelectCheck, bEmptyCheck, bAllCheck;
	CString	strData;
	DWORD	dwOnOff = 0;
	long	lCount, lTotalCount = 0;
	long	lBoardNo = 0, lModulePos = 0, lFirstAxisNo = 0;
	
	//++ 지정한 축의 정보를 반환합니다.
	// [INFO] 여러개의 정보를 읽는 함수 사용시 불필요한 정보는 NULL(0)을 입력하면 됩니다.
	AxmInfoGetAxis(m_lAxisNo, &lBoardNo, &lModulePos, NULL);	
	//++ 지정한 보드/모듈의 첫번째 축 번호를 반환합니다.
	AxmInfoGetFirstAxisNo(lBoardNo, lModulePos, &lFirstAxisNo);
	
	m_lMoveMultiAxesCount	= 0;
	bSelectCheck		= FALSE;
	bEmptyCheck			= FALSE;
	for(lCount = 0; lCount < MAX_MULTI_MOVE_AXIS; lCount++){		
		//++ 지정한 축이 제어가 가능한 상태인지 반환합니다.
		if(AxmInfoGetAxisStatus(lFirstAxisNo) == AXT_RT_SUCCESS){
			strData.Format("Axis %02d", lFirstAxisNo);

			m_chkMoveMultiAxes[lCount].EnableWindow(TRUE);

			bSelectCheck	= m_chkMoveMultiAxes[lCount].GetCheck();
			bEmptyCheck		|= bSelectCheck;

			if(bSelectCheck == TRUE){
				m_lMoveMultiAxes[m_lMoveMultiAxesCount++] = lFirstAxisNo; 
			}
			
			m_edtMovePos[lCount].EnableWindow(bSelectCheck);
			m_edtMoveVel[lCount].EnableWindow(bSelectCheck);
			m_edtMoveAcc[lCount].EnableWindow(bSelectCheck);
			m_edtMoveDec[lCount].EnableWindow(bSelectCheck);

			m_edtJogVel[lCount].EnableWindow(bSelectCheck);
			m_edtJogAcc[lCount].EnableWindow(bSelectCheck);
			m_edtJogDec[lCount].EnableWindow(bSelectCheck);
	
			m_edtLinePos[lCount].EnableWindow(bSelectCheck);
		}else{
			m_lMoveMultiAxes[lCount] = -1; 
			strData.Format("Axis --");

			m_chkMoveMultiAxes[lCount].EnableWindow(FALSE);
			m_chkMoveMultiAxes[lCount].SetCheck(FALSE);

			m_edtMovePos[lCount].EnableWindow(FALSE);
			m_edtMoveVel[lCount].EnableWindow(FALSE);
			m_edtMoveAcc[lCount].EnableWindow(FALSE);
			m_edtMoveDec[lCount].EnableWindow(FALSE);

			m_edtJogVel[lCount].EnableWindow(FALSE);
			m_edtJogAcc[lCount].EnableWindow(FALSE);
			m_edtJogDec[lCount].EnableWindow(FALSE);
			
			m_edtLinePos[lCount].EnableWindow(FALSE);
		}

		lFirstAxisNo++;
		m_chkMoveMultiAxes[lCount].SetWindowText(strData);
	}

	m_edtLineAcc.EnableWindow(bEmptyCheck);
	m_edtLineDec.EnableWindow(bEmptyCheck);

	m_edtLineVel.EnableWindow(bEmptyCheck);
	m_edtLineAcc.EnableWindow(bEmptyCheck);
	m_edtLineDec.EnableWindow(bEmptyCheck);

	m_btnJogN.EnableWindow(bEmptyCheck);
	m_btnJogP.EnableWindow(bEmptyCheck);

	m_btnLineN.EnableWindow(bEmptyCheck);
	m_btnLineP.EnableWindow(bEmptyCheck);

	m_btnPosMove.EnableWindow(bEmptyCheck);
	m_btnPosStop.EnableWindow(bEmptyCheck);

	m_btnPosClear.EnableWindow(bEmptyCheck);
	m_chkMoveBlock.EnableWindow(bEmptyCheck);
	m_chkServoOn.EnableWindow(bEmptyCheck);

	bAllCheck = FALSE;
	for(lCount = 0; lCount < m_lMoveMultiAxesCount; lCount++){		
		//++ 지정한 축의 서보온 상태를 반환합니다.
		AxmSignalIsServoOn(m_lMoveMultiAxes[lCount], &dwOnOff);
		// 선택된 보간축들이 모두 서보온 되어있을 때 TRUE 
		bAllCheck &= dwOnOff;
	}	

	m_chkServoOn.SetCheck(bAllCheck);
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
DWORD CMoveMultiAxesDlg::ConvertComboToAxm(CComboBox *pCboItem)
{
	if(pCboItem == NULL)	return 0;
	
	CString strText;
	long	lCount, lSelData;	
	
	lCount = pCboItem->GetCount();
	if(lCount == 0)		return 0;
	
	lSelData = pCboItem->GetCurSel();
	if(lSelData < 0)	return 0;
	
	pCboItem->GetLBText(lSelData, strText);	
	return (DWORD)atoi(strText);
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
long CMoveMultiAxesDlg::ConvertAxmToCombo(CComboBox *pCboItem, DWORD dwCurData)
{
	if(pCboItem == NULL)	return 0;
	
	long	lCount, lSelData;
	CString strText;
	
	lCount = pCboItem->GetCount();
	if(lCount == 0)	return 0;
	
	for(int i = 0; i < lCount; i++){
		pCboItem->GetLBText(i, strText);
		lSelData = atoi(strText);
		if(lSelData == (long)dwCurData){	
			pCboItem->SetCurSel(i);
			return i;
		}
	}
	
	pCboItem->SetCurSel(0);
	return 0;
}

// ++ =======================================================================
// >> SetDlgItemDouble(...) : double값을 지정한 콘트롤에 설정하는 함수.
//  - 설정한 콘트롤의 ID와 double값을 입력합니다. 이때 표현 할 소숫점 자릿수를
//    지정할 수 있습니다. (기본은 소숫점 3자리로 지정됨)
//  - Edit, Static 콘트롤에 사용할 수 있으며 double값을 입력하면되므로 코드를
//    간결하게 구현할 수 있습니다.
// --------------------------------------------------------------------------
void CMoveMultiAxesDlg::SetDlgItemDouble(int nID, double value, int nPoint)
{
	CString sTemp, sTemp2;
	sTemp2.Format("%%.%df", nPoint);
	sTemp.Format(sTemp2, value);
	GetDlgItem(nID)->SetWindowText(sTemp);
}

// ++ =======================================================================
// >> GetDlgItemDouble(...) : 지정한 콘트롤에 설정되어 있는 텍스트를 
//    double값으로 변환하여 반환하는 함수.
//  - Edit, Static 콘트롤에 설정된 텍스트를 double값으로 읽어들여 코드를 간결
//    하게 구현할 수 있습니다.
// --------------------------------------------------------------------------
double CMoveMultiAxesDlg::GetDlgItemDouble(int nID)
{
	double dRet;
	CString sTemp;
	GetDlgItem(nID)->GetWindowText(sTemp);
	dRet = atof((LPCTSTR)sTemp);
	return dRet;
}
