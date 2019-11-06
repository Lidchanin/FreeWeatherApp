using System;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace FreeWeatherApp.Helpers.Location
{
    public static class LocationHelper
    {
        public static GeolocationAccuracy CurrentAccuracy { get; private set; } =
            PreferencesHelper.GetGeolocationAccuracy();

        public static void SetAccuracy(GeolocationAccuracy accuracy)
        {
            PreferencesHelper.SetGeolocationAccuracy(accuracy);
            CurrentAccuracy = PreferencesHelper.GetGeolocationAccuracy();
        }

        public static async Task<Xamarin.Essentials.Location> GetLastKnownLocationAsync()
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

        public static async Task<Xamarin.Essentials.Location> GetLocationAsync()
        {
            try
            {
                var request = new GeolocationRequest(CurrentAccuracy);
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