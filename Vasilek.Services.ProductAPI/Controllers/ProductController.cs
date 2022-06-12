using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.Domain.Entity.DTO;
using ProductAPI.Service.Interfaces;

namespace Vasilek.Services.ProductAPI.Controllers
{
    [Route("api/")]
    [Produces("application/json")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        /// <summary>
        /// Список всех продуктов.
        /// </summary>
        /// <returns>Вывод всех продуктов.</returns>
        /// <remarks>
        /// Образец запроса:
        /// 
        ///     GET /products
        ///
        /// </remarks> 
        /// <response code="200"> Запрос прошёл. (Успех) </response>
        /// <response code="404"> Список продуктов не найден. </response>
        /// <response code="500"> Внутренняя ошибка сервера. </response>
        [HttpGet]
        [Route("products")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<object> Get()
        {
            var products = await _productService.GetServiceAsync();
            if (products.Result.Count() is 0)
            {
                return NotFound(products);
            }
            return Ok(products);
        }
        /// <summary>
        /// Вывод продукта по id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Вывод данных продукта.</returns>
        /// <remarks>
        /// Образец запроса:
        /// 
        ///     GET /product/{id}
        ///     
        ///        ProductId: 0   // Введите id продукта, который нужно показать.
        ///     
        /// </remarks>
        /// <response code="200"> Запрос прошёл. (Успех) </response>
        /// <response code="400"> Недопустимое значение ввода </response>
        /// <response code="404"> Продукт не найден. </response>
        /// <response code="500"> Внутренняя ошибка сервера. </response>
        [HttpGet]
        [Route("product/{id:int}")]
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
            var product = await _productService.GetByIdAsync(id);
            if (product.Result is null)
            {
                return NotFound(product);
            }
            return Ok(product);
        }
        /// <summary>
        /// Создание нового продукта.
        /// </summary>
        /// <param name="productDto"></param>
        /// <returns>Создаётся продукт.</returns>
        /// <remarks>
        /// 
        /// Образец ввовда данных:
        ///
        ///     POST /product
        ///     
        ///     {
        ///       "ProductId": 0,                // id продукта.
        ///       "Name": "string",              // Наименование продукта.                            
        ///       "Price" 0.0,                   // Цена.
        ///       "Description": "string",       // Описание продукта.
        ///       "Category": [                  // Данные категории.
        ///         {
        ///           "CategoryId": 0,           // id категории.
        ///           "ProductId": 0,            // id продукта, которой принадлежит категория.
        ///           "CategoryName": "string"   // Наименование категории.
        ///         }         
        ///       ],
        ///       "ImageUrl": "string"           // URL изображения продукта. 
        ///     }
        ///
        /// </remarks>
        /// <response code="201"> Продукт создан. </response>
        /// <response code="400"> Введены недопустимые данные. </response>
        /// <response code="500"> Внутренняя ошибка сервера. </response>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [Route("product")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] ProductDto productDto)
        {
            if (ModelState.IsValid)
            {
                var product = await _productService.CreateServiceAsync(productDto);
                return CreatedAtAction(nameof(Get), product);
            }
            return BadRequest("Введены недопустимые данные");
        }
        /// <summary>
        /// Обновление продукта.
        /// </summary>
        /// <param name="productDto"></param>
        /// <returns> Обновление продукта.</returns>
        /// <remarks>
        /// 
        /// Образец ввовда данных:
        ///
        ///     PUT /product
        ///     
        ///     {
        ///       "ProductId": 0,                // id продукта.
        ///       "Name": "string",              // Наименование продукта.                            
        ///       "Price" 0.0,                   // Цена.
        ///       "Description": "string",       // Описание продукта.
        ///       "Category": [                  // Данные категории.
        ///         {
        ///           "CategoryId": 0,           // id категории.
        ///           "ProductId": 0,            // id продукта, которой принадлежит категория.
        ///           "CategoryName": "string"   // Наименование категории.
        ///         }         
        ///       ],
        ///       "ImageUrl": "string"           // URL изображения продукта. 
        ///     }
        ///
        /// </remarks>
        /// <response code="200"> Запрос прошёл. (Успех) </response>
        /// <response code="400"> Введены недопустимые данные. </response>
        /// <response code="404"> Продукт не найден. </response>
        /// <response code="500"> Внутренняя ошибка сервера. </response>
        [HttpPut]
        [Authorize(Roles = "Admin")]
        [Route("product")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update([FromBody] ProductDto productDto)
        {
            if (ModelState.IsValid)
            {
                var product = await _productService.UpdateServiceAsync(productDto);
                if (product.Result is null)
                {
                    return NotFound(product);
                }
                return Ok(product);
            }
            return BadRequest("Введены недопустимые данные");
        }
        /// <summary>
        /// Удаление продукта по id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Продукт удаляется.</returns>
        /// <remarks>
        /// Образец запроса:
        /// 
        ///     DELETE /product/{id}
        ///     
        ///        ProductId: 0   // Введите id продукта, который нужно удалить.
        ///     
        /// </remarks>
        /// <response code="204"> Продукт удалён. (нет содержимого) </response>
        /// <response code="400"> Недопустимое значение ввода </response>
        /// <response code="404"> Продукт c указанным id не найден. </response>
        /// <response code="500"> Внутренняя ошибка сервера. </response>
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        [Route("product/{id}")]
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
            var product = await _productService.DeleteServiceAsync(id);
            if (product.Result is false)
            {
                return NotFound(product);
            }
            return NoContent();
        }
    }
}
