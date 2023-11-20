namespace AutomotiveBrands.VehicleService.Application.Queries.Vehicles.List
{
    public sealed class VehicleListQueryValidator : AutomotiveBrandsApiValidator<VehicleListQuery>
    {
        public VehicleListQueryValidator()
        {
            RuleFor(p => p.Brand).IsInEnum().WithMessage("Lütfen geçerli bir marka giriniz");
        }
    }
}
