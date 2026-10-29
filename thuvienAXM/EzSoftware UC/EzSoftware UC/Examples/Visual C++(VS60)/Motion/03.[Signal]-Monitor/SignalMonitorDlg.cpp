// SignalMonitorDlg.cpp : implementation file
//
// **************************************************************************
// >> [일자]: 2016.01.05
// >> [개요]: 이 예제는 신호 관련 함수들의 사용법을 익히고 제품별 지원되는 
//    기능들을 파악할 수 있도록 작성된 예제입니다.
// >> [중요]: 신호설정 함수 사용시 주의사항 
//     1) 제품의 종류에 따라서 신호설정에 사용되는 인자가 달라질 수 있습니다.
//     2) 네트웍 제품의 리미트 신호나 원점신호의 레벨 변경은 서보팩 파라메타를 
//        변경해서 바꿀수 있습니다.
// **************************************************************************

#include "stdafx.h"
#include "SignalMonitor.h"
#include "SignalMonitorDlg.h"

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
#define Z_PHASE_BIT		1

/////////////////////////////////////////////////////////////////////////////
// CSignalMonitorDlg dialog

CSignalMonitorDlg::CSignalMonitorDlg(CWnd* pParent /*=NULL*/)
	: CDialog(CSignalMonitorDlg::IDD, pParent)
{
	//{{AFX_DATA_INIT(CSignalMonitorDlg)
		// NOTE: the ClassWizard will add member initialization here
	//}}AFX_DATA_INIT
	// Note that LoadIcon does not require a subsequent DestroyIcon in Win32
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);

	//++
	m_lAxisNo		= -1;					// 제어할 축 번호 초기화
	m_lAxisCount	= 0;					// 제어 가능한 축갯수 초기화
	m_dwModuleID	= 0;					// 제어할 축의 모듈ID 초기화
}

void CSignalMonitorDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CSignalMonitorDlg)
	DDX_Control(pDX, IDC_EDT_SW_POS_P, m_edtSWPosP);
	DDX_Control(pDX, IDC_EDT_SW_POS_N, m_edtSWPosN);
	DDX_Control(pDX, IDC_CHK_INP, m_chkInp);
	DDX_Control(pDX, IDC_CHK_EMG, m_chkEmg);
	DDX_Control(pDX, IDC_CHK_ELIMIT_P, m_chkELimitP);
	DDX_Control(pDX, IDC_CHK_ELIMIT_N, m_chkELimitN);
	DDX_Control(pDX, IDC_CHK_ALARM, m_chkAlarm);
	DDX_Control(pDX, IDC_CHK_SW_ENABLE, m_chkSWEnable);
	DDX_Control(pDX, IDC_CHK_SWLIMIT_N, m_chkSWLimitN);
	DDX_Control(pDX, IDC_CHK_SWLIMIT_P, m_chkSWLimitP);
	DDX_Control(pDX, IDC_CHK_Z_PHASE, m_chkZPhase);
	DDX_Control(pDX, IDC_CBO_Z_PHASE, m_cboZPhase);
	DDX_Control(pDX, IDC_CBO_SW_STOP, m_cboSWStop);
	DDX_Control(pDX, IDC_CBO_SW_REF, m_cboSWRef);
	DDX_Control(pDX, IDC_CBO_SERVO_ON, m_cboServoOn);
	DDX_Control(pDX, IDC_CBO_INP, m_cboInp);
	DDX_Control(pDX, IDC_CBO_EMG, m_cboEmg);
	DDX_Control(pDX, IDC_CBO_ELIMIT_P, m_cboELimitP);
	DDX_Control(pDX, IDC_CBO_ELIMIT_N, m_cboELimitN);
	DDX_Control(pDX, IDC_CBO_ALARM_RESET, m_cboAlarmReset);
	DDX_Control(pDX, IDC_CBO_ALARM, m_cboAlarm);
	DDX_Control(pDX, IDC_CBO_SEL_AXIS, m_cboSelAxis);
	//}}AFX_DATA_MAP
}

