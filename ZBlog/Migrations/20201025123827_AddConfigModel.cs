using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZBlog.Migrations
{
    public partial class AddConfigModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "config",
                columns: table => new
                {
                    name = table.Column<string>(nullable: false),
                    data = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_config", x => x.name);
                });

            migrationBuilder.UpdateData(
                table: "account",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "create_time", "update_time" },
                values: new object[] { new DateTime(2020, 10, 25, 20, 38, 27, 289, DateTimeKind.Local).AddTicks(300), new DateTime(2020, 10, 25, 20, 38, 27, 292, DateTimeKind.Local).AddTicks(7110) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "config");

            migrationBuilder.UpdateData(
                table: "account",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "create_time", "update_time" },
                values: new object[] { new DateTime(2020, 10, 25, 13, 29, 9, 684, DateTimeKind.Local).AddTicks(5790), new DateTime(2020, 10, 25, 13, 29, 9, 694, DateTimeKind.Local).AddTicks(1190) });
        }
    }
}
