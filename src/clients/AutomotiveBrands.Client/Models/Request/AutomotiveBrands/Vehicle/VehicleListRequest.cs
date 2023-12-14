namespace AutomotiveBrands.Client.Models.Request.AutomotiveBrands.Vehicle
{
    public sealed record VehicleListRequest
    {
        public BrandType Brand { get; init; }
        public int ModelYear { get; init; }

        public VehicleListRequest(BrandType brand, int modelYear)
        {
            ModelYear = modelYear;
            Brand = brand;
        }
    }
}
