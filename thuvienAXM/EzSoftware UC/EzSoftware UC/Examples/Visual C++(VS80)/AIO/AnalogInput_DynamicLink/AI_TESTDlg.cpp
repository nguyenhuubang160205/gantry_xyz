// AI_TESTDlg.cpp : implementation file
//

#include "stdafx.h"
#include "AI_TEST.h"
#include "AI_TESTDlg.h"
#include "ChannelArray.h"

#include "CJHyperLink.h"
#include "RegistryValue.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CAboutDlg dialog used for App About

//#ifdef _M_X64
//	#pragma comment(lib, "../../../../AXL(Library)/Library/64Bit/AxL.lib")
//#else
//	#pragma comment(lib, "../../../../AXL(Library)/Library/32Bit/AxL.lib")
//#endif

#define WM_AIO_INTERRUPT		WM_USER + 0x203

// Thread
BOOL g_bGetDataThreadFlag = FALSE ;
CWinThread* pGetThread ;

// Delay time
int g_GetDelay = 10 ;

HANDLE g_hThreadHandle = NULL;

#define NUM_CHANNEL						64
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
// CAI_TESTDlg dialog

CAI_TESTDlg::CAI_TESTDlg(CWnd* pParent /*=NULL*/)
	: CDialog(CAI_TESTDlg::IDD, pParent)
{
	//{{AFX_DATA_INIT(CAI_TESTDlg)
	//}}AFX_DATA_INIT
	// Note that LoadIcon does not require a subsequent DestroyIcon in Win32
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);	
	nTimer			= 1000 ;				// Timer rate 1000 (1000Hz)
	nLength			= 1000;					// Data Length	1000 (1000)

	for(int i = 0; i < 16; i++)
	{
		pnCHList[i] = 0;
	}
	nChNum = 0;
	dpVolt			= NULL;

	BpStart = NULL;
	m_BChannelAll = NULL;
	dpVolt = NULL;
	m_pChannelList = NULL;
}

void CAI_TESTDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CAI_TESTDlg)
	DDX_Control(pDX, IDC_LIST_AICHANNEL, m_lstAIChannel);
	DDX_Control(pDX, IDC_EDIT_LENGTH, m_edtLength);
	DDX_Control(pDX, IDC_SPIN_LENGTH, m_spnLength);
	DDX_Control(pDX, IDC_BUTTON_START, m_btnStart);
	DDX_Control(pDX, IDC_COMBO_VRANGE, m_cboVRange);
	DDX_Control(pDX, IDC_COMBO_CHANNEL, m_cboChannel);
	DDX_Control(pDX, IDC_COMBO_Module, m_cboModuleInfo);
	//}}AFX_DATA_MAP
}

BEGIN_MESSAGE_MAP(CAI_TESTDlg, CDialog)
	//{{AFX_MSG_MAP(CAI_TESTDlg)
	ON_WM_SYSCOMMAND()
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	ON_CBN_SELCHANGE(IDC_COMBO_Module, OnSelchangeCOMBOModule)
	ON_WM_DESTROY()
	ON_BN_CLICKED(IDC_CHANNEL_ON_OFF, OnChannelOnOff)
	ON_BN_CLICKED(IDC_BUTTON_START, OnButtonStart)
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CAI_TESTDlg message handlers

BOOL CAI_TESTDlg::OnInitDialog()
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

	LoadAXL();
	LoadAXA();
	
	// TODO: Add extra initialization here
	if(OpenDevice())
	{
		InitControl();
		OnSelchangeCOMBOModule();
	}

	return TRUE;  // return TRUE  unless you set the focus to a control
}

void CAI_TESTDlg::OnSysCommand(UINT nID, LPARAM lParam)
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

void CAI_TESTDlg::OnPaint() 
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
HCURSOR CAI_TESTDlg::OnQueryDragIcon()
{
	return (HCURSOR) m_hIcon;
}

