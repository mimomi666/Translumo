# Release Guide for Translumo

This document describes how to create and publish releases for the Translumo project with multimodal translation support.

## Automated Release Process

### Method 1: Using Git Tags (Recommended)

This is the recommended method for creating releases:

1. **Update the version** in `src/Translumo/AssemblyInfo.cs`:
   ```csharp
   [assembly: AssemblyFileVersion("1.0.3")]
   [assembly: AssemblyInformationalVersion("1.0.3")]
   [assembly: AssemblyVersion("1.0.3")]
   ```

2. **Commit the version change**:
   ```bash
   git add src/Translumo/AssemblyInfo.cs
   git commit -m "Bump version to 1.0.3"
   git push
   ```

3. **Create and push a version tag**:
   ```bash
   git tag v1.0.3
   git push origin v1.0.3
   ```

4. **GitHub Actions will automatically**:
   - Build the application on Windows
   - Download required dependencies (~400MB)
   - Package everything into a zip file
   - Create a GitHub release with the package
   - Upload the release artifact

### Method 2: Manual Workflow Trigger

You can also manually trigger the release workflow from GitHub:

1. Go to the **Actions** tab in your repository
2. Select the **"Build and Release"** workflow
3. Click **"Run workflow"**
4. Enter the version number (e.g., `1.0.3`)
5. Click **"Run workflow"**

The workflow will build and create a release with the specified version.

## Release Contents

Each release package (`Translumo_X.X.X.zip`) includes:

- `Translumo.exe` - Main application (self-contained, ~150MB)
- `models/` - OCR models (Tesseract, EasyOCR)
- `python/` - Python runtime for EasyOCR
- `README.md` - Documentation
- `LICENSE` - Apache 2.0 license
- `IMPLEMENTATION_SUMMARY.md` - Technical details

## Version Numbering

Follow semantic versioning (MAJOR.MINOR.PATCH):

- **MAJOR**: Breaking changes or major new features
- **MINOR**: New features, backward compatible
- **PATCH**: Bug fixes, minor improvements

Current version: **1.0.2**

## Workflow Files

The project includes the following GitHub Actions workflows:

### 1. `release.yml` - Build and Release
- **Trigger**: Git tags (`v*`) or manual dispatch
- **Purpose**: Build and publish official releases
- **Output**: GitHub release with downloadable package
- **Runner**: Windows (required for WPF build)

### 2. `build-test.yml` - Build Test
- **Trigger**: Pull requests or manual dispatch
- **Purpose**: Test builds without creating releases
- **Output**: Build artifact (7-day retention)
- **Runner**: Windows

### 3. `PR.check.yml` - PR Check (existing)
- **Trigger**: Pull requests
- **Purpose**: Validate PR builds
- **Runner**: Windows

## Build Process Details

The build process consists of several steps:

1. **Restore Dependencies**: `dotnet restore Translumo.sln`
2. **Publish Application**: `dotnet publish` with:
   - Configuration: Release
   - Runtime: win-x64
   - Self-contained: true
   - Single file: true
3. **Download Binaries**: `binaries_extract.bat` downloads:
   - Python runtime (~150MB)
   - EasyOCR models (~100MB)
   - Tesseract models (~50MB)
   - ML prediction models (~100MB)
4. **Package**: Create zip with all files
5. **Release**: Upload to GitHub with release notes

## System Requirements for Building

- **OS**: Windows 10/11 (GitHub Actions runner)
- **.NET SDK**: 8.0.x
- **PowerShell**: For packaging scripts
- **Internet**: To download dependencies (~400MB)

## Testing a Release

Before creating an official release, you can test the build:

1. **Trigger the build-test workflow**:
   - Go to Actions → Build Test → Run workflow

2. **Download the artifact**:
   - After the workflow completes, download the artifact
   - Extract and test `Translumo.exe`

3. **Verify functionality**:
   - Test traditional translation (WindowsOCR + DeepL)
   - Test multimodal translation (with API key)
   - Check all settings and features

## Release Checklist

Before creating a new release:

- [ ] Update version in `AssemblyInfo.cs`
- [ ] Update README.md if there are new features
- [ ] Test the application locally (if possible on Windows)
- [ ] Review and update IMPLEMENTATION_SUMMARY.md
- [ ] Run build-test workflow to verify build
- [ ] Create and push version tag
- [ ] Verify release workflow completes successfully
- [ ] Download and test the release package
- [ ] Update release notes if needed

## Customizing Release Notes

The release workflow generates automatic release notes. To customize:

1. Edit `.github/workflows/release.yml`
2. Modify the `body` section in the "Create Release" step
3. Commit and push changes
4. New releases will use the updated template

## Troubleshooting

### Build Fails with "Binaries download failed"

The `binaries_extract.bat` script downloads dependencies from the original Translumo repository. If the download fails:

1. Check internet connectivity
2. Verify the download URL in `binaries_extract.bat`
3. Consider hosting the dependencies in your own fork

### Release Creation Fails

Common issues:

- **Tag already exists**: Delete the tag locally and remotely, then recreate
  ```bash
  git tag -d v1.0.2
  git push --delete origin v1.0.2
  ```
- **Permission issues**: Ensure the `GITHUB_TOKEN` has release permissions
- **Missing files**: Verify all files exist in the publish output

### Large Release Size

The release package is ~500-600MB due to:
- Self-contained .NET runtime (~100MB)
- Python runtime (~150MB)
- OCR models (~250MB)

This is expected for a fully self-contained Windows application.

## Manual Release Process (Alternative)

If you prefer to create releases manually:

1. **Build locally** (requires Windows with Visual Studio 2022):
   ```bash
   dotnet publish src/Translumo/Translumo.csproj -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true -o publish
   ```

2. **Run binaries_extract.bat**:
   ```bash
   binaries_extract.bat publish\
   ```

3. **Package files**:
   - Create a folder: `Translumo_1.0.X`
   - Copy: `publish\Translumo.exe`, `publish\models\`, `publish\python\`
   - Copy: `README.md`, `LICENSE`, `IMPLEMENTATION_SUMMARY.md`
   - Create zip: `Translumo_1.0.X.zip`

4. **Create release on GitHub**:
   - Go to Releases → Draft a new release
   - Create tag: `v1.0.X`
   - Upload the zip file
   - Add release notes
   - Publish release

## Support and Documentation

- **Repository**: https://github.com/mimomi666/Translumo
- **Original Project**: https://github.com/ramjke/Translumo
- **Documentation**: README.md
- **Issues**: Use GitHub Issues for bug reports

## License

Apache License 2.0 - See LICENSE file for details
