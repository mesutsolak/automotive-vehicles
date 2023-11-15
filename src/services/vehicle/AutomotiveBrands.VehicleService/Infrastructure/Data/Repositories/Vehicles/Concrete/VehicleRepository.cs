namespace AutomotiveBrands.VehicleService.Infrastructure.Data.Repositories.Vehicles.Concrete
{
    public class VehicleRepository : EfEntityRepository<Vehicle>, IVehicleRepository
    {
        public VehicleRepository(VehicleDbContext vehicleDbContext) : base(vehicleDbContext)
        {
        }
    }
}
