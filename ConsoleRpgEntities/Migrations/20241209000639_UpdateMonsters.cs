using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleRpgEntities.Migrations
{
    public partial class UpdateMonsters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AggressionLevel",
                table: "Monsters",
                newName: "Coins");

            migrationBuilder.AddColumn<int>(
                name: "ArmorItemId",
                table: "Monsters",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PotionItemId",
                table: "Monsters",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "Monsters",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WeaponItemId",
                table: "Monsters",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Monsters_ArmorItemId",
                table: "Monsters",
                column: "ArmorItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Monsters_PotionItemId",
                table: "Monsters",
                column: "PotionItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Monsters_RoomId",
                table: "Monsters",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Monsters_WeaponItemId",
                table: "Monsters",
                column: "WeaponItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Monsters_Items_ArmorItemId",
                table: "Monsters",
                column: "ArmorItemId",
                principalTable: "Items",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Monsters_Items_PotionItemId",
                table: "Monsters",
                column: "PotionItemId",
                principalTable: "Items",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Monsters_Items_WeaponItemId",
                table: "Monsters",
                column: "WeaponItemId",
                principalTable: "Items",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Monsters_Rooms_RoomId",
                table: "Monsters",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Monsters_Items_ArmorItemId",
                table: "Monsters");

            migrationBuilder.DropForeignKey(
                name: "FK_Monsters_Items_PotionItemId",
                table: "Monsters");

            migrationBuilder.DropForeignKey(
                name: "FK_Monsters_Items_WeaponItemId",
                table: "Monsters");

            migrationBuilder.DropForeignKey(
                name: "FK_Monsters_Rooms_RoomId",
                table: "Monsters");

            migrationBuilder.DropIndex(
                name: "IX_Monsters_ArmorItemId",
                table: "Monsters");

            migrationBuilder.DropIndex(
                name: "IX_Monsters_PotionItemId",
                table: "Monsters");

            migrationBuilder.DropIndex(
                name: "IX_Monsters_RoomId",
                table: "Monsters");

            migrationBuilder.DropIndex(
                name: "IX_Monsters_WeaponItemId",
                table: "Monsters");

            migrationBuilder.DropColumn(
                name: "ArmorItemId",
                table: "Monsters");

            migrationBuilder.DropColumn(
                name: "PotionItemId",
                table: "Monsters");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "Monsters");

            migrationBuilder.DropColumn(
                name: "WeaponItemId",
                table: "Monsters");

            migrationBuilder.RenameColumn(
                name: "Coins",
                table: "Monsters",
                newName: "AggressionLevel");
        }
    }
}
