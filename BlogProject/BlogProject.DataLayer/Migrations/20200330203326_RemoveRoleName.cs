using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogProject.DataLayer.Migrations
{
    public partial class RemoveRoleName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoleName",
                table: "UserRoles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoleName",
                table: "UserRoles",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
