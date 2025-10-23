@echo off
REM Script to create and push a release tag for Translumo
REM This will automatically trigger the release workflow on GitHub

setlocal enabledelayedexpansion

echo.
echo ================================
echo    Translumo Release Creator
echo ================================
echo.

REM Get current version
set VERSION=1.0.2
set TAG=v%VERSION%

echo Version: %VERSION%
echo Tag: %TAG%
echo.

REM Check if we're in the right directory
if not exist "Translumo.sln" (
    echo [ERROR] This script must be run from the Translumo repository root
    pause
    exit /b 1
)

REM Check if tag already exists locally
git rev-parse %TAG% >nul 2>&1
if %errorlevel% equ 0 (
    echo [WARNING] Tag %TAG% already exists locally
    set /p confirm="Do you want to delete and recreate it? (y/N): "
    if /i "!confirm!"=="y" (
        git tag -d %TAG%
        echo [OK] Deleted local tag %TAG%
    ) else (
        echo [ABORTED]
        pause
        exit /b 1
    )
)

REM Check if tag exists on remote
git ls-remote --tags origin | findstr "refs/tags/%TAG%" >nul 2>&1
if %errorlevel% equ 0 (
    echo [WARNING] Tag %TAG% already exists on GitHub
    set /p confirm="Do you want to delete and recreate it? (y/N): "
    if /i "!confirm!"=="y" (
        git push --delete origin %TAG%
        echo [OK] Deleted remote tag %TAG%
    ) else (
        echo [ABORTED]
        pause
        exit /b 1
    )
)

REM Make sure we're up to date
echo.
echo Pulling latest changes...
git pull origin master 2>nul || git pull origin main 2>nul

REM Create the tag
echo.
echo Creating tag %TAG%...
git tag -a %TAG% -m "Release version %VERSION% with multimodal translation support"
if %errorlevel% neq 0 (
    echo [ERROR] Failed to create tag
    pause
    exit /b 1
)
echo [OK] Tag created

REM Push the tag
echo.
echo Pushing tag to GitHub...
git push origin %TAG%
if %errorlevel% neq 0 (
    echo [ERROR] Failed to push tag
    pause
    exit /b 1
)
echo [OK] Tag pushed

echo.
echo ================================
echo           SUCCESS!
echo ================================
echo.
echo Release workflow has been triggered.
echo.
echo Monitor the workflow at:
echo   https://github.com/mimomi666/Translumo/actions
echo.
echo Once complete, the release will be available at:
echo   https://github.com/mimomi666/Translumo/releases
echo.
echo Expected completion time: 5-10 minutes
echo.
pause
