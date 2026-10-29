// ContiInterpolationDlg.h : header file
//

#if !defined(AFX_ContiInterpolationDLG_H__73D72006_6740_48E6_B82A_A2DA794741A4__INCLUDED_)
#define AFX_ContiInterpolationDLG_H__73D72006_6740_48E6_B82A_A2DA794741A4__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

/////////////////////////////////////////////////////////////////////////////
// CContiInterpolationDlg dialog
#define MAX_INTP_MOVE_AXIS		4

class CContiInterpolationDlg : public CDialog
{
public:
	long		m_lAxisNo;								// 제어할 축 번호
	long		m_lAxisCount;							// 유효한 전체 모션축수
	DWORD		m_dwModuleID;							// 선택한 축의 모델ID

	long		m_lMoveIntpAxesCount;					// 보간에 사용할 축 갯수 
	long		m_lMoveIntpAxes[MAX_INTP_MOVE_AXIS];	// 보간에 사용할 축 배열
	
	double		m_dOldCmdPos[MAX_INTP_MOVE_AXIS];		// OnTimer에서 사용할 이전 Command Position
	double		m_dOldActPos[MAX_INTP_MOVE_AXIS];		// OnTimer에서 사용할 이전 Actual Position
	double		m_dOldCmdVel[MAX_INTP_MOVE_AXIS];		// OnTimer에서 사용할 이전 Command Velocity

private:
	CButton		m_chkMoveIntpAxes[MAX_INTP_MOVE_AXIS];

public:
	BOOL		InitLibrary();							// 라이브러리 초기화 및 Mot파일을 불러옵니다.
	BOOL		InitControl();							// Control 변수들을 등록하고, 초기 설정값들을 설정합니다.
	BOOL		AddAxisInfo();							// 검색된 축 정보를 ComboBox에 등록/Control들을 초기화합니다.
	BOOL		UpdateState();							// 모션보드의 상태와 Control들의 상태를 일치시킵니다.
	
	DWORD		ConvertComboToAxm(CComboBox *pCboItem);						// ComboBox콘트롤에 현재 선택된 Item Index를 모션보드에 설정할 값으로 변경하는 함수.	
	long		ConvertAxmToCombo(CComboBox *pCboItem, DWORD dwCurData);	// 설정값과 ComboBox콘트롤의 Item과 일치하는 Item을 찾아 선택하는 함수.	
	void		SetDlgItemDouble(int nID, double value, int nPoint = 3);	// double값을 지정한 콘트롤에 설정하는 함수
	double		GetDlgItemDouble(int nID);									// 지정한 콘트롤에 설정되어 있는 텍스트를 double값으로 변환하여 반환하는 함수.

// Construction
public:
	CContiInterpolationDlg(CWnd* pParent = NULL);	// standard constructor

// Dialog Data
	//{{AFX_DATA(CContiInterpolationDlg)
	enum { IDD = IDD_CONTIINTERPOLATION_DIALOG };
	CButton	m_btnIntpSpline;
	CButton	m_btnIntpLineArc;
	CButton	m_btnIntpLine;
	CButton	m_btnIntpHelical;
	CButton	m_btnIntpCircle;
	CButton	m_btnIntpArc;
	CComboBox	m_cboSelAxis;
	CButton		m_chkServoOn;
	//}}AFX_DATA

	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CContiInterpolationDlg)
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support
	//}}AFX_VIRTUAL

// Implementation
protected:
	HICON m_hIcon;

	// Generated message map functions
	//{{AFX_MSG(CContiInterpolationDlg)
	virtual BOOL OnInitDialog();
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	afx_msg void OnSelchangeCboSelAxis();
	afx_msg void OnTimer(UINT_PTR nIDEvent);
	afx_msg void OnBtnLoadFile();
	afx_msg void OnDestroy();
	afx_msg void OnBtnPosClear();
	afx_msg void OnChkServoOn();
	afx_msg void OnBtnIntpStop();
	afx_msg void OnBtnIntpLine();
	afx_msg void OnBtnIntpArc();
	afx_msg void OnBtnIntpCircle();
	afx_msg void OnBtnIntpLineArc();
	afx_msg void OnBtnIntpHelical();
	afx_msg void OnBtnIntpSpline();
	afx_msg void OnBtnIntpStart();
	afx_msg void OnBtnIntpClear();
	//}}AFX_MSG
	afx_msg void OnChkAxis(UINT nID);
	DECLARE_MESSAGE_MAP()
};

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_ContiInterpolationDLG_H__73D72006_6740_48E6_B82A_A2DA794741A4__INCLUDED_)
