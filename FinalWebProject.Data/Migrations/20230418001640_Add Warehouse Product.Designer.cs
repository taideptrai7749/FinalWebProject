﻿// <auto-generated />
using System;
using FinalWebProject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FinalWebProject.Data.Migrations
{
    [DbContext(typeof(FinalDbContext))]
    [Migration("20230418001640_Add Warehouse Product")]
    partial class AddWarehouseProduct
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FinalWebProject.Data.Accountant", b =>
                {
                    b.Property<int>("AccountantID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AccountantID"));

                    b.Property<string>("AcccountantName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AccountantEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AccountantPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WarehouseID")
                        .HasColumnType("int");

                    b.HasKey("AccountantID");

                    b.HasIndex("WarehouseID");

                    b.ToTable("Accountant");
                });

            modelBuilder.Entity("FinalWebProject.Data.Manufacturer", b =>
                {
                    b.Property<int>("ManufacturerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ManufacturerId"));

                    b.Property<string>("ManufacturerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ManufacturerYear")
                        .HasColumnType("int");

                    b.HasKey("ManufacturerId");

                    b.ToTable("Manufacturer");
                });

            modelBuilder.Entity("FinalWebProject.Data.Phone", b =>
                {
                    b.Property<int>("PhoneId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PhoneId"));

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ManufacturerId")
                        .HasColumnType("int");

                    b.Property<string>("PhoneDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhoneYear")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("PhoneId");

                    b.HasIndex("ManufacturerId");

                    b.ToTable("Phone");
                });

            modelBuilder.Entity("FinalWebProject.Data.Receipt", b =>
                {
                    b.Property<int>("ReceiptId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReceiptId"));

                    b.Property<int>("AccountantId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<int>("TotalPrice")
                        .HasColumnType("int");

                    b.HasKey("ReceiptId");

                    b.HasIndex("AccountantId");

                    b.ToTable("Receipt");
                });

            modelBuilder.Entity("FinalWebProject.Data.ReceiptDetails", b =>
                {
                    b.Property<int>("ReceiptId")
                        .HasColumnType("int");

                    b.Property<int>("PhoneId")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("ReceiptId", "PhoneId");

                    b.HasIndex("PhoneId");

                    b.ToTable("ReceiptDetails");
                });

            modelBuilder.Entity("FinalWebProject.Data.Warehouse", b =>
                {
                    b.Property<int>("WarehouseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WarehouseId"));

                    b.Property<string>("WarehouseLocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WarehouseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("WarehouseId");

                    b.ToTable("Warehouse");
                });

            modelBuilder.Entity("FinalWebProject.Data.WarehouseProducts", b =>
                {
                    b.Property<int>("WarehouseId")
                        .HasColumnType("int");

                    b.Property<int>("PhoneId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("WarehouseId", "PhoneId");

                    b.HasIndex("PhoneId");

                    b.ToTable("WarehouseProducts");
                });

            modelBuilder.Entity("FinalWebProject.Data.Accountant", b =>
                {
                    b.HasOne("FinalWebProject.Data.Warehouse", "Warehouse")
                        .WithMany("Accountants")
                        .HasForeignKey("WarehouseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Warehouse");
                });

            modelBuilder.Entity("FinalWebProject.Data.Phone", b =>
                {
                    b.HasOne("FinalWebProject.Data.Manufacturer", "Manufacturer")
                        .WithMany("Phones")
                        .HasForeignKey("ManufacturerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Manufacturer");
                });

            modelBuilder.Entity("FinalWebProject.Data.Receipt", b =>
                {
                    b.HasOne("FinalWebProject.Data.Accountant", "Accountant")
                        .WithMany("Receipts")
                        .HasForeignKey("AccountantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Accountant");
                });

            modelBuilder.Entity("FinalWebProject.Data.ReceiptDetails", b =>
                {
                    b.HasOne("FinalWebProject.Data.Phone", "Phone")
                        .WithMany("ReceiptDetails")
                        .HasForeignKey("PhoneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FinalWebProject.Data.Receipt", "Receipt")
                        .WithMany("ReceiptDetails")
                        .HasForeignKey("ReceiptId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Phone");

                    b.Navigation("Receipt");
                });

            modelBuilder.Entity("FinalWebProject.Data.WarehouseProducts", b =>
                {
                    b.HasOne("FinalWebProject.Data.Phone", "Phone")
                        .WithMany("WarehouseProducts")
                        .HasForeignKey("PhoneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FinalWebProject.Data.Warehouse", "Warehouse")
                        .WithMany("WarehouseProducts")
                        .HasForeignKey("WarehouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Phone");

                    b.Navigation("Warehouse");
                });

            modelBuilder.Entity("FinalWebProject.Data.Accountant", b =>
                {
                    b.Navigation("Receipts");
                });

            modelBuilder.Entity("FinalWebProject.Data.Manufacturer", b =>
                {
                    b.Navigation("Phones");
                });

            modelBuilder.Entity("FinalWebProject.Data.Phone", b =>
                {
                    b.Navigation("ReceiptDetails");

                    b.Navigation("WarehouseProducts");
                });

            modelBuilder.Entity("FinalWebProject.Data.Receipt", b =>
                {
                    b.Navigation("ReceiptDetails");
                });

            modelBuilder.Entity("FinalWebProject.Data.Warehouse", b =>
                {
                    b.Navigation("Accountants");

                    b.Navigation("WarehouseProducts");
                });
#pragma warning restore 612, 618
        }
    }
}
