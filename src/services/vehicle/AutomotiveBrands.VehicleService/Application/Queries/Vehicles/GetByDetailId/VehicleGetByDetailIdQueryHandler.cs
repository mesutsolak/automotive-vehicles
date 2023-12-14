namespace AutomotiveBrands.VehicleService.Application.Queries.Vehicles.GetByDetailId
{
    public sealed class VehicleGetByDetailIdQueryHandler : IRequestHandler<VehicleGetByDetailIdQuery, ResponseModel<VehicleGetByDetailIdQueryResult>>
    {
        private readonly IVehicleUnitOfWork _uow;
        private readonly ILogger<VehicleGetByDetailIdQueryHandler> _logger;

        public VehicleGetByDetailIdQueryHandler(IServiceProvider serviceProvider)
        {
            _uow = serviceProvider.GetRequiredService<IVehicleUnitOfWork>();
            _logger = serviceProvider.GetRequiredService<ILogger<VehicleGetByDetailIdQueryHandler>>();
        }

        public async Task<ResponseModel<VehicleGetByDetailIdQueryResult>> Handle(VehicleGetByDetailIdQuery vehicleGetByDetailIdQuery, CancellationToken cancellationToken)
        {
            var vehicleDetail = await _uow.VehicleDetails.GetByIdAsync(vehicleGetByDetailIdQuery.VehicleDetailId);

            if (vehicleDetail is null)
            {
                _logger.LogWarning("@vehicleDetailId id bilgisine göre araç detay bilgisi bulunamadı !", vehicleGetByDetailIdQuery.VehicleDetailId);
                return ResponseModel<VehicleGetByDetailIdQueryResult>.Fail("Araç detay bilgisi bulunamadı");
            }

            var vehicleGetByDetailIdQueryResult = ObjectMapper.Mapper.Map<VehicleGetByDetailIdQueryResult>(vehicleDetail);

            return ResponseModel<VehicleGetByDetailIdQueryResult>.Success(vehicleGetByDetailIdQueryResult);
        }
    }
}
