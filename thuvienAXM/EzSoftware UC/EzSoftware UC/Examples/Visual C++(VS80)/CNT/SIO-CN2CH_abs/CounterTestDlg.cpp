// CounterTestDlg.cpp : 구현 파일
//
#include "stdafx.h"
#include "string.h"
#include "CounterTest.h"
#include "CounterTestDlg.h"
#include <math.h>

#ifdef _DEBUG
#define new DEBUG_NEW
#endif

/////////////////////////////////////////////////////////////////////////////
// CAboutDlg dialog used for App About
#ifdef _M_X64
#pragma comment(lib, "../../../../AXL(Library)/Library/64Bit/AxL.lib")
#else
#pragma comment(lib, "../../../../AXL(Library)/Library/32Bit/AxL.lib")
#endif

// 응용 프로그램 정보에 사용되는 CAboutDlg 대화 상자입니다.
#define TM_DISPLAY		100
class CAboutDlg : public CDialog
{
public:
	CAboutDlg();

// 대화 상자 데이터입니다.
	enum { IDD = IDD_ABOUTBOX };

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV 지원입니다.

// 구현입니다.
protected:
	DECLARE_MESSAGE_MAP()
};

CAboutDlg::CAboutDlg() : CDialog(CAboutDlg::IDD)
{
}

void CAboutDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
}

BEGIN_MESSAGE_MAP(CAboutDlg, CDialog)
END_MESSAGE_MAP()


// CCounterTestDlg 대화 상자
CCounterTestDlg::CCounterTestDlg(CWnd* pParent /*=NULL*/)
	: CDialog(CCounterTestDlg::IDD, pParent)
{
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);

	m_nModuleNo					= -1;
	m_nChannelNo[CHANNEL_00]	= -1;
	m_nChannelNo[CHANNEL_01]	= -1;
	m_dCountOld[CHANNEL_00]		= 0.0;
	m_dCountOld[CHANNEL_01]		= 0.0;
}

void CCounterTestDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	DDX_Control(pDX, IDC_LST_LOG, m_lstLog);
}

BEGIN_MESSAGE_MAP(CCounterTestDlg, CDialog)
	ON_WM_SYSCOMMAND()
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	//}}AFX_MSG_MAP
	ON_WM_TIMER()
	ON_COMMAND_RANGE(IDC_BTN_TRIG_APPLY_00, IDC_BTN_TRIG_APPLY_01, OnBnClickedBtnTrigApply)
	ON_COMMAND_RANGE(IDC_BTN_POS_CLEAR_00, IDC_BTN_POS_CLEAR_01, OnBnClickedBtnPosClear)
	ON_COMMAND_RANGE(IDC_BTN_SET_UNIT_00, IDC_BTN_SET_UNIT_01, OnBnClickedBtnSetUnit)
	ON_COMMAND_RANGE(IDC_CHK_ENC_REVERSE_00, IDC_CHK_ENC_REVERSE_01, OnBnClickedChkEncReverse)
	ON_COMMAND_RANGE(IDC_CHK_OUT_00, IDC_CHK_OUT_03, OnBnClickedChkOut0)
	ON_COMMAND_RANGE(IDC_CHK_OUT_10, IDC_CHK_OUT_13, OnBnClickedChkOut1)
	ON_COMMAND_RANGE(IDC_CHK_TRIG_ENABLE_00, IDC_CHK_TRIG_ENABLE_01, OnBnClickedChkTrigEnable)
	ON_COMMAND_RANGE(IDC_BTN_ADD_ABSPOS_00, IDC_BTN_ADD_ABSPOS_01, OnBnClickedBtnAddABSPos)
	ON_COMMAND_RANGE(IDC_BTN_ABS_TRG_CLEAR_00, IDC_BTN_ABS_TRG_CLEAR_01, OnBnClickedBtnClearABSPos)
	ON_LBN_DBLCLK(IDC_LST_LOG, OnLbnDblclkLstLog)
	ON_CBN_SELCHANGE(IDC_CBO_SEL_MODULE, OnCbnSelchangeCboSelModule)
	ON_CBN_SELCHANGE(IDC_CBO_ENC_METHOD_00, OnCbnSelchangeCboEncMethod00)
	ON_CBN_SELCHANGE(IDC_CBO_ENC_METHOD_01, OnCbnSelchangeCboEncMethod01)
	ON_CBN_SELCHANGE(IDC_CBO_ENC_SOURCE_00, OnCbnSelchangeCboEncSource00)
	ON_CBN_SELCHANGE(IDC_CBO_ENC_SOURCE_01, OnCbnSelchangeCboEncSource01)
	ON_CBN_SELCHANGE(IDC_CBO_TRIG_MODE_01, OnCbnSelchangeCboTrigMode01)
	ON_CBN_SELCHANGE(IDC_CBO_ACTIVE_LEVEL_00, OnCbnSelchangeCboActiveLevel00)
	ON_CBN_SELCHANGE(IDC_CBO_ACTIVE_LEVEL_01, OnCbnSelchangeCboActiveLevel01)
	ON_CBN_SELCHANGE(IDC_CBO_DIR_CHECK_00, OnCbnSelchangeCboDirCheck00)
	ON_CBN_SELCHANGE(IDC_CBO_DIR_CHECK_01, OnCbnSelchangeCboDirCheck01)
	ON_CBN_SELCHANGE(IDC_CBO_TRIG_MODE_00, &CCounterTestDlg::OnCbnSelchangeCboTrigMode00)
END_MESSAGE_MAP()


// CCounterTestDlg 메시지 처리기

BOOL CCounterTestDlg::OnInitDialog()
{
	CDialog::OnInitDialog();

	// 시스템 메뉴에 "정보..." 메뉴 항목을 추가합니다.

	// IDM_ABOUTBOX는 시스템 명령 범위에 있어야 합니다.
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

	// 이 대화 상자의 아이콘을 설정합니다. 응용 프로그램의 주 창이 대화 상자가 아닐 경우에는
	//  프레임워크가 이 작업을 자동으로 수행합니다.
	SetIcon(m_hIcon, TRUE);			// 큰 아이콘을 설정합니다.
	SetIcon(m_hIcon, FALSE);		// 작은 아이콘을 설정합니다.

	if(InitLibrary() == TRUE){
		InitControl();
		UpdateState();
	}
	
	return TRUE;  // 포커스를 컨트롤에 설정하지 않으면 TRUE를 반환합니다.
}

CCounterTestDlg::~CCounterTestDlg()
{

}

