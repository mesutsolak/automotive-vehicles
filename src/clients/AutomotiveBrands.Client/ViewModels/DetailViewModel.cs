namespace AutomotiveBrands.Client.ViewModels
{
    public sealed record DetailViewModel
    {
        public DetailViewModel(IEnumerable<string> modelNames,int vehicleId)
        {
            ModelNames = modelNames;
            VehicleId = vehicleId;
        }

        public IEnumerable<string> ModelNames { get; init; }
        public int VehicleId { get; init; }
    }
}
