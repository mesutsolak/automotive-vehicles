namespace AutomotiveBrands.VehicleService.Application.Queries.Vehicles.List
{
    public sealed record VehicleListQuery : IRequest<ResponseModel<List<VehicleListQueryResult>>>;
}
