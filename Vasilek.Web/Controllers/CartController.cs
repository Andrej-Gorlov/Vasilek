using Microsoft.AspNetCore.Mvc;
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
        public IActionResult CartIndex()
        {
            return View();
        }
    }
}
