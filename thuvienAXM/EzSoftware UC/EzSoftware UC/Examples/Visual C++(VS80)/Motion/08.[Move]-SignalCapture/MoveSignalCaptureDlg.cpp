// MoveSignalCaptureDlg.cpp : implementation file
//
// **************************************************************************
// >> [일자]: 2016.01.05
// >> [개요]: 이 예제는 신호검출 구동함수들의 사용법을 익히고 실제 특정 신호의
//    변화를 감지하여 그때 지령값 또는 엔코더값을 캡쳐해보는 예제입니다.
// >> [중요]: 위치캡쳐구동함수 응용범위
//     1) 구동중 특정 센서가 감지될 때의 지령위치 또는 피드벡 위치를 H/W 기능을 
//        이용해 정확하게 저장해야될 때 응용됩니다.
//     2) 이 기능은 웨이퍼 이송 로봇에서 웨이퍼 틀어짐 파악, Tray 적재 로봇에서 
//        Tray높이 파악등에 응용할 수 있습니다.
//     3) 구동중 고속 다중위치 캡쳐기능이 필요하신분은 별도로 기술문의 바랍니다. 
// **************************************************************************

#include "stdafx.h"

#include "math.h"
#include "MoveSignalCapture.h"
#include "MoveSignalCaptureDlg.h"

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
// CMoveSignalCaptureDlg dialog

CMoveSignalCaptureDlg::CMoveSignalCaptureDlg(CWnd* pParent /*=NULL*/)
	: CDialog(CMoveSignalCaptureDlg::IDD, pParent)
{
	//{{AFX_DATA_INIT(CMoveSignalCaptureDlg)
		// NOTE: the ClassWizard will add member initialization here
	//}}AFX_DATA_INIT
	// Note that LoadIcon does not require a subsequent DestroyIcon in Win32
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);

	//++
	m_lAxisNo		= -1;					// 제어할 축 번호 초기화
	m_lAxisCount	= 0;					// 제어 가능한 축갯수 초기화
	m_dwModuleID	= 0;					// 제어할 축의 모듈ID 초기화
}

void CMoveSignalCaptureDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CMoveSignalCaptureDlg)
	DDX_Control(pDX, IDC_CBO_CAPTURE_TARGET, m_cboCaptureTarget);
	DDX_Control(pDX, IDC_CBO_STOP_METHOD, m_cboStopMethod);
	DDX_Control(pDX, IDC_CBO_SIGNAL_EDGE, m_cboSignalEdge);
	DDX_Control(pDX, IDC_CBO_DETECT_SIG, m_cboDetectSig);
	DDX_Control(pDX, IDC_CBO_SEL_AXIS, m_cboSelAxis);
	DDX_Control(pDX, IDC_BTN_JOG_MOVE_P, m_btnJogMoveP);
	DDX_Control(pDX, IDC_BTN_JOG_MOVE_N, m_btnJogMoveN);
	//}}AFX_DATA_MAP
}

BEGIN_MESSAGE_MAP(CMoveSignalCaptureDlg, CDialog)
	//{{AFX_MSG_MAP(CMoveSignalCaptureDlg)
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	ON_CBN_SELCHANGE(IDC_CBO_SEL_AXIS, OnSelchangeCboSelAxis)
	ON_WM_TIMER()
	ON_BN_CLICKED(IDC_BTN_LOAD_FILE, OnBtnLoadFile)
	ON_BN_CLICKED(IDC_BTN_POS_CLEAR, OnBtnPosClear)
	ON_BN_CLICKED(IDC_CHK_SERVO_ON, OnChkServoOn)
	ON_BN_CLICKED(IDC_BTN_CAPTURE_MOVE, OnBtnCaptureMove)
	ON_BN_CLICKED(IDC_BTN_MOVE_STOP, OnBtnMoveStop)
	ON_BN_CLICKED(IDC_BTN_GET_POS, OnBtnGetPos)
	ON_WM_DESTROY()
	//}}AFX_MSG_MAP
	ON_MESSAGE(UM_JOG_BTN_DN, OnJogBtnDn)
	ON_MESSAGE(UM_JOG_BTN_UP, OnJogBtnUp)
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CMoveSignalCaptureDlg message handlers

BOOL CMoveSignalCaptureDlg::OnInitDialog()
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

