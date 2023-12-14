namespace AutomotiveBrands.VehicleService.Infrastructure.Data.Configurations.Vehicles
{
    public sealed class VehicleConfiguration : BaseHistoricEntityConfiguration<Vehicle>
    {
        public override void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            base.Configure(builder);

            #region Properties
            builder.Property(p => p.Id).UseIdentityColumn();
            builder.Property(p => p.Brand).IsRequired();
            builder.Property(p => p.Name).HasMaxLength(100).IsUnicode(false).IsRequired();
            builder.Property(p => p.ImageName).HasMaxLength(100).IsUnicode(false).IsRequired();
            builder.Property(p => p.ModelYear).IsRequired();
            #endregion

            #region Indexes
            builder.HasIndex(p => p.Brand).IsUnique(false);
            builder.HasIndex(p => p.ModelYear).IsUnique(false);
            #endregion

            #region Filter
            builder.HasQueryFilter(p => !p.IsDeleted);
            #endregion
        }
    }
}
