namespace AutomotiveBrands.UserService.Infrastructure.Data.Entities.Preferences
{
    public class Preference : BaseHistoricStatusEntity
    {
        public string IpAddress { get; set; }
        public BrandType Brand { get; set; }
        public int VehicleId { get; init; }
        public int RequestCount { get; set; }
    }
}
