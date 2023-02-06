using Presentation.Domain.Common;

namespace Presentation.Domain.Entities
{
    public class Comment : BaseEntity
    {
        public string Content { get; set; }
        public Guid CommentedUserId { get; set; }
        public Guid ItemId { get; set; }
        public virtual Item Item { get; set; }
    }
}