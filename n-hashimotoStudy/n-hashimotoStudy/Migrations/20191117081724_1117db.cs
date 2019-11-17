using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace nhashimotoStudy.Migrations
{
    public partial class _1117db : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Syains_Bushoes_BushoId",
                table: "Syains");

            migrationBuilder.DropForeignKey(
                name: "FK_Syains_Roles_RoleId",
                table: "Syains");

            migrationBuilder.DropIndex(
                name: "IX_Syains_BushoId",
                table: "Syains");

            migrationBuilder.DropIndex(
                name: "IX_Syains_RoleId",
                table: "Syains");

            migrationBuilder.DropColumn(
                name: "BushoId",
                table: "Syains");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Syains");

            migrationBuilder.AlterColumn<string>(
                name: "No",
                table: "Syains",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "BushoId1",
                table: "Syains",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "RoleId1",
                table: "Syains",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Syains_BushoId1",
                table: "Syains",
                column: "BushoId1");

            migrationBuilder.CreateIndex(
                name: "IX_Syains_RoleId1",
                table: "Syains",
                column: "RoleId1");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Syains_Bushoes_BushoId1",
                table: "Syains");

            migrationBuilder.DropForeignKey(
                name: "FK_Syains_Roles_RoleId1",
                table: "Syains");

            migrationBuilder.DropIndex(
                name: "IX_Syains_BushoId1",
                table: "Syains");

            migrationBuilder.DropIndex(
                name: "IX_Syains_RoleId1",
                table: "Syains");

            migrationBuilder.DropColumn(
                name: "BushoId1",
                table: "Syains");

            migrationBuilder.DropColumn(
                name: "RoleId1",
                table: "Syains");

            migrationBuilder.AlterColumn<string>(
                name: "No",
                table: "Syains",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<long>(
                name: "BushoId",
                table: "Syains",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "RoleId",
                table: "Syains",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Syains_BushoId",
                table: "Syains",
                column: "BushoId");

            migrationBuilder.CreateIndex(
                name: "IX_Syains_RoleId",
                table: "Syains",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Syains_Bushoes_BushoId",
                table: "Syains",
                column: "BushoId",
                principalTable: "Bushoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Syains_Roles_RoleId",
                table: "Syains",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
