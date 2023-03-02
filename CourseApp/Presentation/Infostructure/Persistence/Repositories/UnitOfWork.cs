using Presentation.Application.Interfaces;

namespace Presentation.Infostructure.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly AppDbContext _context;

        public ICollectionRepository Collections => new CollectionRepository(_context);

        public IItemRepository Items => new ItemRepository(_context);
        public ITopicRepository Topics => new TopicRepository(_context);
        public ICommentRepository Comments => new CommentRepoistory(_context);
        public ITagRepository Tags => new TagRepository(_context);
        public ICustomFieldMapperRepository CustomFieldMappers => new CustomFieldMapperRepository(_context);
        public IItemCustomFieldRepository ItemCustomFields => new ItemCustomFieldRepository(_context);
        public ICollectionCustomFieldRepository CollectionCustomFields => new CollectionCustomFieldRepository(_context);
        public ILikeRepository Likes => new LikeRepository(_context);

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
