namespace AutomotiveBrands.VehicleService.Application.Queries.Vehicles.Detail
{
    public sealed class VehicleDetailQueryHandler : IRequestHandler<VehicleDetailQuery, ResponseModel<List<VehicleDetailQueryResult>>>
    {
        private readonly IVehicleUnitOfWork _uow;
        private readonly ILogger<VehicleDetailQueryHandler> _logger;

        public VehicleDetailQueryHandler(IServiceProvider serviceProvider)
        {
            _uow = serviceProvider.GetRequiredService<IVehicleUnitOfWork>();
            _logger = serviceProvider.GetRequiredService<ILogger<VehicleDetailQueryHandler>>();
        }

        public async Task<ResponseModel<List<VehicleDetailQueryResult>>> Handle(VehicleDetailQuery vehicleDetailQuery, CancellationToken cancellationToken)
        {
            var brandVehicleDetails = await _uow.VehicleDetails.GetAllAsync(x => x.VehicleId == vehicleDetailQuery.VehicleId);

            if (brandVehicleDetails.IsNullOrNotAny())
            {
                _logger.LogWarning("@vehicleId id bilgisine göre araç detay bilgisi bulunamadı !", vehicleDetailQuery.VehicleId);
                return ResponseModel<List<VehicleDetailQueryResult>>.Fail("Araç detay bilgisi bulunamadı");
            }

            var vehicleDetails = ObjectMapper.Mapper.Map<List<VehicleDetailQueryResult>>(brandVehicleDetails);

            return ResponseModel<List<VehicleDetailQueryResult>>.Success(vehicleDetails);
        }
    }
}
