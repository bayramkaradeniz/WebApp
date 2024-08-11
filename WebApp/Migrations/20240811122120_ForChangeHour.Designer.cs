﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApp.Models.Classes;

#nullable disable

namespace WebApp.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20240811122120_ForChangeHour")]
    partial class ForChangeHour
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApp.Models.Classes.Admin", b =>
                {
                    b.Property<int>("AdminId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AdminId"));

                    b.Property<string>("Auth")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("AdminId");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("WebApp.Models.Classes.Bill", b =>
                {
                    b.Property<int>("BillId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BillId"));

                    b.Property<string>("BillSequenceNo")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("VarChar");

                    b.Property<string>("BillSerialNo")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("Char");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Hour")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("char");

                    b.Property<string>("Receiver")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("VarChar");

                    b.Property<string>("Sender")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("VarChar");

                    b.Property<string>("TaxOffice")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("VarChar");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("BillId");

                    b.ToTable("Bills");
                });

            modelBuilder.Entity("WebApp.Models.Classes.BillItem", b =>
                {
                    b.Property<int>("BillItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BillItemId"));

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("BillId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(130)
                        .HasColumnType("VarChar");

                    b.Property<decimal>("Sum")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("BillItemId");

                    b.HasIndex("BillId");

                    b.ToTable("BillItems");
                });

            modelBuilder.Entity("WebApp.Models.Classes.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("VarChar");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("WebApp.Models.Classes.Cost", b =>
                {
                    b.Property<int>("CostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CostId"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VarChar");

                    b.HasKey("CostId");

                    b.ToTable("Costs");
                });

            modelBuilder.Entity("WebApp.Models.Classes.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"));

                    b.Property<string>("CustomerCity")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("VarChar");

                    b.Property<string>("CustomerEmail")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("VarChar");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("VarChar");

                    b.Property<string>("CustomerSurname")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("VarChar");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("WebApp.Models.Classes.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepartmentId"));

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("VarChar");

                    b.Property<bool>("State")
                        .HasColumnType("bit");

                    b.HasKey("DepartmentId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("WebApp.Models.Classes.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("MaintenanceIntervalInMonths")
                        .HasColumnType("int");

                    b.Property<string>("ProductModel")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("VarChar");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("VarChar");

                    b.Property<decimal>("PurchasePrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("SalePrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("State")
                        .HasColumnType("bit");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("WebApp.Models.Classes.SaleTransaction", b =>
                {
                    b.Property<int>("SaleTransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SaleTransactionId"));

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("PaymentStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("StaffId")
                        .HasColumnType("int");

                    b.Property<bool>("State")
                        .HasColumnType("bit");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("SaleTransactionId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ProductId");

                    b.HasIndex("StaffId");

                    b.ToTable("SaleTransactions");
                });

            modelBuilder.Entity("WebApp.Models.Classes.Staff", b =>
                {
                    b.Property<int>("StaffId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StaffId"));

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("StaffFullName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("VarChar");

                    b.Property<string>("StaffImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StaffPassword")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("VarChar");

                    b.Property<string>("StaffUsername")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("VarChar");

                    b.HasKey("StaffId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Staffs");
                });

            modelBuilder.Entity("WebApp.Models.Classes.BillItem", b =>
                {
                    b.HasOne("WebApp.Models.Classes.Bill", "Bill")
                        .WithMany("BillItems")
                        .HasForeignKey("BillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bill");
                });

            modelBuilder.Entity("WebApp.Models.Classes.Product", b =>
                {
                    b.HasOne("WebApp.Models.Classes.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("WebApp.Models.Classes.SaleTransaction", b =>
                {
                    b.HasOne("WebApp.Models.Classes.Customer", "Customer")
                        .WithMany("SaleTransactions")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApp.Models.Classes.Product", "Product")
                        .WithMany("SaleTransactions")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApp.Models.Classes.Staff", "Staff")
                        .WithMany("SaleTransactions")
                        .HasForeignKey("StaffId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Product");

                    b.Navigation("Staff");
                });

            modelBuilder.Entity("WebApp.Models.Classes.Staff", b =>
                {
                    b.HasOne("WebApp.Models.Classes.Department", "Department")
                        .WithMany("Staffs")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("WebApp.Models.Classes.Bill", b =>
                {
                    b.Navigation("BillItems");
                });

            modelBuilder.Entity("WebApp.Models.Classes.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("WebApp.Models.Classes.Customer", b =>
                {
                    b.Navigation("SaleTransactions");
                });

            modelBuilder.Entity("WebApp.Models.Classes.Department", b =>
                {
                    b.Navigation("Staffs");
                });

            modelBuilder.Entity("WebApp.Models.Classes.Product", b =>
                {
                    b.Navigation("SaleTransactions");
                });

            modelBuilder.Entity("WebApp.Models.Classes.Staff", b =>
                {
                    b.Navigation("SaleTransactions");
                });
#pragma warning restore 612, 618
        }
    }
}
