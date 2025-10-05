using Microsoft.AspNetCore.Identity;
using _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models;
using System;
using System.Linq;

namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Data
{
    public static class DbInitializer
    {
        public static void Initialize(Context context, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            context.Database.EnsureCreated();

            // 1️⃣ Seed Roles
            string[] roles = new[] { "Admin", "Coordinator", "User" };
            foreach (var role in roles)
            {
                if (!roleManager.RoleExistsAsync(role).Result)
                {
                    roleManager.CreateAsync(new IdentityRole(role)).Wait();
                }
            }

            // 2️⃣ Seed Users
            if (!userManager.Users.Any())
            {
                var adminUser = new IdentityUser { UserName = "admin@petcentre.com", Email = "admin@petcentre.com", EmailConfirmed = true };
                userManager.CreateAsync(adminUser, "Admin123!").Wait();
                userManager.AddToRoleAsync(adminUser, "Admin").Wait();
            }

            // 3️⃣ Seed AccessLevels
            if (!context.AccessLevel.Any())
            {
                context.AccessLevel.AddRange(
                    new AccessLevel { LevelName = "Admin" },
                    new AccessLevel { LevelName = "Coordinator" },
                    new AccessLevel { LevelName = "User" }
                );
                context.SaveChanges();
            }

            // 4️⃣ Seed Titles
            if (!context.Title.Any())
            {
                context.Title.AddRange(
                    new Title { TitleName = "Mr." },
                    new Title { TitleName = "Ms." },
                    new Title { TitleName = "Dr." }
                );
                context.SaveChanges();
            }

            // 5️⃣ Seed Locations
            if (!context.Location.Any())
            {
                context.Location.AddRange(
                    new Location { Address = "123 Main St", Surburb = "Central", City = "Auckland", Region = "Auckland", PostCode = "1010", Country = "NZ" },
                    new Location { Address = "45 Park Rd", Surburb = "West", City = "Wellington", Region = "Wellington", PostCode = "6011", Country = "NZ" }
                    // Add more until 10
                );
                context.SaveChanges();
            }

            // 6️⃣ Seed PetGroups
            if (!context.PetGroup.Any())
            {
                context.PetGroup.AddRange(
                    new PetGroup { PetGroupName = "Dog" },
                    new PetGroup { PetGroupName = "Cat" },
                    new PetGroup { PetGroupName = "Rabbit" }
                );
                context.SaveChanges();
            }

            // 7️⃣ Seed PetStatuses
            if (!context.PetStatus.Any())
            {
                context.PetStatus.AddRange(
                    new PetStatus { Name = "Available" },
                    new PetStatus { Name = "Adopted" },
                    new PetStatus { Name = "Fostered" }
                );
                context.SaveChanges();
            }

            // 8️⃣ Seed Shelters, Franchises, Coordinators, AdminOffices, Payments, PaymentTypes/Methods/Status, Pets, MedicalRecords, VaccinationStatuses...
            // Use similar pattern with  dummy data, 10 rows each
        }
    }
}
