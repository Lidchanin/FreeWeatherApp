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
        public string RealTemperature { get; set; }
        public string ApparentTemperature { get; set; }
        public string Summary { get; set; }
        public ObservableCollection<DataPoint> HourlyForecastData { get; set; }
        public ObservableCollection<string> WeatherDetails { get; set; }

        public TodayForecastViewModel()
        {
            HourlyForecastData = new ObservableCollection<DataPoint>();
            WeatherDetails = new ObservableCollection<string>();
        }

        public async Task LoadData()
        {
            var response = await DarkSkyApiService.GetTodayForecastWith24HourlyAsync();

            if (response.IsSuccess && response.Model is Forecast forecast)
            {
                if (forecast.Currently is DataPoint currently)
                {
                    if (currently.Temperature is double temperature)
                    {
                        RealTemperature = $"{temperature}{LocalizationHelper.Current.TemperatureMeasurement}";
                    }

                    if (currently.ApparentTemperature is double apparentTemperature)
                    {
                        ApparentTemperature =
                            $"{LocalizationHelper.Current.FeltTemperature} {apparentTemperature}{LocalizationHelper.Current.TemperatureMeasurement}";
                    }

                    if (!string.IsNullOrWhiteSpace(currently.Summary))
                    {
                        Summary = currently.Summary;
                    }
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
                        WeatherDetails.Add($"{LocalizationHelper.Current.CloudCover}: {cloudCover:P}");
                    }

                    if (currentlyForecastData.Humidity is double humidity)
                    {
                        WeatherDetails.Add($"{LocalizationHelper.Current.Humidity}: {humidity:P}");
                    }

                    if (currentlyForecastData.PrecipType is PrecipitationType precipType)
                    {
                        if (precipType == PrecipitationType.None)
                        {
                            WeatherDetails.Add(LocalizationHelper.Current.NoPrecipitation);
                        }
                        else
                        {
                            switch (precipType)
                            {
                                case PrecipitationType.Rain:
                                    WeatherDetails.Add(
                                        $"{LocalizationHelper.Current.PrecipType}: {LocalizationHelper.Current.Rain}");
                                    break;
                                case PrecipitationType.Snow:
                                    WeatherDetails.Add(
                                        $"{LocalizationHelper.Current.PrecipType}: {LocalizationHelper.Current.Snow}");
                                    break;
                                case PrecipitationType.Sleet:
                                    WeatherDetails.Add(
                                        $"{LocalizationHelper.Current.PrecipType}: {LocalizationHelper.Current.Sleet}");
                                    break;
                                default:
                                    throw new NotImplementedException("PrecipitationType not implemented.");
                            }

                            if (currentlyForecastData.PrecipProbability is double precipProbability)
                            {
                                WeatherDetails.Add(
                                    $"{LocalizationHelper.Current.PrecipProbability}: {precipProbability:P}");
                            }

                            if (currentlyForecastData.PrecipIntensity is double precipIntensity)
                            {
                                WeatherDetails.Add(
                                    $"{LocalizationHelper.Current.PrecipIntensity}: {precipIntensity} {LocalizationHelper.Current.PrecipIntensityMeasurement}");
                            }
                        }
                    }

                    if (currentlyForecastData.Pressure is double pressure)
                    {
                        WeatherDetails.Add(
                            $"{LocalizationHelper.Current.Pressure}: {pressure} {LocalizationHelper.Current.PressureMeasurement}");
                    }

                    if (currentlyForecastData.WindGust is double windGust)
                    {
                        WeatherDetails.Add(
                            $"{LocalizationHelper.Current.WindGust}: {windGust} {LocalizationHelper.Current.SpeedMeasurement}");
                    }

                    if (currentlyForecastData.WindSpeed is double windSpeed)
                    {
                        WeatherDetails.Add(
                            $"{LocalizationHelper.Current.WindSpeed}: {windSpeed:N2} {LocalizationHelper.Current.SpeedMeasurement}");
                    }

                    if (currentlyForecastData.WindBearing is int windBearing)
                    {
                        WeatherDetails.Add($"{LocalizationHelper.Current.WindBearing}: {windBearing} °");
                    }

                    if (currentlyForecastData.DewPoint is double dewPoint)
                    {
                        WeatherDetails.Add(
                            $"{LocalizationHelper.Current.DewPoint}: {dewPoint} {LocalizationHelper.Current.TemperatureMeasurement}");
                    }

                    if (currentlyForecastData.UvIndex is int uvIndex)
                    {
                        WeatherDetails.Add($"{LocalizationHelper.Current.UvIndex}: {uvIndex}");
                    }

                    if (currentlyForecastData.Visibility is double visibility)
                    {
                        WeatherDetails.Add(
                            $"{LocalizationHelper.Current.Visibility}: {visibility:N2} {LocalizationHelper.Current.DistanceMeasurement}");
                    }
                }
            }
        }
    }
}