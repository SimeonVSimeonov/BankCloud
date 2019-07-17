using Microsoft.EntityFrameworkCore.Migrations;

namespace BankCloud.Data.Migrations
{
    public partial class InitialCreateAddLoansOrderNewParams : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "OrderLoans",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "InterestRate",
                table: "OrderLoans",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MonthlyFee",
                table: "OrderLoans",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "OrderLoans",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Period",
                table: "OrderLoans",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "OrderLoans");

            migrationBuilder.DropColumn(
                name: "InterestRate",
                table: "OrderLoans");

            migrationBuilder.DropColumn(
                name: "MonthlyFee",
                table: "OrderLoans");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "OrderLoans");

            migrationBuilder.DropColumn(
                name: "Period",
                table: "OrderLoans");
        }
    }
}
