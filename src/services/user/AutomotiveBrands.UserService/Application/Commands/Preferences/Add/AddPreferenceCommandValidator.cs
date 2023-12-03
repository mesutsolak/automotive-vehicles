namespace AutomotiveBrands.UserService.Application.Commands.Preferences.Add
{
    public sealed class AddPreferenceCommandValidator : AutomotiveBrandsApiValidator<AddPreferenceCommand>
    {
        public AddPreferenceCommandValidator()
        {
            RuleFor(p => p.VehicleId).GreaterThan(0).WithMessage("Lütfen geçerli bir araç detay id'si giriniz");
            RuleFor(p => p.Brand).IsInEnum().WithMessage("Lütfen geçerli bir marka giriniz");
        }
    }
}
