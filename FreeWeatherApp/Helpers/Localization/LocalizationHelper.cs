using FreeWeatherApp.Enums;
using FreeWeatherApp.Helpers.Localization.Languages;
using System;

namespace FreeWeatherApp.Helpers.Localization
{
    public static class LocalizationHelper
    {
        public static Language Current { get; private set; } = GetLanguageByCode(PreferencesHelper.GetLanguageCode());

        public static LanguageCode CurrentCode { get; private set; } = PreferencesHelper.GetLanguageCode();

        public static void SetLanguage(LanguageCode code)
        {
            PreferencesHelper.SetLanguageCode(code);
            CurrentCode = PreferencesHelper.GetLanguageCode();
            Current = GetLanguageByCode(code);
        }

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