void CCounterTestDlg::OnSysCommand(UINT nID, LPARAM lParam)
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

// 대화 상자에 최소화 단추를 추가할 경우 아이콘을 그리려면
//  아래 코드가 필요합니다. 문서/뷰 모델을 사용하는 MFC 응용 프로그램의 경우에는
//  프레임워크에서 이 작업을 자동으로 수행합니다.

void CCounterTestDlg::OnPaint()
{
	if (IsIconic())
	{
		CPaintDC dc(this); // 그리기를 위한 디바이스 컨텍스트

		SendMessage(WM_ICONERASEBKGND, reinterpret_cast<WPARAM>(dc.GetSafeHdc()), 0);

		// 클라이언트 사각형에서 아이콘을 가운데에 맞춥니다.
		int cxIcon = GetSystemMetrics(SM_CXICON);
		int cyIcon = GetSystemMetrics(SM_CYICON);
		CRect rect;
		GetClientRect(&rect);
		int x = (rect.Width() - cxIcon + 1) / 2;
		int y = (rect.Height() - cyIcon + 1) / 2;

		// 아이콘을 그립니다.
		dc.DrawIcon(x, y, m_hIcon);
	}
	else
	{
		CDialog::OnPaint();
	}
}

// 사용자가 최소화된 창을 끄는 동안에 커서가 표시되도록 시스템에서
//  이 함수를 호출합니다.
HCURSOR CCounterTestDlg::OnQueryDragIcon()
{
	return static_cast<HCURSOR>(m_hIcon);
}

BOOL CCounterTestDlg::InitLibrary()
{
	CString string;
    long    lChannelCnt = 0;
    CString strErrorMessage;
    DWORD   dwReturn;
    dwReturn = AxlOpenNoReset(7);

	if(dwReturn == AXT_RT_SUCCESS)
    {
        AxcInfoGetTotalChannelCount(&lChannelCnt);
        if(lChannelCnt == 0)
        {
		    AfxMessageBox("There is no counter modules.");
            return FALSE;
        }
        else
			return TRUE;
	}
	else
	{
        strErrorMessage.Format("CNT Module Not initialized, Error code = %ld.", dwReturn);
		AfxMessageBox(strErrorMessage);
	}

	return FALSE;
}

