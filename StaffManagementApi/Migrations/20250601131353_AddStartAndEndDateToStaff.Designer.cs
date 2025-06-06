﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StaffManagementApi.Data;

#nullable disable

namespace StaffManagementApi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250601131353_AddStartAndEndDateToStaff")]
    partial class AddStartAndEndDateToStaff
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.3");

            modelBuilder.Entity("StaffManagementApi.Entities.Staff", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AccountHolderName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ActiveSemester")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("BankAccountNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("BankBranch")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("BinusianId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("BinusianStatus")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateOnly>("DateOfBirth")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("EmergencyContact")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("EmergencyRelation")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateOnly?>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<string>("NIK")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NIM")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NPWP")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ParentGuardianName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ParentGuardianPhone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateOnly?>("StartDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("BinusianId")
                        .IsUnique();

                    b.ToTable("Staffs");
                });
#pragma warning restore 612, 618
        }
    }
}
