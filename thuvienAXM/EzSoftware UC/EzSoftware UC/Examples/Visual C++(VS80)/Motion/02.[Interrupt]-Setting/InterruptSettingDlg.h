// InterruptSettingDlg.h : header file
//

#if !defined(AFX_INTERRUPTSETTINGDLG_H__CE15E40E_4A3C_4CD6_9AC9_F56C4746501C__INCLUDED_)
#define AFX_INTERRUPTSETTINGDLG_H__CE15E40E_4A3C_4CD6_9AC9_F56C4746501C__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

#include <afxtempl.h>

/////////////////////////////////////////////////////////////////////////////
// CInterruptSettingDlg dialog
#define INT_BANK_1			0
#define INT_BANK_2			1

#define MAX_BANK_1			4
#define MAX_BANK_2			6
#define MAX_AXIS_COUNT		64

// 인터럽트 이벤트 종류 정의
enum{	INT_MESSAGE, INT_CALLBACK, INT_EVENT };

// 인터럽트 정보 구조체
typedef struct{
	char	szTime[20];

	long	lAxisNo;
	DWORD	dwBank0;
	DWORD	dwBank1;
	DWORD	dwIntFlag;
	BYTE	byIntType;
}STIntItem, *PSTIntItem;

class CInterruptSettingDlg : public CDialog
{
public:
	long		m_lAxisNo;							// 제어할 축 번호
	long		m_lAxisCount;						// 유효한 전체 모션축수
	long		m_lIntCount;						// 인터럽트 발생 갯수
	DWORD		m_dwModuleID;						// 선택한 축의 모델ID

	HANDLE		m_hIntEvent[MAX_AXIS_COUNT];		// 각 축별 인터럽트 이벤트 핸들
	BOOL		m_bThHandle[MAX_AXIS_COUNT];		// 각 축별 인터럽트 쓰레드 생성여부
	HANDLE		m_hThHandle[MAX_AXIS_COUNT];		// 각 축별 인터럽트 쓰레드 핸들

	CArray<STIntItem, STIntItem&> m_aIntItem;

public:
	BOOL		InitLibrary();						// 라이브러리 초기화 및 Mot파일을 불러오는 함수.
	BOOL		InitControl();						// Control 변수들을 등록하고, 초기 설정값들을 설정하는 함수.
	BOOL		AddAxisInfo();						// 검색된 축 정보를 ComboBox에 등록/Control들을 초기화하는 함수.
	BOOL		UpdateState();						// 모션보드의 상태와 Control들의 상태를 일치시키는 함수.
	void		AddMsgToLog(STIntItem stIntItem);	// 인터럽트 정보를 ListBox 콘트롤에 등록하는 함수.

// Construction
public:
	CInterruptSettingDlg(CWnd* pParent = NULL);	// standard constructor

// Dialog Data
	//{{AFX_DATA(CInterruptSettingDlg)
	enum { IDD = IDD_INTERRUPTSETTING_DIALOG };
	int			m_nIntMethod;
	CComboBox	m_cboSelAxis;
	CButton     m_rdoMessage;
	CListBox	m_lstIntLog;
	//}}AFX_DATA

	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CInterruptSettingDlg)
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support
	//}}AFX_VIRTUAL

// Implementation
protected:
	HICON m_hIcon;

	// Generated message map functions
	//{{AFX_MSG(CInterruptSettingDlg)
	virtual BOOL OnInitDialog();
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	afx_msg void OnBtnSetBank1();
	afx_msg void OnBtnSetBank2();
	afx_msg void OnChkIntEnable();
	afx_msg void OnSelchangeCboSelAxis();
	afx_msg void OnDestroy();
	afx_msg void OnTimer(UINT_PTR nIDEvent);
	afx_msg void OnDblclkLstLog();
	//}}AFX_MSG
	afx_msg LRESULT OnAxmIntMessage(WPARAM wParam, LPARAM lParam);
	DECLARE_MESSAGE_MAP()
};

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_INTERRUPTSETTINGDLG_H__CE15E40E_4A3C_4CD6_9AC9_F56C4746501C__INCLUDED_)
