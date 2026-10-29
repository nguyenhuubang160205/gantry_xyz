// GantryMotionDlg.cpp : implementation file
//
// **************************************************************************
// >> [일자]: 2016.01.05
// >> [개요]: 이 예제는 겐트리 함수들의 사용법을 익히고 겐트리 기구물에서의 
//    원점검색 및 Slave축 Offset 설정 방법등에 대해 학습하는 예제입니다.
// >> [중요]: 겐트리 Slave축 Offset설정방법 
//     1) AxmGantrySetEnable함수의 uSlHomeUse인자를 2로 설정해서 원점검색을 합니다. 
//     2) 원점검색이 정상적으로 완료되면 Slave축 원점위치에서 Master축 원점
//        위치까지의 차이값이(Offset) Master축 지령위치가 됩니다.
//     3) AxmGantrySetEnable함수의 uSlHomeUse인자를 1로, dSlaveHmOffset인자에
//        위에서 측정한 Master축 지령위치값에 부호를 변경한 후 설정하면됩니다. 
// **************************************************************************

#include "stdafx.h"

#include "math.h"
#include "GantryMotion.h"
#include "GantryMotionDlg.h"

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
#define TM_HOME_INFO	101

/////////////////////////////////////////////////////////////////////////////
// CGantryMotionDlg dialog

CGantryMotionDlg::CGantryMotionDlg(CWnd* pParent /*=NULL*/)
	: CDialog(CGantryMotionDlg::IDD, pParent)
{
	//{{AFX_DATA_INIT(CGantryMotionDlg)
		// NOTE: the ClassWizard will add member initialization here
	//}}AFX_DATA_INIT
	// Note that LoadIcon does not require a subsequent DestroyIcon in Win32
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);

	//++
	m_lAxisNo		= -1;		// 제어할 축 번호 초기화
	m_lAxisNoMa		= -1;		// Gantry Master 축 번호 초기화
	m_lAxisNoSl		= -1;		// Gantry Slave 축 번호 초기화
	m_lAxisCount	= 0;		// 제어 가능한 축갯수 초기화
	m_dwModuleID	= 0;		// 제어할 축의 모듈ID 초기화
}

void CGantryMotionDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CGantryMotionDlg)
	DDX_Control(pDX, IDC_CBO_GANTRY_HM_SLAVE_USE, m_cboGantryHmSlaveUse);
	DDX_Control(pDX, IDC_STC_AXIS_NO_MA, m_stcAxisNoMa);
	DDX_Control(pDX, IDC_STC_CMD_VEL_SL, m_stcCmdVelSl);
	DDX_Control(pDX, IDC_STC_CMD_POS_SL, m_stcCmdPosSl);
	DDX_Control(pDX, IDC_STC_ACT_POS_SL, m_stcActPosSl);
	DDX_Control(pDX, IDC_STC_AXIS_NO_SL, m_stcAxisNoSl);
	DDX_Control(pDX, IDC_PRG_HOME_RATE, m_prgHomeRate);
	DDX_Control(pDX, IDC_CHK_HOME_STATE_SL, m_chkHomeStateSl);
	DDX_Control(pDX, IDC_CHK_HOME_STATE_MA, m_chkHomeStateMa);
	DDX_Control(pDX, IDC_CBO_SEL_AXIS, m_cboSelAxis);
	DDX_Control(pDX, IDC_BTN_JOG_MOVE_P, m_btnJogMoveP);
	DDX_Control(pDX, IDC_BTN_JOG_MOVE_N, m_btnJogMoveN);
	//}}AFX_DATA_MAP
}

