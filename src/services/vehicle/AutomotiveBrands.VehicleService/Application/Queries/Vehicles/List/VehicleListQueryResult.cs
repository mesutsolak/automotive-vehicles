namespace AutomotiveBrands.VehicleService.Application.Queries.Vehicles.List
{
    public sealed record VehicleListQueryResult
    {
        public int? PkId { get; init; }
        public int? VehicleId { get; init; }
        public string Plate { get; init; }
        public string Chassis { get; init; }
        public int? ChassisModelYear { get; init; }
        public string BrandCode { get; init; }
        public string TopBrandCode { get; init; }
        public string BrandDefinition { get; init; }
        public int? TopModelId { get; init; }
        public int? CountryModelId { get; init; }
        public int? BaseModelId { get; init; }
        public string ParameterValue { get; init; }
        public int? RealtionalType { get; init; }
        public bool? IsOwner { get; init; }
        public DateTime? StartDate { get; init; }
        public DateTime? EndDate { get; init; }
        public DateTime? TrafficDate { get; init; }
        public string CountryModelDefinition { get; init; }
        public string TopModelDefinition { get; init; }
        public DateTime? EstimatedMaintenanceDate { get; init; }
        public string TopModelCode { get; init; }
        public DateTime? ExaminationDate { get; init; }
        public bool? LisenceHolderPermission { get; init; }
        public bool? IsShownMobile { get; init; }
        public string EngineNumber { get; init; }
        public DateTime? QuarantyStartDate { get; init; }
        public DateTime? WarrantyEndDate { get; init; }
        public string BaseModelCode { get; init; }
        public string LastMaintenanceFirm { get; init; }
        public DateTime? LastMaintenanceDate { get; init; }
        public List<string> RelatedCustomers { get; init; }

        #region Custom Properties
        public bool IsFavorite { get; set; }
        public string VehicleImageUrl { get; set; }
        #endregion
    }
}
