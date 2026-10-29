// OutputWriteSingleDlg.cpp : implementation file
//
// **************************************************************************
// >> [일자]: 2016.01.14
// >> [개요]: 이 예제는 AIO모듈의 단일 채널 출력 기능 사용 방법을 학습하는 예제입니다.
// >> [중요]: 출력 관련 함수들
//     1) AxaoSetRange 함수는 지정한 출력 채널에 출력 전압 범위를 설정합니다.
//     2) AxaoWriteVoltage 함수는 지정한 출력 채널에 특정 전압 값을 출력합니다.
//     3) AxaoReadVoltage 함수는 지정한 출력 채널에 출력하고 있는 전압 값을
//        확인합니다.
// **************************************************************************

#include "stdafx.h"
#include "OutputWriteSingle.h"
#include "OutputWriteSingleDlg.h"

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
#include "../../../../AXL(Library)/C, C++/AXA.h"
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
// CAboutDlg dialog used for App About

class CAboutDlg : public CDialog
{
public:
	CAboutDlg();

// Dialog Data
	//{{AFX_DATA(CAboutDlg)
	enum { IDD = IDD_ABOUTBOX };
	//}}AFX_DATA

	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CAboutDlg)
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support
	//}}AFX_VIRTUAL

// Implementation
protected:
	//{{AFX_MSG(CAboutDlg)
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};

CAboutDlg::CAboutDlg() : CDialog(CAboutDlg::IDD)
{
	//{{AFX_DATA_INIT(CAboutDlg)
	//}}AFX_DATA_INIT
}

void CAboutDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CAboutDlg)
	//}}AFX_DATA_MAP
}

BEGIN_MESSAGE_MAP(CAboutDlg, CDialog)
	//{{AFX_MSG_MAP(CAboutDlg)
		// No message handlers
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// COutputWriteSingleDlg dialog

COutputWriteSingleDlg::COutputWriteSingleDlg(CWnd* pParent /*=NULL*/)
	: CDialog(COutputWriteSingleDlg::IDD, pParent)
{
	//{{AFX_DATA_INIT(COutputWriteSingleDlg)
		// NOTE: the ClassWizard will add member initialization here
	//}}AFX_DATA_INIT
	// Note that LoadIcon does not require a subsequent DestroyIcon in Win32
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
}

void COutputWriteSingleDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(COutputWriteSingleDlg)
	DDX_Control(pDX, IDC_SLI_VOLTAGE, m_sliVoltage);
	DDX_Control(pDX, IDC_STC_OUTPUT_VOLTAGE, m_stcOutputVoltage);
	DDX_Control(pDX, IDC_EDT_SETTING_VOLTAGE, m_edtSettingVoltage);
	DDX_Control(pDX, IDC_CBO_VOLTAGE_RANGE, m_cboVoltageRange);
	DDX_Control(pDX, IDC_CBO_MODULE, m_cboModule);
	DDX_Control(pDX, IDC_CBO_CHANNEL, m_cboChannel);
	DDX_Control(pDX, IDC_BTN_SET, m_btnSet);
	//}}AFX_DATA_MAP
}

BEGIN_MESSAGE_MAP(COutputWriteSingleDlg, CDialog)
	//{{AFX_MSG_MAP(COutputWriteSingleDlg)
	ON_WM_SYSCOMMAND()
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	ON_CBN_SELCHANGE(IDC_CBO_MODULE, OnSelchangeCboModule)
	ON_CBN_SELCHANGE(IDC_CBO_CHANNEL, OnSelchangeCboChannel)
	ON_BN_CLICKED(IDC_BTN_SET, OnBtnSet)
	ON_CBN_SELCHANGE(IDC_CBO_VOLTAGE_RANGE, OnSelchangeCboVoltageRange)
	ON_WM_DESTROY()
	ON_WM_TIMER()
	ON_NOTIFY(NM_RELEASEDCAPTURE, IDC_SLI_VOLTAGE, OnReleasedcaptureSliVoltage)
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// COutputWriteSingleDlg message handlers

