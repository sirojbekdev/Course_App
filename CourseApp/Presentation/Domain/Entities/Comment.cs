using Microsoft.Build.Framework;
using Presentation.Domain.Common;

namespace Presentation.Domain.Entities
{
    public class Comment : BaseEntity
    {
        [Required]
        public string Content { get; set; }
        public string CommentedUserName { get; set; }
        public Guid ItemId { get; set; }
        public virtual Item Item { get; set; }
    }
}