BOOL CAI_TESTDlg::OpenDevice()
{
	// Library initialize.
	m_pChannelList = new CChannelArray();

	DWORD Code = AxlOpenNoReset(7);
	
	if ( Code == AXT_RT_SUCCESS)
	{
		TRACE("The library became the initialization.\n");
		DWORD dwStatus;
		
		// The inspection to have AIO module
		Code = AxaInfoIsAIOModule(&dwStatus);
		if(dwStatus == STATUS_EXIST)
		{
			TRACE("AIO module exists.\n");
			long IModuleCounts;
			Code = AxaInfoGetModuleCount(&IModuleCounts);
			if(Code == AXT_RT_SUCCESS)
				TRACE("The number of AIO module: %d\n",IModuleCounts);
			else
				TRACE("AxaGetModuleCount() : ERROR code Ox%x\n",Code);
			
			long IInputCounts;
			long IBoardNo;
			long IModulePos;
			DWORD dwModuleID;
			char	szModuleName[50] = "";
			// An execution existence by the module.
			BpStart = new BOOL[IModuleCounts];

			// All that module channel On/Off setting up situation.
			m_BChannelAll = new BOOL[IModuleCounts];

			m_cboChannel.SetTitleText("B_No. M_No. M_ID, Ch.");
				
			CString strData;
			for(int ModuleNo=0; ModuleNo < IModuleCounts; ModuleNo++)
			{
				// input, output channel grasp
				AxaInfoGetInputCount(ModuleNo, &IInputCounts);
				//AxaGetOutputCount(ModuleNo, &IOutputCounts);
				if(IInputCounts > 0)
				{
					if(AxaInfoGetModule(ModuleNo, &IBoardNo, &IModulePos, &dwModuleID) == AXT_RT_SUCCESS)
					{
						pModuleInfo	m_pModuleInfo = new ModuleInfo;

						switch(dwModuleID)
						{
						/*
						AXT_SIO_AI4RB	// A1h(161) : AI 4Ch, 12 bit
						AXT_SIO_AO4RB	// A2h(162) : AO 4Ch, 12 bit
						AXT_SIO_AI16H	// A3h(163) : AI 4Ch, 16 bit
						AXT_SIO_AO8H	// A4h(164) : AO 4Ch, 16 bit
						AXT_SIO_AI16HB	// A5h(165) : AI 16Ch, 16 bit (SIO-AI16HR(input module))
						AXT_SIO_AO2HB	// A6h(166) : AO 2Ch, 16 bit  (SIO-AI16HR(output module))
						AXT_SIO_RAI8RB  // A7h(167) : AI 8Ch, 16 bit, For RTEX only
						AXT_SIO_RAO4RB  // A8h(168) : AO 4Ch, 16 bit, For RTEX only
						*/
						case AXT_SIO_AI4RB:
							strData.Format("%d ¢Â %d ¢Â SIO_AI4RB [Input : %d]", IBoardNo, ModuleNo, IInputCounts);
							break;
						case AXT_SIO_AI16H:
							strData.Format("%d ¢Â %d ¢Â SIO_AI16H [Input : %d]", IBoardNo, ModuleNo, IInputCounts);
							break;
						case AXT_SIO_AI16HB:
							strData.Format("%d ¢Â %d ¢Â SIO_AI16HB [Input : %d]", IBoardNo, ModuleNo, IInputCounts);
							break;
						case AXT_SIO_RAI8RB:
							strData.Format("%d ¢Â %d ¢Â SIO_RAI8RB [Input : %d]", IBoardNo, ModuleNo, IInputCounts);
							break;
						case AXT_SIO_RAI4MLII:
							strData.Format("%d ¢Â %d ¢Â SIO_RAI4MLII [Input : %d]", IBoardNo, ModuleNo, IInputCounts);
							break;
						case AXT_SIO_RAI16RB:
							strData.Format("%d ¢Â %d ¢Â SIO_RAI16RB [Input : %d]", IBoardNo, ModuleNo, IInputCounts);
							break;
						case AXT_SIO_RAVCI4MLII:
							strData.Format("%d ¢Â %d ¢Â SIO_RAVCI4MLII [Input : %d]", IBoardNo, ModuleNo, IInputCounts);
							break;
						case AXT_SIO_RATI4MLII:
							strData.Format("%d ¢Â %d ¢Â SIO_RATI4MLII [Input : %d]", IBoardNo, ModuleNo, IInputCounts);
							break;
						case AXT_SIO_RARTDI4MLII:
							strData.Format("%d ¢Â %d ¢Â SIO_RARTDI4MLII [Input : %d]", IBoardNo, ModuleNo, IInputCounts);
							break;
						case AXT_SIO_RAO08RTEX:
							strData.Format("%d ¢Â %d ¢Â SIO_RAO08RTEX [Input : %d]", IBoardNo, ModuleNo, IInputCounts);
							break;
						case AXT_SIO_AI8F:
							strData.Format("%d ¢Â %d ¢Â SIO_AI8F [Input : %d]", IBoardNo, ModuleNo, IInputCounts);
							break;
						case AXT_ECAT_AIO:
							if(IInputCounts > 0)
							{
								AxaInfoGetModuleEx(ModuleNo, NULL, szModuleName, NULL);
								strData.Format("%d ¢Â %d ¢Â %s [Input : %d]", IBoardNo, ModuleNo, szModuleName, IInputCounts);
							}
							break;
						}
						m_cboModuleInfo.AddString(strData);

						ChannelInfo* channelInfo = new ChannelInfo[IInputCounts];
						memset(channelInfo, NULL, sizeof(ChannelInfo)*IInputCounts);

						for(int i=0; i < IInputCounts; i++)
						{
							channelInfo[i].BChannelChk = 0;
							channelInfo[i].IChannelNum = i;
						}			

						m_pModuleInfo->lModuleNum = ModuleNo;
						m_pModuleInfo->ICboNum = m_cboModuleInfo.GetCount()-1;
						m_pModuleInfo->IChannelCount = IInputCounts;
						m_pModuleInfo->channelInfo = channelInfo;

						m_pChannelList->m_ModuleInfoList.Add(m_pModuleInfo);

						// A module execution initialization.
						BpStart[m_cboModuleInfo.GetCount()-1] = FALSE;

						// That module total channel On/Off initialization.
						m_BChannelAll[m_cboModuleInfo.GetCount()-1] = FALSE;
					}	
				}
			}
			m_cboModuleInfo.SetCurSel(0);
		}
		else
		{
			AfxMessageBox("The module does not exist.");
			return FALSE;
		}
	}
	else
	{
		AfxMessageBox("Failed the initialization.");
		return FALSE;
	}

	return TRUE;
}

