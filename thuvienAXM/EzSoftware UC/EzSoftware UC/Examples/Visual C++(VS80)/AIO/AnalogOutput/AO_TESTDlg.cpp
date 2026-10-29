// AO_TESTDlg.cpp : implementation file
//

#include "stdafx.h"
#include "AO_TEST.h"
#include "AO_TESTDlg.h"
#include "ChannelArray.h"
#include "math.h"

#include "CJHyperLink.h"
#include "RegistryValue.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CAboutDlg dialog used for App About

#ifdef _M_X64
	#pragma comment(lib, "../../../../AXL(Library)/Library/64Bit/AxL.lib")
#else
	#pragma comment(lib, "../../../../AXL(Library)/Library/32Bit/AxL.lib")
#endif

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
// CAO_TESTDlg dialog

CAO_TESTDlg::CAO_TESTDlg(CWnd* pParent /*=NULL*/)
	: CDialog(CAO_TESTDlg::IDD, pParent)
{
	//{{AFX_DATA_INIT(CAO_TESTDlg)
		// NOTE: the ClassWizard will add member initialization here
	//}}AFX_DATA_INIT
	// Note that LoadIcon does not require a subsequent DestroyIcon in Win32
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
	IpIndex			= NULL;
	m_pChannelList	= NULL;
	BpStart			= NULL;
}

void CAO_TESTDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CAO_TESTDlg)
	DDX_Control(pDX, IDC_BUTTON_START, m_btnStart);
	DDX_Control(pDX, IDC_SPIN_VOLTAGE, m_spnVoltage);
	DDX_Control(pDX, IDC_EDIT_VOLTAGE, m_edtVoltage);
	DDX_Control(pDX, IDC_SPIN_PERIOD, m_spnPeriod);
	DDX_Control(pDX, IDC_EDIT_PERIOD, m_edtPeriod);
	DDX_Control(pDX, IDC_COMBO_GAP, m_cboGap);
	DDX_Control(pDX, IDC_COMBO_VRANGE, m_cboVRange);
	DDX_Control(pDX, IDC_COMBO_WAVE, m_cboWave);
	DDX_Control(pDX, IDC_LIST_AOCHANNEL, m_lstAOChannel);
	DDX_Control(pDX, IDC_COMBO_Module, m_cboModuleInfo);
	//}}AFX_DATA_MAP
}

BEGIN_MESSAGE_MAP(CAO_TESTDlg, CDialog)
	//{{AFX_MSG_MAP(CAO_TESTDlg)
	ON_WM_SYSCOMMAND()
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	ON_WM_DESTROY()
	ON_CBN_SELCHANGE(IDC_COMBO_Module, OnSelchangeCOMBOModule)
	ON_NOTIFY(LVN_ITEMCHANGED, IDC_LIST_AOCHANNEL, OnItemchangedListAochannel)
	ON_CBN_SELCHANGE(IDC_COMBO_WAVE, OnSelchangeComboWave)
	ON_EN_CHANGE(IDC_EDIT_PERIOD, OnChangeEditPeriod)
	ON_CBN_SELCHANGE(IDC_COMBO_VRANGE, OnSelchangeComboVrange)
	ON_CBN_SELCHANGE(IDC_COMBO_GAP, OnSelchangeComboGap)
	ON_EN_CHANGE(IDC_EDIT_VOLTAGE, OnChangeEditVoltage)
	ON_BN_CLICKED(IDC_BUTTON_START, OnButtonStart)
	ON_WM_TIMER()
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CAO_TESTDlg message handlers

BOOL CAO_TESTDlg::OnInitDialog()
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
	
	if(OpenDevice())
	{
		InitControl();
		OnSelchangeCOMBOModule();
	}
	
	return TRUE;  // return TRUE  unless you set the focus to a control
}

void CAO_TESTDlg::OnSysCommand(UINT nID, LPARAM lParam)
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

void CAO_TESTDlg::OnPaint() 
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
HCURSOR CAO_TESTDlg::OnQueryDragIcon()
{
	return (HCURSOR) m_hIcon;
}

