using FreeWeatherApp.Models.DarkSky;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

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
            var response = await DarkSkyApiService.GetHourlyForecastAsync();

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