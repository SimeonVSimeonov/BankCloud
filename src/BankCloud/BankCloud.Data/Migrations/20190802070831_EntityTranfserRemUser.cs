using Microsoft.EntityFrameworkCore.Migrations;

namespace BankCloud.Data.Migrations
{
    public partial class EntityTranfserRemUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transfer_AspNetUsers_UserId",
                table: "Transfer");

            migrationBuilder.DropIndex(
                name: "IX_Transfer_UserId",
                table: "Transfer");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Transfer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Transfer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transfer_UserId",
                table: "Transfer",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transfer_AspNetUsers_UserId",
                table: "Transfer",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
