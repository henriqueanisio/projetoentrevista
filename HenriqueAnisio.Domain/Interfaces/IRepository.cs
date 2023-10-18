using HenriqueAnisio.Domain.Models;
using System.Linq.Expressions;

namespace HenriqueAnisio.Domain.Interfaces
{
    public interface IRepository<T> : IDisposable where T : Entity
    {
        Task DeleteAsync(Guid id);
        Task<IEnumerable<T>> GetAllWithIncludeAsync(params Expression<Func<T, object>>[] includes);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate);
        Task<T> GetById(Guid Id);
        Task InsertAsync(T entity);
        Task UpdateAsync(T entity);
        Task<int> SaveChangesAsync();
    }
}