BOOL CCounterTestDlg::InitControl()
{
	m_ftControl.CreateFont (16, 0, 0, 0, 300,
		FALSE, FALSE, 0, ANSI_CHARSET,
		OUT_DEFAULT_PRECIS, 
		CLIP_DEFAULT_PRECIS,
		DEFAULT_QUALITY, 
		DEFAULT_PITCH|FF_SWISS, "Arial") ;

	m_cboSelModule.SubclassDlgItem(IDC_CBO_SEL_MODULE, this);
	m_cboSelModule.SetFont(&m_ftControl);

	m_grpChannel[CHANNEL_00].SubclassDlgItem(IDC_GRP_CHANNEL_00, this);
	m_grpChannel[CHANNEL_01].SubclassDlgItem(IDC_GRP_CHANNEL_01, this);

	m_stcActPos[CHANNEL_00].SubclassDlgItem(IDC_STC_ACT_POS_00, this);
	m_stcActPos[CHANNEL_00].SetFont(&m_ftControl);

	m_stcActPos[CHANNEL_01].SubclassDlgItem(IDC_STC_ACT_POS_01, this);
	m_stcActPos[CHANNEL_01].SetFont(&m_ftControl);

	m_btnPosClear[CHANNEL_00].SubclassDlgItem(IDC_BTN_POS_CLEAR_00, this);
	m_btnPosClear[CHANNEL_01].SubclassDlgItem(IDC_BTN_POS_CLEAR_01, this);

	m_cboEncMethod[CHANNEL_00].SubclassDlgItem(IDC_CBO_ENC_METHOD_00, this);
	m_cboEncMethod[CHANNEL_00].SetFont(&m_ftControl);
	m_cboEncMethod[CHANNEL_01].SubclassDlgItem(IDC_CBO_ENC_METHOD_01, this);
	m_cboEncMethod[CHANNEL_01].SetFont(&m_ftControl);

	m_cboEncSource[CHANNEL_00].SubclassDlgItem(IDC_CBO_ENC_SOURCE_00, this);
	m_cboEncSource[CHANNEL_00].SetFont(&m_ftControl);
	m_cboEncSource[CHANNEL_01].SubclassDlgItem(IDC_CBO_ENC_SOURCE_01, this);
	m_cboEncSource[CHANNEL_01].SetFont(&m_ftControl);

	m_cboTrigMode[CHANNEL_00].SubclassDlgItem(IDC_CBO_TRIG_MODE_00, this);
	m_cboTrigMode[CHANNEL_00].SetFont(&m_ftControl);
	m_cboTrigMode[CHANNEL_01].SubclassDlgItem(IDC_CBO_TRIG_MODE_01, this);
	m_cboTrigMode[CHANNEL_01].SetFont(&m_ftControl);

	m_cboActiveLevel[CHANNEL_00].SubclassDlgItem(IDC_CBO_ACTIVE_LEVEL_00, this);
	m_cboActiveLevel[CHANNEL_00].SetFont(&m_ftControl);
	m_cboActiveLevel[CHANNEL_01].SubclassDlgItem(IDC_CBO_ACTIVE_LEVEL_01, this);
	m_cboActiveLevel[CHANNEL_01].SetFont(&m_ftControl);

	m_cboDirCheck[CHANNEL_00].SubclassDlgItem(IDC_CBO_DIR_CHECK_00, this);
	m_cboDirCheck[CHANNEL_00].SetFont(&m_ftControl);
	m_cboDirCheck[CHANNEL_01].SubclassDlgItem(IDC_CBO_DIR_CHECK_01, this);
	m_cboDirCheck[CHANNEL_01].SetFont(&m_ftControl);

	m_edtUnitPulse[CHANNEL_00].SubclassDlgItem(IDC_EDT_UNIT_PULSE_00, this);
	m_edtUnitPulse[CHANNEL_00].SetFont(&m_ftControl);
	m_edtUnitPulse[CHANNEL_01].SubclassDlgItem(IDC_EDT_UNIT_PULSE_01, this);
	m_edtUnitPulse[CHANNEL_01].SetFont(&m_ftControl);

	m_edtPosUpper[CHANNEL_00].SubclassDlgItem(IDC_EDT_POS_UPPER_00, this);
	m_edtPosUpper[CHANNEL_00].SetFont(&m_ftControl);
	m_edtPosUpper[CHANNEL_01].SubclassDlgItem(IDC_EDT_POS_UPPER_01, this);
	m_edtPosUpper[CHANNEL_01].SetFont(&m_ftControl);

	m_edtPosLower[CHANNEL_00].SubclassDlgItem(IDC_EDT_POS_LOWER_00, this);
	m_edtPosLower[CHANNEL_00].SetFont(&m_ftControl);
	m_edtPosLower[CHANNEL_01].SubclassDlgItem(IDC_EDT_POS_LOWER_01, this);
	m_edtPosLower[CHANNEL_01].SetFont(&m_ftControl);

	m_edtAbsPos[CHANNEL_00].SubclassDlgItem(IDC_EDT_ABSPOS_00, this);
	m_edtAbsPos[CHANNEL_00].SetFont(&m_ftControl);
	m_edtAbsPos[CHANNEL_01].SubclassDlgItem(IDC_EDT_ABSPOS_01, this);
	m_edtAbsPos[CHANNEL_01].SetFont(&m_ftControl);
	
	m_edtTrigPeriod[CHANNEL_00].SubclassDlgItem(IDC_EDT_TRIG_PERIOD_00, this);
	m_edtTrigPeriod[CHANNEL_00].SetFont(&m_ftControl);
	m_edtTrigPeriod[CHANNEL_01].SubclassDlgItem(IDC_EDT_TRIG_PERIOD_01, this);
	m_edtTrigPeriod[CHANNEL_01].SetFont(&m_ftControl);
	
	m_edtPulseWidth[CHANNEL_00].SubclassDlgItem(IDC_EDT_PULSE_WIDTH_00, this);
	m_edtPulseWidth[CHANNEL_00].SetFont(&m_ftControl);
	m_edtPulseWidth[CHANNEL_01].SubclassDlgItem(IDC_EDT_PULSE_WIDTH_01, this);
	m_edtPulseWidth[CHANNEL_01].SetFont(&m_ftControl);

	////////Digital In/Out SubClassing///////

	m_ChkDigitalIn00[0].SubclassDlgItem(IDC_CHK_IN_00, this);
	m_ChkDigitalIn00[1].SubclassDlgItem(IDC_CHK_IN_01, this);
	m_ChkDigitalIn00[2].SubclassDlgItem(IDC_CHK_IN_02, this);
	m_ChkDigitalIn00[3].SubclassDlgItem(IDC_CHK_IN_03, this);

	m_ChkDigitalIn01[0].SubclassDlgItem(IDC_CHK_IN_10, this);
	m_ChkDigitalIn01[1].SubclassDlgItem(IDC_CHK_IN_11, this);
	m_ChkDigitalIn01[2].SubclassDlgItem(IDC_CHK_IN_12, this);
	m_ChkDigitalIn01[3].SubclassDlgItem(IDC_CHK_IN_13, this);

	m_ChkDigitalOut00[0].SubclassDlgItem(IDC_CHK_OUT_00, this);
	m_ChkDigitalOut00[1].SubclassDlgItem(IDC_CHK_OUT_01, this);
	m_ChkDigitalOut00[2].SubclassDlgItem(IDC_CHK_OUT_02, this);
	m_ChkDigitalOut00[3].SubclassDlgItem(IDC_CHK_OUT_03, this);

	m_ChkDigitalOut01[0].SubclassDlgItem(IDC_CHK_OUT_10, this);
	m_ChkDigitalOut01[1].SubclassDlgItem(IDC_CHK_OUT_11, this);
	m_ChkDigitalOut01[2].SubclassDlgItem(IDC_CHK_OUT_12, this);
	m_ChkDigitalOut01[3].SubclassDlgItem(IDC_CHK_OUT_13, this);
	  
	m_lstLog.SetFont(&m_ftControl);

	int i;
	for(i = 0; i < MAX_CHANNEL; i++){
		m_cboEncMethod[i].AddString("00:UpDownMode");
		m_cboEncMethod[i].AddString("01:Sqr1Mode");
		m_cboEncMethod[i].AddString("02:Sqr2Mode");
		m_cboEncMethod[i].AddString("03:Sqr4Mode");

		m_cboDirCheck[i].AddString("00:None");
		m_cboDirCheck[i].AddString("01:CW");
		m_cboDirCheck[i].AddString("02:CCW");

		m_cboEncSource[i].AddString("00:AB Phase");
		m_cboEncSource[i].AddString("01: Z Phase");

		m_cboTrigMode[i].AddString("00:Absolute Mode");
		m_cboTrigMode[i].AddString("01:Periodic Mode");

		m_cboActiveLevel[i].AddString("00:Active Low");
		m_cboActiveLevel[i].AddString("01:Active High");

		m_dwAbsIndex[i] = 0;
	}	

	memset(m_dwABSPosition, 0x00, sizeof(DWORD) * 2 * 512);

	CString strData;
	DWORD	dwModuleID;
	m_lModuleCount = 0;

	AxcInfoGetModuleCount(&m_lModuleCount);

	for(i = 0; i < m_lModuleCount; i++)
	{
        AxcInfoGetModule(i, NULL, NULL, &dwModuleID);
		switch(dwModuleID){
		case AXT_SIO_CN2CH:		strData.Format(" %02ld-[PCIB-CH2: Reversible 2 Channel Counter Module]", i);	break;
		case AXT_SIO_RCNT2RTEX:	strData.Format(" %02ld-[RTEX-RCNT2: RTEX 2 Channel Counter Module]", i);	break;
		case AXT_SIO_RCNT2MLII:	strData.Format(" %02ld-[MLII-RCNT2: MLII 2 Channel Counter Module]", i);	break;			
		default:				strData.Format(" %02ld-[Unknown]",i);
		}

		m_cboSelModule.AddString(strData);
	}
	if(m_lModuleCount > 0){
		m_nModuleNo				= 0;
		m_nChannelNo[CHANNEL_00]= 0;
		m_nChannelNo[CHANNEL_01]= 1;

		m_cboSelModule.SetCurSel(m_nModuleNo);
	}else{
		TraceLog("ERROR: Cannot find counter modules");
		return FALSE;
	}

	SetTimer(TM_DISPLAY, 100, NULL);

	return TRUE;
}

