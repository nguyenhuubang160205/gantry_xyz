// DIO_TESTDlg.cpp : implementation file
//

#include "stdafx.h"
#include "DIO_TEST.h"
#include "DIO_TESTDlg.h"

#include "CJHyperLink.h"
#include "RegistryValue.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CAboutDlg dialog used for App About

#define	TM_SENSOR_ID		1000
#define	TM_SENSOR_INTERVAL	100
#define WM_DIO_INTERRUPT	1011	//Window message method (define to get interrupt message)

//#ifdef _M_X64
//	#pragma comment(lib, "../../../../AXL(Library)/Library/64Bit/AxL.lib")
//#else
//	#pragma comment(lib, "../../../../AXL(Library)/Library/32Bit/AxL.lib")
//#endif

class CAboutDlg : public CDialog
{
public:
	CAboutDlg();
private:
	CCJHyperLink	m_AjinExtek;
	CString			m_strAuthor;
	CString			m_strCompany;
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
	virtual BOOL OnInitDialog();
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
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CDIO_TESTDlg dialog

CDIO_TESTDlg::CDIO_TESTDlg(CWnd* pParent /*=NULL*/)
	: CDialog(CDIO_TESTDlg::IDD, pParent)
{
	//{{AFX_DATA_INIT(CDIO_TESTDlg)
	//}}AFX_DATA_INIT
	// Note that LoadIcon does not require a subsequent DestroyIcon in Win32
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
	m_hHandle = NULL;
	m_hInterrupt = NULL;
	m_bThread = FALSE;
}

void CDIO_TESTDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CDIO_TESTDlg)
	DDX_Control(pDX, IDC_RADIO_MESSAGE, m_radioMessage);
	DDX_Control(pDX, IDC_CHECK_RISING, m_chkRising);
	DDX_Control(pDX, IDC_LIST_Message, m_listMessage);
	DDX_Control(pDX, IDC_CHECK_FALLING, m_chkFalling);
	DDX_Control(pDX, IDC_CHECK_INTRRUPT, m_chkIntrrupt);
	DDX_Control(pDX, IDC_STATIC_LOW, m_stcLow);
	DDX_Control(pDX, IDC_STATIC_HIGH, m_stcHigh);
	DDX_Control(pDX, IDC_COMBO, m_cboModuleInfo);
	//}}AFX_DATA_MAP
}

BEGIN_MESSAGE_MAP(CDIO_TESTDlg, CDialog)
	//{{AFX_MSG_MAP(CDIO_TESTDlg)
	ON_WM_SYSCOMMAND()
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	ON_CBN_SELCHANGE(IDC_COMBO, OnSelchangeCombo)
	ON_BN_CLICKED(IDC_CHECK_INTRRUPT, OnCheckIntrrupt)
	ON_BN_CLICKED(IDC_CHECK_RISING, OnCheckRising)
	ON_BN_CLICKED(IDC_CHECK_FALLING, OnCheckFalling)
	ON_BN_CLICKED(IDC_LIST_CLEAR, OnListClear)
	ON_WM_DESTROY()
	ON_WM_TIMER()
	ON_BN_CLICKED(IDC_RADIO_MESSAGE, OnRadioMessage)
	ON_BN_CLICKED(IDC_RADIO_CALLBACK, OnRadioCallback)
	ON_BN_CLICKED(IDC_RADIO_EVENT, OnRadioEvent)
	ON_BN_CLICKED(IDC_BUTTON_EXIT, OnButtonExit)
	//}}AFX_MSG_MAP
	ON_COMMAND_RANGE(IDC_CHECK_HIGH_00, IDC_CHECK_HIGH_15, OnClickHigh)
	ON_COMMAND_RANGE(IDC_CHECK_LOW_00, IDC_CHECK_LOW_15, OnClickLow)
	ON_MESSAGE(WM_AXL_INTERRUPT, OnInterruptMessage)
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CDIO_TESTDlg message handlers

BOOL CDIO_TESTDlg::OnInitDialog()
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
	
	LoadAXD();
	LoadAXL();
	
	for (int i = 0; i < 16; i++)
	{
		m_pchkHigh[i]	= (CButton *)GetDlgItem(IDC_CHECK_HIGH_00 + i);
		m_pchkLow[i]	= (CButton *)GetDlgItem(IDC_CHECK_LOW_00 + i);
	}
	
	if(AXTInit())
	{
		OnSelchangeCombo();	
		SetTimer(TM_SENSOR_ID, TM_SENSOR_INTERVAL, NULL);
	}
	
	return TRUE;  // return TRUE  unless you set the focus to a control
}

void CDIO_TESTDlg::OnSysCommand(UINT nID, LPARAM lParam)
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

void CDIO_TESTDlg::OnPaint() 
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
HCURSOR CDIO_TESTDlg::OnQueryDragIcon()
{
	return (HCURSOR) m_hIcon;
}

