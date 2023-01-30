using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortfolioProject.Data.Migrations
{
    public partial class AddedRSVP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RSVPForms",
                columns: table => new
                {
                    RSVPId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConfirmedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RSVPResponse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateSubmitted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EventId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RSVPForms", x => x.RSVPId);
                    table.ForeignKey(
                        name: "FK_RSVPForms_EventForms_EventId",
                        column: x => x.EventId,
                        principalTable: "EventForms",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_RSVPForms_EventId",
                table: "RSVPForms",
                column: "EventId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RSVPForms");
        }
    }
}
