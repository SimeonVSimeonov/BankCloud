using Microsoft.EntityFrameworkCore.Migrations;

namespace BankCloud.Data.Migrations
{
    public partial class AddAccountTransferCollNew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TransferId",
                table: "Accounts");

            migrationBuilder.AddColumn<string>(
                name: "AccountId",
                table: "Transfers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transfers_AccountId",
                table: "Transfers",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transfers_Accounts_AccountId",
                table: "Transfers",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transfers_Accounts_AccountId",
                table: "Transfers");

            migrationBuilder.DropIndex(
                name: "IX_Transfers_AccountId",
                table: "Transfers");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Transfers");

            migrationBuilder.AddColumn<string>(
                name: "TransferId",
                table: "Accounts",
                nullable: true);
        }
    }
}