void CMoveSignalCaptureDlg::OnPaint() 
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
HCURSOR CMoveSignalCaptureDlg::OnQueryDragIcon()
{
	return (HCURSOR) m_hIcon;
}

void CMoveSignalCaptureDlg::OnDestroy() 
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
void CMoveSignalCaptureDlg::OnSelchangeCboSelAxis() 
{
	m_lAxisNo = m_cboSelAxis.GetCurSel();	
	AxmInfoGetAxis(m_lAxisNo, NULL, NULL, &m_dwModuleID);
	
	UpdateState();		
}

// ++ =======================================================================
// >> OnBtnLoadFile() : "Load File"버튼 클릭시 호출되는 핸들러 함수.
//  - 임의 위치에 있는 Mot(AXM에서 사용하는 설정파일 형식) 파일을 불러옵니다.
//  - 이 함수를 통해 임의의 Mot파일을 불러오면 모션축의 설정값들이 Mot파일의 
//    설정값들로 일괄 변경됩니다.
// --------------------------------------------------------------------------
void CMoveSignalCaptureDlg::OnBtnLoadFile() 
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
// >> OnBtnPosClear() : "Position Clear"버튼 클릭시 호출되는 핸들러 함수.
//  - 선택된 축의 위치정보를 0.0으로 설정합니다.
//  - AxmStatusSetPosMatch함수는 AxmStatusSetCmdPos, AxmStatusSetActPos 함수를 
//    사용하는것과 동일한 효과를 냅니다.
// --------------------------------------------------------------------------
void CMoveSignalCaptureDlg::OnBtnPosClear() 
{
	//++ Command위치와 Actual위치를 지정한 값으로 설정합니다.
	AxmStatusSetPosMatch(m_lAxisNo, 0.0);	
}

// ++ =======================================================================
// >> OnChkServoOn() : "Servo On"버튼 클릭시 호출되는 핸들러 함수.
//  - 선택된 축을 체크버튼의 상태에 따라 서보 On/Off 합니다.
// --------------------------------------------------------------------------
void CMoveSignalCaptureDlg::OnChkServoOn() 
{
	DWORD dwOnOff;
	
	dwOnOff = IsDlgButtonChecked(IDC_CHK_SERVO_ON);
	//++ 지정 축의 Servo On/Off 신호를 출력합니다.
	AxmSignalServoOn(m_lAxisNo, dwOnOff);	
}

// ++ =======================================================================
// >> OnBtnCaptureMove() : "Capture Move "버튼 클릭시 호출되는 핸들러 함수.
//  - 선택된 축으로 지정한 신호검출 위치캡쳐 구동을 시작합니다.
//  - 선택한 신호의 Edge 신호가 검출되지않으면 지정한 속도로 무한 구동합니다.
//  ※ [CAUTION] End Limit 신호는 Edge 검출이 되지 않음에 유의 바랍니다.
// --------------------------------------------------------------------------
void CMoveSignalCaptureDlg::OnBtnCaptureMove() 
{
	CString strData;
	DWORD	dwRetCode;
	double	dMoveVel, dMoveAcc;
	long	lDetectSig, lSignalEdge, lTarget, lStopMethod;
	
	dMoveVel	= GetDlgItemDouble(IDC_EDT_MOVE_VEL);
	dMoveAcc	= GetDlgItemDouble(IDC_EDT_MOVE_ACC);

	lDetectSig	= ConvertComboToAxm(&m_cboDetectSig);
	lSignalEdge	= ConvertComboToAxm(&m_cboSignalEdge);
	lTarget		= ConvertComboToAxm(&m_cboCaptureTarget);
	lStopMethod	= ConvertComboToAxm(&m_cboStopMethod);

	//++ 지정 축에 설정된 신호를 검출하고 신호가 검출될 때 그 위치를 저장하기 위해 구동하는 함수입니다.
	dwRetCode	= AxmMoveSignalCapture(m_lAxisNo, dMoveVel, dMoveAcc, lDetectSig, lSignalEdge, lTarget, lStopMethod);	
	if(dwRetCode != AXT_RT_SUCCESS){
		strData.Format("AxmMoveSignalCapture return error[Code:%04d]", dwRetCode);
		MessageBox(strData, "Error", MB_OK | MB_ICONERROR);
	}
}

