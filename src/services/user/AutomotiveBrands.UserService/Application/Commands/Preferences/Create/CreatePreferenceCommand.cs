namespace AutomotiveBrands.UserService.Application.Commands.Preferences.Create
{
    public sealed record CreatePreferenceCommand : IRequest<ResponseModel<Unit>>
    {
        public int VehicleDetailId { get; init; }
    }
}
