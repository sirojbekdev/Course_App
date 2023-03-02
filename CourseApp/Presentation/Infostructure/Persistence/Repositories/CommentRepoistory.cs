using Presentation.Application.Interfaces;
using Presentation.Domain.Entities;

namespace Presentation.Infostructure.Persistence.Repositories
{
    public class CommentRepoistory : Repository<Comment>, ICommentRepository
    {
        public CommentRepoistory(AppDbContext context) : base(context)
        {
        }
    }
}
