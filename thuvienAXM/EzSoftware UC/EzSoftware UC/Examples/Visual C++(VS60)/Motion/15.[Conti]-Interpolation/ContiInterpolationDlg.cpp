// ContiInterpolationDlg.cpp : implementation file
//
// **************************************************************************
// >> [일자]: 2016.01.05
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

#include "stdafx.h"
#include "ContiInterpolation.h"
#include "ContiInterpolationDlg.h"

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

#define COORD_NO		0
#define MAX_SPLINE_NODE	5
#define	TM_DISPLAY		100

/////////////////////////////////////////////////////////////////////////////
// CContiInterpolationDlg dialog

CContiInterpolationDlg::CContiInterpolationDlg(CWnd* pParent /*=NULL*/)
	: CDialog(CContiInterpolationDlg::IDD, pParent)
{
	//{{AFX_DATA_INIT(CContiInterpolationDlg)
		// NOTE: the ClassWizard will add member initialization here
	//}}AFX_DATA_INIT
	// Note that LoadIcon does not require a subsequent DestroyIcon in Win32
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);

	//++
	m_lAxisNo		= -1;	// 제어할 축 번호 초기화 
	m_lAxisCount	= 0;	// 제어 가능한 축갯수 초기화
	m_dwModuleID	= 0;	// 제어할 축의 모듈ID 초기화
}

void CContiInterpolationDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CContiInterpolationDlg)
	DDX_Control(pDX, IDC_BTN_INTP_SPLINE, m_btnIntpSpline);
	DDX_Control(pDX, IDC_BTN_INTP_LINE_ARC, m_btnIntpLineArc);
	DDX_Control(pDX, IDC_BTN_INTP_LINE, m_btnIntpLine);
	DDX_Control(pDX, IDC_BTN_INTP_HELICAL, m_btnIntpHelical);
	DDX_Control(pDX, IDC_BTN_INTP_CIRCLE, m_btnIntpCircle);
	DDX_Control(pDX, IDC_BTN_INTP_ARC, m_btnIntpArc);
	DDX_Control(pDX, IDC_CBO_SEL_AXIS, m_cboSelAxis);
	DDX_Control(pDX, IDC_CHK_SERVO_ON, m_chkServoOn);
	//}}AFX_DATA_MAP
}

BEGIN_MESSAGE_MAP(CContiInterpolationDlg, CDialog)
	//{{AFX_MSG_MAP(CContiInterpolationDlg)
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	ON_CBN_SELCHANGE(IDC_CBO_SEL_AXIS, OnSelchangeCboSelAxis)
	ON_WM_TIMER()
	ON_BN_CLICKED(IDC_BTN_LOAD_FILE, OnBtnLoadFile)
	ON_WM_DESTROY()
	ON_BN_CLICKED(IDC_BTN_POS_CLEAR, OnBtnPosClear)
	ON_BN_CLICKED(IDC_CHK_SERVO_ON, OnChkServoOn)
	ON_BN_CLICKED(IDC_BTN_INTP_STOP, OnBtnIntpStop)
	ON_BN_CLICKED(IDC_BTN_INTP_LINE, OnBtnIntpLine)
	ON_BN_CLICKED(IDC_BTN_INTP_ARC, OnBtnIntpArc)
	ON_BN_CLICKED(IDC_BTN_INTP_CIRCLE, OnBtnIntpCircle)
	ON_BN_CLICKED(IDC_BTN_INTP_LINE_ARC, OnBtnIntpLineArc)
	ON_BN_CLICKED(IDC_BTN_INTP_HELICAL, OnBtnIntpHelical)
	ON_BN_CLICKED(IDC_BTN_INTP_SPLINE, OnBtnIntpSpline)
	ON_BN_CLICKED(IDC_BTN_INTP_START, OnBtnIntpStart)
	ON_BN_CLICKED(IDC_BTN_INTP_CLEAR, OnBtnIntpClear)
	//}}AFX_MSG_MAP
	ON_COMMAND_RANGE(IDC_CHK_AXIS_00, IDC_CHK_AXIS_03, OnChkAxis)
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CContiInterpolationDlg message handlers

