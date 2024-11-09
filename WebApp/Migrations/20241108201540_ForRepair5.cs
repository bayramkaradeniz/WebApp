using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.Migrations
{
    /// <inheritdoc />
    public partial class ForRepair5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Faults_SaleTransactions_SaleTransactionId",
                table: "Faults");

            migrationBuilder.DropIndex(
                name: "IX_Faults_SaleTransactionId",
                table: "Faults");

            migrationBuilder.DropColumn(
                name: "SaleTransactionId",
                table: "Faults");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SaleTransactionId",
                table: "Faults",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Faults_SaleTransactionId",
                table: "Faults",
                column: "SaleTransactionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Faults_SaleTransactions_SaleTransactionId",
                table: "Faults",
                column: "SaleTransactionId",
                principalTable: "SaleTransactions",
                principalColumn: "SaleTransactionId");
        }
    }
}
