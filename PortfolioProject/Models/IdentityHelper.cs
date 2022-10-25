using Microsoft.AspNetCore.Identity;

namespace PortfolioProject.Models
{
#nullable disable
    /// <summary>
    /// This class helps with role support for Identity.
    /// </summary>
    public static class IdentityHelper
    {
        public const string Admin = "Admin";
        public const string User = "User";

        public static async Task CreateRoles(IServiceProvider provider, params string[] roles)
        {
            RoleManager<IdentityRole> roleManager = provider.GetService<RoleManager<IdentityRole>>();

            foreach (string role in roles)
            {
                bool doesRoleExist = await roleManager.RoleExistsAsync(role);
                if (!doesRoleExist)
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }

        public static async Task CreateDefaultUser(IServiceProvider provider, string role)
        {
            var userManager = provider.GetService<UserManager<IdentityUser>>();

            // If no users are present, make the default user
            int numUsers = (await userManager.GetUsersInRoleAsync(role)).Count;
            if (numUsers == 0) // If no users are in the specified role
            {
                var defaultUser = new IdentityUser()
                {
                    Email = "testingweb@site.com",
                    UserName = "Test"
                };

                await userManager.CreateAsync(defaultUser, "Password01#");

                await userManager.AddToRoleAsync(defaultUser, role);
            }
        }
    }
}