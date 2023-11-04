﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WasteManagementAPI.Models;

#nullable disable

namespace WasteManagementAPI.Migrations
{
    [DbContext(typeof(WastMangementGptBaseContext))]
    partial class WastMangementGptBaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WasteManagementAPI.Models.DomainModels.Citizens", b =>
                {
                    b.Property<int>("CitizensId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CitizensId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CitizensId");

                    b.ToTable("Citizens");
                });

            modelBuilder.Entity("WasteManagementAPI.Models.DomainModels.CollectionBooths", b =>
                {
                    b.Property<int>("CollectionBoothsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CollectionBoothsId"));

                    b.Property<string>("EmployeeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeePasswored")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeUserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CollectionBoothsId");

                    b.ToTable("CollectionBooths");
                });

            modelBuilder.Entity("WasteManagementAPI.Models.DomainModels.Contractors", b =>
                {
                    b.Property<int>("ContractorsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ContractorsId"));

                    b.Property<int>("MunicipalitiesId")
                        .HasColumnType("int");

                    b.Property<string>("Nmae")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ContractorsId");

                    b.HasIndex("MunicipalitiesId");

                    b.ToTable("Contractors");
                });

            modelBuilder.Entity("WasteManagementAPI.Models.DomainModels.Municipalities", b =>
                {
                    b.Property<int>("MunicipalitiesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MunicipalitiesId"));

                    b.Property<string>("MunicipalityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MunicipalitiesId");

                    b.ToTable("Municipality");
                });

            modelBuilder.Entity("WasteManagementAPI.Models.DomainModels.Shipments", b =>
                {
                    b.Property<int>("ShipmentsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ShipmentsId"));

                    b.Property<bool>("ApproveBySupervisor")
                        .HasColumnType("bit");

                    b.Property<int>("CitizensId")
                        .HasColumnType("int");

                    b.Property<int>("CollectionBoothsId")
                        .HasColumnType("int");

                    b.Property<int>("PointsAllocated")
                        .HasColumnType("int");

                    b.Property<string>("Weight")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ShipmentsId");

                    b.HasIndex("CitizensId")
                        .IsUnique();

                    b.HasIndex("CollectionBoothsId");

                    b.ToTable("Shipments");
                });

            modelBuilder.Entity("WasteManagementAPI.Models.DomainModels.Supervisors", b =>
                {
                    b.Property<int>("SupervisorsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SupervisorsId"));

                    b.Property<int>("MunicipalitiesId")
                        .HasColumnType("int");

                    b.Property<int>("MunicipalityId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SupervisorsId");

                    b.HasIndex("MunicipalitiesId");

                    b.ToTable("Supervisor");
                });

            modelBuilder.Entity("WasteManagementAPI.Models.DomainModels.WasteTypes", b =>
                {
                    b.Property<int>("WasteTypesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WasteTypesId"));

                    b.Property<int>("ShipmentId")
                        .HasColumnType("int");

                    b.Property<int>("ShipmentsId")
                        .HasColumnType("int");

                    b.Property<string>("WasteName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("WasteTypesId");

                    b.HasIndex("ShipmentsId");

                    b.ToTable("WasteTypes");
                });

            modelBuilder.Entity("WasteManagementAPI.Models.DomainModels.Contractors", b =>
                {
                    b.HasOne("WasteManagementAPI.Models.DomainModels.Municipalities", "Municipalities")
                        .WithMany("Contractors")
                        .HasForeignKey("MunicipalitiesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Municipalities");
                });

            modelBuilder.Entity("WasteManagementAPI.Models.DomainModels.Shipments", b =>
                {
                    b.HasOne("WasteManagementAPI.Models.DomainModels.Citizens", "Citizens")
                        .WithOne("Shipments")
                        .HasForeignKey("WasteManagementAPI.Models.DomainModels.Shipments", "CitizensId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WasteManagementAPI.Models.DomainModels.CollectionBooths", "CollectionBooths")
                        .WithMany("Shipments")
                        .HasForeignKey("CollectionBoothsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Citizens");

                    b.Navigation("CollectionBooths");
                });

            modelBuilder.Entity("WasteManagementAPI.Models.DomainModels.Supervisors", b =>
                {
                    b.HasOne("WasteManagementAPI.Models.DomainModels.Municipalities", "Municipalities")
                        .WithMany("Supervisors")
                        .HasForeignKey("MunicipalitiesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Municipalities");
                });

            modelBuilder.Entity("WasteManagementAPI.Models.DomainModels.WasteTypes", b =>
                {
                    b.HasOne("WasteManagementAPI.Models.DomainModels.Shipments", "Shipments")
                        .WithMany("WasteTypes")
                        .HasForeignKey("ShipmentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Shipments");
                });

            modelBuilder.Entity("WasteManagementAPI.Models.DomainModels.Citizens", b =>
                {
                    b.Navigation("Shipments");
                });

            modelBuilder.Entity("WasteManagementAPI.Models.DomainModels.CollectionBooths", b =>
                {
                    b.Navigation("Shipments");
                });

            modelBuilder.Entity("WasteManagementAPI.Models.DomainModels.Municipalities", b =>
                {
                    b.Navigation("Contractors");

                    b.Navigation("Supervisors");
                });

            modelBuilder.Entity("WasteManagementAPI.Models.DomainModels.Shipments", b =>
                {
                    b.Navigation("WasteTypes");
                });
#pragma warning restore 612, 618
        }
    }
}
