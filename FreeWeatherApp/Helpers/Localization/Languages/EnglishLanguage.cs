namespace FreeWeatherApp.Helpers.Localization.Languages
{
    public sealed class EnglishLanguage : Language
    {
        public override string Forecast { get; } = "Forecast";
        public override string WeekForecast { get; } = "Week Forecast";
        public override string Temperature { get; } = "Temperature";
        public override string ApparentTemperature { get; } = "Apparent Temperature";
    }
}