BOOL CContiInterpolationDlg::OnInitDialog()
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

void CContiInterpolationDlg::OnPaint() 
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
HCURSOR CContiInterpolationDlg::OnQueryDragIcon()
{
	return (HCURSOR) m_hIcon;
}

void CContiInterpolationDlg::OnDestroy() 
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
void CContiInterpolationDlg::OnSelchangeCboSelAxis() 
{
	m_lAxisNo = m_cboSelAxis.GetCurSel();	// 축 선택 ComboBox에서 선택된 축번호를 제어할 축 번호 변수에 설정합니다.

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
void CContiInterpolationDlg::OnBtnLoadFile() 
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
// >> OnChkAxis(...) : 보간축 변경이 있을 때 호출되는 핸들러 함수. 
//  - 축 번호 선택 체크버튼의 체크상태에 변화가 있을 때 보간 사용축 갯수 및 축
//    번호 배열값을 재할당합니다.
//  - IDC_CHK_AXIS_00 ~ IDC_CHK_AXIS_03 버튼의 클릭이벤트 발생시 호출됩니다.
// --------------------------------------------------------------------------
void CContiInterpolationDlg::OnChkAxis(UINT nID) 
{
	// 변경된 모션축의 상태와 Control들의 상태를 일치시킵니다.
	UpdateState();		
}

// ++ =======================================================================
// >> OnBtnPosClear() : "Clear"버튼 클릭시 호출되는 핸들러 함수.
//  - 선택된 보간축들의 위치정보를 0.0으로 설정합니다.
//  - AxmStatusSetPosMatch함수는 AxmStatusSetCmdPos, AxmStatusSetActPos 함수를 
//    사용하는것과 동일한 효과를 냅니다.
// --------------------------------------------------------------------------
void CContiInterpolationDlg::OnBtnPosClear() 
{
	long lCount;
	for(lCount = 0; lCount < m_lMoveIntpAxesCount; lCount++){
		// AxmStatusSetCmdPos(m_lMoveIntpAxes[lCount], 0.0);
		// AxmStatusSetActPos(m_lMoveIntpAxes[lCount], 0.0);

		//++ Command위치와 Actual위치를 지정한 값으로 설정합니다.
		AxmStatusSetPosMatch(m_lMoveIntpAxes[lCount], 0.0);
	}	
}

// ++ =======================================================================
// >> OnChkServoOn() : "Servo On"버튼 클릭시 호출되는 핸들러 함수.
//  - 선택된 보간축들을 체크버튼의 상태에 따라 서보 On/Off 합니다.
// --------------------------------------------------------------------------
void CContiInterpolationDlg::OnChkServoOn() 
{
	long lCount;
	for(lCount = 0; lCount < m_lMoveIntpAxesCount; lCount++){
		//++ 지정 축의 Servo On/Off 신호를 출력합니다.
		AxmSignalServoOn(m_lMoveIntpAxes[lCount], m_chkServoOn.GetCheck());
	}	
}

// ++ =======================================================================
// >> OnBtnIntpLine() : "Line"버튼 클릭시 호출되는 핸들러 함수.
//  - 선택된 보간축들 중 2축을 이용해 단위 직선보간을 하는 함수입니다.
// --------------------------------------------------------------------------
void CContiInterpolationDlg::OnBtnIntpLine() 
{
	DWORD	dwRetCode;
	double  dMovePos[2];	
	double	dVelocity, dAccel, dDecel;
	
	dVelocity	= GetDlgItemDouble(IDC_EDT_MOVE_VEL);
	dAccel		= GetDlgItemDouble(IDC_EDT_MOVE_ACC);
	dDecel		= GetDlgItemDouble(IDC_EDT_MOVE_DEC);
	
	dMovePos[0]	= 100.0;	// 첫번째 축의 이동할 위치값
	dMovePos[1]	= 200.0;	// 두번째 축의 이동할 위치값
	
	//++ 지정한 좌표계에 연속보간 축들을 맵핑합니다.
	AxmContiSetAxisMap(COORD_NO, 2, m_lMoveIntpAxes);
	//++ 지정한 좌표계에 구동모드을 설정합니다.(절대구동/상대구동)
	AxmContiSetAbsRelMode(COORD_NO, POS_REL_MODE);

	//++ 지정한 좌표계의 축들을 이용해 직선보간구동을 수행합니다.  
	dwRetCode = AxmLineMove(COORD_NO, dMovePos, dVelocity, dAccel, dDecel);	
	if(dwRetCode != AXT_RT_SUCCESS){
		CString strData;
		strData.Format("AxmLineMove return error[Code:%04d]", dwRetCode);
		MessageBox(strData, "Error", MB_OK | MB_ICONERROR);
	}
}

// ++ =======================================================================
// >> OnBtnIntpLine() : "Arc"버튼 클릭시 호출되는 핸들러 함수.
//  - 선택된 보간축들 중 2축을 이용해 단위 Arc보간을 하는 함수입니다.
// --------------------------------------------------------------------------
void CContiInterpolationDlg::OnBtnIntpArc() 
{
	double  dEndPos[2], dRadius;	
	double	dVelocity, dAccel, dDecel;
	DWORD	dwRetCode, dwArcDir, dwShortDis;
	
	dVelocity	= GetDlgItemDouble(IDC_EDT_MOVE_VEL);
	dAccel		= GetDlgItemDouble(IDC_EDT_MOVE_ACC);
	dDecel		= GetDlgItemDouble(IDC_EDT_MOVE_DEC);
	
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
		CString strData;
		strData.Format("AxmCircleRadiusMove return error[Code:%04d]", dwRetCode);
		MessageBox(strData, "Error", MB_OK | MB_ICONERROR);
	}	
}

