// OutputWriteMultiDlg.h : header file
//

#if !defined(AFX_OUTPUTWRITEMULTIDLG_H__E8AC939D_975B_4351_8DB6_DE2BD27A6D08__INCLUDED_)
#define AFX_OUTPUTWRITEMULTIDLG_H__E8AC939D_975B_4351_8DB6_DE2BD27A6D08__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

/////////////////////////////////////////////////////////////////////////////
// COutputWriteMultiDlg dialog

class COutputWriteMultiDlg : public CDialog
{
// Customize area
public:
	DWORD			m_dwModuleID;			// 모델ID
	long			m_lModuleNo;			// 제어할 모듈 번호
	long			m_lModuleCount;			// 유효한 전체 모듈 수
	long			m_lChannelCount;		// 유효한 전체 채널 수
	double			m_dOldVoltArr[4];		// OnTimer에서 사용할 이전 Volt
	
public:
	BOOL		InitLibrary();				// 라이브러리 초기화 작업을 수행합니다.
	BOOL		InitControl();				// Control 변수들을 등록하고, 초기 설정값들을 설정하는 함수.
	BOOL		AddModuleChannelInfo();		// 검색된 모듈과 채널 정보를 ComboBox에 등록/Control들을 초기화합니다.
	BOOL		UpdateState();				// AIO모듈의 상태와 Control들의 상태를 일치시킵니다.
	
	DWORD		ConvertComboToAxa(CComboBox *pCboItem);						// ComboBox콘트롤에 현재 선택된 Item Index를 AIO모듈에 설정할 값으로 변경하는 함수.	
	long		ConvertAxaToCombo(CComboBox *pCboItem, DWORD dwCurData);	// 설정값과 ComboBox콘트롤의 Item과 일치하는 Item을 찾아 선택하는 함수.	
	
	void		UpdateVoltageRange();

// Construction
public:
	COutputWriteMultiDlg(CWnd* pParent = NULL);	// standard constructor

// Dialog Data
	//{{AFX_DATA(COutputWriteMultiDlg)
	enum { IDD = IDD_OUTPUTWRITEMULTI_DIALOG };
	CEdit	m_stcOutVoltCh03;
	CEdit	m_stcOutVoltCh02;
	CEdit	m_stcOutVoltCh01;
	CEdit	m_stcOutVoltCh00;
	CSliderCtrl	m_sliSetVoltCh03;
	CSliderCtrl	m_sliSetVoltCh02;
	CSliderCtrl	m_sliSetVoltCh01;
	CSliderCtrl	m_sliSetVoltCh00;
	CEdit	m_edtSetVoltCh03;
	CEdit	m_edtSetVoltCh02;
	CEdit	m_edtSetVoltCh01;
	CEdit	m_edtSetVoltCh00;
	CEdit	m_stcActOutCh03;
	CEdit	m_stcActOutCh02;
	CEdit	m_stcActOutCh01;
	CEdit	m_stcActOutCh00;
	CEdit	m_edtComOutCh03;
	CEdit	m_edtComOutCh02;
	CEdit	m_edtComOutCh01;
	CEdit	m_edtComOutCh00;
	CComboBox	m_cboVoltageRange;
	CComboBox	m_cboModule;
	CButton	m_btnSet;
	//}}AFX_DATA

	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(COutputWriteMultiDlg)
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support
	//}}AFX_VIRTUAL

// Implementation
protected:
	HICON m_hIcon;

	// Generated message map functions
	//{{AFX_MSG(COutputWriteMultiDlg)
	virtual BOOL OnInitDialog();
	afx_msg void OnSysCommand(UINT nID, LPARAM lParam);
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	afx_msg void OnDestroy();
	afx_msg void OnSelchangeCboModule();
	afx_msg void OnSelchangeCboVoltageRange();
	afx_msg void OnBtnSet();
	afx_msg void OnTimer(UINT nIDEvent);
	afx_msg void OnReleasedcaptureSliSetVoltCh00(NMHDR* pNMHDR, LRESULT* pResult);
	afx_msg void OnReleasedcaptureSliSetVoltCh01(NMHDR* pNMHDR, LRESULT* pResult);
	afx_msg void OnReleasedcaptureSliSetVoltCh02(NMHDR* pNMHDR, LRESULT* pResult);
	afx_msg void OnReleasedcaptureSliSetVoltCh03(NMHDR* pNMHDR, LRESULT* pResult);
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_OUTPUTWRITEMULTIDLG_H__E8AC939D_975B_4351_8DB6_DE2BD27A6D08__INCLUDED_)