void CAI_TESTDlg::OnSelchangeCOMBOModule() 
{
	//short	nMaxCount;
	m_cboChannel.ResetContent();
	
	long	lChannel_Count = 0;
	CString strChannel;
	long	lModuleNo;
	long	lBoardNo;
	long	lModulePos;
	DWORD	dwModuleID;

	m_pChannelList->GetFindModuleNo(m_cboModuleInfo.GetCurSel(), &lModuleNo);
	AxaInfoGetModule(lModuleNo, &lBoardNo, &lModulePos, &dwModuleID);
	
/*	switch(dwModuleID)
	{
	
	AXT_SIO_AI4RB	// A1h(161) : AI 4Ch, 12 bit
	AXT_SIO_AO4RB	// A2h(162) : AO 4Ch, 12 bit
	AXT_SIO_AI16H	// A3h(163) : AI 4Ch, 16 bit
	AXT_SIO_AO8H	// A4h(164) : AO 4Ch, 16 bit
	AXT_SIO_AI16HB	// A5h(165) : AI 16Ch, 16 bit (SIO-AI16HR(input module))
	AXT_SIO_AO2HB	// A6h(166) : AO 2Ch, 16 bit  (SIO-AI16HR(output module))
	AXT_SIO_RAI8RB  // A7h(167) : AI 8Ch, 16 bit, For RTEX only
	AXT_SIO_RAO4RB  // A8h(168) : AO 4Ch, 16 bit, For RTEX only

	case AXT_SIO_AI4RB:
		m_rdoInterruptMask.EnableWindow(0);
		GetDlgItem(IDC_RADIO_FIFOHALFFULL)->EnableWindow(0);
		break;
	case AXT_SIO_AI16H:
		m_rdoInterruptMask.EnableWindow(1);
		GetDlgItem(IDC_RADIO_FIFOHALFFULL)->EnableWindow(1);
		break;
	case AXT_SIO_AI16HB:
		m_rdoInterruptMask.EnableWindow(1);
		GetDlgItem(IDC_RADIO_FIFOHALFFULL)->EnableWindow(1);
		break;
	case AXT_SIO_RAI8RB:
		m_rdoInterruptMask.EnableWindow(0);
		GetDlgItem(IDC_RADIO_FIFOHALFFULL)->EnableWindow(0);
		break;
	}
*/
	AxaInfoGetInputCount(lModuleNo, &lChannel_Count);
	
	for (int i = 0; i < lChannel_Count; i++)
	{
		strChannel.Format("%02d    %02d      %02Xh   #%02d", lBoardNo, lModuleNo, dwModuleID, i);		
		m_cboChannel.AddString(strChannel);
		ChannelInfo *m_pChannelInfo = m_pChannelList->GetFindChannel(m_cboModuleInfo.GetCurSel(), i);
		m_cboChannel.SetCheck(m_pChannelInfo->IChannelNum, m_pChannelInfo->BChannelChk);
	}
}

