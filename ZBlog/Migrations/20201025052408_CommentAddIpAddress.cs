using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZBlog.Migrations
{
    public partial class CommentAddIpAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "post_id",
                table: "comment",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "ip_address",
                table: "comment",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "account",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "create_time", "update_time" },
                values: new object[] { new DateTime(2020, 10, 25, 13, 24, 8, 58, DateTimeKind.Local).AddTicks(6050), new DateTime(2020, 10, 25, 13, 24, 8, 63, DateTimeKind.Local).AddTicks(4280) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ip_address",
                table: "comment");

            migrationBuilder.AlterColumn<int>(
                name: "post_id",
                table: "comment",
                type: "int",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.UpdateData(
                table: "account",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "create_time", "update_time" },
                values: new object[] { new DateTime(2020, 10, 25, 2, 50, 30, 689, DateTimeKind.Local).AddTicks(2850), new DateTime(2020, 10, 25, 2, 50, 30, 693, DateTimeKind.Local).AddTicks(5250) });
        }
    }
}
