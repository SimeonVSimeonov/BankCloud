using Microsoft.EntityFrameworkCore.Migrations;

namespace BankCloud.Data.Migrations
{
    public partial class AddAbstractOrder3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_OrderInvestment_BankUserId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_OrderLoan_BankUserId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_OrderSave_BankUserId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "OrderPayments");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Orders_OrderInvestment_BankUserId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_OrderLoan_BankUserId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_OrderSave_BankUserId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderInvestment_BankUserId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderLoan_BankUserId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderSave_BankUserId",
                table: "Orders");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OrderInvestment_BankUserId",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrderLoan_BankUserId",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrderSave_BankUserId",
                table: "Orders",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CurrencyId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    SellerID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Payments_AspNetUsers_SellerID",
                        column: x => x.SellerID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderPayments",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    BankUserId = table.Column<string>(nullable: true),
                    PaymentId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderPayments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderPayments_AspNetUsers_BankUserId",
                        column: x => x.BankUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderPayments_Payments_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "Payments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderInvestment_BankUserId",
                table: "Orders",
                column: "OrderInvestment_BankUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderLoan_BankUserId",
                table: "Orders",
                column: "OrderLoan_BankUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderSave_BankUserId",
                table: "Orders",
                column: "OrderSave_BankUserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderPayments_BankUserId",
                table: "OrderPayments",
                column: "BankUserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderPayments_PaymentId",
                table: "OrderPayments",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_CurrencyId",
                table: "Payments",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_SellerID",
                table: "Payments",
                column: "SellerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_OrderInvestment_BankUserId",
                table: "Orders",
                column: "OrderInvestment_BankUserId",
                principalTable: "AspNetUsers",
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
                name: "FK_Orders_AspNetUsers_OrderSave_BankUserId",
                table: "Orders",
                column: "OrderSave_BankUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
