@echo off

for /f "tokens=4-5 delims=. " %%i in ('ver') do set VERSION=%%i.%%j
IF "%version%" == "10.0" (
    IF EXIST "%PROGRAMFILES(X86)%" (
        @ECHO "Delete Environment Variables"
        goto Win10install
    ) ELSE (
        @ECHO "Delete Environment Variables"
        goto Win10install
    )
) ELSE (
    IF EXIST "%PROGRAMFILES(X86)%" (
        @ECHO "Delete Environment Variables"
        goto Win7install
    ) ELSE (
        @ECHO "Delete Environment Variables"
        goto Win7install
    )
)

:Win10install
:: BatchGotAdmin :------------------------------------- 
REM --> Check for permissions 
>nul 2>&1 "%SYSTEMROOT%\system32\cacls.exe" "%SYSTEMROOT%\system32\config\system" 
REM --> If error flag set, we do not have admin. 
if '%errorlevel%' NEQ '0' ( 
	echo Requesting administrative privileges... 
	goto UACPrompt 
) else ( goto gotAdmin ) 

:UACPrompt 
	echo Set UAC = CreateObject^("Shell.Application"^) > "%temp%\getadmin.vbs" 
	set params = %*:"="" 
	echo UAC.ShellExecute "cmd.exe", "/c %~s0 %params%", "", "runas", 1 >> "%temp%\getadmin.vbs" 

	"%temp%\getadmin.vbs" 
	del "%temp%\getadmin.vbs" 
	exit /B 

:gotAdmin 
	pushd "%CD%" 
	CD /D "%~dp0"
:--------------------------------------

:Win7install
if exist "%FNIO_GENICAM_ROOT_V2_4%" (
powershell -Command "& { $GENICAM_PATH = [System.Environment]::GetEnvironmentVariable('FNIO_GENICAM_ROOT_V2_4','machine'); $GENICAM_BIN_PATH = $GENICAM_PATH + '\bin\Win32_i86;'; $NEW_PATH = [System.Environment]::GetEnvironmentVariable('PATH','machine').replace($GENICAM_BIN_PATH, ''); [System.Environment]::SetEnvironmentVariable('PATH',$NEW_PATH,'machine'); [System.Environment]::SetEnvironmentVariable('FNIO_GENICAM_ROOT_V2_4', '', 'machine'); }"
) else (
echo.
)