void CAI_TESTDlg::InitControl()
{
	// Voltage Range
	m_cboVRange.AddString("-10 ~ 10");

	m_cboVRange.SetCurSel(0);

	// Init Data length, Sample rate EditBox / Spin
	m_edtLength.SetWindowText("1000");
	m_spnLength.SetRange32(10, 10000);

	//A list part
	m_lstAIChannel.SetExtendedStyle(m_lstAIChannel.GetExtendedStyle() | LVS_EX_FULLROWSELECT | LVS_EX_GRIDLINES);
	m_lstAIChannel.InsertColumn(0, "No.", LVCFMT_LEFT, 70);

	LV_ITEM	lvItem;
	CString	strValue;
	lvItem.iItem	= m_lstAIChannel.GetItemCount();
	lvItem.mask		= LVIF_TEXT | LVIF_STATE;
	lvItem.iSubItem	= 0;
	lvItem.iImage	= -1;
	lvItem.stateMask= 0;
	lvItem.state	= 0;
	strValue.Format("%04d", 0 + 1);
	lvItem.pszText	= (LPSTR)(LPCTSTR)strValue;
}

void CAI_TESTDlg::OnDestroy() 
{
	CDialog::OnDestroy();

	// Tread End
	g_bGetDataThreadFlag	= FALSE;
	pGetThread				= NULL;

	for(int i=0; i < m_pChannelList->m_ModuleInfoList.GetSize(); i++)
	{
		pModuleInfo	m_pModuleInfo = m_pChannelList->m_ModuleInfoList.GetAt(i);
	
		ChannelInfo* channelInfo = m_pModuleInfo->channelInfo;

		delete channelInfo;
		channelInfo = NULL;
		delete m_pModuleInfo;
		m_pModuleInfo = NULL;
	}
	m_pChannelList->m_ModuleInfoList.RemoveAll();

	if(BpStart != NULL)
		delete[] BpStart;

	if(m_BChannelAll != NULL)
		delete[] m_BChannelAll;

	if(dpVolt != NULL)
		delete[] dpVolt;

	if(m_pChannelList != NULL)
		delete m_pChannelList;
	
	Sleep(1);
	CloseDevice();
}

void CAI_TESTDlg::OnChannelOnOff() 
{
	if(m_BChannelAll[m_cboModuleInfo.GetCurSel()] == TRUE)
	{
		m_cboChannel.SelectAll(FALSE);
		m_BChannelAll[m_cboModuleInfo.GetCurSel()] = FALSE;
	}
	else
	{
		m_cboChannel.SelectAll(TRUE);
		m_BChannelAll[m_cboModuleInfo.GetCurSel()] = TRUE;
	}
}

double  pdCBuffer[64][32768];
double  *pdBuffer[64];
double	BufferData[16][1000];
BOOL	bFirstPlay = FALSE;

UINT ThreadGetData (LPVOID pParam) 
{
	// Data store mode.
	CAI_TESTDlg* pDlg = (CAI_TESTDlg*)pParam;

	CString strValue, bin, str;
	long	pnCHNum[16] = {0};
	long	pwSize[16] = {0};
	long	wCount = 0;
	int		nRow = 0, nLine = 0, nCount = 0;

	float	maxVal=10, minVal=-10;
	
	while (g_bGetDataThreadFlag)
	{
		if(g_GetDelay>0)
			Sleep (g_GetDelay);
		double	dVolt;
		if (nLine == pDlg->nLength)
		{
			nLine = 0;
		}

		if (nCount < pDlg->nLength)
			pDlg->AddDataIndex(nCount);

		
		for (int i = 0; i < pDlg->m_cboChannel.GetCount(); i++)
		{
					
			if (pDlg->m_cboChannel.GetCheck(i) == TRUE)
			{
			
				AxaiSwReadVoltage(i, &dVolt);

				strValue.Format("%lf", dVolt);

				if (nLine < pDlg->nLength)
				{
					pDlg->m_lstAIChannel.SetItemText(nLine, nRow + 1, strValue);
					pDlg->m_lstAIChannel.SetItemText(nLine, nRow + 1, strValue);
				}
				nRow++;
			}
			
		}
		nRow = 0;
		nLine++;
		nCount++;
		
		if(nLine == pDlg->nLength)
		{
			pDlg->BpStart[pDlg->m_cboModuleInfo.GetCurSel()] = pDlg->BpStart[pDlg->m_cboModuleInfo.GetCurSel()];
			pDlg->OnButtonStart();
			
			pGetThread = NULL;
			return 0 ;
		}
	}

	pGetThread = NULL;

	return 0 ;
}

