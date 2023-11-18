namespace AutomotiveBrands.VehicleService.Fundamentals.IOC
{
    internal static partial class LibraryServiceCollectionContainerBuilderExtensions
    {
        internal static void AddLibraries(this IServiceCollection services)
        {
            services.AddController();

            services.AddApiBehaviorOptions();
            services.AddValidation<Program>();

            //services.AddRedisService();

            services.AddRouteSettings();
            services.AddSwagger(true);
        }
    }
}
