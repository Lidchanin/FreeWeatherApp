namespace FreeWeatherApp.Helpers.Localization.Languages
{
    public sealed class RussianLanguage : Language
    {
        public override string Forecast { get; } = "Прогноз";
        public override string HourlyForecast { get; } = "Почасовой прогноз";
        public override string TodayForecast { get; } = "Прогноз на сегодня";
        public override string WeekForecast { get; } = "Прогноз на неделю";
        public override string Temperature { get; } = "Температура";
        public override string ApparentTemperature { get; } = "Ощущаемая температура";
        public override string Settings { get; } = "Настройки";
        public override string Credits { get; } = "О приложении";
    }
}