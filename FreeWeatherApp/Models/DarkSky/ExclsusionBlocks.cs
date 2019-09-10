namespace FreeWeatherApp.Models.DarkSky
{
    public enum ExclusionBlock
    {
        None = 0,
        Currently = 1 << 1,
        Minutely = 1 << 2,
        Hourly = 1 << 3,
        Daily = 1 << 4,
        Alerts = 1 << 5,
        Flags = 1 << 6
    }
}