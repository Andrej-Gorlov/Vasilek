using static Vasilek.Web.StaticDitels;

namespace Vasilek.Web.Models
{
    public class ApiRequest
    {
        public ApiType Api_Type { get; set; } = ApiType.GET;// тип запроса
        public string? Url { get; set; } // url adres по которму отпровляем request api
        public object? Data { get; set; } // передача data в теле messenger
        public string? AccessToken { get; set; }//для идентификации

    }
}
