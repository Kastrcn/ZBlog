using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZBlog.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "account",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    create_time = table.Column<DateTime>(nullable: false),
                    update_time = table.Column<DateTime>(nullable: false),
                    user_name = table.Column<string>(maxLength: 120, nullable: false),
                    password = table.Column<string>(maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_account", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    create_time = table.Column<DateTime>(nullable: false),
                    update_time = table.Column<DateTime>(nullable: false),
                    name = table.Column<string>(maxLength: 80, nullable: false),
                    slug = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "comment",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    create_time = table.Column<DateTime>(nullable: false),
                    update_time = table.Column<DateTime>(nullable: false),
                    email = table.Column<string>(maxLength: 150, nullable: false),
                    website = table.Column<string>(maxLength: 200, nullable: false),
                    nickname = table.Column<string>(maxLength: 80, nullable: true),
                    post_id = table.Column<int>(nullable: false),
                    content = table.Column<string>(nullable: true),
                    reply = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comment", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "link",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    create_time = table.Column<DateTime>(nullable: false),
                    update_time = table.Column<DateTime>(nullable: false),
                    logo = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: false),
                    priority = table.Column<int>(nullable: false),
                    url = table.Column<string>(nullable: false),
                    description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_link", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "post",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    create_time = table.Column<DateTime>(nullable: false),
                    update_time = table.Column<DateTime>(nullable: false),
                    category_id = table.Column<int>(nullable: false),
                    title = table.Column<string>(maxLength: 200, nullable: false),
                    slug = table.Column<string>(maxLength: 100, nullable: false),
                    context = table.Column<string>(nullable: false),
                    status = table.Column<int>(nullable: false),
                    account_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_post", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tag",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    create_time = table.Column<DateTime>(nullable: false),
                    update_time = table.Column<DateTime>(nullable: false),
                    name = table.Column<string>(maxLength: 80, nullable: false),
                    slug = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tag", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "post_tag",
                columns: table => new
                {
                    post_id = table.Column<long>(nullable: false),
                    tag_id = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_post_tag", x => new { x.post_id, x.tag_id });
                    table.ForeignKey(
                        name: "FK_post_tag_post_post_id",
                        column: x => x.post_id,
                        principalTable: "post",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_post_tag_tag_tag_id",
                        column: x => x.tag_id,
                        principalTable: "tag",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "account",
                columns: new[] { "id", "create_time", "password", "update_time", "user_name" },
                values: new object[] { 1L, new DateTime(2020, 10, 24, 22, 35, 57, 767, DateTimeKind.Local).AddTicks(760), "zhao", new DateTime(2020, 10, 24, 22, 35, 57, 772, DateTimeKind.Local).AddTicks(5190), "tian" });

            migrationBuilder.CreateIndex(
                name: "IX_post_tag_tag_id",
                table: "post_tag",
                column: "tag_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "account");

            migrationBuilder.DropTable(
                name: "category");

            migrationBuilder.DropTable(
                name: "comment");

            migrationBuilder.DropTable(
                name: "link");

            migrationBuilder.DropTable(
                name: "post_tag");

            migrationBuilder.DropTable(
                name: "post");

            migrationBuilder.DropTable(
                name: "tag");
        }
    }
}
