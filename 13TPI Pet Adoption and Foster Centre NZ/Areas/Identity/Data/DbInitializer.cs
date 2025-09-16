using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models;

namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Data
{
    public static class DbInitializer
    {
        public static async Task SeedAsync(Context context)
        {
            // Ensure DB is created
            await context.Database.MigrateAsync();

            // ------------------ LOOKUPS ------------------
            if (!context.PaymentType.Any())
            {
                context.PaymentType.AddRange(
                    Enumerable.Range(1, 10).Select(i => new PaymentType { Name = $"PaymentType {i}" })
                );
                await context.SaveChangesAsync();
            }

            if (!context.PaymentMethod.Any())
            {
                context.PaymentMethod.AddRange(
                    Enumerable.Range(1, 10).Select(i => new PaymentMethod { Name = $"PaymentMethod {i}" })
                );
                await context.SaveChangesAsync();
            }

            if (!context.PaymentStatus.Any())
            {
                context.PaymentStatus.AddRange(
                    Enumerable.Range(1, 10).Select(i => new PaymentStatus { StatusName = $"PaymentStatus {i}" })
                );
                await context.SaveChangesAsync();
            }

            if (!context.PetStatus.Any())
            {
                context.PetStatus.AddRange(
                    Enumerable.Range(1, 10).Select(i => new PetStatus { Name = $"PetStatus {i}" })
                );
                await context.SaveChangesAsync();
            }

            if (!context.ShelterType.Any())
            {
                context.ShelterType.AddRange(
                    Enumerable.Range(1, 10).Select(i => new ShelterType { Name = $"ShelterType {i}" })
                );
                await context.SaveChangesAsync();
            }

            if (!context.VaccinationStatus.Any())
            {
                context.VaccinationStatus.AddRange(
                    Enumerable.Range(1, 10).Select(i => new VaccinationStatus { StatusName = $"VaccinationStatus {i}" })
                );
                await context.SaveChangesAsync();
            }

            if (!context.AccessLevel.Any())
            {
                context.AccessLevel.AddRange(
                    Enumerable.Range(1, 10).Select(i => new AccessLevel { LevelName = $"AccessLevel {i}" })
                );
                await context.SaveChangesAsync();
            }

            if (!context.Title.Any())
            {
                context.Title.AddRange(
                    Enumerable.Range(1, 10).Select(i => new Title { TitleName = $"Title {i}" })
                );
                await context.SaveChangesAsync();
            }

            // ------------------ LOCATIONS ------------------
            if (!context.Location.Any())
            {
                context.Location.AddRange(
                    Enumerable.Range(1, 10).Select(i => new Location
                    {
                        Address = $"Address {i}",
                        City = $"City {i}",
                        Country = $"Country {i}"
                    })
                );
                await context.SaveChangesAsync();
            }

            // ------------------ FRANCHISES ------------------
            if (!context.Franchise.Any())
            {
                var locationIds = context.Location.Select(l => l.LocationID).ToList();
                context.Franchise.AddRange(
                    locationIds.Select((locId, i) => new Franchise
                    {
                        FranchiseName = $"Franchise {i + 1}",
                        LocationID = locId
                    })
                );
                await context.SaveChangesAsync();
            }

            // ------------------ PET GROUPS ------------------
            if (!context.PetGroup.Any())
            {
                context.PetGroup.AddRange(
                    Enumerable.Range(1, 10).Select(i => new PetGroup
                    {
                        PetGroupName = $"PetGroup {i}"
                    })
                );
                await context.SaveChangesAsync();
            }

            // ------------------ COORDINATORS ------------------
            if (!context.Coordinator.Any())
            {
                var franchises = context.Franchise.Take(10).ToList();
                var petGroups = context.PetGroup.Take(10).ToList();

                if (franchises.Count < 1 || petGroups.Count < 1)
                    throw new Exception("Franchise or PetGroup data is missing.");

                if (franchises.Any(f => f.FranchiseID == 0) || petGroups.Any(p => p.PetGroupID == 0))
                    throw new Exception("FranchiseID or PetGroupID contains 0 or null-like values.");

                for (int i = 0; i < 10; i++)
                {
                    var franchiseId = franchises[i % franchises.Count].FranchiseID;
                    var petGroupId = petGroups[i % petGroups.Count].PetGroupID;

                    Console.WriteLine($"Using FranchiseID: {franchiseId}, PetGroupID: {petGroupId}");

                    context.Coordinator.Add(new Coordinator
                    {
                        FirstName = $"First{i + 1}",
                        LastName = $"Last{i + 1}",
                        FranchiseID = franchiseId,
                        PetGroupID = petGroupId
                    });
                }

                await context.SaveChangesAsync();
            }


            // ------------------ PETS ------------------
            if (!context.Pet.Any())
            {
                var petGroups = context.PetGroup.Take(10).ToList();
                var petStatuses = context.PetStatus.Take(10).ToList();

                for (int i = 0; i < 10; i++)
                {
                    context.Pet.Add(new Pet
                    {
                        Name = $"Pet {i + 1}",
                        DateOfBirth = DateTime.Now.AddYears(-i - 1),
                        PetGroupID = petGroups[i % petGroups.Count].PetGroupID,
                        PetStatusID = petStatuses[i % petStatuses.Count].PetStatusID
                    });
                }
                await context.SaveChangesAsync();
            }

            // ------------------ MEDICAL RECORDS ------------------
            if (!context.MedicalRecord.Any())
            {
                var pets = context.Pet.Take(10).ToList();
                var vaccStatuses = context.VaccinationStatus.Take(10).ToList();

                for (int i = 0; i < 10; i++)
                {
                    context.MedicalRecord.Add(new MedicalRecord
                    {
                        Date = DateTime.Now.AddDays(-i),
                        Notes = $"Checkup {i + 1}",
                        PetID = pets[i % pets.Count].PetID,
                        VaccinationStatusID = vaccStatuses[i % vaccStatuses.Count].VaccinationStatusID
                    });
                }
                await context.SaveChangesAsync();
            }

            // ------------------ PAYMENTS ------------------
            if (!context.Payment.Any())
            {
                var payTypes = context.PaymentType.Take(10).ToList();
                var payMethods = context.PaymentMethod.Take(10).ToList();
                var payStatuses = context.PaymentStatus.Take(10).ToList();

                for (int i = 0; i < 10; i++)
                {
                    context.Payment.Add(new Payment
                    {
                        Amount = 50 + i * 10,
                        Date = DateTime.Now.AddDays(-i),
                        PaymentTypeID = payTypes[i % payTypes.Count].PaymentTypeID,
                        PaymentMethodID = payMethods[i % payMethods.Count].PaymentMethodID,
                        PaymentStatusID = payStatuses[i % payStatuses.Count].PaymentStatusID,
                        UserID = "test-user" // Replace with real Identity user IDs in production
                    });
                }
                await context.SaveChangesAsync();
            }
        }
    }
}
