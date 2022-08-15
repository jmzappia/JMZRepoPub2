

@echo off

set OpenCoverConsoleWeb=https://github.com/OpenCover/opencover/releases
set ReportGeneratorWeb=https://github.com/danielpalme/ReportGenerator/releases
set NUnitConsoleWeb=https://github.com/nunit/nunit-console/releases/

set OpenCoverConsole=%LOCALAPPDATA%\Apps\OpenCover\OpenCover.Console.exe
set ReportGenerator=%LOCALAPPDATA%\Apps\ReportGenerator\ReportGenerator.exe
set NUnitConsole=C:\Program Files (x86)\NUnit.org\nunit-console\nunit3-console.exe

set ReportPath=CoverageReport

:: Check OpenCover location
if not exist "%OpenCoverConsole%" (
	echo "OpenCover is not found. Please install from %OpenCoverConsoleWeb% or check its location." 
	goto :eof
	)

:: ReportGenerator location
if not exist "%ReportGenerator%" (
	echo "ReportGenerator is not found. Please install from %ReportGeneratorWeb% or check its location."
	goto :eof
	)
	
:: NUnit location
if not exist "%NUnitConsole%" (
	echo "NUnitConsole is not found. Please install from %NUnitConsole% or check its location."
	goto :eof
	)

:: Perform code coverage test
mkdir %ReportPath%
%OpenCoverConsole% "-register:user" "-target:%NUnitConsole%" "-targetdir:..\XDatabaseTests\bin\Debug" "-targetargs:XDatabaseTests.dll"  "-output:.\%ReportPath%\TestsCodeCoverageResults.xml"
:: Build reports
%ReportGenerator% "-reports:.\%ReportPath%\TestsCodeCoverageResults.xml" "-filters:-XDatabaseTests*" "-targetdir:.\%ReportPath%" "-reporttypes:Html;Badges"
:: Open report
@start %cd%\%ReportPath%\index.htm
