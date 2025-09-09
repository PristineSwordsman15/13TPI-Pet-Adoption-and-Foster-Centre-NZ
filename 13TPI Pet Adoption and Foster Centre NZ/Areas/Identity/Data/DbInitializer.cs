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
                    new AccessLevel { LevelName = "Administrator" },
                    new AccessLevel { LevelName = "Coordinator" },
                    new AccessLevel { LevelName = "Vet" },
                    new AccessLevel { LevelName = "Adopter" },
                    new AccessLevel { LevelName = "Fosterer" },
                    new AccessLevel { LevelName = "GeneralUser" }

                );

            if (!context.Title.Any())
                context.Title.AddRange(
                    new Title { TitleName = "Mr" },
                    new Title { TitleName = "Mrs" },
                    new Title { TitleName = "Miss" },
                    new Title { TitleName = "Ms" },
                    new Title { TitleName = "Dr" },
                    new Title { TitleName = "Prof" },
                    new Title { TitleName = "Sir" },
                    new Title { TitleName = "Madam" },
                    new Title { TitleName = "Mx" },
                    new Title { TitleName = "Rev" }
                );

            if (!context.PetStatus.Any())
                context.PetStatus.AddRange(
                    new PetStatus { StatusName = "Available" },
                    new PetStatus { StatusName = "Adopted" },
                    new PetStatus { StatusName = "Fostered" },
                    new PetStatus { StatusName = "Pending Adoption" },
                    new PetStatus { StatusName = "Quarantined" },
                    new PetStatus { StatusName = "Medical Hold" },
                    new PetStatus { StatusName = "Training" },
                    new PetStatus { StatusName = "Transferred" },
                    new PetStatus { StatusName = "Deceased" },
                    new PetStatus { StatusName = "Returned" }
                );

            if (!context.ShelterType.Any())
                context.ShelterType.AddRange(
                    new ShelterType { Name = "Government" },
                    new ShelterType { Name = "Private" }
                );
               
                   

            if (!context.VaccinationStatus.Any())
                context.VaccinationStatus.AddRange(
                    new VaccinationStatus { StatusName = "Up-to-date" },
                    new VaccinationStatus { StatusName = "Partial" },
                    new VaccinationStatus { StatusName = "Not vaccinated" },
                    new VaccinationStatus { StatusName = "Rabies only" },
                    new VaccinationStatus { StatusName = "Parvo only" },
                    new VaccinationStatus { StatusName = "Distemper only" },
                    new VaccinationStatus { StatusName = "Core vaccines complete" },
                    new VaccinationStatus { StatusName = "Optional vaccines pending" },
                    new VaccinationStatus { StatusName = "Expired" },
                    new VaccinationStatus { StatusName = "Unknown" }
                );

            if (!context.PaymentType.Any())
                context.PaymentType.AddRange(
                    new PaymentType { Name = "Adoption Fee" },
                    new PaymentType { Name = "Donation" },
                    new PaymentType { Name = "Medical Fee" },
                    new PaymentType { Name = "Sponsorship" },
                    new PaymentType { Name = "Membership" },
                    new PaymentType { Name = "Foster Supplies" },
                    new PaymentType { Name = "Training Fee" },
                    new PaymentType { Name = "Microchip Fee" },
                    new PaymentType { Name = "Neuter/Spay Fee" },
                    new PaymentType { Name = "Other" }
                );

            if (!context.PaymentMethod.Any())
                context.PaymentMethod.AddRange(
                    new PaymentMethod {  MethodName = "Credit Card" },
                    new PaymentMethod {  MethodName = "Bank Transfer" },
                    new PaymentMethod {  MethodName = "Cash" },
                    new PaymentMethod {  MethodName = "EFTPOS" },
                    new PaymentMethod {  MethodName = "PayPal" },
                    new PaymentMethod {  MethodName = "Cheque" },
                    new PaymentMethod {  MethodName = "Manual POS" },
                    new PaymentMethod { MethodName = "Gift Card" },
                    new PaymentMethod { MethodName = "Stripe" },
                    new PaymentMethod {  MethodName = "Other" }
                );

            if (!context.PaymentStatus.Any())
                context.PaymentStatus.AddRange(
                    new PaymentStatus { StatusName = "Pending" },
                    new PaymentStatus { StatusName = "Completed" },
                    new PaymentStatus { StatusName = "Failed" },
                    new PaymentStatus { StatusName = "Refunded" },
                    new PaymentStatus { StatusName = "Cancelled" },
                    new PaymentStatus { StatusName = "Chargeback" },
                    new PaymentStatus { StatusName = "On Hold" },
                    new PaymentStatus { StatusName = "Partially Refunded" },
                    new PaymentStatus { StatusName = "Authorized" },
                    new PaymentStatus { StatusName = "Expired" }
                );

            
            // ---- LOCATIONS (10) ----
            if (!context.Location.Any())
            {
                context.Location.AddRange(
                    new Location {  Address = "123 Queen St", Surburb = "CBD", City = "Auckland", Region = "Auckland", PostCode = "1010", Country = "New Zealand" },
                    new Location {  Address = "45 Cuba St", Surburb = "Te Aro", City = "Wellington", Region = "Wellington", PostCode = "6011", Country = "New Zealand" },
                    new Location {   Address = "67 Riccarton Rd", Surburb = "Riccarton", City = "Christchurch", Region = "Canterbury", PostCode = "8011", Country = "New Zealand" },
                    new Location {  Address = "89 George St", Surburb = "Central", City = "Dunedin", Region = "Otago", PostCode = "9016", Country = "New Zealand" },
                    new Location {  Address = "22 Devon St", Surburb = "Central", City = "New Plymouth", Region = "Taranaki", PostCode = "4310", Country = "New Zealand" },
                    new Location { Address = "14 Grey St", Surburb = "Hamilton East", City = "Hamilton", Region = "Waikato", PostCode = "3204", Country = "New Zealand" },
                    new Location {   Address = "33 High St", Surburb = "Central", City = "Lower Hutt", Region = "Wellington", PostCode = "5010", Country = "New Zealand" },
                    new Location {  Address = "77 Main St", Surburb = "Central", City = "Palmerston North", Region = "Manawatu", PostCode = "4410", Country = "New Zealand" },
                    new Location {   Address = "5 Karamu Rd", Surburb = "Hastings", City = "Hastings", Region = "Hawke's Bay", PostCode = "4122", Country = "New Zealand" },
                    new Location {   Address = "11 Gladstone Rd", Surburb = "Central", City = "Gisborne", Region = "Gisborne", PostCode = "4010", Country = "New Zealand" }
                );
                await context.SaveChangesAsync();
            }

            // ---- FRANCHISES (10) ----
            if (!context.Franchise.Any())
            {
                context.Franchise.AddRange(
                    new Franchise { FranchiseName = "Auckland Shelter", ContactNo = "098765432", EmailAddress = "akl.shelter@example.com", OperatingHours = "9am-5pm"},
                    new Franchise { FranchiseName = "Wellington Shelter", ContactNo = "098765433", EmailAddress = "wlg.shelter@example.com", OperatingHours = "9am-5pm" },
                    new Franchise { FranchiseName = "Christchurch Shelter", ContactNo = "098765434", EmailAddress = "chc.shelter@example.com", OperatingHours = "9am-5pm" },
                    new Franchise { FranchiseName = "Dunedin Shelter", ContactNo = "098765435", EmailAddress = "dun.shelter@example.com", OperatingHours = "9am-5pm" },
                    new Franchise { FranchiseName = "New Plymouth Shelter", ContactNo = "098765436", EmailAddress = "np.shelter@example.com", OperatingHours = "9am-5pm" },
                    new Franchise { FranchiseName = "Hamilton Shelter", ContactNo = "098765437", EmailAddress = "ham.shelter@example.com", OperatingHours = "9am-5pm" },
                    new Franchise { FranchiseName = "Lower Hutt Shelter", ContactNo = "098765438", EmailAddress = "lh.shelter@example.com", OperatingHours = "9am-5pm" },
                    new Franchise { FranchiseName = "Palmerston North Shelter", ContactNo = "098765439", EmailAddress = "pn.shelter@example.com", OperatingHours = "9am-5pm" },
                    new Franchise {FranchiseName = "Hastings Shelter", ContactNo = "098765440" , EmailAddress = "has.shelter@example.com", OperatingHours = "9am-5pm" },
                    new Franchise {  FranchiseName = "Gisborne Shelter", ContactNo = "098765441", EmailAddress = "gis.shelter@example.com", OperatingHours = "9am-5pm" }
                );
                await context.SaveChangesAsync();
            }

            // ---- PET GROUPS (10) ----
            if (!context.PetGroup.Any())
            {
                context.PetGroup.AddRange(
                    new PetGroup {   PetGroupName = "Dogs", PetGroupDescription = "All dog breeds" },
                    new PetGroup { PetGroupName = "Cats", PetGroupDescription = "All cat breeds" },
                    new PetGroup {  PetGroupName = "Rabbits", PetGroupDescription = "All rabbit breeds" },
                    new PetGroup { PetGroupName = "Birds", PetGroupDescription = "All bird species" },
                    new PetGroup { PetGroupName = "Reptiles", PetGroupDescription = "Snakes, lizards, turtles" },
                    new PetGroup { PetGroupName = "Rodents", PetGroupDescription = "Mice, rats, hamsters" },
                    new PetGroup { PetGroupName = "Farm", PetGroupDescription = "Goats, sheep, pigs" },
                    new PetGroup { PetGroupName = "Horses", PetGroupDescription = "Equines" },
                    new PetGroup { PetGroupName = "Fish", PetGroupDescription = "Aquatic" },
                    new PetGroup { PetGroupName = "Other", PetGroupDescription = "Miscellaneous" }
                );
                await context.SaveChangesAsync();
            }

            // ---- PETS (10) ----
            if (!context.Pet.Any())
            {
                context.Pet.AddRange(
                    new Pet { PetName = "Bella", Species = "Canine", Breed = "Labrador", PetAge = 3, ArrivalDate = DateTime.UtcNow.AddDays(-30)},
                    new Pet { PetName = "Charlie", Species = "Canine", Breed = "Beagle", PetAge = 4, ArrivalDate = DateTime.UtcNow.AddDays(-40) },
                    new Pet { PetName = "Milo", Species = "Feline", Breed = "Persian", PetAge = 2, ArrivalDate = DateTime.UtcNow.AddDays(-15), },
                    new Pet { PetName = "Luna", Species = "Feline", Breed = "Siamese", PetAge = 1, ArrivalDate = DateTime.UtcNow.AddDays(-20)},
                    new Pet { PetName = "Max", Species = "Canine", Breed = "Bulldog", PetAge = 5, ArrivalDate = DateTime.UtcNow.AddDays(-60) },
                    new Pet { PetName = "Daisy", Species = "Lagomorph", Breed = "Netherland Dwarf", PetAge = 2, ArrivalDate = DateTime.UtcNow.AddDays(-10) },
                    new Pet { PetName = "Rocky", Species = "Canine", Breed = "German Shepherd", PetAge = 6, ArrivalDate = DateTime.UtcNow.AddDays(-90) },
                    new Pet { PetName = "Coco", Species = "Avian", Breed = "Parakeet", PetAge = 1, ArrivalDate = DateTime.UtcNow.AddDays(-5) },
                    new Pet { PetName = "Buddy", Species = "Canine", Breed = "Golden Retriever", PetAge = 4, ArrivalDate = DateTime.UtcNow.AddDays(-25) },
                    new Pet { PetName = "Nala", Species = "Feline", Breed = "Bengal", PetAge = 2, ArrivalDate = DateTime.UtcNow.AddDays(-35) }
                );
                await context.SaveChangesAsync();
            }

            // ---- SHELTERS (10) ----
            if (!context.Shelter.Any())
            {
                context.Shelter.AddRange(
                    new Shelter {  ShelterName = "Auckland Shelter", FranchiseID = 1, LocationID = 1, AvailableBeds = 50, OccupiedBeds = 30, ContactNo = "02123456789", OperatingHours = "9am-6pm",  EmailAddress = "auckland@shelters.nz" },
                    new Shelter { ShelterName = "Wellington Shelter", FranchiseID = 2, LocationID = 2, AvailableBeds = 40, OccupiedBeds = 25, ContactNo = "02123456780", OperatingHours = "9am-5pm",  EmailAddress = "wellington@shelters.nz" },
                    new Shelter { ShelterName = "Christchurch Shelter", FranchiseID = 3, LocationID = 3, AvailableBeds = 60, OccupiedBeds = 45, ContactNo = "02123456781", OperatingHours = "8am-6pm",  EmailAddress = "chch@shelters.nz" },
                    new Shelter { ShelterName = "Hamilton Shelter", FranchiseID = 4, LocationID = 4, AvailableBeds = 35, OccupiedBeds = 20, ContactNo = "02123456782", OperatingHours = "10am-6pm",  EmailAddress = "hamilton@shelters.nz" },
                    new Shelter { ShelterName = "Dunedin Shelter", FranchiseID = 5, LocationID = 5, AvailableBeds = 25, OccupiedBeds = 10, ContactNo = "02123456783", OperatingHours = "9am-5pm",  EmailAddress = "dunedin@shelters.nz" },
                    new Shelter { ShelterName = "Tauranga Shelter", FranchiseID = 6, LocationID = 6, AvailableBeds = 45, OccupiedBeds = 30, ContactNo = "02123456784", OperatingHours = "9am-7pm", EmailAddress = "tauranga@shelters.nz" },
                    new Shelter { ShelterName = "Napier Shelter", FranchiseID = 7, LocationID = 7, AvailableBeds = 20, OccupiedBeds = 12, ContactNo = "02123456785", OperatingHours = "9am-4pm",  EmailAddress = "napier@shelters.nz" },
                    new Shelter { ShelterName = "Nelson Shelter", FranchiseID = 8, LocationID = 8, AvailableBeds = 30, OccupiedBeds = 18, ContactNo = "02123456786", OperatingHours = "8am-5pm",  EmailAddress = "nelson@shelters.nz" },
                    new Shelter { ShelterName = "Rotorua Shelter", FranchiseID = 9, LocationID = 9, AvailableBeds = 40, OccupiedBeds = 28, ContactNo = "02123456787", OperatingHours = "9am-6pm",  EmailAddress = "rotorua@shelters.nz" },
                    new Shelter { ShelterName = "Palmerston Shelter", FranchiseID = 10, LocationID = 10, AvailableBeds = 55, OccupiedBeds = 35, ContactNo = "02123456788", OperatingHours = "9am-6pm",  EmailAddress = "palmerston@shelters.nz" }
                );
                await context.SaveChangesAsync();
            }

            // ---- ADMINS (10) ----
            if (!context.AdminOffice.Any())
            {
                context.AdminOffice.AddRange(
                    new AdminOffice { FirstName = "John", LastName = "Doe", EmailAddress = "john.doe@example.com", ContactNo = "01234567890", DateHired = DateTime.UtcNow.AddYears(-3) },
                    new AdminOffice { FirstName = "Jane", LastName = "Smith", EmailAddress = "jane.smith@example.com", ContactNo = "01234567891", DateHired = DateTime.UtcNow.AddYears(-2)},
                    new AdminOffice { FirstName = "Mike", LastName = "Brown", EmailAddress = "mike.brown@example.com", ContactNo = "01234567892", DateHired = DateTime.UtcNow.AddYears(-4)},
                    new AdminOffice {FirstName = "Emily", LastName = "Clark", EmailAddress = "emily.clark@example.com", ContactNo = "01234567893", DateHired = DateTime.UtcNow.AddYears(-5) },
                    new AdminOffice {FirstName = "Daniel", LastName = "Wilson", EmailAddress = "daniel.wilson@example.com", ContactNo = "01234567894", DateHired = DateTime.UtcNow.AddYears(-1) },
                    new AdminOffice {FirstName = "Sophie", LastName = "Taylor", EmailAddress = "sophie.taylor@example.com", ContactNo = "01234567895", DateHired = DateTime.UtcNow.AddYears(-3) },
                    new AdminOffice { FirstName = "Chris", LastName = "Evans", EmailAddress = "chris.evans@example.com", ContactNo = "01234567896", DateHired = DateTime.UtcNow.AddMonths(-8)},
                    new AdminOffice {FirstName = "Laura", LastName = "Adams", EmailAddress = "laura.adams@example.com", ContactNo = "01234567897", DateHired = DateTime.UtcNow.AddYears(-6) },
                    new AdminOffice { FirstName = "Peter", LastName = "Wright", EmailAddress = "peter.wright@example.com", ContactNo = "01234567898", DateHired = DateTime.UtcNow.AddMonths(-14) },
                    new AdminOffice {FirstName = "Olivia", LastName = "Scott", EmailAddress = "olivia.scott@example.com", ContactNo = "01234567899", DateHired = DateTime.UtcNow.AddMonths(-3) }
                );
                await context.SaveChangesAsync();
            }

            // ---- COORDINATORS (10) ----
            if (!context.Coordinator.Any())
            {
                context.Coordinator.AddRange(
                    new Coordinator { FirstName = "Alice", LastName = "Johnson", EmailAddress = "alice.johnson@example.com", ContactNo = "021123456", HireDate = DateTime.UtcNow.AddYears(-4), ExperienceLevel = "Expert" },
                    new Coordinator {  FirstName = "Bob", LastName = "Williams", EmailAddress = "bob.williams@example.com", ContactNo = "021234567", HireDate = DateTime.UtcNow.AddYears(-3), ExperienceLevel = "Intermediate" },
                    new Coordinator {  FirstName = "Clara", LastName = "Davis", EmailAddress = "clara.davis@example.com", ContactNo = "021345678", HireDate = DateTime.UtcNow.AddYears(-5), ExperienceLevel = "Expert" },
                    new Coordinator {    FirstName = "David", LastName = "Miller", EmailAddress = "david.miller@example.com", ContactNo = "021456789", HireDate = DateTime.UtcNow.AddYears(-2), ExperienceLevel = "Beginner" },
                    new Coordinator {  FirstName = "Ella", LastName = "Wilson", EmailAddress = "ella.wilson@example.com", ContactNo = "021567890", HireDate = DateTime.UtcNow.AddYears(-6), ExperienceLevel = "Expert" },
                    new Coordinator { FirstName = "Frank", LastName = "Moore", EmailAddress = "frank.moore@example.com", ContactNo = "021678901", HireDate = DateTime.UtcNow.AddYears(-4), ExperienceLevel = "Intermediate" },
                    new Coordinator { FirstName = "Grace", LastName = "Taylor", EmailAddress = "grace.taylor@example.com", ContactNo = "021789012", HireDate = DateTime.UtcNow.AddYears(-7), ExperienceLevel = "Expert" },
                    new Coordinator {  FirstName = "Henry", LastName = "Anderson", EmailAddress = "henry.anderson@example.com", ContactNo = "021890123", HireDate = DateTime.UtcNow.AddYears(-5), ExperienceLevel = "Intermediate" },
                    new Coordinator { FirstName = "Isla", LastName = "Thomas", EmailAddress = "isla.thomas@example.com", ContactNo = "021901234", HireDate = DateTime.UtcNow.AddYears(-1), ExperienceLevel = "Beginner" },
                    new Coordinator { FirstName = "Jack", LastName = "Martin", EmailAddress = "jack.martin@example.com", ContactNo = "021012345", HireDate = DateTime.UtcNow.AddYears(-3), ExperienceLevel = "Expert" }
                );  
                await context.SaveChangesAsync();
            }

            // ---- MEDICAL RECORDS (attach to Pets) ----
            if (!context.MedicalRecord.Any())
            {
                context.MedicalRecord.AddRange(
                    new MedicalRecord { PetID = 1, VetName = "Dr. Smith", ClinicName = "Healthy Pets Clinic", VisitDate = DateTime.UtcNow.AddMonths(-6), Diagnosis = "Routine Checkup", Treatment = "None",SpecialNeeds = "None" },
                    new MedicalRecord { VetName = "Dr. Jones", ClinicName = "City Vet Clinic", VisitDate = DateTime.UtcNow.AddMonths(-4), Diagnosis = "Dental Cleaning", Treatment = "Teeth cleaning", SpecialNeeds = "Sensitive teeth" },
                    new MedicalRecord { VetName = "Dr. Brown", ClinicName = "Paws & Claws Vet", VisitDate = DateTime.UtcNow.AddMonths(-2), Diagnosis = "Allergy", Treatment = "Antihistamines",  SpecialNeeds = "Hypoallergenic diet" },
                    new MedicalRecord { VetName = "Dr. Green", ClinicName = "Northside Vet", VisitDate = DateTime.UtcNow.AddMonths(-1), Diagnosis = "Skin infection", Treatment = "Antibiotics", SpecialNeeds = "Sensitive skin" },
                    new MedicalRecord { VetName = "Dr. White", ClinicName = "Happy Paws", VisitDate = DateTime.UtcNow.AddMonths(-8), Diagnosis = "Arthritis", Treatment = "Pain relief" , SpecialNeeds = "Joint supplements" },
                    new MedicalRecord {  VetName = "Dr. Grey", ClinicName = "Furry Friends Vet", VisitDate = DateTime.UtcNow.AddMonths(-3), Diagnosis = "Heartworm", Treatment = "Prevention meds",  SpecialNeeds = "None" },
                    new MedicalRecord {VetName = "Dr. Black", ClinicName = "Riverdale Vet", VisitDate = DateTime.UtcNow.AddMonths(-5), Diagnosis = "Sprain", Treatment = "Rest", SpecialNeeds = "None" },
                    new MedicalRecord { VetName = "Dr. Blue", ClinicName = "Pet Wellness Center", VisitDate = DateTime.UtcNow.AddMonths(-1), Diagnosis = "Mites", Treatment = "Topical", SpecialNeeds = "Follow up in 2w" },  
                    new MedicalRecord {VetName = "Dr. Violet", ClinicName = "Well Vet", VisitDate = DateTime.UtcNow.AddMonths(-7), Diagnosis = "Obesity", Treatment = "Diet plan", SpecialNeeds = "Dietary monitoring" },
                    new MedicalRecord {VetName = "Dr. Amber", ClinicName = "Central Vet", VisitDate = DateTime.UtcNow.AddMonths(-9), Diagnosis = "URI", Treatment = "Antibiotics", SpecialNeeds = "Warm environment" }
                );
                await context.SaveChangesAsync();
            }

            // ---- PAYMENTS (reference lookups) ----
            if (!context.Payment.Any())
            {
                context.Payment.AddRange(
                    new Payment { Amount = 150.00m, Currency = "NZD", PaymentDate = DateTime.UtcNow.AddDays(-30), Notes = "Adoption fee for Bella" },
                    new Payment { Amount = 50.00m, Currency = "NZD", PaymentDate = DateTime.UtcNow.AddDays(-25), Notes = "Donation" },
                    new Payment {Amount = 80.00m, Currency = "NZD", PaymentDate = DateTime.UtcNow.AddDays(-20), Notes = "Medical fee" },
                    new Payment {Amount = 200.00m, Currency = "NZD", PaymentDate = DateTime.UtcNow.AddDays(-18), Notes = "Sponsorship - pending" },
                    new Payment {Amount = 30.00m, Currency = "NZD", PaymentDate = DateTime.UtcNow.AddDays(-15), Notes = "Membership fee" },
                    new Payment {Amount = 40.00m, Currency = "NZD", PaymentDate = DateTime.UtcNow.AddDays(-12), Notes = "Foster supplies" },
                    new Payment { Amount = 120.00m, Currency = "NZD", PaymentDate = DateTime.UtcNow.AddDays(-10), Notes = "Training fee - failed" },
                    new Payment {Amount = 25.00m, Currency = "NZD", PaymentDate = DateTime.UtcNow.AddDays(-8), Notes = "Microchip fee" },
                    new Payment {Amount = 90.00m, Currency = "NZD", PaymentDate = DateTime.UtcNow.AddDays(-5), Notes = "Neuter/spay fee" },
                    new Payment {Amount = 10.00m, Currency = "NZD", PaymentDate = DateTime.UtcNow.AddDays(-2), Notes = "Other" }
                );
                await context.SaveChangesAsync();
            }
        }
    }
}
