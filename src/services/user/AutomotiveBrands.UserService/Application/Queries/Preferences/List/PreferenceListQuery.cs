namespace AutomotiveBrands.UserService.Application.Queries.Vehicles.List
{
    public sealed record PreferenceListQuery : IRequest<ResponseModel<PreferenceListQueryResult>>
    {
        public BrandType Brand { get; init; }
    }
}
