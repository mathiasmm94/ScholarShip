using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ModelsApi.Data.Migrations
{
    public partial class AddedRegisterUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Managers_Email",
                table: "Managers");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Managers",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldMaxLength: 32,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Managers",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldMaxLength: 64,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Managers",
                type: "nvarchar(254)",
                maxLength: 254,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(254)",
                oldMaxLength: 254,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Birthdate",
                table: "Managers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Managers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Managers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "University",
                table: "Managers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Managers_Email",
                table: "Managers",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Managers_Email",
                table: "Managers");

            migrationBuilder.DropColumn(
                name: "Birthdate",
                table: "Managers");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Managers");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Managers");

            migrationBuilder.DropColumn(
                name: "University",
                table: "Managers");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Managers",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldMaxLength: 32);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Managers",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldMaxLength: 64);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Managers",
                type: "nvarchar(254)",
                maxLength: 254,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(254)",
                oldMaxLength: 254);

            migrationBuilder.CreateIndex(
                name: "IX_Managers_Email",
                table: "Managers",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");
        }
    }
}
