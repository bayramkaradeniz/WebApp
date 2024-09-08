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
        public DbSet<CargoDetail> CargoDetails { get; set; }
        public DbSet<CargoTracking> CargoTrackings { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Cost> Costs { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Detail> Details { get; set; }
        public DbSet<Fault> Faults { get; set; }
        public DbSet<Installment> Installments { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentCategory> PaymentCategories { get; set; }
        public DbSet<SaleTransaction> SaleTransactions { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<TechnicalCategory> TechnicalCategories { get; set; }
        public DbSet<TechnicalSupport> TechnicalSupports { get; set; }
        public DbSet<Todo> Todos { get; set; }


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
                new Customer { CustomerId = 1, CustomerName = "Ahmet", CustomerSurname = "Yılmaz", CustomerEmail = "ahmet.yilmaz@example.com", CustomerPhone = "5551234567", CustomerCity = "İstanbul", CustomerDistrict = "Beşiktaş", CustomerAdress = "Kuştepe Mah. 1. Sok. No:5" },
                new Customer { CustomerId = 2, CustomerName = "Elif", CustomerSurname = "Kaya", CustomerEmail = "elif.kaya@example.com", CustomerPhone = "5552345678", CustomerCity = "Ankara", CustomerDistrict = "Çankaya", CustomerAdress = "Kocatepe Mah. 2. Cad. No:10" },
                new Customer { CustomerId = 3, CustomerName = "Mehmet", CustomerSurname = "Öztürk", CustomerEmail = "mehmet.ozturk@example.com", CustomerPhone = "5553456789", CustomerCity = "İzmir", CustomerDistrict = "Konak", CustomerAdress = "Alsancak Mah. 3. Sok. No:20" },
                new Customer { CustomerId = 4, CustomerName = "Ayşe", CustomerSurname = "Demir", CustomerEmail = "ayse.demir@example.com", CustomerPhone = "5554567890", CustomerCity = "Bursa", CustomerDistrict = "Osmangazi", CustomerAdress = "Bahripaşa Mah. 4. Cad. No:15" },
                new Customer { CustomerId = 5, CustomerName = "Ali", CustomerSurname = "Kara", CustomerEmail = "ali.kara@example.com", CustomerPhone = "5555678901", CustomerCity = "Antalya", CustomerDistrict = "Muratpaşa", CustomerAdress = "Yukarı Karaman Mah. 5. Sok. No:25" }
            );


            // Add Categories
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Arıtma Cihazları" },
                new Category { CategoryId = 2, CategoryName = "Filtreler" },
                new Category { CategoryId = 3, CategoryName = "Kimyasal Ürünler" },
                new Category { CategoryId = 4, CategoryName = "Aksesuarlar" }
            );

            // Add Products
            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 1, ProductName = "Reverse Osmosis Arıtma Cihazı", Brand = "PureWater", Stock = 50, PurchasePrice = 5000m, SalePrice = 7500m, State = true, ProductModel = "RO2024", ProductImage = "reverse-osmosis.png", MaintenanceIntervalInMonths = 12, CategoryId = 1 },
                new Product { ProductId = 2, ProductName = "UV Arıtma Cihazı", Brand = "CleanTech", Stock = 30, PurchasePrice = 4000m, SalePrice = 6000m, State = true, ProductModel = "UV2024", ProductImage = "uv-purifier.png", MaintenanceIntervalInMonths = 12, CategoryId = 1 },
                new Product { ProductId = 3, ProductName = "Aktif Karbon Filtre", Brand = "FilterPro", Stock = 100, PurchasePrice = 150m, SalePrice = 250m, State = true, ProductModel = "ACF2024", ProductImage = "carbon-filter.png", MaintenanceIntervalInMonths = 6, CategoryId = 2 },
                new Product { ProductId = 4, ProductName = "Sediment Filtre", Brand = "WaterSafe", Stock = 80, PurchasePrice = 100m, SalePrice = 200m, State = true, ProductModel = "SF2024", ProductImage = "sediment-filter.png", MaintenanceIntervalInMonths = 6, CategoryId = 2 },
                new Product { ProductId = 5, ProductName = "Mineral Ekleme Kartuşu", Brand = "MineralPlus", Stock = 40, PurchasePrice = 200m, SalePrice = 300m, State = true, ProductModel = "MC2024", ProductImage = "mineral-cartridge.png", MaintenanceIntervalInMonths = 6, CategoryId = 3 },
                new Product { ProductId = 6, ProductName = "Ozon Jeneratörü", Brand = "OzoneMax", Stock = 25, PurchasePrice = 700m, SalePrice = 1000m, State = true, ProductModel = "OZ2024", ProductImage = "ozone-generator.png", MaintenanceIntervalInMonths = 12, CategoryId = 3 },
                new Product { ProductId = 7, ProductName = "Üç Aşamalı Filtre Seti", Brand = "TripleGuard", Stock = 60, PurchasePrice = 350m, SalePrice = 500m, State = true, ProductModel = "TS2024", ProductImage = "triple-filter-set.png", MaintenanceIntervalInMonths = 6, CategoryId = 2 },
                new Product { ProductId = 8, ProductName = "Tuzlu Su Arıtma Kartuşu", Brand = "SaltClear", Stock = 45, PurchasePrice = 250m, SalePrice = 350m, State = true, ProductModel = "SC2024", ProductImage = "salt-water-cartridge.png", MaintenanceIntervalInMonths = 6, CategoryId = 2 },
                new Product { ProductId = 9, ProductName = "Filtre Temizlik Kiti", Brand = "CleanKit", Stock = 75, PurchasePrice = 80m, SalePrice = 120m, State = true, ProductModel = "FK2024", ProductImage = "filter-cleaning-kit.png", MaintenanceIntervalInMonths = 6, CategoryId = 4 },
                new Product { ProductId = 10, ProductName = "Yedek Parça Seti", Brand = "PartsPlus", Stock = 35, PurchasePrice = 150m, SalePrice = 200m, State = true, ProductModel = "PS2024", ProductImage = "spare-parts-set.png", MaintenanceIntervalInMonths = 12, CategoryId = 4 }
            );

            // Add Staff
            modelBuilder.Entity<Staff>().HasData(
                new Staff { StaffId = 1, StaffFullName = "Seda Çelik", StaffMail = "sedac", StaffPassword = "password1", StaffImage = "seda-celik.png", DepartmentId = 1 },
                new Staff { StaffId = 2, StaffFullName = "Emre Yurt", StaffMail = "emrey", StaffPassword = "password2", StaffImage = "emre-yurt.png", DepartmentId = 2 },
                new Staff { StaffId = 3, StaffFullName = "Zeynep Akman", StaffMail = "zeynepa", StaffPassword = "password3", StaffImage = "zeynep-akman.png", DepartmentId = 2 },
                new Staff { StaffId = 4, StaffFullName = "Caner Erol", StaffMail = "canere", StaffPassword = "password4", StaffImage = "caner-erol.png", DepartmentId = 3 },
                new Staff { StaffId = 5, StaffFullName = "Merve Arslan", StaffMail = "mervea", StaffPassword = "password5", StaffImage = "merve-arslan.png", DepartmentId = 1 }
            );

        }


    }
}