BOOL COutputWriteSingleDlg::OnInitDialog()
{
	CDialog::OnInitDialog();

	// Add "About..." menu item to system menu.

	// IDM_ABOUTBOX must be in the system command range.
	ASSERT((IDM_ABOUTBOX & 0xFFF0) == IDM_ABOUTBOX);
	ASSERT(IDM_ABOUTBOX < 0xF000);

	CMenu* pSysMenu = GetSystemMenu(FALSE);
	if (pSysMenu != NULL)
	{
		CString strAboutMenu;
		strAboutMenu.LoadString(IDS_ABOUTBOX);
		if (!strAboutMenu.IsEmpty())
		{
			pSysMenu->AppendMenu(MF_SEPARATOR);
			pSysMenu->AppendMenu(MF_STRING, IDM_ABOUTBOX, strAboutMenu);
		}
	}

	// Set the icon for this dialog.  The framework does this automatically
	//  when the application's main window is not a dialog
	SetIcon(m_hIcon, TRUE);			// Set big icon
	SetIcon(m_hIcon, FALSE);		// Set small icon
	
	//++
	InitLibrary();					// 라이브러리 초기화 작업을 수행합니다.
	AddModuleChannelInfo();			// 검색된 모듈과 채널 정보를 ComboBox에 등록/Control들을 초기화합니다.
	UpdateState();					// AIO모듈의 상태와 Control들의 상태를 일치시킵니다.
	
	return TRUE;  // return TRUE  unless you set the focus to a control
}

void COutputWriteSingleDlg::OnSysCommand(UINT nID, LPARAM lParam)
{
	if ((nID & 0xFFF0) == IDM_ABOUTBOX)
	{
		CAboutDlg dlgAbout;
		dlgAbout.DoModal();
	}
	else
	{
		CDialog::OnSysCommand(nID, lParam);
	}
}

// If you add a minimize button to your dialog, you will need the code below
//  to draw the icon.  For MFC applications using the document/view model,
//  this is automatically done for you by the framework.

void COutputWriteSingleDlg::OnPaint() 
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
HCURSOR COutputWriteSingleDlg::OnQueryDragIcon()
{
	return (HCURSOR) m_hIcon;
}

void COutputWriteSingleDlg::OnDestroy() 
{
	CDialog::OnDestroy();
	
	//++ AXL 사용을 종료합니다.
	AxlClose();
}

// **************************************************************************
// >> [구분]: Control에 이벤트가 발생했을 때 처리하는 함수들 모음 
// **************************************************************************

// ++ =======================================================================
// >> OnSelchangeCboModule() : 모듈 변경시 호출되는 핸들러 함수.
//  - 모듈이 변경되었을 때 변경된 모듈의 ID와 Control들을 갱신합니다.
// --------------------------------------------------------------------------
void COutputWriteSingleDlg::OnSelchangeCboModule() 
{
	DWORD dwRetCode = 0;
	long lBoardNo = 0, lModulePos = 0;	
	CString strChNum, strData, strValue;
	double dVolt = 0.0;
	
	m_lModuleNo = m_cboModule.GetCurSel();
	//++ 변경된 모듈의 ID를 가져옵니다.
	AxaInfoGetModule(m_lModuleNo, &lBoardNo, &lModulePos, &m_dwModuleID);
	
	//++ 채널 업데이트
	m_cboChannel.ResetContent();	
	//++ 변경된 모듈의 채널 수를 가져옵니다.
	AxaInfoGetInputCount(m_lModuleNo, &m_lChannelCount);
	for(int i=0; i < m_lChannelCount; i++)
	{		
		strChNum.Format("%02d", i);
		m_cboChannel.AddString(strChNum);
	}
	m_cboChannel.SetCurSel(0);
	m_lChannelNo = 0;
	
	//++ 전압 범위 업데이트
	// 지정 입력 채널에 설정한 입력 전압 범위를 확인합니다.
	UpdateVoltageRange();

	//++ 모듈 변경 시 0번 채널에서 출력하던 값 그대로 EDIT와 슬라이더에도 반영
	dwRetCode = AxaoReadVoltage(m_lChannelNo, &dVolt);
	if(dwRetCode != AXT_RT_SUCCESS)
	{
		strData.Format("AxaoReadVoltage return error[Code:%04d]", dwRetCode);
		MessageBox(strData, "Error", MB_OK | MB_ICONERROR);
	}
	strValue.Format("%.4f", dVolt);
	m_edtSettingVoltage.SetWindowText(strValue);
	m_sliVoltage.SetPos((int)dVolt);
}

