namespace AutomotiveBrands.UserService.Application.Commands.Preferences.Update
{
    public sealed class UpdatePreferenceCommandHandler : IRequestHandler<UpdatePreferenceCommand, ResponseModel<Unit>>
    {
        private readonly IUserUnitOfWork _uow;
        private readonly ILogger<UpdatePreferenceCommandHandler> _logger;
        private readonly IWebHelper _webHelper;

        public UpdatePreferenceCommandHandler(IServiceProvider serviceProvider)
        {
            _uow = serviceProvider.GetRequiredService<IUserUnitOfWork>();
            _logger = serviceProvider.GetRequiredService<ILogger<UpdatePreferenceCommandHandler>>();
            _webHelper = serviceProvider.GetRequiredService<IWebHelper>();
        }


        public async Task<ResponseModel<Unit>> Handle(UpdatePreferenceCommand updatePreferenceCommand, CancellationToken cancellationToken)
        {
            var foundPreference = await _uow.Preferences.GetAsync(x => x.IpAddress.Equals(_webHelper.IpAddress) && x.VehicleDetailId == updatePreferenceCommand.VehicleDetailId);

            if (foundPreference is null)
            {
                _logger.LogWarning("@ipAddress ip adresli kullanıcının @vehicleDetailId araç detay id'li bilgisi bulunmuyor !", _webHelper.IpAddress, foundPreference.VehicleDetailId);
                return ResponseModel<Unit>.Fail("Ip adresinin araç detay bilgisi bulunmuyor !");
            }

            foundPreference.RequestCount += 1;

            _uow.Preferences.Update(foundPreference);
            var isSucceed = await _uow.SaveChangesAsync();

            if (!isSucceed)
            {
                _logger.LogWarning("@ipAddress ip adresli kullanıcının @vehicleDetailId araç detay id'li bilgisi güncellenmeye çalışırken bir hata meydana geldi !", _webHelper.IpAddress, foundPreference.VehicleDetailId);
                return ResponseModel<Unit>.Fail("Ip adresinim araç detay bilgisi güncellenmeye çalışırken bir hata meydana geldi !");
            }

            return ResponseModel<Unit>.Success(Unit.Value);
        }
    }
}
