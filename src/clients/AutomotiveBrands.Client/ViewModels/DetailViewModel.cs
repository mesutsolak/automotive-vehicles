namespace AutomotiveBrands.Client.ViewModels
{
    public sealed class DetailViewModel
    {
        public DetailViewModel(Dictionary<string, List<VehicleDetailResponse>> vehicleListResponses, string imageName)
        {
            VehicleDetailResponses = vehicleListResponses;
            ImageName = imageName;
        }

        public string ImageName { get; set; }

        public Dictionary<string, List<VehicleDetailResponse>> VehicleDetailResponses { get; init; }
    }
}
