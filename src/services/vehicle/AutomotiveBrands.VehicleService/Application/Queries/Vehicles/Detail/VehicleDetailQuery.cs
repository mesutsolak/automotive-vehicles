namespace AutomotiveBrands.VehicleService.Application.Queries.Vehicles.Detail
{
    public sealed record VehicleDetailQuery : IRequest<ResponseModel<List<VehicleDetailQueryResult>>>
    {
        public int VehicleId { get; init; }
    }
}
