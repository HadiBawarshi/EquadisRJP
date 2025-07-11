using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EquadisRJP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addfieldtoOfferSubscription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValidFrom",
                table: "OfferSubscription");

            migrationBuilder.DropColumn(
                name: "ValidTo",
                table: "OfferSubscription");

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "OfferSubscription",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "OfferSubscription");

            migrationBuilder.AddColumn<DateTime>(
                name: "ValidFrom",
                table: "OfferSubscription",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ValidTo",
                table: "OfferSubscription",
                type: "datetime",
                nullable: true);
        }
    }
}
