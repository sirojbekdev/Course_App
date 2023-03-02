using Microsoft.EntityFrameworkCore;
using Presentation.Application.Interfaces;
using Presentation.Domain.Entities;

namespace Presentation.Infostructure.Persistence.Repositories
{
    public class ItemRepository : Repository<Item>, IItemRepository
    {
        public ItemRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Item>> GetItemsByUserIdAsync(Guid userId)
        {
            return await _dbSet.Where(x => x.AppUserId == userId).ToListAsync();
        }
    }
}
