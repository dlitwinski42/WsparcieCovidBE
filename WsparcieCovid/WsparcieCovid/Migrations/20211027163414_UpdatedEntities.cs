using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WsparcieCovid.Migrations
{
    public partial class UpdatedEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Products_ProductId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_SupportMethods_EntrepreneurId",
                table: "SupportMethods");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ProductId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderComment",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "ReturnMsg",
                table: "Products",
                newName: "Name");

            migrationBuilder.AddColumn<DateTime>(
                name: "Timestamp",
                table: "Reviews",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "EntrepreneurId",
                table: "Products",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Products",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOrdered",
                table: "Orders",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DatePaid",
                table: "Orders",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateReceived",
                table: "Orders",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Orders",
                type: "varchar(20)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateConfirmed",
                table: "Donations",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateSent",
                table: "Donations",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_SupportMethods_EntrepreneurId",
                table: "SupportMethods",
                column: "EntrepreneurId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_EntrepreneurId",
                table: "Products",
                column: "EntrepreneurId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductId",
                table: "Products",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Entrepreneurs_EntrepreneurId",
                table: "Products",
                column: "EntrepreneurId",
                principalTable: "Entrepreneurs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Orders_ProductId",
                table: "Products",
                column: "ProductId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Entrepreneurs_EntrepreneurId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Orders_ProductId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_SupportMethods_EntrepreneurId",
                table: "SupportMethods");

            migrationBuilder.DropIndex(
                name: "IX_Products_EntrepreneurId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Timestamp",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "EntrepreneurId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DateOrdered",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DatePaid",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DateReceived",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DateConfirmed",
                table: "Donations");

            migrationBuilder.DropColumn(
                name: "DateSent",
                table: "Donations");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Products",
                newName: "ReturnMsg");

            migrationBuilder.AddColumn<string>(
                name: "OrderComment",
                table: "Products",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Products",
                type: "varchar(20)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Orders",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SupportMethods_EntrepreneurId",
                table: "SupportMethods",
                column: "EntrepreneurId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ProductId",
                table: "Orders",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Products_ProductId",
                table: "Orders",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
