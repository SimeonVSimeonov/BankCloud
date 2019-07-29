using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BankCloud.Data.Migrations
{
    public partial class AddAbstractOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderPayments_Accounts_AccountId",
                table: "OrderPayments");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderPayments_AspNetUsers_BuyerId",
                table: "OrderPayments");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderSaves_Accounts_AccountId",
                table: "OrderSaves");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderSaves_AspNetUsers_BuyerId",
                table: "OrderSaves");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderSaves_Products_SaveId",
                table: "OrderSaves");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Accounts_AccountId1",
                table: "Products");

            migrationBuilder.DropTable(
                name: "OrderInsurances");

            migrationBuilder.DropTable(
                name: "OrderInvestments");

            migrationBuilder.DropTable(
                name: "OrderLoans");

            migrationBuilder.DropIndex(
                name: "IX_Products_AccountId1",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_OrderPayments_AccountId",
                table: "OrderPayments");

            migrationBuilder.DropIndex(
                name: "IX_OrderPayments_BuyerId",
                table: "OrderPayments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderSaves",
                table: "OrderSaves");

            migrationBuilder.DropIndex(
                name: "IX_OrderSaves_AccountId",
                table: "OrderSaves");

            migrationBuilder.DropIndex(
                name: "IX_OrderSaves_BuyerId",
                table: "OrderSaves");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "OrderPayments");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "OrderPayments");

            migrationBuilder.DropColumn(
                name: "BuyerId",
                table: "OrderPayments");

            migrationBuilder.DropColumn(
                name: "CompletedOn",
                table: "OrderPayments");

            migrationBuilder.DropColumn(
                name: "CostPrice",
                table: "OrderPayments");

            migrationBuilder.DropColumn(
                name: "InterestRate",
                table: "OrderPayments");

            migrationBuilder.DropColumn(
                name: "IssuedOn",
                table: "OrderPayments");

            migrationBuilder.DropColumn(
                name: "MonthlyFee",
                table: "OrderPayments");

            migrationBuilder.DropColumn(
                name: "Period",
                table: "OrderPayments");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "OrderPayments");

            migrationBuilder.RenameTable(
                name: "OrderSaves",
                newName: "Orders");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "OrderPayments",
                newName: "BankUserId");

            migrationBuilder.RenameColumn(
                name: "BuyerId",
                table: "Orders",
                newName: "OrderType");

            migrationBuilder.RenameIndex(
                name: "IX_OrderSaves_SaveId",
                table: "Orders",
                newName: "IX_Orders_SaveId");

            migrationBuilder.AlterColumn<string>(
                name: "ProductType",
                table: "Products",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "BankUserId",
                table: "OrderPayments",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OrderType",
                table: "Orders",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "BankUserId",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InsuranceId",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrderInvestment_BankUserId",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InvestmentId",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrderLoan_BankUserId",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LoanId",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrderSave_BankUserId",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_OrderPayments_BankUserId",
                table: "OrderPayments",
                column: "BankUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AccountId",
                table: "Orders",
                column: "AccountId",
                unique: true,
                filter: "[AccountId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BankUserId",
                table: "Orders",
                column: "BankUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_InsuranceId",
                table: "Orders",
                column: "InsuranceId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderInvestment_BankUserId",
                table: "Orders",
                column: "OrderInvestment_BankUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_InvestmentId",
                table: "Orders",
                column: "InvestmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderLoan_BankUserId",
                table: "Orders",
                column: "OrderLoan_BankUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_LoanId",
                table: "Orders",
                column: "LoanId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderSave_BankUserId",
                table: "Orders",
                column: "OrderSave_BankUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderPayments_AspNetUsers_BankUserId",
                table: "OrderPayments",
                column: "BankUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Accounts_AccountId",
                table: "Orders",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_BankUserId",
                table: "Orders",
                column: "BankUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Products_InsuranceId",
                table: "Orders",
                column: "InsuranceId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_OrderInvestment_BankUserId",
                table: "Orders",
                column: "OrderInvestment_BankUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Products_InvestmentId",
                table: "Orders",
                column: "InvestmentId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_OrderLoan_BankUserId",
                table: "Orders",
                column: "OrderLoan_BankUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Products_LoanId",
                table: "Orders",
                column: "LoanId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_OrderSave_BankUserId",
                table: "Orders",
                column: "OrderSave_BankUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Products_SaveId",
                table: "Orders",
                column: "SaveId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderPayments_AspNetUsers_BankUserId",
                table: "OrderPayments");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Accounts_AccountId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_BankUserId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Products_InsuranceId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_OrderInvestment_BankUserId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Products_InvestmentId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_OrderLoan_BankUserId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Products_LoanId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_OrderSave_BankUserId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Products_SaveId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_OrderPayments_BankUserId",
                table: "OrderPayments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_AccountId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_BankUserId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_InsuranceId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_OrderInvestment_BankUserId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_InvestmentId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_OrderLoan_BankUserId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_LoanId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_OrderSave_BankUserId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "BankUserId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "InsuranceId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderInvestment_BankUserId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "InvestmentId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderLoan_BankUserId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "LoanId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderSave_BankUserId",
                table: "Orders");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "OrderSaves");

            migrationBuilder.RenameColumn(
                name: "BankUserId",
                table: "OrderPayments",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "OrderType",
                table: "OrderSaves",
                newName: "BuyerId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_SaveId",
                table: "OrderSaves",
                newName: "IX_OrderSaves_SaveId");

            migrationBuilder.AlterColumn<int>(
                name: "ProductType",
                table: "Products",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "OrderPayments",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AccountId",
                table: "OrderPayments",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "OrderPayments",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "BuyerId",
                table: "OrderPayments",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CompletedOn",
                table: "OrderPayments",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "CostPrice",
                table: "OrderPayments",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "InterestRate",
                table: "OrderPayments",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "IssuedOn",
                table: "OrderPayments",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "MonthlyFee",
                table: "OrderPayments",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Period",
                table: "OrderPayments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "OrderPayments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "BuyerId",
                table: "OrderSaves",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderSaves",
                table: "OrderSaves",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "OrderInsurances",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AccountId = table.Column<string>(nullable: true),
                    Amount = table.Column<decimal>(nullable: false),
                    BuyerId = table.Column<string>(nullable: false),
                    CompletedOn = table.Column<DateTime>(nullable: true),
                    CostPrice = table.Column<decimal>(nullable: false),
                    InsuranceId = table.Column<string>(nullable: true),
                    InterestRate = table.Column<decimal>(nullable: false),
                    IssuedOn = table.Column<DateTime>(nullable: false),
                    MonthlyFee = table.Column<decimal>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Period = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderInsurances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderInsurances_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderInsurances_AspNetUsers_BuyerId",
                        column: x => x.BuyerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderInsurances_Products_InsuranceId",
                        column: x => x.InsuranceId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderInvestments",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AccountId = table.Column<string>(nullable: true),
                    Amount = table.Column<decimal>(nullable: false),
                    BuyerId = table.Column<string>(nullable: false),
                    CompletedOn = table.Column<DateTime>(nullable: true),
                    CostPrice = table.Column<decimal>(nullable: false),
                    InterestRate = table.Column<decimal>(nullable: false),
                    InvestmentId = table.Column<string>(nullable: true),
                    IssuedOn = table.Column<DateTime>(nullable: false),
                    MonthlyFee = table.Column<decimal>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Period = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderInvestments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderInvestments_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderInvestments_AspNetUsers_BuyerId",
                        column: x => x.BuyerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderInvestments_Products_InvestmentId",
                        column: x => x.InvestmentId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderLoans",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AccountId = table.Column<string>(nullable: true),
                    Amount = table.Column<decimal>(nullable: false),
                    BuyerId = table.Column<string>(nullable: false),
                    CompletedOn = table.Column<DateTime>(nullable: true),
                    CostPrice = table.Column<decimal>(nullable: false),
                    InterestRate = table.Column<decimal>(nullable: false),
                    IssuedOn = table.Column<DateTime>(nullable: false),
                    LoanId = table.Column<string>(nullable: true),
                    MonthlyFee = table.Column<decimal>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Period = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderLoans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderLoans_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderLoans_AspNetUsers_BuyerId",
                        column: x => x.BuyerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderLoans_Products_LoanId",
                        column: x => x.LoanId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_AccountId1",
                table: "Products",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderPayments_AccountId",
                table: "OrderPayments",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderPayments_BuyerId",
                table: "OrderPayments",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderSaves_AccountId",
                table: "OrderSaves",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderSaves_BuyerId",
                table: "OrderSaves",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderInsurances_AccountId",
                table: "OrderInsurances",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderInsurances_BuyerId",
                table: "OrderInsurances",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderInsurances_InsuranceId",
                table: "OrderInsurances",
                column: "InsuranceId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderInvestments_AccountId",
                table: "OrderInvestments",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderInvestments_BuyerId",
                table: "OrderInvestments",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderInvestments_InvestmentId",
                table: "OrderInvestments",
                column: "InvestmentId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLoans_AccountId",
                table: "OrderLoans",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLoans_BuyerId",
                table: "OrderLoans",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLoans_LoanId",
                table: "OrderLoans",
                column: "LoanId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderPayments_Accounts_AccountId",
                table: "OrderPayments",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderPayments_AspNetUsers_BuyerId",
                table: "OrderPayments",
                column: "BuyerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderSaves_Accounts_AccountId",
                table: "OrderSaves",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderSaves_AspNetUsers_BuyerId",
                table: "OrderSaves",
                column: "BuyerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderSaves_Products_SaveId",
                table: "OrderSaves",
                column: "SaveId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Accounts_AccountId1",
                table: "Products",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
