using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class otpattributeinaccounttable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Education_University_universityid",
                table: "Education");

            migrationBuilder.AlterColumn<int>(
                name: "universityid",
                table: "Education",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "activeTime",
                table: "Accounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "otp",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "otpIsActive",
                table: "Accounts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Education_University_universityid",
                table: "Education",
                column: "universityid",
                principalTable: "University",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Education_University_universityid",
                table: "Education");

            migrationBuilder.DropColumn(
                name: "activeTime",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "otp",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "otpIsActive",
                table: "Accounts");

            migrationBuilder.AlterColumn<int>(
                name: "universityid",
                table: "Education",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Education_University_universityid",
                table: "Education",
                column: "universityid",
                principalTable: "University",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
