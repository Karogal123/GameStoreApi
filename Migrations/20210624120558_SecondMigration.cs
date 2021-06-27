using Microsoft.EntityFrameworkCore.Migrations;

namespace GameStore.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WarehouseId",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Games_WarehouseId",
                table: "Games",
                column: "WarehouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Warehouses_WarehouseId",
                table: "Games",
                column: "WarehouseId",
                principalTable: "Warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Warehouses_WarehouseId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_WarehouseId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "WarehouseId",
                table: "Games");
        }
    }
}
