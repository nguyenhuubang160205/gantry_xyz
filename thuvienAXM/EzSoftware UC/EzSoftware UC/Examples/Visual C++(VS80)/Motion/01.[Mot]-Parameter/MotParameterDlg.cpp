// MotParameterDlg.cpp : implementation file
//
// **************************************************************************
// >> [일자]: 2016.01.05
// >> [개요]: 이 예제는 모터 구동에 관련된 파라메타들을 설정변경한 후 파일로  
//    저장 또는 불러오기를 할 수 있도록 작성된 예제입니다.
// >> [중요]: 신호설정 함수 사용시 주의사항 
//     1) 제품의 종류에 따라서 신호설정에 사용되는 인자가 달라질 수 있습니다.
//     2) 네트웍 제품의 리미트 신호나 원점신호의 레벨 변경은 서보팩 파라메타를 
//        변경해서 바꿀수 있습니다.
// **************************************************************************

#include "stdafx.h"
#include "MotParameter.h"
#include "MotParameterDlg.h"

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
#include "../../../../AXL(Library)/C, C++/AXDev.h"
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
#define Z_PHASE_BIT		1

/////////////////////////////////////////////////////////////////////////////
// CMotParameterDlg dialog

CMotParameterDlg::CMotParameterDlg(CWnd* pParent /*=NULL*/)
	: CDialog(CMotParameterDlg::IDD, pParent)
{
	//{{AFX_DATA_INIT(CMotParameterDlg)
		// NOTE: the ClassWizard will add member initialization here
	//}}AFX_DATA_INIT
	// Note that LoadIcon does not require a subsequent DestroyIcon in Win32
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);

	//++
	m_lAxisNo		= -1;					// 제어할 축 번호 초기화
	m_lAxisCount	= 0;					// 제어 가능한 축갯수 초기화
	m_dwModuleID	= 0;					// 제어할 축의 모듈ID 초기화
}

void CMotParameterDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CMotParameterDlg)
	DDX_Control(pDX, IDC_EDT_SW_POS_P, m_edtSWPosP);
	DDX_Control(pDX, IDC_EDT_SW_POS_N, m_edtSWPosN);
	DDX_Control(pDX, IDC_CHK_INP, m_chkInp);
	DDX_Control(pDX, IDC_CHK_EMG, m_chkEmg);
	DDX_Control(pDX, IDC_CHK_ELIMIT_P, m_chkELimitP);
	DDX_Control(pDX, IDC_CHK_ELIMIT_N, m_chkELimitN);
	DDX_Control(pDX, IDC_CHK_ALARM, m_chkAlarm);
	DDX_Control(pDX, IDC_CHK_Z_PHASE, m_chkZPhase);
	DDX_Control(pDX, IDC_CBO_PULSE, m_cboPulse);
	DDX_Control(pDX, IDC_CBO_ENCODER, m_cboEncoder);
	DDX_Control(pDX, IDC_CBO_ABSREL, m_cboAbsRel);
	DDX_Control(pDX, IDC_CBO_PROFILE, m_cboProfile);
	DDX_Control(pDX, IDC_CBO_Z_PHASE_USE, m_cboZPhaseUse);
	DDX_Control(pDX, IDC_CBO_Z_PHASE_LEV, m_cboZPhaseLev);

	DDX_Control(pDX, IDC_CBO_SERVO_ON, m_cboServoOn);
	DDX_Control(pDX, IDC_CBO_INP, m_cboInp);
	DDX_Control(pDX, IDC_CBO_STOP_MODE, m_cboStopMode);
	DDX_Control(pDX, IDC_CBO_STOP_LEVEL, m_cboStopLevel);
	DDX_Control(pDX, IDC_CBO_ELIMIT_P, m_cboELimitP);
	DDX_Control(pDX, IDC_CBO_ELIMIT_N, m_cboELimitN);
	DDX_Control(pDX, IDC_CBO_ALARM_RESET, m_cboAlarmReset);
	DDX_Control(pDX, IDC_CBO_ALARM, m_cboAlarm);
	DDX_Control(pDX, IDC_CBO_SEL_AXIS, m_cboSelAxis);
	DDX_Control(pDX, IDC_CBO_ENCODER_TYPE, m_cboEncoderType);

	DDX_Control(pDX, IDC_CBO_HOME_SIGNAL, m_cboHomeSignal);
	DDX_Control(pDX, IDC_CBO_HOME_LEVEL,  m_cboHomeLevel);
	DDX_Control(pDX, IDC_CBO_HOME_DIR, m_cboHomeDir);
	//}}AFX_DATA_MAP
	DDX_Control(pDX, IDC_CBO_SW_SEL, m_cboSWSel);
	DDX_Control(pDX, IDC_CBO_SW_STOP_MODE, m_cboSWStopMode);
	DDX_Control(pDX, IDC_CHK_SW_ENABLE, m_chkSWEnable);
}

BEGIN_MESSAGE_MAP(CMotParameterDlg, CDialog)
	//{{AFX_MSG_MAP(CMotParameterDlg)
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	ON_BN_CLICKED(IDC_BTN_LOAD_FILE, OnBtnLoadFile)
	ON_CBN_SELCHANGE(IDC_CBO_SEL_AXIS, OnSelchangeCboSelAxis)
	ON_WM_TIMER()
	ON_WM_DESTROY()
	ON_BN_CLICKED(IDC_BTN_APPLY_PULSE, OnBtnApplyPulse)
	ON_BN_CLICKED(IDC_BTN_APPLY_SIGNAL, OnBtnApplySignal)
	ON_BN_CLICKED(IDC_BTN_APPLY_HOME, OnBtnApplyHome)
	ON_BN_CLICKED(IDC_BTN_APPLY_SOFTLIMIT, OnBtnApplySoftlimit)
	ON_BN_CLICKED(IDC_BTN_APPLY_USER_PARA, OnBtnApplyUserPara)
	ON_BN_CLICKED(IDC_BTN_APPLY_ALL_AXES, OnBtnApplyAllAxes)
	ON_BN_CLICKED(IDC_BTN_SAVE_FILE, OnBtnSaveFile)
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CMotParameterDlg message handlers

BOOL CMotParameterDlg::OnInitDialog()
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

void CMotParameterDlg::OnPaint() 
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
HCURSOR CMotParameterDlg::OnQueryDragIcon()
{
	return (HCURSOR) m_hIcon;
}

void CMotParameterDlg::OnDestroy() 
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
void CMotParameterDlg::OnSelchangeCboSelAxis() 
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
void CMotParameterDlg::OnBtnLoadFile() 
{
	CString	temp;
	CFileDialog dlg(TRUE, "Mot", NULL, OFN_HIDEREADONLY, "AXM File (*.mot)|*.mot|All Files (*.*)|*.*||");
	
	if (dlg.DoModal() == IDOK){
		LPTSTR strFilename;
		temp		= dlg.GetPathName();
		strFilename	= temp.GetBuffer(0);

		//++ 함수 실행 성공시 지정한 Mot파일의 설정값으로 모션축 설정이 일괄 변경됩니다.
		if (AxmMotLoadParaAll(strFilename) != AXT_RT_SUCCESS)
			AfxMessageBox("File load fail!");		
		else
			UpdateState();		// 변경된 모션축의 상태와 Control들의 상태를 일치시킵니다.
	}		
}

