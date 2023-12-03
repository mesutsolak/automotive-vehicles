namespace AutomotiveBrands.Client.Models.Request.AutomotiveBrands.User
{
    public sealed record PreferenceAddRequest
    {
        public int VehicleId { get; init; }
        public BrandType Brand { get; init; }

        public PreferenceAddRequest(int vehicleId, BrandType brand)
        {
            VehicleId = vehicleId;
            Brand = brand;
        }
    }
}
