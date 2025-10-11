
using _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Areas.Identity.Data;
using _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Collections;


namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Data
{
    public class Context : IdentityDbContext<ApplicationUser>
    {
        internal IEnumerable TitleName;

        public Context(DbContextOptions <Context> options) : base(options) 
        { 
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Breed>().HasData(
                new Breed { BreedID = 1, BreedName = "Shit Tzu" },
                new Breed { BreedID = 2, BreedName = "Chihuahua" },
                new Breed { BreedID = 3, BreedName = "Dalmation" },
                new Breed { BreedID = 4, BreedName = "German Shepard" },
                new Breed { BreedID = 5, BreedName = "Labrador" }
            );

            builder.Entity<Location>().HasData(
                new Location { LocationID = 1, LocationName = "Central City", Street = "123 Main St", City = "Auckland", State = "Auckland", ZipCode = "1010", Country = "NZ" },
                new Location { LocationID = 2, LocationName = "Northside", Street = "456 North Rd", City = "Auckland", State = "Auckland", ZipCode = "1021", Country = "NZ" },
                new Location { LocationID = 3, LocationName = "East End", Street = "789 East Ave", City = "Auckland", State = "Auckland", ZipCode = "1032", Country = "NZ" },
                new Location { LocationID = 4, LocationName = "South Park", Street = "321 South St", City = "Auckland", State = "Auckland", ZipCode = "1043", Country = "NZ" },
                new Location { LocationID = 5, LocationName = "Westfield", Street = "654 West Rd", City = "Auckland", State = "Auckland", ZipCode = "1054", Country = "NZ" }
            );

            builder.Entity<Shelter>().HasData(
                new Shelter { ShelterID = 1, ShelterName = "Happy Tails Shelter", LocationID = 1 },
                new Shelter { ShelterID = 2, ShelterName = "Paws and Claws Rescue", LocationID = 2 },
                new Shelter { ShelterID = 3, ShelterName = "Furry Friends Haven", LocationID = 3 },
                new Shelter { ShelterID = 4, ShelterName = "Safe Haven Shelter", LocationID = 4 },
                new Shelter { ShelterID = 5, ShelterName = "Wagging Tails Rescue", LocationID = 5 },
                new Shelter { ShelterID = 6, ShelterName = "Cozy Paws Shelter", LocationID = 4 },
                new Shelter { ShelterID = 7, ShelterName = "Loving Arms Rescue", LocationID = 3 },
                new Shelter { ShelterID = 8, ShelterName = "Forever Home Shelter", LocationID = 2 },
                new Shelter { ShelterID = 9, ShelterName = "New Beginnings Rescue", LocationID = 1 },
                new Shelter { ShelterID = 10, ShelterName = "Caring Hearts Shelter", LocationID = 5 }
            );

            builder.Entity<Pet>().HasData(
                new Pet { PetID = 1, PetName = "Max", ShelterID = 1, BreedID = 1, Colour = "Brown", Adoption = false },
                new Pet { PetID = 2, PetName = "Bella", ShelterID = 2, BreedID = 2, Colour = "Black", Adoption = false },
                new Pet { PetID = 3, PetName = "Charlie", ShelterID = 1, BreedID = 1, Colour = "White", Adoption = false },
                new Pet { PetID = 4, PetName = "Lucy", ShelterID = 3, BreedID = 3, Colour = "Golden", Adoption = false },
                new Pet { PetID = 5, PetName = "Walter", ShelterID = 4, BreedID = 3, Colour = "Golden", Adoption = false },
                new Pet { PetID = 6, PetName = "Carlos", ShelterID = 2, BreedID = 2, Colour = "Orange", Adoption = false },
                new Pet { PetID = 7, PetName = "Michael", ShelterID = 5, BreedID = 3, Colour = "Yellow", Adoption = false },
                new Pet { PetID = 8, PetName = "Oscar", ShelterID = 4, BreedID = 5, Colour = "Brown", Adoption = false },
                new Pet { PetID = 9, PetName = "Fred", ShelterID = 1, BreedID = 3, Colour = "Black", Adoption = false },
                new Pet { PetID = 10, PetName = "Lucas", ShelterID = 2, BreedID = 5, Colour = "Tan", Adoption = false },
                new Pet { PetID = 11, PetName = "Alonso", ShelterID = 3, BreedID = 3, Colour = "White", Adoption = false },
                new Pet { PetID = 12, PetName = "Alex", ShelterID = 5, BreedID = 1, Colour = "Grey", Adoption = false },
                new Pet { PetID = 13, PetName = "Lawrence", ShelterID = 10, BreedID = 4, Colour = "Red", Adoption = false }
            );
        }
        public DbSet<_13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models.Breed> Breed { get; set; } = default!;
        public DbSet<_13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models.Shelter> Shelter { get; set; } = default!;
        public DbSet<_13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models.Pet> Pet { get; set; } = default!;
        public DbSet<_13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models.Location> Location { get; set; } = default!;
    }
}







