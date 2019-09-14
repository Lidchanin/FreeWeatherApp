using FreeWeatherApp.Enums;
using FreeWeatherApp.Models.DarkSky;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace FreeWeatherApp.ViewModels
{
    public class TodayForecastViewModel : BaseViewModel
    {
        public DataPoint ForecastData { get; set; }

        public TodayForecastViewModel()
        {
            ForecastData = new DataPoint();
        }

        public async Task GetTodayForecast()
        {
            var location = await LocationService.GetLocationAsync(GeolocationAccuracy.Best);

            var response = await DarkSkyApiService.GetTodayForecastAsync(
                location.Latitude,
                location.Longitude,
                LanguageCode.Ru,
                MeasurementUnit.Si);

            if (response.IsSuccess)
            {
                ForecastData = response?.Model?.Currently;
            }
        }
    }
}