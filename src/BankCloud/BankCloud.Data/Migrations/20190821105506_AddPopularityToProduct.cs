using Microsoft.EntityFrameworkCore.Migrations;

namespace BankCloud.Data.Migrations
{
    public partial class AddPopularityToProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Popularity",
                table: "Products",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Popularity",
                table: "Products");
        }
    }
}