// ++ =======================================================================
// >> OnSelchangeCboChannel() : 채널 변경시 호출되는 핸들러 함수.
//  - 채널이 변경되었을 때 변경된 채널에 대한 정보로 갱신합니다.
// --------------------------------------------------------------------------
void COutputWriteSingleDlg::OnSelchangeCboChannel() 
{
	DWORD dwRetCode = 0;
	CString strData, strValue;
	double dVolt = 0.0;

	m_lChannelNo = ConvertComboToAxa(&m_cboChannel);
	
	//++ 전압 범위 업데이트
	// 지정 입력 채널에 설정한 출력 전압 범위를 확인합니다.
	UpdateVoltageRange();

	//++ 채널 변경 시 해당 채널에서 출력하던 값 그대로 EDIT와 슬라이더에도 반영
	dwRetCode = AxaoReadVoltage(m_lChannelNo, &dVolt);
	if(dwRetCode != AXT_RT_SUCCESS)
	{
		strData.Format("AxaoReadVoltage return error[Code:%04d]", dwRetCode);
		MessageBox(strData, "Error", MB_OK | MB_ICONERROR);
	}
	strValue.Format("%.4f", dVolt);
	m_edtSettingVoltage.SetWindowText(strValue);
	m_sliVoltage.SetPos((int)dVolt);
}

// ++ =======================================================================
// >> OnSelchangeCboVoltageRange() : 출력 전압 범위 변경시 호출되는 핸들러 함수.
//  - 해당 채널의 출력 전압 범위를 갱신합니다.
//  - 출력 전압 범위는 A/D변환 성능과 관련이 있으므로 측정 범위 확인 후 설정하시기 바랍니다.
//  - 모듈별로 허용 출력 전압이 정해져 있습니다. 
//  - 사용자가 출력 전압 설정범위 이외 전압을 입력하면 자동으로 그 값을 포함하는 근삿값으로 자동 설정됩니다.
// --------------------------------------------------------------------------
void COutputWriteSingleDlg::OnSelchangeCboVoltageRange() 
{
	DWORD	dwRetCode = 0;
	double	dMinVolt = 0.0, dMaxVolt = 0.0;
	
	switch(m_cboVoltageRange.GetCurSel())
	{
	case 0:
		dMinVolt = -10.0;
		dMaxVolt = 10.0;
		break;
		
	case 1:
		dMinVolt = -5.0;
		dMaxVolt = 5.0;
		break;
		
	case 2:
		dMinVolt = 0.0;
		dMaxVolt = 10.0;
		break;
		
	case 3:
		dMinVolt = 0.0;
		dMaxVolt = 5.0;
		break;
		
	default:
		break;
	}
	
	//++ 출력 전압 범위를 설정합니다.
	dwRetCode = AxaoSetRange(m_lChannelNo, dMinVolt, dMaxVolt);
	if(dwRetCode != AXT_RT_SUCCESS)
	{
		CString strData;
		strData.Format("AxaoSetRange return error[Code:%04d]", dwRetCode);
		MessageBox(strData, "Error", MB_OK | MB_ICONERROR);
	}

	//++ 변경된 전압 범위를 반영합니다.
	UpdateVoltageRange();
}

