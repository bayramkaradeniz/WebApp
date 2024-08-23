using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.Migrations
{
    /// <inheritdoc />
    public partial class TechnicalSupports : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TechnicalCategories",
                columns: table => new
                {
                    TechnicalCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TechnicalCategoryName = table.Column<string>(type: "VarChar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechnicalCategories", x => x.TechnicalCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "TechnicalSupports",
                columns: table => new
                {
                    TechnicalSupportId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsComplete = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "VarChar(1000)", maxLength: 1000, nullable: true),
                    TechnicalCategoryId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    StaffId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechnicalSupports", x => x.TechnicalSupportId);
                    table.ForeignKey(
                        name: "FK_TechnicalSupports_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TechnicalSupports_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TechnicalSupports_Staffs_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staffs",
                        principalColumn: "StaffId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TechnicalSupports_TechnicalCategories_TechnicalCategoryId",
                        column: x => x.TechnicalCategoryId,
                        principalTable: "TechnicalCategories",
                        principalColumn: "TechnicalCategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TechnicalSupports_CustomerId",
                table: "TechnicalSupports",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_TechnicalSupports_ProductId",
                table: "TechnicalSupports",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_TechnicalSupports_StaffId",
                table: "TechnicalSupports",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_TechnicalSupports_TechnicalCategoryId",
                table: "TechnicalSupports",
                column: "TechnicalCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TechnicalSupports");

            migrationBuilder.DropTable(
                name: "TechnicalCategories");
        }
    }
}
