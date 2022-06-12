using Vasilek.Web.Models;
using Vasilek.Web.Services.Interfaces.IProductAPI;

namespace Vasilek.Web.Services.Implementations.ProductAPI
{
    public class ProductService : BaseService, IProductService
    {
        private readonly IHttpClientFactory _clientFactory;
        public ProductService(IHttpClientFactory httpClient) : base(httpClient)
        {
            _clientFactory = httpClient;
        }
        public async Task<T> CreateProductAsync<T>(ProductDtoBase productDto, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                Api_Type = StaticDitels.ApiType.POST,
                Data = productDto,
                Url = StaticDitels.ProductApiBase + "/api/product",
                AccessToken = token
            });
        }
        public async Task<T> DeleteProductAsync<T>(int id, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                Api_Type = StaticDitels.ApiType.DELETE,
                Url = StaticDitels.ProductApiBase + "/api/product/" + id,
                AccessToken = token
            });
        }
        public async Task<T> GetAllProductAsync<T>(string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                Api_Type = StaticDitels.ApiType.GET,
                Url = StaticDitels.ProductApiBase + "/api/products",
                AccessToken = token
            });
        }
        public async Task<T> GetProductByIdAsync<T>(int id, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                Api_Type = StaticDitels.ApiType.GET,
                Url = StaticDitels.ProductApiBase + "/api/product/" + id,
                AccessToken = token
            });
        }
        public async Task<T> UpdateProductAsync<T>(ProductDtoBase productDto, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                Api_Type = StaticDitels.ApiType.PUT,
                Data = productDto,
                Url = StaticDitels.ProductApiBase + "/api/product",
                AccessToken = token
            });
        }
    }
}
