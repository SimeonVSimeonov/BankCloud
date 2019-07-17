using Microsoft.EntityFrameworkCore.Migrations;

namespace BankCloud.Data.Migrations
{
    public partial class InitialCreate1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CurencyId",
                table: "Saves",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Saves",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SellerID",
                table: "Saves",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CurencyId",
                table: "Payments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Payments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SellerID",
                table: "Payments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CurencyId",
                table: "Investments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Investments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SellerID",
                table: "Investments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SellerID",
                table: "Insurances",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Saves_CurencyId",
                table: "Saves",
                column: "CurencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Saves_SellerID",
                table: "Saves",
                column: "SellerID");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_CurencyId",
                table: "Payments",
                column: "CurencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_SellerID",
                table: "Payments",
                column: "SellerID");

            migrationBuilder.CreateIndex(
                name: "IX_Investments_CurencyId",
                table: "Investments",
                column: "CurencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Investments_SellerID",
                table: "Investments",
                column: "SellerID");

            migrationBuilder.CreateIndex(
                name: "IX_Insurances_SellerID",
                table: "Insurances",
                column: "SellerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Insurances_AspNetUsers_SellerID",
                table: "Insurances",
                column: "SellerID",
                principalTable: "AspNetUsers",
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
                name: "FK_Investments_AspNetUsers_SellerID",
                table: "Investments",
                column: "SellerID",
                principalTable: "AspNetUsers",
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
                name: "FK_Payments_AspNetUsers_SellerID",
                table: "Payments",
                column: "SellerID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Saves_Curencies_CurencyId",
                table: "Saves",
                column: "CurencyId",
                principalTable: "Curencies",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Insurances_AspNetUsers_SellerID",
                table: "Insurances");

            migrationBuilder.DropForeignKey(
                name: "FK_Investments_Curencies_CurencyId",
                table: "Investments");

            migrationBuilder.DropForeignKey(
                name: "FK_Investments_AspNetUsers_SellerID",
                table: "Investments");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Curencies_CurencyId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_AspNetUsers_SellerID",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Saves_Curencies_CurencyId",
                table: "Saves");

            migrationBuilder.DropForeignKey(
                name: "FK_Saves_AspNetUsers_SellerID",
                table: "Saves");

            migrationBuilder.DropIndex(
                name: "IX_Saves_CurencyId",
                table: "Saves");

            migrationBuilder.DropIndex(
                name: "IX_Saves_SellerID",
                table: "Saves");

            migrationBuilder.DropIndex(
                name: "IX_Payments_CurencyId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_SellerID",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Investments_CurencyId",
                table: "Investments");

            migrationBuilder.DropIndex(
                name: "IX_Investments_SellerID",
                table: "Investments");

            migrationBuilder.DropIndex(
                name: "IX_Insurances_SellerID",
                table: "Insurances");

            migrationBuilder.DropColumn(
                name: "CurencyId",
                table: "Saves");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Saves");

            migrationBuilder.DropColumn(
                name: "SellerID",
                table: "Saves");

            migrationBuilder.DropColumn(
                name: "CurencyId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "SellerID",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "CurencyId",
                table: "Investments");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Investments");

            migrationBuilder.DropColumn(
                name: "SellerID",
                table: "Investments");

            migrationBuilder.DropColumn(
                name: "SellerID",
                table: "Insurances");
        }
    }
}
