using System;

namespace FreeWeatherApp.Extensions
{
    public static class LongExtensions
    {
        public static DateTimeOffset ToDateTimeOffsetFromUnixTimestamp(this long time, string timezone)
        {
            var utcDateTime = (new DateTime(1970, 1, 1)).AddSeconds(time);

            if (string.IsNullOrWhiteSpace(timezone))
            {
                return utcDateTime.ToLocalTime();
            }

            var timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(timezone);
            return TimeZoneInfo.ConvertTime(utcDateTime, timeZoneInfo);
        }
    }
}