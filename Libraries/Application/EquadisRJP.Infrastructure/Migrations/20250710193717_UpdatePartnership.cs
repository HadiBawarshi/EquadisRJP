using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EquadisRJP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePartnership : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Supplier");

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Partnership",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Partnership",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Partnership");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Partnership");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Supplier",
                type: "nvarchar(511)",
                maxLength: 511,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Supplier",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }
    }
}
