namespace AutomotiveBrands.Client.ViewModels
{
    public sealed record DetailViewModel
    {
        public DetailViewModel(Dictionary<string, List<VehicleDetailResponse>> vehicleListResponses, string imageName)
        {
            VehicleDetailResponses = vehicleListResponses;
            ImageName = imageName;
        }

        public string ImageName { get; init; }

        public Dictionary<string, List<VehicleDetailResponse>> VehicleDetailResponses { get; init; }
    }
}
