using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProductAPI.DAL.Interfaces;
using ProductAPI.Domain.Entity;
using ProductAPI.Domain.Entity.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public async Task<ProductDto> CreateUpdate(ProductDto productDto)
        {
            Product product = _mapper.Map<ProductDto, Product>(productDto);
            if (product.ProductId > 0)
            {
                _db.Product.Update(product);
            }
            else
            {
                _db.Product.Add(product);
            }
            await _db.SaveChangesAsync();
            return _mapper.Map<Product, ProductDto>(product);
        }

        public async Task<bool> Delete(int productId)
        {
            try
            {
                Product? product = await _db.Product.FirstOrDefaultAsync(x => x.ProductId == productId);
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

        public async Task<IEnumerable<ProductDto>> Get()
        {
            List<Product> productList = await _db.Product.ToListAsync();
            return _mapper.Map<List<ProductDto>>(productList);
        }

        public async Task<ProductDto> GetById(int productId)
        {
            Product product = await _db.Product.Where(x => x.ProductId == productId).FirstOrDefaultAsync();
            return _mapper.Map<ProductDto>(product);
        }
    }
}
