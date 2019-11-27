using FreeWeatherApp.Enums;
using FreeWeatherApp.Helpers;
using FreeWeatherApp.Helpers.Localization;
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

        public async Task<ResponseModel<Forecast>> GetHourlyForecastAsync()
        {
            var parameters = new OptionalParameters
            {
                ExtendHourly = false,
                DataBlocksToExclude = new List<ExclusionBlock>
                {
                    ExclusionBlock.Alerts,
                    ExclusionBlock.Flags,
                    ExclusionBlock.Minutely,
                    ExclusionBlock.Currently,
                    ExclusionBlock.Daily
                }
            };

            return await GetAsync<Forecast>(await BuildRequestUri(parameters));
        }

        public async Task<ResponseModel<Forecast>> GetTodayForecastAsync()
        {
            var parameters = new OptionalParameters
            {
                ExtendHourly = false,
                DataBlocksToExclude = new List<ExclusionBlock>
                {
                    ExclusionBlock.Alerts,
                    ExclusionBlock.Flags,
                    ExclusionBlock.Minutely,
                    ExclusionBlock.Daily
                }
            };

            return await GetAsync<Forecast>(await BuildRequestUri(parameters));
        }

        public async Task<ResponseModel<Forecast>> GetTodayForecastWith24HourlyAsync()
        {
            var parameters = new OptionalParameters
            {
                ExtendHourly = false,
                DataBlocksToExclude = new List<ExclusionBlock>
                {
                    ExclusionBlock.Alerts,
                    ExclusionBlock.Flags,
                    ExclusionBlock.Minutely,
                    ExclusionBlock.Daily
                }
            };

            var forecast = await GetAsync<Forecast>(await BuildRequestUri(parameters));

            if (forecast.IsSuccess && forecast.Model?.Hourly?.Data?.Count > 24)
            {
                forecast.Model.Hourly.Data = forecast.Model.Hourly.Data.Take(24).ToList();
            }

            return forecast;
        }

        public async Task<ResponseModel<Forecast>> GetWeekForecastAsync()
        {
            var parameters = new OptionalParameters
            {
                ExtendHourly = false,
                DataBlocksToExclude = new List<ExclusionBlock>
                {
                    ExclusionBlock.Alerts,
                    ExclusionBlock.Minutely,
                    ExclusionBlock.Flags,
                    ExclusionBlock.Currently,
                    ExclusionBlock.Hourly
                }
            };

            return await GetAsync<Forecast>(await BuildRequestUri(parameters));
        }

        private static async Task<string> BuildRequestUri(OptionalParameters parameters)
        {
            var location = await LocationHelper.GetLocationAsync();

            //todo [!] Location == null
            if (location == null)
            {
                throw new Exception("Location == null");
            }

            var queryString =
                new StringBuilder(
                    FormattableString.Invariant($"forecast/{ApiKey}/{location.Latitude:N4},{location.Longitude:N4}"));

            parameters.LanguageCode = LocalizationHelper.CurrentCode;
            parameters.MeasurementUnit = MeasuresHelper.Current;

            if (parameters.ForecastDateTime != null)
            {
                queryString.Append(
                    $",{parameters.ForecastDateTime.Value.ToString("yyyy-MM-ddTHH:mm:ssK", CultureInfo.InvariantCulture)}");
            }

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

            return queryString.ToString();
        }
    }
}