using AutoMapper;
using Vasilek.Services.CouponAPI.Models;
using Vasilek.Services.CouponAPI.Models.Dto;

namespace Vasilek.Services.CouponAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(x => {
                x.CreateMap<CouponDto, Coupon>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}
