// AI_TEST.h : main header file for the AI_TEST application
//

#if !defined(AFX_AI_TEST_H__6666AF21_55EE_438C_9849_776702148EFD__INCLUDED_)
#define AFX_AI_TEST_H__6666AF21_55EE_438C_9849_776702148EFD__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

#ifndef __AFXWIN_H__
	#error include 'stdafx.h' before including this file for PCH
#endif

#include "resource.h"		// main symbols

/////////////////////////////////////////////////////////////////////////////
// CAI_TESTApp:
// See AI_TEST.cpp for the implementation of this class
//

class CAI_TESTApp : public CWinApp
{
public:
	CAI_TESTApp();

// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CAI_TESTApp)
	public:
	virtual BOOL InitInstance();
	//}}AFX_VIRTUAL

// Implementation

	//{{AFX_MSG(CAI_TESTApp)
		// NOTE - the ClassWizard will add and remove member functions here.
		//    DO NOT EDIT what you see in these blocks of generated code !
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};


/////////////////////////////////////////////////////////////////////////////

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_AI_TEST_H__6666AF21_55EE_438C_9849_776702148EFD__INCLUDED_)
