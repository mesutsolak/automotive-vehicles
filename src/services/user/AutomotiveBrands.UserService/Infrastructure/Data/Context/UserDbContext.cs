namespace AutomotiveBrands.UserService.Infrastructure.Data.Context
{
    public sealed class UserDbContext : DbContext, IUserDbContext
    {
        public UserDbContext(DbContextOptions options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Preference> Preferences { get; set; }

        public class UserDbContextDesignFactory : IDesignTimeDbContextFactory<UserDbContext>
        {
            public UserDbContextDesignFactory()
            {
            }

            public UserDbContext CreateDbContext(string[] args)
            {
                string environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
                var configurationRoot = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                   .AddJsonFile($"appsettings.{environmentName}.json", optional: true, reloadOnChange: true)
                   .Build();

                DbContextOptionsBuilder dbContextOptionsBuilder = new();
                dbContextOptionsBuilder.UseNpgsql(configurationRoot.GetConnectionString(nameof(UserDbContext)));

                return new UserDbContext(dbContextOptionsBuilder.Options);
            }
        }
    }
}
