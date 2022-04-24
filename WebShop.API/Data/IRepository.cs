using System.Linq.Expressions;

namespace WebShop.API.Data
{
    public interface IRepository<T> where T : class
    {
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task RemoveAsync(T entity);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter = null);
        Task<T> GetFirstAsync(Expression<Func<T, bool>> filter);
    }
}
