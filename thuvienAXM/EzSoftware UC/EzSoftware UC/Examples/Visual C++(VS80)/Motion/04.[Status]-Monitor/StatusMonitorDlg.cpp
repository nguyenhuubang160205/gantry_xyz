// StatusMonitorDlg.cpp : implementation file
//
// **************************************************************************
// >> [일자]: 2016.01.05
// >> [개요]: 이 예제는 모션구동과 관련된 상태들을 모니터링하는 예제입니다.
// >> [중요]: 상태함수들 응용범위
//     1) AxmStatusReadMechanical함수는 신호 상태값들을 한번에 읽어 확인할 수
//        있어 각각의 개별 함수들을 이용하는것 보다 효율적입니다.
//     2) AxmStatusReadStop 함수는 구동이 정지된 후 정상구동여부를 확인할 수 
//        있습니다. 모션 구동시 목표위치까지 도달하지 않고 정지하였다면 이 함수의
//        반환값을 분석해 정지원인을 파악할 수 있습니다.   
//     3) AxmStatusReadMotion 함수는 현재 모션 구동중인지, 어떤 구동중인지등의
//        구동상태를 확인할 수 있습니다. 
// **************************************************************************

#include "stdafx.h"
#include "StatusMonitor.h"
#include "StatusMonitorDlg.h"

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
// CStatusMonitorDlg dialog

CStatusMonitorDlg::CStatusMonitorDlg(CWnd* pParent /*=NULL*/)
	: CDialog(CStatusMonitorDlg::IDD, pParent)
{
	//{{AFX_DATA_INIT(CStatusMonitorDlg)
		// NOTE: the ClassWizard will add member initialization here
	//}}AFX_DATA_INIT
	// Note that LoadIcon does not require a subsequent DestroyIcon in Win32
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);

	//++
	m_lAxisNo		= -1;					// 제어할 축 번호 초기화
	m_lAxisCount	= 0;					// 제어 가능한 축갯수 초기화
	m_dwModuleID	= 0;					// 제어할 축의 모듈ID 초기화
}

void CStatusMonitorDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CStatusMonitorDlg)
	DDX_Control(pDX, IDC_CBO_SEL_AXIS, m_cboSelAxis);
	//}}AFX_DATA_MAP
}

BEGIN_MESSAGE_MAP(CStatusMonitorDlg, CDialog)
	//{{AFX_MSG_MAP(CStatusMonitorDlg)
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	ON_CBN_SELCHANGE(IDC_CBO_SEL_AXIS, OnSelchangeCboSelAxis)
	ON_WM_TIMER()
	ON_WM_DESTROY()
	ON_BN_CLICKED(IDC_BTN_LOAD_FILE, OnBtnLoadFile)
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CStatusMonitorDlg message handlers

BOOL CStatusMonitorDlg::OnInitDialog()
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

void CStatusMonitorDlg::OnPaint() 
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
HCURSOR CStatusMonitorDlg::OnQueryDragIcon()
{
	return (HCURSOR) m_hIcon;
}

void CStatusMonitorDlg::OnDestroy() 
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
void CStatusMonitorDlg::OnSelchangeCboSelAxis() 
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
void CStatusMonitorDlg::OnBtnLoadFile() 
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

#define MAX_ITEM_END	14	
#define MAX_ITEM_MECH	14	
#define MAX_ITEM_DRIVE	10	

