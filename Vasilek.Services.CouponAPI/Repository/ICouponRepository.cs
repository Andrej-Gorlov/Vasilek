using Vasilek.Services.CouponAPI.Models.Dto;

namespace Vasilek.Services.CouponAPI.Repository
{
    public interface ICouponRepository
    {
        Task<CouponDto> GetCouponByCode(string couponCode);
    }
}
