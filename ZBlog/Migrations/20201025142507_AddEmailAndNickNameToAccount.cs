using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZBlog.Migrations
{
    public partial class AddEmailAndNickNameToAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "account",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "nickname",
                table: "account",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "account",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "create_time", "email", "nickname", "update_time" },
                values: new object[] { new DateTime(2020, 10, 25, 22, 25, 6, 884, DateTimeKind.Local).AddTicks(2790), "kastrcn@outlook.com", "tian", new DateTime(2020, 10, 25, 22, 25, 6, 887, DateTimeKind.Local).AddTicks(7550) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "email",
                table: "account");

            migrationBuilder.DropColumn(
                name: "nickname",
                table: "account");

            migrationBuilder.UpdateData(
                table: "account",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "create_time", "update_time" },
                values: new object[] { new DateTime(2020, 10, 25, 20, 38, 27, 289, DateTimeKind.Local).AddTicks(300), new DateTime(2020, 10, 25, 20, 38, 27, 292, DateTimeKind.Local).AddTicks(7110) });
        }
    }
}
