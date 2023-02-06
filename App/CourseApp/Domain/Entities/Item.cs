using Presentation.Domain.Common;

namespace Presentation.Domain.Entities
{
    public class Item : BaseEntity
    {
        public Item() {}
        public Item(ICollection<ItemCustomField> itemCustomFields)
        {
            ItemCustomFields= itemCustomFields;
        }

        public string Title { get; set; }
        public string? ImagePath { get; set; }
        public virtual ICollection<Like>? Likes { get; set; }
        public virtual ICollection<Comment>? Comments { get; set; }
        public virtual Guid CollectionId { get; set; }
        public virtual Collection Collection { get; set; }
        public virtual ICollection<ItemCustomField>? ItemCustomFields { get; set; }
        public virtual ICollection<Tag>? Tags { get; set; }
        public virtual List<ItemTags>? ItemTags { get; set; }

    }
}