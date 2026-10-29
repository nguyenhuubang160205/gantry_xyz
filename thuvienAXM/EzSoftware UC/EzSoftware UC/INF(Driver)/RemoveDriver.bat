@echo off
setlocal
for /f "tokens=4-5 delims=. " %%i in ('ver') do set VERSION=%%i.%%j
IF "%version%" == "10.0" (
    cd Win10
    IF EXIST "%PROGRAMFILES(X86)%" (
        @ECHO "This is Win10 64bit"
        .\RemoveX64.bat
    ) ELSE (
        @ECHO "This is Win10 32bit"
        .\RemoveX86.bat
    )
) ELSE (
    cd Win7
    IF EXIST "%PROGRAMFILES(X86)%" (
        @ECHO "This is Win7 64bit"
        .\RemoveX64.bat
    ) ELSE (
        @ECHO "This is Win7 32bit"
        .\RemoveX86.bat
    )
)
endlocal