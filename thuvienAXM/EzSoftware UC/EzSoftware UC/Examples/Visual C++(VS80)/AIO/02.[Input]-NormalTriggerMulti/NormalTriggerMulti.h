// NormalTriggerMulti.h : main header file for the NORMALTRIGGERMULTI application
//

#if !defined(AFX_NORMALTRIGGERMULTI_H__B1F73B37_F591_4439_9A61_904F30F091F0__INCLUDED_)
#define AFX_NORMALTRIGGERMULTI_H__B1F73B37_F591_4439_9A61_904F30F091F0__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

#ifndef __AFXWIN_H__
	#error include 'stdafx.h' before including this file for PCH
#endif

#include "resource.h"		// main symbols

/////////////////////////////////////////////////////////////////////////////
// CNormalTriggerMultiApp:
// See NormalTriggerMulti.cpp for the implementation of this class
//

class CNormalTriggerMultiApp : public CWinApp
{
public:
	CNormalTriggerMultiApp();

// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CNormalTriggerMultiApp)
	public:
	virtual BOOL InitInstance();
	//}}AFX_VIRTUAL

// Implementation

	//{{AFX_MSG(CNormalTriggerMultiApp)
		// NOTE - the ClassWizard will add and remove member functions here.
		//    DO NOT EDIT what you see in these blocks of generated code !
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};


/////////////////////////////////////////////////////////////////////////////

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_NORMALTRIGGERMULTI_H__B1F73B37_F591_4439_9A61_904F30F091F0__INCLUDED_)
