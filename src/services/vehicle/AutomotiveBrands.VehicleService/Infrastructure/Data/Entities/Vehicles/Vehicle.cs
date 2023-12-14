namespace AutomotiveBrands.VehicleService.Infrastructure.Data.Entities.Vehicles
{
    public class Vehicle : BaseHistoricStatusEntity
    {
        public BrandType Brand { get; init; }
        public string Name { get; init; }
        public string ImageName { get; init; }
        public int ModelYear { get; init; }
        public ICollection<VehicleDetail> VehicleDetails { get; init; }
    }
}