BEGIN_MESSAGE_MAP(CSignalMonitorDlg, CDialog)
	//{{AFX_MSG_MAP(CSignalMonitorDlg)
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	ON_BN_CLICKED(IDC_BTN_LOAD_FILE, OnBtnLoadFile)
	ON_CBN_SELCHANGE(IDC_CBO_Z_PHASE, OnSelchangeCboZPhase)
	ON_CBN_SELCHANGE(IDC_CBO_ALARM, OnSelchangeCboAlarm)
	ON_CBN_SELCHANGE(IDC_CBO_ELIMIT_N, OnSelchangeCboElimitN)
	ON_CBN_SELCHANGE(IDC_CBO_INP, OnSelchangeCboInp)
	ON_CBN_SELCHANGE(IDC_CBO_EMG, OnSelchangeCboEmg)
	ON_CBN_SELCHANGE(IDC_CBO_ELIMIT_P, OnSelchangeCboElimitP)
	ON_CBN_SELCHANGE(IDC_CBO_SERVO_ON, OnSelchangeCboServoOn)
	ON_CBN_SELCHANGE(IDC_CBO_ALARM_RESET, OnSelchangeCboAlarmReset)
	ON_BN_CLICKED(IDC_CHK_SW_ENABLE, OnChkSwEnable)
	ON_CBN_SELCHANGE(IDC_CBO_SEL_AXIS, OnSelchangeCboSelAxis)
	ON_WM_TIMER()
	ON_WM_DESTROY()
	//}}AFX_MSG_MAP
	ON_COMMAND_RANGE(IDC_CHK_OUT_00, IDC_CHK_OUT_04, OnChkOut)
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CSignalMonitorDlg message handlers

BOOL CSignalMonitorDlg::OnInitDialog()
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

void CSignalMonitorDlg::OnPaint() 
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
HCURSOR CSignalMonitorDlg::OnQueryDragIcon()
{
	return (HCURSOR) m_hIcon;
}

void CSignalMonitorDlg::OnDestroy() 
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
void CSignalMonitorDlg::OnSelchangeCboSelAxis() 
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
void CSignalMonitorDlg::OnBtnLoadFile() 
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
// >> OnChkOut(...) : "Output Bit" 버튼들 클릭시 호출되는 핸들러 함수. 
//  - IDC_CHK_OUT_00 ~ IDC_CHK_OUT_04 버튼의 클릭이벤트 발생시 호출됩니다.
// --------------------------------------------------------------------------
void CSignalMonitorDlg::OnChkOut(UINT nID) 
{
	CString strData;
	long	lBitNo;
	DWORD	dwRetCode, dwOnOff;
	
	lBitNo		= nID - IDC_CHK_OUT_00;
	dwOnOff		= IsDlgButtonChecked(nID);
	//++ 선택한 축에 지정한 Bit의 출력접점을 변경합니다.
	dwRetCode	= AxmSignalWriteOutputBit(m_lAxisNo, lBitNo, dwOnOff);	
	if(dwRetCode != AXT_RT_SUCCESS){
		CheckDlgButton(nID, FALSE);

		strData.Format("AxmSignalWriteOutputBit return error[Code:%04d]", dwRetCode);
		MessageBox(strData, "Error", MB_OK | MB_ICONERROR);
	}
}

// ++ =======================================================================
// >> OnSelchangeCboZPhase() : "Z Phase"콤보박스 Item변경시 호출되는 핸들러 함수.
//  - 선택된 축의 Z상 신호 Active Level을 설정합니다.
// ※ [INFO] 특정 네트웍 제품의 경우 Z상 신호레벨 변경을 지원하지않습니다.
// --------------------------------------------------------------------------
void CSignalMonitorDlg::OnSelchangeCboZPhase() 
{
	CString strData;
	DWORD	dwLevel, dwRetCode;
	
	// 이더켓은 AxmSignalSetZphaseLevel을 지원하지 않음.
	if (m_dwModuleID != AXT_ECAT_MOTION)
	{
		dwLevel		= ConvertComboToAxm(&m_cboZPhase);
		//++ 선택한 축의 Z상 Active Level을 설정합니다.
		dwRetCode	= AxmSignalSetZphaseLevel(m_lAxisNo, dwLevel);	
		if(dwRetCode != AXT_RT_SUCCESS){
			strData.Format("AxmSignalSetZphaseLevel return error[Code:%04d]", dwRetCode);
			MessageBox(strData, "Error", MB_OK | MB_ICONERROR);
		}
	}
}

