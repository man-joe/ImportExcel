using Microsoft.EntityFrameworkCore.Migrations;

namespace ImportExcelDemo.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cmdbs",
                columns: table => new
                {
                    CmdbID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CDTag = table.Column<string>(maxLength: 50, nullable: true),
                    AdUser = table.Column<string>(maxLength: 50, nullable: true),
                    Location = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cmdbs", x => x.CmdbID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cmdbs");
        }
    }
}
