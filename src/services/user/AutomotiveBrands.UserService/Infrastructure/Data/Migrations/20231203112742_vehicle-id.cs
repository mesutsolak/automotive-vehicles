using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutomotiveBrands.UserService.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class vehicleid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VehicleDetailId",
                schema: "dbo",
                table: "preference",
                newName: "VehicleId");

            migrationBuilder.RenameIndex(
                name: "IX_preference_VehicleDetailId",
                schema: "dbo",
                table: "preference",
                newName: "IX_preference_VehicleId");

            migrationBuilder.AddColumn<int>(
                name: "Brand",
                schema: "dbo",
                table: "preference",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Brand",
                schema: "dbo",
                table: "preference");

            migrationBuilder.RenameColumn(
                name: "VehicleId",
                schema: "dbo",
                table: "preference",
                newName: "VehicleDetailId");

            migrationBuilder.RenameIndex(
                name: "IX_preference_VehicleId",
                schema: "dbo",
                table: "preference",
                newName: "IX_preference_VehicleDetailId");
        }
    }
}
