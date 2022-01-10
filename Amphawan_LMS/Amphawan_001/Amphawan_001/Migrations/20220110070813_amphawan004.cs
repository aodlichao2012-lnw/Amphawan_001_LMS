using Microsoft.EntityFrameworkCore.Migrations;

namespace Amphawan_001.Migrations
{
    public partial class amphawan004 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MD_Accountint_id",
                table: "tb_cattalog",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_cattalog_MD_Accountint_id",
                table: "tb_cattalog",
                column: "MD_Accountint_id");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_cattalog_tb_account_MD_Accountint_id",
                table: "tb_cattalog",
                column: "MD_Accountint_id",
                principalTable: "tb_account",
                principalColumn: "int_id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_cattalog_tb_account_MD_Accountint_id",
                table: "tb_cattalog");

            migrationBuilder.DropIndex(
                name: "IX_tb_cattalog_MD_Accountint_id",
                table: "tb_cattalog");

            migrationBuilder.DropColumn(
                name: "MD_Accountint_id",
                table: "tb_cattalog");
        }
    }
}
