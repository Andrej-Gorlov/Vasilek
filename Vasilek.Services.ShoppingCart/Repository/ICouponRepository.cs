using Vasilek.Services.ShoppingCart.Models.Dto;

namespace Vasilek.Services.ShoppingCart.Repository
{
    public interface ICouponRepository
    {
        Task<CouponDto> GetCoupon(string couponName);
    }
}
