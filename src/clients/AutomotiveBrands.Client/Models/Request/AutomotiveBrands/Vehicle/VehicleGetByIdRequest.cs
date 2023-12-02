namespace AutomotiveBrands.Client.Models.Request.AutomotiveBrands.Vehicle
{
    public sealed record VehicleGetByIdRequest
    {
        public VehicleGetByIdRequest(int id)
        {
            Id = id;
        }
        public int Id { get; init; }
    }
}
