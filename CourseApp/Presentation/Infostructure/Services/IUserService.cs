using Presentation.Infostructure.Identity;

namespace Presentation.Infostructure.Services
{
    public interface IUserService
    {
        Task<int> BlockUserAsync(AppUser user);
        Task<int> UnblockUserAsync(AppUser user);
        Task<int> DeleteUserAsync(AppUser user);
    }
}
