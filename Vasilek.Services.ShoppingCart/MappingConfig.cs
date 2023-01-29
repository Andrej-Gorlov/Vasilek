using AutoMapper;
using Vasilek.Services.ShoppingCart.Models;
using Vasilek.Services.ShoppingCart.Models.Dto;

namespace Vasilek.Services.ShoppingCart
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(x => {
                x.CreateMap<ProductDto, Product>().ReverseMap();
                x.CreateMap<CategoryDto, Category>().ReverseMap();
                x.CreateMap<CartHeader, CartHeaderDto>().ReverseMap();
                x.CreateMap<CartDetails, CartDetailsDto>().ReverseMap();
                x.CreateMap<Cart, CartDto>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}
