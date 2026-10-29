// SignalMonitor.h : main header file for the SignalMonitor application
//

#if !defined(AFX_SignalMonitor_H__30C1E57A_E154_416B_8BDB_F012C4D45510__INCLUDED_)
#define AFX_SignalMonitor_H__30C1E57A_E154_416B_8BDB_F012C4D45510__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

#ifndef __AFXWIN_H__
	#error include 'stdafx.h' before including this file for PCH
#endif

#include "resource.h"		// main symbols

/////////////////////////////////////////////////////////////////////////////
// CSignalMonitorApp:
// See SignalMonitor.cpp for the implementation of this class
//

class CSignalMonitorApp : public CWinApp
{
public:
	CSignalMonitorApp();

// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CSignalMonitorApp)
	public:
	virtual BOOL InitInstance();
	//}}AFX_VIRTUAL

// Implementation

	//{{AFX_MSG(CSignalMonitorApp)
		// NOTE - the ClassWizard will add and remove member functions here.
		//    DO NOT EDIT what you see in these blocks of generated code !
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};


/////////////////////////////////////////////////////////////////////////////

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_SignalMonitor_H__30C1E57A_E154_416B_8BDB_F012C4D45510__INCLUDED_)
