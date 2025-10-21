# Release Process Overview

```
┌─────────────────────────────────────────────────────────────────────┐
│                     How to Create a Release                         │
└─────────────────────────────────────────────────────────────────────┘

Method 1: Manual Workflow Trigger (Easiest) 🎯
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

 GitHub → Actions → "Build and Release" → "Run workflow"
                                              ↓
                                    Enter version: 1.0.2
                                              ↓
                                         Click "Run"
                                              ↓
                              [GitHub Actions Workflow Starts]
                                              ↓
        ┌─────────────────────────────────────────────────────────┐
        │  1. Checkout code                                       │
        │  2. Setup .NET 8 SDK                                    │
        │  3. Restore dependencies                                │
        │  4. Build & Publish (win-x64, self-contained)          │
        │  5. Run binaries_extract.bat (~400MB download)         │
        │  6. Package everything into ZIP (~500-600MB)           │
        │  7. Create GitHub Release with detailed notes          │
        │  8. Upload release package                             │
        └─────────────────────────────────────────────────────────┘
                                              ↓
                                    ✅ Release Created!
                                              ↓
                    https://github.com/mimomi666/Translumo/releases


Method 2: Git Tag (Automatic) 🏷️
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

 Local Machine:
   $ git tag v1.0.2
   $ git push origin v1.0.2
           ↓
   [Automatically triggers workflow]
           ↓
   Same process as Method 1
           ↓
   ✅ Release Created!


━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
Release Package Contents
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

Translumo_1.0.2.zip
├── Translumo.exe                    (~150 MB) - Main app + .NET runtime
├── models/
│   ├── tessdata/                   (~50 MB)  - Tesseract models
│   ├── easyocr/                    (~100 MB) - EasyOCR models
│   └── prediction/                 (~100 MB) - ML models
├── python/                         (~150 MB) - Python runtime
├── README.md                       - Documentation
├── LICENSE                         - Apache 2.0
└── IMPLEMENTATION_SUMMARY.md       - Technical details

Total Size: ~500-600 MB (fully self-contained)


━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
User Download Experience
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

User visits: https://github.com/mimomi666/Translumo/releases
           ↓
Downloads: Translumo_1.0.2.zip
           ↓
Extracts to folder
           ↓
Runs: Translumo.exe
           ↓
✅ Works immediately!
   - No .NET installation needed
   - No Python installation needed
   - No OCR models to download
   - Everything is included


━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
Workflow Files
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

.github/workflows/
├── release.yml           → Creates official releases
├── build-test.yml        → Tests builds without releasing
└── PR.check.yml          → Validates pull requests


━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
Documentation
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

📖 QUICKSTART_RELEASE.md        → Simple guide (English)
📖 QUICKSTART_RELEASE_CN.md     → 快速指南（中文）
📖 RELEASE_GUIDE.md              → Comprehensive documentation
📖 README.md                     → Updated with release info


━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
Build Time & Resources
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

⏱️  Build Time:        5-10 minutes
💻 Runner:            windows-latest (GitHub-hosted)
🌐 Network Download:  ~400 MB (dependencies)
📦 Upload Size:       ~500-600 MB (release package)
💰 Cost:              Free (GitHub Actions included minutes)


━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
Version Management
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

Current Version: 1.0.2 (defined in src/Translumo/AssemblyInfo.cs)

To update version:
  1. Edit src/Translumo/AssemblyInfo.cs
  2. Change all version attributes to new version
  3. Commit the change
  4. Create release with new version


━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
✅ Ready to Use!
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

Everything is set up and ready. Just go to Actions and run the workflow!
```
