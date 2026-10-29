// InterruptSettingDlg.cpp : implementation file
//
// **************************************************************************
// >> [일자]: 2016.01.05
// >> [개요]: 이 예제는 인터럽트 함수들의 사용법을 익히고 윈도우 응용프로그램에서
//     여러가지 인터럽트 처리 방법에 대해 학습하는 예제입니다.
// >> [중요]: 인터럽트 사용방법 
//     1) AxlInterruptEnable함수를 이용해서 AXL라이브러리에 인터럽트를 허용합니다.
//     2) AxmInterruptSetAxis함수를 이용해 각 축에 인터럽트 처리 방식을 설정합니다.
//     3) AxmInterruptSetUserEnable함수를 이용해 지정한 축에 사용할 인터럽트 
//        종류들을 설정합니다. Ex) AxmInterruptSetUserEnable(0, INT_BANK_1, 0x6)
//     4) AxmInterruptSetAxisEnable 함수를 이용해 지정한 축에 인터럽트를 허용합니다.
// **************************************************************************

#include "stdafx.h"
#include "InterruptSetting.h"
#include "InterruptSettingDlg.h"

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

#define			TM_DISPLAY		100

// 인터럽트 이벤트 처리 쓰레드 프로시져 선언
UINT			ThreadEventProc(LPVOID lpData);
// 인터럽트 콜벡함수 선언
void __stdcall	MotionIntCallback(long lActiveNo, DWORD dwFlag);
// 메인 다이얼로그 포인트 전역변수
CInterruptSettingDlg *g_MainDlg;

/////////////////////////////////////////////////////////////////////////////
// CInterruptSettingDlg dialog
CInterruptSettingDlg::CInterruptSettingDlg(CWnd* pParent /*=NULL*/)
	: CDialog(CInterruptSettingDlg::IDD, pParent)
{
	//{{AFX_DATA_INIT(CInterruptSettingDlg)
	m_nIntMethod = 0;
	//}}AFX_DATA_INIT
	// Note that LoadIcon does not require a subsequent DestroyIcon in Win32
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);

	//++
	m_lAxisNo		= -1;		// 제어할 축 번호 초기화
	m_lAxisCount	= 0;		// 제어 가능한 축갯수 초기화
	m_lIntCount		= 0;		// 인터럽트 발생 갯수 초기화
	m_dwModuleID	= 0;		// 제어할 축의 모듈ID 초기화
	
	g_MainDlg		= this;		// 메인 다이얼로그 지정

	memset(m_hIntEvent, 0, sizeof(m_hIntEvent));
	memset(m_bThHandle, 0, sizeof(m_bThHandle));
	memset(m_hThHandle, 0, sizeof(m_hThHandle));
}

void CInterruptSettingDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CInterruptSettingDlg)
	DDX_Control(pDX, IDC_CBO_SEL_AXIS, m_cboSelAxis);
	DDX_Radio(pDX, IDC_RDO_MESSAGE, m_nIntMethod);
	DDX_Control(pDX, IDC_LST_INT_LOG, m_lstIntLog);	
	//}}AFX_DATA_MAP
}

BEGIN_MESSAGE_MAP(CInterruptSettingDlg, CDialog)
	//{{AFX_MSG_MAP(CInterruptSettingDlg)
	ON_WM_SYSCOMMAND()
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	ON_BN_CLICKED(IDC_BTN_SET_BANK1, OnBtnSetBank1)
	ON_BN_CLICKED(IDC_BTN_SET_BANK2, OnBtnSetBank2)
	ON_BN_CLICKED(IDC_CHK_INT_ENABLE, OnChkIntEnable)
	ON_CBN_SELCHANGE(IDC_CBO_SEL_AXIS, OnSelchangeCboSelAxis)
	ON_WM_DESTROY()
	ON_WM_TIMER()
	ON_LBN_DBLCLK(IDC_LST_INT_LOG, OnDblclkLstLog)
	//}}AFX_MSG_MAP
	ON_MESSAGE(WM_AXL_INTERRUPT, OnAxmIntMessage)

END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CInterruptSettingDlg message handlers

BOOL CInterruptSettingDlg::OnInitDialog()
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

