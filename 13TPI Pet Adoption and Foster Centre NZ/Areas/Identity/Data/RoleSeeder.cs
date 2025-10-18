using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Data
{
    public static class RoleSeeder
    {
        public static async Task SeedAsync(IServiceProvider services, IConfiguration configuration)
        {
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = services.GetRequiredService<UserManager<IdentityUser>>();

            // Roles to ensure
            string[] roles = new[] { "Admin", "User" };

            foreach (var roleName in roles)
            {
                if (!await roleManager.RoleExistsAsync(roleName))
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            // Optional: create an admin user from configuration (Development only)
            var adminEmail = configuration["AdminUser:Email"];
            var adminPassword = configuration["AdminUser:Password"];

            if (!string.IsNullOrWhiteSpace(adminEmail) && !string.IsNullOrWhiteSpace(adminPassword))
            {
                var admin = await userManager.FindByEmailAsync(adminEmail);
                if (admin == null)
                {
                    admin = new IdentityUser { UserName = adminEmail, Email = adminEmail, EmailConfirmed = true };
                    var createResult = await userManager.CreateAsync(admin, adminPassword);
                    // createResult may fail if password rules not met
                }

                if (admin != null && !await userManager.IsInRoleAsync(admin, "Admin"))
                {
                    await userManager.AddToRoleAsync(admin, "Admin");
                }
            }
        }
    }
}
