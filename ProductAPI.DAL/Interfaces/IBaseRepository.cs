namespace ProductAPI.DAL.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<IEnumerable<T>> GetAsync();
        Task<T> CreateAsync(T model);
        Task<bool> DeleteAsync(int id);
        Task<T> UpdateAsync(T model);
    }
}
