using Microsoft.EntityFrameworkCore.Migrations;

namespace SimaxCrm.Data.Migrations
{
    public partial class addPriceHubbleProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CurrentApiCount",
                table: "Company",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsConnectPriceHubble",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentApiCount",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "IsConnectPriceHubble",
                table: "AspNetUsers");
        }
    }
}
