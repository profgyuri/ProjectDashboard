using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectDashboard.Lib.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Solutions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    SolutionPath = table.Column<string>(type: "TEXT", nullable: false),
                    DebugPath = table.Column<string>(type: "TEXT", nullable: false),
                    ReleasePath = table.Column<string>(type: "TEXT", nullable: false),
                    PublishedPath = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solutions", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Solutions");
        }
    }
}
