using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace WsparcieCovid.Migrations
{
    public partial class DbFinished : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Users",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Users",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PassHash",
                table: "Users",
                type: "character varying(400)",
                maxLength: 400,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Contributors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contributors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contributors_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Entrepreneurs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    FirstName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    NipNumber = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    BankAccountNumber = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entrepreneurs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Entrepreneurs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    OrderComment = table.Column<string>(type: "text", nullable: false),
                    ReturnMsg = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "varchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ReviewBody = table.Column<string>(type: "text", nullable: false),
                    Grade = table.Column<int>(type: "integer", nullable: false),
                    ContributorId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Contributors_ContributorId",
                        column: x => x.ContributorId,
                        principalTable: "Contributors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    City = table.Column<string>(type: "text", nullable: false),
                    Street = table.Column<string>(type: "text", nullable: false),
                    HouseNumber = table.Column<string>(type: "text", nullable: false),
                    FlatNumber = table.Column<string>(type: "text", nullable: false),
                    ContributorId = table.Column<int>(type: "integer", nullable: true),
                    EntrepreneurId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Contributors_ContributorId",
                        column: x => x.ContributorId,
                        principalTable: "Contributors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Addresses_Entrepreneurs_EntrepreneurId",
                        column: x => x.EntrepreneurId,
                        principalTable: "Entrepreneurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Donations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ContributorId = table.Column<int>(type: "integer", nullable: true),
                    EntrepreneurId = table.Column<int>(type: "integer", nullable: true),
                    Amount = table.Column<float>(type: "real", nullable: false),
                    Status = table.Column<string>(type: "varchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Donations_Contributors_ContributorId",
                        column: x => x.ContributorId,
                        principalTable: "Contributors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Donations_Entrepreneurs_EntrepreneurId",
                        column: x => x.EntrepreneurId,
                        principalTable: "Entrepreneurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GiftCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RedeemCode = table.Column<string>(type: "text", nullable: false),
                    ContributorId = table.Column<int>(type: "integer", nullable: true),
                    EntrepreneurId = table.Column<int>(type: "integer", nullable: true),
                    Status = table.Column<string>(type: "varchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiftCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GiftCards_Contributors_ContributorId",
                        column: x => x.ContributorId,
                        principalTable: "Contributors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GiftCards_Entrepreneurs_EntrepreneurId",
                        column: x => x.EntrepreneurId,
                        principalTable: "Entrepreneurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SupportMethods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EntrepreneurId = table.Column<int>(type: "integer", nullable: true),
                    CanDonate = table.Column<bool>(type: "boolean", nullable: false),
                    CanOrder = table.Column<bool>(type: "boolean", nullable: false),
                    CanGiftCard = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupportMethods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SupportMethods_Entrepreneurs_EntrepreneurId",
                        column: x => x.EntrepreneurId,
                        principalTable: "Entrepreneurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ContributorId = table.Column<int>(type: "integer", nullable: true),
                    EntrepreneurId = table.Column<int>(type: "integer", nullable: true),
                    ProductId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Contributors_ContributorId",
                        column: x => x.ContributorId,
                        principalTable: "Contributors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Entrepreneurs_EntrepreneurId",
                        column: x => x.EntrepreneurId,
                        principalTable: "Entrepreneurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_ContributorId",
                table: "Addresses",
                column: "ContributorId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_EntrepreneurId",
                table: "Addresses",
                column: "EntrepreneurId");

            migrationBuilder.CreateIndex(
                name: "IX_Contributors_UserId",
                table: "Contributors",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Donations_ContributorId",
                table: "Donations",
                column: "ContributorId");

            migrationBuilder.CreateIndex(
                name: "IX_Donations_EntrepreneurId",
                table: "Donations",
                column: "EntrepreneurId");

            migrationBuilder.CreateIndex(
                name: "IX_Entrepreneurs_UserId",
                table: "Entrepreneurs",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GiftCards_ContributorId",
                table: "GiftCards",
                column: "ContributorId");

            migrationBuilder.CreateIndex(
                name: "IX_GiftCards_EntrepreneurId",
                table: "GiftCards",
                column: "EntrepreneurId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ContributorId",
                table: "Orders",
                column: "ContributorId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_EntrepreneurId",
                table: "Orders",
                column: "EntrepreneurId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ProductId",
                table: "Orders",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ContributorId",
                table: "Reviews",
                column: "ContributorId");

            migrationBuilder.CreateIndex(
                name: "IX_SupportMethods_EntrepreneurId",
                table: "SupportMethods",
                column: "EntrepreneurId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Donations");

            migrationBuilder.DropTable(
                name: "GiftCards");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "SupportMethods");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Contributors");

            migrationBuilder.DropTable(
                name: "Entrepreneurs");

            migrationBuilder.DropColumn(
                name: "PassHash",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "UserId");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);
        }
    }
}
