using Translumo.Utils;

namespace Translumo.Translation.Configuration
{
    public class MultimodalConfiguration : BindableBase
    {
        public static MultimodalConfiguration Default => new MultimodalConfiguration()
        {
            BaseUrl = "https://api.openai.com/v1/chat/completions",
            ApiKey = "",
            ModelName = "gpt-4o",
            Prompt = "Translate all text in this image to Chinese. Only output the translated text, no explanations."
        };

        public string BaseUrl
        {
            get => _baseUrl;
            set => SetProperty(ref _baseUrl, value);
        }

        public string ApiKey
        {
            get => _apiKey;
            set => SetProperty(ref _apiKey, value);
        }

        public string ModelName
        {
            get => _modelName;
            set => SetProperty(ref _modelName, value);
        }

        public string Prompt
        {
            get => _prompt;
            set => SetProperty(ref _prompt, value);
        }

        private string _baseUrl;
        private string _apiKey;
        private string _modelName;
        private string _prompt;
    }
}
