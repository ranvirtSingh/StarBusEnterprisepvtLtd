using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StarBusEnterprise.Data.Migrations
{
    public partial class dta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AgentBasicInfo",
                table: "AgentBasicInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HomeDeliveryAddressInfos",
                table: "HomeDeliveryAddressInfos");

            migrationBuilder.RenameTable(
                name: "HomeDeliveryAddressInfos",
                newName: "HomeDeliveryAddressInfo");

            migrationBuilder.AddColumn<int>(
                name: "DestinationId",
                table: "TimeList",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "ReachTimeT",
                table: "TimeList",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "TimeReach",
                table: "TimeList",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AlterColumn<string>(
                name: "AgentId",
                table: "AgentBasicInfo",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "AgentBasicInfo",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "AreaCode",
                table: "HomeDeliveryAddressInfo",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AgentBasicInfo",
                table: "AgentBasicInfo",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HomeDeliveryAddressInfo",
                table: "HomeDeliveryAddressInfo",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "DestantionTable",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    startpoint = table.Column<int>(nullable: false),
                    DestinationName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DestantionTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FeedBackSubject",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedBackSubject", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StartFromTable",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartPoint = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StartFromTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TermsAndConditionsDbset",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TermsAndConditions = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TermsAndConditionsDbset", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DestantionTable");

            migrationBuilder.DropTable(
                name: "FeedBackSubject");

            migrationBuilder.DropTable(
                name: "StartFromTable");

            migrationBuilder.DropTable(
                name: "TermsAndConditionsDbset");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AgentBasicInfo",
                table: "AgentBasicInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HomeDeliveryAddressInfo",
                table: "HomeDeliveryAddressInfo");

            migrationBuilder.DropColumn(
                name: "DestinationId",
                table: "TimeList");

            migrationBuilder.DropColumn(
                name: "ReachTimeT",
                table: "TimeList");

            migrationBuilder.DropColumn(
                name: "TimeReach",
                table: "TimeList");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "AgentBasicInfo");

            migrationBuilder.DropColumn(
                name: "AreaCode",
                table: "HomeDeliveryAddressInfo");

            migrationBuilder.RenameTable(
                name: "HomeDeliveryAddressInfo",
                newName: "HomeDeliveryAddressInfos");

            migrationBuilder.AlterColumn<string>(
                name: "AgentId",
                table: "AgentBasicInfo",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AgentBasicInfo",
                table: "AgentBasicInfo",
                column: "AgentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HomeDeliveryAddressInfos",
                table: "HomeDeliveryAddressInfos",
                column: "Id");
        }
    }
}
