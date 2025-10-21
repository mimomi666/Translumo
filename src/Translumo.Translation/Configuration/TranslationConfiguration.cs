﻿using System.Collections.Generic;
using Translumo.Infrastructure.Language;
using Translumo.Utils;

namespace Translumo.Translation.Configuration
{
    public class TranslationConfiguration : BindableBase
    {
        public static TranslationConfiguration Default => new TranslationConfiguration()
        {
            TranslateFromLang = Languages.English,
            TranslateToLang = Languages.Russian,
            ProxySettings = new List<Proxy>(),
            MultimodalSettings = MultimodalConfiguration.Default
        };

        public Languages TranslateFromLang
        {
            get => _translateFromLang;
            set
            {
                SetProperty(ref _translateFromLang, value);
            }
        }

        public Languages TranslateToLang
        {
            get => _translateToLang;
            set
            {
                SetProperty(ref _translateToLang, value);
            }
        }

        public Translators Translator
        {
            get => _translator;
            set
            {
                SetProperty(ref _translator, value);
            }
        }

        public List<Proxy> ProxySettings
        {
            get => _proxySettings;
            set
            {
                SetProperty(ref _proxySettings, value);
            }
        }

        public MultimodalConfiguration MultimodalSettings
        {
            get => _multimodalSettings ?? MultimodalConfiguration.Default;
            set
            {
                SetProperty(ref _multimodalSettings, value ?? MultimodalConfiguration.Default);
            }
        }

        private Languages _translateFromLang;
        private Languages _translateToLang;
        private Translators _translator;
        private List<Proxy> _proxySettings = new List<Proxy>();
        private MultimodalConfiguration _multimodalSettings = MultimodalConfiguration.Default;
    }
}
