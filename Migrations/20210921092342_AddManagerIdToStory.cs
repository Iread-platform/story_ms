using Microsoft.EntityFrameworkCore.Migrations;

namespace iread_story.Migrations
{
    public partial class AddManagerIdToStory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ManagerId",
                table: "Stories",
                type: "text",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "Stories");
        }
    }
}
