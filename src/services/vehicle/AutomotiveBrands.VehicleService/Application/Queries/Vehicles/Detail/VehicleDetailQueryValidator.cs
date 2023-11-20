namespace AutomotiveBrands.VehicleService.Application.Queries.Vehicles.Detail
{
    public sealed class VehicleDetailQueryValidator : AutomotiveBrandsApiValidator<VehicleDetailQuery>
    {
        public VehicleDetailQueryValidator()
        {
            RuleFor(p => p.VehicleId).GreaterThan(0).WithMessage("Geçersiz araç id değeri");
        }
    }
}
