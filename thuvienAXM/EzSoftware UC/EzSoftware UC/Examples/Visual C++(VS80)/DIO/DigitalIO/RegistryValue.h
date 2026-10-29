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
	// Document.프로그램 경로를 구함.
	// 프로그램 절대경로임.
	CString	GetDocFullPath(CString strName);

	//++
	// 해당 레지스트리에서 문자열의 값을 읽음.
	BOOL	GetCurrentName(CString strKeyName, CString strSubject, CString &strValue);

	//++
	// 해당 레지스트리에서 문자열의 값을 저장.
	BOOL	SetCurrentName(CString strKeyName, CString strSubject, CString strValue);

	//++
	// 해당 레지스트리에서 DWORD의 값을 읽음.
	BOOL	GetCurrentName(CString strKeyName, CString strSubject, DWORD &dwValue);

	//++
	// 해당 레지스트리에서 DWORD의 값을 저장.
	BOOL	SetCurrentName(CString strKeyName, CString strSubject, DWORD dwValue);
};

#endif // !defined(AFX_REGISTRYVALUE_H__D448F704_8485_4C19_BF36_61847D3FE145__INCLUDED_)
