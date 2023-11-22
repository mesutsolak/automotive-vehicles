namespace AutomotiveBrands.UserService.Application.Queries.Vehicles.List
{
    public sealed class PreferenceListQueryHandler : IRequestHandler<PreferenceListQuery, ResponseModel<PreferenceListQueryResult>>
    {
        private readonly IUserUnitOfWork _uow;
        private readonly ILogger<PreferenceListQueryHandler> _logger;

        public PreferenceListQueryHandler(IServiceProvider serviceProvider)
        {
            _uow = serviceProvider.GetRequiredService<IUserUnitOfWork>();
            _logger = serviceProvider.GetRequiredService<ILogger<PreferenceListQueryHandler>>();
        }

        public async Task<ResponseModel<PreferenceListQueryResult>> Handle(PreferenceListQuery preferenceListQuery, CancellationToken cancellationToken)
        {
            // ML.NET bakılcaktır.S
            //var brandVehicles = await _uow.Preferences.GetAllAsync(x => x.Brand.Equals(vehicleListQuery.Brand));

            //if (brandVehicles.IsNullOrNotAny())
            //{
            //    _logger.LogWarning("@brand markasına göre araç listesi bulunamadı !", vehicleListQuery.Brand);
            //    return ResponseModel<List<PreferenceListQueryResult>>.Fail("Araç listesi bulunamadı");
            //}

            //var vehicles = ObjectMapper.Mapper.Map<List<PreferenceListQueryResult>>(brandVehicles);

            //return ResponseModel<List<PreferenceListQueryResult>>.Success(vehicles);

            return null;

        }
    }
}