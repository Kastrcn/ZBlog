using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZBlog.Migrations
{
    public partial class inits : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "category_id",
                table: "post",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "account_id",
                table: "post",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "account",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "create_time", "update_time" },
                values: new object[] { new DateTime(2020, 10, 25, 2, 50, 30, 689, DateTimeKind.Local).AddTicks(2850), new DateTime(2020, 10, 25, 2, 50, 30, 693, DateTimeKind.Local).AddTicks(5250) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "category_id",
                table: "post",
                type: "int",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<int>(
                name: "account_id",
                table: "post",
                type: "int",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.UpdateData(
                table: "account",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "create_time", "update_time" },
                values: new object[] { new DateTime(2020, 10, 24, 22, 35, 57, 767, DateTimeKind.Local).AddTicks(760), new DateTime(2020, 10, 24, 22, 35, 57, 772, DateTimeKind.Local).AddTicks(5190) });
        }
    }
}
