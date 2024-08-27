using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.Migrations
{
    /// <inheritdoc />
    public partial class Demox6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "InstallmentDetail",
                columns: table => new
                {
                    InstallmentDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstallmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InstallmentAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsPaid = table.Column<bool>(type: "bit", nullable: false),
                    SaleTransactionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstallmentDetail", x => x.InstallmentDetailId);
                    table.ForeignKey(
                        name: "FK_InstallmentDetail_SaleTransactions_SaleTransactionId",
                        column: x => x.SaleTransactionId,
                        principalTable: "SaleTransactions",
                        principalColumn: "SaleTransactionId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_InstallmentDetail_SaleTransactionId",
                table: "InstallmentDetail",
                column: "SaleTransactionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InstallmentDetail");

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
                name: "PaymentMethod",
                table: "SaleTransactions");
        }
    }
}
