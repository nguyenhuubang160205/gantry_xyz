// AI_TESTDlg.h : header file
//

#include "CheckComboBox.h"
#include "ChannelArray.h"

#if !defined(AFX_AI_TESTDLG_H__A2E31267_8276_45C0_925D_0E60F2879F42__INCLUDED_)
#define AFX_AI_TESTDLG_H__A2E31267_8276_45C0_925D_0E60F2879F42__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

/////////////////////////////////////////////////////////////////////////////
// CAI_TESTDlg dialog


class CAI_TESTDlg : public CDialog
{
// Construction
public:
	BOOL CloseDevice();
	LRESULT OnInterruptMessage(WPARAM wParam, LPARAM lParam);
	BOOL AddDataIndex(short nIndex);
	void InitControl();
	BOOL OpenDevice();
	CAI_TESTDlg(CWnd* pParent = NULL);	// standard constructor
	CButton						*m_pchkHigh;
	CChannelArray				*m_pChannelList;
	BOOL						*BpStart;			// A module start stopping
	int							nTimer ;			// Timer rate
	int							nLength;			// Data length
	long						pnCHList[16];		// Channel list
	long						nChNum;
	double						m_dMaxValue;
	double						m_dMinValue;
	double						*dpVolt;

	afx_msg void OnButtonStart();
// Dialog Data
	//{{AFX_DATA(CAI_TESTDlg)
	enum { IDD = IDD_AI_TEST_DIALOG };
	CListCtrl	m_lstAIChannel;
	CEdit	m_edtLength;
	CSpinButtonCtrl	m_spnLength;
	CButton	m_btnStart;
	CComboBox	m_cboVRange;
	CCheckComboBox	m_cboChannel;
	CComboBox	m_cboModuleInfo;
	//}}AFX_DATA

	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CAI_TESTDlg)
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support
	//}}AFX_VIRTUAL

// Implementation
protected:
	HICON m_hIcon;
	BOOL  *m_BChannelAll;
	
	// Generated message map functions
	//{{AFX_MSG(CAI_TESTDlg)
	virtual BOOL OnInitDialog();
	afx_msg void OnSysCommand(UINT nID, LPARAM lParam);
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	afx_msg void OnSelchangeCOMBOModule();
	afx_msg void OnDestroy();
	afx_msg void OnChannelOnOff();
	afx_msg void OnRadioExternal();
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_AI_TESTDLG_H__A2E31267_8276_45C0_925D_0E60F2879F42__INCLUDED_)
