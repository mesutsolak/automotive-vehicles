namespace AutomotiveBrands.Lib.Database.Configurations
{
    public class BaseHistoricEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseHistoricEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.ToTable(typeof(TEntity).Name.ToLowerInvariant(), DatabaseSchema.Default);
            builder.HasKey(p => p.Id);

            builder.Property(p => p.CreatedDate).HasDefaultValueSql("now()").IsRequired();
            builder.Property(p => p.UpdatedDate).HasDefaultValueSql("now()").IsRequired();
        }
    }
}
