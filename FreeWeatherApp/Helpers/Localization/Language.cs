namespace FreeWeatherApp.Helpers.Localization
{
    public abstract class Language
    {
        public string AppName { get; } = "Free Weather :)";

        public abstract string Forecast { get; }
        public abstract string HourlyForecast { get; }
        public abstract string TodayForecast { get; }
        public abstract string WeekForecast { get; }
        public abstract string Temperature { get; }
        public abstract string ApparentTemperature { get; }
        public abstract string Settings { get; }
        public abstract string Credits { get; }
    }
}