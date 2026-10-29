// MoveSignalCapture.h : main header file for the MoveSignalCapture application
//

#if !defined(AFX_MoveSignalCapture_H__30C1E57A_E154_416B_8BDB_F012C4D45510__INCLUDED_)
#define AFX_MoveSignalCapture_H__30C1E57A_E154_416B_8BDB_F012C4D45510__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

#ifndef __AFXWIN_H__
	#error include 'stdafx.h' before including this file for PCH
#endif

#include "resource.h"		// main symbols

/////////////////////////////////////////////////////////////////////////////
// CMoveSignalCaptureApp:
// See MoveSignalCapture.cpp for the implementation of this class
//

class CMoveSignalCaptureApp : public CWinApp
{
public:
	CMoveSignalCaptureApp();

// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CMoveSignalCaptureApp)
	public:
	virtual BOOL InitInstance();
	//}}AFX_VIRTUAL

// Implementation

	//{{AFX_MSG(CMoveSignalCaptureApp)
		// NOTE - the ClassWizard will add and remove member functions here.
		//    DO NOT EDIT what you see in these blocks of generated code !
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};


/////////////////////////////////////////////////////////////////////////////

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_MoveSignalCapture_H__30C1E57A_E154_416B_8BDB_F012C4D45510__INCLUDED_)