// ++ =======================================================================
// >> OnBtnSet() : "Set"버튼 클릭시 호출되는 핸들러 함수.
//  - 지정한 출력 채널로 전압을 출력합니다.
// --------------------------------------------------------------------------
void COutputWriteSingleDlg::OnBtnSet() 
{
	CString strValue, strData;
	double	dOutputVolt = 0.0;
	DWORD	dwRetCode = 0;
	
	m_dOldVolt = 0.0;
	
	m_edtSettingVoltage.GetWindowText(strValue);
	dOutputVolt = atof(strValue);

	//++ 출력 전압 변경
	dwRetCode = AxaoWriteVoltage(m_lChannelNo, dOutputVolt);
	if(dwRetCode != AXT_RT_SUCCESS)
	{
		strData.Format("AxaoWriteVoltage return error[Code:%04d]", dwRetCode);
		MessageBox(strData, "Error", MB_OK | MB_ICONERROR);
	}
	
	//++ 슬라이더 변경
	m_sliVoltage.SetPos((int)dOutputVolt);	
}

// ++ =======================================================================
// >> OnReleasedcaptureSliVoltage(...) : 출력 전압 슬라이더 조작 시 호출되는 핸들러 함수.
//  - 출력 전압 슬라이더를 조작하여 출력 전압을 실시간으로 적용합니다.
// --------------------------------------------------------------------------
void COutputWriteSingleDlg::OnReleasedcaptureSliVoltage(NMHDR* pNMHDR, LRESULT* pResult) 
{
	CString strData;
	DWORD	dwRetCode = 0;
	
	// 변경된 슬라이더 위치를 에디트 컨트롤에 반영
	int iSliderPos = m_sliVoltage.GetPos();
	strData.Format("%.4f", (double)iSliderPos);
	m_edtSettingVoltage.SetWindowText(strData);
	
	//++ 출력값을 변경합니다.
	dwRetCode = AxaoWriteVoltage(m_lChannelNo, (double)iSliderPos);
	if(dwRetCode != AXT_RT_SUCCESS)
	{
		strData.Format("AxaoWriteVoltage return error[Code:%04d]", dwRetCode);
		MessageBox(strData, "Error", MB_OK | MB_ICONERROR);
	}
	
	*pResult = 0;
}

// ++ =======================================================================
// >> OnTimer(...) : 타이머 이벤트 핸들러 함수.
//  - 출력되고 있는 전압 값을 주기적으로 갱신합니다.
// --------------------------------------------------------------------------
void COutputWriteSingleDlg::OnTimer(UINT nIDEvent) 
{	
	double dVolt = 0.0;
	CString strValue;

	switch (nIDEvent)
	{
	case TM_DISPLAY:
		
		//++ 지정 채널에 출력하고 있는 값을 전압 단위로 읽어옵니다.
		AxaoReadVoltage(m_lChannelNo, &dVolt);
		
		if (m_dOldVolt != dVolt)
		{
			strValue.Format("%.4lf", dVolt);
			m_stcOutputVoltage.SetWindowText(strValue);
			m_dOldVolt = dVolt;
		}
		break;
		
	default:
		break;
	}

	CDialog::OnTimer(nIDEvent);
}

// **************************************************************************
// >> [구분]: 별도의 기능을 구현하기위해 만든 사용자 정의 함수들 모음 
// **************************************************************************

// ++ =======================================================================
// >> InitLibrary() : 라이브러리 초기화 함수.
//  - AXL(AjineXtek Library)을 사용가능하게 합니다. 
// --------------------------------------------------------------------------
BOOL COutputWriteSingleDlg::InitLibrary()
{
	//++ AXL(AjineXtek Library)을 사용가능하게 하고 장착된 보드들을 초기화합니다.
	DWORD dwStatus = 0;
	DWORD dwRetCode = AxlOpenNoReset(7);			// 설정값들을 초기화하지 않음
	long lModuleCounts = 0;

	if (dwRetCode != AXT_RT_SUCCESS){
		AfxMessageBox("AxlOpen Fail...", MB_OK, 0);
		return FALSE;
	}

	TRACE("The library became the initialization.\n");
	dwRetCode = AxaInfoIsAIOModule(&dwStatus);		// AIO모듈 존재여부를 확인합니다
	if (dwStatus != STATUS_EXIST)
	{
		AfxMessageBox("The module does not exist...", MB_OK, 0);
		return FALSE;
	}

	TRACE("AIO module exists.\n");
	return TRUE;
}

