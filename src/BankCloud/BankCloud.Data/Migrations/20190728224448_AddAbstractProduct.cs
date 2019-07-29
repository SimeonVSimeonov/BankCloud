using Microsoft.EntityFrameworkCore.Migrations;

namespace BankCloud.Data.Migrations
{
    public partial class AddAbstractProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CreditScorings_AspNetUsers_BuyerId",
                table: "CreditScorings");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderInsurances_Insurances_InsuranceId",
                table: "OrderInsurances");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderInvestments_Investments_InvestmentId",
                table: "OrderInvestments");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderLoans_Loans_LoanId",
                table: "OrderLoans");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderSaves_Saves_SaveId",
                table: "OrderSaves");

            migrationBuilder.DropForeignKey(
                name: "FK_Saves_Currencies_CurrencyId",
                table: "Saves");

            migrationBuilder.DropForeignKey(
                name: "FK_Saves_AspNetUsers_SellerID",
                table: "Saves");

            migrationBuilder.DropTable(
                name: "Insurances");

            migrationBuilder.DropTable(
                name: "Investments");

            migrationBuilder.DropTable(
                name: "Loans");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Saves",
                table: "Saves");

            migrationBuilder.DropIndex(
                name: "IX_Saves_CurrencyId",
                table: "Saves");

            migrationBuilder.RenameTable(
                name: "Saves",
                newName: "Products");

            migrationBuilder.RenameColumn(
                name: "CurrencyId",
                table: "Products",
                newName: "AdUrl");

            migrationBuilder.RenameIndex(
                name: "IX_Saves_SellerID",
                table: "Products",
                newName: "IX_Products_SellerID");

            migrationBuilder.AddColumn<string>(
                name: "AccountId",
                table: "OrderSaves",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "OrderSaves",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "InterestRate",
                table: "OrderSaves",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MonthlyFee",
                table: "OrderSaves",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "OrderSaves",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Period",
                table: "OrderSaves",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "AccountId",
                table: "OrderPayments",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "OrderPayments",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "InterestRate",
                table: "OrderPayments",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MonthlyFee",
                table: "OrderPayments",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "OrderPayments",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Period",
                table: "OrderPayments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "AccountId",
                table: "OrderInvestments",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "OrderInvestments",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "InterestRate",
                table: "OrderInvestments",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MonthlyFee",
                table: "OrderInvestments",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "OrderInvestments",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Period",
                table: "OrderInvestments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "AccountId",
                table: "OrderInsurances",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "OrderInsurances",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "InterestRate",
                table: "OrderInsurances",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MonthlyFee",
                table: "OrderInsurances",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "OrderInsurances",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Period",
                table: "OrderInsurances",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "AdUrl",
                table: "Products",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Installment",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AccountId",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "Products",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Commission",
                table: "Products",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "InterestRate",
                table: "Products",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Products",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Period",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductType",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_OrderSaves_AccountId",
                table: "OrderSaves",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderPayments_AccountId",
                table: "OrderPayments",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderInvestments_AccountId",
                table: "OrderInvestments",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderInsurances_AccountId",
                table: "OrderInsurances",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_AccountId",
                table: "Products",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_AccountId1",
                table: "Products",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_CreditScorings_AspNetUsers_BuyerId",
                table: "CreditScorings",
                column: "BuyerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderInsurances_Accounts_AccountId",
                table: "OrderInsurances",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderInsurances_Products_InsuranceId",
                table: "OrderInsurances",
                column: "InsuranceId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderInvestments_Accounts_AccountId",
                table: "OrderInvestments",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderInvestments_Products_InvestmentId",
                table: "OrderInvestments",
                column: "InvestmentId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLoans_Products_LoanId",
                table: "OrderLoans",
                column: "LoanId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderPayments_Accounts_AccountId",
                table: "OrderPayments",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderSaves_Accounts_AccountId",
                table: "OrderSaves",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderSaves_Products_SaveId",
                table: "OrderSaves",
                column: "SaveId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Accounts_AccountId",
                table: "Products",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Accounts_AccountId1",
                table: "Products",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_AspNetUsers_SellerID",
                table: "Products",
                column: "SellerID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CreditScorings_AspNetUsers_BuyerId",
                table: "CreditScorings");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderInsurances_Accounts_AccountId",
                table: "OrderInsurances");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderInsurances_Products_InsuranceId",
                table: "OrderInsurances");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderInvestments_Accounts_AccountId",
                table: "OrderInvestments");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderInvestments_Products_InvestmentId",
                table: "OrderInvestments");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderLoans_Products_LoanId",
                table: "OrderLoans");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderPayments_Accounts_AccountId",
                table: "OrderPayments");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderSaves_Accounts_AccountId",
                table: "OrderSaves");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderSaves_Products_SaveId",
                table: "OrderSaves");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Accounts_AccountId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Accounts_AccountId1",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_AspNetUsers_SellerID",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_OrderSaves_AccountId",
                table: "OrderSaves");

            migrationBuilder.DropIndex(
                name: "IX_OrderPayments_AccountId",
                table: "OrderPayments");

            migrationBuilder.DropIndex(
                name: "IX_OrderInvestments_AccountId",
                table: "OrderInvestments");

            migrationBuilder.DropIndex(
                name: "IX_OrderInsurances_AccountId",
                table: "OrderInsurances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_AccountId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_AccountId1",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "OrderSaves");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "OrderSaves");

            migrationBuilder.DropColumn(
                name: "InterestRate",
                table: "OrderSaves");

            migrationBuilder.DropColumn(
                name: "MonthlyFee",
                table: "OrderSaves");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "OrderSaves");

            migrationBuilder.DropColumn(
                name: "Period",
                table: "OrderSaves");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "OrderPayments");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "OrderPayments");

            migrationBuilder.DropColumn(
                name: "InterestRate",
                table: "OrderPayments");

            migrationBuilder.DropColumn(
                name: "MonthlyFee",
                table: "OrderPayments");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "OrderPayments");

            migrationBuilder.DropColumn(
                name: "Period",
                table: "OrderPayments");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "OrderInvestments");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "OrderInvestments");

            migrationBuilder.DropColumn(
                name: "InterestRate",
                table: "OrderInvestments");

            migrationBuilder.DropColumn(
                name: "MonthlyFee",
                table: "OrderInvestments");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "OrderInvestments");

            migrationBuilder.DropColumn(
                name: "Period",
                table: "OrderInvestments");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "OrderInsurances");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "OrderInsurances");

            migrationBuilder.DropColumn(
                name: "InterestRate",
                table: "OrderInsurances");

            migrationBuilder.DropColumn(
                name: "MonthlyFee",
                table: "OrderInsurances");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "OrderInsurances");

            migrationBuilder.DropColumn(
                name: "Period",
                table: "OrderInsurances");

            migrationBuilder.DropColumn(
                name: "Installment",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Commission",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "InterestRate",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Period",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductType",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Saves");

            migrationBuilder.RenameColumn(
                name: "AdUrl",
                table: "Saves",
                newName: "CurrencyId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_SellerID",
                table: "Saves",
                newName: "IX_Saves_SellerID");

            migrationBuilder.AlterColumn<string>(
                name: "CurrencyId",
                table: "Saves",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Saves",
                table: "Saves",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Insurances",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Coverage = table.Column<decimal>(nullable: false),
                    CurrencyId = table.Column<string>(nullable: true),
                    Installment = table.Column<decimal>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    SellerID = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insurances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Insurances_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Insurances_AspNetUsers_SellerID",
                        column: x => x.SellerID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Investments",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CurrencyId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    SellerID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Investments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Investments_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Investments_AspNetUsers_SellerID",
                        column: x => x.SellerID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Loans",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AccountId = table.Column<string>(nullable: true),
                    AdUrl = table.Column<string>(nullable: true),
                    Amount = table.Column<decimal>(nullable: false),
                    Commission = table.Column<decimal>(nullable: false),
                    InterestRate = table.Column<decimal>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Period = table.Column<int>(nullable: false),
                    SellerID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loans_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Loans_AspNetUsers_SellerID",
                        column: x => x.SellerID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Saves_CurrencyId",
                table: "Saves",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Insurances_CurrencyId",
                table: "Insurances",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Insurances_SellerID",
                table: "Insurances",
                column: "SellerID");

            migrationBuilder.CreateIndex(
                name: "IX_Investments_CurrencyId",
                table: "Investments",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Investments_SellerID",
                table: "Investments",
                column: "SellerID");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_AccountId",
                table: "Loans",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_SellerID",
                table: "Loans",
                column: "SellerID");

            migrationBuilder.AddForeignKey(
                name: "FK_CreditScorings_AspNetUsers_BuyerId",
                table: "CreditScorings",
                column: "BuyerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderInsurances_Insurances_InsuranceId",
                table: "OrderInsurances",
                column: "InsuranceId",
                principalTable: "Insurances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderInvestments_Investments_InvestmentId",
                table: "OrderInvestments",
                column: "InvestmentId",
                principalTable: "Investments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLoans_Loans_LoanId",
                table: "OrderLoans",
                column: "LoanId",
                principalTable: "Loans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderSaves_Saves_SaveId",
                table: "OrderSaves",
                column: "SaveId",
                principalTable: "Saves",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Saves_Currencies_CurrencyId",
                table: "Saves",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Saves_AspNetUsers_SellerID",
                table: "Saves",
                column: "SellerID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