void CDIO_TESTDlg::OnSelchangeCombo() 
{
	long IModuleCounts;
	AxdInfoGetModuleCount(&IModuleCounts);

	if(IModuleCounts > 0)
	{
		DWORD	dwStateLow = 0;
		DWORD	dwStateHigh = 0;
		long	IBoardNo, lIndex;
		long	IModulePos, lInCount = 0, lOutCount = 0;
		DWORD	dwModuleID;
		BOOL	bFlagHigh;
		BOOL	bFlagLow;
		DWORD	dwInterrupt;

		if(AxdInfoGetModule(m_cboModuleInfo.GetCurSel(), &IBoardNo, &IModulePos, &dwModuleID) == AXT_RT_SUCCESS)
		{

			/*
			1111 1111 1111 1111
			0000 0000 0000 0001
			--------------------				
			0000 0000 0000 0001	
			Check input area comparing with shift operation bit by bit(16bit)
			*/

			switch(dwModuleID)
			{	
			case AXT_SIO_DI32:
			case AXT_SIO_RDI32:
			case AXT_SIO_RDI16MLII:
			case AXT_SIO_RDI32RTEX:
			case AXT_SIO_DI32_P:
				m_stcHigh.SetWindowText("INPUT 1");
				m_stcLow.SetWindowText("INPUT 2");
				if(dwModuleID == AXT_SIO_RDI32){
					m_chkIntrrupt.EnableWindow(false);
					m_chkRising.EnableWindow(false);
					m_chkFalling.EnableWindow(false);
					GetDlgItem(IDC_RADIO_MESSAGE)->EnableWindow(false);
					GetDlgItem(IDC_RADIO_CALLBACK)->EnableWindow(false);
					GetDlgItem(IDC_RADIO_EVENT)->EnableWindow(false);
				}else{
					m_chkIntrrupt.EnableWindow(true);
					m_chkRising.EnableWindow(true);
					m_chkFalling.EnableWindow(true);

					GetDlgItem(IDC_RADIO_MESSAGE)->EnableWindow(true);
					GetDlgItem(IDC_RADIO_CALLBACK)->EnableWindow(true);
					GetDlgItem(IDC_RADIO_EVENT)->EnableWindow(true);

					AxdiInterruptGetModuleEnable(m_cboModuleInfo.GetCurSel(), &dwInterrupt);
					if(dwInterrupt == ENABLE)
					{
						m_chkIntrrupt.SetCheck(1);
					}
					else
					{
						m_chkIntrrupt.SetCheck(0);
					}

					AxdiInterruptEdgeGetWord(m_cboModuleInfo.GetCurSel(), 0, UP_EDGE, &dwStateHigh);
					if (dwStateHigh == 0xFFFF)
						m_chkRising.SetCheck(1);
					else
						m_chkRising.SetCheck(0);

					AxdiInterruptEdgeGetWord(m_cboModuleInfo.GetCurSel(), 0, DOWN_EDGE, &dwStateHigh);
					if (dwStateHigh == 0xFFFF)
						m_chkFalling.SetCheck(1);
					else
						m_chkFalling.SetCheck(0);
				}
				break;
			case AXT_SIO_DO32P:
			case AXT_SIO_DO32T:
			case AXT_SIO_RDO32:
			case AXT_SIO_RDO16AMLII:
			case AXT_SIO_RDO16BMLII:
			case AXT_SIO_RDO32RTEX:
			case AXT_SIO_DO32T_P:

				{	
					m_stcHigh.SetWindowText("OUTPUT 1");
					m_stcLow.SetWindowText("OUTPUT 2");

					m_chkIntrrupt.EnableWindow(false);
					m_chkRising.EnableWindow(false);
					m_chkFalling.EnableWindow(false);
					GetDlgItem(IDC_RADIO_MESSAGE)->EnableWindow(false);
					GetDlgItem(IDC_RADIO_CALLBACK)->EnableWindow(false);
					GetDlgItem(IDC_RADIO_EVENT)->EnableWindow(false);

					AxdoReadOutportWord(m_cboModuleInfo.GetCurSel(), 0, &dwStateHigh);
					AxdoReadOutportWord(m_cboModuleInfo.GetCurSel(), 1, &dwStateLow);

					for (lIndex = 0; lIndex < 16; lIndex++)
					{
						// Verify the last bit value of data read
						bFlagHigh	= dwStateHigh & 0x0001;
						bFlagLow	= dwStateLow & 0x0001;

						// Shift rightward by bit by bit
						dwStateHigh	= dwStateHigh >> 1;
						dwStateLow	= dwStateLow >> 1;

						// Update bit value in control
						m_pchkHigh[lIndex]->SetCheck(bFlagHigh);
						m_pchkLow[lIndex]->SetCheck(bFlagLow);
					}
				}
				break;
			case AXT_SIO_DB32P:
			case AXT_SIO_DB32T:
			case AXT_SIO_RDB32RTEX:
			case AXT_SIO_RDB32T:
			case AXT_SIO_RDB96MLII:
			case AXT_SIO_RDB128MLII:			
			case AXT_SIO_RSIMPLEIOMLII:
				m_stcHigh.SetWindowText("INPUT 1");
				m_stcLow.SetWindowText("OUTPUT 1");

				m_chkIntrrupt.EnableWindow(true);
				m_chkRising.EnableWindow(true);
				m_chkFalling.EnableWindow(true);

				GetDlgItem(IDC_RADIO_MESSAGE)->EnableWindow(true);
				GetDlgItem(IDC_RADIO_CALLBACK)->EnableWindow(true);
				GetDlgItem(IDC_RADIO_EVENT)->EnableWindow(true);

				AxdiInterruptGetModuleEnable(m_cboModuleInfo.GetCurSel(), &dwInterrupt);
				if(dwInterrupt == ENABLE)
				{
					m_chkIntrrupt.SetCheck(1);
				}
				else
				{
					m_chkIntrrupt.SetCheck(0);
				}

				AxdiInterruptEdgeGetWord(m_cboModuleInfo.GetCurSel(), 0, UP_EDGE, &dwStateHigh);
				if (dwStateHigh == 0xFFFF)
					m_chkRising.SetCheck(1);
				else
					m_chkRising.SetCheck(0);

				AxdiInterruptEdgeGetWord(m_cboModuleInfo.GetCurSel(), 0, DOWN_EDGE, &dwStateHigh);
				if (dwStateHigh == 0xFFFF)
					m_chkFalling.SetCheck(1);
				else
					m_chkFalling.SetCheck(0);

				AxdiReadInportWord(m_cboModuleInfo.GetCurSel(), 0, &dwStateHigh);
				AxdoReadOutportWord(m_cboModuleInfo.GetCurSel(), 0, &dwStateLow);

				for(lIndex=0; lIndex<16; lIndex++)
				{
					bFlagHigh	= dwStateHigh & 0x0001;
					bFlagLow	= dwStateLow & 0x0001;

					dwStateHigh	= dwStateHigh >> 1;
					dwStateLow	= dwStateLow >> 1;

					m_pchkHigh[lIndex]->SetCheck(bFlagHigh);
					m_pchkLow[lIndex]->SetCheck(bFlagLow);

				}
				break;

			case AXT_ECAT_DIO:
				AxdInfoGetInputCount(m_cboModuleInfo.GetCurSel(), &lInCount);
				AxdInfoGetOutputCount(m_cboModuleInfo.GetCurSel(), &lOutCount);				

				if(lInCount > 16)	
				{
					m_stcHigh.SetWindowText("INPUT 1");
					m_stcLow.SetWindowText("INPUT 2");
				}
				else if(lInCount > 0)		
				{
					m_stcHigh.SetWindowText("INPUT 1");
					if(lOutCount > 0)	
					{						
						m_stcLow.SetWindowText("OUTPUT 1");
						AxdoReadOutportWord(m_cboModuleInfo.GetCurSel(), 0, &dwStateLow);
					}
					else
					{
						m_stcLow.SetWindowText("");
					}
				}
				else
				{
					if(lOutCount > 16)	
					{
						m_stcHigh.SetWindowText("OUTPUT 1");
						m_stcLow.SetWindowText("OUTPUT 2");
						AxdoReadOutportWord(m_cboModuleInfo.GetCurSel(), 0, &dwStateHigh);
						AxdoReadOutportWord(m_cboModuleInfo.GetCurSel(), 1, &dwStateLow);						
					}
					else if(lOutCount > 0)
					{
						m_stcHigh.SetWindowText("OUTPUT 1");
						m_stcLow.SetWindowText("");
						AxdoReadOutportWord(m_cboModuleInfo.GetCurSel(), 0, &dwStateHigh);
					}
				}

				m_chkIntrrupt.EnableWindow(false);
				m_chkRising.EnableWindow(false);
				m_chkFalling.EnableWindow(false);

				GetDlgItem(IDC_RADIO_MESSAGE)->EnableWindow(false);
				GetDlgItem(IDC_RADIO_CALLBACK)->EnableWindow(false);
				GetDlgItem(IDC_RADIO_EVENT)->EnableWindow(false);

				for(lIndex=0; lIndex < 16; lIndex++)
				{
					bFlagHigh	= dwStateHigh & 0x0001;
					bFlagLow	= dwStateLow & 0x0001;

					dwStateHigh	= dwStateHigh >> 1;
					dwStateLow	= dwStateLow >> 1;

					m_pchkHigh[lIndex]->SetCheck(bFlagHigh);
					if(lOutCount > 16)
						m_pchkLow[lIndex]->SetCheck(bFlagLow);
				}
				break;
			}
		}

		UpdateCheckEnable();
	}
}

