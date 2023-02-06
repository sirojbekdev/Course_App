using Presentation.Domain.Common;

namespace Presentation.Domain.Entities
{
    public class Like : BaseEntity
    {
        public Guid UserId { get; set; }
    }
}