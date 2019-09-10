namespace FreeWeatherApp.Models.DarkSky
{
    public enum MeasurementUnit
    {
        /// <summary>
        /// Automatically select units based on geographic location
        /// </summary>
        Auto,

        /// <summary>
        /// Same as si, except that windSpeed and windGust are in kilometers per hour
        /// </summary>
        Ca,

        /// <summary>
        /// Same as si, except that nearestStormDistance and visibility are in miles, and windSpeed and windGust in miles per hour
        /// </summary>
        Uk2,

        /// <summary>
        /// Imperial units (the default)
        /// </summary>
        Us,

        /// <summary>
        /// SI units
        /// </summary>
        Si
    }
}