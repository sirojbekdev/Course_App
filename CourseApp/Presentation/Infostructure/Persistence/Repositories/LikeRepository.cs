using Presentation.Application.Interfaces;
using Presentation.Domain.Entities;

namespace Presentation.Infostructure.Persistence.Repositories
{
    public class LikeRepository : Repository<Like>, ILikeRepository
    {
        public LikeRepository(AppDbContext context) : base(context)
        {
        }
    }
}
