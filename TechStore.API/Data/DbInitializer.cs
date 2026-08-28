using Microsoft.AspNetCore.Identity;

namespace TechStore.API.Data
{
    public class DbInitializer
    {
        public async Task InitializeRoles(RoleManager<IdentityRole> roleManager)
        {
            var userRoleExists = await roleManager.RoleExistsAsync("User");
            if (!userRoleExists)
            {
                await roleManager.CreateAsync(new IdentityRole("User"));
            }

            var adminRoleExists = await roleManager.RoleExistsAsync("Admin");
            if (!adminRoleExists)
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }
        }
    }
}
