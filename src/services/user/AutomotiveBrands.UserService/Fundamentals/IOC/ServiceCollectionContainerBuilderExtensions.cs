namespace AutomotiveBrands.UserService.Fundamentals.IOC
{
    internal static partial class ServiceCollectionContainerBuilderExtensions
    {
        internal static void AddMediatR(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddMediatR(assembly);
            services.AddValidatorsFromAssembly(assembly, ServiceLifetime.Transient);

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
        }

        internal static void AddRepositories(this IServiceCollection services)
        {
            services.TryAddScoped<DbContext, UserDbContext>();
            services.TryAddScoped<IUserUnitOfWork, UserUnitOfWork>();
            services.TryAddScoped<IPreferenceRepository, PreferenceRepository>();
        }

        internal static void AddHelpers(this IServiceCollection services)
        {
            services.TryAddScoped<IWebHelper, WebHelper>();
        }
    }
}
