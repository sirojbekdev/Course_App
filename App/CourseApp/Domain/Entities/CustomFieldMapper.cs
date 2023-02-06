using Presentation.Domain.Common;

namespace Presentation.Domain.Entities
{
    public class CustomFieldMapper : BaseEntity
    {
        public Guid CollectionId { get; set; }
        public virtual Collection Collection { get; set; }
        public virtual ICollection<CollectionCustomField>? CustomFields { get; set; }
    }
}
