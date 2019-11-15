using System;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace FreeWeatherApp.Helpers
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

        public static async Task<Location> GetLastKnownLocationAsync()
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
                CrashlyticsHelper.TrackError(fnsEx);
            }
            catch (FeatureNotEnabledException fneEx)
            {
                CrashlyticsHelper.TrackError(fneEx);
            }
            catch (PermissionException pEx)
            {
                CrashlyticsHelper.TrackError(pEx);
            }
            catch (Exception ex)
            {
                CrashlyticsHelper.TrackError(ex);
            }

            return null;
        }

        public static async Task<Location> GetLocationAsync()
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
                CrashlyticsHelper.TrackError(fnsEx);
            }
            catch (FeatureNotEnabledException fneEx)
            {
                CrashlyticsHelper.TrackError(fneEx);
            }
            catch (PermissionException pEx)
            {
                CrashlyticsHelper.TrackError(pEx);
            }
            catch (Exception ex)
            {
                CrashlyticsHelper.TrackError(ex);
            }

            return null;
        }
    }
}