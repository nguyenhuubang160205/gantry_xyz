// OverrideVelocityAtPosDlg.cpp : implementation file
//
// **************************************************************************
// >> [일자]: 2016.01.05
// >> [개요]: 이 예제는 지정한 위치에서 속도 오버라이드하는 함수들의 사용법을
//    익히고 여러 위치에서 다중 속도 오버라이드를 확인할 수 있는 예제입니다.
// >> [중요]: 속도오버라이드 제약사항
//     1) 속도오버라이드는 가속/감속 중에는 반영되지 않습니다.
//     2) 등속구간 진입시 가속/감속 중에 변경한 속도값이 반영됩니다.
//     3) AxmOverrideVelAtMultiPos 함수를 이용해서 오버라이드 구동중에는 별도의
//        속도 오버라이드 함수를 호출하여 속도를 변경하면 지정한 오버라이드 
//        위치에서 지정한 속도가 되도록 하는 기능은 보장 할 수 없습니다.
// **************************************************************************

#include "stdafx.h"
#include "OverrideVelocityAtPos.h"
#include "OverrideVelocityAtPosDlg.h"

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
// COverrideVelocityAtPosDlg dialog

COverrideVelocityAtPosDlg::COverrideVelocityAtPosDlg(CWnd* pParent /*=NULL*/)
	: CDialog(COverrideVelocityAtPosDlg::IDD, pParent)
{
	//{{AFX_DATA_INIT(COverrideVelocityAtPosDlg)
	//}}AFX_DATA_INIT
	// Note that LoadIcon does not require a subsequent DestroyIcon in Win32
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);

	//++
	m_lAxisNo		= -1;					// 제어할 축 번호 초기화
	m_lAxisCount	= 0;					// 제어 가능한 축갯수 초기화
	m_dwModuleID	= 0;					// 제어할 축의 모듈ID 초기화
}

void COverrideVelocityAtPosDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(COverrideVelocityAtPosDlg)
	DDX_Control(pDX, IDC_BTN_OVER_VEL_AT_POS, m_btnOverVelAtPos);
	DDX_Control(pDX, IDC_EDT_OVER_VEL, m_edtOverVel);
	DDX_Control(pDX, IDC_EDT_OVER_POS, m_edtOverPos);
	DDX_Control(pDX, IDC_EDT_OVER_POS_ADD, m_edtOverPosAdd);
	DDX_Control(pDX, IDC_EDT_OVER_VEL_ADD, m_edtOverVelAdd);
	DDX_Control(pDX, IDC_BTN_OVER_VEL_AT_MPOS, m_btnOverVelAtMPos);
	DDX_Control(pDX, IDC_BTN_OVER_DATA_CLR, m_btnOverDataClr);
	DDX_Control(pDX, IDC_BTN_OVER_DATA_ADD, m_btnOverDataAdd);
	DDX_Control(pDX, IDC_LST_OVER_DATA, m_lstOverData);
	DDX_Control(pDX, IDC_CBO_OVER_MODE, m_cboOverMode);
	DDX_Control(pDX, IDC_CBO_CAMP_TARGET, m_cboCampTarget);
	DDX_Control(pDX, IDC_CBO_SEL_AXIS, m_cboSelAxis);
	//}}AFX_DATA_MAP
}

