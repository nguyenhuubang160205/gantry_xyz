@echo off

for /f "tokens=4-5 delims=. " %%i in ('ver') do set VERSION=%%i.%%j
IF "%version%" == "10.0" (
    IF EXIST "%PROGRAMFILES(X86)%" (
        @ECHO "Register environment variables"
        goto Win10install
    ) ELSE (
        @ECHO "Register environment variables"
        goto Win10install
    )
) ELSE (
    IF EXIST "%PROGRAMFILES(X86)%" (
        @ECHO "Register environment variables"
        goto Win7install
    ) ELSE (
        @ECHO "Register environment variables"
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
echo.
) else (
powershell -Command "& { $GENICAM_PATH = '%CD%\genicam'.replace('\\','\'); $GENICAM_BIN_PATH = '%CD%\genicam\bin\Win32_i86'.replace('\\','\'); $OLD_PATH = [System.Environment]::GetEnvironmentVariable('PATH','machine'); $NEW_PATH = \"$GENICAM_BIN_PATH;$OLD_PATH\"; [System.Environment]::SetEnvironmentVariable('FNIO_GENICAM_ROOT_V2_4', $GENICAM_PATH, 'machine');[System.Environment]::SetEnvironmentVariable('PATH',$NEW_PATH,'machine');}"
)

