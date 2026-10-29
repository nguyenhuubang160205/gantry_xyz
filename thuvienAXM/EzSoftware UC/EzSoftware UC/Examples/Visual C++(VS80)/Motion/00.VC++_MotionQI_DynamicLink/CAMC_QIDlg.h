// CAMC_QIDlg.h : header file
//
#if !defined(AFX_CAMC_QIDLG_H__0F7529AF_37FA_4FF6_9B77_4556650D3051__INCLUDED_)
#define AFX_CAMC_QIDLG_H__0F7529AF_37FA_4FF6_9B77_4556650D3051__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

#define MAX_AXIS_COUNT 64

/////////////////////////////////////////////////////////////////////////////
// CCAMCIPDlg dialog
#include "CAMC_QIDlg.h"
#include "CSXButton.h"
#include "xShadeButton.h"
#include "OScopeCtrl.h"
#include "CSGraph.h"
#include "Led.h"
#include "EditEx.h"
#include "StautsView.h"
#include "ManualSet.h"
#include "GL3DGraph.h"

#define WM_CAMC_INTERRUPT				(WM_USER + 2009)
/////////////////////////////////////////////////////////////////////////////
// CCAMC_QIDlg dialog

class CCAMC_QIDlg : public CDialog
{
// Construction
public:
	CCAMC_QIDlg(CWnd* pParent = NULL);

public:
	BOOL			m_bStatus;
	BOOL			m_b3DGraph;
	BOOL			m_bManualSet;

	// Interrupt Event
	BOOL			m_bThread[MAX_AXIS_COUNT];
	HANDLE			m_hHandle[MAX_AXIS_COUNT];
	HANDLE			m_hInterrupt[MAX_AXIS_COUNT];

	long			m_lAxisCounts;
	BOOL			m_bTestActive[MAX_AXIS_COUNT];
	BOOL			m_bEstop, m_bContiFlag;

	long			m_lAxis;
	long			m_lRange;

	CCSGraph		m_XYGraph;
	COScopeCtrl		m_GraphX, m_GraphY;
	CFont			m_sFont, m_sFont1, m_sFont2;
	CString			m_strFont1, m_strFont2;	

	CEditEx			m_edtCmdPos[4], m_edtActPos[4], m_edtCmdVel[4];
	CEditEx			m_edtPosition, m_edtVelocity, m_edtAccel, m_edtDecel;
	CEditEx			m_edtHomeVelFirst, m_edtHomeVelAfter, m_edtHomeVelAgain, m_edtHomeVelLast;

	CEditEx			m_edtSearchVelocity, m_edtSearchAccel;
	CEditEx			m_edtMoveUnit, m_edtStartSpeed;
	CEditEx			m_edtUnit, m_edtPulse;
	CEditEx			m_edtXend, m_edtYend, m_edtAngle;

	ManualSet		*m_pManualSet;
	HANDLE			m_hTestThread[MAX_AXIS_COUNT];									
	CStautsView		*m_pStatus;	
	GL3DGraph  		*m_pGL3DGraph;

	BOOL			m_bA4NAxis;

public:
	BOOL			InitLibrary();
	BOOL			ThreadData();
	BOOL			InitControl();
	
	void			SetCoordMovePara();
	void			UpdateAxisInfo();
	void			SetTitleBar(long axis);
	BOOL			SetGraphRange(long nAxis, double dVelocity);

	double			GetDlgItemDouble(int nID);
	void			SetDlgItemDouble(int nID, double value, int nPoint = 3);	

// Dialog Data
	//{{AFX_DATA(CCAMC_QIDlg)
	enum { IDD = IDD_CAMC_QI_DIALOG };
	CButton	m_btnTrigReset;
	CButton	m_btnTrigPeriod;
	CButton	m_btnTrigOneshot;
	CButton	m_btnTrigABS;
	CEdit	m_edtTrigCycle;
	CEdit	m_edtTrigEndPos;
	CEdit	m_edtTrigPulseWidth;
	CEdit	m_edtTrigStartPos;
	CButton	m_chkGearOnOff;
	CButton	m_chkXYsync;
	CButton	m_chkGantry;
	CLed	m_ledZphase;
	CComboBox	m_cboEncInputM;
	CButton	m_chkHomeLevel;
	CButton	m_chkScurve;
	CxShadeButton	m_btnJogPx;
	CxShadeButton	m_btnJogNx;
	CxShadeButton	m_btnJogPy;
	CxShadeButton	m_btnJogNy;
	CxShadeButton	m_btnJogPz;
	CxShadeButton	m_btnJogNz;
	CxShadeButton	m_btnJogPu;
	CxShadeButton	m_btnJogNu;
	CComboBox	m_cboDetect;
	CComboBox	m_cboDirection;
	CComboBox	m_cboStopM;
	CComboBox	m_cboPulseOutM;
	CComboBox	m_cboHomeSignal;
	CComboBox	m_cboHomeDir;
	CButton	m_chkRelative;
	CButton	m_chkPelmLevel;
	CButton	m_chkNelmLevel;
	CButton	m_chkInpLevel;
	CButton	m_chkCwCcw;
	CButton	m_chkGantrySlave;
	CButton	m_chkZphaseLevel;
	CButton	m_chkAsym;
	CButton	m_chkAlarmUse;
	CButton	m_chkAlarmLevel;
	CButton	m_chkAbsolute;
	CButton m_chkEmgLevel;
	CComboBox	m_cboAxisSet;
	CSXButton	m_bthCircular;
	CSXButton	m_btnCountClr;
	CSXButton	m_btnEstop;
	CLed	m_ledAlarm;
	CLed	m_ledBusyY;
	CLed	m_ledBusyX;
	CLed	m_ledExmp;
	CLed	m_ledExpp;
	CListBox	m_lstLog;
	CLed	m_ledHome;
	CLed	m_ledPelm;
	CLed	m_ledOut5;
	CLed	m_ledOut4;
	CLed	m_ledOut3;
	CLed	m_ledOut2;
	CLed	m_ledOut1;
	CLed	m_ledOut0;
	CLed	m_ledNelm;
	CLed	m_ledInp;
	CLed	m_ledIn5;
	CLed	m_ledIn4;
	CLed	m_ledIn3;
	CLed	m_ledIn2;
	CLed	m_ledIn1;
	CLed	m_ledIn0;
	CLed	m_ledEmg;
	CSXButton	m_btnStop;
	CSXButton	m_btnStatus;
	CSXButton	m_btnRepeat;
	CSXButton	m_btnMove;
	CSXButton	m_btnLinear;
	CSXButton	m_btnHomeAll;
	CSXButton	m_btnHomeSingle;
	COScopeCtrl m_xaxisspd;
	COScopeCtrl m_yaxisspd;
	CSXButton	m_btnCrcOn;
	CSXButton	m_btnCrcOff;
	//}}AFX_DATA

	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CCAMC_QIDlg)
	public:
	virtual BOOL PreTranslateMessage(MSG* pMsg);
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support
	virtual BOOL OnNotify(WPARAM wParam, LPARAM lParam, LRESULT* pResult);
	//}}AFX_VIRTUAL