BEGIN_MESSAGE_MAP(COverrideVelocityAtPosDlg, CDialog)
	//{{AFX_MSG_MAP(COverrideVelocityAtPosDlg)
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	ON_CBN_SELCHANGE(IDC_CBO_SEL_AXIS, OnSelchangeCboSelAxis)
	ON_WM_TIMER()
	ON_BN_CLICKED(IDC_BTN_LOAD_FILE, OnBtnLoadFile)
	ON_WM_DESTROY()
	ON_BN_CLICKED(IDC_BTN_POS_SET, OnBtnPosSet)
	ON_BN_CLICKED(IDC_CHK_SERVO_ON, OnChkServoOn)
	ON_BN_CLICKED(IDC_BTN_OVER_VEL_AT_POS, OnBtnOverVelAtPos)
	ON_BN_CLICKED(IDC_BTN_OVER_VEL_AT_MPOS, OnBtnOverVelAtMpos)
	ON_BN_CLICKED(IDC_BTN_STOP, OnBtnStop)
	ON_BN_CLICKED(IDC_BTN_OVER_DATA_ADD, OnBtnOverDataAdd)
	ON_BN_CLICKED(IDC_BTN_OVER_DATA_CLR, OnBtnOverDataClr)
	ON_LBN_DBLCLK(IDC_LST_OVER_DATA, OnDblclkLstOverData)
	ON_BN_CLICKED(IDC_CHK_OVER_MULTI, OnChkOverMulti)
	//}}AFX_MSG_MAP
	ON_COMMAND_RANGE(IDC_RDO_ABS, IDC_RDO_REL, OnRdoAbsRelMode)
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// COverrideVelocityAtPosDlg message handlers

BOOL COverrideVelocityAtPosDlg::OnInitDialog()
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

void COverrideVelocityAtPosDlg::OnPaint() 
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
HCURSOR COverrideVelocityAtPosDlg::OnQueryDragIcon()
{
	return (HCURSOR) m_hIcon;
}

void COverrideVelocityAtPosDlg::OnDestroy() 
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
void COverrideVelocityAtPosDlg::OnSelchangeCboSelAxis() 
{
	m_lAxisNo = m_cboSelAxis.GetCurSel();		// 축 선택 ComboBox에서 선택된 축번호를 제어할 축 번호 변수에 설정합니다.

	//++ 지정한 축번호의 모듈ID를 반환합니다.
	// [INFO] 여러개의 정보를 읽는 함수 사용시 불필요한 정보는 NULL(0)을 입력하면 됩니다.
	AxmInfoGetAxis(m_lAxisNo, NULL, NULL, &m_dwModuleID);	

	UpdateState();		
}

// ++ =======================================================================
// >> OnBtnLoadFile() : "Load File"버튼 클릭시 호출되는 핸들러 함수.
//  - 임의 위치에 있는 Mot(AXM에서 사용하는 설정파일 형식) 파일을 불러옵니다.
//  - 이 함수를 통해 임의의 Mot파일을 불러오면 모션축의 설정값들이 Mot파일의 
//    설정값들로 일괄 변경됩니다.
// --------------------------------------------------------------------------
void COverrideVelocityAtPosDlg::OnBtnLoadFile() 
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
// >> OnBtnPosSet() : "Position Setting"버튼 클릭시 호출되는 핸들러 함수.
//  - 선택된 축의 위치정보를 지정한 값으로 설정합니다.
//  - AxmStatusSetPosMatch함수는 AxmStatusSetCmdPos, AxmStatusSetActPos 함수를 
//    사용하는것과 동일한 효과를 냅니다.
// --------------------------------------------------------------------------
void COverrideVelocityAtPosDlg::OnBtnPosSet() 
{
	double dSetPos;
	dSetPos = GetDlgItemDouble(IDC_EDT_SET_POS);

	//AxmStatusSetCmdPos(m_lAxisNo, dSetPos);
	//AxmStatusSetActPos(m_lAxisNo, dSetPos);
	//++ Command위치와 Actual위치를 지정한 값으로 설정합니다.
	AxmStatusSetPosMatch(m_lAxisNo, dSetPos);		
}

// ++ =======================================================================
// >> OnChkServoOn() : "Servo On"버튼 클릭시 호출되는 핸들러 함수.
//  - 선택된 축을 체크버튼의 상태에 따라 서보 On/Off 합니다.
// --------------------------------------------------------------------------
void COverrideVelocityAtPosDlg::OnChkServoOn() 
{
	DWORD dwOnOff;	
	dwOnOff = IsDlgButtonChecked(IDC_CHK_SERVO_ON);
	//++ 지정 축의 Servo On/Off 신호를 출력합니다.
	AxmSignalServoOn(m_lAxisNo, dwOnOff);		
}