// ++ =======================================================================
// >> OnBtnMoveStop() : "Move Stop"버튼 클릭시 호출되는 핸들러 함수.
//  - 지정한 축의 신호검출 구동을 감속정지 합니다.
// --------------------------------------------------------------------------
void CMoveSignalCaptureDlg::OnBtnMoveStop() 
{
	//++ 지정한 축의 구동을 감속정지합니다.
	AxmMoveSStop(m_lAxisNo);
}

// ++ =======================================================================
// >> OnBtnGetPos() : "Get Position"버튼 클릭시 호출되는 핸들러 함수.
//  - 지정한 축의 신호검출 구동시 캡쳐한 위치값을 확인합니다.
// --------------------------------------------------------------------------
void CMoveSignalCaptureDlg::OnBtnGetPos() 
{
	DWORD	dwRetCode;
	double	dCapturePos = 0.0;
	
    //++ 'AxmMoveSignalCapture' 함수로 구동중 지정한 신호가 검출되어 저장된 위치값을 확인하는 함수입니다.
	// ※ [CAUTION] 함수 실행 결과가 "AXT_RT_SUCCESS"일때 저장된 위치가 유효하며, 이 함수를 한번 실행하면 
	//    저장된 위치값은 초기화됩니다.
	dwRetCode = AxmMoveGetCapturePos(m_lAxisNo, &dCapturePos);
	if(dwRetCode == AXT_RT_SUCCESS){
		SetDlgItemDouble(IDC_STC_CAPTURE_POS, dCapturePos);
	}else{
		SetWindowText("xxx.xxx ");
	}
}