void CInterruptSettingDlg::OnDestroy() 
{
	CDialog::OnDestroy();
	int i = 0;
	// 인터럽트 처리용 객체 해제
	for(i = 0; i < MAX_AXIS_COUNT; i++)
	{
		if(m_hThHandle[i] != NULL){
			TerminateThread(m_hThHandle[i], 0);
			WaitForSingleObject(m_hThHandle[i],  WAIT_ABANDONED);
			CloseHandle(m_hThHandle[i]);
			m_hThHandle[i] = NULL;
		}
	}

	//++ AXL 사용을 종료합니다.
	AxlClose();	
}

// If you add a minimize button to your dialog, you will need the code below
//  to draw the icon.  For MFC applications using the document/view model,
//  this is automatically done for you by the framework.

void CInterruptSettingDlg::OnPaint() 
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
HCURSOR CInterruptSettingDlg::OnQueryDragIcon()
{
	return (HCURSOR) m_hIcon;
}

// **************************************************************************
// >> [구분]: Control에 이벤트가 발생했을 때 처리하는 함수들 모음 
// **************************************************************************

// ++ =======================================================================
// >> OnSelchangeCboSelAxis() : 축 번호 변경시 호출되는 핸들러 함수.
//  - 축 번호가 변경되었을 때 변경된 축의 모듈 ID와 Control들을 갱신합니다.
// --------------------------------------------------------------------------
void CInterruptSettingDlg::OnSelchangeCboSelAxis() 
{
	m_lAxisNo = m_cboSelAxis.GetCurSel();		// 축 선택 ComboBox에서 선택된 축번호를 제어할 축 번호 변수에 설정합니다.

	//++ 지정한 축번호의 모듈ID를 반환합니다.
	// [INFO] 여러개의 정보를 읽는 함수 사용시 불필요한 정보는 NULL(0)을 입력하면 됩니다.
	AxmInfoGetAxis(m_lAxisNo, NULL, NULL, &m_dwModuleID);
	
	UpdateState();		// 변경한 축의 상태와 Control들의 상태를 일치시킵니다.	
}

// ++ =======================================================================
// >> OnBtnSetBank1() : "Set Bank 1"버튼 클릭시 호출되는 핸들러 함수.
//  - 인터럽트 Bank1에 설정가능한 인터럽트를 설정합니다.
// --------------------------------------------------------------------------
void CInterruptSettingDlg::OnBtnSetBank1() 
{
	int		i;
	CString strIntMask, strData;
	DWORD	dwIntMask = 0, dwRetCode;
	DWORD	dwBitMask[MAX_BANK_1] = {QIINTBANK1_0, QIINTBANK1_1, QIINTBANK1_2, QIINTBANK1_31};

	for(i = 0; i < MAX_BANK_1; i++){
		if(IsDlgButtonChecked(IDC_CHK_BANK1_BIT_00 + i))
			dwIntMask |= dwBitMask[i];
	}

	//++ 지정한 축에 모션구동 시작시, 모셔구동 종료시 등의 인터럽트를 설정합니다.
	dwRetCode = AxmInterruptSetUserEnable(m_lAxisNo, INT_BANK_1, dwIntMask);
	if(dwRetCode != AXT_RT_SUCCESS){
		strData.Format("AxmInterruptSetUserEnable return error[Code:%04d]", dwRetCode);
		MessageBox(strData, "Error", MB_OK | MB_ICONERROR);
	}

	UpdateState();	
}

// ++ =======================================================================
// >> OnBtnSetBank2() : "Set Bank 2"버튼 클릭시 호출되는 핸들러 함수.
//  - 인터럽트 Bank2에 설정가능한 인터럽트를 설정합니다.
// --------------------------------------------------------------------------
void CInterruptSettingDlg::OnBtnSetBank2() 
{
	int		i;
	CString strIntMask, strData;
	DWORD	dwIntMask = 0, dwRetCode;
	DWORD	dwBitMask[MAX_BANK_2] = {QIINTBANK2_14, QIINTBANK2_15, QIINTBANK2_16, QIINTBANK2_20, QIINTBANK2_21, QIINTBANK2_22};
	
	for(i = 0; i < MAX_BANK_2; i++){
		if(IsDlgButtonChecked(IDC_CHK_BANK2_BIT_14 + i))
			dwIntMask |= dwBitMask[i];
	}
	
	//++ 지정한 축에 범용입력 변화시, 범용출력 변화시 등의 인터럽트를 설정합니다.
	dwRetCode = AxmInterruptSetUserEnable(m_lAxisNo, INT_BANK_2, dwIntMask);
	if(dwRetCode != AXT_RT_SUCCESS){
		strData.Format("AxmInterruptSetUserEnable return error[Code:%04d]", dwRetCode);
		MessageBox(strData, "Error", MB_OK | MB_ICONERROR);
	}
	
	UpdateState();
}

