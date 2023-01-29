using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Vasilek.Web.Models;
using Vasilek.Web.Services.Interfaces.IProductAPI;

namespace Vasilek.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public async Task<IActionResult> CategoryIndex()
        {
            List<CategoryDtoBase>? categorys = new();
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var respons = await _categoryService.GetAllCategoryAsync<ResponseDtoBase>(accessToken);
            if (respons != null & respons.IsSuccess)
            {
                categorys = JsonConvert.DeserializeObject<List<CategoryDtoBase>>(Convert.ToString(respons.Result));
            }
            return View(categorys);
        }

        public async Task<IActionResult> CategoryCreate()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CategoryCreate(CategoryDtoBase model)
        {
            if (ModelState.IsValid)
            {
                var accessToken = await HttpContext.GetTokenAsync("access_token");
                var respons = await _categoryService.CreateCategoryAsync<ResponseDtoBase>(model, accessToken);
                if (respons != null & respons.IsSuccess)
                {
                    return RedirectToAction(nameof(CategoryIndex));
                }
            }
            return View(model);
        }

        public async Task<IActionResult> CategoryEdit(int categoryId)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var respons = await _categoryService.GetCategoryByIdAsync<ResponseDtoBase>(categoryId, accessToken);
            if (respons != null & respons.IsSuccess)
            {
                CategoryDtoBase? model = JsonConvert.DeserializeObject<CategoryDtoBase>(Convert.ToString(respons.Result));
                return View(model);
            }
            return NotFound();
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CategoryEdit(CategoryDtoBase model)
        {
            if (ModelState.IsValid)
            {
                var accessToken = await HttpContext.GetTokenAsync("access_token");
                var respons = await _categoryService.UpdateCategoryAsync<ResponseDtoBase>(model, accessToken);
                if (respons != null & respons.IsSuccess)
                {
                    return RedirectToAction(nameof(CategoryIndex));
                }
            }
            return View(model);
        }

        public async Task<IActionResult> CategoryDelete(int categoryId)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var respons = await _categoryService.GetCategoryByIdAsync<ResponseDtoBase>(categoryId, accessToken);
            if (respons != null & respons.IsSuccess)
            {
                CategoryDtoBase? model = JsonConvert.DeserializeObject<CategoryDtoBase>(Convert.ToString(respons.Result));
                return View(model);
            }
            return NotFound();
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CategoryDelete(CategoryDtoBase model)
        {
            if (ModelState.IsValid)
            {
                var accessToken = await HttpContext.GetTokenAsync("access_token");
                var respons = await _categoryService.DeleteCategoryAsync<ResponseDtoBase>(model.CategoryId, accessToken);
                if (respons.IsSuccess)
                {
                    return RedirectToAction(nameof(CategoryIndex));
                }
            }
            return View(model);
        }
    }
}
