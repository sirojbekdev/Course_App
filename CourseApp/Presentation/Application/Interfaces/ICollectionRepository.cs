using Presentation.Domain.Entities;

namespace Presentation.Application.Interfaces
{
    public interface ICollectionRepository : IRepository<Collection>
    {
        Task<IEnumerable<Collection>> GetCollectionsByUserIdAsync(Guid userId);
    }
}
