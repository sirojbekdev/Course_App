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

        private const string _adminRole = "Admin";
        private const string _adminUserName = "admin@email.com";
        private const string _collectorRole = "Collector";
        private const string _collectorUserName = "collector@email.com";

        private const string _defaultPassword = "Password123!";

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
        public async Task SeedAsync()
        {
            await SeedIdentityAsync();
            await SeedTopicsAsync();
            await SeedTagsAsync();
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
                    Name = _adminRole,
                    NormalizedName = _adminRole.ToUpper()
                });

            await _roleManager.CreateAsync(
                new AppRole
                {
                    Name = _collectorRole,
                    NormalizedName = _collectorRole.ToUpper()
                });

            // Create default admin user           
            var adminUser = new AppUser { UserName = _adminUserName, Email = _adminUserName };

            await _userManager.CreateAsync(adminUser, _defaultPassword);

            adminUser = await _userManager.FindByNameAsync(_adminUserName);

            await _userManager.AddToRoleAsync(adminUser!, _adminRole);

            // Create default collector user         
            var collectorUser = new AppUser { UserName = _collectorUserName, Email = _collectorUserName };
            await _userManager.CreateAsync(collectorUser, _defaultPassword);
            collectorUser = await _userManager.FindByNameAsync(_collectorUserName);

            await _userManager.AddToRoleAsync(collectorUser!, _collectorRole);

            await _context.SaveChangesAsync();
        }
        #endregion

        #region Seed Topics 
        private async Task SeedTopicsAsync()
        {
            if (await _context.Topics.AnyAsync())
            {
                return;
            }

            List<Topic> listOfTopics = new(){
                new() { Title = "Books" },
                new() { Title = "Coins" },
                new() { Title = "Pictures" },
                new() { Title = "Jewelry" },
                new() { Title = "Vehicles" },
                new() { Title = "Watches" },
                new() { Title = "Dresses" }
            };
            await _context.Topics.AddRangeAsync(listOfTopics);
            await _context.SaveChangesAsync();
        }
        #endregion

        #region Seed Tags 
        private async Task SeedTagsAsync()
        {
            if (await _context.Tags.AnyAsync())
            {
                return;
            }

            List<Tag> listOfTags = new(){
                new() { TagName = "Books" },
                new() { TagName = "Books2023" },
                new() { TagName = "NewBooks" },
                new() { TagName = "Coins" },
                new() { TagName = "Coins2023" },
                new() { TagName = "NewCoins" },
                new() { TagName = "Pictures" },
                new() { TagName = "Pictures2023" },
                new() { TagName = "NewPictures" },
                new() { TagName = "Jewelry" },
                new() { TagName = "Jewelry2023" },
                new() { TagName = "NewJewelry" },
                new() { TagName = "Vehicles" },
                new() { TagName = "Vehicles2023" },
                new() { TagName = "NewVehicles" },
                new() { TagName = "Watches" },
                new() { TagName = "Watches2023" },
                new() { TagName = "NewWatches" },
                new() { TagName = "Dresses" },
                new() { TagName = "Dresses2023" },
                new() { TagName = "NewDresses" }
            };
            await _context.Tags.AddRangeAsync(listOfTags);
            await _context.SaveChangesAsync();
        }
        #endregion 
    }
}
