namespace Presentation.Application.Interfaces
{
    public interface IUnitOfWork
    {
        ICollectionRepository Collections { get; }
        IItemRepository Items { get; }
        ITopicRepository Topics { get; }
        ICommentRepository Comments { get; }
        ITagRepository Tags { get; }
        ICustomFieldMapperRepository CustomFieldMappers { get; }
        IItemCustomFieldRepository ItemCustomFields { get; }
        ICollectionCustomFieldRepository CollectionCustomFields { get; }
        ILikeRepository Likes { get; }
        Task SaveChangesAsync();
        void Dispose();
    }
}
