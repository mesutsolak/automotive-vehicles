namespace AutomotiveBrands.Lib.HealthCheck.Checks
{
    internal static class NpgSqlConnectionHealthCheck
    {
        internal static IHealthChecksBuilder AddNpgSqlDatabaseChecks(this IHealthChecksBuilder healthChecksBuilder, IConfiguration configuration)
        {
            healthChecksBuilder.AddNpgSql(
                    connectionString: "connection string",
                    name: "[NPG SQL] - Yönetim Veri Tabanı",
                    failureStatus: HealthStatus.Unhealthy,
                    tags: new[] { "MSSQL Server", "ManagementDbContext", "Authentication" });

            healthChecksBuilder.AddNpgSql(
                  connectionString: "connection string",
                  name: "[NPG SQL] - Lastik Veri Tabanı",
                  failureStatus: HealthStatus.Unhealthy,
                  tags: new[] { "MSSQL Server", "TyreShopDbContext", "TyreShopDb" });

            return healthChecksBuilder;
        }
    }
}
