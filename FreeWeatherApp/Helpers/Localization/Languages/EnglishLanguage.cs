namespace FreeWeatherApp.Helpers.Localization.Languages
{
    public sealed class EnglishLanguage : Language
    {
        public override string Next48HoursTitle { get; } = "Next 48 hours";
        public override string TodayForecastTitle { get; } = "Today";
        public override string WeekForecastTitle { get; } = "Week";
        public override string SettingsTitle { get; } = "Settings";
        public override string Forecast { get; } = "Forecast";
        public override string HourlyForecast { get; } = "Hourly Forecast";
        public override string TodayForecast { get; } = "Today Forecast";
        public override string WeekForecast { get; } = "Week Forecast";
        public override string Temperature { get; } = "Temperature";
        public override string ApparentTemperature { get; } = "Apparent Temperature";
        public override string Settings { get; } = "Settings";
        public override string Credits { get; } = "Credits";
        public override string ChooseLanguage { get; } = "Choose Language";
    }
}