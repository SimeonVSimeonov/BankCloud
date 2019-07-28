using Microsoft.EntityFrameworkCore.Migrations;

namespace BankCloud.Data.Migrations
{
    public partial class RenameCurrency : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Curencies_CurencyId",
                table: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_CurencyId",
                table: "Accounts");

            migrationBuilder.AlterColumn<string>(
                name: "CurencyId",
                table: "Accounts",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CurrencyId",
                table: "Accounts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_CurrencyId",
                table: "Accounts",
                column: "CurrencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Curencies_CurrencyId",
                table: "Accounts",
                column: "CurrencyId",
                principalTable: "Curencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Curencies_CurrencyId",
                table: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_CurrencyId",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "CurrencyId",
                table: "Accounts");

            migrationBuilder.AlterColumn<string>(
                name: "CurencyId",
                table: "Accounts",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_CurencyId",
                table: "Accounts",
                column: "CurencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Curencies_CurencyId",
                table: "Accounts",
                column: "CurencyId",
                principalTable: "Curencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