BOOL CCounterTestDlg::UpdateState()
{
	int		i;
	DWORD	dwData;
	DWORD	dwPeriod;
	double	dPeriod, dLowerPos, dUpperPos, dPulseWidth, dMoveUnit;
	CString	strtemp;
	char	buffer[100];		
	char*	cFindStrRTEX = NULL;
	char*	cFindStrMLII = NULL;

	m_cboSelModule.GetLBText(m_cboSelModule.GetCurSel(), strtemp);
	strcpy(buffer, (LPSTR)(LPCSTR)strtemp);

	cFindStrRTEX = strstr(buffer, "RTEX");
	cFindStrMLII = strstr(buffer, "MLII");

	if((cFindStrRTEX != NULL) || (cFindStrMLII != NULL))
	{
		for(i = 0; i < MAX_INPUT; i++)
		{
			m_ChkDigitalIn00[i].EnableWindow(FALSE);
			m_ChkDigitalIn01[i].EnableWindow(FALSE);
			m_ChkDigitalOut00[i].EnableWindow(FALSE);
			m_ChkDigitalOut01[i].EnableWindow(FALSE);			
		}
		m_cboEncSource[0].EnableWindow(FALSE);
		m_cboEncSource[1].EnableWindow(FALSE);
		m_cboDirCheck[0].EnableWindow(FALSE);
		m_cboDirCheck[1].EnableWindow(FALSE);
	}
	else
	{
		for(i = 0; i < MAX_INPUT; i++)
		{
			m_ChkDigitalIn00[i].EnableWindow(TRUE);
			m_ChkDigitalIn01[i].EnableWindow(TRUE);
			m_ChkDigitalOut00[i].EnableWindow(TRUE);
			m_ChkDigitalOut01[i].EnableWindow(TRUE);
		}
	}

	for(i = 0; i < MAX_CHANNEL; i++)
	{
		dMoveUnit = 1.0;
		SetDlgItemDouble(IDC_EDT_UNIT_PULSE_00 + i, dMoveUnit);

		dwData	= 0;
		AxcSignalGetEncInputMethod(m_nChannelNo[i], &dwData);
		ConvertAxtToCombo(&m_cboEncMethod[i], dwData);

		dwData	= 0;
		AxcSignalGetEncSource(m_nChannelNo[i], &dwData);
		ConvertAxtToCombo(&m_cboEncSource[i], dwData);

		dwData	= 0;
		AxcTriggerGetDirectionCheck(m_nChannelNo[i], &dwData);
		ConvertAxtToCombo(&m_cboDirCheck[i], dwData);

		dwData	= 0;
		AxcTriggerGetFunction(m_nChannelNo[i], &dwData);
		ConvertAxtToCombo(&m_cboTrigMode[i], dwData);

		if(dwData == 0)
		{
			m_edtPosUpper[i].EnableWindow(FALSE);
			m_edtPosLower[i].EnableWindow(FALSE);
			m_edtTrigPeriod[i].EnableWindow(FALSE);
			m_edtAbsPos[i].EnableWindow(TRUE);
		}
		else
		{
			m_edtPosUpper[i].EnableWindow(TRUE);
			m_edtPosLower[i].EnableWindow(TRUE);
			m_edtTrigPeriod[i].EnableWindow(TRUE);
			m_edtAbsPos[i].EnableWindow(FALSE);
		}

		dwData	= 0;
		AxcTriggerGetLevel(m_nChannelNo[i], &dwData);
		ConvertAxtToCombo(&m_cboActiveLevel[i], dwData);

		dLowerPos = dUpperPos = dPeriod = 0;

		AxcTriggerGetBlockLowerPos(m_nChannelNo[i], &dLowerPos);
		AxcTriggerGetBlockUpperPos(m_nChannelNo[i], &dUpperPos);
		AxcTriggerGetPosPeriod(m_nChannelNo[i], &dPeriod);

		SetDlgItemDouble(IDC_EDT_TRIG_PERIOD_00 + i, dPeriod);
		SetDlgItemDouble(IDC_EDT_POS_LOWER_00 + i, dLowerPos);
		SetDlgItemDouble(IDC_EDT_POS_UPPER_00 + i, dUpperPos);

		dPulseWidth = 0.0;
		AxcTriggerGetTime(m_nChannelNo[i], &dPulseWidth);
		SetDlgItemDouble(IDC_EDT_PULSE_WIDTH_00 + i, dPulseWidth);

		SetDlgItemDouble(IDC_EDT_ABSPOS_00 + i, 0.0);

		CheckDlgButton(IDC_CHK_TRIG_ENABLE_00 + i, 0);

		m_dwAbsIndex[i] = 0;
	}
	
	return TRUE;
}

// ++ =======================================================================
// >> ConvertComboToAxt(...) : ComboBox콘트롤에 현재 선택된 Item Index를 모션
//    보드에 설정할 값으로 변경하는 함수.
//  - ComboBox에 선택된 Item Index와 실제 모션보드에 설정되는 값이 다르므로 
//    선택된 문자열에서 모션보드에 설정할 값을 추출해서 반환하는 함수입니다.
//  - 변환 할 ComboBox 콘트롤의 포인트를 인자로 전달합니다.
//  - 이 함수를 사용하고자 할 때 데이타 등록을 지정된 양식으로 설정해야됩니다.
//    Format) XX: String, XX=라이브러리로 전달될 값, String=인자 설명
//    Ex) "01: HIGH", "00: COMMAND", "04: HomeSensor"
// --------------------------------------------------------------------------
DWORD CCounterTestDlg::ConvertComboToAxt(CComboBox *pCboItem)
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
// >> ConvertAxtToCombo(...) : 지정한 모션보드에 설정값과 ComboBox콘트롤의  
//    Item과 일치하는 Item을 찾아 선택하는 함수.
//  - 실제 모션보드에 설정되는 값과 ComboBox의 Item Index와  다르므로 지정한
//    값과 일치하는 Item을 찾아 선택하고 선택된 Item의 Index를 반환합니다.
//  - 변경하고자하는 ComboBox 콘트롤의 포인트를 인자로 전달합니다.
//  - 이 함수를 사용하고자 할 때 데이타 등록을 지정된 양식으로 설정해야됩니다.
//    Format) XX: String, XX=라이브러리로 전달될 값, String=인자 설명
//    Ex) "01: HIGH", "00: COMMAND", "04: HomeSensor"
// --------------------------------------------------------------------------
long CCounterTestDlg::ConvertAxtToCombo(CComboBox *pCboItem, DWORD dwCurData)
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
void CCounterTestDlg::SetDlgItemDouble(int nID, double value, int nPoint)
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
double CCounterTestDlg::GetDlgItemDouble(int nID)
{
	double dRet;
	CString sTemp;
	GetDlgItem(nID)->GetWindowText(sTemp);
	dRet = atof((LPCTSTR)sTemp);
	return dRet;
}

