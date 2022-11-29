using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortfolioProject.Data.Migrations
{
    public partial class AddedGreetingForm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GreetingForms",
                columns: table => new
                {
                    GreetingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GreetingForms", x => x.GreetingId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GreetingForms");
        }
    }
}
