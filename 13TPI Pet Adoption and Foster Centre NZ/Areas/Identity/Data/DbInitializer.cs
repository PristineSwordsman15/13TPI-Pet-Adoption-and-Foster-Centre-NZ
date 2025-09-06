// Data/DbSeeder.cs
using _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models;
using _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Data;
using Microsoft.EntityFrameworkCore;

namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Data
{
    public static class DbInitializer
    {
        public static async Task SeedAsync(Context context)
        {
             await context.Database.MigrateAsync();

            // ---- LOOKUPS ----
            if (!context.AccessLevel.Any())
                context.AccessLevel.AddRange(
                    new AccessLevel { AccessLevelID = 1, LevelName = "Administrator" },
                    new AccessLevel { AccessLevelID = 5, LevelName = "Vet" },
                    new AccessLevel { AccessLevelID = 2, LevelName = "Coordinator" },
                    new AccessLevel { AccessLevelID = 4, LevelName = "Coordinator" },
                    new AccessLevel { AccessLevelID = 1, LevelName = "Administrator" },
                    new AccessLevel { AccessLevelID = 2, LevelName = "Coordinator" },
                    new AccessLevel { AccessLevelID = 3, LevelName = "Adopter" },
                    new AccessLevel { AccessLevelID = 4, LevelName = "Fosterer" },
                    new AccessLevel { AccessLevelID = 5, LevelName = "Vet" },
                    new AccessLevel { AccessLevelID = 6, LevelName = "GeneralUser" }
                );

            if (!context.Title.Any())
                context.Title.AddRange(
                    new Title { TitleID = 1, TitleName = "Mr" },
                    new Title { TitleID = 2, TitleName = "Mrs" },
                    new Title { TitleID = 3, TitleName = "Miss" },
                    new Title { TitleID = 4, TitleName = "Ms" },
                    new Title { TitleID = 5, TitleName = "Dr" },
                    new Title { TitleID = 6, TitleName = "Prof" },
                    new Title { TitleID = 7, TitleName = "Sir" },
                    new Title { TitleID = 8, TitleName = "Madam" },
                    new Title { TitleID = 9, TitleName = "Mx" },
                    new Title { TitleID = 10, TitleName = "Rev" }
                );

            if (!context.PetStatus.Any())
                context.PetStatus.AddRange(
                    new PetStatus { PetStatusID = 1, StatusName = "Available" },
                    new PetStatus { PetStatusID = 2, StatusName = "Adopted" },
                    new PetStatus { PetStatusID = 3, StatusName = "Fostered" },
                    new PetStatus { PetStatusID = 4, StatusName = "Pending Adoption" },
                    new PetStatus { PetStatusID = 5, StatusName = "Quarantined" },
                    new PetStatus { PetStatusID = 6, StatusName = "Medical Hold" },
                    new PetStatus { PetStatusID = 7, StatusName = "Training" },
                    new PetStatus { PetStatusID = 8, StatusName = "Transferred" },
                    new PetStatus { PetStatusID = 9, StatusName = "Deceased" },
                    new PetStatus { PetStatusID = 10, StatusName = "Returned" }
                );

            if (!context.ShelterType.Any())
                context.ShelterType.AddRange(
                    new ShelterType { ShelterTypeID = 1, Name = "Government" },
                    new ShelterType { ShelterTypeID = 2, Name = "Private" },
                    new ShelterType { ShelterTypeID = 3, Name = "Non-Profit" },
                    new ShelterType { ShelterTypeID = 4, Name = "Community" },
                    new ShelterType { ShelterTypeID = 5, Name = "Rescue Group" },
                    new ShelterType { ShelterTypeID = 6, Name = "Charity" },
                    new ShelterType { ShelterTypeID = 7, Name = "Regional Council" },
                    new ShelterType { ShelterTypeID = 8, Name = "Wildlife Rescue" },
                    new ShelterType { ShelterTypeID = 9, Name = "Veterinary Shelter" },
                    new ShelterType { ShelterTypeID = 10, Name = "Foster Network" }
                );

            if (!context.VaccinationStatus.Any())
                context.VaccinationStatus.AddRange(
                    new VaccinationStatus { VaccinationStatusID = 1, StatusName = "Up-to-date" },
                    new VaccinationStatus { VaccinationStatusID = 2, StatusName = "Partial" },
                    new VaccinationStatus { VaccinationStatusID = 3, StatusName = "Not vaccinated" },
                    new VaccinationStatus { VaccinationStatusID = 4, StatusName = "Rabies only" },
                    new VaccinationStatus { VaccinationStatusID = 5, StatusName = "Parvo only" },
                    new VaccinationStatus { VaccinationStatusID = 6, StatusName = "Distemper only" },
                    new VaccinationStatus { VaccinationStatusID = 7, StatusName = "Core vaccines complete" },
                    new VaccinationStatus { VaccinationStatusID = 8, StatusName = "Optional vaccines pending" },
                    new VaccinationStatus { VaccinationStatusID = 9, StatusName = "Expired" },
                    new VaccinationStatus { VaccinationStatusID = 10, StatusName = "Unknown" }
                );

            if (!context.PaymentType.Any())
                context.PaymentType.AddRange(
                    new PaymentType { PaymentTypeID = 1, Name = "Adoption Fee" },
                    new PaymentType { PaymentTypeID = 2, Name = "Donation" },
                    new PaymentType { PaymentTypeID = 3, Name = "Medical Fee" },
                    new PaymentType { PaymentTypeID = 4, Name = "Sponsorship" },
                    new PaymentType { PaymentTypeID = 5, Name = "Membership" },
                    new PaymentType { PaymentTypeID = 6, Name = "Foster Supplies" },
                    new PaymentType { PaymentTypeID = 7, Name = "Training Fee" },
                    new PaymentType { PaymentTypeID = 8, Name = "Microchip Fee" },
                    new PaymentType { PaymentTypeID = 9, Name = "Neuter/Spay Fee" },
                    new PaymentType { PaymentTypeID = 10, Name = "Other" }
                );

            if (!context.PaymentMethod.Any())
                context.PaymentMethod.AddRange(
                    new PaymentMethod { PaymentMethodID = 1, MethodName = "Credit Card" },
                    new PaymentMethod { PaymentMethodID = 2, MethodName = "Bank Transfer" },
                    new PaymentMethod { PaymentMethodID = 3, MethodName = "Cash" },
                    new PaymentMethod { PaymentMethodID = 4, MethodName = "EFTPOS" },
                    new PaymentMethod { PaymentMethodID = 5, MethodName = "PayPal" },
                    new PaymentMethod { PaymentMethodID = 6, MethodName = "Cheque" },
                    new PaymentMethod { PaymentMethodID = 7, MethodName = "Manual POS" },
                    new PaymentMethod { PaymentMethodID = 8, MethodName = "Gift Card" },
                    new PaymentMethod { PaymentMethodID = 9, MethodName = "Stripe" },
                    new PaymentMethod { PaymentMethodID = 10, MethodName = "Other" }
                );

            if (!context.PaymentStatus.Any())
                context.PaymentStatus.AddRange(
                    new PaymentStatus { PaymentStatusID = 1, StatusName = "Pending" },
                    new PaymentStatus { PaymentStatusID = 2, StatusName = "Completed" },
                    new PaymentStatus { PaymentStatusID = 3, StatusName = "Failed" },
                    new PaymentStatus { PaymentStatusID = 4, StatusName = "Refunded" },
                    new PaymentStatus { PaymentStatusID = 5, StatusName = "Cancelled" },
                    new PaymentStatus { PaymentStatusID = 6, StatusName = "Chargeback" },
                    new PaymentStatus { PaymentStatusID = 7, StatusName = "On Hold" },
                    new PaymentStatus { PaymentStatusID = 8, StatusName = "Partially Refunded" },
                    new PaymentStatus { PaymentStatusID = 9, StatusName = "Authorized" },
                    new PaymentStatus { PaymentStatusID = 10, StatusName = "Expired" }
                );

            await context.SaveChangesAsync();

            // ---- LOCATIONS (10) ----
            if (!context.Location.Any())
            {
                context.Location.AddRange(
                    new Location { LocationID = 1, Address = "123 Queen St", Surburb = "CBD", City = "Auckland", Region = "Auckland", PostCode = "1010", Country = "New Zealand" },
                    new Location { LocationID = 2, Address = "45 Cuba St", Surburb = "Te Aro", City = "Wellington", Region = "Wellington", PostCode = "6011", Country = "New Zealand" },
                    new Location { LocationID = 3, Address = "67 Riccarton Rd", Surburb = "Riccarton", City = "Christchurch", Region = "Canterbury", PostCode = "8011", Country = "New Zealand" },
                    new Location { LocationID = 4, Address = "89 George St", Surburb = "Central", City = "Dunedin", Region = "Otago", PostCode = "9016", Country = "New Zealand" },
                    new Location { LocationID = 5, Address = "22 Devon St", Surburb = "Central", City = "New Plymouth", Region = "Taranaki", PostCode = "4310", Country = "New Zealand" },
                    new Location { LocationID = 6, Address = "14 Grey St", Surburb = "Hamilton East", City = "Hamilton", Region = "Waikato", PostCode = "3204", Country = "New Zealand" },
                    new Location { LocationID = 7, Address = "33 High St", Surburb = "Central", City = "Lower Hutt", Region = "Wellington", PostCode = "5010", Country = "New Zealand" },
                    new Location { LocationID = 8, Address = "77 Main St", Surburb = "Central", City = "Palmerston North", Region = "Manawatu", PostCode = "4410", Country = "New Zealand" },
                    new Location { LocationID = 9, Address = "5 Karamu Rd", Surburb = "Hastings", City = "Hastings", Region = "Hawke's Bay", PostCode = "4122", Country = "New Zealand" },
                    new Location { LocationID = 10, Address = "11 Gladstone Rd", Surburb = "Central", City = "Gisborne", Region = "Gisborne", PostCode = "4010", Country = "New Zealand" }
                );
                await context.SaveChangesAsync();
            }

            // ---- FRANCHISES (10) ----
            if (!context.Franchise.Any())
            {
                context.Franchise.AddRange(
                    new Franchise { FranchiseID = 1, FranchiseName = "Auckland Shelter", ContactNo = "098765432", LocationID = 1, EmailAddress = "akl.shelter@example.com", OperatingHours = "9am-5pm", OwnerID = 1 },
                    new Franchise { FranchiseID = 2, FranchiseName = "Wellington Shelter", ContactNo = "098765433", LocationID = 2, EmailAddress = "wlg.shelter@example.com", OperatingHours = "9am-5pm", OwnerID = 2 },
                    new Franchise { FranchiseID = 3, FranchiseName = "Christchurch Shelter", ContactNo = "098765434", LocationID = 3, EmailAddress = "chc.shelter@example.com", OperatingHours = "9am-5pm", OwnerID = 3 },
                    new Franchise { FranchiseID = 4, FranchiseName = "Dunedin Shelter", ContactNo = "098765435", LocationID = 4, EmailAddress = "dun.shelter@example.com", OperatingHours = "9am-5pm", OwnerID = 4 },
                    new Franchise { FranchiseID = 5, FranchiseName = "New Plymouth Shelter", ContactNo = "098765436", LocationID = 5, EmailAddress = "np.shelter@example.com", OperatingHours = "9am-5pm", OwnerID = 5 },
                    new Franchise { FranchiseID = 6, FranchiseName = "Hamilton Shelter", ContactNo = "098765437", LocationID = 6, EmailAddress = "ham.shelter@example.com", OperatingHours = "9am-5pm", OwnerID = 6 },
                    new Franchise { FranchiseID = 7, FranchiseName = "Lower Hutt Shelter", ContactNo = "098765438", LocationID = 7, EmailAddress = "lh.shelter@example.com", OperatingHours = "9am-5pm", OwnerID = 7 },
                    new Franchise { FranchiseID = 8, FranchiseName = "Palmerston North Shelter", ContactNo = "098765439", LocationID = 8, EmailAddress = "pn.shelter@example.com", OperatingHours = "9am-5pm", OwnerID = 8 },
                    new Franchise { FranchiseID = 9, FranchiseName = "Hastings Shelter", ContactNo = "098765440", LocationID = 9, EmailAddress = "has.shelter@example.com", OperatingHours = "9am-5pm", OwnerID = 9 },
                    new Franchise { FranchiseID = 10, FranchiseName = "Gisborne Shelter", ContactNo = "098765441", LocationID = 10, EmailAddress = "gis.shelter@example.com", OperatingHours = "9am-5pm", OwnerID = 10 }
                );
                await context.SaveChangesAsync();
            }

            // ---- PET GROUPS (10) ----
            if (!context.PetGroup.Any())
            {
                context.PetGroup.AddRange(
                    new PetGroup { PetGroupID = 1, PetGroupName = "Dogs", PetGroupDescription = "All dog breeds" },
                    new PetGroup { PetGroupID = 2, PetGroupName = "Cats", PetGroupDescription = "All cat breeds" },
                    new PetGroup { PetGroupID = 3, PetGroupName = "Rabbits", PetGroupDescription = "All rabbit breeds" },
                    new PetGroup { PetGroupID = 4, PetGroupName = "Birds", PetGroupDescription = "All bird species" },
                    new PetGroup { PetGroupID = 5, PetGroupName = "Reptiles", PetGroupDescription = "Snakes, lizards, turtles" },
                    new PetGroup { PetGroupID = 6, PetGroupName = "Rodents", PetGroupDescription = "Mice, rats, hamsters" },
                    new PetGroup { PetGroupID = 7, PetGroupName = "Farm", PetGroupDescription = "Goats, sheep, pigs" },
                    new PetGroup { PetGroupID = 8, PetGroupName = "Horses", PetGroupDescription = "Equines" },
                    new PetGroup { PetGroupID = 9, PetGroupName = "Fish", PetGroupDescription = "Aquatic" },
                    new PetGroup { PetGroupID = 10, PetGroupName = "Other", PetGroupDescription = "Miscellaneous" }
                );
                await context.SaveChangesAsync();
            }

            // ---- PETS (10) ----
            if (!context.Pet.Any())
            {
                context.Pet.AddRange(
                    new Pet { PetID = 1, PetName = "Bella", Species = "Canine", Breed = "Labrador", PetAge = 3, ArrivalDate = DateTime.UtcNow.AddDays(-30), PetStatusID = 1 },
                    new Pet { PetID = 2, PetName = "Charlie", Species = "Canine", Breed = "Beagle", PetAge = 4, ArrivalDate = DateTime.UtcNow.AddDays(-40), PetStatusID = 2 },
                    new Pet { PetID = 3, PetName = "Milo", Species = "Feline", Breed = "Persian", PetAge = 2, ArrivalDate = DateTime.UtcNow.AddDays(-15), PetStatusID = 1 },
                    new Pet { PetID = 4, PetName = "Luna", Species = "Feline", Breed = "Siamese", PetAge = 1, ArrivalDate = DateTime.UtcNow.AddDays(-20), PetStatusID = 3 },
                    new Pet { PetID = 5, PetName = "Max", Species = "Canine", Breed = "Bulldog", PetAge = 5, ArrivalDate = DateTime.UtcNow.AddDays(-60), PetStatusID = 4 },
                    new Pet { PetID = 6, PetName = "Daisy", Species = "Lagomorph", Breed = "Netherland Dwarf", PetAge = 2, ArrivalDate = DateTime.UtcNow.AddDays(-10), PetStatusID = 1 },
                    new Pet { PetID = 7, PetName = "Rocky", Species = "Canine", Breed = "German Shepherd", PetAge = 6, ArrivalDate = DateTime.UtcNow.AddDays(-90), PetStatusID = 2 },
                    new Pet { PetID = 8, PetName = "Coco", Species = "Avian", Breed = "Parakeet", PetAge = 1, ArrivalDate = DateTime.UtcNow.AddDays(-5), PetStatusID = 1 },
                    new Pet { PetID = 9, PetName = "Buddy", Species = "Canine", Breed = "Golden Retriever", PetAge = 4, ArrivalDate = DateTime.UtcNow.AddDays(-25), PetStatusID = 7 },
                    new Pet { PetID = 10, PetName = "Nala", Species = "Feline", Breed = "Bengal", PetAge = 2, ArrivalDate = DateTime.UtcNow.AddDays(-35), PetStatusID = 1 }
                );
                await context.SaveChangesAsync();
            }

            // ---- SHELTERS (10) ----
            if (!context.Shelter.Any())
            {
                context.Shelter.AddRange(
                    new Shelter { ShelterID = 1, ShelterName = "Auckland Shelter", FranchiseID = 1, LocationID = 1, AvailableBeds = 50, OccupiedBeds = 30, ContactNo = "02123456789", OperatingHours = "9am-6pm", ShelterTypeID = 1, EmailAddress = "auckland@shelters.nz" },
                    new Shelter { ShelterID = 2, ShelterName = "Wellington Shelter", FranchiseID = 2, LocationID = 2, AvailableBeds = 40, OccupiedBeds = 25, ContactNo = "02123456780", OperatingHours = "9am-5pm", ShelterTypeID = 2, EmailAddress = "wellington@shelters.nz" },
                    new Shelter { ShelterID = 3, ShelterName = "Christchurch Shelter", FranchiseID = 3, LocationID = 3, AvailableBeds = 60, OccupiedBeds = 45, ContactNo = "02123456781", OperatingHours = "8am-6pm", ShelterTypeID = 3, EmailAddress = "chch@shelters.nz" },
                    new Shelter { ShelterID = 4, ShelterName = "Hamilton Shelter", FranchiseID = 4, LocationID = 4, AvailableBeds = 35, OccupiedBeds = 20, ContactNo = "02123456782", OperatingHours = "10am-6pm", ShelterTypeID = 4, EmailAddress = "hamilton@shelters.nz" },
                    new Shelter { ShelterID = 5, ShelterName = "Dunedin Shelter", FranchiseID = 5, LocationID = 5, AvailableBeds = 25, OccupiedBeds = 10, ContactNo = "02123456783", OperatingHours = "9am-5pm", ShelterTypeID = 5, EmailAddress = "dunedin@shelters.nz" },
                    new Shelter { ShelterID = 6, ShelterName = "Tauranga Shelter", FranchiseID = 6, LocationID = 6, AvailableBeds = 45, OccupiedBeds = 30, ContactNo = "02123456784", OperatingHours = "9am-7pm", ShelterTypeID = 6, EmailAddress = "tauranga@shelters.nz" },
                    new Shelter { ShelterID = 7, ShelterName = "Napier Shelter", FranchiseID = 7, LocationID = 7, AvailableBeds = 20, OccupiedBeds = 12, ContactNo = "02123456785", OperatingHours = "9am-4pm", ShelterTypeID = 7, EmailAddress = "napier@shelters.nz" },
                    new Shelter { ShelterID = 8, ShelterName = "Nelson Shelter", FranchiseID = 8, LocationID = 8, AvailableBeds = 30, OccupiedBeds = 18, ContactNo = "02123456786", OperatingHours = "8am-5pm", ShelterTypeID = 8, EmailAddress = "nelson@shelters.nz" },
                    new Shelter { ShelterID = 9, ShelterName = "Rotorua Shelter", FranchiseID = 9, LocationID = 9, AvailableBeds = 40, OccupiedBeds = 28, ContactNo = "02123456787", OperatingHours = "9am-6pm", ShelterTypeID = 9, EmailAddress = "rotorua@shelters.nz" },
                    new Shelter { ShelterID = 10, ShelterName = "Palmerston Shelter", FranchiseID = 10, LocationID = 10, AvailableBeds = 55, OccupiedBeds = 35, ContactNo = "02123456788", OperatingHours = "9am-6pm", ShelterTypeID = 10, EmailAddress = "palmerston@shelters.nz" }
                );
                await context.SaveChangesAsync();
            }

            // ---- ADMINS (10) ----
            if (!context.AdminOffice.Any())
            {
                context.AdminOffice.AddRange(
                    new AdminOffice { AdminID = 1, UserID = 1, FirstName = "John", LastName = "Doe", EmailAddress = "john.doe@example.com", ContactNo = "01234567890", DateHired = DateTime.UtcNow.AddYears(-3), AccessLevelID = 1, TitleID = 5 },
                    new AdminOffice { AdminID = 2, UserID = 2, FirstName = "Jane", LastName = "Smith", EmailAddress = "jane.smith@example.com", ContactNo = "01234567891", DateHired = DateTime.UtcNow.AddYears(-2), AccessLevelID = 2, TitleID = 4 },
                    new AdminOffice { AdminID = 3, UserID = 3, FirstName = "Mike", LastName = "Brown", EmailAddress = "mike.brown@example.com", ContactNo = "01234567892", DateHired = DateTime.UtcNow.AddYears(-4), AccessLevelID = 3, TitleID = 1 },
                    new AdminOffice { AdminID = 4, UserID = 4, FirstName = "Emily", LastName = "Clark", EmailAddress = "emily.clark@example.com", ContactNo = "01234567893", DateHired = DateTime.UtcNow.AddYears(-5), AccessLevelID = 4, TitleID = 3 },
                    new AdminOffice { AdminID = 5, UserID = 5, FirstName = "Daniel", LastName = "Wilson", EmailAddress = "daniel.wilson@example.com", ContactNo = "01234567894", DateHired = DateTime.UtcNow.AddYears(-1), AccessLevelID = 5, TitleID = 1 },
                    new AdminOffice { AdminID = 6, UserID = 6, FirstName = "Sophie", LastName = "Taylor", EmailAddress = "sophie.taylor@example.com", ContactNo = "01234567895", DateHired = DateTime.UtcNow.AddYears(-3), AccessLevelID = 1, TitleID = 4 },
                    new AdminOffice { AdminID = 7, UserID = 7, FirstName = "Chris", LastName = "Evans", EmailAddress = "chris.evans@example.com", ContactNo = "01234567896", DateHired = DateTime.UtcNow.AddMonths(-8), AccessLevelID = 1, TitleID = 1 },
                    new AdminOffice { AdminID = 8, UserID = 8, FirstName = "Laura", LastName = "Adams", EmailAddress = "laura.adams@example.com", ContactNo = "01234567897", DateHired = DateTime.UtcNow.AddYears(-6), AccessLevelID = 1, TitleID = 4 },
                    new AdminOffice { AdminID = 9, UserID = 9, FirstName = "Peter", LastName = "Wright", EmailAddress = "peter.wright@example.com", ContactNo = "01234567898", DateHired = DateTime.UtcNow.AddMonths(-14), AccessLevelID = 1, TitleID = 1 },
                    new AdminOffice { AdminID = 10, UserID = 10, FirstName = "Olivia", LastName = "Scott", EmailAddress = "olivia.scott@example.com", ContactNo = "01234567899", DateHired = DateTime.UtcNow.AddMonths(-3), AccessLevelID = 1, TitleID = 2}
                );
                await context.SaveChangesAsync();
            }

            // ---- COORDINATORS (10) ----
            if (!context.Coordinator.Any())
            {
                context.Coordinator.AddRange(
                    new Coordinator { CoordinatorID = 1, FranchiseID = 1, PetGroupID = 1, FirstName = "Alice", LastName = "Johnson", EmailAddress = "alice.johnson@example.com", ContactNo = "021123456", HireDate = DateTime.UtcNow.AddYears(-4), ExperienceLevel = "Expert" },
                    new Coordinator { CoordinatorID = 2, FranchiseID = 2, PetGroupID = 2, FirstName = "Bob", LastName = "Williams", EmailAddress = "bob.williams@example.com", ContactNo = "021234567", HireDate = DateTime.UtcNow.AddYears(-3), ExperienceLevel = "Intermediate" },
                    new Coordinator { CoordinatorID = 3, FranchiseID = 3, PetGroupID = 1, FirstName = "Clara", LastName = "Davis", EmailAddress = "clara.davis@example.com", ContactNo = "021345678", HireDate = DateTime.UtcNow.AddYears(-5), ExperienceLevel = "Expert" },
                    new Coordinator { CoordinatorID = 4, FranchiseID = 4, PetGroupID = 2, FirstName = "David", LastName = "Miller", EmailAddress = "david.miller@example.com", ContactNo = "021456789", HireDate = DateTime.UtcNow.AddYears(-2), ExperienceLevel = "Beginner" },
                    new Coordinator { CoordinatorID = 5, FranchiseID = 5, PetGroupID = 1, FirstName = "Ella", LastName = "Wilson", EmailAddress = "ella.wilson@example.com", ContactNo = "021567890", HireDate = DateTime.UtcNow.AddYears(-6), ExperienceLevel = "Expert" },
                    new Coordinator { CoordinatorID = 6, FranchiseID = 6, PetGroupID = 2, FirstName = "Frank", LastName = "Moore", EmailAddress = "frank.moore@example.com", ContactNo = "021678901", HireDate = DateTime.UtcNow.AddYears(-4), ExperienceLevel = "Intermediate" },
                    new Coordinator { CoordinatorID = 7, FranchiseID = 7, PetGroupID = 1, FirstName = "Grace", LastName = "Taylor", EmailAddress = "grace.taylor@example.com", ContactNo = "021789012", HireDate = DateTime.UtcNow.AddYears(-7), ExperienceLevel = "Expert" },
                    new Coordinator { CoordinatorID = 8, FranchiseID = 8, PetGroupID = 2, FirstName = "Henry", LastName = "Anderson", EmailAddress = "henry.anderson@example.com", ContactNo = "021890123", HireDate = DateTime.UtcNow.AddYears(-5), ExperienceLevel = "Intermediate" },
                    new Coordinator { CoordinatorID = 9, FranchiseID = 9, PetGroupID = 1, FirstName = "Isla", LastName = "Thomas", EmailAddress = "isla.thomas@example.com", ContactNo = "021901234", HireDate = DateTime.UtcNow.AddYears(-1), ExperienceLevel = "Beginner" },
                    new Coordinator { CoordinatorID = 10, FranchiseID = 10, PetGroupID = 2, FirstName = "Jack", LastName = "Martin", EmailAddress = "jack.martin@example.com", ContactNo = "021012345", HireDate = DateTime.UtcNow.AddYears(-3), ExperienceLevel = "Expert" }
                );
                await context.SaveChangesAsync();
            }

            // ---- MEDICAL RECORDS (attach to Pets) ----
            if (!context.MedicalRecord.Any())
            {
                context.MedicalRecord.AddRange(
                    new MedicalRecord { PetID = 1, VetName = "Dr. Smith", ClinicName = "Healthy Pets Clinic", VisitDate = DateTime.UtcNow.AddMonths(-6), Diagnosis = "Routine Checkup", Treatment = "None", MedicalRecordID = 1, MicrochipID = 1234567001, SpecialNeeds = "None" },
                    new MedicalRecord { PetID = 2, VetName = "Dr. Jones", ClinicName = "City Vet Clinic", VisitDate = DateTime.UtcNow.AddMonths(-4), Diagnosis = "Dental Cleaning", Treatment = "Teeth cleaning", MedicalRecordID = 1, MicrochipID = 1234567002, SpecialNeeds = "Sensitive teeth" },
                    new MedicalRecord { PetID = 3, VetName = "Dr. Brown", ClinicName = "Paws & Claws Vet", VisitDate = DateTime.UtcNow.AddMonths(-2), Diagnosis = "Allergy", Treatment = "Antihistamines", MedicalRecordID = 7, MicrochipID = 1234567003, SpecialNeeds = "Hypoallergenic diet" },
                    new MedicalRecord { PetID = 4, VetName = "Dr. Green", ClinicName = "Northside Vet", VisitDate = DateTime.UtcNow.AddMonths(-1), Diagnosis = "Skin infection", Treatment = "Antibiotics", MedicalRecordID = 1, MicrochipID = 1234567004, SpecialNeeds = "Sensitive skin" },
                    new MedicalRecord { PetID = 5, VetName = "Dr. White", ClinicName = "Happy Paws", VisitDate = DateTime.UtcNow.AddMonths(-8), Diagnosis = "Arthritis", Treatment = "Pain relief", MedicalRecordID = 9, MicrochipID = 1234567005, SpecialNeeds = "Joint supplements" },
                    new MedicalRecord { PetID = 6, VetName = "Dr. Grey", ClinicName = "Furry Friends Vet", VisitDate = DateTime.UtcNow.AddMonths(-3), Diagnosis = "Heartworm", Treatment = "Prevention meds", MedicalRecordID = 3, MicrochipID = 1234567006, SpecialNeeds = "None" },
                    new MedicalRecord { PetID = 7, VetName = "Dr. Black", ClinicName = "Riverdale Vet", VisitDate = DateTime.UtcNow.AddMonths(-5), Diagnosis = "Sprain", Treatment = "Rest", MedicalRecordID = 1, MicrochipID = 1234567007, SpecialNeeds = "None" },
                    new MedicalRecord { PetID = 8, VetName = "Dr. Blue", ClinicName = "Pet Wellness Center", VisitDate = DateTime.UtcNow.AddMonths(-1), Diagnosis = "Mites", Treatment = "Topical", MedicalRecordID = 2, MicrochipID = 1234567008, SpecialNeeds = "Follow up in 2w" },  
                    new MedicalRecord { PetID = 9, VetName = "Dr. Violet", ClinicName = "Well Vet", VisitDate = DateTime.UtcNow.AddMonths(-7), Diagnosis = "Obesity", Treatment = "Diet plan", MedicalRecordID = 1, MicrochipID = 1234567009, SpecialNeeds = "Dietary monitoring" },
                    new MedicalRecord { PetID = 10, VetName = "Dr. Amber", ClinicName = "Central Vet", VisitDate = DateTime.UtcNow.AddMonths(-9), Diagnosis = "URI", Treatment = "Antibiotics", MedicalRecordID = 8, MicrochipID = 1234567010, SpecialNeeds = "Warm environment" }
                );
                await context.SaveChangesAsync();
            }

            // ---- PAYMENTS (reference lookups) ----
            if (!context.Payment.Any())
            {
                context.Payment.AddRange(
                    new Payment { PaymentID = 1, UserID = 1, PaymentTypeID = 1, Amount = 150.00m, Currency = "NZD", PaymentDate = DateTime.UtcNow.AddDays(-30), PaymentMethodID = 1, TransactionID = 90001, PaymentStatusID = 2, Notes = "Adoption fee for Bella" },
                    new Payment { PaymentID = 2, UserID = 2, PaymentTypeID = 2, Amount = 50.00m, Currency = "NZD", PaymentDate = DateTime.UtcNow.AddDays(-25), PaymentMethodID = 2, TransactionID = 90002, PaymentStatusID = 2, Notes = "Donation" },
                    new Payment { PaymentID = 3, UserID = 3, PaymentTypeID = 3, Amount = 80.00m, Currency = "NZD", PaymentDate = DateTime.UtcNow.AddDays(-20), PaymentMethodID = 1, TransactionID = 90003, PaymentStatusID = 2, Notes = "Medical fee" },
                    new Payment { PaymentID = 4, UserID = 4, PaymentTypeID = 4, Amount = 200.00m, Currency = "NZD", PaymentDate = DateTime.UtcNow.AddDays(-18), PaymentMethodID = 5, TransactionID = 90004, PaymentStatusID = 1, Notes = "Sponsorship - pending" },
                    new Payment { PaymentID = 5, UserID = 5, PaymentTypeID = 5, Amount = 30.00m, Currency = "NZD", PaymentDate = DateTime.UtcNow.AddDays(-15), PaymentMethodID = 3, TransactionID = 90005, PaymentStatusID = 2, Notes = "Membership fee" },
                    new Payment { PaymentID = 6, UserID = 6, PaymentTypeID = 6, Amount = 40.00m, Currency = "NZD", PaymentDate = DateTime.UtcNow.AddDays(-12), PaymentMethodID = 4, TransactionID = 90006, PaymentStatusID = 2, Notes = "Foster supplies" },
                    new Payment { PaymentID = 7, UserID = 7, PaymentTypeID = 7, Amount = 120.00m, Currency = "NZD", PaymentDate = DateTime.UtcNow.AddDays(-10), PaymentMethodID = 1, TransactionID = 90007, PaymentStatusID = 3, Notes = "Training fee - failed" },
                    new Payment { PaymentID = 8, UserID = 8, PaymentTypeID = 8, Amount = 25.00m, Currency = "NZD", PaymentDate = DateTime.UtcNow.AddDays(-8), PaymentMethodID = 9, TransactionID = 90008, PaymentStatusID = 2, Notes = "Microchip fee" },
                    new Payment { PaymentID = 9, UserID = 9, PaymentTypeID = 9, Amount = 90.00m, Currency = "NZD", PaymentDate = DateTime.UtcNow.AddDays(-5), PaymentMethodID = 2, TransactionID = 90009, PaymentStatusID = 2, Notes = "Neuter/spay fee" },
                    new Payment { PaymentID = 10, UserID = 10, PaymentTypeID = 10, Amount = 10.00m, Currency = "NZD", PaymentDate = DateTime.UtcNow.AddDays(-2), PaymentMethodID = 3, TransactionID = 90010, PaymentStatusID = 2, Notes = "Other" }
                );
                await context.SaveChangesAsync();
            }
        }
    }
}
