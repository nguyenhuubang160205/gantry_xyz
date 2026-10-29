// MoveSingleAxisDlg.h : header file
//

#if !defined(AFX_MOVESINGLEAXISDLG_H__73D72006_6740_48E6_B82A_A2DA794741A4__INCLUDED_)
#define AFX_MOVESINGLEAXISDLG_H__73D72006_6740_48E6_B82A_A2DA794741A4__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

/////////////////////////////////////////////////////////////////////////////
// CMoveSingleAxisDlg dialog
#include "JogButton.h"

#define MAX_AXIS_COUNT		128
class CMoveSingleAxisDlg : public CDialog
{
public:
	long		m_lAxisNo;					// 제어할 축 번호
	long		m_lAxisCount;				// 유효한 전체 모션축수
	DWORD		m_dwModuleID;				// 선택한 축의 모델ID
	
	double		m_dOldCmdPos;				// OnTimer에서 사용할 이전 Command Position			
	double		m_dOldActPos;				// OnTimer에서 사용할 이전 Actual Position	
	double		m_dOldCmdVel;				// OnTimer에서 사용할 이전 Command Velocity

public:
	BOOL		InitLibrary();				// 라이브러리 초기화 및 Mot파일을 불러오는 함수.
	BOOL		InitControl();				// Control 변수들을 등록하고, 초기 설정값들을 설정하는 함수.
	BOOL		AddAxisInfo();				// 검색된 축 정보를 ComboBox에 등록/Control들을 초기화하는 함수.
	BOOL		UpdateState();				// 모션보드의 상태와 Control들의 상태를 일치시키는 함수.
	
	DWORD		ConvertComboToAxm(CComboBox *pCboItem);						// ComboBox콘트롤에 현재 선택된 Item Index를 모션보드에 설정할 값으로 변경하는 함수.	
	long		ConvertAxmToCombo(CComboBox *pCboItem, DWORD dwCurData);	// 설정값과 ComboBox콘트롤의 Item과 일치하는 Item을 찾아 선택하는 함수.	
	void		SetDlgItemDouble(int nID, double value, int nPoint = 3);	// double값을 지정한 콘트롤에 설정하는 함수
	double		GetDlgItemDouble(int nID);									// 지정한 콘트롤에 설정되어 있는 텍스트를 double값으로 변환하여 반환하는 함수.

	BOOL		m_bTestActive[MAX_AXIS_COUNT];
	HANDLE		m_hTestThread[MAX_AXIS_COUNT];

// Construction
public:
	CMoveSingleAxisDlg(CWnd* pParent = NULL);	// standard constructor

// Dialog Data
	//{{AFX_DATA(CMoveSingleAxisDlg)
	enum { IDD = IDD_MOVESINGLEAXIS_DIALOG };
	CComboBox	m_cboSelAxis;
	CComboBox	m_cboProfile;
	CJogButton	m_btnJogMoveP;
	CJogButton	m_btnJogMoveN;
	double		m_dMovePos1;
	double		m_dMovePos2;
	double		m_dMoveVel;
	double		m_dMoveAcc;
	double		m_dMoveDec;
	double		m_dJogVel;
	//}}AFX_DATA

	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CMoveSingleAxisDlg)
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support
	//}}AFX_VIRTUAL

// Implementation
protected:
	HICON m_hIcon;

	// Generated message map functions
	//{{AFX_MSG(CMoveSingleAxisDlg)
	virtual BOOL OnInitDialog();
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	afx_msg void OnSelchangeCboSelAxis();
	afx_msg void OnBtnLoadFile();
	afx_msg void OnBtnPosClear();
	afx_msg void OnBtnMove1();
	afx_msg void OnBtnMove2();
	afx_msg void OnBtnSstop();
	afx_msg void OnTimer(UINT nIDEvent);
	afx_msg void OnSelchangeCboProfile();
	afx_msg void OnChkServoOn();
	afx_msg void OnDestroy();
	afx_msg void OnBtnRepeat();
	//}}AFX_MSG
	afx_msg void	OnRdoAbsRelMode(UINT nID);
	afx_msg LRESULT OnJogBtnDn(WPARAM wParam, LPARAM lParam);
	afx_msg LRESULT OnJogBtnUp(WPARAM wParam, LPARAM lParam);

	DECLARE_MESSAGE_MAP()
};

UINT RepeatThread(LPVOID pFuncData);

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_MOVESINGLEAXISDLG_H__73D72006_6740_48E6_B82A_A2DA794741A4__INCLUDED_)