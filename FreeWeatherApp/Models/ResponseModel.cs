namespace FreeWeatherApp.Models
{
    public class ResponseModel<TModel>
    {
        public bool IsSuccess { get; set; }

        public TModel Model { get; set; }

        public int Code { get; set; }

        public string ReasonPhrase { get; set; }
    }
}