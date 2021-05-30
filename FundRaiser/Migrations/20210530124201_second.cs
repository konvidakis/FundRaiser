using Microsoft.EntityFrameworkCore.Migrations;

namespace FundRaiser.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TimeStamps",
                table: "ProjectPosts",
                newName: "TimeStamp");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TimeStamp",
                table: "ProjectPosts",
                newName: "TimeStamps");
        }
    }
}
