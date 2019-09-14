using FreeWeatherApp.Models;
using FreeWeatherApp.Models.DarkSky;
using System.Threading.Tasks;
using FreeWeatherApp.Enums;

namespace FreeWeatherApp.Services.DarkSky
{
    public interface IDarkSkyApiService
    {
        Task<ResponseModel<Forecast>> GetTodayForecastAsync(
            double latitude,
            double longitude,
            LanguageCode languageCode,
            MeasurementUnit measurementUnit);

        Task<ResponseModel<Forecast>> GetWeekForecastAsync(
            double latitude,
            double longitude,
            LanguageCode languageCode,
            MeasurementUnit measurementUnit);

        Task<ResponseModel<Forecast>> StabGetWeekForecastAsync(
            double latitude,
            double longitude,
            LanguageCode languageCode,
            MeasurementUnit measurementUnit);
    }
}