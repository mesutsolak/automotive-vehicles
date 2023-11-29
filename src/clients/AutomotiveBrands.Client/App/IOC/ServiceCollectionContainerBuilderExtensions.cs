namespace AutomotiveBrands.Client.App.IOC
{
    internal static partial class ServiceCollectionContainerBuilderExtensions
    {
        internal static IServiceCollection AddBuiltInServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.TryAddScoped<IAutomotiveBrandsService, AutomotiveBrandsService>();

            return serviceCollection;
        }
        public static IHttpClientBuilder AddAutomotiveBrandsService(this IServiceCollection services)
        {
            IServiceProvider serviceProvider = services.BuildServiceProvider();
            ArgumentNullException.ThrowIfNull(serviceProvider);

            IConfiguration configuration = serviceProvider.GetRequiredService<IConfiguration>();
            services.Configure<AutomotiveBrandsSetting>(configuration.GetRequiredSection(nameof(AutomotiveBrandsSetting)));
            services.TryAddSingleton<IAutomotiveBrandsSetting>(provider => provider.GetRequiredService<IOptions<AutomotiveBrandsSetting>>().Value);

            serviceProvider = services.BuildServiceProvider();
            ArgumentNullException.ThrowIfNull(serviceProvider);

            var automotiveBrandsSetting = serviceProvider.GetRequiredService<IAutomotiveBrandsSetting>();

            return services.AddHttpClient(Clients.AutomotiveBrands, configureClient =>
            {
                configureClient.BaseAddress = new Uri(automotiveBrandsSetting.BaseAddress);
                configureClient.Timeout = TimeSpan.FromSeconds(automotiveBrandsSetting.TimeOutInSeconds);
                configureClient.DefaultRequestHeaders.Accept.Clear();
                configureClient.DefaultRequestHeaders.ExpectContinue = false;
                configureClient.DefaultRequestHeaders.Add(HeaderNames.AcceptLanguage, "tr-TR");
                configureClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(MediaTypeNames.Application.Json));
            });
        }
    }
}