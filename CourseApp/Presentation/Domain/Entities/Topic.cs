using Microsoft.EntityFrameworkCore;
using Presentation.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Presentation.Domain.Entities
{
    [Index(nameof(Title), IsUnique = true)]
    public class Topic : BaseEntity
    {
        [Required, MaxLength(25)]
        public string Title { get; set; }
        public virtual ICollection<Collection> Collections { get; set; }
    }
}