void CCounterTestDlg::OnTimer(UINT_PTR nIDEvent)
{
	int		i, j;
	double	dCount;
	CString strData;
	DWORD	uOutput;
	DWORD	uInput;
	long	lCount;

	switch(nIDEvent){
	case TM_DISPLAY:		
		for(i = 0; i < MAX_CHANNEL; i++){
			dCount = 0.0;
			AxcStatusGetActPos(m_nChannelNo[i], &dCount);
			lCount = (long)dCount;
			if(m_dCountOld[i] != dCount){				
				strData.Format("%.3lf", dCount);
				m_stcActPos[i].SetWindowText(strData);
				m_dCountOld[i] = dCount;
			}
			AxcSignalReadOutput(m_nChannelNo[i], &uOutput);
		    AxcSignalReadInput(m_nChannelNo[i], &uInput);
			for(j = 0; j < MAX_INPUT; j++){
				CheckDlgButton(IDC_CHK_OUT_00 + (i * MAX_INPUT) + j, (uOutput >> j) & 0x1);
				CheckDlgButton(IDC_CHK_IN_00 + (i * MAX_INPUT) + j, (uInput >> j) & 0x1);
			}	
		}
		
		break;
	}

	CDialog::OnTimer(nIDEvent);
}

/*void CCounterTestDlg::OnCbnSelchangeCboTrigMode00()
{
	DWORD	dwRetCode;
	UINT	nSelChannel = CHANNEL_00;
	DWORD	dwSetMode;
	double	dPeriod, dLowerPos, dUpperPos;
	
	dwSetMode	= ConvertComboToAxt(&m_cboTrigMode[nSelChannel]);
	dwRetCode	= AxcTriggerSetFunction(m_nChannelNo[nSelChannel], dwSetMode);
	
	if(dwSetMode == 0)
	{
		m_edtPosUpper[nSelChannel].EnableWindow(FALSE);
		m_edtPosLower[nSelChannel].EnableWindow(FALSE);
		m_edtTrigPeriod[nSelChannel].EnableWindow(FALSE);
		m_edtAbsPos[nSelChannel].EnableWindow(TRUE);
	}
	else
	{
		m_edtPosUpper[nSelChannel].EnableWindow(TRUE);
		m_edtPosLower[nSelChannel].EnableWindow(TRUE);
		m_edtTrigPeriod[nSelChannel].EnableWindow(TRUE);
		m_edtAbsPos[nSelChannel].EnableWindow(FALSE);

		AxcTriggerGetBlockLowerPos(m_nChannelNo[nSelChannel], &dLowerPos);
		AxcTriggerGetBlockUpperPos(m_nChannelNo[nSelChannel], &dUpperPos);
		AxcTriggerGetPosPeriod(m_nChannelNo[nSelChannel], &dPeriod);

		SetDlgItemDouble(IDC_EDT_TRIG_PERIOD_00, dPeriod);
		SetDlgItemDouble(IDC_EDT_POS_LOWER_00, dLowerPos);
		SetDlgItemDouble(IDC_EDT_POS_UPPER_00, dUpperPos);
	}
	
	if(dwRetCode != AXT_RT_SUCCESS){
        TraceLog("ERROR[%ld]: AxcTriggerSetFunction(%ld, %ld)", dwRetCode, m_nChannelNo[nSelChannel], dwSetMode);
	}
}*/

void CCounterTestDlg::OnCbnSelchangeCboTrigMode01()
{
	DWORD	dwRetCode;
	UINT	nSelChannel = CHANNEL_01;
	DWORD	dwSetMode;
	double	dPeriod, dLowerPos, dUpperPos;

	dwSetMode	= ConvertComboToAxt(&m_cboTrigMode[nSelChannel]);
	dwRetCode	= AxcTriggerSetFunction(m_nChannelNo[nSelChannel], dwSetMode);

	if(dwSetMode == 0)
	{
		m_edtPosUpper[nSelChannel].EnableWindow(FALSE);
		m_edtPosLower[nSelChannel].EnableWindow(FALSE);
		m_edtTrigPeriod[nSelChannel].EnableWindow(FALSE);
		m_edtAbsPos[nSelChannel].EnableWindow(TRUE);
	}
	else
	{
		m_edtPosUpper[nSelChannel].EnableWindow(TRUE);
		m_edtPosLower[nSelChannel].EnableWindow(TRUE);
		m_edtTrigPeriod[nSelChannel].EnableWindow(TRUE);
		m_edtAbsPos[nSelChannel].EnableWindow(FALSE);

		AxcTriggerGetBlockLowerPos(m_nChannelNo[nSelChannel], &dLowerPos);
		AxcTriggerGetBlockUpperPos(m_nChannelNo[nSelChannel], &dUpperPos);
		AxcTriggerGetPosPeriod(m_nChannelNo[nSelChannel], &dPeriod);

		SetDlgItemDouble(IDC_EDT_TRIG_PERIOD_01, dPeriod);
		SetDlgItemDouble(IDC_EDT_POS_LOWER_01, dLowerPos);
		SetDlgItemDouble(IDC_EDT_POS_UPPER_01, dUpperPos);
	}

	if(dwRetCode != AXT_RT_SUCCESS){
		TraceLog("ERROR[%ld]: AxcTriggerSetFunction(%ld, %ld)", dwRetCode, m_nChannelNo[nSelChannel], dwSetMode);
	}
}

void CCounterTestDlg::OnCbnSelchangeCboActiveLevel00()
{
	DWORD	dwRetCode;
	UINT	nSelChannel = CHANNEL_00;
	DWORD	dwActiveLevel;
	
	dwActiveLevel= ConvertComboToAxt(&m_cboActiveLevel[nSelChannel]);
	dwRetCode	= AxcTriggerSetLevel(m_nChannelNo[nSelChannel], dwActiveLevel);

    if(dwRetCode != AXT_RT_SUCCESS){
		TraceLog("ERROR[%ld]: AxcTriggerSetLevel(%ld, %ld)", dwRetCode, m_nChannelNo[nSelChannel], dwActiveLevel);
	}
}

