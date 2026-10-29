# Microsoft Developer Studio Project File - Name="CAMC_QI" - Package Owner=<4>
# Microsoft Developer Studio Generated Build File, Format Version 6.00
# ** DO NOT EDIT **

# TARGTYPE "Win32 (x86) Application" 0x0101

CFG=CAMC_QI - Win32 Debug
!MESSAGE This is not a valid makefile. To build this project using NMAKE,
!MESSAGE use the Export Makefile command and run
!MESSAGE 
!MESSAGE NMAKE /f "CAMC_QI.mak".
!MESSAGE 
!MESSAGE You can specify a configuration when running NMAKE
!MESSAGE by defining the macro CFG on the command line. For example:
!MESSAGE 
!MESSAGE NMAKE /f "CAMC_QI.mak" CFG="CAMC_QI - Win32 Debug"
!MESSAGE 
!MESSAGE Possible choices for configuration are:
!MESSAGE 
!MESSAGE "CAMC_QI - Win32 Release" (based on "Win32 (x86) Application")
!MESSAGE "CAMC_QI - Win32 Debug" (based on "Win32 (x86) Application")
!MESSAGE 

# Begin Project
# PROP AllowPerConfigDependencies 0
CPP=cl.exe
MTL=midl.exe
RSC=rc.exe

!IF  "$(CFG)" == "CAMC_QI - Win32 Release"

# PROP BASE Use_MFC 6
# PROP BASE Use_Debug_Libraries 0
# PROP BASE Output_Dir "Release"
# PROP BASE Intermediate_Dir "Release"
# PROP BASE Target_Dir ""
# PROP Use_MFC 6
# PROP Use_Debug_Libraries 0
# PROP Output_Dir "..\..\Executable\32Bit\CAMCQI\Release"
# PROP Intermediate_Dir "..\..\Executable\32Bit\CAMCQI\Release"
# PROP Ignore_Export_Lib 0
# PROP Target_Dir ""
# ADD BASE CPP /nologo /MD /W3 /GX /O2 /D "WIN32" /D "NDEBUG" /D "_WINDOWS" /D "_AFXDLL" /Yu"stdafx.h" /FD /c
# ADD CPP /nologo /MD /W3 /GX /O2 /D "WIN32" /D "NDEBUG" /D "_WINDOWS" /D "_AFXDLL" /D "_MBCS" /FR /Yu"stdafx.h" /FD /c
# ADD BASE MTL /nologo /D "NDEBUG" /mktyplib203 /win32
# ADD MTL /nologo /D "NDEBUG" /mktyplib203 /win32
# ADD BASE RSC /l 0x412 /d "NDEBUG" /d "_AFXDLL"
# ADD RSC /l 0x412 /d "NDEBUG" /d "_AFXDLL"
BSC32=bscmake.exe
# ADD BASE BSC32 /nologo
# ADD BSC32 /nologo
LINK32=link.exe
# ADD BASE LINK32 /nologo /subsystem:windows /machine:I386
# ADD LINK32 /nologo /subsystem:windows /machine:I386 /out:"../../Executable/32Bit/CAMC_QI.exe" /libpath:"./KGraph3D/Library/"

!ELSEIF  "$(CFG)" == "CAMC_QI - Win32 Debug"

# PROP BASE Use_MFC 6
# PROP BASE Use_Debug_Libraries 1
# PROP BASE Output_Dir "Debug"
# PROP BASE Intermediate_Dir "Debug"
# PROP BASE Target_Dir ""
# PROP Use_MFC 6
# PROP Use_Debug_Libraries 1
# PROP Output_Dir "..\..\Executable\32Bit\CAMCQI\Debug"
# PROP Intermediate_Dir "..\..\Executable\32Bit\CAMCQI\Debug"
# PROP Ignore_Export_Lib 0
# PROP Target_Dir ""
# ADD BASE CPP /nologo /MDd /W3 /Gm /GX /ZI /Od /D "WIN32" /D "_DEBUG" /D "_WINDOWS" /D "_AFXDLL" /Yu"stdafx.h" /FD /GZ /c
# ADD CPP /nologo /MDd /Gm /GX /ZI /Od /D "WIN32" /D "_DEBUG" /D "_WINDOWS" /D "_AFXDLL" /D "_MBCS" /FR /Yu"stdafx.h" /FD /GZ /c
# ADD BASE MTL /nologo /D "_DEBUG" /mktyplib203 /win32
# ADD MTL /nologo /D "_DEBUG" /mktyplib203 /win32
# ADD BASE RSC /l 0x412 /d "_DEBUG" /d "_AFXDLL"
# ADD RSC /l 0x412 /d "_DEBUG" /d "_AFXDLL"
BSC32=bscmake.exe
# ADD BASE BSC32 /nologo
# ADD BSC32 /nologo
LINK32=link.exe
# ADD BASE LINK32 /nologo /subsystem:windows /debug /machine:I386 /pdbtype:sept
# ADD LINK32 /nologo /subsystem:windows /debug /machine:I386 /out:"../../Executable/32Bit/CAMC_QID.exe" /pdbtype:sept /libpath:"./KGraph3D/Library/"

!ENDIF 

# Begin Target

# Name "CAMC_QI - Win32 Release"
# Name "CAMC_QI - Win32 Debug"
# Begin Group "Source Files"

# PROP Default_Filter "cpp;c;cxx;rc;def;r;odl;idl;hpj;bat"
# Begin Source File

SOURCE=.\CAMC_QI.cpp
# End Source File
# Begin Source File

SOURCE=.\CAMC_QI.rc
# End Source File
# Begin Source File

SOURCE=.\CAMC_QIDlg.cpp
# End Source File
# Begin Source File

