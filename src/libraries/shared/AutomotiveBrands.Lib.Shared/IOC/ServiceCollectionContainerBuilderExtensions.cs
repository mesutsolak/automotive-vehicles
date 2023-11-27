namespace AutomotiveBrands.Lib.Shared.IOC
{
    public static class ServiceCollectionContainerBuilderExtensions
    {
        public static IServiceCollection AddHelpers(this IServiceCollection services) 
        {
            services.TryAddTransient<IWebHelper, WebHelper>();

            return services;
        }
    }
}
