using FreeWeatherApp.Models.DarkSky;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

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
            var response = await DarkSkyApiService.GetWeekForecastAsync();

            if (response.IsSuccess)
            {
                response.Model?.Daily?.Data?.ForEach(WeekForecastData.Add);
            }
        }
    }
}