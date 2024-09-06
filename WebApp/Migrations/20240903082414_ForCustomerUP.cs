using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.Migrations
{
    /// <inheritdoc />
    public partial class ForCustomerUP : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomerPassword",
                table: "Customers",
                type: "VarChar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerUserName",
                table: "Customers",
                type: "VarChar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1,
                columns: new[] { "CustomerPassword", "CustomerUserName" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2,
                columns: new[] { "CustomerPassword", "CustomerUserName" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 3,
                columns: new[] { "CustomerPassword", "CustomerUserName" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 4,
                columns: new[] { "CustomerPassword", "CustomerUserName" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 5,
                columns: new[] { "CustomerPassword", "CustomerUserName" },
                values: new object[] { null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerPassword",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CustomerUserName",
                table: "Customers");
        }
    }
}
