using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Amphawan_001.Migrations
{
    public partial class sss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_account",
                columns: table => new
                {
                    int_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    st_user = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    st_password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    st_compare_password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    st_email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dt_cus_birth_day = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dt_cus_begin_cus_day = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dt_cus_expire_cus_day = table.Column<DateTime>(type: "datetime2", nullable: false),
                    bool_staus = table.Column<bool>(type: "bit", nullable: false),
                    bool_stop_ = table.Column<bool>(type: "bit", nullable: false),
                    st_cus_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    st_post_address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    st_Email_address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    int_type_cus = table.Column<int>(type: "int", nullable: false),
                    Date_login_user = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_account", x => x.int_id);
                });

            migrationBuilder.CreateTable(
                name: "tb_customer",
                columns: table => new
                {
                    int_id_cus = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    st_cus_no = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_customer", x => x.int_id_cus);
                });

            migrationBuilder.CreateTable(
                name: "tb_his",
                columns: table => new
                {
                    int_id_his = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_his", x => x.int_id_his);
                });

            migrationBuilder.CreateTable(
                name: "tb_search",
                columns: table => new
                {
                    int_id_num = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    int_ISBN_ISSN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    int_kind_book = table.Column<int>(type: "int", nullable: false),
                    int_type_book = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_search", x => x.int_id_num);
                });

            migrationBuilder.CreateTable(
                name: "tb_cattalog",
                columns: table => new
                {
                    int_id_catalog_book = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    st_name_book = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    st_ISBN_ISSN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    st_detail_book = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dt_DATE_modify = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MD_Accountint_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_cattalog", x => x.int_id_catalog_book);
                    table.ForeignKey(
                        name: "FK_tb_cattalog_tb_account_MD_Accountint_id",
                        column: x => x.MD_Accountint_id,
                        principalTable: "tb_account",
                        principalColumn: "int_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_cattalog_MD_Accountint_id",
                table: "tb_cattalog",
                column: "MD_Accountint_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_cattalog");

            migrationBuilder.DropTable(
                name: "tb_customer");

            migrationBuilder.DropTable(
                name: "tb_his");

            migrationBuilder.DropTable(
                name: "tb_search");

            migrationBuilder.DropTable(
                name: "tb_account");
        }
    }
}
