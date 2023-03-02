using Presentation.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Presentation.Domain.Entities
{
    public class Item : BaseEntity
    {
        public Item()
        {
            ItemCustomFields = new List<ItemCustomField>();
            Likes = new List<Like>();
            Comments = new List<Comment>();
        }
        public Item(ICollection<ItemCustomField>? itemCustomFields)
        {
            ItemCustomFields = itemCustomFields;
        }

        [Required, MaxLength(50)]
        public string Title { get; set; }
        public string? ImagePath { get; set; }
        public virtual ICollection<Like>? Likes { get; set; }
        public virtual ICollection<Comment>? Comments { get; set; }
        [Required]
        public Guid AppUserId { get; set; }
        [Required]
        public string AppUserName { get; set; }
        public virtual Guid CollectionId { get; set; }
        public virtual Collection Collection { get; set; }
        public virtual ICollection<ItemCustomField>? ItemCustomFields { get; set; }
        public virtual ICollection<Tag>? Tags { get; set; }
        public virtual List<ItemTag>? ItemTags { get; set; }
    }
}