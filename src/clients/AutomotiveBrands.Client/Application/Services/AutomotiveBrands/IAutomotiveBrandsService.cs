namespace AutomotiveBrands.Client.Application.Services.AutomotiveBrands
{
    public interface IAutomotiveBrandsService
    {
        Task<ResponseModel<List<VehicleListResponse>>> VehicleListAsync(VehicleListRequest vehicleListRequest);
        Task<ResponseModel<List<VehicleDetailResponse>>> VehicleDetailAsync(VehicleDetailRequest vehicleDetailRequest);
        Task<ResponseModel<PreferenceAddResponse>> PreferenceAddAsync(PreferenceAddRequest preferenceAddRequest);
        Task<ResponseModel<PreferenceUpdateResponse>> PreferenceUpdateAsync(PreferenceUpdateRequest preferenceUpdateRequest);
        Task<ResponseModel<PreferenceListResponse>> PreferenceListAsync(PreferenceListRequest preferenceListRequest);
    }
}
