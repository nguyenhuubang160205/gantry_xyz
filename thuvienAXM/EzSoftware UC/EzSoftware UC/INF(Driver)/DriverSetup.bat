@echo off
setlocal

for /f "tokens=4-5 delims=. " %%i in ('ver') do set VERSION=%%i.%%j
IF "%version%" == "10.0" (
    cd Win10
    IF EXIST "%PROGRAMFILES(X86)%" (
        @ECHO "This is Win10 64bit"
        .\InstallX64.bat
    ) ELSE (
        @ECHO "This is Win10 32bit"
        .\InstallX86.bat
    )
) ELSE (
    cd Win7
    IF EXIST "%PROGRAMFILES(X86)%" (
        @ECHO "This is Win7 64bit"
        .\InstallX64.bat
    ) ELSE (
        @ECHO "This is Win7 32bit"
        .\InstallX86.bat
    )
)

set /p str = Please Press Enter key ...
endlocal