// ++ =======================================================================
// >> OnBtnSaveFile() : "Save File"버튼 클릭시 호출되는 핸들러 함수.
//  - AXL 라이브러리 함수를 이용해 변경된 설정값들을 지정한 위치에 
//    Mot(AXM에서 사용하는 설정파일 형식) 파일 형식으로 저장합니다.
// --------------------------------------------------------------------------
void CMotParameterDlg::OnBtnSaveFile() 
{
	CString temp;
	CFileDialog dlg(FALSE, "mot", NULL, OFN_HIDEREADONLY, "AXM File (*.mot)|*.mot|All Files (*.*)|*.*||");
	
	if(dlg.DoModal() == IDOK)
	{
		temp = dlg.GetPathName();
		LPTSTR strFilename = temp.GetBuffer(0);
		//++ 함수 실행 성공시 각각의 모션축 설정값으로 지정한 Mot파일을 생성 및 저장 됩니다.
		if (AXT_RT_SUCCESS != AxmMotSaveParaAll(strFilename))
			AfxMessageBox( "File save fail!");
		temp.ReleaseBuffer();	
	}		
}

// ++ =======================================================================
// >> OnBtnApplyPulse() : "Pulse/Encoder Method && Move Parameter Setting"
//    그룹의 "Apply" 버튼을 클릭했을 때 호출되는 핸들러 함수.
//  - 해당 그룹의 모든 설정값들을 각각의 AXL 함수들을 이용하여 적용합니다.
// ※ [CAUTION] 각 콘트롤(ComboBox, Edit) 변경시 AXL에 즉시 반영되지않습니다.
//    반드시 해당 그룹의 "Apply"버튼을 클릭해야 설정변경값이 AXL에 반영됩니다.
// --------------------------------------------------------------------------
void CMotParameterDlg::OnBtnApplyPulse() 
{
	long	lPulse = 1;
	double	dUnit = 1.0, dMinVel = 1.0, dMaxVel = 100.0;
	DWORD	dwMethod = 0, dwAbsRelMode = 0, dwProfileMode = 0;	
	
	if(m_cboPulse.IsWindowEnabled() == TRUE){ 
		dwMethod = ConvertComboToAxm(&m_cboPulse);
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
		
	if(m_cboEncoder.IsWindowEnabled() == TRUE){
		dwMethod = ConvertComboToAxm(&m_cboEncoder);
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

	if(m_cboAbsRel.IsWindowEnabled() == TRUE){
		dwAbsRelMode = ConvertComboToAxm(&m_cboAbsRel);
		//++ 지정 축의 구동 좌표계를 설정합니다. 
		// dwAbsRelMode : (0)POS_ABS_MODE - 현재 위치와 상관없이 지정한 위치로 절대좌표 이동합니다.
		//                (1)POS_REL_MODE - 현재 위치에서 지정한 양만큼 상대좌표 이동합니다.
		AxmMotSetAbsRelMode(m_lAxisNo, dwAbsRelMode);
	}
	if(m_cboProfile.IsWindowEnabled() == TRUE){
		dwProfileMode = ConvertComboToAxm(&m_cboProfile);
		//++ 지정 축의 구동 속도 프로파일 모드를 설정합니다.
		// uProfileMode : (0)SYM_TRAPEZOID_MODE  - Symmetric Trapezoid
		//                (1)ASYM_TRAPEZOID_MODE - Asymmetric Trapezoid
		//                (2)QUASI_S_CURVE_MODE  - Symmetric Quasi-S Curve
		//                (3)SYM_S_CURVE_MODE    - Symmetric S Curve
		//                (4)ASYM_S_CURVE_MODE   - Asymmetric S Curve
		AxmMotSetProfileMode(m_lAxisNo, dwProfileMode);
	}

	dMinVel = GetDlgItemDouble(IDC_EDT_MIN_VEL);
	//++ 지정 축의 초기 구동속도를 설정합니다.
	AxmMotSetMinVel(m_lAxisNo, dMinVel);
	
	dMaxVel = GetDlgItemDouble(IDC_EDT_MAX_VEL);
	//++ 지정 축의 최대 구동속도를 설정합니다.
	AxmMotSetMaxVel(m_lAxisNo, dMaxVel);

	lPulse	= GetDlgItemInt(IDC_EDT_MOVE_PULSE);	
	dUnit	= GetDlgItemDouble(IDC_EDT_MOVE_UNIT);
	//++ 지정 축의 거리/속도/가속도의 제어단위를 설정합니다.
	AxmMotSetMoveUnitPerPulse(m_lAxisNo, dUnit, lPulse);
}

// ++ =======================================================================
// >> OnBtnApplySignal() : "Input/Output Signal Setting" 그룹의 "Apply" 버튼을 
//    클릭했을 때 호출되는 핸들러 함수.
//  - 해당 그룹의 모든 설정값들을 각각의 AXL 함수들을 이용하여 적용합니다.
// ※ [CAUTION] 각 콘트롤(ComboBox, Edit) 변경시 AXL에 즉시 반영되지않습니다.
//    반드시 해당 그룹의 "Apply"버튼을 클릭해야 설정변경값이 AXL에 반영됩니다.
// --------------------------------------------------------------------------
void CMotParameterDlg::OnBtnApplySignal() 
{
	DWORD	dwUse = 0, dwLevel = 0, dwRetCode;
	DWORD	dwStopMode = 0, dwPosigitaveLevel = 0, dwNegativeLevel = 0;	
	DWORD	dwEncoderType = 0;

	dwUse	= ConvertComboToAxm(&m_cboInp);
	//++ 지정 축의 Inposition(위치결정완료) 신호 Active Level/사용유무를 설정합니다.
	// - Inposition 신호를 사용안함으로 설정하면 모션제어 칩에서 펄스출력이 완료될 때 즉시구동 종료됩니다.
	// ※ [CAUTION] Inposition 신호를 사용함으로 설정하면 모션제어 칩에서 펄스출력이 완료된 후 서보팩으로 부터 
	//              Inposition(위치결정완료) 신호가 Active될 때 까지 모션 구동중으로 됩니다.
	// ※ [CAUTION] Inposition 신호를 사용할 때 Active Level이 맞지않으면 최초 한번 구동 후 모션구동이 종료되지않아 
	//              다음 구동을 할 수 없게 됩니다. 
	AxmSignalSetInpos(m_lAxisNo, dwUse);	

	if (m_cboAlarmReset.IsWindowEnabled()) 
	{
		dwLevel	= ConvertComboToAxm(&m_cboAlarmReset);
		//++ 지정 축의 Alarm Reset 신호 Active Level을 설정합니다.
		AxmSignalSetServoAlarmResetLevel(m_lAxisNo, dwLevel);
	}

	//++ 지정 축의 (+/-) End Limit 신호 Active Level/사용유무를 확인합니다.
	dwRetCode = AxmSignalGetLimit(m_lAxisNo, &dwStopMode, NULL, NULL);
	if(dwRetCode == AXT_RT_SUCCESS){
		dwNegativeLevel		= ConvertComboToAxm(&m_cboELimitN);
		dwPosigitaveLevel	= ConvertComboToAxm(&m_cboELimitP);
		//++ 지정 축의 (-) End Limit 신호 Active Level/사용유무를 설정합니다.
		AxmSignalSetLimit(m_lAxisNo, dwStopMode, dwPosigitaveLevel, dwNegativeLevel);
	}

	if (m_cboZPhaseLev.IsWindowEnabled()) 
	{
		dwLevel		= ConvertComboToAxm(&m_cboZPhaseLev);
		//++ 지정 축의 Z상 Active Level을 설정합니다.
		AxmSignalSetZphaseLevel(m_lAxisNo, dwLevel);	
	}

	dwStopMode	= ConvertComboToAxm(&m_cboStopMode);
	dwLevel		= ConvertComboToAxm(&m_cboStopLevel);
	//++ 지정 축의 Emergency 신호 Active Level/사용유무를 설정합니다.
	AxmSignalSetStop(m_lAxisNo, dwStopMode, dwLevel);

	dwLevel		= ConvertComboToAxm(&m_cboServoOn);
	//++ 지정 축의 Servo On/Off 신호 Active Level을 설정합니다.
	dwRetCode	= AxmSignalSetServoOnLevel(m_lAxisNo, dwLevel);

	if (m_cboAlarm.IsWindowEnabled())
	{
		dwUse	= ConvertComboToAxm(&m_cboAlarm);
		//++ 지정 축의 Alarm Reset 신호 Active Level을 설정합니다.
		AxmSignalSetServoAlarm(m_lAxisNo, dwUse);
	}

	dwEncoderType	= ConvertComboToAxm(&m_cboEncoderType);
	//++ 지정 축의 Encoder Input Type를 설정합니다.
    // dwEncoderType : (0)TYPE_INCREMENTAL
	//                 (1)TYPE_ABSOLUTE
	AxmSignalSetEncoderType(m_lAxisNo, dwEncoderType);
}

// ++ =======================================================================
// >> OnBtnApplyHome() : "Home Search Setting" 그룹의 "Apply" 버튼을 클릭했을 때
//    호출되는 핸들러 함수.
//  - 해당 그룹의 모든 설정값들을 각각의 AXL 함수들을 이용하여 적용합니다.
// ※ [CAUTION] 각 콘트롤(ComboBox, Edit) 변경시 AXL에 즉시 반영되지않습니다.
//    반드시 해당 그룹의 "Apply"버튼을 클릭해야 설정변경값이 AXL에 반영됩니다.
// --------------------------------------------------------------------------
void CMotParameterDlg::OnBtnApplyHome() 
{
	long	lHomeDir = 0;
	DWORD	dwHomeSignal = 0, dwHomeLevel = 0, dwZphas = 0;
	double	dHomeClrTime = 1000.0, dHomeOffset = 0.0;

	dwHomeLevel		= ConvertComboToAxm(&m_cboHomeLevel);
	//++ 지정 축의 원점신호 Active Level을 설정합니다.
	AxmHomeSetSignalLevel(m_lAxisNo, dwHomeLevel);

	dwHomeSignal	= ConvertComboToAxm(&m_cboHomeSignal);
	lHomeDir		= ConvertComboToAxm(&m_cboHomeDir);
	dwZphas			= ConvertComboToAxm(&m_cboZPhaseUse);

	dHomeClrTime	= GetDlgItemDouble(IDC_EDT_HOME_CLR_TIME);
	dHomeOffset		= GetDlgItemDouble(IDC_EDT_HOME_OFFSET);
	//++ 지정 축의 원점검색 관련 정보들을 설정합니다.
	AxmHomeSetMethod(m_lAxisNo, lHomeDir, dwHomeSignal, dwZphas, dHomeClrTime, dHomeOffset);
}

// ++ =======================================================================
// >> OnBtnApplySoftlimit() : "Software Limit Setting " 그룹의 "Apply" 버튼을 
//    클릭했을 때 호출되는 핸들러 함수.
//  - 해당 그룹의 모든 설정값들을 각각의 AXL 함수들을 이용하여 적용합니다.
// ※ [CAUTION] 각 콘트롤(ComboBox, Edit) 변경시 AXL에 즉시 반영되지않습니다.
//    반드시 해당 그룹의 "Apply"버튼을 클릭해야 설정변경값이 AXL에 반영됩니다.
// --------------------------------------------------------------------------
void CMotParameterDlg::OnBtnApplySoftlimit() 
{
	DWORD	dwRetCode;
	DWORD	dwUse = 0, dwStopMode = 0, dwSelection = 0;
	double	dPositivePos = 0.0, dNegativePos = 0.0;

	//++ 지정한 축에 Software Limit기능을 확인합니다.
	dwRetCode = AxmSignalGetSoftLimit(m_lAxisNo, &dwUse, &dwStopMode, &dwSelection, NULL, NULL);
	if(dwRetCode == AXT_RT_SUCCESS){
		dNegativePos = GetDlgItemDouble(IDC_EDT_SW_POS_N);
		dPositivePos = GetDlgItemDouble(IDC_EDT_SW_POS_P);
		dwStopMode = ConvertComboToAxm(&m_cboSWStopMode);
		dwSelection = ConvertComboToAxm(&m_cboSWSel);
		dwUse = m_chkSWEnable.GetCheck();
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

// ++ =======================================================================
// >> OnBtnApplyUserPara() : "User Move Parameter Setting " 그룹의 "Apply"  
//    버튼을 클릭했을 때 호출되는 핸들러 함수.
//  - 해당 그룹의 모든 설정값들을 각각의 AXL 함수들을 이용하여 적용합니다.
// ※ [CAUTION] 각 콘트롤(ComboBox, Edit) 변경시 AXL에 즉시 반영되지않습니다.
//    반드시 해당 그룹의 "Apply"버튼을 클릭해야 설정변경값이 AXL에 반영됩니다.
// --------------------------------------------------------------------------
void CMotParameterDlg::OnBtnApplyUserPara() 
{
	double  dInitPos, dInitVel, dInitAccel, dInitDecel;

	dInitPos	= GetDlgItemDouble(IDC_EDT_POSITION);
	dInitVel	= GetDlgItemDouble(IDC_EDT_VELOCITY);
	dInitAccel	= GetDlgItemDouble(IDC_EDT_ACCEL);
	dInitDecel	= GetDlgItemDouble(IDC_EDT_DECEL);
	//++ 지정 축의 사용자 관련 파라메타들을 설정합니다.
	AxmMotSetParaLoad(m_lAxisNo, dInitPos, dInitVel, dInitAccel, dInitDecel);	
}

// ++ =======================================================================
// >> OnBtnApplyAllAxes() : "Apply All Axes" 버튼을 클릭시 호출되는 핸들러 함수.
//  - 모든 설정값들을 각각의 AXL 함수들을 이용하여 모든 축에 적용합니다.
// ※ [CAUTION] 모든 축에 설정값 동일하게 적용시 모션축의 종류에 따라 적용
//    되지않는 파라메타가 있을 수 있습니다. 
// --------------------------------------------------------------------------
void CMotParameterDlg::OnBtnApplyAllAxes() 
{
	int		lAxisNo = 0;
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
	dwMethodPulse	= ConvertComboToAxm(&m_cboPulse);
	dwMethodEncoder = ConvertComboToAxm(&m_cboEncoder);
	dwUseAlarm		= ConvertComboToAxm(&m_cboAlarm);
	dwModeAbsRel	= ConvertComboToAxm(&m_cboAbsRel);
	dwModeProfile   = ConvertComboToAxm(&m_cboProfile);
	dVelocityMin	= GetDlgItemDouble(IDC_EDT_MIN_VEL);
	dVelocityMax	= GetDlgItemDouble(IDC_EDT_MAX_VEL);
	lMovePulse		= GetDlgItemInt(IDC_EDT_MOVE_PULSE);	
	dMoveUnit		= GetDlgItemDouble(IDC_EDT_MOVE_UNIT);

	// Input/Output Signal Setting
	dwUseInp		= ConvertComboToAxm(&m_cboInp);
	dwLevelAlmRst	= ConvertComboToAxm(&m_cboAlarmReset);
	dwLevelLimitN	= ConvertComboToAxm(&m_cboELimitN);
	dwLevelLimitP	= ConvertComboToAxm(&m_cboELimitP);
	dwLevelZPhase	= ConvertComboToAxm(&m_cboZPhaseLev);
	dwModeStop		= ConvertComboToAxm(&m_cboStopMode);
	dwLevelStop		= ConvertComboToAxm(&m_cboStopLevel);
	dwLevelServoOn	= ConvertComboToAxm(&m_cboServoOn);
	dwTypeEncoder	= ConvertComboToAxm(&m_cboEncoderType);

	// Home Search Setting
	dwLevelHome		= ConvertComboToAxm(&m_cboHomeLevel);
	dwHomeSignal	= ConvertComboToAxm(&m_cboHomeSignal);
	lHomeDir		= ConvertComboToAxm(&m_cboHomeDir);
	dwZphas			= ConvertComboToAxm(&m_cboZPhaseUse);
	lHomeDir		= ConvertComboToAxm(&m_cboHomeDir);	
	dHomeClrTime	= GetDlgItemDouble(IDC_EDT_HOME_CLR_TIME);
	dHomeOffset		= GetDlgItemDouble(IDC_EDT_HOME_OFFSET);

	// Software Limit Setting
	dNegativePos	= GetDlgItemDouble(IDC_EDT_SW_POS_N);
	dPositivePos	= GetDlgItemDouble(IDC_EDT_SW_POS_P);

	// User Move Parameter Setting
	dInitPos		= GetDlgItemDouble(IDC_EDT_POSITION);
	dInitVel		= GetDlgItemDouble(IDC_EDT_VELOCITY);
	dInitAccel		= GetDlgItemDouble(IDC_EDT_ACCEL);
	dInitDecel		= GetDlgItemDouble(IDC_EDT_DECEL);

	for(lAxisNo = 0; lAxisNo < m_lAxisCount; lAxisNo++){	
		
		// Pulse/Encoder Method && Move Parameter Setting
		if(m_cboPulse.IsWindowEnabled() == TRUE){ 			
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
		
		if(m_cboEncoder.IsWindowEnabled() == TRUE){
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
		
		if(m_cboAlarm.IsWindowEnabled() == TRUE){
			//++ 지정 축의 비상정지 신호 사용유무/Active Level을 설정합니다. 
			AxmSignalSetServoAlarm(lAxisNo, dwUseAlarm);
		}
		if(m_cboAbsRel.IsWindowEnabled() == TRUE){
			//++ 지정 축의 구동 좌표계를 설정합니다. 
			// dwAbsRelMode : (0)POS_ABS_MODE - 현재 위치와 상관없이 지정한 위치로 절대좌표 이동합니다.
			//                (1)POS_REL_MODE - 현재 위치에서 지정한 양만큼 상대좌표 이동합니다.
			AxmMotSetAbsRelMode(lAxisNo, dwMethodPulse);
		}
		if(m_cboProfile.IsWindowEnabled() == TRUE){
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

// ++ =======================================================================
// >> OnTimer(...) : 타이머 이벤트 핸들러 함수.
//  - 일정한 주기로 변경되는 위치/속도/정보등을 Control에 반영합니다.
// --------------------------------------------------------------------------
void CMotParameterDlg::OnTimer(UINT nIDEvent) 
{
	DWORD	dwState1 = 0, dwState2 = 0, dwRetCode;
	switch(nIDEvent){
	case TM_DISPLAY:
		//++ Z상 신호의 상태를 확인합니다.
		dwRetCode = AxmStatusReadMechanical(m_lAxisNo, &dwState1);
		if(dwRetCode == AXT_RT_SUCCESS){
			dwState1  = ((dwState1 & QIMECHANICAL_ZPHASE_LEVEL) == 0) ? 0 : 1;
			m_chkZPhase.SetCheck(dwState1);
		}

		//++ Servo Alarm 신호의 상태를 확인합니다.
		dwRetCode = AxmSignalReadServoAlarm(m_lAxisNo, &dwState1);
		if(dwRetCode == AXT_RT_SUCCESS){
			m_chkAlarm.SetCheck(dwState1);
		}

		//++ Inposition(위치결정완료) 신호의 상태를 확인합니다.
		dwRetCode = AxmSignalReadInpos(m_lAxisNo, &dwState1);
		if(dwRetCode == AXT_RT_SUCCESS){
			m_chkInp.SetCheck(dwState1);
		}

		//++ Emergency 신호의 상태를 확인합니다.
		dwRetCode = AxmSignalReadStop(m_lAxisNo, &dwState1);
		if(dwRetCode == AXT_RT_SUCCESS){
			m_chkEmg.SetCheck(dwState1);
		}

		//++ (+/-)End Limit신호의 상태를 확인합니다.
		dwRetCode = AxmSignalReadLimit(m_lAxisNo, &dwState1, &dwState2);
		if(dwRetCode == AXT_RT_SUCCESS){
			m_chkELimitP.SetCheck(dwState1);
			m_chkELimitN.SetCheck(dwState2);
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
BOOL CMotParameterDlg::InitLibrary()
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
BOOL CMotParameterDlg::AddAxisInfo()
{
	CString	strData;
	DWORD	dwModuleID, dwNodeAddr= 0;
	long	lNetNo = 0;
	
	AxlGetModuleID(0, 0, &dwModuleID);
	AxlGetModuleNodeInfo(0, 0, &lNetNo, &dwNodeAddr);

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
		
	InitControl();							// Control 변수들을 등록하고, 초기 설정값들을 설정합니다.	
	SetTimer(TM_DISPLAY, 100, NULL);		// 일정한 주기로 변경되는 위치/속도/정보등을 Control에 반영할 타이머를 실행합니다.

	return TRUE;
}

// ++ =======================================================================
// >> InitControl() : Control들에 초기값을 설정하는 함수.
//  - Control 변수들을 등록하고, 초기 설정값들을 설정합니다.
// --------------------------------------------------------------------------
BOOL CMotParameterDlg::InitControl()
{
	m_cboSelAxis.SetCurSel(m_lAxisNo);
	
	return TRUE;
}

// ++ =======================================================================
// >> UpdateState() : 지정한 축의 설정값들을 읽어 Control과 일치시키는 함수.
//  - 축번호가 변경되었을 때 변경한 축의 설정값들과 Control들과 일치시키는 
//    역할을하는 함수입니다.
//  - 지정한 축의 모델별 제약들을 Control에 반영하는 역할을 합니다.
//  - 프로그램 초기 실행시, Mot파일 불러올 때, 축 번호 바뀔 때 사용됩니다.
// --------------------------------------------------------------------------
BOOL CMotParameterDlg::UpdateState()
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
	case AXT_SMC_2V04:
	case AXT_SMC_4V04:		
	case AXT_SMC_R1V04:
	case AXT_SMC_R1V04PM2Q:
	case AXT_SMC_R1V04PM2QE:
		m_cboPulse.ResetContent();
		m_cboPulse.EnableWindow(TRUE);
		m_cboPulse.AddString("00:OneHighLowHigh");
		m_cboPulse.AddString("01:OneHighHighLow");
		m_cboPulse.AddString("02:OneLowLowHigh");
		m_cboPulse.AddString("03:OneLowHighLow");
		m_cboPulse.AddString("04:TwoCcwCwHigh");
		m_cboPulse.AddString("05:TwoCcwCwLow");
		m_cboPulse.AddString("06:TwoCwCcwHigh");
		m_cboPulse.AddString("07:TwoCwCcwLow");
		m_cboPulse.AddString("08:TwoPhase");
		m_cboPulse.AddString("09:TwoPhaseReverse");

		m_cboEncoder.ResetContent();
		m_cboEncoder.EnableWindow(TRUE);
		m_cboEncoder.AddString("00:ObverseUpDownMode");
		m_cboEncoder.AddString("01:ObverseSqr1Mode");
		m_cboEncoder.AddString("02:ObverseSqr2Mode");
		m_cboEncoder.AddString("03:ObverseSqr4Mode");
		m_cboEncoder.AddString("04:ReverseUpDownMode");
		m_cboEncoder.AddString("05:ReverseSqr1Mode");
		m_cboEncoder.AddString("06:ReverseSqr2Mode");
		m_cboEncoder.AddString("07:ReverseSqr4Mode");

		m_cboAbsRel.ResetContent();
		m_cboAbsRel.EnableWindow(TRUE);
		m_cboAbsRel.AddString("00:POS_ABS_MODE");
		m_cboAbsRel.AddString("01:POS_REL_MODE");
		
		m_cboProfile.ResetContent();
		m_cboProfile.EnableWindow(TRUE);
		m_cboProfile.AddString("00:SYM_TRAPEZOIDE_MODE");
		m_cboProfile.AddString("01:ASYM_TRAPEZOIDE_MODE");
		m_cboProfile.AddString("02:QUASI_S_CURVE_MODE");
		m_cboProfile.AddString("03:SYM_S_CURVE_MODE");
		m_cboProfile.AddString("04:ASYM_S_CURVE_MODE");

		m_cboZPhaseLev.ResetContent();
		m_cboZPhaseLev.EnableWindow(TRUE);
		m_cboZPhaseLev.AddString("00:LOW");
		m_cboZPhaseLev.AddString("01:HIGH");

		m_cboZPhaseUse.ResetContent();
		m_cboZPhaseUse.EnableWindow(TRUE);
		m_cboZPhaseUse.AddString("00:UNUSED");
		m_cboZPhaseUse.AddString("01:(+)DIR_CW");
		m_cboZPhaseUse.AddString("02:(-)DIR_CCW");
		
		m_cboAlarm.ResetContent();
		m_cboAlarm.EnableWindow(TRUE);
		m_cboAlarm.AddString("00:LOW");
		m_cboAlarm.AddString("01:HIGH");
		m_cboAlarm.AddString("02:UNUSED");

		m_cboInp.ResetContent();
		m_cboInp.EnableWindow(TRUE);
		m_cboInp.AddString("00:LOW");
		m_cboInp.AddString("01:HIGH");
		m_cboInp.AddString("02:UNUSED");

		m_cboStopMode.ResetContent();
		m_cboStopMode.EnableWindow(TRUE);
		m_cboStopMode.AddString("00:EMERGENCY");
		m_cboStopMode.AddString("01:SLOWDOWN_");

		m_cboStopLevel.ResetContent();
		m_cboStopLevel.EnableWindow(TRUE);
		m_cboStopLevel.AddString("00:LOW");
		m_cboStopLevel.AddString("01:HIGH");
		m_cboStopLevel.AddString("02:UNUSED");

		m_cboELimitN.ResetContent();
		m_cboELimitN.EnableWindow(TRUE);
		m_cboELimitN.AddString("00:LOW");
		m_cboELimitN.AddString("01:HIGH");
		m_cboELimitN.AddString("02:UNUSED");

		m_cboELimitP.ResetContent();
		m_cboELimitP.EnableWindow(TRUE);
		m_cboELimitP.AddString("00:LOW");
		m_cboELimitP.AddString("01:HIGH");
		m_cboELimitP.AddString("02:UNUSED");

		m_cboServoOn.ResetContent();
		m_cboServoOn.EnableWindow(TRUE);
		m_cboServoOn.AddString("00:LOW");
		m_cboServoOn.AddString("01:HIGH");
		
		m_cboAlarmReset.ResetContent();
		m_cboAlarmReset.EnableWindow(TRUE);
		m_cboAlarmReset.AddString("00:LOW");
		m_cboAlarmReset.AddString("01:HIGH");

		m_edtSWPosN.EnableWindow(TRUE);
		m_edtSWPosP.EnableWindow(TRUE);

		m_cboEncoderType.ResetContent();
		m_cboEncoderType.EnableWindow(FALSE);
		m_cboEncoderType.AddString("00:INCREMENTAL");

		m_cboHomeSignal.ResetContent();
		m_cboHomeSignal.EnableWindow(TRUE);
		m_cboHomeSignal.AddString("00:PosEndLimit");
		m_cboHomeSignal.AddString("01:NegEndLimit");
		m_cboHomeSignal.AddString("04:HomeSensor");
		m_cboHomeSignal.AddString("05:EncodZPhase");

		m_cboHomeLevel.ResetContent();
		m_cboHomeLevel.EnableWindow(TRUE);
		m_cboHomeLevel.AddString("00:LOW");		
		m_cboHomeLevel.AddString("01:HIGH");		

		m_cboHomeDir.ResetContent();
		m_cboHomeDir.EnableWindow(TRUE);
		m_cboHomeDir.AddString("00:(-)DIR_CCW");
		m_cboHomeDir.AddString("01:(+)DIR_CW");

		m_cboZPhaseUse.ResetContent();
		m_cboZPhaseUse.EnableWindow(TRUE);
		m_cboZPhaseUse.AddString("00:UNUSED");
		m_cboZPhaseUse.AddString("01:(+)DIR_CW");
		m_cboZPhaseUse.AddString("02:(-)DIR_CCW");
		break;

	case AXT_SMC_R1V04A4:
		m_cboPulse.ResetContent();
		m_cboPulse.EnableWindow(FALSE);
		m_cboPulse.AddString("00:OneHighLowHigh");
		
		m_cboEncoder.ResetContent();
		m_cboEncoder.EnableWindow(FALSE);
		m_cboEncoder.AddString("00:ObverseUpDownMode");

		m_cboAbsRel.ResetContent();
		m_cboAbsRel.EnableWindow(TRUE);
		m_cboAbsRel.AddString("00:POS_ABS_MODE");
		m_cboAbsRel.AddString("01:POS_REL_MODE");
		
		m_cboProfile.ResetContent();
		m_cboProfile.EnableWindow(TRUE);
		m_cboProfile.AddString("00:SYM_TRAPEZOIDE_MODE");
		m_cboProfile.AddString("01:ASYM_TRAPEZOIDE_MODE");
		m_cboProfile.AddString("02:QUASI_S_CURVE_MODE");
		m_cboProfile.AddString("03:SYM_S_CURVE_MODE");
		m_cboProfile.AddString("04:ASYM_S_CURVE_MODE");

		m_cboZPhaseLev.ResetContent();
		m_cboZPhaseLev.EnableWindow(FALSE);
		m_cboZPhaseLev.AddString("02: UNUSED");

		m_cboAlarm.ResetContent();
		m_cboAlarm.EnableWindow(TRUE);
		m_cboAlarm.AddString("01: HIGH");
		m_cboAlarm.AddString("02: UNUSED");
		
		m_cboInp.ResetContent();
		m_cboInp.EnableWindow(TRUE);
		m_cboInp.AddString("01: HIGH");
		m_cboInp.AddString("02: UNUSED");
		
		m_cboStopMode.ResetContent();
		m_cboStopMode.EnableWindow(TRUE);
		m_cboStopMode.AddString("00:EMERGENCY");
		m_cboStopMode.AddString("01:SLOWDOWN");

		m_cboStopLevel.ResetContent();
		m_cboStopLevel.EnableWindow(TRUE);
		m_cboStopLevel.AddString("00: LOW");
		m_cboStopLevel.AddString("02: UNUSED");
		
		m_cboELimitN.ResetContent();
		m_cboELimitN.EnableWindow(TRUE);
		m_cboELimitN.AddString("00: LOW");
		m_cboELimitN.AddString("02: UNUSED");
		
		m_cboELimitP.ResetContent();
		m_cboELimitP.EnableWindow(TRUE);
		m_cboELimitP.AddString("00: LOW");
		m_cboELimitP.AddString("02: UNUSED");		

		m_cboServoOn.ResetContent();
		m_cboServoOn.EnableWindow(FALSE);
		m_cboServoOn.AddString("01: HIGH");
		
		m_cboAlarmReset.ResetContent();
		m_cboAlarmReset.EnableWindow(FALSE);
		m_cboAlarmReset.AddString("01: HIGH");

		m_edtSWPosN.EnableWindow(FALSE);
		m_edtSWPosP.EnableWindow(FALSE);

		m_cboEncoderType.ResetContent();
		m_cboEncoderType.EnableWindow(FALSE);
		m_cboEncoderType.AddString("00:INCREMENTAL");

		m_cboHomeSignal.ResetContent();
		m_cboHomeSignal.EnableWindow(TRUE);
		m_cboHomeSignal.AddString("00:PosEndLimit");
		m_cboHomeSignal.AddString("01:NegEndLimit");
		m_cboHomeSignal.AddString("04:HomeSensor");
		
		m_cboHomeLevel.ResetContent();
		m_cboHomeLevel.EnableWindow(TRUE);
		m_cboHomeLevel.AddString("00:LOW");		
		m_cboHomeLevel.AddString("01:HIGH");		

		m_cboHomeDir.ResetContent();
		m_cboHomeDir.EnableWindow(TRUE);
		m_cboHomeDir.AddString("00:(-)DIR_CCW");
		m_cboHomeDir.AddString("01:(+)DIR_CW");
		
		m_cboZPhaseUse.ResetContent();
		m_cboZPhaseUse.EnableWindow(FALSE);
		m_cboZPhaseUse.AddString("00:UNUSED");
		break;

	case AXT_SMC_R1V04MLIIPM:
		m_cboPulse.ResetContent();
		m_cboPulse.EnableWindow(TRUE);
		m_cboPulse.AddString("00:OneHighLowHigh");
		m_cboPulse.AddString("06:TwoCwCcwHigh");
		
		m_cboEncoder.ResetContent();
		m_cboEncoder.EnableWindow(FALSE);
		m_cboEncoder.AddString("00:ObverseUpDownMode");

		m_cboAbsRel.ResetContent();
		m_cboAbsRel.EnableWindow(TRUE);
		m_cboAbsRel.AddString("00:POS_ABS_MODE");
		m_cboAbsRel.AddString("01:POS_REL_MODE");
		
		m_cboProfile.ResetContent();
		m_cboProfile.EnableWindow(TRUE);
		m_cboProfile.AddString("00:SYM_TRAPEZOIDE_MODE");
		m_cboProfile.AddString("01:ASYM_TRAPEZOIDE_MODE");
		m_cboProfile.AddString("02:QUASI_S_CURVE_MODE");
		m_cboProfile.AddString("03:SYM_S_CURVE_MODE");
		m_cboProfile.AddString("04:ASYM_S_CURVE_MODE");

		m_cboZPhaseLev.ResetContent();
		m_cboZPhaseLev.EnableWindow(FALSE);
		m_cboZPhaseLev.AddString("02: UNUSED");

		m_cboAlarm.ResetContent();
		m_cboAlarm.EnableWindow(FALSE);
		m_cboAlarm.AddString("02: UNUSED");
		
		m_cboInp.ResetContent();
		m_cboInp.EnableWindow(FALSE);
		m_cboInp.AddString("02: UNUSED");
		
		m_cboStopMode.ResetContent();
		m_cboStopMode.EnableWindow(FALSE);
		m_cboStopMode.AddString("00:EMERGENCY");

		m_cboStopLevel.ResetContent();
		m_cboStopLevel.EnableWindow(FALSE);
		m_cboStopLevel.AddString("02: UNUSED");
		
		m_cboELimitN.ResetContent();
		m_cboELimitN.EnableWindow(FALSE);
		m_cboELimitN.AddString("02: UNUSED");
		
		m_cboELimitP.ResetContent();
		m_cboELimitP.EnableWindow(FALSE);
		m_cboELimitP.AddString("02: UNUSED");	

		m_cboServoOn.ResetContent();
		m_cboServoOn.EnableWindow(FALSE);
		m_cboServoOn.AddString("01: HIGH");
		
		m_cboAlarmReset.ResetContent();
		m_cboAlarmReset.EnableWindow(FALSE);
		m_cboAlarmReset.AddString("01: HIGH");
	
		m_edtSWPosN.EnableWindow(FALSE);
		m_edtSWPosP.EnableWindow(FALSE);

		m_cboEncoderType.ResetContent();
		m_cboEncoderType.EnableWindow(FALSE);
		m_cboEncoderType.AddString("00:INCREMENTAL");
	
		m_cboHomeSignal.ResetContent();
		m_cboHomeSignal.EnableWindow(TRUE);
		m_cboHomeSignal.AddString("04:HomeSensor");
		
		m_cboHomeLevel.ResetContent();
		m_cboHomeLevel.EnableWindow(FALSE);
		m_cboHomeLevel.AddString("01:HIGH");

		m_cboHomeDir.ResetContent();
		m_cboHomeDir.EnableWindow(TRUE);
		m_cboHomeDir.AddString("00:(-)DIR_CCW");
		m_cboHomeDir.AddString("01:(+)DIR_CW");
		
		m_cboZPhaseUse.ResetContent();
		m_cboZPhaseUse.EnableWindow(FALSE);
		m_cboZPhaseUse.AddString("00:UNUSED");
		break;

	case AXT_SMC_R1V04MLIISV:
	case AXT_SMC_R1V04SIIIHMIV:
		m_cboPulse.ResetContent();
		m_cboPulse.EnableWindow(FALSE);
		m_cboPulse.AddString("00:OneHighLowHigh");
		
		m_cboEncoder.ResetContent();
		m_cboEncoder.EnableWindow(FALSE);
		m_cboEncoder.AddString("00:ObverseUpDownMode");
		
		m_cboZPhaseLev.ResetContent();
		m_cboZPhaseLev.EnableWindow(FALSE);
		m_cboZPhaseLev.AddString("02: UNUSED");

		m_cboAlarm.ResetContent();
		m_cboAlarm.EnableWindow(TRUE);
		m_cboAlarm.AddString("01: HIGH");
		m_cboAlarm.AddString("02: UNUSED");
		
		m_cboInp.ResetContent();
		m_cboInp.EnableWindow(TRUE);
		m_cboInp.AddString("01: HIGH");
		m_cboInp.AddString("02: UNUSED");
		
		m_cboStopMode.ResetContent();
		m_cboStopMode.EnableWindow(FALSE);
		m_cboStopMode.AddString("00:EMERGENCY");
		
		m_cboStopLevel.ResetContent();
		m_cboStopLevel.EnableWindow(FALSE);
		m_cboStopLevel.AddString("02: UNUSED");
		
		m_cboELimitN.ResetContent();
		m_cboELimitN.EnableWindow(TRUE);
		m_cboELimitN.AddString("00: HIGH");
		m_cboELimitN.AddString("02: UNUSED");
		
		m_cboELimitP.ResetContent();
		m_cboELimitP.EnableWindow(TRUE);
		m_cboELimitP.AddString("00: HIGH");
		m_cboELimitP.AddString("02: UNUSED");	

		m_cboServoOn.ResetContent();
		m_cboServoOn.EnableWindow(FALSE);
		m_cboServoOn.AddString("01: HIGH");

		m_cboAlarmReset.ResetContent();
		m_cboAlarmReset.EnableWindow(FALSE);
		m_cboAlarmReset.AddString("01: HIGH");

		m_edtSWPosN.EnableWindow(FALSE);
		m_edtSWPosP.EnableWindow(FALSE);

		m_cboEncoderType.ResetContent();
		m_cboEncoderType.EnableWindow(TRUE);
		m_cboEncoderType.AddString("00:INCREMENTAL");
		m_cboEncoderType.AddString("01:ABSOLUTE");
	
		m_cboHomeSignal.ResetContent();
		m_cboHomeSignal.EnableWindow(TRUE);
		m_cboHomeSignal.AddString("00:PosEndLimit");
		m_cboHomeSignal.AddString("01:NegEndLimit");
		m_cboHomeSignal.AddString("04:HomeSensor");
		
		m_cboHomeLevel.ResetContent();
		m_cboHomeLevel.EnableWindow(FALSE);
		m_cboHomeLevel.AddString("01:HIGH");

		m_cboHomeDir.ResetContent();
		m_cboHomeDir.EnableWindow(TRUE);
		m_cboHomeDir.AddString("00:(-)DIR_CCW");
		m_cboHomeDir.AddString("01:(+)DIR_CW");
		
		m_cboZPhaseUse.ResetContent();
		m_cboZPhaseUse.EnableWindow(TRUE);
		m_cboZPhaseUse.AddString("00:UNUSED");
		m_cboZPhaseUse.AddString("01:(+)DIR_CW");
		m_cboZPhaseUse.AddString("02:(-)DIR_CCW");
		break;

	case AXT_ECAT_MOTION:
		m_cboPulse.ResetContent();
		m_cboPulse.EnableWindow(FALSE);
		m_cboPulse.AddString("00:OneHighLowHigh");

		m_cboEncoder.ResetContent();
		m_cboEncoder.EnableWindow(FALSE);
		m_cboEncoder.AddString("00:ObverseUpDownMode");

		m_cboAbsRel.ResetContent();
		m_cboAbsRel.EnableWindow(TRUE);
		m_cboAbsRel.AddString("00:POS_ABS_MODE");
		m_cboAbsRel.AddString("01:POS_REL_MODE");

		m_cboProfile.ResetContent();
		m_cboProfile.EnableWindow(TRUE);
		m_cboProfile.AddString("00:SYM_TRAPEZOIDE_MODE");
		m_cboProfile.AddString("01:ASYM_TRAPEZOIDE_MODE");
		m_cboProfile.AddString("02:QUASI_S_CURVE_MODE");
		m_cboProfile.AddString("03:SYM_S_CURVE_MODE");
		m_cboProfile.AddString("04:ASYM_S_CURVE_MODE");

		m_cboZPhaseLev.ResetContent();
		m_cboZPhaseLev.EnableWindow(FALSE);
		m_cboZPhaseLev.AddString("02:UNUSED");

		m_cboZPhaseUse.ResetContent();
		m_cboZPhaseUse.EnableWindow(TRUE);
		m_cboZPhaseUse.AddString("00:UNUSED");
		m_cboZPhaseUse.AddString("01:(+)DIR_CW");
		m_cboZPhaseUse.AddString("02:(-)DIR_CCW");

		m_cboAlarm.ResetContent();
		m_cboAlarm.EnableWindow(TRUE);
		m_cboAlarm.AddString("01:HIGH");
		m_cboAlarm.AddString("02:UNUSED");

		m_cboInp.ResetContent();
		m_cboInp.EnableWindow(TRUE);
		m_cboInp.AddString("00:LOW");
		m_cboInp.AddString("01:HIGH");
		m_cboInp.AddString("02:UNUSED");
		m_cboInp.AddString("03:USED");

		m_cboStopMode.ResetContent();
		m_cboStopMode.EnableWindow(TRUE);
		m_cboStopMode.AddString("00:EMERGENCY");
		m_cboStopMode.AddString("01:SLOWDOWN_");

		m_cboStopLevel.ResetContent();
		m_cboStopLevel.EnableWindow(TRUE);
		m_cboStopLevel.AddString("00:LOW");
		m_cboStopLevel.AddString("01:HIGH");
		m_cboStopLevel.AddString("02:UNUSED");
		m_cboStopLevel.AddString("03:USED");

		m_cboELimitN.ResetContent();
		m_cboELimitN.EnableWindow(TRUE);
		m_cboELimitN.AddString("00:LOW");
		m_cboELimitN.AddString("01:HIGH");
		m_cboELimitN.AddString("02:UNUSED");
		m_cboELimitN.AddString("03:USED");

		m_cboELimitP.ResetContent();
		m_cboELimitP.EnableWindow(TRUE);
		m_cboELimitP.AddString("00:LOW");
		m_cboELimitP.AddString("01:HIGH");
		m_cboELimitP.AddString("02:UNUSED");
		m_cboELimitP.AddString("03:USED");

		m_cboServoOn.ResetContent();
		m_cboServoOn.EnableWindow(FALSE);
		m_cboServoOn.AddString("01:HIGH");

		m_cboAlarmReset.ResetContent();
		m_cboAlarmReset.EnableWindow(FALSE);
		m_cboAlarmReset.AddString("01:HIGH");

		m_edtSWPosN.EnableWindow(FALSE);
		m_edtSWPosP.EnableWindow(FALSE);

		m_cboEncoderType.ResetContent();
		m_cboEncoderType.EnableWindow(FALSE);
		m_cboEncoderType.AddString("00:INCREMENTAL");

		m_cboHomeSignal.ResetContent();
		m_cboHomeSignal.EnableWindow(TRUE);
		m_cboHomeSignal.AddString("00:PosEndLimit");
		m_cboHomeSignal.AddString("01:NegEndLimit");
		m_cboHomeSignal.AddString("04:HomeSensor");
		m_cboHomeSignal.AddString("05:EncodZPhase");

		m_cboHomeLevel.ResetContent();
		m_cboHomeLevel.EnableWindow(TRUE);
		m_cboHomeLevel.AddString("00:LOW");		
		m_cboHomeLevel.AddString("01:HIGH");		

		m_cboHomeDir.ResetContent();
		m_cboHomeDir.EnableWindow(TRUE);
		m_cboHomeDir.AddString("00:(-)DIR_CCW");
		m_cboHomeDir.AddString("01:(+)DIR_CW");

		break;
	}

	//++ 지정 축의 펄스 출력방식 설정값을 확인합니다.
	dwRetCode = AxmMotGetPulseOutMethod(m_lAxisNo, &dwMethod);
	if(dwRetCode != AXT_RT_SUCCESS)	dwMethod = OneHighLowHigh;
	ConvertAxmToCombo(&m_cboPulse, dwMethod);

	//++ 지정 축의 엔코더 입력방식 설정값을 확인합니다.
	dwRetCode = AxmMotGetEncInputMethod(m_lAxisNo, &dwMethod);
	if(dwRetCode != AXT_RT_SUCCESS)	dwMethod = ObverseUpDownMode;
	ConvertAxmToCombo(&m_cboEncoder, dwMethod);	

	dwRetCode = AxmSignalGetServoAlarm(m_lAxisNo, &dwUse);
	if(dwRetCode != AXT_RT_SUCCESS)	dwUse = UNUSED;
	ConvertAxmToCombo(&m_cboAlarm, dwUse);	

	//++ 지정 축에 Software Limit기능을 확인합니다.
	dwRetCode = AxmMotGetMinVel(m_lAxisNo, &dMinVel);
	if(dwRetCode != AXT_RT_SUCCESS)	dMinVel = 1.0;
	SetDlgItemDouble(IDC_EDT_MIN_VEL, dMinVel);

	//++ 지정 축의 초기구동 속도를 확인합니다.
	dwRetCode = AxmMotGetMaxVel(m_lAxisNo, &dMaxVel);
	if(dwRetCode != AXT_RT_SUCCESS)	dMaxVel = 1.0;
	SetDlgItemDouble(IDC_EDT_MAX_VEL, dMaxVel);

	//++ 지정 축의 거리/속도/가속도의 제어단위/설정값들을 확인합니다.
	dwRetCode = AxmMotGetMoveUnitPerPulse(m_lAxisNo, &dUnit, &lPulse);
	if(dwRetCode != AXT_RT_SUCCESS)	dUnit = 1.0;
	SetDlgItemDouble(IDC_EDT_MOVE_UNIT, dUnit);
	SetDlgItemInt(IDC_EDT_MOVE_PULSE, lPulse);

	//++ 지정 축의 Z상 신호 Active Level 설정값을 확인합니다.
	dwRetCode = AxmSignalGetZphaseLevel(m_lAxisNo, &dwLevel);
	if(dwRetCode != AXT_RT_SUCCESS)	dwLevel = UNUSED;
	ConvertAxmToCombo(&m_cboZPhaseLev, dwLevel);

	//++ 지정 축의 Servo Alarm 신호 Active Level/사용유무를 확인합니다.
	dwRetCode = AxmSignalGetServoAlarm(m_lAxisNo, &dwUse);
	if(dwRetCode != AXT_RT_SUCCESS)	dwUse = UNUSED;
	ConvertAxmToCombo(&m_cboAlarm, dwUse);

	//++ 지정 축의 Inposition(위치결정완료) 신호 Active Level/사용유무를 확인합니다.
	dwRetCode = AxmSignalGetInpos(m_lAxisNo, &dwUse);
	if(dwRetCode != AXT_RT_SUCCESS)	dwUse = UNUSED;
	ConvertAxmToCombo(&m_cboInp, dwUse);

	//++ 지정 축의 Emergency 신호 Active Level/사용유무를 확인합니다.
	dwRetCode = AxmSignalGetStop(m_lAxisNo, &dwStopMode, &dwLevel);
	if(dwRetCode != AXT_RT_SUCCESS)	dwLevel = UNUSED;
	ConvertAxmToCombo(&m_cboStopMode, dwStopMode);
	ConvertAxmToCombo(&m_cboStopLevel, dwLevel);

	//++ 지정 축의 (+/-) End Limit 신호 Active Level/사용유무를 확인합니다.
	dwRetCode = AxmSignalGetLimit(m_lAxisNo, NULL, &dwPositiveLevel, &dwNegativeLevel);
	if(dwRetCode != AXT_RT_SUCCESS)	dwPositiveLevel = dwNegativeLevel = UNUSED;
	ConvertAxmToCombo(&m_cboELimitP, dwPositiveLevel);
	ConvertAxmToCombo(&m_cboELimitN, dwNegativeLevel);

	//++ 지정 축의 Servo On/Off 신호 Active Level을 확인합니다.
	dwRetCode = AxmSignalGetServoOnLevel(m_lAxisNo, &dwLevel);
	if(dwRetCode != AXT_RT_SUCCESS)	dwLevel = UNUSED;
	ConvertAxmToCombo(&m_cboServoOn, dwLevel);
	
	//++ 지정 축의 Alarm Reset 신호 Active Level을 확인합니다.
	dwRetCode = AxmSignalGetServoAlarmResetLevel(m_lAxisNo, &dwLevel);
	if(dwRetCode != AXT_RT_SUCCESS)	dwLevel = UNUSED;
	ConvertAxmToCombo(&m_cboAlarmReset, dwLevel);

	//++ 지정한 축에 Software Limit기능을 확인합니다.
	dwRetCode = AxmSignalGetSoftLimit(m_lAxisNo, &dwSWEnable, &dwSWStopMode, &dwSWRef, &dSWLimitP, &dSWLimitN);
	m_cboSWSel.ResetContent();
	m_cboSWSel.AddString("00:COMMAND");
	m_cboSWSel.AddString("01:ACTUAL");
	m_cboSWStopMode.ResetContent();
	m_cboSWStopMode.AddString("00:EMERGENCY");
	m_cboSWStopMode.AddString("01:SLOWSTOP");
	if(dwRetCode != AXT_RT_SUCCESS)	
	{
		ConvertAxmToCombo(&m_cboSWSel, dwSWRef);
		ConvertAxmToCombo(&m_cboSWStopMode, dwSWStopMode);
		m_cboSWSel.EnableWindow(TRUE);
		m_cboSWStopMode.EnableWindow(TRUE);
		m_chkSWEnable.SetCheck(dwSWEnable);
	}
	else
	{
		ConvertAxmToCombo(&m_cboSWSel, 0);
		ConvertAxmToCombo(&m_cboSWStopMode, 0);
		m_cboSWSel.EnableWindow(FALSE);
		m_cboSWStopMode.EnableWindow(FALSE);
		m_chkSWEnable.EnableWindow(FALSE);
	}
	SetDlgItemDouble(IDC_EDT_SW_POS_P, dSWLimitP);
	SetDlgItemDouble(IDC_EDT_SW_POS_N, dSWLimitN);

	//++ 지정한 축에 설정된 구동 좌표계를 확인합니다.
	dwRetCode = AxmMotGetAbsRelMode(m_lAxisNo, &dwAbsRelMode);
	if(dwRetCode != AXT_RT_SUCCESS)	dwAbsRelMode = POS_ABS_MODE;
	ConvertAxmToCombo(&m_cboAbsRel, dwAbsRelMode);

	//++ 지정한 축에 설정된 구동 프로파일 모드를 확인합니다.
	dwRetCode = AxmMotGetProfileMode(m_lAxisNo, &dwProfileMode);
	if(dwRetCode != AXT_RT_SUCCESS)	dwProfileMode = SYM_TRAPEZOIDE_MODE;
	ConvertAxmToCombo(&m_cboProfile, dwProfileMode);
	
	//++ 지정한 축에 설정된 Encoder Type을 확인합니다.
	dwRetCode = AxmSignalGetEncoderType(m_lAxisNo, &dwEncoderType);
	if(dwRetCode != AXT_RT_SUCCESS)	dwEncoderType = 0;
	ConvertAxmToCombo(&m_cboEncoderType, dwEncoderType);

	//++ 지정한 축에 원점검색 신호 Active Level을 확인합니다.
	AxmHomeGetSignalLevel(m_lAxisNo, &dwLevel);
	ConvertAxmToCombo(&m_cboHomeLevel, dwLevel);

	//++ 지정한 축에 원점검색 방법 설정값을 확인합니다.
	AxmHomeGetMethod(m_lAxisNo, &lHmDir, &dwHomeSignal, &dwZphas, &dHomeClrTime, &dHomeOffset);
	ConvertAxmToCombo(&m_cboHomeDir, lHmDir);
	ConvertAxmToCombo(&m_cboHomeSignal, dwHomeSignal);
	ConvertAxmToCombo(&m_cboZPhaseUse, dwZphas);	

	SetDlgItemDouble(IDC_EDT_HOME_CLR_TIME, dHomeClrTime);
	SetDlgItemDouble(IDC_EDT_HOME_OFFSET, dHomeOffset);	

	//++ 지정한 축에 원점검색 속도/가속도 설정값을 확인합니다.
	AxmHomeGetVel(m_lAxisNo, &dVelFirst, &dVelSecond, &dVelThird, &dVelLast, &dAccFirst, &dAccSecond);
	SetDlgItemDouble(IDC_EDT_VEL_FIRST, dVelFirst);
	SetDlgItemDouble(IDC_EDT_VEL_SECOND, dVelSecond);
	SetDlgItemDouble(IDC_EDT_VEL_THIRD, dVelThird);
	SetDlgItemDouble(IDC_EDT_VEL_LAST, dVelLast);

	SetDlgItemDouble(IDC_EDT_ACC_FIRST, dAccFirst);
	SetDlgItemDouble(IDC_EDT_ACC_SECOND, dAccSecond);

	//++ 지정한 축에 원점검색 속도/가속도 설정값을 확인합니다.
	AxmMotGetParaLoad(m_lAxisNo, &dInitPos, &dInitVel, &dInitAccel, &dInitDecel);
	SetDlgItemDouble(IDC_EDT_POSITION, dInitPos);
	SetDlgItemDouble(IDC_EDT_VELOCITY, dInitVel);
	SetDlgItemDouble(IDC_EDT_ACCEL, dInitAccel);
	SetDlgItemDouble(IDC_EDT_DECEL, dInitDecel);
	
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
DWORD CMotParameterDlg::ConvertComboToAxm(CComboBox *pCboItem)
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
long CMotParameterDlg::ConvertAxmToCombo(CComboBox *pCboItem, DWORD dwCurData)
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
void CMotParameterDlg::SetDlgItemDouble(int nID, double value, int nPoint)
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
double CMotParameterDlg::GetDlgItemDouble(int nID)
{
	double dRet;
	CString sTemp;
	GetDlgItem(nID)->GetWindowText(sTemp);
	dRet = atof((LPCTSTR)sTemp);
	return dRet;
}



