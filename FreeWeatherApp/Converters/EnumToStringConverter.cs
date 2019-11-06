using System;
using System.Globalization;
using FreeWeatherApp.Enums;
using FreeWeatherApp.Helpers;
using Xamarin.Forms;

namespace FreeWeatherApp.Converters
{
    public class EnumToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is WeatherIcon weatherIcon)
            {
                switch (weatherIcon)
                {
                    case WeatherIcon.None:
                        return FilenameHelper.BrokenIcon;
                    case WeatherIcon.ClearDay:
                        return FilenameHelper.Weather.ClearDayIcon;
                    case WeatherIcon.ClearNight:
                        return FilenameHelper.Weather.ClearNightIcon;
                    case WeatherIcon.Rain:
                        return FilenameHelper.Weather.RainIcon;
                    case WeatherIcon.Snow:
                        return FilenameHelper.Weather.SnowIcon;
                    case WeatherIcon.Sleet:
                        return FilenameHelper.Weather.SleetIcon;
                    case WeatherIcon.Wind:
                        return FilenameHelper.Weather.WindIcon;
                    case WeatherIcon.Fog:
                        return FilenameHelper.Weather.FogIcon;
                    case WeatherIcon.Cloudy:
                        return FilenameHelper.Weather.CloudyIcon;
                    case WeatherIcon.PartlyCloudyDay:
                        return FilenameHelper.Weather.PartiallyCloudyDayIcon;
                    case WeatherIcon.PartlyCloudyNight:
                        return FilenameHelper.Weather.PartiallyCloudyNightIcon;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            throw new NotImplementedException($"{value.GetType()} isn't implemented");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}