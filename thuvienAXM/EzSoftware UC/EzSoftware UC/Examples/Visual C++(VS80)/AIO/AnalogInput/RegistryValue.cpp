// RegistryValue.cpp: implementation of the CRegistryValue class.
//
//////////////////////////////////////////////////////////////////////

#include "stdafx.h"
#include "RegistryValue.h"

#ifdef _DEBUG
#undef THIS_FILE
static char THIS_FILE[]=__FILE__;
#define new DEBUG_NEW
#endif

//////////////////////////////////////////////////////////////////////
// Construction/Destruction
//////////////////////////////////////////////////////////////////////

CRegistryValue::CRegistryValue()
{

}

CRegistryValue::~CRegistryValue()
{

}

CString CRegistryValue::GetDocFullPath(CString strName)
{
	LONG	lRes;
	HKEY	hKeyIcons;

//	lRes = RegOpenKey(HKEY_CLASSES_ROOT, "EzConfig.Document\\DefaultIcon",
//		&hKeyIcons);

	lRes = RegOpenKeyEx(HKEY_CLASSES_ROOT, strName + ".Document\\DefaultIcon", 0, 
		KEY_ALL_ACCESS, &hKeyIcons);

	if (lRes == ERROR_SUCCESS)
	{
		DWORD dwType, dwBytes;
		CString strPath;
		unsigned char szBuffer[255]; // taken here the character string
		int		nLength;
		
		RegQueryValueEx(hKeyIcons, _T(""), NULL, &dwType, NULL, &dwBytes);
		RegQueryValueEx(hKeyIcons, _T(""), NULL, &dwType, szBuffer, &dwBytes);
		
//		strPath.Format("%ld:%s:%s", dwBytes, strName, szBuffer);
		strPath.Format("%s", szBuffer);

//		AfxMessageBox(strName);

		nLength	= strPath.ReverseFind('\\');

		strPath		= strPath.Left(nLength);

		RegCloseKey(hKeyIcons);

		return		strPath;
	}

	RegCloseKey(hKeyIcons);

	return		"";
}

BOOL CRegistryValue::GetCurrentName(CString strKeyName, CString strSubject, CString &strValue)
{
	LONG	lRes;
	HKEY	hKeyIcons;
	CString	strKeyValue;

	strKeyValue.Format("Software\\%s", strKeyName);

	lRes = RegOpenKeyEx(HKEY_CURRENT_USER, strKeyValue, 0, 
		KEY_ALL_ACCESS, &hKeyIcons);

	if (lRes == ERROR_SUCCESS)
	{
		DWORD dwType, dwBytes;
		unsigned char szBuffer[255]; // taken here the character string
		
		::RegQueryValueEx(hKeyIcons, strSubject, 0, &dwType, szBuffer, &dwBytes);
		
		ZeroMemory(szBuffer, sizeof(szBuffer));

		if (szBuffer[0] != '\0')
			strValue.Format("%s", szBuffer);

		RegCloseKey(hKeyIcons);

		return TRUE;
	}

	RegCloseKey(hKeyIcons);

	return FALSE;
}

BOOL CRegistryValue::SetCurrentName(CString strKeyName, CString strSubject, CString strValue)
{
	LONG	lRes;
	HKEY	hKeyIcons;
	CString	strKeyValue;

	strKeyValue.Format("Software\\%s", strKeyName);

	lRes = RegOpenKeyEx(HKEY_CURRENT_USER, strKeyValue, 0, 
		KEY_ALL_ACCESS, &hKeyIcons);

	if (lRes == ERROR_SUCCESS)
	{
		CString strPath;
		unsigned char szBuffer[255]; // taken here the character string

		CopyMemory(szBuffer, strValue, strValue.GetLength());
		
		::RegSetValueEx(hKeyIcons, strSubject, 0, REG_SZ, szBuffer, strValue.GetLength());

		RegCloseKey(hKeyIcons);

		return TRUE;
	}

	RegCloseKey(hKeyIcons);

	return FALSE;
}

BOOL CRegistryValue::GetCurrentName(CString strKeyName, CString strSubject, DWORD &dwValue)
{
	LONG	lRes;
	HKEY	hKeyIcons;
	CString	strKeyValue;

	strKeyValue.Format("Software\\%s", strKeyName);

	lRes = RegOpenKeyEx(HKEY_CURRENT_USER, strKeyValue, 0, 
		KEY_ALL_ACCESS, &hKeyIcons);

	if (lRes == ERROR_SUCCESS)
	{
		short	nShift;
		DWORD	i;
		DWORD	dwType, dwBytes;
		CString	strValue;
		unsigned char szBuffer[255]; // taken here the character string

		::RegQueryValueEx(hKeyIcons, strSubject, 0, &dwType, szBuffer, &dwBytes);
		
		nShift	= 0;
		dwValue	= 0;

		for (i = 0; i < dwBytes; i++)
		{
			dwValue	+= szBuffer[i] << nShift;
			nShift	+= 8;
		}

		RegCloseKey(hKeyIcons);

		return TRUE;
	}

	RegCloseKey(hKeyIcons);

	return FALSE;
}

BOOL CRegistryValue::SetCurrentName(CString strKeyName, CString strSubject, DWORD dwValue)
{
	LONG	lRes;
	HKEY	hKeyIcons;
	CString	strKeyValue;

	strKeyValue.Format("Software\\%s", strKeyName);

	lRes = RegOpenKeyEx(HKEY_CURRENT_USER, strKeyValue, 0, 
		KEY_ALL_ACCESS, &hKeyIcons);

	if (lRes == ERROR_SUCCESS)
	{
		DWORD	i;
		unsigned char szBuffer[255]; // taken here the character string

		i		= 0;

		while(dwValue)
		{
			szBuffer[i++]	= (BYTE)(dwValue & 0x000000FF);
			dwValue >>= 8;
		}

		::RegSetValueEx(hKeyIcons, strSubject, 0, REG_DWORD, szBuffer, i);

		RegCloseKey(hKeyIcons);

		return TRUE;
	}

	RegCloseKey(hKeyIcons);

	return FALSE;
}