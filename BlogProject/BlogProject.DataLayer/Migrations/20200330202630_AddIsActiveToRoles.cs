using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogProject.DataLayer.Migrations
{
    public partial class AddIsActiveToRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "UserRoles",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "UserRoles");
        }
    }
}
