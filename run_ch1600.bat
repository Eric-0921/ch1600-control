@echo off
chcp 65001 >nul
title CH-1600 Digital Gauss Meter

:: Activate conda base and run
call D:\anaconda3\Scripts\activate.bat D:\anaconda3

cd /d D:\git-zbw\m1600

echo CH-1600 Digital Gauss Meter Control
echo ===================================
echo Dependencies: PyQt5 5.15, pyserial 3.5, numpy, pyqtgraph 0.14
echo Conda env: D:\anaconda3
echo.

python main.py

if %errorlevel% neq 0 (
    echo.
    echo Program exited with error code %errorlevel%
    pause
)
