# Multimodal Translation Feature

## Overview

The Multimodal translation feature allows Translumo to use multimodal AI models (like GPT-4 Vision, Claude 3, or compatible models) to directly translate images without requiring OCR. This can provide more accurate translations, especially for complex layouts or stylized text.

## Configuration

When you select "Multimodal" as your translator in the Languages settings, you'll see additional configuration options:

### Base URL
The API endpoint for your multimodal service. Examples:
- OpenAI: `https://api.openai.com/v1/chat/completions`
- Azure OpenAI: `https://<your-resource>.openai.azure.com/openai/deployments/<deployment-name>/chat/completions?api-version=2024-02-15-preview`
- Other compatible services: Use their chat completions endpoint

### API Key
Your API key for the service. This will be sent in the `Authorization: Bearer <key>` header.

### Model Name
The name of the multimodal model to use. Examples:
- OpenAI: `gpt-4o`, `gpt-4-turbo`, `gpt-4-vision-preview`
- Anthropic Claude (via compatible API): `claude-3-opus-20240229`, `claude-3-sonnet-20240229`
- Other services: Check their documentation for model names

### Prompt
The instruction sent to the model along with the image. The default prompt is:
```
Translate all text in this image to Chinese. Only output the translated text, no explanations.
```

You can customize this to:
- Change the target language (e.g., "Translate to English", "Translate to Japanese")
- Add specific instructions (e.g., "Maintain the original formatting", "Translate game UI elements")
- Request additional context (e.g., "Explain any cultural references")

## How It Works

Unlike traditional translation which uses OCR followed by text translation:
1. **Traditional**: Screen Capture → OCR (extract text) → Text Translation
2. **Multimodal**: Screen Capture → Direct Image Translation

The multimodal approach:
- Bypasses OCR entirely when using a multimodal translator
- Sends the screenshot directly to the AI model
- The model analyzes the image and returns the translation
- Can handle complex layouts, vertical text, and stylized fonts better than OCR

## Supported APIs

Any OpenAI-compatible chat completions API that supports vision/images should work, including:
- OpenAI GPT-4 Vision
- Azure OpenAI with vision models
- Local models through compatible APIs (e.g., LM Studio, LocalAI)
- Other cloud providers with OpenAI-compatible endpoints

## Cost Considerations

Be aware that multimodal API calls are typically more expensive than text-only translation:
- Each translation sends the full screenshot as a base64-encoded image
- Costs vary by provider and model
- Consider using it for challenging text or when OCR quality is poor
- You can still use traditional translators for cost-effective bulk translation

## Tips

1. **Optimize the Prompt**: Experiment with different prompts to get better results for your specific use case
2. **Use Capture Area**: Select smaller capture areas to reduce image size and API costs
3. **Proxy Support**: Multimodal translator supports proxy configuration like other translators
4. **Fallback**: Keep other translators configured so you can switch back if needed

## Troubleshooting

**Error: "Multimodal API error: ..."**
- Check that your API key is correct
- Verify the Base URL matches your service provider
- Ensure the Model Name is valid for your service
- Check your API account has sufficient credits

**No translation appears**
- Enable console logging to see API responses
- Try a simpler prompt first
- Verify the model supports vision/image input
- Check your internet connection and proxy settings
