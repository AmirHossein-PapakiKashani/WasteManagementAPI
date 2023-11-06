﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WasteManagementAPI.Models;

#nullable disable

namespace WasteManagementAPI.Migrations
{
    [DbContext(typeof(WastMangementGptBaseContext))]
    [Migration("20231105123317_RelationBetweenCitizenAndShipment")]
    partial class RelationBetweenCitizenAndShipment
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WasteManagementAPI.Models.DomainModels.Citizens", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ShipmentsId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ShipmentsId");

                    b.ToTable("Citizens");
                });

            modelBuilder.Entity("WasteManagementAPI.Models.DomainModels.Shipments", b =>
                {
                    b.Property<int>("ShipmentsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ShipmentsId"));

                    b.Property<bool>("ApproveBySupervisor")
                        .HasColumnType("bit");

                    b.Property<int>("PointsAllocated")
                        .HasColumnType("int");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("ShipmentsId");

                    b.ToTable("Shipments");
                });

            modelBuilder.Entity("WasteManagementAPI.Models.DomainModels.Citizens", b =>
                {
                    b.HasOne("WasteManagementAPI.Models.DomainModels.Shipments", "Shipments")
                        .WithMany("Citizens")
                        .HasForeignKey("ShipmentsId");

                    b.Navigation("Shipments");
                });

            modelBuilder.Entity("WasteManagementAPI.Models.DomainModels.Shipments", b =>
                {
                    b.Navigation("Citizens");
                });
#pragma warning restore 612, 618
        }
    }
}