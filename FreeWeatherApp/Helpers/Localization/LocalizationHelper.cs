using FreeWeatherApp.Enums;
using FreeWeatherApp.Helpers.Localization.Languages;
using System;

namespace FreeWeatherApp.Helpers.Localization
{
    public static class LocalizationHelper
    {
        public static Language Current { get; private set; } = new EnglishLanguage();

        public static void SetLanguage(LanguageCode code) =>
            Current = GetLanguageByCode(code);

        private static Language GetLanguageByCode(LanguageCode code)
        {
            switch (code)
            {
                case LanguageCode.None:
                case LanguageCode.En:
                    return new EnglishLanguage();
                case LanguageCode.Ru:
                    return new RussianLanguage();
                default:
                    throw new NotImplementedException();
            }
        }
    }
}