void CAI_TESTDlg::OnButtonStart() 
{
	if(!BpStart[m_cboModuleInfo.GetCurSel()] == FALSE)
	{
		
		// Tread End
		g_bGetDataThreadFlag	= FALSE;
		pGetThread				= NULL;
		
		if (m_rdoTriggerNum == 1)
		{
			CString strValue;
			int nRow = 0;

			m_lstAIChannel.DeleteAllItems();
			int j;
			for(j=0; j<1000; j++)
				AddDataIndex((short)j);

			for(int i=0; i<nChNum; i++)
			{
				int nLine = 0;
				
				for(j=0; j<1000; j++)
				{
					strValue.Format("%10.6lf", BufferData[i][j]);
					
					m_lstAIChannel.SetItemText(nLine, nRow + 1, strValue);
					
					nLine++;
				}
				nRow++;
			}
		}
	
		nChNum = 0;
		Sleep(1);
		
		m_btnStart.SetWindowText("START(S)");
		BpStart[m_cboModuleInfo.GetCurSel()] = FALSE;
	}
	else
	{
		// The case to become START
		CString strLength;
		CString strRate;
	
		int		nBufferSize;
		long	lChannelCounts;
		long	lModuleNo;
		long	pwSize[NUM_CHANNEL] = {0};
		double	maxVal=10, minVal=-10;
		int		i;
		m_lstAIChannel.DeleteAllItems();
		
		m_edtLength.GetWindowText(strLength);
		
		//nUpperLimit		= atoi(strLength);
		nLength		= atoi(strLength);		// Data length
		nBufferSize = nLength *2;

		CString m_strDataMax;
		CString m_strDataMin;
		int		IDataMax;

		IDataMax	= atoi(m_strDataMax);

		if (nLength < 1)
			nLength = 1;
		else if (nLength > 50000)
			nLength = 50000;
		
		if (nTimer < 1)
			nTimer = 1;
		else if (nTimer > 100000)
			nTimer = 100000;
		
		strLength.Format("%d", nLength);
		strRate.Format("%d", nTimer);
		
		m_edtLength.SetWindowText(strLength);
			
		m_pChannelList->GetFindModuleNo(m_cboModuleInfo.GetCurSel(), &lModuleNo);		
		AxaInfoGetInputCount(lModuleNo, &lChannelCounts);

		for (i = 0; i < lChannelCounts; i++)
		{
			if (m_cboChannel.GetCheck(i) == TRUE)
			{
				pnCHList[nChNum]	= i;
				pwSize[nChNum]		= nLength;
				pdBuffer[nChNum]	= pdCBuffer[nChNum];
				AxaiHwSetLimit(i, atoi(m_strDataMin), atoi(m_strDataMax));		// Setting High limit
				AxaiSetRange(i, minVal, maxVal);								// Setting input volt range
				nChNum++;
			}
		}

		if (!nChNum)															// return if Channel appoint is lesser than one
			return;

		m_btnStart.SetWindowText("STOP(S)");
		BpStart[m_cboModuleInfo.GetCurSel()] = TRUE;

		// Thread Setting
		g_bGetDataThreadFlag	= TRUE;
		if (pGetThread == NULL)
			pGetThread	= AfxBeginThread(ThreadGetData, this, THREAD_PRIORITY_NORMAL, 0, 0, NULL);
	}
}

BOOL CAI_TESTDlg::AddDataIndex(short nIndex)
{
	LV_ITEM	lvItem;
	CString	strValue;

	//
	lvItem.iItem	= m_lstAIChannel.GetItemCount();
	lvItem.mask		= LVIF_TEXT | LVIF_STATE;
	lvItem.iSubItem	= 0;
	lvItem.iImage	= -1;
	lvItem.stateMask= 0;
	lvItem.state	= 0;
	strValue.Format("%04d", nIndex + 1);
	lvItem.pszText	= (LPSTR)(LPCTSTR)strValue;

	// New row registration
	int		nRet = m_lstAIChannel.InsertItem(&lvItem);

	return (nRet >= 0 ? TRUE : FALSE);
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

BOOL CAI_TESTDlg::CloseDevice()
{
	if (AxlIsOpened())
	{
		AxlClose();
		FreeAXL();
		FreeAXA();

		return	TRUE;
	}
	else
	{
		return	FALSE;
	}
}
