using System.Threading.Tasks;

namespace Translumo.Translation
{
    public interface IImageTranslator : ITranslator
    {
        Task<string> TranslateImageAsync(byte[] imageData);
        bool SupportsImageTranslation { get; }
    }
}
