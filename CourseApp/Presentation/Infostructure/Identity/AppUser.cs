using Microsoft.AspNetCore.Identity;
using Presentation.Domain.Common;
using Presentation.Domain.Entities;
using Presentation.Domain.Enums;

namespace Presentation.Infostructure.Identity
{
    public class AppUser : IdentityUser<Guid>, IAuditable
    {
        public UserStatus Status { get; set; } = UserStatus.Active;
        public virtual ICollection<Collection> Collections { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime? ModifiedOn { get; set; }
    }
}
