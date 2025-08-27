using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models;
using _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNet.Identity;

namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Data
{
    
    

     

    public class DbInitializer
    {
        public static void Initialize (
            Context context)
        {
            // Ensure database is created.
            context.Database.EnsureCreated();

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
                },
                new Location { Address = "789 Critter Avenue, Zoo City", Surburb = "Wild Suburb", City = "Zoo City", Region = "Region Z", PostCode = "9101", Country = "New Zealand" },
                new Location { Address = "101 Pet Lane, Animal Kingdom", Surburb = "Furry City", City = "Animal Kingdom", Region = "Region W", PostCode = "2345", Country = "New Zealand" },
                new Location { Address = "202 Fur Street, Petland", Surburb = "Paw Suburb", City = "Paw City", Region = "Region V", PostCode = "6789", Country = "New Zealand" },
                new Location { Address = "303 Critter Close, Wildlife Town", Surburb = "Critter Suburb", City = "Wildlife Town", Region = "Region U", PostCode = "3456", Country = "New Zealand" },
                new Location { Address = "404 Pet Pathway, Animal Place", Surburb = "Fur Zone", City = "Animal Place", Region = "Region T", PostCode = "5670", Country = "New Zealand" },
                new Location { Address = "505 Critter Corner, Animal World", Surburb = "Pet Suburb", City = "Animal World", Region = "Region S", PostCode = "1239", Country = "New Zealand" },
                new Location { Address = "606 Fur Way, Pet Paradise", Surburb = "Paw Street", City = "Pet Paradise", Region = "Region R", PostCode = "8930", Country = "New Zealand" },
                new Location { Address = "707 Pet Avenue, Fur City", Surburb = "Paws Zone", City = "Fur City", Region = "Region Q", PostCode = "3120", Country = "New Zealand" }

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
                },
                 new MedicalRecord
                 {
                     PetID = 3,
                     VetName = "Dr. Emily Brown",
                     ClinicName = "Paws & Claws Veterinary",
                     VisitDate = new DateOnly(2024, 03, 20),
                     Diagnosis = "Broken leg",
                     Treatment = "Surgical repair",
                     VaccinationStatus = "Not Vaccinated",
                     MicrochipID = 1234567892,
                     SpecialNeeds = "Needs mobility assistance"
                 },
                    new MedicalRecord
                    {
                        PetID = 4,
                        VetName = "Dr. Alan Green",
                        ClinicName = "Northside Animal Clinic",
                        VisitDate = new DateOnly(2024, 04, 05),
                        Diagnosis = "Allergy reaction",
                        Treatment = "Steroid injection",
                        VaccinationStatus = "Fully Vaccinated",
                        MicrochipID = 1234567893,
                        SpecialNeeds = "None"
                    },
                    new MedicalRecord
                    {
                        PetID = 5,
                        VetName = "Dr. Sarah White",
                        ClinicName = "Happy Paws Animal Care",
                        VisitDate = new DateOnly(2024, 05, 10),
                        Diagnosis = "Dental disease",
                        Treatment = "Teeth cleaning",
                        VaccinationStatus = "Fully Vaccinated",
                        MicrochipID = 1234567894,
                        SpecialNeeds = "Requires regular teeth checks"
                    },
                    new MedicalRecord
                    {
                        PetID = 6,
                        VetName = "Dr. Lisa Grey",
                        ClinicName = "Furry Friends Veterinary Clinic",
                        VisitDate = new DateOnly(2024, 06, 15),
                        Diagnosis = "Heartworm",
                        Treatment = "Heartworm prevention meds",
                        VaccinationStatus = "Not Vaccinated",
                        MicrochipID = 1234567895,
                        SpecialNeeds = "None"
                    },
                    new MedicalRecord
                    {
                        PetID = 7,
                        VetName = "Dr. Mike Black",
                        ClinicName = "Riverdale Vet Clinic",
                        VisitDate = new DateOnly(2024, 07, 25),
                        Diagnosis = "Skin infection",
                        Treatment = "Antibiotics",
                        VaccinationStatus = "Fully Vaccinated",
                        MicrochipID = 1234567896,
                        SpecialNeeds = "Sensitive skin"
                    },
                    new MedicalRecord
                    {
                        PetID = 8,
                        VetName = "Dr. Karen Blue",
                        ClinicName = "Pet Wellness Center",
                        VisitDate = new DateOnly(2024, 08, 30),
                        Diagnosis = "Arthritis",
                        Treatment = "Pain relief medication",
                        VaccinationStatus = "Fully Vaccinated",
                        MicrochipID = 1234567897,
                        SpecialNeeds = "Requires arthritis treatment"
                    }


            );
            #endregion

            #region Seed Pet
            context.Pet.AddRange(
                new Pet
                {
                    PetName = "Bella",
                    PetGroupName = "Dog Dungeon",
                    Species = "Dog",
                    Breed = "Golden Retriever",
                    PetAge = 3,
                    ArrivalDate = DateTime.Parse("2023-01-01"),
                    PetStatus = "Available"
                },
                new Pet
                {
                    PetName = "Max",
                    PetGroupName = "Cat Corner",
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
                    Currency = "NZD", // NZD
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
                    Currency = "NZD", // NZD
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
