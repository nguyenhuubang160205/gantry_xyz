// NormalTriggerMultiDlg.h : header file
//

#if !defined(AFX_NORMALTRIGGERMULTIDLG_H__7492FC7D_EBF5_4DB7_AD97_CAE349266FB7__INCLUDED_)
#define AFX_NORMALTRIGGERMULTIDLG_H__7492FC7D_EBF5_4DB7_AD97_CAE349266FB7__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

/////////////////////////////////////////////////////////////////////////////
// CNormalTriggerMultiDlg dialog

class CNormalTriggerMultiDlg : public CDialog
{
// Customize area
public:
	DWORD		m_dwModuleID;			// 모델ID
	long		m_lModuleNo;			// 제어할 모듈 번호
	long		m_lModuleCount;			// 유효한 전체 모듈 수
	long		m_lChannelCount;		// 유효한 전체 채널 수
	BOOL		m_bIsReadVoltage;		// 입력받을 데이터의 종류(TRUE:Volt, FALSE:DIGIT)
	double		m_dOldVoltArr[4];		// OnTimer에서 사용할 이전 Volt
	DWORD		m_dwOldDigitArr[4];		// OnTimer에서 사용할 이전 Digit

private:
	CEdit		m_edtValueArr[4];
	
public:
	BOOL		InitLibrary();				// 라이브러리 초기화 작업을 수행합니다.
	BOOL		InitControl();				// Control 변수들을 등록하고, 초기 설정값들을 설정하는 함수.
	BOOL		AddModuleChannelInfo();		// 검색된 모듈과 채널 정보를 ComboBox에 등록/Control들을 초기화합니다.
	BOOL		UpdateState();				// AIO모듈의 상태와 Control들의 상태를 일치시킵니다.
	
	DWORD		ConvertComboToAxa(CComboBox *pCboItem);						// ComboBox콘트롤에 현재 선택된 Item Index를 AIO모듈에 설정할 값으로 변경하는 함수.	
	long		ConvertAxaToCombo(CComboBox *pCboItem, DWORD dwCurData);	// 설정값과 ComboBox콘트롤의 Item과 일치하는 Item을 찾아 선택하는 함수.	
	void		SetDlgItemDouble(int nID, double value, int nPoint = 6);	// double값을 지정한 콘트롤에 설정하는 함수
	double		GetDlgItemDouble(int nID);									// 지정한 콘트롤에 설정되어 있는 텍스트를 double값으로 변환하여 반환하는 함수.
	
	void		UpdateVoltageRange();

// Construction
public:
	CNormalTriggerMultiDlg(CWnd* pParent = NULL);	// standard constructor

// Dialog Data
	//{{AFX_DATA(CNormalTriggerMultiDlg)
	enum { IDD = IDD_NORMALTRIGGERMULTI_DIALOG };
	CEdit	m_stcCh03;
	CEdit	m_stcCh02;
	CEdit	m_stcCh01;
	CEdit	m_stcCh00;
	CComboBox	m_cboVoltageRange;
	CComboBox	m_cboValueType;
	CComboBox	m_cboModule;
	CButton	m_btnStop;
	CButton	m_btnStart;
	//}}AFX_DATA

	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CNormalTriggerMultiDlg)
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support
	//}}AFX_VIRTUAL

// Implementation
protected:
	HICON m_hIcon;

	// Generated message map functions
	//{{AFX_MSG(CNormalTriggerMultiDlg)
	virtual BOOL OnInitDialog();
	afx_msg void OnSysCommand(UINT nID, LPARAM lParam);
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	afx_msg void OnTimer(UINT nIDEvent);
	afx_msg void OnDestroy();
	afx_msg void OnSelchangeCboModule();
	afx_msg void OnSelchangeCboVoltageRange();
	afx_msg void OnSelchangeCboValueType();
	afx_msg void OnBtnStart();
	afx_msg void OnBtnStop();
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_NORMALTRIGGERMULTIDLG_H__7492FC7D_EBF5_4DB7_AD97_CAE349266FB7__INCLUDED_)
