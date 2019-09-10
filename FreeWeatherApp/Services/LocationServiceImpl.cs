using System;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace FreeWeatherApp.Services
{
    public sealed class LocationServiceImpl : ILocationService
    {
        #region Instance

        private static ILocationService _instance;

        public static ILocationService Instance => _instance ?? (_instance = new LocationServiceImpl());

        #endregion Instance

        public async Task<Location> GetLastKnownLocationAsync()
        {
            try
            {
                var location = await Geolocation.GetLastKnownLocationAsync();

                if (location != null)
                {
                    return location;
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
            }
            catch (Exception ex)
            {
                // Unable to get location
            }

            return null;
        }

        public async Task<Location> GetLocationAsync(GeolocationAccuracy accuracy = GeolocationAccuracy.Medium)
        {
            try
            {
                var request = new GeolocationRequest(accuracy);
                var location = await Geolocation.GetLocationAsync(request);

                if (location != null)
                {
                    return location;
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
            }
            catch (Exception ex)
            {
                // Unable to get location
            }

            return null;
        }
    }
}