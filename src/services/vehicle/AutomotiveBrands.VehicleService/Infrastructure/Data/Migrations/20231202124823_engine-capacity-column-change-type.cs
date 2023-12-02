using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutomotiveBrands.VehicleService.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class enginecapacitycolumnchangetype : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "EngineCapacity",
                schema: "dbo",
                table: "vehicledetail",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "EngineCapacity",
                schema: "dbo",
                table: "vehicledetail",
                type: "integer",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");
        }
    }
}
