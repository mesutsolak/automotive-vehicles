using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutomotiveBrands.VehicleService.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class doubletodecimal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Vat",
                schema: "dbo",
                table: "vehicledetail",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<decimal>(
                name: "TrafficRegistrationServiceFee",
                schema: "dbo",
                table: "vehicledetail",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<decimal>(
                name: "TrafficRegistrationOfficialFee",
                schema: "dbo",
                table: "vehicledetail",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                schema: "dbo",
                table: "vehicledetail",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<decimal>(
                name: "NetPrice",
                schema: "dbo",
                table: "vehicledetail",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<decimal>(
                name: "MotorVehicleTax",
                schema: "dbo",
                table: "vehicledetail",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<decimal>(
                name: "FuelConsumption",
                schema: "dbo",
                table: "vehicledetail",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<decimal>(
                name: "ExciseDuty",
                schema: "dbo",
                table: "vehicledetail",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<decimal>(
                name: "EngineCapacity",
                schema: "dbo",
                table: "vehicledetail",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Vat",
                schema: "dbo",
                table: "vehicledetail",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<double>(
                name: "TrafficRegistrationServiceFee",
                schema: "dbo",
                table: "vehicledetail",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<double>(
                name: "TrafficRegistrationOfficialFee",
                schema: "dbo",
                table: "vehicledetail",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                schema: "dbo",
                table: "vehicledetail",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<double>(
                name: "NetPrice",
                schema: "dbo",
                table: "vehicledetail",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<double>(
                name: "MotorVehicleTax",
                schema: "dbo",
                table: "vehicledetail",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<double>(
                name: "FuelConsumption",
                schema: "dbo",
                table: "vehicledetail",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<double>(
                name: "ExciseDuty",
                schema: "dbo",
                table: "vehicledetail",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<double>(
                name: "EngineCapacity",
                schema: "dbo",
                table: "vehicledetail",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");
        }
    }
}
