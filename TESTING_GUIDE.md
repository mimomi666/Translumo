# How to Test and Verify the Release Fix

## 问题已修复 | Issue Fixed

The release packaging issue has been fixed in the workflow. This document explains how to test and verify the fix.

发布打包问题已在工作流中修复。本文档解释如何测试和验证修复。

---

## Quick Test | 快速测试

### Step 1: Trigger a Test Build | 步骤 1：触发测试构建

1. Visit: https://github.com/mimomi666/Translumo/actions
2. Click "Build and Release" in the left sidebar
3. Click "Run workflow" button (top right)
4. Select branch: `copilot/fix-exe-launch-issues` (to test the fix)
5. Enter version: `1.0.1-test` (or any test version)
6. Click "Run workflow"

访问上述链接，选择 "Build and Release" 工作流，点击 "Run workflow"，选择分支 `copilot/fix-exe-launch-issues`，输入版本号 `1.0.1-test`，然后运行。

### Step 2: Monitor the Build | 步骤 2：监控构建

The workflow will take approximately 5-10 minutes. You'll see several steps:

工作流大约需要 5-10 分钟。您将看到几个步骤：

1. ✅ Checkout code
2. ✅ Setup .NET
3. ✅ Restore dependencies
4. ✅ Build application
5. ✅ **Download and extract components** ← New step that downloads models/python
6. ✅ Get version
7. ✅ **Create release package** ← Should show models and python being copied
8. ✅ Create Release
9. ✅ Upload build artifact

### Step 3: Check the Logs | 步骤 3：检查日志

Click on the running workflow to see detailed logs. Look for:

点击正在运行的工作流以查看详细日志。查找：

**In "Download and extract components" step:**
```
Downloading components from https://github.com/ramjke/Translumo/releases/download/v.0.8.5/_components_v.1.0.0.zip...
Extracting components...
Copying models to publish directory...
Copying tessdata models...
Copying easyocr models...
Copying prediction models...
Copying python runtime...
Components extracted and copied successfully.
```

**In "Create release package" step:**
```
Copying Translumo.exe...
Copying models directory...
Models directory contents:
[list of model files]
Copying python directory...
Python directory contents (first 20 files):
[list of python files]
Copying documentation files...
Creating release package...
Package created: Translumo_1.0.1-test.zip (Size: 500-600 MB)
```

**Important**: The package size should be ~500-600 MB, NOT ~110 MB.

**重要**：包大小应该约为 500-600 MB，而不是约 110 MB。

### Step 4: Download and Verify | 步骤 4：下载并验证

After the workflow completes:

工作流完成后：

1. **Option A - From Release Page:**
   - Go to: https://github.com/mimomi666/Translumo/releases
   - Find the test release (e.g., v1.0.1-test)
   - Download `Translumo_1.0.1-test.zip`

2. **Option B - From Artifacts:**
   - In the workflow run page, scroll down to "Artifacts"
   - Download `Translumo-1.0.1-test`

3. **Extract and verify structure:**
   ```
   Translumo_1.0.1-test/
   ├── Translumo.exe          (~294 MB)
   ├── models/
   │   ├── tessdata/          (5 .traineddata files)
   │   ├── easyocr/          (6 .pth files)
   │   └── prediction/       (5 model files)
   ├── python/               (50+ files)
   ├── README.md
   ├── LICENSE
   └── IMPLEMENTATION_SUMMARY.md
   ```

### Step 5: Test on Windows | 步骤 5：在 Windows 上测试

**Prerequisites 前提条件:**
- Windows 10 version 2004 or later, or Windows 11
- DirectX 11 compatible GPU

**Test the application 测试应用程序:**

1. Extract the zip to a folder
   解压 zip 到文件夹

2. Run `Translumo.exe`
   运行 `Translumo.exe`

3. The application should launch and show the main window
   应用程序应该启动并显示主窗口

4. Test basic functionality:
   测试基本功能：
   - Press **Alt+G** to open settings
   - Select source and target languages
   - Select **WindowsOCR** as OCR engine
   - Press **Alt+Q** to define capture area
   - Press **~** to start translation
   
5. If you see translation working, the fix is successful!
   如果看到翻译正常工作，说明修复成功！

---

## Expected Results | 预期结果

### ✅ Success Indicators | 成功标志

- [ ] Workflow completes without errors
      工作流完成无错误
- [ ] Package size is ~500-600 MB (compressed)
      包大小约 500-600 MB（压缩）
- [ ] Package contains models/ directory with 3 subdirectories
      包含带有 3 个子目录的 models/ 目录
- [ ] Package contains python/ directory with 50+ files
      包含带有 50+ 个文件的 python/ 目录
- [ ] Translumo.exe launches on Windows
      Translumo.exe 在 Windows 上启动
- [ ] OCR functionality works
      OCR 功能正常工作

### ❌ Failure Indicators | 失败标志

- [ ] Package size is still ~110 MB
      包大小仍然约 110 MB
- [ ] Missing models/ or python/ directories
      缺少 models/ 或 python/ 目录
- [ ] Translumo.exe doesn't launch (no window appears)
      Translumo.exe 不启动（没有窗口出现）
- [ ] Error messages about missing files
      关于缺少文件的错误消息

---

## After Successful Test | 测试成功后

Once you verify the fix works:

一旦验证修复有效：

1. **Merge the PR 合并 PR**
   - Merge the `copilot/fix-exe-launch-issues` branch to `main`/`master`
   
2. **Create Official Release 创建正式版本**
   - Go to Actions → "Build and Release" → "Run workflow"
   - Select branch: `main` (or `master`)
   - Enter version: `1.0.1`
   - This will create the official v1.0.1 release
   
3. **Delete/Archive v1.0.0 删除/归档 v1.0.0**
   - Go to: https://github.com/mimomi666/Translumo/releases
   - Edit v1.0.0 release
   - Either delete it or mark as "pre-release" and add a warning

4. **Update Documentation 更新文档**
   - Remove the warning notes from README.md once v1.0.1 is released
   - Keep RELEASE_FIX_SUMMARY.md for historical reference

---

## Troubleshooting | 故障排除

### Problem: Workflow fails at "Download and extract components"
**Solution**: The components URL might be temporarily unavailable. Try again in a few minutes.

### Problem: Package is still ~110 MB
**Possible causes**:
- Using wrong branch (make sure to use `copilot/fix-exe-launch-issues`)
- Workflow cache issue (try deleting the release and running again)

### Problem: Models directory is empty
**Check**: Review the workflow logs to see if the copy commands completed successfully

### Problem: Translumo.exe doesn't launch
**Check**:
1. Are you on Windows 10 version 2004 or later?
2. Do you have DirectX 11?
3. Check Windows Event Viewer for error details

---

## Contact | 联系方式

If you encounter issues during testing:

如果在测试期间遇到问题：

1. Check the workflow logs for detailed error messages
   检查工作流日志以获取详细的错误消息

2. Open an issue on GitHub with:
   在 GitHub 上开启一个 issue，包含：
   - Workflow run URL
   - Error messages from logs
   - Screenshots if applicable

3. Reference this PR: `copilot/fix-exe-launch-issues`

---

**Good luck with the testing! 祝测试顺利！**
