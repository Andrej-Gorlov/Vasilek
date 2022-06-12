using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProductAPI.DAL.Interfaces;
using ProductAPI.Domain.Entity;
using ProductAPI.Domain.Entity.DTO;

namespace ProductAPI.DAL.Repository
{
    public class ProductRepository: IProductRepository
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;
        public ProductRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<ProductDto> CreateAsync(ProductDto model)
        {
            Product product = _mapper.Map<ProductDto, Product>(model);
            _db.Product.Add(product);
            await _db.SaveChangesAsync();
            return _mapper.Map<Product, ProductDto>(product);
        }
        public async Task<bool> DeleteAsync(int id)
        {
            Product? product = await _db.Product.FirstOrDefaultAsync(x => x.ProductId == id);
            if (product is null)
            {
                return false;
            }
            _db.Product.Remove(product);
            await _db.SaveChangesAsync();
            return true;
        }
        public async Task<IEnumerable<ProductDto>> GetAsync() =>

            _mapper.Map<IEnumerable<ProductDto>>(await _db.Product.Include(c => c.Category).ToListAsync());

        public async Task<ProductDto> GetByIdAsync(int id) =>

            _mapper.Map<ProductDto>(await _db.Product.Include(c => c.Category).FirstOrDefaultAsync(x => x.ProductId == id));

        public async Task<ProductDto> UpdateAsync(ProductDto model)
        {
            Product product = _mapper.Map<ProductDto, Product>(model);
            if (await _db.Product.AsNoTracking().FirstOrDefaultAsync(x => x.ProductId == model.ProductId) is null)
            {
                throw new NullReferenceException("Попытка обновить объект, которого нет в хранилище.");
            }
            _db.Product.Update(product);
            await _db.SaveChangesAsync();
            return _mapper.Map<Product, ProductDto>(product);
        }
    }
}
