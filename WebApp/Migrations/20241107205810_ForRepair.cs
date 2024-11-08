using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.Migrations
{
    /// <inheritdoc />
    public partial class ForRepair : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Faults_Customers_CustomerId",
                table: "Faults");

            migrationBuilder.DropForeignKey(
                name: "FK_Faults_Products_ProductId",
                table: "Faults");

            migrationBuilder.DropForeignKey(
                name: "FK_Faults_Staffs_StaffId",
                table: "Faults");

            migrationBuilder.AlterColumn<int>(
                name: "StaffId",
                table: "Faults",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "Faults",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Faults",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Faults",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Faults",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Faults_Customers_CustomerId",
                table: "Faults",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Faults_Products_ProductId",
                table: "Faults",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Faults_Staffs_StaffId",
                table: "Faults",
                column: "StaffId",
                principalTable: "Staffs",
                principalColumn: "StaffId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Faults_Customers_CustomerId",
                table: "Faults");

            migrationBuilder.DropForeignKey(
                name: "FK_Faults_Products_ProductId",
                table: "Faults");

            migrationBuilder.DropForeignKey(
                name: "FK_Faults_Staffs_StaffId",
                table: "Faults");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Faults");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Faults");

            migrationBuilder.AlterColumn<int>(
                name: "StaffId",
                table: "Faults",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "Faults",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Faults",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Faults_Customers_CustomerId",
                table: "Faults",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Faults_Products_ProductId",
                table: "Faults",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Faults_Staffs_StaffId",
                table: "Faults",
                column: "StaffId",
                principalTable: "Staffs",
                principalColumn: "StaffId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
