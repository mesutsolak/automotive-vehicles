namespace AutomotiveBrands.VehicleService.Infrastructure.Data.UnitOfWork
{
    public partial interface IVehicleUnitOfWork : IBaseUnitOfWork
    {
        /// <summary>
        /// Araçlar
        /// </summary>
        IVehicleRepository Vehicles { get; }

        /// <summary>
        /// Araçların Detayları
        /// </summary>
        IVehicleDetailRepository VehicleDetails { get; }
    }
}