// ++ =======================================================================
// >> OnBtnIntpLine() : "Circle"버튼 클릭시 호출되는 핸들러 함수.
//  - 선택된 보간축들 중 2축을 이용해 단위 원호보간을 하는 함수입니다.
// --------------------------------------------------------------------------
void CContiInterpolationDlg::OnBtnIntpCircle() 
{
	DWORD	dwRetCode, dwArcDir;
	double  dCenterPos[2], dAngle;	
	double	dVelocity, dAccel, dDecel;
	
	dVelocity	= GetDlgItemDouble(IDC_EDT_MOVE_VEL);
	dAccel		= GetDlgItemDouble(IDC_EDT_MOVE_ACC);
	dDecel		= GetDlgItemDouble(IDC_EDT_MOVE_DEC);
	
	dCenterPos[0]	= 200.0;
	dCenterPos[1]	= 200.0;
	dAngle			= 360.0;	
	dwArcDir		= DIR_CCW;
	
	//++ 지정한 좌표계에 연속보간 축들을 맵핑합니다.
	AxmContiSetAxisMap(COORD_NO, 2, m_lMoveIntpAxes);
	//++ 지정한 좌표계에 구동모드을 설정합니다.(절대구동/상대구동)
	AxmContiSetAbsRelMode(COORD_NO, POS_ABS_MODE);
	
	//++ 지정한 좌표계의 축들 중 특정 2축에, 회전중심과 회전각도를 이용한 원호보간 구동을 수행합니다.  
	dwRetCode = AxmCircleAngleMove(COORD_NO, m_lMoveIntpAxes, dCenterPos, dAngle, dVelocity, dAccel, dDecel, dwArcDir);	
	if(dwRetCode != AXT_RT_SUCCESS){
		CString strData;
		strData.Format("AxmCircleAngleMove return error[Code:%04d]", dwRetCode);
		MessageBox(strData, "Error", MB_OK | MB_ICONERROR);
	}		
}

