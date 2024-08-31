﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApp.Models.Classes;

#nullable disable

namespace WebApp.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CategoryName = "Filtreli"
                        },
                        new
                        {
                            CategoryId = 2,
                            CategoryName = "Filtresiz"
                        });
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

                    b.Property<string>("CustomerAdress")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("VarChar");

                    b.Property<string>("CustomerCity")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("VarChar");

                    b.Property<string>("CustomerDistrict")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("VarChar");

                    b.Property<string>("CustomerEmail")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("VarChar");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("VarChar");

                    b.Property<string>("CustomerPhone")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("VarChar");

                    b.Property<string>("CustomerSurname")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("VarChar");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            CustomerId = 1,
                            CustomerAdress = "123 Broadway",
                            CustomerCity = "New York",
                            CustomerDistrict = "Manhattan",
                            CustomerEmail = "john.doe@example.com",
                            CustomerName = "John",
                            CustomerPhone = "1234567890",
                            CustomerSurname = "Doe"
                        },
                        new
                        {
                            CustomerId = 2,
                            CustomerAdress = "456 Sunset Blvd",
                            CustomerCity = "Los Angeles",
                            CustomerDistrict = "Hollywood",
                            CustomerEmail = "jane.smith@example.com",
                            CustomerName = "Jane",
                            CustomerPhone = "0987654321",
                            CustomerSurname = "Smith"
                        },
                        new
                        {
                            CustomerId = 3,
                            CustomerAdress = "789 Michigan Ave",
                            CustomerCity = "Chicago",
                            CustomerDistrict = "Downtown",
                            CustomerEmail = "alice.johnson@example.com",
                            CustomerName = "Alice",
                            CustomerPhone = "2345678901",
                            CustomerSurname = "Johnson"
                        },
                        new
                        {
                            CustomerId = 4,
                            CustomerAdress = "101 Main St",
                            CustomerCity = "Houston",
                            CustomerDistrict = "Downtown",
                            CustomerEmail = "bob.williams@example.com",
                            CustomerName = "Bob",
                            CustomerPhone = "3456789012",
                            CustomerSurname = "Williams"
                        },
                        new
                        {
                            CustomerId = 5,
                            CustomerAdress = "202 Central Ave",
                            CustomerCity = "Phoenix",
                            CustomerDistrict = "Central",
                            CustomerEmail = "carol.davis@example.com",
                            CustomerName = "Carol",
                            CustomerPhone = "4567890123",
                            CustomerSurname = "Davis"
                        });
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

                    b.HasData(
                        new
                        {
                            DepartmentId = 1,
                            DepartmentName = "Satış",
                            State = true
                        },
                        new
                        {
                            DepartmentId = 2,
                            DepartmentName = "Teknik Destek",
                            State = true
                        },
                        new
                        {
                            DepartmentId = 3,
                            DepartmentName = "Sekreter",
                            State = true
                        },
                        new
                        {
                            DepartmentId = 4,
                            DepartmentName = "Müdür",
                            State = true
                        });
                });

            modelBuilder.Entity("WebApp.Models.Classes.Detail", b =>
                {
                    b.Property<int>("DetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DetailId"));

                    b.Property<string>("DProductDescription")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("VarChar");

                    b.Property<string>("DProductName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("VarChar");

                    b.HasKey("DetailId");

                    b.ToTable("Details");
                });

            modelBuilder.Entity("WebApp.Models.Classes.Installment", b =>
                {
                    b.Property<int>("InstallmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InstallmentId"));

                    b.Property<decimal>("InstallmentAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("InstallmentDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("InstallmentIsPaid")
                        .HasColumnType("bit");

                    b.Property<int>("InstallmentPaymentType")
                        .HasColumnType("int");

                    b.Property<int>("PaymentId")
                        .HasColumnType("int");

                    b.HasKey("InstallmentId");

                    b.HasIndex("PaymentId");

                    b.ToTable("Installments");
                });

            modelBuilder.Entity("WebApp.Models.Classes.Payment", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaymentId"));

                    b.Property<decimal?>("DownPayment")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("FirstInstallmentDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("InstallmentCount")
                        .HasColumnType("int");

                    b.Property<int?>("InstallmentPeriodMonths")
                        .HasColumnType("int");

                    b.Property<bool>("IsPaid")
                        .HasColumnType("bit");

                    b.Property<decimal?>("PaidPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("PaymentCategoryId")
                        .HasColumnType("int");

                    b.Property<int?>("PaymentTypeForDownPayment")
                        .HasColumnType("int");

                    b.Property<decimal?>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("PaymentId");

                    b.HasIndex("PaymentCategoryId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("WebApp.Models.Classes.PaymentCategory", b =>
                {
                    b.Property<int>("PaymentCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaymentCategoryId"));

                    b.Property<string>("PaymentCategoryName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("VarChar");

                    b.HasKey("PaymentCategoryId");

                    b.ToTable("PaymentCategories");

                    b.HasData(
                        new
                        {
                            PaymentCategoryId = 1,
                            PaymentCategoryName = "Cash"
                        },
                        new
                        {
                            PaymentCategoryId = 2,
                            PaymentCategoryName = "CreditCard"
                        },
                        new
                        {
                            PaymentCategoryId = 3,
                            PaymentCategoryName = "Installment"
                        });
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

                    b.Property<string>("ProductImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            Brand = "Fresh",
                            CategoryId = 1,
                            MaintenanceIntervalInMonths = 6,
                            ProductImage = "apple-juice.png",
                            ProductModel = "AJ2024",
                            ProductName = "Apple Juice",
                            PurchasePrice = 1.50m,
                            SalePrice = 2.00m,
                            State = true,
                            Stock = 100
                        },
                        new
                        {
                            ProductId = 2,
                            Brand = "Tropical",
                            CategoryId = 1,
                            MaintenanceIntervalInMonths = 6,
                            ProductImage = "banana-smoothie.png",
                            ProductModel = "BS2024",
                            ProductName = "Banana Smoothie",
                            PurchasePrice = 2.00m,
                            SalePrice = 2.50m,
                            State = true,
                            Stock = 200
                        },
                        new
                        {
                            ProductId = 3,
                            Brand = "Veggie",
                            CategoryId = 1,
                            MaintenanceIntervalInMonths = 6,
                            ProductImage = "carrot-drink.png",
                            ProductModel = "CD2024",
                            ProductName = "Carrot Drink",
                            PurchasePrice = 1.75m,
                            SalePrice = 2.25m,
                            State = true,
                            Stock = 150
                        },
                        new
                        {
                            ProductId = 4,
                            Brand = "Exotic",
                            CategoryId = 1,
                            MaintenanceIntervalInMonths = 6,
                            ProductImage = "dragon-fruit-juice.png",
                            ProductModel = "DFJ2024",
                            ProductName = "Dragon Fruit Juice",
                            PurchasePrice = 3.00m,
                            SalePrice = 4.00m,
                            State = true,
                            Stock = 50
                        },
                        new
                        {
                            ProductId = 5,
                            Brand = "Berry",
                            CategoryId = 2,
                            MaintenanceIntervalInMonths = 12,
                            ProductImage = "elderberry-wine.png",
                            ProductModel = "EW2024",
                            ProductName = "Elderberry Wine",
                            PurchasePrice = 5.00m,
                            SalePrice = 7.00m,
                            State = true,
                            Stock = 30
                        },
                        new
                        {
                            ProductId = 6,
                            Brand = "Sweet",
                            CategoryId = 2,
                            MaintenanceIntervalInMonths = 6,
                            ProductImage = "fig-syrup.png",
                            ProductModel = "FS2024",
                            ProductName = "Fig Syrup",
                            PurchasePrice = 2.50m,
                            SalePrice = 3.00m,
                            State = true,
                            Stock = 80
                        },
                        new
                        {
                            ProductId = 7,
                            Brand = "Vine",
                            CategoryId = 2,
                            MaintenanceIntervalInMonths = 6,
                            ProductImage = "grape-juice.png",
                            ProductModel = "GJ2024",
                            ProductName = "Grape Juice",
                            PurchasePrice = 1.80m,
                            SalePrice = 2.30m,
                            State = true,
                            Stock = 120
                        },
                        new
                        {
                            ProductId = 8,
                            Brand = "SweetLife",
                            CategoryId = 2,
                            MaintenanceIntervalInMonths = 6,
                            ProductImage = "honey-lemonade.png",
                            ProductModel = "HL2024",
                            ProductName = "Honey Lemonade",
                            PurchasePrice = 2.20m,
                            SalePrice = 2.70m,
                            State = true,
                            Stock = 60
                        },
                        new
                        {
                            ProductId = 9,
                            Brand = "CoolBrew",
                            CategoryId = 2,
                            MaintenanceIntervalInMonths = 6,
                            ProductImage = "iced-tea.png",
                            ProductModel = "IT2024",
                            ProductName = "Iced Tea",
                            PurchasePrice = 1.70m,
                            SalePrice = 2.20m,
                            State = true,
                            Stock = 90
                        },
                        new
                        {
                            ProductId = 10,
                            Brand = "Fusion",
                            CategoryId = 1,
                            MaintenanceIntervalInMonths = 6,
                            ProductImage = "juice-blend.png",
                            ProductModel = "JB2024",
                            ProductName = "Juice Blend",
                            PurchasePrice = 2.00m,
                            SalePrice = 2.60m,
                            State = true,
                            Stock = 70
                        });
                });

            modelBuilder.Entity("WebApp.Models.Classes.SaleTransaction", b =>
                {
                    b.Property<int>("SaleTransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SaleTransactionId"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("InstallationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PaymentId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("StaffId")
                        .HasColumnType("int");

                    b.Property<bool>("State")
                        .HasColumnType("bit");

                    b.Property<int>("StockAmount")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("SaleTransactionId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("PaymentId")
                        .IsUnique();

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

                    b.HasData(
                        new
                        {
                            StaffId = 1,
                            DepartmentId = 1,
                            StaffFullName = "Alice Brown",
                            StaffImage = "alice-brown.png",
                            StaffPassword = "password1",
                            StaffUsername = "aliceb"
                        },
                        new
                        {
                            StaffId = 2,
                            DepartmentId = 2,
                            StaffFullName = "Bob Green",
                            StaffImage = "bob-green.png",
                            StaffPassword = "password2",
                            StaffUsername = "bobg"
                        },
                        new
                        {
                            StaffId = 3,
                            DepartmentId = 2,
                            StaffFullName = "Charlie White",
                            StaffImage = "charlie-white.png",
                            StaffPassword = "password3",
                            StaffUsername = "charliew"
                        },
                        new
                        {
                            StaffId = 4,
                            DepartmentId = 3,
                            StaffFullName = "Diana Black",
                            StaffImage = "diana-black.png",
                            StaffPassword = "password4",
                            StaffUsername = "dianab"
                        },
                        new
                        {
                            StaffId = 5,
                            DepartmentId = 1,
                            StaffFullName = "Edward Blue",
                            StaffImage = "edward-blue.png",
                            StaffPassword = "password5",
                            StaffUsername = "edwardb"
                        });
                });

            modelBuilder.Entity("WebApp.Models.Classes.TechnicalCategory", b =>
                {
                    b.Property<int>("TechnicalCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TechnicalCategoryId"));

                    b.Property<string>("TechnicalCategoryName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("VarChar");

                    b.HasKey("TechnicalCategoryId");

                    b.ToTable("TechnicalCategories");

                    b.HasData(
                        new
                        {
                            TechnicalCategoryId = 1,
                            TechnicalCategoryName = "Kurulum"
                        },
                        new
                        {
                            TechnicalCategoryId = 2,
                            TechnicalCategoryName = "Bakım"
                        },
                        new
                        {
                            TechnicalCategoryId = 3,
                            TechnicalCategoryName = "Onarım"
                        });
                });

            modelBuilder.Entity("WebApp.Models.Classes.TechnicalSupport", b =>
                {
                    b.Property<int>("TechnicalSupportId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TechnicalSupportId"));

                    b.Property<DateTime?>("CompletionDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("VarChar");

                    b.Property<bool?>("IsComplete")
                        .HasColumnType("bit");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<int?>("StaffId")
                        .HasColumnType("int");

                    b.Property<int>("TechnicalCategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("TransactionDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("TransactionFee")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("TechnicalSupportId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ProductId");

                    b.HasIndex("StaffId");

                    b.HasIndex("TechnicalCategoryId");

                    b.ToTable("TechnicalSupports");
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

            modelBuilder.Entity("WebApp.Models.Classes.Installment", b =>
                {
                    b.HasOne("WebApp.Models.Classes.Payment", "Payment")
                        .WithMany("Installments")
                        .HasForeignKey("PaymentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Payment");
                });

            modelBuilder.Entity("WebApp.Models.Classes.Payment", b =>
                {
                    b.HasOne("WebApp.Models.Classes.PaymentCategory", "PaymentCategory")
                        .WithMany("Payments")
                        .HasForeignKey("PaymentCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PaymentCategory");
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

                    b.HasOne("WebApp.Models.Classes.Payment", "Payment")
                        .WithOne("SaleTransaction")
                        .HasForeignKey("WebApp.Models.Classes.SaleTransaction", "PaymentId")
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

                    b.Navigation("Payment");

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

            modelBuilder.Entity("WebApp.Models.Classes.TechnicalSupport", b =>
                {
                    b.HasOne("WebApp.Models.Classes.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");

                    b.HasOne("WebApp.Models.Classes.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");

                    b.HasOne("WebApp.Models.Classes.Staff", "Staff")
                        .WithMany()
                        .HasForeignKey("StaffId");

                    b.HasOne("WebApp.Models.Classes.TechnicalCategory", "TechnicalCategory")
                        .WithMany("TechnicalSupports")
                        .HasForeignKey("TechnicalCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Product");

                    b.Navigation("Staff");

                    b.Navigation("TechnicalCategory");
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

            modelBuilder.Entity("WebApp.Models.Classes.Payment", b =>
                {
                    b.Navigation("Installments");

                    b.Navigation("SaleTransaction")
                        .IsRequired();
                });

            modelBuilder.Entity("WebApp.Models.Classes.PaymentCategory", b =>
                {
                    b.Navigation("Payments");
                });

            modelBuilder.Entity("WebApp.Models.Classes.Product", b =>
                {
                    b.Navigation("SaleTransactions");
                });

            modelBuilder.Entity("WebApp.Models.Classes.Staff", b =>
                {
                    b.Navigation("SaleTransactions");
                });

            modelBuilder.Entity("WebApp.Models.Classes.TechnicalCategory", b =>
                {
                    b.Navigation("TechnicalSupports");
                });
#pragma warning restore 612, 618
        }
    }
}
