namespace AutomotiveBrands.Lib.HealthCheck.IOC
{
    public static class ServiceCollectionContainerBuilderExtensions
    {
        /// <summary>
        /// Add custom health checks
        /// </summary>
        /// <param name="services">type of built-in service collection interface</param>
        /// <seealso cref="https://docs.microsoft.com/en-us/aspnet/core/host-and-deploy/health-checks?view=aspnetcore-6.0"/>
        /// <returns>type of built-in service collection interface</returns>
        /// <exception cref="ArgumentNullException">when the service provider cannot be built</exception>
        /// <exception cref="InvalidOperationException">if your application settings file does not contain health check configurations</exception>
        public static IServiceCollection AddCustomHealthChecks(this IServiceCollection services)
        {
            IServiceProvider serviceProvider = services.BuildServiceProvider();
            ArgumentNullException.ThrowIfNull(serviceProvider, nameof(serviceProvider));

            IWebHostEnvironment webHostEnvironment = serviceProvider.GetRequiredService<IWebHostEnvironment>();
            if (webHostEnvironment.EnvironmentName.Equals("Localhost"))
                return services;

            serviceProvider = PrepareServiceProvider(services);
            ArgumentNullException.ThrowIfNull(serviceProvider, nameof(serviceProvider));

            IHealthChecksBuilder healthChecksBuilder = services.AddHealthChecks();
            ArgumentNullException.ThrowIfNull(healthChecksBuilder, nameof(healthChecksBuilder));

            IHealthChecksCommonSetting healthChecksCommonSetting = serviceProvider.GetRequiredService<IHealthChecksCommonSetting>();

            IConfiguration configuration = serviceProvider.GetRequiredService<IConfiguration>();
            ArgumentNullException.ThrowIfNull(configuration, nameof(configuration));

            healthChecksBuilder.AddRedisCheck(configuration);
            healthChecksBuilder.AddNpgSqlDatabaseChecks(configuration);
            healthChecksBuilder.AddSystemConfigurationCheck();
            healthChecksBuilder.AddRabbitMqCheck();

            services.AddHealthChecksUI(setupSettings =>
            {
                setupSettings.SetEvaluationTimeInSeconds(healthChecksCommonSetting.EvaluationTimeInSeconds);
                setupSettings.SetApiMaxActiveRequests(healthChecksCommonSetting.ApiMaxActiveRequests);
                setupSettings.MaximumHistoryEntriesPerEndpoint(healthChecksCommonSetting.MaximumHistoryEntriesPerEndpoint);
                setupSettings.AddWebhookNotification(
                    name: healthChecksCommonSetting.Name,
                    uri: healthChecksCommonSetting.Url,
                    payload: healthChecksCommonSetting.Payload,
                    restorePayload: healthChecksCommonSetting.RestorePayload);

            }).AddInMemoryStorage();

            return services;
        }

        private static IServiceProvider PrepareServiceProvider(IServiceCollection services)
        {
            ServiceProvider serviceProvider = services.BuildServiceProvider();
            ArgumentNullException.ThrowIfNull(serviceProvider, nameof(serviceProvider));

            IConfiguration configuration = serviceProvider.GetRequiredService<IConfiguration>();

            services.Configure<HealthChecksCommonSetting>(configuration.GetRequiredSection(nameof(HealthChecksCommonSetting)));
            services.TryAddSingleton<IHealthChecksCommonSetting>(provider => provider.GetRequiredService<IOptions<HealthChecksCommonSetting>>().Value);

            serviceProvider = services.BuildServiceProvider();
            ArgumentNullException.ThrowIfNull(serviceProvider, nameof(serviceProvider));

            return serviceProvider;
        }
    }
}
