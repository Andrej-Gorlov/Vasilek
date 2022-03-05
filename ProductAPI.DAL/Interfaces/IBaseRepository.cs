using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductAPI.DAL.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<IEnumerable<T>> Get();
        Task<T> GetById(int productId);
        Task<T> CreateUpdate(T productDto);
        Task<bool> Delete(int productId);
    }
}
