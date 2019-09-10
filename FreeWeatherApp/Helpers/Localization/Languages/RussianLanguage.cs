namespace FreeWeatherApp.Helpers.Localization.Languages
{
    public sealed class RussianLanguage : Language
    {
        public override string Forecast { get; } = "Прогноз";
        public override string WeekForecast { get; } = "Прогноз на неделю";
        public override string Temperature { get; } = "Температура";
        public override string ApparentTemperature { get; } = "Ощущаемая температура";
    }
}