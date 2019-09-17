using FreeWeatherApp.Enums;
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

        public async Task<ResponseModel<Forecast>> GetHourlyForecastAsync(
            double latitude,
            double longitude,
            LanguageCode languageCode,
            MeasurementUnit measurementUnit)
        {
            var parameters = new OptionalParameters
            {
                ExtendHourly = false,
                LanguageCode = languageCode,
                MeasurementUnit = measurementUnit,
                DataBlocksToExclude = new List<ExclusionBlock>
                {
                    ExclusionBlock.Alerts,
                    ExclusionBlock.Flags,
                    ExclusionBlock.Minutely,
                    ExclusionBlock.Currently,
                    ExclusionBlock.Daily
                }
            };

            return await GetAsync<Forecast>(BuildRequestUri(latitude, longitude, parameters));
        }

        public async Task<ResponseModel<Forecast>> GetTodayForecastAsync(
            double latitude,
            double longitude,
            LanguageCode languageCode,
            MeasurementUnit measurementUnit)
        {
            var parameters = new OptionalParameters
            {
                ExtendHourly = false,
                LanguageCode = languageCode,
                MeasurementUnit = measurementUnit,
                DataBlocksToExclude = new List<ExclusionBlock>
                {
                    ExclusionBlock.Alerts,
                    ExclusionBlock.Flags,
                    ExclusionBlock.Minutely,
                    ExclusionBlock.Hourly,
                    ExclusionBlock.Daily
                }
            };

            return await GetAsync<Forecast>(BuildRequestUri(latitude, longitude, parameters));
        }

        public async Task<ResponseModel<Forecast>> GetWeekForecastAsync(
            double latitude,
            double longitude,
            LanguageCode languageCode,
            MeasurementUnit measurementUnit)
        {
            var parameters = new OptionalParameters
            {
                ExtendHourly = false,
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