// ------------------- SEED DATA -------------------
using System;
using System.Linq;
using _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models;

namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Data
{
    public static class DbInitializer
    {
        public static void Initialize(13TPIPetAdoption-FosterCentreNZContext context)
        {
            context.Database.EnsureCreated();
            // Access Levels

            context.AccessLevel.AddRange(
                new AccessLevel { AccessLevelID = 1, LevelName = "Administrator" },
                new AccessLevel { AccessLevelID = 2, LevelName = "Coordinator" },
                new AccessLevel { AccessLevelID = 5, LevelName = "Fosterer" },
                new AccessLevel { AccessLevelID = 4, LevelName = "Adopter" },
                new AccessLevel { AccessLevelID = 5, LevelName = "Fosterer" },
                new AccessLevel { AccessLevelID = 4, LevelName = "Administrator" },
                new AccessLevel { AccessLevelID = 6, LevelName = "Guest" },
                new AccessLevel { AccessLevelID = 2, LevelName = "Coordinator" },
                new AccessLevel { AccessLevelID = 1, LevelName = "Adopter" },
                new AccessLevel { AccessLevelID = 6, LevelName = "Guest" }
            );

            // Admin Office
            context.AdminOffice.AddRange(
                new AdminOffice { AdminID = 1, UserID = 1, FirstName = "John", LastName = "Doe", EmailAddress = "john.doe@example.com", ContactNo = "01234567890", DateHired = DateTime.Parse("2021-01-10"), AccessLevelID = 1, LevelName = "Administrator", TitleName = "Head Admin" },
                new AdminOffice { AdminID = 2, UserID = 2, FirstName = "Jane", LastName = "Smith", EmailAddress = "jane.smith@example.com", ContactNo = "01234567891", DateHired = DateTime.Parse("2022-03-15"), AccessLevelID = 2, LevelName = "Manager", TitleName = "Operations Manager" },
                new AdminOffice { AdminID = 3, UserID = 3, FirstName = "Mike", LastName = "Brown", EmailAddress = "mike.brown@example.com", ContactNo = "01234567892", DateHired = DateTime.Parse("2020-07-20"), AccessLevelID = 3, LevelName = "Supervisor", TitleName = "Senior Supervisor" },
                new AdminOffice { AdminID = 4, UserID = 4, FirstName = "Emily", LastName = "Clark", EmailAddress = "emily.clark@example.com", ContactNo = "01234567893", DateHired = DateTime.Parse("2019-05-10"), AccessLevelID = 4, LevelName = "Coordinator", TitleName = "Pet Coordinator" },
                new AdminOffice { AdminID = 5, UserID = 5, FirstName = "Daniel", LastName = "Wilson", EmailAddress = "daniel.wilson@example.com", ContactNo = "01234567894", DateHired = DateTime.Parse("2021-11-11"), AccessLevelID = 5, LevelName = "Assistant", TitleName = "Admin Assistant" },
                new AdminOffice { AdminID = 6, UserID = 6, FirstName = "Sophie", LastName = "Taylor", EmailAddress = "sophie.taylor@example.com", ContactNo = "01234567895", DateHired = DateTime.Parse("2020-09-09"), AccessLevelID = 6, LevelName = "HR", TitleName = "HR Manager" },
                new AdminOffice { AdminID = 7, UserID = 7, FirstName = "Chris", LastName = "Evans", EmailAddress = "chris.evans@example.com", ContactNo = "01234567896", DateHired = DateTime.Parse("2023-02-02"), AccessLevelID = 7, LevelName = "IT Support", TitleName = "IT Specialist" },
                new AdminOffice { AdminID = 8, UserID = 8, FirstName = "Laura", LastName = "Adams", EmailAddress = "laura.adams@example.com", ContactNo = "01234567897", DateHired = DateTime.Parse("2018-08-08"), AccessLevelID = 8, LevelName = "Finance", TitleName = "Finance Officer" },
                new AdminOffice { AdminID = 9, UserID = 9, FirstName = "Peter", LastName = "Wright", EmailAddress = "peter.wright@example.com", ContactNo = "01234567898", DateHired = DateTime.Parse("2022-06-06"), AccessLevelID = 9, LevelName = "Volunteer", TitleName = "Volunteer Lead" },
                new AdminOffice { AdminID = 10, UserID = 10, FirstName = "Olivia", LastName = "Scott", EmailAddress = "olivia.scott@example.com", ContactNo = "01234567899", DateHired = DateTime.Parse("2023-04-01"), AccessLevelID = 10, LevelName = "Guest", TitleName = "Temporary Staff" }
            );

            // Location
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

            // Franchise
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

            // Coordinator
            context.Coordinator.AddRange(
                new Coordinator { CoordinatorID = 1, FranchiseID = 1, PetGroupID = 1, FirstName = "Alice", LastName = "Johnson", EmailAddress = "alice.johnson@example.com", ContactNo = "021123456", HireDate = DateTime.Parse("2020-01-01"), ExperienceLevel = "Expert", Title = "Senior Coordinator" },
                new Coordinator { CoordinatorID = 2, FranchiseID = 2, PetGroupID = 2, FirstName = "Bob", LastName = "Williams", EmailAddress = "bob.williams@example.com", ContactNo = "021234567", HireDate = DateTime.Parse("2021-02-01"), ExperienceLevel = "Intermediate", Title = "Coordinator" },
                new Coordinator { CoordinatorID = 3, FranchiseID = 3, PetGroupID = 1, FirstName = "Clara", LastName = "Davis", EmailAddress = "clara.davis@example.com", ContactNo = "021345678", HireDate = DateTime.Parse("2019-03-01"), ExperienceLevel = "Expert", Title = "Pet Coordinator" },
                new Coordinator { CoordinatorID = 4, FranchiseID = 4, PetGroupID = 2, FirstName = "David", LastName = "Miller", EmailAddress = "david.miller@example.com", ContactNo = "021456789", HireDate = DateTime.Parse("2022-04-01"), ExperienceLevel = "Beginner", Title = "Junior Coordinator" },
                new Coordinator { CoordinatorID = 5, FranchiseID = 5, PetGroupID = 1, FirstName = "Ella", LastName = "Wilson", EmailAddress = "ella.wilson@example.com", ContactNo = "021567890", HireDate = DateTime.Parse("2018-05-01"), ExperienceLevel = "Expert", Title = "Senior Coordinator" },
                new Coordinator { CoordinatorID = 6, FranchiseID = 6, PetGroupID = 2, FirstName = "Frank", LastName = "Moore", EmailAddress = "frank.moore@example.com", ContactNo = "021678901", HireDate = DateTime.Parse("2020-06-01"), ExperienceLevel = "Intermediate", Title = "Coordinator" },
                new Coordinator { CoordinatorID = 7, FranchiseID = 7, PetGroupID = 1, FirstName = "Grace", LastName = "Taylor", EmailAddress = "grace.taylor@example.com", ContactNo = "021789012", HireDate = DateTime.Parse("2017-07-01"), ExperienceLevel = "Expert", Title = "Pet Coordinator" },
                new Coordinator { CoordinatorID = 8, FranchiseID = 8, PetGroupID = 2, FirstName = "Henry", LastName = "Anderson", EmailAddress = "henry.anderson@example.com", ContactNo = "021890123", HireDate = DateTime.Parse("2019-08-01"), ExperienceLevel = "Intermediate", Title = "Coordinator" },
                new Coordinator { CoordinatorID = 9, FranchiseID = 9, PetGroupID = 1, FirstName = "Isla", LastName = "Thomas", EmailAddress = "isla.thomas@example.com", ContactNo = "021901234", HireDate = DateTime.Parse("2021-09-01"), ExperienceLevel = "Beginner", Title = "Junior Coordinator" },
                new Coordinator { CoordinatorID = 10, FranchiseID = 10, PetGroupID = 2, FirstName = "Jack", LastName = "Martin", EmailAddress = "jack.martin@example.com", ContactNo = "021012345", HireDate = DateTime.Parse("2022-10-01"), ExperienceLevel = "Expert", Title = "Senior Coordinator" });

            #region Seed PetStatus
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
            #endregion

            #region Seed Pet
            context.Pet.AddRange(
                new Pet { PetID = 1, PetName = "Bella", PetGroupName = "Dogs", Species = "Canine", Breed = "Labrador", PetAge = 3, ArrivalDate = DateTime.Now.AddDays(-30), PetStatus = "Available" },
                new Pet { PetID = 2, PetName = "Charlie", PetGroupName = "Dogs", Species = "Canine", Breed = "Beagle", PetAge = 4, ArrivalDate = DateTime.Now.AddDays(-40), PetStatus = "Adopted" },
                new Pet { PetID = 3, PetName = "Milo", PetGroupName = "Cats", Species = "Feline", Breed = "Persian", PetAge = 2, ArrivalDate = DateTime.Now.AddDays(-15), PetStatus = "Available" },
                new Pet { PetID = 4, PetName = "Luna", PetGroupName = "Cats", Species = "Feline", Breed = "Siamese", PetAge = 1, ArrivalDate = DateTime.Now.AddDays(-20), PetStatus = "Fostered" },
                new Pet { PetID = 5, PetName = "Max", PetGroupName = "Dogs", Species = "Canine", Breed = "Bulldog", PetAge = 5, ArrivalDate = DateTime.Now.AddDays(-60), PetStatus = "Pending Adoption" },
                new Pet { PetID = 6, PetName = "Daisy", PetGroupName = "Rabbits", Species = "Lagomorph", Breed = "Netherland Dwarf", PetAge = 2, ArrivalDate = DateTime.Now.AddDays(-10), PetStatus = "Available" },
                new Pet { PetID = 7, PetName = "Rocky", PetGroupName = "Dogs", Species = "Canine", Breed = "German Shepherd", PetAge = 6, ArrivalDate = DateTime.Now.AddDays(-90), PetStatus = "Adopted" },
                new Pet { PetID = 8, PetName = "Coco", PetGroupName = "Birds", Species = "Avian", Breed = "Parakeet", PetAge = 1, ArrivalDate = DateTime.Now.AddDays(-5), PetStatus = "Available" },
                new Pet { PetID = 9, PetName = "Buddy", PetGroupName = "Dogs", Species = "Canine", Breed = "Golden Retriever", PetAge = 4, ArrivalDate = DateTime.Now.AddDays(-25), PetStatus = "Training" },
                new Pet { PetID = 10, PetName = "Nala", PetGroupName = "Cats", Species = "Feline", Breed = "Bengal", PetAge = 2, ArrivalDate = DateTime.Now.AddDays(-35), PetStatus = "Available" }
            );
            #endregion

            #region Seed PetGroup
            context.PetGroup.AddRange(
                new PetGroup { PetGroupID = 1, PetID = 1, GroupID = 1, PetGroupName = "Dogs", PeGroupDescriptiom = "All dog breeds" },
                new PetGroup { PetGroupID = 2, PetID = 2, GroupID = 1, PetGroupName = "Dogs", PeGroupDescriptiom = "All dog breeds" },
                new PetGroup { PetGroupID = 3, PetID = 3, GroupID = 2, PetGroupName = "Cats", PeGroupDescriptiom = "All cat breeds" },
                new PetGroup { PetGroupID = 4, PetID = 4, GroupID = 2, PetGroupName = "Cats", PeGroupDescriptiom = "All cat breeds" },
                new PetGroup { PetGroupID = 5, PetID = 5, GroupID = 1, PetGroupName = "Dogs", PeGroupDescriptiom = "All dog breeds" },
                new PetGroup { PetGroupID = 6, PetID = 6, GroupID = 3, PetGroupName = "Rabbits", PeGroupDescriptiom = "All rabbit breeds" },
                new PetGroup { PetGroupID = 7, PetID = 7, GroupID = 1, PetGroupName = "Dogs", PeGroupDescriptiom = "All dog breeds" },
                new PetGroup { PetGroupID = 8, PetID = 8, GroupID = 4, PetGroupName = "Birds", PeGroupDescriptiom = "All bird species" },
                new PetGroup { PetGroupID = 9, PetID = 9, GroupID = 1, PetGroupName = "Dogs", PeGroupDescriptiom = "All dog breeds" },
                new PetGroup { PetGroupID = 10, PetID = 10, GroupID = 2, PetGroupName = "Cats", PeGroupDescriptiom = "All cat breeds" }
            );
            #endregion

            #region Seed ShelterType
            context.ShelterType.AddRange(
                new ShelterType { ShelterTypeID = 1, TypeName = "Government" },
                new ShelterType { ShelterTypeID = 2, TypeName = "Private" },
                new ShelterType { ShelterTypeID = 3, TypeName = "Non-Profit" },
                new ShelterType { ShelterTypeID = 4, TypeName = "Community" },
                new ShelterType { ShelterTypeID = 5, TypeName = "Rescue Group" },
                new ShelterType { ShelterTypeID = 6, TypeName = "Charity" },
                new ShelterType { ShelterTypeID = 7, TypeName = "Regional Council" },
                new ShelterType { ShelterTypeID = 8, TypeName = "Wildlife Rescue" },
                new ShelterType { ShelterTypeID = 9, TypeName = "Veterinary Shelter" },
                new ShelterType { ShelterTypeID = 10, TypeName = "Foster Network" }
            );
            #endregion

            #region Seed Shelter
            context.Shelter.AddRange(
                new Shelter { ShelterID = 1, ShelterName = "Auckland Shelter", FranchiseID = 1, LocationID = 1, AvailableBeds = 50, OccupiedBeds = 30, ContactNo = "02123456789", OperatingHours = "9am-6pm", ShelterType = "Government", EmailAddress = "auckland@shelters.nz" },
                new Shelter { ShelterID = 2, ShelterName = "Wellington Shelter", FranchiseID = 2, LocationID = 2, AvailableBeds = 40, OccupiedBeds = 25, ContactNo = "02123456780", OperatingHours = "9am-5pm", ShelterType = "Private", EmailAddress = "wellington@shelters.nz" },
                new Shelter { ShelterID = 3, ShelterName = "Christchurch Shelter", FranchiseID = 3, LocationID = 3, AvailableBeds = 60, OccupiedBeds = 45, ContactNo = "02123456781", OperatingHours = "8am-6pm", ShelterType = "Non-Profit", EmailAddress = "chch@shelters.nz" },
                new Shelter { ShelterID = 4, ShelterName = "Hamilton Shelter", FranchiseID = 4, LocationID = 4, AvailableBeds = 35, OccupiedBeds = 20, ContactNo = "02123456782", OperatingHours = "10am-6pm", ShelterType = "Community", EmailAddress = "hamilton@shelters.nz" },
                new Shelter { ShelterID = 5, ShelterName = "Dunedin Shelter", FranchiseID = 5, LocationID = 5, AvailableBeds = 25, OccupiedBeds = 10, ContactNo = "02123456783", OperatingHours = "9am-5pm", ShelterType = "Rescue Group", EmailAddress = "dunedin@shelters.nz" },
                new Shelter { ShelterID = 6, ShelterName = "Tauranga Shelter", FranchiseID = 6, LocationID = 6, AvailableBeds = 45, OccupiedBeds = 30, ContactNo = "02123456784", OperatingHours = "9am-7pm", ShelterType = "Charity", EmailAddress = "tauranga@shelters.nz" },
                new Shelter { ShelterID = 7, ShelterName = "Napier Shelter", FranchiseID = 7, LocationID = 7, AvailableBeds = 20, OccupiedBeds = 12, ContactNo = "02123456785", OperatingHours = "9am-4pm", ShelterType = "Regional Council", EmailAddress = "napier@shelters.nz" },
                new Shelter { ShelterID = 8, ShelterName = "Nelson Shelter", FranchiseID = 8, LocationID = 8, AvailableBeds = 30, OccupiedBeds = 18, ContactNo = "02123456786", OperatingHours = "8am-5pm", ShelterType = "Wildlife Rescue", EmailAddress = "nelson@shelters.nz" },
                new Shelter { ShelterID = 9, ShelterName = "Rotorua Shelter", FranchiseID = 9, LocationID = 9, AvailableBeds = 40, OccupiedBeds = 28, ContactNo = "02123456787", OperatingHours = "9am-6pm", ShelterType = "Veterinary Shelter", EmailAddress = "rotorua@shelters.nz" },
                new Shelter { ShelterID = 10, ShelterName = "Palmerston Shelter", FranchiseID = 10, LocationID = 10, AvailableBeds = 55, OccupiedBeds = 35, ContactNo = "02123456788", OperatingHours = "9am-6pm", ShelterType = "Foster Network", EmailAddress = "palmerston@shelters.nz" }
            );
            #endregion

            #region Seed Title
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
            #endregion

            #region Seed VaccinationStatus
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

            #endregion
        }
    }
}






