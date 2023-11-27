namespace AutomotiveBrands.Client.App.IOC
{
    internal static class SettingsCollectionContainerBuilderExtensions
    {
        //internal static IServiceCollection AddTurkuazSetting(this IServiceCollection services)
        //{
        //    var serviceProvider = services.BuildServiceProvider();
        //    ArgumentNullException.ThrowIfNull(serviceProvider);

        //    var configuration = serviceProvider.GetRequiredService<IConfiguration>();
        //    services.Configure<TurkuazSetting>(configuration.GetRequiredSection(nameof(TurkuazSetting)));
        //    services.TryAddSingleton<ITurkuazSetting>(provider => provider.GetRequiredService<IOptions<TurkuazSetting>>().Value);

        //    return services;
        //}

        //internal static IServiceCollection AddHostingSetting(this IServiceCollection services)
        //{
        //    var serviceProvider = services.BuildServiceProvider();
        //    ArgumentNullException.ThrowIfNull(serviceProvider);

        //    var configuration = serviceProvider.GetRequiredService<IConfiguration>();
        //    services.Configure<HostingSetting>(configuration.GetRequiredSection(nameof(HostingSetting)));
        //    services.TryAddSingleton<IHostingSetting>(provider => provider.GetRequiredService<IOptions<HostingSetting>>().Value);

        //    return services;
        //}
    }
}
