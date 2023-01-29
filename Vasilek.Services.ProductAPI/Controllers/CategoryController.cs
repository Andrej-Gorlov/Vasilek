using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.Domain.Entity.DTO;
using ProductAPI.Service.Interfaces;

namespace Vasilek.Services.ProductAPI.Controllers
{
    [Route("api/")]
    [Produces("application/json")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        /// <summary>
        /// Список всех категорий.
        /// </summary>
        /// <returns>Вывод всех категорий.</returns>
        /// <remarks>
        /// Образец запроса:
        /// 
        ///     GET /categorys
        ///
        /// </remarks> 
        /// <response code="200"> Запрос прошёл. (Успех) </response>
        /// <response code="404"> Список категорий не найден. </response>
        /// <response code="500"> Внутренняя ошибка сервера. </response>
        [HttpGet]
        [Route("categorys")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<object> Get()
        {
            var categorys = await _categoryService.GetServiceAsync();
            if (categorys.Result.Count() is 0)
            {
                return NotFound(categorys);
            }
            return Ok(categorys);
        }
        /// <summary>
        /// Вывод категории по id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Вывод данных категории.</returns>
        /// <remarks>
        /// Образец запроса:
        /// 
        ///     GET /category/{id}
        ///     
        ///        CategoryId: 0   // Введите id категории, который нужно показать.
        ///     
        /// </remarks>
        /// <response code="200"> Запрос прошёл. (Успех) </response>
        /// <response code="400"> Недопустимое значение ввода </response>
        /// <response code="404"> Категория не найден. </response>
        /// <response code="500"> Внутренняя ошибка сервера. </response>
        [HttpGet]
        [Route("category/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0)
            {
                return BadRequest($"id: [{id}] не может быть меньше или равно нулю");
            }
            var category = await _categoryService.GetByIdAsync(id);
            if (category.Result is null)
            {
                return NotFound(category);
            }
            return Ok(category);
        }
        /// <summary>
        /// Создание нового категории.
        /// </summary>
        /// <param name="categoryDto"></param>
        /// <returns>Создаётся категория.</returns>
        /// <remarks>
        /// 
        /// Образец ввовда данных:
        ///
        ///     POST /category
        ///     
        ///     {
        ///       "CategoryId": 0,          // id категории.
        ///       "ProductId": 0,           // id продукта, которая принадлежит категория.                            
        ///       "CategoryName" "string"   // Наименование категории.
        ///     }
        ///
        /// </remarks>
        /// <response code="201"> Категория создана. </response>
        /// <response code="400"> Введены недопустимые данные. </response>
        /// <response code="500"> Внутренняя ошибка сервера. </response>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [Route("category")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] CategoryDto categoryDto)
        {
            if (ModelState.IsValid)
            {
                var category = await _categoryService.CreateServiceAsync(categoryDto);
                return CreatedAtAction(nameof(Get), category);
            }
            return BadRequest("Введены недопустимые данные");
        }
        /// <summary>
        /// Обновление категории.
        /// </summary>
        /// <param name="categoryDto"></param>
        /// <returns> Обновление категории.</returns>
        /// <remarks>
        /// 
        /// Образец ввовда данных:
        ///
        ///     PUT /category
        ///     
        ///     {
        ///       "CategoryId": 0,          // id категории.
        ///       "ProductId": 0,           // id продукта, которая принадлежит категория.                            
        ///       "CategoryName" "string"   // Наименование категории.
        ///     }
        ///
        /// </remarks>
        /// <response code="200"> Запрос прошёл. (Успех) </response>
        /// <response code="400"> Введены недопустимые данные. </response>
        /// <response code="404"> Категория не найдена. </response>
        /// <response code="500"> Внутренняя ошибка сервера. </response>
        [HttpPut]
        [Authorize(Roles = "Admin")]
        [Route("category")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update([FromBody] CategoryDto categoryDto)
        {
            if (ModelState.IsValid)
            {
                var category = await _categoryService.UpdateServiceAsync(categoryDto);
                if (category.Result is null)
                {
                    return NotFound(category);
                }
                return Ok(category);
            }
            return BadRequest("Введены недопустимые данные");
        }
        /// <summary>
        /// Удаление категории по id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Категория удаляется.</returns>
        /// <remarks>
        /// Образец запроса:
        /// 
        ///     DELETE /category/{id}
        ///     
        ///        CategoryId: 0   // Введите id категории, которую нужно удалить.
        ///     
        /// </remarks>
        /// <response code="204"> Категория удалёна. (нет содержимого) </response>
        /// <response code="400"> Недопустимое значение ввода </response>
        /// <response code="404"> Категория c указанным id не найден. </response>
        /// <response code="500"> Внутренняя ошибка сервера. </response>
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        [Route("category/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest($"id: [{id}] не может быть меньше или равно нулю");
            }
            var category = await _categoryService.DeleteServiceAsync(id);
            if (category.Result is false)
            {
                return NotFound(category);
            }
            //return NoContent();
            return Ok(category);
        }
    }
}
