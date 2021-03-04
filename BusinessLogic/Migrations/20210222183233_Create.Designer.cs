﻿// <auto-generated />
using System;
using BusinessLogic.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BusinessLogic.Migrations
{
    [DbContext(typeof(CarRentalContext))]
    [Migration("20210222183233_Create")]
    partial class Create
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.3");

            modelBuilder.Entity("BusinessLogic.Model.Booking", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CarID")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CustomerID")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("From")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("To")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("CarID");

                    b.HasIndex("CustomerID");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("BusinessLogic.Model.Car", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Manufacturer")
                        .HasColumnType("TEXT");

                    b.Property<string>("Model")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("BusinessLogic.Model.Customer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("BusinessLogic.Model.Booking", b =>
                {
                    b.HasOne("BusinessLogic.Model.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarID");

                    b.HasOne("BusinessLogic.Model.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerID");

                    b.Navigation("Car");

                    b.Navigation("Customer");
                });
#pragma warning restore 612, 618
        }
    }
}