void CCounterTestDlg::OnCbnSelchangeCboActiveLevel01()
{
    DWORD	dwRetCode;
    UINT	nSelChannel = CHANNEL_01;
    DWORD	dwActiveLevel;

    dwActiveLevel= ConvertComboToAxt(&m_cboActiveLevel[nSelChannel]);
    dwRetCode	= AxcTriggerSetLevel(m_nChannelNo[nSelChannel], dwActiveLevel);

    if(dwRetCode != AXT_RT_SUCCESS){
        TraceLog("ERROR[%ld]: AxcTriggerSetLevel(%ld, %ld)", dwRetCode, m_nChannelNo[nSelChannel], dwActiveLevel);
    }
}

void CCounterTestDlg::OnCbnSelchangeCboDirCheck00()
{
	DWORD	dwRetCode;
	UINT	nSelChannel = CHANNEL_00;
	DWORD	dwDirCheck;
	
	dwDirCheck = ConvertComboToAxt(&m_cboDirCheck[nSelChannel]);
	dwRetCode  = AxcTriggerSetDirectionCheck(m_nChannelNo[nSelChannel], dwDirCheck);
	
	if(dwRetCode != AXT_RT_SUCCESS){
		TraceLog("ERROR[%ld]: AxcTriggerSetDirectionCheck(%02d, %d)", dwRetCode, m_nChannelNo[nSelChannel], dwDirCheck);
	}
}

void CCounterTestDlg::OnCbnSelchangeCboDirCheck01()
{
    DWORD	dwRetCode;
    UINT	nSelChannel = CHANNEL_01;
    DWORD	dwDirCheck;

    dwDirCheck = ConvertComboToAxt(&m_cboDirCheck[nSelChannel]);
    dwRetCode  = AxcTriggerSetDirectionCheck(m_nChannelNo[nSelChannel], dwDirCheck);

    if(dwRetCode != AXT_RT_SUCCESS){
        TraceLog("ERROR[%ld]: AxcTriggerSetDirectionCheck(%02d, %d)", dwRetCode, m_nChannelNo[nSelChannel], dwDirCheck);
    }
}

void CCounterTestDlg::OnBnClickedBtnTrigApply(UINT nID)
{
	DWORD	dwRetCode;
	double	dLowerPos, dUpperPos, dPulseWidth, dPulsePeriod;
	UINT	nSelChannel = nID - IDC_BTN_TRIG_APPLY_00;
	DWORD	dwGetMode;
	DWORD	dwABSPos[512];

	memset(dwABSPos, 0x00, sizeof(DWORD) * 512);
	
	dPulseWidth = GetDlgItemDouble(IDC_EDT_PULSE_WIDTH_00 + nSelChannel);
	dwRetCode	= AxcTriggerSetTime(m_nChannelNo[nSelChannel], dPulseWidth);	
	if(dwRetCode != AXT_RT_SUCCESS){
		TraceLog("ERROR[%ld]: AxcTriggerSetTime(%02d, %lf)", dwRetCode, m_nChannelNo[nSelChannel], dPulseWidth);
	}

	AxcTriggerGetFunction(m_nChannelNo[nSelChannel], &dwGetMode);

	for(int i = 0; i < m_dwAbsIndex[nSelChannel]; i++)
	{
		dwABSPos[i] = m_dwABSPosition[nSelChannel][i];
	}

	if(dwGetMode)
	{
		dLowerPos	= GetDlgItemDouble(IDC_EDT_POS_LOWER_00 + nSelChannel);
		dUpperPos	= GetDlgItemDouble(IDC_EDT_POS_UPPER_00 + nSelChannel);
		dPulsePeriod = GetDlgItemDouble(IDC_EDT_TRIG_PERIOD_00 + nSelChannel);

		AxcTriggerSetBlockLowerPos(m_nChannelNo[nSelChannel], dLowerPos);
		AxcTriggerSetBlockUpperPos(m_nChannelNo[nSelChannel], dUpperPos);
		AxcTriggerSetPosPeriod(m_nChannelNo[nSelChannel], dPulsePeriod);
	}
	else
	{
		AxcTriggerSetAbs(m_nChannelNo[nSelChannel], m_dwAbsIndex[nSelChannel], dwABSPos, NULL);
	}
}

void CCounterTestDlg::OnBnClickedBtnAddABSPos(UINT nID)
{
	UINT	nSelChannel = nID - IDC_BTN_ADD_ABSPOS_00;	

	m_dwABSPosition[nSelChannel][m_dwAbsIndex[nSelChannel]] = GetDlgItemDouble(IDC_EDT_ABSPOS_00 + nSelChannel);

	if(m_dwAbsIndex[nSelChannel] == 0)
	{
		TraceLog("Channel %d Add ABS Trigger Position (Index = %03d, Pos = %d)", nSelChannel ,m_dwAbsIndex[nSelChannel], m_dwABSPosition[nSelChannel][m_dwAbsIndex[nSelChannel]]);

		m_dwAbsIndex[nSelChannel]++;
	}
	else
	{
		if(m_dwABSPosition[nSelChannel][m_dwAbsIndex[nSelChannel]] > m_dwABSPosition[nSelChannel][m_dwAbsIndex[nSelChannel] - 1])
		{
			TraceLog("Channel %d Add ABS Trigger Position (Index = %03d, Pos = %d)", nSelChannel ,m_dwAbsIndex[nSelChannel], m_dwABSPosition[nSelChannel][m_dwAbsIndex[nSelChannel]]);

			m_dwAbsIndex[nSelChannel]++;
		}
		else
		{
			TraceLog("Ch %d Add ABS Trg Pos Error(Index = %03d, PrevPos = %d > CurrentPos = %d)", nSelChannel ,m_dwAbsIndex[nSelChannel], m_dwABSPosition[nSelChannel][m_dwAbsIndex[nSelChannel] - 1], m_dwABSPosition[nSelChannel][m_dwAbsIndex[nSelChannel]]);
		}
	}
}

void CCounterTestDlg::OnBnClickedBtnClearABSPos(UINT nID)
{
	UINT	nSelChannel = nID - IDC_BTN_ABS_TRG_CLEAR_00;

	m_dwAbsIndex[nSelChannel] = 0;

	TraceLog("Channel %d Clear ABS Position", nSelChannel ,m_dwAbsIndex[nSelChannel], m_dwABSPosition[nSelChannel][m_dwAbsIndex[nSelChannel]]);
}