// ++ =======================================================================
// >> OnChkIntEnable() : "Interrupt Enable"버튼 클릭시 호출되는 핸들러 함수.
//  - 인터럽트 처리 방식에 따라 인터럽트를 설정합니다.
// ※ [CAUTION] 인터럽트 사용시 사용자가 구현하는 인터럽트 처리함수는 되도록이면
//    간결하게 작성하는게 좋습니다(콘트롤 업데이트등은 옳지 않음). 왜냐하면 
//    인터럽트가 발생하는 시간보다 함수처리 시간이 길어지게되면 놓치는 경우가 
//    빈번하게 발생할 수 있기 때문입니다.
// --------------------------------------------------------------------------
void CInterruptSettingDlg::OnChkIntEnable() 
{
	CString strData;
	DWORD	dwRetCode;

	UpdateData();
	
	if(IsDlgButtonChecked(IDC_CHK_INT_ENABLE)){
		switch(m_nIntMethod)
		{
		case INT_MESSAGE: 
			//++ 인터럽트 처리방식을 윈도우메세지 방식으로 지정함
			AxmInterruptSetAxis(m_lAxisNo, GetSafeHwnd(), WM_AXL_INTERRUPT, NULL, NULL);
			break;
		case INT_CALLBACK:
			//++ 인터럽트 처리방식을 콜벡함수 방식으로 지정함
			AxmInterruptSetAxis(m_lAxisNo, NULL, 0, MotionIntCallback, NULL);
			break;
		case INT_EVENT: 
			//++ 인터럽트 처리방식을 이벤트 방식으로 지정함
			AxmInterruptSetAxis(m_lAxisNo, NULL, 0, NULL, &m_hIntEvent[m_lAxisNo]);
			if (m_bThHandle[m_lAxisNo] == FALSE){

				m_bThHandle[m_lAxisNo] = TRUE;
				// 해당축의 인터럽트 이벤트를 대기할 쓰레드 생성
				m_hThHandle[m_lAxisNo]	= CreateThread(NULL, 0, (LPTHREAD_START_ROUTINE)ThreadEventProc, this, NULL, NULL);
			}
			break;
		}
		//++ AXL라이브러리의 인터럽트 발생을 허용합니다.
		AxlInterruptEnable();
		//++ 지정한 축에 인터럽트 발생을 허용합니다.
		dwRetCode = AxmInterruptSetAxisEnable(m_lAxisNo, ENABLE);
		if(dwRetCode != AXT_RT_SUCCESS){
			CheckDlgButton(IDC_CHK_INT_ENABLE, FALSE);

			strData.Format("AxmInterruptSetAxisEnable return error[Code:%04d]", dwRetCode);
			MessageBox(strData, "Error", MB_OK | MB_ICONERROR);
		}
	}else{
		//++ AXL라이브러리의 인터럽트 발생을 금지합니다.
		AxlInterruptDisable();
		//++ 지정한 축에 인터럽트 발생을 금지합니다.
		dwRetCode = AxmInterruptSetAxisEnable(m_lAxisNo, DISABLE);
		if(dwRetCode != AXT_RT_SUCCESS){
			CheckDlgButton(IDC_CHK_INT_ENABLE, TRUE);

			strData.Format("AxmInterruptSetAxisEnable return error[Code:%04d]", dwRetCode);
			MessageBox(strData, "Error", MB_OK | MB_ICONERROR);
		}
	}	
}

// ++ =======================================================================
// >> OnDblclkLstLog() : ListBox 콘트롤 마우스 더블클릭시 호출되는 핸들러 함수.
//  - 등록된 인터럽트 로그를 지울때 호출됩니다.
//  - List Box 콘트롤에서 마우스 오르쪽 버튼을 더블클릭하면 이 함수가 호출됩니다.
// --------------------------------------------------------------------------
void CInterruptSettingDlg::OnDblclkLstLog() 
{
	m_lIntCount = 0;
	m_aIntItem.RemoveAll();	
	m_lstIntLog.ResetContent();
}

