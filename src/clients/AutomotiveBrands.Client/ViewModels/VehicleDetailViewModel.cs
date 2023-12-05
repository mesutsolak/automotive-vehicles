namespace AutomotiveBrands.Client.ViewModels
{
    public sealed record VehicleDetailViewModel
    {
        public VehicleDetailViewModel(Dictionary<string, List<VehicleDetailResponse>> vehicleListResponses, string imageName)
        {
            VehicleDetailResponses = vehicleListResponses;
            ImageName = imageName;
        }

        public string ImageName { get; init; }

        public Dictionary<string, List<VehicleDetailResponse>> VehicleDetailResponses { get; init; }
    }
}
