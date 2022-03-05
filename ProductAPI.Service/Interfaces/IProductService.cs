using ProductAPI.Domain.Entity.DTO;
using ProductAPI.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductAPI.Service.Interfaces
{
    public interface IProductService
    {
        Task<IBaseResponse<IEnumerable<ProductDto>>> GetProducts();
        Task<IBaseResponse<ProductDto>> GetProductById(int id);
        Task<IBaseResponse<ProductDto>> CreateUpdateProduct(ProductDto productDto);
        Task<IBaseResponse<bool>> DeleteProduct(int id);
    }
}
