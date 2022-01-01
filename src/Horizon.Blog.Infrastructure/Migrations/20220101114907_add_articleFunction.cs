using Microsoft.EntityFrameworkCore.Migrations;

namespace Horizon.Blog.Infrastructure.Migrations
{
    public partial class add_articleFunction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "article_id",
                table: "star");

            migrationBuilder.DropColumn(
                name: "article_id",
                table: "review");

            migrationBuilder.AddColumn<string>(
                name: "ArticleFunctionId",
                table: "star",
                type: "character varying(36)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "article_function_id",
                table: "review",
                type: "character varying(36)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "article_function",
                columns: table => new
                {
                    id = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: false),
                    article_id = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_article_function", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_star_ArticleFunctionId",
                table: "star",
                column: "ArticleFunctionId");

            migrationBuilder.CreateIndex(
                name: "IX_review_article_function_id",
                table: "review",
                column: "article_function_id");

            migrationBuilder.AddForeignKey(
                name: "FK_review_article_function_article_function_id",
                table: "review",
                column: "article_function_id",
                principalTable: "article_function",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_star_article_function_ArticleFunctionId",
                table: "star",
                column: "ArticleFunctionId",
                principalTable: "article_function",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_review_article_function_article_function_id",
                table: "review");

            migrationBuilder.DropForeignKey(
                name: "FK_star_article_function_ArticleFunctionId",
                table: "star");

            migrationBuilder.DropTable(
                name: "article_function");

            migrationBuilder.DropIndex(
                name: "IX_star_ArticleFunctionId",
                table: "star");

            migrationBuilder.DropIndex(
                name: "IX_review_article_function_id",
                table: "review");

            migrationBuilder.DropColumn(
                name: "ArticleFunctionId",
                table: "star");

            migrationBuilder.DropColumn(
                name: "article_function_id",
                table: "review");

            migrationBuilder.AddColumn<string>(
                name: "article_id",
                table: "star",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "article_id",
                table: "review",
                type: "text",
                nullable: true);
        }
    }
}
