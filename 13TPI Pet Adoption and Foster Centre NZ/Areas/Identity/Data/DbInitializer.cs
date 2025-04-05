using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models;

namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Data
{
    public class DbInitializer
    {
        public static void Initialize (
            Context context)
        {
            // Ensure database is created.
            context.Database.EnsureCreated();

            // Check if the tables are already populated
            if (context.AdminOffice.Any())
            {
                return; // DB has been seeded
            }

            #region Seed AdminOffice
            context.AdminOffice.AddRange(
                new AdminOffice
                {
                    UserID = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    EmailAddress = "johndoe@example.com",
                    ContactNo = "01234567890",
                    DateHired = DateTime.Parse("2022-01-01"),
                    AccessLevel = "Administrator",
                    Title = "Admin",
                },
                new AdminOffice
                {
                    UserID = 2,
                    FirstName = "Jane",
                    LastName = "Smith",
                    EmailAddress = "janesmith@example.com",
                    ContactNo = "09876543210",
                    DateHired = DateTime.Parse("2023-05-15"),
                    AccessLevel = "Manager",
                    Title = "Admin Assistant",
                }
            );
            #endregion

            #region Seed Coordinator
            context.Coordinator.AddRange(
                new Coordinator
                {
                    FranchiseID = 1,
                    PetGroupID = 1,
                    FirstName = "Alice",
                    LastName = "Johnson",
                    EmailAddress = "alicejohnson@example.com",
                    ContactNo = "02123456789",
                    HireDate = DateTime.Parse("2023-01-01"),
                    ExperienceLevel = "Expert",
                    Title = "Coordinator",
                },
                new Coordinator
                {
                    FranchiseID = 2,
                    PetGroupID = 2,
                    FirstName = "Bob",
                    LastName = "Williams",
                    EmailAddress = "bobwilliams@example.com",
                    ContactNo = "02734567890",
                    HireDate = DateTime.Parse("2022-07-21"),
                    ExperienceLevel = "Intermediate",
                    Title = "Coordinator",
                }
            );
            #endregion

            #region Seed Franchise
            context.Franchise.AddRange(
                new Franchise
                {
                    FranchiseName = "Paws & Claws",
                    ContactNo = "01234567890",
                    LocationID = 1,
                    EmailAddress = "contact@pawsandclaws.com",
                    OperatingHours = "Mon-Fri: 9 AM - 5 PM",
                    OwnerID = 1
                },
                new Franchise
                {
                    FranchiseName = "Furry Friends",
                    ContactNo = "09876543210",
                    LocationID = 2,
                    EmailAddress = "contact@furryfriends.com",
                    OperatingHours = "Mon-Fri: 10 AM - 6 PM",
                    OwnerID = 2
                }
            );
            #endregion

            #region Seed Location
            context.Location.AddRange(
                new Location
                {
                    Address = "123 Pet Street",
                    Surburb = "Newtown",
                    City = "Wellington",
                    Region = "Wellington",
                    PostCode = "6011",
                    Country = "New Zealand"
                },
                new Location
                {
                    Address = "456 Animal Road",
                    Surburb = "Petville",
                    City = "Auckland",
                    Region = "Auckland",
                    PostCode = "1010",
                    Country = "New Zealand"
                }
            );
            #endregion

            #region Seed MedicalRecord
            context.MedicalRecord.AddRange(
                new MedicalRecord
                {
                    PetID = 1,
                    VetName = "Dr. Smith",
                    ClinicName = "Healthy Pets Clinic",
                    VisitDate = DateOnly.Parse("2023-02-15"),
                    Diagnosis = "Routine Checkup",
                    Treatment = "None",
                    VaccinationStatus = "Fully Vaccinated",
                    MicrochipID = 123456789,
                    SpecialNeeds = "None"
                },
                new MedicalRecord
                {
                    PetID = 2,
                    VetName = "Dr. Jones",
                    ClinicName = "City Vet Clinic",
                    VisitDate = DateOnly.Parse("2023-05-10"),
                    Diagnosis = "Dental Cleaning",
                    Treatment = "Teeth Cleaning",
                    VaccinationStatus = "Fully Vaccinated",
                    MicrochipID = 987654321,
                    SpecialNeeds = "Sensitive Teeth"
                }
            );
            #endregion

            #region Seed Pet
            context.Pet.AddRange(
                new Pet
                {
                    PetName = "Bella",
                    PetGroupID = 1,
                    Species = "Dog",
                    Breed = "Golden Retriever",
                    PetAge = 3,
                    ArrivalDate = DateTime.Parse("2023-01-01"),
                    PetStatus = "Available"
                },
                new Pet
                {
                    PetName = "Max",
                    PetGroupID = 2,
                    Species = "Cat",
                    Breed = "Siamese",
                    PetAge = 2,
                    ArrivalDate = DateTime.Parse("2023-03-10"),
                    PetStatus = "Adopted"
                }
            );
            #endregion

            #region Seed Payment
            context.Payment.AddRange(
                new Payment
                {
                    UserID = 1,
                    PaymentType = "Adoption Fee",
                    Amount = 150.00m,
                    Currency = 1, // NZD
                    PaymentDate = DateTime.Parse("2023-02-20"),
                    PaymentMethod = "Credit Card",
                    TransactionID = 123456,
                    PaymentStatus = "Completed",
                    Notes = "Adoption payment for Bella"
                },
                new Payment
                {
                    UserID = 2,
                    PaymentType = "Adoption Fee",
                    Amount = 200.00m,
                    Currency = 1, // NZD
                    PaymentDate = DateTime.Parse("2023-03-15"),
                    PaymentMethod = "Bank Transfer",
                    TransactionID = 654321,
                    PaymentStatus = "Completed",
                    Notes = "Adoption payment for Max"
                }
            );
            #endregion

            #region Seed Shelter
            context.Shelter.AddRange(
                new Shelter
                {
                    ShelterName = "Happy Tails Shelter",
                    FranchiseID = 1,
                    LocationID = 1,
                    AvailableBeds = 50,
                    OccupiedBeds = 30,
                    ContactNo = "01234567890",
                    OperatingHours = "Mon-Sun: 8 AM - 6 PM",
                    ShelterType = "Private",
                    EmailAddress = "shelter@happytails.com"
                },
                new Shelter
                {
                    ShelterName = "Safe Haven Shelter",
                    FranchiseID = 2,
                    LocationID = 2,
                    AvailableBeds = 40,
                    OccupiedBeds = 35,
                    ContactNo = "09876543210",
                    OperatingHours = "Mon-Sun: 9 AM - 7 PM",
                    ShelterType = "Government",
                    EmailAddress = "shelter@safehaven.com"
                }
            );
            #endregion

            context.SaveChanges();
        }
    }
}
