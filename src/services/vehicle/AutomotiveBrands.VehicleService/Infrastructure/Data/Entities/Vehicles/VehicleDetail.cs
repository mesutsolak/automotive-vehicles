namespace AutomotiveBrands.VehicleService.Infrastructure.Data.Entities.Vehicles
{
    public class VehicleDetail : BaseHistoricStatusEntity
    {
        public string ModelName { get; init; }
        public string ModelDescription { get; init; }
        public string ImageName { get; init; }
        public decimal Price { get; init; }
        public decimal FuelConsumption { get; init; }
        public int CO2 { get; init; }
        public string Engine { get; set; }
        public decimal EngineCapacity { get; init; }
        public decimal NetPrice { get; init; }
        public decimal ExciseDuty { get; init; }
        public int ExciseDutyRate { get; init; }
        public decimal Vat { get; init; }
        public int VatRate { get; init; }
        public decimal MotorVehicleTax { get; init; }
        public decimal TrafficRegistrationOfficialFee { get; init; }
        public decimal TrafficRegistrationServiceFee { get; init; }

        #region One-To-Many Relationships
        public int VehicleId { get; init; }
        public Vehicle Vehicle { get; init; }
        #endregion
    }
}
