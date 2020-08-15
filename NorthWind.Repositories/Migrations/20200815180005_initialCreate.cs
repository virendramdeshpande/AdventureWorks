using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NorthWind.Repositories.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Gender = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    SaleDate = table.Column<DateTime>(nullable: false),
                    CoveragePlan = table.Column<string>(nullable: true),
                    NetPrice = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CoveragePlan",
                columns: table => new
                {
                    CoveragePlan = table.Column<string>(nullable: true),
                    EligibilityDateFrom = table.Column<DateTime>(nullable: false),
                    EligibilityDateTo = table.Column<DateTime>(nullable: false),
                    EligibilityCountry = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contracts");

            migrationBuilder.DropTable(
                name: "CoveragePlan");
        }
    }
}
