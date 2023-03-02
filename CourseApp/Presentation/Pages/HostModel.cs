using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Presentation.Data;
using Presentation.Infostructure.Identity;
using System.Globalization;

namespace Presentation.Pages
{
    public class HostModel : PageModel
    {
        private readonly AppData _appData;
        private readonly UserManager<AppUser> _userManager;
        private CultureInfo? _culture;

        public HostModel(AppData appData, UserManager<AppUser> userManager)
        {
            _appData = appData;
            _userManager = userManager;
        }
        public async void OnGet()
        {
            var theme = HttpContext.Request.Cookies["theme"];
            var cultureCode = HttpContext.Request.Cookies["lang"];
            var userName = HttpContext.User.Identity.Name;
            if (string.IsNullOrEmpty(theme))
            {
                theme = "light";
            }

            if (string.IsNullOrEmpty(cultureCode))
            {
                _culture = new CultureInfo("en-US");
            }
            else
            {
                _culture = new CultureInfo(cultureCode);
            }

            if (!string.IsNullOrWhiteSpace(userName) && _appData.User == null)
            {
                _appData.User = await _userManager.FindByNameAsync(userName);
                _appData.IsAdmin = await _userManager.IsInRoleAsync(_appData.User, "Admin");
            }

            _appData.Theme = theme;
            _appData.Culture = _culture;
            Thread.CurrentThread.CurrentCulture = _culture;
            Thread.CurrentThread.CurrentUICulture = _culture;
            CultureInfo.DefaultThreadCurrentCulture = _culture;
            CultureInfo.DefaultThreadCurrentUICulture = _culture;
        }
    }
}
