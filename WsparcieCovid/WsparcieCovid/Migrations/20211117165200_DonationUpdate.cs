using Microsoft.EntityFrameworkCore.Migrations;

namespace WsparcieCovid.Migrations
{
    public partial class DonationUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DonationCode",
                table: "Donations",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DonationCode",
                table: "Donations");
        }
    }
}
