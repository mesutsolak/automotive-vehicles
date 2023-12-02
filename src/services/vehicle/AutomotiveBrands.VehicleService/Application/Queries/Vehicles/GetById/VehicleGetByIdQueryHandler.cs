namespace AutomotiveBrands.VehicleService.Application.Queries.Vehicles.GetById
{
    public sealed class VehicleGetByIdQueryHandler : IRequestHandler<VehicleGetByIdQuery, ResponseModel<VehicleGetByIdQueryResult>>
    {
        private readonly IVehicleUnitOfWork _uow;
        private readonly ILogger<VehicleGetByIdQueryHandler> _logger;

        public VehicleGetByIdQueryHandler(IServiceProvider serviceProvider)
        {
            _uow = serviceProvider.GetRequiredService<IVehicleUnitOfWork>();
            _logger = serviceProvider.GetRequiredService<ILogger<VehicleGetByIdQueryHandler>>();
        }

        public async Task<ResponseModel<VehicleGetByIdQueryResult>> Handle(VehicleGetByIdQuery vehicleGetByIdQuery, CancellationToken cancellationToken)
        {
            var vehicle = await _uow.Vehicles.GetByIdAsync(vehicleGetByIdQuery.VehicleId);

            if (vehicle is null)
            {
                _logger.LogWarning("@vehicleId id bilgisine göre araç bilgisi bulunamadı !", vehicleGetByIdQuery.VehicleId);
                return ResponseModel<VehicleGetByIdQueryResult>.Fail("Araç bilgisi bulunamadı");
            }

            var vehicleGetByIdQueryResult = ObjectMapper.Mapper.Map<VehicleGetByIdQueryResult>(vehicle);

            return ResponseModel<VehicleGetByIdQueryResult>.Success(vehicleGetByIdQueryResult);
        }
    }
}
