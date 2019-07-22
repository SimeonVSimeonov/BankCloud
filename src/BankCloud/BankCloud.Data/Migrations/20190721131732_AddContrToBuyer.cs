using Microsoft.EntityFrameworkCore.Migrations;

namespace BankCloud.Data.Migrations
{
    public partial class AddContrToBuyer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CreditScorings_AspNetUsers_ContractorId",
                table: "CreditScorings");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderInsurances_AspNetUsers_ContractorId",
                table: "OrderInsurances");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderInvestments_AspNetUsers_ContractorId",
                table: "OrderInvestments");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderLoans_AspNetUsers_ContractorId",
                table: "OrderLoans");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderPayments_AspNetUsers_ContractorId",
                table: "OrderPayments");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderSaves_AspNetUsers_ContractorId",
                table: "OrderSaves");

            migrationBuilder.RenameColumn(
                name: "ContractorId",
                table: "OrderSaves",
                newName: "BuyerId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderSaves_ContractorId",
                table: "OrderSaves",
                newName: "IX_OrderSaves_BuyerId");

            migrationBuilder.RenameColumn(
                name: "ContractorId",
                table: "OrderPayments",
                newName: "BuyerId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderPayments_ContractorId",
                table: "OrderPayments",
                newName: "IX_OrderPayments_BuyerId");

            migrationBuilder.RenameColumn(
                name: "ContractorId",
                table: "OrderLoans",
                newName: "BuyerId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderLoans_ContractorId",
                table: "OrderLoans",
                newName: "IX_OrderLoans_BuyerId");

            migrationBuilder.RenameColumn(
                name: "ContractorId",
                table: "OrderInvestments",
                newName: "BuyerId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderInvestments_ContractorId",
                table: "OrderInvestments",
                newName: "IX_OrderInvestments_BuyerId");

            migrationBuilder.RenameColumn(
                name: "ContractorId",
                table: "OrderInsurances",
                newName: "BuyerId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderInsurances_ContractorId",
                table: "OrderInsurances",
                newName: "IX_OrderInsurances_BuyerId");

            migrationBuilder.RenameColumn(
                name: "ContractorId",
                table: "CreditScorings",
                newName: "BuyerId");

            migrationBuilder.RenameIndex(
                name: "IX_CreditScorings_ContractorId",
                table: "CreditScorings",
                newName: "IX_CreditScorings_BuyerId");

            migrationBuilder.AddForeignKey(
                name: "FK_CreditScorings_AspNetUsers_BuyerId",
                table: "CreditScorings",
                column: "BuyerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderInsurances_AspNetUsers_BuyerId",
                table: "OrderInsurances",
                column: "BuyerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderInvestments_AspNetUsers_BuyerId",
                table: "OrderInvestments",
                column: "BuyerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLoans_AspNetUsers_BuyerId",
                table: "OrderLoans",
                column: "BuyerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderPayments_AspNetUsers_BuyerId",
                table: "OrderPayments",
                column: "BuyerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderSaves_AspNetUsers_BuyerId",
                table: "OrderSaves",
                column: "BuyerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CreditScorings_AspNetUsers_BuyerId",
                table: "CreditScorings");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderInsurances_AspNetUsers_BuyerId",
                table: "OrderInsurances");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderInvestments_AspNetUsers_BuyerId",
                table: "OrderInvestments");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderLoans_AspNetUsers_BuyerId",
                table: "OrderLoans");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderPayments_AspNetUsers_BuyerId",
                table: "OrderPayments");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderSaves_AspNetUsers_BuyerId",
                table: "OrderSaves");

            migrationBuilder.RenameColumn(
                name: "BuyerId",
                table: "OrderSaves",
                newName: "ContractorId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderSaves_BuyerId",
                table: "OrderSaves",
                newName: "IX_OrderSaves_ContractorId");

            migrationBuilder.RenameColumn(
                name: "BuyerId",
                table: "OrderPayments",
                newName: "ContractorId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderPayments_BuyerId",
                table: "OrderPayments",
                newName: "IX_OrderPayments_ContractorId");

            migrationBuilder.RenameColumn(
                name: "BuyerId",
                table: "OrderLoans",
                newName: "ContractorId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderLoans_BuyerId",
                table: "OrderLoans",
                newName: "IX_OrderLoans_ContractorId");

            migrationBuilder.RenameColumn(
                name: "BuyerId",
                table: "OrderInvestments",
                newName: "ContractorId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderInvestments_BuyerId",
                table: "OrderInvestments",
                newName: "IX_OrderInvestments_ContractorId");

            migrationBuilder.RenameColumn(
                name: "BuyerId",
                table: "OrderInsurances",
                newName: "ContractorId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderInsurances_BuyerId",
                table: "OrderInsurances",
                newName: "IX_OrderInsurances_ContractorId");

            migrationBuilder.RenameColumn(
                name: "BuyerId",
                table: "CreditScorings",
                newName: "ContractorId");

            migrationBuilder.RenameIndex(
                name: "IX_CreditScorings_BuyerId",
                table: "CreditScorings",
                newName: "IX_CreditScorings_ContractorId");

            migrationBuilder.AddForeignKey(
                name: "FK_CreditScorings_AspNetUsers_ContractorId",
                table: "CreditScorings",
                column: "ContractorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderInsurances_AspNetUsers_ContractorId",
                table: "OrderInsurances",
                column: "ContractorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderInvestments_AspNetUsers_ContractorId",
                table: "OrderInvestments",
                column: "ContractorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLoans_AspNetUsers_ContractorId",
                table: "OrderLoans",
                column: "ContractorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderPayments_AspNetUsers_ContractorId",
                table: "OrderPayments",
                column: "ContractorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderSaves_AspNetUsers_ContractorId",
                table: "OrderSaves",
                column: "ContractorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