// ++ =======================================================================
// >> OnSelchangeCboAlarm() : "Servo Alarm"콤보박스 Item변경시 호출되는 핸들러 함수.
//  - 선택된 축의 Servo Alarm 신호 Active Level/사용유무를 설정합니다.
//  - Servo Alarm 신호를 사용안함으로 설정하면 구동중  Alarm신호가 Active되어도 
//    계속해서 목표지점까지 구동하게됩니다.
// ※ [INFO] 특정 네트웍 제품의 경우 Servo Alarm 신호레벨 변경을 지원하지않습니다.
// --------------------------------------------------------------------------
void CSignalMonitorDlg::OnSelchangeCboAlarm() 
{
	CString strData;
	DWORD	dwLevel, dwRetCode;
	
	// 이더켓은 AxmSignalSetServoAlarm을 지원하지 않음.
	if (m_dwModuleID != AXT_ECAT_MOTION)
	{
		dwLevel		= ConvertComboToAxm(&m_cboAlarm);
		//++ 선택한 축의 Servo Alarm 신호 Active Level/사용유무를 설정합니다.
		dwRetCode	= AxmSignalSetServoAlarm(m_lAxisNo, dwLevel);		
		if(dwRetCode != AXT_RT_SUCCESS){
			strData.Format("AxmSignalSetServoAlarm return error[Code:%04d]", dwRetCode);
			MessageBox(strData, "Error", MB_OK | MB_ICONERROR);
		}
	}
}

// ++ =======================================================================
// >> OnSelchangeCboInp() : "Inposition"콤보박스 Item변경시 호출되는 핸들러 함수.
//  - 선택된 축의 Inposition 신호 Active Level/사용유무를 설정합니다.
// ※ [INFO] 특정 네트웍 제품의 경우 Inposition 신호레벨 변경을 지원하지않습니다.
// --------------------------------------------------------------------------
void CSignalMonitorDlg::OnSelchangeCboInp() 
{
	CString strData;
	DWORD	dwLevel, dwRetCode;
	
	dwLevel		= ConvertComboToAxm(&m_cboInp);
	//++ 선택한 축의 Inposition(위치결정완료) 신호 Active Level/사용유무를 설정합니다.
	// - Inposition 신호를 사용안함으로 설정하면 모션제어 칩에서 펄스출력이 완료될 때 즉시구동 종료됩니다.
	// ※ [CAUTION] Inposition 신호를 사용함으로 설정하면 모션제어 칩에서 펄스출력이 완료된 후 서보팩으로 부터 
	//              Inposition(위치결정완료) 신호가 Active될 때 까지 모션 구동중으로 됩니다.
	// ※ [CAUTION] Inposition 신호를 사용할 때 Active Level이 맞지않으면 최초 한번 구동 후 모션구동이 종료되지않아 
	//              다음 구동을 할 수 없게 됩니다. 
	dwRetCode	= AxmSignalSetInpos(m_lAxisNo, dwLevel);	
	if(dwRetCode != AXT_RT_SUCCESS){
		strData.Format("AxmSignalSetInpos return error[Code:%04d]", dwRetCode);
		MessageBox(strData, "Error", MB_OK | MB_ICONERROR);
	}
}

// ++ =======================================================================
// >> OnSelchangeCboEmg() : "Emergency"콤보박스 Item변경시 호출되는 핸들러 함수.
//  - 선택된 축의 Emergency 신호 Active Level/사용유무를 설정합니다.
//  - Emergency 신호를 사용안함으로 설정하면 구동중  EMG신호가 Active되어도 
//    계속해서 목표지점까지 구동하게됩니다.
// ※ [INFO] 특정 네트웍 제품의 경우 Emergency 신호를 지원하지않습니다.
// --------------------------------------------------------------------------
void CSignalMonitorDlg::OnSelchangeCboEmg() 
{
	CString strData;
	DWORD	dwRetCode, dwStopMode, dwLevel;
	
	//++ 선택한 축의 Emergency 신호 Active Level/사용유무를 확인합니다.
	dwRetCode = AxmSignalGetStop(m_lAxisNo, &dwStopMode, &dwLevel);
	if(dwRetCode == AXT_RT_SUCCESS){
		dwLevel = ConvertComboToAxm(&m_cboEmg);
		//++ 선택한 축의 Emergency 신호 Active Level/사용유무를 설정합니다.
		AxmSignalSetStop(m_lAxisNo, dwStopMode, dwLevel);	
	}else{
		strData.Format("AxmSignalGetStop return error[Code:%04d]", dwRetCode);
		MessageBox(strData, "Error", MB_OK | MB_ICONERROR);
	}
}

