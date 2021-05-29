using Microsoft.EntityFrameworkCore.Migrations;

namespace iread_story.Migrations
{
    public partial class additionalFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Stories",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "Stories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StoryLevel",
                table: "Stories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Writer",
                table: "Stories",
                type: "text",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Stories");

            migrationBuilder.DropColumn(
                name: "StoryLevel",
                table: "Stories");

            migrationBuilder.DropColumn(
                name: "Writer",
                table: "Stories");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Stories",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
