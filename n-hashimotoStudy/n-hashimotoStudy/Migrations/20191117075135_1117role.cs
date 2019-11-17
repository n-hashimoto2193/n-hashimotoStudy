using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace nhashimotoStudy.Migrations
{
    public partial class _1117role : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Syains_Roles_RoleId",
                table: "Syains");

            migrationBuilder.AlterColumn<long>(
                name: "RoleId",
                table: "Syains",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Syains_Roles_RoleId",
                table: "Syains",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Syains_Roles_RoleId",
                table: "Syains");

            migrationBuilder.AlterColumn<long>(
                name: "RoleId",
                table: "Syains",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddForeignKey(
                name: "FK_Syains_Roles_RoleId",
                table: "Syains",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
