﻿// <auto-generated />
using System;
using AutomotiveBrands.VehicleService.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AutomotiveBrands.VehicleService.Infrastructure.Data.Migrations
{
    [DbContext(typeof(VehicleDbContext))]
    [Migration("20231202124823_engine-capacity-column-change-type")]
    partial class enginecapacitycolumnchangetype
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AutomotiveBrands.VehicleService.Infrastructure.Data.Entities.Vehicles.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Brand")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("now()");

                    b.Property<string>("ImageName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("character varying(100)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<int>("ModelYear")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTime>("UpdatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("now()");

                    b.HasKey("Id");

                    b.HasIndex("Brand");

                    b.HasIndex("ModelYear");

                    b.ToTable("vehicle", "dbo");
                });

            modelBuilder.Entity("AutomotiveBrands.VehicleService.Infrastructure.Data.Entities.Vehicles.VehicleDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CO2")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("now()");

                    b.Property<string>("Engine")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("character varying(100)");

                    b.Property<double>("EngineCapacity")
                        .HasColumnType("double precision");

                    b.Property<double>("ExciseDuty")
                        .HasColumnType("double precision");

                    b.Property<int>("ExciseDutyRate")
                        .HasColumnType("integer");

                    b.Property<double>("FuelConsumption")
                        .HasColumnType("double precision");

                    b.Property<string>("ImageName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("character varying(100)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("ModelDescription")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("ModelName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("character varying(100)");

                    b.Property<double>("MotorVehicleTax")
                        .HasColumnType("double precision");

                    b.Property<double>("NetPrice")
                        .HasColumnType("double precision");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.Property<double>("TrafficRegistrationOfficialFee")
                        .HasColumnType("double precision");

                    b.Property<double>("TrafficRegistrationServiceFee")
                        .HasColumnType("double precision");

                    b.Property<DateTime>("UpdatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("now()");

                    b.Property<double>("Vat")
                        .HasColumnType("double precision");

                    b.Property<int>("VatRate")
                        .HasColumnType("integer");

                    b.Property<int>("VehicleId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("VehicleId");

                    b.ToTable("vehicledetail", "dbo");
                });

            modelBuilder.Entity("AutomotiveBrands.VehicleService.Infrastructure.Data.Entities.Vehicles.VehicleDetail", b =>
                {
                    b.HasOne("AutomotiveBrands.VehicleService.Infrastructure.Data.Entities.Vehicles.Vehicle", "Vehicle")
                        .WithMany("VehicleDetails")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("AutomotiveBrands.VehicleService.Infrastructure.Data.Entities.Vehicles.Vehicle", b =>
                {
                    b.Navigation("VehicleDetails");
                });
#pragma warning restore 612, 618
        }
    }
}