void CCounterTestDlg::SettupAbsolutePosition(INT16 nSelChannel, double dLowerPos, double dUpperPos)
{
	long ulTrigNum = 47000;
	DWORD *ulTrigData;

	ulTrigData = new DWORD[47000];

	DWORD  ulSize;

	ulSize = sizeof(ulTrigData);
	
	memset(ulTrigData, 0xFF, sizeof(DWORD) * 47000);

	DWORD dwCurretTime = 0;
	DWORD dwAfterTime = 0;
	DWORD dwElaspTime = 0;
	

	for(int i = 0; i < 10; i++)
	{
		dwCurretTime = GetCurrentTickCount();
		AxcTriggerSetAbs(m_nChannelNo[nSelChannel], ulTrigNum, ulTrigData, 0);
		dwAfterTime  = GetCurrentTickCount();


		if((dwElaspTime = (dwAfterTime - dwCurretTime)) < 0)
			dwElaspTime += 0x7FFFFFFF;

		TRACE("dwElaspTime = %ld\n", dwElaspTime);
		TRACE("dwElaspTime = %ld\n", ulTrigData[40000]);
	}
	delete [] ulTrigData;

}


void CCounterTestDlg::OnLbnDblclkLstLog()
{
	m_lstLog.ResetContent();	
}

#include <sys/timeb.h>
void CCounterTestDlg::TraceLog(char *fmt, ...)
{
	va_list ap;
	char    buf[2048];

	CString	output_string;
	CString	error_code;
	struct _timeb time_tb;
	_ftime(&time_tb);
	CTime tim(time_tb.time);
	CString timeString = tim.Format("[%H:%M:%S]");

	va_start(ap, fmt);
	vsprintf(buf, fmt, ap);
	va_end(ap);

	output_string	= timeString + buf;

	m_lstLog.AddString(output_string);
	m_lstLog.SetTopIndex(m_lstLog.GetCount() - 1);
}

void CCounterTestDlg::OnBnClickedBtnPosClear(UINT nID)
{
	DWORD	dwRetCode;
	UINT	nSelChannel = nID - IDC_BTN_POS_CLEAR_00;

	dwRetCode = AxcStatusSetActPos(m_nChannelNo[nSelChannel], 0.0);
	if(dwRetCode != AXT_RT_SUCCESS){
		TraceLog("ERROR[%ld]: AxcStatusSetActPos(%02d, %lf)", dwRetCode, m_nChannelNo[nSelChannel], 0.0);
	}
}

void CCounterTestDlg::OnBnClickedBtnSetUnit(UINT nID)
{
	BOOL	bRetCode;
	double	dMoveUnit;
	UINT	nSelChannel = nID - IDC_BTN_SET_UNIT_00;
	
	dMoveUnit= GetDlgItemDouble(IDC_EDT_UNIT_PULSE_00 + nSelChannel);
//	bRetCode = CNTset_moveunit_perpulse(m_nChannelNo[nSelChannel], dMoveUnit);
//	if(bRetCode == FALSE){
//		TraceLog("ERROR: CNTset_moveunit_perpulse(%02d, %lf)", m_nChannelNo[nSelChannel], dMoveUnit);
//	}
}

void CCounterTestDlg::OnBnClickedChkEncReverse(UINT nID)
{
	DWORD	dwRetCode;
	DWORD	dwReverse;
	UINT	nSelChannel = nID - IDC_CHK_ENC_REVERSE_00;

	dwReverse = IsDlgButtonChecked(nID);
	dwRetCode = AxcSignalSetEncReverse(m_nChannelNo[nSelChannel], dwReverse);
	if(dwRetCode != AXT_RT_SUCCESS){
		TraceLog("ERROR[%ld]: AxcSignalSetEncReverse(%02d, %d)", dwRetCode, m_nChannelNo[nSelChannel], dwReverse);
	}
}

void CCounterTestDlg::OnBnClickedChkOut0(UINT nID)
{
	DWORD	dwRetCode;
	DWORD	dwOutput;	DWORD	nBit = nID - IDC_CHK_OUT_00;
	DWORD	dwTriggerPos[1000];
	double	dPulseWidth;
			
	dwOutput	= IsDlgButtonChecked(nID);
	dwRetCode    = AxcSignalWriteOutputBit(m_nChannelNo[CHANNEL_00], nBit, dwOutput);
	if(dwRetCode != AXT_RT_SUCCESS){
		TraceLog("ERROR[%ld]: AxcSignalWriteOutputBit(%02d, %d, %d)", dwRetCode, m_nChannelNo[CHANNEL_00], nBit, dwOutput);
	}
}

void CCounterTestDlg::OnBnClickedChkOut1(UINT nID)
{
    DWORD	dwRetCode;
    DWORD	dwOutput;
    DWORD	nBit = nID - IDC_CHK_OUT_10;

    dwOutput	= IsDlgButtonChecked(nID);
    dwRetCode    = AxcSignalWriteOutputBit(m_nChannelNo[CHANNEL_01], nBit, dwOutput);
    if(dwRetCode != AXT_RT_SUCCESS){
        TraceLog("ERROR[%ld]: AxcSignalWriteOutputBit(%02d, %d, %d)", dwRetCode, m_nChannelNo[CHANNEL_01], nBit, dwOutput);
    }
}

void CCounterTestDlg::OnBnClickedChkTrigEnable(UINT nID)
{
    DWORD	dwRetCode;
	UINT	nSelChannel = nID - IDC_CHK_TRIG_ENABLE_00;
	
	if(IsDlgButtonChecked(IDC_CHK_TRIG_ENABLE_00 + nSelChannel))
	{
		dwRetCode = AxcTriggerSetEnable(m_nChannelNo[nSelChannel], ENABLE);
        if(dwRetCode != AXT_RT_SUCCESS)
		{
			TraceLog("ERROR[%ld]: AxcTriggerSetEnable(%02d, ENABLE)",dwRetCode, m_nChannelNo[nSelChannel]);
		}
	}
	else
	{
        dwRetCode = AxcTriggerSetEnable(m_nChannelNo[nSelChannel], DISABLE);
        if(dwRetCode != AXT_RT_SUCCESS)
		{
            TraceLog("ERROR[%ld]: AxcTriggerSetEnable(%02d, DISABLE)",dwRetCode, m_nChannelNo[nSelChannel]);
		}
	}
}

void CCounterTestDlg::OnCbnSelchangeCboSelModule()
{
	UINT16	lModultNo, lChannelNo;
	lModultNo = (UINT16)ConvertComboToAxt(&m_cboSelModule);
	if(lModultNo > -1 && lModultNo >= m_lModuleCount){
		return;
	}

	if(lModultNo == m_nModuleNo)	return;

	lChannelNo	= 0;
	m_nModuleNo = lModultNo;

	m_nChannelNo[CHANNEL_00] = lModultNo * 2;
	m_nChannelNo[CHANNEL_01] = m_nChannelNo[CHANNEL_00] + 1;

	CString strData;
	strData.Format("Channel %02d", m_nChannelNo[CHANNEL_00]);
	m_grpChannel[CHANNEL_00].SetWindowText(strData);

	strData.Format("Channel %02d", m_nChannelNo[CHANNEL_01]);
	m_grpChannel[CHANNEL_01].SetWindowText(strData);

	UpdateState();
}

