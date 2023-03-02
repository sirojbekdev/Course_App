using Microsoft.AspNetCore.Identity;
using Presentation.Domain.Enums;
using Presentation.Infostructure.Identity;
using Presentation.Infostructure.Persistence;

namespace Presentation.Infostructure.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public UserService(AppDbContext taskContext, UserManager<AppUser> userManager)
        {
            _context = taskContext;
            _userManager = userManager;
        }

        public async Task<int> BlockUserAsync(AppUser user)
        {
            user.Status = UserStatus.Blocked;
            await _userManager.UpdateSecurityStampAsync(user);
            _context.Update(user);
            var result = await _context.SaveChangesAsync();

            return result;
        }

        public async Task<int> DeleteUserAsync(AppUser user)
        {
            _context.Users.Remove(user);
            var result = await _context.SaveChangesAsync();

            return result;
        }

        public async Task<int> UnblockUserAsync(AppUser user)
        {
            user.Status = UserStatus.Active;
            _context.Update(user);
            var result = await _context.SaveChangesAsync();

            return result;
        }
    }
}
