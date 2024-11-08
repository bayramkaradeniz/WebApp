using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApp.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    AdminId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Auth = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.AdminId);
                });

            migrationBuilder.CreateTable(
                name: "Bills",
                columns: table => new
                {
                    BillId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BillSequenceNo = table.Column<string>(type: "VarChar(15)", maxLength: 15, nullable: false),
                    BillSerialNo = table.Column<string>(type: "Char(1)", maxLength: 1, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hour = table.Column<string>(type: "char(5)", maxLength: 5, nullable: false),
                    TaxOffice = table.Column<string>(type: "VarChar(15)", maxLength: 15, nullable: false),
                    Sender = table.Column<string>(type: "VarChar(30)", maxLength: 30, nullable: false),
                    Receiver = table.Column<string>(type: "VarChar(30)", maxLength: 30, nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bills", x => x.BillId);
                });

            migrationBuilder.CreateTable(
                name: "CargoDetails",
                columns: table => new
                {
                    CargoDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "VarChar(300)", maxLength: 300, nullable: false),
                    TrackingCode = table.Column<string>(type: "VarChar(10)", maxLength: 10, nullable: false),
                    Staff = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Owner = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CargoDetails", x => x.CargoDetailId);
                });

            migrationBuilder.CreateTable(
                name: "CargoTrackings",
                columns: table => new
                {
                    CargoTrackingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrackingCode = table.Column<string>(type: "VarChar(10)", maxLength: 10, nullable: false),
                    TrackingDescription = table.Column<string>(type: "VarChar(300)", maxLength: 300, nullable: false),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CargoTrackings", x => x.CargoTrackingId);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "VarChar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Costs",
                columns: table => new
                {
                    CostId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "VarChar(100)", maxLength: 100, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Costs", x => x.CostId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "VarChar(30)", maxLength: 30, nullable: false),
                    CustomerSurname = table.Column<string>(type: "VarChar(30)", maxLength: 30, nullable: false),
                    CustomerEmail = table.Column<string>(type: "VarChar(30)", maxLength: 30, nullable: false),
                    CustomerPhone = table.Column<string>(type: "VarChar(30)", maxLength: 30, nullable: false),
                    CustomerCity = table.Column<string>(type: "VarChar(20)", maxLength: 20, nullable: false),
                    CustomerDistrict = table.Column<string>(type: "VarChar(20)", maxLength: 20, nullable: false),
                    CustomerAdress = table.Column<string>(type: "VarChar(200)", maxLength: 200, nullable: false),
                    CustomerUserName = table.Column<string>(type: "VarChar(20)", maxLength: 20, nullable: true),
                    CustomerPassword = table.Column<string>(type: "VarChar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "VarChar(30)", maxLength: 30, nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "Details",
                columns: table => new
                {
                    DetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DProductName = table.Column<string>(type: "VarChar(30)", maxLength: 30, nullable: false),
                    DProductDescription = table.Column<string>(type: "VarChar(2000)", maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Details", x => x.DetailId);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    MessageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Receiver = table.Column<string>(type: "VarChar(50)", maxLength: 50, nullable: false),
                    Sender = table.Column<string>(type: "VarChar(50)", maxLength: 50, nullable: false),
                    Subject = table.Column<string>(type: "VarChar(50)", maxLength: 50, nullable: false),
                    Content = table.Column<string>(type: "VarChar(500)", maxLength: 500, nullable: false),
                    Date = table.Column<DateTime>(type: "Date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.MessageId);
                });

            migrationBuilder.CreateTable(
                name: "PaymentCategories",
                columns: table => new
                {
                    PaymentCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentCategoryName = table.Column<string>(type: "VarChar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentCategories", x => x.PaymentCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "TechnicalCategories",
                columns: table => new
                {
                    TechnicalCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TechnicalCategoryName = table.Column<string>(type: "VarChar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechnicalCategories", x => x.TechnicalCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Todos",
                columns: table => new
                {
                    ToDoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TodoDescription = table.Column<string>(type: "VarChar(300)", maxLength: 300, nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Todos", x => x.ToDoID);
                });

            migrationBuilder.CreateTable(
                name: "BillItems",
                columns: table => new
                {
                    BillItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "VarChar(130)", maxLength: 130, nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BillId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillItems", x => x.BillItemId);
                    table.ForeignKey(
                        name: "FK_BillItems_Bills_BillId",
                        column: x => x.BillId,
                        principalTable: "Bills",
                        principalColumn: "BillId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "VarChar(30)", maxLength: 30, nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    PurchasePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SalePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    ProductModel = table.Column<string>(type: "VarChar(250)", maxLength: 250, nullable: false),
                    ProductImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaintenanceIntervalInMonths = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Staffs",
                columns: table => new
                {
                    StaffId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffFullName = table.Column<string>(type: "VarChar(30)", maxLength: 30, nullable: false),
                    StaffMail = table.Column<string>(type: "VarChar(30)", maxLength: 30, nullable: false),
                    StaffPassword = table.Column<string>(type: "VarChar(30)", maxLength: 30, nullable: false),
                    StaffImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staffs", x => x.StaffId);
                    table.ForeignKey(
                        name: "FK_Staffs_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    PaymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PaidPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DownPayment = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    InstallmentCount = table.Column<int>(type: "int", nullable: true),
                    FirstInstallmentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InstallmentPeriodMonths = table.Column<int>(type: "int", nullable: true),
                    IsPaid = table.Column<bool>(type: "bit", nullable: false),
                    PaymentTypeForDownPayment = table.Column<int>(type: "int", nullable: true),
                    PaymentCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.PaymentId);
                    table.ForeignKey(
                        name: "FK_Payments_PaymentCategories_PaymentCategoryId",
                        column: x => x.PaymentCategoryId,
                        principalTable: "PaymentCategories",
                        principalColumn: "PaymentCategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Faults",
                columns: table => new
                {
                    FaultId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsComplete = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    StaffId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faults", x => x.FaultId);
                    table.ForeignKey(
                        name: "FK_Faults_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Faults_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Faults_Staffs_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staffs",
                        principalColumn: "StaffId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TechnicalSupports",
                columns: table => new
                {
                    TechnicalSupportId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CompletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsComplete = table.Column<bool>(type: "bit", nullable: true),
                    Description = table.Column<string>(type: "VarChar(1000)", maxLength: 1000, nullable: false),
                    TransactionFee = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TechnicalCategoryId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    StaffId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechnicalSupports", x => x.TechnicalSupportId);
                    table.ForeignKey(
                        name: "FK_TechnicalSupports_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId");
                    table.ForeignKey(
                        name: "FK_TechnicalSupports_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId");
                    table.ForeignKey(
                        name: "FK_TechnicalSupports_Staffs_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staffs",
                        principalColumn: "StaffId");
                    table.ForeignKey(
                        name: "FK_TechnicalSupports_TechnicalCategories_TechnicalCategoryId",
                        column: x => x.TechnicalCategoryId,
                        principalTable: "TechnicalCategories",
                        principalColumn: "TechnicalCategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Installments",
                columns: table => new
                {
                    InstallmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstallmentAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InstallmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InstallmentIsPaid = table.Column<bool>(type: "bit", nullable: false),
                    PaymentId = table.Column<int>(type: "int", nullable: false),
                    InstallmentPaymentType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Installments", x => x.InstallmentId);
                    table.ForeignKey(
                        name: "FK_Installments_Payments_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "Payments",
                        principalColumn: "PaymentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SaleTransactions",
                columns: table => new
                {
                    SaleTransactionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StockAmount = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    InstallationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    StaffId = table.Column<int>(type: "int", nullable: false),
                    PaymentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleTransactions", x => x.SaleTransactionId);
                    table.ForeignKey(
                        name: "FK_SaleTransactions_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SaleTransactions_Payments_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "Payments",
                        principalColumn: "PaymentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SaleTransactions_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SaleTransactions_Staffs_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staffs",
                        principalColumn: "StaffId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "AdminId", "Auth", "Password", "UserName" },
                values: new object[] { 1, "A", "123123", "huxx" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Arıtma Cihazları" },
                    { 2, "Filtreler" },
                    { 3, "Kimyasal Ürünler" },
                    { 4, "Aksesuarlar" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "CustomerAdress", "CustomerCity", "CustomerDistrict", "CustomerEmail", "CustomerName", "CustomerPassword", "CustomerPhone", "CustomerSurname", "CustomerUserName" },
                values: new object[,]
                {
                    { 1, "Kuştepe Mah. 1. Sok. No:5", "İstanbul", "Beşiktaş", "ahmet.yilmaz@example.com", "Ahmet", null, "5551234567", "Yılmaz", null },
                    { 2, "Kocatepe Mah. 2. Cad. No:10", "Ankara", "Çankaya", "elif.kaya@example.com", "Elif", null, "5552345678", "Kaya", null },
                    { 3, "Alsancak Mah. 3. Sok. No:20", "İzmir", "Konak", "mehmet.ozturk@example.com", "Mehmet", null, "5553456789", "Öztürk", null },
                    { 4, "Bahripaşa Mah. 4. Cad. No:15", "Bursa", "Osmangazi", "ayse.demir@example.com", "Ayşe", null, "5554567890", "Demir", null },
                    { 5, "Yukarı Karaman Mah. 5. Sok. No:25", "Antalya", "Muratpaşa", "ali.kara@example.com", "Ali", null, "5555678901", "Kara", null }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentId", "DepartmentName", "State" },
                values: new object[,]
                {
                    { 1, "Satış", true },
                    { 2, "Teknik Destek", true },
                    { 3, "Sekreter", true },
                    { 4, "Müdür", true }
                });

            migrationBuilder.InsertData(
                table: "PaymentCategories",
                columns: new[] { "PaymentCategoryId", "PaymentCategoryName" },
                values: new object[,]
                {
                    { 1, "Cash" },
                    { 2, "CreditCard" },
                    { 3, "Installment" }
                });

            migrationBuilder.InsertData(
                table: "TechnicalCategories",
                columns: new[] { "TechnicalCategoryId", "TechnicalCategoryName" },
                values: new object[,]
                {
                    { 1, "Kurulum" },
                    { 2, "Bakım" },
                    { 3, "Onarım" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Brand", "CategoryId", "MaintenanceIntervalInMonths", "ProductImage", "ProductModel", "ProductName", "PurchasePrice", "SalePrice", "State", "Stock" },
                values: new object[,]
                {
                    { 1, "PureWater", 1, 12, "reverse-osmosis.png", "RO2024", "Reverse Osmosis Arıtma Cihazı", 5000m, 7500m, true, 50 },
                    { 2, "CleanTech", 1, 12, "uv-purifier.png", "UV2024", "UV Arıtma Cihazı", 4000m, 6000m, true, 30 },
                    { 3, "FilterPro", 2, 6, "carbon-filter.png", "ACF2024", "Aktif Karbon Filtre", 150m, 250m, true, 100 },
                    { 4, "WaterSafe", 2, 6, "sediment-filter.png", "SF2024", "Sediment Filtre", 100m, 200m, true, 80 },
                    { 5, "MineralPlus", 3, 6, "mineral-cartridge.png", "MC2024", "Mineral Ekleme Kartuşu", 200m, 300m, true, 40 },
                    { 6, "OzoneMax", 3, 12, "ozone-generator.png", "OZ2024", "Ozon Jeneratörü", 700m, 1000m, true, 25 },
                    { 7, "TripleGuard", 2, 6, "triple-filter-set.png", "TS2024", "Üç Aşamalı Filtre Seti", 350m, 500m, true, 60 },
                    { 8, "SaltClear", 2, 6, "salt-water-cartridge.png", "SC2024", "Tuzlu Su Arıtma Kartuşu", 250m, 350m, true, 45 },
                    { 9, "CleanKit", 4, 6, "filter-cleaning-kit.png", "FK2024", "Filtre Temizlik Kiti", 80m, 120m, true, 75 },
                    { 10, "PartsPlus", 4, 12, "spare-parts-set.png", "PS2024", "Yedek Parça Seti", 150m, 200m, true, 35 }
                });

            migrationBuilder.InsertData(
                table: "Staffs",
                columns: new[] { "StaffId", "DepartmentId", "StaffFullName", "StaffImage", "StaffMail", "StaffPassword" },
                values: new object[,]
                {
                    { 1, 1, "Seda Çelik", "seda-celik.png", "sedac", "password1" },
                    { 2, 2, "Emre Yurt", "emre-yurt.png", "emrey", "password2" },
                    { 3, 2, "Zeynep Akman", "zeynep-akman.png", "zeynepa", "password3" },
                    { 4, 3, "Caner Erol", "caner-erol.png", "canere", "password4" },
                    { 5, 1, "Merve Arslan", "merve-arslan.png", "mervea", "password5" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BillItems_BillId",
                table: "BillItems",
                column: "BillId");

            migrationBuilder.CreateIndex(
                name: "IX_Faults_CustomerId",
                table: "Faults",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Faults_ProductId",
                table: "Faults",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Faults_StaffId",
                table: "Faults",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_Installments_PaymentId",
                table: "Installments",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_PaymentCategoryId",
                table: "Payments",
                column: "PaymentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleTransactions_CustomerId",
                table: "SaleTransactions",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleTransactions_PaymentId",
                table: "SaleTransactions",
                column: "PaymentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SaleTransactions_ProductId",
                table: "SaleTransactions",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleTransactions_StaffId",
                table: "SaleTransactions",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_DepartmentId",
                table: "Staffs",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_TechnicalSupports_CustomerId",
                table: "TechnicalSupports",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_TechnicalSupports_ProductId",
                table: "TechnicalSupports",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_TechnicalSupports_StaffId",
                table: "TechnicalSupports",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_TechnicalSupports_TechnicalCategoryId",
                table: "TechnicalSupports",
                column: "TechnicalCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "BillItems");

            migrationBuilder.DropTable(
                name: "CargoDetails");

            migrationBuilder.DropTable(
                name: "CargoTrackings");

            migrationBuilder.DropTable(
                name: "Costs");

            migrationBuilder.DropTable(
                name: "Details");

            migrationBuilder.DropTable(
                name: "Faults");

            migrationBuilder.DropTable(
                name: "Installments");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "SaleTransactions");

            migrationBuilder.DropTable(
                name: "TechnicalSupports");

            migrationBuilder.DropTable(
                name: "Todos");

            migrationBuilder.DropTable(
                name: "Bills");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Staffs");

            migrationBuilder.DropTable(
                name: "TechnicalCategories");

            migrationBuilder.DropTable(
                name: "PaymentCategories");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
