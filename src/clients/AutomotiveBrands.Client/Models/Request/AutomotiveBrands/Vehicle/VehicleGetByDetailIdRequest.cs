namespace AutomotiveBrands.Client.Models.Request.AutomotiveBrands.Vehicle
{
    public sealed class VehicleGetByDetailIdRequest
    {
        public VehicleGetByDetailIdRequest(int vehicleDetailId)
        {
            VehicleDetailId = vehicleDetailId;
        }
        public int VehicleDetailId { get; init; }
    }
}
