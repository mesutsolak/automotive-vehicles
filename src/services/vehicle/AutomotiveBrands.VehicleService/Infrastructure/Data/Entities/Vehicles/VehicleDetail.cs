﻿namespace AutomotiveBrands.VehicleService.Infrastructure.Data.Entities.Vehicles
{
    public class VehicleDetail : BaseHistoricStatusEntity
    {
        public string ModelName { get; init; }
        public string ModelDescription { get; init; }
        public string ImageName { get; init; }
        public double Price { get; init; }
        public double FuelConsumption { get; init; }
        public int CO2 { get; init; }
        public string Engine { get; set; }
        public int EngineCapacity { get; init; }
        public double NetPrice { get; init; }
        public double ExciseDuty { get; init; }
        public int ExciseDutyRate { get; init; }
        public double Vat { get; init; }
        public int VatRate { get; init; }
        public double MotorVehicleTax { get; init; }
        public double TrafficRegistrationOfficialFee { get; init; }
        public double TrafficRegistrationServiceFee { get; init; }

        #region One-To-Many Relationships
        public int VehicleId { get; init; }
        public Vehicle Vehicle { get; init; }
        #endregion
    }
}
