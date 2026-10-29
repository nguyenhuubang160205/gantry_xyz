@echo for Windows 2000/XP/Server 2003/Vista/7

copy /y Axt*32Bit.sys "%WINDIR%\System32\Drivers\" 

devcon dp_add AXTCOM_INST_DRV.inf
wdregX86.exe -inf AXTBUS_INST_DRV.inf -compat install

@echo Now install...
@echo Please any key press...
