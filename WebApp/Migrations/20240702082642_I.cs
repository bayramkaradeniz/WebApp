using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.Migrations
{
    /// <inheritdoc />
    public partial class I : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_SaleTransactions_SaleTransactionSaleId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_SaleTransactions_SaleTransactionSaleId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Staffs_SaleTransactions_SaleTransactionSaleId",
                table: "Staffs");

            migrationBuilder.DropIndex(
                name: "IX_Staffs_SaleTransactionSaleId",
                table: "Staffs");

            migrationBuilder.DropIndex(
                name: "IX_Products_SaleTransactionSaleId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Customers_SaleTransactionSaleId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "SaleTransactionSaleId",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "SaleTransactionSaleId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SaleTransactionSaleId",
                table: "Customers");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "SaleTransactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "SaleTransactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StaffId",
                table: "SaleTransactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SaleTransactions_CustomerId",
                table: "SaleTransactions",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleTransactions_ProductId",
                table: "SaleTransactions",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleTransactions_StaffId",
                table: "SaleTransactions",
                column: "StaffId");

            migrationBuilder.AddForeignKey(
                name: "FK_SaleTransactions_Customers_CustomerId",
                table: "SaleTransactions",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SaleTransactions_Products_ProductId",
                table: "SaleTransactions",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SaleTransactions_Staffs_StaffId",
                table: "SaleTransactions",
                column: "StaffId",
                principalTable: "Staffs",
                principalColumn: "StaffId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaleTransactions_Customers_CustomerId",
                table: "SaleTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_SaleTransactions_Products_ProductId",
                table: "SaleTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_SaleTransactions_Staffs_StaffId",
                table: "SaleTransactions");

            migrationBuilder.DropIndex(
                name: "IX_SaleTransactions_CustomerId",
                table: "SaleTransactions");

            migrationBuilder.DropIndex(
                name: "IX_SaleTransactions_ProductId",
                table: "SaleTransactions");

            migrationBuilder.DropIndex(
                name: "IX_SaleTransactions_StaffId",
                table: "SaleTransactions");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "SaleTransactions");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "SaleTransactions");

            migrationBuilder.DropColumn(
                name: "StaffId",
                table: "SaleTransactions");

            migrationBuilder.AddColumn<int>(
                name: "SaleTransactionSaleId",
                table: "Staffs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SaleTransactionSaleId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SaleTransactionSaleId",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_SaleTransactionSaleId",
                table: "Staffs",
                column: "SaleTransactionSaleId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SaleTransactionSaleId",
                table: "Products",
                column: "SaleTransactionSaleId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_SaleTransactionSaleId",
                table: "Customers",
                column: "SaleTransactionSaleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_SaleTransactions_SaleTransactionSaleId",
                table: "Customers",
                column: "SaleTransactionSaleId",
                principalTable: "SaleTransactions",
                principalColumn: "SaleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_SaleTransactions_SaleTransactionSaleId",
                table: "Products",
                column: "SaleTransactionSaleId",
                principalTable: "SaleTransactions",
                principalColumn: "SaleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Staffs_SaleTransactions_SaleTransactionSaleId",
                table: "Staffs",
                column: "SaleTransactionSaleId",
                principalTable: "SaleTransactions",
                principalColumn: "SaleId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
