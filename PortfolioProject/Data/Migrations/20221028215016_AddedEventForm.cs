using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortfolioProject.Data.Migrations
{
    public partial class AddedEventForm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EventForms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EventById = table.Column<int>(type: "int", nullable: true),
                    CategoryEventId = table.Column<int>(type: "int", nullable: true),
                    LocationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventForms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventForms_Categories_CategoryEventId",
                        column: x => x.CategoryEventId,
                        principalTable: "Categories",
                        principalColumn: "EventId");
                    table.ForeignKey(
                        name: "FK_EventForms_Contacts_EventById",
                        column: x => x.EventById,
                        principalTable: "Contacts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EventForms_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "LocationId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventForms_CategoryEventId",
                table: "EventForms",
                column: "CategoryEventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventForms_EventById",
                table: "EventForms",
                column: "EventById");

            migrationBuilder.CreateIndex(
                name: "IX_EventForms_LocationId",
                table: "EventForms",
                column: "LocationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventForms");
        }
    }
}