void CDIO_TESTDlg::UpdateCheckEnable()
{
	long lIndex = 0;
	long lInCount = 0, lOutCount = 0, lTotalCount = 0;
	
	AxdInfoGetInputCount(m_cboModuleInfo.GetCurSel(), &lInCount);
	AxdInfoGetOutputCount(m_cboModuleInfo.GetCurSel(), &lOutCount);				

	lTotalCount = lInCount + lOutCount;
	for(lIndex = 0; lIndex < 16; lIndex++)
	{
		if(lTotalCount > lIndex)		m_pchkHigh[lIndex]->EnableWindow(TRUE);
		else
		{
			m_pchkHigh[lIndex]->SetCheck(FALSE);
			m_pchkHigh[lIndex]->EnableWindow(FALSE);
		}

		if(lTotalCount > lIndex + 16)	m_pchkLow[lIndex]->EnableWindow(TRUE);
		else
		{
			m_pchkLow[lIndex]->SetCheck(FALSE);
			m_pchkLow[lIndex]->EnableWindow(FALSE);
		}
	}
}

BOOL CDIO_TESTDlg::AXTInit()
{
	// Initialize library 
	DWORD Code = AxlOpenNoReset(7);
	if ( Code == AXT_RT_SUCCESS)
	{
		TRACE("Library is initialized .\n");
		DWORD dwStatus;
		
		// Inspect if DIO module exsits
		Code = AxdInfoIsDIOModule(&dwStatus);
		if(dwStatus == STATUS_EXIST)
		{
			TRACE("DIO module exists.\n");
			long IModuleCounts;
			Code = AxdInfoGetModuleCount(&IModuleCounts);
			if(Code == AXT_RT_SUCCESS)
				TRACE("Number of DIO module: %d\n",IModuleCounts);
			else
				TRACE("AxdInfoGetModuleCount() : ERROR code Ox%x\n",Code);
			
			long IInputCounts;
			long IOutputCounts;
			
			long IBoardNo;
			long IModulePos;
			DWORD dwModuleID;
			
			CString strData;
			char	szModuleName[50] = "";
			for(int ModuleNo=0; ModuleNo < IModuleCounts; ModuleNo++)
			{
				// Grasp IO channel
				AxdInfoGetInputCount(ModuleNo, &IInputCounts);
				AxdInfoGetOutputCount(ModuleNo, &IOutputCounts);
				
				if(AxdInfoGetModule(ModuleNo, &IBoardNo, &IModulePos, &dwModuleID) == AXT_RT_SUCCESS)
				{
					switch(dwModuleID)
					{						
					case AXT_SIO_DI32:
						strData.Format("[BD No:%d - MD No:%d] SIO_DI32", IBoardNo, ModuleNo);
						break;
					case AXT_SIO_RDI32:
						strData.Format("[BD No:%d - MD No:%d] SIO_RDI32", IBoardNo, ModuleNo);
						break;
					case AXT_SIO_DO32P:
						strData.Format("[BD No:%d - MD No:%d] SIO_DO32P", IBoardNo, ModuleNo);
						break;
					case AXT_SIO_DB32P:
						strData.Format("[BD No:%d - MD No:%d] SIO_DB32P", IBoardNo, ModuleNo);
						break;
					case AXT_SIO_DO32T:
						strData.Format("[BD No:%d - MD No:%d] SIO_DO32T", IBoardNo, ModuleNo);
						break;
					case AXT_SIO_RDO32:
						strData.Format("[BD No:%d - MD No:%d] SIO_RDO32", IBoardNo, ModuleNo);
						break;
					case AXT_SIO_DB32T:
						strData.Format("[BD No:%d - MD No:%d] SIO_DB32T", IBoardNo, ModuleNo);
						break;
					case AXT_SIO_RDB128MLII:
						strData.Format("[BD No:%d - MD No:%d] SIO_RDB128MLII", IBoardNo, ModuleNo);
						break;
					case AXT_SIO_RSIMPLEIOMLII:
						strData.Format("[BD No:%d - MD No:%d] SIO_RSIMPLEIOMLII", IBoardNo, ModuleNo);
						break;
					case AXT_SIO_RDI16MLII:
						strData.Format("[BD No:%d - MD No:%d] SIO_RDI16MLII", IBoardNo, ModuleNo);
						break;
					case AXT_SIO_RDO16AMLII:
						strData.Format("[BD No:%d - MD No:%d] SIO_RDO16AMLII", IBoardNo, ModuleNo);
						break;
					case AXT_SIO_RDO16BMLII:
						strData.Format("[BD No:%d - MD No:%d] SIO_RDO16BMLII", IBoardNo, ModuleNo);
						break;
					case AXT_SIO_RDB96MLII:
						strData.Format("[BD No:%d - MD No:%d] SIO_RDB96MLII", IBoardNo, ModuleNo);
						break;
					case AXT_SIO_RDO32RTEX:
						strData.Format("[BD No:%d - MD No:%d] SIO_RDO32RTEX", IBoardNo, ModuleNo);
						break;
					case AXT_SIO_RDI32RTEX:
						strData.Format("[BD No:%d - MD No:%d] SIO_RDI32RTEX", IBoardNo, ModuleNo);
						break;
					case AXT_SIO_RDB32RTEX:
						strData.Format("[BD No:%d - MD No:%d] SIO_RDB32RTEX", IBoardNo, ModuleNo);
						break;
					case AXT_SIO_DI32_P:
						strData.Format("[BD No:%d - MD No:%d] SIO_DI32_P", IBoardNo, ModuleNo);
						break;
					case AXT_SIO_DO32T_P:
						strData.Format("[BD No:%d - MD No:%d] SIO_DO32T_P", IBoardNo, ModuleNo);
						break;
					case AXT_SIO_RDB32T:
						strData.Format("[BD No:%d - MD No:%d] SIO_RDB32T", IBoardNo, ModuleNo);
						break;
					case AXT_ECAT_DIO:
						AxdInfoGetModuleEx(ModuleNo, NULL, szModuleName, NULL);
						strData.Format("[BD No:%d - MD No:%d] %s", IBoardNo, ModuleNo, szModuleName);
						break;

					default:
						strData.Format("[BD No:%d - MD No:%d] Unknown", IBoardNo, ModuleNo);
						break;
					}
					m_cboModuleInfo.AddString(strData);
				}
				m_cboModuleInfo.SetCurSel(0);
			}
		}
		else
		{
			AfxMessageBox("Module not exist.");
			return FALSE;
		}
	}
	else
	{
		AfxMessageBox("Failed initialization.");
		return FALSE;
	}
	return TRUE;
}

