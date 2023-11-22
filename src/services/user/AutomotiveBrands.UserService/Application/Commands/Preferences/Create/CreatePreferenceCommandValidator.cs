namespace AutomotiveBrands.UserService.Application.Commands.Preferences.Create
{
    public sealed class CreatePreferenceCommandValidator : AutomotiveBrandsApiValidator<CreatePreferenceCommand>
    {
        public CreatePreferenceCommandValidator()
        {
            RuleFor(p => p.VehicleDetailId).GreaterThan(0).WithMessage("Lütfen geçerli bir araç detay id'si giriniz");
        }
    }
}
