using Presentation.Infostructure.Identity;
using System.Globalization;

namespace Presentation.Data
{
    public class AppData
    {
        public string Theme { get; set; }
        public CultureInfo Culture { get; set; }
        public AppUser? User { get; set; }
        public bool IsAdmin { get; set; } = false;
    }
}