// ++ =======================================================================
// >> OnRdoAbsRelMode(...) : "Absolute/Relative"버튼 클릭시 호출되는 핸들러 함수.
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
void COverrideVelocityAtPosDlg::OnRdoAbsRelMode(UINT nID) 
{
	DWORD dwAbsRelMode = nID - IDC_RDO_ABS;
	
	//++ 지정 축의 구동 좌표계를 설정합니다. 
	// dwAbsRelMode : (0)POS_ABS_MODE - 현재 위치와 상관없이 지정한 위치로 절대좌표 이동합니다.
	//                (1)POS_REL_MODE - 현재 위치에서 지정한 양만큼 상대좌표 이동합니다.
	AxmMotSetAbsRelMode(m_lAxisNo, dwAbsRelMode);
}

// ++ =======================================================================
// >> OnChkOverMulti() : "Override Vel At Multi Pos Use"버튼 클릭시 호출되는 핸들러 함수.
//  - 선택한 축에 오버라이드 할 함수의 종류를 설정합니다.
//  - 오버라이드 함수에 따라 필요한 인자들을 활성화/비활성화 시킵니다. 
// --------------------------------------------------------------------------
void COverrideVelocityAtPosDlg::OnChkOverMulti() 
{
	BOOL bEnableMulti;
	bEnableMulti = IsDlgButtonChecked(IDC_CHK_OVER_MULTI);

	m_edtOverPos.EnableWindow(!bEnableMulti);
	m_edtOverVel.EnableWindow(!bEnableMulti);
	m_btnOverVelAtPos.EnableWindow(!bEnableMulti);

	m_cboOverMode.EnableWindow(bEnableMulti);
	m_lstOverData.EnableWindow(bEnableMulti);
	m_btnOverVelAtMPos.EnableWindow(bEnableMulti);
	m_btnOverDataAdd.EnableWindow(bEnableMulti);
	m_btnOverDataClr.EnableWindow(bEnableMulti);
	m_edtOverPosAdd.EnableWindow(bEnableMulti);
	m_edtOverVelAdd.EnableWindow(bEnableMulti);
}

// ++ =======================================================================
// >> OnBtnOverVelAtPos() : "Override At Pos"버튼 클릭시 호출되는 핸들러 함수.
//  - 선택한 축에 지정한 위치에서 정확하게 오버라이드하는 구동을 시작합니다.
// --------------------------------------------------------------------------
void COverrideVelocityAtPosDlg::OnBtnOverVelAtPos() 
{
	DWORD	dwRetCode;
	CString strData;
	long	lCampTarget;
	double	dMovePos, dMoveVel, dMoveAcc, dMoveDec, dOverPos, dOverVel;
	
	dMovePos	= GetDlgItemDouble(IDC_EDT_MOVE_POS);
	dMoveVel	= GetDlgItemDouble(IDC_EDT_MOVE_VEL);
	dMoveAcc	= GetDlgItemDouble(IDC_EDT_MOVE_ACC);
	dMoveDec	= GetDlgItemDouble(IDC_EDT_MOVE_DEC);

	dOverPos	= GetDlgItemDouble(IDC_EDT_OVER_POS);
	dOverVel	= GetDlgItemDouble(IDC_EDT_OVER_VEL);

	lCampTarget	= ConvertComboToAxm(&m_cboCampTarget);
	//++ 선택한 축에 모션 구동중 지정한 위치에서 속도 오버라이드 하는 구동을 시작합니다.
	dwRetCode	= AxmOverrideVelAtPos(m_lAxisNo, dMovePos, dMoveVel, dMoveAcc, dMoveDec, dOverPos, dOverVel, lCampTarget);	
	if(dwRetCode != AXT_RT_SUCCESS){
		strData.Format("AxmOverrideVelAtPos return error[Code:%04d]", dwRetCode);
		MessageBox(strData, "Error", MB_OK | MB_ICONERROR);
	}
}

