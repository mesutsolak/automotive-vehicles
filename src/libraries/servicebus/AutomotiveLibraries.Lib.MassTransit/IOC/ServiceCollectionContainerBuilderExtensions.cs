namespace AutomotiveBrands.Lib.MassTransit.IOC
{
    public static class ServiceCollectionContainerBuilderExtensions
    {
        public static IServiceCollection AddRabbitMq(this IServiceCollection services)
        {
            IServiceProvider serviceProvider = services.BuildServiceProvider();
            ArgumentNullException.ThrowIfNull(serviceProvider, nameof(serviceProvider));

            IConfiguration configuration = serviceProvider.GetRequiredService<IConfiguration>();
            services.Configure<RabbitMqSetting>(configuration.GetRequiredSection(nameof(RabbitMqSetting)));
            services.TryAddSingleton<IRabbitMqSetting>(provider => provider.GetRequiredService<IOptions<RabbitMqSetting>>().Value);

            return services;
        }
    }
}
