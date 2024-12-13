using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleRpgEntities.Migrations
{
    public partial class UpdateAbilities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Abilities");

            migrationBuilder.AddColumn<int>(
                name: "ActiveAbility",
                table: "Players",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Value",
                table: "Abilities",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActiveAbility",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "Abilities");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Abilities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
