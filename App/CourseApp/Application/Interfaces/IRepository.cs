using Presentation.Domain.Common;

namespace Presentation.Application.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        List<T> GetAll();
        Task<List<T>> GetAllAsync();
        T GetById(object id);
        Task<T> GetByIdAsync(object id);
        T Add(T entity);
        Task<T> AddAsync(T entity);
        T Delete(object id);
        Task<T> DeleteAsync(object id);
        T Update(object id, T entity);
        Task<T> UpdateAsync(object id, T entity);
    }
}
