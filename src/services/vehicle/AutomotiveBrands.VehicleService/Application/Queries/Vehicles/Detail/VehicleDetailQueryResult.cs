namespace AutomotiveBrands.VehicleService.Application.Queries.Vehicles.Detail
{
    public sealed record VehicleDetailQueryResult
    {
        public string ModelName { get; init; }
        public string ModelDescription { get; init; }
        public string ImageName { get; init; }
        public decimal Price { get; init; }
        public decimal FuelConsumption { get; init; }
        public int CO2 { get; init; }
        public string Engine { get; set; }
        public int EngineCapacity { get; init; }
        public decimal NetPrice { get; init; }
        public decimal ExciseDuty { get; init; }
        public int ExciseDutyRate { get; init; }
        public decimal Vat { get; init; }
        public int VatRate { get; init; }
        public decimal MotorVehicleTax { get; init; }
        public decimal TrafficRegistrationOfficialFee { get; init; }
        public decimal TrafficRegistrationServiceFee { get; init; }
        public int VehicleId { get; init; }
    }
}
