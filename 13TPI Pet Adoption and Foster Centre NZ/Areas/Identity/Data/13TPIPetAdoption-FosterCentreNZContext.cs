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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Franchise ↔ Location (many franchises per location)
            builder.Entity<Franchise>()
                .HasOne(f => f.Location)
                .WithMany(l => l.Franchises)
                .HasForeignKey(f => f.LocationID)
                .OnDelete(DeleteBehavior.Restrict);

            // Coordinator ↔ Franchise
            builder.Entity<Coordinator>()
                .HasOne(c => c.Franchise)
                .WithMany(f => f.Coordinators)
                .HasForeignKey(c => c.FranchiseID)
                .OnDelete(DeleteBehavior.Restrict);

            // Coordinator ↔ PetGroup
            builder.Entity<Coordinator>()
                .HasOne(c => c.PetGroup)
                .WithMany(pg => pg.Coordinators)
                .HasForeignKey(c => c.PetGroupID)
                .OnDelete(DeleteBehavior.Restrict);

            // Shelter ↔ Franchise
            builder.Entity<Shelter>()
                .HasOne(s => s.Franchise)
                .WithMany(f => f.Shelters)
                .HasForeignKey(s => s.FranchiseID)
                .OnDelete(DeleteBehavior.Restrict);

            // Shelter ↔ Location
            builder.Entity<Shelter>()
                .HasOne(s => s.Location)
                .WithMany(l => l.Shelters)
                .HasForeignKey(s => s.LocationID)
                .OnDelete(DeleteBehavior.Restrict);

            // Shelter ↔ ShelterType
            builder.Entity<Shelter>()
                .HasOne(s => s.ShelterType)
                .WithMany(st => st.Shelters)
                .HasForeignKey(s => s.ShelterTypeID)
                .OnDelete(DeleteBehavior.Restrict);

            // Pet ↔ PetGroup
            builder.Entity<Pet>()
                .HasOne(p => p.PetGroup)
                .WithMany(pg => pg.Pets)
                .HasForeignKey(p => p.PetGroupID)
                .OnDelete(DeleteBehavior.Restrict);

            // Pet ↔ PetStatus
            builder.Entity<Pet>()
                .HasOne(p => p.PetStatus)
                .WithMany(ps => ps.Pets)
                .HasForeignKey(p => p.PetStatusID)
                .OnDelete(DeleteBehavior.Restrict);

            // MedicalRecord ↔ Pet
            builder.Entity<MedicalRecord>()
                .HasOne(mr => mr.Pet)
                .WithMany(p => p.MedicalRecords)
                .HasForeignKey(mr => mr.PetID)
                .OnDelete(DeleteBehavior.Restrict);

            // MedicalRecord ↔ VaccinationStatus
            builder.Entity<MedicalRecord>()
                .HasOne(mr => mr.VaccinationStatus)
                .WithMany(vs => vs.MedicalRecords)
                .HasForeignKey(mr => mr.VaccinationStatusID)
                .OnDelete(DeleteBehavior.Restrict);

            // Payment ↔ PaymentType
            builder.Entity<Payment>()
                .HasOne(p => p.PaymentType)
                .WithMany(pt => pt.Payments)
                .HasForeignKey(p => p.PaymentTypeID)
                .OnDelete(DeleteBehavior.Restrict);

            // Payment ↔ PaymentMethod
            builder.Entity<Payment>()
                .HasOne(p => p.PaymentMethod)
                .WithMany(pm => pm.Payments)
                .HasForeignKey(p => p.PaymentMethodID)
                .OnDelete(DeleteBehavior.Restrict);

            // Payment ↔ PaymentStatus
            builder.Entity<Payment>()
                .HasOne(p => p.PaymentStatus)
                .WithMany(ps => ps.Payments)
                .HasForeignKey(p => p.PaymentStatusID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}