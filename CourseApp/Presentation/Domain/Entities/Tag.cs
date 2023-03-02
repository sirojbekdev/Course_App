using Presentation.Domain.Common;

namespace Presentation.Domain.Entities
{
    public class Tag : BaseEntity
    {
        public string TagName { get; set; }
        public virtual ICollection<Item> Items { get; set; }
        public virtual List<ItemTag> ItemTags { get; set; }
    }
}