using ProductAPI.DAL.Interfaces;
using ProductAPI.Domain.Entity.DTO;
using ProductAPI.Domain.Response;
using ProductAPI.Service.Interfaces;

namespace ProductAPI.Service.Implementations
{
    public class ProductService: IProductService
    {
        private readonly IProductRepository? _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<IBaseResponse<ProductDto>> CreateServiceAsync(ProductDto modelDto)
        {
            var products = await _productRepository.GetAsync();
            if (products.FirstOrDefault(x => x.ProductId == modelDto.ProductId) != null)
            {
                throw new Exception("Попытка добавить объект, который уже существует в хранилище.");
            }
            var baseResponse = new BaseResponse<ProductDto>();
            var product = await _productRepository.CreateAsync(modelDto);
            if (product != null)
            {
                baseResponse.IsSuccess = true;
            }
            baseResponse.Result = product;
            return baseResponse;
        }
        public async Task<IBaseResponse<bool>> DeleteServiceAsync(int id)
        {
            var baseResponse = new BaseResponse<bool>();
            bool IsSuccess = await _productRepository.DeleteAsync(id);
            if (IsSuccess)
            {
                baseResponse.IsSuccess = true;
            }
            baseResponse.Result = IsSuccess;
            return baseResponse;
        }
        public async Task<IBaseResponse<ProductDto>> GetByIdAsync(int id)
        {
            var baseResponse = new BaseResponse<ProductDto>();
            var product = await _productRepository.GetByIdAsync(id);
            if (product != null)
            {
                baseResponse.IsSuccess = true;
            }
            baseResponse.Result = product;
            return baseResponse;
        }
        public async Task<IBaseResponse<IEnumerable<ProductDto>>> GetServiceAsync()
        {
            var baseResponse = new BaseResponse<IEnumerable<ProductDto>>();
            var products = await _productRepository.GetAsync();
            if (products.Count() is 0)
            {
                baseResponse.IsSuccess = true;
                baseResponse.DisplayMessage = "Сущность [Product] пуста";
            }
            baseResponse.Result = products;
            return baseResponse;
        }
        public async Task<IBaseResponse<ProductDto>> UpdateServiceAsync(ProductDto modelDto)
        {
            var baseResponse = new BaseResponse<ProductDto>();
            var product = await _productRepository.UpdateAsync(modelDto);
            baseResponse.IsSuccess = true;
            baseResponse.Result = product;
            return baseResponse;
        }
    }
}
