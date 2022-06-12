using AutoMapper;
using ProductAPI.Domain.Entity;
using ProductAPI.Domain.Entity.DTO;

namespace Vasilek.Services.ProductAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(x =>{
                x.CreateMap<Product, ProductDto>().ReverseMap();
                x.CreateMap<Category, CategoryDto>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}
