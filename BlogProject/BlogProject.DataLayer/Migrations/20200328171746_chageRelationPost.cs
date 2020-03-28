using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogProject.DataLayer.Migrations
{
    public partial class chageRelationPost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_PostGroup_PostGroupGroupID",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_PostGroupGroupID",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "GroupID",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "PostGroupGroupID",
                table: "Posts");

            migrationBuilder.CreateTable(
                name: "PostToPostGroup",
                columns: table => new
                {
                    PPG_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostId = table.Column<int>(nullable: false),
                    GroupID = table.Column<int>(nullable: false),
                    PostGroupGroupID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostToPostGroup", x => x.PPG_Id);
                    table.ForeignKey(
                        name: "FK_PostToPostGroup_PostGroup_PostGroupGroupID",
                        column: x => x.PostGroupGroupID,
                        principalTable: "PostGroup",
                        principalColumn: "GroupID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PostToPostGroup_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "PostID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PostToPostGroup_PostGroupGroupID",
                table: "PostToPostGroup",
                column: "PostGroupGroupID");

            migrationBuilder.CreateIndex(
                name: "IX_PostToPostGroup_PostId",
                table: "PostToPostGroup",
                column: "PostId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PostToPostGroup");

            migrationBuilder.AddColumn<int>(
                name: "GroupID",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PostGroupGroupID",
                table: "Posts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_PostGroupGroupID",
                table: "Posts",
                column: "PostGroupGroupID");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_PostGroup_PostGroupGroupID",
                table: "Posts",
                column: "PostGroupGroupID",
                principalTable: "PostGroup",
                principalColumn: "GroupID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
