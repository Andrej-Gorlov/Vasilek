using AutoMapper;

namespace Vasilek.Services.ShoppingCart.CouponAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(x => {
                //x.CreateMap<ProductDto, Product>().ReverseMap();
                //x.CreateMap<CartHeader, CartHeaderDto>().ReverseMap();
                //x.CreateMap<CartDetails, CartDetailsDto>().ReverseMap();
                //x.CreateMap<Cart, CartDto>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}