// ++ =======================================================================
// >> OnSelchangeCboElimitN() : "(-) End Limit"콤보박스 Item변경시 호출되는 핸들러 함수.
//  - 선택된 축의 (-) End Limit 신호 Active Level/사용유무를 설정합니다.
//  - (-) End Limit 신호를 사용안함으로 설정하면 (-)방향으로 구동중  (-) End Limit신호가
//    Active되어도 계속해서 목표지점까지 구동하게됩니다.
// ※ [INFO] 특정 네트웍 제품의 경우 (-) End Limit 신호레벨 변경을 지원하지않습니다.
// --------------------------------------------------------------------------
void CSignalMonitorDlg::OnSelchangeCboElimitN() 
{
	CString strData;
	DWORD	dwRetCode, dwStopMode = 0, dwPLevel = 0, dwNLevel = 0;
	
	//++ 선택한 축의 (+/-) End Limit 신호 Active Level/사용유무를 확인합니다.
	dwRetCode = AxmSignalGetLimit(m_lAxisNo, &dwStopMode, &dwPLevel, &dwNLevel);
	if(dwRetCode == AXT_RT_SUCCESS){
		dwNLevel = ConvertComboToAxm(&m_cboELimitN);
		//++ 선택한 축의 (-) End Limit 신호 Active Level/사용유무를 설정합니다.
		AxmSignalSetLimit(m_lAxisNo, dwStopMode, dwPLevel, dwNLevel);
	}else{
		strData.Format("AxmSignalSetLimit return error[Code:%04d]", dwRetCode);
		MessageBox(strData, "Error", MB_OK | MB_ICONERROR);
	}	
}

// ++ =======================================================================
// >> OnSelchangeCboElimitN() : "(+) End Limit"콤보박스 Item변경시 호출되는 핸들러 함수.
//  - 선택된 축의 (+) End Limit 신호 Active Level/사용유무를 설정합니다.
//  - (+) End Limit 신호를 사용안함으로 설정하면 (+)방향으로 구동중  (+) End Limit신호가
//    Active되어도 계속해서 목표지점까지 구동하게됩니다.
// ※ [INFO] 특정 네트웍 제품의 경우 (+) End Limit 신호레벨 변경을 지원하지않습니다.
// --------------------------------------------------------------------------
void CSignalMonitorDlg::OnSelchangeCboElimitP() 
{
	CString strData;
	DWORD	dwRetCode, dwStopMode = 0, dwPLevel = 0, dwNLevel = 0;

	dwRetCode = AxmSignalGetLimit(m_lAxisNo, &dwStopMode, &dwPLevel, &dwNLevel);
	if(dwRetCode == AXT_RT_SUCCESS){
		dwPLevel = ConvertComboToAxm(&m_cboELimitP);
		//++ 선택한 축의 (+) End Limit 신호 Active Level/사용유무를 설정합니다.
		AxmSignalSetLimit(m_lAxisNo, dwStopMode, dwPLevel, dwNLevel);
	}else{
		strData.Format("AxmSignalSetLimit return error[Code:%04d]", dwRetCode);
		MessageBox(strData, "Error", MB_OK | MB_ICONERROR);
	}
}

// ++ =======================================================================
// >> OnSelchangeCboServoOn() : "Servo On Level"콤보박스 Item변경시 호출되는 핸들러 함수.
//  - 선택된 축의 Servo On/Off 신호 Active Level을 설정합니다.
// ※ [INFO] 특정 네트웍 제품의 경우 Servo On/Off 신호레벨 변경을 지원하지않습니다.
// --------------------------------------------------------------------------
void CSignalMonitorDlg::OnSelchangeCboServoOn() 
{
	CString strData;
	DWORD	dwLevel, dwRetCode;

	// 이더켓은 AxmSignalSetServoOnLevel을 지원하지 않음.
	if (m_dwModuleID != AXT_ECAT_MOTION)
	{
		dwLevel		= ConvertComboToAxm(&m_cboServoOn);
		//++ 선택된 축의 Servo On/Off 신호 Active Level을 설정합니다.
		dwRetCode	= AxmSignalSetServoOnLevel(m_lAxisNo, dwLevel);
		if(dwRetCode != AXT_RT_SUCCESS){
			strData.Format("AxmSignalSetServoOnLevel return error[Code:%04d]", dwRetCode);
			MessageBox(strData, "Error", MB_OK | MB_ICONERROR);
		}
	}
}

// ++ =======================================================================
// >> OnSelchangeCboAlarmReset() : "Alm Reset Level"콤보박스 Item변경시 호출되는 핸들러 함수.
//  - 선택된 축의 Alarm Reset 신호 Active Level을 설정합니다.
// ※ [INFO] 특정 네트웍 제품의 경우 Alarm Reset 신호레벨 변경을 지원하지않습니다.
// --------------------------------------------------------------------------
void CSignalMonitorDlg::OnSelchangeCboAlarmReset() 
{
	CString strData;
	DWORD dwLevel, dwRetCode;
	
	// 이더켓은 AxmSignalSetServoAlarmResetLevel을 지원하지 않음.
	if (m_dwModuleID != AXT_ECAT_MOTION)
	{
		dwLevel		= ConvertComboToAxm(&m_cboAlarmReset);
		//++ 선택된 축의 Alarm Reset 신호 Active Level을 설정합니다.
		dwRetCode	= AxmSignalSetServoAlarmResetLevel(m_lAxisNo, dwLevel);
		if(dwRetCode != AXT_RT_SUCCESS){
			strData.Format("AxmSignalSetServoAlarmResetLevel return error[Code:%04d]", dwRetCode);
			MessageBox(strData, "Error", MB_OK | MB_ICONERROR);
		}
	}
}

