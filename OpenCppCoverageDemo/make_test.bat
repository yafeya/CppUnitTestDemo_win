if exist TestResults RMDIR /S /Q TestResults

Debug\x64\UnitTestConsole.exe --gtest_output=xml:TestResults\xunit_report.xml

vstest.console.exe "Debug\x64\UnitTestConsole.exe" /EnableCodeCoverage /Platform:x64 /TestAdapterPath:"C:\Program Files (x86)\Microsoft Visual Studio\2017\Enterprise\Common7\IDE\Extensions\tmbsyf1p.5mu"

setlocal enableextensions disabledelayedexpansion

set "covrpt="
FOR /F "delims=" %%i IN ('dir /b /ad-h /t:c /od "TestResults"') DO SET covdir=%%i
echo Most recent subfolder: %covdir%

for /f "delims=" %%a in ('dir /b /o-d "TestResults\%covdir%\*.coverage" 2^>nul') do (
        if not defined covrpt set "covrpt=%%a"
    )

echo %covrpt%

cd TestResults
CodeCoverage.exe analyze /output:coverage_report.xml "%covdir%\%covrpt%"