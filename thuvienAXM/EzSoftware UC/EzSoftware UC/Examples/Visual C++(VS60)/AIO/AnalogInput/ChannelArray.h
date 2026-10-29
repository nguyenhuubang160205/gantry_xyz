// ChannelArray.h: interface for the CChannelArray class.
//
//////////////////////////////////////////////////////////////////////

#if !defined(AFX_CHANNELARRAY_H__44A63FA3_031C_4A78_B01D_9F18FD34D895__INCLUDED_)
#define AFX_CHANNELARRAY_H__44A63FA3_031C_4A78_B01D_9F18FD34D895__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000


typedef struct 
{
	int				IChannelNum;			// Channel Num
	BOOL			BChannelChk;			// Channel Chk yes or no
} ChannelInfo;


typedef struct 
{
	int				ICboNum;			// ComboBox Num
	long			lModuleNum;			// Actual module Num 
	int				IChannelCount;		// Number of channels
	ChannelInfo*	channelInfo;		// Channel information
} ModuleInfo, *pModuleInfo;

class CChannelArray  
{
public:
	void GetFindModuleNo(int ICboNum, long *lModuleNo);
	ChannelInfo* GetFindChannel(int ICboNum, int IChannelNo);
	CChannelArray();
	virtual ~CChannelArray();
	CArray<pModuleInfo, pModuleInfo&> m_ModuleInfoList; 

};

#endif // !defined(AFX_CHANNELARRAY_H__44A63FA3_031C_4A78_B01D_9F18FD34D895__INCLUDED_)
