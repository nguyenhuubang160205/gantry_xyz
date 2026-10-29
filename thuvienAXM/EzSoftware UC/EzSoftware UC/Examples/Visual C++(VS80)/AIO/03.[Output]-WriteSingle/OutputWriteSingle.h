// OutputWriteSingle.h : main header file for the OUTPUTWRITESINGLE application
//

#if !defined(AFX_OUTPUTWRITESINGLE_H__0E11FFEF_8AA3_4B5A_A611_366C01F7E40F__INCLUDED_)
#define AFX_OUTPUTWRITESINGLE_H__0E11FFEF_8AA3_4B5A_A611_366C01F7E40F__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

#ifndef __AFXWIN_H__
	#error include 'stdafx.h' before including this file for PCH
#endif

#include "resource.h"		// main symbols

/////////////////////////////////////////////////////////////////////////////
// COutputWriteSingleApp:
// See OutputWriteSingle.cpp for the implementation of this class
//

class COutputWriteSingleApp : public CWinApp
{
public:
	COutputWriteSingleApp();

// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(COutputWriteSingleApp)
	public:
	virtual BOOL InitInstance();
	//}}AFX_VIRTUAL

// Implementation

	//{{AFX_MSG(COutputWriteSingleApp)
		// NOTE - the ClassWizard will add and remove member functions here.
		//    DO NOT EDIT what you see in these blocks of generated code !
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};


/////////////////////////////////////////////////////////////////////////////

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_OUTPUTWRITESINGLE_H__0E11FFEF_8AA3_4B5A_A611_366C01F7E40F__INCLUDED_)
