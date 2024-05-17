﻿// <auto-generated />
using System;
using EmployeeRequestTrackerAPI.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EmployeeRequestTrackerAPI.Migrations
{
    [DbContext(typeof(RequestTrackerContext))]
    [Migration("20240517114931_requestmodeladdedwithfKey")]
    partial class requestmodeladdedwithfKey
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.28")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EmployeeRequestTrackerAPI.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 101,
                            DateOfBirth = new DateTime(2000, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Image = "",
                            Name = "Ramu",
                            Phone = "9876543321"
                        },
                        new
                        {
                            Id = 102,
                            DateOfBirth = new DateTime(2002, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Image = "",
                            Name = "Somu",
                            Phone = "9988776655"
                        });
                });

            modelBuilder.Entity("EmployeeRequestTrackerAPI.Models.Request", b =>
                {
                    b.Property<int>("RequestNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RequestNumber"), 1L, 1);

                    b.Property<DateTime?>("ClosedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("RequestClosedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("RequestDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("RequestMessage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RequestRaisedBy")
                        .HasColumnType("int");

                    b.Property<string>("RequestStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RequestNumber");

                    b.HasIndex("RequestClosedBy");

                    b.HasIndex("RequestRaisedBy");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("EmployeeRequestTrackerAPI.Models.User", b =>
                {
                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<byte[]>("Password")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordHashKey")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("EmployeeRequestTrackerAPI.Models.Request", b =>
                {
                    b.HasOne("EmployeeRequestTrackerAPI.Models.Employee", "RequestClosedByEmployee")
                        .WithMany("RequestsClosed")
                        .HasForeignKey("RequestClosedBy")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("EmployeeRequestTrackerAPI.Models.Employee", "RaisedByEmployee")
                        .WithMany("RequestsRaised")
                        .HasForeignKey("RequestRaisedBy")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("RaisedByEmployee");

                    b.Navigation("RequestClosedByEmployee");
                });

            modelBuilder.Entity("EmployeeRequestTrackerAPI.Models.User", b =>
                {
                    b.HasOne("EmployeeRequestTrackerAPI.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("EmployeeRequestTrackerAPI.Models.Employee", b =>
                {
                    b.Navigation("RequestsClosed");

                    b.Navigation("RequestsRaised");
                });
#pragma warning restore 612, 618
        }
    }
}
