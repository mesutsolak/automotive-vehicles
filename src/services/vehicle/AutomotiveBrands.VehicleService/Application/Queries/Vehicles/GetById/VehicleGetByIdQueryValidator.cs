namespace AutomotiveBrands.VehicleService.Application.Queries.Vehicles.GetById
{
    public sealed class VehicleGetByIdQueryValidator : AutomotiveBrandsApiValidator<VehicleGetByIdQuery>
    {
        public VehicleGetByIdQueryValidator()
        {
            RuleFor(p => p.VehicleId).GreaterThan(0).WithMessage("Geçersiz araç id değeri");
        }
    }
}
