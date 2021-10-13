using Microsoft.EntityFrameworkCore.Migrations;

namespace iread_story.Migrations
{
    public partial class story_language_connection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Stories_LanguageId",
                table: "Stories",
                column: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stories_Languages_LanguageId",
                table: "Stories",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "LanguageId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stories_Languages_LanguageId",
                table: "Stories");

            migrationBuilder.DropIndex(
                name: "IX_Stories_LanguageId",
                table: "Stories");
        }
    }
}
