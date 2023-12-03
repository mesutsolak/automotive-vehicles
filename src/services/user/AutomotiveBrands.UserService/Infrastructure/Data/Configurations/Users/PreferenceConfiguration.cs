namespace AutomotiveBrands.UserService.Infrastructure.Data.Configurations.Users
{
    public sealed class PreferenceConfiguration : BaseHistoricEntityConfiguration<Preference>
    {
        public override void Configure(EntityTypeBuilder<Preference> builder)
        {
            base.Configure(builder);

            #region Properties
            builder.Property(p => p.Id).UseIdentityColumn();
            builder.Property(p => p.Brand).IsRequired();
            builder.Property(p => p.IpAddress).HasMaxLength(100).IsUnicode(false).IsRequired();
            builder.Property(p => p.VehicleId).IsRequired();
            builder.Property(p => p.RequestCount).IsRequired();
            #endregion

            #region Indexes
            builder.HasIndex(p => p.IpAddress).IsUnique(false);
            builder.HasIndex(p => p.VehicleId).IsUnique(false);
            #endregion

            #region Filter
            builder.HasQueryFilter(p => !p.IsDeleted);
            #endregion
        }
    }
}
