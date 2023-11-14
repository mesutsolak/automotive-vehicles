namespace AutomotiveBrands.Lib.Database.Infrastructure.Extensions
{
    /// <summary>
    /// Migration manager extensions with microsoft sql server
    /// </summary>
    public static class MigrationManagerExtensions
    {
        /// <summary>
        /// Migrate database
        /// </summary>
        /// <typeparam name="TDbContext">type of db context</typeparam>
        /// <param name="webApplication">type of web application class</param>
        /// <returns>type of web application class</returns>
        public static async Task<WebApplication> MigrateDatabaseAsync<TDbContext>(this WebApplication webApplication) where TDbContext : DbContext
        {
            if (!webApplication.Environment.EnvironmentName.Equals("Todo"))
                return webApplication;

            await using AsyncServiceScope asyncServiceScope = webApplication.Services.CreateAsyncScope();
            IServiceProvider serviceProvider = asyncServiceScope.ServiceProvider;

            var loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();
            var logger = loggerFactory.CreateLogger(nameof(MigrationManagerExtensions));

            try
            {
                TDbContext dbContext = serviceProvider.GetRequiredService<TDbContext>();
                if (!dbContext.Database.ProviderName.Equals("Microsoft.EntityFrameworkCore.InMemory"))
                {
                    await dbContext.Database.MigrateAsync();
                    logger.LogInformation("Migration işlemi başarıyla tamamlandı.");
                }

                return webApplication;
            }
            catch (Exception exception)
            {
                logger.LogError(exception, "Migration işlemi hata ile sonuçlandı.");
                return webApplication;
            }

        }
    }
}
