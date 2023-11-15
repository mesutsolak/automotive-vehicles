namespace AutomotiveBrands.VehicleService.Infrastructure.Data.Configurations.Vehicles
{
    public sealed class VehicleConfiguration : BaseHistoricEntityConfiguration<Vehicle>
    {
        public override void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            base.Configure(builder);

            #region Properties
            builder.Property(p => p.Id).UseIdentityColumn();

            #endregion

            #region Indexes

            #endregion

            #region Filter
            builder.HasQueryFilter(p => !p.IsDeleted);
            #endregion
        }
    }
}
