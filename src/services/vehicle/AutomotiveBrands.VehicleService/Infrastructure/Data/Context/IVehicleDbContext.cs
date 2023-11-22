namespace AutomotiveBrands.VehicleService.Infrastructure.Data.Context
{
    public interface IVehicleDbContext
    {
        /// <summary>
        /// Araçlar
        /// </summary>
        DbSet<Vehicle> Vehicles { get; set; }

        /// <summary>
        /// Araçların Detayları
        /// </summary>
        DbSet<VehicleDetail> VehicleDetails { get; set; }
    }
}
