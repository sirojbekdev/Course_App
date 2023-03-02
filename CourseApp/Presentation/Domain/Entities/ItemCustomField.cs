using Presentation.Domain.Common;
using Presentation.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Presentation.Domain.Entities
{
    public class ItemCustomField : BaseEntity
    {
        [Required, MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public CustomFieldType Type { get; set; }

        public string? Value { get; set; }
        public bool IsVisible { get; set; } = true;
        public virtual Guid ItemId { get; set; }
    }
}
