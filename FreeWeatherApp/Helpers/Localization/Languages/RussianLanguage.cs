using FreeWeatherApp.Enums;
using System;

namespace FreeWeatherApp.Helpers.Localization.Languages
{
    public sealed class RussianLanguage : Language
    {
        public override string Next48HoursTitle { get; } = "Следующие 48 часов";
        public override string TodayForecastTitle { get; } = "Сегодня";
        public override string WeekForecastTitle { get; } = "Неделя";
        public override string SettingsTitle { get; } = "Настройки";
        public override string SpeedMeasurement
        {
            get
            {
                switch (MeasuresHelper.Current)
                {
                    case MeasurementUnit.Us:
                        return "миль/ч";
                    case MeasurementUnit.Si:
                        return "м/с";
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
                        return "миль";
                    case MeasurementUnit.Si:
                        return "км";
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
                        return "мбар";
                    case MeasurementUnit.Si:
                        return "гПа";
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
                        return "дюйм/ч";
                    case MeasurementUnit.Si:
                        return "мм/ч";
                    default:
                        throw new NotImplementedException($"{MeasuresHelper.Current} is not implemented.");
                }
            }
        }
        public override string Forecast { get; } = "Прогноз";
        public override string HourlyForecast { get; } = "Почасовой прогноз";
        public override string TodayForecast { get; } = "Прогноз на сегодня";
        public override string WeekForecast { get; } = "Прогноз на неделю";
        public override string Settings { get; } = "Настройки";
        public override string Credits { get; } = "О приложении";
        public override string ChooseLanguage { get; } = "Выберите язык";
        public override string ChooseMeasurementUnits { get; } = "Выберите единицы измерения";
        public override string FeltTemperature { get; } = "Ощущается: ";
        public override string ApparentTemperature { get; } = "Ощущаемая температура";
        public override string CloudCover { get; } = "Облачность";
        public override string DewPoint { get; } = "Точка росы";
        public override string Humidity { get; } = "Влажность";
        public override string PrecipIntensity { get; } = "Интенсивность осадков";
        public override string PrecipProbability { get; } = "Вероятность осадков";
        public override string PrecipType { get; } = "Тип осадков";
        public override string Pressure { get; } = "Давление";
        public override string Summary { get; } = "Краткое описание";
        public override string Temperature { get; } = "Температура";
        public override string UvIndex { get; } = "УФ-индекс";
        public override string Visibility { get; } = "Видимость";
        public override string WindBearing { get; } = "Направление ветра";
        public override string WindGust { get; } = "Порыв ветра";
        public override string WindSpeed { get; } = "Скорость ветра";
    }
}