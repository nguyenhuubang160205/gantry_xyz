// RegistryValue.h: interface for the CRegistryValue class.
//
//////////////////////////////////////////////////////////////////////

#if !defined(AFX_REGISTRYVALUE_H__D448F704_8485_4C19_BF36_61847D3FE145__INCLUDED_)
#define AFX_REGISTRYVALUE_H__D448F704_8485_4C19_BF36_61847D3FE145__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

class CRegistryValue  
{
public:
	CRegistryValue();
	virtual ~CRegistryValue();

	//++
	// Document. bring a program route.
	// A program absolute route.
	CString	GetDocFullPath(CString strName);

	//++
	// read the price of the character string in that registry.
	BOOL	GetCurrentName(CString strKeyName, CString strSubject, CString &strValue);

	//++
	// save the price of the character string in that registry.
	BOOL	SetCurrentName(CString strKeyName, CString strSubject, CString strValue);

	//++
	// read the price of DWORD in that registry.
	BOOL	GetCurrentName(CString strKeyName, CString strSubject, DWORD &dwValue);

	//++
	// save the price of DWORD in that registry.
	BOOL	SetCurrentName(CString strKeyName, CString strSubject, DWORD dwValue);
};

#endif // !defined(AFX_REGISTRYVALUE_H__D448F704_8485_4C19_BF36_61847D3FE145__INCLUDED_)
