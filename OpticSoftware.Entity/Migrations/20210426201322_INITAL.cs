using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace OpticSoftware.Entity.Migrations
{
    public partial class INITAL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    ExpireDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    SMSCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SystemParameters",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    ParameterName = table.Column<string>(maxLength: 50, nullable: false),
                    ParameterValue = table.Column<string>(maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemParameters", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    Username = table.Column<string>(maxLength: 25, nullable: false),
                    Password = table.Column<string>(maxLength: 255, nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Language = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CompanyParameters",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    ParameterName = table.Column<string>(maxLength: 50, nullable: false),
                    ParameterValue = table.Column<string>(maxLength: 1000, nullable: false),
                    CompanyID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyParameters", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CompanyParameters_Companies_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Companies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserDetails",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    Name = table.Column<string>(maxLength: 25, nullable: false),
                    Surname = table.Column<string>(maxLength: 25, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 25, nullable: false),
                    Roles = table.Column<string>(maxLength: 50, nullable: false),
                    UserType = table.Column<int>(nullable: false),
                    UserID = table.Column<long>(nullable: false),
                    CompanyID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDetails", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserDetails_Companies_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Companies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserDetails_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Companies_ID",
                table: "Companies",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyParameters_CompanyID",
                table: "CompanyParameters",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyParameters_ParameterName",
                table: "CompanyParameters",
                column: "ParameterName");

            migrationBuilder.CreateIndex(
                name: "IX_SystemParameters_ParameterName",
                table: "SystemParameters",
                column: "ParameterName");

            migrationBuilder.CreateIndex(
                name: "IX_UserDetails_CompanyID",
                table: "UserDetails",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_UserDetails_UserID",
                table: "UserDetails",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyParameters");

            migrationBuilder.DropTable(
                name: "SystemParameters");

            migrationBuilder.DropTable(
                name: "UserDetails");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
