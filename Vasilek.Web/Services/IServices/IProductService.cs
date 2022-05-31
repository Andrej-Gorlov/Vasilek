using Vasilek.Web.Models;

namespace Vasilek.Web.Services.IServices
{
    public interface IProductService: IBaseService
    {
        Task<T> GetAllProductAsync<T>(string token);
        Task<T> GetProductByIdAsync<T>(int id, string token);
        Task<T> CreateProductAsync<T>(ProductDtoBase productDto, string token);
        Task<T> UpdateProductAsync<T>(ProductDtoBase productDto, string token);
        Task<T> DeleteProductAsync<T>(int id, string token);
    }
}
