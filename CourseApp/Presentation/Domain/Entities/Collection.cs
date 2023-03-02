using Presentation.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Presentation.Domain.Entities
{
    public class Collection : BaseEntity
    {
        public Collection()
        {
            CustomFieldMapper = new CustomFieldMapper();
        }
        [Required, MaxLength(50)]
        public string Title { get; set; }
        [MaxLength(500)]
        public string? Description { get; set; }
        public string? ImagePath { get; set; }
        [Required]
        public Guid AppUserId { get; set; }
        [Required]
        public string AppUserName { get; set; }
        public Guid TopicId { get; set; }
        public string? TopicTitle { get; set; }
        public virtual Topic Topic { get; set; }
        public virtual CustomFieldMapper CustomFieldMapper { get; set; }
        public virtual ICollection<Item>? Items { get; set; }
    }
}
