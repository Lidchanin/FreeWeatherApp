namespace FreeWeatherApp.Enums
{
    public enum MeasurementUnit
    {
        None = -1,

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
        ///
        /// apparentTemperature in degrees centigrade
        /// dewPoint in degrees centigrade
        /// precipIntensity in millimeters per hour
        /// pressure in hectopascals
        /// visibility in kilometers
        /// windGust in meters per second
        /// windSpeed in meters per second
        /// </summary>
        Us,

        /// <summary>
        /// SI units
        ///
        /// apparentTemperature in degrees fahrenheit
        /// dewPoint in degrees fahrenheit
        /// precipIntensity in inches per hour
        /// pressure in millibars
        /// visibility in miles
        /// windGust in miles per hour
        /// windSpeed in miles per hour
        /// </summary>
        Si
    }
}