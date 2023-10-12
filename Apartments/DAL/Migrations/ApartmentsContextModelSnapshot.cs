﻿// <auto-generated />
using Apartments.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Apartments.Migrations
{
    [DbContext(typeof(ApartmentsContext))]
    partial class ApartmentsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Apartments.Models.Apartment.Apartment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("HousingTypeId")
                        .HasColumnType("int");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.Property<int>("ResidentsNumber")
                        .HasColumnType("int");

                    b.Property<int>("RoomsNumber")
                        .HasColumnType("int");

                    b.Property<string>("Square")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Address")
                        .HasName("Address_IDX");

                    b.HasIndex("HousingTypeId");

                    b.HasIndex("OwnerId");

                    b.ToTable("apartments");
                });

            modelBuilder.Entity("Apartments.Models.HousingType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.ToTable("housingTypes");
                });

            modelBuilder.Entity("Apartments.Models.Owner.Owner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PlacceOfWork")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("owner");
                });

            modelBuilder.Entity("Apartments.Models.Apartment.Apartment", b =>
                {
                    b.HasOne("Apartments.Models.HousingType", "HousingType")
                        .WithMany("HousingTypeApartments")
                        .HasForeignKey("HousingTypeId")
                        .HasConstraintName("HousingTypeApartments_HousingTypeId_fk")
                        .IsRequired();

                    b.HasOne("Apartments.Models.Owner.Owner", "Owner")
                        .WithMany("OwnerApartments")
                        .HasForeignKey("OwnerId")
                        .HasConstraintName("ownerapartments_OwnerId_FK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}