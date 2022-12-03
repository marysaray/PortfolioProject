using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortfolioProject.Data.Migrations
{
    public partial class AddedUploadFiles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoUrl",
                table: "GreetingForms",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoUrl",
                table: "GreetingForms");
        }
    }
}
