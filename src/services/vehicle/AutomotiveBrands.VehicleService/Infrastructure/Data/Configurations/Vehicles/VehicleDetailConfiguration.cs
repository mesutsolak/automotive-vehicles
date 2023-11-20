namespace AutomotiveBrands.VehicleService.Infrastructure.Data.Configurations.Vehicles
{
    public sealed class VehicleDetailConfiguration : BaseHistoricEntityConfiguration<VehicleDetail>
    {
        public override void Configure(EntityTypeBuilder<VehicleDetail> builder)
        {
            base.Configure(builder);

            #region Properties
            builder.Property(p => p.Id).UseIdentityColumn();
            builder.Property(p => p.ModelName).HasMaxLength(100).IsUnicode(false).IsRequired();
            builder.Property(p => p.ModelDescription).HasMaxLength(100).IsUnicode(false).IsRequired();
            builder.Property(p => p.ImageName).HasMaxLength(100).IsUnicode(false).IsRequired();
            builder.Property(p => p.Price).IsRequired();
            builder.Property(p => p.FuelConsumption).IsRequired();
            builder.Property(p => p.CO2).IsRequired();
            builder.Property(p => p.Engine).HasMaxLength(100).IsUnicode(false).IsRequired();
            builder.Property(p => p.EngineCapacity).IsRequired();
            builder.Property(p => p.NetPrice).IsRequired();
            builder.Property(p => p.ExciseDuty).IsRequired();
            builder.Property(p => p.ExciseDutyRate).IsRequired();
            builder.Property(p => p.Vat).IsRequired();
            builder.Property(p => p.VatRate).IsRequired();
            builder.Property(p => p.MotorVehicleTax).IsRequired();
            builder.Property(p => p.TrafficRegistrationOfficialFee).IsRequired();
            builder.Property(p => p.TrafficRegistrationServiceFee).IsRequired();

            #endregion

            #region Indexes
            builder.HasIndex(p => p.VehicleId).IsUnique(false);
            #endregion

            #region Relationships
            builder.HasOne(p => p.Vehicle).WithMany(p => p.VehicleDetails).HasForeignKey(p => p.VehicleId).OnDelete(DeleteBehavior.Cascade);
            #endregion

            #region Filter
            builder.HasQueryFilter(p => !p.IsDeleted);
            #endregion
        }
    }
}
