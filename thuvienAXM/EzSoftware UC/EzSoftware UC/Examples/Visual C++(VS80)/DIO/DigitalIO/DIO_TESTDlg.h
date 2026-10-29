// DIO_TESTDlg.h : header file
//

#if !defined(AFX_DIO_TESTDLG_H__A4642ABB_4B93_4E0E_8943_F10D3CFFBCF9__INCLUDED_)
#define AFX_DIO_TESTDLG_H__A4642ABB_4B93_4E0E_8943_F10D3CFFBCF9__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

/////////////////////////////////////////////////////////////////////////////
// CDIO_TESTDlg dialog


class CDIO_TESTDlg : public CDialog
{
// Construction
public:
	CDIO_TESTDlg(CWnd* pParent = NULL);	// standard constructor

	BOOL	CloseDevice();
	BOOL	OnModuleInfo(long	lModuleNo, short *InputCount);
	BOOL	ThreadData();
	BOOL	AXTInit();
	void	UpdateCheckEnable();
			
// Dialog Data
	//{{AFX_DATA(CDIO_TESTDlg)
	enum { IDD = IDD_DIO_TEST_DIALOG };
	CButton	m_radioMessage;
	CButton	m_chkRising;
	CListBox	m_listMessage;
	CButton	m_chkFalling;
	CButton	m_chkIntrrupt;
	CButton	m_stcLow;
	CButton	m_stcHigh;
	CComboBox	m_cboModuleInfo;
	//}}AFX_DATA

	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CDIO_TESTDlg)
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support
	//}}AFX_VIRTUAL

// Implementation

private:
	HANDLE		m_hHandle;
	HANDLE		m_hInterrupt;
	BOOL		m_bThread;

protected:
	HICON m_hIcon;
	CButton		*m_pchkHigh[16];
	CButton		*m_pchkLow[16];

	// Generated message map functions
	//{{AFX_MSG(CDIO_TESTDlg)
	virtual BOOL OnInitDialog();
	afx_msg void OnSysCommand(UINT nID, LPARAM lParam);
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	afx_msg void OnSelchangeCombo();
	afx_msg void OnCheckIntrrupt();
	afx_msg void OnCheckRising();
	afx_msg void OnCheckFalling();
	afx_msg void OnListClear();
	afx_msg void OnDestroy();
	afx_msg void OnTimer(UINT_PTR nIDEvent);
	afx_msg void OnRadioMessage();
	afx_msg void OnRadioCallback();
	afx_msg void OnRadioEvent();
	afx_msg void OnButtonExit();
	//}}AFX_MSG
	afx_msg void OnClickHigh(UINT nID);
	afx_msg void OnClickLow(UINT nID);
	afx_msg LRESULT OnInterruptMessage(WPARAM wParam, LPARAM lParam);
	//afx_msg LRESULT OnDIOInterruptCallback(long nModuleNo, DWORD uFlag);
	
	DECLARE_MESSAGE_MAP()
};

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_DIO_TESTDLG_H__A4642ABB_4B93_4E0E_8943_F10D3CFFBCF9__INCLUDED_)
