namespace AutomotiveBrands.UserService.Application.Commands.Preferences.Update
{
    public sealed record UpdatePreferenceCommand : IRequest<ResponseModel<Unit>>
    {
        public int VehicleDetailId { get; init; }
    }
}
