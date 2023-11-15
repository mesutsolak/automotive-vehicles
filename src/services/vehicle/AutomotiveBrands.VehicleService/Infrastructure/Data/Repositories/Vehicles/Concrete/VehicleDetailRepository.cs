namespace AutomotiveBrands.VehicleService.Infrastructure.Data.Repositories.Vehicles.Concrete
{
    public class VehicleDetailRepository : EfEntityRepository<VehicleDetail>, IVehicleDetailRepository
    {
        public VehicleDetailRepository(VehicleDbContext vehicleDbContext) : base(vehicleDbContext)
        {
        }
    }
}
