using FreeWeatherApp.Enums;
using Xamarin.Essentials;

namespace FreeWeatherApp.Helpers
{
    public static class PreferencesHelper
    {
        private const string LanguageCodeKey = "language_code";
        private const string MeasureUnitKey = "measure_unit";
        private const string GeolocationAccuracyKey = "geolocation_accuracy";

        public static LanguageCode GetLanguageCode() =>
            (LanguageCode) Preferences.Get(LanguageCodeKey, (int) LanguageCode.None);

        public static void SetLanguageCode(LanguageCode languageCode) =>
            Preferences.Set(LanguageCodeKey, (int) languageCode);

        public static MeasurementUnit GetMeasurementUnit() =>
            (MeasurementUnit) Preferences.Get(MeasureUnitKey, (int) MeasurementUnit.None);

        public static void SetMeasurementUnit(MeasurementUnit measurementUnit) =>
            Preferences.Set(MeasureUnitKey, (int) measurementUnit);

        public static GeolocationAccuracy GetGeolocationAccuracy() =>
            (GeolocationAccuracy) Preferences.Get(GeolocationAccuracyKey, (int) GeolocationAccuracy.Default);

        public static void SetGeolocationAccuracy(GeolocationAccuracy geolocationAccuracy) =>
            Preferences.Set(GeolocationAccuracyKey, (int) geolocationAccuracy);
    }
}