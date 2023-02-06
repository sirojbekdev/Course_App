using Presentation.Domain.Common;

namespace Presentation.Domain.Entities
{
    public class Collection : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid TopicId { get; set; }
        public virtual Topic Topic { get; set; }
        public virtual CustomFieldMapper CustomFieldMapper { get; set; }
        public virtual ICollection<Item>? Items { get; set; }
        public Guid AppUserId { get; set; }
    }
}
