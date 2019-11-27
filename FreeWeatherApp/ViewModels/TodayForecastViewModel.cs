using FreeWeatherApp.Enums;
using FreeWeatherApp.Helpers.Localization;
using FreeWeatherApp.Models.DarkSky;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace FreeWeatherApp.ViewModels
{
    public class TodayForecastViewModel : BaseViewModel
    {
        public DataPoint TodayForecastData { get; set; }
        public ObservableCollection<DataPoint> HourlyForecastData { get; set; }
        public ObservableCollection<Tuple<string, string>> WeatherDetails { get; set; }

        public TodayForecastViewModel()
        {
            TodayForecastData = new DataPoint();
            HourlyForecastData = new ObservableCollection<DataPoint>();
            WeatherDetails = new ObservableCollection<Tuple<string, string>>();
        }

        public async Task LoadData()
        {
            await Task.Delay(TimeSpan.FromSeconds(3));
            var response = await DarkSkyApiService.GetTodayForecastWith24HourlyAsync();

            if (response.IsSuccess && response.Model is Forecast forecast)
            {
                if (forecast.Currently is DataPoint currently)
                {
                    TodayForecastData = currently;
                }

                if (forecast.Hourly is DataBlock hourlyForecast &&
                    hourlyForecast.Data is List<DataPoint> hourlyForecastData)
                {
                    HourlyForecastData = new ObservableCollection<DataPoint>(hourlyForecastData);
                }

                if (forecast.Currently is DataPoint currentlyForecastData)
                {
                    if (currentlyForecastData.CloudCover is double cloudCover)
                    {
                        WeatherDetails.Add(new Tuple<string, string>(
                            LocalizationHelper.Current.CloudCover,
                            $"{cloudCover:P}"));
                    }

                    if (currentlyForecastData.DewPoint is double dewPoint)
                    {
                        WeatherDetails.Add(new Tuple<string, string>(
                            LocalizationHelper.Current.DewPoint,
                            $"{dewPoint} {LocalizationHelper.Current.TemperatureMeasurement}"));
                    }

                    if (currentlyForecastData.Humidity is double humidity)
                    {
                        WeatherDetails.Add(new Tuple<string, string>(
                            LocalizationHelper.Current.Humidity,
                            $"{humidity:P}"));
                    }

                    if (currentlyForecastData.PrecipIntensity is double precipIntensity)
                    {
                        WeatherDetails.Add(new Tuple<string, string>(
                            LocalizationHelper.Current.PrecipIntensity,
                            $"{precipIntensity} {LocalizationHelper.Current.PrecipIntensityMeasurement}"));
                    }

                    if (currentlyForecastData.PrecipProbability is double precipProbability)
                    {
                        WeatherDetails.Add(new Tuple<string, string>(
                            LocalizationHelper.Current.PrecipProbability,
                            $"{precipProbability:P}"));
                    }

                    if (currentlyForecastData.PrecipType is PrecipitationType precipType)
                    {
                        WeatherDetails.Add(new Tuple<string, string>(
                            LocalizationHelper.Current.PrecipType,
                            $"{precipType}"));
                    }

                    if (currentlyForecastData.Pressure is double pressure)
                    {
                        WeatherDetails.Add(new Tuple<string, string>(
                            LocalizationHelper.Current.Pressure,
                            $"{pressure} {LocalizationHelper.Current.PressureMeasurement}"));
                    }

                    if (currentlyForecastData.UvIndex is int uvIndex)
                    {
                        WeatherDetails.Add(new Tuple<string, string>(
                            LocalizationHelper.Current.UvIndex,
                            $"{uvIndex}"));
                    }

                    if (currentlyForecastData.Visibility is double visibility)
                    {
                        WeatherDetails.Add(new Tuple<string, string>(
                            LocalizationHelper.Current.Visibility,
                            $"{visibility} {LocalizationHelper.Current.DistanceMeasurement}"));
                    }

                    if (currentlyForecastData.WindBearing is int windBearing)
                    {
                        WeatherDetails.Add(new Tuple<string, string>(
                            LocalizationHelper.Current.WindBearing,
                            $"{windBearing} °"));
                    }

                    if (currentlyForecastData.WindGust is double windGust)
                    {
                        WeatherDetails.Add(new Tuple<string, string>(
                            LocalizationHelper.Current.WindGust,
                            $"{windGust} {LocalizationHelper.Current.SpeedMeasurement}"));
                    }

                    if (currentlyForecastData.WindSpeed is double windSpeed)
                    {
                        WeatherDetails.Add(new Tuple<string, string>(
                            LocalizationHelper.Current.WindSpeed,
                            $"{windSpeed} {LocalizationHelper.Current.SpeedMeasurement}"));
                    }
                }
            }
        }
    }
}