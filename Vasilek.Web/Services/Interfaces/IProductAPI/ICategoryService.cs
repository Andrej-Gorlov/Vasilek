using Vasilek.Web.Models;

namespace Vasilek.Web.Services.Interfaces.IProductAPI
{
    public interface ICategoryService : IBaseService
    {
        Task<T> GetAllProductAsync<T>(string token);
        Task<T> GetProductByIdAsync<T>(int id, string token);
        Task<T> CreateProductAsync<T>(CategoryDtoBase categoryDto, string token);
        Task<T> UpdateProductAsync<T>(CategoryDtoBase categoryDto, string token);
        Task<T> DeleteProductAsync<T>(int id, string token);
    }
}
