using FreeWeatherApp.Models.DarkSky;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FreeWeatherApp.ViewModels
{
    public class TodayForecastViewModel : BaseViewModel
    {
        public DataPoint TodayForecastData { get; set; }
        public List<DataPoint> HourlyForecastData { get; set; }

        public TodayForecastViewModel()
        {
            TodayForecastData = new DataPoint();
        }

        public async Task GetForecast()
        {
            var response = await DarkSkyApiService.GetTodayForecastWith24HourlyAsync();

            if (response.IsSuccess)
            {
                TodayForecastData = response.Model?.Currently;

                if (response.Model?.Hourly?.Data?.Count > 0)
                {
                    HourlyForecastData = response.Model?.Hourly?.Data;
                }
            }
        }
    }
}