namespace AutomotiveBrands.Client.ViewModels
{
    public sealed class DetailViewModel
    {
        public DetailViewModel(List<VehicleDetailResponse> vehicleListResponses)
        {
            VehicleDetailResponses = vehicleListResponses;
        }

        public List<VehicleDetailResponse> VehicleDetailResponses { get; init; }
    }
}
