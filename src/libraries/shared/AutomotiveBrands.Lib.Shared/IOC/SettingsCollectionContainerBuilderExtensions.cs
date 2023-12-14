namespace AutomotiveBrands.Lib.Shared.IOC
{
    public static class SettingsCollectionContainerBuilderExtensions
    {
        public static IServiceCollection AddHostingSetting(this IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();
            ArgumentNullException.ThrowIfNull(serviceProvider);

            var configuration = serviceProvider.GetRequiredService<IConfiguration>();
            services.Configure<HostingSetting>(configuration.GetRequiredSection(nameof(HostingSetting)));
            services.TryAddSingleton<IHostingSetting>(provider => provider.GetRequiredService<IOptions<HostingSetting>>().Value);

            return services;
        }
    }
}
