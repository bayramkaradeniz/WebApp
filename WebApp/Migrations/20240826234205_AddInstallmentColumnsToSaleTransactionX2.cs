using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.Migrations
{
    /// <inheritdoc />
    public partial class AddInstallmentColumnsToSaleTransactionX2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InstallmentDetail_PaymentTypes_PaymentTypeId",
                table: "InstallmentDetail");

            migrationBuilder.DropTable(
                name: "PaymentTypes");

            migrationBuilder.DropIndex(
                name: "IX_InstallmentDetail_PaymentTypeId",
                table: "InstallmentDetail");

            migrationBuilder.DropColumn(
                name: "PaymentStatus",
                table: "SaleTransactions");

            migrationBuilder.DropColumn(
                name: "PaymentTypeId",
                table: "SaleTransactions");

            migrationBuilder.DropColumn(
                name: "PaymentTypeId",
                table: "InstallmentDetail");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PaymentStatus",
                table: "SaleTransactions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PaymentTypeId",
                table: "SaleTransactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PaymentTypeId",
                table: "InstallmentDetail",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PaymentTypes",
                columns: table => new
                {
                    PaymentTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SaleTransactionId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DownPayment = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    FirstInstallmentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InstallmentMonths = table.Column<int>(type: "int", nullable: true),
                    InstallmentPeriod = table.Column<int>(type: "int", nullable: true),
                    Method = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentTypes", x => x.PaymentTypeId);
                    table.ForeignKey(
                        name: "FK_PaymentTypes_SaleTransactions_SaleTransactionId",
                        column: x => x.SaleTransactionId,
                        principalTable: "SaleTransactions",
                        principalColumn: "SaleTransactionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InstallmentDetail_PaymentTypeId",
                table: "InstallmentDetail",
                column: "PaymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentTypes_SaleTransactionId",
                table: "PaymentTypes",
                column: "SaleTransactionId");

            migrationBuilder.AddForeignKey(
                name: "FK_InstallmentDetail_PaymentTypes_PaymentTypeId",
                table: "InstallmentDetail",
                column: "PaymentTypeId",
                principalTable: "PaymentTypes",
                principalColumn: "PaymentTypeId");
        }
    }
}
