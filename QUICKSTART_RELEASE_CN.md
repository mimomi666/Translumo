# 快速开始：创建第一个发布版本

本指南将帮助您创建带有多模态翻译支持的 Translumo 第一个发布版本。

## 方法 1：使用 GitHub Actions（手动触发）⚡ 最简单

这是创建发布版本最简单的方法，无需使用命令行：

1. **访问 GitHub Actions**
   - 导航到：https://github.com/mimomi666/Translumo/actions
   - 或点击仓库中的"Actions"标签

2. **选择发布工作流**
   - 在左侧边栏中点击"Build and Release"
   - 点击"Run workflow"按钮（右上角）

3. **配置发布**
   - Branch（分支）：选择要发布的分支（通常是 `main`）
   - Version（版本）：输入 `1.0.2`（或您想要的版本号）
   - 点击"Run workflow"

4. **等待完成**
   - 工作流将需要 5-10 分钟完成
   - 它将构建应用程序、下载依赖项并创建发布版本
   - 完成后您会看到绿色的对勾 ✅

5. **查看您的发布**
   - 访问：https://github.com/mimomi666/Translumo/releases
   - 您将看到新发布的版本和可下载的 ZIP 文件！

## 方法 2：使用 Git 标签 🏷️

此方法在推送版本标签时自动创建发布：

1. **创建并推送标签**
   ```bash
   git tag v1.0.2
   git push origin v1.0.2
   ```

2. **自动发布**
   - GitHub Actions 将自动检测标签
   - 它将构建并创建发布版本
   - 查看 Actions 标签以监控进度

## 发布版本包含什么？

发布包（`Translumo_1.0.2.zip`）将包含：

- ✅ `Translumo.exe` - 主应用程序（独立运行，无需安装 .NET）
- ✅ `models/` - 文本识别的 OCR 模型
- ✅ `python/` - EasyOCR 的 Python 运行时
- ✅ `README.md` - 完整文档
- ✅ `LICENSE` - Apache 2.0 许可证
- ✅ `IMPLEMENTATION_SUMMARY.md` - 技术细节

**总大小**：约 500-600 MB（完全独立，无需额外依赖）

## 发布前测试

想先测试构建吗？使用 Build Test 工作流：

1. 访问 Actions → "Build Test" → "Run workflow"
2. 下载构建产物进行测试
3. 验证后，创建正式发布版本

## 发布说明

发布版本将自动包含：
- ✨ 功能亮点（多模态翻译）
- 📥 下载和安装说明
- 📖 快速入门指南
- 🔗 文档链接
- ⚙️ 系统要求

## 故障排除

### "构建失败"错误

如果构建失败，请检查：
- .NET 8 SDK 可用（GitHub runner 上自动可用）
- 解决方案正确构建（检查 PR.check.yml 结果）
- 可以下载依赖项（互联网访问）

### "发布已存在"错误

如果需要重新创建发布：
1. 在 GitHub 上删除现有发布
2. 删除标签：`git push --delete origin v1.0.2`
3. 删除本地标签：`git tag -d v1.0.2`
4. 创建新标签和发布

## 需要帮助？

- 📖 查看 [RELEASE_GUIDE.md](RELEASE_GUIDE.md) 获取详细说明
- 🐛 检查 GitHub Actions 日志查看构建错误
- 💬 如遇到问题请开启 issue

## 后续步骤

创建第一个发布后：

1. **分享链接**：https://github.com/mimomi666/Translumo/releases/latest
2. **测试下载**：下载并验证包是否正常工作
3. **更新文档**：为用户添加任何特定说明
4. **未来发布**：只需更新版本号并重复！🚀

## 使用说明

用户下载发布包后的使用步骤：

### 基础安装
1. 下载 `Translumo_1.0.2.zip`
2. 解压到任意文件夹
3. 运行 `Translumo.exe`

### 传统翻译（免费）
1. 按 **Alt+G** 打开设置
2. 选择源语言和目标语言
3. 选择 **WindowsOCR** 作为 OCR 引擎
4. 选择 **DeepL** 或 **Google** 作为翻译器
5. 按 **Alt+Q** 定义捕获区域
6. 按 **~** 开始翻译

### 多模态翻译（AI 驱动）
1. 按 **Alt+G** 打开设置
2. 转到 **Languages（语言）** 选项卡
3. 选择 **Multimodal（多模态）** 作为翻译器
4. 输入您的 API 密钥（OpenAI、Azure 或兼容服务）
5. 自定义提示词以指定目标语言
6. 按 **Alt+Q** 定义捕获区域
7. 按 **~** 开始翻译

## 系统要求

- Windows 10 版本 2004（内部版本 19041）或更高版本，或 Windows 11
- DirectX 11 兼容 GPU
- 2 GB RAM（EasyOCR 需要 8 GB）
- .NET 8 运行时（包含在独立包中）

## 重要提示

- 首次启动可能需要较长时间，因为需要初始化依赖项
- 对于多模态翻译，确保您有有效的 API 密钥和足够的额度
- 包大小较大（~500MB）是因为包含了所有依赖项，用户无需额外安装任何东西

---

**准备创建第一个发布了吗？** 访问 [Actions](https://github.com/mimomi666/Translumo/actions) 并点击"Build and Release"！
