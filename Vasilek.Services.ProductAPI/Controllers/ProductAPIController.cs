using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.Domain.Entity.DTO;
using ProductAPI.Service.Interfaces;

namespace Vasilek.Services.ProductAPI.Controllers
{
    [Route("api/product")]
    public class ProductAPIController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductAPIController(IProductService productService)
        {
          _productService = productService;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<object> Get()=>await _productService.GetProducts();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<object> Get(int id)=> await _productService.GetProductById(id);


        [HttpPost]
        [Authorize]
        public async Task<object> Post([FromBody] ProductDto productDto)=>
            await _productService.CreateUpdateProduct(productDto);


        [HttpPut]
        [Authorize]
        public async Task<object> Put([FromBody] ProductDto productDto) => 
            await _productService.CreateUpdateProduct(productDto);


        [HttpDelete]
        [Authorize(Roles ="Admin")]
        [Route("{id}")]
        public async Task<object> Delete(int id)=>await _productService.DeleteProduct(id);

    }
}
