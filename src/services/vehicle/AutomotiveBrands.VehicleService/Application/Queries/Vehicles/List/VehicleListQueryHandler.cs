namespace AutomotiveBrands.VehicleService.Application.Queries.Vehicles.List
{
    public sealed class VehicleListQueryHandler : IRequestHandler<VehicleListQuery, ResponseModel<List<VehicleListQueryResult>>>
    {
        private readonly IVehicleUnitOfWork _uow;
        private readonly ILogger<VehicleListQueryHandler> _logger;

        public VehicleListQueryHandler(IServiceProvider serviceProvider)
        {
            _uow = serviceProvider.GetRequiredService<IVehicleUnitOfWork>();
            _logger = serviceProvider.GetRequiredService<ILogger<VehicleListQueryHandler>>();
        }

        public async Task<ResponseModel<List<VehicleListQueryResult>>> Handle(VehicleListQuery vehicleListQuery, CancellationToken cancellationToken)
        {
            var brandVehicles = await _uow.Vehicles.GetAllAsync(x => x.Brand.Equals(vehicleListQuery.Brand));

            if (brandVehicles.IsNullOrNotAny())
            {
                _logger.LogWarning("@brand markasına göre araç listesi bulunamadı !", vehicleListQuery.Brand);
                return ResponseModel<List<VehicleListQueryResult>>.Fail("Araç listesi bulunamadı");
            }

            var vehicles = ObjectMapper.Mapper.Map<List<VehicleListQueryResult>>(brandVehicles);

            return ResponseModel<List<VehicleListQueryResult>>.Success(vehicles);
        }
    }
}