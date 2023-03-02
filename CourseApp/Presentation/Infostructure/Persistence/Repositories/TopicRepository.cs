using Presentation.Application.Interfaces;
using Presentation.Domain.Entities;

namespace Presentation.Infostructure.Persistence.Repositories
{
    public class TopicRepository : Repository<Topic>, ITopicRepository
    {
        public TopicRepository(AppDbContext context) : base(context)
        {
        }
    }
}
