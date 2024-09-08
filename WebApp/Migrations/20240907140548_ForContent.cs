using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.Migrations
{
    /// <inheritdoc />
    public partial class ForContent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Subject",
                table: "Messages",
                type: "VarChar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "Varchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Sender",
                table: "Messages",
                type: "VarChar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "Varchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Receiver",
                table: "Messages",
                type: "VarChar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "Varchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Messages",
                type: "VarChar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "Varchar(500)",
                oldMaxLength: 500);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Subject",
                table: "Messages",
                type: "Varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VarChar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Sender",
                table: "Messages",
                type: "Varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VarChar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Receiver",
                table: "Messages",
                type: "Varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VarChar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Messages",
                type: "Varchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VarChar(500)",
                oldMaxLength: 500);
        }
    }
}
