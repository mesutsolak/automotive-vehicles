namespace AutomotiveBrands.Client.Application.Services.AutomotiveBrands
{
    public interface IAutomotiveBrandsService
    {
        Task<ResponseModel<VehicleGetByDetailIdResponse>> VehicleGetByDetailIdAsync(VehicleGetByDetailIdRequest vehicleGetByDetailIdRequest);
        Task<ResponseModel<VehicleGetByIdResponse>> VehicleGetByIdAsync(VehicleGetByIdRequest vehicleGetByIdRequest);
        Task<ResponseModel<List<VehicleListResponse>>> VehicleListAsync(VehicleListRequest vehicleListRequest);
        Task<ResponseModel<List<VehicleDetailResponse>>> VehicleDetailAsync(VehicleDetailRequest vehicleDetailRequest);
        Task<ResponseModel<PreferenceAddResponse>> PreferenceAddAsync(PreferenceAddRequest preferenceAddRequest);
        Task<ResponseModel<PreferenceListResponse>> PreferenceListAsync(PreferenceListRequest preferenceListRequest);
    }
}
