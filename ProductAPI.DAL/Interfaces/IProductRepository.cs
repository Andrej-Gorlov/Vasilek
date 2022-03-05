using ProductAPI.Domain.Entity.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductAPI.DAL.Interfaces
{
    public interface IProductRepository: IBaseRepository<ProductDto>
    {
    }
}
