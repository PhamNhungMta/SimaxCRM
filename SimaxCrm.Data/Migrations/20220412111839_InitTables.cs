using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SimaxCrm.Data.Migrations
{
    public partial class InitTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Tid = table.Column<int>(nullable: false),
                    AgentCount = table.Column<int>(nullable: true),
                    QaCount = table.Column<int>(nullable: true),
                    AccountCount = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    ImagePath = table.Column<string>(nullable: true),
                    Experience = table.Column<string>(nullable: true),
                    WorkingEmployees = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    UserRank = table.Column<int>(nullable: false),
                    CompanyName = table.Column<string>(nullable: true),
                    RERANo = table.Column<string>(nullable: true),
                    News = table.Column<string>(nullable: true),
                    LanguageSpeak = table.Column<string>(nullable: true),
                    Specializations = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Attachment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tid = table.Column<int>(nullable: false),
                    UploadCategoryId = table.Column<int>(nullable: true),
                    FilePath = table.Column<string>(nullable: true),
                    FileName = table.Column<string>(nullable: true),
                    FileType = table.Column<string>(nullable: true),
                    FileSize = table.Column<long>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    TempId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tid = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tid = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmailSent",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tid = table.Column<int>(nullable: false),
                    FromEmail = table.Column<string>(nullable: false),
                    ToEmail = table.Column<string>(nullable: false),
                    SendBy = table.Column<string>(nullable: true),
                    IsSent = table.Column<bool>(nullable: false),
                    Subject = table.Column<string>(nullable: false),
                    Body = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailSent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmailSetup",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tid = table.Column<int>(nullable: false),
                    Email = table.Column<string>(maxLength: 200, nullable: false),
                    SmtpServer = table.Column<string>(maxLength: 100, nullable: false),
                    SmtpPort = table.Column<int>(nullable: false),
                    UseSsl = table.Column<string>(maxLength: 5, nullable: false),
                    Username = table.Column<string>(maxLength: 200, nullable: true),
                    Password = table.Column<string>(maxLength: 200, nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    IncommingMailServer = table.Column<string>(nullable: false),
                    IncommingMailPort = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailSetup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InventoryTag",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tid = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryTag", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LeadRemarks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tid = table.Column<int>(nullable: false),
                    Status = table.Column<string>(maxLength: 200, nullable: true),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeadRemarks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LeadSource",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tid = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeadSource", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LeadTag",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tid = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeadTag", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LeadType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tid = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeadType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tid = table.Column<int>(nullable: false),
                    CityId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OtpLog",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tid = table.Column<int>(nullable: false),
                    SentType = table.Column<int>(nullable: false),
                    SentTo = table.Column<string>(nullable: true),
                    Pin = table.Column<string>(nullable: true),
                    IsUsed = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    VerifiedDate = table.Column<DateTime>(nullable: true),
                    ApiResponse = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtpLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Seo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tid = table.Column<int>(nullable: false),
                    SeoPage = table.Column<int>(nullable: false),
                    PageTitle = table.Column<string>(nullable: false),
                    MetaKeyword = table.Column<string>(nullable: false),
                    MetaDescription = table.Column<string>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Slider",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tid = table.Column<int>(nullable: false),
                    ImagePath = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slider", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Society",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tid = table.Column<int>(nullable: false),
                    CityId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Society", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SystemSetup",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tid = table.Column<int>(nullable: false),
                    CompanyName = table.Column<string>(maxLength: 200, nullable: false),
                    AddressPlain = table.Column<string>(maxLength: 200, nullable: true),
                    Address = table.Column<string>(maxLength: 200, nullable: true),
                    AddressLat = table.Column<string>(maxLength: 200, nullable: true),
                    AddressLng = table.Column<string>(maxLength: 200, nullable: true),
                    CompanyEmail = table.Column<string>(maxLength: 200, nullable: true),
                    CompanyContact = table.Column<string>(maxLength: 200, nullable: true),
                    CompanyGstNumber = table.Column<string>(maxLength: 200, nullable: true),
                    TaxPercent = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Currency = table.Column<string>(maxLength: 50, nullable: false),
                    CurrencySymbol = table.Column<string>(maxLength: 50, nullable: false),
                    CompanyLogo = table.Column<string>(maxLength: 200, nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemSetup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Template",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tid = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Text = table.Column<string>(nullable: false),
                    Subject = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Template", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TempLead",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tid = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 20, nullable: false),
                    Email = table.Column<string>(maxLength: 200, nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TempLead", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UploadCategory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tid = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UploadCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LeadAutoAssign",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tid = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeadAutoAssign", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeadAutoAssign_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Message",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tid = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    Body = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedById = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Message_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PaymentLog",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tid = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TransId = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentLog_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Wallet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tid = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    TotalPoints = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    PurchaseCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wallet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wallet_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubCategory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tid = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubCategory_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lead",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tid = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 20, nullable: false),
                    AlternatePhoneNumber = table.Column<string>(maxLength: 20, nullable: true),
                    ReferPhoneNumber = table.Column<string>(maxLength: 20, nullable: true),
                    LeadType = table.Column<string>(maxLength: 200, nullable: false),
                    Email = table.Column<string>(maxLength: 200, nullable: true),
                    Address = table.Column<string>(maxLength: 500, nullable: true),
                    PropertyCategoryId = table.Column<int>(nullable: false),
                    PropertySubcategoryId = table.Column<int>(nullable: false),
                    CityId = table.Column<int>(nullable: false),
                    LocationId = table.Column<int>(nullable: false),
                    SocietyId = table.Column<int>(nullable: false),
                    ReferName = table.Column<string>(maxLength: 200, nullable: true),
                    BudgetMin = table.Column<decimal>(nullable: false),
                    BudgetMax = table.Column<decimal>(nullable: false),
                    City = table.Column<string>(maxLength: 200, nullable: true),
                    State = table.Column<string>(maxLength: 200, nullable: true),
                    Country = table.Column<string>(maxLength: 200, nullable: true),
                    PostalCode = table.Column<string>(maxLength: 20, nullable: true),
                    LeadSourceId = table.Column<int>(nullable: false),
                    LastContact = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    LeadStatus = table.Column<string>(maxLength: 50, nullable: true),
                    DeletedById = table.Column<string>(nullable: true),
                    DeletedDate = table.Column<DateTime>(nullable: true),
                    IsPurchased = table.Column<bool>(nullable: false),
                    PurchasedCount = table.Column<int>(nullable: true),
                    AssignedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    AlertDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lead", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lead_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Lead_LeadSource_LeadSourceId",
                        column: x => x.LeadSourceId,
                        principalTable: "LeadSource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lead_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tid = table.Column<int>(nullable: false),
                    PropertyCategoryId = table.Column<int>(nullable: false),
                    PropertySubcategoryId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    MetaTag = table.Column<string>(nullable: true),
                    MetaDescription = table.Column<string>(nullable: true),
                    CityId = table.Column<int>(nullable: false),
                    LocationId = table.Column<int>(nullable: false),
                    SocietyId = table.Column<int>(nullable: false),
                    AddressPlain = table.Column<string>(maxLength: 500, nullable: true),
                    Address = table.Column<string>(maxLength: 500, nullable: true),
                    AddressLat = table.Column<string>(nullable: true),
                    AddressLng = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    PropertyDimType = table.Column<string>(nullable: true),
                    TotalArea = table.Column<decimal>(nullable: false),
                    PropertyPrice = table.Column<decimal>(nullable: false),
                    TotalPropertyPrice = table.Column<string>(nullable: true),
                    ConstructionStatus = table.Column<string>(nullable: true),
                    Bedroom = table.Column<string>(nullable: true),
                    Parking = table.Column<string>(nullable: true),
                    Bathrooms = table.Column<string>(nullable: true),
                    MaintenanceCharges = table.Column<string>(nullable: true),
                    TotalMaintenanceCharges = table.Column<string>(nullable: true),
                    CentralizedAc = table.Column<bool>(nullable: false),
                    SecurityGuard = table.Column<bool>(nullable: false),
                    FireSafety = table.Column<bool>(nullable: false),
                    CctvCamera = table.Column<bool>(nullable: false),
                    Lift = table.Column<bool>(nullable: false),
                    club = table.Column<bool>(nullable: false),
                    SwimmingPool = table.Column<bool>(nullable: false),
                    GardenArea = table.Column<bool>(nullable: false),
                    KidsPlayArea = table.Column<bool>(nullable: false),
                    Gym = table.Column<bool>(nullable: false),
                    PropertyFloor = table.Column<string>(nullable: true),
                    Furnished = table.Column<string>(nullable: true),
                    MaxSaleRate = table.Column<decimal>(nullable: false),
                    OwnerName = table.Column<string>(nullable: true),
                    OwnerPhoneNumber = table.Column<string>(nullable: true),
                    OwnerEmailId = table.Column<string>(nullable: true),
                    Source = table.Column<string>(nullable: true),
                    ReferenceName = table.Column<string>(nullable: true),
                    ReferenceNumber = table.Column<string>(nullable: true),
                    MainImage = table.Column<string>(maxLength: 1000, nullable: true),
                    EmbadVideo = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    ActiveStatus = table.Column<int>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    ViewCount = table.Column<int>(nullable: false),
                    RecIdOld = table.Column<int>(nullable: false),
                    VideoLink = table.Column<string>(maxLength: 300, nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    AlertDate = table.Column<DateTime>(nullable: true),
                    TotalBlocks = table.Column<string>(nullable: true),
                    TotalFloors = table.Column<string>(nullable: true),
                    TotalFlats = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Project_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Project_Society_SocietyId",
                        column: x => x.SocietyId,
                        principalTable: "Society",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LeadAutoAssignSourceMapping",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tid = table.Column<int>(nullable: false),
                    LeadAutoAssignId = table.Column<int>(nullable: false),
                    LeadSourceId = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeadAutoAssignSourceMapping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeadAutoAssignSourceMapping_LeadAutoAssign_LeadAutoAssignId",
                        column: x => x.LeadAutoAssignId,
                        principalTable: "LeadAutoAssign",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LeadAutoAssignSourceMapping_LeadSource_LeadSourceId",
                        column: x => x.LeadSourceId,
                        principalTable: "LeadSource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MessageDetail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tid = table.Column<int>(nullable: false),
                    MessageId = table.Column<int>(nullable: false),
                    SentToUserId = table.Column<string>(nullable: true),
                    AlertStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MessageDetail_Message_MessageId",
                        column: x => x.MessageId,
                        principalTable: "Message",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MessageDetail_AspNetUsers_SentToUserId",
                        column: x => x.SentToUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LeadOrder",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tid = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    PaymentLogId = table.Column<int>(nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalLeads = table.Column<int>(nullable: false),
                    LeadOrderStatus = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeadOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeadOrder_PaymentLog_PaymentLogId",
                        column: x => x.PaymentLogId,
                        principalTable: "PaymentLog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LeadOrder_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WalletDetail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tid = table.Column<int>(nullable: false),
                    WalletId = table.Column<int>(nullable: false),
                    PaymentLogId = table.Column<int>(nullable: false),
                    Debit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Credit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WalletDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WalletDetail_PaymentLog_PaymentLogId",
                        column: x => x.PaymentLogId,
                        principalTable: "PaymentLog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WalletDetail_Wallet_WalletId",
                        column: x => x.WalletId,
                        principalTable: "Wallet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CallLog",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tid = table.Column<int>(nullable: false),
                    LeadId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    StartTime = table.Column<TimeSpan>(nullable: false),
                    EndTime = table.Column<TimeSpan>(nullable: false),
                    Status = table.Column<string>(nullable: false),
                    Remarks = table.Column<string>(nullable: false),
                    Message = table.Column<string>(nullable: false),
                    AlertDate = table.Column<DateTime>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    AlertStatus = table.Column<int>(nullable: false),
                    AlertStatusFcm = table.Column<int>(nullable: false),
                    InvoiceId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CallLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CallLog_Lead_LeadId",
                        column: x => x.LeadId,
                        principalTable: "Lead",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CallLog_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tid = table.Column<int>(nullable: false),
                    LeadId = table.Column<int>(nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DiscountAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OtherCharges = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TaxPercent = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TaxAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GrandTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    OrderStatus = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoice_Lead_LeadId",
                        column: x => x.LeadId,
                        principalTable: "Lead",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LeadAutoAssignLog",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tid = table.Column<int>(nullable: false),
                    LeadId = table.Column<int>(nullable: false),
                    LeadSourceId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeadAutoAssignLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeadAutoAssignLog_Lead_LeadId",
                        column: x => x.LeadId,
                        principalTable: "Lead",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LeadAutoAssignLog_LeadSource_LeadSourceId",
                        column: x => x.LeadSourceId,
                        principalTable: "LeadSource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LeadAutoAssignLog_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LeadTagMapping",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tid = table.Column<int>(nullable: false),
                    LeadId = table.Column<int>(nullable: false),
                    LeadTagId = table.Column<int>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeadTagMapping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeadTagMapping_Lead_LeadId",
                        column: x => x.LeadId,
                        principalTable: "Lead",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LeadTagMapping_LeadTag_LeadTagId",
                        column: x => x.LeadTagId,
                        principalTable: "LeadTag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhoneCallLeadLog",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecId = table.Column<long>(nullable: false),
                    Tid = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    Date = table.Column<string>(nullable: true),
                    CallTime = table.Column<DateTime>(nullable: false),
                    Number = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    Duration = table.Column<int>(nullable: false),
                    IsNew = table.Column<int>(nullable: false),
                    CachedName = table.Column<string>(nullable: true),
                    CachedNumberType = table.Column<int>(nullable: false),
                    PhoneAccountId = table.Column<string>(nullable: true),
                    ViaNumber = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Contact = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LeadId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneCallLeadLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhoneCallLeadLog_Lead_LeadId",
                        column: x => x.LeadId,
                        principalTable: "Lead",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhoneCallLeadLog_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tcf",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tid = table.Column<int>(nullable: false),
                    LeadId = table.Column<int>(nullable: false),
                    Property = table.Column<string>(nullable: true),
                    Rate = table.Column<string>(nullable: true),
                    Size = table.Column<string>(nullable: true),
                    BSP = table.Column<string>(nullable: true),
                    OtherCharges = table.Column<string>(nullable: true),
                    BookingForm = table.Column<string>(nullable: true),
                    PaymentDetails = table.Column<string>(nullable: true),
                    OpsChecklist = table.Column<string>(nullable: true),
                    DiscountApproval = table.Column<string>(nullable: true),
                    AadharCard = table.Column<string>(nullable: true),
                    PanCard = table.Column<string>(nullable: true),
                    VoterID = table.Column<string>(nullable: true),
                    Passport = table.Column<string>(nullable: true),
                    BrokerageRate = table.Column<string>(nullable: true),
                    RoyaltyDiscount = table.Column<string>(nullable: true),
                    ReferralBrokerage = table.Column<string>(nullable: true),
                    FinalBrokerage = table.Column<string>(nullable: true),
                    EmployeeCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tcf", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tcf_Lead_LeadId",
                        column: x => x.LeadId,
                        principalTable: "Lead",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLog",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tid = table.Column<int>(nullable: false),
                    LeadId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    LogType = table.Column<string>(nullable: false),
                    LogRecId = table.Column<int>(nullable: false),
                    LogText = table.Column<string>(nullable: true),
                    LogStatus = table.Column<string>(nullable: true),
                    IsSuccess = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserLog_Lead_LeadId",
                        column: x => x.LeadId,
                        principalTable: "Lead",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserLog_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AttachmentProjectMapping",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tid = table.Column<int>(nullable: false),
                    ProjectId = table.Column<int>(nullable: false),
                    UploadCategoryId = table.Column<int>(nullable: true),
                    AttachmentId = table.Column<int>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttachmentProjectMapping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttachmentProjectMapping_Attachment_AttachmentId",
                        column: x => x.AttachmentId,
                        principalTable: "Attachment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttachmentProjectMapping_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttachmentProjectMapping_UploadCategory_UploadCategoryId",
                        column: x => x.UploadCategoryId,
                        principalTable: "UploadCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LeadProjectMapping",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tid = table.Column<int>(nullable: false),
                    LeadId = table.Column<int>(nullable: false),
                    ProjectId = table.Column<int>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeadProjectMapping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeadProjectMapping_Lead_LeadId",
                        column: x => x.LeadId,
                        principalTable: "Lead",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LeadProjectMapping_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tid = table.Column<int>(nullable: false),
                    PropertyCategoryId = table.Column<int>(nullable: false),
                    PropertySubcategoryId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    MetaTag = table.Column<string>(nullable: true),
                    MetaDescription = table.Column<string>(nullable: true),
                    CityId = table.Column<int>(nullable: false),
                    LocationId = table.Column<int>(nullable: false),
                    SocietyId = table.Column<int>(nullable: false),
                    AddressPlain = table.Column<string>(maxLength: 500, nullable: true),
                    Address = table.Column<string>(maxLength: 500, nullable: true),
                    AddressLat = table.Column<string>(nullable: true),
                    AddressLng = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    PropertyDimType = table.Column<string>(nullable: true),
                    TotalArea = table.Column<decimal>(nullable: false),
                    PropertyPrice = table.Column<decimal>(nullable: false),
                    TotalPropertyPrice = table.Column<string>(nullable: true),
                    ConstructionStatus = table.Column<string>(nullable: true),
                    Bedroom = table.Column<string>(nullable: true),
                    Parking = table.Column<string>(nullable: true),
                    Bathrooms = table.Column<string>(nullable: true),
                    MaintenanceCharges = table.Column<string>(nullable: true),
                    TotalMaintenanceCharges = table.Column<string>(nullable: true),
                    CentralizedAc = table.Column<bool>(nullable: false),
                    SecurityGuard = table.Column<bool>(nullable: false),
                    FireSafety = table.Column<bool>(nullable: false),
                    CctvCamera = table.Column<bool>(nullable: false),
                    Lift = table.Column<bool>(nullable: false),
                    club = table.Column<bool>(nullable: false),
                    SwimmingPool = table.Column<bool>(nullable: false),
                    GardenArea = table.Column<bool>(nullable: false),
                    KidsPlayArea = table.Column<bool>(nullable: false),
                    Gym = table.Column<bool>(nullable: false),
                    PropertyFloor = table.Column<string>(nullable: true),
                    Furnished = table.Column<string>(nullable: true),
                    MaxSaleRate = table.Column<decimal>(nullable: false),
                    OwnerName = table.Column<string>(nullable: true),
                    OwnerPhoneNumber = table.Column<string>(nullable: true),
                    OwnerEmailId = table.Column<string>(nullable: true),
                    Source = table.Column<string>(nullable: true),
                    ReferenceName = table.Column<string>(nullable: true),
                    ReferenceNumber = table.Column<string>(nullable: true),
                    MainImage = table.Column<string>(maxLength: 1000, nullable: true),
                    EmbadVideo = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    ActiveStatus = table.Column<int>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    ViewCount = table.Column<int>(nullable: false),
                    RecIdOld = table.Column<int>(nullable: false),
                    VideoLink = table.Column<string>(maxLength: 300, nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    AlertDate = table.Column<DateTime>(nullable: true),
                    ProjectId = table.Column<int>(nullable: true),
                    ImagePath1 = table.Column<string>(maxLength: 200, nullable: true),
                    ImagePath2 = table.Column<string>(maxLength: 200, nullable: true),
                    ImagePath3 = table.Column<string>(maxLength: 200, nullable: true),
                    ImagePath4 = table.Column<string>(maxLength: 200, nullable: true),
                    ImagePath5 = table.Column<string>(maxLength: 200, nullable: true),
                    ImagePath6 = table.Column<string>(maxLength: 200, nullable: true),
                    ImagePath7 = table.Column<string>(maxLength: 200, nullable: true),
                    ImagePath8 = table.Column<string>(maxLength: 200, nullable: true),
                    ImagePath9 = table.Column<string>(maxLength: 200, nullable: true),
                    ImagePath10 = table.Column<string>(maxLength: 200, nullable: true),
                    SubCategoryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Product_Society_SocietyId",
                        column: x => x.SocietyId,
                        principalTable: "Society",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_SubCategory_SubCategoryId",
                        column: x => x.SubCategoryId,
                        principalTable: "SubCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjectTagMapping",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tid = table.Column<int>(nullable: false),
                    ProjectId = table.Column<int>(nullable: false),
                    InventoryTagId = table.Column<int>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTagMapping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectTagMapping_InventoryTag_InventoryTagId",
                        column: x => x.InventoryTagId,
                        principalTable: "InventoryTag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectTagMapping_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LeadOrderDetail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tid = table.Column<int>(nullable: false),
                    LeadOrderId = table.Column<int>(nullable: false),
                    LeadId = table.Column<int>(nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    NewLeadId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeadOrderDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeadOrderDetail_Lead_LeadId",
                        column: x => x.LeadId,
                        principalTable: "Lead",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LeadOrderDetail_LeadOrder_LeadOrderId",
                        column: x => x.LeadOrderId,
                        principalTable: "LeadOrder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceDetail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tid = table.Column<int>(nullable: false),
                    InvoiceId = table.Column<int>(nullable: false),
                    ProductName = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Qty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    ActionType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceDetail_Invoice_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AttachmentProductMapping",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tid = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    UploadCategoryId = table.Column<int>(nullable: true),
                    AttachmentId = table.Column<int>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttachmentProductMapping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttachmentProductMapping_Attachment_AttachmentId",
                        column: x => x.AttachmentId,
                        principalTable: "Attachment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttachmentProductMapping_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttachmentProductMapping_UploadCategory_UploadCategoryId",
                        column: x => x.UploadCategoryId,
                        principalTable: "UploadCategory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CallLogProduct",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tid = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    StartTime = table.Column<TimeSpan>(nullable: false),
                    EndTime = table.Column<TimeSpan>(nullable: false),
                    Status = table.Column<string>(nullable: false),
                    Remarks = table.Column<string>(nullable: false),
                    Message = table.Column<string>(nullable: false),
                    AlertDate = table.Column<DateTime>(nullable: true),
                    AlertStatus = table.Column<int>(nullable: false),
                    AlertStatusFcm = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    InvoiceId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CallLogProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CallLogProduct_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CallLogProduct_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomerQuery",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tid = table.Column<int>(nullable: false),
                    ProjectId = table.Column<int>(nullable: true),
                    ProductId = table.Column<int>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    CustomerName = table.Column<string>(nullable: false),
                    CustomerPhone = table.Column<string>(nullable: false),
                    CustomerEmail = table.Column<string>(nullable: false),
                    CustomerMessage = table.Column<string>(nullable: false),
                    ProjectRelatedIds = table.Column<string>(nullable: true),
                    ProductRelatedIds = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerQuery", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerQuery_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomerQuery_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomerQuery_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InventoryTagMapping",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tid = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    InventoryTagId = table.Column<int>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryTagMapping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventoryTagMapping_InventoryTag_InventoryTagId",
                        column: x => x.InventoryTagId,
                        principalTable: "InventoryTag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InventoryTagMapping_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LeadProductMapping",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tid = table.Column<int>(nullable: false),
                    LeadId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeadProductMapping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeadProductMapping_Lead_LeadId",
                        column: x => x.LeadId,
                        principalTable: "Lead",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LeadProductMapping_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhoneCallProductLog",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecId = table.Column<long>(nullable: false),
                    Tid = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    Date = table.Column<string>(nullable: true),
                    CallTime = table.Column<DateTime>(nullable: false),
                    Number = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    Duration = table.Column<int>(nullable: false),
                    IsNew = table.Column<int>(nullable: false),
                    CachedName = table.Column<string>(nullable: true),
                    CachedNumberType = table.Column<int>(nullable: false),
                    PhoneAccountId = table.Column<string>(nullable: true),
                    ViaNumber = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Contact = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneCallProductLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhoneCallProductLog_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhoneCallProductLog_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserRating",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tid = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    ProductId = table.Column<int>(nullable: true),
                    ProjectId = table.Column<int>(nullable: true),
                    Message = table.Column<string>(nullable: true),
                    Rating = table.Column<double>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRating", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRating_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserRating_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRating_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRating_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Wishlist",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tid = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: true),
                    ProjectId = table.Column<int>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wishlist", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wishlist_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Wishlist_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Wishlist_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AttachmentProductMapping_AttachmentId",
                table: "AttachmentProductMapping",
                column: "AttachmentId");

            migrationBuilder.CreateIndex(
                name: "IX_AttachmentProductMapping_ProductId",
                table: "AttachmentProductMapping",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_AttachmentProductMapping_UploadCategoryId",
                table: "AttachmentProductMapping",
                column: "UploadCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_AttachmentProjectMapping_AttachmentId",
                table: "AttachmentProjectMapping",
                column: "AttachmentId");

            migrationBuilder.CreateIndex(
                name: "IX_AttachmentProjectMapping_ProjectId",
                table: "AttachmentProjectMapping",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_AttachmentProjectMapping_UploadCategoryId",
                table: "AttachmentProjectMapping",
                column: "UploadCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CallLog_LeadId",
                table: "CallLog",
                column: "LeadId");

            migrationBuilder.CreateIndex(
                name: "IX_CallLog_UserId",
                table: "CallLog",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CallLogProduct_ProductId",
                table: "CallLogProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_CallLogProduct_UserId",
                table: "CallLogProduct",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerQuery_ProductId",
                table: "CustomerQuery",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerQuery_ProjectId",
                table: "CustomerQuery",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerQuery_UserId",
                table: "CustomerQuery",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryTagMapping_InventoryTagId",
                table: "InventoryTagMapping",
                column: "InventoryTagId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryTagMapping_ProductId",
                table: "InventoryTagMapping",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_LeadId",
                table: "Invoice",
                column: "LeadId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetail_InvoiceId",
                table: "InvoiceDetail",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Lead_DeletedById",
                table: "Lead",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_Lead_LeadSourceId",
                table: "Lead",
                column: "LeadSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Lead_UserId",
                table: "Lead",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_LeadAutoAssign_UserId",
                table: "LeadAutoAssign",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_LeadAutoAssignLog_LeadId",
                table: "LeadAutoAssignLog",
                column: "LeadId");

            migrationBuilder.CreateIndex(
                name: "IX_LeadAutoAssignLog_LeadSourceId",
                table: "LeadAutoAssignLog",
                column: "LeadSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_LeadAutoAssignLog_UserId",
                table: "LeadAutoAssignLog",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_LeadAutoAssignSourceMapping_LeadAutoAssignId",
                table: "LeadAutoAssignSourceMapping",
                column: "LeadAutoAssignId");

            migrationBuilder.CreateIndex(
                name: "IX_LeadAutoAssignSourceMapping_LeadSourceId",
                table: "LeadAutoAssignSourceMapping",
                column: "LeadSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_LeadOrder_PaymentLogId",
                table: "LeadOrder",
                column: "PaymentLogId");

            migrationBuilder.CreateIndex(
                name: "IX_LeadOrder_UserId",
                table: "LeadOrder",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_LeadOrderDetail_LeadId",
                table: "LeadOrderDetail",
                column: "LeadId");

            migrationBuilder.CreateIndex(
                name: "IX_LeadOrderDetail_LeadOrderId",
                table: "LeadOrderDetail",
                column: "LeadOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_LeadProductMapping_LeadId",
                table: "LeadProductMapping",
                column: "LeadId");

            migrationBuilder.CreateIndex(
                name: "IX_LeadProductMapping_ProductId",
                table: "LeadProductMapping",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_LeadProjectMapping_LeadId",
                table: "LeadProjectMapping",
                column: "LeadId");

            migrationBuilder.CreateIndex(
                name: "IX_LeadProjectMapping_ProjectId",
                table: "LeadProjectMapping",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_LeadTagMapping_LeadId",
                table: "LeadTagMapping",
                column: "LeadId");

            migrationBuilder.CreateIndex(
                name: "IX_LeadTagMapping_LeadTagId",
                table: "LeadTagMapping",
                column: "LeadTagId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_CreatedById",
                table: "Message",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_MessageDetail_MessageId",
                table: "MessageDetail",
                column: "MessageId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageDetail_SentToUserId",
                table: "MessageDetail",
                column: "SentToUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentLog_UserId",
                table: "PaymentLog",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneCallLeadLog_LeadId",
                table: "PhoneCallLeadLog",
                column: "LeadId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneCallLeadLog_UserId",
                table: "PhoneCallLeadLog",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneCallProductLog_ProductId",
                table: "PhoneCallProductLog",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneCallProductLog_UserId",
                table: "PhoneCallProductLog",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_LocationId",
                table: "Product",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProjectId",
                table: "Product",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_SocietyId",
                table: "Product",
                column: "SocietyId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_SubCategoryId",
                table: "Product",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_LocationId",
                table: "Project",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_SocietyId",
                table: "Project",
                column: "SocietyId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTagMapping_InventoryTagId",
                table: "ProjectTagMapping",
                column: "InventoryTagId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTagMapping_ProjectId",
                table: "ProjectTagMapping",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategory_CategoryId",
                table: "SubCategory",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Tcf_LeadId",
                table: "Tcf",
                column: "LeadId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLog_LeadId",
                table: "UserLog",
                column: "LeadId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLog_UserId",
                table: "UserLog",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRating_CreatedBy",
                table: "UserRating",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_UserRating_ProductId",
                table: "UserRating",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRating_ProjectId",
                table: "UserRating",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRating_UserId",
                table: "UserRating",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Wallet_UserId",
                table: "Wallet",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WalletDetail_PaymentLogId",
                table: "WalletDetail",
                column: "PaymentLogId");

            migrationBuilder.CreateIndex(
                name: "IX_WalletDetail_WalletId",
                table: "WalletDetail",
                column: "WalletId");

            migrationBuilder.CreateIndex(
                name: "IX_Wishlist_ProductId",
                table: "Wishlist",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Wishlist_ProjectId",
                table: "Wishlist",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Wishlist_UserId",
                table: "Wishlist",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AttachmentProductMapping");

            migrationBuilder.DropTable(
                name: "AttachmentProjectMapping");

            migrationBuilder.DropTable(
                name: "CallLog");

            migrationBuilder.DropTable(
                name: "CallLogProduct");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "CustomerQuery");

            migrationBuilder.DropTable(
                name: "EmailSent");

            migrationBuilder.DropTable(
                name: "EmailSetup");

            migrationBuilder.DropTable(
                name: "InventoryTagMapping");

            migrationBuilder.DropTable(
                name: "InvoiceDetail");

            migrationBuilder.DropTable(
                name: "LeadAutoAssignLog");

            migrationBuilder.DropTable(
                name: "LeadAutoAssignSourceMapping");

            migrationBuilder.DropTable(
                name: "LeadOrderDetail");

            migrationBuilder.DropTable(
                name: "LeadProductMapping");

            migrationBuilder.DropTable(
                name: "LeadProjectMapping");

            migrationBuilder.DropTable(
                name: "LeadRemarks");

            migrationBuilder.DropTable(
                name: "LeadTagMapping");

            migrationBuilder.DropTable(
                name: "LeadType");

            migrationBuilder.DropTable(
                name: "MessageDetail");

            migrationBuilder.DropTable(
                name: "OtpLog");

            migrationBuilder.DropTable(
                name: "PhoneCallLeadLog");

            migrationBuilder.DropTable(
                name: "PhoneCallProductLog");

            migrationBuilder.DropTable(
                name: "ProjectTagMapping");

            migrationBuilder.DropTable(
                name: "Seo");

            migrationBuilder.DropTable(
                name: "Slider");

            migrationBuilder.DropTable(
                name: "SystemSetup");

            migrationBuilder.DropTable(
                name: "Tcf");

            migrationBuilder.DropTable(
                name: "Template");

            migrationBuilder.DropTable(
                name: "TempLead");

            migrationBuilder.DropTable(
                name: "UserLog");

            migrationBuilder.DropTable(
                name: "UserRating");

            migrationBuilder.DropTable(
                name: "WalletDetail");

            migrationBuilder.DropTable(
                name: "Wishlist");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Attachment");

            migrationBuilder.DropTable(
                name: "UploadCategory");

            migrationBuilder.DropTable(
                name: "Invoice");

            migrationBuilder.DropTable(
                name: "LeadAutoAssign");

            migrationBuilder.DropTable(
                name: "LeadOrder");

            migrationBuilder.DropTable(
                name: "LeadTag");

            migrationBuilder.DropTable(
                name: "Message");

            migrationBuilder.DropTable(
                name: "InventoryTag");

            migrationBuilder.DropTable(
                name: "Wallet");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Lead");

            migrationBuilder.DropTable(
                name: "PaymentLog");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "SubCategory");

            migrationBuilder.DropTable(
                name: "LeadSource");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "Society");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
