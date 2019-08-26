using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BankCloud.Data.Migrations
{
    public partial class AddAccountTransferColl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transfer_Accounts_AccountId",
                table: "Transfer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transfer",
                table: "Transfer");

            migrationBuilder.RenameTable(
                name: "Transfer",
                newName: "Transfers");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "Transfers",
                newName: "ForeignAccountId");

            migrationBuilder.RenameIndex(
                name: "IX_Transfer_AccountId",
                table: "Transfers",
                newName: "IX_Transfers_ForeignAccountId");

            migrationBuilder.AddColumn<string>(
                name: "TransferId",
                table: "Accounts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BalanceType",
                table: "Transfers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Completed",
                table: "Transfers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Transfers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transfers",
                table: "Transfers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transfers_Accounts_ForeignAccountId",
                table: "Transfers",
                column: "ForeignAccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transfers_Accounts_ForeignAccountId",
                table: "Transfers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transfers",
                table: "Transfers");

            migrationBuilder.DropColumn(
                name: "TransferId",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "BalanceType",
                table: "Transfers");

            migrationBuilder.DropColumn(
                name: "Completed",
                table: "Transfers");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Transfers");

            migrationBuilder.RenameTable(
                name: "Transfers",
                newName: "Transfer");

            migrationBuilder.RenameColumn(
                name: "ForeignAccountId",
                table: "Transfer",
                newName: "AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_Transfers_ForeignAccountId",
                table: "Transfer",
                newName: "IX_Transfer_AccountId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transfer",
                table: "Transfer",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transfer_Accounts_AccountId",
                table: "Transfer",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
