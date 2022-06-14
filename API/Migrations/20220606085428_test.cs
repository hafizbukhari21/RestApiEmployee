using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_accountRoles_Accounts_accountNIK",
                table: "accountRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_accountRoles_roles_roleidROle",
                table: "accountRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_accountRoles",
                table: "accountRoles");

            migrationBuilder.DropIndex(
                name: "IX_accountRoles_accountNIK",
                table: "accountRoles");

            migrationBuilder.DropIndex(
                name: "IX_accountRoles_roleidROle",
                table: "accountRoles");

            migrationBuilder.DropColumn(
                name: "id",
                table: "accountRoles");

            migrationBuilder.DropColumn(
                name: "accountNIK",
                table: "accountRoles");

            migrationBuilder.DropColumn(
                name: "roleidROle",
                table: "accountRoles");

            migrationBuilder.RenameColumn(
                name: "idROle",
                table: "roles",
                newName: "idRole");

            migrationBuilder.AlterColumn<string>(
                name: "nik",
                table: "accountRoles",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_accountRoles",
                table: "accountRoles",
                columns: new[] { "nik", "idRole" });

            migrationBuilder.CreateIndex(
                name: "IX_accountRoles_idRole",
                table: "accountRoles",
                column: "idRole");

            migrationBuilder.AddForeignKey(
                name: "FK_accountRoles_Accounts_nik",
                table: "accountRoles",
                column: "nik",
                principalTable: "Accounts",
                principalColumn: "NIK",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_accountRoles_roles_idRole",
                table: "accountRoles",
                column: "idRole",
                principalTable: "roles",
                principalColumn: "idRole",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_accountRoles_Accounts_nik",
                table: "accountRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_accountRoles_roles_idRole",
                table: "accountRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_accountRoles",
                table: "accountRoles");

            migrationBuilder.DropIndex(
                name: "IX_accountRoles_idRole",
                table: "accountRoles");

            migrationBuilder.RenameColumn(
                name: "idRole",
                table: "roles",
                newName: "idROle");

            migrationBuilder.AlterColumn<string>(
                name: "nik",
                table: "accountRoles",
                type: "nvarchar(max)",
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

            migrationBuilder.AddColumn<string>(
                name: "accountNIK",
                table: "accountRoles",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "roleidROle",
                table: "accountRoles",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_accountRoles",
                table: "accountRoles",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_accountRoles_accountNIK",
                table: "accountRoles",
                column: "accountNIK");

            migrationBuilder.CreateIndex(
                name: "IX_accountRoles_roleidROle",
                table: "accountRoles",
                column: "roleidROle");

            migrationBuilder.AddForeignKey(
                name: "FK_accountRoles_Accounts_accountNIK",
                table: "accountRoles",
                column: "accountNIK",
                principalTable: "Accounts",
                principalColumn: "NIK",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_accountRoles_roles_roleidROle",
                table: "accountRoles",
                column: "roleidROle",
                principalTable: "roles",
                principalColumn: "idROle",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