// ++ =======================================================================
// >> OnBtnIntpLineArc() : "Line & Arc"버튼 클릭시 호출되는 핸들러 함수.
//  - 선택된 보간축들 중 2축을 이용해 연속 직선/원호보간을 하는 함수입니다.
// --------------------------------------------------------------------------
void CContiInterpolationDlg::OnBtnIntpLineArc() 
{
	double  dMovePos[2];
	double  dCenPos[2];	
	double  dEndPos[2];
	double	dVelocity, dAccel, dDecel;
	
	dVelocity	= GetDlgItemDouble(IDC_EDT_MOVE_VEL);
	dAccel		= GetDlgItemDouble(IDC_EDT_MOVE_ACC);
	dDecel		= GetDlgItemDouble(IDC_EDT_MOVE_DEC);
	
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

// ++ =======================================================================
// >> OnBtnIntpHelical() : "Helical"버튼 클릭시 호출되는 핸들러 함수.
//  - 선택된 보간축들 중 4축을 이용해 연속 헬리컬 보간을 하는 함수입니다.
// --------------------------------------------------------------------------
void CContiInterpolationDlg::OnBtnIntpHelical() 
{
	DWORD	dwArcDir;
	double	dVelocity, dAccel, dDecel;
	double  dCenterPosX, dCenterPosY, dEndPosX, dEndPosY, dZPos;
	
	dVelocity	= GetDlgItemDouble(IDC_EDT_MOVE_VEL);
	dAccel		= GetDlgItemDouble(IDC_EDT_MOVE_ACC);
	dDecel		= GetDlgItemDouble(IDC_EDT_MOVE_DEC);
	
	dCenterPosX	= 100.0;	
	dCenterPosY = 100.0;
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

// ++ =======================================================================
// >> OnBtnIntpHelical() : "Spline"버튼 클릭시 호출되는 핸들러 함수.
//  - 선택된 보간축들 중 3축을 이용해 스플라인 보간을 하는 함수입니다.
// --------------------------------------------------------------------------
void CContiInterpolationDlg::OnBtnIntpSpline() 
{
	long	lPointFactor;
	double	dVelocity, dAccel, dDecel;
	double	dPosX[MAX_SPLINE_NODE], dPosY[MAX_SPLINE_NODE], dPosZ;

	dVelocity	= GetDlgItemDouble(IDC_EDT_MOVE_VEL);
	dAccel		= GetDlgItemDouble(IDC_EDT_MOVE_ACC);
	dDecel		= GetDlgItemDouble(IDC_EDT_MOVE_DEC);
	
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
	dPosZ		= 1.0;
	lPointFactor= 100;	
	
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

// ++ =======================================================================
// >> OnBtnIntpStart() : "Start"버튼 클릭시 호출되는 핸들러 함수.
//  - 예약된 연속보간 데이타들을 이용하여 연속보간을 시작하는 함수입니다.
// --------------------------------------------------------------------------
void CContiInterpolationDlg::OnBtnIntpStart() 
{
	DWORD dwRetCode;

	//++ 지정한 좌표계의 연속보간 구동을 시작합니다.
	dwRetCode = AxmContiStart(COORD_NO, CONTI_NODE_VELOCITY, 0);	
	if(dwRetCode != AXT_RT_SUCCESS){
		CString strData;
		strData.Format("AxmContiStart return error[Code:%04d]", dwRetCode);
		MessageBox(strData, "Error", MB_OK | MB_ICONERROR);
	}		
}

// ++ =======================================================================
// >> OnBtnIntpClear() : "Clear"버튼 클릭시 호출되는 핸들러 함수.
//  - 예약된 연속보간 데이타들을 지우는 함수입니다.
// --------------------------------------------------------------------------
void CContiInterpolationDlg::OnBtnIntpClear() 
{
	DWORD dwRetCode;
	//++ 지정한 좌표계에 연속 보간 구동을 위해 예약된 보간데이타를 모두 삭제합니다.
	dwRetCode = AxmContiWriteClear(COORD_NO);
	if(dwRetCode != AXT_RT_SUCCESS){
		CString strData;
		strData.Format("AxmContiWriteClear return error[Code:%04d]", dwRetCode);
		MessageBox(strData, "Error", MB_OK | MB_ICONERROR);
	}			
}

// ++ =======================================================================
// >> OnBtnIntpStop() : "Stop"버튼 클릭시 호출되는 핸들러 함수.
//  - 연속보간을 정지하는 함수입니다.
// --------------------------------------------------------------------------
void CContiInterpolationDlg::OnBtnIntpStop() 
{
	long lCount;
	for(lCount = 0; lCount < m_lMoveIntpAxesCount; lCount++){
		//++ 지정한 좌표계에 연속 보간 구동을 감속정지합니다.
		// [INFO] 좌표계에 포함된 한 축을 정지하면 연속보간은 정지됩니다.
		AxmMoveSStop(m_lMoveIntpAxes[lCount]);
	}	
}

// ++ =======================================================================
// >> OnTimer(...) : 타이머 이벤트 핸들러 함수.
//  - 일정한 주기로 변경되는 위치/속도/정보등을 Control에 반영합니다.
// --------------------------------------------------------------------------
void CContiInterpolationDlg::OnTimer(UINT nIDEvent) 
{
	long	lCount, lArrayIndex = 0;
	double	dCmdPos, dActPos, dCmdVel;
	long	lExeNode = 0, lTotalNode = 0; 
	DWORD	dwQueueFree = 0, dwIntpInMotion= 0;
	switch(nIDEvent){
	case TM_DISPLAY:
		for(lCount = 0; lCount < MAX_INTP_MOVE_AXIS; lCount++){
			// 버튼 콘트롤의 체크 상태를 확인합니다.
			if(IsDlgButtonChecked(IDC_CHK_AXIS_00 + lCount))
			{
				//++ 지정한 축의 지령(Command)위치를 반환합니다.
				AxmStatusGetCmdPos(m_lMoveIntpAxes[lArrayIndex], &dCmdPos);
				if(m_dOldCmdPos[lCount] != dCmdPos){
					SetDlgItemDouble(IDC_STC_CMD_POS_00 + lCount, dCmdPos);
					m_dOldCmdPos[lCount] = dCmdPos;
				}
				
				//++ 지정한 축의 실제(Feedback)위치를 반환합니다.
				AxmStatusGetActPos(m_lMoveIntpAxes[lArrayIndex], &dActPos);
				if(m_dOldActPos[lCount] != dActPos){
					SetDlgItemDouble(IDC_STC_ACT_POS_00 + lCount, dActPos);
					m_dOldActPos[lCount] = dActPos;
				}
				
				//++ 지정한 축의 구동 속도를 반환합니다.
				AxmStatusReadVel(m_lMoveIntpAxes[lArrayIndex], &dCmdVel);
				if(m_dOldCmdVel[lCount] != dCmdVel){
					SetDlgItemDouble(IDC_STC_CMD_VEL_00 + lCount, dCmdVel);
					m_dOldCmdVel[lCount] = dCmdVel;
				}
				
				++lArrayIndex;
			}
		}

		//++ 지정한 좌표계에 연속보간 Queue가 비었는지 확인합니다.
		AxmContiReadFree(COORD_NO, &dwQueueFree);
		CheckDlgButton(IDC_CHK_INTP_QUEUE_FREE, dwQueueFree);

		//++ 지정한 좌표계가 연속보간 구동중인지 확인합니다.
		AxmContiIsMotion(COORD_NO, &dwIntpInMotion);
		CheckDlgButton(IDC_CHK_INTP_IN_MOTION, dwIntpInMotion);

		//++ 지정한 좌표계가 연속보간 구동중 현재 실행중인 Node의 Index를 확인합니다.
		AxmContiGetNodeNum(COORD_NO, &lExeNode);
		if(GetDlgItemInt(IDC_STC_INTP_EXE_NODE) != (UINT)lExeNode)
			SetDlgItemInt(IDC_STC_INTP_EXE_NODE, lExeNode);

		//++ 지정한 좌표계에 예약된 연속보간 데이타의 전체 갯수를 확인합니다.
		AxmContiGetTotalNodeNum(COORD_NO, &lTotalNode);
		if(GetDlgItemInt(IDC_STC_INTP_TOTAL_NODE) != (UINT)lTotalNode)
			SetDlgItemInt(IDC_STC_INTP_TOTAL_NODE, lTotalNode);

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
BOOL CContiInterpolationDlg::InitLibrary()
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
BOOL CContiInterpolationDlg::AddAxisInfo()
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
		case AXT_SMC_R1V04:			strData.Format("%02ld-(RTEX-PM)", i);		break;
		case AXT_SMC_R1V04PM2Q:		strData.Format("%02ld-(RTEX-PM2Q)", i);		break;
		case AXT_SMC_R1V04PM2QE:	strData.Format("%02ld-(RTEX-PM2QE)", i);	break;
		case AXT_SMC_R1V04MLIISV:	strData.Format("%02ld-[MLII-SGDV]", i);		break;
		case AXT_SMC_R1V04MLIIPM:	strData.Format("%02ld-(MLII-PM)", i);		break;
		case AXT_SMC_R1V04MLIICL:	strData.Format("%02ld-(MLII-CSDL)", i);		break;
		case AXT_SMC_R1V04MLIICR:	strData.Format("%02ld-(MLII-CSDH)", i);		break;
		case AXT_SMC_R1V04SIIIHMIV:	strData.Format("%02ld-(SIIIH-MRJ4)", i);	break;
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
BOOL CContiInterpolationDlg::InitControl()
{
	m_cboSelAxis.SetCurSel(m_lAxisNo);
	
	long	lCount;
	for(lCount = 0; lCount < MAX_INTP_MOVE_AXIS; lCount++){
		m_chkMoveIntpAxes[lCount].SubclassDlgItem(IDC_CHK_AXIS_00 + lCount, this); 
	}

	// Edit Control에 초기값 설정
	SetDlgItemDouble(IDC_EDT_MOVE_VEL, 100.0);
	SetDlgItemDouble(IDC_EDT_MOVE_ACC, 400.0);
	SetDlgItemDouble(IDC_EDT_MOVE_DEC, 400.0);

	return TRUE;
}

// ++ =======================================================================
// >> UpdateState() : 지정한 축의 설정값들을 읽어 Control과 일치시키는 함수.
//  - 축번호가 변경되었을 때 변경한 축의 설정값들과 Control들과 일치시키는 
//    역할을하는 함수입니다.
//  - 지정한 축의 모델별 제약들을 Control에 반영하는 역할을 합니다.
//  - 프로그램 초기 실행시, Mot파일 불러올 때, 축 번호 바뀔 때 사용됩니다.
// --------------------------------------------------------------------------
BOOL CContiInterpolationDlg::UpdateState()
{
	if(m_lAxisCount < 1)	return FALSE;
	
	CString	strData;
	DWORD	dwOnOff = 0;
	long	lCount, lTotalCount = 0;
	BOOL	bSelectCheck, bEmptyCheck, bAllCheck;
	long	lBoardNo = 0, lModulePos = 0, lFirstAxisNo = 0;
	
	//++ 지정한 축의 정보를 반환합니다.
	// [INFO] 여러개의 정보를 읽는 함수 사용시 불필요한 정보는 NULL(0)을 입력하면 됩니다.
	AxmInfoGetAxis(m_lAxisNo, &lBoardNo, &lModulePos, NULL);
	//++ 지정한 보드/모듈의 첫번째 축 번호를 반환합니다.
	AxmInfoGetFirstAxisNo(lBoardNo, lModulePos, &lFirstAxisNo);
	
	bSelectCheck		= FALSE;
	bEmptyCheck			= FALSE;
	m_lMoveIntpAxesCount= 0;
	for(lCount = 0; lCount < MAX_INTP_MOVE_AXIS; lCount++){		
		//++ 지정한 축이 제어가 가능한 상태인지 반환합니다.
		if(AxmInfoGetAxisStatus(lFirstAxisNo) == AXT_RT_SUCCESS){
			strData.Format("Axis %02d", lFirstAxisNo);
			
			m_chkMoveIntpAxes[lCount].EnableWindow(TRUE);			
			bSelectCheck	= m_chkMoveIntpAxes[lCount].GetCheck();
			bEmptyCheck		|= bSelectCheck;
			
			if(bSelectCheck == TRUE){
				m_lMoveIntpAxes[m_lMoveIntpAxesCount++] = lFirstAxisNo; 
			}
		}else{
			m_lMoveIntpAxes[lCount] = -1; 
			strData.Format("Axis --");
			
			m_chkMoveIntpAxes[lCount].EnableWindow(FALSE);
			m_chkMoveIntpAxes[lCount].SetCheck(FALSE);
		}
		
		lFirstAxisNo++;
		m_chkMoveIntpAxes[lCount].SetWindowText(strData);
	}
	
	// 선택된 축이 없으면 Disable처리
	m_chkServoOn.EnableWindow(bEmptyCheck);
	
	bAllCheck = TRUE;
	for(lCount = 0; lCount < m_lMoveIntpAxesCount; lCount++){		
		//++ 지정한 축의 서보온 상태를 반환합니다.
		AxmSignalIsServoOn(m_lMoveIntpAxes[lCount], &dwOnOff);
		// 선택된 보간축들이 모두 서보온 되어있을 때 TRUE 
		bAllCheck &= dwOnOff;
	}		
	
	m_chkServoOn.SetCheck(bAllCheck);	

	// 선택된 축수에 따라 사용가능한 보간버튼들을 활성화시킵니다.
	if(m_lMoveIntpAxesCount < 2){
		m_btnIntpLine.EnableWindow(DISABLE);
		m_btnIntpArc.EnableWindow(DISABLE);
		m_btnIntpCircle.EnableWindow(DISABLE);
		m_btnIntpLineArc.EnableWindow(DISABLE);
		m_btnIntpHelical.EnableWindow(DISABLE);
		m_btnIntpSpline.EnableWindow(DISABLE);
	}else{
		m_btnIntpLine.EnableWindow(ENABLE);
		m_btnIntpArc.EnableWindow(ENABLE);
		m_btnIntpCircle.EnableWindow(ENABLE);
		m_btnIntpLineArc.EnableWindow(ENABLE);		
		m_btnIntpSpline.EnableWindow(ENABLE);

		if(m_lMoveIntpAxesCount >= 3)	m_btnIntpSpline.EnableWindow(ENABLE);
		else							m_btnIntpSpline.EnableWindow(DISABLE);

		if(m_lMoveIntpAxesCount == 4)	m_btnIntpHelical.EnableWindow(ENABLE);
		else							m_btnIntpHelical.EnableWindow(DISABLE);
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
DWORD CContiInterpolationDlg::ConvertComboToAxm(CComboBox *pCboItem)
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
long CContiInterpolationDlg::ConvertAxmToCombo(CComboBox *pCboItem, DWORD dwCurData)
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
void CContiInterpolationDlg::SetDlgItemDouble(int nID, double value, int nPoint)
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
double CContiInterpolationDlg::GetDlgItemDouble(int nID)
{
	double dRet;
	CString sTemp;
	GetDlgItem(nID)->GetWindowText(sTemp);
	dRet = atof((LPCTSTR)sTemp);
	return dRet;
}

