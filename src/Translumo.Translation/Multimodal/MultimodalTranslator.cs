using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Translumo.Infrastructure.Language;
using Translumo.Translation.Configuration;
using Translumo.Translation.Exceptions;
using Translumo.Utils.Http;

namespace Translumo.Translation.Multimodal
{
    public sealed class MultimodalTranslator : BaseTranslator<MultimodalContainer>, IImageTranslator
    {
        public bool SupportsImageTranslation => true;

        public MultimodalTranslator(TranslationConfiguration translationConfiguration, LanguageService languageService, ILogger logger)
            : base(translationConfiguration, languageService, logger)
        {
        }

        public async Task<string> TranslateImageAsync(byte[] imageData)
        {
            if (Containers == null)
            {
                Containers = CreateContainers(TranslationConfiguration);
            }

            var container = GetContainer(true);
            while (true)
            {
                try
                {
                    var result = await TranslateImageInternal(container, imageData);
                    container.MarkContainerIsUsed(true);
                    return result;
                }
                catch (TranslationException ex)
                {
                    container.MarkContainerIsUsed(false);
                    if (container.IsBlocked && !container.IsPrimary)
                    {
                        Logger.LogWarning($"Translation container is blocked until {container.BlockedUntilUtc.Value.ToLocalTime()} ({container.Proxy})");
                    }

                    var backupContainer = GetContainer(false, container);
                    if (backupContainer == null)
                    {
                        throw;
                    }

                    if (backupContainer == container)
                    {
                        await Task.Delay(AttemptDelayMs);
                    }

                    container = backupContainer;
                }
                catch (Exception ex)
                {
                    container.MarkContainerIsUsed(false);
                    throw;
                }
            }
        }

        protected override async Task<string> TranslateTextInternal(MultimodalContainer container, string sourceText)
        {
            // For text-based translation, we can still support it but it's not the primary use case
            throw new NotSupportedException("Multimodal translator requires image input. Use TranslateImageAsync instead.");
        }

        private async Task<string> TranslateImageInternal(MultimodalContainer container, byte[] imageData)
        {
            var config = container.Config;

            // Convert image to base64
            var base64Image = Convert.ToBase64String(imageData);
            var imageUrl = $"data:image/png;base64,{base64Image}";

            // Build request
            var request = new MultimodalRequest
            {
                Model = config.ModelName,
                Messages = new List<MultimodalRequest.Message>
                {
                    new MultimodalRequest.Message
                    {
                        Role = "user",
                        ContentList = new List<MultimodalRequest.Content>
                        {
                            new MultimodalRequest.Content
                            {
                                Type = "text",
                                Text = config.Prompt
                            },
                            new MultimodalRequest.Content
                            {
                                Type = "image_url",
                                ImageUrlObj = new MultimodalRequest.ImageUrl
                                {
                                    Url = imageUrl
                                }
                            }
                        }
                    }
                }
            };

            var requestJson = JsonSerializer.Serialize(request, new JsonSerializerOptions
            {
                DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
            });

            // Add authorization header
            var headers = new Dictionary<string, string>
            {
                { "Authorization", $"Bearer {config.ApiKey}" },
                { "Content-Type", "application/json" }
            };

            HttpResponse httpResponse = await container.Reader.RequestWebDataAsync(
                config.BaseUrl,
                HttpMethods.POST,
                requestJson,
                headers: headers
            ).ConfigureAwait(false);

            if (httpResponse.IsSuccessful)
            {
                var response = JsonSerializer.Deserialize<MultimodalResponse>(httpResponse.Body);
                
                if (response?.ErrorObj != null)
                {
                    throw new TranslationException($"Multimodal API error: {response.ErrorObj.Message}");
                }

                if (response?.Choices != null && response.Choices.Count > 0)
                {
                    var content = response.Choices[0].Message?.Content;
                    if (!string.IsNullOrWhiteSpace(content))
                    {
                        return content.Trim();
                    }
                }

                throw new TranslationException($"Unexpected multimodal API response: '{httpResponse.Body}'");
            }

            throw new TranslationException($"Multimodal API request failed: '{httpResponse.Body}'", httpResponse.InnerException);
        }

        protected override IList<MultimodalContainer> CreateContainers(TranslationConfiguration configuration)
        {
            var multimodalConfig = configuration.MultimodalSettings;
            var result = configuration.ProxySettings.Select(proxy => new MultimodalContainer(multimodalConfig, proxy)).ToList();
            result.Add(new MultimodalContainer(multimodalConfig, isPrimary: true));

            return result;
        }
    }
}
