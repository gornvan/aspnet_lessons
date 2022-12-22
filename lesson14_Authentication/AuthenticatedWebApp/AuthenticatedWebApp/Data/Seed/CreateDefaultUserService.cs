using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace AuthenticatedWebApp.Data.Seed
{
    public class CreateDefaultUserService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _rolesManager;
        private readonly ILogger _logger;

        public CreateDefaultUserService(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
             ILoggerFactory loggerFactory
             )
        {
            _userManager = userManager;
            _rolesManager = roleManager;
            _logger = loggerFactory.CreateLogger<CreateDefaultUserService>();
        }

        public async Task CreateRoles()
        {
            var adminRoleName = "Admin";

            // if there are roles in the database already, do not repeat:
            var rolesExist = await _rolesManager.Roles.AnyAsync();
            if (!rolesExist)
            {
                var roleNames = new String[] { adminRoleName, "User" };

                foreach (var roleName in roleNames)
                {
                    var role = await _rolesManager.RoleExistsAsync(roleName);
                    if (!role)
                    {
                        var result = await _rolesManager.CreateAsync(new IdentityRole(roleName));
                        //
                        _logger.LogInformation("Create {0}: {1}", roleName, result.Succeeded);
                    }
                }
            }
            else
            {
                _logger.LogInformation("Roles seem to be already in place.");
            }

            // administrator
            var adminUserToBeCreated = new IdentityUser
            {
                UserName = "test@example.com",
                Email = "test@example.com",
                EmailConfirmed = true
            };
            var existingAdminUser = await _userManager.FindByEmailAsync(adminUserToBeCreated.Email);
            if (existingAdminUser == null)
            {
                var adminUser = await _userManager.CreateAsync(adminUserToBeCreated, "P@ssw0rd!");
                if (adminUser.Succeeded)
                {
                    await _userManager.AddToRoleAsync(adminUserToBeCreated, adminRoleName);
                    _logger.LogInformation("Created admin {0} and added to role {1}", adminUserToBeCreated.UserName, adminRoleName);
                }
            }
            else
            {
                _logger.LogInformation("Admin user is already there, making no changes to it!");
            }
        }
    }
}
