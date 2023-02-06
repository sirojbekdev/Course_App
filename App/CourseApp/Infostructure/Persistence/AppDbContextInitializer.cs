using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Presentation.Domain.Entities;
using Presentation.Infostructure.Identity;

namespace Presentation.Infostructure.Persistence
{
    public class AppDbContextInitializer
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;

        private const string AdministratorsRole = "Administrators";
        private const string CollectorRole = "Accounts";

        private const string DefaultPassword = "Password123!";

        public AppDbContextInitializer(
            AppDbContext context,
            UserManager<AppUser> userManager,
            RoleManager<AppRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task InitialiseAsync()
        {
            await InitialiseWithMigrationsAsync();
        }

        private async Task InitialiseWithDropCreateAsync()
        {
            await _context.Database.EnsureDeletedAsync();
            await _context.Database.EnsureCreatedAsync();
        }

        private async Task InitialiseWithMigrationsAsync()
        {
            if (_context.Database.IsSqlServer())
            {
                await _context.Database.MigrateAsync();
            }
            else
            {
                await _context.Database.EnsureCreatedAsync();
            }
        }

        public async Task SeedAsync()
        {
            await SeedIdentityAsync();
            await SeedDataAsync();
        }
        #region Seed Roles and User
        private async Task SeedIdentityAsync()
        {
            if(await _roleManager.Roles.AnyAsync())
            {
                return;
            }
            // Create roles
            await _roleManager.CreateAsync(
                new AppRole
                {
                    Name = AdministratorsRole,
                    NormalizedName = AdministratorsRole.ToUpper()
                });

            await _roleManager.CreateAsync(
                new AppRole
                {
                    Name = CollectorRole,
                    NormalizedName = CollectorRole.ToUpper()
                });


            // Create default admin user
            var adminUserName = "admin@email.com";
            var adminUser = new AppUser { UserName = adminUserName, Email = adminUserName };

            await _userManager.CreateAsync(adminUser, DefaultPassword);

            adminUser = await _userManager.FindByNameAsync(adminUserName);

            await _userManager.AddToRoleAsync(adminUser!, AdministratorsRole);

            // Create default auditor user
            var auditorUserName = "collector@email.com";
            var auditorUser = new AppUser { UserName = auditorUserName, Email = auditorUserName };
            await _userManager.CreateAsync(auditorUser, DefaultPassword);

            await _context.SaveChangesAsync();
        }
        #endregion

        #region Seed Topics 
        private async Task SeedDataAsync()
        {
            if (await _context.Topics.AnyAsync())
            {
                return;
            }

            List<Topic> listOfTopics = new(){
                new Topic()
                {
                    Title = "Books"
                },
                new Topic()
                {
                    Title = "Coins"
                },
                new Topic()
                {
                    Title = "Pictures"
                },
                new Topic()
                {
                    Title = "Jewelry"
                },
                new Topic()
                {
                    Title = "Vehicles"
                },
                new Topic()
                {
                    Title = "Watches"
                },
                new Topic()
                {
                    Title = "Dresses"
                }
            };
            await _context.Topics.AddRangeAsync(listOfTopics);
            await _context.SaveChangesAsync();
        }
        #endregion 
    }
}
