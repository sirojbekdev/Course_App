using Presentation.Application.Interfaces;
using Presentation.Domain.Entities;

namespace Presentation.Infostructure.Persistence.Repositories
{
    public class ItemCustomFieldRepository : Repository<ItemCustomField>, IItemCustomFieldRepository
    {
        public ItemCustomFieldRepository(AppDbContext context) : base(context)
        {
        }
    }
}
