using FreeWeatherApp.Models;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace FreeWeatherApp.Services
{
    public abstract class BaseNetworkService
    {
        protected abstract HttpClient HttpClient { get; set; }

        protected async Task<ResponseModel<T>> GetAsync<T>(string url)
        {
            return await ExecuteWithGeneralExceptionHandling(async () =>
            {
                var response = await HttpClient.GetAsync(url);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var json = await response.Content.ReadAsStringAsync();

                    var result = JsonConvert.DeserializeObject<T>(json, new JsonSerializerSettings
                    {
                        DateTimeZoneHandling = DateTimeZoneHandling.Local,
                    });

                    return result;
                }

                throw new HttpListenerException((int) response.StatusCode, response.ReasonPhrase);
            });
        }

        #region Private methods

        //todo [!] Add exception handling
        private async Task<ResponseModel<T>> ExecuteWithGeneralExceptionHandling<T>(Func<Task<T>> func)
        {
            var response = new ResponseModel<T>();

            if (HttpClient == null)
            {
                throw new NotImplementedException();
            }

            try
            {
                response.IsSuccess = true;
                response.Model = await func();
                //if (ConnectivityHelper.GetConnectionStatus())
                //{
                //    response.IsSuccess = true;
                //    response.Content = await func();
                //}
                //else
                //{
                //    response.IsSuccess = false;
                //    response.Message = ConstantHelper.ConnectionErrorMessage;
                //}
            }
            catch (WebException ex)
            {
                response.IsSuccess = false;
            }
            catch (HttpListenerException ex)
            {
                //var result = Enum.TryParse(ex.ErrorCode.ToString(), out HttpStatusCode status);

                response.IsSuccess = false;
                response.Code = ex.ErrorCode;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
            }

            return response;
        }

        #endregion Private methods
    }
}