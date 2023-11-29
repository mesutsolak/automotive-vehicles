namespace AutomotiveBrands.Client.Application.Services.AutomotiveBrands
{
    public sealed class AutomotiveBrandsService : IAutomotiveBrandsService
    {
        private readonly IRestService _restService;

        public AutomotiveBrandsService(IRestService restService)
        {
            _restService = restService;
        }

        public async Task<ResponseModel<PreferenceAddResponse>> PreferenceAddAsync(PreferenceAddRequest preferenceAddRequest)
        {
            return await _restService.PostApiResponseAsync<ResponseModel<PreferenceAddResponse>>(Clients.AutomotiveBrands, "addPreference", preferenceAddRequest);
        }

        public async Task<ResponseModel<PreferenceListResponse>> PreferenceListAsync(PreferenceListRequest preferenceListRequest)
        {
            return await _restService.GetApiResponseAsync<ResponseModel<PreferenceListResponse>>(Clients.AutomotiveBrands, "preferences");
        }

        public async Task<ResponseModel<PreferenceUpdateResponse>> PreferenceUpdateAsync(PreferenceUpdateRequest preferenceUpdateRequest)
        {
            return await _restService.PostApiResponseAsync<ResponseModel<PreferenceUpdateResponse>>(Clients.AutomotiveBrands, "updatePreference", preferenceUpdateRequest);
        }

        public async Task<ResponseModel<List<VehicleDetailResponse>>> VehicleDetailAsync(VehicleDetailRequest vehicleDetailRequest)
        {
            var queryStringParameters = new Dictionary<string, string>
            {
                { "vehicleid", vehicleDetailRequest.VehicleId.ToString() }
            };

            var serviceUri = QueryHelpers.AddQueryString("vehicledetail", queryStringParameters);

            return await _restService.GetApiResponseAsync<ResponseModel<List<VehicleDetailResponse>>>(Clients.AutomotiveBrands, serviceUri);
        }

        public async Task<ResponseModel<List<VehicleListResponse>>> VehicleListAsync(VehicleListRequest vehicleListRequest)
        {
            var queryStringParameters = new Dictionary<string, string>
            {
                { "brand", vehicleListRequest.Brand.ToString() }
            };

            var serviceUri = QueryHelpers.AddQueryString("vehicle", queryStringParameters);

            return await _restService.GetApiResponseAsync<ResponseModel<List<VehicleListResponse>>>(Clients.AutomotiveBrands, serviceUri);
        }
    }
}
