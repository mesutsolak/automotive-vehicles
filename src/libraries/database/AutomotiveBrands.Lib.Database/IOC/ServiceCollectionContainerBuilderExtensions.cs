namespace AutomotiveBrands.Lib.Database.IOC
{
    public static class ServiceCollectionContainerBuilderExtensions
    {
        /// <summary>
        /// Add postgre sql server db context
        /// </summary>
        /// <typeparam name="TDbContext">type of db dbcontext</typeparam>
        /// <param name="services">type of built-in service collection interface</param>
        /// <param name="contextName">database context class name</param>
        /// <param name="isSplitQuery">split query behavior</param>
        /// <param name="enabledLazyLoading">enabled lazy loading</param>
        /// <seealso cref="https://docs.microsoft.com/en-us/ef/core/dbcontext-configuration/"/>
        /// <returns>type of built-in service collection</returns>
        /// <exception cref="ArgumentNullException">when the service provider cannot be built</exception>
        /// <exception cref="InvalidOperationException">If the container cannot invoke the configuration interface</exception>
        public static IServiceCollection AddPostgreSqlServerDbContext<TDbContext>(this IServiceCollection services, string contextName, bool isSplitQuery = true) where TDbContext : DbContext
        {
            IServiceProvider serviceProvider = services.BuildServiceProvider();
            ArgumentNullException.ThrowIfNull(serviceProvider, nameof(serviceProvider));

            IWebHostEnvironment webHostEnvironment = serviceProvider.GetRequiredService<IWebHostEnvironment>();
            IConfiguration configuration = serviceProvider.GetRequiredService<IConfiguration>();

            services.AddDbContextPool<TDbContext>(contextOptions =>
            {
                contextOptions.ConfigureWarnings(warnings => warnings.Ignore(CoreEventId.DetachedLazyLoadingWarning));
                contextOptions.ConfigureWarnings(warnings => warnings.Ignore(CoreEventId.PossibleIncorrectRequiredNavigationWithQueryFilterInteractionWarning));
                contextOptions.ConfigureWarnings(warnings => warnings.Ignore(CoreEventId.SensitiveDataLoggingEnabledWarning));
                contextOptions.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.BoolWithDefaultWarning));
                contextOptions.ConfigureWarnings(warnings => warnings.Ignore(CoreEventId.RowLimitingOperationWithoutOrderByWarning));
                contextOptions.LogTo(Log.Logger.Warning, LogLevel.Warning);
                contextOptions.EnableSensitiveDataLogging(!webHostEnvironment.IsProduction());
                contextOptions.UseLoggerFactory(LoggerFactory.Create(builder =>
                {
                    if (webHostEnvironment.EnvironmentName.Equals("Localhost"))
                    {
                        builder.AddConsole();
                    }
                }));

                contextOptions.UseLazyLoadingProxies(false);
                contextOptions.UseNpgsql(configuration.GetConnectionString(contextName), sqlOptions =>
                {
                    sqlOptions.MigrationsAssembly(typeof(TDbContext).Assembly.FullName);
                    sqlOptions.CommandTimeout(Convert.ToInt16(TimeSpan.FromSeconds(60).TotalSeconds));

                    if (isSplitQuery)
                    {
                        sqlOptions.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                    }

                });
            });

            if (!webHostEnvironment.IsProduction())
            {
                services.AddDatabaseDeveloperPageExceptionFilter();
            }

            services.TryAddScoped(typeof(IEfEntityRepository<>), typeof(EfEntityRepository<>));
            services.TryAddScoped<IBaseUnitOfWork, BaseUnitOfWork>();

            return services;
        }
    }
}
