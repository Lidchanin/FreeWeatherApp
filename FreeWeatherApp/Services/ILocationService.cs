using System.Threading.Tasks;
using Xamarin.Essentials;

namespace FreeWeatherApp.Services
{
    public interface ILocationService
    {
        Task<Location> GetLastKnownLocationAsync();

        Task<Location> GetLocationAsync(GeolocationAccuracy accuracy = GeolocationAccuracy.Medium);
    }
}