// ++ =======================================================================
// >> OnTimer(...) : 타이머 이벤트 핸들러 함수.
//  - 일정한 주기로 변경되는 위치/속도/정보등을 Control에 반영합니다.
// --------------------------------------------------------------------------
void CInterruptSettingDlg::OnTimer(UINT nIDEvent) 
{	
	int i, nCntFront, nCntRear;

	switch(nIDEvent){
	case TM_DISPLAY:
		nCntRear	= m_lstIntLog.GetCount();
		nCntFront	= m_aIntItem.GetSize();

		// 인터럽트 정보를 담고있는 어레이에 데이타가 추가된만큼 List Box에 등록함.
		for(i = nCntRear; i < nCntFront; i++){
			AddMsgToLog(m_aIntItem.GetAt(i));
			nCntRear++;
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
BOOL CInterruptSettingDlg::InitLibrary()
{
	//++ AXL(AjineXtek Library)을 사용가능하게 하고 장착된 보드들을 초기화합니다.
	if ((AxlOpen(7) != AXT_RT_SUCCESS)){
		AfxMessageBox("AxlOpen Fail...");
		return FALSE;
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
BOOL CInterruptSettingDlg::AddAxisInfo()
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
		case AXT_SMC_R1V04A4:		strData.Format("%02ld-[RTEX-A4N]   : Not support interrupt", i);	break;
		case AXT_SMC_R1V04A5:		strData.Format("%02ld-[RTEX-A5N]   : Not support interrupt", i);	break;
		case AXT_SMC_R1V04:			strData.Format("%02ld-[RTEX-PM]    : Not support interrupt", i);	break;
		case AXT_SMC_R1V04PM2Q:		strData.Format("%02ld-[RTEX-PM2Q]  : Not support interrupt", i);	break;
		case AXT_SMC_R1V04PM2QE:	strData.Format("%02ld-[RTEX-PM2QE] : Not support interrupt", i);	break;
		case AXT_SMC_R1V04MLIISV:	strData.Format("%02ld-[MLII-SGDV]  : Not support interrupt", i);	break;
		case AXT_SMC_R1V04MLIIPM:	strData.Format("%02ld-[MLII-PM]    : Not support interrupt", i);	break;
		case AXT_SMC_R1V04MLIICL:	strData.Format("%02ld-[MLII-CSDL]  : Not support interrupt", i);	break;
		case AXT_SMC_R1V04MLIICR:	strData.Format("%02ld-[MLII-CSDH]  : Not support interrupt", i);	break;
		case AXT_SMC_R1V04SIIIHMIV:	strData.Format("%02ld-[SIIIH-MRJ4] : Not support interrupt", i);	break;
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
	SetTimer(TM_DISPLAY, 100, NULL);	// 일정한 주기로 변경되는 인터럽트 정보를 Control에 반영할 타이머를 실행합니다.
	return TRUE;
}

// ++ =======================================================================
// >> InitControl() : Control들에 초기값을 설정하는 함수.
//  - Control 변수들을 등록하고, 초기 설정값들을 설정합니다.
// --------------------------------------------------------------------------
BOOL CInterruptSettingDlg::InitControl()
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
BOOL CInterruptSettingDlg::UpdateState()
{
	if(m_lAxisCount < 1)	return FALSE;

	DWORD	dwIntMask = 0, dwOnOff = 0;
	CString strIntMask;

	//++ 지정한 축의 인터럽트 Bank1의 설정값을 확인합니다.
	AxmInterruptGetUserEnable(m_lAxisNo, INT_BANK_1, &dwIntMask);
	strIntMask.Format("Interrupt Event Bank 1 [0x%08X]", dwIntMask);
	SetDlgItemText(IDC_GRP_BANK1, strIntMask);
	
	// 인터럽트 설정값 해당 콘트롤에 적용
	CheckDlgButton(IDC_CHK_BANK1_BIT_00, dwIntMask & QIINTBANK1_0);
	CheckDlgButton(IDC_CHK_BANK1_BIT_01, dwIntMask & QIINTBANK1_1);
	CheckDlgButton(IDC_CHK_BANK1_BIT_02, dwIntMask & QIINTBANK1_2);
	CheckDlgButton(IDC_CHK_BANK1_BIT_31, dwIntMask & QIINTBANK1_31);

	//++ 지정한 축의 인터럽트 Bank2의 설정값을 확인합니다.
	AxmInterruptGetUserEnable(m_lAxisNo, INT_BANK_2, &dwIntMask);
	strIntMask.Format("Interrupt Event Bank 2 [0x%08X]", dwIntMask);
	SetDlgItemText(IDC_GRP_BANK2, strIntMask);	
	
	// 인터럽트 설정값 해당 콘트롤에 적용
	CheckDlgButton(IDC_CHK_BANK2_BIT_14, dwIntMask & QIINTBANK2_14);
	CheckDlgButton(IDC_CHK_BANK2_BIT_15, dwIntMask & QIINTBANK2_15);
	CheckDlgButton(IDC_CHK_BANK2_BIT_16, dwIntMask & QIINTBANK2_16);
	CheckDlgButton(IDC_CHK_BANK2_BIT_20, dwIntMask & QIINTBANK2_20);
	CheckDlgButton(IDC_CHK_BANK2_BIT_21, dwIntMask & QIINTBANK2_21);
	CheckDlgButton(IDC_CHK_BANK2_BIT_22, dwIntMask & QIINTBANK2_22);

	return TRUE;
}

// ++ =======================================================================
// >> AddMsgToLog(...) : 인터럽트 정보를 List Box에 등록하는 함수.
//  - 인터럽트 정보를 List Box에 등록하고 항상 최신데이타가 List Box에 보여지도록 
//    자동 스크롤을 해 줍니다.
// --------------------------------------------------------------------------
void CInterruptSettingDlg::AddMsgToLog(STIntItem stIntItem)
{
	CString strData;
	
	switch(stIntItem.byIntType){
	case INT_MESSAGE:
		strData.Format("[%03d][M] AxisNo: %02d, Flag: %d[%XH], Bank0: %d[%XH], Bank1: %d[%XH]\n", 
			++m_lIntCount, stIntItem.lAxisNo, stIntItem.dwIntFlag, stIntItem.dwIntFlag, stIntItem.dwBank0, stIntItem.dwBank0, stIntItem.dwBank1, stIntItem.dwBank1);
		break;
		
	case INT_CALLBACK:
		strData.Format("[%03d][C] AxisNo: %02d, Flag: %d[%XH], Bank0: %d[%XH], Bank1: %d[%XH]\n", 
			++m_lIntCount, stIntItem.lAxisNo, stIntItem.dwIntFlag, stIntItem.dwIntFlag, stIntItem.dwBank0, stIntItem.dwBank0, stIntItem.dwBank1, stIntItem.dwBank1);
		break;
		
	case INT_EVENT:
		strData.Format("[%03d][E] AxisNo: %02d, Flag: %d[%XH], Bank0: %d[%XH], Bank1: %d[%XH]\n", 
			++m_lIntCount, stIntItem.lAxisNo, stIntItem.dwIntFlag, stIntItem.dwIntFlag, stIntItem.dwBank0, stIntItem.dwBank0, stIntItem.dwBank1, stIntItem.dwBank1);
		
		break;
	}
	m_lstIntLog.AddString(strData);
	m_lstIntLog.SetCurSel(m_lstIntLog.GetCount() - 1);
}

// ++ =======================================================================
// >> OnAxmIntMessage(...) : 인터럽트 메시지 핸들러 함수.
//  - 인터럽트 방식중 윈도 메세지 방식으로 인터럽트를 사용할 경우 라이브러리에서
//    인터럽트 발생시 자동으로 호출되는 인터럽트 메세지 처리 함수입니다.
//  - wParam에는 축정보가 전달됩니다.
//  - lParam에는 인터럽트가 발생된 Bank정보가 전달 됩니다.
// --------------------------------------------------------------------------
LRESULT CInterruptSettingDlg::OnAxmIntMessage(WPARAM wParam, LPARAM lParam)
{
	SYSTEMTIME	time;
	STIntItem	stIntItem;
	
	long		lAxisNo;
	DWORD		dwIntBank0, dwIntBank1;

	lAxisNo = (long)wParam;
	GetSystemTime(&time);
	sprintf(stIntItem.szTime, "%02d:%02d:%02d.%03d", time.wHour, time.wMinute, time.wSecond, time.wMilliseconds);

	//++ 지정한 축의 인터럽트 발생 Flag를 확인합니다.
	AxmInterruptReadAxisFlag(lAxisNo, 0, &dwIntBank0);
	AxmInterruptReadAxisFlag(lAxisNo, 1, &dwIntBank1);

	stIntItem.lAxisNo	= lAxisNo;
	stIntItem.byIntType = INT_MESSAGE;
	stIntItem.dwBank0	= dwIntBank0;
	stIntItem.dwBank1	= dwIntBank1;
	stIntItem.dwIntFlag = (DWORD)lParam;

	m_aIntItem.Add(stIntItem);	// 인터럽트 정보 어레이에 추가합니다.

	return TRUE;
}

// ++ =======================================================================
// >> MotionIntCallback(...) : 인터럽트 처리 콜벡함수.
//  - 인터럽트 방식중 콜벡함수 방식으로 인터럽트를 사용할 경우 라이브러리에서
//    인터럽트 발생시 자동으로 호출되는 인터럽트 콜벡함수입니다.
//  - lActiveNo에는 인터럽트 발생 축 정보가 전달됩니다.
//  - dwFlag에는 인터럽트가 발생된 Bank정보가 전달 됩니다.
// --------------------------------------------------------------------------
void __stdcall MotionIntCallback(long lActiveNo, DWORD dwFlag)
{
	SYSTEMTIME	time;
	STIntItem	stIntItem;
	
	long		lAxisNo;
	DWORD		dwIntBank0, dwIntBank1;
	
	lAxisNo = lActiveNo;
	GetSystemTime(&time);
	sprintf(stIntItem.szTime, "%02d:%02d:%02d.%03d", time.wHour, time.wMinute, time.wSecond, time.wMilliseconds);
	
	//++ 지정한 축의 인터럽트 발생 Flag를 확인합니다.
	AxmInterruptReadAxisFlag(lAxisNo, 0, &dwIntBank0);
	AxmInterruptReadAxisFlag(lAxisNo, 1, &dwIntBank1);
	
	stIntItem.lAxisNo	= lAxisNo;
	stIntItem.byIntType = INT_CALLBACK;
	stIntItem.dwBank0	= dwIntBank0;
	stIntItem.dwBank1	= dwIntBank1;
	stIntItem.dwIntFlag = dwFlag;
	
	g_MainDlg->m_aIntItem.Add(stIntItem);	// 인터럽트 정보 어레이에 추가합니다.
}

// ++ =======================================================================
// >> ThreadEventProc(...) : 인터럽트 이벤트 처리 쓰레드.
//  - 인터럽트 방식중 이벤트 방식으로 인터럽트를 사용할 경우 라이브러리에서
//    인터럽트 발생시 자동으로 발생되는 인터럽트 이벤트 처리용 쓰레드입니다.
// --------------------------------------------------------------------------
UINT ThreadEventProc(LPVOID lpData)
{
	CInterruptSettingDlg *pDlg	= (CInterruptSettingDlg *)lpData;
	long lAxisNo = pDlg->m_lAxisNo;
	
	SYSTEMTIME	time;
	STIntItem	stIntItem;
	DWORD		dwIntBank0, dwIntBank1;
	
	while(pDlg->m_bThHandle[lAxisNo])
	{
		// 인터럽트 이벤트가 발생될 때 까지 100msec동안 대기함
		if (WaitForSingleObject(pDlg->m_hIntEvent[lAxisNo], 100) == WAIT_OBJECT_0){		// 인터럽트 이벤트가 발생했다면...
			GetSystemTime(&time);
			sprintf(stIntItem.szTime, "%02d:%02d:%02d.%03d", time.wHour, time.wMinute, time.wSecond, time.wMilliseconds);

			//++ 지정한 축의 인터럽트 발생 Flag를 확인합니다.
            AxmInterruptReadAxisFlag(lAxisNo, 0, &dwIntBank0);
			AxmInterruptReadAxisFlag(lAxisNo, 1, &dwIntBank1);
			
			stIntItem.lAxisNo	= lAxisNo;
			stIntItem.byIntType = INT_EVENT;
			stIntItem.dwBank0	= dwIntBank0;
			stIntItem.dwBank1	= dwIntBank1;

			if((dwIntBank0 != 0x0) && (dwIntBank1 != 0))	stIntItem.dwIntFlag = 0x3;
			else if(dwIntBank0 != 0x0)						stIntItem.dwIntFlag = 0x1;	
			else if(dwIntBank1 != 0x0)						stIntItem.dwIntFlag = 0x2;	
			else											stIntItem.dwIntFlag = 0x0;	

			pDlg->m_aIntItem.Add(stIntItem);	// 인터럽트 정보 어레이에 추가합니다.
		}
	}

	pDlg->m_bThHandle[lAxisNo] = FALSE;
	pDlg->m_hThHandle[lAxisNo] = NULL;

	return 0;
}
