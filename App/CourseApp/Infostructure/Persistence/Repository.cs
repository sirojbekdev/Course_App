using Microsoft.EntityFrameworkCore;
using Presentation.Application.Interfaces;
using Presentation.Domain.Common;

namespace Presentation.Infostructure.Persistence
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;
        private DbSet<T> _dbSet;

        public Repository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public T Add(T entity)
        {
            _dbSet.Add(entity);
            return entity;
        }        
        public async Task<T> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }

        public List<T> GetAll()
        {
            return _dbSet.ToList();
        }
        public async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public T Delete(object id)
        {
            var item =  GetById(id);
            _dbSet.Remove(item);
            return item;
        }  
        public async Task<T> DeleteAsync(object id)
        {
            var item = await GetByIdAsync(id);
            _dbSet.Remove(item);
            return item;
        }

        public T GetById(object id)
        {
            return  _dbSet.Find(id);
        }     
        public async Task<T> GetByIdAsync(object id)
        {
            return await _dbSet.FindAsync(id);
        }

        public T Update(object id, T entity)
        {
            var item =  GetById(id);
            _dbSet.Update(item);
            return item;
        }    
        public async Task<T> UpdateAsync(object id, T entity)
        {
            var item = await GetByIdAsync(id);
            _dbSet.Update(item);
            return item;
        }
    }
}
