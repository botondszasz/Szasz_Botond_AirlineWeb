﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Szasz_Botond_AirlineWeb.Data;

namespace Szasz_Botond_AirlineWeb.Migrations
{
    [DbContext(typeof(Szasz_Botond_AirlineWebContext))]
    [Migration("20220107182438_ReservationCategory")]
    partial class ReservationCategory
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Szasz_Botond_AirlineWeb.Models.Airline", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AirlineName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Airline");
                });

            modelBuilder.Entity("Szasz_Botond_AirlineWeb.Models.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("Szasz_Botond_AirlineWeb.Models.Reservation", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AirlineID")
                        .HasColumnType("int");

                    b.Property<DateTime>("ArrivalDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DepartureDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("first_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("last_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nationality")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("AirlineID");

                    b.ToTable("Reservation");
                });

            modelBuilder.Entity("Szasz_Botond_AirlineWeb.Models.ReservationCategory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<int>("ReservationID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("ReservationID");

                    b.ToTable("ReservationCategory");
                });

            modelBuilder.Entity("Szasz_Botond_AirlineWeb.Models.Reservation", b =>
                {
                    b.HasOne("Szasz_Botond_AirlineWeb.Models.Airline", "Airline")
                        .WithMany("Reservations")
                        .HasForeignKey("AirlineID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Airline");
                });

            modelBuilder.Entity("Szasz_Botond_AirlineWeb.Models.ReservationCategory", b =>
                {
                    b.HasOne("Szasz_Botond_AirlineWeb.Models.Category", "Category")
                        .WithMany("ReservationCategories")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Szasz_Botond_AirlineWeb.Models.Reservation", "Reservation")
                        .WithMany("ReservationCategories")
                        .HasForeignKey("ReservationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Reservation");
                });

            modelBuilder.Entity("Szasz_Botond_AirlineWeb.Models.Airline", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("Szasz_Botond_AirlineWeb.Models.Category", b =>
                {
                    b.Navigation("ReservationCategories");
                });

            modelBuilder.Entity("Szasz_Botond_AirlineWeb.Models.Reservation", b =>
                {
                    b.Navigation("ReservationCategories");
                });
#pragma warning restore 612, 618
        }
    }
}