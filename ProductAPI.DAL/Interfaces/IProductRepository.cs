using ProductAPI.Domain.Entity.DTO;

namespace ProductAPI.DAL.Interfaces
{
    public interface IProductRepository: IBaseRepository<ProductDto>
    {
        Task<ProductDto> GetByIdAsync(int id);
    }
}
