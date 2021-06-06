using Microsoft.EntityFrameworkCore.Migrations;

namespace FundRaiser.Migrations
{
    public partial class fourth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "ProjectPosts");

            migrationBuilder.RenameColumn(
                name: "Photo",
                table: "ProjectPosts",
                newName: "Multimedia");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Multimedia",
                table: "ProjectPosts",
                newName: "Photo");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "ProjectPosts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
