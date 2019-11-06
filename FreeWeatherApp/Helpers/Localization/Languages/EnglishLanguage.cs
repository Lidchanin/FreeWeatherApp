using FreeWeatherApp.Enums;
using FreeWeatherApp.Helpers.Measures;
using System;

namespace FreeWeatherApp.Helpers.Localization.Languages
{
    public sealed class EnglishLanguage : Language
    {
        public override string Next48HoursTitle { get; } = "Next 48 hours";
        public override string TodayForecastTitle { get; } = "Today";
        public override string WeekForecastTitle { get; } = "Week";
        public override string SettingsTitle { get; } = "Settings";
        public override string SpeedMeasurement
        {
            get
            {
                switch (MeasuresHelper.Current)
                {
                    case MeasurementUnit.Us:
                        return "miles/h";
                    case MeasurementUnit.Si:
                        return "m/s";
                    default:
                        throw new NotImplementedException($"{MeasuresHelper.Current} is not implemented.");
                }
            }
        }
        public override string DistanceMeasurement
        {
            get
            {
                switch (MeasuresHelper.Current)
                {
                    case MeasurementUnit.Us:
                        return "miles";
                    case MeasurementUnit.Si:
                        return "km";
                    default:
                        throw new NotImplementedException($"{MeasuresHelper.Current} is not implemented.");
                }
            }
        }
        public override string PressureMeasurement
        {
            get
            {
                switch (MeasuresHelper.Current)
                {
                    case MeasurementUnit.Us:
                        return "mb";
                    case MeasurementUnit.Si:
                        return "hPa";
                    default:
                        throw new NotImplementedException($"{MeasuresHelper.Current} is not implemented.");
                }
            }
        }
        public override string PrecipIntensityMeasurement
        {
            get
            {
                switch (MeasuresHelper.Current)
                {
                    case MeasurementUnit.Us:
                        return "in/h";
                    case MeasurementUnit.Si:
                        return "mm/h";
                    default:
                        throw new NotImplementedException($"{MeasuresHelper.Current} is not implemented.");
                }
            }
        }
        public override string Forecast { get; } = "Forecast";
        public override string HourlyForecast { get; } = "Hourly Forecast";
        public override string TodayForecast { get; } = "Today Forecast";
        public override string WeekForecast { get; } = "Week Forecast";
        public override string Settings { get; } = "Settings";
        public override string Credits { get; } = "Credits";
        public override string ChooseLanguage { get; } = "Choose Language";
        public override string ChooseMeasurementUnits { get; } = "Choose measurement units";
        public override string FeltTemperature { get; } = "Felt: ";
        public override string ApparentTemperature { get; } = "Apparent Temperature";
        public override string CloudCover { get; } = "Cloud Cover";
        public override string DewPoint { get; } = "Dew Point";
        public override string Humidity { get; } = "Humidity";
        public override string PrecipIntensity { get; } = "Precipitation Intensity";
        public override string PrecipProbability { get; } = "Precipitation Probability";
        public override string PrecipType { get; } = "Precipitation Type";
        public override string Pressure { get; } = "Pressure";
        public override string Summary { get; } = "Summary";
        public override string Temperature { get; } = "Temperature";
        public override string UvIndex { get; } = "UV Index";
        public override string Visibility { get; } = "Visibility";
        public override string WindBearing { get; } = "Wind Bearing";
        public override string WindGust { get; } = "Wind Gust";
        public override string WindSpeed { get; } = "Wind Speed";
    }
}