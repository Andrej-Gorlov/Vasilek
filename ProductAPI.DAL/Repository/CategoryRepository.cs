using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProductAPI.DAL.Interfaces;
using ProductAPI.Domain.Entity;
using ProductAPI.Domain.Entity.DTO;

namespace ProductAPI.DAL.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;
        public CategoryRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<CategoryDto> CreateAsync(CategoryDto model)
        {
            Category category = _mapper.Map<CategoryDto, Category>(model);
            _db.Category.Add(category);
            await _db.SaveChangesAsync();
            return _mapper.Map<Category, CategoryDto>(category);
        }
        public async Task<bool> DeleteAsync(int id)
        {
            Category? category = await _db.Category.FirstOrDefaultAsync(x => x.CategoryId == id);
            if (category is null)
            {
                return false;
            }
            _db.Category.Remove(category);
            await _db.SaveChangesAsync();
            return true;
        }
        public async Task<IEnumerable<CategoryDto>> GetAsync() =>

            _mapper.Map<IEnumerable<CategoryDto>>(await _db.Category.ToListAsync());

        public async Task<CategoryDto> GetByIdAsync(int id) =>

             _mapper.Map<CategoryDto>(await _db.Category.FirstOrDefaultAsync(x => x.CategoryId == id));

        public async Task<CategoryDto> UpdateAsync(CategoryDto model)
        {
            Category category = _mapper.Map<CategoryDto, Category>(model);
            if (await _db.Category.AsNoTracking().FirstOrDefaultAsync(x => x.CategoryId == model.CategoryId) is null)
            {
                throw new NullReferenceException("Попытка обновить объект, которого нет в хранилище.");
            }
            _db.Category.Update(category);
            await _db.SaveChangesAsync();
            return _mapper.Map<Category, CategoryDto>(category);
        }
    }
}
