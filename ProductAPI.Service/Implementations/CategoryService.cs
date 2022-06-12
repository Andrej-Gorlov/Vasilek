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
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository? _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<IBaseResponse<CategoryDto>> CreateServiceAsync(CategoryDto modelDto)
        {
            var categorys = await _categoryRepository.GetAsync();
            if (categorys.FirstOrDefault(x => x.CategoryId== modelDto.CategoryId) != null)
            {
                throw new Exception("Попытка добавить объект, который уже существует в хранилище.");
            }
            var baseResponse = new BaseResponse<CategoryDto>();
            var category = await _categoryRepository.CreateAsync(modelDto);
            if (category != null)
            {
                baseResponse.IsSuccess = true;
            }
            baseResponse.Result = category;
            return baseResponse;
        }
        public async Task<IBaseResponse<bool>> DeleteServiceAsync(int id)
        {
            var baseResponse = new BaseResponse<bool>();
            bool IsSuccess = await _categoryRepository.DeleteAsync(id);
            if (IsSuccess)
            {
                baseResponse.IsSuccess = true;
            }
            baseResponse.Result = IsSuccess;
            return baseResponse;
        }
        public async Task<IBaseResponse<CategoryDto>> GetByIdAsync(int id)
        {
            var baseResponse = new BaseResponse<CategoryDto>();
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category != null)
            {
                baseResponse.IsSuccess = true;
            }
            baseResponse.Result = category;
            return baseResponse;
        }
        public async Task<IBaseResponse<IEnumerable<CategoryDto>>> GetServiceAsync()
        {
            var baseResponse = new BaseResponse<IEnumerable<CategoryDto>>();
            var categorys = await _categoryRepository.GetAsync();
            if (categorys.Count() != 0)
            {
                baseResponse.IsSuccess = true;
                baseResponse.DisplayMessage = "Сущность [Category] пуста";
            }
            baseResponse.Result = categorys;
            return baseResponse;
        }
        public async Task<IBaseResponse<CategoryDto>> UpdateServiceAsync(CategoryDto modelDto)
        {
            var baseResponse = new BaseResponse<CategoryDto>();
            var category = await _categoryRepository.UpdateAsync(modelDto);
            baseResponse.IsSuccess = true;
            baseResponse.Result = category;
            return baseResponse;
        }
    }
}
