namespace AutomotiveBrands.UserService.Application.Queries.Vehicles.List
{
    public sealed class PreferenceListQueryHandler : IRequestHandler<PreferenceListQuery, ResponseModel<PreferenceListQueryResult>>
    {
        private readonly IUserUnitOfWork _uow;
        private readonly ILogger<PreferenceListQueryHandler> _logger;
        private readonly IWebHelper _webHelper;

        public PreferenceListQueryHandler(IServiceProvider serviceProvider)
        {
            _uow = serviceProvider.GetRequiredService<IUserUnitOfWork>();
            _logger = serviceProvider.GetRequiredService<ILogger<PreferenceListQueryHandler>>();
            _webHelper = serviceProvider.GetRequiredService<IWebHelper>();
        }

        public async Task<ResponseModel<PreferenceListQueryResult>> Handle(PreferenceListQuery preferenceListQuery, CancellationToken cancellationToken)
        {
            var preference = await _uow.Preferences.GetAsync(x => x.IpAddress.Equals(_webHelper.IpAddress), o => o.OrderByDescending(p => p.RequestCount));

            if (preference is null)
            {
                _logger.LogWarning("@ipAddress ip adresli kullanıcının tercihleri bulunamadı !", _webHelper.IpAddress);
                return ResponseModel<PreferenceListQueryResult>.Fail("Ip adresine ait bir tercih bulunamadı !");
            }

            var preferenceListQueryResult = ObjectMapper.Mapper.Map<Preference, PreferenceListQueryResult>(preference);

            return ResponseModel<PreferenceListQueryResult>.Success(preferenceListQueryResult);
        }
    }
}