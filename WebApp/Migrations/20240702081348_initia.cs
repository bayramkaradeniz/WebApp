using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.Migrations
{
    /// <inheritdoc />
    public partial class initia : Migration
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
                    Hour = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TaxOffice = table.Column<string>(type: "VarChar(15)", maxLength: 15, nullable: false),
                    Sender = table.Column<string>(type: "VarChar(30)", maxLength: 30, nullable: false),
                    Receiver = table.Column<string>(type: "VarChar(30)", maxLength: 30, nullable: false)
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
                name: "Department",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "VarChar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "SaleTransactions",
                columns: table => new
                {
                    SaleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleTransactions", x => x.SaleId);
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
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CustomerName = table.Column<string>(type: "VarChar(30)", maxLength: 30, nullable: false),
                    CustomerSurname = table.Column<string>(type: "VarChar(30)", maxLength: 30, nullable: false),
                    CustomerEmail = table.Column<string>(type: "VarChar(30)", maxLength: 30, nullable: false),
                    CustomerCity = table.Column<string>(type: "VarChar(15)", maxLength: 15, nullable: false),
                    SaleTransactionSaleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_SaleTransactions_SaleTransactionSaleId",
                        column: x => x.SaleTransactionSaleId,
                        principalTable: "SaleTransactions",
                        principalColumn: "SaleId",
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
                    Stock = table.Column<short>(type: "smallint", nullable: false),
                    PurchasePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SalePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    ProductImage = table.Column<string>(type: "VarChar(250)", maxLength: 250, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    SaleTransactionSaleId = table.Column<int>(type: "int", nullable: false)
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
                    table.ForeignKey(
                        name: "FK_Products_SaleTransactions_SaleTransactionSaleId",
                        column: x => x.SaleTransactionSaleId,
                        principalTable: "SaleTransactions",
                        principalColumn: "SaleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Staffs",
                columns: table => new
                {
                    StaffId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffName = table.Column<string>(type: "VarChar(30)", maxLength: 30, nullable: false),
                    StaffSurname = table.Column<string>(type: "VarChar(30)", maxLength: 30, nullable: false),
                    StaffImage = table.Column<string>(type: "VarChar(250)", maxLength: 250, nullable: false),
                    SaleTransactionSaleId = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staffs", x => x.StaffId);
                    table.ForeignKey(
                        name: "FK_Staffs_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Staffs_SaleTransactions_SaleTransactionSaleId",
                        column: x => x.SaleTransactionSaleId,
                        principalTable: "SaleTransactions",
                        principalColumn: "SaleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BillItems_BillId",
                table: "BillItems",
                column: "BillId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_SaleTransactionSaleId",
                table: "Customers",
                column: "SaleTransactionSaleId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SaleTransactionSaleId",
                table: "Products",
                column: "SaleTransactionSaleId");

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_DepartmentId",
                table: "Staffs",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_SaleTransactionSaleId",
                table: "Staffs",
                column: "SaleTransactionSaleId");
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
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Staffs");

            migrationBuilder.DropTable(
                name: "Bills");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "SaleTransactions");
        }
    }
}
