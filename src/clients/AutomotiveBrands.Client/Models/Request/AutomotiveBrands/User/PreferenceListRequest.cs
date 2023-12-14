namespace AutomotiveBrands.Client.Models.Request.AutomotiveBrands.User
{
    public sealed record PreferenceListRequest
    {
        public PreferenceListRequest(BrandType brand)
        {
            Brand = brand;
        }
        public BrandType Brand { get; init; }
    }
}
