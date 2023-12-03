namespace AutomotiveBrands.UserService.Application.Commands.Preferences.Add
{
    public sealed class AddPreferenceCommandHandler : IRequestHandler<AddPreferenceCommand, ResponseModel<Unit>>
    {
        private readonly IUserUnitOfWork _uow;
        private readonly ILogger<AddPreferenceCommandHandler> _logger;
        private readonly IWebHelper _webHelper;

        public AddPreferenceCommandHandler(IServiceProvider serviceProvider)
        {
            _uow = serviceProvider.GetRequiredService<IUserUnitOfWork>();
            _logger = serviceProvider.GetRequiredService<ILogger<AddPreferenceCommandHandler>>();
            _webHelper = serviceProvider.GetRequiredService<IWebHelper>();
        }

        public async Task<ResponseModel<Unit>> Handle(AddPreferenceCommand addPreferenceCommand, CancellationToken cancellationToken)
        {
            var foundPreference = await _uow.Preferences.GetAsync(x => x.IpAddress.Equals(_webHelper.IpAddress) && x.VehicleId == addPreferenceCommand.VehicleId);

            if (foundPreference is not null)
            {
                foundPreference.RequestCount += 1;
                _uow.Preferences.Update(foundPreference);
            }
            else
            {
                var preference = ObjectMapper.Mapper.Map<AddPreferenceCommand, Preference>(addPreferenceCommand);

                preference.Brand = addPreferenceCommand.Brand;
                preference.IpAddress = _webHelper.IpAddress;
                preference.RequestCount = 1;

                await _uow.Preferences.InsertAsync(preference, cancellationToken);
            }

            var isSucceed = await _uow.SaveChangesAsync(cancellationToken);

            if (!isSucceed)
            {
                _logger.LogWarning("@ipAddress ip adresli kullanıcının @vehicleId araç id bilgisi eklenmeye çalışırken bir hata meydana geldi !", _webHelper.IpAddress, addPreferenceCommand.VehicleId);
                return ResponseModel<Unit>.Fail("Ip adresine araç detay bilgisi eklenmeye çalışırken bir hata meydana geldi !");
            }

            return ResponseModel<Unit>.Success(Unit.Value);
        }
    }
}