// ++ =======================================================================
// >> OnJogBtnDn(...) : "Jog Move(+/-)"버튼 Down시 호출되는 핸들러 함수.
//  - "CJogButton" 버튼 클래스에서 버튼 클릭시 호출되는 WM_LBUTTONDOWN 이벤트를 
//    받아 사용자 이벤트로 이 함수를 호출해 줍니다. 이 때 wParam을 통해 전달되는
//    콘트롤 ID로 Jog(+/-)버튼을 구분하게 됩니다.
//  - Jog버튼 Down시 연속구동 함수를 호출하여 Jog 구동을 시작합니다.
// --------------------------------------------------------------------------
LRESULT CMoveSignalCaptureDlg::OnJogBtnDn(WPARAM wParam, LPARAM lParam)
{
	double dJogVel, dJogAcc, dJogDec;
	
	dJogVel	= fabs(GetDlgItemDouble(IDC_EDT_JOG_VEL));
	dJogAcc	= fabs(GetDlgItemDouble(IDC_EDT_JOG_ACC));
	dJogDec	= fabs(GetDlgItemDouble(IDC_EDT_JOG_DEC));
	
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
// >> OnJogBtnUp(...) : "Jog Move(+/-)"버튼 Up시 호출되는 핸들러 함수.
//  - "CJogButton" 버튼 클래스에서 버튼 클릭시 호출되는 WM_LBUTTONUP이벤트를 
//    받아 사용자 이벤트로 이 함수를 호출해 줍니다. 이 때 wParam을 통해 전달되는
//    콘트롤 ID로 Jog(+/-)버튼을 구분하게 됩니다.
//  - Jog버튼 Up시 구동정지 함수를 호출하여 Jog 구동을 종료합니다.
// --------------------------------------------------------------------------
LRESULT CMoveSignalCaptureDlg::OnJogBtnUp(WPARAM wParam, LPARAM lParam)
{
	//++ 지정한 축의 Jog구동(모션구동/원점검색구동)을 감속정지합니다.
	AxmMoveSStop(m_lAxisNo);	
	return 0;
}

// ++ =======================================================================
// >> OnTimer(...) : 타이머 이벤트 핸들러 함수.
//  - 일정한 주기로 변경되는 위치/속도/정보등을 Control에 반영합니다.
// --------------------------------------------------------------------------
void CMoveSignalCaptureDlg::OnTimer(UINT_PTR nIDEvent) 
{
	double dCmdPos = 0.0, dActPos = 0.0, dCmdVel = 0.0;
	
	switch(nIDEvent){
	case TM_DISPLAY:		
		//++ 지정한 축의 지령(Command)위치를 반환합니다.
		AxmStatusGetCmdPos(m_lAxisNo, &dCmdPos);
		if(m_dOldCmdPos != dCmdPos){
			SetDlgItemDouble(IDC_STC_CMD_POS, dCmdPos);
			m_dOldCmdPos = dCmdPos;
		}
		
		//++ 지정한 축의 실제(Feedback)위치를 반환합니다.
		AxmStatusGetActPos(m_lAxisNo, &dActPos);
		if(m_dOldActPos != dActPos){
			SetDlgItemDouble(IDC_STC_ACT_POS, dActPos);
			m_dOldActPos = dActPos;
		}
		
		//++ 지정한 축의 구동 속도를 반환합니다.
		AxmStatusReadVel(m_lAxisNo, &dCmdVel);
		if(m_dOldCmdVel != dCmdVel){
			SetDlgItemDouble(IDC_STC_CMD_VEL, dCmdVel);
			m_dOldCmdVel = dCmdVel;
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
BOOL CMoveSignalCaptureDlg::InitLibrary()
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
BOOL CMoveSignalCaptureDlg::AddAxisInfo()
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
		case AXT_SMC_R1V04:			strData.Format("%02ld-(RTEX-PM2Q)", i);		break;
		case AXT_SMC_R1V04PM2Q:		strData.Format("%02ld-(RTEX-PM2QE)", i);	break;
		case AXT_SMC_R1V04PM2QE:	strData.Format("%02ld-(RTEX-PM)", i);		break;
		case AXT_SMC_R1V04MLIISV:	strData.Format("%02ld-[MLII-SGDV]", i);		break;
		case AXT_SMC_R1V04MLIIPM:	strData.Format("%02ld-(MLII-PM)", i);		break;
		case AXT_SMC_R1V04MLIICL:	strData.Format("%02ld-[MLII-CSDL]", i);		break;
		case AXT_SMC_R1V04MLIICR:	strData.Format("%02ld-[MLII-CSDH]", i);		break;
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
BOOL CMoveSignalCaptureDlg::InitControl()
{
	m_cboSelAxis.SetCurSel(m_lAxisNo);
	
	// Edit Control에 초기값 설정
	SetDlgItemDouble(IDC_EDT_JOG_VEL, 100.0);
	SetDlgItemDouble(IDC_EDT_JOG_ACC, 400.0);
	SetDlgItemDouble(IDC_EDT_JOG_DEC, 400.0);
	
	SetDlgItemDouble(IDC_EDT_MOVE_VEL, 100.0);
	SetDlgItemDouble(IDC_EDT_MOVE_ACC, 400.0);

	m_cboDetectSig.SetCurSel(2);	
	m_cboSignalEdge.SetCurSel(1);
	m_cboStopMethod.SetCurSel(1);
	m_cboCaptureTarget.SetCurSel(0);

	return TRUE;
}

// ++ =======================================================================
// >> UpdateState() : 지정한 축의 설정값들을 읽어 Control과 일치시키는 함수.
//  - 축번호가 변경되었을 때 변경한 축의 설정값들과 Control들과 일치시키는 
//    역할을하는 함수입니다.
//  - 지정한 축의 모델별 제약들을 Control에 반영하는 역할을 합니다.
//  - 프로그램 초기 실행시, Mot파일 불러올 때, 축 번호 바뀔 때 사용됩니다.
// --------------------------------------------------------------------------
BOOL CMoveSignalCaptureDlg::UpdateState()
{
	if(m_lAxisCount < 1)	return FALSE;	

	DWORD	dwOnOff = 0;

	//++ 지정한 축의 서보온 상태를 반환합니다.
	AxmSignalIsServoOn(m_lAxisNo, &dwOnOff);
	CheckDlgButton(IDC_CHK_SERVO_ON, dwOnOff);

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
DWORD CMoveSignalCaptureDlg::ConvertComboToAxm(CComboBox *pCboItem)
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
long CMoveSignalCaptureDlg::ConvertAxmToCombo(CComboBox *pCboItem, DWORD dwCurData)
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
void CMoveSignalCaptureDlg::SetDlgItemDouble(int nID, double value, int nPoint)
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
double CMoveSignalCaptureDlg::GetDlgItemDouble(int nID)
{
	double dRet;
	CString sTemp;
	GetDlgItem(nID)->GetWindowText(sTemp);
	dRet = atof((LPCTSTR)sTemp);
	return dRet;
}


