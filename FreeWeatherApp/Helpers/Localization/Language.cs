using FreeWeatherApp.Enums;
using FreeWeatherApp.Helpers.Measures;
using System;

namespace FreeWeatherApp.Helpers.Localization
{
    public abstract class Language
    {
        public string AppName { get; } = "Free Weather :)";

        #region Page Titles

        public abstract string Next48HoursTitle { get; }
        public abstract string TodayForecastTitle { get; }
        public abstract string WeekForecastTitle { get; }
        public abstract string SettingsTitle { get; }

        #endregion Page Titles

        #region Measure Units

        public abstract string SpeedMeasurement { get; }
        public string TemperatureMeasurement
        {
            get
            {
                switch (MeasuresHelper.Current)
                {
                    case MeasurementUnit.Us:
                        return "°F";
                    case MeasurementUnit.Si:
                        return "°C";
                    default:
                        throw new NotImplementedException();
                }
            }
        }
        public abstract string DistanceMeasurement { get; }
        public abstract string PressureMeasurement { get; }
        public abstract string PrecipIntensityMeasurement { get; }

        #endregion Measure Units

        public abstract string Forecast { get; }
        public abstract string HourlyForecast { get; }
        public abstract string TodayForecast { get; }
        public abstract string WeekForecast { get; }
        public abstract string Settings { get; }
        public abstract string Credits { get; }
        public abstract string ChooseLanguage { get; }
        public abstract string ChooseMeasurementUnits { get; }
        public abstract string FeltTemperature { get; }

        public abstract string ApparentTemperature { get; }
        public abstract string CloudCover { get; }
        public abstract string DewPoint { get; }
        public abstract string Humidity { get; }
        public abstract string PrecipIntensity { get; }
        public abstract string PrecipProbability { get; }
        public abstract string PrecipType { get; }
        public abstract string Pressure { get; }
        public abstract string Summary { get; }
        public abstract string Temperature { get; }
        public abstract string UvIndex { get; }
        public abstract string Visibility { get; }
        public abstract string WindBearing { get; }
        public abstract string WindGust { get; }
        public abstract string WindSpeed { get; }
    }
}