// ++ =======================================================================
// >> OnChkSwEnable() : "Enable"버튼 클릭시 호출되는 핸들러 함수.
//  - 선택된 축에 Software Limit기능을 설정합니다.
// --------------------------------------------------------------------------
void CSignalMonitorDlg::OnChkSwEnable() 
{
	CString strData;
	double	dSWLimitP, dSWLimitN;
	DWORD	dwSWEnable, dwSWStopMode, dwSWRef, dwRetCode;

	dwSWEnable		= IsDlgButtonChecked(IDC_CHK_SW_ENABLE);
	dwSWStopMode	= ConvertComboToAxm(&m_cboSWStop);
	dwSWRef			= ConvertComboToAxm(&m_cboSWRef);
	dSWLimitP		= GetDlgItemDouble(IDC_EDT_SW_POS_P);
	dSWLimitN		= GetDlgItemDouble(IDC_EDT_SW_POS_N);

	//++ 지정한 축에 Software Limit기능을 설정합니다.
	// ※ [INFO] Software Limit 기능은 원점검색시 무시됩니다. 원점검색이 완료되면 자동으로 이전 상태가 됩니다.
	dwRetCode = AxmSignalSetSoftLimit(m_lAxisNo, dwSWEnable, dwSWStopMode, dwSWRef, dSWLimitP, dSWLimitN);
	if(dwRetCode != AXT_RT_SUCCESS){
		CheckDlgButton(IDC_CHK_SW_ENABLE, FALSE);

		strData.Format("AxmSignalSetSoftLimit return error[Code:%04d]", dwRetCode);
		MessageBox(strData, "Error", MB_OK | MB_ICONERROR);
	}
}

