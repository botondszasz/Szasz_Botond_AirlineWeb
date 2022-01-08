﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Szasz_Botond_AirlineWeb.Data;

namespace Szasz_Botond_AirlineWeb.Migrations
{
    [DbContext(typeof(Szasz_Botond_AirlineWebContext))]
    partial class Szasz_Botond_AirlineWebContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("Szasz_Botond_AirlineWeb.Models.Destination", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DestinationName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Destination");
                });

            modelBuilder.Entity("Szasz_Botond_AirlineWeb.Models.Detail", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DetailName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Detail");
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

                    b.Property<int>("DestinationID")
                        .HasColumnType("int");

                    b.Property<string>("first_name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("last_name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("nationality")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("ID");

                    b.HasIndex("AirlineID");

                    b.HasIndex("DestinationID");

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

            modelBuilder.Entity("Szasz_Botond_AirlineWeb.Models.ReservationDetail", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DetailID")
                        .HasColumnType("int");

                    b.Property<int>("ReservationID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("DetailID");

                    b.HasIndex("ReservationID");

                    b.ToTable("ReservationDetail");
                });

            modelBuilder.Entity("Szasz_Botond_AirlineWeb.Models.Reservation", b =>
                {
                    b.HasOne("Szasz_Botond_AirlineWeb.Models.Airline", "Airline")
                        .WithMany("Reservations")
                        .HasForeignKey("AirlineID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Szasz_Botond_AirlineWeb.Models.Destination", "Destination")
                        .WithMany("Reservations")
                        .HasForeignKey("DestinationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Airline");

                    b.Navigation("Destination");
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

            modelBuilder.Entity("Szasz_Botond_AirlineWeb.Models.ReservationDetail", b =>
                {
                    b.HasOne("Szasz_Botond_AirlineWeb.Models.Detail", "Detail")
                        .WithMany("ReservationDetails")
                        .HasForeignKey("DetailID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Szasz_Botond_AirlineWeb.Models.Reservation", "Reservation")
                        .WithMany("ReservationDetails")
                        .HasForeignKey("ReservationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Detail");

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

            modelBuilder.Entity("Szasz_Botond_AirlineWeb.Models.Destination", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("Szasz_Botond_AirlineWeb.Models.Detail", b =>
                {
                    b.Navigation("ReservationDetails");
                });

            modelBuilder.Entity("Szasz_Botond_AirlineWeb.Models.Reservation", b =>
                {
                    b.Navigation("ReservationCategories");

                    b.Navigation("ReservationDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
