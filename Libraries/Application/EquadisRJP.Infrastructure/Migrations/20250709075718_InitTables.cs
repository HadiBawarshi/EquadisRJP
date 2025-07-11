using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EquadisRJP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StoreType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Supplier",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(511)", maxLength: 511, nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Supplier_Country",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Retailer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreName = table.Column<string>(type: "nvarchar(511)", maxLength: 511, nullable: true),
                    StoreTypeId = table.Column<int>(type: "int", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Retailer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Retailer_StoreType",
                        column: x => x.StoreTypeId,
                        principalTable: "StoreType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CommercialOffer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(511)", maxLength: 511, nullable: true),
                    ValidFrom = table.Column<DateTime>(type: "datetime", nullable: true),
                    ValidTo = table.Column<DateTime>(type: "datetime", nullable: true),
                    DiscountValuePercentage = table.Column<int>(type: "int", nullable: true),
                    SupplierId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommercialOffer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommercialOffer_Supplier",
                        column: x => x.SupplierId,
                        principalTable: "Supplier",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Partnership",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RetailerId = table.Column<int>(type: "int", nullable: true),
                    SupplierId = table.Column<int>(type: "int", nullable: true),
                    ExpiryDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partnership", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Partnership_Retailer",
                        column: x => x.RetailerId,
                        principalTable: "Retailer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Partnership_Supplier",
                        column: x => x.SupplierId,
                        principalTable: "Supplier",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OfferSubscription",
                columns: table => new
                {
                    RetailerId = table.Column<int>(type: "int", nullable: true),
                    CommercialOfferId = table.Column<int>(type: "int", nullable: true),
                    ValidFrom = table.Column<DateTime>(type: "datetime", nullable: true),
                    ValidTo = table.Column<DateTime>(type: "datetime", nullable: true),
                    Id = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_OfferSubscription_CommercialOffer",
                        column: x => x.CommercialOfferId,
                        principalTable: "CommercialOffer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OfferSubscription_Retailer",
                        column: x => x.RetailerId,
                        principalTable: "Retailer",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommercialOffer_SupplierId",
                table: "CommercialOffer",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferSubscription_CommercialOfferId",
                table: "OfferSubscription",
                column: "CommercialOfferId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferSubscription_RetailerId",
                table: "OfferSubscription",
                column: "RetailerId");

            migrationBuilder.CreateIndex(
                name: "IX_Partnership_RetailerId",
                table: "Partnership",
                column: "RetailerId");

            migrationBuilder.CreateIndex(
                name: "IX_Partnership_SupplierId",
                table: "Partnership",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Retailer_StoreTypeId",
                table: "Retailer",
                column: "StoreTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_CountryId",
                table: "Supplier",
                column: "CountryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OfferSubscription");

            migrationBuilder.DropTable(
                name: "Partnership");

            migrationBuilder.DropTable(
                name: "CommercialOffer");

            migrationBuilder.DropTable(
                name: "Retailer");

            migrationBuilder.DropTable(
                name: "Supplier");

            migrationBuilder.DropTable(
                name: "StoreType");

            migrationBuilder.DropTable(
                name: "Country");
        }
    }
}
