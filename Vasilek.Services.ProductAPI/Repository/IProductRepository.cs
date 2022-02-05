using Vasilek.Services.ProductAPI.Models;

namespace Vasilek.Services.ProductAPI.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductDto>> GetProducts();
        Task<ProductDto> GetProductsById(int productId);
        Task<ProductDto> CreateUpdateProduct(ProductDto productDto); // create/update new tovar
        Task<bool> DeleteProduct(int productId);
    }
}
