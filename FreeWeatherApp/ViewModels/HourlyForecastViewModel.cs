using System;
using System.Collections.Generic;
using FreeWeatherApp.Enums;
using FreeWeatherApp.Models.DarkSky;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace FreeWeatherApp.ViewModels
{
    public class HourlyForecastViewModel : BaseViewModel
    {
        public ObservableCollection<DataPoint> ForecastData { get; set; }

        public HourlyForecastViewModel()
        {
            ForecastData = new ObservableCollection<DataPoint>();
        }

        public async Task GetHourlyForecast()
        {
            var location = await LocationService.GetLocationAsync(GeolocationAccuracy.Best);

            var response = await DarkSkyApiService.GetHourlyForecastAsync(
                location.Latitude,
                location.Longitude,
                LanguageCode.Ru,
                MeasurementUnit.Si);

            if (response.IsSuccess)
            {
                if (response.Model?.Hourly != null)
                {
                    foreach (var dataPoint in response.Model?.Hourly?.Data)
                    {
                        ForecastData.Add(dataPoint);
                    }
                }
            }
        }
    }
}