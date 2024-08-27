using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.Migrations
{
    /// <inheritdoc />
    public partial class Demox5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DownPayment",
                table: "SaleTransactions");

            migrationBuilder.DropColumn(
                name: "FirstInstallmentDate",
                table: "SaleTransactions");

            migrationBuilder.DropColumn(
                name: "InstallmentDetailsJson",
                table: "SaleTransactions");

            migrationBuilder.DropColumn(
                name: "InstallmentMonths",
                table: "SaleTransactions");

            migrationBuilder.DropColumn(
                name: "InstallmentPeriod",
                table: "SaleTransactions");

            migrationBuilder.DropColumn(
                name: "PaymentMethod",
                table: "SaleTransactions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<string>(
                name: "InstallmentDetailsJson",
                table: "SaleTransactions",
                type: "nvarchar(max)",
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
                name: "PaymentMethod",
                table: "SaleTransactions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
