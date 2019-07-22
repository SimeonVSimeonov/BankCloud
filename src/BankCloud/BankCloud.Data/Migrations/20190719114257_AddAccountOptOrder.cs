using Microsoft.EntityFrameworkCore.Migrations;

namespace BankCloud.Data.Migrations
{
    public partial class AddAccountOptOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AccountId",
                table: "OrderLoans",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderLoans_AccountId",
                table: "OrderLoans",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLoans_Accounts_AccountId",
                table: "OrderLoans",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderLoans_Accounts_AccountId",
                table: "OrderLoans");

            migrationBuilder.DropIndex(
                name: "IX_OrderLoans_AccountId",
                table: "OrderLoans");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "OrderLoans");
        }
    }
}
