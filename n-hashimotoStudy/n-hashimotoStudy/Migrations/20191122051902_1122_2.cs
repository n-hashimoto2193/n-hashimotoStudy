using Microsoft.EntityFrameworkCore.Migrations;

namespace nhashimotoStudy.Migrations
{
    public partial class _1122_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kintais_Syains_SyainId",
                table: "Kintais");

            migrationBuilder.DropForeignKey(
                name: "FK_Syains_Bushoes_BushoId1",
                table: "Syains");

            migrationBuilder.DropForeignKey(
                name: "FK_Syains_Roles_RoleId1",
                table: "Syains");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Syains",
                table: "Syains");

            migrationBuilder.RenameTable(
                name: "Syains",
                newName: "Syain");

            migrationBuilder.RenameIndex(
                name: "IX_Syains_RoleId1",
                table: "Syain",
                newName: "IX_Syain_RoleId1");

            migrationBuilder.RenameIndex(
                name: "IX_Syains_BushoId1",
                table: "Syain",
                newName: "IX_Syain_BushoId1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Syain",
                table: "Syain",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Kintais_Syain_SyainId",
                table: "Kintais",
                column: "SyainId",
                principalTable: "Syain",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Syain_Bushoes_BushoId1",
                table: "Syain",
                column: "BushoId1",
                principalTable: "Bushoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Syain_Roles_RoleId1",
                table: "Syain",
                column: "RoleId1",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kintais_Syain_SyainId",
                table: "Kintais");

            migrationBuilder.DropForeignKey(
                name: "FK_Syain_Bushoes_BushoId1",
                table: "Syain");

            migrationBuilder.DropForeignKey(
                name: "FK_Syain_Roles_RoleId1",
                table: "Syain");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Syain",
                table: "Syain");

            migrationBuilder.RenameTable(
                name: "Syain",
                newName: "Syains");

            migrationBuilder.RenameIndex(
                name: "IX_Syain_RoleId1",
                table: "Syains",
                newName: "IX_Syains_RoleId1");

            migrationBuilder.RenameIndex(
                name: "IX_Syain_BushoId1",
                table: "Syains",
                newName: "IX_Syains_BushoId1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Syains",
                table: "Syains",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Kintais_Syains_SyainId",
                table: "Kintais",
                column: "SyainId",
                principalTable: "Syains",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Syains_Bushoes_BushoId1",
                table: "Syains",
                column: "BushoId1",
                principalTable: "Bushoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Syains_Roles_RoleId1",
                table: "Syains",
                column: "RoleId1",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
