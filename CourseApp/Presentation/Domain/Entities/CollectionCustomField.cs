using Presentation.Domain.Common;
using Presentation.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Presentation.Domain.Entities
{
    public class CollectionCustomField : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public CustomFieldType Type { get; set; }
        public bool IsVisible { get; set; } = true;
        public Guid CustomFieldMapperId { get; set; }
        public virtual CustomFieldMapper? CustomFieldMapper { get; set; }
    }
}