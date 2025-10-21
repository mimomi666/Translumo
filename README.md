[![License](https://img.shields.io/badge/License-Apache_2.0-blue.svg)](https://opensource.org/licenses/Apache-2.0)
[![Github All Releases](https://img.shields.io/github/downloads/ramjke/Translumo/total.svg)]()

<p align="center">
  <img width="670" src="https://github.com/ramjke/Translumo/assets/29047281/8985049f-ea1c-428e-94be-042ece66cb54">
</p>
  <h2 align="center" style="border: 0">Advanced Real-Time Screen Translator</h2>

<p align="center"><strong>English</strong> | <a href="docs/README-RU.md"><strong>Русский</strong></a></p>

## 🔥 Fork Notice | 分支说明

This is a **fork** of the original [Translumo repository](https://github.com/ramjke/Translumo) with **enhanced multimodal translation capabilities**.

**Original Repository**: https://github.com/ramjke/Translumo

### ✨ What's New in This Fork | 本分支的新功能

This fork adds **Multimodal AI Translation** support, allowing Translumo to use advanced AI models (GPT-4o, GPT-4 Vision, Claude 3, etc.) to translate images directly without OCR. This provides:

- **Higher accuracy** for complex layouts and stylized text
- **Direct image translation** without OCR preprocessing
- **Support for any OpenAI-compatible vision API**
- **Customizable prompts** for better translation control

本分支新增了**多模态 AI 翻译**支持，允许 Translumo 使用先进的 AI 模型（GPT-4o、GPT-4 Vision、Claude 3 等）直接翻译图像，无需 OCR。这带来了：

- **更高的准确性**，特别是对于复杂布局和风格化文本
- **直接图像翻译**，无需 OCR 预处理
- **支持任何 OpenAI 兼容的视觉 API**
- **可自定义提示词**，更好地控制翻译效果

📖 **See the [Multimodal Translation Tutorial](#multimodal-translation-tutorial) below for setup and usage guide.**

📖 **查看下方的[多模态翻译教程](#multimodal-translation-tutorial)了解设置和使用指南。**


## Download Translumo

### 🎉 Download This Fork with Multimodal Translation

**Latest release with multimodal support:**  
👉 **[Download from Releases](https://github.com/mimomi666/Translumo/releases/latest)**

After downloading, unzip the archive and run `Translumo.exe`.

This fork includes all features from the original Translumo v1.0.2 plus **multimodal AI translation** support.

### Download Original Version

If you prefer the original version without multimodal features:  
[Translumo_1.0.2.zip](https://github.com/ramjke/Translumo/releases/download/v.1.0.2/Translumo_1.0.2.zip) (Original repository) 

## Main Features

- **High text recognition precision**  
  Translumo allows combining multiple OCR engines simultaneously. It uses a machine learning model to score each OCR result and selects the best one.  

  <p align="center">
    <img width="740" src="https://github.com/ramjke/Translumo/assets/29047281/649e5fab-a5de-4c54-a3d8-f7ea95b8f218">
  </p>

- **Game oriented**  
  Designed for real-time translation in PC games, but works anywhere on the screen with any application.

- **Low latency**  
  Several optimizations reduce system impact and minimize latency between text appearance and translation.

- **Integrated modern OCR engines**: Windows OCR (recommended), Tesseract 5.2 (legacy), EasyOCR (legacy)

- **Available translators**: DeepL (recommended), Google Translate, Yandex Translate, Naver Papago.

- **Supported recognition languages**: English, Russian, Japanese, Chinese (Simplified), Korean.

- **Supported translation languages**: English, Russian, Japanese, Chinese (Simplified), Korean, French, Spanish, German, Portuguese, Italian, Vietnamese, Thai, Turkish, Arabic, Greek, Brazilian Portuguese, Polish, Belarusian, Persian, Indonesian, Bulgarian, Czech, Danish, Estonian, Finnish, Hungarian, Lithuanian, Latvian, Dutch, Romanian, Slovak, Slovenian, Swedish, Ukrainian.

## System Requirements

### Minimal requirements to use Tesseract and Windows OCR
- Windows 10 version 2004 (build 19041) or later, or Windows 11
- DirectX 11 compatible GPU
- 2 GB RAM

### Minimal requirements to use EasyOCR
- NVIDIA GPU with CUDA SDK 11.8 support (GTX 750, 8xxM, 9xx series or newer)
- 8 GB RAM
- At least 5 GB of free storage space

## How to Use

![Preview](https://github.com/ramjke/Translumo/blob/7f4a73ffba0e5a0090ea0bfc3d72acb99832a0f4/docs/preview-EN.gif)

1. Open the Settings (**Alt+G**)
2. Select languages: source language for OCR and translation language
3. Select text recognition engines (see Usage Tips for recommended modes)
4. Define the capture area: press **Alt+Q** and select an area on the screen
5. Run translation (press **~**)

### Recommended OCR Engines

- It is recommended to use **WindowsOCR** only.

Tesseract is old, slow, and produces many errors.  
EasyOCR is even slower, requires significant resources (including a specific GPU), and often leads to bugs.  

It’s probably better to remove all other OCR engines and keep only WindowsOCR, but they are still included in Translumo for historical reasons.

### Select Minimum Capture Area
Reducing the capture area decreases the chance of picking up random letters from the background. Larger frames take longer to process.

### Use Proxy List to Avoid Blocking by Translation Services
Some translators may block clients sending many requests. Configure personal or shared IPv4 proxies (1-2 is usually enough) under **Languages → Proxy tab**. The app will alternate proxies to reduce requests from a single IP.

### Use Borderless or Windowed Modes in Games (Not Fullscreen)
These modes are required for correct translation overlay display. If your game does not support them, use tools like [Borderless Gaming](https://github.com/Codeusa/Borderless-Gaming).

## FAQ

**Q: I get "Failed to capture screen" or nothing happens after translation starts**  
A: Ensure the target window is active. Restart Translumo or reopen the target window if needed.

**Q: Borderless/windowed mode is set, but the translation window is under the game**  
A: With the game running and focused, press the hotkey (**Alt+T** by default) to hide and show the translation window.

**Q: EasyOCR package download failed**  
A: Try reinstalling while connected to a VPN.

**Q: Hotkeys don't work**  
A: Other applications may be intercepting hotkeys.

**Q: Text detection failed (TesseractOCREngine)**  
A: Ensure the application path contains only Latin letters.

## Multimodal Translation Tutorial

### 🌟 What is Multimodal Translation? | 什么是多模态翻译？

Multimodal translation uses AI models with vision capabilities (like GPT-4o, GPT-4 Vision, Claude 3) to translate text directly from images, bypassing traditional OCR entirely. This results in:

- Better handling of stylized fonts and complex layouts
- More accurate translations with context awareness
- Support for vertical text, overlapping text, and decorative elements
- Direct translation without text extraction errors

多模态翻译使用具有视觉能力的 AI 模型（如 GPT-4o、GPT-4 Vision、Claude 3）直接从图像翻译文本，完全绕过传统 OCR。这带来了：

- 更好地处理风格化字体和复杂布局
- 具有上下文感知的更准确翻译
- 支持竖排文本、重叠文本和装饰元素
- 无需文本提取错误的直接翻译

### 📋 Prerequisites | 前置要求

1. **API Key**: You need an API key from one of the supported services:
   - OpenAI (GPT-4o, GPT-4 Vision) - https://platform.openai.com/api-keys
   - Azure OpenAI with vision models
   - Any OpenAI-compatible API service with vision support

2. **API Credits**: Ensure your account has sufficient credits (multimodal calls cost more than text-only)

1. **API 密钥**：您需要来自以下支持服务之一的 API 密钥：
   - OpenAI (GPT-4o、GPT-4 Vision) - https://platform.openai.com/api-keys
   - 带有视觉模型的 Azure OpenAI
   - 任何支持视觉的 OpenAI 兼容 API 服务

2. **API 额度**：确保您的账户有足够的额度（多模态调用比纯文本调用更昂贵）

### 🚀 Step-by-Step Setup Guide | 分步设置指南

#### Step 1: Open Settings | 第 1 步：打开设置

Press **Alt+G** to open the Translumo settings window.

按 **Alt+G** 打开 Translumo 设置窗口。

#### Step 2: Select Multimodal Translator | 第 2 步：选择多模态翻译器

1. Navigate to the **Languages** tab
2. In the **Translator** dropdown, select **Multimodal**
3. A new configuration panel will appear with four fields

1. 转到 **Languages（语言）** 选项卡
2. 在 **Translator（翻译器）** 下拉菜单中，选择 **Multimodal（多模态）**
3. 将出现一个包含四个字段的新配置面板

#### Step 3: Configure API Settings | 第 3 步：配置 API 设置

**For OpenAI (Recommended) | 使用 OpenAI（推荐）：**

- **Base URL**: `https://api.openai.com/v1/chat/completions` (default, no change needed)
- **API Key**: Enter your OpenAI API key (starts with `sk-...`)
- **Model Name**: `gpt-4o` (recommended) or `gpt-4-vision-preview`
- **Prompt**: Customize based on your target language (see examples below)

**For Azure OpenAI | 使用 Azure OpenAI：**

- **Base URL**: `https://<your-resource>.openai.azure.com/openai/deployments/<deployment-name>/chat/completions?api-version=2024-02-15-preview`
- **API Key**: Your Azure OpenAI API key
- **Model Name**: Your deployment name
- **Prompt**: Customize based on your target language

**For Other Compatible APIs | 使用其他兼容 API：**

- **Base URL**: Your service's chat completions endpoint
- **API Key**: Your service's API key
- **Model Name**: Check your service's documentation
- **Prompt**: Customize based on your target language

#### Step 4: Customize the Prompt | 第 4 步：自定义提示词

The prompt tells the AI model what to do with the image. Here are examples for different languages:

提示词告诉 AI 模型如何处理图像。以下是不同语言的示例：

**English to Chinese | 英译中：**
```
Translate all text in this image to Chinese. Only output the translated text, no explanations.
```

**Japanese to English | 日译英：**
```
Translate all Japanese text in this image to English. Only output the translated text, no explanations.
```

**Chinese to English | 中译英：**
```
Translate all Chinese text in this image to English. Only output the translated text, no explanations.
```

**Korean to Chinese | 韩译中：**
```
Translate all Korean text in this image to Chinese. Only output the translated text, no explanations.
```

**With Formatting Preservation | 保持格式：**
```
Translate all text in this image to Chinese. Maintain the original line breaks and formatting. Only output the translated text.
```

**With Context Explanation | 包含上下文解释：**
```
Translate all text in this image to English and briefly explain any cultural references or context.
```

#### Step 5: Select Source Language | 第 5 步：选择源语言

Even though multimodal translation doesn't use OCR, you should still select the **Source Language** that matches your content for proper handling.

即使多模态翻译不使用 OCR，您仍应选择与内容匹配的**源语言**以便正确处理。

#### Step 6: Define Capture Area | 第 6 步：定义捕获区域

1. Press **Alt+Q**
2. Click and drag to select the area you want to translate
3. **Tip**: Smaller capture areas = lower API costs and faster processing

1. 按 **Alt+Q**
2. 点击并拖动以选择要翻译的区域
3. **提示**：较小的捕获区域 = 更低的 API 成本和更快的处理速度

#### Step 7: Start Translation | 第 7 步：开始翻译

Press **~** (tilde key) to start the translation. The captured image will be sent to the multimodal API, and the translation will appear in the overlay window.

按 **~**（波浪号键）开始翻译。捕获的图像将被发送到多模态 API，翻译结果将显示在覆盖窗口中。

### 💡 Tips and Best Practices | 提示和最佳实践

1. **Start with Small Areas**: Test with small capture areas first to verify your setup and minimize costs
   
   **从小区域开始**：首先使用小的捕获区域进行测试，以验证设置并降低成本

2. **Optimize Prompts**: Experiment with different prompts to get better results for your specific use case
   
   **优化提示词**：尝试不同的提示词，为您的特定用例获得更好的结果

3. **Use Proxy if Needed**: If you experience rate limiting, configure proxies under **Languages → Proxy tab**
   
   **必要时使用代理**：如果遇到速率限制，请在 **Languages → Proxy** 选项卡下配置代理

4. **Monitor API Usage**: Keep track of your API usage and costs through your provider's dashboard
   
   **监控 API 使用情况**：通过提供商的仪表板跟踪您的 API 使用情况和成本

5. **Fallback Option**: Keep traditional translators (like DeepL) configured so you can switch when needed
   
   **备用选项**：保持传统翻译器（如 DeepL）配置，以便在需要时切换

### ⚙️ Advanced Configuration | 高级配置

**Using Local Models | 使用本地模型：**

If you're running a local vision model (e.g., through LM Studio or LocalAI):

如果您正在运行本地视觉模型（例如通过 LM Studio 或 LocalAI）：

- **Base URL**: `http://localhost:1234/v1/chat/completions` (or your local server URL)
- **API Key**: May not be required (use `none` or any value)
- **Model Name**: Your local model name
- **Prompt**: Standard translation prompt

**Custom Model Parameters | 自定义模型参数：**

Currently, the implementation uses default parameters. If you need custom parameters (temperature, max_tokens, etc.), you may need to modify the API endpoint or use a proxy service that allows parameter injection.

当前实现使用默认参数。如果需要自定义参数（temperature、max_tokens 等），您可能需要修改 API 端点或使用允许参数注入的代理服务。

### 🔧 Troubleshooting | 故障排除

**Problem: "Multimodal API error: Unauthorized"**
- Solution: Check that your API key is correct and has not expired
- 解决方案：检查您的 API 密钥是否正确且未过期

**Problem: "Multimodal API error: Model not found"**
- Solution: Verify the model name is correct for your service
- 解决方案：验证模型名称对您的服务是否正确

**Problem: No translation appears**
- Solution: Check your internet connection, API credits, and console logs for detailed errors
- 解决方案：检查您的互联网连接、API 额度和控制台日志以获取详细错误

**Problem: Translation is too slow**
- Solution: Use smaller capture areas, or switch to a faster model (e.g., gpt-4o-mini if available)
- 解决方案：使用较小的捕获区域，或切换到更快的模型（例如 gpt-4o-mini，如果可用）

**Problem: High API costs**
- Solution: Use traditional OCR+translation for bulk content, reserve multimodal for difficult text
- 解决方案：对于大量内容使用传统的 OCR+翻译，为困难文本保留多模态翻译

### 📊 Cost Comparison | 成本比较

**Traditional Translation (OCR + DeepL/Google):**
- Nearly free for unlimited use
- 几乎免费无限使用

**Multimodal Translation (GPT-4o):**
- ~$0.002-0.01 per image (varies by image size and model)
- 每张图片约 $0.002-0.01（因图片大小和模型而异）

**Recommendation**: Use multimodal translation for challenging content where OCR fails, and traditional translation for regular text.

**建议**：对 OCR 失败的挑战性内容使用多模态翻译，对常规文本使用传统翻译。

### 📚 Additional Resources | 其他资源

- **Full Documentation**: See [docs/MULTIMODAL.md](docs/MULTIMODAL.md) for technical details
- **Implementation Summary**: See [IMPLEMENTATION_SUMMARY.md](IMPLEMENTATION_SUMMARY.md) for development details
- **Original Repository**: https://github.com/ramjke/Translumo

- **完整文档**：查看 [docs/MULTIMODAL.md](docs/MULTIMODAL.md) 了解技术细节
- **实现摘要**：查看 [IMPLEMENTATION_SUMMARY.md](IMPLEMENTATION_SUMMARY.md) 了解开发详情
- **原始仓库**：https://github.com/ramjke/Translumo

## Build

*Visual Studio 2022 and .NET 8 SDK are required.*

1. Clone this fork repository:

    ```bash
    git clone https://github.com/mimomi666/Translumo.git
    ```

   Or clone the original repository:

    ```bash
    git clone https://github.com/ramjke/Translumo.git
    ```

> Note: During the build, **binaries_extract.bat** will automatically download and extract models and Python binaries (~400 MB) to the target output directory.

## Creating Releases

**For Maintainers**: This repository includes automated GitHub Actions workflows to build and publish releases.

📖 **Quick Start**: See [QUICKSTART_RELEASE.md](QUICKSTART_RELEASE.md) or [QUICKSTART_RELEASE_CN.md](QUICKSTART_RELEASE_CN.md) (中文版)

📚 **Detailed Guide**: See [RELEASE_GUIDE.md](RELEASE_GUIDE.md) for comprehensive instructions

**Easy Method**: 
1. Go to [Actions](../../actions) → "Build and Release"
2. Click "Run workflow"
3. Enter version number (e.g., `1.0.2`)
4. The workflow will automatically build, package, and create a GitHub release

**Tag Method**: 
```bash
git tag v1.0.2
git push origin v1.0.2
```

The release package will include everything needed to run Translumo, including the .NET runtime, OCR models, and Python dependencies (~500-600 MB total).

## Credits

- [Material Design In XAML Toolkit](https://github.com/MaterialDesignInXAML/MaterialDesignInXamlToolkit)  
- [Tesseract .NET wrapper](https://github.com/charlesw/tesseract)  
- [OpenCvSharp](https://github.com/shimat/opencvsharp)  
- [Python.NET](https://github.com/pythonnet/pythonnet)  
- [EasyOCR](https://github.com/JaidedAI/EasyOCR)  
- [Silero TTS](https://github.com/snakers4/silero-models)  

## Alternative Solutions

- [Lookupper](https://lookupper.com) — on-screen dictionary and translator for language learning.
- [ScreTran](https://github.com/PavlikBender/ScreTran) — simple screen translator.
- [ScreenTranslator](https://github.com/OneMoreGres/ScreenTranslator) - screen capture, OCR and translation tool.