// ++ =======================================================================
// >> InitControl() : Control들에 초기값을 설정하는 함수.
//  - Control 변수들을 등록하고, 초기 설정값들을 설정합니다.
// --------------------------------------------------------------------------
BOOL COutputWriteSingleDlg::InitControl()
{
	m_lModuleNo = 0;
	m_lChannelNo = 0;

	m_cboModule.SetCurSel(0);	
	m_cboChannel.SetCurSel(0);	

	//++ 첫번째 모듈의 ID를 가져옵니다.
	AxaInfoGetModule(m_lModuleNo, NULL, NULL, &m_dwModuleID);

	return TRUE;
}

// ++ =======================================================================
// >> AddModuleChannelInfo() : 시스템에 장착된 AIO모듈들을 ComboBox에 등록하는 함수.
//  - AIO모듈 정보를 읽어 ComboBox에 등록하여 사용자가 선택
//    제어할 수 있도록 합니다.
//  - 유효한 모듈이 검색되었을 때 Control들을 초기화 합니다.
// --------------------------------------------------------------------------
BOOL COutputWriteSingleDlg::AddModuleChannelInfo()
{
	CString strData;
	char szModuleName[50] = "";
	long lOutputCounts = 0, lBoardNo = 0, lModulePos = 0;
	DWORD dwModuleID = 0;
	// 시스템에 장착된 모든AIO 모듈의 개수를 확인합니다.
	DWORD dwRetCode = AxaInfoGetModuleCount(&m_lModuleCount);
	if (dwRetCode == AXT_RT_SUCCESS)
	{
		TRACE("The number of AIO module: %d\n",m_lModuleCount);
	} 
	else
	{
		TRACE("AxaGetModuleCount() : ERROR code Ox%x\n",dwRetCode);
	}

	for (int iModuleNo = 0; iModuleNo < m_lModuleCount; iModuleNo++)
	{
		// 각 모듈의 출력 채널 수를 확인합니다.
		AxaInfoGetOutputCount(iModuleNo, &lOutputCounts);
		if (lOutputCounts > 0)
		{
			// 해당 모듈의 정보를 가져옵니다.
			dwRetCode = AxaInfoGetModule(iModuleNo, &lBoardNo, &lModulePos, &dwModuleID);
			if (dwRetCode == AXT_RT_SUCCESS)
			{
				switch (dwModuleID)
				{
				case AXT_SIO_AI4RB:
					strData.Format("[BD No:%d - MD No:%d] SIO_AI4RB [Output : %d]", lBoardNo, iModuleNo, lOutputCounts);
					break;
				case AXT_SIO_AI16H:
					strData.Format("[BD No:%d - MD No:%d] SIO_AI16H [Output : %d]", lBoardNo, iModuleNo, lOutputCounts);
					break;
				case AXT_SIO_AI16HB:
					strData.Format("[BD No:%d - MD No:%d] SIO_AI16HB [Output : %d]", lBoardNo, iModuleNo, lOutputCounts);
					break;
				case AXT_SIO_RAI8RB:
					strData.Format("[BD No:%d - MD No:%d] SIO_RAI8RB [Output : %d]", lBoardNo, iModuleNo, lOutputCounts);
					break;
				case AXT_SIO_RAI4MLII:
					strData.Format("[BD No:%d - MD No:%d] SIO_RAI4MLII [Output : %d]", lBoardNo, iModuleNo, lOutputCounts);
					break;
				case AXT_SIO_RAI16RB:
					strData.Format("[BD No:%d - MD No:%d] SIO_RAI16RB [Output : %d]", lBoardNo, iModuleNo, lOutputCounts);
					break;
				case AXT_SIO_RAVCI4MLII:
					strData.Format("[BD No:%d - MD No:%d] SIO_RAVCI4MLII [Output : %d]", lBoardNo, iModuleNo, lOutputCounts);
					break;
				case AXT_SIO_RATI4MLII:
					strData.Format("[BD No:%d - MD No:%d] SIO_RATI4MLII [Output : %d]", lBoardNo, iModuleNo, lOutputCounts);
					break;
				case AXT_SIO_RARTDI4MLII:
					strData.Format("[BD No:%d - MD No:%d] SIO_RARTDI4MLII [Output : %d]", lBoardNo, iModuleNo, lOutputCounts);
					break;
				case AXT_SIO_RAO08RTEX:
					strData.Format("[BD No:%d - MD No:%d] SIO_RAO08RTEX [Output : %d]", lBoardNo, iModuleNo, lOutputCounts);
					break;
				case AXT_SIO_AI8F:
					strData.Format("[BD No:%d - MD No:%d] SIO_AI8F [Output : %d]", lBoardNo, iModuleNo, lOutputCounts);
					break;
				case AXT_SIO_AI8AO4F:
					strData.Format("[BD No:%d - MD No:%d] SIO_AI8A04F [Output : %d]", lBoardNo, iModuleNo, lOutputCounts);
					break;
				case AXT_ECAT_AIO:
					if(lOutputCounts > 0)
					{
						// EtherCAT AIO 전용 모듈 정보 추출
						AxaInfoGetModuleEx(iModuleNo, NULL, szModuleName, NULL);
						strData.Format("[BD No:%d - MD No:%d] %s [Output : %d]", lBoardNo, iModuleNo, szModuleName, lOutputCounts);
					}
					break;
				}				
				m_cboModule.AddString(strData);
				
				for(int i=0; i < lOutputCounts; i++)
				{
					CString strChNum;					
					strChNum.Format("%02d", i);
					m_cboChannel.AddString(strChNum);
				}				
			}
		}
	}

	InitControl();
	SetTimer(TM_DISPLAY, 100, NULL);		// 일정한 주기로 변경되는 전압 값을 Control에 반영할 타이머를 실행합니다.

	return TRUE;
}

