using Microsoft.EntityFrameworkCore.Migrations;

namespace BankCloud.Data.Migrations
{
    public partial class InitialCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Addresses_AddressId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_FullNames_FullNameId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_AspNetUsers_ActiveMemberId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "ActiveMemberId",
                table: "Products",
                newName: "BankUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_ActiveMemberId",
                table: "Products",
                newName: "IX_Products_BankUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Addresses_AddressId",
                table: "AspNetUsers",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_FullNames_FullNameId",
                table: "AspNetUsers",
                column: "FullNameId",
                principalTable: "FullNames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_AspNetUsers_BankUserId",
                table: "Products",
                column: "BankUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Addresses_AddressId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_FullNames_FullNameId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_AspNetUsers_BankUserId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "BankUserId",
                table: "Products",
                newName: "ActiveMemberId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_BankUserId",
                table: "Products",
                newName: "IX_Products_ActiveMemberId");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Addresses_AddressId",
                table: "AspNetUsers",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_FullNames_FullNameId",
                table: "AspNetUsers",
                column: "FullNameId",
                principalTable: "FullNames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_AspNetUsers_ActiveMemberId",
                table: "Products",
                column: "ActiveMemberId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