void CDIO_TESTDlg::OnListClear() 
{
	m_listMessage.ResetContent();
}

void CDIO_TESTDlg::OnDestroy() 
{
	CDialog::OnDestroy();
	
	//Exit timer
	KillTimer(0);
	// Exit library and motion
	CloseDevice();
}

void CDIO_TESTDlg::OnTimer(UINT_PTR nIDEvent) 
{
	short		nIndex;
	DWORD		dwDataHigh = 0;
	DWORD		dwDataLow = 0;
	BOOL		bFlagHigh;
	BOOL		bFlagLow;
	long		lBoardNo;
	long		lModulePos, lCount = 0;
	DWORD		dwModuleID;

	switch (nIDEvent)
	{
	case TM_SENSOR_ID:
		AxdInfoGetModule(m_cboModuleInfo.GetCurSel(), &lBoardNo, &lModulePos, &dwModuleID);	
		
		switch (dwModuleID)
		{
		case AXT_SIO_DI32:
		case AXT_SIO_RDI32:
		case AXT_SIO_RDI16MLII:
		case AXT_SIO_RDI32RTEX:
		case AXT_SIO_DI32_P:

			//++
			// Read inputting signal in WORD
			AxdiReadInportWord(m_cboModuleInfo.GetCurSel(), 0, &dwDataHigh);
			AxdiReadInportWord(m_cboModuleInfo.GetCurSel(), 1, &dwDataLow);

			for (nIndex = 0; nIndex < 16; nIndex++)
			{
				// Verify the last bit value of data read
				bFlagHigh	= dwDataHigh & 0x0001;
				bFlagLow	= dwDataLow & 0x0001;
				
				// Shift rightward by bit by bit
				dwDataHigh	= dwDataHigh >> 1;
				dwDataLow	= dwDataLow >> 1;

				// Updat bit value in control
				m_pchkHigh[nIndex]->SetCheck(bFlagHigh);
				m_pchkLow[nIndex]->SetCheck(bFlagLow);
			}
			break;

		case AXT_SIO_DB32P:
		case AXT_SIO_DB32T:
		case AXT_SIO_RDB32RTEX:
		case AXT_SIO_RDB32T:
		case AXT_SIO_RDB96MLII:
		case AXT_SIO_RDB128MLII:			
		case AXT_SIO_RSIMPLEIOMLII:
			//++
			// Read inputting signal in WORD
			AxdiReadInportWord(m_cboModuleInfo.GetCurSel(), 0, &dwDataHigh);

			for (nIndex = 0; nIndex < 16; nIndex++)
			{
				// Verify the last bit value of data read
				bFlagHigh	= dwDataHigh & 0x0001;
				
				// Shift rightward by bit by bit
				dwDataHigh	= dwDataHigh >> 1;

				// Updat bit value in control
				m_pchkHigh[nIndex]->SetCheck(bFlagHigh);
			}
			break;

		case AXT_ECAT_DIO:
			// Read input connect
			AxdInfoGetInputCount(m_cboModuleInfo.GetCurSel(), &lCount);

			if(lCount > 0)
			{
				AxdiReadInportWord(m_cboModuleInfo.GetCurSel(), 0, &dwDataHigh);
				AxdiReadInportWord(m_cboModuleInfo.GetCurSel(), 1, &dwDataLow);

				for(nIndex = 0; nIndex < 16; nIndex++)
				{
					// Verify the last bit value of data read
					bFlagHigh	= dwDataHigh & 0x0001;
					bFlagLow	= dwDataLow & 0x0001;

					// Shift rightward by bit by bit
					dwDataHigh	= dwDataHigh >> 1;
					dwDataLow	= dwDataLow >> 1;

					// Updat bit value in control
					m_pchkHigh[nIndex]->SetCheck(bFlagHigh);

					if(lCount > 16)
						m_pchkLow[nIndex]->SetCheck(bFlagLow);
				}
			}
			break;
		}
		break;
	}
	
	CDialog::OnTimer(nIDEvent);
}

