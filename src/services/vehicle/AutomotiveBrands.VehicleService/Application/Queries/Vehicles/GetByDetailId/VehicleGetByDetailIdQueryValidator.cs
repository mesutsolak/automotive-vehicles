namespace AutomotiveBrands.VehicleService.Application.Queries.Vehicles.GetByDetailId
{
    public sealed class VehicleGetByDetailIdQueryValidator : AutomotiveBrandsApiValidator<VehicleGetByDetailIdQuery>
    {
        public VehicleGetByDetailIdQueryValidator()
        {
            RuleFor(p => p.VehicleDetailId).GreaterThan(0).WithMessage("Geçersiz araç detay id değeri");
        }
    }
}
