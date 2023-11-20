using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutomotiveBrands.VehicleService.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class vehicleclassadd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "dbo",
                table: "vehicle",
                type: "character varying(100)",
                unicode: false,
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "Brand",
                schema: "dbo",
                table: "vehicle",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                schema: "dbo",
                table: "vehicle",
                type: "character varying(100)",
                unicode: false,
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ModelYear",
                schema: "dbo",
                table: "vehicle",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_vehicle_Brand",
                schema: "dbo",
                table: "vehicle",
                column: "Brand");

            migrationBuilder.CreateIndex(
                name: "IX_vehicle_ModelYear",
                schema: "dbo",
                table: "vehicle",
                column: "ModelYear");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_vehicle_Brand",
                schema: "dbo",
                table: "vehicle");

            migrationBuilder.DropIndex(
                name: "IX_vehicle_ModelYear",
                schema: "dbo",
                table: "vehicle");

            migrationBuilder.DropColumn(
                name: "Brand",
                schema: "dbo",
                table: "vehicle");

            migrationBuilder.DropColumn(
                name: "ImageName",
                schema: "dbo",
                table: "vehicle");

            migrationBuilder.DropColumn(
                name: "ModelYear",
                schema: "dbo",
                table: "vehicle");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "dbo",
                table: "vehicle",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldUnicode: false,
                oldMaxLength: 100);
        }
    }
}
