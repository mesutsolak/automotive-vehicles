namespace AutomotiveBrands.UserService.Application.Commands.Preferences.Update
{
    public class UpdatePreferenceCommandValidator : AutomotiveBrandsApiValidator<UpdatePreferenceCommand>
    {
        public UpdatePreferenceCommandValidator()
        {
            RuleFor(p => p.VehicleDetailId).GreaterThan(0).WithMessage("Lütfen geçerli bir araç detay id'si giriniz");
        }
    }
}