using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Vasilek.Web.Models;
using Vasilek.Web.Services.Interfaces.IProductAPI;

namespace Vasilek.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        public async Task <IActionResult> ProductIndex()
        {
            List<ProductDtoBase>? products = new ();
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var respons = await _productService.GetAllProductAsync<ResponseDtoBase>(accessToken);
            if (respons!=null & respons.IsSuccess)
            {
                products = JsonConvert.DeserializeObject<List<ProductDtoBase>>(Convert.ToString(respons.Result));
            }
            return View(products);
        }

        public async Task<IActionResult> ProductCreate()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProductCreate(ProductDtoBase model)
        {
            if (ModelState.IsValid)
            {
                var accessToken = await HttpContext.GetTokenAsync("access_token");
                var respons = await _productService.CreateProductAsync<ResponseDtoBase>(model, accessToken);
                if (respons != null & respons.IsSuccess)
                    return RedirectToAction(nameof(ProductIndex));
            }
            return View(model);
        }

        public async Task<IActionResult> ProductEdit(int productId)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var respons = await _productService.GetProductByIdAsync<ResponseDtoBase>(productId, accessToken);
             if (respons != null & respons.IsSuccess)
             {
                ProductDtoBase? model = JsonConvert.DeserializeObject<ProductDtoBase>(Convert.ToString(respons.Result));
                return View(model);
             }
            return NotFound();
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProductEdit(ProductDtoBase model)
        {
            if (ModelState.IsValid)
            {
                var accessToken = await HttpContext.GetTokenAsync("access_token");
                var respons = await _productService.UpdateProductAsync<ResponseDtoBase>(model, accessToken);
                if (respons != null & respons.IsSuccess)
                    return RedirectToAction(nameof(ProductIndex));
            }
            return View(model);
        }

        public async Task<IActionResult> ProductDelete(int productId)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var respons = await _productService.GetProductByIdAsync<ResponseDtoBase>(productId, accessToken);
            if (respons != null & respons.IsSuccess)
            {
                ProductDtoBase? model = JsonConvert.DeserializeObject<ProductDtoBase>(Convert.ToString(respons.Result));
                return View(model);
            }
            return NotFound();
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProductDelete(ProductDtoBase model)
        {
            if (ModelState.IsValid)
            {
                var accessToken = await HttpContext.GetTokenAsync("access_token");
                var respons = await _productService.DeleteProductAsync<ResponseDtoBase>(model.ProductId, accessToken);
                if (respons.IsSuccess)
                    return RedirectToAction(nameof(ProductIndex));
            }
            return View(model);
        }
    }
}
