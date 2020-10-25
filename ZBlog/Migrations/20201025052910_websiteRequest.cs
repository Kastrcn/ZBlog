using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZBlog.Migrations
{
    public partial class websiteRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "website",
                table: "comment",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(200) CHARACTER SET utf8mb4",
                oldMaxLength: 200);

            migrationBuilder.UpdateData(
                table: "account",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "create_time", "update_time" },
                values: new object[] { new DateTime(2020, 10, 25, 13, 29, 9, 684, DateTimeKind.Local).AddTicks(5790), new DateTime(2020, 10, 25, 13, 29, 9, 694, DateTimeKind.Local).AddTicks(1190) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "website",
                table: "comment",
                type: "varchar(200) CHARACTER SET utf8mb4",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "account",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "create_time", "update_time" },
                values: new object[] { new DateTime(2020, 10, 25, 13, 24, 8, 58, DateTimeKind.Local).AddTicks(6050), new DateTime(2020, 10, 25, 13, 24, 8, 63, DateTimeKind.Local).AddTicks(4280) });
        }
    }
}