// ++ =======================================================================
// >> OnTimer(...) : 타이머 이벤트 핸들러 함수.
//  - 일정한 주기로 변경되는 위치/속도/정보등을 Control에 반영합니다.
// --------------------------------------------------------------------------
void CSignalMonitorDlg::OnTimer(UINT nIDEvent) 
{
	long	lBitNo = 0;
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

		for(lBitNo = 0; lBitNo < UIO_OUT5; lBitNo++){
			//++ 범용입력 신호의(Bit00-Bit04) 상태를 확인합니다.
			dwRetCode = AxmSignalReadInputBit(m_lAxisNo, lBitNo, &dwState1);
			if(dwRetCode == AXT_RT_SUCCESS)		CheckDlgButton(IDC_CHK_INP_00 + lBitNo, dwState1);

			//++ 범용출력 신호의(Bit00-Bit04) 상태를 확인합니다.
			dwRetCode = AxmSignalReadOutputBit(m_lAxisNo, lBitNo, &dwState2);
			if(dwRetCode == AXT_RT_SUCCESS)		CheckDlgButton(IDC_CHK_OUT_00 + lBitNo, dwState2);
		}

		//++ (+/-)Software Limit의 Active 상태를 확인합니다.
		dwRetCode = AxmSignalReadSoftLimit(m_lAxisNo, &dwState1, &dwState2);
		if(dwRetCode == AXT_RT_SUCCESS){
			m_chkSWLimitP.SetCheck(dwState1);
			m_chkSWLimitN.SetCheck(dwState2);
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
BOOL CSignalMonitorDlg::InitLibrary()
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
BOOL CSignalMonitorDlg::AddAxisInfo()
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
		
	InitControl();							// Control 변수들을 등록하고, 초기 설정값들을 설정합니다.	
	SetTimer(TM_DISPLAY, 100, NULL);		// 일정한 주기로 변경되는 위치/속도/정보등을 Control에 반영할 타이머를 실행합니다.

	return TRUE;
}

// ++ =======================================================================
// >> InitControl() : Control들에 초기값을 설정하는 함수.
//  - Control 변수들을 등록하고, 초기 설정값들을 설정합니다.
// --------------------------------------------------------------------------
BOOL CSignalMonitorDlg::InitControl()
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
BOOL CSignalMonitorDlg::UpdateState()
{
	if(m_lAxisCount < 1)	return FALSE;
	
	double  dSWLimitP = 0.0, dSWLimitN = 0.0;
	DWORD	dwSWEnable = 0, dwSWStopMode = 0, dwSWRef = 0;
	DWORD	dwLevel1 = 0, dwLevel2 = 0, dwRetCode;

	// 각 제품별 지원여부에 따라 콘트롤 값들을 변경합니다.
	switch(m_dwModuleID){
	case AXT_SMC_2V04:
	case AXT_SMC_4V04:		
	case AXT_SMC_R1V04:
	case AXT_SMC_R1V04PM2Q:
	case AXT_SMC_R1V04PM2QE:
		m_cboZPhase.ResetContent();
		m_cboZPhase.EnableWindow(TRUE);
		m_cboZPhase.AddString("00: LOW");
		m_cboZPhase.AddString("01: HIGH");

		m_cboAlarm.ResetContent();
		m_cboAlarm.EnableWindow(TRUE);
		m_cboAlarm.AddString("00: LOW");
		m_cboAlarm.AddString("01: HIGH");
		m_cboAlarm.AddString("02: UNUSED");

		m_cboInp.ResetContent();
		m_cboInp.EnableWindow(TRUE);
		m_cboInp.AddString("00: LOW");
		m_cboInp.AddString("01: HIGH");
		m_cboInp.AddString("02: UNUSED");

		m_cboEmg.ResetContent();
		m_cboEmg.EnableWindow(TRUE);
		m_cboEmg.AddString("00: LOW");
		m_cboEmg.AddString("01: HIGH");
		m_cboEmg.AddString("02: UNUSED");

		m_cboELimitN.ResetContent();
		m_cboELimitN.EnableWindow(TRUE);
		m_cboELimitN.AddString("00: LOW");
		m_cboELimitN.AddString("01: HIGH");
		m_cboELimitN.AddString("02: UNUSED");

		m_cboELimitP.ResetContent();
		m_cboELimitP.EnableWindow(TRUE);
		m_cboELimitP.AddString("00: LOW");
		m_cboELimitP.AddString("01: HIGH");
		m_cboELimitP.AddString("02: UNUSED");

		m_cboServoOn.ResetContent();
		m_cboServoOn.EnableWindow(TRUE);
		m_cboServoOn.AddString("00: LOW");
		m_cboServoOn.AddString("01: HIGH");
		
		m_cboAlarmReset.ResetContent();
		m_cboAlarmReset.EnableWindow(TRUE);
		m_cboAlarmReset.AddString("00: LOW");
		m_cboAlarmReset.AddString("01: HIGH");

		m_cboSWRef.ResetContent();
		m_cboSWRef.EnableWindow(TRUE);
		m_cboSWRef.AddString("00: COMMAND");
		m_cboSWRef.AddString("01: ACTUAL");

		m_cboSWStop.ResetContent();
		m_cboSWStop.EnableWindow(TRUE);
		m_cboSWStop.AddString("00: E_STOP");
		m_cboSWStop.AddString("01: S_STOP");

		m_edtSWPosN.EnableWindow(TRUE);
		m_edtSWPosP.EnableWindow(TRUE);
		m_chkSWEnable.EnableWindow(TRUE);
		break;

	case AXT_SMC_R1V04A4:
		m_cboZPhase.ResetContent();
		m_cboZPhase.EnableWindow(FALSE);
		m_cboZPhase.AddString("02: UNUSED");

		m_cboAlarm.ResetContent();
		m_cboAlarm.EnableWindow(TRUE);
		m_cboAlarm.AddString("01: HIGH");
		m_cboAlarm.AddString("02: UNUSED");
		
		m_cboInp.ResetContent();
		m_cboInp.EnableWindow(TRUE);
		m_cboInp.AddString("01: HIGH");
		m_cboInp.AddString("02: UNUSED");
		
		m_cboEmg.ResetContent();
		m_cboEmg.EnableWindow(TRUE);
		m_cboEmg.AddString("00: LOW");
		m_cboEmg.AddString("02: UNUSED");
		
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

		m_cboSWRef.ResetContent();
		m_cboSWRef.EnableWindow(FALSE);
		m_cboSWRef.AddString("02: UNUSED");
	
		m_cboSWStop.ResetContent();
		m_cboSWStop.EnableWindow(FALSE);
		m_cboSWStop.AddString("02: UNUSED");

		m_edtSWPosN.EnableWindow(FALSE);
		m_edtSWPosP.EnableWindow(FALSE);
		m_chkSWEnable.EnableWindow(FALSE);

		break;

	case AXT_SMC_R1V04MLIIPM:
		m_cboZPhase.ResetContent();
		m_cboZPhase.EnableWindow(FALSE);
		m_cboZPhase.AddString("02: UNUSED");

		m_cboAlarm.ResetContent();
		m_cboAlarm.EnableWindow(FALSE);
		m_cboAlarm.AddString("02: UNUSED");
		
		m_cboInp.ResetContent();
		m_cboInp.EnableWindow(FALSE);
		m_cboInp.AddString("02: UNUSED");
		
		m_cboEmg.ResetContent();
		m_cboEmg.EnableWindow(FALSE);
		m_cboEmg.AddString("02: UNUSED");
		
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
	
		m_cboSWRef.ResetContent();
		m_cboSWRef.EnableWindow(FALSE);
		m_cboSWRef.AddString("02: UNUSED");
		
		m_cboSWStop.ResetContent();
		m_cboSWStop.EnableWindow(FALSE);
		m_cboSWStop.AddString("02: UNUSED");

		m_edtSWPosN.EnableWindow(FALSE);
		m_edtSWPosP.EnableWindow(FALSE);
		m_chkSWEnable.EnableWindow(FALSE);
		break;

	case AXT_SMC_R1V04MLIISV:
	case AXT_SMC_R1V04SIIIHMIV:
		m_cboZPhase.ResetContent();
		m_cboZPhase.EnableWindow(FALSE);
		m_cboZPhase.AddString("02: UNUSED");

		m_cboAlarm.ResetContent();
		m_cboAlarm.EnableWindow(TRUE);
		m_cboAlarm.AddString("01: HIGH");
		m_cboAlarm.AddString("02: UNUSED");
		
		m_cboInp.ResetContent();
		m_cboInp.EnableWindow(TRUE);
		m_cboInp.AddString("01: HIGH");
		m_cboInp.AddString("02: UNUSED");
		
		m_cboEmg.ResetContent();
		m_cboEmg.EnableWindow(FALSE);
		m_cboEmg.AddString("02: UNUSED");
		
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

		m_cboSWRef.ResetContent();
		m_cboSWRef.EnableWindow(FALSE);
		m_cboSWRef.AddString("02: UNUSED");
		
		m_cboSWStop.ResetContent();
		m_cboSWStop.EnableWindow(FALSE);
		m_cboSWStop.AddString("02: UNUSED");

		m_edtSWPosN.EnableWindow(FALSE);
		m_edtSWPosP.EnableWindow(FALSE);
		m_chkSWEnable.EnableWindow(FALSE);
		break;

	case AXT_ECAT_MOTION:
		m_cboZPhase.ResetContent();
		m_cboZPhase.EnableWindow(FALSE);
		m_cboZPhase.AddString("02: UNUSED");

		m_cboAlarm.ResetContent();
		m_cboAlarm.EnableWindow(TRUE);
		m_cboAlarm.AddString("01: HIGH");
		m_cboAlarm.AddString("02: UNUSED");

		m_cboInp.ResetContent();
		m_cboInp.EnableWindow(TRUE);
		m_cboInp.AddString("00: LOW");
		m_cboInp.AddString("01: HIGH");
		m_cboInp.AddString("02: UNUSED");
		m_cboInp.AddString("03: USED");

		m_cboEmg.ResetContent();
		m_cboEmg.EnableWindow(TRUE);
		m_cboEmg.AddString("00: LOW");
		m_cboEmg.AddString("01: HIGH");
		m_cboEmg.AddString("02: UNUSED");
		m_cboEmg.AddString("03: USED");

		m_cboELimitN.ResetContent();
		m_cboELimitN.EnableWindow(TRUE);
		m_cboELimitN.AddString("00: LOW");
		m_cboELimitN.AddString("01: HIGH");
		m_cboELimitN.AddString("02: UNUSED");
		m_cboELimitN.AddString("03: USED");

		m_cboELimitP.ResetContent();
		m_cboELimitP.EnableWindow(TRUE);
		m_cboELimitP.AddString("00: LOW");
		m_cboELimitP.AddString("01: HIGH");
		m_cboELimitP.AddString("02: UNUSED");
		m_cboELimitP.AddString("03: USED");

		m_cboServoOn.ResetContent();
		m_cboServoOn.EnableWindow(FALSE);
		m_cboServoOn.AddString("01: HIGH");

		m_cboAlarmReset.ResetContent();
		m_cboAlarmReset.EnableWindow(FALSE);
		m_cboAlarmReset.AddString("01: HIGH");

		m_cboSWRef.ResetContent();
		m_cboSWRef.EnableWindow(FALSE);
		m_cboSWRef.AddString("02: UNUSED");

		m_cboSWStop.ResetContent();
		m_cboSWStop.EnableWindow(FALSE);
		m_cboSWStop.AddString("02: UNUSED");

		m_edtSWPosN.EnableWindow(FALSE);
		m_edtSWPosP.EnableWindow(FALSE);
		m_chkSWEnable.EnableWindow(FALSE);
		break;
	}
	
	//++ 선택한 축의 Z상 신호 Active Level 설정값을 확인합니다.
	dwRetCode = AxmSignalGetZphaseLevel(m_lAxisNo, &dwLevel1);
	if(dwRetCode != AXT_RT_SUCCESS)	dwLevel1 = UNUSED;
	ConvertAxmToCombo(&m_cboZPhase, dwLevel1);

	//++ 선택한 축의 Servo Alarm 신호 Active Level/사용유무를 확인합니다.
	dwRetCode = AxmSignalGetServoAlarm(m_lAxisNo, &dwLevel1);
	if(dwRetCode != AXT_RT_SUCCESS)	dwLevel1 = UNUSED;
	ConvertAxmToCombo(&m_cboAlarm, dwLevel1);

	//++ 선택한 축의 Inposition(위치결정완료) 신호 Active Level/사용유무를 확인합니다.
	dwRetCode = AxmSignalGetInpos(m_lAxisNo, &dwLevel1);
	if(dwRetCode != AXT_RT_SUCCESS)	dwLevel1 = UNUSED;
	ConvertAxmToCombo(&m_cboInp, dwLevel1);

	//++ 선택한 축의 Emergency 신호 Active Level/사용유무를 확인합니다.
	dwRetCode = AxmSignalGetStop(m_lAxisNo, NULL, &dwLevel1);
	if(dwRetCode != AXT_RT_SUCCESS)	dwLevel1 = UNUSED;
	ConvertAxmToCombo(&m_cboEmg, dwLevel1);

	//++ 선택한 축의 (+/-) End Limit 신호 Active Level/사용유무를 확인합니다.
	dwRetCode = AxmSignalGetLimit(m_lAxisNo, NULL, &dwLevel1, &dwLevel2);
	if(dwRetCode != AXT_RT_SUCCESS)	dwLevel1 = dwLevel2 = UNUSED;
	ConvertAxmToCombo(&m_cboELimitP, dwLevel1);
	ConvertAxmToCombo(&m_cboELimitN, dwLevel2);

	//++ 선택된 축의 Servo On/Off 신호 Active Level을 확인합니다.
	dwRetCode = AxmSignalGetServoOnLevel(m_lAxisNo, &dwLevel1);
	if(dwRetCode != AXT_RT_SUCCESS)	dwLevel1 = UNUSED;
	ConvertAxmToCombo(&m_cboServoOn, dwLevel1);
	
	//++ 선택된 축의 Alarm Reset 신호 Active Level을 확인합니다.
	dwRetCode = AxmSignalGetServoAlarmResetLevel(m_lAxisNo, &dwLevel1);
	if(dwRetCode != AXT_RT_SUCCESS)	dwLevel1 = UNUSED;
	ConvertAxmToCombo(&m_cboAlarmReset, dwLevel1);

	//++ 지정한 축에 Software Limit기능을 확인합니다.
	dwRetCode = AxmSignalGetSoftLimit(m_lAxisNo, &dwSWEnable, &dwSWStopMode, &dwSWRef, &dSWLimitP, &dSWLimitN);
	if(dwRetCode != AXT_RT_SUCCESS)	dwSWStopMode = dwSWRef = UNUSED;

	m_chkSWEnable.SetCheck(dwSWEnable);	
	ConvertAxmToCombo(&m_cboSWRef, dwSWRef);
	ConvertAxmToCombo(&m_cboSWStop, dwSWStopMode);
	SetDlgItemDouble(IDC_EDT_SW_POS_P, dSWLimitP);
	SetDlgItemDouble(IDC_EDT_SW_POS_N, dSWLimitN);
	
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
DWORD CSignalMonitorDlg::ConvertComboToAxm(CComboBox *pCboItem)
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
long CSignalMonitorDlg::ConvertAxmToCombo(CComboBox *pCboItem, DWORD dwCurData)
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
void CSignalMonitorDlg::SetDlgItemDouble(int nID, double value, int nPoint)
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
double CSignalMonitorDlg::GetDlgItemDouble(int nID)
{
	double dRet;
	CString sTemp;
	GetDlgItem(nID)->GetWindowText(sTemp);
	dRet = atof((LPCTSTR)sTemp);
	return dRet;
}