BEGIN_MESSAGE_MAP(CGantryMotionDlg, CDialog)
	//{{AFX_MSG_MAP(CGantryMotionDlg)
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	ON_CBN_SELCHANGE(IDC_CBO_SEL_AXIS, OnSelchangeCboSelAxis)
	ON_WM_TIMER()
	ON_BN_CLICKED(IDC_BTN_LOAD_FILE, OnBtnLoadFile)
	ON_WM_DESTROY()
	ON_BN_CLICKED(IDC_BTN_POS_CLEAR, OnBtnPosClear)
	ON_BN_CLICKED(IDC_CHK_SERVO_ON, OnChkServoOn)
	ON_BN_CLICKED(IDC_BTN_MOVE_POS, OnBtnMovePos)
	ON_BN_CLICKED(IDC_BTN_MOVE_STOP, OnBtnMoveStop)
	ON_BN_CLICKED(IDC_BTN_HOME_START, OnBtnHomeStart)
	ON_BN_CLICKED(IDC_CHK_GANTRY_ENABLE, OnChkGantryEnable)
	ON_BN_CLICKED(IDC_BTN_HOME_STOP, OnBtnHomeStop)
	//}}AFX_MSG_MAP
	ON_COMMAND_RANGE(IDC_RDO_ABS, IDC_RDO_REL, OnRdoAbsRelMode)
	ON_MESSAGE(UM_JOG_BTN_DN, OnJogBtnDn)
	ON_MESSAGE(UM_JOG_BTN_UP, OnJogBtnUp)
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CGantryMotionDlg message handlers

BOOL CGantryMotionDlg::OnInitDialog()
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

void CGantryMotionDlg::OnPaint() 
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
HCURSOR CGantryMotionDlg::OnQueryDragIcon()
{
	return (HCURSOR) m_hIcon;
}

