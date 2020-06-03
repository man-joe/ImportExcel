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
                    Model = table.Column<string>(maxLength: 100, nullable: true),
                    SerialNumber = table.Column<string>(maxLength: 50, nullable: true),
                    OperatingSystem = table.Column<string>(maxLength: 50, nullable: true),
                    AdUser = table.Column<string>(maxLength: 50, nullable: true),
                    SunflowerUser = table.Column<string>(maxLength: 250, nullable: true),
                    Status = table.Column<string>(maxLength: 50, nullable: true),
                    ClassType = table.Column<string>(maxLength: 50, nullable: true),
                    AcquisitionDate = table.Column<DateTime>(nullable: true),
                    WarrentyEndDate = table.Column<DateTime>(nullable: true),
                    Custodian = table.Column<string>(maxLength: 50, nullable: true),
                    Comments = table.Column<string>(maxLength: 800, nullable: true),
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

            migrationBuilder.CreateTable(
                name: "Epos",
                columns: table => new
                {
                    EpoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SystemName = table.Column<string>(maxLength: 50, nullable: true),
                    ManagedState = table.Column<string>(maxLength: 50, nullable: true),
                    Tags = table.Column<string>(maxLength: 150, nullable: true),
                    IpAddress = table.Column<string>(maxLength: 50, nullable: true),
                    UserName = table.Column<string>(maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Epos", x => x.EpoID);
                });

            migrationBuilder.CreateTable(
                name: "Sunflowers",
                columns: table => new
                {
                    SunID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BarcodeNum = table.Column<string>(maxLength: 50, nullable: true),
                    Status = table.Column<string>(maxLength: 50, nullable: true),
                    OfficialName = table.Column<string>(maxLength: 50, nullable: true),
                    Manufacturer = table.Column<string>(maxLength: 50, nullable: true),
                    Model = table.Column<string>(maxLength: 100, nullable: true),
                    ModelName = table.Column<string>(maxLength: 100, nullable: true),
                    SerialNumber = table.Column<string>(maxLength: 50, nullable: true),
                    AssetValue = table.Column<string>(maxLength: 59, nullable: true),
                    EffectiveDate = table.Column<DateTime>(nullable: true),
                    CustArea = table.Column<string>(maxLength: 50, nullable: true),
                    BureauOrRegion = table.Column<string>(maxLength: 50, nullable: true),
                    PropertyContact = table.Column<string>(maxLength: 50, nullable: true),
                    CurrentUser = table.Column<string>(maxLength: 50, nullable: true),
                    FedSupplyGroup = table.Column<string>(maxLength: 500, nullable: true),
                    UtilizationCode = table.Column<string>(maxLength: 50, nullable: true),
                    AssetCondition = table.Column<string>(maxLength: 50, nullable: true),
                    ConditionDescription = table.Column<string>(maxLength: 50, nullable: true),
                    PhysicalInventoryDate = table.Column<DateTime>(nullable: true),
                    AcquisitionDate = table.Column<DateTime>(nullable: true),
                    ResponsibilityDate = table.Column<DateTime>(nullable: true),
                    Site = table.Column<string>(maxLength: 50, nullable: true),
                    Stlv1 = table.Column<string>(maxLength: 50, nullable: true),
                    Stlv2 = table.Column<string>(maxLength: 50, nullable: true),
                    Stlv3 = table.Column<string>(maxLength: 50, nullable: true),
                    MailStop = table.Column<string>(maxLength: 50, nullable: true),
                    Gps1 = table.Column<string>(maxLength: 50, nullable: true),
                    Gps2 = table.Column<string>(maxLength: 50, nullable: true),
                    Gps3 = table.Column<string>(maxLength: 50, nullable: true),
                    ResolutionDate = table.Column<DateTime>(nullable: true),
                    Resolution = table.Column<string>(maxLength: 50, nullable: true),
                    FinalEvent = table.Column<string>(maxLength: 50, nullable: true),
                    Datetime = table.Column<DateTime>(nullable: true),
                    FinalEventUserDefinedLabel01 = table.Column<string>(maxLength: 50, nullable: true),
                    FinalEventUserField01 = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sunflowers", x => x.SunID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CMDB");

            migrationBuilder.DropTable(
                name: "Epos");

            migrationBuilder.DropTable(
                name: "Sunflowers");
        }
    }
}
