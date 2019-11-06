using FreeWeatherApp.Models;
using FreeWeatherApp.Models.DarkSky;
using System.Threading.Tasks;

namespace FreeWeatherApp.Services.DarkSky
{
    public interface IDarkSkyApiService
    {
        Task<ResponseModel<Forecast>> GetHourlyForecastAsync();

        Task<ResponseModel<Forecast>> GetTodayForecastAsync();

        Task<ResponseModel<Forecast>> GetTodayForecastWith24HourlyAsync();

        Task<ResponseModel<Forecast>> GetWeekForecastAsync();
    }
}