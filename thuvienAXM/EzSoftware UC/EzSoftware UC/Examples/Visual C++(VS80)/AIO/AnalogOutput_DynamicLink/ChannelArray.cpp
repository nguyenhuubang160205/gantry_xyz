// ChannelArray.cpp: implementation of the CChannelArray class.
//
//////////////////////////////////////////////////////////////////////

#include "stdafx.h"
#include "ChannelArray.h"

#ifdef _DEBUG
#undef THIS_FILE
static char THIS_FILE[]=__FILE__;
#define new DEBUG_NEW
#endif

//////////////////////////////////////////////////////////////////////
// Construction/Destruction
//////////////////////////////////////////////////////////////////////

CChannelArray::CChannelArray()
{

}

CChannelArray::~CChannelArray()
{

}

ChannelInfo* CChannelArray::GetFindChannel(int ICboNum, int IChannelNo)
{
	for(int i=0; i < m_ModuleInfoList.GetSize(); i++)
	{
		pModuleInfo m_pModuleInfo = m_ModuleInfoList.GetAt(i);
		if(ICboNum == m_pModuleInfo->ICboNum)
		{
			//Channel retrieval
			ChannelInfo* channelInfo = m_pModuleInfo->channelInfo;
			for(int k=0; k < m_pModuleInfo->IChannelCount; k++)
			{
				if(channelInfo[k].IChannelNum == IChannelNo)
					return &channelInfo[k];

			}
		}
	}
	return NULL;
}


void CChannelArray::GetFindModuleNo(int ICboNum, long *lModuleNo)
{
	for(int i=0; i < m_ModuleInfoList.GetSize(); i++)
	{
		pModuleInfo m_pModuleInfo = m_ModuleInfoList.GetAt(i);
		if(ICboNum == m_pModuleInfo->ICboNum)
		{
			//Channel retrieval
			*lModuleNo = m_pModuleInfo->lModuleNum;
		}
	}
}
