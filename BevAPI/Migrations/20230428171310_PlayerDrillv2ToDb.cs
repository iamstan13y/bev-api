using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BevAPI.Migrations
{
    public partial class PlayerDrillv2ToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DrillId",
                table: "PlayerDrills",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PlayerDrills_DrillId",
                table: "PlayerDrills",
                column: "DrillId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerDrills_Drills_DrillId",
                table: "PlayerDrills",
                column: "DrillId",
                principalTable: "Drills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerDrills_Drills_DrillId",
                table: "PlayerDrills");

            migrationBuilder.DropIndex(
                name: "IX_PlayerDrills_DrillId",
                table: "PlayerDrills");

            migrationBuilder.DropColumn(
                name: "DrillId",
                table: "PlayerDrills");
        }
    }
}