#define MAX_OVER_MULTI_POS	50
// ++ =======================================================================
// >> OnBtnOverVelAtMpos() : "Multi At Pos"버튼 클릭시 호출되는 핸들러 함수.
//  - 선택한 축에 여러개의 지정한 위치에서 정확하게 오버라이드하는 구동을 시작합니다.
//  - 실제 오버라이드 함수의 위치지정 갯수 제한은 없으나 예제 구현 편의상 50개로
//    제한하였습니다.
// --------------------------------------------------------------------------
void COverrideVelocityAtPosDlg::OnBtnOverVelAtMpos() 
{	
	DWORD	dwRetCode;
	CString strData;
	long	lCampTarget, lOverMode, lArraySize;
	double	dMovePos, dMoveVel, dMoveAcc, dMoveDec;
	double  daOverPos[MAX_OVER_MULTI_POS], daOverVel[MAX_OVER_MULTI_POS];
	
	dMovePos	= GetDlgItemDouble(IDC_EDT_MOVE_POS);
	dMoveVel	= GetDlgItemDouble(IDC_EDT_MOVE_VEL);
	dMoveAcc	= GetDlgItemDouble(IDC_EDT_MOVE_ACC);
	dMoveDec	= GetDlgItemDouble(IDC_EDT_MOVE_DEC);
	
	lCampTarget	= ConvertComboToAxm(&m_cboCampTarget);		
	lOverMode	= ConvertComboToAxm(&m_cboOverMode);	
	lArraySize	= ConvertListBoxToArray(&m_lstOverData, daOverPos, daOverVel);
	
	//++ 선택한 축에 모션 구동중 여러개의 지정한 위치에서 속도 오버라이드 하는 구동을 시작합니다.
	//   함수 사용시 진행 방향 기준으로 먼저 도달하는 포지션부터 배열에 입력이 되어야 합니다.
    //   dwOverrideMode : (0)OVERRIDE_POS_START 지정한 위치에서 지정한 속도로 오버라이드 시작함        
    //                  : (1)OVERRIDE_POS_END 지정한 위치에서 지정한 속도가 되도록 미리 오버라이드 시작함
	dwRetCode	= AxmOverrideVelAtMultiPos(m_lAxisNo, dMovePos, dMoveVel, dMoveAcc, dMoveDec, lArraySize, daOverPos, daOverVel, lCampTarget, lOverMode);		
	if(dwRetCode != AXT_RT_SUCCESS){
		strData.Format("AxmOverrideVelAtMultiPos return error[Code:%04d]", dwRetCode);
		MessageBox(strData, "Error", MB_OK | MB_ICONERROR);
	}
}

// ++ =======================================================================
// >> OnBtnPosStop() : "Move Stop"버튼 클릭시 호출되는 핸들러 함수.
//  - 선택한 축에 구동정지 함수를 호출하여 구동을 감속정지합니다.
// --------------------------------------------------------------------------
void COverrideVelocityAtPosDlg::OnBtnStop() 
{
	//++ 지정한 축의 구동을 감속정지합니다.
	AxmMoveSStop(m_lAxisNo);		
}

// ++ =======================================================================
// >> OnBtnOverDataAdd() : "<< Add Item"버튼 클릭시 호출되는 핸들러 함수.
//  - 속도 오버라이드 정보를 ListBox에 등록합니다. 
// --------------------------------------------------------------------------
void COverrideVelocityAtPosDlg::OnBtnOverDataAdd() 
{
	CString strData;
	double	dOverPos, dOverVel;

	dOverPos = GetDlgItemDouble(IDC_EDT_OVER_POS_ADD);
	dOverVel = GetDlgItemDouble(IDC_EDT_OVER_VEL_ADD);

	strData.Format("%11.3lf, %11.3lf", dOverPos, dOverVel);
	m_lstOverData.AddString(strData);
}

