namespace AutomotiveAPI.VehicleService.Infrastructure.Data.Context
{
    public sealed class VehicleDbContext : DbContext, IVehicleDbContext
    {
        public VehicleDbContext(DbContextOptions options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<VehicleDetail> VehicleDetails { get; set; }

        public class VehicleContextDesignFactory : IDesignTimeDbContextFactory<VehicleDbContext>
        {
            public VehicleContextDesignFactory()
            {
            }

            public VehicleDbContext CreateDbContext(string[] args)
            {
                string environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
                var configurationRoot = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                   .AddJsonFile($"appsettings.{environmentName}.json", optional: true, reloadOnChange: true)
                   .Build();

                DbContextOptionsBuilder dbContextOptionsBuilder = new();
                dbContextOptionsBuilder.UseNpgsql(configurationRoot.GetConnectionString(nameof(VehicleDbContext)));

                return new VehicleDbContext(dbContextOptionsBuilder.Options);
            }
        }
    }
}
