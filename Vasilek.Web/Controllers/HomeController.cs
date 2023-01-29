using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Concurrent;
using System.Diagnostics;
using Vasilek.Web.Models;
using Vasilek.Web.Models.ShoppingCartAPI;
using Vasilek.Web.Models.VM;
using Vasilek.Web.Services.Interfaces.IProductAPI;
using Vasilek.Web.Services.IServices;

namespace Vasilek.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;
        private readonly IShoppingCartService _shoppingCartService;
        private readonly ICategoryService _categoryService;

        public HomeController(ILogger<HomeController> logger, IProductService productService, 
            IShoppingCartService shoppingCartService, ICategoryService categoryService)
        {
            _logger = logger;
            _productService = productService;
            _shoppingCartService = shoppingCartService;
            _categoryService = categoryService;
        }

        public async Task <IActionResult> Index()
        {
            List<CategoryDtoBase>? categorys = new ();
            var response = await _categoryService.GetAllCategoryAsync<ResponseDtoBase>("");
            if (response != null && response.IsSuccess)
            {
                categorys = JsonConvert.DeserializeObject<List<CategoryDtoBase>>(Convert.ToString(response.Result));
            }
            return View(categorys);
        }



        public async Task<IActionResult> CategoryVM(string category)
        {
            ProductDtoVM  list = new();
            var response = await _productService.GetAllProductAsync<ResponseDtoBase>("");
            if (response != null && response.IsSuccess)
            {
                list.Products = JsonConvert.DeserializeObject<List<ProductDtoBase>>(Convert.ToString(response.Result)).Where(x => x.Category.CategoryName == category).ToList();
            }

            return View(list);
        }


        //[HttpGet]
        //public async Task<IActionResult> Details(int productId)
        //{
        //    ProductDtoBase model = new();
        //    var response = await _productService.GetProductByIdAsync<ResponseDtoBase>(productId, "");
        //    if (response != null && response.IsSuccess)
        //    {
        //        model = JsonConvert.DeserializeObject<ProductDtoBase>(Convert.ToString(response.Result));
        //    }
        //    return View(model);
        //}

        //[HttpPost]
        //[ActionName("Details")]
        //[Authorize]
        //public async Task<IActionResult> Details(ProductDtoVM productDto)
        public async Task<IActionResult> Details(int count, int productId)
        {
           

            CartDtoBase cartDto = new()
            {
                CartHeader = new CartHeaderDtoBase
                {
                    UserId = User.Claims.Where(u => u.Type == "sub")?.FirstOrDefault()?.Value
                }
            };

            CartDetailsDtoBase cartDetails = new ()
            {
                Count = count,
                ProductId = productId
            };

            var resp = await _productService.GetProductByIdAsync<ResponseDtoBase>(productId, "");
            
            if (resp != null && resp.IsSuccess)
            {
                cartDetails.Product = JsonConvert.DeserializeObject<ProductDtoBase>(Convert.ToString(resp.Result));
            }
            List<CartDetailsDtoBase> cartDetailsDtos = new();
            cartDetailsDtos.Add(cartDetails);

            cartDto.CartDetails = cartDetailsDtos;

            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var addToCartResp = await _shoppingCartService.AddToCartAsync<ResponseDtoBase>(cartDto, accessToken);
            
            if (addToCartResp != null && addToCartResp.IsSuccess)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [Authorize]
        public async Task< IActionResult> Login()
        {
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Logout()
        {
            return SignOut("Cookies","oidc");
        }
    }
}