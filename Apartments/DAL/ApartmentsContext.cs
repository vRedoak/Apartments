using Apartments.Models;
using Apartments.Models.Apartment;
using Apartments.Models.Owner;
using Microsoft.EntityFrameworkCore;

namespace Apartments.DAL
{
    public class ApartmentsContext : DbContext
    {
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<HousingType> HousingTypes { get; set; }

        public ApartmentsContext(DbContextOptions<ApartmentsContext> options)
            : base(options)
        {
           // Database.EnsureCreated(); 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HousingType>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("housingTypes");

                entity.Property(e => e.Type).HasColumnType("nvarchar(256)");
            });

            modelBuilder.Entity<Apartment>(entity =>
            {
                entity.HasKey(e => new { e.Id });

                entity.ToTable("apartments");

                entity.HasIndex(e => e.Address)
                    .HasName("Address_IDX");

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.OwnerApartments)
                    .HasForeignKey(d => d.OwnerId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("ownerapartments_OwnerId_FK");

                entity.HasOne(d => d.HousingType)
                    .WithMany(p => p.HousingTypeApartments)
                    .HasForeignKey(d => d.HousingTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("HousingTypeApartments_HousingTypeId_fk");
            });

            modelBuilder.Entity<Owner>(entity =>
            {
                entity.HasKey(e => new { e.Id });

                entity.ToTable("owner");

                entity.Property(e => e.FirstName).HasColumnType("nvarchar(50)");
                entity.Property(e => e.LastName).HasColumnType("nvarchar(50)");
            });
        }
    }
}
