using Vasilek.Web.Models;
using Vasilek.Web.Services.IServices;

namespace Vasilek.Web.Services
{
    public class CouponService: BaseService, ICouponService
    {
        private readonly IHttpClientFactory _clientFactory;

        public CouponService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<T> GetCoupon<T>(string couponCode, string? token = null)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                Api_Type = StaticDitels.ApiType.GET,
                Url = StaticDitels.CouponApiBase + "/api/coupon/" + couponCode,
                AccessToken = token
            });
        }
    }
}
