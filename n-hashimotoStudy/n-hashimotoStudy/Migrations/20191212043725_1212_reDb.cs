using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace nhashimotoStudy.Migrations
{
    public partial class _1212_reDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "RecordingDateEvidence",
                table: "Kintais",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ShuttaiDivision",
                table: "Kintais",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "WorkDate",
                table: "Kintais",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RecordingDateEvidence",
                table: "Kintais");

            migrationBuilder.DropColumn(
                name: "ShuttaiDivision",
                table: "Kintais");

            migrationBuilder.DropColumn(
                name: "WorkDate",
                table: "Kintais");
        }
    }
}
