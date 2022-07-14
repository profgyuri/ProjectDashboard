using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectDashboard.Library.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Standalones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PublishPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DebugPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReleasePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SolutionPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Standalones", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Standalones");
        }
    }
}
