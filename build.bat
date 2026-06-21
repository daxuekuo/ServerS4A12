@echo off
setlocal

set "DOTNET=dotnet"
if exist "%ProgramFiles%\dotnet\dotnet.exe" set "DOTNET=%ProgramFiles%\dotnet\dotnet.exe"

"%DOTNET%" build Server\DfoServer.sln -c Debug
if errorlevel 1 goto failed

echo.
echo Build succeeded.
echo Output: Server\DfoServer\bin\Debug\DfoServer.exe
echo You can also double-click StartServer.exe from the repository root.
pause
exit /b 0

:failed
echo.
echo Build failed. Please install the .NET SDK, then run build.bat again.
echo Download: https://aka.ms/dotnet-download
pause
exit /b 1