using AutoMapper;
using Vasilek.Services.ProductAPI.Models;
using Vasilek.Services.ProductAPI.Models.Dto;

namespace Vasilek.Services.ProductAPI
{
    public class MappingConfig
    {
        //преобразования ProductDto в Product и наоборот
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(x =>{
                 x.CreateMap<ProductDto, Product>();
                 x.CreateMap<Product, ProductDto>();
            });
            return mappingConfig;
        }
    }
}
