using Microsoft.EntityFrameworkCore;
using Presentation.Application.Interfaces;
using Presentation.Domain.Entities;

namespace Presentation.Infostructure.Persistence.Repositories
{
    public class CollectionRepository : Repository<Collection>, ICollectionRepository
    {
        public CollectionRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Collection>> GetCollectionsByUserIdAsync(Guid userId)
        {
            return await _dbSet.Where(x => x.AppUserId == userId).ToListAsync();
        }
    }
}
