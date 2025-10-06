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

        // DbSets
        public DbSet<AccessLevel> AccessLevel { get; set; }
        public DbSet<AdminOffice> AdminOffice { get; set; }
        public DbSet<Coordinator> Coordinator { get; set; }
        public DbSet<Franchise> Franchise { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<MedicalRecord> MedicalRecord { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<PaymentMethod> PaymentMethod { get; set; }
        public DbSet<PaymentStatus> PaymentStatus { get; set; }
        public DbSet<PaymentType> PaymentType { get; set; }
        public DbSet<Pet> Pet { get; set; }
        public DbSet<PetGroup> PetGroup { get; set; }
        public DbSet<PetStatus> PetStatus { get; set; }
        public DbSet<Shelter> Shelter { get; set; }
        public DbSet<ShelterType> ShelterType { get; set; }
        public DbSet<Title> Title { get; set; }
        public DbSet<VaccinationStatus> VaccinationStatus { get; set; }
    
       

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
                .WithMany(p => p.MedicalRecord)
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