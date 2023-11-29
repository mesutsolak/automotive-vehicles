namespace AutomotiveBrands.Client.Models.Request.AutomotiveBrands.Vehicle
{
    public sealed record VehicleDetailRequest
    {
        public VehicleDetailRequest(int vehicleId)
        {
            VehicleId = vehicleId;
        }

        public int VehicleId { get; init; }
    }
}
