using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EquadisRJP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCommercialOffer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommercialOffer_Supplier",
                table: "CommercialOffer");

            migrationBuilder.AlterColumn<int>(
                name: "SupplierId",
                table: "CommercialOffer",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "CommercialOffer",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_CommercialOffer_Supplier",
                table: "CommercialOffer",
                column: "SupplierId",
                principalTable: "Supplier",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommercialOffer_Supplier",
                table: "CommercialOffer");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "CommercialOffer");

            migrationBuilder.AlterColumn<int>(
                name: "SupplierId",
                table: "CommercialOffer",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_CommercialOffer_Supplier",
                table: "CommercialOffer",
                column: "SupplierId",
                principalTable: "Supplier",
                principalColumn: "Id");
        }
    }
}
