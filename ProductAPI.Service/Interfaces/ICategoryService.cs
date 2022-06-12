using ProductAPI.Domain.Entity.DTO;
using ProductAPI.Domain.Response;

namespace ProductAPI.Service.Interfaces
{
    public interface ICategoryService : IBaseService<CategoryDto>
    {
        Task<IBaseResponse<CategoryDto>> GetByIdAsync(int id);
    }
}
