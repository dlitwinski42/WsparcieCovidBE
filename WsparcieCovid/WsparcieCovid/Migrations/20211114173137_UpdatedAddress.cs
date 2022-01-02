using Microsoft.EntityFrameworkCore.Migrations;

namespace WsparcieCovid.Migrations
{
    public partial class UpdatedAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Addresses_ContributorId",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_EntrepreneurId",
                table: "Addresses");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Entrepreneurs",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_ContributorId",
                table: "Addresses",
                column: "ContributorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_EntrepreneurId",
                table: "Addresses",
                column: "EntrepreneurId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Addresses_ContributorId",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_EntrepreneurId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Entrepreneurs");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_ContributorId",
                table: "Addresses",
                column: "ContributorId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_EntrepreneurId",
                table: "Addresses",
                column: "EntrepreneurId");
        }
    }
}
