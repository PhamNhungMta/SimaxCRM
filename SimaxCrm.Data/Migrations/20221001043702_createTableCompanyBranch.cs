using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SimaxCrm.Data.Migrations
{
    public partial class createTableCompanyBranch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BranchId",
                table: "Project",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyId",
                table: "Project",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BranchId",
                table: "Product",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyId",
                table: "Product",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BranchId",
                table: "Message",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyId",
                table: "Message",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BranchId",
                table: "Location",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyId",
                table: "Location",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BranchId",
                table: "LeadType",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyId",
                table: "LeadType",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BranchId",
                table: "LeadTag",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyId",
                table: "LeadTag",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BranchId",
                table: "LeadSource",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyId",
                table: "LeadSource",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BranchId",
                table: "LeadRemarks",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyId",
                table: "LeadRemarks",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BranchId",
                table: "LeadOrder",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyId",
                table: "LeadOrder",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BranchId",
                table: "LeadAutoAssign",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyId",
                table: "LeadAutoAssign",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BranchId",
                table: "Lead",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyId",
                table: "Lead",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BranchId",
                table: "Invoice",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyId",
                table: "Invoice",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BranchId",
                table: "InventoryTag",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyId",
                table: "InventoryTag",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BranchId",
                table: "EmailSetup",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyId",
                table: "EmailSetup",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BranchId",
                table: "CustomerQuery",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyId",
                table: "CustomerQuery",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BranchId",
                table: "City",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyId",
                table: "City",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BranchId",
                table: "Category",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyId",
                table: "Category",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BranchId",
                table: "CallLog",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyId",
                table: "CallLog",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BranchId",
                table: "Attachment",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyId",
                table: "Attachment",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BranchId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Branch",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CompanyId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 200, nullable: true),
                    Country = table.Column<string>(maxLength: 200, nullable: true),
                    Region = table.Column<string>(maxLength: 200, nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branch", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Branch_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Branch_CompanyId",
                table: "Branch",
                column: "CompanyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Branch");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "Message");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Message");

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "LeadType");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "LeadType");

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "LeadTag");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "LeadTag");

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "LeadSource");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "LeadSource");

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "LeadRemarks");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "LeadRemarks");

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "LeadOrder");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "LeadOrder");

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "LeadAutoAssign");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "LeadAutoAssign");

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "Lead");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Lead");

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "InventoryTag");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "InventoryTag");

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "EmailSetup");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "EmailSetup");

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "CustomerQuery");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "CustomerQuery");

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "City");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "City");

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "CallLog");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "CallLog");

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "Attachment");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Attachment");

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "AspNetUsers");
        }
    }
}