SOURCE=.\CSGraph.cpp
# End Source File
# Begin Source File

SOURCE=.\CSXButton.cpp
# End Source File
# Begin Source File

SOURCE=.\CxStatic.cpp
# End Source File
# Begin Source File

SOURCE=.\EditEx.cpp
# End Source File
# Begin Source File

SOURCE=.\GL3DGraph.cpp
# End Source File
# Begin Source File

SOURCE=.\Led.cpp
# End Source File
# Begin Source File

SOURCE=.\ManualSet.cpp
# End Source File
# Begin Source File

SOURCE=.\OScopeCtrl.cpp
# End Source File
# Begin Source File

SOURCE=.\StautsView.cpp
# End Source File
# Begin Source File

SOURCE=.\StdAfx.cpp
# ADD CPP /Yc"stdafx.h"
# End Source File
# Begin Source File

SOURCE=.\xShadeButton.cpp
# End Source File
# End Group
# Begin Group "Header Files"

# PROP Default_Filter "h;hpp;hxx;hm;inl"
# Begin Source File

SOURCE=.\CAMC_QI.h
# End Source File
# Begin Source File

SOURCE=.\CAMC_QIDlg.h
# End Source File
# Begin Source File

SOURCE=.\CSGraph.h
# End Source File
# Begin Source File

SOURCE=.\CSXButton.h
# End Source File
# Begin Source File

SOURCE=.\CxStatic.h
# End Source File
# Begin Source File

SOURCE=.\EditEx.h
# End Source File
# Begin Source File

SOURCE=.\GL3DGraph.h
# End Source File
# Begin Source File

SOURCE=.\Led.h
# End Source File
# Begin Source File

SOURCE=.\ManualSet.h
# End Source File
# Begin Source File

SOURCE=.\OScopeCtrl.h
# End Source File
# Begin Source File

SOURCE=.\Resource.h
# End Source File
# Begin Source File

SOURCE=.\StautsView.h
# End Source File
# Begin Source File

SOURCE=.\StdAfx.h
# End Source File
# Begin Source File

SOURCE=.\xShadeButton.h
# End Source File
# End Group
# Begin Group "Resource Files"

# PROP Default_Filter "ico;cur;bmp;dlg;rc2;rct;bin;rgs;gif;jpg;jpeg;jpe"
# Begin Source File

SOURCE=.\res\ARW03DN.ICO
# End Source File
# Begin Source File

SOURCE=.\res\ARW03LT.ICO
# End Source File
# Begin Source File

SOURCE=.\res\ARW03RT.ICO
# End Source File
# Begin Source File

SOURCE=.\res\ARW03UP.ICO
# End Source File
# Begin Source File

SOURCE=.\res\bad.ico
# End Source File
# Begin Source File

SOURCE=.\res\CAMC_QI.ico
# End Source File
# Begin Source File

SOURCE=.\res\CAMC_QI.rc2
# End Source File
# Begin Source File

SOURCE=.\res\dopoint.ico
# End Source File
# Begin Source File

SOURCE=.\res\emark.ico
# End Source File
# Begin Source File

SOURCE=.\res\fit.ico
# End Source File
# Begin Source File

SOURCE=.\res\home.ico
# End Source File
# Begin Source File

SOURCE=.\res\motion.ico
# End Source File
# Begin Source File

SOURCE=.\res\npadb.ico
# End Source File
# Begin Source File

SOURCE=.\res\Radioactive.ico
# End Source File
# End Group
# Begin Source File

SOURCE=.\ReadMe.txt
# End Source File
# End Target
# End Project
# Section CAMC_QI : {E2A8647B-3676-432B-99B5-04944FB0D7F8}
# 	1:14:IDD_STATUSVIEW:103
# 	2:16:Resource Include:resource.h
# 	2:12:StautsView.h:StautsView.h
# 	2:10:ENUM: enum:enum
# 	2:14:IDD_STATUSVIEW:IDD_STATUSVIEW
# 	2:19:Application Include:CAMC_QI.h
# 	2:18:CLASS: CStautsView:CStautsView
# 	2:14:StautsView.cpp:StautsView.cpp
# End Section
# Section CAMC_QI : {7937AD3B-A556-4E36-8F5B-FEA8B87CF008}
# 	1:14:IDD_MANUAL_SET:104
# 	2:16:Resource Include:resource.h
# 	2:14:IDD_MANUAL_SET:IDD_MANUAL_SET
# 	2:13:ManualSet.cpp:ManualSet.cpp
# 	2:10:ENUM: enum:enum
# 	2:16:CLASS: ManualSet:ManualSet
# 	2:11:ManualSet.h:ManualSet.h
# 	2:19:Application Include:CAMC_QI.h
# End Section
# Section CAMC_QI : {47BB50BB-7764-49AF-B64A-7A3209694CC2}
# 	1:14:IDD_STATUSVIEW:104
# 	2:16:Resource Include:resource.h
# 	2:13:CLASS: lsByte:lsByte
# 	2:18:TYPEDEF: byte_bits:byte_bits
# 	2:18:TYPEDEF: word_bits:word_bits
# 	2:12:StautsView.h:StautsView.h
# 	2:15:TYPEDEF: lsByte:lsByte
# 	2:10:ENUM: enum:enum
# 	2:14:IDD_STATUSVIEW:IDD_STATUSVIEW
# 	2:16:CLASS: byte_bits:byte_bits
# 	2:19:Application Include:CAMC_QI.h
# 	2:18:CLASS: CStautsView:CStautsView
# 	2:14:StautsView.cpp:StautsView1.cpp
# 	2:16:CLASS: word_bits:word_bits
# End Section