void CDIO_TESTDlg::OnClickHigh(UINT nID)
{
	long IModuleCounts;
	AxdInfoGetModuleCount(&IModuleCounts);
	
	if(IModuleCounts > 0)
	{	
		long	IBoardNo;
		long	IModulePos, lCount = 0;
		DWORD	dwModuleID;
		CString strMessage;
		short	nIndex;
		BOOL    bState;
		
		if(AxdInfoGetModule(m_cboModuleInfo.GetCurSel(), &IBoardNo, &IModulePos, &dwModuleID) == AXT_RT_SUCCESS)
		{
			switch(dwModuleID)
			{	
			case AXT_SIO_DO32P:
			case AXT_SIO_DO32T:
			case AXT_SIO_RDO32:
				nIndex	= nID - IDC_CHECK_HIGH_00;
				bState = m_pchkHigh[nIndex]->GetCheck();
				AxdoWriteOutportBit(m_cboModuleInfo.GetCurSel(), nIndex, bState);
				break;

			case AXT_ECAT_DIO:
				AxdInfoGetOutputCount(m_cboModuleInfo.GetCurSel(), &lCount);
				if(lCount > 0)
				{
					nIndex	= nID - IDC_CHECK_HIGH_00;
					bState = m_pchkHigh[nIndex]->GetCheck();

					AxdoWriteOutportBit(m_cboModuleInfo.GetCurSel(), nIndex, bState);
				}
				break;
			}
		}
	}
}

void CDIO_TESTDlg::OnClickLow(UINT nID)
{
	long IModuleCounts;
	AxdInfoGetModuleCount(&IModuleCounts);
	
	if(IModuleCounts > 0)
	{	
		long	IBoardNo;
		long	IModulePos, lCount = 0;
		DWORD	dwModuleID;
		CString strMessage;
		short	nIndex;
		BOOL    bState;
		
		if(AxdInfoGetModule(m_cboModuleInfo.GetCurSel(), &IBoardNo, &IModulePos, &dwModuleID) == AXT_RT_SUCCESS)
		{
			switch(dwModuleID)
			{
			case AXT_SIO_DB32P:
			case AXT_SIO_DB32T:
			case AXT_SIO_RDB128MLII:
				nIndex	= nID - IDC_CHECK_LOW_00;
				bState = m_pchkLow[nIndex]->GetCheck();
				AxdoWriteOutportBit(m_cboModuleInfo.GetCurSel(), nIndex, bState);
				break;
			case AXT_SIO_DO32P:
			case AXT_SIO_DO32T:
			case AXT_SIO_RDO32:

				nIndex	= nID - IDC_CHECK_LOW_00;
				bState = m_pchkLow[nIndex]->GetCheck();
				AxdoWriteOutportBit(m_cboModuleInfo.GetCurSel(), nIndex+16, bState);
				break;

			case AXT_ECAT_DIO:
				AxdInfoGetOutputCount(m_cboModuleInfo.GetCurSel(), &lCount);
				if(lCount > 16)
				{
					nIndex	= nID - IDC_CHECK_LOW_00;
					bState = m_pchkLow[nIndex]->GetCheck();

					AxdoWriteOutportBit(m_cboModuleInfo.GetCurSel(), nIndex+16, bState);
				}
				break;
			}
		}
	}
}

