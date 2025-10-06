using Microsoft.EntityFrameworkCore;
using _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models;

namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Data
{
    public static class DbInitializer
    {
        public static async Task SeedAsync(Context context)
        {
            await context.Database.MigrateAsync();

            // === TITLES ===
            if (!context.Title.Any())
            {
                context.Title.AddRange(
                    new Title { TitleName = "Mr" },
                    new Title { TitleName = "Ms" },
                    new Title { TitleName = "Dr" }
                );
                await context.SaveChangesAsync();
            }

            // === FRANCHISES ===
            if (!context.Franchise.Any())
            {
                context.Franchise.AddRange(
                    new Franchise { FranchiseName = "Happy Paws Ltd" },
                    new Franchise { FranchiseName = "Safe Haven Trust" }
                );
                await context.SaveChangesAsync();
            }

            // === LOCATIONS ===
            if (!context.Location.Any())
            {
                context.Location.AddRange(
                    new Location { Address = "123 Pet Street", City = "Auckland", Country = "NZ" },
                    new Location { Address = "456 Cat Avenue", City = "Wellington", Country = "NZ" }
                );
                await context.SaveChangesAsync();
            }

            // === SHELTER TYPES ===
            if (!context.ShelterType.Any())
            {
                context.ShelterType.AddRange(
                    new ShelterType { Name = "Temporary" },
                    new ShelterType { Name = "Permanent" }
                );
                await context.SaveChangesAsync();
            }

            // === SHELTERS ===
            if (!context.Shelter.Any())
            {
                context.Shelter.AddRange(
                    new Shelter { Name = "Auckland Shelter", FranchiseID = 1, LocationID = 1, ShelterTypeID = 1 },
                    new Shelter { Name = "Wellington Shelter", FranchiseID = 2, LocationID = 2, ShelterTypeID = 2 }
                );
                await context.SaveChangesAsync();
            }

            // === PET GROUPS ===
            if (!context.PetGroup.Any())
            {
                context.PetGroup.AddRange(
                    new PetGroup { PetGroupName = "Dogs" },
                    new PetGroup { PetGroupName = "Cats" },
                    new PetGroup { PetGroupName = "Birds" }
                );
                await context.SaveChangesAsync();
            }

            // === PET STATUSES ===
            if (!context.PetStatus.Any())
            {
                context.PetStatus.AddRange(
                    new PetStatus { StatusName = "Available" },
                    new PetStatus { StatusName = "Adopted" },
                    new PetStatus { StatusName = "Fostered" }
                );
                await context.SaveChangesAsync();
            }

            // === VACCINATION STATUSES ===
            if (!context.VaccinationStatus.Any())
            {
                context.VaccinationStatus.AddRange(
                    new VaccinationStatus { StatusName = "Up to Date" },
                    new VaccinationStatus { StatusName = "Due" }
                );
                await context.SaveChangesAsync();
            }

            // === PETS ===
            if (!context.Pet.Any())
            {
                context.Pet.AddRange(
                    new Pet { Name = "Bella", DateOfBirth = DateTime.Now.AddYears(-2), PetGroupID = 1, PetStatusID = 1 },
                    new Pet { Name = "Milo", DateOfBirth = DateTime.Now.AddYears(-1), PetGroupID = 2, PetStatusID = 1 },
                    new Pet { Name = "Coco", DateOfBirth = DateTime.Now.AddYears(-3), PetGroupID = 3, PetStatusID = 1 }
                );
                await context.SaveChangesAsync();
            }

            // === MEDICAL RECORDS ===
            if (!context.MedicalRecord.Any())
            {
                context.MedicalRecord.AddRange(
                    new MedicalRecord { PetID = 1, VaccinationStatusID = 1, Notes = "Healthy and active" },
                    new MedicalRecord { PetID = 2, VaccinationStatusID = 2, Notes = "Needs vaccination soon" }
                );
                await context.SaveChangesAsync();
            }

            // === COORDINATORS ===
            if (!context.Coordinator.Any())
            {
                context.Coordinator.AddRange(
                    new Coordinator { FirstName = "Alice", LastName = "Johnson",EmailAddress = "alice@test.com" },
                    new Coordinator { FirstName = "Bob", LastName = "Smith", EmailAddress = "bob@test.com" }
                );
                await context.SaveChangesAsync();
            }

            // === PAYMENT METHODS ===
            if (!context.PaymentMethod.Any())
            {
                context.PaymentMethod.AddRange(
                    new PaymentMethod { Name = "Stripe" },
                    new PaymentMethod { Name = "Cash" }
                );
                await context.SaveChangesAsync();
            }

            // === PAYMENT TYPES ===
            if (!context.PaymentType.Any())
            {
                context.PaymentType.AddRange(
                    new PaymentType { Name = "Adoption Fee" },
                    new PaymentType { Name = "Donation" }
                );
                await context.SaveChangesAsync();
            }

            // === PAYMENT STATUSES ===
            if (!context.PaymentStatus.Any())
            {
                context.PaymentStatus.AddRange(
                    new PaymentStatus { StatusName = "Completed" },
                    new PaymentStatus { StatusName = "Pending" }
                );
                await context.SaveChangesAsync();
            }

            // === PAYMENTS ===
            if (!context.Payment.Any())
            {
                context.Payment.AddRange(
                    new Payment { Amount = 100, PaymentDate = DateTime.Now, PaymentMethodID = 1, PaymentTypeID = 1, PaymentStatusID = 1 },
                    new Payment { Amount = 50, PaymentDate = DateTime.Now.AddDays(-1), PaymentMethodID = 1, PaymentTypeID = 2, PaymentStatusID = 2 }
                );
                await context.SaveChangesAsync();
            }

        }
    }
}
