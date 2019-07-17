using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BankCloud.Data.Migrations
{
    public partial class InitialCreateAddOrders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrderInvestments",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    IssuedOn = table.Column<DateTime>(nullable: false),
                    CompletedOn = table.Column<DateTime>(nullable: true),
                    CostPrice = table.Column<decimal>(nullable: false),
                    ContractorId = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    InvestmentId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderInvestments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderInvestments_AspNetUsers_ContractorId",
                        column: x => x.ContractorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderInvestments_Investments_InvestmentId",
                        column: x => x.InvestmentId,
                        principalTable: "Investments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderPayments",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    IssuedOn = table.Column<DateTime>(nullable: false),
                    CompletedOn = table.Column<DateTime>(nullable: true),
                    CostPrice = table.Column<decimal>(nullable: false),
                    ContractorId = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    PaymentId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderPayments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderPayments_AspNetUsers_ContractorId",
                        column: x => x.ContractorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderPayments_Payments_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "Payments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderSaves",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    IssuedOn = table.Column<DateTime>(nullable: false),
                    CompletedOn = table.Column<DateTime>(nullable: true),
                    CostPrice = table.Column<decimal>(nullable: false),
                    ContractorId = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    SaveId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderSaves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderSaves_AspNetUsers_ContractorId",
                        column: x => x.ContractorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderSaves_Saves_SaveId",
                        column: x => x.SaveId,
                        principalTable: "Saves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderInvestments_ContractorId",
                table: "OrderInvestments",
                column: "ContractorId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderInvestments_InvestmentId",
                table: "OrderInvestments",
                column: "InvestmentId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderPayments_ContractorId",
                table: "OrderPayments",
                column: "ContractorId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderPayments_PaymentId",
                table: "OrderPayments",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderSaves_ContractorId",
                table: "OrderSaves",
                column: "ContractorId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderSaves_SaveId",
                table: "OrderSaves",
                column: "SaveId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderInvestments");

            migrationBuilder.DropTable(
                name: "OrderPayments");

            migrationBuilder.DropTable(
                name: "OrderSaves");
        }
    }
}
