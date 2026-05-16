#!/bin/bash
# CH-1600 Digital Gauss Meter Control - Bash Launcher
set -e

PROJECT_DIR="D:/git-zbw/m1600"
CONDA_BASE="D:/anaconda3"

echo "========================================"
echo "  CH-1600 Digital Gauss Meter Control"
echo "  PyQt5 5.15 | pyserial 3.5 | pyqtgraph 0.14"
echo "  Conda: $CONDA_BASE"
echo "========================================"
echo ""

cd "$PROJECT_DIR"
source "$CONDA_BASE/Scripts/activate" "$CONDA_BASE"
python main.py