// Implementation
protected:
	HICON m_hIcon;

	// Generated message map functions
	//{{AFX_MSG(CCAMC_QIDlg)
	virtual BOOL OnInitDialog();
	afx_msg void OnSysCommand(UINT nID, LPARAM lParam);
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	afx_msg void OnTimer(UINT_PTR nIDEvent);
	afx_msg void OnDestroy();
	afx_msg void OnBtnHomeAll();
	afx_msg void OnBtnHomeSingle();
	afx_msg void OnBtnVelOverride();
	afx_msg void OnChkPelmLevel();
	afx_msg void OnChkNelmLevel();
	afx_msg void OnChkInpLevel();
	afx_msg void OnChkAlarmLevel();
	afx_msg void OnChkEmgLevel();
	afx_msg void OnLedOut0();
	afx_msg void OnLedOut1();
	afx_msg void OnLedOut2();
	afx_msg void OnLedOut3();
	afx_msg void OnLedOut4();
	afx_msg void OnLedOut5();
	afx_msg void OnBtnSearch();
	afx_msg void OnChkHomeLevel();
	afx_msg void OnChkAsym();
	afx_msg void OnChkAbsolute();
	afx_msg void OnChkRelative();
	afx_msg void OnBtnSetting();
	afx_msg void OnBtnRepeat();
	afx_msg void OnBtnStop();
	afx_msg void OnBtnEstop();
	afx_msg void OnChkZphaseLevel();
	afx_msg void OnBtnStatus();
	afx_msg void OnSelchangeCmbAxisset();
	afx_msg void OnSelchangeCmbPulseOutm();
	afx_msg void OnSelchangeCmbEncInputm();
	afx_msg void OnBtnMove();
	afx_msg void OnBtnLinear();
	afx_msg void OnBtnCircular();
	afx_msg void OnBtnCountClr();
	afx_msg void OnBtnContiLine();
	afx_msg void OnBtnContiSpline();
	afx_msg void OnBtnContiStart();
	afx_msg void OnChkGantry();
	afx_msg void OnBtnContiClr();
	afx_msg void OnBtnIntDisable();
	afx_msg void OnBtnCrcOff();
	afx_msg void OnBtnCrcOn();
	afx_msg void OnBtnMpgOff();
	afx_msg void OnBtnMpgOn();
	afx_msg void OnBtncontiTest();
	afx_msg void OnBtnManualset();
	afx_msg void OnChkScurve();
	afx_msg void OnBtnLoad();
	afx_msg void OnBtnSave();
	afx_msg void OnBtnTrigReset();
	afx_msg void OnBtnTrigAbs();
	afx_msg void OnBtnTrigPeriod();
	afx_msg void OnBtnSigCapture();
	afx_msg void OnBtnIntMessage();
	afx_msg void OnBtnIntEvent();
	afx_msg void OnBtnIntCallback();
	afx_msg void OnBtnContiBlend();
	afx_msg void OnBtnContiCircle();
	afx_msg void OnBtnTrigOneshot();
	afx_msg void OnChkGearOnoff();
	afx_msg void OnDblclkLstLog();
	afx_msg void OnBtnReadCapture();
	afx_msg void OnBtn3dgraph();
	afx_msg void OnChkGantrySlave();
	//}}AFX_MSG
	afx_msg LRESULT OnControlMessage(WPARAM wParam, LPARAM lParam);
	DECLARE_MESSAGE_MAP()
};

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_CAMC_QIDLG_H__0F7529AF_37FA_4FF6_9B77_4556650D3051__INCLUDED_)




























































