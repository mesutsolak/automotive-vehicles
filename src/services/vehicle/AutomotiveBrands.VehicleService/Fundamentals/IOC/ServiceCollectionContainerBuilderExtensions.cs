namespace AutomotiveBrands.VehicleService.Fundamentals.IOC
{
    internal static partial class ServiceCollectionContainerBuilderExtensions
    {
        //internal static void AddMediatR(this IServiceCollection services)
        //{
        //    var assembly = Assembly.GetExecutingAssembly();
        //    services.AddMediatR(assembly);
        //    services.AddValidatorsFromAssembly(assembly, ServiceLifetime.Transient);

        //    services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        //    services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));
        //    services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
        //}

        //internal static void AddRepositories(this IServiceCollection services)
        //{
        //    services.TryAddScoped<IUserUnitOfWork, UserUnitOfWork>();
        //    services.TryAddScoped<IUserRepository, UserRepository>();
        //    services.TryAddScoped<IUserDetailRepository, UserDetailRepository>();
        //    services.TryAddScoped<IUserActivityRepository, UserActivityRepository>();
        //    services.TryAddScoped<IGuestRepository, GuestRepository>();
        //    services.TryAddScoped<IStatusMessageRepository, StatusMessageRepository>();
        //}

        //internal static void AddServices(this IServiceCollection services)
        //{
        //    services.TryAddSingleton<ITokenService, TokenManager>();
        //    services.TryAddSingleton<IKpsService, KpsManager>();
        //}
    }
}