BOOL CDIO_TESTDlg::OnModuleInfo(long lModuleNo, short *InputCount)
{
	long	IBoardNo;
	long	IModulePos;
	DWORD	dwModuleID;

	if(AxdInfoGetModule(lModuleNo, &IBoardNo, &IModulePos, &dwModuleID) == AXT_RT_SUCCESS)
	{
		switch(dwModuleID)
		{
		case AXT_SIO_DI32:
		case AXT_SIO_RDI32:		
		case AXT_SIO_RDI32RTEX:
		case AXT_SIO_DI32_P:
			*InputCount = 32;
			break;
		case AXT_SIO_DB32P:
		case AXT_SIO_DB32T:
		case AXT_SIO_RDB32RTEX:
		case AXT_SIO_RDB32T:		
		case AXT_SIO_RDB128MLII:			
		case AXT_SIO_RSIMPLEIOMLII:
		case AXT_SIO_RDI16MLII:
			*InputCount = 16;
			break;
		case AXT_SIO_RDB96MLII:
			*InputCount = 96;
			break;
		}
		return TRUE;
	}
	return FALSE;	
}

BOOL CDIO_TESTDlg::CloseDevice()
{
	// Verify if the integrated library is available to use (If it is initialized)  
	if (AxlIsOpened())
	{
		AxlClose();
		FreeAXD();
		FreeAXL();

		return	TRUE;
	}
	else
	{
		return	FALSE;
	}
}

BOOL CAboutDlg::OnInitDialog() 
{
	CDialog::OnInitDialog();
	
	m_AjinExtek.SubclassDlgItem(IDC_AJINEXTEK, this);

	CRegistryValue	RegistryValue;
	CString			strData;

	m_strAuthor.LoadString(IDS_STRING1008);
	m_strCompany.LoadString(IDS_STRING1009);

	RegistryValue.GetCurrentName("AJINEXTEK\\EzConfig\\Information", "Author", m_strAuthor);
	RegistryValue.GetCurrentName("AJINEXTEK\\EzConfig\\Information", "Company", m_strCompany);
	
	UpdateData(FALSE);
	
	return TRUE;  // return TRUE unless you set the focus to a control
	              // EXCEPTION: OCX Property Pages should return FALSE
}

void CDIO_TESTDlg::OnButtonExit() 
{
	CloseDevice();
	
	OnOK();
}

void CDIO_TESTDlg::OnCheckIntrrupt() 
{
	long IModuleCounts;
	AxdInfoGetModuleCount(&IModuleCounts);

	if(IModuleCounts > 0)
	{
		long	IBoardNo;
		long	IModulePos;
		DWORD	dwModuleID;
		CString strMessage;
		
		if(AxdInfoGetModule(m_cboModuleInfo.GetCurSel(), &IBoardNo, &IModulePos, &dwModuleID) == AXT_RT_SUCCESS)
		{
			switch(dwModuleID)
			{	
			case AXT_SIO_DI32:
			case AXT_SIO_RDI32:
			case AXT_SIO_DB32P:
			case AXT_SIO_DB32T:
				if(m_chkIntrrupt.GetCheck())
				{
					AxlInterruptEnable();
					strMessage.Format("Enable Interrupt Button Enable");
					AxdiInterruptSetModuleEnable(m_cboModuleInfo.GetCurSel(), ENABLE);
				}
				else
				{
					//Initialize interrupt part
					strMessage.Format("Enable Interrupt Button Desable");
					AxdiInterruptEdgeSetDword(m_cboModuleInfo.GetCurSel(), 0, UP_EDGE, 0x00000000);
					AxdiInterruptEdgeSetDword(m_cboModuleInfo.GetCurSel(), 0, DOWN_EDGE, 0x00000000);

					m_chkRising.SetCheck(0);
					m_chkFalling.SetCheck(0);
					m_radioMessage.SetCheck(0);

					AxdiInterruptSetModuleEnable(m_cboModuleInfo.GetCurSel(), DISABLE);
					//Initialize interrupt event (3 ways: callback, window message, event)
					AxdiInterruptSetModule(m_cboModuleInfo.GetCurSel(), m_hWnd, NULL, NULL, NULL);
					AxlInterruptDisable();

				}
				break;
			default:
				strMessage.Format("It is the module not to able to use Enable Interrupt.");
				m_chkIntrrupt.SetCheck(0);
				break;
			}
			m_listMessage.AddString(strMessage);
			
		}
	}
}

