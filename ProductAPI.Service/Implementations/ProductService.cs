using ProductAPI.DAL.Interfaces;
using ProductAPI.Domain.Entity.DTO;
using ProductAPI.Domain.Response;
using ProductAPI.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductAPI.Service.Implementations
{
    public class ProductService: IProductService
    {
        private IProductRepository? _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<IBaseResponse<ProductDto>> CreateUpdateProduct(ProductDto productDto)
        {
            var baseResponse = new BaseResponse<ProductDto>();
            try
            {
                ProductDto model = await _productRepository.CreateUpdate(productDto);
                baseResponse.Result = model;
            }
            catch (Exception ex)
            {
                baseResponse.IsSuccess = false;
                baseResponse.ErrorMessages = new List<string> { ex.ToString() };
            }
            return baseResponse;
        }
        public async Task<IBaseResponse<bool>> DeleteProduct(int id)
        {
            var baseResponse = new BaseResponse<bool>();
            try
            {
                bool IsSuccess = await _productRepository.Delete(id);
                baseResponse.Result = IsSuccess;
            }
            catch (Exception ex)
            {
                baseResponse.IsSuccess = false;
                baseResponse.ErrorMessages = new List<string> { ex.ToString() };
            }
            return baseResponse;
        }
        public async Task<IBaseResponse<ProductDto>> GetProductById(int id)
        {
            var baseResponse = new BaseResponse<ProductDto>();
            try
            {
                ProductDto productDto = await _productRepository.GetById(id);
                baseResponse.Result = productDto;
            }
            catch (Exception ex)
            {
                baseResponse.IsSuccess = false;
                baseResponse.ErrorMessages = new List<string> { ex.ToString() };
            }
            return baseResponse;
        }
        public async Task<IBaseResponse<IEnumerable<ProductDto>>> GetProducts()
        {
            var baseResponse = new BaseResponse<IEnumerable<ProductDto>>();
            try
            {
                IEnumerable<ProductDto> productDtos = await _productRepository.Get();
                baseResponse.Result = productDtos;
            }
            catch (Exception ex)
            {
                baseResponse.IsSuccess = false;
                baseResponse.ErrorMessages = new List<string> { ex.ToString() };
            }
            return baseResponse;
        }
    }
}
