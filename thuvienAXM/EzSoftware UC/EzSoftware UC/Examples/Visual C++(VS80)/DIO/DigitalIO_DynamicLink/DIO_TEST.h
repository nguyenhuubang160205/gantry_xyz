// DIO_TEST.h : main header file for the DIO_TEST application
//

#if !defined(AFX_DIO_TEST_H__B087998D_891E_46A2_8E98_6099A4E4C29D__INCLUDED_)
#define AFX_DIO_TEST_H__B087998D_891E_46A2_8E98_6099A4E4C29D__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

#ifndef __AFXWIN_H__
	#error include 'stdafx.h' before including this file for PCH
#endif

#include "resource.h"		// main symbols

/////////////////////////////////////////////////////////////////////////////
// CDIO_TESTApp:
// See DIO_TEST.cpp for the implementation of this class
//

class CDIO_TESTApp : public CWinApp
{
public:
	CDIO_TESTApp();

// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CDIO_TESTApp)
	public:
	virtual BOOL InitInstance();
	//}}AFX_VIRTUAL

// Implementation

	//{{AFX_MSG(CDIO_TESTApp)
		// NOTE - the ClassWizard will add and remove member functions here.
		//    DO NOT EDIT what you see in these blocks of generated code !
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};


/////////////////////////////////////////////////////////////////////////////

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_DIO_TEST_H__B087998D_891E_46A2_8E98_6099A4E4C29D__INCLUDED_)