// ++ =======================================================================
// >> UpdateState() : 지정한 모듈의 설정값들을 읽어 Control과 일치시키는 함수.
//  - 모듈이 변경되었을 때 변경한 모듈의 설정값들과 Control들과 일치시키는 
//    역할을하는 함수입니다.
//  - 지정한 모듈의 모델별 제약들을 Control에 반영하는 역할을 합니다.
//  - 프로그램 초기 실행시, 모듈 번호 바뀔 때 사용됩니다.
// --------------------------------------------------------------------------
BOOL COutputWriteSingleDlg::UpdateState()
{
	if(m_lModuleCount < 1) return FALSE;

	DWORD	dwRetCode = 0;
	
	//++ 각 모듈별 지원여부에 따라 콘트롤 값들을 변경합니다.
	m_cboVoltageRange.ResetContent();
	m_cboVoltageRange.EnableWindow(TRUE);
	switch(m_dwModuleID) {
	case AXT_SIO_AI4RB:
	case AXT_SIO_AO4RB:
	case AXT_SIO_AI8AO4F:
		m_cboVoltageRange.AddString("00: -10V ~ +10V");
		m_cboVoltageRange.AddString("01: -5V ~ +5V");
		m_cboVoltageRange.AddString("02: 0V ~ +10V");
		m_cboVoltageRange.AddString("03: 0V ~ +5V");
		break;

	case AXT_SIO_AI8F:
	case AXT_SIO_AO4F:
		m_cboVoltageRange.AddString("00: -10V ~ +10V");
		m_cboVoltageRange.AddString("01: -5V ~ +5V");
		break;

	default:
		break;
	}

	//++ 지정 입력 채널에 설정한 입력 전압 범위를 확인합니다.
	UpdateVoltageRange();

	return TRUE;
}

