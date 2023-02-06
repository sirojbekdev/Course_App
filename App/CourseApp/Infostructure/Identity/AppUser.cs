using Microsoft.AspNetCore.Identity;
using Presentation.Domain.Common;
using Presentation.Domain.Entities;
using Presentation.Domain.Enums;

namespace Presentation.Infostructure.Identity
{
    public class AppUser : IdentityUser<Guid>, IAuditable
    {
        [PersonalData]
        public string? ImagePath { get; set; }
        public UserStatus Status { get; set; }
        public virtual ICollection<Collection> Collections { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
