using Presentation.Application.Interfaces;
using Presentation.Domain.Entities;

namespace Presentation.Infostructure.Persistence.Repositories
{
    public class CustomFieldMapperRepository : Repository<CustomFieldMapper>, ICustomFieldMapperRepository
    {
        public CustomFieldMapperRepository(AppDbContext context) : base(context)
        {
        }
    }
}
