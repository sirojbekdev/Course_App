using Presentation.Application.Interfaces;
using Presentation.Domain.Entities;

namespace Presentation.Infostructure.Persistence.Repositories
{
    public class CollectionCustomFieldRepository : Repository<CollectionCustomField>, ICollectionCustomFieldRepository
    {
        public CollectionCustomFieldRepository(AppDbContext context) : base(context)
        {
        }
    }
}
