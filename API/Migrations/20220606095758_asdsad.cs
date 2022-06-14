using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class asdsad : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_accountRoles_Accounts_nik",
                table: "accountRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_accountRoles",
                table: "accountRoles");

            migrationBuilder.AlterColumn<string>(
                name: "nik",
                table: "accountRoles",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "accountRoles",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_accountRoles",
                table: "accountRoles",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_accountRoles_nik",
                table: "accountRoles",
                column: "nik");

            migrationBuilder.AddForeignKey(
                name: "FK_accountRoles_Accounts_nik",
                table: "accountRoles",
                column: "nik",
                principalTable: "Accounts",
                principalColumn: "NIK",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_accountRoles_Accounts_nik",
                table: "accountRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_accountRoles",
                table: "accountRoles");

            migrationBuilder.DropIndex(
                name: "IX_accountRoles_nik",
                table: "accountRoles");

            migrationBuilder.DropColumn(
                name: "id",
                table: "accountRoles");

            migrationBuilder.AlterColumn<string>(
                name: "nik",
                table: "accountRoles",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_accountRoles",
                table: "accountRoles",
                columns: new[] { "nik", "idRole" });

            migrationBuilder.AddForeignKey(
                name: "FK_accountRoles_Accounts_nik",
                table: "accountRoles",
                column: "nik",
                principalTable: "Accounts",
                principalColumn: "NIK",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
