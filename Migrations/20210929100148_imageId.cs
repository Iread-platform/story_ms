using Microsoft.EntityFrameworkCore.Migrations;

namespace iread_story.Migrations
{
    public partial class imageId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "Pages",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Pages");
        }
    }
}
