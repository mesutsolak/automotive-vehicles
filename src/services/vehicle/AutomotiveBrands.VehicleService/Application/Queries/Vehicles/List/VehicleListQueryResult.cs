namespace AutomotiveBrands.VehicleService.Application.Queries.Vehicles.List
{
    public sealed record VehicleListQueryResult
    {
        public int Id { get; init; }
        public BrandType Brand { get; init; }
        public string Name { get; init; }
        public string ImageName { get; init; }
        public int ModelYear { get; init; }
    }
}
