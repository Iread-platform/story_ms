using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace iread_story.Migrations
{
    public partial class initMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stories",
                columns: table => new
                {
                    StoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "text", nullable: true),
                    ReleaseDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    StoryLevel = table.Column<int>(type: "int", nullable: false),
                    Writer = table.Column<string>(type: "text", nullable: true),
                    CoverId = table.Column<int>(type: "int", nullable: false),
                    AudioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stories", x => x.StoryId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stories");
        }
    }
}
