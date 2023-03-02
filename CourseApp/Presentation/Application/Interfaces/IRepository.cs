using Presentation.Domain.Common;
using System.Linq.Expressions;

namespace Presentation.Application.Interfaces
{
    public interface IRepository<T> where T : IAuditable
    {
        T Add(T entity);

        T Update(object id, T entity);

        T Delete(object id);

        T GetById(object id);

        List<T> GetAll();

        Task<List<T>> GetAllAsync();

        Task<T> GetByIdAsync(object id);

        Task<T> AddAsync(T entity);

        Task<T> DeleteAsync(object id);

        Task<T> UpdateAsync(object id, T entity);

        Task<T> FindAsync(Expression<Func<T, bool>> predicate);

        Task<List<T>> FindAllAsync(Expression<Func<T, bool>> predicate);
    }
}
