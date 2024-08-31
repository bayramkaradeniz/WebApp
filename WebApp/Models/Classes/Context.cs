using Microsoft.EntityFrameworkCore;
using System;

namespace WebApp.Models.Classes
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<BillItem> BillItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Cost> Costs { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Detail> Details { get; set; }
        public DbSet<Installment> Installments { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentCategory> PaymentCategories { get; set; }
        public DbSet<SaleTransaction> SaleTransactions { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<TechnicalCategory> TechnicalCategories { get; set; }
        public DbSet<TechnicalSupport> TechnicalSupports { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Kategoriler için başlangıç verilerini ekleme
            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = 1, DepartmentName = "Satış", State = true },
                new Department { DepartmentId = 2, DepartmentName = "Teknik Destek", State = true },
                new Department { DepartmentId = 3, DepartmentName = "Sekreter", State = true },
                new Department { DepartmentId = 4, DepartmentName = "Müdür", State = true }
            );


            // Kategoriler için başlangıç verilerini ekleme
            // Kategoriler
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Filtreli" },
                new Category { CategoryId = 2, CategoryName = "Filtresiz" }
            );

            // Teknik Kategoriler
            modelBuilder.Entity<TechnicalCategory>().HasData(
                new TechnicalCategory { TechnicalCategoryId = 1, TechnicalCategoryName = "Kurulum" },
                new TechnicalCategory { TechnicalCategoryId = 2, TechnicalCategoryName = "Bakım" },
                new TechnicalCategory { TechnicalCategoryId = 3, TechnicalCategoryName = "Onarım" }
            );

            // Ödeme Kategorileri
            modelBuilder.Entity<PaymentCategory>().HasData(
                new PaymentCategory { PaymentCategoryId = 1, PaymentCategoryName = "Cash" },
                new PaymentCategory { PaymentCategoryId = 2, PaymentCategoryName = "CreditCard" },
                new PaymentCategory { PaymentCategoryId = 3, PaymentCategoryName = "Installment" }
            );

            // Add Customers
            modelBuilder.Entity<Customer>().HasData(
                new Customer { CustomerId = 1, CustomerName = "John", CustomerSurname = "Doe", CustomerEmail = "john.doe@example.com", CustomerPhone = "1234567890", CustomerCity = "New York", CustomerDistrict = "Manhattan", CustomerAdress = "123 Broadway" },
                new Customer { CustomerId = 2, CustomerName = "Jane", CustomerSurname = "Smith", CustomerEmail = "jane.smith@example.com", CustomerPhone = "0987654321", CustomerCity = "Los Angeles", CustomerDistrict = "Hollywood", CustomerAdress = "456 Sunset Blvd" },
                new Customer { CustomerId = 3, CustomerName = "Alice", CustomerSurname = "Johnson", CustomerEmail = "alice.johnson@example.com", CustomerPhone = "2345678901", CustomerCity = "Chicago", CustomerDistrict = "Downtown", CustomerAdress = "789 Michigan Ave" },
                new Customer { CustomerId = 4, CustomerName = "Bob", CustomerSurname = "Williams", CustomerEmail = "bob.williams@example.com", CustomerPhone = "3456789012", CustomerCity = "Houston", CustomerDistrict = "Downtown", CustomerAdress = "101 Main St" },
                new Customer { CustomerId = 5, CustomerName = "Carol", CustomerSurname = "Davis", CustomerEmail = "carol.davis@example.com", CustomerPhone = "4567890123", CustomerCity = "Phoenix", CustomerDistrict = "Central", CustomerAdress = "202 Central Ave" }
            );

            // Add Products
            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 1, ProductName = "Apple Juice", Brand = "Fresh", Stock = 100, PurchasePrice = 1.50m, SalePrice = 2.00m, State = true, ProductModel = "AJ2024", ProductImage = "apple-juice.png", MaintenanceIntervalInMonths = 6, CategoryId = 1 },
                new Product { ProductId = 2, ProductName = "Banana Smoothie", Brand = "Tropical", Stock = 200, PurchasePrice = 2.00m, SalePrice = 2.50m, State = true, ProductModel = "BS2024", ProductImage = "banana-smoothie.png", MaintenanceIntervalInMonths = 6, CategoryId = 1 },
                new Product { ProductId = 3, ProductName = "Carrot Drink", Brand = "Veggie", Stock = 150, PurchasePrice = 1.75m, SalePrice = 2.25m, State = true, ProductModel = "CD2024", ProductImage = "carrot-drink.png", MaintenanceIntervalInMonths = 6, CategoryId = 1 },
                new Product { ProductId = 4, ProductName = "Dragon Fruit Juice", Brand = "Exotic", Stock = 50, PurchasePrice = 3.00m, SalePrice = 4.00m, State = true, ProductModel = "DFJ2024", ProductImage = "dragon-fruit-juice.png", MaintenanceIntervalInMonths = 6, CategoryId = 1 },
                new Product { ProductId = 5, ProductName = "Elderberry Wine", Brand = "Berry", Stock = 30, PurchasePrice = 5.00m, SalePrice = 7.00m, State = true, ProductModel = "EW2024", ProductImage = "elderberry-wine.png", MaintenanceIntervalInMonths = 12, CategoryId = 2 },
                new Product { ProductId = 6, ProductName = "Fig Syrup", Brand = "Sweet", Stock = 80, PurchasePrice = 2.50m, SalePrice = 3.00m, State = true, ProductModel = "FS2024", ProductImage = "fig-syrup.png", MaintenanceIntervalInMonths = 6, CategoryId = 2 },
                new Product { ProductId = 7, ProductName = "Grape Juice", Brand = "Vine", Stock = 120, PurchasePrice = 1.80m, SalePrice = 2.30m, State = true, ProductModel = "GJ2024", ProductImage = "grape-juice.png", MaintenanceIntervalInMonths = 6, CategoryId = 2 },
                new Product { ProductId = 8, ProductName = "Honey Lemonade", Brand = "SweetLife", Stock = 60, PurchasePrice = 2.20m, SalePrice = 2.70m, State = true, ProductModel = "HL2024", ProductImage = "honey-lemonade.png", MaintenanceIntervalInMonths = 6, CategoryId = 2 },
                new Product { ProductId = 9, ProductName = "Iced Tea", Brand = "CoolBrew", Stock = 90, PurchasePrice = 1.70m, SalePrice = 2.20m, State = true, ProductModel = "IT2024", ProductImage = "iced-tea.png", MaintenanceIntervalInMonths = 6, CategoryId = 2 },
                new Product { ProductId = 10, ProductName = "Juice Blend", Brand = "Fusion", Stock = 70, PurchasePrice = 2.00m, SalePrice = 2.60m, State = true, ProductModel = "JB2024", ProductImage = "juice-blend.png", MaintenanceIntervalInMonths = 6, CategoryId = 1 }
            );

            // Add Staff
            modelBuilder.Entity<Staff>().HasData(
                new Staff { StaffId = 1, StaffFullName = "Alice Brown", StaffUsername = "aliceb", StaffPassword = "password1", StaffImage = "alice-brown.png", DepartmentId = 1 },
                new Staff { StaffId = 2, StaffFullName = "Bob Green", StaffUsername = "bobg", StaffPassword = "password2", StaffImage = "bob-green.png", DepartmentId = 2 },
                new Staff { StaffId = 3, StaffFullName = "Charlie White", StaffUsername = "charliew", StaffPassword = "password3", StaffImage = "charlie-white.png", DepartmentId = 2 },
                new Staff { StaffId = 4, StaffFullName = "Diana Black", StaffUsername = "dianab", StaffPassword = "password4", StaffImage = "diana-black.png", DepartmentId = 3 },
                new Staff { StaffId = 5, StaffFullName = "Edward Blue", StaffUsername = "edwardb", StaffPassword = "password5", StaffImage = "edward-blue.png", DepartmentId = 1 }
            );
        }


    }
}
