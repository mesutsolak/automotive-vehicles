using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AutomotiveBrands.VehicleService.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class vehicledetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "vehicle",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Brand = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: false),
                    ImageName = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: false),
                    ModelYear = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()"),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()"),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vehicle", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "vehicledetail",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ModelName = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: false),
                    ModelDescription = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: false),
                    ImageName = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: false),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    FuelConsumption = table.Column<double>(type: "double precision", nullable: false),
                    CO2 = table.Column<int>(type: "integer", nullable: false),
                    Engine = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: false),
                    EngineCapacity = table.Column<int>(type: "integer", nullable: false),
                    NetPrice = table.Column<double>(type: "double precision", nullable: false),
                    ExciseDuty = table.Column<double>(type: "double precision", nullable: false),
                    ExciseDutyRate = table.Column<int>(type: "integer", nullable: false),
                    Vat = table.Column<double>(type: "double precision", nullable: false),
                    VatRate = table.Column<int>(type: "integer", nullable: false),
                    MotorVehicleTax = table.Column<double>(type: "double precision", nullable: false),
                    TrafficRegistrationOfficialFee = table.Column<double>(type: "double precision", nullable: false),
                    TrafficRegistrationServiceFee = table.Column<double>(type: "double precision", nullable: false),
                    VehicleId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()"),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()"),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vehicledetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_vehicledetail_vehicle_VehicleId",
                        column: x => x.VehicleId,
                        principalSchema: "dbo",
                        principalTable: "vehicle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_vehicledetail_VehicleId",
                schema: "dbo",
                table: "vehicledetail",
                column: "VehicleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "vehicledetail",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "vehicle",
                schema: "dbo");
        }
    }
}
