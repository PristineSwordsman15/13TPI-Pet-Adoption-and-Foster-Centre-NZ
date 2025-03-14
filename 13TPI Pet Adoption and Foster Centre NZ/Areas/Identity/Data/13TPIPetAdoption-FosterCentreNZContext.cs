using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Areas.Identity.Data;

namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Data;

public class Context : IdentityDbContext<ApplicationUser>
{
    public Context(DbContextOptions<Context> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);

        builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
    }

public DbSet<_13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models.AdminOffice> AdminOffice { get; set; } = default!;

public DbSet<_13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models.Pet> Pet { get; set; } = default!;

public DbSet<_13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models.Franchise> Franchise { get; set; } = default!;

public DbSet<_13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models.Coordinator> Coordinator { get; set; } = default!;

public DbSet<_13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models.Location> Location { get; set; } = default!;

public DbSet<_13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models.MedicalRecord> MedicalRecord { get; set; } = default!;

public DbSet<_13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models.Payment> Payment { get; set; } = default!;

public DbSet<_13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models.Shelter> Shelter { get; set; } = default!;

public DbSet<_13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models.User> User { get; set; } = default!;

public DbSet<_13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models.Role> Role { get; set; } = default!;

public DbSet<_13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models.PetGroup> PetGroup { get; set; } = default!;
}
public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.Property(u => u.FirstName).HasMaxLength(25);
        builder.Property(u => u.LastName).HasMaxLength(25);
    }

   
}