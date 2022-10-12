﻿using Microsoft.AspNetCore.Identity;

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
    }
}
