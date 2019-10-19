using FreeWeatherApp.Enums;
using Xamarin.Essentials;

namespace FreeWeatherApp.Helpers
{
    public static class PreferencesHelper
    {
        private const string LanguageCodeKey = "language_code";

        public static LanguageCode GetLanguageCode() =>
            (LanguageCode) Preferences.Get(LanguageCodeKey, 0);

        public static void SetLanguageCode(LanguageCode languageCode) =>
            Preferences.Set(LanguageCodeKey, (int) languageCode);
    }
}