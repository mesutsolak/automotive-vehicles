namespace AutomotiveBrands.VehicleService.Application.Queries.Vehicles.GetById
{
    public sealed record VehicleGetByIdQueryResult
    {
        public int Id { get; init; }
        public BrandType Brand { get; init; }
        public string Name { get; init; }
        public string ImageName { get; init; }
        public int ModelYear { get; init; }
    }
}
