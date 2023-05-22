using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ModelsApi.Data.Migrations
{
    public partial class addedcheckboxandnumberofweekstoannonce : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CheckBoxValue",
                table: "Annonces",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfWeeks",
                table: "Annonces",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CheckBoxValue",
                table: "Annonces");

            migrationBuilder.DropColumn(
                name: "NumberOfWeeks",
                table: "Annonces");
        }
    }
}
