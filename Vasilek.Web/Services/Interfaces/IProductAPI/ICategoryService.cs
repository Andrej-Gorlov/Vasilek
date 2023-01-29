using Vasilek.Web.Models;

namespace Vasilek.Web.Services.Interfaces.IProductAPI
{
    public interface ICategoryService : IBaseService
    {
        Task<T> GetAllCategoryAsync<T>(string token);
        Task<T> GetCategoryByIdAsync<T>(int id, string token);
        Task<T> CreateCategoryAsync<T>(CategoryDtoBase categoryDto, string token);
        Task<T> UpdateCategoryAsync<T>(CategoryDtoBase categoryDto, string token);
        Task<T> DeleteCategoryAsync<T>(int id, string token);
    }
}
