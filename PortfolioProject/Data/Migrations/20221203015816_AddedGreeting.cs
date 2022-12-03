using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortfolioProject.Data.Migrations
{
    public partial class AddedGreeting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GreetingTypeGreetingId",
                table: "GreetingForms",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GreetingForms_GreetingTypeGreetingId",
                table: "GreetingForms",
                column: "GreetingTypeGreetingId");

            migrationBuilder.AddForeignKey(
                name: "FK_GreetingForms_GreetingTypes_GreetingTypeGreetingId",
                table: "GreetingForms",
                column: "GreetingTypeGreetingId",
                principalTable: "GreetingTypes",
                principalColumn: "GreetingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GreetingForms_GreetingTypes_GreetingTypeGreetingId",
                table: "GreetingForms");

            migrationBuilder.DropIndex(
                name: "IX_GreetingForms_GreetingTypeGreetingId",
                table: "GreetingForms");

            migrationBuilder.DropColumn(
                name: "GreetingTypeGreetingId",
                table: "GreetingForms");
        }
    }
}