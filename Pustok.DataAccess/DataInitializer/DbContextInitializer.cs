using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Pustok.Core.Entities;
using Pustok.DataAccess.Context;
using Pustok.DataAccess.Model;
using Microsoft.Extensions.Configuration;
using Pustok.Core.Enums;
using Pustok.DataAccess.Abstractions;


namespace Pustok.DataAccess.DataInitializer 
{
    internal class DbContextInitializer : IContextInitializer
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly UserDto _userDto;


        public DbContextInitializer(AppDbContext context, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, IConfiguration configuration)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;

            _userDto = _configuration.GetSection("AdminSetting").Get<UserDto>() ?? new();

        }

        public async Task InitDatabaseAsync()
        {
            await _context.Database.MigrateAsync();
            await CreateRolesAsync();

            await CreateAdminAsync();

        }

        private async Task CreateAdminAsync()
        {
            AppUser adminUser = new()
            {
                Email = _userDto.Email,
                UserName = _userDto.Username,
                Fullname = _userDto.Fullname
            };

            var result = await _userManager.CreateAsync(adminUser, _userDto.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(adminUser, IdentityRoles.Admin.ToString());
            }
        }

        private async Task CreateRolesAsync()
        {
            foreach (var role in Enum.GetNames(typeof(IdentityRoles)))
            {
                AppRole appRole = new()
                {
                    Name = role
                };

                await _roleManager.CreateAsync(appRole);
            }
        }


    }
}
