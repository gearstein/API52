using Microsoft.EntityFrameworkCore.Migrations;

namespace API52.Migrations
{
    public partial class accrole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_M_Profilling_tb_M_Account_NIK",
                table: "tb_M_Profilling");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_M_Profilling_tb_M_Education_EducationId",
                table: "tb_M_Profilling");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_M_Profilling",
                table: "tb_M_Profilling");

            migrationBuilder.RenameTable(
                name: "tb_M_Profilling",
                newName: "tb_Tr_Profilling");

            migrationBuilder.RenameIndex(
                name: "IX_tb_M_Profilling_EducationId",
                table: "tb_Tr_Profilling",
                newName: "IX_tb_Tr_Profilling_EducationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_Tr_Profilling",
                table: "tb_Tr_Profilling",
                column: "NIK");

            migrationBuilder.CreateTable(
                name: "tb_M_Role",
                columns: table => new
                {
                    RoleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_M_Role", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "tb_Tr_AccountRole",
                columns: table => new
                {
                    NIK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Tr_AccountRole", x => new { x.NIK, x.RoleID });
                    table.ForeignKey(
                        name: "FK_tb_Tr_AccountRole_tb_M_Account_NIK",
                        column: x => x.NIK,
                        principalTable: "tb_M_Account",
                        principalColumn: "NIK",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_Tr_AccountRole_tb_M_Role_RoleID",
                        column: x => x.RoleID,
                        principalTable: "tb_M_Role",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_Tr_AccountRole_RoleID",
                table: "tb_Tr_AccountRole",
                column: "RoleID");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_Tr_Profilling_tb_M_Account_NIK",
                table: "tb_Tr_Profilling",
                column: "NIK",
                principalTable: "tb_M_Account",
                principalColumn: "NIK",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_Tr_Profilling_tb_M_Education_EducationId",
                table: "tb_Tr_Profilling",
                column: "EducationId",
                principalTable: "tb_M_Education",
                principalColumn: "EducationId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_Tr_Profilling_tb_M_Account_NIK",
                table: "tb_Tr_Profilling");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_Tr_Profilling_tb_M_Education_EducationId",
                table: "tb_Tr_Profilling");

            migrationBuilder.DropTable(
                name: "tb_Tr_AccountRole");

            migrationBuilder.DropTable(
                name: "tb_M_Role");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_Tr_Profilling",
                table: "tb_Tr_Profilling");

            migrationBuilder.RenameTable(
                name: "tb_Tr_Profilling",
                newName: "tb_M_Profilling");

            migrationBuilder.RenameIndex(
                name: "IX_tb_Tr_Profilling_EducationId",
                table: "tb_M_Profilling",
                newName: "IX_tb_M_Profilling_EducationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_M_Profilling",
                table: "tb_M_Profilling",
                column: "NIK");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_M_Profilling_tb_M_Account_NIK",
                table: "tb_M_Profilling",
                column: "NIK",
                principalTable: "tb_M_Account",
                principalColumn: "NIK",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_M_Profilling_tb_M_Education_EducationId",
                table: "tb_M_Profilling",
                column: "EducationId",
                principalTable: "tb_M_Education",
                principalColumn: "EducationId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
