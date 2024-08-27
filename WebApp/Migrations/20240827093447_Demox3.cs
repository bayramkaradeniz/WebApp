using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.Migrations
{
    /// <inheritdoc />
    public partial class Demox3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InstallmentDetail");

            migrationBuilder.AddColumn<string>(
                name: "InstallmentDetailsJson",
                table: "SaleTransactions",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InstallmentDetailsJson",
                table: "SaleTransactions");

            migrationBuilder.CreateTable(
                name: "InstallmentDetail",
                columns: table => new
                {
                    InstallmentDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstallmentAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InstallmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
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
    }
}
