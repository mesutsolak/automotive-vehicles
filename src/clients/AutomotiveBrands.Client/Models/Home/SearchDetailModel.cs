namespace AutomotiveBrands.Client.Models.Home
{
    public sealed record SearchDetailModel
    {
        public int VehicleId { get; init; }
        public List<int> Prices { get; init; }
        public List<string> ModelNames { get; init; }
        public List<int> VatRates { get; init; }
        public List<int> ExciseDutyRates { get; init; }
    }
}
