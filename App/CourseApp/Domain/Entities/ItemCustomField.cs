using Presentation.Domain.Common;
using Presentation.Domain.Enums;

namespace Presentation.Domain.Entities
{
    public class ItemCustomField : BaseEntity
    {
        public CustomFieldType Type { get; set; }
        public string? Value { get; set; }
        public virtual Guid ItemId { get; set; }
    }
}
