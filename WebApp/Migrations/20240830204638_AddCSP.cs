using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApp.Migrations
{
    /// <inheritdoc />
    public partial class AddCSP : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "CustomerAdress", "CustomerCity", "CustomerDistrict", "CustomerEmail", "CustomerName", "CustomerPhone", "CustomerSurname" },
                values: new object[,]
                {
                    { 1, "123 Broadway", "New York", "Manhattan", "john.doe@example.com", "John", "1234567890", "Doe" },
                    { 2, "456 Sunset Blvd", "Los Angeles", "Hollywood", "jane.smith@example.com", "Jane", "0987654321", "Smith" },
                    { 3, "789 Michigan Ave", "Chicago", "Downtown", "alice.johnson@example.com", "Alice", "2345678901", "Johnson" },
                    { 4, "101 Main St", "Houston", "Downtown", "bob.williams@example.com", "Bob", "3456789012", "Williams" },
                    { 5, "202 Central Ave", "Phoenix", "Central", "carol.davis@example.com", "Carol", "4567890123", "Davis" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Brand", "CategoryId", "MaintenanceIntervalInMonths", "ProductImage", "ProductModel", "ProductName", "PurchasePrice", "SalePrice", "State", "Stock" },
                values: new object[,]
                {
                    { 1, "Fresh", 1, 6, "apple-juice.png", "AJ2024", "Apple Juice", 1.50m, 2.00m, true, 100 },
                    { 2, "Tropical", 1, 6, "banana-smoothie.png", "BS2024", "Banana Smoothie", 2.00m, 2.50m, true, 200 },
                    { 3, "Veggie", 1, 6, "carrot-drink.png", "CD2024", "Carrot Drink", 1.75m, 2.25m, true, 150 },
                    { 4, "Exotic", 1, 6, "dragon-fruit-juice.png", "DFJ2024", "Dragon Fruit Juice", 3.00m, 4.00m, true, 50 },
                    { 5, "Berry", 2, 12, "elderberry-wine.png", "EW2024", "Elderberry Wine", 5.00m, 7.00m, true, 30 },
                    { 6, "Sweet", 2, 6, "fig-syrup.png", "FS2024", "Fig Syrup", 2.50m, 3.00m, true, 80 },
                    { 7, "Vine", 2, 6, "grape-juice.png", "GJ2024", "Grape Juice", 1.80m, 2.30m, true, 120 },
                    { 8, "SweetLife", 2, 6, "honey-lemonade.png", "HL2024", "Honey Lemonade", 2.20m, 2.70m, true, 60 },
                    { 9, "CoolBrew", 2, 6, "iced-tea.png", "IT2024", "Iced Tea", 1.70m, 2.20m, true, 90 },
                    { 10, "Fusion", 1, 6, "juice-blend.png", "JB2024", "Juice Blend", 2.00m, 2.60m, true, 70 }
                });

            migrationBuilder.InsertData(
                table: "Staffs",
                columns: new[] { "StaffId", "DepartmentId", "StaffFullName", "StaffImage", "StaffPassword", "StaffUsername" },
                values: new object[,]
                {
                    { 1, 1, "Alice Brown", "alice-brown.png", "password1", "aliceb" },
                    { 2, 2, "Bob Green", "bob-green.png", "password2", "bobg" },
                    { 3, 2, "Charlie White", "charlie-white.png", "password3", "charliew" },
                    { 4, 3, "Diana Black", "diana-black.png", "password4", "dianab" },
                    { 5, 1, "Edward Blue", "edward-blue.png", "password5", "edwardb" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Staffs",
                keyColumn: "StaffId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Staffs",
                keyColumn: "StaffId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Staffs",
                keyColumn: "StaffId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Staffs",
                keyColumn: "StaffId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Staffs",
                keyColumn: "StaffId",
                keyValue: 5);
        }
    }
}
