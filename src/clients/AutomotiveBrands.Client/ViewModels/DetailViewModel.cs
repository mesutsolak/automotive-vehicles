namespace AutomotiveBrands.Client.ViewModels
{
    public sealed class DetailViewModel
    {
        public DetailViewModel(List<VehicleDetailResponse> vehicleListResponses, VehicleGetByIdResponse vehicleGetByIdResponse)
        {
            VehicleDetailResponses = vehicleListResponses;
            VehicleGetByIdResponse = vehicleGetByIdResponse;
        }

        public VehicleGetByIdResponse VehicleGetByIdResponse { get; set; }

        public List<VehicleDetailResponse> VehicleDetailResponses { get; init; }
    }
}
