// Data/ApplicationDbContext.cs
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

           
        }
        public DbSet<_13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models.Breed> Breed { get; set; } = default!;
        public DbSet<_13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models.Shelter> Shelter { get; set; } = default!;
        public DbSet<_13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models.Pet> Pet { get; set; } = default!;
        public DbSet<_13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models.Location> Location { get; set; } = default!;
    }
}