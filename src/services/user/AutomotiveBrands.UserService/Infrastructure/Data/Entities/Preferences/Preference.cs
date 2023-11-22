namespace AutomotiveBrands.UserService.Infrastructure.Data.Entities.Preferences
{
    public sealed class Preference : BaseHistoricStatusEntity
    {
        public string IpAddress { get; set; }
        public int VehicleDetailId { get; init; }
        public int RequestCount { get; set; }
    }
}
