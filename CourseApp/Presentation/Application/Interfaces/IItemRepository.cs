using Presentation.Domain.Entities;

namespace Presentation.Application.Interfaces
{
    public interface IItemRepository : IRepository<Item>
    {
        Task<IEnumerable<Item>> GetItemsByUserIdAsync(Guid userId);
    }
}
