using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.Migrations
{
    /// <inheritdoc />
    public partial class initialx2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bills_BillItems_BillItemId",
                table: "Bills");

            migrationBuilder.DropIndex(
                name: "IX_Bills_BillItemId",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "BillItemId",
                table: "Bills");

            migrationBuilder.AddColumn<int>(
                name: "BillId",
                table: "BillItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BillItems_BillId",
                table: "BillItems",
                column: "BillId");

            migrationBuilder.AddForeignKey(
                name: "FK_BillItems_Bills_BillId",
                table: "BillItems",
                column: "BillId",
                principalTable: "Bills",
                principalColumn: "BillId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillItems_Bills_BillId",
                table: "BillItems");

            migrationBuilder.DropIndex(
                name: "IX_BillItems_BillId",
                table: "BillItems");

            migrationBuilder.DropColumn(
                name: "BillId",
                table: "BillItems");

            migrationBuilder.AddColumn<int>(
                name: "BillItemId",
                table: "Bills",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Bills_BillItemId",
                table: "Bills",
                column: "BillItemId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_BillItems_BillItemId",
                table: "Bills",
                column: "BillItemId",
                principalTable: "BillItems",
                principalColumn: "BillItemId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
