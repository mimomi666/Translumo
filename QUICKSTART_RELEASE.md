# Quick Start: Creating Your First Release

This guide will help you create the first release of Translumo with multimodal translation support.

> **📢 Important Update (2025-10-24)**: The v1.0.0 release had a packaging issue where required models and python directories were missing, causing the program to not run. This issue has been fixed in the current version. If you downloaded v1.0.0, please wait for a new release. See [RELEASE_FIX_SUMMARY.md](RELEASE_FIX_SUMMARY.md) for details.

## Option 1: Using GitHub Actions (Manual Trigger) ⚡ EASIEST

This is the easiest way to create a release without using command line:

1. **Go to GitHub Actions**
   - Navigate to: https://github.com/mimomi666/Translumo/actions
   - Or click the "Actions" tab in your repository

2. **Select the Release Workflow**
   - Click on "Build and Release" in the left sidebar
   - Click the "Run workflow" button (top right)

3. **Configure the Release**
   - Branch: Select the branch you want to release (usually `main`)
   - Version: Enter `1.0.2` (or your desired version)
   - Click "Run workflow"

4. **Wait for Completion**
   - The workflow will take 5-10 minutes to complete
   - It will build the application, download dependencies, and create a release
   - You'll see a green checkmark when done ✅

5. **Check Your Release**
   - Go to: https://github.com/mimomi666/Translumo/releases
   - You'll see your new release with the downloadable ZIP file!

## Option 2: Using Git Tags 🏷️

This method automatically creates a release when you push a version tag:

1. **Create and Push a Tag**
   ```bash
   git tag v1.0.2
   git push origin v1.0.2
   ```

2. **Automatic Release**
   - GitHub Actions will automatically detect the tag
   - It will build and create the release
   - Check the Actions tab to monitor progress

## What Gets Included in the Release?

The release package (`Translumo_1.0.2.zip`) will contain:

- ✅ `Translumo.exe` - Main application (self-contained, no .NET install needed)
- ✅ `models/` - OCR models for text recognition
- ✅ `python/` - Python runtime for EasyOCR
- ✅ `README.md` - Full documentation
- ✅ `LICENSE` - Apache 2.0 license
- ✅ `IMPLEMENTATION_SUMMARY.md` - Technical details

**Total size**: ~500-600 MB (fully self-contained, no dependencies needed)

## Testing Before Release

Want to test the build first? Use the Build Test workflow:

1. Go to Actions → "Build Test" → "Run workflow"
2. Download the artifact to test
3. Once verified, create the official release

## Release Notes

The release will automatically include:
- ✨ Feature highlights (multimodal translation)
- 📥 Download and installation instructions
- 📖 Quick start guides
- 🔗 Links to documentation
- ⚙️ System requirements

## Troubleshooting

### "Build failed" Error

If the build fails, check:
- The .NET 8 SDK is available (automatic on GitHub runners)
- The solution builds correctly (check PR.check.yml results)
- Dependencies can be downloaded (internet access)

### "Release already exists" Error

If you need to recreate a release:
1. Delete the existing release on GitHub
2. Delete the tag: `git push --delete origin v1.0.2`
3. Delete local tag: `git tag -d v1.0.2`
4. Create new tag and release

## Need Help?

- 📖 See [RELEASE_GUIDE.md](RELEASE_GUIDE.md) for detailed instructions
- 🐛 Check GitHub Actions logs for build errors
- 💬 Open an issue if you encounter problems

## Next Steps

After your first release:

1. **Share the link**: https://github.com/mimomi666/Translumo/releases/latest
2. **Test the download**: Download and verify the package works
3. **Update documentation**: Add any specific instructions for users
4. **Future releases**: Just update the version and repeat! 🚀

---

**Ready to create your first release?** Go to [Actions](https://github.com/mimomi666/Translumo/actions) and click "Build and Release"!
