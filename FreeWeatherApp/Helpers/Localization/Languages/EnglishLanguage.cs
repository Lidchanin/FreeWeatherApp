namespace FreeWeatherApp.Helpers.Localization.Languages
{
    public sealed class EnglishLanguage : Language
    {
        public override string Forecast { get; } = "Forecast";
        public override string HourlyForecast { get; } = "Hourly Forecast";
        public override string TodayForecast { get; } = "Today Forecast";
        public override string WeekForecast { get; } = "Week Forecast";
        public override string Temperature { get; } = "Temperature";
        public override string ApparentTemperature { get; } = "Apparent Temperature";
        public override string Settings { get; } = "Settings";
        public override string Credits { get; } = "Credits";
    }
}