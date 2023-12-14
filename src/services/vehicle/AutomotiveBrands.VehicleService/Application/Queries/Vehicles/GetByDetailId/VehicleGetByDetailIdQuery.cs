namespace AutomotiveBrands.VehicleService.Application.Queries.Vehicles.GetByDetailId
{
    public sealed class VehicleGetByDetailIdQuery : IRequest<ResponseModel<VehicleGetByDetailIdQueryResult>>
    {
        public int VehicleDetailId { get; init; }
    }
}

