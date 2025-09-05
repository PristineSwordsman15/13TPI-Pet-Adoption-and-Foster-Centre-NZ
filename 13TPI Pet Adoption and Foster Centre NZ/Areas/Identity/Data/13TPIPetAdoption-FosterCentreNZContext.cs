// Data/ApplicationDbContext.cs
using _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models;
using Microsoft.EntityFrameworkCore;


namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Data
{
    public class Context : DbContext
    {
        public Context (DbContextOptions options) : base(options) { }

        // DbSets
        public DbSet<AccessLevel> AccessLevel => Set<AccessLevel>();
        public DbSet<Title> Title => Set<Title>();
        public DbSet<AdminOffice> AdminOffice => Set<AdminOffice>();

        public DbSet<Location> Location => Set<Location>();
        public DbSet<Franchise> Franchise => Set<Franchise>();
        public DbSet<ShelterType> ShelterType => Set<ShelterType>();
        public DbSet<Shelter> Shelter => Set<Shelter>();

        public DbSet<PetStatus> PetStatus => Set<PetStatus>();
        public DbSet<PetGroup> PetGroup => Set<PetGroup>();
        public DbSet<Pet> Pet => Set<Pet>();
        public DbSet<Coordinator> Coordinator => Set<Coordinator>();

        public DbSet<VaccinationStatus> VaccinationStatus => Set<VaccinationStatus>();
        public DbSet<MedicalRecord> MedicalRecord => Set<MedicalRecord>();

        public DbSet<PaymentType> PaymentType => Set<PaymentType>();
        public DbSet<PaymentMethod> PaymentMethod => Set<PaymentMethod>();
        public DbSet<PaymentStatus> PaymentStatus => Set<PaymentStatus>();
        public DbSet<Payment> Payment => Set<Payment>();

        protected override void OnModelCreating(ModelBuilder mb)
        {
            base.OnModelCreating(mb);

            // minimal constraints/fluent config examples
            mb.Entity<Shelter>()
              .HasOne(s => s.ShelterType)
              .WithMany(t => t.Shelters)
              .HasForeignKey(s => s.ShelterTypeID)
              .OnDelete(DeleteBehavior.Restrict);

            mb.Entity<Franchise>()
              .HasOne(f => f.Location)
              .WithMany()
              .HasForeignKey(f => f.LocationID)
              .OnDelete(DeleteBehavior.Restrict);

            mb.Entity<MedicalRecord>()
              .HasOne(m => m.Pet)
              .WithMany()
              .HasForeignKey(m => m.PetID)
              .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
