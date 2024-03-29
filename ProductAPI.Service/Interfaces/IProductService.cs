﻿using ProductAPI.Domain.Entity.DTO;
using ProductAPI.Domain.Response;

namespace ProductAPI.Service.Interfaces
{
    public interface IProductService : IBaseService<ProductDto>
    {
        Task<IBaseResponse<ProductDto>> GetByIdAsync(int id);
    }
}
