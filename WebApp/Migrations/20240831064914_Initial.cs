﻿using System;
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
                    CustomerAdress = table.Column<string>(type: "VarChar(200)", maxLength: 200, nullable: false)
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
                name: "BillItems",
                columns: table => new
                {
                    BillItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "VarChar(130)", maxLength: 130, nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Sum = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
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
                    StaffUsername = table.Column<string>(type: "VarChar(30)", maxLength: 30, nullable: false),
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
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Filtreli" },
                    { 2, "Filtresiz" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "CustomerAdress", "CustomerCity", "CustomerDistrict", "CustomerEmail", "CustomerName", "CustomerPhone", "CustomerSurname" },
                values: new object[,]
                {
                    { 1, "123 Broadway", "New York", "Manhattan", "john.doe@example.com", "John", "1234567890", "Doe" },
                    { 2, "456 Sunset Blvd", "Los Angeles", "Hollywood", "jane.smith@example.com", "Jane", "0987654321", "Smith" },
                    { 3, "789 Michigan Ave", "Chicago", "Downtown", "alice.johnson@example.com", "Alice", "2345678901", "Johnson" },
                    { 4, "101 Main St", "Houston", "Downtown", "bob.williams@example.com", "Bob", "3456789012", "Williams" },
                    { 5, "202 Central Ave", "Phoenix", "Central", "carol.davis@example.com", "Carol", "4567890123", "Davis" }
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
                    { 1, "Fresh", 1, 6, "apple-juice.png", "AJ2024", "Apple Juice", 1.50m, 2.00m, true, 100 },
                    { 2, "Tropical", 1, 6, "banana-smoothie.png", "BS2024", "Banana Smoothie", 2.00m, 2.50m, true, 200 },
                    { 3, "Veggie", 1, 6, "carrot-drink.png", "CD2024", "Carrot Drink", 1.75m, 2.25m, true, 150 },
                    { 4, "Exotic", 1, 6, "dragon-fruit-juice.png", "DFJ2024", "Dragon Fruit Juice", 3.00m, 4.00m, true, 50 },
                    { 5, "Berry", 2, 12, "elderberry-wine.png", "EW2024", "Elderberry Wine", 5.00m, 7.00m, true, 30 },
                    { 6, "Sweet", 2, 6, "fig-syrup.png", "FS2024", "Fig Syrup", 2.50m, 3.00m, true, 80 },
                    { 7, "Vine", 2, 6, "grape-juice.png", "GJ2024", "Grape Juice", 1.80m, 2.30m, true, 120 },
                    { 8, "SweetLife", 2, 6, "honey-lemonade.png", "HL2024", "Honey Lemonade", 2.20m, 2.70m, true, 60 },
                    { 9, "CoolBrew", 2, 6, "iced-tea.png", "IT2024", "Iced Tea", 1.70m, 2.20m, true, 90 },
                    { 10, "Fusion", 1, 6, "juice-blend.png", "JB2024", "Juice Blend", 2.00m, 2.60m, true, 70 }
                });

            migrationBuilder.InsertData(
                table: "Staffs",
                columns: new[] { "StaffId", "DepartmentId", "StaffFullName", "StaffImage", "StaffPassword", "StaffUsername" },
                values: new object[,]
                {
                    { 1, 1, "Alice Brown", "alice-brown.png", "password1", "aliceb" },
                    { 2, 2, "Bob Green", "bob-green.png", "password2", "bobg" },
                    { 3, 2, "Charlie White", "charlie-white.png", "password3", "charliew" },
                    { 4, 3, "Diana Black", "diana-black.png", "password4", "dianab" },
                    { 5, 1, "Edward Blue", "edward-blue.png", "password5", "edwardb" }
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
                name: "Costs");

            migrationBuilder.DropTable(
                name: "Details");

            migrationBuilder.DropTable(
                name: "Faults");

            migrationBuilder.DropTable(
                name: "Installments");

            migrationBuilder.DropTable(
                name: "SaleTransactions");

            migrationBuilder.DropTable(
                name: "TechnicalSupports");

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