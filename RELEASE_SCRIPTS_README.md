# 🚀 Translumo Release Scripts

This directory contains automated scripts to help you create releases for Translumo.

## Quick Start

Choose the method that works best for you:

### 1️⃣ Use the Automated Script (Easiest)

#### On Windows:
```cmd
create_release.bat
```

#### On Linux/Mac:
```bash
./create_release.sh
```

These scripts will:
- ✅ Create the v1.0.2 tag
- ✅ Push it to GitHub
- ✅ Automatically trigger the release workflow
- ✅ Guide you through any conflicts

---

### 2️⃣ Use GitHub Actions UI (No Command Line)

1. Go to: https://github.com/mimomi666/Translumo/actions/workflows/release.yml
2. Click **"Run workflow"**
3. Select branch: `master`
4. Enter version: `1.0.2`
5. Click **"Run workflow"**

---

### 3️⃣ Manual Git Commands

```bash
# Create and push the tag
git tag -a v1.0.2 -m "Release version 1.0.2 with multimodal translation support"
git push origin v1.0.2
```

---

## 📚 Documentation Files

- **HOW_TO_CREATE_RELEASE.md** - Complete guide (English)
- **HOW_TO_CREATE_RELEASE_CN.md** - 完整指南（中文）
- **RELEASE_GUIDE.md** - Detailed technical guide
- **RELEASE_PROCESS.md** - Process overview diagram
- **CREATING_RELEASE.md** - Comprehensive release documentation

## ⏱️ What Happens Next?

After triggering the release:

1. **GitHub Actions workflow starts** (5-10 minutes)
2. **Builds Windows application** with all dependencies
3. **Creates release package** (~500-600 MB ZIP file)
4. **Publishes to GitHub Releases** with auto-generated notes

Monitor progress: https://github.com/mimomi666/Translumo/actions

## 📦 Release Contents

The release will include:
- `Translumo.exe` - Self-contained Windows executable (~150MB)
- `models/` - OCR and ML models (~250MB)
- `python/` - Python runtime (~150MB)
- Documentation and license files

Total package size: ~500-600 MB

## ✅ Current Setup

- **Version**: 1.0.2 (from `src/Translumo/AssemblyInfo.cs`)
- **Workflow**: `.github/workflows/release.yml` (ready)
- **Status**: No existing tags - clean for first release

## 🆘 Need Help?

Check these files for more information:
- **Quick guides**: `QUICKSTART_RELEASE.md` | `QUICKSTART_RELEASE_CN.md`
- **Troubleshooting**: See "Troubleshooting" section in `HOW_TO_CREATE_RELEASE.md`
- **Technical details**: `RELEASE_GUIDE.md`

## 🎯 First Time Release

This is the **first release** for this fork with multimodal translation support. The infrastructure is fully tested and ready to go!

---

**Ready?** Just run `create_release.bat` (Windows) or `./create_release.sh` (Linux/Mac) to get started! 🎉
