using Microsoft.EntityFrameworkCore.Migrations;

namespace BankCloud.Data.Migrations
{
    public partial class LoanIdSetNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderLoans_Loans_LoanId",
                table: "OrderLoans");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLoans_Loans_LoanId",
                table: "OrderLoans",
                column: "LoanId",
                principalTable: "Loans",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderLoans_Loans_LoanId",
                table: "OrderLoans");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLoans_Loans_LoanId",
                table: "OrderLoans",
                column: "LoanId",
                principalTable: "Loans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
