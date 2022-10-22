using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortfolioProject.Data.Migrations
{
    public partial class AddedCelebrationsAndCeremonies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CelebrationsAndCeremonies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CelebrationsAndCeremonies", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CelebrationsAndCeremonies");
        }
    }
}
