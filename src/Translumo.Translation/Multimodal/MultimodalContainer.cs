using Translumo.Translation.Configuration;
using Translumo.Utils.Http;

namespace Translumo.Translation.Multimodal
{
    public class MultimodalContainer : TranslationContainer
    {
        public MultimodalConfiguration Config { get; }
        public HttpReader Reader { get; private set; }

        public MultimodalContainer(MultimodalConfiguration config, bool isPrimary = false) 
            : base(null, isPrimary)
        {
            Config = config;
            Reader = CreateReader(null);
        }

        public MultimodalContainer(MultimodalConfiguration config, Proxy proxy) 
            : base(proxy, false)
        {
            Config = config;
            Reader = CreateReader(proxy);
        }

        private HttpReader CreateReader(Proxy proxy)
        {
            var reader = new HttpReader();
            reader.ContentType = "application/json";
            reader.Accept = "application/json";
            reader.Proxy = proxy?.ToWebProxy();

            return reader;
        }
    }
}
