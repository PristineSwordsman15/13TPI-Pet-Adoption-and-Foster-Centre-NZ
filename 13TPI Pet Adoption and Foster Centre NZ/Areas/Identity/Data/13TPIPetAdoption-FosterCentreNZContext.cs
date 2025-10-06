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
    }
}