using Microsoft.EntityFrameworkCore.Migrations;

namespace API52.Migrations
{
    public partial class renameuni : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "tb_M_University",
                newName: "UniversityName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UniversityName",
                table: "tb_M_University",
                newName: "Name");
        }
    }
}
