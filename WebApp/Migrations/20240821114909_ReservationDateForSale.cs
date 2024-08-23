using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.Migrations
{
    /// <inheritdoc />
    public partial class ReservationDateForSale : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "TechnicalSupports",
                type: "VarChar(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VarChar(30)",
                oldMaxLength: 30);

            migrationBuilder.AddColumn<string>(
                name: "ReservationDate",
                table: "SaleTransactions",
                type: "nvarchar(30)",
                nullable: true,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReservationDate",
                table: "SaleTransactions");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "TechnicalSupports",
                type: "VarChar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VarChar(1000)",
                oldMaxLength: 1000);
        }
    }
}
