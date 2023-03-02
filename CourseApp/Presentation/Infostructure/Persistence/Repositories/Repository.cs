using Microsoft.EntityFrameworkCore;
using Presentation.Application.Interfaces;
using Presentation.Domain.Common;
using System.Linq.Expressions;

namespace Presentation.Infostructure.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        internal readonly AppDbContext _context;
        internal DbSet<T> _dbSet;

        public Repository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public virtual T Add(T entity)
        {
            _dbSet.Add(entity);
            return entity;
        }
        public virtual async Task<T> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public virtual List<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public virtual async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual T Delete(object id)
        {
            var item = GetById(id);
            _dbSet.Remove(item);
            return item;
        }
        public virtual async Task<T> DeleteAsync(object id)
        {
            var item = await GetByIdAsync(id);
            _dbSet.Remove(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public virtual T GetById(object id)
        {
            return _dbSet.Find(id);
        }
        public virtual async Task<T> GetByIdAsync(object id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual T Update(object id, T entity)
        {
            var item = GetById(id);
            _dbSet.Update(item);
            return item;
        }
        public virtual async Task<T> UpdateAsync(object id, T entity)
        {
            var item = await GetByIdAsync(id);
            _dbSet.Update(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public virtual async Task<List<T>> FindAllAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public virtual async Task<T> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.SingleAsync(predicate);
        }
    }
}
