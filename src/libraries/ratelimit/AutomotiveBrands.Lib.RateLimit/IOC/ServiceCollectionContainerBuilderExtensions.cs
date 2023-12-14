namespace AutomotiveBrands.Lib.RateLimit.IOC
{
    public static class ServiceCollectionContainerBuilderExtensions
    {
        public static IServiceCollection AddRateLimitConfiguration(this IServiceCollection services)
        {
            IServiceProvider serviceProvider = services.BuildServiceProvider();
            ArgumentNullException.ThrowIfNull(serviceProvider);

            services.AddDistributedMemoryCache();

            IConfiguration configuration = serviceProvider.GetRequiredService<IConfiguration>();
            services.Configure<IpRateLimitOptions>(configuration.GetSection(nameof(IpRateLimitOptions)));
            services.Configure<IpRateLimitPolicies>(configuration.GetSection(nameof(IpRateLimitPolicies)));

            services.AddRedisRateLimiting();
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.TryAddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
            services.TryAddSingleton<IIpPolicyStore, DistributedCacheIpPolicyStore>();
            services.TryAddSingleton<IRateLimitCounterStore, DistributedCacheRateLimitCounterStore>();
            services.TryAddSingleton<IProcessingStrategy, AsyncKeyLockProcessingStrategy>();

            return services;
        }
    }
}
