namespace AutomotiveBrands.Client.Models.Response.AutomotiveBrands.Vehicle
{
    public sealed record VehicleListResponse
    {
        public int Id { get; init; }
        public BrandType Brand { get; init; }
        public string Name { get; init; }
        public string ImageName { get; init; }
        public int ModelYear { get; init; }
    }
}
