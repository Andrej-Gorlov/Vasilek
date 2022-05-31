using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Vasilek.Web.Models;
using Vasilek.Web.Models.ShoppingCartAPI;
using Vasilek.Web.Services.IServices;

namespace Vasilek.Web.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductService _productService;
        private readonly IShoppingCartService _cartService;
        public CartController(IProductService productService, IShoppingCartService cartService)
        {
            _productService = productService;
            _cartService = cartService;
        }
        public async Task<IActionResult> CartIndex()
        {
            return View(await LoadCartDtoBasedOnLoggedInUser());
        }

        private async Task<CartDtoBase> LoadCartDtoBasedOnLoggedInUser()
        {
            var userId = User.Claims.Where(u => u.Type == "sub")?.FirstOrDefault()?.Value;
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var response = await _cartService.GetCartByUserIdAsnyc<ResponseDtoBase>(userId, accessToken);

            CartDtoBase? cartDto = new();
            if (response != null && response.IsSuccess)
            {
                cartDto = JsonConvert.DeserializeObject<CartDtoBase>(Convert.ToString(response.Result));
            }

            if (cartDto.CartHeader != null)
            {
                //if (!string.IsNullOrEmpty(cartDto.CartHeader.CouponCode))
                //{
                //    var coupon = await _couponService.GetCoupon<ResponseDto>(cartDto.CartHeader.CouponCode, accessToken);
                //    if (coupon != null && coupon.IsSuccess)
                //    {
                //        var couponObj = JsonConvert.DeserializeObject<CouponDto>(Convert.ToString(coupon.Result));
                //        cartDto.CartHeader.DiscountTotal = couponObj.DiscountAmount;
                //    }
                //}

                foreach (var detail in cartDto.CartDetails)
                {
                    cartDto.CartHeader.OrderTotal += (detail.Product.Price * detail.Count);
                }

                //cartDto.CartHeader.OrderTotal -= cartDto.CartHeader.DiscountTotal;
            }
            return cartDto;
        }
    }
}