// ++ =======================================================================
// >> OnDblclkLstOverData() : ListBox 콘트롤 마우스 더블클릭시 호출되는 핸들러 함수.
//  - 등록된 속도 오버라이드 정보중 선택된 Item을 지울때 호출됩니다.
//  - List Box 콘트롤에서 마우스 포인트를 삭제할 Item 으로 이동한 후 마우스 
//    왼쪽 버튼을 더블클릭하면 해당 Item이 선택 삭제됩니다.
// --------------------------------------------------------------------------
void COverrideVelocityAtPosDlg::OnDblclkLstOverData() 
{
	long lSelItem;
	
	lSelItem = m_lstOverData.GetCurSel();	
	m_lstOverData.DeleteString(lSelItem);
}

// ++ =======================================================================
// >> OnDblclkLstOverData() : "All Clear Item"버튼 클릭시 호출되는 핸들러 함수.
//  - 등록된 오버라이드 데이타를 모두 지웁니다.
// --------------------------------------------------------------------------
void COverrideVelocityAtPosDlg::OnBtnOverDataClr() 
{
	m_lstOverData.ResetContent();
}

// ++ =======================================================================
// >> OnTimer(...) : 타이머 이벤트 핸들러 함수.
//  - 일정한 주기로 변경되는 위치/속도/정보등을 Control에 반영합니다.
// --------------------------------------------------------------------------
void COverrideVelocityAtPosDlg::OnTimer(UINT nIDEvent) 
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
BOOL COverrideVelocityAtPosDlg::InitLibrary()
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
BOOL COverrideVelocityAtPosDlg::AddAxisInfo()
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
		case AXT_SMC_4V04:			strData.Format("%02ld-[PCIB-QI4A]",i);	break;
		case AXT_SMC_2V04:			strData.Format("%02ld-[PCIB-QI2A]",i);	break;
		case AXT_SMC_R1V04A4:		strData.Format("%02ld-[RTEX-A4N]   : Not support", i);	break;
		case AXT_SMC_R1V04A5:		strData.Format("%02ld-[RTEX-A5N]   : Not support", i);	break;
		case AXT_SMC_R1V04:			strData.Format("%02ld-(RTEX-PM)    : Not support", i);	break;
		case AXT_SMC_R1V04PM2Q:		strData.Format("%02ld-(RTEX-PM2Q)  : Not support", i);	break;
		case AXT_SMC_R1V04PM2QE:	strData.Format("%02ld-(RTEX-PM2QE) : Not support", i);	break;
		case AXT_SMC_R1V04MLIISV:	strData.Format("%02ld-[MLII-SGDV]  : Not support", i);	break;
		case AXT_SMC_R1V04MLIIPM:	strData.Format("%02ld-(MLII-PM)    : Not support", i);	break;
		case AXT_SMC_R1V04MLIICL:	strData.Format("%02ld-[MLII-CSDL]  : Not support", i);	break;
		case AXT_SMC_R1V04MLIICR:	strData.Format("%02ld-[MLII-CSDH]  : Not support", i);	break;
		case AXT_SMC_R1V04SIIIHMIV:	strData.Format("%02ld-[SIIIH-MRJ4] : Not support", i);	break;
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
	return TRUE;
}

// ++ =======================================================================
// >> InitControl() : Control들에 초기값을 설정하는 함수.
//  - Control 변수들을 등록하고, 초기 설정값들을 설정합니다.
// --------------------------------------------------------------------------
BOOL COverrideVelocityAtPosDlg::InitControl()
{
	m_cboSelAxis.SetCurSel(m_lAxisNo);

	// Edit Control에 초기값 설정
	SetDlgItemDouble(IDC_EDT_SET_POS,  0.0);	
	SetDlgItemDouble(IDC_EDT_MOVE_POS, 1000.0);
	SetDlgItemDouble(IDC_EDT_MOVE_VEL, 100.0);
	SetDlgItemDouble(IDC_EDT_MOVE_ACC, 200.0);
	SetDlgItemDouble(IDC_EDT_MOVE_DEC, 200.0);

	SetDlgItemDouble(IDC_EDT_OVER_POS, 200.0);
	SetDlgItemDouble(IDC_EDT_OVER_VEL, 200.0);

	m_cboOverMode.SetCurSel(0);
	m_cboCampTarget.SetCurSel(0);
	
	SetDlgItemDouble(IDC_EDT_OVER_POS_ADD, 300.0);
	SetDlgItemDouble(IDC_EDT_OVER_VEL_ADD, 300.0);

	m_ftItemList.CreateFont(-12, 0, 0, 0, FW_NORMAL, FALSE, FALSE, 0, 0, 0, 0, 0, 0, "Courier");
	m_lstOverData.SetFont(&m_ftItemList, TRUE);

	return TRUE;
}

