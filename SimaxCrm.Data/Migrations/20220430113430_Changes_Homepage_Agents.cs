using Microsoft.EntityFrameworkCore.Migrations;

namespace SimaxCrm.Data.Migrations
{
    public partial class Changes_Homepage_Agents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ShowInHomePage",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShowInHomePage",
                table: "AspNetUsers");
        }
    }
}
