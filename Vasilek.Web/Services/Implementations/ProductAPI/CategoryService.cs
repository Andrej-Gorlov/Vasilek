using Vasilek.Web.Models;
using Vasilek.Web.Services.Interfaces.IProductAPI;

namespace Vasilek.Web.Services.Implementations.ProductAPI
{
    public class CategoryService : BaseService, ICategoryService
    {
        private readonly IHttpClientFactory _clientFactory;
        public CategoryService(IHttpClientFactory httpClient) : base(httpClient)
        {
            _clientFactory = httpClient;
        }
        public async Task<T> CreateCategoryAsync<T>(CategoryDtoBase categoryDto, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                Api_Type = StaticDitels.ApiType.POST,
                Data = categoryDto,
                Url = StaticDitels.ProductApiBase + "/api/category",
                AccessToken = token
            });
        }
        public async Task<T> DeleteCategoryAsync<T>(int id, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                Api_Type = StaticDitels.ApiType.DELETE,
                Url = StaticDitels.ProductApiBase + "/api/category/" + id,
                AccessToken = token
            });
        }
        public async Task<T> GetAllCategoryAsync<T>(string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                Api_Type = StaticDitels.ApiType.GET,
                Url = StaticDitels.ProductApiBase + "/api/categorys",
                AccessToken = token
            });
        }
        public async Task<T> GetCategoryByIdAsync<T>(int id, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                Api_Type = StaticDitels.ApiType.GET,
                Url = StaticDitels.ProductApiBase + "/api/category/" + id,
                AccessToken = token
            });
        }
        public async Task<T> UpdateCategoryAsync<T>(CategoryDtoBase categoryDto, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                Api_Type = StaticDitels.ApiType.PUT,
                Data = categoryDto,
                Url = StaticDitels.ProductApiBase + "/api/category",
                AccessToken = token
            });
        }
    }
}
