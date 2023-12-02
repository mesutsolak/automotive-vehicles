namespace AutomotiveBrands.VehicleService.Application.Queries.Vehicles.GetById
{
    public sealed class VehicleGetByIdQuery : IRequest<ResponseModel<VehicleGetByIdQueryResult>>
    {
        public int VehicleId { get; init; }
    }
}

