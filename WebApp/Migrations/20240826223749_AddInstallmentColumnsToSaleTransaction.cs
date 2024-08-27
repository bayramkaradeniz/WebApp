using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.Migrations
{
    /// <inheritdoc />
    public partial class AddInstallmentColumnsToSaleTransaction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaleTransactions_PaymentTypes_PaymentTypeId",
                table: "SaleTransactions");

            migrationBuilder.DropIndex(
                name: "IX_SaleTransactions_PaymentTypeId",
                table: "SaleTransactions");

            migrationBuilder.AddColumn<decimal>(
                name: "DownPayment",
                table: "SaleTransactions",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FirstInstallmentDate",
                table: "SaleTransactions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InstallmentMonths",
                table: "SaleTransactions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InstallmentPeriod",
                table: "SaleTransactions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Method",
                table: "SaleTransactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SaleTransactionId",
                table: "InstallmentDetail",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InstallmentDetail_SaleTransactionId",
                table: "InstallmentDetail",
                column: "SaleTransactionId");

            migrationBuilder.AddForeignKey(
                name: "FK_InstallmentDetail_SaleTransactions_SaleTransactionId",
                table: "InstallmentDetail",
                column: "SaleTransactionId",
                principalTable: "SaleTransactions",
                principalColumn: "SaleTransactionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InstallmentDetail_SaleTransactions_SaleTransactionId",
                table: "InstallmentDetail");

            migrationBuilder.DropIndex(
                name: "IX_InstallmentDetail_SaleTransactionId",
                table: "InstallmentDetail");

            migrationBuilder.DropColumn(
                name: "DownPayment",
                table: "SaleTransactions");

            migrationBuilder.DropColumn(
                name: "FirstInstallmentDate",
                table: "SaleTransactions");

            migrationBuilder.DropColumn(
                name: "InstallmentMonths",
                table: "SaleTransactions");

            migrationBuilder.DropColumn(
                name: "InstallmentPeriod",
                table: "SaleTransactions");

            migrationBuilder.DropColumn(
                name: "Method",
                table: "SaleTransactions");

            migrationBuilder.DropColumn(
                name: "SaleTransactionId",
                table: "InstallmentDetail");

            migrationBuilder.CreateIndex(
                name: "IX_SaleTransactions_PaymentTypeId",
                table: "SaleTransactions",
                column: "PaymentTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_SaleTransactions_PaymentTypes_PaymentTypeId",
                table: "SaleTransactions",
                column: "PaymentTypeId",
                principalTable: "PaymentTypes",
                principalColumn: "PaymentTypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