BOOL CAO_TESTDlg::OpenDevice()
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
			
			long	lOutputCounts;
			long	lBoardNo	= 0;
			long	lModulePos	= 0;
			DWORD	dwModuleID= 0;
			char	szModuleName[50] = "";

			// An execution existence by the module.
			BpStart = new BOOL[IModuleCounts];

			CString strData;
			for(int ModuleNo=0; ModuleNo < IModuleCounts; ModuleNo++)
			{
				// input, output channel grasp
				AxaInfoGetOutputCount(ModuleNo, &lOutputCounts);
				if(lOutputCounts > 0)
				{
					if(AxaInfoGetModule(ModuleNo, &lBoardNo, &lModulePos, &dwModuleID) == AXT_RT_SUCCESS)
					{
						pModuleInfo	m_pModuleInfo = new ModuleInfo;

						switch(dwModuleID)
						{
						case AXT_SIO_AO4RB:
							strData.Format("%d ¢Â %d ¢Â %s [Output : %d]", lBoardNo, ModuleNo, "SIO_AO4RB", lOutputCounts);
							break;
						case AXT_SIO_AO8H:
							strData.Format("%d ¢Â %d ¢Â %s [Output : %d]", lBoardNo, ModuleNo, "SIO_AO8H", lOutputCounts);
							break;
						case AXT_SIO_AO2HB:
							strData.Format("%d ¢Â %d ¢Â %s [Output : %d]", lBoardNo, ModuleNo, "SIO_AO2HB", lOutputCounts);
							break;
						case AXT_SIO_RAO4RB:
							strData.Format("%d ¢Â %d ¢Â %s [Output : %d]", lBoardNo, ModuleNo, "SIO_RAO4RB", lOutputCounts);
							break;
						case AXT_SIO_RAO2MLII:
							strData.Format("%d ¢Â %d ¢Â %s [Output : %d]", lBoardNo, ModuleNo, "SIO_RAO2MLII", lOutputCounts);
							break;
						case AXT_SIO_RAVO2MLII:
							strData.Format("%d ¢Â %d ¢Â %s [Output : %d]", lBoardNo, ModuleNo, "SIO_RAVO2MLII", lOutputCounts);
							break;
						case AXT_SIO_RACO2MLII:
							strData.Format("%d ¢Â %d ¢Â %s [Output : %d]", lBoardNo, ModuleNo, "SIO_RACO2MLII", lOutputCounts);
							break;
						case AXT_SIO_RAO08RTEX:
							strData.Format("%d ¢Â %d ¢Â %s [Output : %d]", lBoardNo, ModuleNo, "SIO_RAO08RTEX", lOutputCounts);
							break;
						case AXT_SIO_AO4F:
							strData.Format("%d ¢Â %d ¢Â %s [Output : %d]", lBoardNo, ModuleNo, "SIO_AO4F", lOutputCounts);
							break;
						case AXT_SIO_AI8F:
							strData.Format("%d ¢Â %d ¢Â SIO_AI8F [Output : %d]", lBoardNo, ModuleNo, lOutputCounts);
							break;
						case AXT_SIO_AI8AO4F:
							strData.Format("%d ¢Â %d ¢Â SIO_AI8A04F [Output : %d]", lBoardNo, ModuleNo, lOutputCounts);
							break;
						case AXT_ECAT_AIO:
							if(lOutputCounts > 0)
							{
								AxaInfoGetModuleEx(ModuleNo, NULL, szModuleName, NULL);
								strData.Format("%d ¢Â %d ¢Â %s [Output : %d]", lBoardNo, ModuleNo, szModuleName, lOutputCounts);
							}
							break;
						}
						m_cboModuleInfo.AddString(strData);

						ChannelInfo* channelInfo = new ChannelInfo[lOutputCounts];
						memset(channelInfo, NULL, sizeof(ChannelInfo)*lOutputCounts);

						for(int i=0; i < lOutputCounts; i++)
						{
							channelInfo[i].IChannelNum	=	i;		// Channel Num
							channelInfo[i].BChannelChk	=	0;		// Channel Check
							channelInfo[i].IWave		=	0;		// WaveType
							channelInfo[i].IPeriod		=	1000;	// Period
							channelInfo[i].IVRange		=	2;		// Volt range
							channelInfo[i].IGap			=	0;		// Interval
							channelInfo[i].IVoltage		=	0;		// Voltage							
						}			

						m_pModuleInfo->lModuleNum = ModuleNo;
						m_pModuleInfo->ICboNum = m_cboModuleInfo.GetCount()-1;
						m_pModuleInfo->IChannelCount = lOutputCounts;
						m_pModuleInfo->channelInfo = channelInfo;

						m_pChannelList->m_ModuleInfoList.Add(m_pModuleInfo);

						// A module execution initialization.
						BpStart[m_cboModuleInfo.GetCount()-1] = FALSE;
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

void CAO_TESTDlg::OnDestroy() 
{
	CDialog::OnDestroy();
	
	KillTimer(0);
	if(IpIndex) delete[] IpIndex;

	for(int i=0; i < m_pChannelList->m_ModuleInfoList.GetSize(); i++)
	{
		pModuleInfo	m_pModuleInfo = m_pChannelList->m_ModuleInfoList.GetAt(i);
		TRACE("CboNum :%d, ModuleNum : %d\n", m_pModuleInfo->ICboNum, m_pModuleInfo->lModuleNum);
		
		ChannelInfo* channelInfo = m_pModuleInfo->channelInfo;

		for(int k=0; k<m_pModuleInfo->IChannelCount; k++)
		{
			TRACE("ChannelNum :%d, ChannelChk : %d, WaveType : %d, Period : %d, Volt Range :%d, Interval : %d, Voltage : %d  \n", 
				channelInfo[k].IChannelNum, channelInfo[k].BChannelChk, channelInfo[k].IWave, channelInfo[k].IPeriod, 
				channelInfo[k].IVRange, channelInfo[k].IGap, channelInfo[k].IVoltage);
		}
		delete channelInfo;
		delete m_pModuleInfo;
	}
	m_pChannelList->m_ModuleInfoList.RemoveAll();
	if(m_pChannelList) delete m_pChannelList;
	if(BpStart) delete[] BpStart;

	// Library and Motion close
	CloseDevice();
}

void CAO_TESTDlg::OnSelchangeCOMBOModule() 
{
	long	lModuleNo;
	long	lChannel_Count = 0;

	m_lstAOChannel.DeleteAllItems();
	m_pChannelList->GetFindModuleNo(m_cboModuleInfo.GetCurSel(), &lModuleNo);
	
	AxaInfoGetOutputCount(lModuleNo, &lChannel_Count);

	for (int i = 0; i < lChannel_Count; i++)
	{
		AddData(i);
	}
}

void CAO_TESTDlg::InitControl()
{
	CString			strValue;

	// ListCtrl Init
	m_lstAOChannel.SetExtendedStyle(m_lstAOChannel.GetExtendedStyle() |
		LVS_EX_FULLROWSELECT | LVS_EX_GRIDLINES | LVS_EX_CHECKBOXES);
	
	m_lstAOChannel.SetHotItem(0);
	strValue.Format("%s","Channel No");
	m_lstAOChannel.InsertColumn(0, strValue, LVCFMT_CENTER, 80);
	strValue.Format("%s","Module No");
	m_lstAOChannel.InsertColumn(1, strValue, LVCFMT_CENTER, 74);
	strValue.Format("%s","Module ID");
	m_lstAOChannel.InsertColumn(2, strValue, LVCFMT_CENTER, 69);
	strValue.Format("%s","Wave");
	m_lstAOChannel.InsertColumn(3, strValue, LVCFMT_CENTER, 85);
	strValue.Format("%s","Periodic");
	m_lstAOChannel.InsertColumn(4, strValue, LVCFMT_CENTER, 68);
	strValue.Format("%s","Voltage range");
	m_lstAOChannel.InsertColumn(5, strValue, LVCFMT_CENTER, 90);
	strValue.Format("%s","Gap");
	m_lstAOChannel.InsertColumn(6, strValue, LVCFMT_CENTER, 40);
	strValue.Format("%s","Voltage");
	m_lstAOChannel.InsertColumn(7, strValue, LVCFMT_CENTER, 60);

	// ComboBox(Wave) Init
	strValue.Format("%s","Sine");
	m_cboWave.AddString(strValue);
	strValue.Format("%s","Triangle");
	m_cboWave.AddString(strValue);
	strValue.Format("%s","Rectangle");
	m_cboWave.AddString(strValue);
	strValue.Format("%s","Voltage");
	m_cboWave.AddString(strValue);
	m_cboWave.SetCurSel(0);

	// ComboBox(VRange) Init
	m_cboVRange.AddString("-10 ~ 10");
	m_cboVRange.SetCurSel(0);

	// EditBox&Spin Init
	m_edtPeriod.SetWindowText("1000");
	m_spnPeriod.SetRange(100, 1000);
	m_edtVoltage.SetWindowText("0");
	m_spnVoltage.SetRange(-10, 10);

	// ComboBox(Gap) Init
	m_cboGap.AddString("1");
	m_cboGap.AddString("5");
	m_cboGap.AddString("10");
	m_cboGap.AddString("20");
	m_cboGap.AddString("50");
	m_cboGap.AddString("100");
	m_cboGap.SetCurSel(0);

	m_cboWave.EnableWindow(FALSE);
	m_edtPeriod.EnableWindow(FALSE);
	m_spnPeriod.EnableWindow(FALSE);
	m_cboVRange.EnableWindow(FALSE);
	m_edtVoltage.EnableWindow(FALSE);
	m_edtVoltage.EnableWindow(FALSE);
	m_spnVoltage.EnableWindow(FALSE);
}

BOOL CAO_TESTDlg::AddData(short nIndex)
{
	LV_ITEM			lvItem;
	CString			strValue;
	long			lValue;

	//
	lvItem.iItem	= m_lstAOChannel.GetItemCount();
	lvItem.mask		= LVIF_TEXT | LVIF_IMAGE | LVIF_STATE;
	lvItem.iSubItem	= 0;
	lvItem.iImage	= -1;
	lvItem.stateMask= 0;
	lvItem.state	= 0;
	//strValue.Format("%02d", nIndex + 1);
	strValue.Format("%02d", nIndex);
	lvItem.pszText	= (LPSTR)(LPCTSTR)strValue;

	// New row registration
	int nRet = m_lstAOChannel.InsertItem(&lvItem);

	AxaoInfoGetModuleNoOfChannelNo(nIndex, &lValue);
	
	// Module No.
	strValue.Format("%02d", lValue);
	m_lstAOChannel.SetItemText(lvItem.iItem, 1, strValue);

	// Module ID
	long	lBoardID, lModulePos;
	DWORD	dwModuleID;

	AxaInfoGetModule(lValue, &lBoardID, &lModulePos, &dwModuleID);
	strValue.Format("%02Xh", dwModuleID);
	m_lstAOChannel.SetItemText(lvItem.iItem, 2, strValue);
	strValue.Format("%s", "Sine");
	m_lstAOChannel.SetItemText(lvItem.iItem, 3, strValue);
	m_lstAOChannel.SetItemText(lvItem.iItem, 4, "1000");
	m_lstAOChannel.SetItemText(lvItem.iItem, 5, " -10 ~ 10");
	m_lstAOChannel.SetItemText(lvItem.iItem, 6, "1");
	m_lstAOChannel.SetItemText(lvItem.iItem, 7, "0");

	//m_lstAOChannel.SetCheck(nIndex, TRUE);
	return (nRet >= 0 ? TRUE : FALSE);
}

void CAO_TESTDlg::OnItemchangedListAochannel(NMHDR* pNMHDR, LRESULT* pResult) 
{
	NM_LISTVIEW* pNMListView = (NM_LISTVIEW*)pNMHDR;
	
	ChannelInfo *m_pChannelInfo;
	m_pChannelInfo = m_pChannelList->GetFindChannel(m_cboModuleInfo.GetCurSel(), pNMListView->iItem);
	m_pChannelInfo->BChannelChk = m_lstAOChannel.GetCheck(pNMListView->iItem);

	if(m_lstAOChannel.GetCheck(pNMListView->iItem) == TRUE)
	{
		// The processing in the case which the channel was selected
		CString strValue;

		// channel store to be checked
		IChannelChk = pNMListView->iItem;

		m_cboWave.EnableWindow(TRUE);
		m_edtPeriod.EnableWindow(TRUE);
		m_spnPeriod.EnableWindow(TRUE);
		m_cboVRange.EnableWindow(TRUE);
		m_cboGap.EnableWindow(TRUE);
		m_edtVoltage.EnableWindow(TRUE);

		// Input WaveType
		m_cboWave.SetCurSel(m_pChannelInfo->IWave);

		// Input Period
		strValue.Format("%d",m_pChannelInfo->IPeriod);
		m_edtPeriod.SetWindowText(strValue);

		// Input Volt range
		m_cboVRange.SetCurSel(m_pChannelInfo->IVRange);

		// Interval
		m_cboGap.SetCurSel(m_pChannelInfo->IGap);
		
		// A channel timer action which in the case is checked which does START
		if(!BpStart[m_cboModuleInfo.GetCurSel()] == FALSE) 
		{
			m_cboGap.GetWindowText(strValue);
			if (m_pChannelInfo->IWave != 2)
				SetTimer(pNMListView->iItem, atoi(strValue), NULL);
			else	// The execution in a Rectangle wave case without Gap senior.
				SetTimer(pNMListView->iItem, 0, NULL);	
		}
		
		OnSelchangeComboWave();
	}
	else
	{
		m_cboWave.EnableWindow(FALSE);
		m_edtPeriod.EnableWindow(FALSE);
		m_spnPeriod.EnableWindow(FALSE);
		m_cboVRange.EnableWindow(FALSE);
		m_cboGap.EnableWindow(FALSE);
		m_edtVoltage.EnableWindow(FALSE);

		// A channel timer quit which in the case the collation is canceled which does START
		if(!BpStart[m_cboModuleInfo.GetCurSel()] == FALSE) 
		{
			KillTimer(pNMListView->iItem);
		}
	}

	*pResult = 0;
}

// do WaveType change.
void CAO_TESTDlg::OnSelchangeComboWave() 
{
	short		nItem;
	CString		strValue;

	// output at WaveType information that listcontrol
	m_cboWave.GetWindowText(strValue);
	nItem = IChannelChk;
	m_lstAOChannel.SetItemText(nItem, 3, strValue);

	// WaveType information that channel Array store.
	ChannelInfo *m_pChannelInfo;
	m_pChannelInfo = m_pChannelList->GetFindChannel(m_cboModuleInfo.GetCurSel(), nItem);
	m_pChannelInfo->IWave = m_cboWave.GetCurSel();

	switch (m_cboWave.GetCurSel())
	{
	case 0:		// Sin wave
		m_edtPeriod.EnableWindow(TRUE);
		m_spnPeriod.EnableWindow(TRUE);
		m_edtVoltage.EnableWindow(FALSE);
		m_spnVoltage.EnableWindow(FALSE);
	
		OnSelchangeComboVrange();
		break;
	case 1:		// Triangle wave
		m_edtPeriod.EnableWindow(TRUE);
		m_spnPeriod.EnableWindow(TRUE);
		m_edtVoltage.EnableWindow(FALSE);
		m_spnVoltage.EnableWindow(FALSE);
	
		OnSelchangeComboVrange();
		break;
	case 2:		// Rectangle wave
		m_edtPeriod.EnableWindow(TRUE);
		m_spnPeriod.EnableWindow(TRUE);
		m_edtVoltage.EnableWindow(FALSE);
		m_spnVoltage.EnableWindow(FALSE);
	
		// processing when do START.
		// The execution in a Rectangle wave case without Gap(Sampling interval) senior.
		if(!BpStart[m_cboModuleInfo.GetCurSel()] == FALSE) 
		{
			// execution again after a timer stopping which is the progress.
			KillTimer(nItem);
			
			SetTimer(nItem, 0, NULL);
		}

		OnSelchangeComboVrange();
		break;
	case 3:		// Voltage
		m_edtPeriod.EnableWindow(FALSE);
		m_spnPeriod.EnableWindow(FALSE);
		m_edtVoltage.EnableWindow(TRUE);
		m_spnVoltage.EnableWindow(TRUE);
		
		OnChangeEditVoltage();
		break;
	}
}

// do Period change.
void CAO_TESTDlg::OnChangeEditPeriod() 
{
	if (m_edtPeriod)
	{
		short		nItem;
		CString		strValue;
		CString		m_Gap;
		
		nItem = IChannelChk;
		m_edtPeriod.GetWindowText(strValue);

		// An exception processing when we call at the same time with a program execution.
		if (!atoi(strValue) || nItem < 0)
			return;
		
		if(atoi(strValue) < 100)
			strValue = "100";

		if(atoi(strValue) > 1000)
			strValue = "1000";

		m_edtPeriod.SetWindowText(strValue);

		ChannelInfo *m_pChannelInfo;
		m_pChannelInfo = m_pChannelList->GetFindChannel(m_cboModuleInfo.GetCurSel(), nItem);

		m_cboGap.GetWindowText(m_Gap);

		// Sin wave, Triangle wave exception processing
		if(m_pChannelInfo->IPeriod / atoi(m_Gap) == 1 || m_pChannelInfo->IPeriod / atoi(m_Gap) == 2)
		{
			m_pChannelInfo->IGap = 0;
			m_cboGap.SetCurSel(0);
			m_lstAOChannel.SetItemText(nItem, 6, "1");
		}
		
		// Output at a cycle information listcontrol
		m_lstAOChannel.SetItemText(nItem, 4, strValue);

		// A cycle information that channel Array store.
		m_pChannelInfo->IPeriod = atoi(strValue);
	}
}

// do Wave range change.
void CAO_TESTDlg::OnSelchangeComboVrange() 
{
	short		nItem;
	CString		strValue;

	// Output at wave range information listcontrol
	m_cboVRange.GetWindowText(strValue);
	nItem = IChannelChk;
	m_lstAOChannel.SetItemText(nItem, 5, strValue);

	// Wave range information that channel Array store.
	ChannelInfo *m_pChannelInfo;
	m_pChannelInfo = m_pChannelList->GetFindChannel(m_cboModuleInfo.GetCurSel(), nItem);
	m_pChannelInfo->IVRange = m_cboVRange.GetCurSel();
}

// do interval change.
void CAO_TESTDlg::OnSelchangeComboGap() 
{
	short		nItem;
	CString		strValue;

	// Output at interval information listcontrol
	m_cboGap.GetWindowText(strValue);
	nItem = IChannelChk;
	m_lstAOChannel.SetItemText(nItem, 6, strValue);

	// Interval information that channel Array store.
	ChannelInfo *m_pChannelInfo;
	m_pChannelInfo = m_pChannelList->GetFindChannel(m_cboModuleInfo.GetCurSel(), nItem);
	m_pChannelInfo->IGap = m_cboGap.GetCurSel();

	// Sin wave, Triangle wave exception processing
	if(m_pChannelInfo->IPeriod / atoi(strValue) == 1 || m_pChannelInfo->IPeriod / atoi(strValue) == 2)
	{
		m_pChannelInfo->IGap = 0;
		m_cboGap.SetCurSel(0);
		m_lstAOChannel.SetItemText(nItem, 6, "1");
		m_cboGap.GetWindowText(strValue);
	}
	
	// processing when do START.
	if(!BpStart[m_cboModuleInfo.GetCurSel()] == FALSE && m_cboWave.GetCurSel() != 2) 
	{
		// execution again after a timer stopping which is the progress.
		KillTimer(nItem);
		SetTimer(nItem, atoi(strValue), NULL);
	}
}

// do voltage change.
void CAO_TESTDlg::OnChangeEditVoltage() 
{
	if (m_edtVoltage && m_cboWave.GetCurSel() == 3)
	{
		short		nItem;
		CString		strValue;

		m_edtVoltage.GetWindowText(strValue);

		// An exception processing when we call at the same time with a program execution.
		if (!atof(strValue))
			return;

		if(atoi(strValue) < -10)
			strValue = "-10";

		if(atoi(strValue) > 10)
			strValue = "10";

		m_edtVoltage.SetWindowText(strValue);

		// Output at a cycle information listcontrol
		nItem = IChannelChk;
		m_lstAOChannel.SetItemText(nItem, 7, strValue);

		// An exception processing when we call at the same time with a program execution.
		if (nItem < 0)
			return;

		// A cycle information that channel Array store.
		ChannelInfo *m_pChannelInfo;
		m_pChannelInfo = m_pChannelList->GetFindChannel(m_cboModuleInfo.GetCurSel(), nItem);
		m_pChannelInfo->IVoltage = atoi(strValue);
	}
}

void CAO_TESTDlg::OnButtonStart() 
{
	int i;
	ChannelInfo	*m_pChannelInfo;		// Channel information

	if(!BpStart[m_cboModuleInfo.GetCurSel()] == FALSE)
	{
		// processing when do STOP.
		for (i = 0; i < m_lstAOChannel.GetItemCount(); i++)
		{
			m_pChannelInfo = m_pChannelList->GetFindChannel(m_cboModuleInfo.GetCurSel(), i);
			
			if(m_pChannelInfo->BChannelChk == TRUE)
			{
				// Channel timer termination to be checked.
				KillTimer(i);
			}
		}

		m_btnStart.SetWindowText("START(S)");
		BpStart[m_cboModuleInfo.GetCurSel()] = FALSE;
		if(IpIndex) 
		{
			delete[] IpIndex;
			IpIndex = NULL;
		}
	}
	else
	{
		// processing when do START.
		int nChNum = 0;
		CString strValue;
		
		for (i = 0; i < m_lstAOChannel.GetItemCount(); i++)
		{
			m_pChannelInfo = m_pChannelList->GetFindChannel(m_cboModuleInfo.GetCurSel(), i);
			
			if(m_pChannelInfo->BChannelChk == TRUE)
			{
				nChNum++;
			}
		}
		
		if (!nChNum)		// Channel appoint is lesser than one, return
			return;

		IpIndex = new int[m_lstAOChannel.GetItemCount()];
		memset(IpIndex, NULL, sizeof(int)*m_lstAOChannel.GetItemCount());
			
		for(i=0; i<m_lstAOChannel.GetItemCount(); i++)
		{
			m_pChannelInfo = m_pChannelList->GetFindChannel(m_cboModuleInfo.GetCurSel(), i);	
			
			if(m_pChannelInfo->BChannelChk == TRUE)
			{
				m_cboGap.GetLBText(m_pChannelInfo->IGap, strValue);
			
				if (m_pChannelInfo->IWave != 2)
					SetTimer(i, atoi(strValue), NULL);
				else	// The execution in a Rectangle wave case without Gap senior.
					SetTimer(i, 0, NULL);
			}
		}

		m_btnStart.SetWindowText("STOP(S)");
		BpStart[m_cboModuleInfo.GetCurSel()] = TRUE;		
	}
}

void CAO_TESTDlg::OnTimer(UINT_PTR nIDEvent) 
{
	CAO_TESTDlg* pDlg = (CAO_TESTDlg*)AfxGetApp ()->GetMainWnd ();

	double		maxVal, minVal;
	CString		strValue;
	double		dValue;
	int			IGap;
	CString		m_Gap;

	ChannelInfo	*m_pChannelInfo;		// Channel information
	m_pChannelInfo = pDlg->m_pChannelList->GetFindChannel(pDlg->m_cboModuleInfo.GetCurSel(), nIDEvent);
	
	if(m_pChannelInfo->BChannelChk == TRUE)	
	{
		// The case which that channel is checked
		switch (m_pChannelInfo->IVRange)
		{
		case 0:
			maxVal = 10.0;
			minVal = -10.0;
			break;
		}
		
		m_cboGap.GetLBText(m_pChannelInfo->IGap, m_Gap);
		IGap = atoi(m_Gap);
		
		switch(m_pChannelInfo->IWave)				
		{
		case 0:		// Sin wave
			// Interval
			if ( (double) IpIndex[nIDEvent] >=  (double)m_pChannelInfo->IPeriod / (double)IGap)
				IpIndex[nIDEvent]	= 0;
			else
			{
				IpIndex[nIDEvent]++;
			}
			
			dValue	= (double)sin(((double)IpIndex[nIDEvent] * 3.141592  * 2) / ( (double)m_pChannelInfo->IPeriod / (double)IGap)) * maxVal;
			
			AxaoWriteVoltage(nIDEvent, dValue);
			TRACE("%f\n", dValue);
			break;
			
		case 1:		// Triangle wave
			// Interval
			if ( (double) IpIndex[nIDEvent] >=  (double)m_pChannelInfo->IPeriod / (double)IGap)
				IpIndex[nIDEvent]	= 0;
			else
			{
				IpIndex[nIDEvent]++;
			}

			// under the rise which the interval is big than 0 (case which the interval is 100 0 ~ 24)
			if ((double)IpIndex[nIDEvent] < (double)m_pChannelInfo->IPeriod / (4.0 * (double)IGap))
				dValue	= maxVal / ((double)m_pChannelInfo->IPeriod / (4.0 * (double)IGap)) * (double)IpIndex[nIDEvent];
			
			
			// under the falling which the interval (case which the interval is 100 25 ~ 74)
			else if ((double)IpIndex[nIDEvent] < (((double)m_pChannelInfo->IPeriod / (4.0 * (double)IGap)) * 3))
				dValue	= (double)-((maxVal / ((double)m_pChannelInfo->IPeriod / (4.0 * (double)IGap))) * (double)IpIndex[nIDEvent]) + maxVal * 2.0;
			
			// under the rise which the interval is small than 0 (case which the interval is 100 75 ~ 99)
			else
				dValue	= (double)((maxVal / ((double)m_pChannelInfo->IPeriod / (4.0 * (double)IGap))) * (double)IpIndex[nIDEvent]) - maxVal * 4.0;
			
			AxaoWriteVoltage(nIDEvent, dValue);
			break;
			
		case 2:		// Rectangle wave
			// Interval
			if ( (double) IpIndex[nIDEvent] >=  (double)m_pChannelInfo->IPeriod)
				IpIndex[nIDEvent]	= 0;
			else
				IpIndex[nIDEvent]++;
			
			// under the rise which the interval (case which the interval is 100 0 ~ 49)
			if ((double)IpIndex[nIDEvent] < (double)m_pChannelInfo->IPeriod / 2.0)
				dValue	= maxVal ;
			
			// under the falling which the interval (case which the interval is 100 50 ~ 99)
			else
				dValue	= -maxVal ;
			
			AxaoWriteVoltage(nIDEvent, dValue);
			break;
			
		case 3:		// Voltage
			m_edtVoltage.GetWindowText(strValue);
			AxaoWriteVoltage(nIDEvent, atof(strValue));
			break;
		}
	}
	
	CDialog::OnTimer(nIDEvent);
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

BOOL CAO_TESTDlg::CloseDevice()
{
	if (AxlIsOpened())
	{
		AxlClose();

		return	TRUE;
	}
	else
	{
		return	FALSE;
	}
}
