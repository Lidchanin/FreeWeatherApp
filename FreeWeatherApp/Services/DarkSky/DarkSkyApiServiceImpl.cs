using FreeWeatherApp.Models;
using FreeWeatherApp.Models.DarkSky;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FreeWeatherApp.Enums;

namespace FreeWeatherApp.Services.DarkSky
{
    public sealed class DarkSkyApiServiceImpl : BaseNetworkService, IDarkSkyApiService
    {
        #region Instance

        private static IDarkSkyApiService _instance;

        public static IDarkSkyApiService Instance => _instance ?? (_instance = new DarkSkyApiServiceImpl());

        #endregion Instance

        protected override HttpClient HttpClient { get; set; }

        private const string ApiKey = "b8bb1ce362f6e13f0d1ed25650ea8147";

        private const string BaseApiAddress = "https://api.darksky.net/";

        private DarkSkyApiServiceImpl()
        {
            var clientHandler = new HttpClientHandler();

            if (clientHandler.SupportsAutomaticDecompression)
            {
                clientHandler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            }

            HttpClient = new HttpClient(clientHandler)
            {
                BaseAddress = new Uri(BaseApiAddress)
            };
        }

        public async Task<ResponseModel<Forecast>> GetWeekForecastAsync(
            double latitude,
            double longitude,
            LanguageCode languageCode,
            MeasurementUnit measurementUnit)
        {
            var parameters = new OptionalParameters
            {
                ExtendHourly = true,
                LanguageCode = languageCode,
                MeasurementUnit = measurementUnit,
                DataBlocksToExclude = new List<ExclusionBlock>
                {
                    ExclusionBlock.Alerts,
                    ExclusionBlock.Minutely,
                    ExclusionBlock.Flags,
                    ExclusionBlock.Currently,
                    ExclusionBlock.Hourly
                }
            };

            return await GetAsync<Forecast>(BuildRequestUri(latitude, longitude, parameters));
        }

        public Task<ResponseModel<Forecast>> StabGetWeekForecastAsync(
            double latitude,
            double longitude,
            LanguageCode languageCode,
            MeasurementUnit measurementUnit)
        {
            var dataPoints = new List<DataPoint>(8);

            for (var i = 0; i < dataPoints.Capacity; i++)
            {
                dataPoints.Add(new DataPoint
                {
                    Icon = (Icon) i,
                    ApparentTemperatureHigh = 30 + i,
                    ApparentTemperatureLow = 15 + i,
                    CloudCover = 50 + i,
                    Humidity = 75 + i,
                    DewPoint = 14.8 + i,
                    MoonPhase = 0.13 + i * 0.1,
                    Ozone = 276.2 + i,
                    PrecipIntensity = 0.1721 + i * 0.01,
                    PrecipIntensityMax = 1.5744 + i * 0.5,
                    PrecipProbability = 0.58 + i * 0.3,
                    PrecipType = PrecipitationType.Rain,
                    Pressure = 1014.34 + i * 10,
                    Summary = $"DataPoint summary {i}",
                    TemperatureHigh = 35 + i,
                    TemperatureLow = 15 - i,
                    UvIndex = 1,
                    Visibility = 300 + i * 3.5,
                    WindBearing = 286 + i * 3,
                    WindGust = 12.66 + i * 0.05,
                    WindSpeed = 4.46 + i * 0.1
                });
            }

            var weekForecast = new Forecast
            {
                Daily = new DataBlock
                {
                    Summary = "DataBlock Summary",
                    Icon = Icon.Fog,
                    Data = dataPoints
                }
            };

            var response = new ResponseModel<Forecast>
            {
                IsSuccess = true,
                Model = weekForecast
            };

            return Task.Factory.StartNew(() => response);
        }

        private static string BuildRequestUri(double latitude, double longitude, OptionalParameters parameters)
        {
            var queryString =
                new StringBuilder(FormattableString.Invariant($"forecast/{ApiKey}/{latitude:N4},{longitude:N4}"));

            if (parameters?.ForecastDateTime != null)
            {
                queryString.Append(
                    $",{parameters.ForecastDateTime.Value.ToString("yyyy-MM-ddTHH:mm:ssK", CultureInfo.InvariantCulture)}");
            }

            if (parameters != null)
            {
                queryString.Append("?");

                if (parameters.DataBlocksToExclude != null)
                {
                    queryString.Append(
                        $"&exclude={string.Join(",", parameters.DataBlocksToExclude.Select(x => x.ToString().ToLowerInvariant()))}");
                }

                if (parameters.ExtendHourly != null && parameters.ExtendHourly.Value)
                {
                    queryString.Append("&extend=hourly");
                }

                if (parameters.LanguageCode != LanguageCode.None)
                {
                    queryString.Append($"&lang={parameters.LanguageCode.ToString().ToLowerInvariant()}");
                }

                queryString.Append($"&units={parameters.MeasurementUnit.ToString().ToLowerInvariant()}");
            }

            return queryString.ToString();
        }
    }
}