// ++ =======================================================================
// >> UpdateState() : 지정한 축의 설정값들을 읽어 Control과 일치시키는 함수.
//  - 축번호가 변경되었을 때 변경한 축의 설정값들과 Control들과 일치시키는 
//    역할을하는 함수입니다.
//  - 지정한 축의 모델별 제약들을 Control에 반영하는 역할을 합니다.
//  - 프로그램 초기 실행시, Mot파일 불러올 때, 축 번호 바뀔 때 사용됩니다.
// --------------------------------------------------------------------------
BOOL COverrideVelocityAtPosDlg::UpdateState()
{
	if(m_lAxisCount < 1)	return FALSE;	

	DWORD dwAbsRelMode = POS_ABS_MODE, dwProfile = ASYM_S_CURVE_MODE, dwOnOff = 0;

	//++ 지정한 축의 서보온 상태를 반환합니다.
	AxmSignalIsServoOn(m_lAxisNo, &dwOnOff);
	CheckDlgButton(IDC_CHK_SERVO_ON, dwOnOff);

	//++ 지정한 축의 구동 좌표계 설정값을 확인합니다.
	AxmMotGetAbsRelMode(m_lAxisNo, &dwAbsRelMode);	
	CheckRadioButton(IDC_RDO_ABS, IDC_RDO_REL, IDC_RDO_ABS + dwAbsRelMode);
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
DWORD COverrideVelocityAtPosDlg::ConvertComboToAxm(CComboBox *pCboItem)
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
long COverrideVelocityAtPosDlg::ConvertAxmToCombo(CComboBox *pCboItem, DWORD dwCurData)
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
void COverrideVelocityAtPosDlg::SetDlgItemDouble(int nID, double value, int nPoint)
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
double COverrideVelocityAtPosDlg::GetDlgItemDouble(int nID)
{
	double dRet;
	CString sTemp;
	GetDlgItem(nID)->GetWindowText(sTemp);
	dRet = atof((LPCTSTR)sTemp);
	return dRet;
}

// ++ =======================================================================
// >> ConvertListBoxToArray(...) : 지정한 콘트롤에 설정되어 있는 텍스트를 
//    오버라이드 정보값으로  변환하여 반환하는 함수.
//  - ListBox 콘트롤에 설정된 텍스트를 두개의 오버라이드 정보값으로 변환하여
//    코드를 간결하게 구현하였습니다.
//  - 실제 오버라이드 함수의 위치지정 갯수 제한은 없으나 예제구현 편의상 50개로
//    제한하였습니다.
// --------------------------------------------------------------------------
long COverrideVelocityAtPosDlg::ConvertListBoxToArray(CListBox *pLstItem, double *dpOverVel, double *dpOverAcc)
{
	if(pLstItem == NULL)	return 0;
	if(dpOverVel == NULL)	return 0;
	if(dpOverAcc == NULL)	return 0;
	
	CString strData;
	int		nSection, nLength;
	long	lCount, lArraySize;	
	
	lArraySize = pLstItem->GetCount();
	if(lArraySize == 0)	return 0;

	for(lCount = 0; lCount < lArraySize; lCount++){
		if(lCount == MAX_OVER_MULTI_POS){
			lArraySize = MAX_OVER_MULTI_POS;
			break;
		}
		pLstItem->GetText(lCount, strData);	

		nLength		= strData.GetLength();
		nSection	= strData.Find(",", 0);		
		dpOverVel[lCount] = atof(strData.Mid(0, nSection));
		dpOverAcc[lCount] = atof(strData.Mid(nSection + 1, nLength));
	}

	return lArraySize;
}


