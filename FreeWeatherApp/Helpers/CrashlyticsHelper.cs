using Microsoft.AppCenter;
using Microsoft.AppCenter.Crashes;
using System;

namespace FreeWeatherApp.Helpers
{
    public static class CrashlyticsHelper
    {
        public static void Init()
        {
            AppCenter.Start(
                "ios={599d0643-db3c-49d6-aa8c-3c0c8ca61af8};android={e5c110e4-82f5-4f7f-88c3-5af46f72f5ef}",
                typeof(Crashes));
        }

        public static void TrackError(Exception exception)
        {
            Crashes.TrackError(exception);
        }
    }
}