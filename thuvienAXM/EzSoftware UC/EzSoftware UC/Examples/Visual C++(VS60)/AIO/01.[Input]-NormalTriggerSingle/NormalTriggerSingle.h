// NormalTriggerSingle.h : main header file for the NORMALTRIGGERSINGLE application
//

#if !defined(AFX_NORMALTRIGGERSINGLE_H__5E3D19F9_532B_4EB1_B480_235631A7EF85__INCLUDED_)
#define AFX_NORMALTRIGGERSINGLE_H__5E3D19F9_532B_4EB1_B480_235631A7EF85__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

#ifndef __AFXWIN_H__
	#error include 'stdafx.h' before including this file for PCH
#endif

#include "resource.h"		// main symbols

/////////////////////////////////////////////////////////////////////////////
// CNormalTriggerSingleApp:
// See NormalTriggerSingle.cpp for the implementation of this class
//

class CNormalTriggerSingleApp : public CWinApp
{
public:
	CNormalTriggerSingleApp();

// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CNormalTriggerSingleApp)
	public:
	virtual BOOL InitInstance();
	//}}AFX_VIRTUAL

// Implementation

	//{{AFX_MSG(CNormalTriggerSingleApp)
		// NOTE - the ClassWizard will add and remove member functions here.
		//    DO NOT EDIT what you see in these blocks of generated code !
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};


/////////////////////////////////////////////////////////////////////////////

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_NORMALTRIGGERSINGLE_H__5E3D19F9_532B_4EB1_B480_235631A7EF85__INCLUDED_)
