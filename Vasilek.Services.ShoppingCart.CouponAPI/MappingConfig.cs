﻿using AutoMapper;
using Vasilek.Services.ShoppingCart.CouponAPI.Models;
using Vasilek.Services.ShoppingCart.CouponAPI.Models.Dto;

namespace Vasilek.Services.ShoppingCart.CouponAPI
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