void CCounterTestDlg::OnCbnSelchangeCboEncMethod00()
{
    DWORD	dwRetCode;
	UINT	nSelChannel = CHANNEL_00;
	DWORD	dwSetMethod;
	
	dwSetMethod	= ConvertComboToAxt(&m_cboEncMethod[nSelChannel]);
	dwRetCode = AxcSignalSetEncInputMethod(m_nChannelNo[nSelChannel], dwSetMethod);
        if(dwRetCode != AXT_RT_SUCCESS){
            TraceLog("ERROR[%ld]:AxcSignalSetEncInputMethod(%02d, %d)",dwRetCode, m_nChannelNo[nSelChannel], dwSetMethod);
	}
}

void CCounterTestDlg::OnCbnSelchangeCboEncMethod01()
{
    DWORD	dwRetCode;
    UINT	nSelChannel = CHANNEL_01;
    DWORD	dwSetMethod;

    dwSetMethod	= ConvertComboToAxt(&m_cboEncMethod[nSelChannel]);
    dwRetCode = AxcSignalSetEncInputMethod(m_nChannelNo[nSelChannel], dwSetMethod);
    if(dwRetCode != AXT_RT_SUCCESS){
        TraceLog("ERROR[%ld]:AxcSignalSetEncInputMethod(%02d, %d)",dwRetCode, m_nChannelNo[nSelChannel], dwSetMethod);
    }
}

void CCounterTestDlg::OnCbnSelchangeCboEncSource00()
{
    DWORD	dwRetCode;
	UINT	nSelChannel = CHANNEL_00;
    DWORD	dwSetMethod;
	
	dwSetMethod	= ConvertComboToAxt(&m_cboEncSource[nSelChannel]);
	dwRetCode	= AxcSignalSetEncSource(m_nChannelNo[nSelChannel], dwSetMethod);
   if(dwRetCode != AXT_RT_SUCCESS){
		TraceLog("ERROR[%ld]: AxcSignalSetEncSource(%02d, %d)", dwRetCode, m_nChannelNo[nSelChannel], dwSetMethod);
	}
}

void CCounterTestDlg::OnCbnSelchangeCboEncSource01()
{
    DWORD	dwRetCode;
    UINT	nSelChannel = CHANNEL_01;
    DWORD	dwSetMethod;

    dwSetMethod	= ConvertComboToAxt(&m_cboEncSource[nSelChannel]);
    dwRetCode	= AxcSignalSetEncSource(m_nChannelNo[nSelChannel], dwSetMethod);
    if(dwRetCode != AXT_RT_SUCCESS){
        TraceLog("ERROR[%ld]: AxcSignalSetEncSource(%02d, %d)", dwRetCode, m_nChannelNo[nSelChannel], dwSetMethod);
    }
}


// return microSecond time stamp.
UINT32 CCounterTestDlg::GetCurrentTickCount(void)
{
    static double dFreq = 0;
    LARGE_INTEGER liCount, liFreq;
	
    if ( dFreq == 0 )
    {
        QueryPerformanceFrequency(&liFreq);
        dFreq = (double)liFreq.QuadPart / 1000000;
		
        if ( dFreq == 0 )
            return 0;
    }
	
    QueryPerformanceCounter(&liCount);
    return( (unsigned long)((double)liCount.QuadPart / dFreq) );
}


// void CCounterTestDlg::OnBnDClickedBtnAddABSPos1(void)
// {
// 	for(int i = 0; i < 512; i++)
// 	{
// 		m_dwABSPosition[0][i] = 0x00;
// 	}
// }
// 
// void CCounterTestDlg::OnBnDClickedBtnAddABSPos2(void)
// {
// 	for(int i = 0; i < 512; i++)
// 	{
// 		m_dwABSPosition[1][i] = 0x00;
// 	}
// }
void CCounterTestDlg::OnCbnSelchangeCboTrigMode00()
{
	DWORD	dwRetCode;
	UINT	nSelChannel = CHANNEL_00;
	DWORD	dwSetMode;
	double	dPeriod, dLowerPos, dUpperPos;

	dwSetMode	= ConvertComboToAxt(&m_cboTrigMode[nSelChannel]);
	dwRetCode	= AxcTriggerSetFunction(m_nChannelNo[nSelChannel], dwSetMode);
	TRACE("ReturnCode = %d, SelChannel = %d, dwSetMode = %d\n", dwRetCode, m_nChannelNo[nSelChannel], dwSetMode);
	Sleep(3);

	if(dwSetMode == 0)
	{
		m_edtPosUpper[nSelChannel].EnableWindow(FALSE);
		m_edtPosLower[nSelChannel].EnableWindow(FALSE);
		m_edtTrigPeriod[nSelChannel].EnableWindow(FALSE);
		m_edtAbsPos[nSelChannel].EnableWindow(TRUE);
	}
	else
	{
		m_edtPosUpper[nSelChannel].EnableWindow(TRUE);
		m_edtPosLower[nSelChannel].EnableWindow(TRUE);
		m_edtTrigPeriod[nSelChannel].EnableWindow(TRUE);
		m_edtAbsPos[nSelChannel].EnableWindow(FALSE);

 		AxcTriggerGetBlockLowerPos(m_nChannelNo[nSelChannel], &dLowerPos);
 		AxcTriggerGetBlockUpperPos(m_nChannelNo[nSelChannel], &dUpperPos);
 		AxcTriggerGetPosPeriod(m_nChannelNo[nSelChannel], &dPeriod);

		SetDlgItemDouble(IDC_EDT_TRIG_PERIOD_00, dPeriod);
		SetDlgItemDouble(IDC_EDT_POS_LOWER_00, dLowerPos);
		SetDlgItemDouble(IDC_EDT_POS_UPPER_00, dUpperPos);
	}

	if(dwRetCode != AXT_RT_SUCCESS){
		TraceLog("ERROR[%ld]: AxcTriggerSetFunction(%ld, %ld)", dwRetCode, m_nChannelNo[nSelChannel], dwSetMode);
	}
}
