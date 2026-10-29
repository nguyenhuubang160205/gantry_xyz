// AO_TESTDlg.h : header file
//

#include "ChannelArray.h"
#if !defined(AFX_AO_TESTDLG_H__CAFCF29A_D98A_4E3D_A68A_9DD93AD1D85B__INCLUDED_)
#define AFX_AO_TESTDLG_H__CAFCF29A_D98A_4E3D_A68A_9DD93AD1D85B__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

/////////////////////////////////////////////////////////////////////////////
// CAO_TESTDlg dialog

class CAO_TESTDlg : public CDialog
{
// Construction
public:
	BOOL CloseDevice();
	BOOL AddData(short nIndex);
	void InitControl();
	BOOL OpenDevice();
	CAO_TESTDlg(CWnd* pParent = NULL);			// standard constructor
	BOOL					*BpStart;			// A module start stopping
	CChannelArray			*m_pChannelList;
	int						*IpIndex;
	int						IChannelChk;		// Channel check number
// Dialog Data
	//{{AFX_DATA(CAO_TESTDlg)
	enum { IDD = IDD_AO_TEST_DIALOG };
	CButton	m_btnStart;
	CSpinButtonCtrl	m_spnVoltage;
	CEdit	m_edtVoltage;
	CSpinButtonCtrl	m_spnPeriod;
	CEdit	m_edtPeriod;
	CComboBox	m_cboGap;
	CComboBox	m_cboVRange;
	CComboBox	m_cboWave;
	CListCtrl	m_lstAOChannel;
	CComboBox	m_cboModuleInfo;
	//}}AFX_DATA

	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CAO_TESTDlg)
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support
	//}}AFX_VIRTUAL

// Implementation
protected:
	HICON m_hIcon;

	// Generated message map functions
	//{{AFX_MSG(CAO_TESTDlg)
	virtual BOOL OnInitDialog();
	afx_msg void OnSysCommand(UINT nID, LPARAM lParam);
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	afx_msg void OnDestroy();
	afx_msg void OnSelchangeCOMBOModule();
	afx_msg void OnItemchangedListAochannel(NMHDR* pNMHDR, LRESULT* pResult);
	afx_msg void OnSelchangeComboWave();
	afx_msg void OnChangeEditPeriod();
	afx_msg void OnSelchangeComboVrange();
	afx_msg void OnSelchangeComboGap();
	afx_msg void OnChangeEditVoltage();
	afx_msg void OnButtonStart();
	afx_msg void OnTimer(UINT_PTR nIDEvent);
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_AO_TESTDLG_H__CAFCF29A_D98A_4E3D_A68A_9DD93AD1D85B__INCLUDED_)
