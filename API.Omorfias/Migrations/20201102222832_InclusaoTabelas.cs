using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace API.Omorfias.Migrations
{
    public partial class InclusaoTabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "AccountType",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Adress",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Street = table.Column<string>(nullable: true),
                    Number = table.Column<int>(nullable: false),
                    Neighborhood = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Telephone = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adress", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Card",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Number = table.Column<decimal>(nullable: false),
                    CardHolder = table.Column<string>(nullable: true),
                    ExpirationDate = table.Column<DateTime>(nullable: false),
                    SecurityCode = table.Column<int>(nullable: false),
                    CardType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Card", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Premium",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Premium", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceLocation",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Home = table.Column<bool>(nullable: false),
                    Store = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceLocation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserName = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    AccountTypeId = table.Column<int>(nullable: true),
                    PremiumId = table.Column<int>(nullable: true),
                    CardId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_AccountType_AccountTypeId",
                        column: x => x.AccountTypeId,
                        principalSchema: "dbo",
                        principalTable: "AccountType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_Card_CardId",
                        column: x => x.CardId,
                        principalSchema: "dbo",
                        principalTable: "Card",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_Premium_PremiumId",
                        column: x => x.PremiumId,
                        principalSchema: "dbo",
                        principalTable: "Premium",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Enterprise",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true),
                    Evaluation = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Telephone = table.Column<decimal>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: true),
                    AverageValue = table.Column<int>(nullable: false),
                    Cnpj = table.Column<decimal>(nullable: true),
                    Cpf = table.Column<decimal>(nullable: true),
                    Category = table.Column<int>(nullable: false),
                    UrlImage = table.Column<string>(nullable: true),
                    ServiceLocationId = table.Column<int>(nullable: true),
                    AdressId = table.Column<int>(nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enterprise", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enterprise_Adress_AdressId",
                        column: x => x.AdressId,
                        principalSchema: "dbo",
                        principalTable: "Adress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Enterprise_ServiceLocation_ServiceLocationId",
                        column: x => x.ServiceLocationId,
                        principalSchema: "dbo",
                        principalTable: "ServiceLocation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Enterprise_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Post",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Post_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Favorites",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EnterpriseId = table.Column<int>(nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favorites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Favorites_Enterprise_EnterpriseId",
                        column: x => x.EnterpriseId,
                        principalSchema: "dbo",
                        principalTable: "Enterprise",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Favorites_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Scheduling",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ServiceLocation = table.Column<int>(nullable: false),
                    CardId = table.Column<int>(nullable: true),
                    EnterpriseId = table.Column<int>(nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scheduling", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Scheduling_Card_CardId",
                        column: x => x.CardId,
                        principalSchema: "dbo",
                        principalTable: "Card",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Scheduling_Enterprise_EnterpriseId",
                        column: x => x.EnterpriseId,
                        principalSchema: "dbo",
                        principalTable: "Enterprise",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Scheduling_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CategoryEnum = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    EnterpriseId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Services_Enterprise_EnterpriseId",
                        column: x => x.EnterpriseId,
                        principalSchema: "dbo",
                        principalTable: "Enterprise",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enterprise_AdressId",
                schema: "dbo",
                table: "Enterprise",
                column: "AdressId");

            migrationBuilder.CreateIndex(
                name: "IX_Enterprise_ServiceLocationId",
                schema: "dbo",
                table: "Enterprise",
                column: "ServiceLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Enterprise_UserId",
                schema: "dbo",
                table: "Enterprise",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_EnterpriseId",
                schema: "dbo",
                table: "Favorites",
                column: "EnterpriseId");

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_UserId",
                schema: "dbo",
                table: "Favorites",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_UserId",
                schema: "dbo",
                table: "Post",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Scheduling_CardId",
                schema: "dbo",
                table: "Scheduling",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_Scheduling_EnterpriseId",
                schema: "dbo",
                table: "Scheduling",
                column: "EnterpriseId");

            migrationBuilder.CreateIndex(
                name: "IX_Scheduling_UserId",
                schema: "dbo",
                table: "Scheduling",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_EnterpriseId",
                schema: "dbo",
                table: "Services",
                column: "EnterpriseId");

            migrationBuilder.CreateIndex(
                name: "IX_User_AccountTypeId",
                schema: "dbo",
                table: "User",
                column: "AccountTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_User_CardId",
                schema: "dbo",
                table: "User",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_User_PremiumId",
                schema: "dbo",
                table: "User",
                column: "PremiumId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Favorites",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Post",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Scheduling",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Services",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Enterprise",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Adress",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ServiceLocation",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "User",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AccountType",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Card",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Premium",
                schema: "dbo");
        }
    }
}