// ++ =======================================================================
// >> ConvertComboToAxa(...) : ComboBox콘트롤에 현재 선택된 Item Index를 모션
//    보드에 설정할 값으로 변경하는 함수.
//  - ComboBox에 선택된 Item Index와 실제 모듈에 설정되는 값이 다르므로 
//    선택된 문자열에서 모듈에 설정할 값을 추출해서 반환하는 함수입니다.
//  - 변환 할 ComboBox 콘트롤의 포인터를 인자로 전달합니다.
//  - 이 함수를 사용하고자 할 때 데이타 등록을 지정된 양식으로 설정해야됩니다.
//    Format) XX: String, XX=라이브러리로 전달될 값, String=인자 설명
//    Ex) "00: Volt", "01: Digit"
// --------------------------------------------------------------------------
DWORD COutputWriteSingleDlg::ConvertComboToAxa(CComboBox *pCboItem)
{
	if(pCboItem == NULL)	return 0;

	CString strText;
	long	lCount, lSelData;	

	lCount = pCboItem->GetCount();
	if(lCount == 0)		return 0;

	lSelData = pCboItem->GetCurSel();
	if(lSelData < 0)	return 0;

	pCboItem->GetLBText(lSelData, strText);	
	return (DWORD)_ttoi(strText);
}

// ++ =======================================================================
// >> ConvertAxaToCombo(...) : 지정한 모듈의 설정값과 ComboBox콘트롤의  
//    Item과 일치하는 Item을 찾아 선택하는 함수.
//  - 실제 모듈값과 ComboBox의 Item Index가  다르므로 지정한
//    값과 일치하는 Item을 찾아 선택하고 선택된 Item의 Index를 반환합니다.
//  - 변경하고자하는 ComboBox 콘트롤의 포인터를 인자로 전달합니다.
//  - 이 함수를 사용하고자 할 때 데이타 등록을 지정된 양식으로 설정해야됩니다.
//    Format) XX: String, XX=라이브러리로 전달될 값, String=인자 설명
//    Ex) "00: Volt", "01: Digit"
// --------------------------------------------------------------------------
long COutputWriteSingleDlg::ConvertAxaToCombo(CComboBox *pCboItem, DWORD dwCurData)
{
	if(pCboItem == NULL)	return 0;

	long	lCount, lSelData;
	CString strText;

	lCount = pCboItem->GetCount();
	if(lCount == 0)	return 0;

	for(int i = 0; i < lCount; i++){
		pCboItem->GetLBText(i, strText);
		lSelData = _ttoi(strText);
		if(lSelData == (long)dwCurData){	
			pCboItem->SetCurSel(i);
			return i;
		}
	}

	pCboItem->SetCurSel(0);
	return 0;
}

// ++ =======================================================================
// >> UpdateVoltageRange(...) : 전압 범위를 갱신하는 함수.
//  - 모듈이나 채널 변경 시 해당 채널의 출력 전압 범위로
//    Control값을 변경합니다.
// --------------------------------------------------------------------------
void COutputWriteSingleDlg::UpdateVoltageRange()
{
	DWORD	dwRetCode = 0;
	double	dMinVolt = 0.0, dMaxVolt = 0.0;
	CString strData;

	//++ 지정 출력 채널에 설정한 출력 전압 범위를 확인합니다.
	dwRetCode = AxaoGetRange(m_lChannelNo, &dMinVolt, &dMaxVolt);
	if(dwRetCode == AXT_RT_SUCCESS)
	{
		if(dMinVolt == -10.0 && dMaxVolt == 10.0)
		{
			m_cboVoltageRange.SetCurSel(0);			
		}
		else if(dMinVolt == -5.0 && dMaxVolt == 5.0)
		{
			m_cboVoltageRange.SetCurSel(1);
		}
		else if(dMinVolt == 0.0 && dMaxVolt == 10.0)
		{
			m_cboVoltageRange.SetCurSel(2);
		}
		else if(dMinVolt == 0.0 && dMaxVolt == 5.0)
		{
			m_cboVoltageRange.SetCurSel(3);
		}		
		m_sliVoltage.SetRange((int)dMinVolt, (int)dMaxVolt, TRUE);
		m_sliVoltage.SetPos(0);
	}
	else
	{
		m_cboVoltageRange.SetCurSel(0);
		m_sliVoltage.SetRange(-10, 10, TRUE);
		m_sliVoltage.SetPos(0);
	}

	strData.Format("%.4f", 0.0);
	m_edtSettingVoltage.SetWindowText(strData);
}
