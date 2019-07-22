using Microsoft.EntityFrameworkCore.Migrations;

namespace BankCloud.Data.Migrations
{
    public partial class ChangeAccountEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Account_AspNetUsers_BankUserId",
                table: "Account");

            migrationBuilder.DropForeignKey(
                name: "FK_Account_Curencies_CurencyId",
                table: "Account");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Account",
                table: "Account");

            migrationBuilder.RenameTable(
                name: "Account",
                newName: "Accounts");

            migrationBuilder.RenameIndex(
                name: "IX_Account_CurencyId",
                table: "Accounts",
                newName: "IX_Accounts_CurencyId");

            migrationBuilder.RenameIndex(
                name: "IX_Account_BankUserId",
                table: "Accounts",
                newName: "IX_Accounts_BankUserId");

            migrationBuilder.AddColumn<string>(
                name: "IBAN",
                table: "Accounts",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Accounts",
                table: "Accounts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_AspNetUsers_BankUserId",
                table: "Accounts",
                column: "BankUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Curencies_CurencyId",
                table: "Accounts",
                column: "CurencyId",
                principalTable: "Curencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_AspNetUsers_BankUserId",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Curencies_CurencyId",
                table: "Accounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Accounts",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "IBAN",
                table: "Accounts");

            migrationBuilder.RenameTable(
                name: "Accounts",
                newName: "Account");

            migrationBuilder.RenameIndex(
                name: "IX_Accounts_CurencyId",
                table: "Account",
                newName: "IX_Account_CurencyId");

            migrationBuilder.RenameIndex(
                name: "IX_Accounts_BankUserId",
                table: "Account",
                newName: "IX_Account_BankUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Account",
                table: "Account",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Account_AspNetUsers_BankUserId",
                table: "Account",
                column: "BankUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Account_Curencies_CurencyId",
                table: "Account",
                column: "CurencyId",
                principalTable: "Curencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
