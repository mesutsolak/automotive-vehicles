namespace AutomotiveBrands.VehicleService.Application.Queries.Vehicles.List
{
    public sealed class VehicleListQueryHandler : IRequestHandler<VehicleListQuery, ResponseModel<List<VehicleListQueryResult>>>
    {


        public VehicleListQueryHandler(IServiceProvider serviceProvider)
        {

        }

        public async Task<ResponseModel<List<VehicleListQueryResult>>> Handle(VehicleListQuery vehicleListQuery, CancellationToken cancellationToken)
        {


            return null;
        }
    }
}