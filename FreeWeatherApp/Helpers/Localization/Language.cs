namespace FreeWeatherApp.Helpers.Localization
{
    public abstract class Language
    {
        public abstract string Forecast { get; }
        public abstract string WeekForecast { get; }
        public abstract string Temperature { get; }
        public abstract string ApparentTemperature { get; }
    }
}