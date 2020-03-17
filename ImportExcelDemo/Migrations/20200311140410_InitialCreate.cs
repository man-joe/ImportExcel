using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ImportExcelDemo.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CMDB",
                columns: table => new
                {
                    CmdbID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CDTag = table.Column<string>(maxLength: 50, nullable: true),
                    Org = table.Column<string>(maxLength: 50, nullable: true),
                    HostName = table.Column<string>(maxLength: 50, nullable: true),
                    Location = table.Column<string>(maxLength: 50, nullable: true),
                    Floor = table.Column<string>(maxLength: 50, nullable: true),
                    Room = table.Column<string>(maxLength: 50, nullable: true),
                    IpAddress = table.Column<string>(maxLength: 50, nullable: true),
                    SubnetMask = table.Column<string>(maxLength: 50, nullable: true),
                    MacAddress = table.Column<string>(maxLength: 50, nullable: true),
                    Manufacturer = table.Column<string>(maxLength: 50, nullable: true),
                    Model = table.Column<string>(maxLength: 50, nullable: true),
                    SerialNumber = table.Column<string>(maxLength: 50, nullable: true),
                    OperatingSystem = table.Column<string>(maxLength: 50, nullable: true),
                    AdUser = table.Column<string>(maxLength: 50, nullable: true),
                    SunflowerUser = table.Column<string>(maxLength: 50, nullable: true),
                    Status = table.Column<string>(maxLength: 50, nullable: true),
                    ClassType = table.Column<string>(maxLength: 50, nullable: true),
                    AcquisitionDate = table.Column<DateTime>(maxLength: 50, nullable: false),
                    WarrentyEndDate = table.Column<string>(maxLength: 50, nullable: true),
                    Custodian = table.Column<string>(maxLength: 50, nullable: true),
                    Comments = table.Column<string>(maxLength: 50, nullable: true),
                    InventoriedBy = table.Column<string>(maxLength: 50, nullable: true),
                    InventoryDate = table.Column<DateTime>(nullable: true),
                    LastScan = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 50, nullable: true),
                    Modified = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CMDB", x => x.CmdbID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CMDB");
        }
    }
}
