﻿// <auto-generated />
using System;
using AspMvcFlightsApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AspMvcFlightsApp.Migrations
{
    [DbContext(typeof(DataModelDbContext))]
    [Migration("20241219181006_DataModelCreate")]
    partial class DataModelCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AspMvcFlightsApp.Models.DataAirline", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Airlines");
                });

            modelBuilder.Entity("AspMvcFlightsApp.Models.DataAirport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Airports");
                });

            modelBuilder.Entity("AspMvcFlightsApp.Models.DataCity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("AspMvcFlightsApp.Models.DataFlight", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AirlineId")
                        .HasColumnType("int");

                    b.Property<int?>("ArrivalId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DepartureId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AirlineId");

                    b.HasIndex("ArrivalId");

                    b.HasIndex("DepartureId");

                    b.ToTable("Flights");
                });

            modelBuilder.Entity("AspMvcFlightsApp.Models.DataAirport", b =>
                {
                    b.HasOne("AspMvcFlightsApp.Models.DataCity", "City")
                        .WithMany()
                        .HasForeignKey("CityId");

                    b.Navigation("City");
                });

            modelBuilder.Entity("AspMvcFlightsApp.Models.DataFlight", b =>
                {
                    b.HasOne("AspMvcFlightsApp.Models.DataAirline", "Airline")
                        .WithMany()
                        .HasForeignKey("AirlineId");

                    b.HasOne("AspMvcFlightsApp.Models.DataAirport", "Arrival")
                        .WithMany()
                        .HasForeignKey("ArrivalId");

                    b.HasOne("AspMvcFlightsApp.Models.DataAirport", "Departure")
                        .WithMany()
                        .HasForeignKey("DepartureId");

                    b.Navigation("Airline");

                    b.Navigation("Arrival");

                    b.Navigation("Departure");
                });
#pragma warning restore 612, 618
        }
    }
}
