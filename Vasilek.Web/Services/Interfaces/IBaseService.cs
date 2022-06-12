using Vasilek.Web.Models;

namespace Vasilek.Web.Services.Interfaces
{
    public interface IBaseService
    {
        ResponseDtoBase responseModel { get; set; }
        Task<T> SendAsync<T>(ApiRequest apiRequest);
    }
}