void CGantryMotionDlg::OnDestroy() 
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
void CGantryMotionDlg::OnSelchangeCboSelAxis() 
{
	m_lAxisNo	= m_cboSelAxis.GetCurSel();		// 축 선택 ComboBox에서 선택된 축번호를 제어할 축 번호 변수에 설정합니다.

	m_lAxisNoMa	= (m_lAxisNo / 2) * 2;			// 선택된 축번호로 겐트리 Master축 번호 생성 
	m_lAxisNoSl	= m_lAxisNoMa + 1;				// 선택된 축번호로 겐트리 Slave축 번호 생성 

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
void CGantryMotionDlg::OnBtnLoadFile() 
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
// >> OnBtnPosClear() : "Clear"버튼 클릭시 호출되는 핸들러 함수.
//  - 선택된 겐트리 축들의 위치정보를 0.0으로 설정합니다.
//  - AxmStatusSetPosMatch함수는 AxmStatusSetCmdPos, AxmStatusSetActPos 함수를 
//    사용하는것과 동일한 효과를 냅니다.
// ※ [CAUTION] 겐트리 축으로 설정되어도 위치설정, 서보온등은 축별로 동작합니다.
// --------------------------------------------------------------------------
void CGantryMotionDlg::OnBtnPosClear() 
{
	DWORD	dwState = DISABLE;
	//++ 지정 축이 Gantry축으로 활성화되었는지 확인합니다.
	AxmGantryGetEnable(m_lAxisNoMa, NULL, NULL, NULL, &dwState);
	if(dwState == ENABLE){
		//++ Command위치와 Actual위치를 지정한 값으로 설정합니다.
		AxmStatusSetPosMatch(m_lAxisNoMa, 0.0);
		AxmStatusSetPosMatch(m_lAxisNoSl, 0.0);
	}else{
		AxmStatusSetPosMatch(m_lAxisNo, 0.0);
	}
}

// ++ =======================================================================
// >> OnChkServoOn() : "Servo On"버튼 클릭시 호출되는 핸들러 함수.
//  - 선택된 겐트리 축들을 체크버튼의 상태에 따라 서보 On/Off 합니다.
// ※ [CAUTION] 겐트리 축으로 설정되어도 위치설정, 서보온등은 각 축별로 동작합니다.
// --------------------------------------------------------------------------
void CGantryMotionDlg::OnChkServoOn() 
{
	DWORD	dwOnOff, dwState = DISABLE;
	
	dwOnOff = IsDlgButtonChecked(IDC_CHK_SERVO_ON);
	//++ 지정 축이 Gantry축으로 활성화되었는지 확인합니다.
	AxmGantryGetEnable(m_lAxisNoMa, NULL, NULL, NULL, &dwState);
	if(dwState == ENABLE){
		//++ 지정 축의 Servo On/Off 신호를 출력합니다.
		AxmSignalServoOn(m_lAxisNoMa, dwOnOff);	
		AxmSignalServoOn(m_lAxisNoSl, dwOnOff);	
	}else{
		AxmSignalServoOn(m_lAxisNo, dwOnOff);	
	}
}

// ++ =======================================================================
// >> OnRdoAbsRelMode(...) : "Absolute/Relative"버튼 클릭시 호출되는 핸들러 함수.
//  - 지정한 축의 구동 좌표계를 설정합니다.
// ※ [CAUTION] 겐트리 축으로 설정되어있으면 Master축의 설정값으로 좌표구동합니다.
// --------------------------------------------------------------------------
void CGantryMotionDlg::OnRdoAbsRelMode(UINT nID) 
{
	DWORD dwAbsRelMode = nID - IDC_RDO_ABS;
	
	//++ 지정 축의 구동 좌표계를 설정합니다. 
	// dwAbsRelMode : (0)POS_ABS_MODE - 현재 위치와 상관없이 지정한 위치로 절대좌표 이동합니다.
	//                (1)POS_REL_MODE - 현재 위치에서 지정한 양만큼 상대좌표 이동합니다.
	AxmMotSetAbsRelMode(m_lAxisNo, dwAbsRelMode);
}

// ++ =======================================================================
// >> OnBtnMovePos() : "Move Target"버튼 클릭시 호출되는 핸들러 함수.
//  - 지정한 축을 지정한 거리(또는 위치)/속도/가속도/감속도로 모션구동합니다.
//  - 지정한 축이 겐트리 축으로 활성화되어 있으면 두축이 동기되어 구동됩니다.
// ※ [CAUTION] 겐트리 축으로 설정되어 있을경우 구동전 반드시 Master축과 Slave축을
//    각각 서보온 해야됩니다. 만약 한쪽만 서보온 되어있을 경우 모터에(Ballscrew) 
//    따라 기구물에 부하가 가해져 알람이 발생할 수 있습니다.
// --------------------------------------------------------------------------
void CGantryMotionDlg::OnBtnMovePos() 
{
	double dMovePos, dMoveVel, dMoveAcc, dMoveDec;
	
	// 각각의 Edit 콘트롤에서 설정값을 가져옴
	dMovePos = GetDlgItemDouble(IDC_EDT_MOVE_POS);
	dMoveVel = GetDlgItemDouble(IDC_EDT_MOVE_VEL);
	dMoveAcc = GetDlgItemDouble(IDC_EDT_MOVE_ACC);
	dMoveDec = GetDlgItemDouble(IDC_EDT_MOVE_DEC);
	
	//++ 지정한 축을 지정한 거리(또는 위치)/속도/가속도로 모션구동합니다.
	AxmMoveStartPos(m_lAxisNo, dMovePos, dMoveVel, dMoveAcc, dMoveDec);		
}

// ++ =======================================================================
// >> OnJogBtnDn(...) : "Move Jog(+/-)"버튼 Down시 호출되는 핸들러 함수.
//  - "CJogButton" 버튼 클래스에서 버튼 클릭시 호출되는 WM_LBUTTONDOWN 이벤트를 
//    받아 사용자 이벤트로 이 함수를 호출해 줍니다. 이 때 wParam을 통해 전달되는
//    콘트롤 ID로 Jog(+/-)버튼을 구분하게 됩니다.
//  - Jog버튼 Down시 연속구동 함수를 호출하여 Jog 구동을 시작합니다.
// ※ [CAUTION] 겐트리 축으로 설정되어 있을경우 구동전 반드시 Master축과 Slave축을
//    각각 서보온 해야됩니다. 만약 한쪽만 서보온 되어있을 경우 모터에(Ballscrew) 
//    따라 기구물에 부하가 가해져 알람이 발생할 수 있습니다.
// --------------------------------------------------------------------------
LRESULT CGantryMotionDlg::OnJogBtnDn(WPARAM wParam, LPARAM lParam)
{
	double dJogVel, dJogAcc, dJogDec;
	
	dJogVel	= fabs(GetDlgItemDouble(IDC_EDT_MOVE_VEL));
	dJogAcc	= fabs(GetDlgItemDouble(IDC_EDT_MOVE_ACC));
	dJogDec	= fabs(GetDlgItemDouble(IDC_EDT_MOVE_DEC));
	
	switch(wParam)
	{
	case IDC_BTN_JOG_MOVE_P:		
		//++ 지정한 축을 (+)방향으로 지정한 속도/가속도/감속도로 모션구동합니다.
		AxmMoveVel(m_lAxisNo, dJogVel, dJogAcc, dJogDec);
		break;
		
	case IDC_BTN_JOG_MOVE_N:
		//++ 지정한 축을 (-)방향으로 지정한 속도/가속도/감속도로 모션구동합니다.
		AxmMoveVel(m_lAxisNo, -dJogVel, dJogAcc, dJogDec);
		break;
	}
	
	return 0;
}

// ++ =======================================================================
// >> OnJogBtnUp(...) : "Move Jog(+/-)"버튼 Up시 호출되는 핸들러 함수.
//  - "CJogButton" 버튼 클래스에서 버튼 클릭시 호출되는 WM_LBUTTONUP이벤트를 
//    받아 사용자 이벤트로 이 함수를 호출해 줍니다. 이 때 wParam을 통해 전달되는
//    콘트롤 ID로 Jog(+/-)버튼을 구분하게 됩니다.
//  - Jog버튼 Up시 구동정지 함수를 호출하여 Jog 구동을 종료합니다.
// ※ [CAUTION] 겐트리 축으로 설정되어 있을경우 Master축의 구동을 종료하면 Slave축
//    또한 동기되어 자동정지됩니다.
// --------------------------------------------------------------------------
LRESULT CGantryMotionDlg::OnJogBtnUp(WPARAM wParam, LPARAM lParam)
{
	//++ 지정한 축의 Jog구동(모션구동/원점검색구동)을 감속정지합니다.
	AxmMoveSStop(m_lAxisNo);	
	return 0;
}

// ++ =======================================================================
// >> OnBtnMoveStop() : "Move Stop"버튼 클릭시 호출되는 핸들러 함수.
//  - 지정한 축으로 구동정지 함수를 호출하여 구동을 종료합니다.
// ※ [CAUTION] 겐트리 축으로 설정되어 있을경우 Master축의 구동을 종료하면 Slave축
//    또한 동기되어 자동정지됩니다.
// --------------------------------------------------------------------------
void CGantryMotionDlg::OnBtnMoveStop() 
{
	//++ 지정한 축의 모션구동(Jog구동/원점검색구동)을 감속정지합니다.
	AxmMoveSStop(m_lAxisNo);		
}

// ++ =======================================================================
// >> OnBtnHomeStart() : "Home Start"버튼 클릭시 호출되는 핸들러 함수.
//  - 지정한 축으로 원점검색을 시작합니다.
// ※ [CAUTION] 지정한 축이 겐트리 축으로 설정되어 있을경우 두축 모두 서보온이
//    되어있지 않을 경우 AxmGantrySetEnable 함수로 겐트리 기능을 활성활 할 때 설정한 
//    dwSlaveHmUse의 값에 따라 원점검색이 완료되지 않을 수 있습니다.
// ※ [CAUTION] 지정한 축이 겐트리 축으로 설정되어 있을경우 AxmGantrySetEnable
//    함수로 겐트리 기능을 활성활 할 때 설정한 dwSlaveHmUse의 값에 따라 원점검색
//    방법이 달라집니다.
// --------------------------------------------------------------------------
void CGantryMotionDlg::OnBtnHomeStart() 
{
	DWORD	dwRetCode;
	// 원점검색 레벨 변경이 필요할 때 주석을 해제해서 사용하세요.
	// - dwLevel: [00]LOW, [01]HIGH
	// > AxmHomeSetSignalLevel(m_lAxisNoMa, dwLevel);
	// > AxmHomeSetSignalLevel(m_lAxisNoSl, dwLevel);

	// 원점검색 방법설정 변경이 필요할 때 주석을 해제해서 사용하세요.
	// - lHomeDir     : [00]DIR_CCW, [01]DIR_CW
	// - dwHomeSignal : [00]PosEndLimit, [01]NegEndLimit, [04]HomeSensor
	// - dwZPhaseUse  : [00]Not Use, [01]Home Dir, [02]Not Home Dir
	// > AxmHomeSetMethod(m_lAxisNoMa, lHomeDir, dwHomeSignal, dwZPhaseUse, dHomeClrTime, dHomeOffset);
	// > AxmHomeSetMethod(m_lAxisNoSl, lHomeDir, dwHomeSignal, dwZPhaseUse, dHomeClrTime, dHomeOffset);

	// 원점검색 속도설정 변경이 필요할 때 주석을 해제해서 사용하세요.
	// > AxmHomeSetVel(m_lAxisNoMa, dVelFirst, dVelSecond, dVelThird, dVelLast, dAccFirst, dAccSecond);	
	// > AxmHomeSetVel(m_lAxisNoSl, dVelFirst, dVelSecond, dVelThird, dVelLast, dAccFirst, dAccSecond);	

	//++ 지정한 축의 원점검색 구동을 시작합니다.
	dwRetCode = AxmHomeSetStart(m_lAxisNo);		
	if(dwRetCode != AXT_RT_SUCCESS){
		CString strData;
		strData.Format("AxmHomeSetStart return error[Code:%04d]", dwRetCode);
		MessageBox(strData, "Error", MB_OK | MB_ICONERROR);
	}
}

// ++ =======================================================================
// >> OnBtnHomeStop() : "Home Stop"버튼 클릭시 호출되는 핸들러 함수.
//  - 지정한 축으로 구동정지 함수를 호출하여 원점검색구동을 종료합니다.
// ※ [CAUTION] 겐트리 축으로 설정되어 있을경우 Master축의 구동을 종료하면 Slave축
//    또한 동기되어 자동정지됩니다.
// --------------------------------------------------------------------------
void CGantryMotionDlg::OnBtnHomeStop() 
{
	//++ 지정한 축의 원점검색구동(모션구동/Jog구동)을 감속정지합니다.
	AxmMoveSStop(m_lAxisNo);	
}

// ++ =======================================================================
// >> OnChkGantryEnable() : "Gantry Enable"버튼 클릭시 호출되는 핸들러 함수.
//  - 지정한 축으로 겐트리 기능을 활성화 합니다.
// ※ [CAUTION] 겐트리 축으로 설정되어 있을경우 Master축의 구동을 종료하면 Slave축
//    또한 동기되어 자동정지됩니다.
// --------------------------------------------------------------------------
void CGantryMotionDlg::OnChkGantryEnable() 
{
	DWORD	dwSlaveHmUse, dwRetCode;
	double	dSlaveHmOffset, dSlaveHmRange;

	if(IsDlgButtonChecked(IDC_CHK_GANTRY_ENABLE)){
		dwSlaveHmUse	= ConvertComboToAxm(&m_cboGantryHmSlaveUse);
		dSlaveHmOffset	= GetDlgItemDouble(IDC_EDT_GANTRY_HM_OFFSET);
		dSlaveHmRange	= GetDlgItemDouble(IDC_EDT_GANTRY_HM_RANGE);

		//++ 지정한 Master축과 Slave축으로 겐트리 기능을 활성화 시킵니다.
		dwRetCode = AxmGantrySetEnable(m_lAxisNoMa, m_lAxisNoSl, dwSlaveHmUse, dSlaveHmOffset, dSlaveHmRange);
		if(dwRetCode != AXT_RT_SUCCESS){
			CString strData;
			CheckDlgButton(IDC_CHK_GANTRY_ENABLE, FALSE);

			strData.Format("AxmGantrySetEnable return error[Code:%04d]", dwRetCode);
			MessageBox(strData, "Error", MB_OK | MB_ICONERROR);
		}
	}else{
		//++ 지정한 Master축과 Slave축으로 겐트리 기능을 비활성화 시킵니다.
		dwRetCode = AxmGantrySetDisable(m_lAxisNoMa, m_lAxisNoSl);
		if(dwRetCode != AXT_RT_SUCCESS){
			CString strData;
			CheckDlgButton(IDC_CHK_GANTRY_ENABLE, TRUE);

			strData.Format("AxmGantrySetDisable return error[Code:%04d]", dwRetCode);
			MessageBox(strData, "Error", MB_OK | MB_ICONERROR);
		}
	}
}

// ++ =======================================================================
// >> OnTimer(...) : 타이머 이벤트 핸들러 함수.
//  - 일정한 주기로 변경되는 위치/속도/정보등을 Control에 반영합니다.
// --------------------------------------------------------------------------
void CGantryMotionDlg::OnTimer(UINT nIDEvent) 
{
	DWORD	dwRetCode, dwState = 0;
	DWORD	dwStepMain = 0, dwStepSub = 0;
	double	dCmdPos = 0.0, dActPos = 0.0, dCmdVel = 0.0;
	
	switch(nIDEvent){
	case TM_DISPLAY:
		//++ 지정한 축의 지령(Command)위치를 반환합니다.
		AxmStatusGetCmdPos(m_lAxisNoMa, &dCmdPos);
		if(m_dOldCmdPosMa != dCmdPos){
			SetDlgItemDouble(IDC_STC_CMD_POS_MA, dCmdPos);
			m_dOldCmdPosMa = dCmdPos;
		}
		
		//++ 지정한 축의 실제(Feedback)위치를 반환합니다.
		AxmStatusGetActPos(m_lAxisNoMa, &dActPos);
		if(m_dOldActPosMa != dActPos){
			SetDlgItemDouble(IDC_STC_ACT_POS_MA, dActPos);
			m_dOldActPosMa = dActPos;
		}
		
		//++ 지정한 축의 구동 속도를 반환합니다.
		AxmStatusReadVel(m_lAxisNoMa, &dCmdVel);
		if(m_dOldCmdVelMa != dCmdVel){
			SetDlgItemDouble(IDC_STC_CMD_VEL_MA, dCmdVel);
			m_dOldCmdVelMa = dCmdVel;
		}	
		
		//++ 지정한 축의 지령(Command)위치를 반환합니다.
		AxmStatusGetCmdPos(m_lAxisNoSl, &dCmdPos);
		if(m_dOldCmdPosSl != dCmdPos){
			SetDlgItemDouble(IDC_STC_CMD_POS_SL, dCmdPos);
			m_dOldCmdPosSl = dCmdPos;
		}
		
		//++ 지정한 축의 실제(Feedback)위치를 반환합니다.
		AxmStatusGetActPos(m_lAxisNoSl, &dActPos);
		if(m_dOldActPosSl != dActPos){
			SetDlgItemDouble(IDC_STC_ACT_POS_SL, dActPos);
			m_dOldActPosSl = dActPos;
		}
		
		//++ 지정한 축의 구동 속도를 반환합니다.
		AxmStatusReadVel(m_lAxisNoSl, &dCmdVel);
		if(m_dOldCmdVelSl != dCmdVel){
			SetDlgItemDouble(IDC_STC_CMD_VEL_SL, dCmdVel);
			m_dOldCmdVelSl = dCmdVel;
		}	
		
		//++ 지정한 축에 겐트리 기능이 활성화되었는지 확인합니다.
		AxmGantryGetEnable(m_lAxisNoMa, NULL, NULL, NULL, &dwState);
		if(dwState == ENABLE)	SetDlgItemText(IDC_STC_GANTRY_STATE, "∞");
		else					SetDlgItemText(IDC_STC_GANTRY_STATE, " ");

		break;
		
	case TM_HOME_INFO:	// About Home Search		
		//++ 지정한 축의 원점신호의 상태를 확인합니다.
		dwRetCode = AxmHomeReadSignal(m_lAxisNoMa, &dwState);
		if(dwRetCode == AXT_RT_SUCCESS){
			m_chkHomeStateMa.SetCheck(dwState);
		}

		//++ 지정한 축의 원점신호의 상태를 확인합니다.
		dwRetCode = AxmHomeReadSignal(m_lAxisNoSl, &dwState);
		if(dwRetCode == AXT_RT_SUCCESS){
			m_chkHomeStateSl.SetCheck(dwState);
		}
		
		//++ 지정한 축의 원점검색 결과를 확인합니다.
		AxmHomeGetResult(m_lAxisNoMa, &dwState);
		if(m_dwOldResult != dwState){
			SetDlgItemText(IDC_STC_HOME_RESULT, TranslateHomeResult(dwState));
			m_dwOldResult = dwState;
		}
		
		//++ 지정한 축의 원점검색 진행율을 확인합니다.
		dwRetCode = AxmHomeGetRate(m_lAxisNoMa, &dwStepMain, &dwStepSub);
		if(dwRetCode == AXT_RT_SUCCESS){
			if(GetDlgItemInt(IDC_STC_HOME_STEP_MAIN) != (UINT)dwStepMain)
				SetDlgItemInt(IDC_STC_HOME_STEP_MAIN, dwStepMain);

			if(GetDlgItemInt(IDC_STC_HOME_STEP_SUB) != (UINT)dwStepSub)
				SetDlgItemInt(IDC_STC_HOME_STEP_SUB, dwStepSub);

			m_prgHomeRate.SetPos(dwStepSub);
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
BOOL CGantryMotionDlg::InitLibrary()
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
BOOL CGantryMotionDlg::AddAxisInfo()
{
	CString	strData;
	DWORD	dwModuleID;
	
	//++ 유효한 전체 모션축수를 반환합니다.
	AxmInfoGetAxisCount(&m_lAxisCount);
	if(m_lAxisCount < 1)	return FALSE;

	m_lAxisNo	= 0;
	m_lAxisNoMa = 0;
	m_lAxisNoSl = 1;	
	//++ 지정한 축의 정보를 반환합니다.
	// [INFO] 여러개의 정보를 읽는 함수 사용시 불필요한 정보는 NULL(0)을 입력하면 됩니다.
	AxmInfoGetAxis(m_lAxisNoMa, NULL, NULL, &m_dwModuleID);

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
		
	InitControl();							// Control 변수들을 등록하고, 초기 설정값들을 설정합니다.	

	SetTimer(TM_DISPLAY, 100, NULL);		// 일정한 주기로 변경되는 위치/속도/정보등을 Control에 반영할 타이머를 실행합니다.
	SetTimer(TM_HOME_INFO, 200, NULL);		// 일정한 주기로 변경되는 원점검색 관련정보를 Control에 반영할 타이머를 실행합니다.

	return TRUE;
}

// ++ =======================================================================
// >> InitControl() : Control들에 초기값을 설정하는 함수.
//  - Control 변수들을 등록하고, 초기 설정값들을 설정합니다.
// --------------------------------------------------------------------------
BOOL CGantryMotionDlg::InitControl()
{
	m_cboSelAxis.SetCurSel(m_lAxisNoMa);

	// 원점검색 진행율을 표시할 프로그래스바 설정
	m_prgHomeRate.SetRange(0, 100);
	m_prgHomeRate.SetStep(1);
	m_prgHomeRate.SetPos(0);

	// Edit Control에 초기값 설정
	SetDlgItemDouble(IDC_EDT_MOVE_POS, 100.0);
	SetDlgItemDouble(IDC_EDT_MOVE_VEL, 100.0);
	SetDlgItemDouble(IDC_EDT_MOVE_ACC, 400.0);
	SetDlgItemDouble(IDC_EDT_MOVE_DEC, 400.0);

	SetDlgItemDouble(IDC_EDT_GANTRY_HM_OFFSET, 0.0);
	SetDlgItemDouble(IDC_EDT_GANTRY_HM_RANGE, 100.0);
	
	return TRUE;
}

#define GANTYR_SLAVE_HM_DONE	0
#define GANTYR_SLAVE_HM_BOTH	1
#define GANTYR_SLAVE_HM_EACH	2
	
// ++ =======================================================================
// >> UpdateState() : 지정한 축의 설정값들을 읽어 Control과 일치시키는 함수.
//  - 축번호가 변경되었을 때 변경한 축의 설정값들과 Control들과 일치시키는 
//    역할을하는 함수입니다.
//  - 지정한 축의 모델별 제약들을 Control에 반영하는 역할을 합니다.
//  - 프로그램 초기 실행시, Mot파일 불러올 때, 축 번호 바뀔 때 사용됩니다.
// --------------------------------------------------------------------------
BOOL CGantryMotionDlg::UpdateState()
{
	if(m_lAxisCount < 1)	return FALSE;

	CString	strData;
	DWORD	dwAbsRelMode = POS_ABS_MODE, dwOnOff = 0;
	DWORD	dwSlaveHmUse = 0, dwGantryOn = DISABLE;
	double	dSlaveHmOffset = 0.0, dSlaveHmRange = 1.0;

	//++ 지정한 축의 구동 좌표계 설정값을 확인합니다.
	AxmMotGetAbsRelMode(m_lAxisNo, &dwAbsRelMode);	
	CheckRadioButton(IDC_RDO_ABS, IDC_RDO_REL, IDC_RDO_ABS + dwAbsRelMode);

	//++ 지정한 축이 제어가 가능한 상태인지 확인합니다.
	if(AxmInfoGetAxisStatus(m_lAxisNoSl) == AXT_RT_SUCCESS){
		m_stcCmdPosSl.EnableWindow(ENABLE);
		m_stcActPosSl.EnableWindow(ENABLE);
		m_stcCmdVelSl.EnableWindow(ENABLE);
	}else{
		m_stcCmdPosSl.EnableWindow(DISABLE);
		m_stcActPosSl.EnableWindow(DISABLE);
		m_stcCmdVelSl.EnableWindow(DISABLE);
	}

	strData.Format("Ma Axis %02d", m_lAxisNoMa);
	SetDlgItemText(IDC_STC_AXIS_NO_MA, strData);

	strData.Format("Sl Axis %02d", m_lAxisNoSl);
	SetDlgItemText(IDC_STC_AXIS_NO_SL, strData);

	//++ 지정한 축의 서보온 상태를 반환합니다.
	AxmSignalIsServoOn(m_lAxisNoMa, &dwOnOff);
	CheckDlgButton(IDC_CHK_SERVO_ON, dwOnOff);

	//++ 지정한 축의 겐트리제어 관련 설정값을 확인합니다.
	AxmGantryGetEnable(m_lAxisNoMa, &dwSlaveHmUse, &dSlaveHmOffset, &dSlaveHmRange, &dwGantryOn);
	ConvertAxmToCombo(&m_cboGantryHmSlaveUse, dwSlaveHmUse);
	SetDlgItemDouble(IDC_EDT_GANTRY_HM_OFFSET, dSlaveHmOffset);
	SetDlgItemDouble(IDC_EDT_GANTRY_HM_RANGE, dSlaveHmRange);
	CheckDlgButton(IDC_CHK_GANTRY_ENABLE, dwGantryOn);

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
DWORD CGantryMotionDlg::ConvertComboToAxm(CComboBox *pCboItem)
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
long CGantryMotionDlg::ConvertAxmToCombo(CComboBox *pCboItem, DWORD dwCurData)
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
void CGantryMotionDlg::SetDlgItemDouble(int nID, double value, int nPoint)
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
double CGantryMotionDlg::GetDlgItemDouble(int nID)
{
	double dRet;
	CString sTemp;
	GetDlgItem(nID)->GetWindowText(sTemp);
	dRet = atof((LPCTSTR)sTemp);
	return dRet;
}

// ++ =======================================================================
// >> TranslateHomeResult(...) : 지정한 원점검색 결과에 해당하는 문자열을 반환
//    하는 함수.
//  - "AXHS.h"에 정의되어있는 AXT_MOTION_HOME_RESULT 구조체를 기반으로 합니다.
// --------------------------------------------------------------------------
CString  CGantryMotionDlg::TranslateHomeResult(DWORD dwHomeResult)
{
	CString strResult;	
	
	switch(dwHomeResult){		
	case HOME_SUCCESS:			strResult.Format("[01H] HOME_SUCCESS");			break;
	case HOME_SEARCHING:		strResult.Format("[02H] HOME_SEARCHING");		break;
	case HOME_ERR_GNT_RANGE:	strResult.Format("[10H] HOME_ERR_GNT_RANGE");	break;
	case HOME_ERR_USER_BREAK:	strResult.Format("[11H] HOME_ERR_USER_BREAK");	break;
	case HOME_ERR_VELOCITY:		strResult.Format("[12H] HOME_ERR_VELOCITY");	break;
	case HOME_ERR_AMP_FAULT:	strResult.Format("[13H] HOME_ERR_AMP_FAULT");	break;
	case HOME_ERR_NEG_LIMIT:	strResult.Format("[14H] HOME_ERR_NEG_LIMIT");	break;
	case HOME_ERR_POS_LIMIT:	strResult.Format("[15H] HOME_ERR_POS_LIMIT");	break;
	case HOME_ERR_NOT_DETECT:	strResult.Format("[16H] HOME_ERR_NOT_DETECT");	break;
	case HOME_ERR_UNKNOWN:		strResult.Format("[FFH] HOME_ERR_UNKNOWN");		break;
	}
	
	return strResult;	
}

