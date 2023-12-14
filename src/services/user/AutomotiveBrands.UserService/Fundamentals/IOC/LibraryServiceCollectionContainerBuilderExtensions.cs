namespace AutomotiveBrands.UserService.Fundamentals.IOC
{
    internal static partial class LibraryServiceCollectionContainerBuilderExtensions
    {
        internal static void AddLibraries(this IServiceCollection services)
        {
            services.AddController();

            services.AddApiBehaviorOptions();
            services.AddValidation<Program>();

            services.AddApiVersioningWithProvider(new CustomizedResponseProvider());
            services.AddRateLimitConfiguration();
            services.AddGzipResponseCompression();

            services.AddRouteSettings();
            services.AddHostingSetting();
            services.AddHelpers();
            services.AddSwagger(true);
        }
    }
}
