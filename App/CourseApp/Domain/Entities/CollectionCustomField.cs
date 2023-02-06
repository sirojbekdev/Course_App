using Presentation.Domain.Common;
using Presentation.Domain.Enums;

namespace Presentation.Domain.Entities
{
    public class CollectionCustomField : BaseEntity
    {
        public string Name { get; set; }
        public CustomFieldType Type { get; set; }
        public Guid CustomFieldMapperId { get; set; }
        public virtual CustomFieldMapper? CustomFieldMapper { get; set; }
    }
}