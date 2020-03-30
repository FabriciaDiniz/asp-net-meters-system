using Microsoft.EntityFrameworkCore.Migrations;

namespace MetersDesktopApp.Migrations
{
    public partial class migration0002_mod_requerimenos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SerialNumber",
                table: "meters",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SerialNumber",
                table: "meters");
        }
    }
}
