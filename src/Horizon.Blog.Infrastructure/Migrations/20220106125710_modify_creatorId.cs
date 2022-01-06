using Microsoft.EntityFrameworkCore.Migrations;

namespace Horizon.Blog.Infrastructure.Migrations
{
    public partial class modify_creatorId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "creator_id",
                table: "star",
                newName: "creator_ip");

            migrationBuilder.RenameColumn(
                name: "creator_id",
                table: "review",
                newName: "creator_ip");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "creator_ip",
                table: "star",
                newName: "creator_id");

            migrationBuilder.RenameColumn(
                name: "creator_ip",
                table: "review",
                newName: "creator_id");
        }
    }
}
