using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class accountroleandaccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    idROle = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nama_role = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.idROle);
                });

            migrationBuilder.CreateTable(
                name: "accountRoles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    idRole = table.Column<int>(type: "int", nullable: false),
                    accountNIK = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    roleidROle = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_accountRoles", x => x.id);
                    table.ForeignKey(
                        name: "FK_accountRoles_Accounts_accountNIK",
                        column: x => x.accountNIK,
                        principalTable: "Accounts",
                        principalColumn: "NIK",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_accountRoles_roles_roleidROle",
                        column: x => x.roleidROle,
                        principalTable: "roles",
                        principalColumn: "idROle",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_accountRoles_accountNIK",
                table: "accountRoles",
                column: "accountNIK");

            migrationBuilder.CreateIndex(
                name: "IX_accountRoles_roleidROle",
                table: "accountRoles",
                column: "roleidROle");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "accountRoles");

            migrationBuilder.DropTable(
                name: "roles");
        }
    }
}
