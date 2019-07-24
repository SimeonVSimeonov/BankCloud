using Microsoft.EntityFrameworkCore.Migrations;

namespace BankCloud.Data.Migrations
{
    public partial class AddLoanAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Loans_Curencies_CurencyId",
                table: "Loans");

            migrationBuilder.RenameColumn(
                name: "CurencyId",
                table: "Loans",
                newName: "AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_Loans_CurencyId",
                table: "Loans",
                newName: "IX_Loans_AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Loans_Accounts_AccountId",
                table: "Loans",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Loans_Accounts_AccountId",
                table: "Loans");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "Loans",
                newName: "CurencyId");

            migrationBuilder.RenameIndex(
                name: "IX_Loans_AccountId",
                table: "Loans",
                newName: "IX_Loans_CurencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Loans_Curencies_CurencyId",
                table: "Loans",
                column: "CurencyId",
                principalTable: "Curencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
