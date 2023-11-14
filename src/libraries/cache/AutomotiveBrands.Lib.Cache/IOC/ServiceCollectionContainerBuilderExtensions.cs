namespace AutomotiveBrands.Lib.Cache.IOC
{
    public static class ServiceCollectionContainerBuilderExtensions
    {
        /// <summary>
        /// Add redis service
        /// </summary>
        /// <param name="services">type of built-in service collection interface</param>
        /// <seealso cref="https://redis.io/"/>
        /// <returns>type of built-in service collection interface</returns>
        /// <exception cref="ArgumentNullException">when the service provider cannot be built</exception>
        /// <exception cref="InvalidOperationException">if your application settings file does not contain redis configurations</exception>
        public static IServiceCollection AddRedisService(this IServiceCollection services)
        {
            IServiceProvider serviceProvider = services.BuildServiceProvider();
            ArgumentNullException.ThrowIfNull(serviceProvider);

            IConfiguration configuration = serviceProvider.GetRequiredService<IConfiguration>();
            services.Configure<RedisServerSetting>(configuration.GetRequiredSection(nameof(RedisServerSetting)));
            services.TryAddSingleton<IRedisServerSetting>(provider => provider.GetRequiredService<IOptions<RedisServerSetting>>().Value);

            serviceProvider = services.BuildServiceProvider();
            ArgumentNullException.ThrowIfNull(serviceProvider);

            IRedisServerSetting redisServerSetting = serviceProvider.GetRequiredService<IRedisServerSetting>();
            
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.TryAddSingleton<IConnectionMultiplexer>(provider => ConnectionMultiplexer.Connect(new ConfigurationOptions
            {
                EndPoints = { redisServerSetting.ConnectionString },
                AbortOnConnectFail = redisServerSetting.AbortOnConnectFail,
                AsyncTimeout = redisServerSetting.AsyncTimeOutMilliSecond,
                ConnectTimeout = redisServerSetting.ConnectTimeOutMilliSecond,
                User = redisServerSetting.Username,
                Password = redisServerSetting.Password,
                DefaultDatabase = redisServerSetting.DefaultDatabase,
                AllowAdmin = redisServerSetting.AllowAdmin
            }));

            services.TryAddSingleton(provider =>
            {
                IConnectionMultiplexer connectionMultiplexer = provider.GetRequiredService<IConnectionMultiplexer>();
                return connectionMultiplexer.GetServer(redisServerSetting.ConnectionString);
            });

            services.TryAddSingleton<IRedisService>(provider =>
            {
                IConnectionMultiplexer connectionMultiplexer = provider.GetRequiredService<IConnectionMultiplexer>();
                IDatabase database = connectionMultiplexer.GetDatabase(redisServerSetting.DefaultDatabase);
                IServer server = connectionMultiplexer.GetServer(redisServerSetting.ConnectionString);

                return new RedisApiManager(database, server, redisServerSetting.DefaultDatabase);
            });

            return services;
        }
    }
}