void CDIO_TESTDlg::OnCheckRising() 
{
	long IModuleCounts;
	AxdInfoGetModuleCount(&IModuleCounts);

	if(IModuleCounts > 0)
	{
	
		long	IBoardNo;
		long	IModulePos;
		DWORD	dwModuleID;
		CString strMessage;
		
		if(m_chkIntrrupt.GetCheck())
		{
			if(AxdInfoGetModule(m_cboModuleInfo.GetCurSel(), &IBoardNo, &IModulePos, &dwModuleID) == AXT_RT_SUCCESS)
			{
				switch(dwModuleID)
				{	
				case AXT_SIO_DI32:
				case AXT_SIO_RDI32:
					if(m_chkRising.GetCheck())
					{
						strMessage.Format("¡ã Rising Edge Button Ensable");
						AxdiInterruptEdgeSetDword(m_cboModuleInfo.GetCurSel(), 0, UP_EDGE, 0xFFFFFFFF);
					}
					else
					{
						strMessage.Format("¡ã Rising Edge Button Desable");
						AxdiInterruptEdgeSetDword(m_cboModuleInfo.GetCurSel(), 0, UP_EDGE, 0x00000000);
					}
					break;
				case AXT_SIO_DB32P:
				case AXT_SIO_DB32T:
					if(m_chkRising.GetCheck())
					{
						strMessage.Format("¡ã Rising Edge Button Ensable");
						AxdiInterruptEdgeSetWord(m_cboModuleInfo.GetCurSel(), 0, UP_EDGE, 0xFFFF);
					}
					else
					{
						strMessage.Format("¡ã Rising Edge Button Desable");
						AxdiInterruptEdgeSetWord(m_cboModuleInfo.GetCurSel(), 0, UP_EDGE, 0x0000);
					}
					break;
				default:
					strMessage.Format("It is the module not to able to use ¡ã Rising Edge.");
					m_chkRising.SetCheck(0);
					break;
				}
				
			}
		}
		else
		{
			strMessage.Format("Enable Interrupt is not to be selected.");
			m_chkRising.SetCheck(0);
		}
		m_listMessage.AddString(strMessage);
	}
}

void CDIO_TESTDlg::OnCheckFalling() 
{
	long IModuleCounts;
	AxdInfoGetModuleCount(&IModuleCounts);
	
	if(IModuleCounts > 0)
	{	
		long	IBoardNo;
		long	IModulePos;
		DWORD	dwModuleID;
		CString strMessage;
		
		if(m_chkIntrrupt.GetCheck())
		{
			if(AxdInfoGetModule(m_cboModuleInfo.GetCurSel(), &IBoardNo, &IModulePos, &dwModuleID) == AXT_RT_SUCCESS)
			{
				switch(dwModuleID)
				{	
				case AXT_SIO_DI32:
				case AXT_SIO_RDI32:
					if(m_chkFalling.GetCheck())
					{
						strMessage.Format("¡å Falling Edge Button Ensable");
						AxdiInterruptEdgeSetDword(m_cboModuleInfo.GetCurSel(), 0, DOWN_EDGE, 0xFFFFFFFF);
					}
					else
					{
						strMessage.Format("¡å Falling Edge Button Desable");
						AxdiInterruptEdgeSetDword(m_cboModuleInfo.GetCurSel(), 0, DOWN_EDGE, 0x00000000);
					}
					break;
				case AXT_SIO_DB32P:
				case AXT_SIO_DB32T:
					if(m_chkFalling.GetCheck())
					{
						strMessage.Format("¡å Falling Edge Button Ensable");
						AxdiInterruptEdgeSetWord(m_cboModuleInfo.GetCurSel(), 0, DOWN_EDGE, 0xFFFF);
					}
					else
					{
						strMessage.Format("¡å Falling Edge Button Desable");
						AxdiInterruptEdgeSetWord(m_cboModuleInfo.GetCurSel(), 0, DOWN_EDGE, 0x0000);
					}
					break;
				default:
					strMessage.Format("It is the module not to able to use ¡å Falling Edge.");
					m_chkFalling.SetCheck(0);
					break;
				}
				
			}
		}
		else
		{
			strMessage.Format("Enable Interrupt is not to be selected.");
			m_chkFalling.SetCheck(0);
		}
		m_listMessage.AddString(strMessage);
	}
}

void CDIO_TESTDlg::OnRadioMessage() 
{
	long IModuleCounts;
	AxdInfoGetModuleCount(&IModuleCounts);
	
	if(IModuleCounts > 0)
	{	

		CString strMessage;
		
		if(m_chkIntrrupt.GetCheck())
		{
			//Initialize interrupt method
			AxdiInterruptSetModule(m_cboModuleInfo.GetCurSel(), m_hWnd, NULL, NULL, NULL);
	
			//Exit thread
			if (m_hHandle)
			{
				TerminateThread(m_hHandle, 0);
				WaitForSingleObject(m_hHandle, WAIT_ABANDONED);
				CloseHandle(m_hHandle);
				m_bThread	= NULL;
				m_hHandle	= NULL;
			}

			AxdiInterruptSetModule(m_cboModuleInfo.GetCurSel(), m_hWnd, WM_AXL_INTERRUPT, NULL, NULL);
			
			strMessage.Format("Window Message Interrupt is selected.");
			
		}

		else
		{
			strMessage.Format("Enable Interrupt is not to be selected.");
			m_radioMessage.SetCheck(0);
			
		}

		m_listMessage.AddString(strMessage);
	}
}

LRESULT CDIO_TESTDlg::OnInterruptMessage(WPARAM wParam, LPARAM lParam)
{
	short	InputCount = 0;
	DWORD	dwValue;

	int		nBoard		= HIBYTE(wParam);	// Board number of interrupt occurrence (0,1¡¦.)
	int		nModule		= LOBYTE(wParam);	// Module number of interrupt occurrence (0,1,2,3)
	int		nIntrFlag	= (int)lParam;		// Flag of interrupt occurrence ( verify interrupt occurrence at input port 1,2,4,8,16..)

	CString strMessage;

	if(OnModuleInfo(nModule, &InputCount))
	{
		for(int ChkBit=0; ChkBit < InputCount; ChkBit++)
		{
			if((nIntrFlag >> ChkBit) & 0x01)
			{
				AxdiReadInportBit(nModule, ChkBit, &dwValue);
				if (dwValue)
					strMessage.Format("¡ã Rising %02Xh", ChkBit);
				else
					strMessage.Format("¡å Falling %02Xh", ChkBit);
			}	
		}
		m_listMessage.AddString(strMessage);
	}
	return 0;
}

