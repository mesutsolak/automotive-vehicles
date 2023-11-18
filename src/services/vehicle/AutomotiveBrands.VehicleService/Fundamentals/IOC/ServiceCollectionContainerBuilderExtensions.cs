namespace AutomotiveBrands.VehicleService.Fundamentals.IOC
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
            services.TryAddScoped<DbContext, VehicleDbContext>();
            services.TryAddScoped<IVehicleUnitOfWork, VehicleUnitOfWork>();
            services.TryAddScoped<IVehicleRepository, VehicleRepository>();
            services.TryAddScoped<IVehicleDetailRepository, VehicleDetailRepository>();
        }
    }
}
