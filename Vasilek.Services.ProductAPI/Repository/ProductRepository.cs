using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Vasilek.Services.ProductAPI.DbContexts;
using Vasilek.Services.ProductAPI.Models;
using Vasilek.Services.ProductAPI.Models.Dto;

namespace Vasilek.Services.ProductAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;
        public ProductRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db=db;
           _mapper=mapper;  
        }
        public async Task<ProductDto> CreateUpdateProduct(ProductDto productDto)
        {
            Product product=_mapper.Map<ProductDto,Product>(productDto);
            if (product.ProductId>0)//t.e update
            {
                _db.Product.Update(product);
            }
            else
            {
                _db.Product.Add(product);
            }
            await _db.SaveChangesAsync();
            return _mapper.Map<Product,ProductDto>(product);
        }

        public async Task<bool> DeleteProduct(int productId)
        {
            try
            {
                Product product=await _db.Product.FirstOrDefaultAsync(x => x.ProductId==productId);
                if (product == null)
                    return false;
                _db.Product.Remove(product);    
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            List < Product > productList = await _db.Product.ToListAsync();
            return _mapper.Map<List<ProductDto>>(productList);// преобразуем в объект dto
        }

        public async Task<ProductDto> GetProductsById(int productId)
        {
            Product product = await _db.Product.Where(x=>x.ProductId==productId).FirstOrDefaultAsync();
            return _mapper.Map<ProductDto>(product);// преобразуем в объект dto
        }
    }
}
