using FreeWeatherApp.Enums;
using FreeWeatherApp.Models.DarkSky;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace FreeWeatherApp.ViewModels
{
    public class WeekForecastViewModel : BaseViewModel
    {
        public ObservableCollection<DataPoint> WeekForecastData { get; set; }

        public WeekForecastViewModel()
        {
            WeekForecastData = new ObservableCollection<DataPoint>();
        }

        public async Task GetWeekForecast()
        {
            var location = await LocationService.GetLocationAsync(GeolocationAccuracy.Best);

            var response = await DarkSkyApiService.GetWeekForecastAsync(
                location.Latitude,
                location.Longitude,
                LanguageCode.Ru,
                MeasurementUnit.Si);
            //todo [StabData] Week Forecast
            //var response = await DarkSkyApiService.StabGetWeekForecastAsync(53.6522761, 23.8430957,
            //    LanguageCode.Ru, MeasurementUnit.Si);

            if (response.IsSuccess)
            {
                response.Model?.Daily?.Data?.ForEach(WeekForecastData.Add);
            }
        }
    }
}