// ++ =======================================================================
// >> OnTimer(...) : 타이머 이벤트 핸들러 함수.
//  - 일정한 주기로 변경되는 위치/속도/정보등을 Control에 반영합니다.
// --------------------------------------------------------------------------
void CStatusMonitorDlg::OnTimer(UINT_PTR nIDEvent) 
{
	// 중요한 정보들만 모니터링 하도록 선택했습니다.
	long	lDigitEnd[MAX_ITEM_END]		= {0, 1, 4, 5, 6, 7, 8, 9, 10, 11, 15, 28, 30, 31};
	long	lDigitMech[MAX_ITEM_MECH]	= {0, 1, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 17};
	long	lDigitDrive[MAX_ITEM_DRIVE]	= {0, 1, 2, 3, 4, 5, 6, 7, 10, 11};

	long	lIndex = 0, lCheck = 0;
	DWORD	dwRetCode,  dwStatus = 0;

	switch(nIDEvent){
	case TM_DISPLAY:
		//++ 지정 축의 Mechanical Signal Data(현재 기계적인 신호상태)를 확인합니다.
		// ※ [CAUTION] 각 제품별로 하드웨어적인 신호가 다르기 때문에 매뉴얼 및 AXHS.xxx파일을 참고하십시요.
		dwRetCode = AxmStatusReadMechanical(m_lAxisNo, &dwStatus);
		if(dwRetCode == AXT_RT_SUCCESS){
			for(lIndex = 0; lIndex < MAX_ITEM_MECH; lIndex++){
				lCheck = (dwStatus >>  lDigitMech[lIndex]) & 0x1;
				CheckDlgButton(IDC_CHK_MECH_BIT_00 + lIndex, lCheck);
			}
		}

		//++ 지정 축의 End Status(정지 상태)를 확인합니다.
		// ※ [CAUTION] 각 제품별로 정지 상태가 다르기 때문에 매뉴얼 및 AXHS.xxx 파일을 참고하십시요.
		dwRetCode = AxmStatusReadStop(m_lAxisNo, &dwStatus);
		if(dwRetCode == AXT_RT_SUCCESS){
			for(lIndex = 0; lIndex < MAX_ITEM_END; lIndex++){
				lCheck = (dwStatus >>  lDigitEnd[lIndex]) & 0x1;
				CheckDlgButton(IDC_CHK_END_BIT_00 + lIndex, lCheck);
			}
		}
		
		//++ 지정 축의 Drive Status(모션중 상태)를 확인합니다.
		// ※ [CAUTION] 각 제품별로 모션중 상태가 다르기 때문에 매뉴얼 및 AXHS.xxx 파일을 참고하십시요.
		dwRetCode = AxmStatusReadMotion(m_lAxisNo, &dwStatus);
		if(dwRetCode == AXT_RT_SUCCESS){
			for(lIndex = 0; lIndex < MAX_ITEM_DRIVE; lIndex++){
				lCheck = (dwStatus >>  lDigitDrive[lIndex]) & 0x1;
				CheckDlgButton(IDC_CHK_DRIVE_BIT_00 + lIndex, lCheck);
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
BOOL CStatusMonitorDlg::InitLibrary()
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
BOOL CStatusMonitorDlg::AddAxisInfo()
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
		
	InitControl();							// Control 변수들을 등록하고, 초기 설정값들을 설정합니다.
	SetTimer(TM_DISPLAY, 100, NULL);		// 일정한 주기로 변경되는 위치/속도/정보등을 Control에 반영할 타이머를 실행합니다.
	return TRUE;
}

// ++ =======================================================================
// >> InitControl() : Control들에 초기값을 설정하는 함수.
//  - Control 변수들을 등록하고, 초기 설정값들을 설정합니다.
// --------------------------------------------------------------------------
BOOL CStatusMonitorDlg::InitControl()
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
BOOL CStatusMonitorDlg::UpdateState()
{
	if(m_lAxisCount < 1)	return FALSE;
		
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
DWORD CStatusMonitorDlg::ConvertComboToAxm(CComboBox *pCboItem)
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
long CStatusMonitorDlg::ConvertAxmToCombo(CComboBox *pCboItem, DWORD dwCurData)
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
void CStatusMonitorDlg::SetDlgItemDouble(int nID, double value, int nPoint)
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
double CStatusMonitorDlg::GetDlgItemDouble(int nID)
{
	double dRet;
	CString sTemp;
	GetDlgItem(nID)->GetWindowText(sTemp);
	dRet = atof((LPCTSTR)sTemp);
	return dRet;
}

