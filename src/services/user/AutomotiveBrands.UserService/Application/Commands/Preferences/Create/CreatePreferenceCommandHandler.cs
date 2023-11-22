namespace AutomotiveBrands.UserService.Application.Commands.Preferences.Create
{
    public sealed class CreatePreferenceCommandHandler : IRequestHandler<CreatePreferenceCommand, ResponseModel<Unit>>
    {
        private readonly IUserUnitOfWork _uow;
        private readonly ILogger<CreatePreferenceCommandHandler> _logger;
        private readonly IWebHelper _webHelper;

        public CreatePreferenceCommandHandler(IServiceProvider serviceProvider)
        {
            _uow = serviceProvider.GetRequiredService<IUserUnitOfWork>();
            _logger = serviceProvider.GetRequiredService<ILogger<CreatePreferenceCommandHandler>>();
            _webHelper = serviceProvider.GetRequiredService<IWebHelper>();
        }

        public async Task<ResponseModel<Unit>> Handle(CreatePreferenceCommand createPreferenceCommand, CancellationToken cancellationToken)
        {
            var foundPreference = await _uow.Preferences.GetAsync(x => x.IpAddress.Equals(_webHelper.IpAddress) && x.VehicleDetailId == createPreferenceCommand.VehicleDetailId);

            if (foundPreference is not null)
            {
                _logger.LogWarning("@ipAddress ip adresli kullanıcının @vehicleDetailId araç detay id'li bilgisi zaten var !", _webHelper.IpAddress, createPreferenceCommand.VehicleDetailId);
                return ResponseModel<Unit>.Fail("Ip adresine araç detay bilgisi daha önce kaydedilmiş !");
            }


            var preference = ObjectMapper.Mapper.Map<CreatePreferenceCommand, Preference>(createPreferenceCommand);

            preference.IpAddress = _webHelper.IpAddress;
            preference.RequestCount = 1;


            _ = _uow.Preferences.InsertAsync(preference, cancellationToken);
            var isSucceed = await _uow.SaveChangesAsync();

            if (!isSucceed)
            {
                _logger.LogWarning("@ipAddress ip adresli kullanıcının @vehicleDetailId araç detay id'li bilgisi eklenmeye çalışırken bir hata meydana geldi !", _webHelper.IpAddress, createPreferenceCommand.VehicleDetailId);
                return ResponseModel<Unit>.Fail("Ip adresine araç detay bilgisi eklenmeye çalışırken bir hata meydana geldi !");
            }

            return ResponseModel<Unit>.Success(Unit.Value);
        }
    }
}