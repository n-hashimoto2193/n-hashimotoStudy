using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace nhashimotoStudy.Migrations
{
    public partial class _1122_modelDel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kintais_Syain_SyainId",
                table: "Kintais");

            migrationBuilder.DropTable(
                name: "Syain");

            migrationBuilder.DropIndex(
                name: "IX_Kintais_SyainId",
                table: "Kintais");

            migrationBuilder.DropColumn(
                name: "SyainId",
                table: "Kintais");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "SyainId",
                table: "Kintais",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Syain",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    BushoId1 = table.Column<long>(nullable: true),
                    Email = table.Column<string>(nullable: false),
                    No = table.Column<string>(nullable: false),
                    RoleId1 = table.Column<long>(nullable: true),
                    SyainName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Syain", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Syain_Bushoes_BushoId1",
                        column: x => x.BushoId1,
                        principalTable: "Bushoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Syain_Roles_RoleId1",
                        column: x => x.RoleId1,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Kintais_SyainId",
                table: "Kintais",
                column: "SyainId");

            migrationBuilder.CreateIndex(
                name: "IX_Syain_BushoId1",
                table: "Syain",
                column: "BushoId1");

            migrationBuilder.CreateIndex(
                name: "IX_Syain_RoleId1",
                table: "Syain",
                column: "RoleId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Kintais_Syain_SyainId",
                table: "Kintais",
                column: "SyainId",
                principalTable: "Syain",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
