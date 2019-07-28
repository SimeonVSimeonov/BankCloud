using Microsoft.EntityFrameworkCore.Migrations;

namespace BankCloud.Data.Migrations
{
    public partial class RenameCurrency2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Curencies_CurrencyId",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Insurances_Curencies_CurencyId",
                table: "Insurances");

            migrationBuilder.DropForeignKey(
                name: "FK_Investments_Curencies_CurencyId",
                table: "Investments");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Curencies_CurencyId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Saves_Curencies_CurencyId",
                table: "Saves");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Curencies",
                table: "Curencies");

            migrationBuilder.DropColumn(
                name: "CurencyId",
                table: "Accounts");

            migrationBuilder.RenameTable(
                name: "Curencies",
                newName: "Currencies");

            migrationBuilder.RenameColumn(
                name: "CurencyId",
                table: "Saves",
                newName: "CurrencyId");

            migrationBuilder.RenameIndex(
                name: "IX_Saves_CurencyId",
                table: "Saves",
                newName: "IX_Saves_CurrencyId");

            migrationBuilder.RenameColumn(
                name: "CurencyId",
                table: "Payments",
                newName: "CurrencyId");

            migrationBuilder.RenameIndex(
                name: "IX_Payments_CurencyId",
                table: "Payments",
                newName: "IX_Payments_CurrencyId");

            migrationBuilder.RenameColumn(
                name: "CurencyId",
                table: "Investments",
                newName: "CurrencyId");

            migrationBuilder.RenameIndex(
                name: "IX_Investments_CurencyId",
                table: "Investments",
                newName: "IX_Investments_CurrencyId");

            migrationBuilder.RenameColumn(
                name: "CurencyId",
                table: "Insurances",
                newName: "CurrencyId");

            migrationBuilder.RenameIndex(
                name: "IX_Insurances_CurencyId",
                table: "Insurances",
                newName: "IX_Insurances_CurrencyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Currencies",
                table: "Currencies",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Currencies_CurrencyId",
                table: "Accounts",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Insurances_Currencies_CurrencyId",
                table: "Insurances",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Investments_Currencies_CurrencyId",
                table: "Investments",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Currencies_CurrencyId",
                table: "Payments",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Saves_Currencies_CurrencyId",
                table: "Saves",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Currencies_CurrencyId",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Insurances_Currencies_CurrencyId",
                table: "Insurances");

            migrationBuilder.DropForeignKey(
                name: "FK_Investments_Currencies_CurrencyId",
                table: "Investments");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Currencies_CurrencyId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Saves_Currencies_CurrencyId",
                table: "Saves");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Currencies",
                table: "Currencies");

            migrationBuilder.RenameTable(
                name: "Currencies",
                newName: "Curencies");

            migrationBuilder.RenameColumn(
                name: "CurrencyId",
                table: "Saves",
                newName: "CurencyId");

            migrationBuilder.RenameIndex(
                name: "IX_Saves_CurrencyId",
                table: "Saves",
                newName: "IX_Saves_CurencyId");

            migrationBuilder.RenameColumn(
                name: "CurrencyId",
                table: "Payments",
                newName: "CurencyId");

            migrationBuilder.RenameIndex(
                name: "IX_Payments_CurrencyId",
                table: "Payments",
                newName: "IX_Payments_CurencyId");

            migrationBuilder.RenameColumn(
                name: "CurrencyId",
                table: "Investments",
                newName: "CurencyId");

            migrationBuilder.RenameIndex(
                name: "IX_Investments_CurrencyId",
                table: "Investments",
                newName: "IX_Investments_CurencyId");

            migrationBuilder.RenameColumn(
                name: "CurrencyId",
                table: "Insurances",
                newName: "CurencyId");

            migrationBuilder.RenameIndex(
                name: "IX_Insurances_CurrencyId",
                table: "Insurances",
                newName: "IX_Insurances_CurencyId");

            migrationBuilder.AddColumn<string>(
                name: "CurencyId",
                table: "Accounts",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Curencies",
                table: "Curencies",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Curencies_CurrencyId",
                table: "Accounts",
                column: "CurrencyId",
                principalTable: "Curencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Insurances_Curencies_CurencyId",
                table: "Insurances",
                column: "CurencyId",
                principalTable: "Curencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Investments_Curencies_CurencyId",
                table: "Investments",
                column: "CurencyId",
                principalTable: "Curencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Curencies_CurencyId",
                table: "Payments",
                column: "CurencyId",
                principalTable: "Curencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Saves_Curencies_CurencyId",
                table: "Saves",
                column: "CurencyId",
                principalTable: "Curencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