void __stdcall OnDIOInterruptCallback (long lActiveNo, DWORD uFlag)
{
	short	InputCount = 0;
	DWORD	dwValue;
	CString strMessage;

	CDIO_TESTDlg *pDlg = (CDIO_TESTDlg*) AfxGetApp ()->GetMainWnd () ;

	if(pDlg->OnModuleInfo(lActiveNo, &InputCount))
	{
		for(int ChkBit=0; ChkBit < InputCount; ChkBit++)
		{
			if((uFlag >> ChkBit) & 0x01)
			{
				AxdiReadInportBit(lActiveNo, ChkBit, &dwValue);
				if (dwValue)
					strMessage.Format("¡ã Rising %02Xh", ChkBit);
				else
					strMessage.Format("¡å Falling %02Xh", ChkBit);
			}	
		}
		pDlg->m_listMessage.AddString(strMessage);
	}
	return ;
}


void CDIO_TESTDlg::OnRadioCallback() 
{
	long IModuleCounts;
	AxdInfoGetModuleCount(&IModuleCounts);
	
	if(IModuleCounts > 0)
	{	
		CString strMessage;
		
		if(m_chkIntrrupt.GetCheck())
		{
			//Initialize interrupt method
			AxdiInterruptSetModule(m_cboModuleInfo.GetCurSel(), m_hWnd, NULL, NULL, NULL);
			
			if (m_hHandle)
			{
				TerminateThread(m_hHandle, 0);
				WaitForSingleObject(m_hHandle, WAIT_ABANDONED);
				CloseHandle(m_hHandle);
				m_bThread	= NULL;
				m_hHandle	= NULL;
			}
			
			AxdiInterruptSetModule(m_cboModuleInfo.GetCurSel(), NULL, NULL, (AXT_INTERRUPT_PROC)OnDIOInterruptCallback, NULL);
			
			strMessage.Format("Callback Intrrupt is selected.");
		}

		else
		{
			strMessage.Format("Enable Intrrupt is selected.");
			m_radioMessage.SetCheck(0);
		}

		m_listMessage.AddString(strMessage);
	}
}

BOOL ThreadProc(LPVOID lpData)
{
	CDIO_TESTDlg *pDlg	= (CDIO_TESTDlg *)lpData;

	pDlg->ThreadData();

	return TRUE;
}

void CDIO_TESTDlg::OnRadioEvent() 
{
	long IModuleCounts;
	AxdInfoGetModuleCount(&IModuleCounts);
	
	if(IModuleCounts > 0)
	{	
		CString strMessage;
		
		if(m_chkIntrrupt.GetCheck())
		{
			//Initialize interrupt method
			AxdiInterruptSetModule(m_cboModuleInfo.GetCurSel(), m_hWnd, NULL, NULL, NULL);
			
			AxdiInterruptSetModule(m_cboModuleInfo.GetCurSel(), NULL, NULL, NULL, &m_hInterrupt);
			
			if (m_hHandle)
			{
				TerminateThread(m_hHandle, 0);
				WaitForSingleObject(m_hHandle, WAIT_ABANDONED);
				CloseHandle(m_hHandle);
				m_bThread	= NULL;
				m_hHandle	= NULL;
			}

			if (!m_bThread)
			{
				m_bThread	= TRUE;
				m_hHandle	= CreateThread(NULL, 0, (LPTHREAD_START_ROUTINE)ThreadProc, this, NULL, NULL);
			}
			
			strMessage.Format("Event Intrrupt is selected.");
		}

		else
		{
			strMessage.Format("Enable Intrrupt is selected.");
			m_radioMessage.SetCheck(0);
		}

		m_listMessage.AddString(strMessage);
	}
}

BOOL CDIO_TESTDlg::ThreadData()
{
	while(m_bThread)
	{
		if (WaitForSingleObject(m_hInterrupt, INFINITE) == WAIT_OBJECT_0)
		{
			long IModuleCounts;
			AxdInfoGetModuleCount(&IModuleCounts);
			
			if(IModuleCounts > 0)
			{	
				CString strMessage;
				
				if(m_chkIntrrupt.GetCheck())
				{
					long	lModuleNo;
					DWORD	dwFlag;
					CString	strData;
					CString	strInt;
					DWORD	dwValue;
					short	InputCount = 0;
					
					//Verify interrupt occurrence position
					AxdiInterruptRead(&lModuleNo, &dwFlag);
					//TRACE("\nInterrupt => %d %08X\n", lModuleNo, dwFlag);
					
					if(OnModuleInfo(lModuleNo, &InputCount))
					{
						for(int ChkBit=0; ChkBit < InputCount; ChkBit++)
						{
							if((dwFlag >> ChkBit) & 0x01)
							{
								AxdiReadInportBit(lModuleNo, ChkBit, &dwValue);
								if (dwValue)
									strMessage.Format("¡ã Rising %02Xh", ChkBit);
								else
									strMessage.Format("¡å Falling %02Xh", ChkBit);
							}	
						}
						m_listMessage.AddString(strMessage);
					}
				}
			}
		}
	}

	return TRUE;
}
