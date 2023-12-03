namespace AutomotiveBrands.UserService.Application.Commands.Preferences.Add
{
    public sealed record AddPreferenceCommand : IRequest<ResponseModel<Unit>>
    {
        public int VehicleId { get; init; }
        public BrandType Brand { get; init; }
    }
}
