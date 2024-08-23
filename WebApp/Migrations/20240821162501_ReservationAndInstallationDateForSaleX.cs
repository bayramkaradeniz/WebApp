using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.Migrations
{
    /// <inheritdoc />
    public partial class ReservationAndInstallationDateForSaleX : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "TechnicalSupports");

            migrationBuilder.DropColumn(
                name: "ReservationDate",
                table: "SaleTransactions");

            migrationBuilder.AddColumn<DateTime>(
                name: "TransactionDate",
                table: "TechnicalSupports",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "InstallationDate",
                table: "SaleTransactions",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TransactionDate",
                table: "TechnicalSupports");

            migrationBuilder.DropColumn(
                name: "InstallationDate",
                table: "SaleTransactions");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "TechnicalSupports",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ReservationDate",
                table: "SaleTransactions",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "");
        }
    }
}
