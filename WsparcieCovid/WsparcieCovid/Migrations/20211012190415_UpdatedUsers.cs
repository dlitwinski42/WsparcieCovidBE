using Microsoft.EntityFrameworkCore.Migrations;

namespace WsparcieCovid.Migrations
{
    public partial class UpdatedUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Entrepreneurs");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Entrepreneurs");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Entrepreneurs");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Contributors");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Contributors");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Contributors");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Users",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "EntrepreneurId",
                table: "Reviews",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_EntrepreneurId",
                table: "Reviews",
                column: "EntrepreneurId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Entrepreneurs_EntrepreneurId",
                table: "Reviews",
                column: "EntrepreneurId",
                principalTable: "Entrepreneurs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Entrepreneurs_EntrepreneurId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_EntrepreneurId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "EntrepreneurId",
                table: "Reviews");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Entrepreneurs",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Entrepreneurs",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Entrepreneurs",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Contributors",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Contributors",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Contributors",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
