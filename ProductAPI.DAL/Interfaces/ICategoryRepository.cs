using ProductAPI.Domain.Entity.DTO;

namespace ProductAPI.DAL.Interfaces
{
    public interface ICategoryRepository : IBaseRepository<CategoryDto>
    {
        Task<CategoryDto> GetByIdAsync(int id);
    }
}
